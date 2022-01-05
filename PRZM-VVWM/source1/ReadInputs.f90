module readinputs
implicit none
contains

    !******************************************************************
subroutine read_inputfile
!NEW read for new input file, reading same file as the PWC Input file ******
use constants_and_variables, ONLY: EchoFileUnit, inputfile, inputfile_unit_number,&
    is_koc, is_freundlich, is_nonequilibrium, &
    k_f_input, N_f_input, k_f_2_input, N_f_2_input, lowest_conc , number_subdelt, k2, &
    water_column_rate_input,water_column_ref_temp, xAerobic, &
    benthic_rate_input, benthic_ref_temp, xBenthic, &
    photo_input, xPhoto, &
    hydrolysis_rate_input, rflat, xhydro, &
    soil_degradation_rate_input, soil_ref_temp, xsoil, &
    plant_pesticide_degrade_rate,foliar_formation_ratio_12, foliar_formation_ratio_23, plant_washoff_coeff, & 
    mwt, vapor_press, solubilty, dair,HENRYK,Heat_of_Henry, q_10, &
    number_of_schemes, scheme_number, scheme_name,num_apps_in_schemes, number_of_scenarios, &
    app_reference_point_schemes  ,&
    application_rate_schemes, depth_schemes, split_schemes, efficiency_schemes, drift_schemes, &
    lag_schemes, periodicity_schemes,&
    method_schemes, days_until_applied_schemes,&
    scenario_names, working_directory, family_name,weatherfiledirectory,erflag, hydro_length, afield, nchem, simtypeflag,is_output_all
