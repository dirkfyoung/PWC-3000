module allocations
    implicit none
    
    
    
    contains
    
     subroutine allocate_time_series
     use constants_and_variables, ONLY:num_records, runoff_series,erosion_series,parent_runoff_series,parent_erosion_series,daughter_runoff_series,&
                                       daughter_erosion_series,granddaughter_runoff_series,granddaughter_erosion_series
      allocate (runoff_series(num_records))
      allocate (erosion_series(num_records))            
      allocate (parent_runoff_series(num_records))
      allocate (parent_erosion_series(num_records))
      allocate (daughter_runoff_series(num_records))
      allocate (daughter_erosion_series(num_records))
      allocate (granddaughter_runoff_series(num_records))
      allocate (granddaughter_erosion_series(num_records))
    end subroutine allocate_time_series
    
    
    
    
    
    subroutine allocate_soil_compartments
    use constants_and_variables, ONLY: ncom2,soil_depth,wiltpoint_water,fieldcap_water,delx,bulkdensity,clay,sand,orgcarb,theta_zero, &
        theta_end,theta_sat, theta_fc, theta_wp,soil_temp,soilwater, dwrate, dsrate, dgrate, dwrate_atRefTemp,dsrate_atRefTemp,dgrate_atRefTemp,  &
        MolarConvert_aq12, MolarConvert_aq13, MolarConvert_aq23, MolarConvert_s12 ,MolarConvert_s13 , MolarConvert_s23 ,dispersion,thair_old,thair_new,  &
        Kd_new,Kd_old, k_freundlich,  N_freundlich, k_freundlich_2, N_freundlich_2, conc_total_per_water, &
        mass_in_compartment,mass_in_compartment2, &
        conc_porewater,sorbed2,Kd_2, ainf, vel, &
        EvapoTran,GAMMA1,new_henry,old_Henry,runoff_intensity, erosion_intensity,soilap, nchem,  &
        DKFLUX,SRCFLX,PVFLUX,UPFLUX,DFFLUX,ADFLUX, dgair, soil_applied_washoff
    
    
        allocate (soil_depth(ncom2))
        allocate (wiltpoint_water(ncom2))
        allocate (fieldcap_water(ncom2))
        allocate (bulkdensity(ncom2))
        allocate (delx(ncom2))
        allocate (clay(ncom2))
        allocate (sand(ncom2))
        allocate (orgcarb(ncom2))
        allocate (theta_zero(ncom2))
        allocate (theta_end(ncom2))
        allocate (theta_sat(ncom2))
        allocate (theta_fc(ncom2))
        allocate (theta_wp(ncom2))
        allocate (soil_temp(ncom2))
        allocate (soilwater(ncom2))
              
        allocate (dwrate(nchem,ncom2))
        allocate (dsrate(nchem,ncom2)) 
        allocate (dgrate(nchem,ncom2))
        allocate (dwrate_atRefTemp(nchem,ncom2))
        allocate (dsrate_atRefTemp(nchem,ncom2))
        allocate (dgrate_atRefTemp(nchem,ncom2))
        
        allocate (MolarConvert_aq12(ncom2))
        allocate (MolarConvert_aq13(ncom2))
        allocate (MolarConvert_aq23(ncom2))
        allocate (MolarConvert_s12 (ncom2))
        allocate (MolarConvert_s13 (ncom2))
        allocate (MolarConvert_s23 (ncom2))
        
        allocate (Kd_new(nchem,ncom2))
        allocate (Kd_old(nchem,ncom2))
        
        allocate (k_freundlich(nchem,ncom2))
        allocate (N_freundlich(nchem,ncom2))
        
        allocate (k_freundlich_2(nchem,ncom2))
        allocate (N_freundlich_2(nchem,ncom2))        
              
        allocate (conc_porewater      (nchem,ncom2))
        allocate (conc_total_per_water(nchem,ncom2))
        allocate (mass_in_compartment (nchem,ncom2))
        allocate (mass_in_compartment2(nchem,ncom2))   
         
        allocate (Sorbed2(nchem,ncom2))
        allocate (Kd_2   (nchem,ncom2))      !Effective linearized Kd for nonequiliobrium compartment

        allocate (GAMMA1 (nchem,ncom2))  
  
        allocate (dispersion(ncom2))
       
        allocate (thair_old(ncom2))
        allocate (thair_new(ncom2))
       
        allocate (DGAIR(ncom2))
             
        allocate (ainf(ncom2+1))  ! need extra compartment to hold final leaching amount (ainf is leaching INTO compartment)
        allocate (vel(ncom2))
        allocate (EvapoTran(ncom2)) 
       
        allocate (new_henry(nchem,ncom2))  
        allocate (old_Henry(nchem,ncom2))  
         
        allocate (runoff_intensity(ncom2))
        allocate (erosion_intensity(ncom2))
           
        allocate (soilap(nchem,ncom2)) 
        
        allocate (DKFLUX(nchem,ncom2)) 
       
        allocate (PVFLUX(nchem,ncom2)) 
        allocate (UPFLUX(nchem,ncom2)) 
        allocate (DFFLUX(nchem,ncom2)) 
        allocate (ADFLUX(nchem,ncom2)) 
        allocate (SRCFLX(3,ncom2))    !this one needs to be 3 becuz parent can produces 2 degradates   
         
        allocate (soil_applied_washoff(nchem,ncom2))   !plant washoff pesticide 
        
    end subroutine allocate_soil_compartments
    
    
    
    
       subroutine  deallocate_scenario_parameters
        use constants_and_variables, ONLY: emergence_date ,maturity_date,harvest_date ,&
        precip,pet_evap,air_temperature,wind_speed,solar_radiation,&
       runoff_series,erosion_series,parent_runoff_series,parent_erosion_series,daughter_runoff_series,&
        daughter_erosion_series,granddaughter_runoff_series,granddaughter_erosion_series,     &
        soil_depth,wiltpoint_water,fieldcap_water,delx,bulkdensity,clay,sand,orgcarb,theta_zero, &
        theta_end,theta_sat, theta_fc, theta_wp,soil_temp,soilwater, dwrate, dsrate, dgrate, dwrate_atRefTemp,dsrate_atRefTemp,dgrate_atRefTemp,  &
        MolarConvert_aq12, MolarConvert_aq13, MolarConvert_aq23, MolarConvert_s12 ,MolarConvert_s13 , MolarConvert_s23 ,dispersion,thair_old,thair_new,  &
        Kd_new,Kd_old, k_freundlich,  N_freundlich, k_freundlich_2, N_freundlich_2, conc_total_per_water, &
        mass_in_compartment,mass_in_compartment2, &
        conc_porewater,sorbed2,Kd_2, ainf, vel, &
        EvapoTran,GAMMA1,new_henry,old_Henry,runoff_intensity, erosion_intensity,soilap,  &
        DKFLUX,SRCFLX,PVFLUX,UPFLUX,DFFLUX,ADFLUX, dgair, soil_applied_washoff,&
        application_date, pest_app_method, DEPI,TAPP,APPEFF,Tband_top,drift_kg_per_m2,&
        crop_fraction_of_max,canopy_cover,canopy_height,canopy_holdup,is_harvest_day,&      
        evapo_root_node,root_depth,root_node,atharvest_pest_app  
        
        
  
        deallocate (emergence_date )        
        deallocate (maturity_date  )
        deallocate (harvest_date   )
 
        deallocate (precip)
       
        deallocate (pet_evap)
        deallocate (air_temperature)
        deallocate (wind_speed)
        deallocate (solar_radiation)       
        deallocate (runoff_series)
        deallocate (erosion_series)            
        deallocate (parent_runoff_series)
        deallocate (parent_erosion_series)
        deallocate (daughter_runoff_series)
        deallocate (daughter_erosion_series)
        deallocate (granddaughter_runoff_series)
        deallocate (granddaughter_erosion_series)
                  
        deallocate (soil_depth)
        deallocate (wiltpoint_water)
        deallocate (fieldcap_water)
        deallocate (bulkdensity)
        deallocate (delx)
        deallocate (clay)
        deallocate (sand)
        deallocate (orgcarb)
        deallocate (theta_zero)
        deallocate (theta_end)
        deallocate (theta_sat)
        deallocate (theta_fc)
        deallocate (theta_wp)
        deallocate (soil_temp)
        deallocate (soilwater)          
        deallocate (dwrate)
        deallocate (dsrate) 
        deallocate (dgrate)
        deallocate (dwrate_atRefTemp)
        deallocate (dsrate_atRefTemp)
        deallocate (dgrate_atRefTemp)  
        deallocate (MolarConvert_aq12)
        deallocate (MolarConvert_aq13)
        deallocate (MolarConvert_aq23)
        deallocate (MolarConvert_s12 )
        deallocate (MolarConvert_s13 )
        deallocate (MolarConvert_s23 ) 
        deallocate (Kd_new)
        deallocate (Kd_old)
        deallocate (k_freundlich)
        deallocate (N_freundlich)
        deallocate (k_freundlich_2)
        deallocate (N_freundlich_2)               
        deallocate (conc_porewater      )
        deallocate (conc_total_per_water)
        deallocate (mass_in_compartment )
        deallocate (mass_in_compartment2)      
        deallocate (Sorbed2)
        deallocate (Kd_2   )      !Effective linearized Kd for nonequiliobrium compartment
        deallocate (GAMMA1 )    
        deallocate (dispersion)       
        deallocate (thair_old)
        deallocate (thair_new)      
        deallocate (DGAIR)             
        deallocate (ainf)  ! need extra compartment to hold final leaching amount (ainf is leaching INTO compartment)
        deallocate (vel)
        deallocate (EvapoTran)        
        deallocate (new_henry)  
        deallocate (old_Henry)           
        deallocate (runoff_intensity)
        deallocate (erosion_intensity)          
        deallocate (soilap)        
        deallocate (DKFLUX)        
        deallocate (PVFLUX) 
        deallocate (UPFLUX) 
        deallocate (DFFLUX) 
        deallocate (ADFLUX) 
        deallocate (SRCFLX)    !this one needs to be 3 becuz parent can produces 2 degradates           
        deallocate (soil_applied_washoff)   !plant washoff pesticide 
        
        
        deallocate (application_date)
        deallocate (pest_app_method)
        deallocate (DEPI)        
        deallocate (TAPP)             
        deallocate (APPEFF)
        deallocate (Tband_top)
        deallocate ( drift_kg_per_m2)
        
        
      deallocate (crop_fraction_of_max ) 
      deallocate (canopy_cover         ) 
      deallocate (canopy_height        )
      deallocate (canopy_holdup        )
      deallocate (is_harvest_day       )
      deallocate (evapo_root_node      )
      deallocate (root_depth           )
      deallocate (root_node            )
      deallocate (atharvest_pest_app   ) 
        
        
        
   end subroutine deallocate_scenario_parameters
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    subroutine allocate_vvwm
!USE noninputvariables
!use variables, ONLY: nchem
!integer :: status            !array allocation status,  0=success
!    
!        allocate (wind(num_records), STAT=status)
!        allocate (temp_avg(num_records), STAT=status)
!        allocate (evap(num_records), STAT=status)
!        allocate (precip(num_records), STAT=status)
    
    !wind = wind_speed
    !temp_avg = air_temperature
    !evap = pet_evap
    !precip = precip
    

