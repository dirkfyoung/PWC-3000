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
    number_of_schemes,num_apps_in_schemes, number_of_scenarios, &
    app_reference_point_schemes  ,&
    application_rate_schemes, depth_schemes, split_schemes, drift_schemes, &
    lag_schemes, periodicity_schemes,driftfactor_schemes,&
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
	is_waterbody_info_output , is_adjust_for_rain_schemes,rain_limit_schemes,optimum_application_window_schemes, &
	intolerable_rain_window_schemes, min_days_between_apps_schemes,  is_batch_scenario , scenario_batchfile 

use waterbody_parameters, ONLY: itsapond, itsareservoir, itsother,itstpezwpez, waterbody_names, USEPA_reservoir,USEPA_pond 
use utilities
        
    integer :: num_waterbodies, num_special_waterbodies

    integer :: status, i, j
    integer, parameter :: Max_read_line = 200
    character(Len=Max_read_line) ::  wholeline
    integer :: absolute_app_month
    integer :: absolute_app_day 
    integer :: comma_1, comma_2,comma_3,comma_4,comma_5,comma_6,comma_7,comma_8
    integer :: start_wb
    
    character (len=512) :: scheme_name
	integer             :: scheme_number_readin
    
    
    write(*,*) "Inside read_inputfile"

    OPEN(Unit = inputfile_unit_number, FILE=(inputfile),STATUS='OLD', IOSTAT=status  )
    IF (status .NE. 0) THEN
      WRITE(*,*)'Problem with PRZMVVWM input file: ', inputfile
      stop
    ENDIF 
    
    read(inputfile_unit_number,*) !Version info                                                                   !Line 1
                                                                                                                  
    read(inputfile_unit_number,'(A)')  working_directory                                                          !Line 2   
    read(inputfile_unit_number,'(A)') family_name                                                                 !Line 3
    read(inputfile_unit_number,'(A)') weatherfiledirectory                                                        !Line 4 
	write(*,*) 'weather directory is ', trim(weatherfiledirectory)                                                
    read(inputfile_unit_number,*) is_koc,is_freundlich , is_nonequilibrium                                        !Line 5
    read(inputfile_unit_number,*) nchem                                                                           !Line 6
    read(inputfile_unit_number,*) k_f_input(1),k_f_input(2),k_f_input(3)                                          !Line 7  
    read(inputfile_unit_number,*) N_f_input(1), N_f_input(2), N_f_input(3)                                        !Line 8
    read(inputfile_unit_number,*) k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)                                  !Line 9
    read(inputfile_unit_number,*) N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)                                  !Line 10
    read(inputfile_unit_number,*) K2(1), K2(2), K2(3)                                                             !Line 11
    read(inputfile_unit_number,*) lowest_conc, number_subdelt                                                     !Line 12
    read(inputfile_unit_number,*) water_column_halflife_input(1), &                                               !Line 13
        water_column_halflife_input(2),water_column_halflife_input(3),xAerobic(1),  xAerobic(2)   
	read(inputfile_unit_number,*) water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)      !Line 14
    read(inputfile_unit_number,*) benthic_halflife_input(1),benthic_halflife_input(2),benthic_halflife_input(3),& !Line 15
        xBenthic(1), xbenthic(2)
    read(inputfile_unit_number,*) benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)                     !Line 16
    read(inputfile_unit_number,*) photo_halflife_input(1), photo_halflife_input(2), photo_halflife_input(3),&     !Line 17
        xPhoto(1), xphoto(2) 
    read(inputfile_unit_number,*) rflat(1), rflat(2), rflat(3)                                                    !Line 18
    read(inputfile_unit_number,*) hydrolysis_halflife_input(1),hydrolysis_halflife_input(2), &                    !Line 19
        hydrolysis_halflife_input(3) , xhydro(1), xhydro(2)
    read(inputfile_unit_number,*) soil_degradation_halflife_input(1), soil_degradation_halflife_input(2),&        !Line 20
        soil_degradation_halflife_input(3), xsoil(1), xsoil(2), is_total_degradation	
	read(inputfile_unit_number,*) soil_ref_temp(1), soil_ref_temp(2), soil_ref_temp(3)                            !Line 21
    read(inputfile_unit_number,*) plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2),&              !Line 22
        plant_pesticide_degrade_rate(3),foliar_formation_ratio_12, foliar_formation_ratio_23            
    read(inputfile_unit_number,*) plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3)            !Line 23  
    read(inputfile_unit_number,*) mwt(1), mwt(2), mwt(3)                                                          !Line 24
    read(inputfile_unit_number,*) vapor_press(1), vapor_press(2),vapor_press(3)                                   !Line 25
    read(inputfile_unit_number,*) solubilty(1), solubilty(2), solubilty(3)                                        !Line 26
    read(inputfile_unit_number,*) Henry_unitless(1),Henry_unitless(2),Henry_unitless(3)
    read(inputfile_unit_number,*) DAIR(1),DAIR(2),DAIR(3)                                                         !Line 28
    read(inputfile_unit_number,*) Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)                              !Line 29
    read(inputfile_unit_number,*) Q_10                                                                            !Line 30
    read(inputfile_unit_number,*) is_constant_profile                                                             !Line 31
    read(inputfile_unit_number,*) is_ramp_profile, ramp1, ramp2, ramp3                                            !Line 32
    read(inputfile_unit_number,*) is_exp_profile , exp_profile1, exp_profile2                                     !Line 33
    read(inputfile_unit_number,*) number_of_schemes                                                               !Line 34
                                     
    write(*,*) "Number of schemes = ", number_of_schemes                                                          
                                                                                                                  !Lines become variable from here 
    allocate (num_apps_in_schemes(number_of_schemes))                                                             
    allocate (app_reference_point_schemes(number_of_schemes))
    allocate (days_until_applied_schemes(number_of_schemes,366)) 
    
    allocate (application_rate_schemes(number_of_schemes,366)) 
    allocate (method_schemes(number_of_schemes,366)) 
    allocate (depth_schemes(number_of_schemes,366)) 
    allocate (split_schemes(number_of_schemes,366)) 
    allocate (drift_schemes(number_of_schemes,366)) 
	allocate (driftfactor_schemes(number_of_schemes,366))
	
    allocate (lag_schemes(number_of_schemes,366)) 
    allocate (periodicity_schemes(number_of_schemes,366)) 
    allocate (scenario_names(number_of_schemes,1000))       
    allocate (number_of_scenarios(number_of_schemes))

    allocate (is_app_window(number_of_schemes))
    allocate (app_window_span(number_of_schemes))
    allocate (app_window_step(number_of_schemes))
    
	allocate (is_adjust_for_rain_schemes(number_of_schemes))
    allocate (rain_limit_schemes(number_of_schemes))
    allocate (optimum_application_window_schemes(number_of_schemes))
    allocate (intolerable_rain_window_schemes(number_of_schemes))
    allocate (min_days_between_apps_schemes(number_of_schemes))

    allocate (is_batch_scenario(number_of_schemes))    
    allocate (scenario_batchfile(number_of_schemes))
    
	
    do i=1, number_of_schemes
        read(inputfile_unit_number,*) scheme_number_readin, scheme_name                                !scheme line 1
        write(*,*) "Scheme Number & Name ",scheme_number_readin, trim(scheme_name)
         
        read(inputfile_unit_number,*) app_reference_point_schemes(i)                            !scheme line 2
        read(inputfile_unit_number,*) num_apps_in_schemes(i)                                    !scheme line 3
        
        do j=1, num_apps_in_schemes(i)                          
            select case (app_reference_point_schemes(i))
            case (0)
                read(inputfile_unit_number,'(A)')wholeline                                      !Scheme Line Group 4               
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
				read(wholeline((comma_6+1):(comma_7-1)),*)		   driftfactor_schemes(i,j)
                read(wholeline((comma_7+1):(comma_8-1)),*)         periodicity_schemes(i,j)  
                read(wholeline((comma_8+1):len(wholeline)),*)      lag_schemes(i,j)  
				
                !read(wholeline((comma_8+1):len(wholeline)),*)       
                
            case default
                     read(inputfile_unit_number,*) days_until_applied_schemes(i,j), application_rate_schemes(i,j), &
                         method_schemes(i,j), depth_schemes(i,j), split_schemes(i,j),   &
                         drift_schemes(i,j), driftfactor_schemes(i,j) ,periodicity_schemes(i,j) , lag_schemes(i,j)           
            end select                
		end do

		
