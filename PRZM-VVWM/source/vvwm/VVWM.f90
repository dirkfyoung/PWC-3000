module VVWM_solution_setup
    
!***************************************************************************
! THIS IS THE ANALYTICAL SOLUTION For the two compartment VVWM.
! Also has a single comprtment TPEZ solution
!
! Based on EXAMS, attempt made to put EXAMS parameters in CAPITAL LETTERS
!___________________________________________________________________________
    contains
    subroutine VVWM
    use constants_and_variables, ONLY: nchem, waterbody_timeseries_unit,summary_output_unit,summary_output_unit_deg1, summary_output_unit_deg2,&
        summary_outputfile , summary_outputfile_deg1, summary_outputfile_deg2 , &
        is_koc, k_f_input, DELT_vvwm,summary_outputfile,  k_flow
    
    use waterbody_parameters, ONLY: FROC2, simtypeflag, this_waterbody_name
    
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


 !   call allocation_for_VVWM  moved to front
    call convert_weatherdata_for_VVWM      

    call get_mass_inputs

    call spraydrift
    
    !****************************************************************
    !Washout and volume calculations for individual cases
    select case (simtypeflag)
    case (3,5) !reservoir constant volume,flow
          call constant_volume_calc 
    case (2,4)  !pond constant volume, no flow
          call constant_volume_calc 
          k_flow=0.           !for this case zero out washout
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
        call solute_holding_capacity(chem_index,koc)    
        
        call omega_mass_xfer
        call hydrolysis(chem_index) 
        
        call photolysis(chem_index)

        call metabolism(chem_index)     
        call burial_calc(koc)
        call volatilization(chem_index )
            
        !process the individual degradation rates into overall parameters:
        call gamma_one
        call gamma_two
        
        call initial_conditions(chem_index)

        call MainLoop       
   
        if (nchem > chem_index) then    
              call DegradateProduction(chem_index) 
        end if

      !**********************************************************          
       call output_processor(chem_index, waterbody_timeseries_unit, &
           summary_output_unit, summary_output_unit_deg1, summary_output_unit_deg2,       &
           summary_outputfile, summary_outputfile_deg1, summary_outputfile_deg2, this_waterbody_name)
      !**********************************************************          
  end do                                                                 

end subroutine VVWM
    
    

end module VVWM_solution_setup