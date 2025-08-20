module erosion
    implicit none 
    contains
    
    SUBROUTINE EROSN(day, julday)
     !Determines loss of pesticide due to erosion by a variation of USLE and an enrichment ratio.
      use constants_and_Variables,ONLY: soil_temp,is_temperature_simulated,AFIELD_ha,USLEK,USLELS,USLEP,cfac, &
                                        erflag,sedl,enriched_eroded_solids,  julday1900,model_erosion,data_date ,&
	                                    erosion_save, enriched_erosion_save, runoff_save
	  
	  !***NOTE make sedl and enriched_erosion_solids local variables when done *************
										
										
      use utilities_1
      implicit none
	  integer, intent(in) :: day    !simulation tracker for output arrays
      integer,intent(in) :: julday  !used to determine the rainfall characteristics
      
      real :: runoff_today

	  
      REAL ::  Q,QQP,SLKGHA,ENRICH
      REAL ::  EC0,EC1,EC2,TC,QP,QU
      
      runoff_today = runoff_save(day)
      

      
      !if runoff does not occur or frozen ground (maybe redundant) then no erosion
	  SEDL= 0.0                     
      enriched_eroded_solids= 0.0	
	  IF (runoff_today <= 0.0 ) then !if runoff does not occur, no erosion
        
          
		  SEDL= 0.0                     
          enriched_eroded_solids= 0.0	
	  else if ((is_temperature_simulated).AND.(soil_temp(1).LE.0.0)) then !if runoff does not occur or frozen ground (maybe redundant) 
          SEDL= 0.0                     
          enriched_eroded_solids= 0.0	 
             
          
      else  !regular erosion caluclations
             
          
         call TMCOEF(EC0,EC1,EC2, julday)  !Get Coefficients from Table F-1 in TR-55
         call Time_of_conc_lag_method(TC)
         QU=EC0+EC1*ALOG10(TC)+EC2*(ALOG10(TC))**2.     
         QU=10.0**QU     
         !QP=(QU*(AFIELD_ha*.00386)*(runoff_on_day*.3937))*0.02832
         !QP=(QP/AFIELD_ha)*360.
    
         QP= 0.01549346 *QU *runoff_today   ! check = QU*.00386*runoff_on_day*.3937*0.02832*360.      
         Q=runoff_today*10.
         QQP=Q*QP
      
         IF(ERFLAG.EQ.1)THEN                          ! MUSLE
           sedl=1.586*(QQP**0.56)*(AFIELD_ha**0.12)
         ELSEIF(ERFLAG.EQ.2)THEN                      ! MUST
           sedl=2.5*(QQP**0.5)
         ELSEIF(ERFLAG.EQ.3)THEN                      ! MUSS
           SEDL=0.79*(QQP**0.65)*(AFIELD_ha**0.009)
         else                                         ! anything else is no erosion
             sedl=0.0
         endif           
          SEDL   = (SEDL* USLEK* USLELS* CFAC* USLEP)*AFIELD_ha  !metric tons per day
          SLKGHA = (SEDL* 1000.)/AFIELD_ha						 !kg/ha
             
         IF(SLKGHA.EQ.0.0)THEN
           ENRICH=1.0
         ELSE
           ENRICH = 2.0- (0.2* log(SLKGHA)) 
           ENRICH= EXP(ENRICH)
         ENDIF
	     enriched_eroded_solids=  (SLKGHA/(100000.))*ENRICH   !grams/cm2  (ha/10000 m2)(1000 g/kg)(m2/10000 cm2) = 1/100000
	  end if
	
	  
      erosion_save(day) = sedl
	  enriched_erosion_save(day)= enriched_eroded_solids

      
      	  write(92,*) runoff_today, sedl
      
    END  SUBROUTINE EROSN
    
  
    
   SUBROUTINE Time_of_conc_lag_method(TC)

      !Calculate time of concentration based on Watershed Lag Method ion NEH-4 Chapter 4
      !TC = time of concentration (hrs)
      !HL is in meters so must convert to feet forthis method
      !Slp is in perecent so no conversion needed
      
       use  constants_and_Variables, ONLY: SLP,curve_number_daily
       use waterbody_parameters, ONLY: hydro_length
       implicit none
       real, intent(out) :: TC
       REAL HL1, S              

       
       
       HL1 = hydro_length*3.28                       !convert to feet
       S = 1000./curve_number_daily - 10.0
    
       TC = HL1**.8 * (S  +1.)**0.7 / 1140.0 /slp**0.5

    END SUBROUTINE Time_of_conc_lag_method
    
    
    
    
    
  
