module schemeload
    implicit none
    contains
    
     Subroutine deallocate_application_parameters
     use constants_and_variables, ONLY: application_rate_in,days_until_applied,DEPI_in,APPEFF_in,Tband_top_in,&
                                        pest_app_method_in ,drift_in,lag_app_in,repeat_app_in
        deallocate(application_rate_in)                                                            
        deallocate(days_until_applied )                                                            
        deallocate(DEPI_in            )          
        deallocate(APPEFF_in          )
        deallocate(Tband_top_in       )
        deallocate(pest_app_method_in )         
        deallocate(drift_in           ) 
        deallocate(lag_app_in         ) 
        deallocate(repeat_app_in      )   


     end Subroutine deallocate_application_parameters
     
     
    subroutine set_chemical_applications(scheme_number)
    !load the scheme's pesticide application data into the names of the regular przm variables
    use constants_and_variables, ONLY:num_apps_in_schemes, application_rate_in , depi_in, appeff_in, Tband_top_in, &
        pest_app_method_in , drift_in,lag_app_in , repeat_app_in,num_applications_input, some_applications_were_foliar,&
        days_until_applied,&
        days_until_applied_schemes,application_rate_schemes,method_schemes,depth_schemes,split_schemes,&
        drift_schemes,lag_schemes,periodicity_schemes,driftfactor_schemes,&
        app_reference_point, app_reference_point_schemes
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
        allocate(drift_in           (num_applications_input)) 
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
			
			!Reduction of spray drift by drift factor is done here
			drift_in(i)            = spray_values(drift_schemes(scheme_number,i)) * driftfactor_schemes(scheme_number,i) !inside parenth is index number corresponding to the spray values in the waterbody file
							
            lag_app_in(i)          = lag_schemes(scheme_number,i)
            repeat_app_in(i)       = periodicity_schemes(scheme_number,i)
                   
			
			
			!calclautaed based on looses to the waterbody suvtracted from fields applied pesticide
			APPEFF_in(i)           = 1.0 - drift_in(i) * area_waterbody/afield
			
			
           write(*,'(I8,G10.3, I4, 3F8.3, I4, 3x, F8.3,3x, 2I6)')days_until_applied(i),application_rate_in(i), pest_app_method_in(i), DEPI_in(i),Tband_top_in(i), APPEFF_in(i),drift_schemes(scheme_number,i), drift_in(i) , repeat_app_in(i),lag_app_in(i) 
        
		end do 



      some_applications_were_foliar = .FALSE.
      if(any(pest_app_method_in==2)) then
          some_applications_were_foliar = .TRUE.
      end if
     
    write(*,*) 'Any Foliar Applications? ', some_applications_were_foliar
    end subroutine set_chemical_applications
    
    end module schemeload
   
