module readinputs
implicit none
contains

    !******************************************************************
subroutine read_inputfile
!NEW read for new input file, reading same file as the PWC Input file ******
use constants_and_variables, ONLY:  inputfile, inputfile_unit_number,&
    is_koc, is_freundlich, is_nonequilibrium, &
    k_f_input, N_f_input, k_f_2_input, N_f_2_input, lowest_conc , number_subdelt, k2, &
    water_column_ref_temp, xAerobic, &
    benthic_halflife_input, benthic_ref_temp, xBenthic, &
    photo_halflife_input, xPhoto, &
    hydrolysis_halflife_input, rflat, xhydro, &
    soil_degradation_halflife_input, soil_ref_temp, xsoil, &
    plant_pesticide_degrade_rate,foliar_formation_ratio_12, foliar_formation_ratio_23, plant_washoff_coeff, & 
    mwt, vapor_press, solubilty, dair,Henry_unitless,Heat_of_Henry, q_10, &
    number_of_schemes, scheme_number, scheme_name,num_apps_in_schemes, number_of_scenarios, &
    app_reference_point_schemes  ,&
    application_rate_schemes, depth_schemes, split_schemes, drift_schemes, &
    lag_schemes, periodicity_schemes,&
    method_schemes, days_until_applied_schemes,&
    scenario_names, working_directory, family_name,weatherfiledirectory,erflag, nchem,  &
    ADJUST_CN, water_column_halflife_input, &
    is_runoff_output, is_erosion_output, is_runoff_chem_output, is_erosion_chem_output , &
    is_conc_bottom_output,is_daily_volatilized_output,is_daily_chem_leached_output, leachdepth,&
    is_chem_decayed_part_of_soil_output, decay_start, decay_end, &
    is_chem_in_part_soil_output, fieldmass_start, fieldmass_end,is_chem_on_foliage_output , is_precipitation_output , &
    is_evapotranspiration_output, is_soil_water_output, is_irrigation_output,is_chem_in_all_soil_output, &
    is_infiltration_at_depth_output,infiltration_point,is_infiltrated_bottom_output,infiltration_point,is_infiltrated_bottom_output, &
    extra_plots, temp_PLNAME,  temp_chem_id, temp_MODE,temp_ARG,temp_ARG2,temp_CONST,&
    is_constant_profile, is_ramp_profile, ramp1, ramp2, ramp3, is_exp_profile , exp_profile1, exp_profile2, is_total_degradation, &
    is_app_window, app_window_span, app_window_step, is_timeseriesfile, &
	is_waterbody_info_output 

