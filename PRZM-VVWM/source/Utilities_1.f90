
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
    
    USE constants_and_variables, ONLY: run_id ,  scenario_id ,  full_run_identification, working_directory, family_name   
    USE waterbody_parameters, ONLY: waterbody_names
    implicit none
    integer, intent(in) :: i,j, ii,mm
    character(LEN=25) :: schemnumber, scenarionumber, appnumber
    integer :: last_slash, last_dot,last_slash2, last_dot2
    
    character(len=512) :: local_name
    
    !*****turn numbers into text*****
    write(schemnumber,*) i
    write(scenarionumber,*) j
    
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
    
    write(*,'(A8, A256)') 'Run ID:', adjustl(run_ID )


    
    !run_ID =  trim(adjustl(schemnumber)) // '_' //&
    !trim(adjustl(scenario_names(i,j)((last_slash+1):(last_dot-1))))  &
    !    // '_' // trim(adjustl(local_name)) // '_' // trim(adjustl(appnumber))
    
    full_run_identification = trim(working_directory) // trim(family_name) // "_" // trim(run_id)
    

     
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
     use clock_variables
     implicit none
        integer,intent(in) :: n                      !size of input vectors for depth and prperty
        real   ,intent(in) :: depth(n)          !vector of cumulative depths 
        real   ,intent(in) :: property(n)            !property of interest corresponding to thicknrss vector
        real   ,intent(in) :: target_depth           ! target depth is lower depth for averaging
        real   ,intent(out):: average                 !average property value from zero depth to target depth
        
        integer :: i
        real ::  previous_depth, weighted_tally
call time_check('averag deep loop 1') 
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
     
    
     
     subroutine find_medians(rows, columns, local_hold_for_medians, medians)
        !Find median of array with 10 columns and 
         integer, intent(in) ::  rows, columns
         
         real, intent(in)    ::  local_hold_for_medians(columns, rows) 
         real, intent(out)   ::  medians(columns)
        
         real :: pos_median, neg_median, test_for_median
         integer:: i,j, count_above, count_below
         logical :: got_pos, got_neg, got_median
         
         test_for_median = 0.0
         
         do j = 1, columns !loop for each conc
              got_pos = .False.
              got_neg = .False.
              got_median = .False.    
               
              do i = 1, rows !days
                   test_for_median = local_hold_for_medians(j, i)  
                   count_above = count (local_hold_for_medians(j,:) >= test_for_median)
                   count_below = count (local_hold_for_medians(j,:) <= test_for_median)
                   
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
                  medians(j) = test_for_median
              else if (got_pos .AND. got_neg) then
                  medians(j) = (pos_median + neg_median)/2.0
              else 
                  write(*,*) "Can not find median"
              end if
         end do
     end subroutine find_medians
     
     
     
     subroutine pick_max (num_years,num_records,bounds,c, output)
!    !this subroutine choses the maximum values of subsets of the vector c
!    !the subsets are defined by the vector "bounds"
!    !maximum values of "c" are chosen from within the c indices defined by "bounds"
!    !output is delivered in the vector "output"
    implicit none
    integer, intent(in) :: num_records
    integer, intent(in) :: num_years
    integer, intent(in) :: bounds(num_years)
    real, intent(in), dimension(num_records) :: c
    real, intent(out),dimension(num_years) :: output

    integer :: i

    !forall (i = 1: num_years-1) output(i) = maxval( c(bounds(i):bounds(i+1)-1) ) changed 2/5/2020
    
    
    
    do concurrent(i = 1: num_years-1)
        output(i) = maxval( c(bounds(i):bounds(i+1)-1) )
    end do
    
    output(num_years)= maxval( c(bounds(num_years):num_records) )

    
     end subroutine pick_max

     
     
     
 !***************************************************************
subroutine Return_Frequency_Value(returnfrequency, c_in, n, c_out, lowYearFlag)
    !CALCULATES THE Concentration at the given yearly return frequency
    implicit none
    
    real,intent(in) :: returnfrequency             !Example 1 in 10 years would be 10.0
    integer,intent(in) :: n                        !number of items in list
    real, intent(in), dimension(n):: c_in          !list of items
    
    real,intent(out):: c_out                       !output of 90th centile of peaks
    real:: f,DEC      
    integer:: m    
    real,dimension(n):: c_sorted
    logical, intent(out) :: LowYearFlag  !if n is less than 10, returns max value and LowYearFlag =1
    LowYearFlag = .false.

    call hpsort(n,c_sorted, c_in)  !returns a sorted array
    
    f = (1.0 -1.0/returnfrequency )*(n+1)
    m=int(f)
    DEC = f-m      
    
   if (n < returnfrequency)then
      c_out = c_sorted(n)
      LowYearFlag = .true.
   else 
    c_out = c_sorted(m)+DEC*(c_sorted(m+1)-c_sorted(m))
   end if

end subroutine Return_Frequency_Value    
     
!****************************************************************
subroutine hpsort(n,ra,b)
!  from numerical recipes  (should be upgraded to new f90 routine)
    implicit none
    integer,intent(in):: n
    real,intent(out),dimension(n)::ra !ordered output array
    real,intent(in),dimension(n):: b  !original unordered input array

    integer i,ir,j,l
    real rra
    
    ra=b    ! this added to conserve original order

    if (n.lt.2) return

    l=n/2+1
    ir=n
10    continue
    if(l.gt.1)then 
    l=l-1
    rra=ra(l)
    else 
    rra=ra(ir)    
    ra(ir)=ra(1)
    ir=ir-1
    if(ir.eq.1)then 
    ra(1)=rra 
    return
    endif
    endif
    i=l 
    j=l+l
20    if(j.le.ir)then 
        if(j.lt.ir)then
            if(ra(j).lt.ra(j+1))j=j+1 
        endif
        if(rra.lt.ra(j))then 
            ra(i)=ra(j)
            i=j
            j=j+j
        else 
            j=ir+1
        endif
        goto 20
        endif
    ra(i)=rra
    goto 10
end subroutine hpsort
!*******************************************************************************     
     
!*******************************************************************************
subroutine find_first_annual_dates(num_years, first_annual_dates )
   use constants_and_variables, ONLY: first_year, first_mon, first_day, startday
   use utilities
   implicit none
   
   integer,intent(in) :: num_years
   integer,intent(out),dimension(num_years) :: first_annual_dates
   integer i

   do i = 1,num_years
      first_annual_dates(i) =  jd(first_year+(i-1), first_mon,first_day )    
   end do

   first_annual_dates = first_annual_dates - startday+1

end subroutine find_first_annual_dates
!********************************************************************************






end module utilities_1
