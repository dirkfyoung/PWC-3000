module VVWM_solution_setup
    
!***************************************************************************
! THIS IS THE ANALYTICAL SOLUTION For the two compartment VVWM.
! Also has a single comprtment TPEZ solution
!
! Based on EXAMS, attempt made to put EXAMS partameters in CAPITAL LETTERS
!___________________________________________________________________________
    contains
    subroutine VVWM
    use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
        water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext,summary_outputfile,  k_flow 
    
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
   

   
   

   !write(echofileunit, *) "Chemical Index", chem_index     
   !
   !select case (chem_index)
   !case (1)
   !    
   !   open (UNIT=11, FILE= trim(outputfile_parent_analysis), STATUS ='unknown')
   !   open (UNIT=12,FILE= trim(outputfile_parent_daily),  STATUS='unknown')
   !   
   !   
   !    if (SimTypeFlag /=2 .and. is_hed_files_made  ) then  !No need for Calendex and DEEM for Pond
   !       open (UNIT=22,FILE=trim(outputfile_parent_deem), STATUS='unknown')
   !       open (UNIT=23,FILE=trim(outputfile_parent_calendex), STATUS='unknown')
   !    end if
   !        
   !    if (is_add_return_frequency) then  !make additional return files
   !        write(stringreturn, '(I3)')  int(additional_return_frequency)
   !         open (UNIT=33, FILE=outputfile_parent_esa, STATUS ='unknown')
   !    end if
   !
   !case (2)  
   !   open (UNIT = 11, FILE = trim(outputfile_deg1_analysis), STATUS = 'unknown')
   !   open (UNIT = 12, FILE=  trim(outputfile_deg1_daily), STATUS = 'unknown')
   !   
   !   if (SimTypeFlag /=2 .and. is_hed_files_made ) then  !No need for Calendex and DEEM for Pond
   !       open (UNIT= 22, FILE= trim(outputfile_deg1_deem),  STATUS = 'unknown')
   !       open (UNIT= 23, FILE= trim(outputfile_deg1_calendex), STATUS = 'unknown')
   !   end if
   !   
   !   if (is_add_return_frequency) then  !make additional return files
   !       
   !        write(stringreturn, '(I3)')  int(additional_return_frequency)
   !         open (UNIT=33, FILE=trim( outputfile_deg1_esa), STATUS ='unknown')
   !   end if
   !
   !case (3)
   !   open (UNIT = 11, FILE = trim(outputfile_deg2_analysis), STATUS = 'unknown')
   !   open (UNIT= 12,FILE = trim(outputfile_deg2_daily),  STATUS = 'unknown')
   !   
   !   if (SimTypeFlag /=2 .and. is_hed_files_made ) then  !No need for Calendex and DEEM for Pond
   !       open (UNIT= 22,FILE = trim(outputfile_deg2_deem),  STATUS = 'unknown')      
   !       open (UNIT= 23,FILE = trim(outputfile_deg2_calendex), STATUS = 'unknown')   
   !   end if
   !   
   !  if (is_add_return_frequency) then  !make additional return files
   !        write(stringreturn, '(I3)') int(additional_return_frequency)
   !         open (UNIT=33, FILE=trim(outputfile_deg2_esa),   STATUS ='unknown')
   !  end if  
   !   
   !
   !end select 
   !
        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if
write (*,*) 'Calling output_processing'
       call output_processor(chem_index)
    !**********************************************************
  end do


end subroutine VVWM
    
    
    
subroutine wpez
!THIS IS THE SAME ROUTINE AS VVWM BUT WITH SOME HARD CODED VALUES FOR INPUTS


    use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
        water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext,summary_outputfile,  k_flow 
    
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

 
!RESET PARAMETERS for wpez      
  simtypeflag   = 1
  depth_0       = 0.15      
  depth_max     = 0.15       
  baseflow      = 0.0      
  is_zero_depth = .TRUE. 
  zero_depth    = 0.01  
 
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
   

   write(*,*) 'batch output file ', trim(summary_outputfile)
   

   
        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if
write (*,*) 'Calling output_processing'
       call output_processor(chem_index)
    !**********************************************************
  end do



end subroutine wpez
    


subroutine tpez(scheme_number)
    use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
        water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext,summary_outputfile, k_flow,&
        num_applications_input,application_rate_in, first_year ,lag_app_in , last_year, repeat_app_in, drift_kg_per_m2, drift_schemes
    
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
    
    integer,intent(in) ::scheme_number
!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


