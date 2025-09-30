
Module PRZM_VERSION

   Implicit None

Contains
  Subroutine przm_id
    use  constants_and_variables, ONLY:   Version_Number 
     Implicit None


     WRITE(*,'(A19,1X,F7.3)')' PRZM-VVWM Version:', Version_Number  
     Write(*, *)
     Write(*, *) '    For technical support contact:'
     Write(*, *) '           Dirk F. Young ' 
     Write(*, *) '      Office of Pesticide Programs '
     Write(*, *) 'United States Environmental Protection Agency'
     Write(*, *) '      Washington, DC 20460-0001'
     Write(*, *) '      E-mail: young.dirk@epa.gov'
     Write(*, *)

   End Subroutine przm_id
 

End Module PRZM_VERSION

