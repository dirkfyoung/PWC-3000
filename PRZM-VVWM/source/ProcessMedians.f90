module process_medians
    implicit none
    
    
    contains
    
    subroutine calculate_medians(app_window_counter, run_tpez_wpez)
          use constants_and_variables, ONLY: nchem, number_medians, hold_for_medians_wb, hold_for_medians_wpez, hold_for_medians_tpez,  &
              hold_for_medians_daughter, hold_for_medians_grandaughter, hold_for_medians_WPEZ_daughter, hold_for_medians_TPEZ_daughter, &
              hold_for_medians_WPEZ_grandaughter,hold_for_medians_TPEZ_grandaughter , &
              First_time_through_medians,median_unit,run_id,hold_for_medians_eof, &
              median_daughter_unit,median_grandaughter_unit ,median_unit_wpez, median_unit_tpez,median_daughter_unit_wpez,median_grandaughter_unit_wpez,&
              median_daughter_unit_tpez,median_grandaughter_unit_tpez, Sediment_conversion_factor, family_name, working_directory,median_unit_eof , calc_eof
            
          use utilities_1, ONLY: find_medians
          use waterbody_parameters, ONLY: this_waterbody_name
          
          
          integer, intent(in) :: app_window_counter
          logical, intent(in) :: run_tpez_wpez
    
          integer :: i
          real    :: medians_temp(number_medians)        
          character(Len=1000) :: localfilename
          

          !**********Water Bodies File Open *****************
          if (First_time_through_medians) then 
              !open a file and write header
               localfilename = trim(working_directory) //trim(family_name) // "_medians_" // trim(this_waterbody_name) // ".txt"
               open (UNIT= median_unit, FILE = localfilename, STATUS = 'UNKNOWN')
               write(median_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(1)*1000.        
               write(median_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput,  GWpeak"))

               if (nchem>1) then !daughter
                   localfilename = trim(working_directory) //trim(family_name) //  "_medians_deg1_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_daughter_unit, FILE = localfilename, STATUS = 'UNKNOWN')
                   
                   write(median_daughter_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(2)*1000.
                   write(median_daughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif
               
               if (nchem>2) then !grandaughter
                   localfilename =  trim(working_directory) //trim(family_name) // "_medians_deg2_" // trim(this_waterbody_name) // ".txt"
                   open (UNIT= median_grandaughter_unit, FILE = localfilename, STATUS = 'UNKNOWN')
                   write(median_grandaughter_unit, '(''Benthic Conversion Factor             = '', G14.4E3,'' -Pore water (ug/L) to (total mass, ug)/(dry sed mass,kg)'')') Sediment_conversion_factor(3)*1000.
                   
                   write(median_grandaughter_unit, '(A225)') (("Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg, post_bt_avg,  throughput, GWpeak"))
               endif

               !**********TPEZ WPEZ Field File Open *****************
               if (run_tpez_wpez) then
                  localfilename = trim(working_directory) //trim(family_name) // '_medians_wpez.txt'
                  open (UNIT= median_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                  write(median_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                  localfilename = trim(working_directory) //trim(family_name) // '_medians_tpez.txt'
                  open (UNIT= median_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                  write(median_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"
                  
                  if (nchem>1) then !daughter
                      localfilename = trim(working_directory) //trim(family_name) // '_medians_deg1_wpez.txt'
                      open (UNIT= median_daughter_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_daughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfilename = trim(working_directory) //trim(family_name) // '_medians_deg1_tpez.txt'
                      open (UNIT= median_daughter_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_daughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"
                  endif
                  
                  if (nchem>2) then !grandaughter
                      localfilename =  trim(working_directory) //trim(family_name) // '_medians_deg2_wpez.txt'
                      open (UNIT= median_grandaughter_unit_wpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_grandaughter_unit_wpez,  '(A212)') "Run Information                                                                       ,  1-d avg   ,  365-d avg ,  Total avg ,  4-d avg   ,  21-d avg  ,  60-d avg  ,   B 1-day  ,  B 21-d avg,  Total System (lb/A)"

                      localfilename = trim(working_directory) // trim(family_name) // '_medians_deg2_tpez.txt'
                      open (UNIT= median_grandaughter_unit_tpez, FILE = localfilename, STATUS = 'UNKNOWN')
                      write(median_grandaughter_unit_tpez,  '(A93)') "Run Information                                                                       ,  lb/A"
                  endif
               end if
               
               !**********Edge of Field File Open *****************
               if (calc_eof) then
                   localfilename = trim(working_directory) //trim(family_name) // '_medians_eof.txt'
                   open (UNIT= median_unit_eof, FILE = localfilename, STATUS = 'UNKNOWN')
                   write(median_unit_eof,  '(A93)')  "Run Information                                                                       ,  ug/L"           
               end if

               First_time_through_medians = .FALSE.
          end if
               
 
          !*********Populate Open Median Files with Data ************

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
           if (calc_eof) then
                    call find_medians (app_window_counter, 1, hold_for_medians_eof, medians_temp)  
                    write(median_unit_eof, '(A86, ",", G12.4 )') adjustl((adjustr(run_id)//"_median")), medians_temp(1)
           end if
                

         if (run_tpez_wpez) then  !wpez needs its own call due to different capture also because its scenario run is same as pond                 

                call find_medians (app_window_counter, number_medians, hold_for_medians_wpez, medians_temp)  

                write(median_unit_wpez, '(A86, 10(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, 9) 
   
                call find_medians (app_window_counter, 1, hold_for_medians_tpez, medians_temp)   
                write(median_unit_tpez, '(A86, ",", G12.4 )') adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179  !unit conversion to lb/acre
    

                
                if (nchem>1) then !daughter
     
                   call find_medians (app_window_counter, number_medians, hold_for_medians_WPEZ_daughter, medians_temp)             
                   write(median_daughter_unit_wpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
           
                   call find_medians (app_window_counter, 1, hold_for_medians_TPEZ_daughter, medians_temp)             
                   write(median_daughter_unit_tpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179
                end if
                 
          
               if (nchem>2) then !grandaughter
                   call find_medians (app_window_counter, number_medians, hold_for_medians_WPEZ_grandaughter, medians_temp)             
                   write(median_grandaughter_unit_wpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), (medians_temp(i), i=1, number_medians)  
           
                   call find_medians (app_window_counter, 1, hold_for_medians_TPEZ_grandaughter, medians_temp)             
                   write(median_grandaughter_unit_tpez, '(A86, 11(",",G12.4)  )' )  adjustl((adjustr(run_id)//"_median")), medians_temp(1)*0.892179
               end if
               
         end if
         
               
               
    end subroutine calculate_medians
    

end module process_medians
    