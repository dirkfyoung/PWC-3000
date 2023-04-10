module VVWM_solution_setup
    
!***************************************************************************
! THIS IS THE ANALYTICAL SOLUTION For the two compartment VVWM.
! Also has a single comprtment TPEZ solution
!
! Based on EXAMS, attempt made to put EXAMS partameters in CAPITAL LETTERS
!___________________________________________________________________________
    contains
    subroutine VVWM
    use constants_and_variables, ONLY: nchem, waterbody_timeseries_unit,summary_output_unit,summary_output_unit_deg1, summary_output_unit_deg2,&
        summary_outputfile , summary_outputfile_deg1, summary_outputfile_deg2 , &
        is_koc, k_f_input, water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext,summary_outputfile,  k_flow, First_time_through_wb
    
    use waterbody_parameters, ONLY: FROC2, simtypeflag
    
  !  use variables, ONLY: ,Batch_outputfile

    use degradation
    use solute_capacity
    use mass_transfer
    use volumeAndwashout
    use MassInputs
    use ProcessMetfiles
    use outputprocessing
    use nonInputVariables, only: 
    use allocations
    use coreCalculations
    
    implicit none              

!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


!**local chemical properties****
integer :: chem_index
real    :: koc



    write(*,*) "enter VVWM"

 !   call allocation_for_VVWM  moved to front
    call convert_weatherdata_for_VVWM      

    call get_mass_inputs

    call spraydrift
    
    
    
    
    !****************************************************************
    !Washout and volume calculations for individual cases
    
 write(*,*) "simulation type = ", simtypeflag
    select case (simtypeflag)
        case (3,5) !reservoir constant volume,flow
                call constant_volume_calc 
        case (2,4)  !pond constant volume, no flow
                call constant_volume_calc 
                k_flow=0.  !for this case zero out washout
        case (1) !variable volume, flow
                call volume_calc
        end select
        

    do chem_index= 1, nchem
          if (is_koc) then
                  koc   = k_f_input(chem_index) 
          else
                  Koc = k_f_input(chem_index)/froc2
          end if
      
      !*******************************************

        call solute_holding_capacity(koc)    
        
        call omega_mass_xfer
        call hydrolysis(chem_index) 
        
        call photolysis(chem_index)

        call metabolism(chem_index)     
        call burial_calc(koc)
        call volatilization(chem_index )
            
          !********************************************
          !process the individual degradation rates into overall parameters:
        call gamma_one
        call gamma_two
        
        
          !**************************************************************
        
        call initial_conditions(chem_index)
        write(*,*) "Main VVWM Loop "
        call MainLoop       
       
        
        select case  (simtypeflag)
        case (3)  
            waterbodytext = "Reservoir"
        case (2)
            waterbodytext = "Pond"
        case (1,4,5)
            waterbodytext =  "Custom"
        end select
        
   

   write(*,*) 'batch output file ', trim(summary_outputfile)
   

   

        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if


    !**********************************************************          


       call output_processor(chem_index,First_time_through_wb, waterbody_timeseries_unit,  summary_output_unit, summary_output_unit_deg1, summary_output_unit_deg2, &
           summary_outputfile, summary_outputfile_deg1, summary_outputfile_deg2)
    !**********************************************************          
  end do                                                                 


end subroutine VVWM
    
    
    
subroutine wpez
!THIS IS THE SAME ROUTINE AS VVWM BUT WITH SOME HARD CODED VALUES FOR INPUTS


    use constants_and_variables, ONLY: nchem, wpez_timeseries_unit,  summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
        is_koc, k_f_input, water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext , k_flow , &
        summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2,First_time_through_wpez
    
    
    
    use waterbody_parameters, ONLY: FROC2, simtypeflag, depth_0,depth_max,baseflow,is_zero_depth,zero_depth  
    
    
  !  use variables, ONLY: ,Batch_outputfile

    use degradation
    use solute_capacity
    use mass_transfer
    use volumeAndwashout
    use MassInputs
    use ProcessMetfiles
    use outputprocessing
    use nonInputVariables, only: 
    use allocations
    use coreCalculations
    
    implicit none              

