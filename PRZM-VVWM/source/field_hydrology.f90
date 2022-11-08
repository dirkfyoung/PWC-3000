module field_hydrology
    implicit none
	contains
	
	subroutine hydrology_only
	use constants_and_Variables, ONLY:precip, pet_evap,air_temperature ,wind_speed, solar_radiation, &
                                  precipitation,PEVP,air_TEMP,WIND, SOLRAD ,harvest_day, &
                                  startday, num_records,is_harvest_day,canopy_holdup, &
                                  canopy_height, canopy_cover  , cover, height, harvest_placement, &
                                  potential_canopy_holdup,evapo_root_node_daily, &
                                  evapo_root_node,root_node ,root_node_daily, julday1900 ,startday
	  integer :: i
      julday1900 = startday

	   do i=1, num_records

	        precipitation           = precip(i) 
            PEVP                    = pet_evap(i)
	        air_TEMP                = air_temperature(i)
	        WIND                    = wind_speed(i)
            SOLRAD                  = solar_radiation(i)
	        cover                   = canopy_cover(i)  
	        height                  = canopy_height(i) 
	        potential_canopy_holdup = canopy_holdup(i)
            evapo_root_node_daily   = evapo_root_node(i)
            root_node_daily         = root_node(i)       !only needed for irrigation

			call runoff_leaching_and_heat(i)
			
			julday1900 = julday1900  +1
	   end do
	   

	   
	end subroutine hydrology_only
	
    !*******************************************************************************************************
    SUBROUTINE runoff_leaching_and_heat(day)
	use constants_and_Variables, ONLY: is_temperature_simulated,soil_temp, is_nonequilibrium,              & 
        THRUFL,really_not_thrufl,COVER, USLEC,cfac,theta_end,bulkdensity,runoff_on_day,  & 
        ainf,juslec,nuslec,ncom2,sedl,CN_index, under_canopy_irrig,over_canopy_irrig,julday1900, &
        use_usleyears,enriched_eroded_solids,delx,theta_zero, delt,harvest_day, mass_in_compartment, irtype,is_timeseriesfile, irrigation_save

    use Temperatue_Calcs
    use Output_From_Field
    use erosion
    use utilities_1

    use plant_pesticide_processes
    implicit none
    integer, intent(in) :: day !day tracker
	
    integer  :: I,K, J
    integer  :: julday                   !this is the day of the year starting with Jan 1
    integer  :: current_year, current_month, current_day    

    real     :: theta_new_subday(NCOM2)
    real     :: theta_old_subday(NCOM2)
    real     :: delta_watercontent(NCOM2)  !local water contents for use with subdaily time steps
    real     :: theta_air_new_subday(NCOM2)
    real     :: theta_air_old_subday(NCOM2)
    real     :: delta_aircontent(NCOM2)    !local water contents for use with subdaily time steps  

    !************************************************************************************************
    AINF   = 0.0
    THRUFL = 0.0
    really_not_thrufl = .FALSE.
 

	
   !**********IRRIGATION ************************ 
   IF (irtype > 0  .AND. cover > 0.0) then  !irrigate if there is a crop
      CALL irrigation(day)
   else										!no irrigation
      under_canopy_irrig = 0.0
      over_canopy_irrig = 0.0
      irrigation_save(day) = 0.0               
   end if

   !this version of julian day is needed for the curve number and erosion routines
   call get_date (julday1900, current_year, current_month, current_day) 
   julday = julday1900 -jd(current_year,1,1) +1
   

   
   if (use_usleyears) then
      do i = 1, nuslec
         if (julday1900  ==juslec(i))then
             cfac=USLEC(i)
             CN_index = i  !this is used for curve number
             exit
         end if
      end do       
   else     
      do i = 1, nuslec
         if (julday ==juslec(i))then
           cfac=USLEC(i)
           CN_index = i  !this is used for curve number
           exit
         end if
      end do
   end if



       Call Runoff_cn(day) 
       CALL EVPOTR(day)				 !EVAPORATION 
       CALL Leaching(day)        !determine water content of soil and air content (old and new)
       CALL EROSN(day, JULDAY)  !calc loss of chem due to erosion


   
        ! ****** Soil Temperature Calculations ************** 
       IF (is_temperature_simulated) CALL SLTEMP()                         

	END Subroutine runoff_leaching_and_heat
	

	
	!********************************************************************************************************
    SUBROUTINE EVPOTR(day)
      use  constants_and_Variables, ONLY:  air_TEMP, pfac,sttdet ,PEVP, &
           wiltpoint_water,fieldcap_water,soilwater,cint,EvapoTran,DELX,cevap,evapo_root_node_daily,TDET , et_save

      implicit none
