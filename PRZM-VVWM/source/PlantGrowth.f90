module plantgrowth
    implicit none
    contains
    
    Subroutine Crop_Growth
    use utilities_1
    
    use constants_and_Variables, ONLY: num_records, crop_fraction_of_max, startday,num_crop_periods_input, &  
                                       emergence_date,maturity_date, harvest_date, &
                                       canopy_cover,canopy_height,canopy_holdup ,NCOM2,soil_depth, &
                                       is_harvest_day, evapo_root_node,root_depth, &
                                       max_root_depth,max_canopy_cover,max_canopy_holdup,max_canopy_height, &
                                       min_evap_node,root_node, atharvest_pest_app,foliar_disposition,&
                                       first_year , last_year, evergreen
            
      implicit none
    
      integer i ,j, k , m

      allocate (crop_fraction_of_max (num_records)) 
      allocate (canopy_cover         (num_records)) 
      allocate (canopy_height        (num_records))
      allocate (canopy_holdup        (num_records))
      allocate (is_harvest_day       (num_records))
      allocate (evapo_root_node      (num_records))
      allocate (root_depth           (num_records))
      allocate (root_node            (num_records))
      allocate (atharvest_pest_app   (num_records)) 
      
      !Default Values (initialization)
      crop_fraction_of_max = 0.0  
      canopy_cover = 0.0
      canopy_height = 0.0
      canopy_holdup = 0.0
      root_depth = 0.0
      root_node  = 0
      is_harvest_day = .FALSE.
      evapo_root_node = min_evap_node
      atharvest_pest_app = 0
      

      !Do growth stage

      do i=1, num_crop_periods_input  

            if (evergreen) then   !there should be only one crop period for evergreen
                      canopy_cover  = max_canopy_cover(i)
                      canopy_height = max_canopy_height(i)
                      canopy_holdup = max_canopy_holdup(i)*max_canopy_cover(i)
                      
                      root_depth    = max_root_depth(i)                     
                      root_node     = find_depth_node(ncom2,soil_depth,max_root_depth(i))
                      
                      
            else   !****************************************************  
                      do k = 1 ,last_year -first_year+1   
                           do j=emergence_date(i,k), maturity_date(i,k)
                             m = j-startday +1 
                             if (m > num_records) exit
                      
                             crop_fraction_of_max(m) = real(j-emergence_date(i,k) )/real(maturity_date(i,k)-emergence_date(i,k)   )                 
                             canopy_cover(m)  = crop_fraction_of_max(m)*max_canopy_cover(i)
                             canopy_height(m) = crop_fraction_of_max(m)*max_canopy_height(i)
                             canopy_holdup(m) = canopy_cover(m)*max_canopy_holdup(i)
                             root_depth(m)    = crop_fraction_of_max(m)*max_root_depth(i)
                             root_node(m) =  find_depth_node(ncom2,soil_depth,root_depth(m))     
                              
                    
                             
                           end do
                           
                           do j=maturity_date(i,k), harvest_date(i,k)-1
                              m = j-startday +1 
                              if (m > num_records) exit
                              crop_fraction_of_max(j-startday +1 ) = 1.0 
                              canopy_cover(m)  = max_canopy_cover(i)
                              canopy_height(m) = max_canopy_height(i)
                              canopy_holdup(m) = max_canopy_holdup(i)*canopy_cover(m)
                              root_depth(m)    = max_root_depth(i)                            
                              root_node(m) =  find_depth_node(ncom2,soil_depth,root_depth(m))

                           end do                          
                                         
                          !Set Harvest Dates
                           m = harvest_date(i,k)-startday +1
                           if (m > 0 .AND. m <= num_records) then 
                               is_harvest_day(m) = .TRUE. 
                               atharvest_pest_app(m) = foliar_disposition(i)
                           end if                          
                      end do
            end if        
      end do
      
            

       !minimum evaporation zone is limited by min_evap_depth (anetd) parameter
        where (root_node > min_evap_node) evapo_root_node = root_node
       

    end subroutine Crop_Growth
    
 
end module plantgrowth
   