!        allocate (q(num_records), STAT=status)
!        allocate (burial(num_records), STAT=status)
!        allocate (eroded_solids_mass(num_records), STAT=status)
!        allocate (fraction_to_benthic(num_records), STAT=status)
!           
!        allocate (mass(num_records,2,3), STAT=status)
!        
!        if (nchem > 1) then 
!                allocate (degradateProduced1(num_records), STAT=status)
!                allocate (degradateProduced2(num_records), STAT=status)    
!        end if
!     
!        allocate (volume1(num_records), STAT=status)
!        allocate (daily_depth(num_records), STAT=status)
!        allocate (k_flow(num_records), STAT=status)
!        allocate (k_burial(num_records), STAT=status)
!        allocate (k_aer_aq(num_records), STAT=status)             
!        allocate (k_anaer_aq(num_records), STAT=status)         
!        allocate (k_aer_s(num_records), STAT=status)             
!        allocate (k_anaer_s(num_records), STAT=status)
!        allocate (k_volatile(num_records), STAT=status)
!        allocate (k_photo(num_records), STAT=status)
!        allocate (k_hydro(num_records), STAT=status)
!        allocate (gamma_1(num_records), STAT=status)
!        allocate (gamma_2(num_records), STAT=status)
!        allocate (A(num_records), STAT=status)
!        allocate (B(num_records), STAT=status)
!        allocate (E(num_records), STAT=status)
!        allocate (F(num_records), STAT=status)
!        allocate (theta(num_records), STAT=status)
!        allocate (capacity_1(num_records), STAT=status)
!        allocate (fw1(num_records), STAT=status)
!        allocate (m1_input(num_records), STAT=status)
!        allocate (m2_input(num_records), STAT=status)
!        allocate (m1_store(num_records), STAT=status)
!        allocate (m2_store(num_records), STAT=status)
!        allocate (mavg1_store(num_records), STAT=status)     
!          
!        
! !       allocate (v1(num_records), STAT=status)
!        allocate (aqconc_avg1(num_records), STAT=status)        
!        allocate (aqconc_avg2(num_records), STAT=status)    
!
!        allocate (aq1_store(num_records), STAT=status)        
!        allocate (aq2_store(num_records), STAT=status)    
!
!    
!        
        
end subroutine allocate_vvwm
    
    
    
    
    
    
    
    
    
    
    
end module allocations