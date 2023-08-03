program PRZMVVWM
    use allocations
    use readinputs
    use constants_and_variables, ONLY: maxFileLength, inputfile,number_of_schemes, &
                                       number_of_scenarios,  First_time_through_wb, First_time_through_wpez,First_time_through_tpez,First_time_through_medians, &
                                       app_window_span, app_window_step, application_date, application_date_original, &
                                       is_adjust_for_rain, is_batch_scenario, scenario_batchfile , BatchFileUnit, run_id, app_window_counter,hold_for_medians, medians_conc 
    
    use waterbody_parameters, ONLY: read_waterbodyfile, get_pond_parameters, get_reservoir_parameters,waterbody_names,USEPA_reservoir,USEPA_pond, spraytable,itstpezwpez
    use clock_variables
	
    use outputprocessing, ONLY: write_medians
    use PRZM_VERSION
   ! use PRZM_part
    use initialization
    use VVWM_solution_setup
    use schemeload
    use utilities_1
    use plantgrowth
    use field_hydrology
    use chemical_transport
	use Output_From_Field
	use Pesticide_Applications
	use readbatchscenario
    use TPEZ_WPEZ

    implicit none

    integer :: length               !length of input file characters
    integer :: hh, i ,jj, kk,  iostatus
    logical :: error
    logical :: end_of_file, error_on_read
    logical :: run_tpez_wpez  !TRUE if USEPA_pond has just been simulated AND TPEZ/WPEZ run has been requested (i.e., istpezwpez==treue)
    character :: dummy
    character(len= 256) :: hold_run_id
    
    !################################################ 
    CALL CPU_TIME (cputime_begin)
    write (*,*) 'Start CPU Time',  cputime_begin
	
    call SYSTEM_CLOCK(c_count, c_rate, c_max)
    clock_time_0 = real(c_count)/real(c_rate)

	Cumulative_cpu_3 = 0.0
	
   !################################################ 
	
    First_time_through_wb   = .TRUE.  !used to write output file headers, so can keep all output writes in one place
    First_time_through_tpez = .TRUE.
    First_time_through_wpez = .TRUE.
    First_time_through_medians = .TRUE.
    
    
    call get_command_argument(1,inputfile,length)
    call przm_id                                     !Stamp the runstatus file 
	
	
    write(*,*) "Input file: ", trim(inputfile)
    call read_inputfile
    call chemical_manipulations
	
	
    write(*,*)    '************* Start PRZM-VVWM Scheme Loop *******************'

    !LOOP Description
    !Outermost (ii) is for info describing watershed and waterbody, At present, there is a dependency
        !on the watershed size and the PER/AREA output from the field. This means that a field output cannot be used for multiple waterbodies
        !A field must be run for each waterbody. Future work should look at removing this over-parameterization of the erosion routine, 
        !and that would allow a single PRZM run for all waterbodies
        !The dependency occurs in the hydraulic length which is area dependent AND in the MUSS, MUSL equations. 
    !Middle Loop (i) is for Application Schemes
    !Inner Loop (j) is for scenarios
     
	 write(*,*) '******************** Start Waterbody Loop ***************************'

     do hh = 1, size(waterbody_names)
         run_tpez_wpez = .FALSE.
         
         select case   (waterbody_names(hh))
         case (USEPA_reservoir)
             call get_reservoir_parameters
         case (USEPA_pond)
              call get_pond_parameters
              If (itstpezwpez) then
                 run_tpez_wpez = .TRUE.
              end if
         case default
              call read_waterbodyfile(hh)  
         end select
         
         write(*,*) 'Doing Water Body: ', trim(waterbody_names(hh))
		 

	     write(*,*) '**** Start Scheme Loop *********************************************'
		 
         do i = 1, number_of_schemes
			 Write(*,*) 'Doing Scheme No. ', i
			 
             call set_chemical_applications(i) !gets the individual application scheme from the whole scheme table, non scenario specfic 
							
	         write(*,*) '********** Start Scenario Loop *************************************'
				           
            if(is_batch_scenario(i)) then
               write(*,'("Batch Scenario File: ", A100) ')   scenario_batchfile(i)
               open (Unit = BatchFileUnit, FILE=scenario_batchfile(i),STATUS='OLD', IOSTAT= iostatus ) 
               read(BatchFileUnit,*) dummy  ! skip header
               end_of_file = .FALSE. !reset the batch scenario reading
               error_on_read = .FALSE.
            end if    
       
            kk=0
            
            do !scenario do loop
               !Loop controled by either the number of files in the batch or by the number of scenarios read in from input file
               kk=kk+1
               write(*,*) 'Doing scenario ', KK
               if( is_batch_scenario(i)) then
                       call read_batch_scenarios(BatchFileUnit, end_of_file, error_on_read)

                        !*****ERROR and EOF CHECKING ON SCENARIO BATCH FILE ****************
                        if(end_of_file) then
                           close(BatchFileUnit)
                           write(*,*) 'end of batch scenario read, exit after completing the run'
                           exit  !exit scenario loop
                        end if
                                                 
                        if (error_on_read)  then  
                               write(*,*) 'bad scenario # ', kk
                               cycle                       
                        end if 
                        !*****END ERROR CHECKING ON SCENARIO BATCH FILE ****************   
                             
               else    !*******use scenarios directly read into input
                       if (kk == number_of_scenarios(i) + 1) exit  !end of scenario list from gui inputs
                       call read_scenario_file(i,kk, error)
                       
                       if (error) then 
				           Write(*,*) 'exiting scenario loop due to scenario open problem'
				           cycle   !error, try next scenario in scheme
                       end if   
                   
               end if 
                     
                                write (*,*) '###################################################'	 
                                CALL CPU_TIME (time_1)
                                write (*,*) 'cpu time scenario start  ',time_1- cputime_begin
                                write (*,*) '###################################################'			   

               call Read_Weatherfile !this reads the new format weather file
               		   
                                write (*,*) '###################################################'	 
                                CALL CPU_TIME (time_1)
                                write (*,*) 'cpu time read weather ',time_1- cputime_begin
                                write (*,*) '###################################################'			   

               CALL INITL    !initialize and ALLOCATIONS przm variables  

                             write (*,*) '###################################################'	 
                             CALL CPU_TIME (time_1)
                             write (*,*) 'cpu time do initialization',time_1- cputime_begin
                             write (*,*) '###################################################'	               
               

               Call Crop_Growth
			   call hydrology_only
		   
               !soil temp is good here
               
               write(*,*) 'Start allocations'
               call allocation_for_VVWM
			   			   
			   write(*,*) '****************** Start App Loop **********************************'

			   app_window_counter = 0  !use this to track app window to find medians
               hold_for_medians = 0.0  !use this to hold data for medians
               medians_conc = 0.0
               do jj = 0, app_window_span(i), app_window_step(i) 
				     application_date= application_date_original + jj
                     app_window_counter = app_window_counter +1 
                    call make_run_id (i,kk, hh,jj) !makes a string that can be used for identifying output scheme#_scenario#_scenarioname      
                     

					 !"Rain Fast" Option
					 write(*,*) "Adjust applications for rain?", is_adjust_for_rain
					 if (is_adjust_for_rain) call adjust_application_dates_for_weather
					 
					 call chem_transport_onfield
					 
                                write (*,*) '###################################################'	 
                                CALL CPU_TIME (time_1)
                                write (*,*) 'cpu time chen xport ',time_1- cputime_begin
                                write (*,*) '###################################################'					 
					 
					 call groundwater
					 
                              write (*,*) '###################################################'	 
                              CALL CPU_TIME (time_1)
                              write (*,*) 'cpu time gw  ',time_1- cputime_begin
                              write (*,*) '###################################################'					 

                      call VVWM 
                      
                      
                      if (run_tpez_wpez) then !only do TPEZ WPEZ if its a pond run
                               hold_run_id = run_id
                          
                               run_id = trim(hold_run_id) //"_WPEZ"
                               call wpez  
                               run_id = trim(hold_run_id) //"_TPEZ"    
                               
                               write(*,*) 'TPEZ ID ', trim(run_id)
                               call tpez(i)  !need to send in scheme to find drift
                      end if
                      

                              write (*,*) '###################################################'	 
                              CALL CPU_TIME (time_1)
                              write (*,*) 'cpu time vvwm ',time_1- cputime_begin
                              write (*,*) '###################################################'					 				 
               end do    
			   
               call find_medians (app_window_counter, 10, hold_for_medians, medians_conc)  
               call write_medians
               
               
               call deallocate_scenario_parameters
			   
                             write (*,*) '###################################################'	 
                             CALL CPU_TIME (time_1)
                             write (*,*) 'cpu time deallocate  ',time_1- cputime_begin
                             write (*,*) '###################################################'			   
	
            end do  !END SCENARIO LOOP  kk 
            

                            write (*,*) '###################################################'	 
                            CALL CPU_TIME (time_1)
                            write (*,*) 'cpu time vvwm done      ',time_1- cputime_begin
                            write (*,*) '###################################################'				
			            
        
            call deallocate_application_parameters !allocations are done in set_chmical_applications, need to deallocatte for next scheme       
            write(*,*) '*****************************Done with scheme ', i    
                
                             write (*,*) '###################################################'	 
                             CALL CPU_TIME (time_1)
                             write (*,*) 'cpu time, scheme   ',time_1- cputime_begin, kk
                             write (*,*) '###################################################'			
			
		 end do  !End scheme Loop, i
		 
                            write (*,*) '###################################################'	 
                            CALL CPU_TIME (time_1)
                            write (*,*) 'cpu time, waterbody   ',time_1- cputime_begin, hh
                            write (*,*) '###################################################'
		                 
		 deallocate (spraytable )
		 
	 end do !End Waterbody/Watershed Loop

                              write (*,*) '###################################################'	 
                              CALL CPU_TIME (time_1)
                              write (*,*) 'End Proram cpu time   ',time_1- cputime_begin
                              write (*,*) '###################################################'  	 
	
                              call SYSTEM_CLOCK(c_count, c_rate, c_max)
                              clock_time = real(c_count)/real(c_rate)
                              write (*,*) 'Total clock time = ',clock_time  - clock_time_0 
                              write (*,*) 'tridiag', Cumulative_cpu_3
                              write (*,*) '###################################################'  	

end program PRZMVVWM