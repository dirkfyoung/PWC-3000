program PRZMVVWM
    use allocations
    use readinputs
    use constants_and_variables, ONLY: maxFileLength, inputfile,number_of_schemes, &
             number_of_scenarios,  First_time_through_wb, First_time_through_wpez,First_time_through_tpez,First_time_through_medians, &
             app_window_span, app_window_step, application_date, application_date_original, &
             is_adjust_for_rain, is_batch_scenario, scenario_batchfile , BatchFileUnit, app_window_counter, &
             First_time_through_medians_wpez, First_time_through_medians_tpez
    
    use waterbody_parameters, ONLY: read_waterbodyfile, get_pond_parameters, get_reservoir_parameters,waterbody_names,USEPA_reservoir,USEPA_pond, spraytable,itstpezwpez
    use clock_variables
	
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
!	use readbatchscenario
    use TPEZ_WPEZ
    use process_medians, ONLY: calculate_medians
    use TPEZ_spray_initialization, ONLY:tpez_drift_finalize, set_tpez_spray
    implicit none

    integer :: length               !length of input file characters
    integer :: hh, i ,jj, kk,  iostatus
    logical :: error
    logical :: end_of_file, error_on_read
    logical :: run_tpez_wpez  !TRUE if USEPA_pond has just been simulated AND TPEZ/WPEZ run has been requested (i.e., istpezwpez==treue)
    character :: dummy
    character(LEN=20) ::message

    !################################################ 
    CALL CPU_TIME (cputime_begin)
    
    call SYSTEM_CLOCK(c_count, c_rate, c_max)
    clock_time_0 = real(c_count)/real(c_rate)
	Cumulative_cpu_3 = 0.0
	
   !################################################ 
	
    First_time_through_wb   = .TRUE.  !ARRAY of 3 parent, deg1, deg2, used to write output file headers
    First_time_through_tpez = .TRUE.
    First_time_through_wpez = .TRUE.

    First_time_through_medians_wpez = .TRUE. 
    First_time_through_medians_tpez = .TRUE.
    
    call get_command_argument(1,inputfile,length)
    call przm_id                                     !Stamp the runstatus file 
		
    call read_inputfile
    call chemical_manipulations
	
    !LOOP Description
    !Outermost (ii) is for info describing watershed and waterbody, At present, there is a dependency
        !on the watershed size and the PER/AREA output from the field. This means that a field output cannot be used for multiple waterbodies
        !A field must be run for each waterbody. Future work should look at removing this over-parameterization of the erosion routine, 
        !and that would allow a single PRZM run for all waterbodies
        !The dependency occurs in the hydraulic length which is area dependent AND in the MUSS, MUSL equations. 
    !Middle Loop (i) is for Application Schemes
    !Inner Loop (j) is for scenarios
     

     do hh = 1, size(waterbody_names)
  
         run_tpez_wpez = .FALSE.
         First_time_through_medians = .TRUE.     !we want a separate file for each median (move this uop if all in one file, but file has waterbody name
         
         select case   (waterbody_names(hh))       !note:   waterbody spray drift table is loaded here (tpez will need different table)
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

		 Write(*,*) 'Doing waterbody: ',  trim(waterbody_names(hh))
         
         schemeloop: do i = 1, number_of_schemes
			 Write(*,*) 'Doing Scheme No. ', i 
			 
             !*****************************************************************
             !open and check to see if we have a batch scenario file is present
             if(is_batch_scenario(i)) then
                write(*,'(" Batch Scenario File: ", A) ') scenario_batchfile(i)
                open (Unit = BatchFileUnit, FILE=scenario_batchfile(i),STATUS='OLD', IOSTAT= iostatus ) 
                
                if(iostatus /= 0) then
                    write(*,*) "Can't find scenario batch file for scheme ",i 
                    write(*,*) "Skip to next scheme"
                    cycle schemeloop
                end if
                
                read(BatchFileUnit,*) dummy  ! skip header
                end_of_file = .FALSE. !reset the batch scenario reading
                error_on_read = .FALSE.
             end if    
            !*********************************************************************   
             
             
             
             
             
             !*******************************************************************
             !will use spray table in here --need to make spray table correct if changed by tpez
             call set_chemical_applications(i) !gets the individual application scheme from the whole scheme table, non scenario specfic 
        
             !If running TPEZ, set the unchanging (with scheme) parameters here like spraydrift
             call set_tpez_spray(i)  
             !*******************************************************************
             

             
             
            kk=0 !index for scenario loop
            
            do !scenario do loop
               !Loop controled by either the number of files in the batch or by the number of scenarios read in from input file
               kk=kk+1
               if( is_batch_scenario(i)) then
                    call read_batch_scenarios(BatchFileUnit, end_of_file, error_on_read)

                     !*****ERROR and EOF CHECKING ON SCENARIO BATCH FILE ****************
                     if(end_of_file) then
                        close(BatchFileUnit)
                        write(*,*) 'end of batch scenario read, exit after completing the run'
                        exit  !exit scenario loop
                     end if
                                              
                     if (error_on_read)  then  
                            write(*,*) 'bad scenario line # ', kk
                            cycle                       
                     end if 
                     !*****END ERROR CHECKING ON SCENARIO BATCH FILE ****************       
                     
               else    !*******use scenarios directly read into input
                     if (kk == number_of_scenarios(i) + 1) exit  !end of scenario list from gui inputs
                     call read_scenario_file(i,kk, error)
                     
                     if (error) then 
				         Write(*,*)  'Skipping scenario loop due to scenario open problem'
				         cycle   !error, try next scenario in scheme
                     end if                    
               end if 

               call Read_Weatherfile(error) !this reads the new format weather file	  
                    if (error) then 
				         Write(*,'(A59, I4)') ' Skipping scenario due to weather file problem, Scenario # ', kk
				         cycle   !error, try next scenario in scheme
                     end if 
               
               
               call INITL    !initialize and ALLOCATIONS przm variables  (also sets application and drift)    
               !set scenario-dependent TPEZ drift here
               
               call Crop_Growth              
			   call hydrology_only
               call allocation_for_VVWM
               
               call tpez_drift_finalize !must be called after INITL because need to know total applications
               
			   app_window_counter = 0  !use this to track app window to find medians
               do jj = 0, app_window_span(i), app_window_step(i)   
    
                     call reset_initial_masses
                   
				     application_date= application_date_original + jj
                    
                     
                     app_window_counter = app_window_counter +1 
                     call make_run_id (i,kk, hh,jj) !makes a string that can be used for identifying output scheme#_scenario#_scenarioname      
                    
					 !"Rain Fast" Option
					 if (is_adjust_for_rain) call adjust_application_dates_for_weather
					 
					 call chem_transport_onfield
					 call groundwater	
                     
                     call VVWM 
                        
                     if (run_tpez_wpez) then !only do TPEZ WPEZ if its a pond run
                         call wpez     !drift is same as pond noi need to recalculate
                         call tpez(i)  !need to send in scheme number to find drift
                     end if                     
               end do    
               
               call scenario_hydrolgy_summary
               
               !process application date window into medians      
               call calculate_medians(app_window_counter,run_tpez_wpez )
               
               call deallocate_scenario_parameters		   

            end do  !END SCENARIO LOOP  kk 
            
             
            call deallocate_application_parameters !allocations are done in set_chmical_applications, need to deallocatte for next scheme 
              
            write (message, '(A17,I3)') 'cpu time, scheme ', i
            call time_check(message)                

		 end do schemeloop                 !End scheme Loop
		 
		 deallocate (spraytable )
		 
     end do !End Waterbody/Watershed Loop
     
 !*******************************************    
 call time_check('End program cpu time ')   	
 call SYSTEM_CLOCK(c_count, c_rate, c_max)
 clock_time = real(c_count)/real(c_rate)
 write (*,*) 'Total clock time = ',clock_time  - clock_time_0 

 
end program PRZMVVWM