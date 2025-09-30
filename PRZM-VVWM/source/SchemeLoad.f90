module schemeload
    implicit none
    contains
    
    Subroutine deallocate_application_parameters
        use constants_and_variables,   ONLY: application_rate_in,days_until_applied,DEPI_in,APPEFF_in,Tband_top_in,&
                                           pest_app_method_in ,drift_value,lag_app_in,repeat_app_in, is_absolute_year
        use TPEZ_spray_initialization, ONLY: tpez_drift_value 
        use waterbody_parameters, ONLY:itstpezwpez
        
        
        deallocate(application_rate_in)                                                            
        deallocate(days_until_applied )                                                            
        deallocate(DEPI_in            )          
        deallocate(APPEFF_in          )
        deallocate(Tband_top_in       )
        deallocate(drift_value        ) 
        deallocate(pest_app_method_in )         
        
        deallocate(lag_app_in ) 
        deallocate(repeat_app_in) 
        deallocate(is_absolute_year)
        if (itstpezwpez) deallocate(tpez_drift_value ) 
        
	end Subroutine deallocate_application_parameters


    subroutine set_chemical_applications(scheme_number)
       !load the scheme's pesticide application data into the names of the regular przm variables
       use constants_and_variables, ONLY:num_apps_in_schemes, application_rate_in , depi_in, appeff_in, Tband_top_in, &
           pest_app_method_in , drift_value,lag_app_in , repeat_app_in,num_applications_input, some_applications_were_foliar,&
           days_until_applied,&
           days_until_applied_schemes,application_rate_schemes,method_schemes,depth_schemes,split_schemes,&
           drift_schemes,lag_schemes,periodicity_schemes,driftbuffer_schemes,&
           app_reference_point, app_reference_point_schemes, is_adjust_for_rain_schemes, & 	
           rain_limit_schemes,optimum_application_window_schemes,intolerable_rain_window_schemes,min_days_between_apps_schemes, & 
	       is_adjust_for_rain, rain_limit,optimum_application_window,intolerable_rain_window,min_days_between_apps, is_batch_scenario, &
           is_absolute_year, is_absolute_year_schemes, runoff_mitigation_schemes, erosion_mitigation_schemes,  drift_mitigation_schemes, &
           runoff_mitigation, erosion_mitigation,drift_mitigation,is_output_spraydrift
       
       use spray_deposition_curve
       use waterbody_parameters, ONLY: afield,   area_waterbody, distance_drift
        integer,intent(in):: scheme_number
        integer :: i
        real:: buffer, distance
        
        
        num_applications_input = num_apps_in_schemes(scheme_number)

        allocate(application_rate_in(num_applications_input))
        allocate(DEPI_in            (num_applications_input))          
        allocate(APPEFF_in          (num_applications_input))
        allocate(Tband_top_in       (num_applications_input))
        allocate(pest_app_method_in (num_applications_input))   
        allocate(drift_value        (num_applications_input)) 
        allocate(lag_app_in         (num_applications_input)) 
        allocate(repeat_app_in      (num_applications_input))
        allocate(days_until_applied (num_applications_input))
        allocate(is_absolute_year   (num_applications_input))    
        
        
        !pest_app_method = 1 "Below Crop" 
        !pest_app_method = 2 "Above Crop"
        !pest_app_method = 3 "Uniform"
        !pest_app_method = 4 "At Specific Depth"
        !pest_app_method = 5 "T Band"
        !pest_app_method = 6 "triangle chrw 9651"
        !pest_app_method = 7 "invert triangle chrw 9661"
        
        
        app_reference_point = app_reference_point_schemes(scheme_number)
      
        do i=1, num_applications_input
            is_absolute_year(i)    = is_absolute_year_schemes(scheme_number,i)
            days_until_applied(i)  = days_until_applied_schemes(scheme_number,i)
            application_rate_in(i) = application_rate_schemes(scheme_number,i)
            pest_app_method_in(i)  = method_schemes(scheme_number,i)
            DEPI_in(i)             = depth_schemes(scheme_number,i)
            Tband_top_in(i)        = split_schemes(scheme_number,i)
            
            !********************************************************************************
            !the new spray curve and integration routine
            !convert feet to meters
            buffer = driftbuffer_schemes(scheme_number,i)*0.3048 !convert input feet to meters       
            distance = distance_drift  !already in meters, this comes from the waterbody parameters

            call trapezoid_rule(buffer,    buffer+ distance,    (drift_schemes(scheme_number,i) ), drift_value(i)  )
            
            if (is_output_spraydrift)  write(*,*)  "drift factor, before mitigation ", drift_value(i)    
            
            lag_app_in(i)          = lag_schemes(scheme_number,i)
            repeat_app_in(i)       = periodicity_schemes(scheme_number,i)
                   
			!Efficiency calclautaed based on losses to the waterbody subtracted from fields applied pesticide
			APPEFF_in(i)           = 1.0 - drift_value(i) * area_waterbody/afield
        end do 
        		
		!the following cannot be applied until after the weather file has been read in. 
		!But parameters are read in here because they are part of the application scheme
		
		is_adjust_for_rain	       = is_adjust_for_rain_schemes(scheme_number)
		rain_limit                 = rain_limit_schemes(scheme_number)
		optimum_application_window = optimum_application_window_schemes(scheme_number)
		intolerable_rain_window    = intolerable_rain_window_schemes(scheme_number)
		min_days_between_apps      = min_days_between_apps_schemes(scheme_number)
         
        runoff_mitigation  = runoff_mitigation_schemes(scheme_number)
        erosion_mitigation = erosion_mitigation_schemes(scheme_number)
        drift_mitigation   = drift_mitigation_schemes(scheme_number)
        
        
        !************ some warnings requested by QA team **************************************
        if (runoff_mitigation > 1.0000001) then 
              write(*,*) "Runoff mass modified with factor greater than 1: ", runoff_mitigation
        else if (runoff_mitigation < -0.000000001) then             
               write(*,*) "Runoff mass modified with negative factor: ", runoff_mitigation
        end if
        
        if (erosion_mitigation > 1.0000001) then 
              write(*,*) "Erosion mass modified with factor greater than 1: ", erosion_mitigation
        else if (erosion_mitigation < -0.00000000) then             
               write(*,*) "Erosion mass modified with negative factor: ", erosion_mitigation
        end if
        
        if (drift_mitigation > 1.0000001) then 
              write(*,*) "Drift mass modified with factor greater than 1: ", drift_mitigation
        else if (erosion_mitigation < -0.00000000) then             
               write(*,*) "Drift mass modified with negative factor: ", drift_mitigation
        end if        
       !************ End some warnings requested by QA team **************************************
        
        
        
        
        

        some_applications_were_foliar = .FALSE.
        if(any(pest_app_method_in==2)) then
            some_applications_were_foliar = .TRUE.
        end if

    end subroutine set_chemical_applications
    

end module schemeload
   