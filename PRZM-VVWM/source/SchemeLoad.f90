module schemeload
    implicit none
    contains
    
    Subroutine deallocate_application_parameters
        use constants_and_variables, ONLY: application_rate_in,days_until_applied,DEPI_in,APPEFF_in,Tband_top_in,&
                                        pest_app_method_in ,drift_value,lag_app_in,repeat_app_in
        deallocate(application_rate_in)                                                            
        deallocate(days_until_applied )                                                            
        deallocate(DEPI_in            )          
        deallocate(APPEFF_in          )
        deallocate(Tband_top_in       )
        deallocate(drift_value        ) 
        deallocate(pest_app_method_in )         
        
        deallocate(lag_app_in ) 
        deallocate(repeat_app_in) 
        

	end Subroutine deallocate_application_parameters


    subroutine set_chemical_applications(scheme_number)
       !load the scheme's pesticide application data into the names of the regular przm variables
       use constants_and_variables, ONLY:num_apps_in_schemes, application_rate_in , depi_in, appeff_in, Tband_top_in, &
           pest_app_method_in , drift_value,lag_app_in , repeat_app_in,num_applications_input, some_applications_were_foliar,&
           days_until_applied,&
           days_until_applied_schemes,application_rate_schemes,method_schemes,depth_schemes,split_schemes,&
           drift_schemes,lag_schemes,periodicity_schemes,driftfactor_schemes,&
           app_reference_point, app_reference_point_schemes, is_adjust_for_rain_schemes, & 	
           rain_limit_schemes,optimum_application_window_schemes,intolerable_rain_window_schemes,min_days_between_apps_schemes, & 
	       is_adjust_for_rain, rain_limit,optimum_application_window,intolerable_rain_window,min_days_between_apps , is_batch_scenario 
      
       use waterbody_parameters, ONLY: afield,   area_waterbody, spray_values
           integer,intent(in):: scheme_number
           integer :: i
           write(*,*) "Inside set_chemical_applications"
           num_applications_input = num_apps_in_schemes(scheme_number)
        
        write(*,*) 'number of apps ', num_apps_in_schemes(scheme_number)

        allocate(application_rate_in(num_applications_input))
        allocate(DEPI_in            (num_applications_input))          
        allocate(APPEFF_in          (num_applications_input))
        allocate(Tband_top_in       (num_applications_input))
        allocate(pest_app_method_in (num_applications_input))   
        allocate(drift_value        (num_applications_input)) 
        allocate(lag_app_in         (num_applications_input)) 
        allocate(repeat_app_in      (num_applications_input))
        allocate(days_until_applied (num_applications_input))
        
        !pest_app_method = 1 "Below Crop" 
        !pest_app_method = 2 "Above Crop"
        !pest_app_method = 3 "Uniform"
        !pest_app_method = 4 "At Specific Depth"
        !pest_app_method = 5 "T Band"
        !pest_app_method = 6 "invert triange chrw 9661"
        !pest_app_method = 7 "triangle chrw 9651"
        
       write(*,'(A)') '     day  rate  method   depth   Tband   Eff   drft#  driftValue  repeat  lag'
      
       app_reference_point = app_reference_point_schemes(scheme_number)
      

        do i=1, num_applications_input

            days_until_applied(i)  = days_until_applied_schemes(scheme_number,i)
            application_rate_in(i) = application_rate_schemes(scheme_number,i)
            pest_app_method_in(i)  = method_schemes(scheme_number,i)
            DEPI_in(i)             = depth_schemes(scheme_number,i)
            Tband_top_in(i)        = split_schemes(scheme_number,i)
			
			
			!Interpolate Drift Values from Spray Table. Remember there is a header in the saved table so add 1
			call lookup_drift(drift_schemes(scheme_number,i)+1, driftfactor_schemes(scheme_number,i),drift_value(i))
            

		!	drift_value(i)            = spray_values(drift_schemes(scheme_number,i)) * driftfactor_schemes(scheme_number,i) !inside parenth is index number corresponding to the spray values in the waterbody file
							
			!get spray method (row number) and get the distance
			
			
            lag_app_in(i)          = lag_schemes(scheme_number,i)
            repeat_app_in(i)       = periodicity_schemes(scheme_number,i)
                   
			
			
			!calclautaed based on losses to the waterbody subtracted from fields applied pesticide
			APPEFF_in(i)           = 1.0 - drift_value(i) * area_waterbody/afield

           write(*,'(I8,G10.3, I4, 3F8.3, I4, 3x, F8.3,3x, 2I6)')days_until_applied(i),application_rate_in(i), pest_app_method_in(i), DEPI_in(i),Tband_top_in(i), APPEFF_in(i),drift_schemes(scheme_number,i), drift_value(i) , repeat_app_in(i),lag_app_in(i) 

		end do 

		
		!the following cannot be applied until after the weather file has been read in. 
		!But parameters are read in here because they are part of the application scheme
		
		is_adjust_for_rain	       = is_adjust_for_rain_schemes(scheme_number)
		rain_limit                 = rain_limit_schemes(scheme_number)
		optimum_application_window = optimum_application_window_schemes(scheme_number)
		intolerable_rain_window    = intolerable_rain_window_schemes(scheme_number)
		min_days_between_apps      = min_days_between_apps_schemes(scheme_number)

	
      some_applications_were_foliar = .FALSE.
      if(any(pest_app_method_in==2)) then
          some_applications_were_foliar = .TRUE.
      end if
     
    write(*,*) 'Any Foliar Applications? ', some_applications_were_foliar
	end subroutine set_chemical_applications
    
	
	subroutine lookup_drift(row, column, output)
	   use waterbody_parameters, only: spraytable
	   integer, intent(in) :: row  
	   real, intent(in)    :: column
	   real, intent(out)   :: output
	
	   integer :: i
	   real    :: previous
	
	   !interpolate column value for values in row
	   previous = 0.0
	   do i = 1, size(spraytable, 2)
	   	 if (column ==spraytable(1, i)) then !exact match, get value and end
	   		 output = spraytable(row, i)
	   		 exit
	   	 elseif (spraytable(1, i) < column ) then
	   		 previous = spraytable(1, i)
	   	 else      !spraytable(1, i))< column  !do interpolation and quit
	   		 output =  spraytable(row, i-1) +   (spraytable(row, i)-spraytable(row, i-1)) *  (column - previous)/(spraytable(1, i)- previous)
	   		 write(*,'("            row = ",i2, " interpolate between columns ", i2, " and ", i2, ", fraction = ", g10.4 )') row, i-1, i,  (column - previous)/(spraytable(1, i)- previous)
	   		 exit
		 end if	 
	   end do

	   write(*,'("            Interrpolated Spray Drift = ", G12.4)')  , output
	
	end subroutine lookup_drift
	

end module schemeload
   
