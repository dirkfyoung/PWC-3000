module process_medians
    implicit none
    
    
    contains
    
    subroutine calculate_medians(app_window_counter, run_tpez_wpez)
          use constants_and_variables, ONLY: number_medians, hold_for_medians, hold_for_medians_wpez,   hold_for_medians_tpez
          use outputprocessing, ONLY: write_medians       
          use TPEZ_WPEZ, ONLY: write_medians_wpez,write_medians_tpez
          use utilities_1, ONLY: find_medians
          
          integer, intent(in) :: app_window_counter
          logical, intent(in) :: run_tpez_wpez
          
           real               :: medians_conc_wpez(number_medians)
           real               :: medians_conc_tpez(1)
           real               :: medians_conc(number_medians)
          

          ! Main waterbody median output
          call find_medians (app_window_counter, number_medians, hold_for_medians, medians_conc)  
          call write_medians(medians_conc, number_medians)
          
         if (run_tpez_wpez) then  !wpez needs its own call due to different capture also because its scenario run is same as pond                 
                call find_medians (app_window_counter, number_medians, hold_for_medians_wpez, medians_conc_wpez)  
                call write_medians_wpez(medians_conc_wpez, number_medians)
                
                call find_medians (app_window_counter, 1, hold_for_medians_tpez, medians_conc_tpez) 
                call write_medians_tpez(medians_conc_tpez(1))                              
         end if
         
          
    
    
    end subroutine calculate_medians
    
    
    
end module process_medians
    