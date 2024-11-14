module chemical_transport
    implicit none
	contains

	subroutine chem_transport_onfield
	!Loop for chemical transport on field
    use constants_and_Variables, ONLY: julday1900 ,&
        precip, pet_evap,air_temperature ,wind_speed, solar_radiation, &
        precipitation,PEVP,air_TEMP,WIND, SOLRAD ,harvest_day, &
        startday, num_records,is_harvest_day,canopy_holdup, &
        canopy_height, canopy_cover  , cover, height, harvest_placement, &
        potential_canopy_holdup,evapo_root_node_daily, &
        evapo_root_node,root_node ,root_node_daily,atharvest_pest_app,day_number_chemtrans, &
        canopy_flow, canopy_flow_save, &
        First_time_through_PRZM, THAIR_new ,THAIR_save, theta_end_save,theta_end,runoff_on_day , runoff_save, & 
		soilwater, soilwater_save,velocity_save, vel,velocity_save, theta_zero,theta_zero_save,thair_old_save, thair_old, &
		erosion_save, enriched_erosion_save, sedl, enriched_eroded_solids, tdet ,et_save ,ainf,infiltration_save, &
        soil_temp_save, soil_temp, applied_mass_sum_gram_per_cm2
	

    use utilities_1
    use readinputs

    use field_hydrology
    use clock_variables

    implicit none

    integer :: i 
  
    First_time_through_PRZM = .TRUE. 
    julday1900 = startday
    applied_mass_sum_gram_per_cm2= 0.0
    

    
    do i=1, num_records   !day loop driven by metfile only   

       day_number_chemtrans = i
       !Vectors determined outside of loop transfered as scalers (or smaller arrays) to loop
       precipitation           = precip(i) 
       PEVP                    = pet_evap(i)
       air_TEMP                = air_temperature(i)
       WIND                    = wind_speed(i)
       SOLRAD                  = solar_radiation(i)
       cover                   = canopy_cover(i)   
       height                  = canopy_height(i) 
       harvest_day             = is_harvest_day(i)
       potential_canopy_holdup = canopy_holdup(i)
       evapo_root_node_daily   = evapo_root_node(i)
       root_node_daily         = root_node(i)       !only needed for irrigation
       harvest_placement       = atharvest_pest_app(i)
	   canopy_flow             = canopy_flow_save(i)
	   runoff_on_day           = runoff_save(i)
	   tdet                    = et_save(i)
	   
	   sedl                    = erosion_save(i)  !not sure if this is needed until output 
	   enriched_eroded_solids        = enriched_erosion_save(i)
	   
	   !still need to move erosion
			
       THAIR_new               = THAIR_save(:,i)
	   theta_end               = theta_end_save(:,i) 
	   soilwater               = soilwater_save(:,i)  !probably can eleiminate some of the soil water terms, rather than allocate and save them it might be quiicker to simple recalculate
	   vel                     = velocity_save(:,i)   !alocaction time might be counterproductive, need to check this
	   theta_zero              = theta_zero_save(:,i)
	   thair_old               = thair_old_save(:,i)
	   ainf				       = infiltration_save(:,i)   !only needed for output
	   
       soil_temp               = soil_temp_save(:,i)
       
      CALL chemical_transport_oneday


      julday1900 = julday1900  +1
	end do

   end subroutine chem_transport_onfield
    

	!*****************************************************************************************************
   SUBROUTINE chemical_transport_oneday
      use  constants_and_Variables, ONLY: is_temperature_simulated,soil_temp, is_nonequilibrium,              & 
      theta_end,bulkdensity, ncom2,&
      conc_total_per_water, mass_in_compartment,mass_in_compartment2, conc_porewater,    &
      ENPY,new_henry, old_Henry,NCHEM, some_applications_were_foliar,                         & 
      application_date, julday1900, total_applications,is_Freundlich,Henry_unitless, henry_ref_temp, &
      Kd_old,	kd_new, delx,  thair_old, thair_new, & 
      theta_zero, delt, number_subdelt, subdelt, Sorbed2, harvest_day, mass_in_compartment
 
     use Pesticide_Applications  
     use Temperatue_Calcs
     use Output_From_Field
  !   use Hydrolgy
  !   use evapotranspiration
     use erosion
     use irrigation
     !use plantgrowth
     use utilities_1
     use nonideal_sorption
     use volatilization
     use plant_pesticide_processes
	 use clock_variables
     implicit none
		
     integer  :: I,K, J
     integer  :: julday                   !this is the day of the year starting with Jan 1
     integer  :: current_year, current_month, current_day    
     REAL     :: OLDKH(NCOM2)
     real     :: old_conc(NCOM2), new_conc(NCOM2)
     real     :: predicted_conc(NCOM2)
     real     :: conc1_neq(NCOM2)         !mobile region post nonequilibrium phase  conc
     real     :: S2_neq(NCOM2)            !region2 post nonequilibrium phase conc
     real     :: S2_old(ncom2)            !local sorbed2 concentration    
     real     :: theta_new_subday(NCOM2)
     real     :: theta_old_subday(NCOM2)
     real     :: delta_watercontent(NCOM2)  !local water contents for use with subdaily time steps
     real     :: theta_air_new_subday(NCOM2)
     real     :: theta_air_old_subday(NCOM2)
     real     :: delta_aircontent(NCOM2)    !local water contents for use with subdaily time steps  
   
     !this version of julian day is needed for the curve number and erosion routines
     call get_date (julday1900, current_year, current_month, current_day) 
     julday = julday1900 -jd(current_year,1,1) +1
	 
        

     ! Application of Pesticide into System
     do i = 1,  total_applications   !check to see if this is an application day     
       if (application_date(i)==julday1900) then	
      
             CALL PESTAP(i)  
       end if
	 end do
		
     !Note for application day:
       !Currently there is no iterative adjustment to Kd (in Freundlich case) following application. 
       !However, it is adjusted on the subsequent day
   
     !The pesticide from washoff is taken into account in the "F" term of tridiagonal, somewhat in a manner
     !that it is production over time rather than an intial condition
   
     if (some_applications_were_foliar) then 
        CALL plant_pesticide_washoff
        if (harvest_day ) CALL plant_pesticide_harvest_application        
        CALL plant_pesticide_degradation
     end if   

	 
     
     
     do K=1, NCHEM   !******Pesticide Simulation ********************    
        !After application, get a new pore water concentration for beginning of time step: old_conc to be fed to tridiagonal
        do concurrent (I=1:NCOM2)
           old_conc(i) = conc_total_per_water(k,i)*theta_zero(i)/ &
                         (theta_zero(i)+kd_new(k,i)*bulkdensity(i)+ thair_old(i)*old_henry(k,i))     
           S2_old(i) =sorbed2(k,i)  !create a local array to help things run smoothly 
        end do
 
   
        ! ****** HENRY LAW COEFFICIENT CALCULATION Temperature Adjustments**************   
        IF (is_temperature_simulated) THEN  

            !adjust Henry's Constant for temperature
            CALL Henry_Temp_Correction (soil_temp, Henry_unitless(K),ENPY(K), henry_ref_temp, NCOM2,OLDKH)  !move to volatilization PLEASE
            new_henry(K,:) = OLDKH
            
            call Q10DK  !adjust degradation rates for temperature
            
        ENDIF

        call volatilization_setup(k)  !calculates boundary layer conductance and dair

        !Added these variables to explore Freundlich nonlinearity by different apporoximation methods and subdaily time steps
        
        !locally define these for sub daily
        delta_watercontent = (theta_end - theta_zero)/number_subdelt
        theta_old_subday = theta_zero
        theta_air_old_subday = THAIR_old
        delta_aircontent = (thair_new- thair_old)/number_subdelt
              
        do j = 1, number_subdelt  !********  Start sub daily time step here           
            !This creeps water & air contents through the subdaily steps*****                     
            theta_new_subday = theta_old_subday + delta_watercontent              
            theta_air_new_subday = theta_air_old_subday + delta_aircontent               
            Kd_old(K, :) = kd_new(K,:)   !Store Old Kd for use in F coefficients of tridiagonal
                 
            !***************************************************************************   
            !******************** Nonequilibrium ***************************************     
            !***************************************************************************   
            if (is_nonequilibrium) then
                ! 1.  Use analytical solution to transfer mass between mobile region and Noneq region. Use current Kd_new.
                !     Get new pre-predicted mobile concentration.
                   
                call nonequilibrium(subdelt,k, old_conc , S2_old, theta_old_subday , theta_air_old_subday, conc1_neq, S2_neq )
                !This opeartion is done outside the P-C routine using explicit Kd values. Possible could ibnclude in P-C by 
                !calculating an average Kd during the time step but is it worthwhile?   
                !use conc output from noneq routine (conc1_neq) as input for mobile region conc
                
                !conc1_neq and Sorbed2 is the output
                
                S2_old   = S2_neq       !update the sorbed 2 region and we are done with it for this time step
                old_conc = conc1_neq    !update the beginning day concentration to reflect post-nonequilibrium step
            end if 
      
            !***************************************************************************                              
            !************************** Predictor **************************************
            !***************************************************************************
            if (is_Freundlich) then                  !Freundlich Flag: only need P/C for nonlinear isotherms
                !calculate a "predictor" concentration for calculating predictor Kd:
                !Split operator : Mass transfer to Region 2 is solved independently of Advection Dispersion operation.
                
                !  2. With mobile new concentration (conc1_neq) a& current Kd, take time step and get a predicted mobile concentration.
                call setup_tridiagonal_for_przm(subdelt, K, theta_new_subday, theta_old_subday,&
                                      theta_air_new_subday, theta_air_old_subday, old_conc, predicted_conc)  
                
                !  3. With predicted future concentration, calculate a future Kd to be used in the corrector step. No concentrations are 
                !     saved during the precictor step.
                Call Freundlich(k, predicted_conc)           !Puts a predicted New Kd into parameter module
			end if 
                    
            !**************************************************************************** 
            !************************  Corrector  ***************************************
            !**************************************************************************** 
            !  4. With predicted Kd the conc1_neq concentration, now calculate                
            !      the Corrected concentration for future mobile region (new_conc)
            
            call setup_tridiagonal_for_przm(subdelt, K, theta_new_subday, theta_old_subday,theta_air_new_subday, &
                                 theta_air_old_subday, old_conc, new_conc) 

            theta_old_subday = theta_new_subday        !store these for use in tridiagonal
            theta_air_old_subday = theta_air_new_subday
                
		end do    !*******end sub daily here


        !Store new total mass
        do i=1, NCOM2
    
            conc_total_per_water(K,I)=new_conc(i)*(theta_end(i)+kd_new(K,i)*bulkdensity(i) + thair_new(i)*new_henry(K,i))/theta_end(i)           
            Sorbed2(k,i)  = S2_neq(i)
            mass_in_compartment(K,I) = new_conc(i) * (theta_end(i) + kd_new(K,i)*bulkdensity(i) + thair_new(i)*new_henry(K,i))*delx(i)
            mass_in_compartment2(K,I) = Sorbed2(k,i)*bulkdensity(i)*delx(i)                        
        end do
        
        
        
       !*****END PREDICTOR CORRECTOR ********************************************************************************************

       call flux_calculations(K, new_conc)   ! Fluxes should really be a summation of the subdaily--fix this
       conc_porewater(k,:) =  new_conc       ! rename concentration to something of more sense
       
       !Store new values for start values of next run
       old_Henry(K,:) = new_henry(K,:) !First Store Previous Run's Henry's Constant
	 end do

    !probably could/should take this out of this subroutine	, but would require more arrays saves
	 call get_inputs_from_field_for_vvwm	
     CALL write_outputfile_2    
	           
   end subroutine chemical_transport_oneday
   
	