use utilities
        
    integer :: status, i, j
    integer, parameter :: Max_read_line = 200
    character(Len=Max_read_line) ::  wholeline
    integer :: absolute_app_month
    integer :: absolute_app_day 
    integer :: comma_1, comma_2,comma_3,comma_4,comma_5,comma_6,comma_7,comma_8
    
    write(EchoFileUnit, *) trim(inputfile )
    write(EchoFileUnit, *) "prepring to open input file"    
       

    
    
    OPEN(Unit = inputfile_unit_number, FILE=(inputfile),STATUS='OLD', IOSTAT=status  )
    IF (status .NE. 0) THEN
      WRITE(EchoFileUnit,*)'Problem with input file: ', inputfile
      stop
    ENDIF 
    
    read(inputfile_unit_number,*) !Version info    
    
    read(inputfile_unit_number,'(A)')  working_directory
        write(EchoFileUnit, *) 'Working Directory is: ', trim(working_directory) 
    read(inputfile_unit_number,'(A)') family_name 
        write(EchoFileUnit, *) 'Family Name is: ', trim(family_name)
    read(inputfile_unit_number,'(A)') weatherfiledirectory !Weather File
        write(EchoFileUnit, *) 'Weather File Directory: ', trim(weatherfiledirectory)
    read(inputfile_unit_number,*) is_koc
     write(EchoFileUnit, *) is_koc
     
    is_nonequilibrium = .False.
    is_freundlich = .False.
     read(inputfile_unit_number,*) nchem
    read(inputfile_unit_number,*) k_f_input(1),k_f_input(2),k_f_input(3) 
    
        write(EchoFileUnit, *) "Kf",  k_f_input(1),k_f_input(2),k_f_input(3)     
    read(inputfile_unit_number,*) N_f_input(1), N_f_input(2), N_f_input(3)
        write(EchoFileUnit, *) N_f_input(1), N_f_input(2), N_f_input(3)
    read(inputfile_unit_number,*) k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)
        write(EchoFileUnit, *) k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)       
    read(inputfile_unit_number,*) N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)
        write(EchoFileUnit, *) N_f_input(1), N_f_input(2), N_f_input(3)          
    read(inputfile_unit_number,*) K2(1), K2(2), K2(3)
        write(EchoFileUnit, *)K2(1), K2(2), K2(3)       
    read(inputfile_unit_number,*) lowest_conc, number_subdelt 
    read(inputfile_unit_number,*) water_column_rate_input(1),water_column_rate_input(2),water_column_rate_input(3), xAerobic(1),  xAerobic(2)
    read(inputfile_unit_number,*) water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)
    read(inputfile_unit_number,*) benthic_rate_input(1),benthic_rate_input(2),benthic_rate_input(3),xBenthic(1), xbenthic(2)
    read(inputfile_unit_number,*) benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)
    read(inputfile_unit_number,*) photo_input(1), photo_input(2), photo_input(3), xPhoto(1), xphoto(2)  
    read(inputfile_unit_number,*) rflat(1), rflat(2), rflat(3)       
    read(inputfile_unit_number,*) hydrolysis_rate_input(1),hydrolysis_rate_input(2),hydrolysis_rate_input(3) , xhydro(1), xhydro(2)
    read(inputfile_unit_number,*) soil_degradation_rate_input(1), soil_degradation_rate_input(2),soil_degradation_rate_input(3), xsoil(1), xsoil(2)
    read(inputfile_unit_number,*) soil_ref_temp(1), soil_ref_temp(2), soil_ref_temp(3)
    read(inputfile_unit_number,*) plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2), plant_pesticide_degrade_rate(3),foliar_formation_ratio_12, foliar_formation_ratio_23 
    read(inputfile_unit_number,*) plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3) 
    read(inputfile_unit_number,*) mwt(1), mwt(2), mwt(3)
    read(inputfile_unit_number,*) vapor_press(1), vapor_press(2),vapor_press(3)
    read(inputfile_unit_number,*) solubilty(1), solubilty(2), solubilty(3)
    read(inputfile_unit_number,*) HENRYK(1),HENRYK(2),HENRYK(3)
    read(inputfile_unit_number,*) DAIR(1),DAIR(2),DAIR(3) 
    read(inputfile_unit_number,*) Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)
    read(inputfile_unit_number,*) Q_10
         
    write(EchoFileUnit, *)K2(1), K2(2), K2(3)
    write(EchoFileUnit, *) lowest_conc, number_subdelt 
    write(EchoFileUnit, *) water_column_rate_input(1),water_column_rate_input(2),water_column_rate_input(3), xAerobic(1),  xAerobic(2)
    write(EchoFileUnit, *) water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)
    write(EchoFileUnit, *) benthic_rate_input(1),benthic_rate_input(2),benthic_rate_input(3),xBenthic(1), xbenthic(2)
    write(EchoFileUnit, *) benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)
    write(EchoFileUnit, *) photo_input(1), photo_input(2), photo_input(3), xPhoto(1), xphoto(2)  
    write(EchoFileUnit, *) rflat(1), rflat(2), rflat(3)       
    write(EchoFileUnit, *) hydrolysis_rate_input(1),hydrolysis_rate_input(2),hydrolysis_rate_input(3) , xhydro(1), xhydro(2)
    write(EchoFileUnit, *) soil_degradation_rate_input(1), soil_degradation_rate_input(2),soil_degradation_rate_input(3), xsoil(1), xsoil(2)
    write(EchoFileUnit, *) soil_ref_temp(1), soil_ref_temp(2), soil_ref_temp(3)
    write(EchoFileUnit, *) plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2), plant_pesticide_degrade_rate(3),foliar_formation_ratio_12, foliar_formation_ratio_23 
    write(EchoFileUnit, *) plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3) 
    write(EchoFileUnit, *) mwt(1), mwt(2), mwt(3)
    write(EchoFileUnit, *) vapor_press(1), vapor_press(2),vapor_press(3)
    write(EchoFileUnit, *) solubilty(1), solubilty(2), solubilty(3)
    write(EchoFileUnit, *) HENRYK(1),HENRYK(2),HENRYK(3)
    write(EchoFileUnit, *) DAIR(1),DAIR(2),DAIR(3) 
    write(EchoFileUnit, *) Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)
    write(EchoFileUnit, *) Q_10
    
    write(EchoFileUnit, *) "End of chemical property inputs"

    
    
    
    read(inputfile_unit_number,*) number_of_schemes
    write(EchoFileUnit, *) "*************************************************************"
    write(EchoFileUnit, *) "*************************************************************"
    
    write(EchoFileUnit, *) "schemes ", number_of_schemes
    
    allocate (num_apps_in_schemes(number_of_schemes))
    allocate (app_reference_point_schemes(number_of_schemes))
    allocate (days_until_applied_schemes(number_of_schemes,366)) 
    
    allocate (application_rate_schemes(number_of_schemes,366)) 
    allocate (method_schemes(number_of_schemes,366)) 
    allocate (depth_schemes(number_of_schemes,366)) 
    allocate (split_schemes(number_of_schemes,366)) 
    allocate (efficiency_schemes(number_of_schemes,366)) 
    allocate (drift_schemes(number_of_schemes,366)) 
    allocate (lag_schemes(number_of_schemes,366)) 
    allocate (periodicity_schemes(number_of_schemes,366)) 
    allocate (scenario_names(number_of_schemes,1000))       
    allocate ( number_of_scenarios(number_of_schemes))
         
    do i=1, number_of_schemes
        read(inputfile_unit_number,*) scheme_number, scheme_name 
          write(echofileunit,*) "Scheme Number & Name ", scheme_number, trim(scheme_name)
        
        read(inputfile_unit_number,*) app_reference_point_schemes(i)
        read(inputfile_unit_number,*) num_apps_in_schemes(i)
        
        do j=1, num_apps_in_schemes(i)
            select case (app_reference_point_schemes(i))
            case (0)
                read(inputfile_unit_number,'(A)')wholeline                    
                if (index(wholeline, '/') == index(wholeline, '/', .TRUE.)) then
                   ! only a day and month are given, so this is repeating every year
                                          
                   !convert string dates into integers
                   read(wholeline(1:(index(wholeline, '/')-1)),*)  absolute_app_month
                   comma_1 = index(wholeline, ',')
                   
                   read(wholeline((index(wholeline, '/')+1): (comma_1 -1)),*)  absolute_app_day
                   !Convert to julian day. Treat these similar to realtive application, using Jan 1 as referewnce date                                             
                   days_until_applied_schemes(i,j) = jd (1900, absolute_app_month,absolute_app_day)               
                else
                         !the year is include, so this is year specific
                end if
                
                comma_2 = comma_1 + index(wholeline((comma_1+1):len(wholeline)), ',')
                comma_3 = comma_2 + index(wholeline((comma_2+1):len(wholeline)), ',')
                comma_4 = comma_3 + index(wholeline((comma_3+1):len(wholeline)), ',')
                comma_5 = comma_4 + index(wholeline((comma_4+1):len(wholeline)), ',')
                comma_6 = comma_5 + index(wholeline((comma_5+1):len(wholeline)), ',')
                comma_7 = comma_6 + index(wholeline((comma_6+1):len(wholeline)), ',')
                comma_8 = comma_7 + index(wholeline((comma_7+1):len(wholeline)), ',')
                                        
                read(wholeline((comma_1+1):(comma_2-1)),*)         application_rate_schemes(i,j)         
                read(wholeline((comma_2+1):(comma_3-1)),*)         method_schemes(i,j)
                read(wholeline((comma_3+1):(comma_4-1)),*)         depth_schemes(i,j) 
                read(wholeline((comma_4+1):(comma_5-1)),*)         split_schemes(i,j)
                read(wholeline((comma_5+1):(comma_6-1)),*)         efficiency_schemes(i,j)
                read(wholeline((comma_6+1):(comma_7-1)),*)         drift_schemes(i,j) 
                read(wholeline((comma_7+1):(comma_8-1)),*)         lag_schemes(i,j)      
                read(wholeline((comma_8+1):len(wholeline)),*)      periodicity_schemes(i,j)
                
            case default
                     read(inputfile_unit_number,*) days_until_applied_schemes(i,j), application_rate_schemes(i,j), method_schemes(i,j), depth_schemes(i,j), split_schemes(i,j), efficiency_schemes(i,j), drift_schemes(i,j), lag_schemes(i,j), periodicity_schemes(i,j)
              
                     write(echofileunit,'(I3,G20.3, I4, 4F8.3, 3I4)') days_until_applied_schemes(i,j), application_rate_schemes(i,j), method_schemes(i,j), depth_schemes(i,j), split_schemes(i,j), efficiency_schemes(i,j), drift_schemes(i,j), lag_schemes(i,j), periodicity_schemes(i,j)
            end select                
        end do

        read(inputfile_unit_number,*) number_of_scenarios(i)
        write(echofileunit,*)"Number of Scenarios = ", number_of_scenarios(i)
           
        do j=1, number_of_scenarios(i)
            read(inputfile_unit_number,'(A512)')  scenario_names(i,j) !(i,j) i is scheme #, j is scenario #
             write(echofileunit,'(A)') trim(scenario_names(i,j))
        end do 
            
    enddo
     read(inputfile_unit_number,*) erflag
     read(inputfile_unit_number,*) hydro_length
     read(inputfile_unit_number,*) AField
     read(inputfile_unit_number,*)  simtypeflag
     read(inputfile_unit_number,*)  is_output_all
     
     
     
 write(EchoFileUnit, *) 'HL ', hydro_length
 write(EchoFileUnit, *)  'area of field ' ,  AField
 write(EchoFileUnit, *) 'water body type ', simtypeflag
  write(EchoFileUnit, *) 'is all output ',   is_output_all
     
    write(EchoFileUnit, *) "*************************************************************"
    write(EchoFileUnit, *) "*************************************************************"
        