!**local chemical properties****
integer :: chem_index
real    :: koc
real :: drift_value_local
integer :: i,j
  integer :: app_counter
  
  
  drift_kg_per_m2= 0.0
  
    write(*,*) "Enter TPEZ"
    
  !******Set TPEZ Specific parameterS  

    

 !   call allocation_for_VVWM  moved to front
    call convert_weatherdata_for_VVWM      

    call get_mass_inputs !this doesnt get mass inputs anymore

app_counter= 0
!need to make drift adjustment for tpez
 do i=1, num_applications_input
        do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)

           app_counter = app_counter+1       
     
        
        select case (drift_schemes(scheme_number,i)+1)  !this is the row number in the drift table which specifiess the spray method
        case (1)
            drift_value_local = 0.1  !these are all DUMMY values---need to populate with real values
        case (2)
            drift_value_local = 0.2
        case (3)
            drift_value_local = 0.3
        case (4)
            drift_value_local = 0.4
        case (5)
            drift_value_local = 0.5
        case (6)
            drift_value_local = 0.6
        case (7)
            drift_value_local = 0.7
        case (8)
            drift_value_local = 0.8
        case (9)
            drift_value_local = 0.9 
        case (10)
            drift_value_local = 0.01
        case (11)
            drift_value_local = 0.02
        case (12)
            drift_value_local = 0.03
        case (13)
            drift_value_local = 0.04
        case (14)   
            drift_value_local = 0.05
        case (15)
            drift_value_local = 0.0
        case (16)     
            drift_value_local = 0.0
        case default
        drift_value_local = 0.0
        end select
        
         drift_kg_per_m2(app_counter) = drift_value_local * application_rate_in(i)/10000.
    end do
 end do
 
    
    call spraydrift
    

!    !****************************************************************
!    !Washout and volume calculations for individual cases
!    
 write(*,*) "simulation type = 1 tpez"
 call  tpez_volume_calc
!
!    !select case (simtypeflag)
!    !    case (3,5) !reservoir constant volume,flow
!    !            call constant_volume_calc 
!    !    case (2,4)  !pond constant volume, no flow
!    !            call constant_volume_calc 
!    !            k_flow=0.  !for this case zero out washout
!    !    case (1) !variable volume, flow
           call volume_calc
!    !    end select
!        
 
 !NEED TO GET OC CONTENT FROM FIELD

    do chem_index= 1, nchem
          if (is_koc) then
                  koc   = k_f_input(chem_index) 
          else
                  Koc = k_f_input(chem_index)/froc2
          end if
      
!      !*******************************************
!
!        call solute_holding_capacity(koc)    
!        
!        call omega_mass_xfer             ! omega = D_over_dx/benthic_depth !(m3/hr)/(3600 s/hr)
!        call hydrolysis(chem_index)      ! 
!         k_hydro = 0.   
!        call photolysis(chem_index)      ! 
!          k_photo = 0.
          
!CHANGE METABOLISM
        call metabolism(chem_index)     
                        !k_aer_aq = water_column_rate(nchem) *Q_10**((temp_avg - water_column_ref_temp(nchem))/10.)     !k_aer_aq  = 0.69314718/aer_aq/86400.    
                        !k_aer_s  = k_aer_aq        
                        !k_anaer_aq = benthic_rate(nchem)*Q_10**((temp_avg - benthic_ref_temp(nchem))/10.) !effective aq metab rate (per sec)
                        !k_anaer_s  = k_anaer_aq

!        call burial_calc(koc)
!                                 !kd_sed_2 = KOC*FROC2*.001       !Kd of sediment  [m3/kg]
!                                 !k_burial=  burial* kd_sed_2/capacity_2
!        
!        call volatilization(chem_index )
 !        k_volatile = 0.0
!          !********************************************
!          !process the individual degradation rates into overall parameters:
!        call gamma_one
        call gamma_two
          !gamma_2  = k_anaer_aq*fw2 +k_anaer_s*(1.-fw2)+ k_hydro*fw2 + k_burial
!        
!          !**************************************************************
!        
       call initial_conditions(chem_index)
!        write(*,*) "Main VVWM Loop "
!        call MainLoop       
!       
!        
!        select case  (simtypeflag)
!        case (3)  
!            waterbodytext = "Reservoir"
!        case (2)
!            waterbodytext = "Pond"
!        case (1,4,5)
!            waterbodytext =  "Custom"
!        end select
!        
!   
!
!   write(*,*) 'batch output file ', trim(summary_outputfile)
!   
!
!
!        if (nchem > chem_index) then     
!              call DegradateProduction(chem_index) 
!        end if
!write (*,*) 'Calling output_processing'
!       call output_processor(chem_index)
!    !**********************************************************

    end do


end subroutine tpez
    
    
    

end module VVWM_solution_setup