SUBROUTINE setup_tridiagonal_for_przm(delt, K, theta_new, theta_old,theta_air_new, theta_air_old, old_conc, new_conc)
    use utilities_1
    use constants_and_Variables, ONLY: SoilWater,EvapoTran,DELX,bulkdensity,runoff_on_day,         &
      ncom2,vel, DWRATE,DSRATE,DGRATE, gamma1, &
      dispersion,old_Henry,new_henry,soil_applied_washoff,CONDUC, &
      SRCFLX, runoff_intensity,  enriched_eroded_solids, erosion_intensity, dgair, &
      kd_new, Kd_old
use clock_variables	
	
    implicit none

    !Sets up the coefficient matrix for the solution of the soil pesticide transport equation. It then calls an equation
    !solver for the tridiagonal matrix and sets up pesticide flux terms using the new concentrations.
    !Modification date: 2/18/92 JAM
    !Further modified at AQUA TERRA Consultants to hard code the
    !pesticide extraction depth to 1 cm. 9/93

    INTEGER, intent(in)  :: K!     K      - chemical number being simulated (1-3)
    real,    intent(in)  :: old_conc(ncom2)
    real,    intent(out) :: new_conc(ncom2)
    real,    intent(in)  :: delt                !time step, could be subdaily
    real,    intent(in)  :: theta_new(ncom2), theta_old(ncom2)
    real,    intent(in)  :: theta_air_new(ncom2), theta_air_old(ncom2)
      
    INTEGER ::   I
    real    ::   A(ncom2),B(ncom2),C(ncom2),F(ncom2)
