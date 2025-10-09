Module waterbody_parameters
    
implicit none
    character(len=20) :: this_waterbody_name  !name of specific water body, included in waterbody input file
    integer :: SimTypeFlag    !1=vvwm,2 = USepa pond, 3 = usepa reservoir, 4=constant vol w/o flow, 5 = const vol w/flow
    real :: D_over_dx     
    real :: benthic_depth 
    real :: porosity      
    real :: bulk_density  
    real :: FROC2         
    real :: DOC2          
    real :: BNMAS         
    real :: DFAC          
    real :: SUSED         
    real :: CHL           
    real :: FROC1         
    real :: DOC1          
    real :: PLMAS         
    real :: afield            !square meters 
    real :: area_waterbody    
    
    !NEW PARAMETER
    real :: distance_drift    !the length of the water body in the direction of drift 
    
    real :: depth_0    
    real :: depth_max     
    real :: baseflow       
    integer:: flow_averaging  !0 indicates full simulation average, other values are back averaged days
    real   :: hydro_length
    
	logical :: is_zero_depth  !post processing to zero out conc below a certain depth
    real    :: zero_depth     !depth below which conc are zeroed during post processing

	!real,dimension(14):: spray_values  !default or read-in values for spray drift, their order should corresponds to the menu in the application table

    logical:: itsapond, itsareservoir, itsother, itstpezwpez, use_tpezbuffer
    character(len=512), allocatable, dimension(:) :: waterbody_names  !this holds the info for looping waterbodies (position 1 and 2 are often Pond and reservoir)
    character(len=512), parameter :: USEPA_pond = "USEPA Pond"  
    character(len=512), parameter :: USEPA_reservoir = "USEPA Reservoir"

    !**** POND ****************

    integer, parameter :: waterbodytype_P = 2
    real,parameter :: D_over_dx_P     = 1e-8
    real,parameter :: benthic_depth_P = 0.05
    real,parameter :: porosity_P      = 0.5    
    real,parameter :: bulk_density_P  = 1.35
    real,parameter :: FROC2_P         = 0.04
    real,parameter :: DOC2_P          = 5.0
    real,parameter :: BNMAS_P         = 0.006
    real,parameter :: DFAC_P          = 1.19
    real,parameter :: SUSED_P         = 30.
    real,parameter :: CHL_P           = 0.005
    real,parameter :: FROC1_P         = 0.04
    real,parameter :: DOC1_P          = 5.0
    real,parameter :: PLMAS_P         = 0.4    
    real,parameter :: afield_P        = 100000.  !square meters
    real,parameter :: area_waterbody_P   = 10000.
    real,parameter :: depth_0_P       = 2.0
    real,parameter :: depth_max_P     = 2.0
    real,parameter :: baseflow_P      = 0.0   
    integer,parameter :: flow_averaging_P = 0
    real,parameter    :: hydro_length_P      = 356.8   
    
	real,parameter    :: distance_drift_P      = 63.61 !meters
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

    
    !*** RESERVOIR ****************

    integer, parameter :: waterbodytype_R = 3
    real,parameter :: D_over_dx_R     = 1e-8
    real,parameter :: benthic_depth_R = 0.05
    real,parameter :: porosity_R      = 0.5    
    real,parameter :: bulk_density_R  = 1.35
    real,parameter :: FROC2_R         = 0.04
    real,parameter :: DOC2_R          = 5.0
    real,parameter :: BNMAS_R         = 0.006
    real,parameter :: DFAC_R          = 1.19
    real,parameter :: SUSED_R         = 30.
    real,parameter :: CHL_R           = 0.005
    real,parameter :: FROC1_R         = 0.04
    real,parameter :: DOC1_R          = 5.0
    real,parameter :: PLMAS_R         = 0.4       
    real,parameter :: afield_R        = 1728000.
    real,parameter :: area_waterbody_R    = 52600.
    real,parameter :: depth_0_R           = 2.74
    real,parameter :: depth_max_R         = 2.74
    real,parameter :: baseflow_R          = 0.0   
    integer,parameter :: flow_averaging_R = 0
    real,parameter :: hydro_length_R      = 600. 
    
    real :: distance_drift_R = 48.0
     
     
  !  real,dimension(14),parameter :: spray_R = (/0.258, 0.135, 0.097, 0.076, 0.066,0.027,0.017,0.011, 0.048, 0.017,0.0003,0.025, 1.0, 0.0 /)
	
