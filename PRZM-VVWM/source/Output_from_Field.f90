Module Output_From_Field
  implicit none
    contains
		
    subroutine scenario_hydrolgy_summary
    use constants_and_variables, ONLY: scenario_id, hold_precip, hold_irrig, hold_runoff
       !  write(98,'(A40, 4G12.4)') trim(scenario_id), hold_precip, hold_irrig, hold_runoff, hold_runoff/(hold_precip + hold_irrig) 

    
    end subroutine scenario_hydrolgy_summary
    
    
    
	subroutine groundwater
	    use constants_and_variables, ONLY: num_records, retardation_factor,  maxcap_volume, conc_last_horizon_save, &
	    	                               infiltration_save, ncom2,gw_peak, post_bt_avg ,throughputs,simulation_avg, nchem
	    implicit none
        !maxcap_volume = effective pore volume
	    !Throughputs = infiltration/maxcap_volume/retardation_factor
	    integer :: i,k
	    integer :: count
	    real    :: adj 
	    reaL    :: inflitration_cum
	    
	    !write(98,*) 'Retardation Factor: ', retardation_factor
	    !write(98,*) 'Water Capacity:	 ', maxcap_volume
	    !write(98,*) 'Day    Flow(cm)  Pore Volumes  Throughputs  Conc(ppb)'
	
        do k=1,nchem         
              adj = maxcap_volume*retardation_factor(k)
              post_bt_avg(k)    = 0.0          !post breakthrough average, avg concentration after one thoughput in last horizon
              simulation_avg(k) = 0.0		   !entire simulation average concentration in last horizon
              gw_peak(k) = 0.0				   !highest concentration in last horizon
              count = 0
              inflitration_cum = 0.0           !cumulative infiltration (cm)   
             
              do i = 1, num_records
                  simulation_avg(k) =simulation_avg(k) + conc_last_horizon_save(k, i)
                  inflitration_cum = inflitration_cum + infiltration_save(ncom2, i)
                 !   write(98,'(I6, 4G12.3)') i, inflitration_cum,inflitration_cum/maxcap_volume, inflitration_cum/adj, conc_last_horizon_save(i)
                  if (inflitration_cum/adj >= 1.0) then
                      count = count + 1
                      post_bt_avg(k) = post_bt_avg(k) +conc_last_horizon_save(k,i)
                  end if	
              end do
              
              gw_peak(k) = maxval(conc_last_horizon_save(k,:))
              post_bt_avg(k) = post_bt_avg(k)/count
              throughputs(k) = inflitration_cum/adj
              simulation_avg(k) = simulation_avg(k) / num_records 
        end do

    end subroutine groundwater
    
    

	
	subroutine get_inputs_from_field_for_vvwm
	    use  constants_and_Variables, ONLY:mass_off_field,ROFLUX,ERFLUX,day_number_chemtrans,nchem 
	    use waterbody_parameters, ONLY: afield 
	    implicit none
   
	   
        !Time Series sent to VVWM:
        mass_off_field(day_number_chemtrans,1,1) =   ROFLUX(1)* afield*10.  !converts to kg
        mass_off_field(day_number_chemtrans,2,1) =   ERFLUX(1)* afield*10.  !converts to kg
          
        
        
        
        if (nchem >1) then
          mass_off_field(day_number_chemtrans,1,2) = ROFLUX(2)* afield*10.  !converts to kg
          mass_off_field(day_number_chemtrans,2,2) = ERFLUX(2)* afield*10.  !converts to kg
        end if
        
        if (nchem >2) then
          mass_off_field(day_number_chemtrans,1,3) = ROFLUX(3)* afield*10.  !converts to kg
          mass_off_field(day_number_chemtrans,2,3) = ERFLUX(3) * afield*10.  !converts to kg
		end if


	end subroutine get_inputs_from_field_for_vvwm
	


  !**********************************************************************************************
  subroutine write_outputfile_header_2
  !called by program below id time series is selected
      use  constants_and_Variables, ONLY:TimeSeriesUnit2,Version_Number,PLNAME,chem_id,NPLOTS
      integer :: i
      
      WRITE(TimeSeriesUnit2,'(A48,1X,F7.3)')'United States of America, EPA PRZM5-VVWM Version', Version_Number  
      WRITE(TimeSeriesUnit2,*)      
  
      WRITE(TimeSeriesUnit2,'(A4,1x,A2,1x,A2,9x, 100(A4,I1,9X))') "Year","Mo","Dy", (PLNAME(I),chem_id(I),I=1,NPLOTS)     !Header List
      
  end subroutine write_outputfile_header_2
 
  SUBROUTINE write_outputfile_2
    use	constants_and_Variables, ONLY: is_timeseriesfile, TimeSeriesUnit2, precipitation, snowfl,soil_temp,THRUFL,IRRR,SoilWater,cint,EvapoTran,delx, &
    theta_end, CEVAP ,runoff_on_day,curve_number_daily,theta_sat,ainf,ncom2,snow,sedl,TDET,PVFLUX,sdkflx,SUPFLX,UPFLUX,kd_new, &
    conc_total_per_water, mass_in_compartment, mass_in_compartment2,HEIGHT,  &
    conc_porewater, FOLPST,Foliar_degrade_loss,new_henry,Foliar_volatile_loss,plant_app, &
    NCHEM,TCNC,DKFLUX,ERFLUX, WOFLUX,ROFLUX,const,OUTPUJ,    &
    OUTPJJ,chem_id,NPLOTS, ARG,ARG2,PLNAME,MODE,DCOFLX,max_number_plots,Version_Number,julday1900,  &
     day_number_chemtrans,mass_off_field, &
    First_time_through_PRZM , working_directory, family_name, run_id,maxFileLength, &
	top_node_last_horizon, bottom_node_last_horizon,conc_last_horizon_save, day_number_chemtrans, full_run_identification, &
    hold_precip,hold_irrig,hold_runoff
    
    use waterbody_parameters, ONLY: afield 
    use utilities_1
    
