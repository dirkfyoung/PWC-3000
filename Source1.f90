SUBROUTINE read_main_inputs
  !Reads and checks input data. 
      
      use  constants_and_Variables, ONLY:PRZMinputUnit, PRZMVVWMinputfile,EchoFileUnit,pfac, sfac, &
      soil_temp_input,is_temperature_simulated,  &
      albedo,emmiss,bbt,IRTYPE,PCDEPL,max_irrig,FLEACH, min_evap_depth ,                   &
      AFIELD,IREG,USLEK,USLELS,USLEP,HL,SLP, USLEC,MNGN,theta_zero_input,sand_input,clay_input,fc_input,wp_input,CN_2,     &
      NUSLEC,GDUSLEC,GMUSLEC,GYUSLEC,erflag, IRFLAG, Num_delx,                          &
      plant_pesticide_degrade_rate,         &
      foliar_formation_ratio_12,foliar_formation_ratio_23, &
      MolarConvert_aq12_input, MolarConvert_aq13_input, MolarConvert_aq23_input,  &
      MolarConvert_s12_input,  MolarConvert_s13_input, MolarConvert_s23_input,   &    
      UPTKF,DAIR,HENRYK,plant_volatilization_rate,oc_input,pest_app_method,     &
      Q_10,TBASE,NCHEM,NHORIZ,thickness,CONST,NPLOTS,chem_id  ,           &
      ARG,IARG2,PLNAME,mode,  &
       dispersion_input,  &
      runoff_effic,runoff_decline,runoff_extr_depth,erosion_decline,erosion_depth,erosion_effic ,Num_hydro_factors,use_usleyears,  &
      metfileunit,maxFileLength,TimeSeriesUnit,  &
      is_Freundlich,is_nonequilibrium,calibrationflag,  &
      UserSpecifiesDepth, user_irrig_depth, k_f_input, N_f_input,lowest_conc, uWind_Reference_Height,Height_stagnant_air_layer_cm, &
      number_subdelt,     N_f_2_input,k_f_2_input,K2, bd_input, OC_input,  &
      aq_rate_input, sorb_rate_input, gas_rate_input,ADJUST_CN,&
      some_applications_were_foliar, plant_washoff_coeff,plant_volatilization_rate,weatherfilename, & 
      max_root_depth,max_canopy_cover,max_canopy_holdup,max_canopy_height,  foliar_disposition,TAPP ,is_true_rain_distribution, &
       is_irrigation, is_allyear_irrigation, is_above_crop_irrigation, relative_date_flag, &
      num_applications_input, apd, apm,  application_rate_in,DEPI_in, appeff_in,Tband_top_in, pest_app_method_in, drift_in,lag_app_in,repeat_app_in, &      
      emd, emm, emy, mad, mam, may,had, ham, hay, crop_lag, crop_periodicity,num_crop_periods_input, is_koc, water_column_rate_input, &
      latitude, water_column_ref_temp, &
      benthic_rate_input,benthic_ref_temp, photo_input, rflat, &
      xbenthic, xAerobic, xphoto, xbenthic, xhydro,  hydrolysis_rate_input, & 
      mwt, solubilty, vapor_press, Heat_of_Henry,  Henry_unitless, D_over_dx, benthic_depth, porosity, &
      FROC2, bulk_density, bnmas,DFAC, SUSED,CHL, DOC2,  FROC1,DOC1,PLMAS,area_waterbody, depth_0, depth_max , flow_averaging, baseflow   ,cropped_fraction, &
      is_hed_files_made,is_add_return_frequency, additional_return_frequency, &
      vvwm_type, ConstVolnoflow_type, ConstVolflow_type, pond_type, reservoir_type,&
      outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
      outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis,&
      outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
      outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
      outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa, &
      working_directory, family_name, scenario_id
      
      
      
      use utilities_1
  !    use Output_File
      
     ! Use m_Wind
      implicit none

      INTEGER  dummy
      character(len = 74)  dummystring
  
      INTEGER      I,K
      
      
      CHARACTER(len = 150):: note  !used for sending error messages

      LOGICAL      FATAL
      Logical      value_in_range

      Character(Len = maxFileLength)    :: Filename
      

      integer :: status
     
      

     MolarConvert_aq12_input = 0.0
     MolarConvert_aq23_input = 0.0
     MolarConvert_aq13_input = 0.0
     MolarConvert_s12_input  = 0.0
     MolarConvert_s23_input  = 0.0
     MolarConvert_s13_input  = 0.0
     
      soil_temp_input = 0.0
      sand_input      = 0.0
      clay_input      = 0.0

 !no longer reading this file     
      !OPEN(Unit = PRZMinputUnit,FILE=(PRZMVVWMinputfile),STATUS='OLD', IOSTAT=status)
      !IF (status .NE. 0) THEN
      !    WRITE(EchoFileUnit,*)'Problem with PRZM INP file.'
      !    stop
      !ENDIF 
      
      !CALL check_for_comment(PRZMinputUnit)
      !READ(PRZMinputUnit,'(A)',IOSTAT = status) working_directory    
      !if (status/=0) stop
      !write(EchoFileUnit,*) "A1 Working Directory: ", trim(working_directory)

      !CALL check_for_comment(PRZMinputUnit)
      !READ(PRZMinputUnit,'(A)',IOSTAT = status) family_name   
      !if (status/=0) stop
      !write(EchoFileUnit,*) "A2 Family Name of Run: ", trim(family_name)
      

      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,'(A)',IOSTAT = status) scenario_id !Weather File
      if (status/=0) stop      
      write(EchoFileUnit,*) "A3 scenario ID: ", trim(scenario_id)

      
      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,'(A)',IOSTAT = status) weatherfilename !Weather File
      if (status/=0) stop      
      write(EchoFileUnit,*) "A4 weather file: ", trim(weatherfilename)
      
    
      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) latitude 
      if (status/=0) stop      
      write(EchoFileUnit,*) "A5 latitude: ", latitude
          

      CALL check_for_comment(PRZMinputUnit)
       READ(PRZMinputUnit,*,IOSTAT = status)  number_subdelt 
      if (status/=0) stop      
      write(EchoFileUnit,*) "A6, Sub Time steps: ", number_subdelt  
      
 


      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) PFAC,SFAC, min_evap_depth     
      if (status/=0) stop
      write(EchoFileUnit,*) 'B1: PFAC,SFAC, min_evap_depth', PFAC,SFAC, min_evap_depth
      
                
      
       CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  ERFLAG
      if (status/=0) stop 
      write(EchoFileUnit,*) 'B2 erosion flag ', erflag
      

