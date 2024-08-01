Module TPEZ_WPEZ
    implicit none
    contains
    
    
    subroutine wpez
    !THIS IS THE SAME ROUTINE AS VVWM BUT WITH SOME HARD CODED VALUES FOR INPUTS

        use constants_and_variables, ONLY: nchem, wpez_timeseries_unit,  summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
            is_koc, k_f_input, water_column_ref_temp, benthic_ref_temp, &
            water_column_rate,is_hed_files_made, DELT_vvwm, additional_return_frequency, &
            outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
            outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
            outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa, k_flow , &
            summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2,First_time_through_wpez  , aqconc_avg1
       use waterbody_parameters, ONLY: FROC2, simtypeflag, depth_0,depth_max,baseflow,is_zero_depth,zero_depth  

       use degradation
       use solute_capacity
       use mass_transfer
       use volumeAndwashout
       use MassInputs
       use ProcessMetfiles
     !  use outputprocessing
       use nonInputVariables, only: 
       use allocations
       use coreCalculations
    
       implicit none              

       !**local chemical properties****
       integer :: chem_index, i
       real    :: koc
       character(LEN=20) :: waterbody_name


      ! FOR WPEZ these should already be calculated AFTER pond run
      !   call allocation_for_VVWM  moved to front
      !   call convert_weatherdata_for_VVWM      
      !   call get_mass_inputs
      !   call spraydrift
 
      !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
      !RESET PARAMETERS for wpez      
       simtypeflag   = 1       !***WPEZ MODIFICATION, Always varing volume **********
       depth_0       = 0.15      
       depth_max     = 0.15       
       baseflow      = 0.0      
       is_zero_depth = .TRUE.  ! exclusion of conc values from output when below 0.5 cm
       zero_depth    = 0.005  
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
      
          call solute_holding_capacity(chem_index,koc)    
          
          call omega_mass_xfer             !probably doesnt need recalculation
          call hydrolysis(chem_index) 
          call photolysis(chem_index)
        
          call metabolism(chem_index)      !probably doesnt need recalculation
          call burial_calc(koc)            !probably doesnt need recalculation
          call volatilization(chem_index )
              
          !process the individual degradation rates into overall parameters:
          call gamma_one
          call gamma_two                   !probably doesnt need recalculation
          
          call initial_conditions(chem_index)

          call MainLoop             
          
          
          waterbody_name =  "WPEZ"
        
        
          if (nchem > chem_index) then     
                call DegradateProduction(chem_index) 
          end if

          call output_processor_WPEZ(chem_index,First_time_through_wpez, wpez_timeseries_unit, summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
                             summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2, waterbody_name )
      end do
      
      
      !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
      !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
      !to do:  should make wpez completely independent so reset not necessary       
       simtypeflag   = 2
       depth_0       = 2.0     
       depth_max     = 2.0       
       baseflow      = 0.0      
       is_zero_depth = .FALSE. 
       zero_depth    = 0.00  
      !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    
    end subroutine wpez
    
    
    subroutine output_processor_WPEZ(chem_index, First_time_through, output_unit, unit_number,unit_number_deg1,unit_number_deg2,&
                                summary_filename, summary_filename_deg1, summary_filename_deg2, waterbody_name )

    use utilities
    use waterbody_parameters, ONLY: SimTypeFlag, zero_depth, is_zero_depth, Afield, area_waterbody
    
    use constants_and_variables, ONLY:  num_records, run_id, num_years, startday, &
                                 gamma_1,        &
                                 gamma_2,        &
                                 fw1,            &
                                 fw2,            &
                                 aq1_store,      &   !beginning day after app concentration in water column
                                 aq2_store,      &
                                 aqconc_avg1,    &   !average daily concentration (after app)
                                 aqconc_avg2,    &
                                 daily_depth,    &
                                 runoff_total ,  &
                                 erosion_total,  &
                                 spray_total ,   &
                                 m_total,        &  !total system average daily mass
                                 Daily_Avg_Runoff, Daily_avg_flow_out,  runoff_fraction, erosion_fraction, drift_fraction ,&
    k_burial, k_aer_aq, k_hydro, k_photo, k_volatile,k_anaer_aq, gamma_1, gamma_2, gw_peak, post_bt_avg ,throughputs,simulation_avg, &
	is_waterbody_info_output, full_run_identification, applied_mass_sum_gram_per_cm2 , fraction_off_field
   
    use utilities_1, ONLY: pick_max, find_first_annual_dates
     
    implicit none
    integer,             intent(in)    :: chem_index
    integer,             intent(in)    :: output_unit                                             !time series
    integer,             intent(in)    :: unit_number,unit_number_deg1,unit_number_deg2            ! summary files
    character(len= 500), intent(in)    :: summary_filename, summary_filename_deg1, summary_filename_deg2
    logical,             intent(inout) :: First_time_through
    character(len= 20), intent(in)     :: waterbody_name
    
    
    character(len=512) :: waterbody_outputfile
    
    !temporary parameters for esa, should make this more general in the future
    real:: return_frequency

    real:: simulation_average  
    real :: xxx  !local variable

 !   real(8),dimension(num_records)::c1
 !   real(8),dimension(num_records)::cavgw


    real,dimension(num_records):: c4        !all 4-day averaged values
    real,dimension(num_records):: c21
    real,dimension(num_records):: c60
    real,dimension(num_records):: c90
    real,dimension(num_records):: c365
    real,dimension(num_records):: benthic_c21
    
 !   real,dimension(num_years):: onedayavg
    real,dimension(num_years):: peak   
    real,dimension(num_years):: benthic_peak  !now it 1-day average
    
    
    real,dimension(num_years):: c1_max      !peak year to year daily average
    real,dimension(num_years):: total_max   !total mass in system  converted to lb/acre below
    
    
    real,dimension(num_years):: c4_max  !the peak 4-day average within the 365 days after application
    real,dimension(num_years):: c21_max
    real,dimension(num_years):: c60_max
    real, dimension(num_years)::c90_max
    real,dimension(num_years):: c365_max !the peak 365-day average within the 365 days after application
                                            !last year will be short depending on application date
                                        
    real,dimension(num_years):: benthic_c21_max                         
                                        
    integer :: i    
    integer ::date_time(8)
    real :: convert                    !conversion factor kg/m3 

    real :: Total_Mass
    integer :: YEAR,MONTH,DAY
    integer :: eliminate_year
    integer,dimension(num_years) ::  first_annual_dates !array of yearly first dates (absolute days).
                                    ! First date is the calendar day of start of simulation 
    first_annual_dates= 0
    

     if (is_waterbody_info_output) then
     	select case (chem_index)
     	    case (1)
     		    waterbody_outputfile = trim(full_run_identification) // '_parent_'       // trim(waterbody_name) // '.out'
     	    case (2)
     		    waterbody_outputfile = trim(full_run_identification) // '_daughter_'      // trim(waterbody_name) // '.out'
     	    case (3)
     		    waterbody_outputfile = trim(full_run_identification) // '_granddaugter_' // trim(waterbody_name) // '.out'	
     	    case default
     		    waterbody_outputfile =trim(full_run_identification) // '_nada.out'	
         end select
     	
         open (UNIT=output_unit,FILE= trim(waterbody_outputfile),  STATUS='unknown')
     
         
         write(output_unit,*) 'Depth(m)   ,  Water Col(kg/m3), Benthic(kg/m3), total mass (kg)'
      
         do i =1, num_records
             write(output_unit,'(G12.4E3, "," ,ES12.4E3, "      ," ,ES12.4E3, "   ," ,ES12.4E3)')  daily_depth(i), aqconc_avg1(i), aqconc_avg2(i), m_total(i)


         end do

     	 close (output_unit)
     end if

     !For Certain water bodies, users want to exclude concentrations below a certain level
       if (is_zero_depth) then
               where (daily_depth < zero_depth) aqconc_avg1 = 0.0
       end if
       
     
     
     
     
     
    !Calculate chronic values *******************
    !The following returns the n-day running averages for each day in simulation
   
    call window_average(aqconc_avg1,4,num_records,c4)
    call window_average(aqconc_avg1,21,num_records,c21)
    call window_average(aqconc_avg1,60,num_records,c60)
    call window_average(aqconc_avg1,90,num_records,c90)  
    call window_average(aqconc_avg1,365,num_records,c365)

    Simulation_average = sum(aqconc_avg1)/num_records
    
    call window_average(aqconc_avg2,21,num_records,benthic_c21)

    call find_first_annual_dates (num_years, first_annual_dates )

	 
    call pick_max(num_years,num_records, first_annual_dates,aqconc_avg1,c1_max)     !NEW FIND DAILY AVERAGE CONCENTRATION RETURN   
    call pick_max(num_years,num_records, first_annual_dates,m_total,total_max)     !total mass (depth restriction not applicable here)
    
    call pick_max(num_years,num_records, first_annual_dates,c4,c4_max)
    call pick_max(num_years,num_records, first_annual_dates,c21,c21_max)
    call pick_max(num_years,num_records, first_annual_dates,c60,c60_max)
    call pick_max(num_years,num_records, first_annual_dates,c90,c90_max)
    call pick_max(num_years,num_records, first_annual_dates,benthic_c21,benthic_c21_max)
    
    

    !treat the 365 day average somewhat differently:
    !In this case, we simply are calculating the average for the 365 day forward from the
    !day of application
 
    do concurrent (i=1:num_years-1) 
        c365_max(i) = c365(first_annual_dates(i)+365)  
    end do
    
    c365_max(num_years) = c365(num_records)

    !****Calculate Acute values *******************
    call pick_max(num_years,num_records, first_annual_dates,aq1_store, peak)    !now using 1-d avg for acutes intead of peak
   ! call pick_max(num_years,num_records, first_annual_dates,aq2_store, benthic_peak)
    
    call pick_max(num_years,num_records, first_annual_dates,aqconc_avg2, benthic_peak) !new 4/5/2023 Changed to daily average for benthin acute
    

        !*****************************************
       
        convert = 1000000.
        peak               = peak*convert
        c1_max             = c1_max*convert
        c4_max             = c4_max*convert
        c21_max            = c21_max*convert
        c60_max            = c60_max*convert
        c90_max            = c90_max*convert
        c365_max           = c365_max*convert
        benthic_peak       = benthic_peak*convert
        benthic_c21_max    = benthic_c21_max*convert
        Simulation_average = Simulation_average*convert
        
        total_max = total_max/area_waterbody*8921.79         !convert from kg/m2 to lb/Acre


       return_frequency = 10.0

 
        Total_Mass = runoff_total(chem_index) + erosion_total(chem_index) +  spray_total(chem_index)        !kg i think
        If (Total_Mass <= 0.0) then
            runoff_fraction  = 0.0
            erosion_fraction = 0.0
            drift_fraction   = 0.0
            fraction_off_field =0.0
        else
            runoff_fraction  = runoff_total(chem_index) /Total_Mass
            erosion_fraction = erosion_total(chem_index) /Total_Mass
            drift_fraction   =  spray_total(chem_index)/Total_Mass
            
            if (applied_mass_sum_gram_per_cm2 > 0.0) then
                  fraction_off_field = Total_Mass/(applied_mass_sum_gram_per_cm2*Afield*10.)  !applied mass is in kg/ha, afield is in m2
            else
                  fraction_off_field = 0.0
            endif
        end if
        
    
  !     write(*,*) "total and fraction off field (WPEZ)" , applied_mass_sum_gram_per_cm2*Afield*10., fraction_off_field
   
 !      call calculate_effective_halflives()
       

       call write_simple_batch_data_WPEZ(chem_index, First_time_through, unit_number,unit_number_deg1,unit_number_deg2,&
                                     summary_filename, summary_filename_deg1, summary_filename_deg2, &
                                     return_frequency,num_years, peak,Simulation_average,c1_max,c4_max, &
                                     c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max, total_max )      


    end subroutine output_processor_WPEZ  
                                
    
   
    
    
   subroutine write_simple_batch_data_WPEZ(chem_index,First_time_through, unit_number,unit_number_deg1,unit_number_deg2, &
                                        summary_filename, summary_filename_deg1, summary_filename_deg2, &
                                        return_frequency,num_years, peak,Simulation_average,c1_max, &
                                        c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max, total_max  )

    use constants_and_variables, ONLY: run_id,fw2 ,&
    nchem,     runoff_fraction,erosion_fraction,drift_fraction,summary_outputfile, &
    effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1,&
    effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, &
    gw_peak, post_bt_avg ,throughputs,simulation_avg, fraction_off_field, family_name, app_window_counter,&
    hold_for_medians_WPEZ,hold_for_medians_WPEZ_daughter, hold_for_medians_WPEZ_grandaughter


    use utilities_1, ONLY: Return_Frequency_Value


    implicit none   
    integer, intent(in)                       :: num_years
    real, intent(in)                          :: return_frequency
    real, intent(in), dimension(num_years)    :: peak,c1_max,c4_max,c21_max,c60_max,c90_max,c365_max,benthic_peak, benthic_c21_max, total_max
    real, intent(in)                          :: Simulation_average
    logical, intent(inout)                    :: First_time_through
    
    
    integer, intent(in) :: unit_number,unit_number_deg1,unit_number_deg2
    character(len= 500), intent(in):: summary_filename, summary_filename_deg1, summary_filename_deg2
    
    
    integer, intent(in) ::chem_index
    character (len=444) :: header
    
    
    !****LOCAL*********************
    real      :: peak_out,c1_out, c4_out,c21_out,c60_out,c90_out,c365_out,benthic_peak_out,benthic_c21_out, total_out  
    logical   :: lowyearflag
    character(len= 257) :: local_run_id
    
    If (First_time_through) then
        header = 'Run Information                                                                  ,      1-d avg,    365-d avg,    Total avg,      4-d avg,     21-d avg,     60-d avg,      B 1-day,   B 21-d avg,    Off-Field,  Runoff Frac,   Erosn Frac,   Drift Frac,  col washout,    col metab,    col hydro,    col photo,    col volat,    col total,  ben sed rem,    ben metab,    ben hydro,    ben total,  total_out(lb/A) '
        
        Open(unit=unit_number,FILE=  (trim(family_name) // "_" // trim(summary_filename)),Status='unknown')  
        Write(unit_number, '(A444)') header
        if ( NCHEM>1) then
            Open(unit=unit_number_deg1,FILE= (trim(family_name) // "_" // trim(summary_filename_deg1)),Status='unknown')  
            Write(unit_number_deg1, '(A433)') header
        end if
        if ( NCHEM >2) then
            Open(unit=unit_number_deg2,FILE= (trim(family_name) // "_" // trim(summary_filename_deg2)),Status='unknown')  
            Write(unit_number_deg2, '(A433)') header
        end if
        
        First_time_through= .FALSE.
    end if

    !**find values corresponding to  percentiles
    call Return_Frequency_Value(return_frequency, peak,           num_years, peak_out,         lowyearflag)   
    call Return_Frequency_Value(return_frequency, c1_max,         num_years, c1_out,           lowyearflag)
    
    call Return_Frequency_Value(return_frequency, total_max,      num_years, total_out,           lowyearflag)
    

    call Return_Frequency_Value(return_frequency, c4_max,         num_years, c4_out,           lowyearflag)
    call Return_Frequency_Value(return_frequency, c21_max,        num_years, c21_out,          lowyearflag)
    call Return_Frequency_Value(return_frequency, c60_max,        num_years, c60_out,          lowyearflag)
    !call Return_Frequency_Value(return_frequency, c90_max,        num_years, c90_out,          lowyearflag)
    call Return_Frequency_Value(return_frequency, c365_max,       num_years, c365_out,         lowyearflag)
    call Return_Frequency_Value(return_frequency, benthic_peak,   num_years, benthic_peak_out, lowyearflag)
    call Return_Frequency_Value(return_frequency, benthic_c21_max,num_years, benthic_c21_out,  lowyearflag)


    select case (chem_index)
    case (1)
        local_run_id = trim(run_id)//"_WPEZ" // '_Parent'
        write(unit_number,'(A80,1x,23(",", ES13.4E3))') (adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out, fraction_off_field, runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, total_out    !effective_total_deg2 does not mean degradate, means benthic

        
          
    !**capture data for median calculations here
          hold_for_medians_WPEZ(app_window_counter,1)= c1_out
          hold_for_medians_WPEZ(app_window_counter,2)= c365_out
          hold_for_medians_WPEZ(app_window_counter,3)= simulation_average
          hold_for_medians_WPEZ(app_window_counter,4)= c4_out
          hold_for_medians_WPEZ(app_window_counter,5)= c21_out
          hold_for_medians_WPEZ(app_window_counter,6)= c60_out
          hold_for_medians_WPEZ(app_window_counter,7)= benthic_peak_out
          hold_for_medians_WPEZ(app_window_counter,8)= benthic_c21_out
          
          hold_for_medians_WPEZ(app_window_counter,9)= total_out
          hold_for_medians_WPEZ(app_window_counter,10)= 0.0  !spare  wpez only uses 9
          hold_for_medians_WPEZ(app_window_counter,11)= 0.0  !spare
          
          
    !      hold_for_medians_WPEZ( 9, app_window_counter)= post_bt_avg(1)
    !      hold_for_medians_WPEZ( 10, app_window_counter)= throughputs(1)

    case (2)
        local_run_id = trim(run_id)//"_WPEZ" // '_deg1'
        write(unit_number_deg1,'(A80,1x,23(",", ES13.4E3))') (adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out,fraction_off_field,runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, total_out  !, gw_peak(2), post_bt_avg(2) ,throughputs(2) ,simulation_avg(2)

          hold_for_medians_WPEZ_daughter(app_window_counter,1)= c1_out
          hold_for_medians_WPEZ_daughter(app_window_counter,2)= c365_out
          hold_for_medians_WPEZ_daughter(app_window_counter,3)= simulation_average
          hold_for_medians_WPEZ_daughter(app_window_counter,4)= c4_out
          hold_for_medians_WPEZ_daughter(app_window_counter,5)= c21_out
          hold_for_medians_WPEZ_daughter(app_window_counter,6)= c60_out
          hold_for_medians_WPEZ_daughter(app_window_counter,7)= benthic_peak_out
          hold_for_medians_WPEZ_daughter(app_window_counter,8)= benthic_c21_out
          hold_for_medians_WPEZ_daughter(app_window_counter,9)= total_out
          hold_for_medians_WPEZ_daughter(app_window_counter,10)= 0.0  !spare
          hold_for_medians_WPEZ_daughter(app_window_counter,11)= 0.0  !spare
    
    case (3)
        local_run_id = trim(run_id) //"_WPEZ" // '_deg2'
        write(unit_number_deg2,'(A80,1x,23(",", ES13.4E3))')(adjustl(local_run_id)), c1_out, c365_out , simulation_average, c4_out, c21_out,c60_out,benthic_peak_out, benthic_c21_out,fraction_off_field, runoff_fraction,erosion_fraction,drift_fraction, &
        effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1, effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2, total_out   !, gw_peak(3), post_bt_avg(3) ,throughputs(3) ,simulation_avg(3)


          hold_for_medians_WPEZ_grandaughter( app_window_counter , 1  )= c1_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 2  )= c365_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 3  )= simulation_average
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 4  )= c4_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 5  )= c21_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 6  )= c60_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 7  )= benthic_peak_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 8  )= benthic_c21_out  
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 9  )= total_out
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 10 )= 0.0  !spare
          hold_for_medians_WPEZ_grandaughter( app_window_counter , 11 )= 0.0  !spare
        
        
        
        case default
    end select


     
   end subroutine write_simple_batch_data_WPEZ
                                        

    !****************************************************************************
    subroutine tpez(scheme_number)
      ! this is scenario dependent
      use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
          DELT_vvwm, waterbodytext,soil_depth, &
          application_rate_in, first_year ,lag_app_in , last_year, repeat_app_in, drift_schemes,&
          theta_fc,theta_wp, ncom2,  orgcarb,bulkdensity, mavg1_store, driftfactor_schemes, is_output_spraydrift     
 !     num_applications_input,
      
      
      use waterbody_parameters, ONLY: simtypeflag    !, use_tpezbuffer