end subroutine read_inputfile
    
    
             !  xsoil -->         READ(PRZMinputUnit,*,IOSTAT = status) MolarConvert_aq12_input(i),MolarConvert_aq13_input(i),MolarConvert_aq23_input(i), &
          !                                         MolarConvert_s12_input(i), MolarConvert_s13_input(i) ,MolarConvert_s23_input(i)
       
!**************************************************************************************************************    
    subroutine read_scenario_file(schemenumber,scenarionumber, error)
    use constants_and_variables, ONLY:echofileunit, scenario_names, scenario_id, &
        weatherfilename, latitude, num_crop_periods_input, &
        emd,emm,mad,mam,had,ham,max_root_depth,max_canopy_cover, max_number_crop_periods, &
        max_canopy_height, max_canopy_holdup,foliar_disposition, crop_lag, crop_periodicity  , PFAC,SFAC, min_evap_depth,& 
        FLEACH,PCDEPL,max_irrig ,UserSpecifiesDepth, user_irrig_depth,irtype, USLEK,USLELS,USLEP, IREG,SLP, &
        nhoriz,thickness,bd_input,fc_input, wp_input, oc_input, bd_input, Num_delx,sand_input,clay_input,dispersion_input, &
        is_temperature_simulated , albedo, emmiss, NUSLEC,GDUSLEC,GMUSLEC,cn_2, uslec, &
    runoff_extr_depth,runoff_decline,runoff_effic,erosion_depth, erosion_decline, erosion_effic,use_usleyears,Height_stagnant_air_layer_cm
    
    logical, intent(out) :: error
        integer, intent(in) :: schemenumber,scenarionumber
        character (len=512) filename
        integer :: i,status
 
        !local that will likely need to go to module
        logical :: lessThanAnnualGrowth, evergreen, greaterThanAnualGrowth

        
                character(len= 25) ::dummy
                
                real :: scalar_albedo
                
                
        write(echofileunit, *)  '**********  Start Reading Scenario Values ************************'  
        error = .FALSE.      
        filename = trim(scenario_names(schemenumber,scenarionumber))  
        write(echofileunit, '(A)') trim(filename)
        
        OPEN(Unit = 80, FILE=(filename),STATUS='OLD', IOSTAT=status  )
        IF (status .NE. 0) THEN
            WRITE(EchoFileUnit,*)'Problem with scenario file: ', status, filename
            Error = .TRUE.
            return
        ENDIF 
        
        
        
        read(80,'(A)') scenario_id
        read(80,'(A)') weatherfilename 
        write(echofileunit, *)  'weather ', trim(weatherfilename )
        read(80,*) latitude
        read(80,*)  !ignore get water type somewhere else  !A1,A2,A3,A4,A5, A6,A7
        read(80,*)  !UserSpecifiedFlowAvg.Checked, ReservoirFlowAvgDays.Text, CustomFlowAvgDays.Text)
        read(80,*)  !BurialButton.Checked 
        read(80,*) dummy !really AFIELD
        
        write(echofileunit, *) trim(dummy) , 'Area in m2 '  !, Afield
        !need to add area smewhere RETHINK this
   
        
        read(80,*)! waterAreaBox.Text)
        read(80,*) ! initialDepthBox.Text)
        read(80,*) ! maxDepthBox.Text)
        read(80,*) !massXferBox.Text)
        read(80,*) ! calculate_prben.Checked, prbenBox.Text)
        read(80,*) ! benthicdepthBox.Text)
        read(80,*) ! porosityBox.Text)
        read(80,*) ! bdBox.Text)
        read(80,*) ! foc2Box.Text)
        read(80,*) ! DOC2Box.Text)
        read(80,*) ! biomass2Box.Text)
        read(80,*) ! dfacBox.Text)
        read(80,*) ! ssBox.Text)
        read(80,*) ! ChlorophyllBox.Text)
        read(80,*) ! foc1Box.Text)
        read(80,*) ! DOC1Box.Text)
        read(80,*) ! Biomass1Box.Text)
        read(80,*) ! vbNewLine & EpaDefaultsCheck.Checked                                                            'line 53
        read(80,*) ! String.Format("{0}{1},{2}", vbNewLine, ReservoirCroppedAreaBox.Text, CustomCroppedAreaBox.Text) 'Line 54
        read(80,*) ! vbNewLine
               
        read(80,'(A)') dummy !   msg = "******** start of PRZM information ******************" & vbNewLine
        write(echofileunit, *)  trim(dummy)
        
        read(80,*) lessThanAnnualGrowth, evergreen, greaterThanAnualGrowth
        write(echofileunit, *)  lessThanAnnualGrowth, evergreen, greaterThanAnualGrowth
              
        read(80,*) num_crop_periods_input
        write(echofileunit, *) "Crop Cycles per year: ", num_crop_periods_input
        read(80,*) ! msg & String.Format("{0}{1},", vbNewLine, simpleRB.Checked)

        do  i=1,num_crop_periods_input
            read(80,*) emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i),max_root_depth(i),max_canopy_cover(i),  &
                max_canopy_height(i), max_canopy_holdup(i),foliar_disposition(i), crop_periodicity(i), crop_lag(i)   
            !PWC saves canopy cover it as a percent, but przm needs fraction
            max_canopy_cover(i)=max_canopy_cover(i)/100.
            
            write(echofileunit, '(6I3,4F8.3, 3I5)') emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i),max_root_depth(i), &
                max_canopy_cover(i),max_canopy_height(i),max_canopy_holdup(i),foliar_disposition(i),crop_periodicity(i),crop_lag(i)        
        end do
        
        do i=1, max_number_crop_periods - num_crop_periods_input
            read(80,*) 
            write(echofileunit, *) i
        end do
        
        
        read(80,*)  !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altRootDepth.Text, altCanopyCover.Text, altCanopyHeight.Text, altCanopyHoldup.Text)
        read(80,*)  !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altEmergeDay.Text, altEmergeMon.Text, altDaysToMaturity.Text, altDaysToHarvest.Text)
        read(80,*)  PFAC,SFAC, min_evap_depth 
        read(80,*) ! msg = msg & vbNewLine & "*** irrigation information start ***"        
        read(80,*) irtype !0 = none, 1 flood, 2 undefined 3 = overcanopy 4 = under canopy 5 = undefined, 6 over canopy       
        read(80,*) FLEACH,PCDEPL,max_irrig  !fleach.Text, depletion.Text, rateIrrig.Text)        

        read(80,*) UserSpecifiesDepth, user_irrig_depth  ! UserSpecifiesIrrigDepth.Checked, IrrigationDepthUserSpec.Text)
        read(80,'(A)')  !msg = msg & vbNewLine & "*** spare line for expansion"        
        read(80,'(A)') !msg = msg & vbNewLine & "*** spare line for expansion"       
        read(80,'(A)')  !msg = msg & vbNewLine & "*** spare line for expansion"         
        read(80,*) USLEK,USLELS,USLEP        
        read(80,*) IREG,SLP
        read(80,*) !line 51   *** Horizon Info *******          
        read(80,*) NHORIZ        
        read(80,*) (thickness(i), i=1, nhoriz)
        read(80,*) (bd_input(i), i=1, nhoriz) 
        read(80,*) (fc_input(i), i=1, nhoriz)
        read(80,*) (wp_input(i), i=1, nhoriz)
        read(80,*) (oc_input(i), i=1, nhoriz)      
        read(80,*) (Num_delx(i), i=1, nhoriz)
        read(80,*) (sand_input(i), i=1, nhoriz)        
        read(80,*) (clay_input(i), i=1, nhoriz)
        
        write(echofileunit,*) 
        
        write(echofileunit,*) 'Nhori', NHORIZ        
        write(echofileunit,*) 'THCK ', (thickness(i), i=1, nhoriz)
        write(echofileunit,*) 'BD   ', (bd_input(i), i=1, nhoriz) 
        write(echofileunit,*) 'FC   ', (fc_input(i), i=1, nhoriz)
        write(echofileunit,*) 'WP   ', (wp_input(i), i=1, nhoriz)
        write(echofileunit,*) 'OC   ', (oc_input(i), i=1, nhoriz)      
        write(echofileunit,*) 'DELX ', (Num_delx(i), i=1, nhoriz)
        write(echofileunit,*) 'Sand ', (sand_input(i), i=1, nhoriz)        
        write(echofileunit,*) 'Clay ', (clay_input(i), i=1, nhoriz)
        
        
        
        
        
        dispersion_input = 0.0


   
        read(80,*)!msg = msg & vbNewLine & "*** Horizon End, Temperature Start ********"
        !
        read(80,*) scalar_albedo !msg = msg & String.Format("{0}{1},{2}", vbNewLine, albedoBox.Text, bcTemp.Text)
        ALBEDO = scalar_albedo  !albedo is monthly in przm       
        EMMISS = 0.97           !0.97 is emmisivity fixed
        
        read(80,*) is_temperature_simulated !msg = msg & vbNewLine & simTemperature.Checked
       
        write (echofileunit, *)'Is temperature simulated: ', is_temperature_simulated
        read(80,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(80,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(80,*) !msg = msg & vbNewLine & "*** Erosion & Curve Number Info **********"
              
        read(80,*) NUSLEC  !msg = msg & vbNewLine & NumberOfFactors.Text
 write (echofileunit, *) 'How many CN & USLE: ', nuslec
        
        read(80,*) (GDUSLEC(i), i=1,nuslec)
        read(80,*) (GMUSLEC(i), i=1,nuslec)
        read(80,*) (CN_2(i), i=1,nuslec)
        read(80,*) (USLEC(i), i=1,nuslec)
        read(80,*) !no longer use manning n mngn
      write (echofileunit, *) 'CN: ', (CN_2(i), i=1,nuslec)
      READ(80,*) runoff_extr_depth,runoff_decline,runoff_effic     
      READ(80,*)  erosion_depth, erosion_decline, erosion_effic

      READ(80,*)  use_usleyears 
      
      read(80,*) !years of uslec need to add later if we want years
      read(80,*) Height_stagnant_air_layer_cm !msg = msg & vbNewLine & volatilizationBoundaryBox.Text
     
        
      write (echofileunit, *) 'stagnant layer ',Height_stagnant_air_layer_cm


       ! ! simtypeflag  
       ! ! 1= vary volume w/ flowthrough, 2=const volume, no flowthrough, 3=const vol, flowthrough, 
       ! ! 4 = const vol no flow, 5 = const vol, flow, 
       ! ! 2 & 3 For use with the USEPA pond and reservoir ( and other situations) 
       !If (A1) then !EPAreservoir.Checked = currentrow(0)
       !     simtypeflag=3
       ! else if (A2) then !EPApond.Checked = currentrow(1)
       !     simtypeflag=2
       ! else if (A3) then !VaryVolFlow.Checked = currentrow(2)  
       !     simtypeflag=1
       ! elseif (A4) then !ConstVolNoFlow.Checked = currentrow(3) 
       !     simtypeflag=4
       ! elseif (A5) then !ConstVolFlow.Checked = currentrow(4)   
       !     simtypeflag=5
       ! elseif (A6) then !GroundWater.Checked = currentrow(5)     
       !     !no waterbody
       ! elseif (A7) then !PRZMonly.Checked = currentrow(6)
       !     !no waterbody
       ! end if
       ! 
   



        
        close (80)
    end subroutine read_scenario_file
    
  

    
       !************************************************************
    subroutine Read_Weatherfile
     !open weather file, count file, allocate the weather variables, read in dat and place in vectors to store in constant/variable mod.
      
    use utilities_1
    use constants_and_Variables, ONLY:precip, pet_evap,air_temperature, wind_speed, solar_radiation, num_records, &
                                        EchoFileUnit,metfileunit,weatherfilename, startday, first_year, last_year, num_years,first_mon, first_day
      
      integer :: dummy, status,i, year

      OPEN(Unit = metfileunit,FILE=trim(adjustl(weatherfilename)),STATUS='OLD', IOSTAT=status)
      IF (status .NE. 0) THEN
         write(EchoFileUnit,*)'Problem opening weather file. Name is ', trim(adjustl(weatherfilename))
         stop
      ENDIF   
      
      num_records = 0
      
      !Read first Date of Simulation
      read (metfileunit,*, IOSTAT=status) first_mon, first_day, first_year
      
      if (status /= 0) then
          write(EchoFileUnit,*) "No data or other problem in Weather File"
          stop
      end if
      
      startday = jd(first_year, first_mon, first_day)
 
      !Count the records in the weather file
      num_records=1
      do        
          read (metfileunit,*, IOSTAT=status) dummy
          if (status /= 0)exit
          num_records=num_records+1
      end do
      write (EchoFileUnit,*) "Weather file total days = ",num_records
      
      !Allocate the weather parameters 
      allocate (precip(num_records))
      allocate (pet_evap(num_records))
      allocate (air_temperature(num_records))
      allocate (wind_speed(num_records))
      allocate (solar_radiation(num_records))
      
      !rewind and read in weather data
      rewind(metfileunit)      
      do i = 1, num_records
          READ(MetFileUnit,*, IOSTAT=status) dummy,dummy,year,precip(i),pet_evap(i),air_temperature(i),wind_speed(i),solar_radiation(i)
          if (status /= 0)then
              write (EchoFileUnit,*) "weather file problem on line ", i, status
              exit
          end if
      end do
  
      last_year = year
      
      num_years = last_year-first_year+1
      
      close(metfileunit)
       write (EchoFileUnit,*) "Finished reading weather file"
    end subroutine Read_Weatherfile 
    
    

end module readinputs