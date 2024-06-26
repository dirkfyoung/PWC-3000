module MassInputs

contains

    subroutine get_mass_inputs

    use constants_and_variables, ONLY: echofileunit,nchem ,num_records, runoff_series,erosion_series,parent_runoff_series,parent_erosion_series,&
                                 daughter_runoff_series,daughter_erosion_series, & 
                                 granddaughter_runoff_series,granddaughter_erosion_series,  afield, baseflow

    
    use nonInputVariables, Only:  mass,          &   !OUTPUT array to hold runoff & erosion & spraydrift events
                                  flowthru_the_body,             &   !OUTPUT (m3/sec) array of daily flow
                                 burial,        &   !OUTPUT burial rate each day kg/s 
                                 runoff_total,  &
                                 erosion_total,  &
                                 eroded_solids_mass, &
                                 Daily_Avg_Runoff
                                 
                                       
                 
    !****************************************************************
    !This subroutine reads the PRZM output file with ZTS subscript
    !It then reads in the file and puts pesticide spray drift and runoff mass into first
    !column of the array mass.
    !It returns all masses for the simulation in the array mass
    !It puts erosion pesticide mass into second column of 'mass'
    !It outputs daily runoff in m3/s in "q"
    !****************************************************************
    implicit none


!    real :: applied
!    real(8) :: percent

!    real(8) :: spraymass                !individual spraydrift mass (kg)
!    real(8) :: runoff_cm
!    real(8):: erosion_tonnes        !
!    real(8):: absolute_day            !total number of days from start of simulation



!    integer:: day_number            !number of the day (e.g., jan 1 = 1, feb 1 = 32)
!    integer:: app_day                !day of application
!    integer:: app_mon                !month of application
!    integer:: day                !month and day of erosion/ runoff event


    burial = 0.
    runoff_total = 0.0
    erosion_total =0.0
 

        ! Process and convert runoff for VVWM use
        flowthru_the_body=runoff_series*afield/8640000.    !m3/s :(cm/day) *(m2)* (m/100cm)* (day/86400s)  
        Daily_Avg_Runoff = sum(flowthru_the_body)/num_records
        flowthru_the_body= flowthru_the_body+ baseflow  !add in baseflow
    
        ! Process and convert erosion for VVWM use
        eroded_solids_mass= erosion_series*1000. !convert from tonnes to kg
        Burial = eroded_solids_mass/86400.  ! kg/day*(day/86400 sec)    = kg/sec
        
        !proocess mass inputs
        mass= mass* afield*10.  !converts to kg

        mass(:,1,1) =  parent_runoff_series(:)* afield*10.  !converts to kg
        mass(:,2,1) = parent_erosion_series(:)* afield*10.  !converts to kg
                
        if (nchem >1) then
          mass(:,1,2) = daughter_runoff_series(:)* afield*10.  !converts to kg
          mass(:,2,2) = daughter_erosion_series(:)* afield*10.  !converts to kg
        end if
        
        if (nchem >2) then
          mass(:,1,3) = granddaughter_runoff_series(:)* afield*10.  !converts to kg
          mass(:,2,3) = granddaughter_erosion_series(:)* afield*10.  !converts to kg
        end if
        
        runoff_total(1:nchem) = sum(mass(:,1,1:nchem),1)
        erosion_total(1:nchem)= sum(mass(:,2,1:nchem),1)

        write(EchoFileUnit,*) "Total Pest Runoff mass = ", runoff_total(1) 
        write(EchoFileUnit,*) "Total Eroded Runoff mass = ", erosion_total(1) 
        
        
        
    end subroutine get_mass_inputs

    
    
!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    subroutine spraydrift
       use nonInputVariables, only: mass, spray_total
       use constants_and_variables, ONLY: echofileunit,num_records, total_applications, drift_kg_per_m2 , application_date, startday, area_waterbody
                                                               
       implicit none
       integer ::  i, index_day
       real :: sprayrate
    !Note mass is an array refernced to day 1 of the simulation, appdate is an array of dates from 1900       
       
       spray_total= 0.0
       
       do i=1, total_applications
           index_day = application_date(i)-startday
           if (index_day > 0 .and. index_day <= num_records) then
               sprayrate = drift_kg_per_m2(i) * area_waterbody              
               mass(index_day, 1,1) =  mass(index_day, 1,1) +   sprayrate             
               spray_total(1) =  spray_total(1) +  sprayrate
           end if
           
       end do
       
       write(EchoFileUnit,*) "total_applications = ", total_applications
       write(EchoFileUnit,*) "Spray mass = ", spray_total(1)
       
    end subroutine spraydrift