!    ERFLAG = 0 indicates that erosion will not be calculated
      if (ERFLAG.eq.1 .or. ERFLAG.gt.4 .or. ERFLAG.lt.0) then
         note = 'Erosion flag (ERFLAG) out of range'
         FATAL = .True.
         Call ERRCHK (note, FATAL)
      ENDIF 
      
      write(EchoFileUnit,*) 'B3'
      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) USLEK,USLELS,USLEP,AFIELD,IREG,SLP,HL
      if (status/=0) stop            
   

      !--------- Erosion/Curve number Inputs ---------------------
          

      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*) NUSLEC, use_usleyears
      if (status/=0) stop 
      write(EchoFileUnit,*) "B4, number of factors, use years?: ", NUSLEC, use_usleyears
      
          
      write(EchoFileUnit,*) 'B5 day, mon, yr, cn, C'
      CALL check_for_comment(PRZMinputUnit)
      do i= 1, NUSLEC
         READ(PRZMinputUnit,*)  GDUSLEC(i), GMUSLEC(i), GYUSLEC(i),CN_2(i),USLEC(i)
           write(EchoFileUnit,*) i, GDUSLEC(i), GMUSLEC(i), GYUSLEC(i),CN_2(i),USLEC(i)    
      end do
 !-------------End cn erosion Inputs ------------------------
      
      
      write(EchoFileUnit,*) 'Start Crop Inputs'
      CALL check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  num_crop_periods_input
      if (status/=0) stop
      write(EchoFileUnit,*) 'C1, number of unique crops = ', num_crop_periods_input
        
      allocate (emd (num_crop_periods_input))
      allocate (emm (num_crop_periods_input))
      allocate (emy (num_crop_periods_input))  
      allocate (mad (num_crop_periods_input))
      allocate (mam (num_crop_periods_input))
      allocate (may (num_crop_periods_input)) 
      allocate (had (num_crop_periods_input))
      allocate (ham (num_crop_periods_input))
      allocate (hay (num_crop_periods_input)) 

      
      allocate (max_root_depth       (num_crop_periods_input))
      allocate (max_canopy_cover     (num_crop_periods_input))
      allocate (max_canopy_holdup    (num_crop_periods_input))
      allocate (max_canopy_height    (num_crop_periods_input))
      allocate (foliar_disposition   (num_crop_periods_input))
      allocate (crop_lag             (num_crop_periods_input))
      allocate (crop_periodicity     (num_crop_periods_input))
      
  
      write(EchoFileUnit,*) 'C2 Crop Properties'
      DO  I=1,num_crop_periods_input
        CALL check_for_comment(PRZMinputUnit)
        READ(PRZMinputUnit,*,IOSTAT = status) emd(i),emm(i),emy(i),mad(i),mam(i),may(i),had(i),ham(i),hay(i),max_root_depth(i),max_canopy_cover(i),  &
                                              max_canopy_height(i), max_canopy_holdup(i),foliar_disposition(i), crop_lag(i), crop_periodicity(i) 
        if (status/=0) stop                                
      end do

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  is_irrigation, is_allyear_irrigation, is_above_crop_irrigation
      if (status/=0) stop
      write(EchoFileUnit,*) 'D1 irrigation flag = ', is_irrigation, is_allyear_irrigation, is_above_crop_irrigation


      write(EchoFileUnit,*) 'D2 Irrigation Properties'
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) max_irrig, PCDEPL,FLEACH,UserSpecifiesDepth, user_irrig_depth
      if (status/=0) stop
                
      write(EchoFileUnit,*)  max_irrig, PCDEPL,FLEACH,UserSpecifiesDepth, user_irrig_depth
       
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) is_temperature_simulated
      if (status/=0) stop     
      write(EchoFileUnit,*) 'E1 Temperature simulated? ',    is_temperature_simulated     
               
     write(EchoFileUnit,*) 'E2, albedo, emissivity '
     call check_for_comment(PRZMinputUnit)
     READ(PRZMinputUnit,*,IOSTAT = status)(ALBEDO(I),I=1,12),EMMISS
     if (status/=0) stop

     write(EchoFileUnit,*) 'E3 '
     call check_for_comment(PRZMinputUnit)
     READ(PRZMinputUnit,*,IOSTAT = status) uWind_Reference_Height,   Height_stagnant_air_layer_cm
     if (status/=0) stop     
     write(EchoFileUnit,*)  uWind_Reference_Height,   Height_stagnant_air_layer_cm
        
        
