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
    real :: depth_0    
    real :: depth_max     
    real :: baseflow       
    integer:: flow_averaging  !0 indicates full simulation average, other values are back averaged days
    real   :: hydro_length
    
	logical :: is_zero_depth  !post processing to zero out conc below a certain depth
    real    :: zero_depth     !depth below which conc are zeroed during post processing

	
	real,dimension(14):: spray_values  !default or read-in values for spray drift, their order should corresponds to the menu in the application table

    real,allocatable,dimension(:,:)	  :: spraytable !holds all the spraydrift and buffer values
	integer :: rows_spraytable
    integer :: columns_spraytable
    
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
	
    
    
	                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
	real,dimension(14),parameter :: spray_p = (/0.242,0.125,0.089,0.068, 0.062, 0.027, 0.017, 0.011, 0.042, 0.015, 0.002, 0.022, 1.0, 0.0 /)

    integer,parameter :: rows_spraytable_P = 17
    integer,parameter :: columns_spraytable_P =15   

real,dimension(17,15),parameter :: spray_table_P = transpose(reshape((/&	   
0.0000, 10.000, 25.000, 50.000, 75.000, 100.00, 125.00, 150.00, 200.00, 250.00, 300.00, 350.00, 400.00   , 450.00   , 500.00    ,&
0.2421, 0.2266, 0.2076, 0.1821, 0.1617, 0.1446, 0.1311, 0.1196, 0.1023, 0.0899, 0.0804, 0.0730, 0.067    , 0.0622   , 0.0582    ,&
0.1254, 0.1082, 0.0916, 0.0733, 0.0598, 0.0503, 0.0435, 0.0385, 0.0314, 0.0266, 0.0231, 0.0205, 0.0186   , 0.0172   , 0.016     ,&
0.0885, 0.0713, 0.0564, 0.0428, 0.0332, 0.0271, 0.0228, 0.0197, 0.0154, 0.0126, 0.0108, 0.0095, 0.0086   , 0.008    , 0.0074    ,&
0.0681, 0.0512, 0.0378, 0.0271, 0.0207, 0.0167, 0.0139, 0.0119, 0.0093, 0.0077, 0.0066, 0.0059, 0.0053   , 0.0048   , 0.0045    ,&
0.0616, 0.0376, 0.0267, 0.0194, 0.0155, 0.013 , 0.0112, 0.0098, 0.0078, 0.0064, 0.0053, 0.0046, 0.0039   , 0.0035   , 0.003     ,&
0.0165, 0.009 , 0.0071, 0.0056, 0.0048, 0.0042, 0.0037, 0.0034, 0.0028, 0.0024, 0.0021, 0.0019, 0.0017   , 0.0015   , 0.0014    ,&
0.0268, 0.0136, 0.0100, 0.0076, 0.0063, 0.0054, 0.0048, 0.0043, 0.0036, 0.0031, 0.0027, 0.0024, 0.0021   , 0.0019   , 0.0017    ,&
0.0109, 0.0056, 0.0045, 0.0036, 0.0031, 0.0028, 0.0025, 0.0023, 0.0019, 0.0017, 0.0015, 0.0013, 0.0012   , 0.0011   , 0.001     ,&
0.0011, 0.0009, 0.0007, 0.0005, 0.0004, 0.0003, 0.0003, 0.0002, 0.0002, 0.0002, 0.0001, 0.0001, 0.0000978, 0.0000863, 0.0000769 ,&
0.0145, 0.0106, 0.0074, 0.005 , 0.0037, 0.003 , 0.0025, 0.0022, 0.0017, 0.0014, 0.0012, 0.0011, 0.001    , 0.0009   , 0.0008    ,&
0.0416, 0.0258, 0.015 , 0.0077, 0.0047, 0.0031, 0.0022, 0.0017, 0.001 , 0.0007, 0.0005, 0.0004, 0.0003   , 0.0002   , 0.0002    ,&
0.0024, 0.0014, 0.0009, 0.0006, 0.0004, 0.0003, 0.0003, 0.0002, 0.0002, 0.0001, 0.0001, 0.0001, 0.0000881, 0.0000765, 0.0000672 ,&
0.0218, 0.0145, 0.0093, 0.0056, 0.004 , 0.0031, 0.0025, 0.0021, 0.0016, 0.0013, 0.0011, 0.0009, 0.0008   , 0.0007   , 0.0007    ,&
1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0   , 1.0      , 1.0      , 1.0       ,&
0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0      , 0.0      , 0.0       ,&
0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0   , 0.0      , 0.0      , 0.0 &        
/),(/15,17/)))  
    
    

    
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
    
    
    real,dimension(14),parameter :: spray_R = (/0.258, 0.135, 0.097, 0.076, 0.066,0.027,0.017,0.011, 0.048, 0.017,0.0003,0.025, 1.0, 0.0 /)
	
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