!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


!**local chemical properties****
integer :: chem_index
real    :: koc

    write(*,*) "enter WPEZ"

 ! FOR WPEZ these should already be calculated AFTER pond run
      !   call allocation_for_VVWM  moved to front
      !   call convert_weatherdata_for_VVWM      
      !   call get_mass_inputs
      !   call spraydrift
    
 
 !***WPEZ MODIFICATION, Always varing volume **********
 ! Set  simtypeflag = 1
 !*******************************************************
 write(*,*) "WPEZ simulation type is always Varying Volume Type 1"

 
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
 !RESET PARAMETERS for wpez      
  simtypeflag   = 1
  depth_0       = 0.15      
  depth_max     = 0.15       
  baseflow      = 0.0      
  is_zero_depth = .TRUE. 
  zero_depth    = 0.01  
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
  
  
    select case (simtypeflag)
        case (3,5) !reservoir constant volume,flow
                call constant_volume_calc 
        case (2,4)  !pond constant volume, no flow
                call constant_volume_calc 
                k_flow=0.  !for this case zero out washout
        case (1) !variable volume, flow
                call volume_calc
        end select
 

    do chem_index= 1, nchem
          if (is_koc) then
                  koc   = k_f_input(chem_index) 
          else
                  Koc = k_f_input(chem_index)/froc2
          end if
      
      !*******************************************

        call solute_holding_capacity(koc)    
        
        call omega_mass_xfer             !probably doesnt need recalculation
        call hydrolysis(chem_index) 
        call photolysis(chem_index)

        call metabolism(chem_index)      !probably doesnt need recalculation
        call burial_calc(koc)            !probably doesnt need recalculation
        call volatilization(chem_index )
            
        !process the individual degradation rates into overall parameters:
        call gamma_one
        call gamma_two                   !probably doesnt need recalculation
        
        !**************************************************************
        
        call initial_conditions(chem_index)
        write(*,*) "Main VVWM Loop "
        call MainLoop             
        
        !select case  (simtypeflag)
        !case (3)  
        !    waterbodytext = "Reservoir"
        !case (2)
        !    waterbodytext = "Pond"
        !case (1,4,5)
        !    waterbodytext =  "Custom"
        !end select
        
        waterbodytext =  "WPEZ"
   

   write(*,*) 'wpez batch output file ', trim(summary_WPEZoutputfile)
   

   
        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if



       call output_processor(chem_index,First_time_through_wpez, wpez_timeseries_unit, summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
                             summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2)
       
       
       
    !**********************************************************
    end do


    
    
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
    
  simtypeflag   = 2
  depth_0       = 2.0     
  depth_max     = 2.0       
  baseflow      = 0.0      
  is_zero_depth = .FALSE. 
  zero_depth    = 0.00  
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    

    
    
    
    
    
    

end subroutine wpez
    