!   Outputs user specified time series to time series plotting files
    implicit none

    integer :: start_compartment, end_compartment
    INTEGER  I,K
    real ::  OUTPUT(max_number_plots)
    REAL ::  PNBRN(max_number_plots)
    real ::  PRTBUF(max_number_plots)

    REAL   RMULT,onSOIL(3)
    REAL   TTTOT,DPTOT

    CHARACTER(len=4) :: TSUM,TAVE,TSER,TCUM
    character(len = maxFileLength) :: filename
    integer :: current_year,current_month,current_day
    

	!**************************************************************
     DO K=1,NCHEM    !always capture the average concentration in last two compartments for use in gw       
         tttot = 0.0
         do i =   top_node_last_horizon,bottom_node_last_horizon              
                TTTOT= TTTOT  + conc_porewater(k,i)   *DELX(i) 
         end do 
         !top_node_last_horizon = next to last node and bottom_node_last_horizon = last node, now set this way
         conc_last_horizon_save(k, day_number_chemtrans) =   TTTOT  * 1.0E9/sum(delx( top_node_last_horizon:bottom_node_last_horizon ))
     end do	

    !********************************************************************** 
       !Cummulatives for researech
  hold_precip   = hold_precip + precipitation
  hold_irrig    = hold_irrig  + IRRR
  hold_runoff   = hold_runoff + runoff_on_day
     
     
     
     
	if (is_timeseriesfile .eqv. .FALSE. ) return  !if time series file is not specified, then leave
	
    if (First_time_through_PRZM) then 
		filename = trim(full_run_identification) // ".out"  !field output name    
	    OPEN(Unit=TimeSeriesUnit2,FILE=filename, STATUS='UNKNOWN') 
        call  write_outputfile_header_2
        First_time_through_PRZM = .FALSE.
    end if
    
    TSUM = 'TSUM'
    TAVE = 'TAVE'
    TCUM = 'TCUM'
    TSER = 'TSER'
    
    !DO K=1,NCHEM
    !  onSOIL(K) = 0.00
    !  DO i = 1, NCOM2
    !    onSOIL(K) = onSOIL(K) + SOILAP(K,i)  !total soil application
    !  END DO
    !END DO