!     Computes daily potential evapotranspiration,
!     canopy evaporation, and actual evapotranspiration from each
!     soil layer.
      ! New version with Houbau's correction
      integer, intent(in) :: day
      REAL ::      FRAC(evapo_root_node_daily), DEP(evapo_root_node_daily) !!!add DEP() as the depth of each compartment (top)!!!
      REAL         PET,PETP,ANUM,DENOM,AW,TSW
      Real         TWP,TFRAC,STDELX,EDEPTH, depth, DEPtotal !!!add depth to calculate top of each compartment, DEPtotal to calculate sum of DEP()!!!
      INTEGER      ITEMP,I

!     Compute potential evapotranspiration

      ITEMP= INT(air_TEMP)
      IF (ITEMP.LT.1)  ITEMP= 1
      IF (ITEMP.GT.40) ITEMP= 40
      
      PET= PEVP*PFAC
      
!     Subtract canopy evaporation from potential evapotranspiration

      PETP= AMAX1(0.0,PET-CINT)
      
      IF (PET .GT. CINT) THEN
        CEVAP= CINT
      ELSE
        CEVAP= PET
      ENDIF
      CINT= CINT-CEVAP

!     Compute evapotranspiration from each soil layer
      EDEPTH = 5.0
      STDELX = delx(1)
      STTDET = 0.0

      TDET = 0.0
      EvapoTran= 0.0
      ANUM = 0.0
      DENOM= 0.0
      FRAC = 0.0
  
      do I= 1, evapo_root_node_daily
        ANUM = ANUM  + AMAX1(0.0,soilwater(I)- wiltpoint_water(I))
        DENOM= DENOM + AMAX1(0.0,fieldcap_water(I)- wiltpoint_water(I))
      end do
      


      AW   = ANUM/DENOM
      IF (AW.LT.0.6) PETP= AW*PETP/0.6
      TSW  = 0.0
      TWP  = 0.0
      DEPtotal = 0.0  !!! initial DEPtotal !!!
      depth = 0.0     !!! initial depth !!!
      
      do I= 1, evapo_root_node_daily 
        DEP(I) = depth               !!! DEP(I) calculation !!!
        DEPtotal = DEPtotal + DEP(I) !!! DEP calculation !!!
        TSW  = TSW + SoilWater(I)
        TWP  = TWP + wiltpoint_water(I)
        depth = depth + DELX(I)      !!! depth calculation !!!
      end do   

      IF ((evapo_root_node_daily*depth-DEPtotal) .GT. 0.00 .AND. TSW .GT. TWP) THEN
        TFRAC= 0.0        
        do I= 1, evapo_root_node_daily
          FRAC(I)=(DEP(I)-depth)/(DEPtotal - evapo_root_node_daily*depth)*(SoilWater(I)-wiltpoint_water(I))/(TSW-TWP)  !!! depth related FRAC calculation !!!
          TFRAC  =TFRAC + FRAC(I)
        end do
!###########################################################################################################################################################
           
        
        
        DO  I = 1, evapo_root_node_daily
          EvapoTran(I) = AMIN1((SoilWater(I)-wiltpoint_water(I)),PETP*FRAC(I)/TFRAC)
          EvapoTran(I) = AMAX1(EvapoTran(I),0.0)
          
          TDET  = TDET + EvapoTran(I)  !used to save ET output
		  
!         This code is added by C.S.Raju to estimate the evaporation through the top 5cm depth of soil.
          IF (STDELX .LE. EDEPTH)THEN
            STTDET = STTDET + EvapoTran(I)  !used in temperature routine
            STDELX = STDELX + DELX(I)
          END IF
        end do
      ENDIF
      
      et_save(day) = tdet

          
    END SUBROUTINE EVPOTR	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
