
	module utilities_1
    implicit none
    
    contains 

    
    
    subroutine make_run_id (i,j, ii,mm)
    !makes a string that can be used for identifying output: Scheme#_Scenario#_ScenarioFileName (eg., 2_3_NDpumpkins)
    
    USE constants_and_variables, ONLY: scenario_names, run_id
    USE waterbody_parameters, ONLY: waterbody_names
    implicit none
    integer, intent(in) :: i,j, ii,mm
    character(LEN=25) :: schemnumber, scenarionumber, appnumber
    integer :: last_slash, last_dot,last_slash2, last_dot2
    
    character(len=512) :: local_name
    
    write(schemnumber, *) i
    write(scenarionumber, *) j
    
    last_slash = index(scenario_names(i,j), '\', .TRUE.)
    last_dot   = index(scenario_names(i,j), '.', .TRUE.)
    
    last_slash2 = index(waterbody_names(ii), '\', .TRUE.)
    last_dot2   = index(waterbody_names(ii), '.', .TRUE.)
    
    IF (index(waterbody_names(ii), '.')==0) then
         local_name = waterbody_names(ii)
    else
         local_name= (waterbody_names(ii)((last_slash2+1):(last_dot2-1)))         
    end if
    write(appnumber, '(I4.4)') mm
    
    ! scheme_number_ScenarioName_WaterbodyName
    run_ID =  trim(adjustl(schemnumber)) // '_' //&
    trim(adjustl(scenario_names(i,j)((last_slash+1):(last_dot-1))))  &
        // '_' // trim(adjustl(local_name)) // '_' // trim(adjustl(appnumber))
    
    
    end subroutine make_run_id 
    
    
    
    SUBROUTINE tridiagonal_solution(A,B,C,X,F,n)
        implicit none
        integer,intent(in) :: n
        real,intent(in)    :: A(n), B(n),C(n) , F(n)
        real,intent(out)   :: X(n)
        
        real :: Y(n), ALPHA(n), BETA(n)
        integer :: nu, i, j
        
        ALPHA(1) = B(1)
        BETA(1) = C(1)/ALPHA(1)
        Y(1) = F(1)/ALPHA(1)
        do I=2, N
            ALPHA(I) = B(I) - A(I)*BETA(I-1)
            BETA(I) = C(I)/ALPHA(I)
            Y(I) = (F(I)-A(I)*Y(I-1))/ALPHA(I)
        end do
  
        X(N) = Y(N)
        NU=N-1

        do I=1, NU
            J=N-I
            X(J) = Y(J) - BETA(J)*X(J+1)          
        end do
    end subroutine tridiagonal_solution
    

               
  !*****************************************************************************
   pure elemental integer function jd (YEAR,MONTH,DAY)
     !calculate the days since 1/1/1900 given year,month, day, from Fliegel and van Flandern (1968)
    !Fliegel, H. F. and van Flandern, T. C. (1968). Communications of the ACM, Vol. 11, No. 10 (October, 1968). 

     implicit none
     integer, intent(in) :: year,month,day

      JD= day-32075+1461*(year+4800+(month-14)/12)/4+367*(month-2-(month-14)/12*12) /12-3*((year+4900+(month-14)/12)/100)/4 -2415021

   end function jd
   !*****************************************************************************
   
   pure subroutine get_date (date1900, YEAR,MONTH,DAY)
 !computes THE GREGORIAN CALENDAR DATE (YEAR,MONTH,DAY) given days since 1900
   implicit none

   integer,intent(out) :: YEAR,MONTH,DAY

   integer,intent(in) :: date1900  !days since 1900
   integer :: L,n,i,j

   L= 2483590 + date1900

   n= 4*L/146097

   L= L-(146097*n+3)/4
   I= 4000*(L+1)/1461001
   L= L-1461*I/4+31
   J= 80*L/2447

   day= L-2447*J/80
   L= J/11
   month = J+2-12*L
   year = 100*(N-49)+I+L

 !   YEAR= I
 !  MONTH= J
 !  DAY= K

   end subroutine get_date
      
 
  

     pure integer function find_depth_node(n,depth,desired) 
     !Given an array "depth" of size "n" that is ordered from low to high values, this 
     !function will give the index of "depth" that is closest to the value "desired"
    
      implicit none
      integer,intent(in)            :: n       !size of depth vector 
      real,dimension(n), intent(in) :: depth   !vector holding incremental depths)
      real,intent(in)               :: desired !desired depth
      
      integer :: i, index


      do i=1, n 
          index = i  !store value for the case where we go to the max n and i would be incremented another 1 value
          if (depth(i) > desired) exit
      end do

      
      i = index     !if i falls out the loop above it will have a value of n+1, so we use index to capture real value
      if  (i==1) then 
          find_depth_node = 1
      else if (abs(depth(i) - desired) < abs (depth(i-1) - desired)) then
          find_depth_node = i
      else
          find_depth_node = i-1
      end if

     end function find_depth_node  
         
end module utilities_1