use waterbody_parameters, ONLY: itsapond, itsareservoir, itsother,waterbody_names,    USEPA_reservoir,USEPA_pond 
use utilities
        
    integer :: num_waterbodies, num_special_waterbodies

    integer :: status, i, j
    integer, parameter :: Max_read_line = 200
    character(Len=Max_read_line) ::  wholeline
    integer :: absolute_app_month
    integer :: absolute_app_day 
    integer :: comma_1, comma_2,comma_3,comma_4,comma_5,comma_6,comma_7,comma_8
    integer :: start_wb

	
    write(*,*) trim(inputfile )

    OPEN(Unit = inputfile_unit_number, FILE=(inputfile),STATUS='OLD', IOSTAT=status  )
    IF (status .NE. 0) THEN
      WRITE(*,*)'Problem with PRZMVVWM input file: ', inputfile
      stop
    ENDIF 
    
    read(inputfile_unit_number,*) !Version info                                       !Line 1
    
    read(inputfile_unit_number,'(A)')  working_directory             !Line 2

        write(*,*) 'Working Directory is: ', trim(working_directory) 
    read(inputfile_unit_number,'(A)') family_name                                     !Line 3
       write(*,*) 'Family Name is: ', trim(family_name)
    read(inputfile_unit_number,'(A)') weatherfiledirectory                            !Line 4 
	write(*,*) 'weather directory is ', trim(weatherfiledirectory) 
    read(inputfile_unit_number,*) is_koc,is_freundlich , is_nonequilibrium            !Line 5
    read(inputfile_unit_number,*) nchem                                               !Line 6
    read(inputfile_unit_number,*) k_f_input(1),k_f_input(2),k_f_input(3)              !Line 7  
	
	write(*,*) 'Sorption coeff. ',  k_f_input(1),k_f_input(2),k_f_input(3)
    read(inputfile_unit_number,*) N_f_input(1), N_f_input(2), N_f_input(3)            !Line 8
	write(*,*) 'Freundlich exponents ' , N_f_input(1), N_f_input(2), N_f_input(3) 
    read(inputfile_unit_number,*) k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)      !Line 9
	write(*,*) 'Sorption coeff 2: ',k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)
    read(inputfile_unit_number,*) N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)      !Line 10
	write(*,*) 'Freundlich exponents 2 ', N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)
    read(inputfile_unit_number,*) K2(1), K2(2), K2(3)                                 !Line 11
	write(*,*) 'Mass xfer: ',  K2(1), K2(2), K2(3)
    read(inputfile_unit_number,*) lowest_conc, number_subdelt                         !Line 12
    write(*,*) 'lowest conc to linear:' , lowest_conc, 'subdelt', number_subdelt 
    read(inputfile_unit_number,*) water_column_halflife_input(1),water_column_halflife_input(2),water_column_halflife_input(3), xAerobic(1),  xAerobic(2)
    write(*,*) 'Water col halflife ', water_column_halflife_input(1),water_column_halflife_input(2),water_column_halflife_input(3)
	read(inputfile_unit_number,*) water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)
    read(inputfile_unit_number,*) benthic_halflife_input(1),benthic_halflife_input(2),benthic_halflife_input(3),xBenthic(1), xbenthic(2)
    read(inputfile_unit_number,*) benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)
    read(inputfile_unit_number,*) photo_halflife_input(1), photo_halflife_input(2), photo_halflife_input(3), xPhoto(1), xphoto(2) 
    read(inputfile_unit_number,*) rflat(1), rflat(2), rflat(3)       
    read(inputfile_unit_number,*) hydrolysis_halflife_input(1),hydrolysis_halflife_input(2),hydrolysis_halflife_input(3) , xhydro(1), xhydro(2)
    write(*,*) 'hydrol halflife: ', hydrolysis_halflife_input(1),hydrolysis_halflife_input(2),hydrolysis_halflife_input(3)
    read(inputfile_unit_number,*) soil_degradation_halflife_input(1), soil_degradation_halflife_input(2),soil_degradation_halflife_input(3), xsoil(1), xsoil(2), is_total_degradation
    write(*,*) 'soil conversions',  xsoil(1), xsoil(2)
	
	read(inputfile_unit_number,*) soil_ref_temp(1), soil_ref_temp(2), soil_ref_temp(3)
    read(inputfile_unit_number,*) plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2), plant_pesticide_degrade_rate(3),foliar_formation_ratio_12, foliar_formation_ratio_23 
    read(inputfile_unit_number,*) plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3) 
    read(inputfile_unit_number,*) mwt(1), mwt(2), mwt(3)                                !Line 24
    read(inputfile_unit_number,*) vapor_press(1), vapor_press(2),vapor_press(3)
    read(inputfile_unit_number,*) solubilty(1), solubilty(2), solubilty(3)                                !Line 26
    read(inputfile_unit_number,*) Henry_unitless(1),Henry_unitless(2),Henry_unitless(3)
    read(inputfile_unit_number,*) DAIR(1),DAIR(2),DAIR(3)                                 !Line 28
    read(inputfile_unit_number,*) Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)
    read(inputfile_unit_number,*) Q_10                                                     !Line 30
      
    read(inputfile_unit_number,*) is_constant_profile
    read(inputfile_unit_number,*) is_ramp_profile, ramp1, ramp2, ramp3  !ramp1 is first plateau distance, ramp2 is second plateau distance, ramp3 is second plateau value
    read(inputfile_unit_number,*) is_exp_profile , exp_profile1, exp_profile2               !Line 33

    read(inputfile_unit_number,*) number_of_schemes                                         !Line 34

    write(*,*) "Number of schemes = ", number_of_schemes
    
    
    allocate (num_apps_in_schemes(number_of_schemes))
    allocate (app_reference_point_schemes(number_of_schemes))
    allocate (days_until_applied_schemes(number_of_schemes,366)) 
    
    

    allocate (application_rate_schemes(number_of_schemes,366)) 
    allocate (method_schemes(number_of_schemes,366)) 
    allocate (depth_schemes(number_of_schemes,366)) 
    allocate (split_schemes(number_of_schemes,366)) 
    allocate (drift_schemes(number_of_schemes,366)) 
    allocate (lag_schemes(number_of_schemes,366)) 
    allocate (periodicity_schemes(number_of_schemes,366)) 
    allocate (scenario_names(number_of_schemes,1000))       
    allocate (number_of_scenarios(number_of_schemes))

    allocate (is_app_window(number_of_schemes))
    allocate (app_window_span(number_of_schemes))
    allocate (app_window_step(number_of_schemes))
    

    do i=1, number_of_schemes
        read(inputfile_unit_number,*) scheme_number, scheme_name 
        write(*,*) "Scheme Number & Name ", scheme_number, trim(scheme_name)
         
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
                   !Convert to julian day. Treat these similar to realtive application, using Jan 1 as reference date                                             
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
             !   comma_8 = comma_7 + index(wholeline((comma_7+1):len(wholeline)), ',')
                                        
                read(wholeline((comma_1+1):(comma_2-1)),*)         application_rate_schemes(i,j)         
                read(wholeline((comma_2+1):(comma_3-1)),*)         method_schemes(i,j)
                read(wholeline((comma_3+1):(comma_4-1)),*)         depth_schemes(i,j) 
                read(wholeline((comma_4+1):(comma_5-1)),*)         split_schemes(i,j)
                read(wholeline((comma_5+1):(comma_6-1)),*)         drift_schemes(i,j)	
                read(wholeline((comma_6+1):(comma_7-1)),*)         periodicity_schemes(i,j)  
                read(wholeline((comma_7+1):len(wholeline)),*)         lag_schemes(i,j)  
				
                !read(wholeline((comma_8+1):len(wholeline)),*)       
                
            case default
                     read(inputfile_unit_number,*) days_until_applied_schemes(i,j), application_rate_schemes(i,j), &
                         method_schemes(i,j), depth_schemes(i,j), split_schemes(i,j),   &
                         drift_schemes(i,j), periodicity_schemes(i,j) , lag_schemes(i,j)           
            end select                
		end do

		
