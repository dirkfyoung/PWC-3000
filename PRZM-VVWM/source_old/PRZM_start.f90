Module PRZM_part
  
   contains
   subroutine PRZM5

   use constants_and_Variables, ONLY: EchoFileUnit, julday1900 ,&
                                  precip, pet_evap,air_temperature ,wind_speed, solar_radiation, &
                                  precipitation,PEVP,air_TEMP,WIND, SOLRAD ,harvest_day, &
                                  startday, num_records,is_harvest_day,canopy_holdup, &
                                  canopy_height, canopy_cover  , cover, height, harvest_placement, &
                                  potential_canopy_holdup,evapo_root_node_daily, &
                                  evapo_root_node,root_node ,root_node_daily,atharvest_pest_app,day_number
                             
   
   use initialization
   use utilities_1
   use readinputs
   use PRZM_core
   use plantgrowth

   implicit none
   
   integer :: i 


   CALL INITL    !initialize variables   
   Call Crop_Growth
   write(echofileunit, *) 'finish crop growth'
   julday1900 = startday
 
   do i=1, num_records   !day loop driven by metfile only   

       day_number = i
       !Vectors determined outside of loop transfered as scalers to loop
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
       

      CALL PRZM_one_day_step 
      julday1900 = julday1900  +1
   end do
  
 
   write(EchoFileUnit,*) 'PRZM5 program normal completion.'


   end subroutine PRZM5
    
   
   

   
end module przm_part
    