! ******************************************************************

  
   OUTPUT= 0.   
   DO i=1,NPLOTS

     start_compartment= ARG(i)
     end_compartment  = ARG2(i)
      
      !ID1 = 1
      !IF (chem_id(I) == 2) ID1 = 2
      !IF (chem_id(I) == 3) ID1 = 3

      DPTOT=0.0
      TTTOT=0.0

      IF ((MODE(i).EQ.TAVE).OR.(MODE(i).EQ.TSUM))THEN
          select case (PLNAME(i))
          case('SWTR')!   Water storages  (units of CM)
              do K =start_compartment,end_compartment
               
                    IF(MODE(I).EQ.TAVE)THEN
                      TTTOT= TTTOT+SoilWater(K)*DELX(K)
                    ELSE
                      TTTOT= TTTOT+SoilWater(K)
                    ENDIF
              end do
              PNBRN(I)=TTTOT
          !case('INFL')           !this doesnt make sense
          !    do K =start_compartment,end_compartment
          !       IF(MODE(I).EQ.TAVE)THEN
          !          TTTOT= TTTOT+AINF(K)*DELX(K) 
          !       ELSE
          !          TTTOT= TTTOT+AINF(K)
          !       ENDIF           
          !    end do                   
          !    PNBRN(I)=TTTOT       
          case('SLET') 
              do K =start_compartment,end_compartment
                 IF(MODE(I).EQ.TAVE)THEN
                   TTTOT= TTTOT+EvapoTran(K)*DELX(K)
                 ELSE
                   TTTOT= TTTOT+EvapoTran(K)
                 ENDIF
              end do
              PNBRN(I)=TTTOT
                   
          case('STMP')
              do K =start_compartment,end_compartment
                     IF(MODE(I).EQ.TAVE)THEN
                       TTTOT=TTTOT+soil_temp(K)*DELX(K)
                     ELSE
                       TTTOT=TTTOT+soil_temp(K)
                     ENDIF
              end do
              PNBRN(I)=TTTOT    
          case ('TPST')  !Pesticide storages (units of GRAMS/(CM**2)             
              DO K =start_compartment,end_compartment
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT=TTTOT + (conc_total_per_water(chem_id(i),K)*DELX(K)*theta_end(K))   *DELX(K)
                ELSE
                  TTTOT=TTTOT + (conc_total_per_water(chem_id(i),K)*DELX(K)*theta_end(K))        
                ENDIF
              END DO
              PNBRN(I)=TTTOT                      
          case('MASS')              
              DO K =start_compartment,end_compartment
                  IF(MODE(I).EQ.TAVE)THEN
                    TTTOT=TTTOT + mass_in_compartment(chem_id(i),K)
                  ELSE
                    TTTOT=TTTOT + mass_in_compartment(chem_id(i),K)                    
                  ENDIF
              END Do
              PNBRN(I)=TTTOT               
          case('MAS2' )             
              DO K =start_compartment,end_compartment
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT=TTTOT + mass_in_compartment2(chem_id(i),K)
                ELSE
                  TTTOT=TTTOT + mass_in_compartment2(chem_id(i),K)          
                ENDIF
              END DO
              PNBRN(I)=TTTOT                    
          case('SPST')             
              DO  K =start_compartment,end_compartment
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT=TTTOT+( conc_porewater(chem_id(i),K)*DELX(K)*theta_end(K))*DELX(K)
                ELSE
                  TTTOT=TTTOT+( conc_porewater(chem_id(i),K)*DELX(K)*theta_end(K))
                ENDIF
              end do
              PNBRN(I)=TTTOT                     
                                      
          case('DKFX')              
              DO K =start_compartment,end_compartment
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT= TTTOT+DKFLUX(chem_id(i),K)*DELX(K)
                ELSE
                  TTTOT= TTTOT+DKFLUX(chem_id(i),K)
                ENDIF
              end do
              PNBRN(I)=TTTOT                   
          case('UFLX')              
              DO K =start_compartment,end_compartment
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT= TTTOT+UPFLUX(chem_id(i),K)*DELX(K)
                ELSE
                  TTTOT= TTTOT+UPFLUX(chem_id(i),K)
                ENDIF
              end do
              PNBRN(I)=TTTOT                     
          case('DCON')             
              DO K =start_compartment,end_compartment
                  
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6)*DELX(K)
                ELSE
                  TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6)
                ENDIF
              end do         
              PNBRN(I)=TTTOT  
              
         case('AQFR')  !Aquifer
              DO K =start_compartment,end_compartment
                  
                IF(MODE(I).EQ.TAVE)THEN
                  TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6)*DELX(K)
                ELSE
                  TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6)
                ENDIF
              end do         
              PNBRN(I)=TTTOT    
              
       
              
          case('ACON')             
             DO K =start_compartment,end_compartment
               IF(MODE(I).EQ.TAVE)THEN
                 TTTOT= TTTOT+(( conc_porewater(chem_id(i),K)*1.E6)*kd_new(chem_id(i),K))*DELX(K)
               ELSE
                 TTTOT= TTTOT+(( conc_porewater(chem_id(i),K)*1.E6)*kd_new(chem_id(i),K))
               ENDIF
             end do            
             PNBRN(I)=TTTOT                                   
          case('GCON') 
             DO K =start_compartment,end_compartment
               IF(MODE(I).EQ.TAVE)THEN
                 TTTOT= TTTOT+((( conc_porewater(chem_id(i),K)*1.E6)*new_henry(chem_id(i),K)))*DELX(K)
               ELSE
                 TTTOT= TTTOT+((( conc_porewater(chem_id(i),K)*1.E6)*new_henry(chem_id(i),K)))
               ENDIF
             end do  
             PNBRN(I)=TTTOT                                       
          case('TCON')      
             do K =start_compartment,end_compartment
               IF(MODE(I).EQ.TAVE)THEN
                 TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6*theta_end(K)+           &
                                conc_porewater(chem_id(i),K)*1.E6*kd_new(chem_id(i),K)+   &
                                conc_porewater(chem_id(i),K)*1.E6*new_henry(chem_id(i),K)*(theta_sat(K)-theta_end(K)))*DELX(K)
               ELSE
                 TTTOT= TTTOT+( conc_porewater(chem_id(i),K)*1.E6*theta_end(K)+           &
                                conc_porewater(chem_id(i),K)*1.E6*kd_new(chem_id(i),K)+   &
                                conc_porewater(chem_id(i),K)*1.E6*new_henry(chem_id(i),K)*(theta_sat(K)-theta_end(K)))
               ENDIF
             end do
             PNBRN(I)=TTTOT        
          case default       
          end select
          
          
      ELSE  !DAILY TIME SERIES    

        !swtr with tser only gives time series for single point
        IF (PLNAME(I) == 'SWTR') PNBRN(I)= SoilWater(start_compartment)

        IF (PLNAME(I) == 'THET') PNBRN(I)= theta_end(start_compartment) ! Soil water storage (dimensionless)
        
