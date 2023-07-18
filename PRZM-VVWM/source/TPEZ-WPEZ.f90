Module TPEZ_WPEZ
    implicit none
    contains
    subroutine wpez
!THIS IS THE SAME ROUTINE AS VVWM BUT WITH SOME HARD CODED VALUES FOR INPUTS


    use constants_and_variables, ONLY: nchem, wpez_timeseries_unit,  summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
        is_koc, k_f_input, water_column_ref_temp, benthic_ref_temp, &
        water_column_rate,is_hed_files_made, DELT_vvwm,is_add_return_frequency, additional_return_frequency, &
        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily,&
        outputfile_parent_deem,outputfile_deg1_deem,outputfile_deg2_deem,&
        outputfile_parent_calendex,outputfile_deg1_calendex,outputfile_deg2_calendex,&
        outputfile_parent_esa,outputfile_deg1_esa,outputfile_deg2_esa,waterbodytext , k_flow , &
        summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2,First_time_through_wpez
    
    
    
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

 
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
 !RESET PARAMETERS for wpez      
  simtypeflag   = 1
  depth_0       = 0.15      
  depth_max     = 0.15       
  baseflow      = 0.0      
  is_zero_depth = .TRUE. 
  zero_depth    = 0.01  
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
   

   write(*,*) 'wpez batch output file ', trim(summary_WPEZoutputfile)
   

   
        if (nchem > chem_index) then     
              call DegradateProduction(chem_index) 
        end if



       call output_processor(chem_index,First_time_through_wpez, wpez_timeseries_unit, summary_wpez_unit,summary_wpez_unit_deg1,summary_wpez_unit_deg2, &
                             summary_WPEZoutputfile , summary_WPEZoutputfile_deg1 , summary_WPEZoutputfile_deg2)
       
       
       
    !**********************************************************
    end do


    
    
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
 !AT END OF RUN RESET THESE PARAMETERS TO VVWM STANDARDS
    
  simtypeflag   = 2
  depth_0       = 2.0     
  depth_max     = 2.0       
  baseflow      = 0.0      
  is_zero_depth = .FALSE. 
  zero_depth    = 0.00  
 !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    

end subroutine wpez
    

