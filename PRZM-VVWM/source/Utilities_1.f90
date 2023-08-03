
	module utilities_1
    implicit none
    
	contains 
	
    function get_order(x) result(order)
    !returns an integer array with indices idicating the sort order of original array x
       implicit none
       integer, intent(in) :: x(:)
       integer :: order(size(x))      ! Function result
    
       logical :: mask(size(x))
       integer :: i

       mask = .true.
       do i = 1, size(x)
             order(i) = findloc( x, value=minval(x,dim=1,mask=mask), dim=1 )
             mask(order(i)) = .false.
       end do  
    end function
    
    
    subroutine make_run_id (i,j, ii,mm)
    !makes a string that can be used for identifying output: Scheme#_Scenario#_ScenarioFileName (eg., 2_3_NDpumpkins)
    
    USE constants_and_variables, ONLY: run_id ,  scenario_id      !scenario_names
    USE waterbody_parameters, ONLY: waterbody_names
    implicit none
    integer, intent(in) :: i,j, ii,mm
    character(LEN=25) :: schemnumber, scenarionumber, appnumber
    integer :: last_slash, last_dot,last_slash2, last_dot2
    
    character(len=512) :: local_name
    
    write(schemnumber, *) i
    write(scenarionumber, *) j
    
    !last_slash = index(scenario_names(i,j), '\', .TRUE.)
    !last_dot   = index(scenario_names(i,j), '.', .TRUE.)
    
    last_slash2 = index(waterbody_names(ii), '\', .TRUE.)
    last_dot2   = index(waterbody_names(ii), '.', .TRUE.)
    
    IF (index(waterbody_names(ii), '.')==0) then
         local_name = waterbody_names(ii)
    else
         local_name= (waterbody_names(ii)((last_slash2+1):(last_dot2-1)))         
    end if
    
    write(appnumber, '(I4.4)') mm  !app window
    
    ! scheme_number_ScenarioName_WaterbodyName
    
    run_ID =  trim(adjustl(schemnumber)) // '_' //& 
    trim(scenario_id)  &
        // '_' // trim(adjustl(local_name)) // '_' // trim(adjustl(appnumber))
    

    !run_ID =  trim(adjustl(schemnumber)) // '_' //&
    !trim(adjustl(scenario_names(i,j)((last_slash+1):(last_dot-1))))  &
    !    // '_' // trim(adjustl(local_name)) // '_' // trim(adjustl(appnumber))
    
    write(*,*) "run id ", trim(run_ID)
     
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
      
 
  
!
     pure integer function find_depth_node(n,depth,desired) 
     !Given an array "depth" of size "n" that is ordered from low to high values, this 
     !function will give the index of "depth" that is closest to the value "desired"
    
      implicit none
      integer,intent(in)            :: n       !size of depth vector 
      real,dimension(n), intent(in) :: depth   !vector holding incremental depths)
      real,intent(in)               :: desired !desired depth
      
      integer :: i, index

      !write(*,*) "CHECK for N herree:   n, depth, desired"
      !write(*,*) n,depth,desired
      
      
      

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
         

     
     subroutine find_average_property(n, depth, target_depth, property, average)
     !weigted average, given vector of thicknesses and vector of correspnding property, Finds the average property
     !value of a target_depth
     implicit none
        integer,intent(in) :: n                      !size of input vectors for depth and prperty
        real   ,intent(in) :: depth(n)          !vector of cumulative depths 
        real   ,intent(in) :: property(n)            !property of interest corresponding to thicknrss vector
        real   ,intent(in) :: target_depth           ! target depth is lower depth for averaging
        real   ,intent(out):: average                 !average property value from zero depth to target depth
        
        integer :: i
        real ::  previous_depth, weighted_tally

        weighted_tally = 0.0
        previous_depth = 0.0
        
        do i = 1, n            
              if (depth(i) < target_depth) then
                  weighted_tally = weighted_tally+ property(i)*(depth(i) - previous_depth ) 
              elseif(depth(i) >= target_depth) then
      
                 weighted_tally = weighted_tally + property(i)*(target_depth -  previous_depth)

                 exit !exit do loop   
              end if 
              previous_depth = depth(i)
        end do
       average =  weighted_tally/target_depth
     end subroutine
     
    
     
     subroutine find_medians
     USE constants_and_variables, ONLY: hold_for_medians,  app_window_counter
     real :: median, pos_median, neg_median, test_for_median
     integer:: i, count_above, count_below
     logical :: got_pos, got_neg, got_median
      got_pos = .False.
      got_neg = .False.
      got_median = .False.
      

     do i = 1, app_window_counter
            test_for_median = hold_for_medians(1, i)  
            count_above = count (hold_for_medians(1,1:app_window_counter) >= test_for_median)
            count_below = count (hold_for_medians(1,1:app_window_counter) <= test_for_median)
            
  write(*,*) test_for_median, count_above, count_below, count_above - count_below
            if (count_above == count_below) then 
                    got_median = .TRUE.
                    exit
            else if (count_above - count_below == 1) then 
                    pos_median = test_for_median
                    got_pos = .TRUE.                  
            else if (count_above - count_below == -1) then 
                    neg_median = test_for_median
                    got_neg = .TRUE.
            end if
            if (got_pos .AND. got_neg) exit  
            
     end do
     
     if (got_median) then
           median = test_for_median
     else if (got_pos .AND. got_neg) then
           median = (pos_median + neg_median)/2.0
           
           
     else 
         write(*,*) "Can not find median"
     end if
     
     write(*,*) "median = " , median
     
     
     end subroutine find_medians
     
     
     
     
     
end module utilities_1
