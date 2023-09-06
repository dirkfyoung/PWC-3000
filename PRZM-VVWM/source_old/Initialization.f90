module initialization
implicit none
contains

    
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!     
SUBROUTINE INITL
use utilities_1
use allocations
use constants_and_Variables, ONLY: min_evap_depth,                                    &
        SoilWater,fieldcap_water, wiltpoint_water,delx,                        &
        theta_zero,                                                            &
        sand_input,            sand,                                           &
        clay_input,            clay,                                           &
        bd_input,              bulkdensity,                                    &
        N_f_2_input,           N_freundlich_2,                                 &
        k_f_2_input,           k_freundlich_2,                                 & 
        k_f_input,             k_freundlich,                                   &
        N_f_input,             N_freundlich,                                   &
        fc_input,              theta_fc,                                       &
        wp_input,              theta_wp,                                       &
        soil_temp_input,       soil_temp,                                      &
        theta_sat, juslec,NUSLEC,CN_moisture_ref,RNCMPT,ncom2,                           &
        old_Henry,new_henry, HENRYK,orgcarb, oc_input, NCHEM,NHORIZ,thickness, &
        OUTPUJ,OUTPJJ,Num_delx,startday, soil_depth,                                                       &
        theta_end,CN_index,cfac,USLEC,EchoFileUnit,                             &
        cn_moist_node, runoff_effic, runoff_decline,runoff_intensity,runoff_extr_depth,                    &
        cam123_soil_depth, &
        CN_moisture_depth,erosion_intensity,erosion_decline,erosion_depth,erosion_effic , erosion_compt, &
        GYUSLEC,GMUSLEC,GDUSLEC,use_usleyears,number_washoff_nodes, washoff_incorp_depth, &
        user_irrig_depth_node, UserSpecifiesDepth,user_irrig_depth,   Kd_new ,Kd_old,  &
        conc_total_per_water, mass_in_compartment, conc_porewater, number_subdelt, subdelt, delt, &
        Sorbed2, aq_rate_input, sorb_rate_input, gas_rate_input, &
        dwrate_atRefTemp, dsrate_atRefTemp, dgrate_atRefTemp, dwrate, dsrate, dgrate, &
        MolarConvert_aq12,MolarConvert_aq13,MolarConvert_aq23,                &
        MolarConvert_s12, MolarConvert_s13, MolarConvert_s23, &
        MolarConvert_aq12_input, MolarConvert_aq13_input, MolarConvert_aq23_input, &
        MolarConvert_s12_input ,MolarConvert_s13_input , MolarConvert_s23_input,  &
        dispersion_input,dispersion, ainf, GAMMA1, vel, KD_2,  first_year,Min_Evap_node,soil_applied_washoff, &
        is_koc, AFIELD_ha, AFIELD, ENPY, Heat_of_Henry, &
        water_column_rate_input,benthic_rate_input, water_column_rate,benthic_rate, photo_input, photo_rate, &
        hydrolysis_rate, hydrolysis_rate_input                                  
     
    implicit none
    INTEGER         :: i,k   
    real            :: delx_avg_depth
    integer         :: startday_doy !  startday day of year  number of days past Jan 1, used for erosion
    integer         :: day_difference, smallest_difference
    real, parameter :: tol = 0.01  !some kind of tolerance for compartment size, Needs checking
    integer         :: start, xend


  !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
       ! 1= vary volume w/ flowthrough, 2=const volume, no flowthrough, 3=const vol, 
       !flowthrough, 4 = const vol no flow, 5 = const vol, flow
       ! 2 & 3 For use with the USEPA pond and reservoir ( and other situations)
    
          !!this will need to be incorporated into a loop---as is only will do one
          ! !1=vvwm,2 = USepa pond, 3 = usepa reservoir, 4=constant vol w/o flow, 5 = const vol w/flow
          !if (vvwm_type) then
          !    SimTypeFlag = 1
          !else if (pond_type) then
          !    SimTypeFlag = 2
          !else if (reservoir_type) then
          !    SimTypeFlag = 3
          !else if ( ConstVolnoflow_type) then
          !    SimTypeFlag = 4
          !else if (ConstVolflow_type) then
          !    SimTypeFlag = 5 
          !end if
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 

    !convert rates to per sec fr5om the input of per day
    water_column_rate   = water_column_rate_input/86400.  !per second
    benthic_rate        = benthic_rate_input/86400.       !per second         
    photo_rate          = photo_input/86400.              !per second
    hydrolysis_rate     = hydrolysis_rate_input/86400.    !per second  
 
    !For sub delt calculations
    subdelt = delt/number_subdelt
    
    call allocate_time_series
    AFIELD_ha = AFIELD/10000.

     ! convert enthalpy from Joules to Kcal for PRZM  4184 J/kcal   parent, daughter, granddaughter
    ENPY = Heat_of_Henry/ 4184.0   
    
    !********Allocations of Soil Profile Variables**********************
    NCOM2 = sum(num_delx(1:nhoriz))  !Total Number of Compartments

    call  allocate_soil_compartments
    ainf = 0.0
    GAMMA1  = 0.0
    vel = 0.0
    
    ! *** Populate the Delx Vector and Kf & N *******
    start = 1
    Xend = 0
             
    write(EchoFileUnit,*) "Initial Horizon Parameters"
    do i=1, nhoriz
        xend = start +num_delx(i)-1
        
        delx(start:xend)           = thickness(i)/num_delx(i) 
        bulkdensity(start:xend)    = bd_input(i)
        clay(start:xend)           = clay_input(i)
        sand(start:xend)           = sand_input(i)
        orgcarb(start:xend)        = oc_input(i)
        !Set the iniitial Water content to field capacity
        
        theta_zero(start:xend)    = fc_input(i)
        
 
        theta_fc(start:xend)       = fc_input(i)
        theta_wp(start:xend)       = wp_input(i)
        soil_temp(start:xend)      = soil_temp_input(i)
        dispersion(start:xend)     = dispersion_input(i)
        
        MolarConvert_aq12(start:xend)  = MolarConvert_aq12_input(i)
        MolarConvert_aq13(start:xend)  = MolarConvert_aq13_input(i)
        MolarConvert_aq23(start:xend)  = MolarConvert_aq23_input(i)
        MolarConvert_s12(start:xend)   = MolarConvert_s12_input(i)
        MolarConvert_s13(start:xend)   = MolarConvert_s13_input(i)
        MolarConvert_s23(start:xend)   = MolarConvert_s23_input(i)
        
        do K=1, NCHEM
            if (is_koc) then
                k_freundlich(k, start:xend)   = k_f_input(k)*oc_input(i)
                k_freundlich_2(k, start:xend) = k_f_2_input(k)*oc_input(i)
            else
                k_freundlich(k, start:xend)   = k_f_input(k)
                k_freundlich_2(k, start:xend) = k_f_2_input(k)   
            end if
             N_freundlich(k, start:xend) = N_f_input(k)   
             N_freundlich_2(k, start:xend) = N_f_2_input(k)                       
             !KD(k, start:xend)= k_f_input(k,i)                !Used in Freundlich linearization for tridiagonal              
             dwrate_atRefTemp(k,start:xend) =     exp(aq_rate_input(K)) -1.  !fraction removed per day
             dsrate_atRefTemp(k,start:xend) =     exp(sorb_rate_input(K)) -1.
             dgrate_atRefTemp(k,start:xend) =     exp(gas_rate_input(K)) -1.
         end do                       
        start = xend+1
    end do
    
    !As a default set the degradation rate to equal the input values
    dwrate = dwrate_atRefTemp
    dsrate = dsrate_atRefTemp
    dgrate = dgrate_atRefTemp

    theta_sat = 1.0 - bulkdensity/2.65
    if (any(theta_fc > theta_sat)) then
          WRITE(EchoFileUnit,* ) 'Water capacity exceeds saturation.'
    end if
    
    !If Linear Isotherms are used the reading Freundlich coefficient are used as Kd
    Kd_new  = k_freundlich   !used for Freundlich routines in tridiagonal 
    Kd_old  = k_freundlich 
     
    KD_2   = k_freundlich_2
    
    soil_applied_washoff  = 0.0
    conc_total_per_water = 0.0    
    mass_in_compartment = 0.0
    
    conc_porewater = 0.0
    Sorbed2 = 0.0   !nonequilibrium phase concentration

    !*** Populate Soil Depth Vector *********
    soil_depth = 0.0
    soil_depth(1) = delx(1)
    
    do i=2, NCOM2
       soil_depth(i) = soil_depth(i-1) + delx(i) 
    end do
 
    !*** Calculate Runoff Depth   ****************
    cn_moist_node = find_depth_node(ncom2,soil_depth,CN_moisture_depth)
    
    !*** Find the node for the  min_evap_depth (formerly) ANETD***************
    Min_Evap_node =  find_depth_node(ncom2,soil_depth,min_evap_depth)
    
    !Find the node for user-specified irrigation depth
    If (UserSpecifiesDepth) then
        user_irrig_depth_node =  find_depth_node(ncom2,soil_depth,user_irrig_depth)
    end if
    
    !initialize the water content in the profile to the THETO (previously initailized in SUBROUTINE INIACC)
    theta_end = theta_zero 
 
    OUTPUJ=0.0   !output accumulators, only used in output, could be initialzed with save attribute there
    OUTPJJ=0.0

    !initializehenry's law constant for first time here
    !These will also be the values used when temperature is not used 
    do K = 1, NCHEM
        old_Henry(K,:) = HENRYK(K)
        new_henry(K,:) = HENRYK(K)
    end do

    !Setup  Crop Growth 
    Call setup_crops
    write(EchoFileUnit,*)  "Exit Crop Setup"
    

    !**** Initialization of Curve Number and Erosion parameters*****  
    if (use_usleyears) then  !Erosion Parameters and Curve Numbers are Year Specific
        CN_index = 1  
        !For case 1, JUSLEC is referenced to Jan 1, 1900     
        do I=1,NUSLEC  
              JUSLEC(I)= jd(GYUSLEC(I),GMUSLEC(I),GDUSLEC(I))       
        end do 

        smallest_difference = 1e6
        do i= 1,NUSLEC
            day_difference =  abs(startday - JUSLEC(i))
            if (day_difference < smallest_difference) then
               smallest_difference = day_difference
               CN_index = i   !This sets the index for initial CN and erosion parameters
            end if    
        end do
        

    else  !Erosion Parameters and Curve Numbers  repeat every year
        !For default case JUSLEC is referenced to the Jan 1 of any year
        startday_doy = startday - jd(first_year,1,1)+1  
        do I=1,NUSLEC              
           JUSLEC(I)= jd(1,GMUSLEC(I),GDUSLEC(I)) -jd(1,1,1) +1     
        end do 
        smallest_difference = 1000                  
        do i= 1,NUSLEC    
               if (JUSLEC(i) > startday_doy) then
                 day_difference =  startday_doy - (JUSLEC(i)-365)
               else
                 day_difference =  startday_doy - JUSLEC(i)   
               end if
               if (day_difference < smallest_difference) then
                   smallest_difference = day_difference  
                   CN_index = i   !This sets the index for initial CN and erosion parameters
               end if
        enddo      
    end if
    cfac = USLEC(CN_index)
      
    !****************************************
    !Calculate Average Soil moisture in moisture zone (spec'd as a parameter) 
    !altered on 8/24/17 to average over depth rather than nodes so that it is consitent
    !when used to compared to actual soil moisture in HYDROLGY routine
    
    CN_moisture_ref  = 0.0
    
    do I=1,cn_moist_node
      CN_moisture_ref = CN_moisture_ref + 0.5*(theta_fc(I)+theta_wp(I))*delx(i)
    end do
     
    CN_moisture_ref = CN_moisture_ref /soil_depth(cn_moist_node)
   
    !***********************************************************      
    soilwater       = theta_zero*DELX
    fieldcap_water  = theta_fc*  DELX
    wiltpoint_water = theta_wp*  DELX
    

    !!***  Find the Maximum Root Node **********
    !rzd = maxval(max_root_depth(1:num_crops))
    !
    !NCOMRZ = find_depth_node(ncom2,soil_depth,rzd)

    !Calculate number of compartments which make upwashoff incorporation
    number_washoff_nodes =  find_depth_node(ncom2,soil_depth,washoff_incorp_depth) 
    
    !*** EXTRACTION of RUNOFF AND EROSION FROM SOIL ****************************
    !** Runoff Extraction Intensity
    RNCMPT =  find_depth_node(ncom2,soil_depth,runoff_extr_depth) !Calculate number of compartments which make up runoff
    runoff_intensity=0.0   
   
    if (runoff_decline > 0.0001) then
        do I=1,RNCMPT
            delx_avg_depth =  soil_depth(i) - DELX(I)/2.
            runoff_intensity(I)=runoff_effic*runoff_decline/(1-exp(-runoff_decline*runoff_extr_depth))*exp(-runoff_decline*delx_avg_depth)                            
        end do
    else   
       runoff_intensity(1:rncmpt)=runoff_effic/runoff_extr_depth
    end if
     
    !** Erosion Extraction Intensity    
    erosion_compt =  find_depth_node(ncom2,soil_depth,erosion_depth) !Calculate number of compartments which make up runoff
    erosion_intensity=0.0  
    
    !Using soil_depth(erosion_compt) instead of erosion_depth to prevent
    !some glitchy things like when depths are less than delx

    if (erosion_decline > 0.0001) then
        do i=1,erosion_compt
           delx_avg_depth =  soil_depth(i) - DELX(I)/2.
           erosion_intensity(i)= erosion_effic*erosion_decline/(1.0-exp(-erosion_decline*soil_depth(erosion_compt))) &
               *exp(-erosion_decline*delx_avg_depth)
        end do   
    else !essentially no decline uniform extraction      
        !need to limit this when depth is less than compartment !!!!!!
        !perhaps set it to the nodes
        !fixed it with erosion_numerical_depth    
        erosion_intensity(1:erosion_compt) = erosion_effic/soil_depth(erosion_compt)
    end if
    
!     perform units conversions for input variables
!     COVMAX..PERCENT--->FRACTION
!     WFMAX...KG/M**2--->G/CM**2


      !COVMAX = COVMAX/100.
      !WFMAX = WFMAX/10.   
         
     ! TAPP = application_rate_in/1.0E5  !     TAPP... KG/HA  --->G/CM**2
     !
     !
     !
     ! DO I = 1, num_applications
     !
     !       Select Case(pest_app_method(I))
     !       Case(1:3)
     !           DEPI(I) = cam123_soil_depth
     !       Case(4:10)
     !             If (DEPI(I) < delx(1)) Then
     !                 DEPI(I) = delx(1)
     !                 write (EchoFileUnit,*) 'Note: Minimum incorporation = ', Delx(1)
     !             End If
     !       Case Default
     !             note = 'CAM value is unheard of.'
     !             FATAL = .True.
     !             CALL ERRCHK(note,FATAL)
     !       End Select
     !
     !End Do

     call SetupApplications


end subroutine INITL
    


subroutine SetupApplications
  !Gets a scheme application set and 
  !sets the application days in julian days referenced to 1/1/1900 and puts them  in  application_date array
  ! Applcation_date is the entire
use constants_and_Variables, ONLY:EchoFileUnit,num_applications_input,pest_app_method_in,DEPI_in,application_rate_in,APPEFF_in, &
                                    Tband_top_in,drift_in,lag_app_in,repeat_app_in, first_year, last_year,  &
                                    application_date,pest_app_method,DEPI,TAPP,APPEFF,Tband_top, &
                                    num_crop_periods_input, emm, emd, mam,mad, ham,had, &
                                    total_applications , drift_kg_per_m2, cam123_soil_depth, delx, &
                                     days_until_applied,app_reference_point
  use utilities_1                                                     
  implicit none 
  
    integer :: i, j, mcrop,crop_iterations
    integer :: app_counter
        integer :: MONTH,DAY
        integer :: YEAR_out,MONTH_out,DAY_out

        ! (actual total apps may be less if simulation starts late in the of stops early) but that does not matter to the program,  also because of lag and periodicity
  
        total_applications = (last_year - first_year + 1)*num_applications_input*num_crop_periods_input
        write(EchoFileUnit,*)"Total Applications = ",   total_applications
  
  
        allocate (application_date(total_applications))
        allocate (pest_app_method(total_applications))
        allocate (DEPI(total_applications))
         
        allocate (TAPP(total_applications))             
        allocate (APPEFF(total_applications))
        allocate (Tband_top(total_applications))
        allocate ( drift_kg_per_m2(total_applications))

        if (app_reference_point== 0) then
            crop_iterations = 1
        else
            crop_iterations = num_crop_periods_input
        end if

        !First Loop is Crop Iterations, for absolute dates there is only one iteration  

        app_counter=0       
        do mcrop = 1, crop_iterations
            !first get  the month and day of the realtive reference (years will be tacked on later)   
            
            
             select case (app_reference_point)
             case (0) !absolute        
                     month = 1
                     day = 1
             case (1) !relative to emergenge
                     month = emm(mcrop)
                     day = emd(mcrop)
             case (2) !relative to maturity
                     month = mam(mcrop)
                     day = mad(mcrop)   
             case (3) !relative to harvest 
                     month = ham(mcrop)
                     day = had(mcrop)     
             end select
             
              write(EchoFileUnit,*) 'crop date ',  month , day

              write(EchoFileUnit,*)' num_applications_input ', num_applications_input
              
              
             do i=1, num_applications_input

                    do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)
                        app_counter = app_counter+1            
  
                        application_date(app_counter)=   jd(j,month,day) + days_until_applied(i)       

                    
                        pest_app_method(app_counter) = pest_app_method_in(i)
                        DEPI(app_counter) =  DEPI_in(i)
                        !make some Depth corrections if necessary
                         Select Case(pest_app_method(app_counter))
                         Case(1:3)
                              DEPI(app_counter) = cam123_soil_depth  !default for genaeral unspecified applications
                         Case(4:10)                            
                            If (DEPI(app_counter) < delx(1)) Then
                              DEPI(app_counter) = delx(1)
                              write (EchoFileUnit,*) 'Note: used minimum incorporation = ', Delx(1)
                            End If
                         End Select         
                         
                        TAPP(app_counter) = application_rate_in(i)/1.0E5  !     TAPP... kg/ha ---> g/cm**2
                        APPEFF(app_counter) = APPEFF_in(i)
                        Tband_top(app_counter) = Tband_top_in(i)
                        
                        !Kg/m2 drift application to waterbody
                        drift_kg_per_m2(app_counter) = drift_in(i)*application_rate_in(i)/10000. 
             
                        call get_date (application_date(app_counter), YEAR_out,MONTH_out,DAY_out)
                    
   
                        write(EchoFileUnit,*) application_date(app_counter) , YEAR_out,MONTH_out,DAY_out,  TAPP(app_counter)*1e5

                        !write(EchoFileUnit,'(I1,X,I1, 1X,I8,1X,I5,1X,I2,1X,I2,1X,G10.3, 1X,I2, 8g10.3 )') mcrop,i , application_date(app_counter) !, YEAR_out,MONTH_out,DAY_out,TAPP(app_counter), pest_app_method(app_counter), DEPI(app_counter), APPEFF(app_counter),Tband_top(app_counter),  drift_in(i),drift_kg_per_m2(app_counter)
                    end do 
             end  do  
        end do
        

 write(EchoFileUnit,*) 'Done setting application dates, Total applications in sim = ', app_counter


  end subroutine SetupApplications


