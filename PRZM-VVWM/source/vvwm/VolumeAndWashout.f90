module volumeAndwashout

contains

   !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    subroutine constant_volume_calc
        !This subroutine calculates volume and washout rate
        use utilities

        use constants_and_variables, ONLY: num_records, flowthru_the_body,k_flow,daily_depth,      &  !output array of daily wash out rates (per second)
                                     volume1,     &  !for this case, v=constant, but keep array to be consistent with program
                                     Daily_avg_flow_out
        
        use waterbody_parameters, ONLY: area_waterbody,depth_0,flow_averaging
        
        implicit none
        real,dimension(num_records):: q_avg        !Adjustable-day flow average
        real:: v_0                                 ! water body volume
                
        Daily_avg_flow_out = 0.0
               
        v_0 = area_waterbody*depth_0

        if (flow_averaging ==0) then
              q_avg = sum(flowthru_the_body)/num_records 
        else
             call window_average(flowthru_the_body,flow_averaging,num_records,q_avg) !calculate 30-day previous average  
        endif 

        k_flow = q_avg/v_0   !array of washout rates
        volume1= v_0
        daily_depth = depth_0    
        Daily_avg_flow_out = sum(q_avg)/num_records    !used for output characterization only
        
    end subroutine constant_volume_calc
    !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    subroutine volume_calc
        !This subroutine calculates volume and washout rate
        
        use constants_and_variables, ONLY: num_records, evap_m, precip_m, DELT_vvwm,minimum_depth,flowthru_the_body,&
            daily_depth,volume1,k_flow ,Daily_avg_flow_out
        
        
        use waterbody_parameters, ONLY: depth_0, depth_max,area_waterbody

        implicit none
        integer:: day
        real:: v_0                                  !initial water body volume [m3]
        real:: v_max                                !maximum water body volume [m3]
        real:: v_min                                !minimum water body volume [m3]
        real:: v_previous
        real:: check
        real,dimension(num_records)::vol_net
        real,dimension(num_records)::evap_area
        real,dimension(num_records)::precip_area
        Daily_avg_flow_out = 0.0
        write(*,*) "DOING VOLUME CALCULATION"
        
        v_0 = area_waterbody*depth_0
        v_max = area_waterbody*depth_max
        v_min = area_waterbody*minimum_depth
        k_flow = 0.        !sets all values of the array to zero
        v_previous = v_0

        precip_area = precip_m*area_waterbody /86400.    !m3/s
        evap_area = evap_m*area_waterbody /86400.    !m3/s, evap factor pfac now calculated in convert_weatherdata_for_VVWM  

        vol_net = (flowthru_the_body-evap_area+precip_area)*DELT_vvwm  !volume of water added in day; whole array operations
        
        do day = 1,num_records
            check = v_previous + vol_net(day)
            if (check > v_max) then
                volume1(day) = v_max
                k_flow(day) = (check-v_max)/DELT_vvwm/v_max   !day # and washout VOLUME
            else if (check < v_min) then
                volume1(day) = v_min
            else
                volume1(day) = check
            end if
            v_previous = volume1(day)
        end do
               
        Daily_avg_flow_out = sum(k_flow)*v_max/num_records  !used for output characterization only
        daily_depth = volume1/area_waterbody !whole array operation

    end subroutine volume_calc
    !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%

    !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    subroutine burial_calc(koc)
	!this is not really burial,mut a mass sediment mass balance onthe benthic zone

     use waterbody_parameters, ONLY: froc2
     use constants_and_variables, ONLY:   burial,capacity_2, & 
                                          k_burial                !output(kg/sec)
                              
        implicit none
        real,intent(in) :: koc
        real :: kd_sed_2  

        kd_sed_2 = KOC*FROC2*.001       !Kd of sediment  [m3/kg]
        k_burial=  burial* kd_sed_2/capacity_2

    end subroutine burial_calc
    !%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%


    subroutine tpez_volume_calc(depth_max,TPEZ_depth_min , area_waterbody)
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
        
        write(*,*) "DOING VOLUME CALCULATION for TPEZ "
        
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
        daily_depth = volume1/area_waterbody !whole array operation
  
    end subroutine tpez_volume_calc
    
    

end module volumeAndwashout