!       Water fluxes (units of CM/DAY)

        IF (PLNAME(I) == 'PVOL') PNBRN(I)= AINF(start_compartment) !pore volume
        IF (PLNAME(I) == 'TPUT') PNBRN(I)= AINF(start_compartment) !throughput
        
        
        IF (PLNAME(I) == 'INFL') PNBRN(I)= AINF(start_compartment)
        IF (PLNAME(I) == 'SLET') PNBRN(I)= EvapoTran(start_compartment)
        IF (PLNAME(I) == 'STMP') PNBRN(I)= soil_temp(start_compartment)         !     Soil temperature (oC)
   
        ! Pesticide storages (units of GRAMS/(CM**2)
        IF (PLNAME(I) == 'TPST') PNBRN(I)= conc_total_per_water(chem_id(i),start_compartment)*   &
                                           DELX(start_compartment)*theta_end(start_compartment) 
        
        IF (PLNAME(I) == 'MASS') PNBRN(I)= mass_in_compartment(chem_id(i),start_compartment)
        IF (PLNAME(I) == 'SPST') PNBRN(I)= conc_porewater(chem_id(i),start_compartment)*   &
                                           theta_end(start_compartment)*DELX(start_compartment)
          
        !  Pesticide fluxes (units of GRAMS/(CM**2-DAY)
!        IF (PLNAME(I)=='DFLX') PNBRN(I)=DFFLUX(chem_id(i),start_compartment)
!        IF (PLNAME(I)=='AFLX') PNBRN(I)=ADFLUX(chem_id(i),start_compartment)
        IF (PLNAME(I)=='DKFX') PNBRN(I)=DKFLUX(chem_id(i),start_compartment)
        IF (PLNAME(I)=='UFLX') PNBRN(I)=UPFLUX(chem_id(i),start_compartment)

        IF (PLNAME(I)=='DCON') then
            PNBRN(I)=conc_porewater(chem_id(i),start_compartment)*1.E6     
        end if
        
        
        IF (PLNAME(I)=='ACON') PNBRN(I)=conc_porewater(chem_id(i),start_compartment)*1.E6 *kd_new(chem_id(i),start_compartment)
        IF (PLNAME(I)=='GCON') PNBRN(I)=conc_porewater(chem_id(i),start_compartment)*1.E6*new_henry(chem_id(i),start_compartment)
        
        IF (PLNAME(I)=='TCON') PNBRN(I)=conc_porewater(chem_id(i),start_compartment)*1.E6*theta_end(start_compartment)+ &
                                        conc_porewater(chem_id(i),start_compartment)*1.E6*kd_new(chem_id(i),start_compartment)+  &
                                        conc_porewater(chem_id(i),start_compartment)*1.E6*new_henry(chem_id(i),start_compartment)* &
                                        (theta_sat(start_compartment)-theta_end(start_compartment))
      ENDIF   
        
      ! Water storages  (units of CM)
      IF (PLNAME(I) .EQ. 'INTS') PNBRN(I)= CINT
      IF (PLNAME(I) .EQ. 'SNOP') PNBRN(I)= SNOW
      
      ! Water fluxes (units of CM/DAY)
      IF (PLNAME(I) .EQ. 'PRCP') PNBRN(I)= precipitation
      IF (PLNAME(I) .EQ. 'IRRG') PNBRN(I)= IRRR
      IF (PLNAME(I) .EQ. 'SNOF') PNBRN(I)= SNOWFL
      IF (PLNAME(I) .EQ. 'THRF') PNBRN(I)= THRUFL
      IF (PLNAME(I) .EQ. 'RUNF') PNBRN(I)= runoff_on_day
        
      IF (PLNAME(I) .EQ. 'CEVP') PNBRN(I)= CEVAP
      IF (PLNAME(I) .EQ. 'TETD') PNBRN(I)= TDET
      
      IF (PLNAME(I) .EQ. 'CURV') PNBRN(I)= curve_number_daily
      IF (PLNAME(I) .EQ. 'ESLS') PNBRN(I)= SEDL      ! Sediment flux (metric tons)
      IF (PLNAME(I) .EQ. 'CHGT') PNBRN(I)= HEIGHT    !  Crop height (CM)
      
      !  Pesticide storages (units of GRAMS/(CM**2)
      IF (PLNAME(I) .EQ. 'FPST') PNBRN(I)=FOLPST(chem_id(i))
      IF (PLNAME(I) .EQ. 'PCNC') PNBRN(I)=TCNC(chem_id(i))
      IF (PLNAME(I) .EQ. 'TPAP') PNBRN(I)= onSOIL(chem_id(i)) + plant_app       
      
      IF (PLNAME(I) .EQ. 'FPDL') PNBRN(I)= Foliar_degrade_loss(chem_id(i))
      IF (PLNAME(I) .EQ. 'WFLX') PNBRN(I)= WOFLUX(chem_id(i))
      IF (PLNAME(I) .EQ. 'RFLX') PNBRN(I)= ROFLUX(chem_id(i))
      IF (PLNAME(I) .EQ. 'EFLX') PNBRN(I)= ERFLUX(chem_id(i))

      IF (PLNAME(I) .EQ. 'TUPX') PNBRN(I)= SUPFLX(chem_id(i))
      IF (PLNAME(I) .EQ. 'TDKF') PNBRN(I)= SDKFLX(chem_id(i))
      IF (PLNAME(I) .EQ. 'COFX') PNBRN(I)= DCOFLX(chem_id(i))
      
      ! Add VFLX option to plot PVFLUX
      IF (PLNAME(I) .EQ. 'VFLX') PNBRN(I)= -PVFLUX(chem_id(i),1)
      IF (PLNAME(I) .EQ. 'FPVL') PNBRN(I)= Foliar_volatile_loss(chem_id(i))
      
      !Change units of output using user supplied constant
      RMULT= CONST(I)
      
      PNBRN(I)= PNBRN(I)* RMULT 
      
      IF((MODE(I).EQ.TSER).OR.(MODE(I).EQ.TSUM))THEN
          OUTPUT(I)= PNBRN(I)
      ELSEIF (MODE(I).EQ.TCUM) THEN          !            Accumulate output variable if a cumulative plot is requested
          OUTPUJ(I)= OUTPUT(I) + PNBRN(I)
          OUTPJJ(I)= OUTPJJ(I) + OUTPUJ(I)
      ELSEIF(MODE(I).EQ.TAVE)THEN 
          DO   K=start_compartment,end_compartment           !Accumulate Total Depth for use in depth weighted average
             DPTOT=DPTOT+DELX(K)
          end do
            OUTPUT(I)=PNBRN(I)/DPTOT
      ENDIF
           
        IF ((MODE(I).EQ.TSER).OR.(MODE(I).EQ.TSUM).OR.(MODE(I).EQ.TAVE))PRTBUF(i)= OUTPUT(I)
        IF (MODE(I).EQ.TCUM) PRTBUF(i)= OUTPJJ(I)

   end do
    
   call get_date(julday1900, current_year,current_month,current_day)
  

   
   WRITE(TimeSeriesUnit2,'(I4,I3,I3, 4X,100(2X,ES12.4E3))') current_year,current_month,current_day,(PRTBUF(I),I=1,NPLOTS)  
!         !E3 format cuz program was leaving out the "E" on number <  E-99
!18       FORMAT (I4,I3,I3, 4X,100(2X,ES12.4E3))  

  END SUBROUTINE write_outputfile_2
	
end Module Output_From_Field
      
	
	
	
	
	
	
	
	
	
    
    
    
    
  !NOT Sure what this output was, it was undocumented  
                     
   ! IF (PLNAME(I) .EQ. DLYS)THEN                    
                     !SPTOT=0.0
                     !NUMCOM=(IARG3-IARG1)+1
                     !DELTOT=DELX(IARG1)*NUMCOM
                     !IF(MOD(NUMCOM,2).EQ.0)THEN
                     !  SPSTRT=((DELTOT/2.0)-(DELX(IARG1)/2.0))/2.5
                     !  IF(SPSTRT.LT.1.0)SPSTRT=1.0
                     !  MIDCOM1=(IARG1+IARG3)/2
                     !  MIDCOM2=MIDCOM1+1
                     !ELSE
                     !  SPSTRT=((DELTOT/2.0)/2.5)
                     !  IF(SPSTRT.LT.1.0)SPSTRT=1.0
                     !  MIDCOM1=(IARG1+IARG3)/2
                     !  MIDCOM2=MIDCOM1
                     !ENDIF
                     !DO K=IARG1,IARG3
                     !  SPWGHT=(2.0/((SPSTRT**2)+1.0))
                     !  TTTOT= TTTOT+((conc_porewater(ID1,K)*1.E6)*SPWGHT)
                     !  SPTOT=SPTOT+SPWGHT
                     !  IF(((K.LT.MIDCOM1).OR.(K.LT.MIDCOM2)).AND.((DELX(K)/2.5).GE.2.0))THEN
                     !    SPSTRT=(DELX(K)/2.5)/2.0
                     !  ELSEIF(((K.LT.MIDCOM1).OR.(K.LT.MIDCOM2)).AND.((DELX(K)/2.5).LT.2.0))THEN
                     !    SPSTRT=1.0
                     !  ELSEIF(((K.EQ.MIDCOM1).OR.(K.EQ.MIDCOM2)).AND.((DELX(K)/2.5).GE.2.0))THEN
                     !    SPSTRT=(DELX(K)/2.5)/2.0
                     !  ELSEIF(((K.EQ.MIDCOM1).OR.(K.EQ.MIDCOM2)).AND.((DELX(K)/2.5).LT.2.0))THEN
                     !    SPSTRT=1.0
                     !  ELSEIF(((K.GT.MIDCOM1).OR.(K.GT.MIDCOM2)).AND.((DELX(K)/2.5).GE.2.0))THEN
                     !    SPSTRT=SPSTRT+(DELX(K)/2.5)
                     !  ELSEIF(((K.GT.MIDCOM1).OR.(K.GT.MIDCOM2)).AND.((DELX(K)/2.5).LT.2.0))THEN
                     !    SPSTRT=1.0
                     !  ENDIF
                     !end do                 
                     !PNBRN(I)=TTTOT     
                 !ELSEIF (PLNAME(I) .EQ. CMSS)THEN    !cmss is not documented      
                 !    CMDPTH=0.0
                 !    DO K=IARG1,IARG3
                 !      TTTOT=TTTOT+(conc_total_per_water(ID1,K)*DELX(K)*theta_end(K))*DELX(K)
                 !    end do
                 !    CMTOT=0.0
                 !    CMSS1=TTTOT/2.
                 !    TTTOT=0.0
                 !    DO K=IARG1,IARG3
                 !      CMTOT=CMTOT+DELX(K)
                 !      TTTOT=TTTOT+(conc_total_per_water(ID1,K)*DELX(K)*theta_end(K))*DELX(K)
                 !      IF(TTTOT.EQ.0.0)THEN
                 !        CMDPTH=0.0
                 !      ELSEIF(TTTOT.LE.CMSS1)THEN
                 !        CMDPTH=CMTOT
                 !      ENDIF
                 !    end do
                 !    PNBRN(I)=CMDPTH
                 !ELSEIF (PLNAME(I) .EQ. INCS)THEN   !INCS is not documented       
                 !    TTTOT=0.0
                 !    CMTOT=0.0
                 !    CMDPTH=0.0                 
                 !    do  K=IARG1,IARG3
                 !      CMTOT=CMTOT+DELX(K)
                 !      TTTOT=(conc_total_per_water(ID1,K)*DELX(K)*theta_end(K))*DELX(K)
                 !      IF(TTTOT.GT.CONST(I))CMDPTH=CMTOT              !the use of CONST doesnt make sence to me here
                 !    end do                  
                 !    PNBRN(I)=CMDPTH
                 !ENDIF  