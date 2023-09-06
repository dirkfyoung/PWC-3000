program PRZMVVWM
    use allocations
    use readinputs
    use constants_and_variables, ONLY: EchoFileUnit,maxFileLength, inputfile,number_of_schemes, number_of_scenarios, summaryoutputUnit, summary_outputfile, run_ID,scenario_names
    use PRZM_VERSION
    use PRZM_part
    use initialization
    use VVWM_solution_setup
    use schemeload
    use utilities_1
    
    implicit none
    integer :: ierror
    Character(Len=maxFileLength) :: filename !text report on the run status during runtme
    integer :: length !length of input file characters
    integer :: i , j
    logical error
    character (len=50):: scenarionumber
    
    
    
    call get_command_argument(1,inputfile,length)
    
    !RunStatus.txt records the operating status of PRZM and VVWM during runtime
    filename =  'RunStatus.txt'
    
    OPEN(Unit=EchoFileUnit,FILE=Filename,STATUS='UNKNOWN',IOSTAT=ierror)  
    
    summary_outputfile = 'summary_ouput.txt'
    Open(unit=summaryoutputUnit,FILE= trim(summary_outputfile),Status='unknown')  
    
    call przm_id(EchoFileUnit) !Stamp the runstatus file 
    
    write(echofileunit, *) "Input file: ", trim(inputfile)
    write(*,*) 'Runtime erros, if any'
    
    call read_inputfile

    !Scheme Loop
     write(EchoFileUnit,*)    '************* Start PRZM-VVWM Scheme Loop *******************'
    Do i = 1, number_of_schemes
  
        write(EchoFileUnit,*) '*************************************************************'
        write(EchoFileUnit,*) "Scheme " , i
        call set_chemical_applications(i) !gets the individual application scheme from the whole sceme table, non scenario spaecfic
          
        do j=1, number_of_scenarios(i)


            call make_run_id (i,j) !makes a string that can be used for identifying output scheme#_scenario#_scenarioname
            write(*,*) run_ID 
    
            call read_scenario_file(i,j, error)
            if (error) exit        

            call Read_Weatherfile  !this reads the new format weather file
        
            
         
            call PRZM5 
            
             call name_output_files
             !!For Now lets say USEPA Pond is selected
            !waterbody_id  = "USEPA_Pond"   
          
     

            call VVWM   
    
            call deallocate_scenario_parameters
            

        end do
        
        ! Do  Scenario Loop 
               
                
                !store Output (Sheme#, Scenario, p1,p2,p3....)
       
        
    
            ! call read_main_inputs
            ! call Read_Weatherfile  !this reads the new format weather file
            !
            !
            !!Here should be selection of water body, so we can initiate a loop for the various waterbody scenarios
     
     
        
                
        call deallocate_application_parameters !allocations are done in set_chmical_applications, need to deallocatte for next sceme
        
    end do

end program PRZMVVWM