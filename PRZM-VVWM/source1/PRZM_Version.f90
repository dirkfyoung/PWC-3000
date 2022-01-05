
Module PRZM_VERSION

   Implicit None

Contains
  Subroutine przm_id(Uout)
    use  constants_and_variables, ONLY:   Version_Number 
     Implicit None
     Integer, Intent(In) :: Uout   ! Echo Output unit number

     WRITE(Uout,'(A48,1X,F7.3)')'PRZM5-VVWM Version:', Version_Number  
     Write(Uout, *)
     Write(Uout, *) '    For technical support contact:'
     Write(Uout, *) '           Dirk F. Young ' 
     Write(Uout, *) '      Office of Pesticide Programs '
     Write(Uout, *) 'United States Environmental Protection Agency'
     Write(Uout, *) '      Washington, DC 20460-0001'
     Write(Uout, *) '      E-mail: young.dirk@epa.gov'
     Write(Uout, *)

   End Subroutine przm_id
 

End Module PRZM_VERSION