!**********************************************************************  
  subroutine setup_crops
  !converts days and months to julia
  !emergence date, maturity_date, harvest_date are all since 1-1-1900
  
  use constants_and_Variables, ONLY:EchoFileUnit, emd, emm, mad, mam, had, ham, num_crop_periods_input, &
       first_year, last_year,num_years, crop_lag, crop_periodicity, emergence_date, maturity_date, harvest_date
   
  use utilities_1
   implicit none

   integer :: i,j,k
   integer :: maturity_year, harvest_year !local hold for year that maturity or harvest occurs, which may differ from emergence
   
   integer ::   yr_tracker
   
 !  total_crop_periods=0
    
   write (echofileunit, *) 'crop periods ', num_crop_periods_input 
   !do i=1, num_crop_periods_input        
   !   total_crop_periods = total_crop_periods+((last_year- first_year)- crop_lag(i) + crop_periodicity(i))/crop_periodicity(i)
   !end do
   
  ! write (echofileunit, *) 'Calculated Total Actual Crop Periods =', total_crop_periods
   
   allocate (emergence_date (num_crop_periods_input, num_years)) 
   allocate (maturity_date  (num_crop_periods_input, num_years))
   allocate (harvest_date   (num_crop_periods_input, num_years)) 
   
   !allocate (emergence_date (total_crop_periods))
   !allocate (maturity_date  (total_crop_periods))
   !allocate (harvest_date   (total_crop_periods)) 

   emergence_date =-7777 !arbitrary unlikely value to ever interfere with simulation if array has some unued spaces 
   maturity_date  =-7777
   harvest_date   =-7777
   
   k=0 !index for crop dates
   do i=1, num_crop_periods_input          
           yr_tracker = 0  !count tracker for years
          do j = first_year + crop_lag(i) , last_year, crop_periodicity(i)
    
              yr_tracker= yr_tracker+1
              k=k+1
              emergence_date(i,yr_tracker) = jd (j,emm(i),emd(i))            

              !maturity might cross over to another calendar year, but it must occur after emergence
              maturity_year = j  !first assume that maturity occurs on same calendar year j 
              maturity_date(i,yr_tracker)  = jd (maturity_year ,mam(i),mad(i))               
              if (emergence_date(i,yr_tracker) > maturity_date(i,yr_tracker))then 
                  maturity_year = j+1
                  maturity_date(i,yr_tracker)  = jd (maturity_year,mam(i),mad(i))
              end if     
              harvest_year = maturity_year !first assume that harvestoccurs on same calendar year as maturity
              harvest_date(i,yr_tracker) = jd (harvest_year,ham(i),had(i))
              
              !harvest might cross over to another calendar year, but it must occur after maturity
              if (maturity_date(i,yr_tracker) > harvest_date(i,yr_tracker))then 
                  harvest_year = maturity_year + 1
                  harvest_date(i,yr_tracker)  = jd (harvest_year,ham(i),had(i))
              end if  
           
          end do
        
         
      end do

  
  

  end subroutine setup_crops


  subroutine name_output_files
    use constants_and_variables, ONLY: EchoFileUnit,maxFileLength, TimeSeriesUnit, working_directory,scenario_id,family_name,waterbody_id, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily, &
        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis   
    use Output_File      
    implicit none
    character(len = maxFileLength) :: filename

    filename = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) // ".zts"
    OPEN(Unit=TimeSeriesUnit,FILE=trim(adjustl(filename)), STATUS='UNKNOWN') 
    call write_outputfile_header
    
    WRITE(EchoFileUnit,*) 'Read and open Time Series: ' //  trim(filename)
    

    outputfile_parent_daily = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_Parent_daily.csv"
    outputfile_deg1_daily   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_Degradate1_daily.csv"
    outputfile_deg2_daily   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_Degradate2_daily.csv"
 
    outputfile_parent_analysis = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Parent.txt"
    outputfile_deg1_analysis   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_deg1.txt"
    outputfile_deg2_analysis   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_deg2.txt"
  
    !outputfile_parent_deem    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Parent_DEEM.rdf"
    !outputfile_deg1_deem      = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate1_DEEM.rdf"
    !outputfile_deg2_deem      = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate2_DEEM.rdf"
    !
    !outputfile_parent_calendex  = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Parent_Calendex.rdf"  
    !outputfile_deg1_calendex    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate1_Calendex.rdf"
    !outputfile_deg2_calendex    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate2_Calendex.rdf"
    !
    !outputfile_parent_esa   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Parent.txt"
    !outputfile_deg1_esa     = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Degradate1.txt"
    !outputfile_deg2_esa     = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Degradate2.txt"
    !

      

      






end subroutine name_output_files

  
  
  
  

end module initialization   