!**********************************************************
!no longer reading in efficiency , Calculate it later....in scheme load routine      

!*****************************************************************

        read(inputfile_unit_number,*) is_app_window(i), app_window_span(i), app_window_step(i)                      !Scheme Line 5
        if (not(is_app_window(i) )) then 
            app_window_span(i) =0  !the stepping starts with zero, so the span iz zero for only one iteration
            app_window_step(i)= 1          
		end if
    
		read(inputfile_unit_number,*) is_adjust_for_rain_schemes(i),rain_limit_schemes(i), &                         !Scheme Line 6
		   optimum_application_window_schemes(i),intolerable_rain_window_schemes(i),min_days_between_apps_schemes(i) 
			
		 write(*,*) "Rain restriction" , 	is_adjust_for_rain_schemes(i),rain_limit_schemes(i), &
		   optimum_application_window_schemes(i),intolerable_rain_window_schemes(i),min_days_between_apps_schemes(i) 						  
		 
		read(inputfile_unit_number,*) number_of_scenarios(i)                                                         !Scheme Line 7
        write(*,*)"Number of scn files = ", number_of_scenarios(i)
           
        do j=1, number_of_scenarios(i)
            read(inputfile_unit_number,'(A512)')  scenario_names(i,j) !(i,j) i is scheme #, j is scenario #          !Scheme Group of Lines 8
           !  write(*,'(A)') trim(scenario_names(i,j))
        end do 
        
        read(inputfile_unit_number,*) is_batch_scenario(i)                                                           !Scheme Line 9
        read(inputfile_unit_number,'(A)') scenario_batchfile(i)                                                      !Scheme Line 10
       
        write(*,*)  "Read a batch scenario file?" ,  is_batch_scenario(i)  
        write (*,'(A)') trim(scenario_batchfile(i))
        
	enddo
	
	
     read(inputfile_unit_number,*) erflag                                                              !WS Line 1
     read(inputfile_unit_number,*)                                                                     !WS Line 2
     read(inputfile_unit_number,*)                                                                     !WS Line 3
     read(inputfile_unit_number,*)                                                                     !WS Line 4
     read(inputfile_unit_number,*)                                                                     !WS Line 5
     read(inputfile_unit_number,*)                                                                     !WS Line 6
     read(inputfile_unit_number,*) adjust_cn                                                           !WS Line 7
     read(inputfile_unit_number,*) itsapond,itsareservoir,itsother, itstpezwpez                        !WS Line 8
     read(inputfile_unit_number,*) num_special_waterbodies                                             !WS Line 9
     
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
           read(inputfile_unit_number,*) waterbody_names(i)                                                  !WS Line 10
        else !skip over the special water bodies that nmight be listed, and its other not checked
           read(inputfile_unit_number,*)                                                                     !WS Line 10 (alt)
        endif  
    end do
     
    !Read in optional output to zts file
     is_timeseriesfile = .FALSE.
	
    read(inputfile_unit_number,*) is_runoff_output                                                !OUTPUT Line 1
	    if (is_runoff_output ) is_timeseriesfile = .TRUE.	
    read(inputfile_unit_number,*) is_erosion_output                                               !OUTPUT Line 2
		if (is_erosion_output ) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_runoff_chem_output                                           !OUTPUT Line 3
	    if (is_runoff_chem_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_erosion_chem_output                                          !OUTPUT Line 4
         if (is_erosion_chem_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_conc_bottom_output                                           !OUTPUT Line 5
	    if (is_conc_bottom_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_daily_volatilized_output                                     !OUTPUT Line 6
        if (is_daily_volatilized_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_daily_chem_leached_output, leachdepth                        !OUTPUT Line 7
	    if (is_daily_chem_leached_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_decayed_part_of_soil_output, decay_start, decay_end     !OUTPUT Line 8
        if (is_chem_decayed_part_of_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_in_all_soil_output                                      !OUTPUT Line 9
	    if (is_chem_in_all_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_chem_in_part_soil_output, fieldmass_start, fieldmass_end     !OUTPUT Line 10
        if (is_chem_in_part_soil_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_chem_on_foliage_output                                      !OUTPUT Line 11
        if (is_chem_on_foliage_output) is_timeseriesfile = .TRUE.                               
    read(inputfile_unit_number,*)  is_precipitation_output                                        !OUTPUT Line 12
	    if (is_precipitation_output) is_timeseriesfile = .TRUE.                                 
    read(inputfile_unit_number,*)  is_evapotranspiration_output                                   !OUTPUT Line 13
	    if (is_evapotranspiration_output) is_timeseriesfile = .TRUE.                            
    read(inputfile_unit_number,*)  is_soil_water_output                                           !OUTPUT Line 14
	    if (is_soil_water_output) is_timeseriesfile = .TRUE.                                    
    read(inputfile_unit_number,*)  is_irrigation_output                                           !OUTPUT Line 15
        if (is_irrigation_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*)  is_infiltration_at_depth_output,infiltration_point             !OUTPUT Line 16
        if (is_infiltration_at_depth_output) is_timeseriesfile = .TRUE.
    read(inputfile_unit_number,*) is_infiltrated_bottom_output                                    !OUTPUT Line 17
        if (is_infiltrated_bottom_output) is_timeseriesfile = .TRUE.	
		
	!these next 3 are for output from waterbody, this goes into a separate output file
	read(inputfile_unit_number,*) is_waterbody_info_output   !waterbody depth, conc and benthic   !OUTPUT Line 18
	
	read(inputfile_unit_number,*)  !expansion lines    ! OUTPUT Line 19
	read(inputfile_unit_number,*)	                   ! OUTPUT Line 20
	read(inputfile_unit_number,*)	                   ! OUTPUT Line 21
	read(inputfile_unit_number,*)                      ! OUTPUT Line 22
	read(inputfile_unit_number,*)	                   ! OUTPUT Line 23
	read(inputfile_unit_number,*)	                   ! OUTPUT Line 24
	read(inputfile_unit_number,*)	                   ! OUTPUT Line 25
		
		
    read(inputfile_unit_number,*) extra_plots            !OUTPUT Line 26
	    if (extra_plots > 0) is_timeseriesfile = .TRUE.

	write(*,*) "reading tabulated output requests, if any"
		
    do i = 1, extra_plots
        read(inputfile_unit_number,*)  temp_PLNAME(i),  temp_chem_id(i), temp_MODE(i),temp_ARG(i),temp_ARG2(i),temp_CONST(i)   !OUTPUT Line 27   
	end do
    
end subroutine read_inputfile
    

subroutine read_scenario_file(schemenumber,scenarionumber, error) 
    !reads scn2x files
    use constants_and_variables, ONLY:ScenarioFileUnit, scenario_names, &
        weatherfilename, latitude, num_crop_periods_input, &
        emd,emm,mad,mam,had,ham,max_root_depth,max_canopy_cover, max_number_crop_periods, &
        max_canopy_height, max_canopy_holdup,foliar_disposition, crop_lag, crop_periodicity  , PFAC,SFAC, min_evap_depth,& 
        FLEACH,PCDEPL,max_irrig ,UserSpecifiesDepth, user_irrig_depth,irtype, USLEK,USLELS,USLEP, IREG,SLP, &
        nhoriz,thickness,bd_input,fc_input, wp_input, oc_input, bd_input, Num_delx,dispersion_input, &
        is_temperature_simulated , albedo, NUSLEC,GDUSLEC,GMUSLEC,cn_2, uslec, &
        runoff_extr_depth,runoff_decline,runoff_effic,erosion_depth, erosion_decline, erosion_effic,use_usleyears,Height_stagnant_air_layer_cm, &
		is_auto_profile,number_of_discrete_layers,  profile_thick, profile_number_increments,  evergreen,soil_temp_input, scenario_id, bottom_bc
    
        integer :: eof
        logical, intent(out) :: error
        integer, intent(in) :: schemenumber,scenarionumber
        character (len=512) filename
        integer :: i,status
        
 
        !local that will likely need to go to module
        !logical :: evergreen
        
        character(len= 50) ::dummy, dummy2
        real :: scalar_albedo, scaler_soil_temp  !these values are arrays in the program, but they are initialesd with constants
		
		logical :: checkopen
            
        
        thickness  = 0.0
        bd_input   = 0.0
        fc_input   = 0.0
        wp_input   = 0.0
        oc_input   = 0.0

        write(*,*)  '**********  Start Reading Scenario Values ************************'  
        error = .FALSE.      
        filename = trim(scenario_names(schemenumber,scenarionumber))  
        write(*,*) trim(filename)   
		
		inquire(53, OPENED=checkopen)
		write(*,*) 'is scenario open ', checkopen

		
        OPEN(Unit = ScenarioFileUnit, FILE=(filename),STATUS='OLD', IOSTAT=status  )
        IF (status .NE. 0) THEN
            WRITE(*,*)'Problem opening scenario file: ', status, trim(filename)
            Error = .TRUE.
            return
        ENDIF 
        
        read(ScenarioFileUnit,'(A)') scenario_id
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
        
        read(ScenarioFileUnit,*, IOSTAT=status) dummy, evergreen
        
    			IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if				
        read(ScenarioFileUnit,*,  IOSTAT=status ) num_crop_periods_input !line 30
    			IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if		
		
        write(*,*) "Crop Cycles per year: ", num_crop_periods_input
        read(ScenarioFileUnit,*) ! msg & String.Format("{0}{1},", vbNewLine, simpleRB.Checked)
        
        write(*,*) "Start reading crop info"
        do  i=1,num_crop_periods_input
            read(ScenarioFileUnit,*, IOSTAT = status) emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i),max_root_depth(i),max_canopy_cover(i),  &
                max_canopy_height(i), max_canopy_holdup(i),foliar_disposition(i), crop_periodicity(i), crop_lag(i) 
			    IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if
					
            !PWC saves canopy cover it as a percent, but przm needs fraction
            max_canopy_cover(i)=max_canopy_cover(i)/100.
            
            write(*,'(8I6)') emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i), foliar_disposition(i),crop_periodicity(i), crop_lag(i) 
        end do
      
     !   write (*,*) "Foliar disposition always = 1, pesticide surface applied"
     !   foliar_disposition = 1        
       
        do i=1, max_number_crop_periods - num_crop_periods_input
            read(ScenarioFileUnit,'(A)') dummy
        end do
		           
        read(ScenarioFileUnit,*)     !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altRootDepth.Text, altCanopyCover.Text, altCanopyHeight.Text, altCanopyHoldup.Text)     
        read(ScenarioFileUnit,*)     !msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altEmergeDay.Text, altEmergeMon.Text, altDaysToMaturity.Text, altDaysToHarvest.Text)
       
        write(*,*)   "PFAC,dummy, min_evap_depth"
        read(ScenarioFileUnit,*, IOSTAT= status)  PFAC,dummy, min_evap_depth 
			    IF (status .NE. 0) then
				  call scenario_error(error)
				  return
				end if		
        write(*,*)   PFAC,dummy, min_evap_depth
        
        
        read(ScenarioFileUnit,*) ! msg = msg & vbNewLine & "*** irrigation information start ***"        
        read(ScenarioFileUnit,*) irtype !0 = none, 1 flood, 2 undefined 3 = overcanopy 4 = under canopy 5 = undefined, 6 over canopy       43
        read(ScenarioFileUnit,*) FLEACH,PCDEPL,max_irrig  !fleach.Text, depletion.Text, rateIrrig.Text)                                    44
        
        write(*,*) 'Irrigation Type ', irtype   
        write(*,*) 'FLEACH,PCDEPL,max_irrig', FLEACH,PCDEPL,max_irrig

        read(ScenarioFileUnit,*) UserSpecifiesDepth !, user_irrig_depth  ! UserSpecifiesIrrigDepth.Checked, IrrigationDepthUserSpec.Text)
        write(*,*) "User specifies depth? " ,UserSpecifiesDepth 
        if (UserSpecifiesDepth) then
            backspace(ScenarioFileUnit)  !if true the userirrig depth will be blankl sometinmes
            read(ScenarioFileUnit,*) UserSpecifiesDepth, user_irrig_depth        
        endif
 
        read(ScenarioFileUnit,'(A)')!msg = msg & vbNewLine & "*** spare line for expansion"     

        read(ScenarioFileUnit,'(A)') !msg = msg & vbNewLine & "*** spare line for expansion"       
        
        read(ScenarioFileUnit,'(A)')!msg = msg & vbNewLine & "*** spare line for expansion"   
   
        
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
        read(ScenarioFileUnit,*) !(sand_input(i), i=1, nhoriz)        
        read(ScenarioFileUnit,*) !(clay_input(i), i=1, nhoriz)
              
        !do i= 1, nhoriz
        !         write(*, '(7G12.3)')  thickness(i), bd_input(i), fc_input(i), wp_input(i), oc_input(i), sand_input(i), clay_input(i)
        !end do

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

        
        read(ScenarioFileUnit,*)   !*** Horizon End, Temperature Start ********
        
        read(ScenarioFileUnit,"(A50)", IOSTAT= status) dummy

        read(dummy,*, IOSTAT= status) scalar_albedo,scaler_soil_temp  !msg = msg & String.Format("{0}{1},{2}", vbNewLine, albedoBox.Text, bcTemp.Text)
        IF (status .NE. 0) then  !this isn't populated for standard scnarios in 2023
             scalar_albedo = 0.2
             scaler_soil_temp = 15.           
             write(*,*) "Using Default albedo and gw temperature"
        end if

        write(*,*) "albedo and temp = ",  scalar_albedo,scaler_soil_temp
        
        ALBEDO = scalar_albedo                 !albedo is monthly in przm      
        soil_temp_input = scaler_soil_temp
        
        !need to set bottom boundary condition
        bottom_bc= scaler_soil_temp
        
        read(ScenarioFileUnit,*) is_temperature_simulated !msg = msg & vbNewLine & simTemperature.Checked
    
        
        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "***spare line for expansion"
        read(ScenarioFileUnit,*) !msg = msg & vbNewLine & "*** Erosion & Curve Number Info **********"
         write(*,*)  "Temperature simulated? ",    is_temperature_simulated
        
        
        read(ScenarioFileUnit,*) NUSLEC  !msg = msg & vbNewLine & NumberOfFactors.Text
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
     
        
      write (*,*) 'read in stagnant layer ',Height_stagnant_air_layer_cm
 
      
      profile_thick= 0.0
	  profile_number_increments=0
	  read(ScenarioFileUnit,*, IOSTAT=eof)  is_auto_profile
      
	  write (*,*) "eof   ?", eof, is_auto_profile

      
	  if (eof >= 0) then             !provides for the possibilty of older scenarios without this feature
		  if (is_auto_profile) then 
		     read(ScenarioFileUnit,*) number_of_discrete_layers
		     do i = 1,  number_of_discrete_layers
		       read(ScenarioFileUnit,*) profile_thick(i), profile_number_increments(i)
		     end do
          end if
      else 
          is_auto_profile= .FALSE.  !for older files set default to No aurto profile    
	  end if
	  
        close (ScenarioFileUnit)
end subroutine read_scenario_file

	
subroutine  scenario_error(error)
	implicit none
	logical, intent(out) :: error
          WRITE(*,*) 'Problem reading scenario file, skipping scenario ?????????????????????????????'
          error = .TRUE.
    end subroutine  scenario_error
    
    
subroutine read_batch_scenarios(batchfileunit, end_of_file, error_on_read)
         use utilities_1
         use constants_and_variables, ONLY: scenario_id, weatherfilename,latitude, min_evap_depth, IREG, irtype,max_irrig, PCDEPL, fleach, USLEP, USLEK,USLELS,SLP, &
             num_crop_periods_input,NHORIZ, thickness,bd_input,fc_input,wp_input,oc_input, evergreen,emm, emd, mad, mam, had, ham, &
             PFAC,SFAC, max_canopy_cover, max_canopy_holdup, max_root_depth, crop_periodicity, crop_lag,UserSpecifiesDepth, is_temperature_simulated, &
             ALBEDO, soil_temp_input, dispersion_input, nuslec,cn_2, USLEC, gmuslec, gduslec, use_usleyears, &
             runoff_extr_depth,runoff_decline,runoff_effic,erosion_depth,erosion_decline,erosion_effic, Height_stagnant_air_layer_cm, &
             profile_thick, profile_number_increments, is_auto_profile,  number_of_discrete_layers, foliar_disposition, UserSpecifiesDepth,  &
             user_irrig_depth , bottom_bc
                                                                          
         logical, intent(out) :: end_of_file, error_on_read                                 
         integer, intent(in)  :: batchfileunit                            
                                                                            
         character(LEN=5) :: dummy
         integer :: julian_emerg, julian_matur, julian_harv  !need conversion to days & months and put into emd(i),emm(i) ,mad(i),mam(i),had(i),ham(i
         real :: canopy_holdup      !needs to be put into array max_canopy_holdup(i)
         real :: canopy_coverage    !needs to be put into array max_canopy_cover(i)
         real :: root_depth         !needs to be put into array max_root_depth(i)
         real :: cn_cov, cn_fal, usle_c_cov, usle_c_fal
         integer year !dummy not used but for sub op
         character(LEN=10) :: weather_grid
         integer :: iostatus
         integer :: i
         real ::  gw_depth, gw_temp
         character(LEN=1000) :: input_string
         character(LEN=3) ::cropgroup,region
         

         thickness  = 0.0
         bd_input   = 0.0
         fc_input   = 0.0
         wp_input   = 0.0
         oc_input   = 0.0


        !Presets
        foliar_disposition = 1
        UserSpecifiesDepth = .false.
        user_irrig_depth = 0.0
        crop_periodicity(1) =1
        crop_lag(1) = 0
        PFAC = 1.0                    !always using PET files now, No need to adjust
        !SFAC = 0.274                 !USDA value  now a parameter        
        ALBEDO = 0.2                  !albedo is monthly in przm  
        UserSpecifiesDepth = .FALSE.  !only root irrigation
        is_temperature_simulated = .TRUE. 
        dispersion_input = 0.0
        nuslec = 2
        use_usleyears = .FALSE.
        runoff_extr_depth = 8.0
        runoff_decline    = 1.4
        runoff_effic      = 0.19
        erosion_depth     = 0.1
        erosion_decline   = 0.0
        erosion_effic     = 1.0
        Height_stagnant_air_layer_cm = 5.0
        
        is_auto_profile = .TRUE.  !we will use discretizations specified independent of horizon info
        number_of_discrete_layers	=   6
        profile_thick(1) =  3.0
        profile_thick(2) =  7.0
        profile_thick(3) = 10.0
        profile_thick(4) = 80.0      
       ! profile_thick(5) = gw_depth - 100.  ! gw_depth is depth to aquifer surface, subtract the 1 meter from above
        profile_thick(6) = 100.       
      
        profile_number_increments(1) = 30
	    profile_number_increments(2) =  7
        profile_number_increments(3) =  2
        profile_number_increments(4) =  4 
        !  profile_number_increments(5) = int(gw_depth)/50 -2
        profile_number_increments(6) = 2
        
          end_of_file    = .FALSE.
          error_on_read  = .FALSE.
        
          
         !read in as string for better list directed error checking. Prevents reads to subsequent lines in the event of missing data
         read(BatchFileUnit, '(A)',IOSTAT=iostatus ) input_string
         !Check for end of file
         
         write(*,*) 'READ END OF FILE STATUS ' , IS_IOSTAT_END(iostatus)
         if(IS_IOSTAT_END(iostatus)) then
             end_of_file = .TRUE.
             return
         else 
            write(*,'(A)') input_string 
         end if
        
 
         read(input_string, *, IOSTAT=iostatus)   scenario_id, dummy, weather_grid, dummy ,dummy, dummy, dummy, dummy, dummy, &  !enter the long string of values
             latitude, dummy, min_evap_depth , IREG, irtype, max_irrig,  PCDEPL, FLEACH,dummy, julian_emerg, julian_matur, julian_harv, &
             dummy, dummy, dummy, dummy, canopy_holdup, canopy_coverage, root_depth, cn_cov, cn_fal, usle_c_cov, usle_c_fal, USLEP, USLEK,USLELS,SLP, &
             NHORIZ, thickness(1), thickness(2), thickness(3), thickness(4), thickness(5), thickness(6), thickness(7), thickness(8), &
             bd_input(1),bd_input(2),bd_input(3),bd_input(4),bd_input(5),bd_input(6),bd_input(7),bd_input(8), &
             fc_input(1),fc_input(2),fc_input(3),fc_input(4),fc_input(5),fc_input(6),fc_input(7),fc_input(8), &
             wp_input(1),wp_input(2),wp_input(3),wp_input(4),wp_input(5),wp_input(6),wp_input(7),wp_input(8), &
             oc_input(1),oc_input(2),oc_input(3),oc_input(4),oc_input(5),oc_input(6),oc_input(7),oc_input(8), &
             dummy,dummy,dummy,dummy,dummy,dummy,dummy,dummy, &
             dummy,dummy,dummy,dummy,dummy,dummy,dummy,dummy,dummy,cropgroup,region, gw_depth, gw_temp               
         
         
        
         if (iostatus /= 0 ) then  !there is a problem
             error_on_read = .TRUE.
             write (*,*) '^^^^^^^^^^ ERROR DETECTED IN THIS SCENARIO ^^^^^^^^'
             return
         end if
         
         
          scenario_id =  trim(scenario_id) //"_C" // trim(cropgroup) //"_R" //trim(region)
         
         !**************************************************
         !Foliar Disposition seems to be undefined in the batch file
         !canopy height is undefined, set to 1 meter by default put into: max_canopy_height(i)
                  
         weatherfilename = trim(adjustl(weather_grid)) // '_grid.wea'
         write(*,*) trim(weatherfilename)

         num_crop_periods_input = 1
         if (julian_emerg==0 .AND.  julian_matur==1 .AND. julian_harv==364) then
             evergreen = .TRUE. 
         end if
         
         max_canopy_cover(1) = canopy_coverage/100.  ! read in as percent
         max_canopy_holdup(1)   = canopy_holdup
         max_root_depth(1)      = root_depth


         call get_date(julian_emerg, year, emm(1), emd(1) )
         write(*,    '("Emerge", 4I12)' ) julian_emerg, year, emm(1), emd(1)
         
         call get_date(julian_matur, year, mam(1), mad(1) )
         write(*,    '("Mature", 4I12)' )  julian_matur,year, mam(1), mad(1)
         
         call get_date(julian_harv , year,  ham(1), had(1) )
          write(*,    '("Harves", 4I12)' )julian_harv, year, ham(1), had(1)
                
         
         !nuscle = 2 so only 2 curve numbers
         CN_2(1)  = cn_cov
         CN_2(2)  = cn_fal 
         USLEC(1) = usle_c_cov
         USLEC(2) = usle_c_fal
         
         !only 1 crop
         GDUSLEC(1) = emd(1)  !emergence 
         GMUSLEC(1) = emm(1)
         
         GDUSLEC(2) = had(1)  !harvest
         GMUSLEC(2) = ham(1)
         
        soil_temp_input  = gw_temp         !array for horizons, set as constant for all horizons as initial condition. 
        bottom_bc = gw_temp                !bottom boundary is constant temperature
        
        
        profile_thick(5) = gw_depth - 100.  ! gw_depth is depth to aquifer surface, subtract the 1 meter (thickness of the horizons 1 to 4)
        profile_number_increments(5) = int(gw_depth)/50 -2
        
        

    end subroutine read_batch_scenarios
    
    
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
        if (status .NE. 0) THEN
            write(*,*)'Problem opening weather file. Name is ', trim(adjustl(weatherfilename))
            stop
        endif  
      
      num_records = 0
      
      !Read first Date of Simulation
      read (metfileunit,*, IOSTAT=status) first_mon, first_day, first_year
      
      if (status /= 0) then
          write(*,*) "No data or other problem in Weather File"
          stop
      end if
      
      startday = jd(first_year, first_mon, first_day)

      write(*,*)  'startday = ', startday, first_year, first_mon, first_day
      
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
      
      !ONLY READS WEA FORMAT
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
    
end module readinputs