integer mm

    SRCFLX(1,:)=0.0  !Parent production is always zero. For degradate, this variable gets populated after corrrector run
    ! Set up coefficients for surface layer
    ! Set up tridiagonal system
    ! a(i) y(i-1)  +  b(i) y(i)  +  c(i) y(i+1) = f(i)
    ! a(1) = c(n) = 0


	
    A(1)= 0.0
    B(1)= (  (dispersion(1)*theta_new(1) + new_henry(K,1)*DGAIR(1)) / (DELX(1)* DELX(1))  & 
             + VEL(1)*theta_new(1)/DELX(1)                                                  &
             + (DWRATE(K,1)*theta_new(1))                                                   &  
             + (DSRATE(K,1)*kd_new(K,1)*bulkdensity(1))                                     &
             + (DGRATE(K,1)*theta_air_new(1)*new_henry(K,1))                                &
             + GAMMA1(K,1)*EvapoTran(1)*theta_new(1)/SoilWater(1)                           &
             + runoff_on_day*runoff_intensity(1)                                            &
             + enriched_eroded_solids*kd_new(K,1)*erosion_intensity(1)                      &
            ) *DELT                                                                         &
             +theta_new(1) + kd_new(K,1)*bulkdensity(1) + theta_air_new(1)*new_henry(K,1) + CONDUC(K)*new_henry(K,1)*DELT/DELX(1)     

    C(1)= -(dispersion(2)*theta_new(2) + new_henry(K,2)*DGAIR(2) )  *DELT/(DELX(1)* 0.5*(DELX(1)+DELX(2)))
         
    !Mass is added either as an initial condition as with pesticide applications or as a rate over the time
    !step as it is done here for washoff and degradate production
    F(1)= (theta_old(1)+ Kd_old(K,1)*bulkdensity(1) +    theta_air_old(1)*old_Henry(K,1))* old_conc(1)    +  &
             (soil_applied_washoff(K,1)*DELT/DELX(1))   +   SRCFLX(K,1)/DELX(1)*DELT 

	
	
    ! Calculate coefficient of non-boundary soil layers
    do I=2,NCOM2- 1
        A(I)= (-(dispersion(I-1)*theta_new(I-1)+new_henry(K,I-1)*DGAIR(I-1))/(DELX(I)*0.5*(DELX(I-1)+DELX(I)))        &
              -VEL(I-1)*theta_new(I-1)/DELX(I) )*DELT

        
        B(I)= ( (dispersion(I)*theta_new(I)  +  new_henry(K,I)*DGAIR(I))  /   (DELX(I)*0.5*(DELX(I-1)+DELX(I)))            &
              + (dispersion(I)*theta_new(I)  +  new_henry(K,I)*DGAIR(I))  /   (DELX(I)*0.5*(DELX(I)+DELX(I+1)))            &
              + VEL(I)*theta_new(I)/DELX(I)                                 &
              + (DWRATE(K,I) *theta_new(I))                                 &
              + (DSRATE(K,I) *kd_new(K,I)*bulkdensity(I))                   &
              + (DGRATE(K,I) *theta_air_new(I)*new_henry(K,I))              &
              + GAMMA1(K,I)*EvapoTran(I)*theta_new(I)/SoilWater(I)          &
              + runoff_on_day*runoff_intensity(i)                           &
              + enriched_eroded_solids*kd_new(K,i)*erosion_intensity(i)     &
              )*DELT   +   theta_new(i)   +   kd_new(K,i)*bulkdensity(i)  +  theta_air_new(i)*new_henry(K,i)
                      
        C(I)= -(dispersion(I+1)*theta_new(I+1)+  new_henry(K,I+1)*DGAIR(I+1))*DELT  /  (DELX(I)*0.5*(DELX(I)+DELX(I+1)))
         
        F(I)=(theta_old(I) + Kd_old(K,I)*bulkdensity(I)  +  theta_air_old(I)*old_Henry(K,I) )* old_conc(I)  +  &
               (soil_applied_washoff(K,I)*DELT/DELX(I)) +     SRCFLX(K,I)/DELX(I)*DELT
        
      

 
        
        
    end do
        



	
    !Runoff and Erosion are not included in the last layer
    !Calculate coefficients of bottom layer
    A(NCOM2)=(-(dispersion(NCOM2- 1)*theta_new(NCOM2- 1)+new_henry(K,NCOM2- 1)*DGAIR(NCOM2- 1))                 &
          /(DELX(NCOM2)*0.5*(DELX(NCOM2- 1)+DELX(NCOM2)))-VEL(NCOM2- 1)*theta_new(NCOM2- 1)/DELX(NCOM2))*DELT
    
    B(NCOM2)= ((dispersion(NCOM2)*theta_new(NCOM2)+new_henry(K,NCOM2)*DGAIR(NCOM2))/(DELX(NCOM2)*DELX(NCOM2))    &
              + VEL(NCOM2) * theta_new(NCOM2) / DELX(NCOM2)    &
              +(DWRATE(K,NCOM2)*theta_new(NCOM2))        &
              +(DSRATE(K,NCOM2)*kd_new(K,NCOM2)*bulkdensity(NCOM2))+DGRATE(K,NCOM2)*theta_air_new(NCOM2)*new_henry(K,NCOM2))*DELT   &
              +theta_new(NCOM2)+kd_new(K,NCOM2)*bulkdensity(NCOM2)+theta_air_new(NCOM2)*new_henry(K,NCOM2)
 
    C(NCOM2)= 0.0 
    F(NCOM2)= (theta_old(NCOM2)+Kd_old(K,NCOM2)*bulkdensity(NCOM2)+ theta_air_old(NCOM2)*old_Henry(K,NCOM2))* old_conc(NCOM2)  &
               +(soil_applied_washoff(K,NCOM2)*DELT/DELX(NCOM2))    +  SRCFLX(K,NCOM2)/DELX(NCOM2)*DELT
  