!    reads in Lower boundary temperatures if is_temperature_simulated
     write(EchoFileUnit,*) 'E4 lower BC'
     call check_for_comment(PRZMinputUnit)
     READ(PRZMinputUnit,*,IOSTAT = status)(BBT(I),I=1,12)             
     if (status/=0) stop
     
!    reads in Q10FAC and TBASE
     write(EchoFileUnit,*) 'E5'
     call check_for_comment(PRZMinputUnit)
     READ(PRZMinputUnit,*,IOSTAT = status) Q_10,TBASE       
     if (status/=0) stop
     write(EchoFileUnit,*) "Q10, soil ref temp = ", Q_10,TBASE   
      
     write(EchoFileUnit,*) 'F1'
     call check_for_comment(PRZMinputUnit)
     READ(PRZMinputUnit,*,IOSTAT = status) NHORIZ
     if (status/=0) stop
     write(EchoFileUnit,*)'F1 Number of soil layers = ',   NHORIZ 
     write(EchoFileUnit,*) 'F2 Soil Parameters' 
     do I=1,NHORIZ       
        call check_for_comment(PRZMinputUnit)
        READ(PRZMinputUnit,*,IOSTAT=status) dummy,thickness(I),Num_delx(I),dispersion_input(i),bd_input(I), &
            theta_zero_input(i),fc_input(i),wp_input(i),oc_input(i),sand_input(i),clay_input(i),soil_temp_input(I)                        
        if (status/=0) stop         
        write(EchoFileUnit,'(I2,1x,F5.1, 1x, I4, 1x, 9F7.2)') dummy,thickness(I),Num_delx(I),dispersion_input(i),bd_input(I), &
              theta_zero_input(i),fc_input(i),wp_input(i),oc_input(i),sand_input(i),clay_input(i),soil_temp_input(I)
                                 
      end do

      write(EchoFileUnit,*) 'F3  PRZM5 runoff extraction parameters'
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) runoff_extr_depth,runoff_decline,runoff_effic     
      if (status/=0) stop   
      
      write(EchoFileUnit,*) 'F4 PRZM5 erosion extraction parameters'
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  erosion_depth, erosion_decline, erosion_effic
      if (status/=0) stop     
      
      
      !*********CHEMICAL INPUTS*************************************
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) NCHEM
      if (status/=0) stop
      write(EchoFileUnit,*)'G1 Parent, daughter, granddaughter =',  nchem     
  
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) relative_date_flag 
      if (status/=0) stop
      write(EchoFileUnit,*)'G2 dates are relative flag',  relative_date_flag 
      
      
      
      
      
      
      !call check_for_comment(PRZMinputUnit)
      !READ(PRZMinputUnit,*,IOSTAT = status) num_applications_input
      !if (status/=0) stop
      !write(EchoFileUnit,*)'G3 number of pesticide applications to be read ',num_applications_input
      !
      !!*** allocate pesticide application parameters ****
      !
      !allocate(application_rate_in(num_applications_input))
      !allocate(apd(num_applications_input))
      !allocate(apm(num_applications_input))
      !
      !
      !allocate(DEPI_in            (num_applications_input))          
      !allocate(APPEFF_in          (num_applications_input))
      !allocate(Tband_top_in       (num_applications_input))
      !allocate(pest_app_method_in (num_applications_input))   
      !
      !allocate(drift_in (num_applications_input)) 
      !allocate(lag_app_in (num_applications_input)) 
      !allocate(repeat_app_in (num_applications_input)) 
      ! 
      ! 
      !!****************************************
      !
      ! !pest_app_method = 1 "Below Crop"
      ! !pest_app_method = 2 "Above Crop"
      ! !pest_app_method = 3 "Uniform"
      ! !pest_app_method = 4 "At Specific Depth"
      ! !pest_app_method = 5 "T Band"
      ! !pest_app_method = 6 "invert triange chrw 9661"
      ! !pest_app_method = 7 "triangle chrw 9651"
      !
      ! write(EchoFileUnit,*) 'd   m    rate method depth  Tband   Eff   drift    lag   repeat'
      !
      !do i=1, num_applications_input
      !   call check_for_comment(PRZMinputUnit)
      !   READ(PRZMinputUnit,*,IOSTAT = status) apd(i), apm(i), application_rate_in(i), pest_app_method_in(i),DEPI_in(i), Tband_top_in(i), APPEFF_in(i), drift_in(i), lag_app_in(i), repeat_app_in(i)
      !   
      !   if (status/=0) stop  
      !   write(EchoFileUnit,'(1x,I2,1x,I2,1X, F7.2,1X, I2, 8F8.2)') apd(i), apm(i),application_rate_in(i), pest_app_method_in(i),DEPI_in(i), Tband_top_in(i), APPEFF_in(i), drift_in(i), lag_app_in(i), repeat_app_in(i)
      !end do 
      !write(EchoFileUnit,*) 'G4 Done reading applation info'
      !
      !some_applications_were_foliar = .FALSE.
      !if(any(pest_app_method==2)) then
      !    some_applications_were_foliar = .TRUE.
      !end if
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  (UPTKF(K),K=1,NCHEM)
      if (status/=0) stop
      write(EchoFileUnit,*) 'H1 uptake'
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3)
      if (status/=0) stop   
      write(EchoFileUnit,*) 'H2 Foliar Washoff',  plant_washoff_coeff(1),plant_washoff_coeff(2),plant_washoff_coeff(3)      
    
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2), plant_pesticide_degrade_rate(3)
      if (status/=0) stop   
      write(EchoFileUnit,*) 'H3 Foliar Degradation',  plant_pesticide_degrade_rate(1), plant_pesticide_degrade_rate(2), plant_pesticide_degrade_rate(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) plant_volatilization_rate(1), plant_volatilization_rate(2), plant_volatilization_rate(3)
      if (status/=0) stop   
      write(EchoFileUnit,*) 'H4 Foliar Volatilization',plant_volatilization_rate(1), plant_volatilization_rate(2), plant_volatilization_rate(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) foliar_formation_ratio_12,  foliar_formation_ratio_23
      if (status/=0) stop        
      write(EchoFileUnit,*) 'H5 Foliar Formation factors', foliar_formation_ratio_12, foliar_formation_ratio_23
        
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) DAIR(1),DAIR(2),DAIR(3)
      if (status/=0) stop  
      write(EchoFileUnit,*) "I1 Dif Air ", DAIR(1),DAIR(2),DAIR(3)    
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) HENRYK(1),HENRYK(2),HENRYK(3)
      if (status/=0) stop  
      write(EchoFileUnit,*) "I2 Henry ",HENRYK(1),HENRYK(2),HENRYK(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)
      if (status/=0) stop  
      write(EchoFileUnit,*) "I3 Heat of Menry: ", Heat_of_Henry(1),Heat_of_Henry(2),Heat_of_Henry(3)
           
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) is_Freundlich, is_nonequilibrium, is_koc
      if (status/=0) stop  
      write(EchoFileUnit,*) "J1 use Freundlich: ", is_Freundlich, "use noneqiulibrium: ", is_nonequilibrium, "is Koc ", is_koc

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) k_f_input(1),k_f_input(2),k_f_input(3) 
      if (status/=0) stop
      Write(EchoFileUnit,*) "J2  Freundlich Kf Region 1",  k_f_input(1), k_f_input(2), k_f_input(3)     

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) N_f_input(1), N_f_input(2), N_f_input(3)
      write(EchoFileUnit,*) 'J3 Freundlich N Region 1 ',  N_f_input(1), N_f_input(2), N_f_input(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'J4 Freundlich kf Region 2 ', k_f_2_input(1), k_f_2_input(2), k_f_2_input(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)
      if (status/=0) stop    
      write(EchoFileUnit,*) 'J5 Freundlich N Region 2 ', N_f_2_input(1), N_f_2_input(2), N_f_2_input(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) lowest_conc 
      if (status/=0) stop  
      write(EchoFileUnit,*) 'J6 Concentration where isotherm is linear (mg/L) ', lowest_conc 
          
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) K2(1),K2(2),K2(3)
      write(EchoFileUnit,*)  "J7 Mass Transfer Coefficient = ", K2(1), K2(2), K2(3)
            
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) Aq_rate_input(1), Aq_rate_input(2), Aq_rate_input(3)
      if (status/=0) stop
       write(EchoFileUnit,*) 'K1 Soil Aqueous Degradation Rates',Aq_rate_input(1), Aq_rate_input(2), Aq_rate_input(3)
                 
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) Sorb_rate_input(1),Sorb_rate_input(2),Sorb_rate_input(3)
      if (status/=0) stop
       write(EchoFileUnit,*) 'K2 Soil Sorbed Degradation Rates',Sorb_rate_input(1),Sorb_rate_input(2),Sorb_rate_input(3)
             
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) Gas_rate_input(1), Gas_rate_input(2), Gas_rate_input(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K3 Soil Gas Degradation Rates'  ,   Gas_rate_input(1), Gas_rate_input(2), Gas_rate_input(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) MolarConvert_aq12_input(1), MolarConvert_aq23_input(2)
      if (status/=0) stop
       write(EchoFileUnit,*) 'K4 Molar conversions'  ,  MolarConvert_aq12_input(i), MolarConvert_aq23_input(i)
         
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) hydrolysis_rate_input(1),hydrolysis_rate_input(2),hydrolysis_rate_input(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K5 hydrolysis rates in days'  ,  hydrolysis_rate_input(1),hydrolysis_rate_input(2),hydrolysis_rate_input(3)
       
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) xhydro(1), xhydro(2) 
      if (status/=0) stop
      write(EchoFileUnit,*) 'K6 hydrolysis Molar conversions '  , xhydro(1), xhydro(2)     
 
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,'(A)',IOSTAT = status) dummystring
      if (status/=0) stop
      write(EchoFileUnit,*) 'K7 ', dummystring
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) water_column_rate_input(1),water_column_rate_input(2),water_column_rate_input(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K8 water column metabolism rates (PER DAY) ', water_column_rate_input(1),water_column_rate_input(2),water_column_rate_input(3)
 
      call check_for_comment(PRZMinputUnit) 
      READ(PRZMinputUnit,*,IOSTAT = status) water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K9 Reference Temperature ', water_column_ref_temp(1),water_column_ref_temp(2),water_column_ref_temp(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) , xAerobic(1),  xAerobic(2)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K10 water molar conversions ', xAerobic(1),  xAerobic(2)

      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) benthic_rate_input(1),benthic_rate_input(2),benthic_rate_input(3)
      if (status/=0) stop
      write(EchoFileUnit,'(1x,A, 3G12.5)') 'K11 benthic metabolism rates (PER DAY) ', benthic_rate_input(1),benthic_rate_input(2),benthic_rate_input(3)

      
      call check_for_comment(PRZMinputUnit) 
      READ(PRZMinputUnit,*,IOSTAT = status) benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K12 benthic Reference Temperature ', benthic_ref_temp(1),benthic_ref_temp(2),benthic_ref_temp(3)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) xBenthic(1), xbenthic(2)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K13 benthic molar conversions ',xBenthic(1), xBenthic(2)

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) photo_input(1), photo_input(2), photo_input(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K14 photolyis rates in per day ',photo_input(1), photo_input(2), photo_input(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) rflat(1), rflat(2), rflat(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'K15 photolyis reference latitude  ',rflat(1), rflat(2), rflat(3)   
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) mwt(1), mwt(2), mwt(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'L1 molecular wt  ',mwt(1), mwt(2), mwt(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) vapor_press(1), vapor_press(2), vapor_press(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'L2 Vapor Pressure  ',vapor_press(1), vapor_press(2),vapor_press(3)
   
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) solubilty(1), solubilty(2), solubilty(3)
      if (status/=0) stop
      write(EchoFileUnit,*) 'L3 Solubility  ',solubilty(1), solubilty(2), solubilty(3)
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) D_over_dx
      if (status/=0) stop
      write(EchoFileUnit,*) 'M1 Mass Transfer to Benthic  ', D_over_dx
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  benthic_depth
      if (status/=0) stop
      write(EchoFileUnit,*) 'M2 benthic depth  ', benthic_depth
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  porosity
      if (status/=0) stop
      write(EchoFileUnit,*) 'M3 benthic porosity  ', porosity   
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  bulk_density
      if (status/=0) stop
      write(EchoFileUnit,*) 'M4 benthic bulk density ', bulk_density 
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  FROC2
      if (status/=0) stop
      write(EchoFileUnit,*) 'M5 benthic oc fraction  ', FROC2       
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  DOC2
      if (status/=0) stop
      write(EchoFileUnit,*) 'M6 benthic DOC  ', DOC2            
 
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  BNMAS
      if (status/=0) stop
      write(EchoFileUnit,*) 'M7 benthic porosity  ', BNMAS  

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  DFAC
      if (status/=0) stop
      write(EchoFileUnit,*) 'M8 DFAC ', DFAC  
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  sused
      if (status/=0) stop
      write(EchoFileUnit,*) 'M9 Suspended solids ', sused
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) chl
      if (status/=0) stop
      write(EchoFileUnit,*) 'M10 chorophyll ', chl
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) FROC1
      if (status/=0) stop
      write(EchoFileUnit,*) 'M11 water column oc fraction ', FROC1     

      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) DOC1
      if (status/=0) stop
      write(EchoFileUnit,*) 'M12 water column DOC ', DOC1
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)PLMAS
      if (status/=0) stop
      write(EchoFileUnit,*) 'M13 water column biomass ', PLMAS     
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) area_waterbody
      if (status/=0) stop
      write(EchoFileUnit,*) 'M14 Waterbody Area ', area_waterbody    
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) depth_0, depth_max 
      if (status/=0) stop
      write(EchoFileUnit,*) 'M15 Initial Depth, Maximum depth ', depth_0, depth_max   
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) flow_averaging, baseflow 
      if (status/=0) stop
      write(EchoFileUnit,*) 'M16 Flow Averaging, Base Flow ', flow_averaging, baseflow              
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) cropped_fraction
      if (status/=0) stop
      write(EchoFileUnit,*) 'M17 Cropped Fraction of Area',  cropped_fraction     
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status)  vvwm_type, ConstVolnoflow_type, ConstVolflow_type, pond_type, reservoir_type
      if (status/=0) stop
      write(EchoFileUnit,*) 'Water body simulation types to be run',   vvwm_type, ConstVolnoflow_type, ConstVolflow_type, pond_type, reservoir_type 
      
      
      
      
      
      
      
      
      !****************TIME SERIES OUTPUT****************

      
      
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) is_hed_files_made
      if (status/=0) stop
      write(EchoFileUnit,*) 'Z1 Make HED files? ', is_hed_files_made
      
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) is_add_return_frequency, additional_return_frequency
      if (status/=0) stop
      write(EchoFileUnit,*) 'Z2 return frequncy info: ',    is_add_return_frequency, additional_return_frequency
      
      
   
      call check_for_comment(PRZMinputUnit)
      READ(PRZMinputUnit,*,IOSTAT = status) NPLOTS
      write(EchoFileUnit,*) 'Record U1 ', NPLOTS

      IF (NPLOTS .GT. 0) THEN
   
        DO I=1,NPLOTS
          
          call check_for_comment(PRZMinputUnit)
          READ(PRZMinputUnit,*) PLNAME(I),chem_id(I),MODE(I),ARG(I),IARG2(I),CONST(I)
          write(EchoFileUnit,*) 'Record U2: ' ,PLNAME(I),chem_id(I),MODE(I),ARG(I),IARG2(I),CONST(I)
        end do

      ENDIF

      write(EchoFileUnit,*) 'Finished reading inputs'

  end subroutine read_main_inputs