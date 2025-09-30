Partial Public Class Form1

    Sub SaveInputsAsTextFile(ByVal savefile As String)
        Dim msg As String
        msg = "PWC 3 Input File, Version " & Standard.VersionNumber
        msg &= String.Format("{0}{1}", vbNewLine, WorkingDirectoryLabel.Text)  'Dont put commas on the end of long strings, need to leave off for fortran read
        msg &= String.Format("{0}{1}", vbNewLine, IOFamilyName.Text)
        msg &= String.Format("{0}{1}", vbNewLine, WeatherDirectoryBox.Text)
        msg &= String.Format("{0}{1},", vbNewLine, WaterbodyEvapAdjustment.Text)


        msg &= String.Format("{0}{1}, {2}, {3}, {4}, {5},", vbNewLine, isKoc.Checked, UseFreundlich.Checked, UseNonequilibrium.Checked, poundToKiloConversion.Checked, IsHydrolysisOverride.Checked)

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

        If (NumberOfSchemes > SchemeInfoList.Count) Then
            MsgBox("There is an uncommitted scheme. Delete it or commit it.")
            Return
        End If

        If NumberOfSchemes = 1 And SchemeInfoList.Count = 0 Then
            'scheme is not commited so dont try to save else get error below
            NumberOfSchemes = 0
        End If

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
                                          ApplicationTable.Drift(j), ApplicationTable.DriftBuffer(j), ApplicationTable.Periodicity(j), ApplicationTable.Lag(j))
            Next


            msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, ApplicationTable.UseApplicationWindow, ApplicationTable.ApplicationWindowSpan, ApplicationTable.ApplicationWindowStep)
            msg = msg & String.Format("{0}{1},{2},{3},{4},{5},", vbNewLine, ApplicationTable.UseRainFast, ApplicationTable.RainLimit, ApplicationTable.IntolerableRainWindow, ApplicationTable.OptimumApplicationWindow, ApplicationTable.MinDaysBetweenApps)

            NumberOfScenarios = ApplicationTable.Scenarios.Count
            msg = msg & vbNewLine & NumberOfScenarios

            For j As Integer = 0 To NumberOfScenarios - 1
                msg = msg & vbNewLine & ApplicationTable.Scenarios(j)
            Next
            msg = msg & vbNewLine & ApplicationTable.UseBatchScenarioFile & ","
            msg = msg & vbNewLine & ApplicationTable.ScenarioBatchFileName & ","
            msg = msg & vbNewLine & "Mitigations (flag to make older versions still readable)"
            msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, ApplicationTable.RunoffMitigation, ApplicationTable.ErosionMitigation, ApplicationTable.DriftMitigation)
        Next

        msg &= String.Format("{0}{1},", vbNewLine, ErosionFlag.Text)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)
        msg &= String.Format("{0},", vbNewLine)

        msg &= String.Format("{0}{1},", vbNewLine, AdjustCN.Checked)
        msg &= String.Format("{0}{1},{2},{3},{4},{5}", vbNewLine, ItsaPond.Checked, ItsaReservoir.Checked, ItsOther.Checked, ItsTPEZWPEZ.Checked, UseTPEZbuffers.Checked)
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
        msg = msg & vbNewLine & outputSpraydrift.Checked & ","
        msg = msg & vbNewLine & output_GW_BTC.Checked & ","

        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & "holder for future expansion" & ","
        msg = msg & vbNewLine & CalculateEoF.Checked & ","

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


    Sub SaveSchemeTableAsTextFile(ByVal savefile As String)
        Dim msg As String
        msg = "PWC 3 Scheme Table"



        'Schemes***************************
        Dim NumberOfSchemes As Integer
        Dim ApplicationTable As New SchemeDetails
        Dim actualRowsInAppTable As Integer 'app table rows

        Dim NumberOfScenarios As Integer
        Dim referencedate As Integer

        AppTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)  'commit the cell if cursor still on box


        NumberOfSchemes = SchemeTableDisplay.RowCount - 1

        If (NumberOfSchemes > SchemeInfoList.Count) Then
            MsgBox("There is an uncommitted scheme. Delete it or commit it.")
            Return
        End If

        Dim massUnits As String
        If kgha.Checked Then
            massUnits = "kg/ha"
        Else
            massUnits = "lb/acre"
        End If



        msg = msg & String.Format("{0}{1}, amt in {2} {0}", vbNewLine, NumberOfSchemes, massUnits)
        SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit) 'commit the cell if cursor still on box

        Dim phrase1 As String = "Sch#, Description,mode,#Apps,"
        Dim phrase2 As String = " days,amt,method,depth,split,drift,buffer,period,lag,"
        Dim phrase3 As String = "window, span,step,raifast,rainlimit,intolwindow,optwindow,mindays,RunoffMit, ErosionMit, DriftMit, #scn, scn dir,  "

        msg = msg & String.Format("{0}{1}{1}{1}{1}{1}{1}{1}{1}{1}{1}{2}", phrase1, phrase2, phrase3)


        Dim checktest As Integer
        Try

            For i As Integer = 0 To NumberOfSchemes - 1


                checktest = i
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

                msg = msg & String.Format("{0},", referencedate)

                'Application Table Information
                actualRowsInAppTable = ApplicationTable.Days.Count   'AppTableDisplay.RowCount - 1
                msg = msg & String.Format("{0},", actualRowsInAppTable)


                'Maximum of 10 applications for a scheme dump
                If actualRowsInAppTable - 1 > 10 Then
                    MsgBox("column order is preserved only for a maximum of 10 applications")
                End If

                For j As Integer = 0 To actualRowsInAppTable - 1

                    msg = msg & String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},", ApplicationTable.Days(j), ApplicationTable.Amount(j),
                                              ApplicationTable.Method(j), ApplicationTable.Depth(j), ApplicationTable.Split(j),
                                              ApplicationTable.Drift(j), ApplicationTable.DriftBuffer(j), ApplicationTable.Periodicity(j), ApplicationTable.Lag(j))
                Next

                If actualRowsInAppTable < 10 Then
                    For j As Integer = 1 To (10 - actualRowsInAppTable)
                        msg = msg & String.Format("{0},{1},{2},{3},{4},{5},{6},{7},{8},", 0, 0, 0, 0, 0, 0, 0, 0, 0)
                    Next
                End If

                msg = msg & String.Format("{0},{1},{2},", ApplicationTable.UseApplicationWindow, ApplicationTable.ApplicationWindowSpan, ApplicationTable.ApplicationWindowStep)
                msg = msg & String.Format("{0},{1},{2},{3},{4},", ApplicationTable.UseRainFast, ApplicationTable.RainLimit, ApplicationTable.IntolerableRainWindow, ApplicationTable.OptimumApplicationWindow, ApplicationTable.MinDaysBetweenApps)

                msg = msg & String.Format("{0},{1},{2},", ApplicationTable.RunoffMitigation, ApplicationTable.ErosionMitigation, ApplicationTable.DriftMitigation)

                NumberOfScenarios = ApplicationTable.Scenarios.Count

                msg = msg & NumberOfScenarios

                If NumberOfScenarios = 0 Then
                    msg = msg & ","
                Else
                    If IO.Path.GetDirectoryName(ApplicationTable.Scenarios(0)) = "" Then
                        msg = msg & ","
                    Else
                        msg = msg & "," & IO.Path.GetDirectoryName(ApplicationTable.Scenarios(0)) & "\"
                    End If
                End If

                For j As Integer = 0 To NumberOfScenarios - 1
                    msg = msg & "," & IO.Path.GetFileName(ApplicationTable.Scenarios(j))
                Next

                'msg = msg & vbNewLine & ApplicationTable.UseBatchScenarioFile & ","
                'msg = msg & vbNewLine & ApplicationTable.ScenarioBatchFileName & ","
            Next


        Catch ex As Exception

            MsgBox("There is a problem with scheme save. " & ex.Message)
            Return
        End Try




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

        For i As Integer = 1 To 24  'This is all the waterbody stuff in the old scenarios
            msg = msg & vbNewLine
        Next

        msg = msg & vbNewLine

        msg = msg & "******** start of PRZM information ******************" & vbNewLine 'line 28
        msg = msg & String.Format("False, {0}, False", Evergreen.Checked)  'to be compatible with old scenarios, now only evergreen is needed

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

        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, PETadjustment.Text, 0.00000, evapDepth.Text)


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

        msg = msg & String.Format("{0}{1},{2},{3},{4},", vbNewLine, fleach.Text, depletion.Text, rateIrrig.Text, MaxIrrigationDepth.Text)
        msg = msg & String.Format("{0}{1},{2},", vbNewLine, UserSpecifiesIrrigDepth.Checked, IrrigationDepthUserSpec.Text)
        msg = msg & vbNewLine & "*** spare line for expansion"
        msg = msg & vbNewLine & "*** spare line for expansion"
        msg = msg & vbNewLine & "*** Soil Information ***"

        msg = msg & String.Format("{0}{1},{2},{3},", vbNewLine, usleK.Text, usleLS.Text, usleP.Text)
        msg = msg & String.Format("{0}{1},{2},", vbNewLine, ireg.Text, slope.Text)


        msg = msg & vbNewLine & "*** Horizon Info *******" '
        HorizonGridView.CommitEdit(DataGridViewDataErrorContexts.Commit)

        Dim numberofhorizons As Integer
        numberofhorizons = HorizonGridView.RowCount - 1

        msg = msg & String.Format("{0}{1},{0}", vbNewLine, numberofhorizons)


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

        'For i As Integer = 0 To numberofhorizons - 1
        '    msg = msg & String.Format("{0},", HorizonGridView.Item(7, i).Value)
        'Next
        msg = msg & "Spare Line (formerly sand)"


        msg = msg & vbNewLine
        'For i As Integer = 0 To numberofhorizons - 1
        '    msg = msg & String.Format("{0},", HorizonGridView.Item(8, i).Value)
        'Next
        msg = msg & "Spare Line (formerly clay)"


        msg = msg & vbNewLine & "*** Horizon End, Temperature Start ********"

        msg = msg & String.Format("{0}{1},{2},", vbNewLine, albedo.Text, bcTemp.Text)
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

        If useAutoGWprofile.Checked Then
            Dim numberofdiscreterows As Integer
            numberofdiscreterows = DiscretizationGridView.RowCount - 1
            msg = msg & vbNewLine & numberofdiscreterows

            For i As Integer = 0 To numberofdiscreterows - 1
                msg = msg & String.Format("{0}{1}, {2}", vbNewLine, DiscretizationGridView.Item(0, i).Value, DiscretizationGridView.Item(1, i).Value)
            Next
        End If


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


            MyReader.ReadLine() 'Title Line  LINE 1
            MyReader.ReadLine() 'working directory, not retrieved here, so can alter
            MyReader.ReadLine() 'family name not retrieved, so can alter, needed for transfer to vvwm
            'Weather Path

            WeatherDirectoryBox.Text = MyReader.ReadLine()   'LINE 4

            currentrow = MyReader.ReadFields                 'LINE 5
            WaterbodyEvapAdjustment.Text = currentrow(0)

            'Chemical Proerties
            currentrow = MyReader.ReadFields         'LINE 6
            If currentrow(0) Then
                isKoc.Checked = True
                isKd.Checked = False
            Else
                isKoc.Checked = False
                isKd.Checked = True
            End If

            UseFreundlich.Checked = currentrow(1)
            UseNonequilibrium.Checked = currentrow(2)

            'early pwc3 did not have these options:
            Try

                If currentrow(3) Then
                    poundToKiloConversion.Checked = True
                    kgha.Checked = False
                Else
                    poundToKiloConversion.Checked = False
                    kgha.Checked = True
                End If

                IsHydrolysisOverride.Checked = currentrow(4)
            Catch ex As Exception

                IsHydrolysisOverride.Checked = True
            End Try


            Dim nchem As Integer
            currentrow = MyReader.ReadFields
            nchem = currentrow(0) 'LINE 6
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

            currentrow = MyReader.ReadFields 'LINE 11
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

            currentrow = MyReader.ReadFields 'LINE 20
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

            currentrow = MyReader.ReadFields         'LINE 31
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
            Dim blip As String


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
                .DriftBuffer = New List(Of String),
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
                    currentrow = MyReader.ReadFields               'Not read if zero rows
                    ApplicationTable.Days.Add(currentrow(0))
                    ApplicationTable.Amount.Add(currentrow(1))
                    ApplicationTable.Method.Add(currentrow(2))
                    ApplicationTable.Depth.Add(currentrow(3))
                    ApplicationTable.Split.Add(currentrow(4))
                    ApplicationTable.Drift.Add(currentrow(5))
                    ApplicationTable.DriftBuffer.Add(currentrow(6))
                    ApplicationTable.Periodicity.Add(currentrow(7))
                    ApplicationTable.Lag.Add(currentrow(8))
                Next

                currentrow = MyReader.ReadFields
                ApplicationTable.UseApplicationWindow = currentrow(0)
                ApplicationTable.ApplicationWindowSpan = currentrow(1)
                ApplicationTable.ApplicationWindowStep = currentrow(2)

                currentrow = MyReader.ReadFields                          'LINE 40
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
                    blip = MyReader.ReadLine()
                    ApplicationTable.Scenarios.Add(blip)
                Next
                currentrow = MyReader.ReadFields
                ApplicationTable.UseBatchScenarioFile = currentrow(0)

                currentrow = MyReader.ReadFields
                ApplicationTable.ScenarioBatchFileName = currentrow(0)




                If MyReader.PeekChars(11) = "Mitigations" Then


                    MyReader.ReadLine() 'skip over the Mitigations line


                    currentrow = MyReader.ReadFields
                        ApplicationTable.RunoffMitigation = currentrow(0)
                        ApplicationTable.ErosionMitigation = currentrow(1)
                        ApplicationTable.DriftMitigation = currentrow(2)

                Else



                    ApplicationTable.RunoffMitigation = "1.0"
                    ApplicationTable.ErosionMitigation = "1.0"
                    ApplicationTable.DriftMitigation = "1.0"
                End If


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
            ItsTPEZWPEZ.Checked = currentrow(3)
            UseTPEZbuffers.Checked = currentrow(4)

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


            currentrow = MyReader.ReadFields

            If currentrow(0) = "True" Or "False" Then
                outputSpraydrift.Checked = currentrow(0)
            Else
                outputSpraydrift.Checked = False
            End If

            currentrow = MyReader.ReadFields
            If currentrow(0) = "True" Or "False" Then
                output_GW_BTC.Checked = currentrow(0)
            Else
                output_GW_BTC.Checked = False
            End If

            MyReader.ReadLine() 'expansion lines
            MyReader.ReadLine()
            MyReader.ReadLine()
            MyReader.ReadLine()

            currentrow = MyReader.ReadFields

            If currentrow(0) = "True" Or currentrow(0) = "False" Then  ' for backward compatibiilty cuz line used to be unused
                CalculateEoF.Checked = currentrow(0)
            End If

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

    Sub ReadSchemeFile(ByVal filename As String)


        SchemeInfoList.Clear()

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
            Dim currentrow As String()
            Dim NumberOfSchemes As Integer
            Dim NumberOfScenarios As Integer
            Dim numRows As Integer
            Dim scenariopath As String


            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")

            MyReader.ReadLine()                'Title        LINE 1
            currentrow = MyReader.ReadFields   'No. Schemes  LINE 2
            NumberOfSchemes = currentrow(0)

            If currentrow(1).Contains("kg/ha") Then
                kgha.Checked = True
            Else
                poundToKiloConversion.Checked = True
            End If

            MyReader.ReadLine()                'Header       LINE 3

            SchemeTableDisplay.Rows.Clear()

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
                .DriftBuffer = New List(Of String),
                .Periodicity = New List(Of String),
                .Lag = New List(Of String),
                .Scenarios = New List(Of String)
                 } 'local for picking up scheme information

                ' ApplicationTable.ClearAll()

                currentrow = MyReader.ReadFields                   'read full scheme line

                SchemeTableDisplay.Rows.Add("", False, "", currentrow(1))

                ApplicationTable.AbsoluteRelative = False
                ApplicationTable.Emerge = False
                ApplicationTable.Maturity = False
                ApplicationTable.Removal = False
                Select Case currentrow(2)                           'timing reference (mode)
                    Case 0
                        ApplicationTable.AbsoluteRelative = True
                    Case 1
                        ApplicationTable.Emerge = True
                    Case 2
                        ApplicationTable.Maturity = True
                    Case 3
                        ApplicationTable.Removal = True
                End Select

                numRows = currentrow(3)             'number of application (rows) in app table

                If numRows > 10 Then
                    MsgBox("for scheme upload/download using this external feature, apps are limited to 10 per scheme")
                End If

                For j As Integer = 0 To numRows - 1
                    ApplicationTable.Days.Add(currentrow(4 + 9 * j))
                    ApplicationTable.Amount.Add(currentrow(5 + 9 * j))
                    ApplicationTable.Method.Add(currentrow(6 + 9 * j))
                    ApplicationTable.Depth.Add(currentrow(7 + 9 * j))
                    ApplicationTable.Split.Add(currentrow(8 + 9 * j))
                    ApplicationTable.Drift.Add(currentrow(9 + 9 * j))
                    ApplicationTable.DriftBuffer.Add(currentrow(10 + 9 * j))
                    ApplicationTable.Periodicity.Add(currentrow(11 + 9 * j))
                    ApplicationTable.Lag.Add(currentrow(12 + 9 * j))
                Next

                ApplicationTable.UseApplicationWindow = currentrow(94)
                ApplicationTable.ApplicationWindowSpan = currentrow(95)
                ApplicationTable.ApplicationWindowStep = currentrow(96)

                ApplicationTable.UseRainFast = currentrow(97)
                ApplicationTable.RainLimit = currentrow(98)
                ApplicationTable.IntolerableRainWindow = currentrow(99)
                ApplicationTable.OptimumApplicationWindow = currentrow(100)
                ApplicationTable.MinDaysBetweenApps = currentrow(101)

                ApplicationTable.RunoffMitigation = currentrow(102)
                ApplicationTable.ErosionMitigation = currentrow(103)
                ApplicationTable.DriftMitigation = currentrow(104)

                NumberOfScenarios = currentrow(105)


                'Row 103 is the path
                If currentrow(106) = "" Then
                    scenariopath = ""
                Else
                    scenariopath = currentrow(106)
                End If


                For j As Integer = 107 To 107 + NumberOfScenarios - 1
                    ApplicationTable.Scenarios.Add(scenariopath & currentrow(j))
                Next
                SchemeInfoList.Add(ApplicationTable)
            Next


        End Using


    End Sub


    Private Sub ReadwaterBodyParameters(filename As String)

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim currentRow As String()

            WaterbodyName.Text = MyReader.ReadLine()
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
            isZeroConc.Checked = currentRow(0)
            ZeroConcDepth.Text = currentRow(1)

            MyReader.ReadLine() 'blank line

            Dim test As String
            test = MyReader.ReadLine()
            If test.Contains(",") Then
                MsgBox("Old Waterbody file! This file is missing the waterbody width used for spray drift. Add it.")
            Else
                WidthSpray.Text = test
            End If




        End Using

    End Sub
    Private Function CreateWaterbodyString() As String
        Dim msg As String


        msg = WaterbodyName.Text
        msg = msg & vbNewLine & WaterBodyType.Text
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
        msg = msg & vbNewLine & isZeroConc.Checked & "," & ZeroConcDepth.Text & ","
        msg = msg & vbNewLine & "unused line for future expansion"


        msg = msg & vbNewLine & WidthSpray.Text


        'Dim column_count As Integer
        ''determine column count
        'column_count = 0
        'For i As Integer = 1 To SprayGridView.ColumnCount - 1

        '    If IsNumeric(SprayGridView.Item(i, 0).Value) Then
        '        column_count = column_count + 1
        '    Else
        '        Exit For
        '    End If
        'Next

        'msg = msg & vbNewLine & SprayGridView.RowCount & "," & column_count

        'Dim submsg As String

        'For i As Integer = 0 To SprayGridView.RowCount - 1
        '    submsg = SprayGridView.Item(1, i).Value

        '    For j As Integer = 2 To SprayGridView.ColumnCount - 2
        '        submsg = submsg & ", " & SprayGridView.Item(j, i).Value
        '    Next
        '    msg = msg & vbNewLine & submsg

        'Next


        CreateWaterbodyString = msg
    End Function
    Private Sub LoadSingleBatchFileScenario(ByVal filename As String)
        Try




            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(filename)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters(",")
                Dim currentRow As String()
                Dim test As Boolean

                Dim msg As String
                msg = ""


                TestIntegers(test, msg, CSV_line)
                If test = False Then
                    MsgBox(msg)
                    Return
                End If


                For i As Integer = 1 To Convert.ToInt16(CSV_line.Text) - 1
                    If MyReader.EndOfData Then
                        Exit For
                    End If

                    MyReader.ReadLine()
                Next

                If MyReader.EndOfData Then
                    MsgBox("No data on this line")
                    Exit Sub
                End If

                currentRow = MyReader.ReadFields
                ScenarioID.Text = currentRow(0)
                WeatherFileName.Text = currentRow(2) & "_grid.wea"
                latitude.Text = currentRow(9)

                PETadjustment.Text = "1.0"              'default
                VolatilizationBounday.Text = "5.0"      'default

                evapDepth.Text = currentRow(11)

                ireg.Text = currentRow(12)


                Select Case currentRow(13)
                    Case "0"
                        noIrrigation.Checked = True
                    Case "1"
                        overCanopy.Checked = True
                    Case "2"
                        underCanopy.Checked = True
                    Case Else
                        noIrrigation.Checked = True
                End Select


                rateIrrig.Text = currentRow(14)
                depletion.Text = currentRow(15)
                fleach.Text = currentRow(16)

                IrrigDepthRootZone.Checked = True  'default
                SimTemperature.Checked = True      'default

                bcTemp.Text = currentRow(97)
                albedo.Text = 0.2                  'default

                HorizonGridView.Rows.Clear()
                For i As Integer = 0 To currentRow(36) - 1
                    HorizonGridView.Rows.Add(i + 1, currentRow(37 + i), currentRow(45 + i), currentRow(53 + i), currentRow(61 + i), currentRow(69 + i), "0")
                Next

                useAutoGWprofile.Checked = True  'true
                DiscretizationGridView.Rows.Clear()
                DiscretizationGridView.Rows.Add("3.0", "30")
                DiscretizationGridView.Rows.Add("7.0", "7")
                DiscretizationGridView.Rows.Add("10.0", "2")
                DiscretizationGridView.Rows.Add("80.0", "4")

                Dim transition_depth As Single
                Dim transition_delta As Integer
                transition_depth = currentRow(96) - 100
                transition_delta = transition_depth / 50     ' 50 cm increment

                DiscretizationGridView.Rows.Add(transition_depth, transition_delta)
                DiscretizationGridView.Rows.Add("100.0", "2")


                CropGridView.Rows.Clear()

                Dim emergence_date As Date  ' emergence
                Dim maturity_date As Date  ' maturity
                Dim harvest_date As Date  ' harvest

                Dim dayEmerge As Integer
                Dim monthEmerge As Integer
                Dim dayMature As Integer
                Dim monthMature As Integer
                Dim dayHarvest As Integer
                Dim monthHarvest As Integer

                Dim aa, bb, cc As Double
                aa = currentRow(18)
                bb = currentRow(19)
                cc = currentRow(20)

                emergence_date = DateAdd(DateInterval.Day, aa, #1/1/1900#)
                maturity_date = DateAdd(DateInterval.Day, bb, #1/1/1900#)
                harvest_date = DateAdd(DateInterval.Day, cc, #1/1/1900#)

                dayEmerge = DatePart(DateInterval.Day, emergence_date)
                monthEmerge = DatePart(DateInterval.Month, emergence_date)

                dayMature = DatePart(DateInterval.Day, maturity_date)
                monthMature = DatePart(DateInterval.Month, maturity_date)

                dayHarvest = DatePart(DateInterval.Day, harvest_date)
                monthHarvest = DatePart(DateInterval.Month, harvest_date)

                CropGridView.Rows.Add(monthEmerge & "/" & dayEmerge, monthMature & "/" & dayMature, monthHarvest & "/" & dayHarvest, currentRow(27), currentRow(26),
                          "1.0", currentRow(25), "Surface Applied", "1", "0")

                Evergreen.Checked = False

                If (Convert.ToInt16(aa) = 0 And Convert.ToInt16(bb) = 1) Then
                    Evergreen.Checked = True
                    EvergreenRoot.Text = currentRow(27)
                    EvergreenCover.Text = currentRow(26)
                    EvergreenHt.Text = 1.0
                    EvergreenHoldup.Text = currentRow(25)
                End If




                YearlyCycleButton.Checked = True
                HydroDataGrid.Rows.Clear()

                HydroDataGrid.Rows.Add(monthEmerge & "/" & dayEmerge, currentRow(28), currentRow(30))
                HydroDataGrid.Rows.Add(monthHarvest & "/" & dayHarvest, currentRow(29), currentRow(31))

                usleK.Text = currentRow(33)
                usleLS.Text = currentRow(34)
                usleP.Text = currentRow(32)
                slope.Text = currentRow(35)


                rDepth.Text = "8.0"
                rDecline.Text = "1.4"
                rInteracting.Text = "0.19"

                eDepth.Text = "0.1"
                eDecline.Text = "0.0"
                eInteracting.Text = "1.0"


            End Using




        Catch ex As Exception
            MsgBox("Bad line in csv file")
        End Try







    End Sub



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
            Evergreen.Checked = currentRow(1) 'there are unused parameters on this line

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
            'snowMelt.Text = currentRow(1)  'For FDA, we will keep snowmelt factor constant
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

            'Old scenarios are mising max irrigation depth
            Try
                MaxIrrigationDepth.Text = currentRow(3)
            Catch ex As Exception
                MaxIrrigationDepth.Text = "30.0"
            End Try



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
            '  hydlength.Text = currentRow(2) THIS NEEDS TO BE HANDLED SOMEWHERE ELSE. Watershed not field parameter

            MyReader.ReadLine() 'this is: *** Horizon Info *******

            Dim numberofhorizons As Integer
            'numberofhorizons = MyReader.ReadLine()
            currentRow = MyReader.ReadFields
            numberofhorizons = currentRow(0)

            Dim thicknessrow As String()
            Dim blkdensityrow As String()
            Dim maxcapacityrow As String()
            Dim mincapacityrow As String()
            Dim ocrow As String()
            Dim compartmentrow As String()
            'Dim sandrow As String()
            'Dim clayrow As String()

            thicknessrow = MyReader.ReadFields
            blkdensityrow = MyReader.ReadFields
            maxcapacityrow = MyReader.ReadFields
            mincapacityrow = MyReader.ReadFields
            ocrow = MyReader.ReadFields
            compartmentrow = MyReader.ReadFields

            'sandrow = MyReader.ReadFields
            'clayrow = MyReader.ReadFields
            MyReader.ReadLine()
            MyReader.ReadLine()

            HorizonGridView.Rows.Clear()

            For i As Integer = 0 To numberofhorizons - 1
                HorizonGridView.Rows.Add(i + 1, thicknessrow(i), blkdensityrow(i), maxcapacityrow(i), mincapacityrow(i), ocrow(i), compartmentrow(i))
            Next

            MyReader.ReadLine() '*** Horizon End, Temperature Start ********"

            'V4 scenarios do not have temp populated'line 62
                'MyReader.ReadLine()

                '**************************************]
                Dim ttt As String
            ttt = MyReader.ReadLine()
            If ttt = "" Then
                albedo.Text = 0.2
                bcTemp.Text = 10
            Else
                Dim uuu As String() = Split(ttt, ",")
                albedo.Text = uuu(0)
                bcTemp.Text = uuu(1)
            End If



            '**************************************

            currentRow = MyReader.ReadFields
            SimTemperature.Checked = currentRow(0) 'line 63

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
                useAutoGWprofile.Checked = False
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
            .DriftBuffer = New List(Of String),
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
                Case (Standard.sprayterm6)
                    AppData.Drift.Add("6")
                Case (Standard.sprayterm7)
                    AppData.Drift.Add("7")
                Case (Standard.sprayterm8)
                    AppData.Drift.Add("8")
                Case (Standard.sprayterm9)
                    AppData.Drift.Add("9")
                Case (Standard.sprayterm10)
                    AppData.Drift.Add("10")
                Case (Standard.sprayterm11)
                    AppData.Drift.Add("11")
                Case (Standard.sprayterm12)
                    AppData.Drift.Add("12")
                Case (Standard.sprayterm13)
                    AppData.Drift.Add("13")
                Case (Standard.sprayterm14)
                    AppData.Drift.Add("14")
                Case (Standard.sprayterm15)
                    AppData.Drift.Add("15")
                    'Case (Standard.sprayterm16)
                    '    AppData.Drift.Add("16")
                Case Else
                    AppData.Drift.Add("15")
            End Select

            AppData.DriftBuffer.Add(AppTableDisplay.Item(6, i).Value)
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

        AppData.RunoffMitigation = RunoffMitigation.Text
        AppData.ErosionMitigation = ErosionMitigation.Text
        AppData.DriftMitigation = DriftMitigation.Text



        AppData.Scenarios = ScenarioListBox.Items.Cast(Of String).ToList

        AppData.UseBatchScenarioFile = GetScenariosBatchCheckBox.Checked
        AppData.ScenarioBatchFileName = ScenarioBatchFileName.Text

        If SchemeInfoList.Count - 1 < SchemeNumber Then
            'if application scheme does not exist, then add it
            SchemeInfoList.Add(AppData)
        ElseIf SchemeNumber >= 0 Then
            'otherwise replace it
            SchemeInfoList.Item(SchemeNumber) = AppData
        End If

    End Sub


End Class