!****************************************************************************
subroutine tpez(scheme_number)
    use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
        DELT_vvwm, k_flow,waterbodytext,soil_depth, &
        num_applications_input,application_rate_in, first_year ,lag_app_in , last_year, repeat_app_in, drift_kg_per_m2, drift_schemes,&
        theta_fc,theta_wp, ncom2,  orgcarb,bulkdensity , mavg1_store
    use waterbody_parameters, ONLY: simtypeflag
    
    use degradation
    use volumeAndwashout
    use MassInputs
    use outputprocessing
    use coreCalculations
    use utilities_1
    
    implicit none   
    
    integer,intent(in) ::scheme_number

    !**local chemical properties****
    integer :: chem_index
    real    :: koc
    real    :: drift_value_local
    integer :: i,j
    integer :: app_counter
    real    :: avg_maxwater ,avg_minwater, avg_oc, avg_bd
    
    real, parameter :: area_tpez = 10000.!m2
    real kd
    write(*,*) "Enter TPEZ"
     
     
    drift_kg_per_m2= 0.0
    
   
    
   !******Set TPEZ Specific parameters  
 
   app_counter= 0
   do i=1, num_applications_input
        do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)

             app_counter = app_counter+1       

             select case (drift_schemes(scheme_number,i))  !this is the row number in the drift table which specifiess the spray method
             case (1)                         !"Aerial (VF-F)"
                 drift_value_local = 0.3194
             case (2)                         !"Aerial (F-M) D"
                 drift_value_local = 0.1948
             case (3)                         !"Aerial (M-C)"
                 drift_value_local = 0.148
             case (4)                         !"Aerial (C-VC)"
                 drift_value_local = 0.1196
             case (5)                         !"Ground (High, VF-F) D"
                 drift_value_local = 0.1123
             case (6)                         !"Ground (High, F-MC)"
                 drift_value_local = 0.0293
             case (7)                         !"Ground (Low, VF-F)"
                 drift_value_local = 0.0495
             case (8)                         !"Ground (Low, F-MC)"
                 drift_value_local = 0.0195
             case (9)                         !"Airblast (normal)"
                 drift_value_local = 0.0019 
             case (10)                        !"Airblast (dense)"
                 drift_value_local = 0.0265
             case (11)                        !"Airblast (sparse) D"
                 drift_value_local = 0.0831
             case (12)                        !"Airblast (vinyard)"
                 drift_value_local = 0.0047
             case (13)                        !"Airblast (orchard)"
                 drift_value_local = 0.0417
             case (14)                        !"Directly applied to waterbody"
                 drift_value_local = 1.0
             case (15)                        !"None"
                 drift_value_local = 0.0
             case (16)                        !"advanced user"  
                 drift_value_local = 0.0
             case default
             drift_value_local = 0.0
             end select
        
             drift_kg_per_m2(app_counter) = drift_value_local * application_rate_in(i)/10000.
        end do
   end do
   
    
    call spraydrift

   
   
    call find_average_property(ncom2,soil_depth, 15.0,  theta_fc, avg_maxwater)    
    call find_average_property(ncom2,soil_depth,15.0, theta_wp, avg_minwater)
    call find_average_property(ncom2,soil_depth,15.0, bulkdensity , avg_bd)  
    call find_average_property(ncom2,soil_depth,15.0, orgcarb     , avg_oc) 
    
    write(*,*)"For TPEZ, avg_maxwater, avg_minwater,avg_bd, avg_oc as follows:"
    write(*,*) avg_maxwater,  avg_minwater, avg_bd, avg_oc 
  
    call  tpez_volume_calc (avg_maxwater, avg_minwater, area_tpez)   !call special averaging in here

    !NEED TO GET OC CONTENT FROM FIELD
    !   find_average_property(n,target_depth, thickness, property, average)

 
  do chem_index= 1, nchem
     
          if (is_koc) then
                  kd   = k_f_input(chem_index) * avg_oc /100.0   !ml/g , oc is in %
          else
                  Kd = k_f_input(chem_index)
          end if

          write(*,* ) "KD = " , kd
          write(*,* ) "BD = " , avg_bd
          write(*,* ) "R = " , ( avg_maxwater+avg_bd*kd)/avg_maxwater
          
         call initial_conditions(chem_index)  !just populates m1 additions: erosion runoff and drift
         call MainLoopTPEZ(avg_maxwater, kd, avg_bd)      
    
          waterbodytext = "TPEZ"
  
!        if (nchem > chem_index) then     
!              call DegradateProduction(chem_index)  !not available for tpez
!        end if
       write (*,*) 'Calling tpez output_processing'
       call tpez_output_processor(chem_index)
       
       
       
       !Calculate Edge of Field
      ! flowthru_the_body = runoff_save*afield/8640000.    !m3/s :(cm/day) *(m2)* (m/100cm)* (day/86400s)  
      ! mass_off_field(day_number_chemtrans,1,1) =   ROFLUX(1)* afield*10.  !converts to kg
       
   

    !**********************************************************
  end do
  


          
end subroutine tpez
    
    
    

end module VVWM_solution_setup