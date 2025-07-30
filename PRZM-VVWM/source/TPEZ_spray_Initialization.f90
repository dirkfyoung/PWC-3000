module TPEZ_spray_initialization
    implicit none 
    
    real,allocatable,dimension(:)  :: tpez_drift_value         !raw values and array is dependent only on inputs application tab
    real,allocatable,dimension(:)  :: tpez_drift_kg_per_m2     !the drift application rate to tpez, array size dependent on scenario
    real,allocatable,dimension(:)  :: tpez_spray_additions     !daily mass of spray to be added to water column (kg) 
 
    real, parameter :: area_tpez = 10000.!m2  
    real, parameter :: width_tpez = 30.0 !m
  

    contains 
    
    subroutine set_tpez_spray(scheme_number)
    !After scheme and before scenarios.  
         use constants_and_variables, ONLY: num_applications_input, drift_schemes, driftfactor_schemes,is_output_spraydrift, drift_mitigation
         use waterbody_parameters, ONLY:  use_tpezbuffer,itstpezwpez
        ! use utilities_1, ONLY:find_in_table
         use spray_deposition_curve, ONLY: trapezoid_rule
         
         real    :: buffer   !local holder to take care of zero buffer option
         integer, intent(in) ::scheme_number
         integer :: i
         allocate(tpez_drift_value(num_applications_input)) 
    
         do i=1, num_applications_input
                if (use_tpezbuffer) then
                     buffer = driftfactor_schemes(scheme_number,i)*0.3048 !convert input feet to meters  
                else            
                     buffer = 0.0
                end if
      
                call trapezoid_rule(buffer,    buffer + width_tpez ,    (drift_schemes(scheme_number,i) ), tpez_drift_value(i) ) 
                
                if (is_output_spraydrift )  write(*,*)  "tpez drift factor, before mitigation", tpez_drift_value(i) 
                
                tpez_drift_value(i) =  tpez_drift_value(i) * drift_mitigation    
                
         end do 
         
    end  subroutine set_tpez_spray
    
    
   subroutine tpez_drift_finalize          
     !Call must be placed after INITL because call to tpez_spraydrift need to know toatal apps
      use constants_and_variables, ONLY: driftfactor_schemes,is_output_spraydrift,is_absolute_year, &
                                        lag_app_in ,first_year, last_year, repeat_app_in,application_rate_in, &
                                        num_applications_input

     integer :: i,j
     integer :: app_counter

      tpez_drift_kg_per_m2= 0.0
      app_counter= 0
    
          
          do i=1, num_applications_input
             
            if (is_absolute_year(i)) then        
                app_counter = app_counter+1  !this allows both absolute years AND cycle years to be used
                tpez_drift_kg_per_m2(app_counter) = tpez_drift_value(i)*application_rate_in(i)/10000.    !Kg/m2 drift application to tpez        
            else
                do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)
                      app_counter = app_counter+1                               
                      tpez_drift_kg_per_m2(app_counter) = tpez_drift_value(i)*application_rate_in(i)/10000.    !Kg/m2 drift application to tpez                          
              end do    
            endif  !absolute years vs. yearly cycle
    
         end  do    
              

    call tpez_spraydrift  
    
    end subroutine tpez_drift_finalize 
    
    
    
    subroutine tpez_spraydrift
       !Because vvwm spraydrift values are calculated outside app loop, this routine needs to be isolated to not change vvwm spray values
       !probably could put this outside loop also for nore efficiency
       !but this routine needs to know total apps which requires that scenario be read in
       use constants_and_variables, ONLY: num_records, total_applications, application_date, startday           
       implicit none

       integer  ::  i, index_day
       !Note mass is an array refernced to day 1 of the simulation, appdate is an array of dates from 1900       

       tpez_spray_additions = 0.0
       
       do i=1, total_applications
           index_day = application_date(i)-startday
           if (index_day > 0 .and. index_day <= num_records) then       
               tpez_spray_additions(index_day) = tpez_drift_kg_per_m2(i) * area_tpez 
           end if          
       end do

    end subroutine tpez_spraydrift
        
end module TPEZ_spray_initialization 
    