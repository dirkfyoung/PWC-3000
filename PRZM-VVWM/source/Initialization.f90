module initialization
implicit none
    contains

subroutine chemical_manipulations
use constants_and_Variables, ONLY: MolarConvert_aq12_input, MolarConvert_s12_input,MolarConvert_aq23_input,MolarConvert_s23_input, xsoil


!SET Soil molar coinversions to the same value for all horizons, for both aqueous and sorbed degradation
MolarConvert_aq12_input = xsoil(1)
MolarConvert_s12_input  = xsoil(1)

!MolarConvert_aq13_input(i) = not defined in this version
!MolarConvert_s13_input(i) = not defined 

MolarConvert_aq23_input = xsoil(2)
MolarConvert_s23_input  = xsoil(2)


end subroutine chemical_manipulations
    
    
    
    

!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!     
  SUBROUTINE INITL
  use utilities_1
  use allocations
  use constants_and_Variables, ONLY: min_evap_depth,                             &
        SoilWater,fieldcap_water, wiltpoint_water,delx,                        &
        theta_zero,                                                            &
        bd_input,              bulkdensity,                                    &
        N_f_2_input,           N_freundlich_2,                                 &
        k_f_2_input,           k_freundlich_2,                                 & 
        k_f_input,             k_freundlich,                                   &
        N_f_input,             N_freundlich,                                   &
        fc_input,              theta_fc,                                       &
        wp_input,              theta_wp,                                       &
        soil_temp_input,       soil_temp,                                      &
        theta_sat, juslec,NUSLEC,CN_moisture_ref,RNCMPT,ncom2,                           &
        old_Henry,new_henry, Henry_unitless,orgcarb, oc_input, NCHEM,NHORIZ,thickness, &
        OUTPUJ,OUTPJJ,Num_delx,startday, soil_depth,                                                       &
        theta_end,CN_index,cfac,USLEC,                           &
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
        is_koc, AFIELD_ha,  ENPY, Heat_of_Henry, &
        water_column_rate,benthic_rate, photo_halflife_input, photo_rate, &
        hydrolysis_rate, hydrolysis_halflife_input,water_column_halflife_input   ,  benthic_halflife_input , soil_degradation_halflife_input, &
        is_total_degradation,is_constant_profile, is_ramp_profile, ramp1, ramp2, ramp3,is_exp_profile , exp_profile1, exp_profile2, folpst, &
	    top_node_last_horizon, bottom_node_last_horizon, snow, cint, foliar_degrade_loss, SUPFLX, Foliar_volatile_loss, &
        is_auto_profile, profile_thick, profile_number_increments, number_of_discrete_layers, &
        aq_rate_corrected,sorb_rate_corrected, gas_rate_corrected,scenario_id,is_hydrolysis_override



  use waterbody_parameters, ONLY: afield
     
    implicit none
    INTEGER         :: i,j,k,m   
    real            :: delx_avg_depth
    integer         :: startday_doy !  startday day of year  number of days past Jan 1, used for erosion
    integer         :: day_difference, smallest_difference
    real, parameter :: tol = 0.01  !some kind of tolerance for compartment size, Needs checking
    integer         :: start, xend
    real            :: running_depth, previous_depth,slope_ramp, value1, value2, value_integrated
   
	
	real :: target_depth(nhoriz)  ! depth of horizons for use with custom discretizartion
	real :: lowerdepth            ! for tracking lower depth of a compartment strandling multipe data horizons
	integer :: count_straddled	  ! counter for the number of straddled horizons
	integer :: horiz_indx_tracker(50)
	real :: track_thickness(50)
	
    real :: hydrolyisis_rate_corrected(3)  !soil hydrolysis corrected for implicit function and corrected for per second to per day prent daughter granddaughter
    
	real :: sumofdp
	real :: sumofbd
	real :: sumofmx
	real :: sumofmn
	real :: sumofoc
	real :: sumofsn
	real :: sumofcl

    real :: sumoftheta_zero 
    real :: sumofdispersion         
    real :: sumofsoil_temp  
    real :: sumofMolarConvert_aq12
    real :: sumofMolarConvert_aq13
    real :: sumofMolarConvert_aq23
    real :: sumofMolarConvert_s12 
    real :: sumofMolarConvert_s13 
    real :: sumofMolarConvert_s23 
        
    !moving these to Constants and Variables because they are needed for TPEZ adjustments
    !real :: aq_rate_corrected(3)  !degradation inputs corrected for implicit routine
    !real :: sorb_rate_corrected(3)
    !real :: gas_rate_corrected(3) 

	horiz_indx_tracker=0
	track_thickness = 0.0

	!please move these to chem manipulations, no need to repeat them
    
    call Convert_halflife_to_rate_per_sec(water_column_halflife_input(1), water_column_rate(1)) 
    call Convert_halflife_to_rate_per_sec(water_column_halflife_input(2), water_column_rate(2))
    call Convert_halflife_to_rate_per_sec(water_column_halflife_input(3), water_column_rate(3)) 
    call Convert_halflife_to_rate_per_sec(benthic_halflife_input(1), benthic_rate(1)) 
    call Convert_halflife_to_rate_per_sec(benthic_halflife_input(2), benthic_rate(2))
    call Convert_halflife_to_rate_per_sec(benthic_halflife_input(3), benthic_rate(3))  
    call Convert_halflife_to_rate_per_sec(photo_halflife_input(1), photo_rate(1)) 
    call Convert_halflife_to_rate_per_sec(photo_halflife_input(2), photo_rate(2))
    call Convert_halflife_to_rate_per_sec(photo_halflife_input(3), photo_rate(3))  
    call Convert_halflife_to_rate_per_sec(hydrolysis_halflife_input(1), hydrolysis_rate(1)) 
    call Convert_halflife_to_rate_per_sec(hydrolysis_halflife_input(2), hydrolysis_rate(2))
    call Convert_halflife_to_rate_per_sec(hydrolysis_halflife_input(3), hydrolysis_rate(3))
    call Convert_halflife_to_rate_per_day(soil_degradation_halflife_input(1), aq_rate_input(1)) 
    call Convert_halflife_to_rate_per_day(soil_degradation_halflife_input(2), aq_rate_input(2))
    call Convert_halflife_to_rate_per_day(soil_degradation_halflife_input(3), aq_rate_input(3))

	snow = 0.0
	cint = 0.0
	
	folpst = 0.0
	foliar_degrade_loss = 0.0
	SUPFLX = 0.0
	Foliar_volatile_loss = 0.0
	
    if (is_total_degradation) then
        sorb_rate_input = aq_rate_input
        gas_rate_input= 0.0
    else               !Aqueous phase only
        sorb_rate_input = 0.0
        gas_rate_input= 0.0
    end if
    
    !For sub delt calculations
    subdelt = delt/number_subdelt
    
    AFIELD_ha = AFIELD/10000.
    
    ! convert enthalpy from Joules to Kcal for PRZM  4184 J/kcal   parent, daughter, granddaughter
    ENPY = Heat_of_Henry/ 4184.0   
    
    !********Allocations of Soil Profile Variables**********************

	if (is_auto_profile) then
		ncom2 = sum(profile_number_increments(1:number_of_discrete_layers))  !New way
    else     
        NCOM2 = sum(num_delx(1:nhoriz))  !Total Number of Compartments       !old way
    end if

	!***********  allocate and initialize ***********
    call  allocate_soil_compartments

	call  allocate_time_series       !some time series also have soil components, so ncom2 must be defined previoyusly before this call

    
    ainf = 0.0
    GAMMA1  = 0.0
    vel = 0.0
    !************************************************
    
    if (is_auto_profile) then  ! create the discretization based on input profile instead of delx     

	        !get thicknesses for each compartment
			start = 1
		    xend = 0
	        do i = 1, number_of_discrete_layers
	        	xend = xend + profile_number_increments(i)
	        	do j = start, xend
	        		delx(j)  = profile_thick(i)/ real(profile_number_increments(i))
	        	end do
                start =xend +1
            end do
	
            !*** Populate Soil Depth Vector *********
            soil_depth = 0.0
            soil_depth(1) = delx(1)
    
            do i=2, NCOM2
               soil_depth(i) = soil_depth(i-1) + delx(i) 
	        end do

	        !Find depths of input horizons these are "target depths" where changes occur
	        target_depth(1) = thickness(1)
	        do i=2, nhoriz
	           target_depth(i) =target_depth(i-1) + thickness(i) 
	        end do

	        bulkdensity   = 0.0
            orgcarb       = 0.0
            theta_fc      = 0.0
            theta_wp      = 0.0
            theta_zero    = 0.0
            dispersion 	  = 0.0
            soil_temp     = 0.0
	   
	        j = 1  ! tracker for data horizons
	        do i = 1, ncom2   !check each fixed compartment depth against the horizon depth to determine its location

	             if (soil_depth(i) <= target_depth(j)) then 
                     
	                 bulkdensity(i)       = bd_input  (j)
                     orgcarb    (i)       = oc_input  (j)                                          
                     theta_fc   (i)       = fc_input  (j)
                     theta_wp   (i)       = wp_input  (j)    
                     theta_zero (i)       = fc_input  (j)  !Set the iniitial Water content to field capacity 
                     dispersion (i)		  = dispersion_input(j)	            
                     soil_temp  (i)       = soil_temp_input (j)
	                 		
                     MolarConvert_aq12(i) = MolarConvert_aq12_input(j)
                     MolarConvert_aq13(i) = MolarConvert_aq13_input(j)
                     MolarConvert_aq23(i) = MolarConvert_aq23_input(j)
                     MolarConvert_s12 (i) = MolarConvert_s12_input(j)
                     MolarConvert_s13 (i) = MolarConvert_s13_input(j)
                     MolarConvert_s23 (i) = MolarConvert_s23_input(j)	   
                 else !compartment depth is greater than horizon
                                      
                     
				     lowerdepth = soil_depth(i-1)  !capture the lower depth of the compartment that straddles
				  
			         if ( lowerdepth >= target_depth(nhoriz)) then  !we've run out of horizons, so every thing is the last horizon
			             bulkdensity(i) = bd_input  (nhoriz)
                         theta_fc   (i) = fc_input  (nhoriz)
                         theta_wp   (i) = wp_input  (nhoriz)
                         orgcarb    (i) = 0.0   ! oc_input %  (nhoriz)
                         theta_zero (i) = fc_input(nhoriz)
                         dispersion (i)	= dispersion_input(nhoriz)           
                         soil_temp  (i) = soil_temp_input (nhoriz)
                         
                         MolarConvert_aq12(i) = MolarConvert_aq12_input(nhoriz)
                         MolarConvert_aq13(i) = MolarConvert_aq13_input(nhoriz)
                         MolarConvert_aq23(i) = MolarConvert_aq23_input(nhoriz)
                         MolarConvert_s12 (i)  = MolarConvert_s12_input(nhoriz)
                         MolarConvert_s13 (i)  = MolarConvert_s13_input(nhoriz)
                         MolarConvert_s23 (i)  = MolarConvert_s23_input(nhoriz)	  
                           
                     else	           
                         
			        	 !find out how many data horizons this compartment straddles (typically will be 2, but keep possibilitiy open for many)
			        	 count_straddled = 0
			        	 do k= j, nhoriz
                            count_straddled = count_straddled +1
			        		horiz_indx_tracker(count_straddled) = k
			        		
			        		if (soil_depth(i) > target_depth(k)) then 
                                track_thickness(count_straddled) = target_depth(k)-lowerdepth
			        			lowerdepth = target_depth(k)
			        		else	
			        			track_thickness(count_straddled) = soil_depth(i) - target_depth(k-1)			        			
			        			j = j + count_straddled -1
			        		    exit 
			        		end if
			        	end do

			        	!Do Averaging
			        	sumofdp =  0.0
			        	sumofbd =  0.0
                        sumofmx =  0.0
                        sumofmn =  0.0
                        sumofoc =  0.0
                        sumofsn =  0.0
                        sumofcl =  0.0
                                           
                        sumoftheta_zero        = 0.0
                        sumofdispersion        = 0.0
                        sumofsoil_temp         = 0.0
                        sumofMolarConvert_aq12 = 0.0
                        sumofMolarConvert_aq13 = 0.0
                        sumofMolarConvert_aq23 = 0.0
                        sumofMolarConvert_s12  = 0.0
                        sumofMolarConvert_s13  = 0.0
                        sumofMolarConvert_s23  = 0.0

			        	do m = 1, count_straddled
			        		sumofdp = sumofdp + track_thickness(m)
			        		sumofbd = sumofbd + bd_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofmx = sumofmx + fc_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofmn = sumofmn + wp_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofoc = sumofoc + oc_input  (horiz_indx_tracker(m)) *   track_thickness(m)                            
                            sumoftheta_zero          =sumoftheta_zero          +  fc_input                 (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofdispersion          =sumofdispersion          +  dispersion_input         (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofsoil_temp           =sumofsoil_temp           +  soil_temp_input          (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_aq12   =sumofMolarConvert_aq12   +   MolarConvert_aq12_input (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_aq13   =sumofMolarConvert_aq13   +   MolarConvert_aq13_input (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_aq23   =sumofMolarConvert_aq23   +   MolarConvert_aq23_input (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_s12    =sumofMolarConvert_s12    +   MolarConvert_s12_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_s13    =sumofMolarConvert_s13    +   MolarConvert_s13_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                            sumofMolarConvert_s23    =sumofMolarConvert_s23    +   MolarConvert_s23_input  (horiz_indx_tracker(m)) *   track_thickness(m)
                                                                            
			        	end do                     
			        	    bulkdensity(i) = sumofbd /sumofdp	
                            theta_fc   (i) = sumofmx /sumofdp	
                            theta_wp   (i) = sumofmn /sumofdp	
                            orgcarb    (i) = sumofoc /sumofdp	
			        	 
                            theta_zero       (i) =sumoftheta_zero          /sumofdp
                            dispersion       (i) =sumofdispersion          /sumofdp
                            soil_temp        (i) =sumofsoil_temp           /sumofdp
                            MolarConvert_aq12(i) = sumofMolarConvert_aq12  /sumofdp
                            MolarConvert_aq13(i) = sumofMolarConvert_aq13  /sumofdp
                            MolarConvert_aq23(i) = sumofMolarConvert_aq23  /sumofdp
                            MolarConvert_s12 (i) = sumofMolarConvert_s12   /sumofdp
                            MolarConvert_s13 (i) = sumofMolarConvert_s13   /sumofdp
                            MolarConvert_s23 (i) = sumofMolarConvert_s23   /sumofdp                         
                     endif 
                 end if
            end do          

          !saturate last 2 compartments to simulate aquifer
            
            theta_fc(ncom2-1) = 1.0 - bulkdensity(ncom2-1)/2.65
            theta_fc(ncom2)   = 1.0 - bulkdensity(ncom2)/2.65
            
    else 	!No auto discretization  START OF  OLD WAY -- Possibly eliminate
	
      ! *** Populate the Delx Vector and Kf & N *******
      start = 1
      Xend  = 0
      do i=1, nhoriz
        xend = start +num_delx(i)-1      
        delx(start:xend)           = thickness(i)/num_delx(i) 
        bulkdensity(start:xend)    = bd_input(i)
        
        orgcarb(start:xend)        = oc_input(i)           
                        
        theta_fc(start:xend)       = fc_input(i)
        theta_wp(start:xend)       = wp_input(i)

        dispersion(start:xend)     = dispersion_input(i)
		
		theta_zero(start:xend)     = fc_input(i)  !Set the iniitial Water content to field capacity 
        soil_temp(start:xend)      = soil_temp_input(i)
				
        MolarConvert_aq12(start:xend)  = MolarConvert_aq12_input(i)
        MolarConvert_aq13(start:xend)  = MolarConvert_aq13_input(i)
        MolarConvert_aq23(start:xend)  = MolarConvert_aq23_input(i)
        MolarConvert_s12(start:xend)   = MolarConvert_s12_input(i)
        MolarConvert_s13(start:xend)   = MolarConvert_s13_input(i)
        MolarConvert_s23(start:xend)   = MolarConvert_s23_input(i)
        
        !do K=1, NCHEM
        !    if (is_koc) then
        !        k_freundlich(k, start:xend)   = k_f_input(k)*oc_input(i)*.01  !oc is in percent
        !        k_freundlich_2(k, start:xend) = k_f_2_input(k)*oc_input(i)*.01
        !    else
        !        k_freundlich(k, start:xend)   = k_f_input(k)
        !        k_freundlich_2(k, start:xend) = k_f_2_input(k)   
        !    end if
        !    
        !    N_freundlich(k, start:xend) = N_f_input(k)   
        !    N_freundlich_2(k, start:xend) = N_f_2_input(k)                       
        !    !KD(k, start:xend)= k_f_input(k,i)                !Used in Freundlich linearization for tridiagonal    
        !     
        !  !NEED TO COMMENT OUT THESE LINES after done below  
        !  !  dwrate_atRefTemp(k,start:xend) =     aq_rate_input(K)
        !  !  dsrate_atRefTemp(k,start:xend) =     sorb_rate_input(K)
        !  !  dgrate_atRefTemp(k,start:xend) =     gas_rate_input(K)      
        !  !  **************************************************
        !    
        !end do    
         start = xend+1
         
      end do
      
        !*** Populate Soil Depth Vector *********
        soil_depth = 0.0
        soil_depth(1) = delx(1)
        
        do i=2, NCOM2
           soil_depth(i) = soil_depth(i-1) + delx(i) 
       end do
       !&&&&&&&&&&&&&&&&&&&&&&&&&&& END OF  OLD WAY &&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&	
    end if	
    

    
    !****** Calculate Kd for each compartment ******************************
    do K=1, NCHEM
        do i = 1, ncom2
            if (is_koc) then
                k_freundlich(k, i)   = k_f_input(k)*orgcarb(i)*.01  !oc is in percent
                k_freundlich_2(k, i) = k_f_2_input(k)*orgcarb(i)*.01
            else
                k_freundlich(k,i)   = k_f_input(k)
                k_freundlich_2(k,i) = k_f_2_input(k)   
            end if
            
            N_freundlich(k, i) = N_f_input(k)   
            N_freundlich_2(k, i) = N_f_2_input(k)                         
        end do
        
    end do   	

    !WWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWWW  look
    !****************************needs repair for autoprofile

    !Find index of last 2 nodes, this will be used for groundwater calculations
	    top_node_last_horizon    = ncom2-1
		bottom_node_last_horizon = ncom2
    
    !SHOULD last 2 compaertments be saturated?  Not sure if that is in here 7/5/2023
    !*************************************************

    !Implicit routine corection for degradation: insures perfect degradation at high rates    
             aq_rate_corrected =     exp(aq_rate_input)   -1.  
             sorb_rate_corrected =   exp(sorb_rate_input) -1.
             gas_rate_corrected =    exp(gas_rate_input)  -1.
             
             hydrolyisis_rate_corrected = exp(hydrolysis_rate*86400.)-1  !hydrolysis rate is per second, parent, daughter, grand
    !******************************************************************************************
    !
	! changed---put these corrected values as substitute for input values below, 
             !done as of 12-4-2022  but check
	!
    !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! 
             
    do k = 1, nchem       
        previous_depth = 0.0
        running_depth  = 0.0
        
        if (is_ramp_profile) then            
           ! Parameters ramp1 is first plateau distance, ramp2 is second plateau distance, ramp3 is second plateau value
            slope_ramp = (ramp3-1.0)/(ramp2-ramp1)
            
            do i = 1, ncom2
                running_depth   = running_depth +delx(i)
                if (running_depth <= ramp1) then                                      !cell is totally in first plateau
                   dwrate_atRefTemp(k,i) =  aq_rate_corrected(K)
                   dsrate_atRefTemp(k,i) =  sorb_rate_corrected(K)
                   dgrate_atRefTemp(k,i) =  gas_rate_corrected(K)     
                                     
                else if (previous_depth < ramp1 .AND. running_depth > ramp1 )then     !cell staddles corner of first plateau
                   value1 = (ramp1-previous_depth)  !*1.0
                   value2 = (running_depth-ramp1)* (0.5*slope_ramp*(running_depth-ramp1) + 1.0 )                   
                   value_integrated = (value1 + value2)/ delx(i)
                   
                   dwrate_atRefTemp(k,i) =  value_integrated * aq_rate_corrected(K)
                   dsrate_atRefTemp(k,i) =  value_integrated * sorb_rate_corrected(K)
                   dgrate_atRefTemp(k,i) =  value_integrated * gas_rate_corrected(K) 
                   
                else if (previous_depth >= ramp1 .AND. running_depth <= ramp2 )then   !cell is completely on the ramp
                    value1 = slope_ramp*(previous_depth-ramp1) + 1   ! y=mx+b
                    value2 = slope_ramp*(running_depth-ramp1) + 1 
                    value_integrated = 0.5 * (value1 + value2)
                    
                    dwrate_atRefTemp(k,i) =   value_integrated * aq_rate_corrected(K)
                    dsrate_atRefTemp(k,i) =   value_integrated * sorb_rate_corrected(K)
                    dgrate_atRefTemp(k,i) =   value_integrated * gas_rate_corrected(K)  

                else if (previous_depth <  ramp2 .AND. running_depth > ramp2 )then    !cell straddles corner of second plateau                                  
                   value1 = (running_depth-ramp2)*ramp3 
                   value2 = (ramp2-previous_depth)*0.5 *((previous_depth-ramp1)* slope_ramp +1.0 + ramp3 )                  
                   value_integrated = (value1 + value2)/delx(i)
                   
                   dwrate_atRefTemp(k,i) =  value_integrated * aq_rate_corrected(K)
                   dsrate_atRefTemp(k,i) =  value_integrated * sorb_rate_corrected(K)
                   dgrate_atRefTemp(k,i) =  value_integrated * gas_rate_corrected(K) 
                                                                  
                else if (previous_depth >= ramp2 )then    !cell is completely in second plateau                       
                    dwrate_atRefTemp(k,i) =  ramp3 * aq_rate_corrected(K)
                    dsrate_atRefTemp(k,i) =  ramp3 * sorb_rate_corrected(K)
                    dgrate_atRefTemp(k,i) =  ramp3 * gas_rate_corrected(K) 
                else
                   write(*,*) "message to developer: check degradation ramp logic"  !This should not happen
                end if                
                previous_depth = running_depth
             end do      
            
        else if (is_exp_profile) then
            do i = 1, ncom2
               running_depth   = running_depth +delx(i) 
               value1 = (1-exp_profile2)/(-exp_profile1)*exp(-exp_profile1*previous_depth) + exp_profile2*previous_depth
               value2 = (1-exp_profile2)/(-exp_profile1)*exp(-exp_profile1*running_depth) + exp_profile2*running_depth
               value_integrated = (value2-value1)/delx(i)
           
               dwrate_atRefTemp(k,i) =  value_integrated * aq_rate_corrected(K)
               dsrate_atRefTemp(k,i) =  value_integrated * sorb_rate_corrected(K)
               dgrate_atRefTemp(k,i) =  value_integrated * gas_rate_corrected(K) 
               
               previous_depth = running_depth
            end do
            
 
        else  !is_constant_profile
             do i = 1, ncom2
                dwrate_atRefTemp(k,i) =  aq_rate_corrected(K)
                dsrate_atRefTemp(k,i) =  sorb_rate_corrected(K)
                dgrate_atRefTemp(k,i) =  gas_rate_corrected(K)   
                
             end do   
        end if
        
       !Hydrolysis Overide where aq rate is less than hydrolysis, use hydrolysis
       if (is_hydrolysis_override) then 
           where (dwrate_atRefTemp(k,:) < hydrolyisis_rate_corrected(k)  )
              dwrate_atRefTemp(k,:) = hydrolyisis_rate_corrected(k)
           end where
       end if
       
       
        !do i = 1, ncom2
        !    write(*,*)i, dwrate_atRefTemp(k,i), dsrate_atRefTemp(k,i)
        !end do
        
        
    end do  !chemical species loop
    
    
    

    

    !write (*,'(A)')   '    #     depth     bd       max_water     min_wat    orgcarb         kd         dwrate'
    !do i = 1, ncom2
    !   write (*,'(I5,1X, F9.2, 8G12.3)') i,soil_depth(i), bulkdensity(i),theta_fc(i), theta_wp(i), orgcarb(i),  k_freundlich(1,i),dwrate_atRefTemp(1,i)
    !end do	
    
    !As a default set the degradation rate to equal the input values
    dwrate = dwrate_atRefTemp
    dsrate = dsrate_atRefTemp
    dgrate = dgrate_atRefTemp

    theta_sat = 1.0 - bulkdensity/2.65
    if (any(theta_fc > theta_sat)) then
          WRITE(*,* ) scenario_id, 'water capacity exceeds saturation; assuming no user error'
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
        old_Henry(K,:) = Henry_unitless(K)
        new_henry(K,:) = Henry_unitless(K)
    end do

    !Setup  Crop Growth 
    Call setup_crops
    
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
  
    call SetupApplications
    call SetupFieldOutputOptions
	call calculate_retardation_factor
    
end subroutine INITL
    
!**********************************************************************


  Subroutine Convert_halflife_to_rate_per_sec(halflife, rate)
    Real, intent(in):: halflife
    real,intent(out):: rate
    !converts halflives in Days to rate in Per Sec
    !assume that an entry of zero half life means No degradation or zero rate
    

          If (halflife < tiny(halflife)) then
              rate = 0.0
          else
              rate  = (8.022536812e-6)/halflife        ! 0.693147180559/( halflife *86400)     
          end if
    end subroutine Convert_halflife_to_rate_per_sec
!**********************************************************************        
    Subroutine Convert_halflife_to_rate_per_day(halflife, rate)
        Real, intent(in):: halflife
        real, intent(out):: rate
        !converts halflives in Days to rate in Per Sec
        !assume that an entry of zero half life means No degradation or zero rate
    
          If (halflife < tiny(halflife)) then
              rate = 0.0
          else
              rate  = 0.693147180559/halflife
          endif

    end subroutine Convert_halflife_to_rate_per_day 
!**********************************************************************

subroutine SetupApplications
    !Gets a scheme application set and 
    !sets the application days in julian days referenced to 1/1/1900 and puts them in application_date array
    ! Application_date is the entire
    use utilities_1
    use constants_and_Variables, ONLY:num_applications_input,pest_app_method_in,DEPI_in,application_rate_in,APPEFF_in, &
                                    Tband_top_in,drift_value,lag_app_in,repeat_app_in, first_year, last_year,  &
                                    application_date_original,application_date, pest_app_method,DEPI,TAPP,APPEFF,Tband_top, &
                                    num_crop_periods_input, emm, emd, mam,mad, ham,had, &
                                    total_applications , drift_kg_per_m2, cam123_soil_depth, delx, &
                                     days_until_applied,app_reference_point, application_order, is_adjust_for_rain, is_absolute_year
   
    use clock_variables
          
    implicit none 
    integer :: i, j, mcrop,crop_iterations
    integer :: app_counter
    integer :: MONTH,DAY
    integer :: YEAR_out,MONTH_out,DAY_out

    ! (actual total apps may be less if simulation starts late in the of stops early) but that does not matter to the program,  also because of lag and periodicity
  
    total_applications = (last_year - first_year + 1)*num_applications_input*num_crop_periods_input

    allocate (application_date(total_applications))
    allocate (application_order(total_applications))
    allocate (application_date_original(total_applications))
    
    allocate (pest_app_method(total_applications))
    allocate (DEPI(total_applications))    
    allocate (TAPP(total_applications))             
    allocate (APPEFF(total_applications))
    allocate (Tband_top(total_applications))
    allocate (drift_kg_per_m2(total_applications))

    !initialize application date to very high (unlikely julian app date). 
    !Because allocated array may be larger than the actual number of applications (i.e. i used a simple counting scheme)
    application_date = 100000000 
    pest_app_method = 1
    DEPI = 0.0
    TAPP= 0.0
    APPEFF= 0.0
    Tband_top= 0.0
    drift_kg_per_m2 = 0.0
 
    if (app_reference_point== 0) then
        crop_iterations = 1
    else
        crop_iterations = num_crop_periods_input
    end if

    
    
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
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
         
        !The following does not put apps in chrono order, rather by app number, then chrono.
        ! this is because each app may be lagged and stepped independent of others
        !For rain fast option, will need chrono order.  
         do i=1, num_applications_input
             
            if (is_absolute_year(i)) then        
                app_counter = app_counter+1  !this allows both absolute years AND cycle years to be used
                application_date(app_counter)=   days_until_applied(i) !for absolute years the actual julian is held here  
                
                pest_app_method(app_counter) = pest_app_method_in(i)
                DEPI(app_counter) =  DEPI_in(i)
                select case(pest_app_method(app_counter))
                  case(1:2)  !these are the only default depths and set to 4 cm
                          DEPI(app_counter) = cam123_soil_depth  !default for general unspecified applications
                  case(3:10)                            
                     If (DEPI(app_counter) < delx(1)) Then
                        DEPI(app_counter) = delx(1)
                        write (*,*) 'Note: Specified depth is less than compartment size, so used minimum incorporation = ', Delx(1)
                     End If
                end select
                                
                  TAPP(app_counter) = application_rate_in(i)/1.0E5  !     TAPP... kg/ha ---> g/cm**2
                  APPEFF(app_counter) = APPEFF_in(i)
                  
                  Tband_top(app_counter) = Tband_top_in(i)    
                  
                  
                  drift_kg_per_m2(app_counter) = drift_value(i)*application_rate_in(i)/10000.    !Kg/m2 drift application to waterbody         
               !  call get_date (application_date(app_counter), YEAR_out,MONTH_out,DAY_out)
                 
    
            else
              do j = first_year +lag_app_in(i) , last_year, repeat_app_in(i)

                    app_counter = app_counter+1

 
                    application_date(app_counter)=   jd(j,month,day) + days_until_applied(i)       
                    pest_app_method(app_counter) = pest_app_method_in(i)
                    DEPI(app_counter) =  DEPI_in(i)
                    !make some Depth corrections if necessary
 
                    select case(pest_app_method(app_counter))
                      case(1:2)  !these are the only default depths and set to 4 cm
                          DEPI(app_counter) = cam123_soil_depth  !default for general unspecified applications
                      case(3:10)                            
                          If (DEPI(app_counter) < delx(1)) Then
                             DEPI(app_counter) = delx(1)
                             write (*,*) 'Note: Specified depth is less than compartment size, so used minimum incorporation = ', Delx(1)
                          End If
                      end select
   
                      
                    TAPP(app_counter) = application_rate_in(i)/1.0E5  !     TAPP... kg/ha ---> g/cm**2
                    APPEFF(app_counter) = APPEFF_in(i)
                    Tband_top(app_counter) = Tband_top_in(i)                                   
                    drift_kg_per_m2(app_counter) = drift_value(i)*application_rate_in(i)/10000.    !Kg/m2 drift application to waterbody         
                   !call get_date (application_date(app_counter), YEAR_out,MONTH_out,DAY_out)
              !    write (*,*) "cyc",YEAR_out,MONTH_out,DAY_out
                    
              end do    
            endif  !absolute years vs. yearly cycle
    
            
         end  do    
    end do
    

    
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    
    
    
    application_date_original = application_date  !keep application_date_original the same for every scheme
  
    !Put applications in chronlogical order for use with rain-fast option. its not necessary to do this for normal runs,

    !this is a time consuming operation, lets bypass unless rainfast is checked

    
    if (is_adjust_for_rain) then
        write(*,*) "Put applications in order for rain restrictions?", is_adjust_for_rain
        write(*,*) "To developer:"
        write(*,*) "For rain restrictions, the program uses a sort routine that is very slow."
        write(*,*) "Consider modifications, Or require user to input applications in chrono order"
        write(*,*) "to avoid sorting requirement"
        
        write (*,*) '###################################################'	 
        CALL CPU_TIME (time_1)
        write (*,*) 'cpu time before ordering applications (if applicable)  ',time_1- cputime_begin
        write (*,*) '###################################################'		
   
        !potentially very TIME CONSUMING!!!! 
        
        application_order = get_order(application_date)
        application_date = application_date(application_order)
        pest_app_method  = pest_app_method (application_order)
        DEPI             = DEPI            (application_order)
        TAPP             = TAPP            (application_order)
        APPEFF           = APPEFF          (application_order)
        Tband_top        = Tband_top       (application_order)
        drift_kg_per_m2  = drift_kg_per_m2 (application_order)
       
        write (*,*) '###################################################'	 
        CALL CPU_TIME (time_1)
        write (*,*) 'cpu time after ordering applications (if applicable)  ',time_1- cputime_begin
        write (*,*) '###################################################'
    end if

    !not sure about this, check it it seems to alter the original
    application_date_original = application_date  !keep application_date_original the same for every scheme
    
  end subroutine SetupApplications

!**********************************************************************  
  subroutine setup_crops
  !converts days and months to julia
  !emergence date, maturity_date, harvest_date are all since 1-1-1900
  
  use constants_and_Variables, ONLY: emd, emm, mad, mam, had, ham, num_crop_periods_input, &
       first_year, last_year,num_years, crop_lag, crop_periodicity, emergence_date, maturity_date, harvest_date
   
  use utilities_1
   implicit none

   integer :: i,j,k
   integer :: maturity_year, harvest_year !local hold for year that maturity or harvest occurs, which may differ from emergence
   
   integer ::   yr_tracker
   
 !  total_crop_periods=0
   !do i=1, num_crop_periods_input        
   !   total_crop_periods = total_crop_periods+((last_year- first_year)- crop_lag(i) + crop_periodicity(i))/crop_periodicity(i)
   !end do
   
  ! write (echofileunit, *) 'Calculated Total Actual Crop Periods =', total_crop_periods
   
   allocate (emergence_date (num_crop_periods_input, num_years)) 
   allocate (maturity_date  (num_crop_periods_input, num_years))
   allocate (harvest_date   (num_crop_periods_input, num_years)) 
   

   emergence_date =-7777 !arbitrary unlikely value to ever interfere with simulation if array has some unused spaces 
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

!#######################################################################
!  subroutine name_output_files
!    use constants_and_variables, ONLY: maxFileLength, TimeSeriesUnit, working_directory,run_id,family_name,waterbody_id, &
!        outputfile_parent_daily,outputfile_deg1_daily,outputfile_deg2_daily, &
!        outputfile_parent_analysis,outputfile_deg1_analysis,outputfile_deg2_analysis   
!    use Output_From_Field     
!    implicit none
!    character(len = maxFileLength) :: filename
!
!    filename = trim(working_directory) // trim(family_name) // "_" // trim(run_id) // ".zts"
!    OPEN(Unit=TimeSeriesUnit,FILE=trim(adjustl(filename)), STATUS='UNKNOWN') 
!    call write_outputfile_header
!    
!    WRITE(*,*) 'Read and open Time Series: ' //  trim(filename)
!    
!
!    outputfile_parent_daily = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) //  "_Parent_daily.csv"
!    outputfile_deg1_daily   = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) //  "_Degradate1_daily.csv"
!    outputfile_deg2_daily   = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) //  "_Degradate2_daily.csv"
! 
!    outputfile_parent_analysis = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) // "_Parent.txt"
!    outputfile_deg1_analysis   = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) // "_deg1.txt"
!    outputfile_deg2_analysis   = trim(working_directory) // trim(family_name) // "_" // trim(run_id) //trim(waterbody_id ) // "_deg2.txt"
!  
!    !outputfile_parent_deem    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Parent_DEEM.rdf"
!    !outputfile_deg1_deem      = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate1_DEEM.rdf"
!    !outputfile_deg2_deem      = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate2_DEEM.rdf"
!    !
!    !outputfile_parent_calendex  = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Parent_Calendex.rdf"  
!    !outputfile_deg1_calendex    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate1_Calendex.rdf"
!    !outputfile_deg2_calendex    = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) // "_Degradate2_Calendex.rdf"
!    !
!    !outputfile_parent_esa   = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Parent.txt"
!    !outputfile_deg1_esa     = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Degradate1.txt"
!    !outputfile_deg2_esa     = trim(working_directory) // trim(family_name) // "_" // trim(scenario_id) //trim(waterbody_id ) //  "_" & Trim(ReturnFrequency) & "_Degradate2.txt"
!    !
!end subroutine name_output_files