!****************************************************************************
  subroutine tpez(scheme_number)
      use constants_and_variables, ONLY: nchem, is_koc, k_f_input, &
          DELT_vvwm, k_flow,waterbodytext,soil_depth, &
          num_applications_input,application_rate_in, first_year ,lag_app_in , last_year, repeat_app_in, drift_kg_per_m2, drift_schemes,&
          theta_fc,theta_wp, ncom2,  orgcarb,bulkdensity , mavg1_store
      use waterbody_parameters, ONLY: simtypeflag
      
      use degradation
      use MassInputs
      use outputprocessing
      use utilities_1
    
      implicit none   
      integer,intent(in) ::scheme_number
     
      !**local chemical properties****
      integer :: chem_index
      real    :: koc
      real    :: drift_value_local
      integer :: i,j
      integer :: app_counter
      real    :: avg_maxwater ,avg_minwater, avg_oc, avg_bd
      real kd
      
      !******Set TPEZ Specific parameters 
      real, parameter :: area_tpez = 10000.!m2
      
      write(*,*) "Enter TPEZ"
     
      drift_kg_per_m2= 0.0

      app_counter= 0
      do i=1, num_applications_input
          do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)
   
             app_counter = app_counter+1       

             select case (drift_schemes(scheme_number,i))  !this is the row number in the drift table which specifiess the spray method
             case (1)                         !"Aerial (VF-F)"
                 drift_value_local = 0.3194
             case (2)                         !"Aerial (F-M) D"
                 drift_value_local = 0.1948
             case (3)                         !"Aerial (M-C)"
                 drift_value_local = 0.148
             case (4)                         !"Aerial (C-VC)"
                 drift_value_local = 0.1196
             case (5)                         !"Ground (High, VF-F) D"
                 drift_value_local = 0.1123
             case (6)                         !"Ground (High, F-MC)"
                 drift_value_local = 0.0293
             case (7)                         !"Ground (Low, VF-F)"
                 drift_value_local = 0.0495
             case (8)                         !"Ground (Low, F-MC)"
                 drift_value_local = 0.0195
             case (9)                         !"Airblast (normal)"
                 drift_value_local = 0.0019 
             case (10)                        !"Airblast (dense)"
                 drift_value_local = 0.0265
             case (11)                        !"Airblast (sparse) D"
                 drift_value_local = 0.0831
             case (12)                        !"Airblast (vinyard)"
                 drift_value_local = 0.0047
             case (13)                        !"Airblast (orchard)"
                 drift_value_local = 0.0417
             case (14)                        !"Directly applied to waterbody"
                 drift_value_local = 1.0
             case (15)                        !"None"
                 drift_value_local = 0.0
             case (16)                        !"advanced user"  
                 drift_value_local = 0.0
             case default
                 drift_value_local = 0.0
             end select
        
             drift_kg_per_m2(app_counter) = drift_value_local * application_rate_in(i)/10000.
          end do
      end do
    
     call spraydrift
   
     call find_average_property(ncom2,soil_depth,15.0, theta_fc    , avg_maxwater)    
     call find_average_property(ncom2,soil_depth,15.0, theta_wp    , avg_minwater)
     call find_average_property(ncom2,soil_depth,15.0, bulkdensity , avg_bd)  
     call find_average_property(ncom2,soil_depth,15.0, orgcarb     , avg_oc) 
    
     write(*,*)"For TPEZ, avg_maxwater, avg_minwater,avg_bd, avg_oc as follows:"
     write(*,*) avg_maxwater,  avg_minwater, avg_bd, avg_oc 
  
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


          call tpez_output_processor(chem_index)
     end do
     

  end subroutine tpez
    
    !*******************************************************************************
    subroutine TPEZ_initial_conditions(chem_index)
       !THIS SUBROUTINE RETURNS VALUES FOR input masses m1_input for TPEZ 
       use constants_and_variables, ONLY: eroded_solids_mass, degradateProduced1, mass_off_field, spray_additions, capacity_1, kd_sed_1, & 
                                          m1_input  !OUTPUT mass added to littoral region (kg)                                                       
        implicit none      
        integer,intent(in) :: chem_index
        
        m1_input = mass_off_field(:,1,chem_index) +  mass_off_field(:,2,chem_index) + spray_additions  !all mass goes to single compartment 

        !******* Add in any degradate mass produced by parent from subsequent parent run******
        if (chem_index >1) then                 ! 1 is the parent.
          m1_input = m1_input + degradateProduced1   
        end if
        
    end subroutine TPEZ_initial_conditions
    
    
    !***************************************************************************************
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
                                           k_flow,soil_degradation_halflife_input, burial, dwrate, aq_rate_corrected, ncom2, &
           degradateProduced1, mwt, nchem,soil_depth

       use initialization, ONLY: Convert_halflife_to_rate_per_sec                        
       use utilities_1
       
       implicit none
       integer, intent(in) :: chem_index
       real, intent(in):: vmax, kd, bd
       
       integer :: day_count
       real:: m1        !begin day mass
       real:: mn1       !mass at end of time step 
       
       real :: avg_soil_deg_implicit !days, has an implicit correction that will be removed se below
       real :: avg_soil_deg          !corrected to unimlpicit and to sec
       
       real :: k_total
       real :: MWTRatio
       
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
       
          !kflow needs to be adjusted for tpez, in normal vvwm solid phase is not considered in water vcolumn
          !adjustment is Vmax/(Vmax + bd Kd) this is a CONSTANT Adjustmen
        
          !Adding daily temerature adjustments for soil degradation
          !because dwrate includes a impicit correction that is not applicable to TPEZ, this needs to be uncorrected
          call find_average_property(ncom2,soil_depth,15.0, dwrate(chem_index,:), avg_soil_deg_implicit) 
          
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
             degradateProduced1(day_count) =  MWTRatio * avg_soil_deg * mavg1_store(day_count) * DELT_vvwm
          end if
       end do
       
       if (nchem > chem_index) then
           !!Degradate production is delayed one time step, this means production is assumed at end of time step 
 
           degradateProduced1(2:num_records)= degradateProduced1(1:num_records-1)
           degradateProduced1(1)= 0.                       !no degradate in calc on first day---sent to next day 
       end if
      
    end subroutine MainLoopTPEZ
    

    
end module TPEZ_WPEZ
    