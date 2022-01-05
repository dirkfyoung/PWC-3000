module clock_variables
!************************Clock Tinming  ***************************************    
real :: cputime_begin     !processor start reference time for begining of program
real :: time_1			  !cpu time at measured process
real :: time_2			  !cpu time at measured process
real :: time_3
real :: time_4
real :: time_5
real :: time_6

integer :: c_count, c_rate, C_max  !used for system clock routine calls	


real :: clock_time_0   !clock start reference time for begining of program
real :: clock_time	   !clock time at process being measured

real :: Cumulative_cpu_1, Cumulative_cpu_2, Cumulative_cpu_3
real :: Cumulative_cpu_4 
real :: Cumulative_cpu_5  
real :: Cumulative_cpu_6 
real :: Cumulative_cpu_7 ,  Cumulative_cpu_8, Cumulative_cpu_9


end module clock_variables