!***********************************************************************************************	
SUBROUTINE irrigation(day)
!     determines soil moisture deficit, decides if  irrigation is needed, and calculates irrigation depths.

      use  constants_and_Variables, ONLY: precipitation, really_not_thrufl,IRTYPE,PCDEPL,max_irrig,FLEACH, &
           cint,DELX,theta_end,theta_fc,theta_wp,potential_canopy_holdup,root_node_daily, &
           under_canopy_irrig, over_canopy_irrig, UserSpecifiesDepth,user_irrig_depth_node,irrigation_save
      
      implicit none

	  integer, intent(in) :: day
      REAL     :: SMCRIT,SMAVG,FCAVG,SMDEF
      INTEGER  :: I
      integer  :: local_irrigation_node
      
      SMDEF = 0.0
      really_not_thrufl = .FALSE.
!     compute average soil moisture and porosity for root zone

! SMCRIT -- soil moisture level where irrigation begins (fraction).
! SMAVG  -- average root zone soil moisture level (fraction).
! FCAVG  -- average root zone field capacity (fraction).
!
! PCDEPL -- fraction of available water capacity at which irrigation is applied.
!           Usually ~0.45 – 0.55; PRZM accepts values between 0.0 and 0.9
!
! THEFC --  field capacity in the horizon (cm3 cm^-3).
! THEWP --  wilting point in the horizon (cm3 cm^-3).
! THETN --  (cm3 cm^-3) soil water content at the end of the current day for
!           each soil compartment. Note: the water content above the wilting
!           point (ThetN - TheWP) represents the water available to the crop.

! Maximum available soil water:  TheFC - TheWP
! Critical Water Fraction, below which irrigation occurs:  PCDEPL*(TheFC - TheWP)
! Today's available water: Thetn - TheWP
! Therefore, irrigate if: Thetn - TheWP < PCDEPL*(TheFC - TheWP)
!                   i.e., Thetn < PCDEPL*(TheFC - TheWP) + TheWP
!
! From Dirk Young/DC/USEPA/US 10/20/04 12:08 PM
! THETN is actually the begining day water content at this point
! in the program because the call to IRRIG occurs before the
! hydrologic updates in HYDR1. Thus in the IRRIG routine, the
! definition of THETN is contrary to the manual's definition.
!
! See also comments in subroutine iniacc.


      SMCRIT = 0.0
      SMAVG = 0.0
      FCAVG = 0.0
      
      if (UserSpecifiesDepth) then
           local_irrigation_node = user_irrig_depth_node 
      else
           local_irrigation_node = root_node_daily
      end if
 
      DO I=1,local_irrigation_node
         SMCRIT = SMCRIT + (PCDEPL*(theta_fc(i)-theta_wp(I))+theta_wp(I))*delx(i)
         SMDEF = SMDEF+(theta_fc(i)-theta_end(I))*(1.0 + FLEACH)*DELX(I)
         ! dfy note SMDEF is not the soil moisture deficit, but deficit + salt leaching requirements
         ! not as defined in equation 6-89
      ENDDO

      under_canopy_irrig = 0.0
      over_canopy_irrig = 0.0
      
      IF((Sum(theta_end(1:local_irrigation_node)*delx(1:local_irrigation_node)) > SMCRIT) .OR. precipitation > 0.0) THEN
          irrigation_save(day) = 0.0
          return !no irrigation needed
      end if
      
     
     select case (irtype)
      case (1) !Over-Canopy Sprinkler Irrigation;  irrigation applied above the canopy as precipitation 
         !Din is the max holdup possible on the canopy,cint is any water that is on the canopy.  
         !The difference is what is needed to supply canopy demand during overhead irrig
         !Cint is the start-of-day value     
         over_canopy_irrig = MIN(max_irrig , SMDEF + potential_canopy_holdup -CINT)   
         irrigation_save(day) = over_canopy_irrig
      case (2)
          
      !Under-Canopy Sprinkler Irrigation; irrigation applied as under-canopy throughfall    
         under_canopy_irrig = MIN(max_irrig , SMDEF)
         irrigation_save(day)=under_canopy_irrig    
      case default
        over_canopy_irrig = 0.0
        irrigation_save(day) = 0.0
      end select
END SUBROUTINE Irrigation
!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!	