!     use TPEZ_initialization, ONLY: tpez_drift_kg_per_m2
      
      use degradation
      use MassInputs
    !  use outputprocessing
      use utilities_1, ONLY:find_average_property
      use TPEZ_spray_initialization, ONLY: area_tpez
      
      use clock_variables
      implicit none   
      integer,intent(in) ::scheme_number
     
      !**local chemical properties****
      integer :: chem_index
      real    :: koc
      integer :: i,j
      real    :: avg_maxwater, avg_minwater, avg_oc, avg_bd
      real    :: kd

     !Scenario Dependent Properties. Must be called after each Scenario
     call find_average_property(ncom2,soil_depth,15.0, theta_fc    , avg_maxwater)    
     call find_average_property(ncom2,soil_depth,15.0, theta_wp    , avg_minwater)
     call find_average_property(ncom2,soil_depth,15.0, bulkdensity , avg_bd)  
     call find_average_property(ncom2,soil_depth,15.0, orgcarb     , avg_oc) !percent

     call  tpez_volume_calc (avg_maxwater, avg_minwater, area_tpez)   !call special averaging in here
  
     do chem_index= 1, nchem 
           
          if (is_koc) then
                  kd = k_f_input(chem_index) * avg_oc /100.0   !ml/g , oc is in %
          else
                  Kd = k_f_input(chem_index)
          end if
          
          call TPEZ_initial_conditions(chem_index)  !just populates m1 additions: erosion runoff and drift                
          call MainLoopTPEZ(chem_index, avg_maxwater, kd, avg_bd)      
          
          waterbodytext = "TPEZ"
          call tpez_output_processor(chem_index,area_tpez )
     end do
     
  end subroutine tpez
    
    !*******************************************************************************
    subroutine TPEZ_initial_conditions(chem_index)
       !THIS SUBROUTINE RETURNS VALUES FOR input masses m1_input for TPEZ 
       use constants_and_variables, ONLY:  degradateProduced1, mass_off_field, kd_sed_1, & 
                                          m1_input  !OUTPUT mass added to littoral region (kg) 
       use TPEZ_spray_initialization, ONLY:tpez_spray_additions
        implicit none      
        integer,intent(in) :: chem_index
        integer i
        
        !all mass goes to single compartment
        if (chem_index==1) then
             m1_input = mass_off_field(:,1,chem_index) +  mass_off_field(:,2,chem_index) + tpez_spray_additions   !only parent drifts
        else
             m1_input = mass_off_field(:,1,chem_index) +  mass_off_field(:,2,chem_index)                     !degradates dont drift
        end if
         
        !******* Add in any degradate mass produced by parent from subsequent parent run******
        if (chem_index >1) then                 ! 1 is the parent.
            m1_input = m1_input + degradateProduced1    
        end if
        
    end subroutine TPEZ_initial_conditions
    
    
    subroutine tpez_volume_calc(depth_max,TPEZ_depth_min, area_waterbody)
        !This subroutine calculates tpez volume and washout rate
        !need to get soil properties
        
        use constants_and_variables, ONLY: num_records, evap_m, precip_m, DELT_vvwm,flowthru_the_body,&
            daily_depth,volume1,k_flow ,Daily_avg_flow_out
        use utilities_1 
        
       !MAKE THESE LOCAL FOR TPEZ 
       !  use waterbody_parameters, ONLY: depth_0, depth_max,area_waterbody

        implicit none
        real, intent(in) :: depth_max,TPEZ_depth_min, area_waterbody 

        integer:: day
        real:: v_0                                  !initial water body volume [m3]
        real:: v_max                                !maximum water body volume [m3]
        real:: v_min                                !minimum water body volume [m3]
        real:: v_previous
        real:: check
        real,dimension(num_records)::vol_net
        real,dimension(num_records)::evap_area
        real,dimension(num_records)::precip_area
        
        real ::  depth_0 
        real ::  avg_property  
         
        depth_0 = depth_max

        Daily_avg_flow_out = 0.0 !initialization
        
        v_0 = area_waterbody*depth_0
        v_max = area_waterbody*depth_max
        v_min = area_waterbody*TPEZ_depth_min 
        k_flow = 0.        !sets all values of the array to zero
        v_previous = v_0

        precip_area = precip_m*area_waterbody /86400.    !m3/s
        evap_area = evap_m*area_waterbody /86400.    !m3/s, evap factor pfac now calculated in convert_weatherdata_for_VVWM  

        vol_net = (flowthru_the_body-evap_area+precip_area)*DELT_vvwm  !volume of water added in day; whole array operations
        
        do day = 1,num_records
            check = v_previous + vol_net(day)
            if (check > v_max) then
                volume1(day) = v_max
                
                !for tpez this will need to be adjusted for sorbed component: this is done later
                k_flow(day) = (check-v_max)/DELT_vvwm/v_max      !day # and washout VOLUME
                               
            else if (check < v_min) then
                volume1(day) = v_min
            else
                volume1(day) = check
            end if
               v_previous = volume1(day)             
        end do
               
        Daily_avg_flow_out = sum(k_flow)*v_max/num_records  !used for output characterization only
        daily_depth = volume1/area_waterbody                !whole array operation
  
    end subroutine tpez_volume_calc  
    
    
    !****************************************************************************
    subroutine MainLoopTPEZ(chem_index, vmax, kd, bd)
       use constants_and_variables, ONLY: num_records , DELT_vvwm,m1_input,m1_store,mavg1_store, aq1_store,  &
                                           k_flow,soil_degradation_halflife_input, burial, dwrate, ncom2, &
                                           degradateProduced1, mwt, nchem,soil_depth, xsoil

       use initialization, ONLY: Convert_halflife_to_rate_per_sec                        
       use utilities_1
       use clock_variables
       
       implicit none
       integer, intent(in) :: chem_index
       real, intent(in):: vmax, kd, bd
       
       integer :: day_count, i
       real:: m1        !begin day mass
       real:: mn1       !mass at end of time step 
       
       real :: avg_soil_deg_implicit !days, has an implicit correction that will be removed se below
       real :: avg_soil_deg          !corrected to unimlpicit and to sec
       
       real :: k_total
       real :: MWTRatio
       
       real :: dummy_holder(ncom2)
       
       degradateProduced1 = 0.
       m1=0.
       mn1=0.
       
       !call Convert_halflife_to_rate_per_sec(soil_degradation_halflife_input(chem_index), k_soil )

       if (nchem > chem_index) then
              MWTRatio = MWT(chem_index+1)/MWT(chem_index)
       end if             

       !***** Daily Loop Calculations ************************
       do day_count = 1,num_records  

          m1 = mn1 + m1_input(day_count)       
          m1_store(day_count)=m1
            
          !kflow needs to be adjusted for tpez, in normal vvwm solid phase is not considered in water column
          !adjustment is Vmax/(Vmax + bd Kd) this is a CONSTANT Adjustment
        
          !Adding daily temerature adjustments for soil degradation
          !because dwrate includes a impicit correction that is not applicable to TPEZ, this needs to be uncorrected
          do i = 1, ncom2  
                dummy_holder(i) = dwrate(chem_index,i)  !necessary for subroutine call, otherwise routine gets hung up.
                                               ! NOTE: probably should switch order of dwrate array, put chem index 2nd         
          end do
           
          call find_average_property(ncom2,soil_depth,15.0, dummy_holder, avg_soil_deg_implicit)
          
          !here is the derivation to undo the correction
          ! aq_rate_corrected      = exp(aq_rate_input)   -1.  (this is previous correction)
          ! aq_rate_corrected +1.  = exp(aq_rate_input)
          ! exp(aq_rate_input)     = aq_rate_corrected +1.
          ! aq_rate_input          = log(aq_rate_corrected +1.)   (this undoes it)
          
          avg_soil_deg = log(avg_soil_deg_implicit + 1.0)/86400.   ! removed implicit correction and now is in per sec,  86400 sec/day
          
          k_total =  k_flow(day_count)*vmax/(vmax+kd*bd) + burial(day_count)*Kd/(vmax+kd*bd) + avg_soil_deg
          
          mn1 = m1*exp(-DELT_vvwm * k_total) !next start day mass
                   
          if (k_total>0.0) then
                 mavg1_store(day_count) = m1_store(day_count)*(1.-exp(-DELT_vvwm * k_total)) /k_total/DELT_vvwm 
          else
                 mavg1_store(day_count) = m1_store(day_count)
          end if

          !calculate mass degraded by soil degradation alone  
          if (nchem > chem_index) then
             degradateProduced1(day_count) =  xsoil(chem_index) * MWTRatio * avg_soil_deg * mavg1_store(day_count) * DELT_vvwm            
          end if
          
       end do


       if (nchem > chem_index) then
           !!Degradate production is delayed one time step, this means production is assumed at end of time step 
 
           degradateProduced1(2:num_records)= degradateProduced1(1:num_records-1)
           degradateProduced1(1)= 0.                       !no degradate in calc on first day---sent to next day 
       end if

    end subroutine MainLoopTPEZ
    
    !*************************************************************************************************
    subroutine tpez_output_processor(chem_index, area_tpez)
    use utilities

    use waterbody_parameters, ONLY: SimTypeFlag, zero_depth, is_zero_depth, Afield
    use utilities_1, ONLY: pick_max, find_first_annual_dates
    use constants_and_variables, ONLY:  num_records, run_id, num_years, startday,  waterbodytext, &
                                 gamma_1,        &
                                 gamma_2,        &
                                 fw1,            &
                                 fw2,            &
                                 aq1_store,      &   !beginning day after app concentration in water column
                                 aq2_store,      &
                                 aqconc_avg1,    &   !average daily concentration (after app)
                                 aqconc_avg2,    &
                                 daily_depth,    &
	                             is_waterbody_info_output, full_run_identification, applied_mass_sum_gram_per_cm2, mavg1_store, edge_of_field
                         
         implicit none
         integer, intent(in) :: chem_index
         real, intent(in)    :: area_tpez          
         character(len=512) :: waterbody_outputfile
           
         !temporary parameters for esa, should make this more general in the future
         real:: return_frequency
      
         real,dimension(num_years):: tpez_max               !peak year to year daily average
         real,dimension(num_years):: edge_of_field_max
        
         integer :: i    
         integer,dimension(num_years) ::  first_annual_dates !array of yearly first dates (absolute days).
                                    ! First date is the calendar day of start of simulation 
         first_annual_dates= 0
    
        if (is_waterbody_info_output) then
        	select case (chem_index)
        	    case (1)
        		    waterbody_outputfile = trim(full_run_identification) // '_parent_tpez.out'
        	    case (2)
        		    waterbody_outputfile = trim(full_run_identification) // '_daughter_tpez.out'
        	    case (3)
        		    waterbody_outputfile = trim(full_run_identification) // '_granddaughter_tpez.out'		
        	    case default
        		    waterbody_outputfile =trim(full_run_identification) // '_nada_tpez.out'	
        	end select
        	
        	open (UNIT=19,FILE= trim(waterbody_outputfile),  STATUS='unknown')
        
            
            write(19, *) "Mass/Area (kg/m2)"
            do i =1, num_records
                write(19,'(ES12.4E3)')  mavg1_store(i)/area_tpez
        	end do
        	close (19)
        end if

        call find_first_annual_dates (num_years, first_annual_dates )
        call pick_max(num_years,num_records, first_annual_dates,mavg1_store,tpez_max)             !NEW FIND DAILY AVERAGE CONCENTRATION RETURN  
        call pick_max(num_years,num_records, first_annual_dates,edge_of_field ,edge_of_field_max) !NEW FIND DAILY AVERAGE CONCENTRATION RETURN   
     
        return_frequency = 10.0
        call tpez_write_simple_batch_data(chem_index, return_frequency,num_years, tpez_max, edge_of_field_max)      

    end subroutine tpez_output_processor
    

    subroutine  tpez_write_simple_batch_data(chem_index, return_frequency,num_years, tpez_max, edge_of_field_max)

