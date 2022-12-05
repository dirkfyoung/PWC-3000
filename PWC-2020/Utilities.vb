Module Utilities

    Public Function RateFromHalflife(ByVal halflife As String) As Double
        'converts half life to rate. Assumes that a blank entry  means zero rate. Also assumes by EFED convention
        'that a 0 halflife means a zero rate.


        If halflife = "" Then
            RateFromHalflife = 0.0   'Blank means stable
        ElseIf Convert.ToSingle(halflife) = 0.0 Then
            RateFromHalflife = 0.0   'half life of 0 means stable
        Else
            RateFromHalflife = 0.69314 / halflife
        End If


    End Function



    Public Function BlankMeansZero(ByVal input As String) As String
        'converts hato single, recognizes that user intends blans to mean zero
        BlankMeansZero = input
        If input = "" Then
            BlankMeansZero = "0.0"  'Blank means stable
        End If

    End Function




    Sub TestRealNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox)
        'Tests if real
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True
        name.BackColor = Color.White

        Try
            TestNumber = name.Text
        Catch ex As Exception

            MsgBox(name.Text)
            name.BackColor = Color.Orange
            msg = "Check the value for " & name.Tag
            TrueOrFalse = False

            Return

        End Try

        If name.Text.Contains(",") Then
            '  MsgBox("No commas allowed for " & name.Tag)
            name.BackColor = Color.Orange
            msg = "No commas allowed for " & name.Tag
            TrueOrFalse = False
            Return
        End If

    End Sub


    Sub TestRealNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox, ByVal except As String)
        'This OVERLOAD will allow exceptions to the real number requirement, For example the null string would
        'indicate a zero rate of degradation if box is left blank
        'Tests if real
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True
        name.BackColor = Color.White

        If name.Text = except Then
            TrueOrFalse = True
            Return
        End If

        Try
            TestNumber = name.Text
        Catch ex As Exception

            name.BackColor = Color.Orange
            msg = "Check the value for " & name.Tag
            TrueOrFalse = False
            Return

        End Try

        If name.Text.Contains(",") Then
            '  MsgBox("No commas allowed for " & name.Tag)
            name.BackColor = Color.Orange
            msg = "No commas allowed for " & name.Tag
            TrueOrFalse = False
            Return
        End If

    End Sub


    Sub TestActualRealNumbers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As String)
        'This test the real number requirementfor any object, 
        'Tests if real
        'return True if everythin OK

        Dim TestNumber As Double
        TrueOrFalse = True


        Try
            TestNumber = name
        Catch ex As Exception
            msg = "Not a real number."

            TrueOrFalse = False
            Return
        End Try

        If name = "" Then Return  'blank boxes dont work with next
        If name.Contains(",") Then
            msg = "No commas allowed."
            TrueOrFalse = False
            Return
        End If

    End Sub



    Sub TestIntegers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox, ByVal except As String)
        'This OVERLOAD will allow exceptions to the number requirement, For example the null string would
        'indicate a zero if box is left blank
        'otherwise Tests if integer
        'return True if everythin OK

        Dim TestNumber As Integer
        Dim TestReal As Double

        TrueOrFalse = True

        name.BackColor = Color.White
        'test to see if its  a number


        If name.Text = except Then
            TrueOrFalse = True
            Return
        End If

        Try
            TestNumber = name.Text
        Catch ex As Exception
            msg = "Check the value for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End Try

        'testIntegers Today see if its an integer

        TestReal = name.Text
        If TestReal - TestNumber > 0.01 Then
            msg = "This value should be an integer:  " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End If

        If name.Text.Contains(",") Then
            msg = "No commas allowed for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End If
    End Sub



    Sub TestIntegers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As TextBox)
        Dim TestNumber As Integer
        Dim TestReal As Double

        TrueOrFalse = True

        name.BackColor = Color.White


        'test to see if its  a number

        Try
            TestNumber = name.Text
        Catch ex As Exception
            msg = "Check the value for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End Try

        'testIntegers Today see if its an integer

        TestReal = name.Text
        If TestReal - TestNumber > 0.01 Then
            msg = "This value should be an integer:  " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End If

        If name.Text.Contains(",") Then
            msg = "No commas allowed for " & name.Tag
            name.BackColor = Color.Orange
            TrueOrFalse = False
            Return
        End If
    End Sub



    Sub TestActualIntegers(ByRef TrueOrFalse As Boolean, ByRef msg As String, ByVal name As String)
        ' Test string, instead of text boxes
        Dim TestNumber As Integer
        Dim TestReal As Double

        TrueOrFalse = True


        Try
            TestNumber = name
        Catch ex As Exception
            msg = "Value should be an integer"
            TrueOrFalse = False
            Return
        End Try

        'testIntegers Today see if its an integer

        TestReal = name
        If TestReal - TestNumber > 0.01 Then
            msg = "Value should be an integer"
            TrueOrFalse = False
            Return
        End If

        Try


            If name.Contains(",") Then
                msg = "No commas allowed for " & name
                TrueOrFalse = False
                Return
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



    End Sub













    Sub CalendarCheck(ByVal dayBox As TextBox, ByVal monthBox As TextBox, ByRef TrueOrFalse As Boolean, ByRef msg As String)

        Dim monthtest As Integer
        Dim daytest As Integer

        TrueOrFalse = True
        msg = ""

        dayBox.BackColor = Color.White
        monthBox.BackColor = Color.White

        Try
            monthtest = Convert.ToInt16(monthBox.Text)
        Catch
            monthBox.BackColor = Color.Orange
            msg = "  Check " & monthBox.Tag
            TrueOrFalse = False
            Return
        End Try


        Try
            daytest = Convert.ToInt16(dayBox.Text)
        Catch
            dayBox.BackColor = Color.Orange
            msg = "  Check " & dayBox.Tag
            TrueOrFalse = False
            Return
        End Try

        If monthtest > 12 Or monthtest < 1 Then
            monthBox.BackColor = Color.Orange
            msg = "The following month is not posssible: " & monthBox.Tag
            TrueOrFalse = False
            Return
        End If

        Select Case monthtest
            Case 1, 3, 5, 7, 8, 10, 12
                If daytest > 31 Or daytest < 1 Then
                    '   MsgBox("Bad day for " & dayBox.Tag)
                    dayBox.BackColor = Color.Orange
                    msg = "Bad day for " & dayBox.Tag
                    TrueOrFalse = False
                    Return
                End If
            Case 2
                If daytest > 28 Or daytest < 1 Then
                    dayBox.BackColor = Color.Orange
                    msg = "Bad day for you and " & dayBox.Tag
                    TrueOrFalse = False
                    Return
                End If
            Case 4, 6, 9, 11
                If daytest > 30 Or daytest < 1 Then
                    dayBox.BackColor = Color.Orange
                    TrueOrFalse = False
                    msg = "Bad day for " & dayBox.Tag
                    Return
                End If
            Case Else
                monthBox.BackColor = Color.Orange
                TrueOrFalse = False
                msg = "Month does not exist on Earth calendar for " & monthBox.Tag
                Return
        End Select


    End Sub


    Public Function FindNode(ByVal depth As Double, ByVal horizonTable As DataGridView)

        'given a depth, returns the node that is closest to that depth as well as the approximated depth (testdepth) that will be used by the program.

        Dim deltaX As Double
        Dim testdepth As Double
        Dim node As Integer
        Dim increments As Integer
        Dim thickness As Double

        node = 0
        testdepth = 0.0

        'Smallest node is 1
        If depth <= 0 Then
            node = 1
            Return node
        End If


        For i As Integer = 0 To horizonTable.Rows.Count - 1
            increments = horizonTable(6, i).Value
            thickness = horizonTable(1, i).Value

            deltaX = thickness / increments

            For j As Integer = 1 To increments
                node = node + 1
                testdepth = testdepth + deltaX

                If testdepth >= depth Then
                    'Test if the overshoot was too much
                    If (testdepth - depth) < (depth - (testdepth - deltaX)) Then
                        Return node
                    Else
                        testdepth = testdepth - deltaX
                        node = node - 1
                        Return node
                    End If
                End If
            Next
        Next


        FindNode = node

    End Function


    Function CalculateSoilMass(ByVal horizonTable As DataGridView, ByVal top As Integer, ByVal bottom As Integer) As Double
        'Returns mass of soil per ha given a Horizon table with following set up:
        'Assume horizon table thickness is column 1 (zero based)
        'Assume horizon table density is column 2 (zero based)
        'Assume horizon table compartment number is in column 6 (zero based)

        Dim totalhorizons, totalcompartments As Integer

        totalhorizons = horizonTable.Rows.Count - 1

        totalcompartments = 0
        For i As Integer = 0 To totalhorizons - 1
            totalcompartments = totalcompartments + horizonTable(6, i).Value
        Next

        Dim mass(totalcompartments) As Double

        'Try


        'Create arrays
        Dim k As Integer
        k = 0
        For i As Integer = 0 To totalhorizons - 1

            For j As Integer = 1 To horizonTable(6, i).Value
                k = k + 1
                '   Kg = (thickness (cm)/ NumberComp/100)*(10000m2) * Bulk density kg/L * 1000 L/m3
                mass(k) = horizonTable(1, i).Value / horizonTable(6, i).Value * horizonTable(2, i).Value * 100000
            Next
        Next


        CalculateSoilMass = 0
        For i As Integer = top To bottom
            CalculateSoilMass = CalculateSoilMass + mass(i)
        Next




    End Function


End Module
