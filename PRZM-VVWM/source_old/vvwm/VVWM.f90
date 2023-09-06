module VVWM_solution_setup
    
    !***************************************************************************
! THIS IS THE ANALYTICAL SOLUTION TO THE EFED SUBSETS OF THE EXAMS MODEL. 
!
!
! Attempt was made to put all EXAMS partameters in CAPITAL LETTERS
! errors are reported in fort.11
!___________________________________________________________________________
    contains
    subroutine VVWM
    use constants_and_variables, ONLY: echofileunit,nchem, is_koc, k_f_input,froc2,water_column_rate_input, &
        water_column_ref_temp,benthic_rate_input, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        simtypeflag,&
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa, is_output_all,waterbodytext,summary_outputfile
    
    
    
  !  use variables, ONLY: ,Batch_outputfile

    use degradation
    use solute_capacity
    use mass_transfer
    use volumeAndwashout
    use MassInputs
    use ProcessMetfiles
    use outputprocessing
    use nonInputVariables, only:k_flow  
    use ALLOCATIONmodule
    use coreCalculations
    
    implicit none              

!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


!**local chemical properties****
integer :: chem_index
real    :: koc


character(len = 10) stringreturn


    write(echofileunit, *) "enter VVWM"

    call ALLOCATION
    call convert_weatherdata_for_VVWM      

    call get_mass_inputs

    call spraydrift
    
    
    !****************************************************************
    !Washout and volume calculations for individual cases
    
 write(echofileunit, *) "simulation type = ", simtypeflag
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
        write(echofileunit, *) "Main Loop "
        call MainLoop       
       
        
        select case  (simtypeflag)
        case (3)  
            waterbodytext = "Reservoir"
        case (2)
            waterbodytext = "Pond"
        case (1,4,5)
            waterbodytext =  "Custom"
        end select
        
   

   write(echofileunit, *) 'batch file ', trim(summary_outputfile)
   


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
   !
   !

        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if
        
        call output_processor(chem_index)

      !  call output_processor_PEAK(chem_index)
        
      !  call WriteInputs(aer_aq,temp_ref_aer,anae_aq ,temp_ref_anae,photo,rflat,hydro,koc,MWT_all(chem_index),&
        !VAPR_all(chem_index),sol_ALL(CHEM_INDEX))
        close (11) 
    !**********************************************************
  end do


end subroutine VVWM

end module VVWM_solution_setup