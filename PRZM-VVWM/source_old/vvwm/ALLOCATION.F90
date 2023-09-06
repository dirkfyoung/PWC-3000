MODULE ALLOCATIONmodule
IMPLICIT NONE
contains

subroutine allocation
use constants_and_variables, ONLY: num_records,nchem, temp_avg, wind_m, evap_m, precip_m
USE noninputvariables

    
        !allocate (wind(num_records))
        !allocate (temp_avg(num_records))
        !allocate (evap(num_records))
        !allocate (precip(num_records))
        allocate (flowthru_the_body(num_records))
        allocate (burial(num_records))
        allocate (eroded_solids_mass(num_records))
        allocate (fraction_to_benthic(num_records))
        
        
        allocate (precip_m(num_records))  !VVWM parameters which have  different units
        allocate (evap_m(num_records)) 
        allocate (temp_avg(num_records)) 
        allocate (wind_m(num_records))
        
        
        
        allocate (mass(num_records,2,3))
        
        if (nchem > 1) then 
                allocate (degradateProduced1(num_records))
                allocate (degradateProduced2(num_records))    
        end if
     
        allocate (volume1(num_records))
        allocate (daily_depth(num_records))
        allocate (k_flow(num_records))
        allocate (k_burial(num_records))
        allocate (k_aer_aq(num_records))       
        
        
        allocate (k_anaer_aq(num_records))         
        allocate (k_aer_s(num_records))             
        allocate (k_anaer_s(num_records))
        allocate (k_volatile(num_records))
        allocate (k_photo(num_records))
        allocate (k_hydro(num_records))
        allocate (gamma_1(num_records))
        allocate (gamma_2(num_records))
        allocate (A(num_records))
        allocate (B(num_records))
        allocate (E(num_records))
        allocate (F(num_records))
        allocate (theta(num_records))
        allocate (capacity_1(num_records))
        allocate (fw1(num_records))
        allocate (m1_input(num_records))
        allocate (m2_input(num_records))
        allocate (m1_store(num_records))
        allocate (m2_store(num_records))
        allocate (mavg1_store(num_records))     
                 
 !       allocate (v1(num_records), STAT=status)
        allocate (aqconc_avg1(num_records))        
        allocate (aqconc_avg2(num_records))    

        allocate (aq1_store(num_records))        
        allocate (aq2_store(num_records))    

    
        
        
end subroutine allocation



    
    
    
END MODULE ALLOCATIONmodule