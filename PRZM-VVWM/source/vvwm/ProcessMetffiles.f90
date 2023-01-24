module ProcessMetfiles
    implicit none
    contains
    

   
    !******************************************************************************************************
   subroutine convert_weatherdata_for_VVWM  
   !Converts weather data to VVWM relevant units !average previous 30 day temperature and daily wind speed
    use constants_and_variables, ONLY: num_records, precip, pet_evap,air_temperature, wind_speed,  &
                                        wind_m,temp_avg,evap_m,precip_m  , pfac
       
    implicit none

    real :: temp30(30)        !array to hold previous 30 days of temperature 
    real :: tempsum            !sum of 30 day temperature values
 
    integer :: i,j                !do loop counters



    !***********************************************************************
    temp30=air_temperature(1)    !initially fill array with temperature of first value
    tempsum=30.*air_temperature(1) 
            
    !Calculate running average 30 day 
    do i=1,num_records
        tempsum = tempsum +air_temperature(i)-temp30(1)    !calculate new average termperature
        temp_avg(i)=tempsum/30.                !calculate new average termperature

        do j=1, 29                    !update new array
            temp30(j)= temp30(j+1)
        end do
        temp30(30) = air_temperature(i)
        !***********************************************
    end do

    wind_m   = wind_speed/100.        !whole array operation convert to m/s
    evap_m   = pet_evap/100.  *pfac       !whole array operation convert to m
    precip_m = precip/100.      !whole array operation convert to m

    
    end subroutine convert_weatherdata_for_VVWM  
    !******************************************************************************************************
  

end module ProcessMetfiles