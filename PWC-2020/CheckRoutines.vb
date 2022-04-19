Imports System.Globalization

Partial Public Class Form1
    Private Sub CheckChemicalInputs(ByRef TrueOrFalse As Boolean, ByRef msg As String)
        TrueOrFalse = True

        TestRealNumbers(TrueOrFalse, msg, sorption1)
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, WaterColMetab1, "")
        If TrueOrFalse = False Then Return

        If WaterColMetab1.Text <> "" Then
            TestRealNumbers(TrueOrFalse, msg, WaterColRef1)
            If TrueOrFalse = False Then Return
        End If

        TestRealNumbers(TrueOrFalse, msg, BenthicMetab1, "")
        If TrueOrFalse = False Then Return

        If BenthicMetab1.Text <> "" Then
            TestRealNumbers(TrueOrFalse, msg, BenthicRef1)
            If TrueOrFalse = False Then Return
        End If

        TestRealNumbers(TrueOrFalse, msg, Photo1, "")
        If TrueOrFalse = False Then Return

        If Photo1.Text <> "" Then
            TestRealNumbers(TrueOrFalse, msg, PhotoLat1)
            If TrueOrFalse = False Then Return
        End If

        TestRealNumbers(TrueOrFalse, msg, Hydrolysis1, "")
        If TrueOrFalse = False Then Return


        TestRealNumbers(TrueOrFalse, msg, SoilDegradation1, "")
        If TrueOrFalse = False Then Return

        If SoilDegradation1.Text <> "" Then
            TestRealNumbers(TrueOrFalse, msg, SoilRef1)
            If TrueOrFalse = False Then Return
        End If

        TestRealNumbers(TrueOrFalse, msg, MWT1, "")
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, VaporPress1, "")
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, Sol1, "")
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, Henry1, "")
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, AirDiff1, "")
        If TrueOrFalse = False Then Return

        TestRealNumbers(TrueOrFalse, msg, HeatHenry1, "")
        If TrueOrFalse = False Then Return

        'OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO
        If DoDegradate1.Checked Then
            TestRealNumbers(TrueOrFalse, msg, WaterMolarRatio1, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, BenthicMolarRatio1, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, PhotoMolarRatio1, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, HydroMolarRatio1, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, SoilMolarRatio1, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, FoliarMolarRatio1, "")
            If TrueOrFalse = False Then Return


            TestRealNumbers(TrueOrFalse, msg, sorption2)
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, WaterColMetab2, "")
            If TrueOrFalse = False Then Return

            If WaterColMetab2.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, WaterColRef2)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, BenthicMetab2, "")
            If TrueOrFalse = False Then Return

            If BenthicMetab2.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, BenthicRef2)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Photo2, "")
            If TrueOrFalse = False Then Return

            If Photo2.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, PhotoLat2)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Hydrolysis2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, SoilDegradation2, "")
            If TrueOrFalse = False Then Return

            If SoilDegradation2.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, SoilRef2)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, MWT2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, VaporPress2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, Sol2, "")
            If TrueOrFalse = False Then Return


            TestRealNumbers(TrueOrFalse, msg, Henry2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, AirDiff2, "")
            If TrueOrFalse = False Then Return


            TestRealNumbers(TrueOrFalse, msg, HeatHenry2, "")
            If TrueOrFalse = False Then Return

        End If

        If DoDegradate2.Checked Then

            TestRealNumbers(TrueOrFalse, msg, WaterMolarRatio2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, BenthicMolarRatio2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, PhotoMolarRatio2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, HydroMolarRatio2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, SoilMolarRatio2, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, FoliarMolarRatio2, "")
            If TrueOrFalse = False Then Return


            TestRealNumbers(TrueOrFalse, msg, sorption3)
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, WaterColMetab3, "")
            If TrueOrFalse = False Then Return

            If WaterColMetab3.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, WaterColRef3)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, BenthicMetab3, "")
            If TrueOrFalse = False Then Return

            If BenthicMetab3.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, BenthicRef3)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Photo3, "")
            If TrueOrFalse = False Then Return

            If Photo3.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, PhotoLat3)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Hydrolysis3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, SoilDegradation3, "")
            If TrueOrFalse = False Then Return

            If SoilDegradation3.Text <> "" Then
                TestRealNumbers(TrueOrFalse, msg, SoilRef3)
                If TrueOrFalse = False Then Return
            End If

            TestRealNumbers(TrueOrFalse, msg, MWT3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, VaporPress3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, Sol3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, Henry3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, AirDiff3, "")
            If TrueOrFalse = False Then Return

            TestRealNumbers(TrueOrFalse, msg, HeatHenry3, "")
            If TrueOrFalse = False Then Return

        End If

        'Check application information
        Dim NumberOfSchemes As Integer
        Dim ApplicationTable As New SchemeDetails
        Dim actualRowsInAppTable As Integer 'app table rows

        AppTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)  'commit the cell if cursor still on box

        NumberOfSchemes = SchemeTableDisplay.RowCount - 1
        SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit) 'commit the cell if cursor still on box

        For i As Integer = 0 To NumberOfSchemes - 1

            ApplicationTable = SchemeInfoList(i)

            'Application Table Information
            actualRowsInAppTable = ApplicationTable.Days.Count   'AppTableDisplay.RowCount - 1
            If actualRowsInAppTable < 1 Then
                msg = (String.Format("There are no pesticide applications for scheme number {0}", i + 1))
                TrueOrFalse = False
                Return
            End If

            Dim formats() As String = {"MM/d/yyyy", "MM/dd/yyyy", "M/dd/yyyy", "M/d/yyyy", "M/d", "MM/d", "M/d", "M/dd"}
            Dim thisDt As DateTime

            For j As Integer = 0 To actualRowsInAppTable - 1

                If ApplicationTable.AbsoluteRelative Then  'TRUE MEANS ABSOLUTE
                    If Not DateTime.TryParseExact(ApplicationTable.Days(j), formats, Globalization.CultureInfo.InvariantCulture, DateTimeStyles.None, thisDt) Then
                        msg = "Absolute Application date is not in the right format" & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                        TrueOrFalse = False
                        Return
                    End If

                Else
                    TestActualIntegers(TrueOrFalse, msg, ApplicationTable.Days(j))
                    msg = msg & String.Format(" for Scheme {0}, Row {1}", i + 1, j + 1)
                    If TrueOrFalse = False Then Return
                End If

                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Amount(j))
                If TrueOrFalse = False Then Return

                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Depth(j))
                If TrueOrFalse = False Then Return

                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Split(j))
                If TrueOrFalse = False Then Return

                'TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Efficiency(j))
                'If TrueOrFalse = False Then Return

                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Drift(j))
                If TrueOrFalse = False Then Return

                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Periodicity(j))
                If TrueOrFalse = False Then Return

                'Periodicity must be 1 or greater
                If ApplicationTable.Periodicity(j) < 1 Then
                    msg = "Periodicity in Application Table must be 1 or greater"
                    TrueOrFalse = False
                    Return
                End If



                TestActualRealNumbers(TrueOrFalse, msg, ApplicationTable.Lag(j))
                If TrueOrFalse = False Then Return



            Next
        Next



        'Check Optional Output Table
        AdditionalOutputGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim zts_modes As New List(Of String) From {"TSER", "TCUM", "TAVE", "TSUM"}

        For i As Integer = 0 To AdditionalOutputGridView.RowCount - 2  'minus 2 because there is always a last empty row

            TestActualIntegers(TrueOrFalse, msg, AdditionalOutputGridView.Item(1, i).Value)
            If TrueOrFalse = False Then Return

            If DoDegradate1.Checked = False Then
                If AdditionalOutputGridView.Item(1, i).Value > 1 Then
                    msg = String.Format("Chemical form must be less than 2.  Row {0} in Optional Outputs Table.  Degradate calculations were not selected on chemical tab.", i + 1)
                    TrueOrFalse = False
                    Return
                End If
            End If

            If DoDegradate2.Checked = False Then
                If AdditionalOutputGridView.Item(1, i).Value > 2 Then
                    msg = String.Format("Chemical form must be less than 3. Row {0} in Optional Outputs Table. Grandaughter calculations were not selected on chemical tab.", i + 1)
                    TrueOrFalse = False
                    Return
                End If
            End If

            If Not zts_modes.Contains((AdditionalOutputGridView.Item(2, i).Value)) Then
                msg = String.Format("Mode selection can only be TSER, TAVE, TSUM, or TCUM.  Row {0} in Optional Outputs Table.", i + 1)
                TrueOrFalse = False
                Return
            End If

            TestActualIntegers(TrueOrFalse, msg, AdditionalOutputGridView.Item(3, i).Value)
            msg = msg & String.Format(" Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False Then Return

            TestActualIntegers(TrueOrFalse, msg, AdditionalOutputGridView.Item(4, i).Value)
            msg = msg & String.Format(" Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False Then Return

            TestActualRealNumbers(TrueOrFalse, msg, AdditionalOutputGridView.Item(5, i).Value)
            msg = msg & String.Format(" Row {0} in Optional Outputs Table.", i + 1)
            If TrueOrFalse = False Then Return

        Next

    End Sub

End Class