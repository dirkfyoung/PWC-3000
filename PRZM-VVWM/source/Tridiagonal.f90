Module Tridiagonal
contains

SUBROUTINE PRZM5_tridiagonal(delt, K, theta_new, theta_old,theta_air_new, theta_air_old, old_conc, new_conc)
    use utilities_1
    use constants_and_Variables, ONLY: SoilWater,EvapoTran,DELX,bulkdensity,runoff_on_day,         &
      ncom2,vel, DWRATE,DSRATE,DGRATE, gamma1, &
      dispersion,old_Henry,new_henry,soil_applied_washoff,CONDUC, &
      SRCFLX, runoff_intensity,  enriched_eroded_solids, erosion_intensity, dgair, &
      kd_new, Kd_old,use_bidiagonal
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
	

         
    CALL TRIDIAGONAL_Solution (A,B,C, new_conc,F,NCOM2)        


    
END SUBROUTINE PRZM5_tridiagonal

   
   
   
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
   
end module tridiagonal
    