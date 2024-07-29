module TPEZ_spray_initialization
    implicit none 
    
    real,allocatable,dimension(:)  :: tpez_drift_value         !raw values and array is dependent only on inputs application tab
    real,allocatable,dimension(:)  :: tpez_drift_kg_per_m2     !the drift application rate to tpez, array size dependent on scenario
    real,allocatable,dimension(:)  :: tpez_spray_additions     !daily mass of spray to be added to water column (kg) 
 
    real, parameter :: area_tpez = 10000.!m2  
    real,dimension(17,13),parameter :: spray_table_TPEZ = transpose(reshape((/&      
    0.0000E+00,1.0000E+01,2.5000E+01,5.0000E+01,7.5000E+01,1.0000E+02,1.2500E+02,1.5000E+02,2.0000E+02,2.5000E+02,3.0000E+02,3.5000E+02,4.0000E+02,&
    3.1900E-01,2.9490E-01,2.6660E-01,2.3020E-01,2.0100E-01,1.7640E-01,1.5750E-01,1.4100E-01,1.1760E-01,1.0160E-01,8.9500E-02,8.0100E-02,7.2800E-02,&
    1.9440E-01,1.6300E-01,1.3400E-01,1.0310E-01,8.0800E-02,6.5300E-02,5.4800E-02,4.7500E-02,3.7500E-02,3.0900E-02,2.6300E-02,2.2900E-02,2.0400E-02,&
    1.4760E-01,1.1430E-01,8.6800E-02,6.3000E-02,4.6500E-02,3.6600E-02,3.0000E-02,2.5400E-02,1.8900E-02,1.4900E-02,1.2400E-02,1.0700E-02,9.5000E-03,&
    1.1920E-01,8.5600E-02,5.9800E-02,4.0700E-02,2.9700E-02,2.3100E-02,1.8500E-02,1.5300E-02,1.1200E-02,9.0000E-03,7.6000E-03,6.6000E-03,5.9000E-03,&
    1.1190E-01,6.2200E-02,4.0800E-02,2.7500E-02,2.1100E-02,1.7100E-02,1.4400E-02,1.2300E-02,9.5000E-03,7.6000E-03,6.3000E-03,5.3000E-03,4.5000E-03,&
    2.9200E-02,1.3600E-02,1.0000E-02,7.5000E-03,6.1000E-03,5.2000E-03,4.6000E-03,4.1000E-03,3.3000E-03,2.8000E-03,2.4000E-03,2.1000E-03,1.9000E-03,&
    4.9300E-02,2.1800E-02,1.4700E-02,1.0300E-02,8.2000E-03,6.9000E-03,5.9000E-03,5.2000E-03,4.2000E-03,3.5000E-03,3.0000E-03,2.6000E-03,2.3000E-03,&
    1.9400E-02,8.3000E-03,6.2000E-03,4.7000E-03,3.9000E-03,3.4000E-03,3.0000E-03,2.7000E-03,2.2000E-03,1.9000E-03,1.7000E-03,1.5000E-03,1.3000E-03,&
    1.9000E-03,1.4000E-03,1.0000E-03,7.0000E-04,5.0000E-04,4.0000E-04,4.0000E-04,3.0000E-04,2.0000E-04,2.0000E-04,2.0000E-04,1.0000E-04,1.0000E-04,&
    2.6400E-02,1.8300E-02,1.2200E-02,7.5000E-03,5.3000E-03,4.1000E-03,3.3000E-03,2.7000E-03,2.1000E-03,1.7000E-03,1.4000E-03,1.2000E-03,1.1000E-03,&
    8.2800E-02,5.0100E-02,2.8000E-02,1.3500E-02,7.8000E-03,5.0000E-03,3.5000E-03,2.5000E-03,1.5000E-03,1.0000E-03,7.0000E-04,5.0000E-04,4.0000E-04,&
    4.6000E-03,2.6000E-03,1.5000E-03,9.0000E-04,6.0000E-04,5.0000E-04,4.0000E-04,3.0000E-04,2.0000E-04,2.0000E-04,1.0000E-04,1.0000E-04,1.0000E-04,&
    4.1500E-02,2.6400E-02,1.6100E-02,9.0000E-03,5.9000E-03,4.3000E-03,3.4000E-03,2.7000E-03,2.0000E-03,1.5000E-03,1.3000E-03,1.1000E-03,9.0000E-04,&
    1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,1.0000E+00,&
    0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,&
    0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00,0.0000E+00 &
    /),(/13,17/)))
    


    contains 
    
    subroutine set_tpez_spray(scheme_number)
    !After scheme and before scenarios
         use constants_and_variables, ONLY: num_applications_input, drift_schemes, driftfactor_schemes,is_output_spraydrift
         use waterbody_parameters, ONLY:  use_tpezbuffer
         use utilities_1, ONLY:find_in_table
         
         real    :: buffer_distance   !local holder to take care of zero buffer option
         integer, intent(in) ::scheme_number
         integer :: i
         allocate(tpez_drift_value(num_applications_input)) 
    
         do i=1, num_applications_input
                if (use_tpezbuffer) then
                     buffer_distance = driftfactor_schemes(scheme_number,i)
                else            
                     buffer_distance = 0.0
                end if
      
                call find_in_table(drift_schemes(scheme_number,i)+1, buffer_distance, spray_table_TPEZ,size(spray_table_TPEZ,1),size(spray_table_TPEZ,2),  tpez_drift_value(i))        
                if (is_output_spraydrift)  write(*,*)  "tpez drift factor ", tpez_drift_value(i)
         end do 
         
         
         
         

    end  subroutine set_tpez_spray
    
    
   subroutine tpez_drift_finalize          
     !Set TPEZ Specific parameters dependent on scenario 
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
    