!**********************************************************
!no longer reading in efficiency , Calculate it later....in scheme load routine      

!*****************************************************************

        read(inputfile_unit_number,*) is_app_window(i), app_window_span(i), app_window_step(i)
        if (not(is_app_window(i) )) then 
            app_window_span(i) =0  !the stepping starts with zero, so the span iz zero for only one iteration
            app_window_step(i)= 1          
        end if
        
    
        
        read(inputfile_unit_number,*) number_of_scenarios(i)
        write(*,*)"Number of Scenarios = ", number_of_scenarios(i)
           
        do j=1, number_of_scenarios(i)
            read(inputfile_unit_number,'(A512)')  scenario_names(i,j) !(i,j) i is scheme #, j is scenario #
             write(*,'(A)') trim(scenario_names(i,j))
        end do 
            
	enddo
	
	
     read(inputfile_unit_number,*) erflag
     read(inputfile_unit_number,*) 
     read(inputfile_unit_number,*) 
     read(inputfile_unit_number,*) 
     read(inputfile_unit_number,*) 
     read(inputfile_unit_number,*) 
     read(inputfile_unit_number,*) adjust_cn
     read(inputfile_unit_number,*) itsapond,itsareservoir,itsother
     read(inputfile_unit_number,*) num_special_waterbodies !special water bodies
     
     If (.NOT. (itsapond .AND. itsareservoir)) start_wb = 0 
     IF (itsapond .NEQV. itsareservoir) start_wb = 1
     IF (itsapond .AND. itsareservoir) start_wb = 2
   
     !The size of the array is the exact number of waterbodies, this SIZE is used later for setting  the run loop
     
    
     If (itsother) then
          num_waterbodies = num_special_waterbodies + start_wb
         allocate (waterbody_names( num_waterbodies )) !add possibility of USEPA reservoir and pond. 
     else
         num_waterbodies = start_wb
         allocate (waterbody_names( num_waterbodies )) ! no special water bodies
     end if
     
         
     If (itsapond .AND. itsareservoir) then
        waterbody_names(1) = USEPA_pond 
        waterbody_names(2) = USEPA_reservoir    
     else if (itsapond .AND. .NOT. itsareservoir) then
        waterbody_names(1) = USEPA_pond 
     else if (.NOT. itsapond .AND. itsareservoir) then
        waterbody_names(1) = USEPA_reservoir
     end if
   

    do i = 1 + start_wB,  num_special_waterbodies + start_wB      
        if (itsother) then      
           read(inputfile_unit_number,*) waterbody_names(i)       
        else !skip over the special water bodies that nmight be listed, and its other not checked
           read(inputfile_unit_number,*)  
        endif  
    end do
    
     write(*,*) 'Total Number of waterbodies',num_waterbodies
     do i=1, num_waterbodies
         write(*,*) trim( waterbody_names(i))
     end do
     
    !Read in optional output to zts file
     is_timeseriesfile = .FALSE.
	
    read(inputfile_unit_number,*) is_runoff_output  
	    if (is_runoff_output ) is_timeseriesfile = .TRUE.	
    read(inputfile_unit_number,*) is_erosion_output  
		if (is_erosion_output ) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_runoff_chem_output
	    if (is_runoff_chem_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_erosion_chem_output 
         if (is_erosion_chem_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_conc_bottom_output  
	    if (is_conc_bottom_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_daily_volatilized_output   
        if (is_daily_volatilized_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_daily_chem_leached_output, leachdepth
	    if (is_daily_chem_leached_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_decayed_part_of_soil_output, decay_start, decay_end
        if (is_chem_decayed_part_of_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_in_all_soil_output
	    if (is_chem_in_all_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_in_part_soil_output, fieldmass_start, fieldmass_end
        if (is_chem_in_part_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_chem_on_foliage_output 
        if (is_chem_on_foliage_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_precipitation_output
	    if (is_precipitation_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_evapotranspiration_output
	    if (is_evapotranspiration_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_soil_water_output
	    if (is_soil_water_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_irrigation_output
        if (is_irrigation_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_infiltration_at_depth_output,infiltration_point
        if (is_infiltration_at_depth_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_infiltrated_bottom_output
        if (is_infiltrated_bottom_output) is_timeseriesfile = .TRUE.
		
		
	!these next 3 are for output from waterbody, this goes into a separate output file
	read(inputfile_unit_number,*) is_waterbody_info_output   !waterbody depth, conc and benthic
	
	read(inputfile_unit_number,*)  !expansion lines
	read(inputfile_unit_number,*)	
	read(inputfile_unit_number,*)	
	read(inputfile_unit_number,*)
	read(inputfile_unit_number,*)	
	read(inputfile_unit_number,*)	
	read(inputfile_unit_number,*)	
		
		
    read(inputfile_unit_number,*) extra_plots
	    if (extra_plots > 0) is_timeseriesfile = .TRUE.

		write(*,*) "reading extra time series if any"
		
    do i = 1, extra_plots
        read(inputfile_unit_number,*)  temp_PLNAME(i),  temp_chem_id(i), temp_MODE(i),temp_ARG(i),temp_ARG2(i),temp_CONST(i)      
	end do
    
end subroutine read_inputfile
    
    
             !  xsoil -->         READ(PRZMinputUnit,*,IOSTAT = status) MolarConvert_aq12_input(i),MolarConvert_aq13_input(i),MolarConvert_aq23_input(i), &
          !                                         MolarConvert_s12_input(i), MolarConvert_s13_input(i) ,MolarConvert_s23_input(i)
       
!**************************************************************************************************************    
    subroutine read_scenario_file(schemenumber,scenarionumber, error)
    use constants_and_variables, ONLY:ScenarioFileUnit, scenario_names, &
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
        
        character(len= 50) ::dummy
        real :: scalar_albedo
                                
        write(*,*)  '**********  Start Reading Scenario Values ************************'  
        error = .FALSE.      
        filename = trim(scenario_names(schemenumber,scenarionumber))  
        write(*,*) trim(filename)      
        OPEN(Unit = ScenarioFileUnit, FILE=(filename),STATUS='OLD', IOSTAT=status  )
        IF (status .NE. 0) THEN
            WRITE(*,*)'Problem opening scenario file: ', status, trim(filename)
            Error = .TRUE.
            return
        ENDIF 
        
        read(ScenarioFileUnit,'(A)') !scenario_id
        read(ScenarioFileUnit,'(A)') weatherfilename 
        write(*,*)  'weather: ', trim(weatherfilename )
        read(ScenarioFileUnit,*,  IOSTAT=status ) latitude	
			IF (status .NE. 0) then
				call scenario_error(error)  !set the error to true
                return
			end if
        
        !the following comes from elsewhere:
        read(ScenarioFileUnit,*)  !ignore get water type somewhere else  !A1,A2,A3,A4,A5, A6,A7
        read(ScenarioFileUnit,*)  !UserSpecifiedFlowAvg.Checked, ReservoirFlowAvgDays.Text, CustomFlowAvgDays.Text)
        read(ScenarioFileUnit,*)  !BurialButton.Checked default is always on in pwc 2020
        read(ScenarioFileUnit,*)  !AFIELD       
        read(ScenarioFileUnit,*) ! waterAreaBox.Text)
        read(ScenarioFileUnit,*) ! initialDepthBox.Text)
        read(ScenarioFileUnit,*) ! maxDepthBox.Text)
        read(ScenarioFileUnit,*) ! massXferBox.Text)
        read(ScenarioFileUnit,*) ! calculate_prben.Checked, prbenBox.Text)
        read(ScenarioFileUnit,*) ! benthicdepthBox.Text)
        read(ScenarioFileUnit,*) ! porosityBox.Text)
        read(ScenarioFileUnit,*) ! bdBox.Text)
        read(ScenarioFileUnit,*) ! foc2Box.Text)
        read(ScenarioFileUnit,*) ! DOC2Box.Text)
        read(ScenarioFileUnit,*) ! biomass2Box.Text)
        read(ScenarioFileUnit,*) ! dfacBox.Text)
        read(ScenarioFileUnit,*) ! ssBox.Text)
        read(ScenarioFileUnit,*) ! ChlorophyllBox.Text)
        read(ScenarioFileUnit,*) ! foc1Box.Text)
        read(ScenarioFileUnit,*) ! DOC1Box.Text)
        read(ScenarioFileUnit,*) ! Biomass1Box.Text)
        read(ScenarioFileUnit,*) ! vbNewLine & EpaDefaultsCheck.Checked                                                            'line 53
        read(ScenarioFileUnit,*) ! String.Format("{0}{1},{2}", vbNewLine, ReservoirCroppedAreaBox.Text, CustomCroppedAreaBox.Text) 'Line 54
        read(ScenarioFileUnit,*) ! vbNewLine
               
        read(ScenarioFileUnit,'(A)') dummy !   msg = "******** start of PRZM information ******************" & vbNewLine
        
        read(ScenarioFileUnit,*, IOSTAT=status) lessThanAnnualGrowth, evergreen, greaterThanAnualGrowth
    			IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if				
        read(ScenarioFileUnit,*,  IOSTAT=status ) num_crop_periods_input
    			IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if		
		
        write(*,*) "Crop Cycles per year: ", num_crop_periods_input
        read(ScenarioFileUnit,*) ! msg & String.Format("{0}{1},", vbNewLine, simpleRB.Checked)

        do  i=1,num_crop_periods_input
            read(ScenarioFileUnit,*, IOSTAT = status) emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i),max_root_depth(i),max_canopy_cover(i),  &
                max_canopy_height(i), max_canopy_holdup(i),foliar_disposition(i), crop_periodicity(i),  crop_lag(i) 
			    IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if
					
            !PWC saves canopy cover it as a percent, but przm needs fraction
            max_canopy_cover(i)=max_canopy_cover(i)/100.
            
            write(*,'(8I6)') emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i), crop_periodicity(i),  crop_lag(i) 
        end do
  
        do i=1, max_number_crop_periods - num_crop_periods_input
            read(ScenarioFileUnit,'(A)') dummy
		end do
		     
        read(ScenarioFileUnit,*)     !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altRootDepth.Text, altCanopyCover.Text, altCanopyHeight.Text, altCanopyHoldup.Text)     
        read(ScenarioFileUnit,*)     !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altEmergeDay.Text, altEmergeMon.Text, altDaysToMaturity.Text, altDaysToHarvest.Text)
        read(ScenarioFileUnit,*, IOSTAT= status)  PFAC,SFAC, min_evap_depth 
			    IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if		
	
        
        read(ScenarioFileUnit,*) ! msg = msg & vbNewLine & "*** irrigation information start ***"        
        read(ScenarioFileUnit,*) irtype !0 = none, 1 flood, 2 undefined 3 = overcanopy 4 = under canopy 5 = undefined, 6 over canopy       
        read(ScenarioFileUnit,*) FLEACH,PCDEPL,max_irrig  !fleach.Text, depletion.Text, rateIrrig.Text)        
        
        write(*,*) 'Irrigation Type ', irtype
        write(*,*) 'FLEACH,PCDEPL,max_irrig', FLEACH,PCDEPL,max_irrig
        
        read(ScenarioFileUnit,*) UserSpecifiesDepth !, user_irrig_depth  ! UserSpecifiesIrrigDepth.Checked, IrrigationDepthUserSpec.Text)

        if (UserSpecifiesDepth) then
            backspace(ScenarioFileUnit)  !if true the userirrig depth will be blankl sometinmes
            read(ScenarioFileUnit,*) UserSpecifiesDepth, user_irrig_depth        
        endif
        
        
        read(ScenarioFileUnit,'(A)')  !msg = msg & vbNewLine & "*** spare line for expansion"        
        read(ScenarioFileUnit,'(A)') !msg = msg & vbNewLine & "*** spare line for expansion"       
        read(ScenarioFileUnit,'(A)')  !msg = msg & vbNewLine & "*** spare line for expansion"         
        read(ScenarioFileUnit,*) USLEK,USLELS,USLEP        
        read(ScenarioFileUnit,*) IREG,SLP
        read(ScenarioFileUnit,*) !line 51   *** Horizon Info *******          
        read(ScenarioFileUnit,*) NHORIZ        
        read(ScenarioFileUnit,*) (thickness(i), i=1, nhoriz)
        read(ScenarioFileUnit,*) (bd_input(i), i=1, nhoriz) 
        read(ScenarioFileUnit,*) (fc_input(i), i=1, nhoriz)
        read(ScenarioFileUnit,*) (wp_input(i), i=1, nhoriz)
        read(ScenarioFileUnit,*) (oc_input(i), i=1, nhoriz)      
        read(ScenarioFileUnit,*) (Num_delx(i), i=1, nhoriz)
        read(ScenarioFileUnit,*) (sand_input(i), i=1, nhoriz)        
        read(ScenarioFileUnit,*) (clay_input(i), i=1, nhoriz)
    
        
        !write(*,*) 'Nhori', NHORIZ        
        !write(*,*) 'THCK ', (thickness(i), i=1, nhoriz)
        !write(*,*) 'BD   ', (bd_input(i), i=1, nhoriz) 
        !write(*,*) 'FC   ', (fc_input(i), i=1, nhoriz)
        !write(*,*) 'WP   ', (wp_input(i), i=1, nhoriz)
        !write(*,*) 'OC   ', (oc_input(i), i=1, nhoriz)      
        !write(*,*) 'DELX ', (Num_delx(i), i=1, nhoriz)
        !write(*,*) 'Sand ', (sand_input(i), i=1, nhoriz)        
        !write(*,*) 'Clay ', (clay_input(i), i=1, nhoriz)
              
        dispersion_input = 0.0

        read(ScenarioFileUnit,*)!msg = msg & vbNewLine & "*** Horizon End, Temperature Start ********"
        !
        read(ScenarioFileUnit,*) scalar_albedo !msg = msg & String.Format("{0}{1},{2}", vbNewLine, albedoBox.Text, bcTemp.Text)
        ALBEDO = scalar_albedo  !albedo is monthly in przm       
        EMMISS = 0.97           !0.97 is emmisivity fixed
        
        read(ScenarioFileUnit,*) is_temperature_simulated !msg = msg & vbNewLine & simTemperature.Checked

        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "*** Erosion & Curve Number Info **********"
              
        read(ScenarioFileUnit,*) NUSLEC  !msg = msg & vbNewLine & NumberOfFactors.Text
 write (*,*) 'How many CN & USLE: ', nuslec
        
        read(ScenarioFileUnit,*) (GDUSLEC(i), i=1,nuslec)
        read(ScenarioFileUnit,*) (GMUSLEC(i), i=1,nuslec)
        read(ScenarioFileUnit,*) (CN_2(i), i=1,nuslec)
        read(ScenarioFileUnit,*) (USLEC(i), i=1,nuslec)
        read(ScenarioFileUnit,*) !no longer use manning n mngn
      write (*,*) 'CN: ', (CN_2(i), i=1,nuslec)
      READ(ScenarioFileUnit,*) runoff_extr_depth,runoff_decline,runoff_effic     
      READ(ScenarioFileUnit,*)  erosion_depth, erosion_decline, erosion_effic

      READ(ScenarioFileUnit,*)  use_usleyears 
      
      read(ScenarioFileUnit,*) !years of uslec need to add later if we want years
      read(ScenarioFileUnit,*) Height_stagnant_air_layer_cm !msg = msg & vbNewLine & volatilizationBoundaryBox.Text
     
        
      write (*,*) 'stagnant layer ',Height_stagnant_air_layer_cm


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
   



        
        close (ScenarioFileUnit)
    end subroutine read_scenario_file
    
  

    
       !************************************************************
    subroutine Read_Weatherfile
    !open weather file, count file, allocate the weather variables, read in dat and place in vectors to store in constant/variable mod.  
    use utilities_1
    use constants_and_Variables, ONLY:precip, pet_evap,air_temperature, wind_speed, solar_radiation, num_records, &
                                      metfileunit,weatherfilename, weatherfiledirectory, &
                                      startday, first_year, last_year, num_years,first_mon, first_day     
        integer :: dummy, status,i, year
        character(Len=1024) :: weatherfile_pathandname
        weatherfile_pathandname = trim(adjustl(weatherfiledirectory)) // trim(adjustl(weatherfilename))
        
        write(*,*) 'weather path and file to open: ', trim(adjustl(weatherfile_pathandname))
        
        OPEN(Unit = metfileunit,FILE=trim(adjustl(weatherfile_pathandname)),STATUS='OLD', IOSTAT=status)
        IF (status .NE. 0) THEN
            write(*,*)'Problem opening weather file. Name is ', trim(adjustl(weatherfilename))
            stop
        ENDIF   
      
      num_records = 0
      
      !Read first Date of Simulation
      read (metfileunit,*, IOSTAT=status) first_mon, first_day, first_year
      
      if (status /= 0) then
          write(*,*) "No data or other problem in Weather File"
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
      write (*,*) "Weather file total days = ",num_records
      
      !Allocate the weather parameters 
      allocate (precip(num_records))
      allocate (pet_evap(num_records))
      allocate (air_temperature(num_records))
      allocate (wind_speed(num_records))
      allocate (solar_radiation(num_records))

      write (*,*) "End Weather allocation"
      
      
      !rewind and read in weather data
      rewind(metfileunit)      
      do i = 1, num_records
          READ(MetFileUnit,*, IOSTAT=status) dummy,dummy,year,precip(i),pet_evap(i),air_temperature(i),wind_speed(i),solar_radiation(i)
          if (status /= 0)then
              write (*,*) "weather file problem on line ", i, status
              exit
          end if
      end do
  
      last_year = year
      
      num_years = last_year-first_year+1
      
      close(metfileunit)
       write (*,*) "Finished reading weather file"
	end subroutine Read_Weatherfile 
    
	
    subroutine  scenario_error(error)
	implicit none
	logical, intent(out) :: error
          WRITE(*,*) 'Problem reading scenario file, skipping scenario ?????????????????????????????'
          error = .TRUE.
	end subroutine  scenario_error

end module readinputs