!*****************************************************************************************
SUBROUTINE Runoff_cn(day)
    !PRZM5: Calculate runoff first and then using any left over for the canopy & infiltration 
    !In conformance to NEH-4, initial abstraction is no longer altered by canopy
    
      use constants_and_Variables, ONLY: precipitation, precip_rain, air_TEMP,sfac,snowfl,THRUFL, &
        cint,smelt,runoff_on_day, curve_number_daily,ainf,potential_canopy_holdup,snow, &
        under_canopy_irrig, over_canopy_irrig,  canopy_flow_save, &
        effective_rain , julday1900, data_date,  &
        SoilWater,cn_moist_node,soil_depth,cn_moisture, runoff_save
        
      implicit none
!     This subroutine calculates snowmelt, crop interception, runoff, and infiltration from the soil surface
      integer, intent(in) :: day
      REAL   CURVN

      real :: canopy_capture

      runoff_on_day = 0.0
      SMELT = 0.0
      SNOWFL= 0.0
      effective_rain = 0.0
      canopy_flow_save(day) = 0.0
      precip_rain = precipitation 

      !Is sfac/0 uneccessary flag? perhaps a nonintuitive flag, zero causes problems if not here. 
      !I think  very low sfac would cause problems as well..check on this later
      IF (SFAC .GT. 0.0) THEN      