!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    

!**********************************************************************************************
subroutine DegradateProduction(chem_index)
!when this routine is run, it calculates the production of degradate from parent
!Thus, the "index" refers to the parent chemical
      use constants_and_variables, ONLY: num_records,xAerobic,xPhoto, xHydro,xBenthic, mwt,DELT_vvwm
      use nonInputVariables, ONLY: degradateProduced1,degradateProduced2,  &
                                    volume1, v2    ,k_photo, k_hydro, k_aer_aq,capacity_1,  &
                                    aqconc_avg1,aqconc_avg2,k_anaer_aq,capacity_2 
      
      implicit none               
      integer,intent(in) :: chem_index

      real :: MWTRatio
      
      MWTRatio = MWT(chem_index+1)/MWT(chem_index)

      degradateProduced1 = MWTRatio*(xPhoto(chem_index)*k_photo*volume1 + xHydro(chem_index)*k_hydro*volume1 + &
                            xAerobic(chem_index)*k_aer_aq*capacity_1)*aqconc_avg1*DELT_vvwm
      
      
      degradateProduced2 = MWTRatio*(xHydro(chem_index)*k_hydro*v2 + xBenthic(chem_index)*k_anaer_aq*capacity_2)*aqconc_avg2*DELT_vvwm 
             
      !Degradate production is delayed one time step to approximate the process and to maintain analytical solution for time step  
      degradateProduced1(2:num_records)= degradateProduced1(1:num_records-1)
      degradateProduced2(2:num_records)= degradateProduced2(1:num_records-1)
      degradateProduced1(1)= 0.
      degradateProduced2(1)= 0.

      
end subroutine DegradateProduction    
    
!######################################################################################
subroutine initial_conditions(chem_index)
       !THIS SUBROUTINE RETURNS VALUES FOR input masses into each compartment 

        use nonInputVariables, Only:  mass,  & 
                                     m1_input,           & !OUTPUT mass added to littoral region (kg) 
                                     m2_input,           &       !OUTPUT mass added to bethic region (kg)
                                     degradateProduced1, &
                                     degradateProduced2, &
                                     capacity_1,         &
                                     kd_sed_1,           &
                                     eroded_solids_mass, &
                                     fraction_to_benthic
        
                                     !INPUT !mass(:,2)mass coming in by runoff and spraydrift (kg) 
                                     !INPUT mass(:,2) mass coming in on sediment (kg)
        !Local Variables
       
        
        implicit none      
        integer,intent(in) :: chem_index

        !********************************************************************
            fraction_to_benthic = kd_sed_1*eroded_solids_mass/ (capacity_1 + kd_sed_1*eroded_solids_mass)    !used later
            m1_input = mass(:,1,chem_index) +  mass(:,2,chem_index)    !all mass goes to water column initially
            m2_input = 0  
        
        !CALCULATE INPUT MASSES   
        !if (is_calc_prben) then
            !fraction_to_benthic = kd_sed_1*eroded_solids_mass/ (capacity_1 + kd_sed_1*eroded_solids_mass)    !used later
            !m1_input = mass(:,1,chem_index) +  mass(:,2,chem_index)    !all mass goes to water column initially
            !m2_input = 0  

        !else 
        !    fraction_to_benthic = prben
        !    m1_input = mass(:,1,chem_index) +(1.-fraction_to_benthic)*mass(:,2,chem_index)    !note: rfx includes spraydrift and runoff
        !    m2_input = fraction_to_benthic*mass(:,2,chem_index)
        !              
        !end if

        !******* Add in any degradate mass produced by parent from subsequent parent run******
        if (chem_index>1) then                 !j=1 is the parent.  The following call is for the manual pesticide applications.
          m1_input = m1_input + degradateProduced1   
          m2_input = m2_input + degradateProduced2
        end if
        
end subroutine initial_conditions


end module MassInputs