! **********************************************
  SUBROUTINE TMCOEF(EC0,EC1,EC2,julday)
      !Gets Coefficients fro Table F-1 in TR-55
      use  constants_and_Variables, ONLY: PRECIP_rain, thrufl, ireg, inabs, smelt

      implicit none 

      integer,intent(in) :: julday
       real, intent(out) :: EC0,EC1,EC2
      
      INTEGER  IFND,J
      INTEGER  NBG(4),NEN(4)
      REAL     CC(32),CC0(32),CC1(32),CC2(32)
      REAL     CTEMP,IAP
     

      DATA NBG /1,9,17,25/
      DATA NEN /8,13,22,30/
      DATA CC  /0.10,0.20,0.25,0.30,0.35,0.40,0.45,0.50,0.10,0.20,0.25,0.30,0.50,0.00,0.00,0.00, &
                0.10,0.30,0.35,0.40,0.45,0.50,0.00,0.00,0.10,0.30,0.35,0.40,0.45,0.50,0.00,0.00/
      DATA CC0 /2.30550,2.23537,2.18219,2.10624,2.00303,1.87733,1.76312,1.67889,2.03250,1.91978,1.83842,1.72657,1.63417, &
                0.0,0.0,0.0,2.55323,2.46532,2.41896,2.36409,2.29238,2.20282,0.0,0.0,                                     &
                2.47317,2.39628,2.35477,2.30726,2.24876,2.17772,0.0,0.0/
      DATA CC1 /-0.51429,-0.50387,-0.48488,-0.45695,-0.40769,-0.32274,-0.15644,-0.06930,                                &
                -0.31583,-0.28215,-0.25543,-0.19826,-0.09100,0.0,0.0,0.0,-0.61512,-0.62257,-0.61594,-0.59857,-0.57005,  &
                -0.51599,0.0,0.0,-0.51848,-0.51202,-0.49735,-0.46541,-0.41314,-0.36803,0.0,0.0/
      DATA CC2 /-0.11750,-0.08929,-0.06589,-0.02835,0.01983,0.05754,0.00453,0.0,-0.13748,-0.07020,-0.02597,0.02633,0.0,  &
                 0.0,0.0,0.0,-0.16403,-0.11657,-0.08820,-0.05621,-0.02281,-0.01259,0.0,0.0,                              &
                 -0.17083,-0.13245,-0.11985,-0.11094,-0.11508,-0.09525,0.0,0.0/

      
      
!      IREGOLD=IREG
      
      !!not sure where these ideas came from, they seem contrived to reduce peak runoff.  No reference given in manual. I am adding this option
      !!to bypass relations and allow for some examination.  dfy Feb 2019
      ! original even possibly even confused the ireg numbers as ireg2 is equal to type 1A, not type 2
                                           
      !       IF(IREG.NE.2)THEN
      !         IF((JULDAY.LE.121).OR.(JULDAY.GE.258))THEN  !May 1 to Sep 16,  IREG = IREG, else IREG =2
      !           IREG=2
      !         ELSEIF(PRECIP_rain .GT. 5.08)THEN  !not sure what this is about
      !           IREG=1
      !         ENDIF
      !       ENDIF

      
      
      
      IFND=0
      IAP=INABS/(THRUFL+SMELT)

      
      
      IF(IAP.LE.CC(NBG(IREG)))THEN
        EC0=CC0(NBG(IREG))
        EC1=CC1(NBG(IREG))
        EC2=CC2(NBG(IREG))
      ELSE
        do J=NBG(IREG),NEN(IREG)
          IF((IAP.LE.CC(J)).AND.(IFND.EQ.0))THEN
            CTEMP=(IAP-CC(J-1)) / (CC(J)-CC(J-1))
            EC0=CTEMP * (CC0(J)-CC0(J-1)) + CC0(J-1)
            EC1=CTEMP * (CC1(J)-CC1(J-1)) + CC1(J-1)
            EC2=CTEMP * (CC2(J)-CC2(J-1)) + CC2(J-1)
            IFND=1
          ENDIF
        end do
        IF(IFND.EQ.0)THEN
          EC0=CC0(NEN(IREG))
          EC1=CC1(NEN(IREG))
          EC2=CC2(NEN(IREG))
        ENDIF
      ENDIF


  !    IREG=IREGOLD

  END SUBROUTINE TMCOEF
  

    
end module erosion
    
    
    