integer,parameter :: rows_spraytable_R = 17
integer,parameter :: columns_spraytable_R =15

real,dimension(17,15),parameter :: spray_table_R = transpose(reshape((/&	
	
0.0000E+00,1.0000E+01,2.5000E+01,5.0000E+01,7.5000E+01,1.0000E+02,1.2500E+02,1.5000E+02,2.0000E+02,2.5000E+02,3.0000E+02,3.5000E+02,4.0000E+02,4.5000E+02,5.0000E+02 ,&
2.5828E-01,2.4692E-01,2.2550E-01,1.9757E-01,1.7616E-01,1.5725E-01,1.4289E-01,1.3039E-01,1.1162E-01,9.8045E-02,8.7796E-02,7.9781E-02,7.3386E-02,6.8186E-02,6.3946E-02 ,&
1.3494E-01,1.2408E-01,1.0187E-01,8.2155E-02,6.6128E-02,5.5481E-02,4.7449E-02,4.2128E-02,3.4088E-02,2.8893E-02,2.5218E-02,2.2515E-02,2.0461E-02,1.8887E-02,1.7692E-02 ,&
9.6538E-02,8.6219E-02,6.4323E-02,4.8682E-02,3.6972E-02,2.9925E-02,2.4873E-02,2.1596E-02,1.6798E-02,1.3735E-02,1.1823E-02,1.0472E-02,9.4890E-03,8.7633E-03,8.1718E-03 ,&
7.5736E-02,6.5809E-02,4.4828E-02,3.0943E-02,2.3225E-02,1.8610E-02,1.5315E-02,1.3144E-02,1.0112E-02,8.4119E-03,7.1832E-03,6.4460E-03,5.8431E-03,5.2517E-03,4.8945E-03 ,&
6.6075E-02,5.0682E-02,3.2178E-02,2.1876E-02,1.7098E-02,1.4164E-02,1.2149E-02,1.0595E-02,8.4262E-03,6.8404E-03,5.7346E-03,4.8974E-03,4.2831E-03,3.7030E-03,3.3345E-03 ,&
1.6618E-02,1.1256E-02,8.1893E-03,6.2462E-03,5.2375E-03,4.5660E-03,4.0402E-03,3.6602E-03,3.0459E-03,2.6659E-03,2.3087E-03,2.0744E-03,1.8401E-03,1.7058E-03,1.4944E-03 ,&
2.7231E-02,1.8154E-02,1.8124e-02,8.5178E-03,6.9034E-03,5.9290e-03,5.2575E-03,4.6317E-03,3.8716E-03,3.2688E-03,2.8887E-03,2.5403E-03,2.2973E-03,2.0630E-03,1.8401E-03 ,&
1.0818E-02,6.9380E-03,5.2119E-03,4.0774E-03,3.3945E-03,2.9802E-03,2.7116E-03,2.4659E-03,2.0973E-03,1.8515E-03,1.6172E-03,1.4829E-03,1.3715E-03,1.2486E-03,1.1372E-03 ,&
1.2201E-03,1.0659E-03,8.1723E-04,5.2576E-04,3.9146E-04,3.6860E-04,2.5716E-04,2.4573E-04,2.3430E-04,1.2287E-04,1.2287E-04,1.1143E-04,1.0313E-04,9.2733E-05,8.3596E-05 ,&
1.6545E-02,1.4019E-02,9.2640E-03,5.7549E-03,4.1718E-03,3.2860E-03,2.7145E-03,2.4116E-03,1.8858E-03,1.5287E-03,1.2829E-03,1.1601E-03,1.0372E-03,9.1433E-04,9.0290E-04 ,&
4.8080E-02,3.8661E-02,2.0680E-02,9.7099E-03,5.5835E-03,3.6404E-03,2.5631E-03,1.8573E-03,1.1515E-03,7.4863E-04,5.0290E-04,3.6860E-04,3.5716E-04,2.3430E-04,2.3430E-04 ,&
2.6431E-03,2.1032E-03,1.2116E-03,6.8293E-04,5.1433E-04,3.8003E-04,3.5716E-04,2.4573E-04,2.3430E-04,1.2287E-04,1.2287E-04,1.0663E-04,9.3433E-05,8.2841E-05,7.2864E-05 ,&
2.4946E-02,2.0549E-02,1.2105E-02,6.7351E-03,4.5662E-03,3.4660E-03,2.7488E-03,2.3230E-03,1.6858E-03,1.4172E-03,1.1715E-03,1.0372E-03,9.1433E-04,8.0290E-04,6.9146E-04 ,&
1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0       ,1.0        ,&
0.0       ,0.0       ,0.0	    ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0        ,&
0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0       ,0.0         &
/),(/15,17/)))



    contains
    subroutine get_pond_parameters
    integer :: i,j
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
        spray_values        =spray_p
        
        is_zero_depth = .FALSE.
        zero_depth = 0.0


	    rows_spraytable = rows_spraytable_P
        columns_spraytable = columns_spraytable_P
        
        allocate (spraytable (rows_spraytable, columns_spraytable))	
	    spraytable = spray_table_P 
        

        !do i = 1, rows_spraytable
        !    write(*,'(17G12.4)') (spraytable(i,j),j=1, columns_spraytable)
        !end do	
		
	end subroutine get_pond_parameters
   
	
	
    subroutine get_reservoir_parameters
        integer :: i,j
        
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

        
       ! spray_values        = spray_R
        
        rows_spraytable = rows_spraytable_R
        columns_spraytable = columns_spraytable_R
        
       allocate (spraytable (rows_spraytable, columns_spraytable))	
	   spraytable = spray_table_R 
        
       !write(*,*) 'Default Reservoir Spraydrift Table'
       !do i = 1, rows_spraytable
       !     write(*,'(17G12.4)') (spraytable(i,j),j=1, columns_spraytable)
       !end do
    end subroutine get_reservoir_parameters

    
    subroutine read_waterbodyfile(file_index)
    use constants_and_variables, ONLY: waterbody_file_unit

    integer,intent(in) :: file_index
	integer :: i,j
     
        open (UNIT=waterbody_file_unit, FILE= trim(waterbody_names(file_index)), STATUS ='old')
   
        read(waterbody_file_unit, *) this_waterbody_name       
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
        write(*,*) "qa check 1"
        read(waterbody_file_unit, *) is_zero_depth, zero_depth
        write(*,*) "qa check 2"
        read(waterbody_file_unit, *) 

		read(waterbody_file_unit, *) rows_spraytable, columns_spraytable ! data is 1 less column, col 0 is a text description in the vb interface, row 1 is length header
		
		allocate (spraytable (rows_spraytable, columns_spraytable-1))
		
		do i =1, rows_spraytable
			read(waterbody_file_unit, *) (spraytable(i,j),j=1, columns_spraytable-1)
		end do
		
		!write(*, *) 'spray table'
		!do i =1, rows_spraytable
		!	write(*,'(20G12.4)' ) (spraytable(i,j),j=1, columns_spraytable-1)
  !      end do
		

    end subroutine read_waterbodyfile
    
    
    
    
    
    
end Module waterbody_parameters
   
