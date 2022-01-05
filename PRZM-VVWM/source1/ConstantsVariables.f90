module constants_and_variables

      implicit none
      save
      
      real,parameter :: Version_Number = -1.0 !using negative to denote preliminary work
      
      logical :: use_bidiagonal
      
real :: cputime_begin     !processor start reference time for begining of program
real :: clock_time_0   !clock start reference time for begining of program
real :: Cumulative_cpu_1, Cumulative_cpu_2, Cumulative_cpu_3
real :: Cumulative_cpu_4 
real :: Cumulative_cpu_5  
real :: Cumulative_cpu_6 
real :: Cumulative_cpu_7 ,  Cumulative_cpu_8, Cumulative_cpu_9
      ! File Names *******************************************************************************
      character (len=512) PRZMVVWMinputfile     
      character (len=512) inputfile !new input file to replace przmvvwminputfile. this file is the same as the pwc input file

      logical :: create_optional_output
      
      ! File Unit Numbers****************************************************
      integer, parameter ::  inputfile_unit_number  = 50    
      integer, parameter ::  PRZMinputUnit          = 51
      integer, parameter ::  MetFileUnit            = 52
      integer, parameter ::  ScenarioFileUnit       = 53
      integer, parameter ::  TimeSeriesUnit         = 54
      
      integer, parameter ::  EchoFileUnit           = 56
      integer, parameter ::  waterbody_file_unit    = 57
      
      integer, parameter ::  summary_output_unit    = 44
      
      ! scenario_unit_number :: 80 local number in read scenario routine

      !*********************************************************************
      integer :: number_of_schemes
      character (len=512) scheme_name
      integer :: scheme_number

      integer, parameter :: max_number_crop_periods  = 7 ! Maximum nuber of crop periods that the scenario file holds, Currently the PWC 2020 it is 7 periods oer year
     
      character(len=10)  :: waterbodytext  !text for water body type (not an input)
      logicaL :: is_output_all  !OUTPUT ALL FILES FROM WATERBODY dAILY 
      character(len= 500) :: summary_outputfile
      character(len= 256) :: run_id
      
      
      !Scheme inputs
      
      integer, allocatable,dimension(:)    :: number_of_scenarios
      integer, allocatable, dimension(:)   :: app_reference_point_schemes  !0=absolute date, 1=emergence, 2=maturity, 3=removal
      integer, allocatable, dimension(:)   :: num_apps_in_schemes
      integer, allocatable, dimension(:,:) :: method_schemes
      integer, allocatable, dimension(:,:) :: days_until_applied_schemes   !(scehme #, application # max of 366) 
      

      
   !   character(LEN=10), allocatable,dimension(:,:) absolute_date_option
      
      
      real,allocatable,dimension(:,:)      :: application_rate_schemes
      real,allocatable,dimension(:,:)      :: depth_schemes
      real,allocatable,dimension(:,:)      :: split_schemes
      real,allocatable,dimension(:,:)      :: efficiency_schemes
      real,allocatable,dimension(:,:)      :: drift_schemes
      integer,allocatable,dimension(:,:)      :: lag_schemes
      integer,allocatable,dimension(:,:)      :: periodicity_schemes
      
      integer :: app_reference_point   !0=absolute date, 1=emergence, 2=maturity, 3=removal;   scalar sent to przm-vvwm
      
      
      character (len=512),allocatable, dimension(:,:) :: scenario_names !(i,j) i is scheme #, j is scenario #
      
      !*********************************************************************
      logical :: is_koc     
      
      !The following are new additionas and need to be populated and converted as appropriate
      real ::  soil_degradation_rate_input(3), soil_ref_temp(3), xsoil(3)
      
 
      !molar conversions daughter granddaughter
      real :: xAerobic(2)
      real :: xBenthic(2)
      real :: xPhoto(2)
      real::  xHydro(2)
      
      character(len=256) :: outputfilename = "TestThis"      !output file name
   
      !real:: D_over_dx 
      !real:: benthic_depth
      !real:: porosity
      !real:: bulk_density  !dry mass/total volume  g/ml
      !real:: FROC2         !fraction oc in benthic sed
      !real:: DOC2
      !real:: BNMAS
      !real:: DFAC
      !real:: SUSED   !mg/L
      !real:: CHL

      !real:: FROC1
      !real:: DOC1
      !real:: PLMAS
      !real :: area_waterbody           !water body area (m2) 
      !real :: depth_0        !initial water body depth (m)
      !real :: depth_max      !maximum water body depth (m)
      !integer :: flow_averaging          !Ldays used to average flow for special case reservoir, 0 indicates complete sim average
      !real :: baseflow               
      real :: cropped_fraction !fractional area used for crop: only used here to display in output
      real,parameter :: CLOUD = 0.

      real, parameter :: wind_height= 6.     !height at which wind measurements are reported (m)
      real, parameter :: DELT_vvwm = 86400.  !seconds, simulation TIME INTERVAL IS ONE DAY. used for vvwm only
      real, parameter :: minimum_depth = 0.00001     !minimum water body depth
      
      logical :: is_hed_files_made
      logical :: is_add_return_frequency
      real    :: additional_return_frequency
      logical ::  ConstVolnoflow_type, ConstVolflow_type, pond_type, reservoir_type
     ! logical ::vvwm_type,

      
      character (Len = 10) waterbody_id

      !***************************************************************
      
      logical :: is_irrigation
      logical :: is_allyear_irrigation
      logical :: is_above_crop_irrigation
  
      !Time series trasfer from PRZM to VVWM
      real, allocatable, dimension(:) :: runoff_series   !runoff in cm
      real, allocatable, dimension(:) :: erosion_series  !eroded solids in (metric tons)
      
      
   
           
     !*********** Parameters used for calibration Routines *********
      integer :: data_number = 0
      integer :: data_date(100) = 0
      real    :: data_erosion(100) = 0.0
      real    :: data_runoff(100) = 0.0
      real    :: data_mgsed(100) = 0.0
      real    :: data_mgh2o(100) = 0.0
      
      real    :: model_erosion(100) = 0.0
      real    :: model_runoff(100) = -0.0
      real    :: model_mg_ro(100) = 0.0
      real    :: model_mg_er(100) = 0.0
      
      real    :: cn_moisture(100) = 0.0   

      !************************************************************
      
      logical :: is_true_rain_distribution
!      logical :: is_TC_lag_method
      
      integer :: day_number  !only used for diagnostics and time series 
      
      integer, parameter :: maxFileLength = 300  ! Maximum path and File name length  probably should limit to 256 due to windows limit
      integer, parameter :: max_horizons = 10    ! maximum number of soil horizons  
      integer, parameter :: max_number_plots = 100

    
      Character(Len = maxFileLength) :: working_directory
      Character(Len = maxFileLength) :: family_name
      Character(Len = maxFileLength) :: weatherFile_directory
      
      
      !Scenario Parameters
     ! Character(Len = 100)              :: scenario_id  use run_id
      Character(Len = maxFileLength)    :: weatherfilename
      Character(Len = maxFileLength)    :: weatherfiledirectory
      real                              :: latitude
      
      
      
      
      
      
      integer, parameter :: Num_hydro_factors = 100
      
      real,parameter    :: DELT = 1.0  !1 day time step, this value is not adjustable unless considerations are made for runoff which is daily
      
      integer     :: number_subdelt  !number of sub time steps in tridigonal calculation (used to investigate effect on nonlinear isotherms)
      real        :: subdelt         !delt/number_subdelt
      
      integer :: NCOM2              ! actual number of total compartments   
      
      integer :: user_node =1      ! a user specified node that is used for specific output of flux at a depth (node), not hooked up yet
         


      
      !*****Soil Profile Dependent Input Parameters *****************
      integer :: NHORIZ                           !input value
      integer :: Num_delx(max_horizons)           !Input Number of discretizations in horizon
      real    :: bd_input(max_horizons)           !bulk density of each horizon input
      real    :: clay_input(max_horizons)         !clay of each horizon input
      real    :: sand_input(max_horizons)         !clay of each horizon input
      real    :: oc_input(max_horizons)           !organic carbon fraction input
 
      real    :: fc_input(max_horizons)           !field capacity input
      real    :: wp_input(max_horizons)           !wilting point input
      real    :: soil_temp_input(max_horizons)    !input of initial soil temperatures
      real    :: thickness(max_horizons)          !thickness of each horizon
      real    :: dispersion_input(max_horizons)  !dispersion
             
      real ::  hydrolysis_rate_input(3)  ! rate in per days
      real ::  hydrolysis_rate(3)       ! rate in per sec
 
 
      real :: water_column_rate_input(3)        !Degradation rate in per day
      real :: water_column_rate(3)              ! converted to per sec
      real :: water_column_ref_temp(3)
      

      
      
      real :: benthic_rate_input(3)        !Degradation rate in per day
      real :: benthic_rate(3)              ! converted to per sec
      real :: benthic_ref_temp(3)
      
      real :: photo_input(3)             ! Degradation halflife in days
      real :: photo_rate(3)              ! Rate in per sec
      real :: rflat(3)                   ! input latitude for photolysis study   
      

      real    :: Aq_rate_input(3)    !input soil aqueous degradation rate parent, daughter, grand daughter
      real    :: Sorb_rate_input(3)  !input soil sorbed degradation rate parent, daughter, grand daughter
      real    :: Gas_rate_input(3)   !input soil as degradation rate parent, daughter, grand daughter
     

      real    :: k_f_input(3)        !input Freundlich Kf for each horizon
      real    :: N_f_input(3)        !input Freundlich N for each horizon
       
      !nonequilibrium parameters
      real :: k_f_2_input(3)  !input Freundlich Kf for each horizon Region 2
      real :: N_f_2_input(3)  !input Freundlich N for each horizon Region 2
          
      real :: MolarConvert_aq12_input(max_horizons),MolarConvert_aq13_input(max_horizons),MolarConvert_aq23_input(max_horizons)
      real :: MolarConvert_s12_input(max_horizons), MolarConvert_s13_input(max_horizons), MolarConvert_s23_input(max_horizons)
        
      real :: lowest_conc             !Below this concentration (mg/L), Freundlich isotherm is approximated to be linear to prevent numerical issues
           
      !Compartment-Specific Parameters

      real,allocatable,dimension(:,:) :: k_freundlich   !Freundich Coefficient in equilibrium Region  
      real,allocatable,dimension(:,:) :: N_freundlich   !Freundich Exponent in equilibrium Region
      real,allocatable,dimension(:,:) :: k_freundlich_2 !Freundich Coefficient in Nonequilibrium Region 2
      real,allocatable,dimension(:,:) :: N_freundlich_2 !Freundich Exponent in Nonequilibrium Region 2 
      
      real,allocatable,dimension(:) :: soil_depth       !vector of soil depths
      real,allocatable,dimension(:) :: wiltpoint_water  !wilting point content weighted by size of compartment (absolute water content)
      real,allocatable,dimension(:) :: fieldcap_water   !field capacity content weighted by size of compartment (absolute water content)
      real,allocatable,dimension(:) :: delx
      real,allocatable,dimension(:) :: bulkdensity
      
      real,allocatable,dimension(:) :: clay
      real,allocatable,dimension(:) :: sand
      real,allocatable,dimension(:) :: orgcarb
      real,allocatable,dimension(:) :: theta_zero  !beginning day water content
      real,allocatable,dimension(:) :: theta_end   !end day water content
      real,allocatable,dimension(:) :: theta_sat   !stauration water content (fractional)
      real,allocatable,dimension(:) :: theta_fc    !field capacity water content (fractional)
      real,allocatable,dimension(:) :: theta_wp    !wilting point water content (fractional)
        
      real,allocatable,dimension(:) :: soil_temp   !soil temperature
      real,allocatable,dimension(:) :: soilwater
      
      real,allocatable,dimension(:,:) :: dwrate, dsrate, dgrate
      real,allocatable,dimension(:,:) :: dwrate_atRefTemp, dsrate_atRefTemp, dgrate_atRefTemp
      
      real,allocatable,dimension(:) :: MolarConvert_aq12,MolarConvert_aq13,MolarConvert_aq23
      real,allocatable,dimension(:) :: MolarConvert_s12, MolarConvert_s13, MolarConvert_s23
      
      real,allocatable,dimension(:) :: dispersion  !formerly disp
      real,allocatable,dimension(:) :: thair_old
      real,allocatable,dimension(:) :: thair_new
      
      real,allocatable,dimension(:,:) :: Kd_new
      real,allocatable,dimension(:,:) :: Kd_old   !current time step Kd (applies to nnlinear isothrems)
      real,allocatable,dimension(:,:) :: Kd_2
      
      real,allocatable,dimension(:,:) :: new_henry  !henry constant for current time step (end of current step)
      real,allocatable,dimension(:,:) :: old_Henry  !Henry constant previous time step (start of current step)
      
      real,allocatable,dimension(:,:) :: Sorbed2  !nonequilib phase conc (internal units of g/g to correspond with mg/L aqueous)
    
      real,allocatable,dimension(:,:) :: conc_porewater
      real,allocatable,dimension(:,:) :: conc_total_per_water     !pest conc in Total Mass in all phases divided by water content)
      real,allocatable,dimension(:,:) :: mass_in_compartment      !New experimetal variable to replace "conc_total_per_water"
      real,allocatable,dimension(:,:) :: mass_in_compartment2     !mass in nonequilibrium compartment
      real,allocatable,dimension(:,:) :: SOILAP  !g/cm2  Mass of applied pesticide in soil
      
      real,allocatable,dimension(:) :: DGAIR !effective air diffusion coefficient through profile for chemical in the loop  
         
      !****Pesticide Flux**************
      
      
      
       real,allocatable,dimension(:,:) :: SRCFLX  !Production of chemical. i.e., from degrdation 
      !*******STORED OUTPUT VARIABLES**************************************
      
      real :: ERFLUX(3), WOFLUX(3), ROFLUX(3) 
      real,allocatable,dimension(:,:) :: DKFLUX
      real,allocatable,dimension(:,:) :: PVFLUX
      real,allocatable,dimension(:,:) :: UPFLUX
      real :: SDKFLX(3)     = 0.0 
      real :: DCOFLX(3)     = 0.0   !Pesticide outflow below soil core      
      real,allocatable,dimension(:,:) :: soil_applied_washoff
   

 
      real, parameter :: washoff_incorp_depth  = 2.0 !depth at which foliar washoff pesticide is incorporated into soil
      !previously this value was fixed to the runoff extraction depth
      integer :: number_washoff_nodes  !number of nodes coreresponding to washoff_incorp_depth

     ! integer :: NCOM1  !holds the lowest relavant evaopration node for each day
     ! integer :: NCOM0  !holds the node of corresponding to anetd
 
       integer :: min_evap_node  !holds the node of corresponding to anetd (min_evap_depth)
 
 
      Real, Parameter :: cam123_soil_depth = 4.0 ! cm  Default pesticide incorporation depth
      real, parameter :: CN_moisture_depth = 10.0  !depth of soil moisture for CN calculations
      
      REAL :: r1
      REAL :: R0MIN  = Tiny(r1)
                   
      logical :: really_not_thrufl  !flag to prevent washoff of undercanopy irrigation in PRZM3 (not used in PRZM5)
      real    :: canopy_flow        !flow through the canopy
      real    :: effective_rain     !total water, without consideration for canopy holdup 
      real    :: THRUFL             !total water minus canopy holdup 
      
      !***Simulation Timne **************************************************
      integer  :: startday      !julian day start date referenced to 1900 (note that we use two digit date, makes no difference)
      integer  :: julday1900    !the current day referenced to Jan 1, 1900
      integer  :: first_year
      integer  :: last_year
      integer  :: num_years    !number of calendar years in simulation (number of different year numbers, can be incomplete years)
      integer  :: first_mon  !first month of simulation
      integer  :: first_day    !first day of simulation
      
      
      !***PRZM5 Advanced Analysis OPtipon
      logical :: is_Freundlich !True if Freundlich
      logical :: is_nonequilibrium
      logical :: calibrationFlag =.FALSE.
      
      logical :: ADJUST_CN
      
      !*****Pesticide Applications ******************
      
      !These parameters are arrays that have each application for the entire simulation, day by day
      integer,allocatable,dimension(:) :: application_date ! juilan date (1900 references) array of application dates       
      integer,allocatable,dimension(:) :: pest_app_method
      real,allocatable,dimension(:) :: DEPI

      real,allocatable,dimension(:) :: TAPP     !read in application_rate_in as KG/HA but converted to G/CM**2 in initialization
      real,allocatable,dimension(:) :: APPEFF
      real,allocatable,dimension(:) :: Tband_top
      real,allocatable,dimension(:) :: drift_kg_per_m2  !the drift application rate to pond

      integer :: total_applications      !Total applications for simulations 
        
      
      !these parameters are the application parameters that are read in from the input file.  They represent a short-hand of the actual applications above
      integer :: num_applications_input  !number of apps reported in the input file (shorthand, does not include each year individual apps)
      
      integer,allocatable,dimension(:) :: pest_app_method_in
      real,allocatable,dimension(:) :: DEPI_in
      real,allocatable,dimension(:) :: application_rate_in  
           
      real,allocatable,dimension(:) :: APPEFF_in
      real,allocatable,dimension(:) :: Tband_top_in
      real,allocatable,dimension(:) :: drift_in
      integer,allocatable,dimension(:) :: lag_app_in
      integer,allocatable,dimension(:) :: repeat_app_in
      
      integer,allocatable,dimension(:) :: days_until_applied          !for relative dates


      
      real    :: plant_app     !store the plant applied pesticide
      logical :: some_applications_were_foliar
                
     !*****Pesticide Properties ******************  
      real    :: plant_pesticide_degrade_rate(3)    !plant decay rate
      real    :: plant_washoff_coeff(3)             !plant washoff coefficient (per cm rainfall)  
          


          
      real :: mwt(3)
      real :: solubilty(3)
      real :: vapor_press(3)
    real :: Henry_unitless(3)     !Henry's Constant ConcAir/ConcWater volumetric   now called HenryK same as PRZM
      real :: Heat_of_Henry(3)      !Enthalpy of air water exchange (J/mol)
            real    :: ENPY(3)             ! convert enthalpy from Joules to Kcal for PRZM  4184 J/kcal 
      
      
      
      
      
                       
      integer :: PCMC                               !signal to tell if its Koc to use
      integer :: KDFLAG                             !Select Kd calculation
      integer :: THFLAG                             !computw Wp and FC based on texture  
      real    :: k2(3)                              !noneq mass transfer coeff
      

      real :: foliar_formation_ratio_12, foliar_formation_ratio_23 !foliar transformation rates 
      real :: plant_volatilization_rate(3)   !plant pesticide volatilization rate (does not produce degradate)
      

      REAL :: UPTKF(3)         !PLANT UPTAKE FACTOR, CONVERTED TO GAMMA1 IN PLANTGROW

      !********Volatilization
      real           :: Height_stagnant_air_layer_cm = 0.5  !(can be changed by input file)
      real           :: uWind_Reference_Height = 10.0       !(can be changed by input file)
      real,parameter :: vonKarman = 0.4
      
      real :: CONDUC(3)        !Some canopy volatilization parameter
      REAL :: DAIR(3)
  !    real :: HENRYK(3)

      real,parameter :: henry_ref_temp  = 25.0
      
      REAL    :: Q_10   !temperature basis for formerly QFAC
      REAL    :: TBASE  !temperature reference for Q_10 degradation
      
     integer :: NCHEM

   
      !*******Heat transfer variables*********************
      real    :: emmiss   
      real    :: UBT                            !used in volatilization and heat routines

      real    :: Albedo(13), bbt(13)
   !   integer :: ITFLAG
      
      logical :: is_temperature_simulated

      real :: enriched_eroded_solids  !mass of eroded solids bumped up be an enrichment factor,  g/cm2, (analogous to runoff)
   
      real :: TCNC(3)     !used for output only
      
      


      !******Weather Related Variables******************       
      real :: precip_rain     !rain-only component, minus snow
      real :: PFAC,SFAC
      real :: SNOWFL
      
      

      integer :: num_records  !number of records in weather file

      real, allocatable, dimension(:) :: precip, pet_evap,air_temperature, wind_speed, solar_radiation  !from weather file
      real, allocatable, dimension(:) :: precip_m,evap_m , temp_avg, wind_m  ! with VVWM units, all meters, sec, temp is 30-day avg
 

      
      !Weather Scalers
      
      real :: wind
      real :: precipitation,air_TEMP,PEVP,SOLRAD !old ones
      
      !*****Irrigation Parameters
      integer :: IRFLAG
      integer :: IRTYPE
      
      real    :: PCDEPL,FLEACH      !inputs
      real    :: max_irrig  !maximum  irrigation water over 24 hour period
      real    :: under_canopy_irrig, over_canopy_irrig,flood_irrig  
      
      real    :: IRRR                      !daily irrigation water, used for time series reporting only
      logical :: UserSpecifiesDepth        !True if custom depth, False if auto with root depth
      real    :: user_irrig_depth          !user-specified depth of irrigation, input value
      integer :: user_irrig_depth_node     !node for user-specified depth of irrigation, calc in INITL subroutine
      
      !*****Crop Parameters ********* 

      real    :: min_evap_depth  ! the minimum depth that is used for PET satisfaction                     
      !VECTORS ODF SIZE NUM_RECORDS
      real,   allocatable, dimension(:) :: crop_fraction_of_max  !vector of daily fration of crop growth
      real,   allocatable, dimension(:) :: canopy_cover          !Fractional Coverage (but in PWC interface it is %)
      real,   allocatable, dimension(:) :: canopy_height
      real,   allocatable, dimension(:) :: canopy_holdup
      real,   allocatable, dimension(:) :: root_depth
      integer,allocatable, dimension(:) :: evapo_root_node  !Node that represents the root depth or evap zone (whichever greatest) Ncom1
      integer,allocatable, dimension(:) :: root_node        !Node for the root (formerly nrzomp)
      integer,allocatable, dimension(:) :: atharvest_pest_app
      
      logical,allocatable, dimension(:) :: is_harvest_day !True if the current day is a harvest day
    
      !VECTORS OF SIZE OF INPUT READ

        integer,dimension(max_number_crop_periods) :: emd   !these are the input values for day month
        integer,dimension(max_number_crop_periods) :: emm
        integer,dimension(max_number_crop_periods) :: mad
        integer,dimension(max_number_crop_periods) :: mam
        integer,dimension(max_number_crop_periods) :: had
        integer,dimension(max_number_crop_periods) :: ham
        integer,dimension(max_number_crop_periods) :: foliar_disposition       !1 = pesticide is surface applied at harvest, 2 = complete removal, 3 = left alone, 4 = bypass, 0 = ????
        real   ,dimension(max_number_crop_periods) :: max_root_depth
        real   ,dimension(max_number_crop_periods) :: max_canopy_cover
        real   ,dimension(max_number_crop_periods) :: max_canopy_holdup
        real   ,dimension(max_number_crop_periods) :: max_canopy_height     
        integer,dimension(max_number_crop_periods) :: crop_lag
        integer,dimension(max_number_crop_periods) :: crop_periodicity
      
        integer,allocatable,dimension(:,:) :: emergence_date  !(Crop#), these are the processed julian1900 dates
        integer,allocatable,dimension(:,:) :: maturity_date 
        integer,allocatable,dimension(:,:) :: harvest_date    
      
      
      
      !Scalers for core przm run
      integer :: root_node_daily   
      integer :: evapo_root_node_daily       !the nodes to the bottom of evap/root zone
      real    :: cover                       !Fractional Coverage (but in PWC interface it is %)
      real    :: height     
      integer :: harvest_placement
      logical :: harvest_day
      
      integer :: num_crop_periods_input !number of cropping periods read from the input file,not the actual number in the simulation
   !   integer :: total_crop_periods !total number of crop periods in the simulation, considering lag and periodicity and years
      
      !*****Erosion Parameters *************************
      real :: AFIELD           !INPUT, field area input, m2
      real :: AFIELD_ha        !   Area in ha, used in erosion routine
      
      real :: USLEK            !INPUT,
      real :: USLEP            !INPUT, 
      real :: USLELS           !INPUT,
    !  real :: hydro_length     !INPUT,
      real :: SLP
      
      integer :: erflag         !erosion flag
      
      integer :: CN_index                    !Current index for ereosion and runoff parameters, current one being used
    !  real    :: N1                          !The current mannings n value
      real    :: CFAC                        !The current c factor
      real    :: USLEC(Num_hydro_factors)    !inpuit values for c facator
      real    :: MNGN(Num_hydro_factors)      
                  
      logical :: use_usleyears               !True means usle values are year specific and do not repeat
      integer :: NUSLEC                      !number of c factors
      integer :: GDUSLEC(Num_hydro_factors)  !day
      integer :: GMUSLEC(Num_hydro_factors)  !month
      integer :: GYUSLEC(Num_hydro_factors)  !year when this option is used
      
      
      
      integer :: JUSLEC(Num_hydro_factors)   !julian day for each of the erosion days converted from gduslec and gmuslec
      

      real :: CN_2(Num_hydro_factors) !Curve Number 2 read from inputs, Now a Real number ( was an integer because its used as index in lookup table )    
      
      
      
      integer :: IREG        !erosion/rain intensity map region
      
      
      !******Hydrology*********
      real :: STTDET              !evaporation amount in the top 5 cm, used for temperature calculations 
      REAL :: CEVAP               !HOLDS ACTUAL PET
      real :: SMELT               !snow melt     
      real :: CN_moisture_ref     !water content halfway between wp and fc averaged over cn depth
      real :: INABS
      real :: Infiltration_Out   !Infiltration out of last compartment, this info was previously not captured by PRZM
      integer :: cn_moist_node   !number of compartments that make up runff moisture depth
      
      
      !real :: THETH    dfy renamed CN_moisture_ref  8/24/17          !water content halfway between wp and fc averaged over cn depth (not sure of purpose)
      
      !***Accumulators***************

      real, allocatable,dimension(:)   :: ainf        !infiltration INTO compartment(needs to be dimensioned as ncom2+1 to capture outflow)
      real, allocatable,dimension(:)   :: vel         !velocity out of compartment = ainf(i+1)/theta
      real, allocatable,dimension(:)   :: EvapoTran
      
      real, allocatable,dimension(:,:) :: GAMMA1   

      real :: runoff_on_day                   = 0.0   
      real :: snow                            = 0.0   !accumulated snow for each day
      real :: foliar_degrade_loss(3)          = 0.0   !foliar loss by degradation
      real :: FOLPST(3)                       = 0.0   !foliar storage

      real :: SUPFLX(3)                       = 0.0 

      real :: Foliar_volatile_loss(3)         = 0.0    !volatilization

      real :: potential_canopy_holdup  = 0.0    !daily maximum water that the canopy can hold
      real :: CINT             = 0.0    !the actual water held on the canopy during the current day
      real :: TDET             = 0.0    !evapotranspiration in the topp ncom1 compartments
      
      real :: SEDL
   



!      integer :: MTR1  !some kind of comaprtment count = ncom2
      
      
      !****Miscelaneous******

      
      !CHARACTER(len=78) ::  TITLE     !INPUTused in EXAMS output files and time series
      CHARACTER(len=20) ::  PSTNAM(3) !INPUT used in EXAMS

      !integer :: current_day        !day of month
      !integer :: current_month
      !integer :: current_year       !taken from metfile
              
      integer  :: CFLAG                 !INPUT initial pesticide concentration conversion flag
      
      character(len=4)  :: MODE(max_number_plots)      !INPUT time series plot modes
      character(len=4)  :: PLNAME(max_number_plots)    !INPUT Plot IDs for time series
      integer           :: ARG(max_number_plots)      !Formerly IARG, INPUT arguments for time series plots
      integer           :: IARG2(max_number_plots)      !INPUT arguments for time series plots
      
      integer           :: NPLOTS                       !INPUT number of time series plots
      real              :: CONST(max_number_plots)             !INPUT, the user defined adjustment to the time series output
      real              :: OUTPUJ(max_number_plots)
      
      
      real              :: OUTPJJ(max_number_plots)  !output accumulator
      integer           :: chem_id(max_number_plots)    !plot characterizer chem 1 2 3 
      
      REAL   ::  curve_number_daily   !holds curve number for plotting
             
      !***** PRZM5 runoff and erosion extraction variables ****************
      real :: runoff_effic              !amount of runoff bypassing surface soil
      real :: runoff_decline            !exponential factor for interaction decline with depth
      real :: runoff_extr_depth         !depth of runoff interaction
      real, allocatable,dimension(:) :: runoff_intensity  !PRZM5 uses this instead of DRI, fraction of runoff per cm depth

      real :: erosion_effic             !propotional reduction in erosion intensity
      real :: erosion_decline           !exponential factor for interaction decline with depth
      real :: erosion_depth             !erosion depth
      real, allocatable,dimension(:) :: erosion_intensity
      
      integer :: RNCMPT             !the number of compartments corresponding to the runoff extraction depth
      integer :: erosion_compt      !number of compartments for rerosion extraction
      
  
   character(len= 256) :: outputfile_parent_daily
   character(len= 256) :: outputfile_deg1_daily
   character(len= 256) :: outputfile_deg2_daily
            
   character(len= 256) :: outputfile_parent_analysis
   character(len= 256) :: outputfile_deg1_analysis
   character(len= 256) :: outputfile_deg2_analysis
               
   character(len= 256) :: outputfile_parent_deem
   character(len= 256) :: outputfile_deg1_deem
   character(len= 256) :: outputfile_deg2_deem
         
   character(len= 256) :: outputfile_parent_calendex
   character(len= 256) :: outputfile_deg1_calendex
   character(len= 256) :: outputfile_deg2_calendex
               
   character(len= 256) :: outputfile_parent_esa
   character(len= 256) :: outputfile_deg1_esa
   character(len= 256) :: outputfile_deg2_esa
      

    !VVWM Parameters
    real,allocatable,dimension(:) :: fraction_to_benthic
    real,allocatable,dimension(:) :: eroded_solids_mass   !read in from PRZMV output as tonnes/day but immediately converted to kg/day
    real,allocatable,dimension(:) :: burial               !(kg/sec) array of daily burial rate
    real,allocatable,dimension(:) :: flowthru_the_body    !(m3/sec) array of daily flow
   
    real,allocatable,dimension(:) :: k_aer_aq     !aqueous-phase aerobic rate (per sec)
    real,allocatable,dimension(:) :: k_anaer_aq   !aqueous-phase anaerobic rate (per sec)
    real,allocatable,dimension(:) :: k_aer_s      !sorbed-phase aerobic rate (per sec)
    real,allocatable,dimension(:) :: k_anaer_s    !sorbed-phase anaerobic rate (per sec)
    real,allocatable,dimension(:) :: k_volatile   !first order volatilization rate (per sec)
    real,allocatable,dimension(:) :: k_photo      !photolysis rate (1/sec)
    real,allocatable,dimension(:) :: daily_depth  !daily water body depths
    real,allocatable,dimension(:) :: k_hydro      !hydrolysis rate (per sec)
    real,allocatable,dimension(:) :: k_flow       !array of daily wash out rates (per second)
    real,allocatable,dimension(:) :: k_burial
    real,allocatable,dimension(:) :: theta        !solute holding capacity ratio [--]
    real,allocatable,dimension(:) :: capacity_1   !solute holding capacity of region 1 [m3]  
    real,allocatable,dimension(:) :: degradateProduced1,degradateProduced2
    real,allocatable,dimension(:) :: fw1          !fraction of region 1 solute in aqueous phase  
    real,allocatable,dimension(:) :: gamma_1              !effective littoral degradation
    real,allocatable,dimension(:) :: gamma_2              !effective benthic degradation
       
    real                          :: capacity_2   !solute holding capacity of region 2 [m3]
    real                          :: fw2          !fraction of region 2 solute in aqueous phase
    real                          :: kd_sed_1     !local Kd of ss (m3/kg)
    real                          :: omega                !mass transfer coefficient

real                          :: m_sed_1      !base amount of suspended solids mass (kg)    
real,allocatable,dimension(:) :: volume1              !array of daily water column volumes  [m3]    
real:: v2                                          !aqueous volume of pore water in sediment
real, allocatable, dimension(:)    :: A,B,E,F          !final coefficients for the 2 simultaneous equations
real, allocatable, dimension(:)    :: m1_input, m2_input               !at start of time step: the mass input in litt and benthic
real, allocatable, dimension(:)    :: m1_store,m2_store,mavg1_store    !array of daily peak/avg. mass in littoral and benthic
real, allocatable, dimension(:)    :: aq1_store, aq2_store             !begining day concentrations, after mass inputs

real,allocatable,dimension(:,:,:):: mass_off_field     !daily mass loading from runoff (column 1) & erosion (column 2) (kg)
real,allocatable,dimension(:) :: aqconc_avg1 ,aqconc_avg2  ! daily average aqueous concentrations


real:: spray_total(3)
real:: runoff_total(3)
real:: erosion_total(3)

real :: Sediment_conversion_factor !Converts pore water to concentration (total mass)/(dry solid mass)
real :: Daily_Avg_Runoff
real :: Daily_avg_flow_out










end module constants_and_variables