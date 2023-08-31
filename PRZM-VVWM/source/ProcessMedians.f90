module process_medians
    implicit none
    
    
    contains
    
    subroutine calculate_medians(app_window_counter, run_tpez_wpez)
          use constants_and_variables, ONLY: nchem, number_medians, hold_for_medians_wb, hold_for_medians_wpez, hold_for_medians_tpez,  &
              hold_for_medians_daughter, hold_for_medians_grandaughter, First_time_through_medians,median_unit,run_id, &
              median_daughter_unit,median_grandaughter_unit ,median_unit_wpez, median_unit_tpez,median_daughter_unit_wpez,median_grandaughter_unit_wpez,&
              median_daughter_unit_tpez,median_grandaughter_unit_tpez
            
          use utilities_1, ONLY: find_medians
          use waterbody_parameters, ONLY: this_waterbody_name
          
          
          integer, intent(in) :: app_window_counter
          logical, intent(in) :: run_tpez_wpez
    
          integer :: i
          real    :: medians_temp(number_medians)        
          character(Len=50) :: localfilename
          
          
          !***** Open median file and write headers*******
 
          if (First_time_through_medians) then 
              !open a file and write header
               localfilename = "medians_" // trim(this_waterbody_name) // ".txt"
               open (UNIT= median_unit, FILE = localfilename, STATUS = 'UNKNOWN')
               write(median_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput,  GWpeak"))

               if (nchem>1) then !daughter
                   localfilename = "medians_deg1_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_daughter_unit, FILE = localfilename, STATUS = 'UNKNOWN')
                   write(median_daughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif
               
               if (nchem>2) then !grandaughter
                   localfilename = "medians_deg2_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_grandaughter_unit, FILE = localfilename, STATUS = 'UNKNOWN')
                   write(median_grandaughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif

               if (run_tpez_wpez) then
                  localfilename = 'Medians_wpez.txt'
                  open (UNIT= median_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                  write(median_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                  localfilename = 'Medians_tpez.txt'
                  open (UNIT= median_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                  write(median_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  if (nchem>1) then !daughter
                      localfilename = 'Medians_deg1_wpez.txt'
                      open (UNIT= median_daughter_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_daughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfilename = 'Medians_deg1_tpez.txt'
                      open (UNIT= median_daughter_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_daughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  endif
                  
                  
                  if (nchem>2) then !grandaughter
                      localfilename = 'Medians_deg2_wpez.txt'
                      open (UNIT= median_grandaughter_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_grandaughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfilename = 'Medians_deg2_tpez.txt'
                      open (UNIT= median_grandaughter_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_grandaughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"

                  endif
                  
                  

               end if
               
   
               
               First_time_through_medians = .FALSE.
          end if
               
 
          !*********Populate Open Median Files with Data************

          call find_medians (app_window_counter, number_medians, hold_for_medians_wb, medians_temp)             
          write(median_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  

          if (nchem>1) then !daughter
              call find_medians (app_window_counter, number_medians, hold_for_medians_daughter, medians_temp)             
              write(median_daughter_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
          end if
          
          if (nchem>2) then !grandaughter
              call find_medians (app_window_counter, number_medians, hold_for_medians_grandaughter, medians_temp)             
              write(median_grandaughter_unit, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
          end if
          

          
          !*******************************************
          
   
          
         !
         !if (run_tpez_wpez) then  !wpez needs its own call due to different capture also because its scenario run is same as pond                 
         !       call find_medians (app_window_counter, number_medians, hold_for_medians_wpez, medians_temp)  
         !       call write_medians_wpez(medians_temp, number_medians)
         !       
         !       call find_medians (app_window_counter, 1, hold_for_medians_tpez, medians_temp) 
         !       call write_medians_tpez(medians_temp(1))                              
         !end if
         
                !write(median_output_unit_tpez, '(A86, ",", G12.4 )') adjustl((adjustr(run_id)//"_median")), medians_input*0.892179


    end subroutine calculate_medians
    
   !subroutine write_medians_wpez(medians_input,number)
   !  use constants_and_variables, only: median_unit_wpez, First_time_through_medians_wpez, run_id
   !             implicit none
   !             integer, intent(in) :: number
   !             real, intent(in) :: medians_input(number)
   !             integer :: i
   !             if (First_time_through_medians_wpez) then 
   !                 !write header
   !                 open (UNIT= median_unit_wpez, FILE = 'Medians_wpez.txt', STATUS = 'UNKNOWN')
   !                 write(median_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"
   !   
   !                 First_time_through_medians_wpez = .FALSE.
   !             end if
   !             
   !             write(median_unit_wpez, '(A86, 10(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_input(i), i=1, 9) 
   !             
   !          
   !end subroutine write_medians_wpez
     
     
   
   
     subroutine write_medians_tpez(medians_input)
     use constants_and_variables, only: median_unit_tpez, First_time_through_medians_tpez, run_id
                implicit none
                real, intent(in) :: medians_input
                integer :: i
                if (First_time_through_medians_tpez) then 
                    !write header
                    open (UNIT= median_unit_tpez, FILE = 'Medians_tpez.txt', STATUS = 'UNKNOWN')
                    write(median_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"
                    First_time_through_medians_tpez = .FALSE.
                end if
                
                write(median_unit_tpez, '(A86, ",", G12.4 )') adjustl((adjustr(run_id)//"_median")), medians_input*0.892179
             
     end subroutine write_medians_tpez
     

end module process_medians
    