CALL CPU_TIME (time_5)	

!do i= 1, ncom2
!       write(97,'(I8, 4G12.4)')  i, (DWRATE(K,i)*theta_new(i))  +(DSRATE(K,i)*kd_new(K,i)*bulkdensity(i)),DWRATE(K,i), DSRATE(K,i)
!end do
!
!  
    CALL TRIDIAGONAL_Solution (A,B,C, new_conc,F,NCOM2)        

	
CALL CPU_TIME (time_6)		  
Cumulative_cpu_3 = Cumulative_cpu_3 + time_6 - time_5 		
	

END SUBROUTINE setup_tridiagonal_for_przm	
	
	
!***********************************************************************   
subroutine flux_calculations(k, concentration)
    !Calculates the fluxes for the day.  Use after all concentrations are calculated.
    use  constants_and_Variables, ONLY: ncom2, &
                                 PVFLUX, CONDUC, new_henry,  &
                                 delx,theta_end,    &
                                 vel,                &
                                 DKFLUX, DWRATE, DSRATE, DGRATE, bulkdensity, THAIR_new,           &
                                 MolarConvert_aq12, MolarConvert_aq13, MolarConvert_aq23 ,         &
                                 MolarConvert_s12,  MolarConvert_s13,  MolarConvert_s23 ,          &
                                 SRCFLX,                                                           &
                                 ROFLUX, runoff_on_day, runoff_intensity, RNCMPT,                          &
                                 ERFLUX, enriched_eroded_solids, erosion_intensity, erosion_compt, &
                                 UPFLUX, gamma1, EvapoTran,                                        &
                                 DCOFLX,                                                           &
                                 WOFLUX, soil_applied_washoff,                                     &
                                 SDKFLX, SUPFLX,                                                   &
                                 DGAIR,                                                            &
                                 kd_new, nchem
                                          
    implicit none
    real, intent(in)    :: concentration(ncom2)  !porewater concentration
    integer, intent(in) :: k
    integer :: i

    !Primary Fluxes need for program at all times
    ROFLUX(K) =  sum( runoff_on_day*runoff_intensity(1:RNCMPT)*concentration(1:RNCMPT) *DELX(1:RNCMPT) )   
     

    
    
    ERFLUX(K) =  sum( enriched_eroded_solids*kd_new(K,1:erosion_compt)*    & 
                       concentration(1:erosion_compt)*erosion_intensity(1:erosion_compt)*DELX(1:erosion_compt) )
      
        !-------------------VOLATILIZATION--------------------------
        !PVFLUX: Daily Soil Pesticide Volatilization Flux (g cm^-2 day^-1)
        PVFLUX(K,1) = -CONDUC(K)*concentration(1)*new_henry(K,1)   !Calculate pesticide fluxes at soil surface 
        PVFLUX(K,NCOM2)=0.
        IF(ABS(PVFLUX(K,1)).LT.1.E-34)PVFLUX(K,1)=0.0
        do i=2,NCOM2- 1 
            PVFLUX(K,I)=DGAIR(I)*new_henry(K,I)/(0.5*(DELX(I)+DELX(I+1)))*concentration(I)    &
                   -DGAIR(I+1)*new_henry(K,I+1)/(0.5*(DELX(I)+DELX(I+1)))*concentration(I+1)       
            IF(ABS(PVFLUX(K,I)).LT.1.E-34)PVFLUX(K,I)=0.0       
        end do
             
        !------------Soil Degradation------------------------------------
        DKFLUX(K,1)=DELX(1)*concentration(1)*(DWRATE(K,1)*theta_end(1) + DSRATE(K,1)*bulkdensity(1)*kd_new(K,1)+ DGRATE(K,1)*THAIR_new(1)*new_henry(K,1) )
        do i=1,NCOM2 
             DKFLUX(K,I)=DELX(I)*concentration(i)*(DWRATE(K,i)*theta_end(I)+ DSRATE(K,I)*bulkdensity(I)*kd_new(K,I)+  DGRATE(K,I)*THAIR_new(I)*new_henry(K,I)   )           
        end do
        SDKFLX(K)=sum(DKFLUX(K,:))

        !------------Plant Washoff ------------------------------------------
        WOFLUX(K) = sum(soil_applied_washoff(K,:))
        
        !------------Plant Upotake -------------------------------------------
        UPFLUX(K,1:ncom2)=GAMMA1(K,1:ncom2)*EvapoTran(1:ncom2)*concentration(1:ncom2)
        SUPFLX(K)=sum(UPFLUX(K,1:ncom2))
    
        !--------Pestide Outflow from Bottom compartment----------
        DCOFLX(K) =  (VEL(NCOM2)*concentration(NCOM2)*theta_end(NCOM2))      

    
    
    !------------------------Degrdate Production --------------------------------------
    IF (nchem ==1)then 
         srcflx=0.0
    else     
        if(k.eq.1)then
            !Assume no gas phase degradation here
            srcflx(2,1)=DELX(1)*concentration(1)*(MolarConvert_aq12(1)*DWRATE(K,1)*theta_end(1) + MolarConvert_s12(1)*DSRATE(K,1)*bulkdensity(1)*kd_new(K,1) ) !+DGRATE(K,1)*THAIR_new(1)*new_henry(K,1)   ) 
            srcflx(3,1)=DELX(1)*concentration(1)*(MolarConvert_aq13(1)*DWRATE(K,1)*theta_end(1) + MolarConvert_s13(1)*DSRATE(K,1)*bulkdensity(1)*kd_new(K,1) ) !+DGRATE(K,1)*THAIR_new(1)*new_henry(K,1)   )
        elseif(k.eq.2)then    
            srcflx(3,1)=srcflx(3,1)+ DELX(1)*concentration(1)*(MolarConvert_aq23(1)*DWRATE(K,1)*theta_end(1) + MolarConvert_s23(1)*DSRATE(K,1)*bulkdensity(1)*kd_new(K,1) )
        endif
        
        do i=2,NCOM2- 1 
            if(k.eq.1)then  
                srcflx(2,i) = DELX(i)*concentration(i)*(MolarConvert_aq12(i)*DWRATE(K,i)*theta_end(i) +  &
                          MolarConvert_s12(i)*DSRATE(K,i)*bulkdensity(i)*kd_new(K,i) )   
                srcflx(3,i) = DELX(i)*concentration(i)*(MolarConvert_aq13(i)*DWRATE(K,i)*theta_end(i) + &
                          MolarConvert_s13(i)*DSRATE(K,i)*bulkdensity(i)*kd_new(K,i) ) 
            elseif(k.eq.2)then
                srcflx(3,i) = srcflx(3,i)+DELX(i)*concentration(i)*(MolarConvert_aq23(i)*DWRATE(K,i)*theta_end(i) +   &
                         MolarConvert_s23(i)*DSRATE(K,i)*bulkdensity(i)*kd_new(K,i) ) 
            endif
        end do

        if(k.eq.1) then
            srcflx(2,ncom2)= DELX(NCOM2)*concentration(NCOM2)* & 
                          (MolarConvert_aq12(ncom2)*DWRATE(K,NCOM2)*theta_end(NCOM2) +          &
                           MolarConvert_s12(ncom2) *DSRATE(K,NCOM2)*bulkdensity(NCOM2)*kd_new(K,NCOM2) )  ! +DGRATE(K,NCOM2)*THAIR_new(NCOM2)*new_henry(K,NCOM2)   )
            srcflx(3,ncom2)= DELX(NCOM2)*concentration(NCOM2)* & 
                           (MolarConvert_aq13(ncom2)* DWRATE(K,NCOM2)* theta_end(NCOM2) +          &
                            MolarConvert_s13(ncom2) * DSRATE(K,NCOM2)* bulkdensity(NCOM2)*kd_new(K,NCOM2) ) 
        elseif(k.eq.2) then
            srcflx(3,ncom2) = srcflx(3,ncom2)  + DELX(NCOM2)*concentration(NCOM2)* & 
                          (MolarConvert_aq23(ncom2)* DWRATE(K,NCOM2)* theta_end(NCOM2) +          &
                          MolarConvert_s23(ncom2) * DSRATE(K,NCOM2)* bulkdensity(NCOM2)*kd_new(K,NCOM2) ) 
        endif
    endif
    

   end subroutine flux_calculations	
	
	

	
	
	
!**************************************************************************************************		


   
   
   
	
end module chemical_transport