!       Compute snowmelt and accumulation
        IF (air_TEMP .LE. 0.0) THEN
              precip_rain  = 0.0              !this is now rain only  
              SNOWFL       = precipitation    
              SNOW         = SNOW + SNOWFL
        ELSE
              precip_rain = precipitation     !this is now rain only
              SMELT       = AMIN1(SFAC*air_TEMP,SNOW)
              SNOW        = SNOW- SMELT
        ENDIF
      ENDIF

      effective_rain  = under_canopy_irrig + over_canopy_irrig + precip_rain + smelt  !used for runoff calc only  (canopy not included)
          
      call Curve_Number_Adjustment(curvn)
	  

      call Calculate_Runoff_PRZM5(curvn,Effective_Rain)

      !Here runoff has preference since according to CN method canopy would already be accounted for:
      canopy_capture = min(potential_canopy_holdup-CINT, (precip_rain + over_canopy_irrig - runoff_on_day)  )
      canopy_capture = max (0.0, canopy_capture) !for under canopy irrigation the above could be negative
     
      cint   = cint + canopy_capture
	  
	  !cint is not well defrined after harvest, but impact is trivial. After harvest there is still cint water, 
	  !but it evaporates in a few days under normal evapo values. If PET is zero,
	  !then it will linger at max value for the entire simulation regardless of crop presence--has insignificant impact
	  !but it could be added to soil at harvest if you want to get picky
	
	  
	  !Capture this in an array
      canopy_flow_save(day) = max (0.0, over_canopy_irrig + precip_rain -canopy_capture ) !used for pesticide washoff calcs
     	  
	  
	  
      !Thrufl is now only the amount of water actually hitting the ground  used for erosion calcs
      !Might need rethinkin to remove canopy if already accounted for in C factors
      !used effective rain for time of conc in erosion routine
      THRUFL = over_canopy_irrig + precip_rain -canopy_capture + under_canopy_irrig
 
      ! Compute infiltration for first soil compartment
      AINF(1) = AINF(1) + Effective_Rain- runoff_on_day -canopy_capture
	 
      curve_number_daily = CURVN  !store curve number for later output display          
      runoff_save(day)=runoff_on_day


    END SUBROUTINE Runoff_cn




    !****************************************************************************************** 
    Subroutine Curve_Number_Adjustment(curvn)
    !moisture adjustments to the curve number
    !CN_index is determined based on the julian day and sets the curve number until the next change
    !Nov 5 2014, dfy changed curve number 2 to a real number and allowed interpolation between whole curve numbers   
    
        use constants_and_Variables, ONLY:CN_moisture_ref, CN_index, CN_2, SoilWater,cn_moist_node,ADJUST_CN,soil_depth
        use curve_number_table
        implicit none
        real,intent(out) :: curvn
        integer :: i
        
        real :: curve_number1, curve_number2,curve_number3, twlvl
  
        IF (ADJUST_CN) then
            !Water amount in top 10 cm used for CN manipulation
            TWLVL = sum(SoilWater(1:cn_moist_node)) / soil_depth(cn_moist_node)  !average water content per depth in top 10 cm

            !Interpolation
            i= int (CN_2(CN_index)) !integer portion of CN_2
            curve_number2  =  CN_2(CN_index)
            curve_number1  =  cn_1(i) + (curve_number2- int(curve_number2)) *(cn_1(i+1)-cn_1(i))
            curve_number3  =  cn_3(i) + (curve_number2- int(curve_number2)) *(cn_3(i+1)-cn_3(i))   
            CURVN = curve_number2 + (curve_number3 -  curve_number2) *  (TWLVL-CN_moisture_ref)/ CN_moisture_ref       
            if (twlvl < CN_moisture_ref ) CURVN = curve_number1  + (curve_number2 - curve_number1)* twlvl/CN_moisture_ref
    
        else
            CURVN =  CN_2(CN_index)
        end if
               
     
    End Subroutine Curve_Number_Adjustment
    
     
  
    !****************************************************************rf*************************
    Subroutine Calculate_Runoff_PRZM5(curvn,Effective_Rain)
       use constants_and_Variables, ONLY:runoff_on_day,inabs
       implicit none
       real, intent(in) :: curvn
       real,intent(in)  :: Effective_Rain
    
       !the constant 0.508 is derived from 0.2 * 2.54 cm/in and 0.2 is from INABS = 0.2 * S, where S is (1000./CURVN-10.).
       !INABS: Initial Abstraction INABS = AMAX1(0.508* (1000./CURVN-10.),PRECIP-THRUFL)
       !The Original NRCS Curve Number method already accounts for canopy holdup.  -DFY

       INABS = 0.508* (1000./CURVN-10.)  !also used in erosion calculation
       IF (Effective_Rain .GT. INABS) then
           runoff_on_day= (Effective_Rain-INABS)**2/ (Effective_Rain + (4.0* INABS))  !OK the 4 is from 0.8 = 4 * 0.2
       else 
           runoff_on_day = 0.0
	   end if

    end  Subroutine Calculate_Runoff_PRZM5  
     
     

    !**************************************************************************************************
    SUBROUTINE Leaching(day)
    use constants_and_Variables, ONLY: soilwater,EvapoTran,theta_zero,DELX,theta_end,ainf,ncom2, & 
         vel, thair_old, THAIR_new,theta_sat,theta_fc, &
		THAIR_save,theta_end_save,soilwater_save, velocity_save,theta_zero_save, thair_old_save, infiltration_save, xx
	
        implicit none
        !Performs hydraulic calculations assuming a uniform soil profile with unrestricted drainage
        !(drainage occurs instantaneously)
        !Also calculates the Air space at start and end of time step
        integer, intent(in) :: day
        INTEGER      I

        do I=1,NCOM2
            theta_zero(I) = soilwater(I)/DELX(I)
            theta_end(I) = (soilwater(I)+ AINF(I)- EvapoTran(I))/ DELX(I)
            AINF(I+1)= 0.0
			

            IF (theta_end(I) .GT. theta_fc(I)) THEN
				!AINF(I+1)= (theta_end(I)- theta_fc(I))* DELX(I) ! reformulated below to get rig of some nymrical precission issues
               AINF(I+1)= theta_end(I)* DELX(I)- theta_fc(I)* DELX(I)
                theta_end(I) = theta_fc(I)
			ENDIF


			
			
            VEL(I)= AINF(I+1)/theta_end(I)
            soilwater(I) = theta_end(I)*DELX(I)
		end do	

		
        !***** Calculate Air space and gas diffusion coefficient
        thair_old = theta_sat - theta_zero
        where (thair_old < 0.0) thair_old = 0.0
        
        THAIR_new = theta_sat - theta_end
        where (THAIR_new < 0.0) THAIR_new = 0.0
		
		
		theta_end_save(:,day) = theta_end(:)
		velocity_save(:,day) = vel(:)		
		THAIR_save(:,day) =  THAIR_new(:)
        soilwater_save(:,day) = soilwater(:)
		theta_zero_save(:,day) = theta_zero(:)
		thair_old_save(:,day) =  thair_old(:)
		infiltration_save(:,day) = ainf(:)
		

    END SUBROUTINE Leaching
    




	
end module field_hydrology