!######################################################################################  
subroutine SetupFieldOutputOptions()
use utilities_1
use constants_and_variables, ONLY:     is_runoff_output, is_erosion_output, is_runoff_chem_output, is_erosion_chem_output , &
    is_conc_bottom_output,is_daily_volatilized_output,is_daily_chem_leached_output, &
    is_chem_decayed_part_of_soil_output, decay_start, decay_end, &
    is_chem_in_part_soil_output, fieldmass_start, fieldmass_end,is_chem_on_foliage_output , is_precipitation_output , &
    is_evapotranspiration_output, is_soil_water_output, is_irrigation_output,is_chem_in_all_soil_output, &
    is_infiltration_at_depth_output,infiltration_point,is_infiltrated_bottom_output,infiltration_point,is_infiltrated_bottom_output, &
    PLNAME, chem_id, mode, arg, arg2, const, nplots, thickness, ncom2,soil_depth,nhoriz,leachdepth, &
    extra_plots, temp_PLNAME,  temp_chem_id, temp_MODE,temp_ARG,temp_ARG2,temp_CONST, nchem
    
    
    implicit none
    integer :: i, j
    real :: depth1 !local variables used to determine reklevant depths for output in last horizon, and possibly elsewher
    real :: depth2 
    integer :: num_std_plots  !counter for the number of standard plots that were requested 
                              !("extra plots" as in the variables module are those that the user specified with the traditional przm nomenclature)

    i=0
    if (is_runoff_output) then
        i=i+1
         PLNAME(i) = 'RUNF'
         chem_id(I) = 1
         MODE(i) = 'TSER'
         ARG(i) = 0
         ARG2(i) = 0
         CONST(i) = 1.0
    end if

    if (is_erosion_output) then
        i=i+1
         PLNAME(i) = 'ESLS'
         chem_id(I) = 1
         MODE(i) = 'TSER'
         ARG(i) = 0
         ARG2(i) = 0
         CONST(i) = 1.0
	end if


    if (is_precipitation_output) then
        i=i+1
         PLNAME(i) = 'PRCP'
         chem_id(i) = 1
         MODE(i) = 'TSER'   
         ARG(i) = 1
         ARG2(i) = 2
         CONST(i) = 1.
    end if
    
    if (is_evapotranspiration_output) then
        i=i+1
         PLNAME(i) = 'TETD'
         chem_id(i) = 1
         MODE(i) = 'TSER'   
         ARG(i) = 1
         ARG2(i) = 2
         CONST(i) = 1.
	end if
	
    if (is_soil_water_output) then
        i=i+1
         PLNAME(i) = 'SWTR'
         chem_id(i) = 1
         MODE(i) = 'TSUM'   
         
         ARG(i) = 1
		 
		 depth2 = sum(thickness)
    
         ARG2(i) = find_depth_node(ncom2,soil_depth,depth2)
         CONST(i) = 1.

	end if

	
    if (is_irrigation_output) then
        i=i+1
         PLNAME(i) = 'IRRG'
         chem_id(i) = 1
         MODE(i) = 'TSER'      
         ARG(i) = 1
         ARG2(i) = 2
         CONST(i) = 1.
    end if

    if (is_infiltration_at_depth_output) then
        i=i+1
         PLNAME(i) = 'INFL'
         chem_id(i) = 1
         MODE(i) = 'TSER'  
         
         ARG(i)  = find_depth_node(ncom2,soil_depth,infiltration_point)
         ARG2(i) = 0
         CONST(i) = 1.
    end if

    if (is_infiltrated_bottom_output) then
        i=i+1
         PLNAME(i) = 'INFL'
         chem_id(i) = 1
         MODE(i) = 'TSER'   
         depth2 = sum(thickness)

         ARG(i) = find_depth_node(ncom2,soil_depth,depth2)
         ARG2(i) = 2
         CONST(i) = 1.
	end if
	


   !Below are the chemical outputs, need to get parent and degradates
	do j=1, nchem
           if (is_runoff_chem_output) then
               i=i+1
                PLNAME(i) = 'RFLX'
                chem_id(I) = j
                MODE(i) = 'TSER'
                ARG(i) = 0
                ARG2(i) = 0
                CONST(i) = 100000.  !kg/ha
           end if
    
           if (is_erosion_chem_output) then
               i=i+1
                PLNAME(i) = 'EFLX'
                chem_id(I) = j
                MODE(i) = 'TSER'
                ARG(i) = 0
                ARG2(i) = 0
                CONST(i) = 100000.
           end if
           
           if (is_conc_bottom_output) then
               i=i+1
                PLNAME(i) = 'DCON'
                chem_id(I) = j
                MODE(i) = 'TAVE'
                 
                depth1 = sum(thickness(1:(nhoriz-1)) )     !top of last horizon
                depth2 = sum(thickness)                   !Bottom of last horizon   
                
                ARG(i)  = find_depth_node(ncom2,soil_depth,depth1) 
                If (Arg(i) > 1) then    !Forthe unusual case where the last node is the first node
                    ARG(i)  = ARG(i) +1 !need to add node because depth is countedat bottom of node
                end if
   
                ARG2(i) = find_depth_node(ncom2,soil_depth,depth2)
                CONST(i) = 1000.     
           end if
           
           if (is_daily_volatilized_output) then
               i=i+1
                PLNAME(i) = 'VFLX'
                chem_id(I) = j
                MODE(i) = 'TSER'
                ARG(i) = 0
                ARG2(i) = 0
                CONST(i) = 100000. !kg/ha
           end if
           
           if (is_daily_chem_leached_output) then
               i=i+1
                PLNAME(i) = 'COFX'
                chem_id(i) = j
                MODE(i) = 'TSER'
                
                ARG(i)  = find_depth_node(ncom2,soil_depth,leachdepth)
                ARG2(i) = 0
                CONST(i) = 100000. !kg/ha
           end if
           
           if (is_chem_decayed_part_of_soil_output) then
               i=i+1
                PLNAME(i) = 'DKFX'
                chem_id(I) = j
                MODE(i) = 'TSUM'
                
                ARG(i)  = find_depth_node(ncom2,soil_depth,decay_start)
                !because depth is determined at bottom of compartment need to add 1 (except fdor case of 1, where find_node already considers this)
                If (Arg(i) > 1) then             
                    ARG(i)  = ARG(i) +1
                end if
                ARG2(i) = find_depth_node(ncom2,soil_depth,decay_end)
                CONST(i) = 100000. !kg/ha
           end if
           
           if (is_chem_in_part_soil_output) then
               i=i+1
                PLNAME(i) = 'TPST'
                chem_id(i) = j
                MODE(i) = 'TSUM'

                ARG(i)  = find_depth_node(ncom2,soil_depth,fieldmass_start)
                !because depth is determined at bottom of compartment need to add 1 (except fdor case of 1, where find_node already considers this)
                If (Arg(i) > 1) then             
                    ARG(i)  = ARG(i) +1
                end if

                ARG2(i) = find_depth_node(ncom2,soil_depth, fieldmass_end )
                
                CONST(i) = 100000. !kg/ha
           end if
           
           if (is_chem_in_all_soil_output) then
               i=i+1
                PLNAME(i) = 'TPST'
                chem_id(i) = j
                MODE(i) = 'TSUM'     
                ARG(i) = 1
                depth2 = sum(thickness)
                ARG2(i) = find_depth_node(ncom2,soil_depth,depth2)
                CONST(i) = 100000. !kg/ha
           end if
           
           if (is_chem_on_foliage_output ) then
               i=i+1
                PLNAME(i) = 'FPST'
                chem_id(i) = j
                MODE(i) = 'TSER'   
                ARG(i) = 1
                ARG2(i) = 2
                CONST(i) = 100000. !kg/ha
           end if

    end do
    
    num_std_plots= i 

    do i =  1, extra_plots       
        PLNAME(num_std_plots +i)  = temp_PLNAME(i)
        chem_id(num_std_plots +i) = temp_chem_id(i)
        MODE(num_std_plots +i)    = temp_MODE(i)
        ARG(num_std_plots +i)     = temp_ARG(i)
        ARG2(num_std_plots +i)    = temp_ARG2(i)
        CONST(num_std_plots +i)   = temp_CONST(i)
	end do

    NPLOTS= num_std_plots + extra_plots
	
  end subroutine SetupFieldOutputOptions

  
  subroutine Calculate_Retardation_Factor
  use constants_and_variables, ONLY: ncom2, delx, theta_fc, bulkdensity, Kd_new,retardation_factor,maxcap_volume , nchem
        implicit none

		real :: total_depth
		integer ::i, k
        !  For i As Integer = 0 To (NumberOfHorizons - 2)
        !    depth = depth + thick(i).Text
        !Next
        !
        !Retardation = 0.0
        !For i As Integer = 0 To (NumberOfHorizons - 2)
        !    Retardation = Retardation + thick(i).Text / depth * (maxcap(i).Text + bulkden(i).Text * kd(ChemID, i)) / maxcap(i).Text
        !Next   
        
       do k = 1, nchem
	       total_depth = sum(delx)
	       retardation_factor(k) = 0.0
	       do i = 1, ncom2
	          	retardation_factor(k) = retardation_factor(k) + delx(i) /total_depth*	(theta_fc(i) +bulkdensity(i)*kd_new(k, i))/theta_fc(i)
	       end do

       end do       
        
       maxcap_volume = 0.0       
	   do i = 1, ncom2
			maxcap_volume = maxcap_volume + theta_fc(i) * delx(i)
       end do
  end subroutine Calculate_Retardation_Factor
  

end module initialization   