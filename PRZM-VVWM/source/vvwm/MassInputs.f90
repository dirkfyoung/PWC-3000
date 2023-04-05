module MassInputs

contains

    subroutine get_mass_inputs

    use constants_and_variables, ONLY: nchem ,num_records, runoff_save,erosion_save,&
                                 eroded_solids_mass, burial,flowthru_the_body, mass_off_field,&   !OUTPUT array to hold runoff & erosion & spraydrift events
                                 runoff_total,erosion_total,  Daily_Avg_Runoff, runoff_save, edge_of_field
    
    use waterbody_parameters, ONLY: afield, baseflow    

    !       This routine no longer reads zts of course. It serves only to tie up a few things
    
    
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
integer :: i

    burial = 0.
    runoff_total = 0.0
    erosion_total =0.0
 

        ! Process and convert runoff for VVWM use
        flowthru_the_body = runoff_save*afield/8640000.    !m3/s :(cm/day) *(m2)* (m/100cm)* (day/86400s)  
        Daily_Avg_Runoff  = sum(flowthru_the_body)/num_records
        flowthru_the_body = flowthru_the_body+ baseflow  !add in baseflow
       
        edge_of_field  = 0.0
        where (flowthru_the_body> 0.0) edge_of_field = mass_off_field(:,1,nchem) /(flowthru_the_body*86400.) !kg/m3
        
        ! Process and convert erosion for VVWM use
        eroded_solids_mass= erosion_save*1000. !convert from tonnes to kg
		
        Burial = eroded_solids_mass/86400.  ! kg/day*(day/86400 sec)    = kg/sec
        
        write(*,*) 'parent runoff mass delivered ',     sum(mass_off_field(:,1,1))
        write(*,*)  'parent erosion mass ',             sum(mass_off_field(:,2,1))
        
        !proocess mass inputs
    !    mass_off_field= mass_off_field* afield*10.  !converts to kg

        !mass_off_field(:,1,1) =  parent_runoff_series(:)* afield*10.  !converts to kg
        !mass_off_field(:,2,1) = parent_erosion_series(:)* afield*10.  !converts to kg
        !        
        !if (nchem >1) then
        !  mass_off_field(:,1,2) = daughter_runoff_series(:)* afield*10.  !converts to kg
        !  mass_off_field(:,2,2) = daughter_erosion_series(:)* afield*10.  !converts to kg
        !end if
        !
        !if (nchem >2) then
        !  mass_off_field(:,1,3) = granddaughter_runoff_series(:)* afield*10.  !converts to kg
        !  mass_off_field(:,2,3) = granddaughter_erosion_series(:)* afield*10.  !converts to kg
        !end if
        
        runoff_total(1:nchem) = sum(mass_off_field(:,1,1:nchem),1)
        erosion_total(1:nchem)= sum(mass_off_field(:,2,1:nchem),1)


        
        
        
    end subroutine get_mass_inputs

    
    
!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%
    subroutine spraydrift
       use nonInputVariables, only: 
       use waterbody_parameters, ONLY:area_waterbody
       
       use constants_and_variables, ONLY: num_records, total_applications, drift_kg_per_m2 , application_date, startday, &
                                      mass_off_field, spray_total, spray_additions             
       implicit none
       integer  ::  i, index_day
      ! real     ::  sprayrate
    !Note mass is an array refernced to day 1 of the simulation, appdate is an array of dates from 1900       
       
       spray_total= 0.0
       spray_additions = 0.0
       
       !need to adjust drift here
       ! drift_kg_per_m2(app_counter) = drift_value(i)*application_rate_in(i)/10000.
       
       
       
       
       
       
       do i=1, total_applications
           index_day = application_date(i)-startday
           if (index_day > 0 .and. index_day <= num_records) then
            !   sprayrate = drift_kg_per_m2(i) * area_waterbody  
               
               spray_additions(index_day) = drift_kg_per_m2(i) * area_waterbody 
               
           !    mass_off_field(index_day, 1,1) =  mass_off_field(index_day, 1,1) +   sprayrate             
              ! spray_total(1) =  spray_total(1) +  sprayrate
               
                spray_total(1) =  spray_total(1) + spray_additions(index_day)
               
           end if          
       end do
       
       write(*,*) "total_applications = ", total_applications
       write(*,*) "Spray mass = ", spray_total(1)
       
    end subroutine spraydrift
!%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%    

!**********************************************************************************************
subroutine DegradateProduction(chem_index)
!when this routine is run, it calculates the production of degradate from parent
!Thus, the "index" refers to the parent chemical
      use constants_and_variables, ONLY: num_records,xAerobic,xPhoto, xHydro,xBenthic, mwt,DELT_vvwm, &
                                    degradateProduced1,degradateProduced2,  &
                                    volume1, v2 ,k_photo, k_hydro, k_aer_aq,capacity_1,  &
                                    aqconc_avg1,aqconc_avg2,k_anaer_aq,capacity_2 , degradateProduced1,degradateProduced2
      
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
       use constants_and_variables, ONLY: fraction_to_benthic, eroded_solids_mass, degradateProduced1, &
                                     degradateProduced2, mass_off_field, spray_additions,  & 
                                     m1_input,           & !OUTPUT mass added to littoral region (kg) 
                                     m2_input,           & !OUTPUT mass added to bethic region (kg) --now always zero for parent
                                     capacity_1, kd_sed_1
                                                       
        implicit none      
        integer,intent(in) :: chem_index

        !********************************************************************
        fraction_to_benthic = kd_sed_1*eroded_solids_mass/ (capacity_1 + kd_sed_1*eroded_solids_mass)    !used later in core calc routine
        m1_input = mass_off_field(:,1,chem_index) +  mass_off_field(:,2,chem_index) + spray_additions  !all mass goes to water column initially
        m2_input = 0.0  

        !******* Add in any degradate mass produced by parent from subsequent parent run******
        if (chem_index>1) then                 !j=1 is the parent.
          m1_input = m1_input + degradateProduced1   
          m2_input = m2_input + degradateProduced2
        end if
        
end subroutine initial_conditions


end module MassInputs