!"Method \  Buffer (ft)",
!"Aerial (VF-F)"        ,
!"Aerial (F-M) default" ,
!"Aerial (M-C)"         ,
!"Aerial (C-VC)"        ,
!"GrdHi (VF-F) default" ,
!"GrdHi (F-MC)"         ,
!"GrdLow (VF-F)"        ,
!"GrdLow (F-MC)"        ,
!"Airblast (normal)"    ,
!"Airblast (dense)"     ,
!"Airblst (sparse) def" ,
! "Airblast (vinyard)"  ,
!"Airblast (orchard)"   ,
!full
!none
!you define


    contains
    subroutine get_pond_parameters
        this_waterbody_name = "Pond"
        simtypeflag         = waterbodytype_P 
        flow_averaging      = flow_averaging_P  
        afield              = afield_P       
        area_waterbody       = area_waterbody_P      
        D_over_dx           = D_over_dx_P     
        benthic_depth       = benthic_depth_P 
        porosity            = porosity_P      
        bulk_density        = bulk_density_P  
        FROC2               = FROC2_P         
        DOC2                = DOC2_P          
        BNMAS               = BNMAS_P         
        DFAC                = DFAC_P          
        SUSED               = SUSED_P        
        CHL                 = CHL_P           
        FROC1               = FROC1_P         
        DOC1                = DOC1_P          
        PLMAS               = PLMAS_P            
        depth_0             = depth_0_P       
        depth_max           = depth_max_P     
        baseflow            = baseflow_P        
        hydro_length        = hydro_length_P
      !  spray_values        =spray_p
        
        is_zero_depth = .FALSE.
        zero_depth = 0.0

        distance_drift  =  distance_drift_P 
   
	end subroutine get_pond_parameters
   
	
	
    subroutine get_reservoir_parameters
        
        this_waterbody_name = "Reservoir"
        simtypeflag = waterbodytype_R
        afield              = afield_R  
        area_waterbody      = area_waterbody_R
        D_over_dx           = D_over_dx_R     
        benthic_depth       = benthic_depth_R 
        porosity            = porosity_R      
        bulk_density        = bulk_density_R  
        FROC2               = FROC2_R         
        DOC2                = DOC2_R
        BNMAS               = BNMAS_R
        DFAC                = DFAC_R    
        SUSED               = SUSED_R   
        CHL                 = CHL_R     
        FROC1               = FROC1_R   
        DOC1                = DOC1_R     
        PLMAS               = PLMAS_R  
        depth_0             = depth_0_R       
        depth_max           = depth_max_R     
        baseflow            = baseflow_R        
        flow_averaging      = flow_averaging_R
        hydro_length        = hydro_length_R
        
        is_zero_depth = .FALSE.
        zero_depth = 0.0

        distance_drift  =  distance_drift_R
    end subroutine get_reservoir_parameters

    
    
    
    
    
    
    subroutine read_waterbodyfile(file_index)
    use constants_and_variables, ONLY: waterbody_file_unit

    integer,intent(in) :: file_index
	integer :: eof
     
        open (UNIT=waterbody_file_unit, FILE= trim(waterbody_names(file_index)), STATUS ='old')
   
        read(waterbody_file_unit, '(A)') this_waterbody_name       
        read(waterbody_file_unit, *) simtypeflag                           !Line 2
        read(waterbody_file_unit, *) flow_averaging     
        read(waterbody_file_unit, *) afield       
        read(waterbody_file_unit, *) area_waterbody     
        read(waterbody_file_unit, *) D_over_dx          
        read(waterbody_file_unit, *) benthic_depth      
        read(waterbody_file_unit, *) porosity           
        read(waterbody_file_unit, *) bulk_density       
        read(waterbody_file_unit, *) FROC2              
        read(waterbody_file_unit, *) DOC2               
        read(waterbody_file_unit, *) BNMAS         
        read(waterbody_file_unit, *) DFAC               
        read(waterbody_file_unit, *) SUSED              
        read(waterbody_file_unit, *) CHL                
        read(waterbody_file_unit, *) FROC1              
        read(waterbody_file_unit, *) DOC1               
        read(waterbody_file_unit, *) PLMAS       !LIne 18

        read(waterbody_file_unit, *) depth_0      !Line 19      
        read(waterbody_file_unit, *) depth_max    !Line 20
        read(waterbody_file_unit, *) baseflow     !line 21

        read(waterbody_file_unit, *) hydro_length  !Line 22
       
        read(waterbody_file_unit, *) is_zero_depth, zero_depth
 
        read(waterbody_file_unit, *) 

        read(waterbody_file_unit,*, IOSTAT=eof) distance_drift
        if (eof < 0) then 
            write(*,*) "The waterbody file is older version and does not include a waterbody dimension for spray drift."
            write(*,*) "Assuming waterbody is square for spray calculations."
            distance_drift = sqrt(area_waterbody )
        end if
        

    end subroutine read_waterbodyfile
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
    
end Module waterbody_parameters
   
