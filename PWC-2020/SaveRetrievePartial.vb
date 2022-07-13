﻿Partial Public Class Form1

    Sub SaveInputsAsTextFile(ByVal savefile As String)
        Dim msg As String
        msg = "PWC 2021 Input File, Version " & VersionNumber
        msg &= String.Format("{0}{1}", vbNewLine, WorkingDirectoryLabel.Text)  'Dont put commas on the end of long strings, need to leave off for fortran read
        msg &= String.Format("{0}{1}", vbNewLine, IOFamilyName.Text)
        msg &= String.Format("{0}{1}", vbNewLine, WeatherDirectoryBox.Text)

        msg &= String.Format("{0}{1}, {2}, {3},", vbNewLine, isKoc.Checked, UseFreundlich.Checked, UseNonequilibrium.Checked)

        Dim nchem As String
        If DoDegradate1.Checked And DoDegradate2.Checked Then 'daughter and graddaugter
            nchem = "3"
        ElseIf DoDegradate1.Checked And DoDegradate2.Checked = False Then 'daughter
            nchem = "2"
        Else 'parent only'
            nchem = "1"
        End If
        msg = msg & String.Format("{0}{1},", vbNewLine, nchem)


        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, sorption1.Text, sorption2.Text, sorption3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, Nexp1Reg1.Text, Nexp2Reg1.Text, Nexp3Reg1.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, Kf1Reg2.Text, Kf2Reg2.Text, Kf3Reg2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, Nexp1Reg2.Text, Nexp2Reg2.Text, Nexp3Reg2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, MassTransferRegion2.Text, MassTransferRegion2Daughter.Text, MassTransferRegion2GrandDaughter.Text)
        msg = msg & String.Format("{0}{1},{2},", vbNewLine, FreundlichMinimumConc.Text, SubTimeSteps.Text)

        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, WaterColMetab1.Text, WaterColMetab2.Text, WaterColMetab3.Text, WaterMolarRatio1.Text, WaterMolarRatio2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, WaterColRef1.Text, WaterColRef2.Text, WaterColRef3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, BenthicMetab1.Text, BenthicMetab2.Text, BenthicMetab3.Text, BenthicMolarRatio1.Text, BenthicMolarRatio2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, BenthicRef1.Text, BenthicRef2.Text, BenthicRef3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, Photo1.Text, Photo2.Text, Photo3.Text, PhotoMolarRatio1.Text, PhotoMolarRatio2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, PhotoLat1.Text, PhotoLat2.Text, PhotoLat3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, Hydrolysis1.Text, Hydrolysis2.Text, Hydrolysis3.Text, HydroMolarRatio1.Text, HydroMolarRatio2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},", vbNewLine, SoilDegradation1.Text, SoilDegradation2.Text, SoilDegradation3.Text, SoilMolarRatio1.Text, SoilMolarRatio2.Text, IsAllMedia.Checked)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, SoilRef1.Text, SoilRef2.Text, SoilRef3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, FoliarDeg1.Text, FoliarDeg2.Text, FoliarDeg3.Text, FoliarMolarRatio1.Text, FoliarMolarRatio2.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, FoliarWashoff1.Text, FoliarWashoff2.Text, FoliarWashoff3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, MWT1.Text, MWT2.Text, MWT3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, VaporPress1.Text, VaporPress2.Text, VaporPress3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, Sol1.Text, Sol2.Text, Sol3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, Henry1.Text, Henry2.Text, Henry3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, AirDiff1.Text, AirDiff2.Text, AirDiff3.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, HeatHenry1.Text, HeatHenry2.Text, HeatHenry3.Text)
        msg = msg & String.Format("{0}{1},", vbNewLine, Q10.Text)

        msg = msg & String.Format("{0}{1},", vbNewLine, ConstantProfile.Checked)
        msg = msg & String.Format("{0}{1},{2},{3},{4},", vbNewLine, RampProfile.Checked, profileDepth1.Text, ProfileDepth2.Text, RampEndValue.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, ExponentialProfile.Checked, ExpParameter1.Text, ExpParameter2.Text)



        'Schemes***************************
        Dim NumberOfSchemes As Integer
        Dim ApplicationTable As New SchemeDetails
        Dim actualRowsInAppTable As Integer 'app table rows

        Dim NumberOfScenarios As Integer
        Dim referencedate As Integer

        AppTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)  'commit the cell if cursor still on box


        NumberOfSchemes = SchemeTableDisplay.RowCount - 1
        msg = msg & String.Format("{0}{1},", vbNewLine, NumberOfSchemes)
        SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit) 'commit the cell if cursor still on box

        For i As Integer = 0 To NumberOfSchemes - 1
            msg = msg & String.Format("{0}{1},{2},", vbNewLine, (i + 1), """" & SchemeTableDisplay.Item(3, i).Value & """")


            ApplicationTable = SchemeInfoList(i)

            Select Case True
                Case ApplicationTable.AbsoluteRelative
                    referencedate = 0
                Case ApplicationTable.Emerge
                    referencedate = 1
                Case ApplicationTable.Maturity
                    referencedate = 2
                Case ApplicationTable.Removal
                    referencedate = 3
                Case Else
                    referencedate = 99
            End Select

            msg = msg & String.Format("{0}{1},", vbNewLine, referencedate)

            'Application Table Information
            actualRowsInAppTable = ApplicationTable.Days.Count   'AppTableDisplay.RowCount - 1
            msg = msg & String.Format("{0}{1},", vbNewLine, actualRowsInAppTable)

            For j As Integer = 0 To actualRowsInAppTable - 1

                msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},{7},{8},{9},", vbNewLine, ApplicationTable.Days(j), ApplicationTable.Amount(j),
                                          ApplicationTable.Method(j), ApplicationTable.Depth(j), ApplicationTable.Split(j),
                                          ApplicationTable.Drift(j), ApplicationTable.DriftFactor(j), ApplicationTable.Periodicity(j), ApplicationTable.Lag(j))
            Next


            msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, ApplicationTable.UseApplicationWindow, ApplicationTable.ApplicationWindowSpan, ApplicationTable.ApplicationWindowStep)
            msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, ApplicationTable.UseRainFast, ApplicationTable.RainLimit, ApplicationTable.IntolerableRainWindow, ApplicationTable.OptimumApplicationWindow, ApplicationTable.MinDaysBetweenApps)


            NumberOfScenarios = ApplicationTable.Scenarios.Count
            msg = msg & vbNewLine & NumberOfScenarios

            For j As Integer = 0 To NumberOfScenarios - 1
                msg = msg & vbNewLine & ApplicationTable.Scenarios(j)
            Next

        Next

        msg &= String.Format("{0}{1},", vbNewLine, ErosionFlag.Text)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)

        msg &= String.Format("{0}{1},", vbNewLine, AdjustCN.Checked)
        msg &= String.Format("{0}{1},{2},{3}", vbNewLine, ItsaPond.Checked, ItsaReservoir.Checked, ItsOther.Checked)
        msg &= String.Format("{0}{1},", vbNewLine, WaterbodyList.Items.Count)

        For Each specialwaterbody As String In WaterbodyList.Items
            msg = msg & vbNewLine & """" & specialwaterbody & """"
        Next

        '*********** OUTPUT ******************************

        msg = msg & vbNewLine & outputRunoff.Checked & ","
        msg = msg & vbNewLine & outputErosion.Checked & ","
        msg = msg & vbNewLine & outputPestRunoff.Checked & ","
        msg = msg & vbNewLine & outputPestErosion.Checked & ","

        msg = msg & vbNewLine & outputConcLastLayer.Checked & ","
        msg = msg & vbNewLine & outputDailyFieldVolatilization.Checked & ","
        'msg = msg & vbNewLine & outputCumulativeFieldVolatilzation.Checked

        msg = msg & vbNewLine & OutputDailyPestLeached.Checked & "," & chemInfiltrationDepth.Text & ","
        '  msg = msg & vbNewLine & outputCumulativePestLeached.Checked
        msg = msg & vbNewLine & OutputDecayedPest.Checked & "," & OutputDecayDepth1.Text & "," & OutputDecayDepth2.Text & ","
        msg = msg & vbNewLine & outputMassInSoilProfile.Checked
        msg = msg & vbNewLine & outputMassSoilSpecific.Checked & "," & OutputMassDepth1.Text & "," & OutputMassDepth2.Text & ","
        msg = msg & vbNewLine & outputMassOnFoliage.Checked & ","

        msg = msg & vbNewLine & outputPrecipitation.Checked & ","
        msg = msg & vbNewLine & outputActualEvap.Checked & ","
        msg = msg & vbNewLine & outputTotalSoilWater.Checked & ","
        msg = msg & vbNewLine & outputIrrigation.Checked & ","
        msg = msg & vbNewLine & outputInfiltrationAtDepth.Checked & "," & OutputInfiltrationDepth.Text & ","
        msg = msg & vbNewLine & outputInfiltratedWaterLastLayer.Checked & ","

        msg = msg & vbNewLine & outputWaterConc.Checked & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","

        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","

        AdditionalOutputGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)
        Dim NumberAdditionalOutputs As Integer
        NumberAdditionalOutputs = AdditionalOutputGridView.RowCount - 1
        msg = msg & vbNewLine & NumberAdditionalOutputs & ","



        For i As Integer = 0 To NumberAdditionalOutputs - 1
            msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},", vbNewLine,
                  AdditionalOutputGridView.Item(0, i).Value, AdditionalOutputGridView.Item(1, i).Value,
                  AdditionalOutputGridView.Item(2, i).Value, AdditionalOutputGridView.Item(3, i).Value,
                  AdditionalOutputGridView.Item(4, i).Value, AdditionalOutputGridView.Item(5, i).Value)
        Next



        'Dim MoreOutputRequested As Boolean
        'MoreOutputRequested = False
        'For Each ctrl As Control In OptionalOutputTab.Controls
        '    If TypeOf ctrl Is CheckBox AndAlso DirectCast(ctrl, CheckBox).Checked Then
        '        MoreOutputRequested = True
        '    End If
        'Next
        'If NumberAdditionalOutputs > 0 Then
        '    MoreOutputRequested = True
        'End If


        Try
            My.Computer.FileSystem.WriteAllText(savefile, msg, False, System.Text.Encoding.ASCII)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub


    Private Function CreateScenarioString() As String
        'Private Function WaterBodyInfo() As String
        Dim msg As String

        msg = ScenarioID.Text
        msg = msg & vbNewLine & WeatherFileName.Text
        msg = msg & vbNewLine & latitude.Text

        For i = 1 To 24  'This is all the waterbody stuff in the old scenarios
            msg = msg & vbNewLine
        Next

        msg = msg & vbNewLine

        msg = msg & "******** start of PRZM information ******************" & vbNewLine 'line 28
        msg = msg & String.Format("{0},{1},{2},", "False", Evergreen.Checked, "False")

        Dim numberOfCrops As Integer

        CropGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)

        numberOfCrops = CropGridView.RowCount - 1

        msg = msg & String.Format("{0}{1}", vbNewLine, numberOfCrops)
        Dim simple As Boolean
        If numberOfCrops = 1 Then
            simple = True
        Else
            simple = False
        End If
        msg = msg & String.Format("{0}{1},", vbNewLine, simple)


        Dim AA, BB, CC As Date
        Dim DD As String
        Dim DDout As Integer

        For i As Integer = 0 To numberOfCrops - 1
            AA = CropGridView.Item(0, i).Value
            BB = CropGridView.Item(1, i).Value
            CC = CropGridView.Item(2, i).Value

            DD = CropGridView.Item(7, i).Value

            Select Case DD
                Case "Surface Applied"
                    DDout = 1
                Case "Removed"
                    DDout = 2
                Case "Left on Plant"
                    DDout = 3
                Case Else
                    DDout = 1
            End Select

            msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13} ", vbNewLine,
                                      AA.Day, AA.Month, BB.Day, BB.Month, CC.Day, CC.Month,
                                      CropGridView.Item(3, i).Value, CropGridView.Item(4, i).Value, CropGridView.Item(5, i).Value,
                                      CropGridView.Item(6, i).Value, DDout, CropGridView.Item(8, i).Value,
                                      CropGridView.Item(9, i).Value)
        Next
        For i As Integer = numberOfCrops To 6
            msg = msg & String.Format("{0},,,,,,,,,,,,", vbNewLine)
        Next

        'msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altRootDepth.Text, altCanopyCover.Text, altCanopyHeight.Text, altCanopyHoldup.Text)
        'msg = msg & String.Format("{0}{1},{2},{3},{4}", vbNewLine, altEmergeDay.Text, altEmergeMon.Text, altDaysToMaturity.Text, altDaysToHarvest.Text)

        msg = msg & vbNewLine & ",,,"
        msg = msg & vbNewLine & ",,,"

        msg = msg & String.Format("{0}{1},{2},{3}", vbNewLine, PETadjustment.Text, snowMelt.Text, evapDepth.Text)


        msg = msg & vbNewLine & "*** irrigation information start ***"
        If noIrrigation.Checked Then
            msg = msg & String.Format("{0}0", vbNewLine)

        ElseIf overCanopy.Checked Then
            msg = msg & String.Format("{0}1", vbNewLine)

        ElseIf underCanopy.Checked Then
            msg = msg & String.Format("{0}2", vbNewLine)
        Else
            msg = msg & String.Format("{0}0", vbNewLine)
        End If

        msg = msg & String.Format("{0}{1},{2},{3}", vbNewLine, fleach.Text, depletion.Text, rateIrrig.Text)
        msg = msg & String.Format("{0}{1},{2}", vbNewLine, UserSpecifiesIrrigDepth.Checked, IrrigationDepthUserSpec.Text)
        msg = msg & vbNewLine & "*** spare line for expansion"
        msg = msg & vbNewLine & "*** spare line for expansion"
        msg = msg & vbNewLine & "*** Soil Information ***"

        msg = msg & String.Format("{0}{1},{2},{3}", vbNewLine, usleK.Text, usleLS.Text, usleP.Text)
        msg = msg & String.Format("{0}{1},{2}", vbNewLine, ireg.Text, slope.Text)


        msg = msg & vbNewLine & "*** Horizon Info *******" '
        HorizonGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim numberofhorizons As Integer
        numberofhorizons = HorizonGridView.RowCount - 1

        msg = msg & String.Format("{0}{1}{0}", vbNewLine, numberofhorizons)


        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(1, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(2, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(3, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(4, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(5, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(6, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(7, i).Value)
        Next
        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhorizons - 1
            msg = msg & String.Format("{0},", HorizonGridView.Item(8, i).Value)
        Next


        msg = msg & vbNewLine & "*** Horizon End, Temperature Start ********"

        msg = msg & String.Format("{0}{1},{2}", vbNewLine, albedo.Text, bcTemp.Text)
        msg = msg & vbNewLine & SimTemperature.Checked
        msg = msg & vbNewLine & "***spare line for expansion"
        msg = msg & vbNewLine & "***spare line for expansion"
        msg = msg & vbNewLine & "*** Erosion & Curve Number Info **********"

        HydroDataGrid.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim numberofhydrofactors As Integer
        numberofhydrofactors = HydroDataGrid.RowCount - 1

        msg = msg & vbNewLine & numberofhydrofactors


        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhydrofactors - 1
            AA = HydroDataGrid.Item(0, i).Value
            msg = msg & AA.Day & ","
        Next

        msg = msg & vbNewLine

        For i As Integer = 0 To numberofhydrofactors - 1
            AA = HydroDataGrid.Item(0, i).Value
            msg = msg & AA.Month & ","
        Next

        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhydrofactors - 1
            msg = msg & HydroDataGrid.Item(1, i).Value & ","
        Next

        msg = msg & vbNewLine
        For i As Integer = 0 To numberofhydrofactors - 1
            msg = msg & HydroDataGrid.Item(2, i).Value & ","
        Next

        msg = msg & vbNewLine & "Spare, old mannings"

        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, rDepth.Text, rDecline.Text, rInteracting.Text)
        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, eDepth.Text, eDecline.Text, eInteracting.Text)
        msg = msg & vbNewLine & "False"
        msg = msg & vbNewLine & ",,,,,"
        ' msg = msg & vbNewLine & useUSLEYear.Checked & vbNewLine
        'For i As Integer = 0 To USLE.MaxHydroErosionFactors - 1
        '    msg = msg & USLE.year(i).Text & ","
        'Next

        msg = msg & vbNewLine & VolatilizationBounday.Text


        msg = msg & vbNewLine & useAutoGWprofile.Checked
        Dim numberofdiscreterows As Integer
        numberofdiscreterows = DiscretizationGridView.RowCount - 1
        msg = msg & vbNewLine & numberofdiscreterows

        For i As Integer = 0 To numberofdiscreterows - 1
            msg = msg & String.Format("{0}{1}, {2}", vbNewLine, DiscretizationGridView.Item(0, i).Value, DiscretizationGridView.Item(1, i).Value)

        Next



        Return msg


    End Function


    Sub ReadInputsFromTextFile(ByVal filename As String)


        SchemeInfoList.Clear()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
            Dim currentrow As String()

            WorkingDirectoryLabel.Text = System.IO.Path.GetDirectoryName(filename) & "\"
            FileNames.WorkingDirectory = System.IO.Path.GetDirectoryName(filename) & "\"

            IOFamilyName.Text = System.IO.Path.GetFileNameWithoutExtension(filename)

            WorkingDirectoryLabel.ForeColor = Color.Black
            IOFamilyName.ForeColor = Color.Black

            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")


            MyReader.ReadLine() 'Title Line
            MyReader.ReadLine() 'working directory, not retrieved here, so can alter
            MyReader.ReadLine() 'family name not retrieved, so can alter, needed for transfer to vvwm
            'Weather Path
            WeatherDirectoryBox.Text = MyReader.ReadLine()

            'Chemical Proerties
            currentrow = MyReader.ReadFields
            isKoc.Checked = currentrow(0)
            UseFreundlich.Checked = currentrow(1)
            UseNonequilibrium.Checked = currentrow(2)

            Dim nchem As Integer
            currentrow = MyReader.ReadFields
            nchem = currentrow(0)
            Select Case nchem
                Case 3
                    DoDegradate1.Checked = True
                    DoDegradate2.Checked = True
                Case 2
                    DoDegradate1.Checked = True
                    DoDegradate2.Checked = False
                Case 1
                    DoDegradate1.Checked = False
                    DoDegradate2.Checked = False
                Case Else
            End Select


            currentrow = MyReader.ReadFields
            sorption1.Text = currentrow(0)
            sorption2.Text = currentrow(1)
            sorption3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Nexp1Reg1.Text = currentrow(0)
            Nexp2Reg1.Text = currentrow(1)
            Nexp3Reg1.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Kf1Reg2.Text = currentrow(0)
            Kf2Reg2.Text = currentrow(1)
            Kf3Reg2.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Nexp1Reg2.Text = currentrow(0)
            Nexp2Reg2.Text = currentrow(1)
            Nexp3Reg2.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            MassTransferRegion2.Text = currentrow(0)
            MassTransferRegion2Daughter.Text = currentrow(1)
            MassTransferRegion2GrandDaughter.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            FreundlichMinimumConc.Text = currentrow(0)
            SubTimeSteps.Text = currentrow(1)

            currentrow = MyReader.ReadFields
            WaterColMetab1.Text = currentrow(0)
            WaterColMetab2.Text = currentrow(1)
            WaterColMetab3.Text = currentrow(2)
            WaterMolarRatio1.Text = currentrow(3)
            WaterMolarRatio2.Text = currentrow(4)

            currentrow = MyReader.ReadFields
            WaterColRef1.Text = currentrow(0)
            WaterColRef2.Text = currentrow(1)
            WaterColRef3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            BenthicMetab1.Text = currentrow(0)
            BenthicMetab2.Text = currentrow(1)
            BenthicMetab3.Text = currentrow(2)
            BenthicMolarRatio1.Text = currentrow(3)
            BenthicMolarRatio2.Text = currentrow(4)

            currentrow = MyReader.ReadFields
            BenthicRef1.Text = currentrow(0)
            BenthicRef2.Text = currentrow(1)
            BenthicRef3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Photo1.Text = currentrow(0)
            Photo2.Text = currentrow(1)
            Photo3.Text = currentrow(2)
            PhotoMolarRatio1.Text = currentrow(3)
            PhotoMolarRatio2.Text = currentrow(4)

            currentrow = MyReader.ReadFields
            PhotoLat1.Text = currentrow(0)
            PhotoLat2.Text = currentrow(1)
            PhotoLat3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Hydrolysis1.Text = currentrow(0)
            Hydrolysis2.Text = currentrow(1)
            Hydrolysis3.Text = currentrow(2)
            HydroMolarRatio1.Text = currentrow(3)
            HydroMolarRatio2.Text = currentrow(4)

            currentrow = MyReader.ReadFields
            SoilDegradation1.Text = currentrow(0)
            SoilDegradation2.Text = currentrow(1)
            SoilDegradation3.Text = currentrow(2)
            SoilMolarRatio1.Text = currentrow(3)
            SoilMolarRatio2.Text = currentrow(4)
            IsAllMedia.Checked = currentrow(5)
            IsAqueousDegradation.Checked = Not IsAllMedia.Checked

            currentrow = MyReader.ReadFields
            SoilRef1.Text = currentrow(0)
            SoilRef2.Text = currentrow(1)
            SoilRef3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            FoliarDeg1.Text = currentrow(0)
            FoliarDeg2.Text = currentrow(1)
            FoliarDeg3.Text = currentrow(2)
            FoliarMolarRatio1.Text = currentrow(3)
            FoliarMolarRatio2.Text = currentrow(4)

            currentrow = MyReader.ReadFields
            FoliarWashoff1.Text = currentrow(0)
            FoliarWashoff2.Text = currentrow(1)
            FoliarWashoff3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            MWT1.Text = currentrow(0)
            MWT2.Text = currentrow(1)
            MWT3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            VaporPress1.Text = currentrow(0)
            VaporPress2.Text = currentrow(1)
            VaporPress3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Sol1.Text = currentrow(0)
            Sol2.Text = currentrow(1)
            Sol3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Henry1.Text = currentrow(0)
            Henry2.Text = currentrow(1)
            Henry3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            AirDiff1.Text = currentrow(0)
            AirDiff2.Text = currentrow(1)
            AirDiff3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            HeatHenry1.Text = currentrow(0)
            HeatHenry2.Text = currentrow(1)
            HeatHenry3.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            Q10.Text = currentrow(0)


            currentrow = MyReader.ReadFields
            ConstantProfile.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            RampProfile.Checked = currentrow(0)
            profileDepth1.Text = currentrow(1)
            ProfileDepth2.Text = currentrow(2)
            RampEndValue.Text = currentrow(3)

            currentrow = MyReader.ReadFields

            ExponentialProfile.Checked = currentrow(0)
            ExpParameter1.Text = currentrow(1)
            ExpParameter2.Text = currentrow(2)


            currentrow = MyReader.ReadFields
            Dim NumberOfSchemes As Integer
            NumberOfSchemes = currentrow(0)

            SchemeTableDisplay.Rows.Clear()

            Dim NumberOfScenarios As Integer
            Dim numRows As Integer

            For i As Integer = 0 To NumberOfSchemes - 1
                'Need a new apptable for every scheme because otherwise just a reference to table will be sent to schemeinfo
                ' and only copies of the last scheme will be picked up
                Dim ApplicationTable As New SchemeDetails With {
                .Days = New List(Of String),
                .Amount = New List(Of String),
                .Method = New List(Of String),
                .Depth = New List(Of String),
                .Split = New List(Of String),
                .Drift = New List(Of String),
                .DriftFactor = New List(Of String),
                .Periodicity = New List(Of String),
                .Lag = New List(Of String),
                .Scenarios = New List(Of String)
                 } 'local for picking up scheme information

                ' ApplicationTable.ClearAll()

                currentrow = MyReader.ReadFields

                SchemeTableDisplay.Rows.Add("", False, "", currentrow(1))

                currentrow = MyReader.ReadFields

                ApplicationTable.AbsoluteRelative = False
                ApplicationTable.Emerge = False
                ApplicationTable.Maturity = False
                ApplicationTable.Removal = False
                Select Case currentrow(0)
                    Case 0
                        ApplicationTable.AbsoluteRelative = True
                    Case 1
                        ApplicationTable.Emerge = True
                    Case 2
                        ApplicationTable.Maturity = True
                    Case 3
                        ApplicationTable.Removal = True
                End Select

                currentrow = MyReader.ReadFields
                numRows = currentrow(0) 'number of application (rows) in app table

                For j As Integer = 0 To numRows - 1
                    currentrow = MyReader.ReadFields
                    ApplicationTable.Days.Add(currentrow(0))
                    ApplicationTable.Amount.Add(currentrow(1))
                    ApplicationTable.Method.Add(currentrow(2))
                    ApplicationTable.Depth.Add(currentrow(3))
                    ApplicationTable.Split.Add(currentrow(4))
                    ApplicationTable.Drift.Add(currentrow(5))
                    ApplicationTable.DriftFactor.Add(currentrow(6))
                    ApplicationTable.Periodicity.Add(currentrow(7))
                    ApplicationTable.Lag.Add(currentrow(8))

                Next

                currentrow = MyReader.ReadFields
                ApplicationTable.UseApplicationWindow = currentrow(0)
                ApplicationTable.ApplicationWindowSpan = currentrow(1)
                ApplicationTable.ApplicationWindowStep = currentrow(2)

                currentrow = MyReader.ReadFields
                ApplicationTable.UseRainFast = currentrow(0)
                ApplicationTable.RainLimit = currentrow(1)
                ApplicationTable.IntolerableRainWindow = currentrow(2)
                ApplicationTable.OptimumApplicationWindow = currentrow(3)
                ApplicationTable.MinDaysBetweenApps = currentrow(4)




                currentrow = MyReader.ReadFields  'Read number of scenarios

                NumberOfScenarios = currentrow(0)

                For j As Integer = 0 To NumberOfScenarios - 1
                    'currentrow = MyReader.ReadFields
                    'ApplicationTable.Scenarios.Add(currentrow(0)) ' commas in name were causing problems READ Entire line instead

                    ApplicationTable.Scenarios.Add(MyReader.ReadLine())

                Next
                SchemeInfoList.Add(ApplicationTable)
            Next

            currentrow = MyReader.ReadFields 'msg = msg & vbNewLine & ErosionFlag.Text
            ErosionFlag.Text = currentrow(0)
            MyReader.ReadLine() 'msg = msg & vbNewLine & HydroLength.Text
            MyReader.ReadLine() 'msg = msg & vbNewLine & AreaOfField.Text
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine() 'msg = msg & vbNewLine & additionaloutput.Checked

            currentrow = MyReader.ReadFields
            AdjustCN.Checked = currentrow(0) 'msg = msg & vbNewLine & AdjustCN.Checked

            currentrow = MyReader.ReadFields 'msg = msg & vbNewLine & ItsaPond.Checked & "," & ItsaReservoir.Checked & "," & ItsOther.Checked
            ItsaPond.Checked = currentrow(0)
            ItsaReservoir.Checked = currentrow(1)
            ItsOther.Checked = currentrow(2)


            currentrow = MyReader.ReadFields 'msg = msg & vbNewLine & WaterbodyList.Items.Count
            Dim countofspecialwaterbodies As Integer
            countofspecialwaterbodies = currentrow(0)
            WaterbodyList.Items.Clear()

            For i As Integer = 1 To countofspecialwaterbodies
                currentrow = MyReader.ReadFields
                WaterbodyList.Items.Add(currentrow(0))
            Next

            currentrow = MyReader.ReadFields
            outputRunoff.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputErosion.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputPestRunoff.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputPestErosion.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputConcLastLayer.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputDailyFieldVolatilization.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            OutputDailyPestLeached.Checked = currentrow(0)
            chemInfiltrationDepth.Text = currentrow(1)

            currentrow = MyReader.ReadFields
            OutputDecayedPest.Checked = currentrow(0)
            OutputDecayDepth1.Text = currentrow(1)
            OutputDecayDepth2.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            outputMassInSoilProfile.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            outputMassSoilSpecific.Checked = currentrow(0)
            OutputMassDepth1.Text = currentrow(1)
            OutputMassDepth2.Text = currentrow(2)

            currentrow = MyReader.ReadFields
            outputMassOnFoliage.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            outputPrecipitation.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputActualEvap.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputTotalSoilWater.Checked = currentrow(0)
            currentrow = MyReader.ReadFields
            outputIrrigation.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            outputInfiltrationAtDepth.Checked = currentrow(0)
            OutputInfiltrationDepth.Text = currentrow(1)

            currentrow = MyReader.ReadFields
            outputInfiltratedWaterLastLayer.Checked = currentrow(0)

            currentrow = MyReader.ReadFields
            outputWaterConc.Checked = currentrow(0)

            MyReader.ReadLine() 'expansion lines
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine()

            Dim NumOutputRows As Integer
            currentrow = MyReader.ReadFields
            NumOutputRows = currentrow(0)


            AdditionalOutputGridView.Rows.Clear()
            For j As Integer = 0 To NumOutputRows - 1
                currentrow = MyReader.ReadFields
                AdditionalOutputGridView.Rows.Add(currentrow(0), currentrow(1), currentrow(2), currentrow(3), currentrow(4), currentrow(5))
            Next






        End Using


    End Sub

    Private Sub ReadwaterBodyParameters(filename As String)



        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()

            WaterBodyType.Text = MyReader.ReadLine()
            FlowAveraging.Text = MyReader.ReadLine()
            FieldSize.Text = MyReader.ReadLine()
            WaterBodyArea.Text = MyReader.ReadLine()

            DoverDx.Text = MyReader.ReadLine()
            BenthicDepth.Text = MyReader.ReadLine()
            BenthicPorosity.Text = MyReader.ReadLine()
            BenthicBulkDensity.Text = MyReader.ReadLine()
            BenthicFoc.Text = MyReader.ReadLine()
            BenthicDOC.Text = MyReader.ReadLine()
            BenthicBiomass.Text = MyReader.ReadLine()
            Dfac.Text = MyReader.ReadLine()
            SuspendedSolids.Text = MyReader.ReadLine()
            Chlorophyll.Text = MyReader.ReadLine()
            WaterColumnFoc.Text = MyReader.ReadLine()
            WaterColumnDoc.Text = MyReader.ReadLine()
            WaterColumnBiomass.Text = MyReader.ReadLine()
            InitialDepth.Text = MyReader.ReadLine()
            MaxDepth.Text = MyReader.ReadLine()
            BaseFlow.Text = MyReader.ReadLine()
            FlowLength.Text = MyReader.ReadLine()

            currentRow = MyReader.ReadFields
            spray1.Text = currentRow(0)
            spray2.Text = currentRow(1)
            spray3.Text = currentRow(2)
            spray4.Text = currentRow(3)
            spray5.Text = currentRow(4)
            spray6.Text = currentRow(5)
            spray7.Text = currentRow(6)
            spray8.Text = currentRow(7)
            spray9.Text = currentRow(8)
            spray10.Text = currentRow(9)
            spray11.Text = currentRow(10)
            spray12.Text = currentRow(11)
            spray13.Text = currentRow(12)
            spray14.Text = currentRow(13)


            Dim rowcount As Integer
            rowcount = MyReader.ReadLine


            For i As Integer = 0 To rowcount - 1
                currentRow = MyReader.ReadFields

                SprayGridView.Item(1, i).Value = currentRow(0)
                SprayGridView.Item(2, i).Value = currentRow(1)
                SprayGridView.Item(3, i).Value = currentRow(2)
                SprayGridView.Item(4, i).Value = currentRow(3)
                SprayGridView.Item(5, i).Value = currentRow(4)
                SprayGridView.Item(6, i).Value = currentRow(5)
                SprayGridView.Item(7, i).Value = currentRow(6)
                SprayGridView.Item(8, i).Value = currentRow(7)
                SprayGridView.Item(9, i).Value = currentRow(8)
                SprayGridView.Item(10, i).Value = currentRow(9)
                SprayGridView.Item(11, i).Value = currentRow(10)
                SprayGridView.Item(12, i).Value = currentRow(11)

            Next





        End Using

    End Sub
    Private Function CreateWaterbodyString() As String
        Dim msg As String

        msg = WaterBodyType.Text
        msg = msg & vbNewLine & FlowAveraging.Text
        msg = msg & vbNewLine & FieldSize.Text
        msg = msg & vbNewLine & WaterBodyArea.Text
        msg = msg & vbNewLine & DoverDx.Text
        msg = msg & vbNewLine & BenthicDepth.Text
        msg = msg & vbNewLine & BenthicPorosity.Text
        msg = msg & vbNewLine & BenthicBulkDensity.Text
        msg = msg & vbNewLine & BenthicFoc.Text
        msg = msg & vbNewLine & BenthicDOC.Text
        msg = msg & vbNewLine & BenthicBiomass.Text
        msg = msg & vbNewLine & Dfac.Text
        msg = msg & vbNewLine & SuspendedSolids.Text
        msg = msg & vbNewLine & Chlorophyll.Text
        msg = msg & vbNewLine & WaterColumnFoc.Text
        msg = msg & vbNewLine & WaterColumnDoc.Text
        msg = msg & vbNewLine & WaterColumnBiomass.Text
        msg = msg & vbNewLine & InitialDepth.Text
        msg = msg & vbNewLine & MaxDepth.Text
        msg = msg & vbNewLine & BaseFlow.Text
        msg = msg & vbNewLine & FlowLength.Text
        msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13},{14}", vbNewLine, spray1.Text, spray2.Text, spray3.Text, spray4.Text, spray5.Text,
                                  spray6.Text, spray7.Text, spray8.Text, spray9.Text, spray10.Text, spray11.Text, spray12.Text, spray13.Text, spray14.Text)




        msg = msg & vbNewLine & SprayGridView.RowCount
        For i As Integer = 0 To SprayGridView.RowCount - 1
            msg = msg & String.Format("{0}{1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12}", vbNewLine,
                              SprayGridView.Item(1, i).Value, SprayGridView.Item(2, i).Value, SprayGridView.Item(3, i).Value, SprayGridView.Item(4, i).Value, SprayGridView.Item(5, i).Value,
                              SprayGridView.Item(6, i).Value, SprayGridView.Item(7, i).Value, SprayGridView.Item(8, i).Value, SprayGridView.Item(9, i).Value, SprayGridView.Item(10, i).Value,
                              SprayGridView.Item(11, i).Value, SprayGridView.Item(12, i).Value)

        Next






        CreateWaterbodyString = msg
    End Function


    Private Sub ReadScenarioParameters(ByVal filename As String)

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)

            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()

            ScenarioID.Text = MyReader.ReadLine()
            WeatherFileName.Text = MyReader.ReadLine()

            latitude.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'waterbody types
            MyReader.ReadLine() 'flow averagin
            MyReader.ReadLine() 'burial
            MyReader.ReadLine() 'fieldsize.Text = Myreader.ReadLine()
            MyReader.ReadLine() 'waterAreaBox.Text = Myreader.ReadLine()
            MyReader.ReadLine() 'initialDepthBox.Text = Myreader.ReadLine()
            MyReader.ReadLine() 'maxDepthBox.Text = Myreader.ReadLine()
            MyReader.ReadLine() 'massXferBox.Text = Myreader.ReadLine()
            MyReader.ReadLine() 'prben
            MyReader.ReadLine() ' benthicdepthBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' porosityBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' bdBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' foc2Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' DOC2Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' biomass2Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' dfacBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() ' ssBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'ChlorophyllBox.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'foc1Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'DOC1Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'Biomass1Box.Text = MyReader.ReadLine()
            MyReader.ReadLine() 'Line 25 'EpaDefaultsCheck.Checked = MyReader.ReadLine()
            MyReader.ReadLine() 'Line 26
            MyReader.ReadLine() 'Line 27 blank

            MyReader.ReadLine()  ' line 28 with ******** start of PRZM information ******************

            currentRow = MyReader.ReadFields
            '  SingleCropAnnual.Checked = currentRow(0)
            Evergreen.Checked = currentRow(1)

            Dim croprows As Integer

            croprows = MyReader.ReadLine()  'Line 30 CropCyclesPerYear is number of rows in crop tab;le
            MyReader.ReadLine()  ' irrelevant now

            Dim emday, emmonth, matday, matmonth, endday, endmonth As Integer
            Dim emergencedate As String
            Dim maturedate As String
            Dim enddate As String
            Dim foliardeposit As String

            CropGridView.Rows.Clear()

            For j As Integer = 0 To croprows - 1
                currentRow = MyReader.ReadFields
                emday = currentRow(0)
                emmonth = currentRow(1)
                matday = currentRow(2)
                matmonth = currentRow(3)
                endday = currentRow(4)
                endmonth = currentRow(5)

                emergencedate = String.Format("{1}/{0}", emday, emmonth)
                maturedate = String.Format("{1}/{0}", matday, matmonth)
                enddate = String.Format("{1}/{0}", endday, endmonth)

                Select Case currentRow(10)
                    Case 1
                        foliardeposit = "Surface Applied"
                    Case 2
                        foliardeposit = "Removed"
                    Case 3
                        foliardeposit = "Left on Plant"
                    Case Else
                        foliardeposit = "Surface Applied"
                End Select
                CropGridView.Rows.Add(emergencedate, maturedate, enddate, currentRow(6), currentRow(7),
                                      currentRow(8), currentRow(9), foliardeposit, currentRow(11), currentRow(12))
            Next

            For j As Integer = croprows To 6
                MyReader.ReadLine() 'read the lines that do not have crop data
            Next

            MyReader.ReadLine()  'Line 39  alternative crop parameters fro evergreen and such, probably should rework this
            MyReader.ReadLine()  'Line 40

            currentRow = MyReader.ReadFields  'Line 41
            PETadjustment.Text = currentRow(0)
            snowMelt.Text = currentRow(1)  'For FDA, we will keep snowmelt factor constant
            evapDepth.Text = currentRow(2)

            MyReader.ReadLine() 'Line 42 *** irrigation information start ***
            Dim test As Integer
            test = MyReader.ReadLine()  'Line 43

            Select Case test
                Case "0"
                    noIrrigation.Checked = True
                Case "1"
                    overCanopy.Checked = True
                Case "2"
                    underCanopy.Checked = True
                Case Else
                    noIrrigation.Checked = True
            End Select

            currentRow = MyReader.ReadFields 'line 44
            fleach.Text = currentRow(0)
            depletion.Text = currentRow(1)
            rateIrrig.Text = currentRow(2)

            currentRow = MyReader.ReadFields 'line 45
            UserSpecifiesIrrigDepth.Checked = currentRow(0)
            IrrigDepthRootZone.Checked = Not UserSpecifiesIrrigDepth.Checked
            IrrigationDepthUserSpec.Text = currentRow(1)

            MyReader.ReadLine()      'Line46
            MyReader.ReadLine()      'Line47
            MyReader.ReadLine()      'Line48  Soil Information

            '    Try
            currentRow = MyReader.ReadFields '49
            usleK.Text = currentRow(0)
            usleLS.Text = currentRow(1)
            usleP.Text = currentRow(2)

            currentRow = MyReader.ReadFields
            ireg.Text = currentRow(0)
            slope.Text = currentRow(1)
            '  hydlength.Text = currentRow(2) THIS NEEDSA TO BE HANDLED SOMEWHERE ELSE. Watershed not field parameter

            MyReader.ReadLine() 'this is: *** Horizon Info *******

            Dim numberofhorizons As Integer
            numberofhorizons = MyReader.ReadLine()
            Dim thicknessrow As String()
            Dim blkdensityrow As String()
            Dim maxcapacityrow As String()
            Dim mincapacityrow As String()
            Dim ocrow As String()
            Dim compartmentrow As String()
            Dim sandrow As String()
            Dim clayrow As String()

            thicknessrow = MyReader.ReadFields
            blkdensityrow = MyReader.ReadFields
            maxcapacityrow = MyReader.ReadFields
            mincapacityrow = MyReader.ReadFields
            ocrow = MyReader.ReadFields
            compartmentrow = MyReader.ReadFields
            sandrow = MyReader.ReadFields
            clayrow = MyReader.ReadFields

            HorizonGridView.Rows.Clear()

            For i As Integer = 0 To numberofhorizons - 1
                HorizonGridView.Rows.Add(i + 1, thicknessrow(i), blkdensityrow(i), maxcapacityrow(i), mincapacityrow(i), ocrow(i), compartmentrow(i), sandrow(i), clayrow(i))
            Next

            MyReader.ReadLine() '*** Horizon End, Temperature Start ********"
            currentRow = MyReader.ReadFields 'line 62
            albedo.Text = currentRow(0)
            bcTemp.Text = currentRow(1)

            SimTemperature.Checked = MyReader.ReadLine() 'line 63
            MyReader.ReadLine()  '***spare line for expansion
            MyReader.ReadLine()  '***spare line for expansion
            MyReader.ReadLine() '***Erosion Curve Number Inputs, Line 66

            '****** READ IN USLE and CN Values ************************
            HydroDataGrid.Rows.Clear()
            Dim numberofevents As Integer
            numberofevents = MyReader.ReadLine() 'line 67

            Dim USLEday As String()
            Dim USLmon As String()
            Dim USLEcn As String()
            Dim USLEC As String()

            USLEday = MyReader.ReadFields 'line 68
            USLmon = MyReader.ReadFields 'line 69
            USLEcn = MyReader.ReadFields 'line 70
            USLEC = MyReader.ReadFields 'line 71
            MyReader.ReadLine() 'line 72 old Mannings N

            Dim combodate As String
            For i As Integer = 0 To numberofevents - 1
                combodate = String.Format("{0}/{1}", USLmon(i), USLEday(i))
                HydroDataGrid.Rows.Add(combodate, USLEcn(i), USLEC(i))
            Next

            ''******************************************************************************
            currentRow = MyReader.ReadFields 'line 73
            rDepth.Text = currentRow(0)
            rDecline.Text = currentRow(1)
            rInteracting.Text = currentRow(2)

            currentRow = MyReader.ReadFields 'line 74
            eDepth.Text = currentRow(0)
            eDecline.Text = currentRow(1)
            eInteracting.Text = currentRow(2)

            MyReader.ReadLine() 'use usle years
            MyReader.ReadLine() 'list of usle years if used
            VolatilizationBounday.Text = MyReader.ReadLine() 'volatilization boundary


            'adding in the new discretization routine
            If MyReader.EndOfData Then
            Else
                Dim numberofdiscreterows As Integer
                useAutoGWprofile.Checked = MyReader.ReadLine()
                numberofdiscreterows = MyReader.ReadLine()

                DiscretizationGridView.Rows.Clear()

                For i As Integer = 1 To numberofdiscreterows
                    currentRow = MyReader.ReadFields
                    DiscretizationGridView.Rows.Add(currentRow(0), currentRow(1))
                Next


            End If







        End Using
    End Sub


    Private Sub RecordScheme(ByVal SchemeNumber As Integer)

        Dim AppTableList As New List(Of Integer)

        Dim AppData As New SchemeDetails With {
            .Days = New List(Of String),
            .Amount = New List(Of String),
            .Method = New List(Of String),
            .Depth = New List(Of String),
            .Split = New List(Of String),
            .Drift = New List(Of String),
            .DriftFactor = New List(Of String),
            .Periodicity = New List(Of String),
            .Lag = New List(Of String)
        }


        AppTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)  'commit the cell if cursor still on box


        For i As Integer = 0 To AppTableDisplay.RowCount - 2
            AppData.Days.Add(AppTableDisplay.Item(0, i).Value)
            AppData.Amount.Add(AppTableDisplay.Item(1, i).Value)


            Select Case (AppTableDisplay.Item(2, i).Value)
                Case (Standard.method1)
                    AppData.Method.Add("1")
                Case (Standard.method2)
                    AppData.Method.Add("2")
                Case (Standard.method3)
                    AppData.Method.Add("3")
                Case (Standard.method4)
                    AppData.Method.Add("4")
                Case (Standard.method5)
                    AppData.Method.Add("5")
                Case (Standard.method6)
                    AppData.Method.Add("6")
                Case (Standard.method7)
                    AppData.Method.Add("7")
                Case Else
                    AppData.Method.Add("1")
            End Select

            AppData.Depth.Add(AppTableDisplay.Item(3, i).Value)
            AppData.Split.Add(AppTableDisplay.Item(4, i).Value)
            '    AppData.Drift.Add(AppTableDisplay.Item(5, i).Value)

            Select Case AppTableDisplay.Item(5, i).Value
                Case (Standard.sprayterm1)
                    AppData.Drift.Add("1")
                Case (Standard.sprayterm2)
                    AppData.Drift.Add("2")
                Case (Standard.sprayterm3)
                    AppData.Drift.Add("3")
                Case (Standard.sprayterm4)
                    AppData.Drift.Add("4")
                Case (Standard.sprayterm5)
                    AppData.Drift.Add("5")
                Case Else
                    AppData.Drift.Add("5")
            End Select

            AppData.DriftFactor.Add(AppTableDisplay.Item(6, i).Value)
            AppData.Periodicity.Add(AppTableDisplay.Item(7, i).Value)
            AppData.Lag.Add(AppTableDisplay.Item(8, i).Value)
        Next

        AppData.AbsoluteRelative = AbsoluteDaysButton.Checked
        AppData.Emerge = emerge.Checked
        AppData.Maturity = maturity.Checked
        AppData.Removal = removal.Checked

        AppData.UseApplicationWindow = UseApplicationWindow.Checked
        AppData.ApplicationWindowSpan = ApplicationWindowDays.Text
        AppData.ApplicationWindowStep = ApplicationWindowStep.Text

        AppData.UseRainFast = UseRainFast.Checked
        AppData.RainLimit = RainLimit.Text
        AppData.IntolerableRainWindow = IntolerableRainWindow.Text
        AppData.OptimumApplicationWindow = OptimumApplicationWindow.Text
        AppData.MinDaysBetweenApps = MinDaysBetweenApps.Text


        AppData.Scenarios = ScenarioListBox.Items.Cast(Of String).ToList

        If SchemeInfoList.Count - 1 < SchemeNumber Then
            'if application scheme does not exist, then add it
            SchemeInfoList.Add(AppData)
        ElseIf SchemeNumber >= 0 Then
            'otherwise repalace it
            SchemeInfoList.Item(SchemeNumber) = AppData
        End If

    End Sub


End Class