use constants_and_variables, ONLY: run_id,fw2 ,&
    nchem, runoff_fraction,erosion_fraction,drift_fraction , &
    First_time_through_tpez,summary_outputfile_tpez,summary_outputfile_tpez_deg1,summary_outputfile_tpez_deg2,&
    summary_output_unit_tpez,summary_output_unit_tpez_deg1,summary_output_unit_tpez_deg2, &   
    effective_washout, effective_watercol_metab, effective_hydrolysis, effective_photolysis, effective_volatization, effective_total_deg1,&
    effective_burial, effective_benthic_metab, effective_benthic_hydrolysis, effective_total_deg2,  &
     fraction_off_field, family_name, hold_for_medians_TPEZ, app_window_counter,hold_for_medians_TPEZ_daughter,hold_for_medians_TPEZ_grandaughter

use utilities_1, ONLY: Return_Frequency_Value

    implicit none   
    integer, intent(in)                     :: num_years
    real, intent(in)                        :: return_frequency
    real, intent(in), dimension(num_years)  :: tpez_max, edge_of_field_max
    integer, intent(in)                     :: chem_index
    
    character (len=400) :: header
        
    !****LOCAL*********************
    real      ::  tpez_max_out 
    real      ::  edge_of_field_max_out
    
    logical   :: lowyearflag
    character(len= 257) :: local_run_id
    
    If (First_time_through_tpez) then
        header = 'Run Information                                                                  ,  TPEZ (kg/ha)' !,   EoF (ug/L) parent calc only'

        Open(     unit=summary_output_unit_tpez,  FILE= (trim(family_name) // "_" // trim(summary_outputfile_tpez)),Status='unknown')  
        Write(summary_output_unit_tpez, '(A400)') header
        
        if ( NCHEM>1) then
            Open( unit=summary_output_unit_tpez_deg1,   FILE= (trim(family_name) // "_" // trim(summary_outputfile_tpez_deg1)),Status='unknown')  
            Write(summary_output_unit_tpez_deg1, '(A322)') header
        end if
        if ( NCHEM >2) then
           Open(unit=summary_output_unit_tpez_deg2,FILE= (trim(family_name) // "_" // trim(summary_outputfile_tpez_deg2)),Status='unknown')  
            Write(summary_output_unit_tpez_deg2, '(A322)') header
        end if
        
        First_time_through_tpez= .FALSE.
    end if


    !**find values corresponding to  percentiles
    call Return_Frequency_Value(return_frequency, tpez_max,          num_years, tpez_max_out,          lowyearflag)   
    call Return_Frequency_Value(return_frequency, edge_of_field_max, num_years, edge_of_field_max_out, lowyearflag)   


    select case (chem_index)
    case (1)
        local_run_id = trim(run_id)//"_TPEZ"  // '_Parent'
        write(summary_output_unit_tpez,     '(A80,1x,2(",",ES13.4E3))') (adjustl(local_run_id)), tpez_max_out  !, edge_of_field_max_out*1000000.0  !convert to ug/L  from kg/m3
        hold_for_medians_TPEZ(app_window_counter,1) = tpez_max_out
    
    
    case (2)
        local_run_id = trim(run_id)//"_TPEZ"  // '_deg1'
        write(summary_output_unit_tpez_deg1,'(A80,1x,1(",",ES13.4E3))') (adjustl(local_run_id)), tpez_max_out
        hold_for_medians_TPEZ_daughter(app_window_counter,1) = tpez_max_out
        
        
    case (3)
        local_run_id = trim(run_id)//"_TPEZ"   // '_deg2'
        write(summary_output_unit_tpez_deg2,'(A80,1x,1(",",ES13.4E3))') (adjustl(local_run_id)), tpez_max_out
        hold_for_medians_TPEZ_grandaughter(app_window_counter,1) = tpez_max_out
        case default
    end select

     
end subroutine tpez_write_simple_batch_data
    
!***************************************************************************
 
end module TPEZ_WPEZ