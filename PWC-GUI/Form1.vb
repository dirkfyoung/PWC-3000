Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.Windows.Forms.VisualStyles




Public Class Form1

    Private ReadOnly SchemeInfoList As New ArrayList ' this is a list and characteristics of all the application schemes, icluding crops, rates everything from labels

    ' these are for hiding the tabs that are not normally used
    Private tempTabpage1 As TabPage
    Private tempTabpage2 As TabPage
    Private tempTabpage3 As TabPage
    Private tempTabpage4 As TabPage
    Private tempTabpage5 As TabPage  'application tab
    Private tempTabpage6 As TabPage  'scenario tab

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.GetCultureInfo("en-US")
        Me.Text = "Pesticide Water Calculator, Version " & Standard.VersionNumber

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeApplicationTable()
        tempTabpage1 = AdvancedTab
        tempTabpage2 = ScenarioExaminerTab
        tempTabpage3 = OptionalOutputTab
        tempTabpage4 = WaterbodyExaminerTab
        tempTabpage5 = SchemeApplicationsTab
        tempTabpage6 = SchemeScenariosTab

        TabControl1.Controls.Remove(AdvancedTab)
        TabControl1.Controls.Remove(ScenarioExaminerTab)
        TabControl1.Controls.Remove(OptionalOutputTab)
        TabControl1.Controls.Remove(WaterbodyExaminerTab)
        TabControl1.Controls.Remove(SchemeApplicationsTab)
        TabControl1.Controls.Remove(SchemeScenariosTab)

        LoadDefaultDiscretizations()


    End Sub

    Private Sub LoadDefaultDiscretizations()
        DiscretizationGridView.Rows.Add(3, 30)
        DiscretizationGridView.Rows.Add(7, 7)
        DiscretizationGridView.Rows.Add(10, 2)
        DiscretizationGridView.Rows.Add(80, 4)
        DiscretizationGridView.Rows.Add(900, 18)
        DiscretizationGridView.Rows.Add(100, 2)
    End Sub



    Private Sub MakeApplicationTable()
        'Add Columns
        AppTableDisplay.ColumnCount = 2
        AppTableDisplay.Columns(0).Name = "Days"
        AppTableDisplay.Columns(0).Width = 70

        AppTableDisplay.Columns(1).Name = "Amount (kg/ha)"
        AppTableDisplay.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.None
        AppTableDisplay.Columns(1).Width = 60

        Dim combo As New DataGridViewComboBoxColumn With {
            .HeaderText = "Application Method",
            .Width = 135
        }

        combo.Items.Add(Standard.method1)
        combo.Items.Add(Standard.method2)
        combo.Items.Add(Standard.method3)
        combo.Items.Add(Standard.method4)
        combo.Items.Add(Standard.method5)
        combo.Items.Add(Standard.method6)
        combo.Items.Add(Standard.method7)

        'combo.Items.Add(Convert.ToString(ChrW(9661))) ' "▽" 'convert to string, or else there are problems elsewhere in read and save
        ''   combo.Items.Add(Convert.ToString(ChrW(9651))) ' "△"


        'combo.Items.Add(Standard.method7)
        AppTableDisplay.Columns.Add(combo)

        AppTableDisplay.Columns.Add("Depth", "Depth (cm)")
        ' AppTableDisplay.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(3).Width = 42

        AppTableDisplay.Columns.Add("Split", "Split")
        '    AppTableDisplay.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(4).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(4).Width = 44


        Dim driftcombo As New DataGridViewComboBoxColumn With {
            .HeaderText = "Drift Type",
            .DropDownWidth = 220,
            .Width = 160
        }

        driftcombo.Items.Add(Standard.sprayterm1)
        driftcombo.Items.Add(Standard.sprayterm2)
        driftcombo.Items.Add(Standard.sprayterm3)
        driftcombo.Items.Add(Standard.sprayterm4)
        driftcombo.Items.Add(Standard.sprayterm5)
        driftcombo.Items.Add(Standard.sprayterm6)
        driftcombo.Items.Add(Standard.sprayterm7)
        driftcombo.Items.Add(Standard.sprayterm8)
        driftcombo.Items.Add(Standard.sprayterm9)
        driftcombo.Items.Add(Standard.sprayterm10)
        driftcombo.Items.Add(Standard.sprayterm11)
        driftcombo.Items.Add(Standard.sprayterm12)
        driftcombo.Items.Add(Standard.sprayterm13)
        driftcombo.Items.Add(Standard.sprayterm14)
        driftcombo.Items.Add(Standard.sprayterm15)
        '       driftcombo.Items.Add(Standard.sprayterm16)

        AppTableDisplay.Columns.Add(driftcombo)


        'AppTableDisplay.Columns.Add("Drift", "Drift")
        '' AppTableDisplay.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'AppTableDisplay.Columns(5).SortMode = DataGridViewColumnSortMode.NotSortable
        'AppTableDisplay.Columns(5).Width = 80

        AppTableDisplay.Columns.Add("Buffer", "Drift Buffer (ft)")
        'AppTableDisplay.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        AppTableDisplay.Columns(6).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(6).Width = 64

        AppTableDisplay.Columns.Add("Periodicity", "Period")
        'AppTableDisplay.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(7).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(7).Width = 56

        AppTableDisplay.Columns.Add("Lag", "Lag")
        '  AppTableDisplay.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        AppTableDisplay.Columns(8).SortMode = DataGridViewColumnSortMode.NotSortable
        AppTableDisplay.Columns(8).Width = 42

        Dim btn As New DataGridViewButtonColumn()
        btn.Text = "delete"
        btn.HeaderText = "Delete"
        btn.Name = "Delete"
        btn.UseColumnTextForButtonValue = True
        btn.FlatStyle = FlatStyle.Popup
        btn.DefaultCellStyle.BackColor = Color.Orange

        AppTableDisplay.Columns.Add(btn)
        AppTableDisplay.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
    End Sub

    Private Sub RunoffGridView_RowPostPaint(ByVal sender As Object, ByVal e As DataGridViewRowPostPaintEventArgs)
        'Adds line numbers to the runoff table
        Using b As SolidBrush = New SolidBrush(HydroDataGrid.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex + 1, HydroDataGrid.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4)
        End Using
    End Sub



    Private Sub SaveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SaveToolStripMenuItem.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveFileDialogMain.Filter = "PWC 3 INPUT Files (*.PW4)|*.PW4|ALL Files (*.*)|*.*"
        SaveFileDialogMain.FilterIndex = 1

        SaveFileDialogMain.InitialDirectory = FileNames.WorkingDirectory
        SaveFileDialogMain.FileName = ""
        result = SaveFileDialogMain.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.InputFileName = SaveFileDialogMain.FileName


        FileNames.WorkingDirectory = System.IO.Path.GetDirectoryName(SaveFileDialogMain.FileName) & "\"
        WorkingDirectoryLabel.Text = FileNames.WorkingDirectory
        SaveFileDialogMain.InitialDirectory = WorkingDirectoryLabel.Text

        IOFamilyName.Text = System.IO.Path.GetFileNameWithoutExtension(SaveFileDialogMain.FileName)

        SaveInputsAsTextFile(SaveFileDialogMain.FileName)

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Try
            TextBox2.Text = Chr(TextBox3.Text)
        Catch ex As Exception

        End Try

        Try
            TextBox5.Text = ChrW(TextBox3.Text)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub WorkingDirectoryLabel_DoubleClick(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.DoubleClick
        'Go to directory if it exists

        If System.IO.Directory.Exists(WorkingDirectoryLabel.Text) Then
            Process.Start("explorer.exe", WorkingDirectoryLabel.Text)
        Else
            Return
        End If
    End Sub

    Private Sub WorkingDirectoryLabel_MouseEnter(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.MouseEnter
        If System.IO.Directory.Exists(WorkingDirectoryLabel.Text) Then
            WorkingDirectoryLabel.ForeColor = Color.Blue
        Else
            Return
        End If
    End Sub

    Private Sub WorkingDirectoryLabel_MouseLeave(sender As Object, e As EventArgs) Handles WorkingDirectoryLabel.MouseLeave
        WorkingDirectoryLabel.ForeColor = Color.Black
    End Sub

    Private Sub RetrieveToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RetrieveToolStripMenuItem.Click
        Dim result As System.Windows.Forms.DialogResult

        RetrieveMainInput.Filter = "PWC 3 INPUT Files (*.PW4)|*.PW4|PWC 3 INPUT Files (*.PW3)|*.PW3|ALL Files (*.*)|*.*"

        'Opens the desktop if there is no previous open
        If System.IO.Directory.Exists(FileNames.WorkingDirectory) Then
            RetrieveMainInput.InitialDirectory = FileNames.WorkingDirectory
        Else
            '  RetrieveMainInput.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End If

        RetrieveMainInput.FileName = ""

        result = RetrieveMainInput.ShowDialog(Me)

        'Cancel button will cause return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.WorkingDirectory = System.IO.Path.GetDirectoryName(RetrieveMainInput.FileName) & "\"

        ReadInputsFromTextFile(RetrieveMainInput.FileName)

        'disable all edit buttons in scheme table on first retrieve
        Dim buttonCell As DataGridViewDisableButtonCell
        For i As Integer = 0 To SchemeTableDisplay.RowCount - 1
            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
            buttonCell.Enabled = False
        Next

        'Disable the last new row button
        buttonCell = CType(SchemeTableDisplay.Rows(SchemeTableDisplay.Rows.Count - 1).Cells("Delete"), DataGridViewDisableButtonCell)
        buttonCell.Enabled = False

        TallyRuns()


    End Sub

    Private Sub CalculateButton_Click(sender As Object, e As EventArgs) Handles CalculateButton.Click


        If Not System.IO.Directory.Exists(WorkingDirectoryLabel.Text) Then
            MsgBox("No Working Directory. Save this work, And a working directory will be automatcally established")
            Return
        End If

        System.IO.Directory.SetCurrentDirectory(WorkingDirectoryLabel.Text)

        Dim isCorrect As Boolean
        Dim WarningMessage As String = ""
        CheckChemicalInputs(isCorrect, WarningMessage)
        If Not isCorrect Then
            MsgBox(WarningMessage)
            Return
        End If


        RunPRZMandVVWM()



    End Sub

    Private Sub YearlyCycleButton_CheckedChanged(sender As Object, e As EventArgs)

        If HydroDataGrid.IsHandleCreated Then ' need this to prevent firing at load time before grid is available
            If YearlyCycleButton.Checked Then
                HydroDataGrid.Columns(0).HeaderText = "Date (m/d)"
            Else
                HydroDataGrid.Columns(0).HeaderText = "Date (m/d/y)"
            End If
        End If

    End Sub

    Private Sub EvergreenCheckbox_CheckedChanged(sender As Object, e As EventArgs)
        If Evergreen.Checked Then
            EvergreenPanel.Visible = True
            CropGridView.Visible = False
        Else
            EvergreenPanel.Visible = False
            CropGridView.Visible = True
        End If
    End Sub





    Private Sub AbsoluteDaysButton_CheckedChanged(sender As Object, e As EventArgs) Handles AbsoluteDaysButton.CheckedChanged, emerge.CheckedChanged

        If AppTableDisplay.IsHandleCreated Then
            If AbsoluteDaysButton.Checked Then
                AppTableDisplay.Columns(0).Name = "Date"
            Else
                AppTableDisplay.Columns(0).Name = "Days"
            End If
        End If

    End Sub

    Private Sub GetWeatherFileDirectory_Click(sender As Object, e As EventArgs) Handles GetWeatherFileDirectory.Click
        Dim result As System.Windows.Forms.DialogResult

        result = WeatherFolderBrowser.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        WeatherDirectoryBox.Text = WeatherFolderBrowser.SelectedPath & "\"
    End Sub

    Private Sub GetWeatherFile_Click(sender As Object, e As EventArgs) Handles GetWeatherFile.Click
        Dim result As System.Windows.Forms.DialogResult
        GetWeatherFileDialog.Filter = "WEA files (*.WEA)|*.WEA|All files (*.*)|*.*"

        If System.IO.Directory.Exists(FileNames.PreviousWeatherPath) Then
            GetWeatherFileDialog.InitialDirectory = FileNames.PreviousWeatherPath
        End If

        result = GetWeatherFileDialog.ShowDialog() 'display Open dialog box

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        WeatherFileName.Text = System.IO.Path.GetFileName(GetWeatherFileDialog.FileName)
        WeatherDirectoryBox.Text = System.IO.Path.GetDirectoryName(GetWeatherFileDialog.FileName) & "\"

        FileNames.PreviousWeatherPath = System.IO.Path.GetDirectoryName(GetWeatherFileDialog.FileName)

    End Sub

    ' This event handler manually raises the CellValueChanged event
    ' by calling the CommitEdit method.
    Public Sub DataGridView1_CurrentCellDirtyStateChanged(
        ByVal sender As Object, ByVal e As EventArgs) _
        Handles SchemeTableDisplay.CurrentCellDirtyStateChanged

        If SchemeTableDisplay.IsCurrentCellDirty Then
            SchemeTableDisplay.CommitEdit(DataGridViewDataErrorContexts.Commit)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellContentClick

        Dim NumberofApplications As Integer
        Dim ApplicationTable As New SchemeDetails With {
            .Days = New List(Of String),
            .Amount = New List(Of String),
            .Method = New List(Of String),
            .Depth = New List(Of String),
            .Split = New List(Of String),
            .Drift = New List(Of String),
            .Lag = New List(Of String),
            .Periodicity = New List(Of String),
            .Scenarios = New List(Of String)
        } 'local for picking up schem inforation

        Dim Description As String
        Dim SchemeLabels As String
        Dim DisplayedSchemeNumber As Integer

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
                Case "Edit"

                    'clear all got it
                    For i As Integer = 0 To SchemeTableDisplay.RowCount - 1
                        SchemeTableDisplay.Rows(i).Cells("Commit").Value = ""
                    Next

                'this if statement ensures that all buttons are deactivated when unchecked
                If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True Then

                    For Each oRow As DataGridViewRow In SchemeTableDisplay.Rows
                        oRow.Cells("Edit").Value = False
                    Next
                    SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True

                    'toggle scenario and app tab on if checked
                    If TabControl1.Controls.Contains(tempTabpage5) = False Then
                        'tab 5 and 6 are always together, so only need to see if oe or the other is active
                        TabControl1.Controls.Add(tempTabpage5)
                        TabControl1.Controls.Add(tempTabpage6)
                    End If

                Else
                    For Each oRow As DataGridViewRow In SchemeTableDisplay.Rows
                        oRow.Cells("Edit").Value = False
                    Next

                    'toggle off scenario and app tab if nothing checked
                    TabControl1.Controls.Remove(SchemeApplicationsTab)
                    TabControl1.Controls.Remove(SchemeScenariosTab)
                End If


                If SchemeTableDisplay.Columns(e.ColumnIndex).Name = "Edit" Then
                        Dim buttonCell As DataGridViewDisableButtonCell
                        Dim checkCell As DataGridViewCheckBoxCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit"), DataGridViewCheckBoxCell)

                        For i As Integer = 0 To SchemeTableDisplay.RowCount - 1
                            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = False

                            'dont allow scheme description to be edited unless checked
                            SchemeTableDisplay.Rows(i).Cells(3).ReadOnly = True
                        Next

                        '________________________________________________________________________
                        'When a new row is created, Make the delete button imediatelty active and disable the new button


                        If (SchemeTableDisplay.Rows.Count - 2 = e.RowIndex) Then
                            buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = True
                            buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex + 1).Cells("Delete"), DataGridViewDisableButtonCell)
                            buttonCell.Enabled = False
                        End If

                    '_______________________________________________

                    'allow only active scheme description to be edited
                    SchemeTableDisplay.Rows(e.RowIndex).Cells(3).ReadOnly = False

                        buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit"), DataGridViewDisableButtonCell)

                        buttonCell.Enabled = CType(checkCell.Value, [Boolean])

                        SchemeTableDisplay.Invalidate()
                    End If

                    Description = SchemeTableDisplay.Rows(e.RowIndex).Cells(3).Value

                    DisplayedSchemeNumber = e.RowIndex + 1
                    SchemeLabels = DisplayedSchemeNumber & " " & Description

                    Label88.Text = SchemeLabels
                    Label87.Text = SchemeLabels

                    If SchemeInfoList.Count - 1 < e.RowIndex Then
                        'in case edit button is pushed before anything is populated previously an error will not throw
                        Exit Sub
                    End If

                    ApplicationTable = SchemeInfoList(e.RowIndex)

                    NumberofApplications = ApplicationTable.Days.Count
                    AppTableDisplay.Rows.Clear()

                If NumberofApplications > 0 Then  'prevents error if user attempts to save without any applications
                    AppTableDisplay.Rows.Add(NumberofApplications)

                    For i As Integer = 0 To NumberofApplications - 1
                        AppTableDisplay.Item(0, i).Value = ApplicationTable.Days(i)
                        AppTableDisplay.Item(1, i).Value = ApplicationTable.Amount(i)


                        Select Case (ApplicationTable.Method(i))
                            Case (1)
                                AppTableDisplay.Item(2, i).Value = Standard.method1
                            Case (2)
                                AppTableDisplay.Item(2, i).Value = Standard.method2
                            Case (3)
                                AppTableDisplay.Item(2, i).Value = Standard.method3
                            Case (4)
                                AppTableDisplay.Item(2, i).Value = Standard.method4
                            Case (5)
                                AppTableDisplay.Item(2, i).Value = Standard.method5
                            Case (6)
                                AppTableDisplay.Item(2, i).Value = Standard.method6
                            Case (7)
                                AppTableDisplay.Item(2, i).Value = Standard.method7
                            Case Else
                                AppTableDisplay.Item(2, i).Value = Standard.method1
                        End Select


                        AppTableDisplay.Item(3, i).Value = ApplicationTable.Depth(i)
                        AppTableDisplay.Item(4, i).Value = ApplicationTable.Split(i)
                        '   AppTableDisplay.Item(5, i).Value = ApplicationTable.Drift(i)

                        Select Case ApplicationTable.Drift(i)
                            Case 1
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm1
                            Case 2
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm2
                            Case 3
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm3
                            Case 4
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm4
                            Case (5)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm5
                            Case (6)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm6
                            Case (7)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm7
                            Case (8)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm8
                            Case (9)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm9
                            Case (10)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm10
                            Case (11)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm11
                            Case (12)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm12
                            Case (13)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm13
                            Case (14)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm14
                            Case (15)
                                AppTableDisplay.Item(5, i).Value = Standard.sprayterm15
                                'Case (16)
                                '    AppTableDisplay.Item(5, i).Value = Standard.sprayterm16
                        End Select

                        AppTableDisplay.Item(6, i).Value = ApplicationTable.DriftBuffer(i)
                        AppTableDisplay.Item(7, i).Value = ApplicationTable.Periodicity(i)
                        AppTableDisplay.Item(8, i).Value = ApplicationTable.Lag(i)

                    Next
                End If

                AbsoluteDaysButton.Checked = ApplicationTable.AbsoluteRelative

                emerge.Checked = ApplicationTable.Emerge
                maturity.Checked = ApplicationTable.Maturity
                removal.Checked = ApplicationTable.Removal

                UseApplicationWindow.Checked = ApplicationTable.UseApplicationWindow
                ApplicationWindowDays.Text = ApplicationTable.ApplicationWindowSpan
                ApplicationWindowStep.Text = ApplicationTable.ApplicationWindowStep

                UseRainFast.Checked = ApplicationTable.UseRainFast
                RainLimit.Text = ApplicationTable.RainLimit
                IntolerableRainWindow.Text = ApplicationTable.IntolerableRainWindow
                OptimumApplicationWindow.Text = ApplicationTable.OptimumApplicationWindow
                MinDaysBetweenApps.Text = ApplicationTable.MinDaysBetweenApps
                GetScenariosBatchCheckBox.Checked = ApplicationTable.UseBatchScenarioFile
                ScenarioBatchFileName.Text = ApplicationTable.ScenarioBatchFileName

                RunoffMitigation.Text = ApplicationTable.RunoffMitigation
                ErosionMitigation.Text = ApplicationTable.ErosionMitigation
                DriftMitigation.Text = ApplicationTable.DriftMitigation

                ScenarioListBox.Items.Clear()
                    For Each ee As String In ApplicationTable.Scenarios
                        ScenarioListBox.Items.Add(ee)
                    Next

                Case "Commit"

                '    'Disabling button apparently does not really disable its action, only its color
                '    'So I added the following IF to kick out of the commit button if the edit box is not checked

                If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = False Then
                    Exit Sub
                End If


                'same set of lines as in EDIT above, but needed because if you change scheme description
                'without unchecking and rechecking EDIT, then the labels will not be loaded
                Description = SchemeTableDisplay.Rows(e.RowIndex).Cells(3).Value

                    DisplayedSchemeNumber = e.RowIndex + 1
                    SchemeLabels = DisplayedSchemeNumber & " " & Description

                    Label88.Text = SchemeLabels
                    Label87.Text = SchemeLabels

                For i As Integer = 0 To SchemeTableDisplay.RowCount - 1
                    SchemeTableDisplay.Rows(i).Cells(e.ColumnIndex).Value = ""
                Next

                RecordScheme(e.RowIndex)

                SchemeTableDisplay.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "got it"

                TallyRuns()

                ''******* Calculate the total number of simulations ************************
                'Dim tally As Integer
                'Dim runsInScheme As Integer
                'Dim windowRuns As Integer
                'Dim span As Single
                'Dim windstep As Single

                'tally = 0

                'For i As Integer = 0 To SchemeInfoList.Count - 1
                '    If SchemeInfoList(i).UseBatchScenarioFile Then
                '        RunCount.Text = "????"

                '        Exit For
                '    End If

                '    If SchemeInfoList(i).UseApplicationWindow Then
                '        Try
                '            span = SchemeInfoList(i).ApplicationWindowSpan
                '            windstep = SchemeInfoList(i).ApplicationWindowStep
                '            If span > 365 Then
                '                MsgBox("Application Window span maximum is 365 days")
                '                RunCount.Text = "XXXXXXX"
                '                Exit Sub
                '            End If

                '        Catch ex As Exception
                '            MsgBox("The Application Window parameters are a problem")
                '            RunCount.Text = "XXXXXXX"
                '            Exit Sub
                '        End Try

                '        windowRuns = span / windstep + 1
                '    Else
                '        windowRuns = 1
                '    End If
                '    runsInScheme = SchemeInfoList(i).Scenarios.Count * windowRuns
                '    tally = tally + runsInScheme
                'Next


                'If RunCount.Text <> "????" Then
                '    RunCount.Text = tally
                'End If
                ''********************************************************************

                Timer1.Start()



                Case "Delete"

                If SchemeTableDisplay.CurrentRow.IsNewRow Then
                        Beep()
                    Else
                        'toggle off scenario and app tab if delete the checked scheme 

                        If SchemeTableDisplay.Rows(e.RowIndex).Cells(1).Value Then
                            TabControl1.Controls.Remove(SchemeApplicationsTab)
                            TabControl1.Controls.Remove(SchemeScenariosTab)
                        End If

                    SchemeTableDisplay.Rows.Remove(SchemeTableDisplay.Rows(e.RowIndex))
                    End If

                    If SchemeInfoList.Count > e.RowIndex Then
                        'this if condition is needed if there is an uncommitted row, then you can still delete it
                        'likewise if there is an uncommited row, then this prevents attempting to delete a nonexistent scheme
                        'only want to delete table row, and not schemeinfolist item

                        SchemeInfoList.RemoveAt(e.RowIndex)
                    End If

                TallyRuns()




            Case Else
                    Exit Sub
            End Select





    End Sub

    Private Sub TallyRuns()
        '******* Calculate the total number of simulations ************************
        Dim tally As Integer
        Dim runsInScheme As Integer
        Dim windowRuns As Integer
        Dim span As Single
        Dim windstep As Single

        tally = 0

        For i As Integer = 0 To SchemeInfoList.Count - 1
            If SchemeInfoList(i).UseBatchScenarioFile Then
                RunCount.Text = "????"

                Exit For
            End If

            If SchemeInfoList(i).UseApplicationWindow Then
                Try
                    span = SchemeInfoList(i).ApplicationWindowSpan
                    windstep = SchemeInfoList(i).ApplicationWindowStep
                    'If span > 365 Then
                    '    MsgBox("Application Window span maximum is 365 days")
                    '    RunCount.Text = "XXXXXXX"
                    '    Exit Sub
                    'End If

                Catch ex As Exception
                    '     MsgBox("The Application Window parameters are a problem")
                    RunCount.Text = "XXXXXXX"
                    Exit Sub
                End Try

                windowRuns = span / windstep + 1
            Else
                windowRuns = 1
            End If
            runsInScheme = SchemeInfoList(i).Scenarios.Count * windowRuns
            tally = tally + runsInScheme
        Next


        If RunCount.Text <> "????" Then
            RunCount.Text = tally
        End If



    End Sub






    Private Sub SchemeTableDisplay_CellMouseEnter(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellMouseEnter

        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Dim buttonCell As DataGridViewDisableButtonCell
        buttonCell = CType(SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete"), DataGridViewDisableButtonCell)

        'this logic signifies a new row,;iterally "isnewrow" does not work so resorted to this.
        If (SchemeTableDisplay.Rows.Count - 1 = e.RowIndex) Then
            buttonCell.Enabled = False
            SchemeTableDisplay.Invalidate()  'redraw
            Exit Sub
        Else
            buttonCell.Enabled = True
        End If


        SchemeTableDisplay.Invalidate()  'redraw



        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
            Case "Delete"

                SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete").Value = "Delete"


            Case "Commit"
                If SchemeTableDisplay.Rows(e.RowIndex).Cells("Edit").Value = True Then
                    SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit").Value = "Commit"
                End If
        End Select

    End Sub

    Private Sub SchemeTableDisplay_CellMouseLeave(sender As Object, e As DataGridViewCellEventArgs) Handles SchemeTableDisplay.CellMouseLeave
        If e.RowIndex < 0 Then
            Exit Sub
        End If

        Select Case SchemeTableDisplay.Columns(e.ColumnIndex).Name
            Case "Delete"
                SchemeTableDisplay.Rows(e.RowIndex).Cells("Delete").Value = ""
            Case "Commit"
                SchemeTableDisplay.Rows(e.RowIndex).Cells("Commit").Value = ""
        End Select
    End Sub




    Private Sub SchemeTableDisplay_SelectionChanged(sender As Object, e As EventArgs) Handles SchemeTableDisplay.SelectionChanged

        'Prevents adding new schemes until previous scheme is committed. It does this by checking whether the rows
        ' in the SchemeTableDisplay equal the number items of items in the SchemeInfoList, specifically by checking:
        '(SchemeInfoList.Count vs. SchemeTableDisplay.Rows.Count - 1)


        If SchemeTableDisplay.CurrentRow.IsNewRow Then  'schemes can only be added on the "new row"

            If SchemeInfoList.Count < SchemeTableDisplay.Rows.Count - 1 Then  'Previous row is not committed

                SchemeTableDisplay.CurrentRow.Cells(3).ReadOnly = True  'Current row is new row, so no entry allowed util commit
                '  SchemeTableDisplay.CurrentRow.Cells(1).Value = False    'clear any checks
                SchemeTableDisplay.CurrentRow.Cells(1).ReadOnly = True  'dont allow any checks in edit box
                MsgBox("Previous scheme has never been committed. Commit that scheme before adding another scheme")
            Else
                SchemeTableDisplay.CurrentRow.Cells(1).ReadOnly = False   'allow the edit box to be checked
            End If

        Else


            'prevents previous row from being editable without checkbox after a new row has been populated
            If SchemeTableDisplay.CurrentRow.Cells(1).Value = False Then
                SchemeTableDisplay.CurrentRow.Cells(3).ReadOnly = True
            Else
                SchemeTableDisplay.CurrentRow.Cells(3).ReadOnly = False
            End If



        End If



    End Sub






    Private Sub SelectScenarios_Click(sender As Object, e As EventArgs) Handles SelectScenarios.Click
        Dim result As System.Windows.Forms.DialogResult

        OpenAndSelectScenarios.Filter = "Scenario Files V2 (*.SCN2)|*.SCN2| All files (*.*)|*.*"

        OpenAndSelectScenarios.InitialDirectory = FileNames.DefaultScenarioDirectory

        If System.IO.Directory.Exists(FileNames.PreviousScenarioPath) Then
            OpenAndSelectScenarios.InitialDirectory = FileNames.PreviousScenarioPath
        End If

        result = OpenAndSelectScenarios.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FileName)
        Dim selectedScenario As String

        For Each selectedScenario In OpenAndSelectScenarios.FileNames
            ' ScenariosList.Items.Add(System.IO.Path.GetFileName(selectedScenario))
            'need path
            ScenarioListBox.Items.Add(selectedScenario)
        Next

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FileName)

    End Sub

    Private Sub ClearSelectedScenarios_Click(sender As Object, e As EventArgs) Handles ClearSelectedScenarios.Click
        Dim selectedScenario As String
        Dim selectedScenarios = (From i In ScenarioListBox.SelectedItems).ToArray()

        For Each selectedScenario In selectedScenarios
            ScenarioListBox.Items.Remove(selectedScenario)
        Next
    End Sub

    Private Sub ClearAllScenarios_Click(sender As Object, e As EventArgs) Handles ClearAllScenarios.Click
        ScenarioListBox.Items.Clear()
    End Sub

    Private Sub SchemeTableDisplay_RowPostPaint(sender As Object, e As DataGridViewRowPostPaintEventArgs) Handles SchemeTableDisplay.RowPostPaint
        'Adds line numbers to the scheme table
        Using b As SolidBrush = New SolidBrush(SchemeTableDisplay.RowHeadersDefaultCellStyle.ForeColor)
            e.Graphics.DrawString(e.RowIndex + 1, SchemeTableDisplay.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4)
        End Using
    End Sub

    Private Sub DoDegradate1_CheckedChanged(sender As Object, e As EventArgs) Handles DoDegradate1.CheckedChanged
        If DoDegradate1.Checked = False Then
            DoDegradate2.Checked = False
            DoDegradate2.Enabled = False
            DaughterVisibleStatus(False)
        Else
            DoDegradate2.Enabled = True
            DaughterVisibleStatus(True)
        End If
    End Sub

    Private Sub DoDegradate2_CheckedChanged(sender As Object, e As EventArgs) Handles DoDegradate2.CheckedChanged
        If DoDegradate2.Checked = False Then
            GrandaughterVisibleStatus(False)
        Else
            GrandaughterVisibleStatus(True)
        End If
    End Sub


    Private Sub GrandaughterVisibleStatus(status As Boolean)
        sorption3.Visible = status
        WaterColMetab3.Visible = status
        WaterColRef3.Visible = status
        BenthicMetab3.Visible = status
        BenthicRef3.Visible = status
        Photo3.Visible = status
        PhotoLat3.Visible = status
        Hydrolysis3.Visible = status
        SoilDegradation3.Visible = status
        SoilRef3.Visible = status
        FoliarDeg3.Visible = status
        FoliarWashoff3.Visible = status
        MWT3.Visible = status
        VaporPress3.Visible = status
        Sol3.Visible = status
        Henry3.Visible = status
        AirDiff3.Visible = status
        HeatHenry3.Visible = status

        WaterMolarRatio2.Visible = status
        BenthicMolarRatio2.Visible = status
        PhotoMolarRatio2.Visible = status
        HydroMolarRatio2.Visible = status
        SoilMolarRatio2.Visible = status
        FoliarMolarRatio2.Visible = status


    End Sub

    Private Sub DaughterVisibleStatus(status As Boolean)

        sorption2.Visible = status
        WaterColMetab2.Visible = status
        WaterColRef2.Visible = status
        BenthicMetab2.Visible = status
        BenthicRef2.Visible = status
        Photo2.Visible = status
        PhotoLat2.Visible = status
        Hydrolysis2.Visible = status
        SoilDegradation2.Visible = status
        SoilRef2.Visible = status
        FoliarDeg2.Visible = status
        FoliarWashoff2.Visible = status
        MWT2.Visible = status
        VaporPress2.Visible = status
        Sol2.Visible = status
        Henry2.Visible = status
        AirDiff2.Visible = status
        HeatHenry2.Visible = status

        WaterMolarRatio1.Visible = status
        BenthicMolarRatio1.Visible = status
        PhotoMolarRatio1.Visible = status
        HydroMolarRatio1.Visible = status
        SoilMolarRatio1.Visible = status
        FoliarMolarRatio1.Visible = status


    End Sub






    Private Sub ItsOther_CheckedChanged(sender As Object, e As EventArgs) Handles ItsOther.CheckedChanged
        'If ItsOther.Checked Then
        '    waterbodypanel.Visible = True
        'Else
        '    waterbodypanel.Visible = False
        'End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim result As System.Windows.Forms.DialogResult

        OpenAndSelectScenarios.Filter = "Water Body Files (*.WAT)|*.WAT| All files (*.*)|*.*"

        OpenAndSelectScenarios.InitialDirectory = FileNames.DefaultWaterBodyDirectory

        If System.IO.Directory.Exists(FileNames.PreviousWaterBodyPath) Then
            OpenAndSelectScenarios.InitialDirectory = FileNames.PreviousWaterBodyPath
        End If

        result = OpenAndSelectScenarios.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FileName)
        Dim selectedScenario As String

        For Each selectedScenario In OpenAndSelectScenarios.FileNames
            ' ScenariosList.Items.Add(System.IO.Path.GetFileName(selectedScenario))
            'need path
            WaterbodyList.Items.Add(selectedScenario)
        Next

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenAndSelectScenarios.FileName)



    End Sub

    Private Sub ClearSelectedWaterBody_Click(sender As Object, e As EventArgs) Handles ClearSelectedWaterBody.Click
        Dim WaterBody As String

        Dim selectedWaterBodies = (From i In WaterbodyList.SelectedItems).ToArray()

        For Each WaterBody In selectedWaterBodies
            WaterbodyList.Items.Remove(WaterBody)
        Next
    End Sub

    Private Sub ClearAllWaterBodies_Click(sender As Object, e As EventArgs) Handles ClearAllWaterBodies.Click
        WaterbodyList.Items.Clear()
    End Sub

    Private Sub PushToLoadScenario_Click(sender As Object, e As EventArgs) Handles PushToLoadScenario.Click

        If LoadFromCSV.Checked Then
            OpenSingleScenarioFile.Filter = "Batch CSV Files (*.CSV)|*.CSV"
        Else
            OpenSingleScenarioFile.Filter = "Scenario Files (*.SCN2)|*.SCN2"
        End If


        If System.IO.Directory.Exists(FileNames.PreviousScenarioPath) Then
            OpenSingleScenarioFile.InitialDirectory = FileNames.PreviousScenarioPath
        Else
            OpenSingleScenarioFile.InitialDirectory = FileNames.DefaultScenarioDirectory
        End If

        Dim result As System.Windows.Forms.DialogResult
        result = OpenSingleScenarioFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSingleScenarioFile.FileName)

        If LoadFromCSV.Checked Then
            LoadSingleBatchFileScenario(OpenSingleScenarioFile.FileName)
        Else
            ReadScenarioParameters(OpenSingleScenarioFile.FileName)
        End If






    End Sub

    Private Sub PushToSaveScenario_Click(sender As Object, e As EventArgs) Handles PushToSaveScenario.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveSingleScenarioFile.Filter = "Scenario Files V2 (*.scn2)|*.SCN2"
        SaveSingleScenarioFile.InitialDirectory = FileNames.PreviousCustomScenarioPath

        'make the file default to be the last file retrieved
        SaveSingleScenarioFile.FileName = FileNames.PreviousScenarioFile

        result = SaveSingleScenarioFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(SaveSingleScenarioFile.FileName)

        Dim msg As String

        msg = CreateScenarioString()

        Try
            My.Computer.FileSystem.WriteAllText(SaveSingleScenarioFile.FileName, msg, False, System.Text.Encoding.ASCII)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub PushToLoadWaterBody_Click(sender As Object, e As EventArgs) Handles PushToLoadWaterBody.Click

        OpenWaterbodyFile.Filter = "Waterbody Files (*.WAT)|*.WAT"

        If System.IO.Directory.Exists(FileNames.PreviousWaterBodyPath) Then
            OpenWaterbodyFile.InitialDirectory = FileNames.PreviousWaterBodyPath
        Else
            OpenWaterbodyFile.InitialDirectory = FileNames.DefaultScenarioDirectory
        End If


        Dim result As System.Windows.Forms.DialogResult

        result = OpenWaterbodyFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If


        FileNames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(OpenWaterbodyFile.FileName)

        ReadwaterBodyParameters(OpenWaterbodyFile.FileName)


    End Sub

    Private Sub PushToSaveWaterBody_Click(sender As Object, e As EventArgs) Handles PushToSaveWaterBody.Click


        Dim result As System.Windows.Forms.DialogResult

        SaveWaterbodyFile.Filter = "Waterbody Files (*.WAT)|*.WAT|ALL Files (*.*)|*.*"
        SaveWaterbodyFile.InitialDirectory = FileNames.PreviousWaterBodyPath

        'make the file default to be the last file retrieved
        SaveWaterbodyFile.FileName = FileNames.PreviousScenarioFile

        result = SaveWaterbodyFile.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousWaterBodyPath = System.IO.Path.GetDirectoryName(SaveWaterbodyFile.FileName)

        Dim msg As String

        msg = CreateWaterbodyString()

        Try
            My.Computer.FileSystem.WriteAllText(SaveWaterbodyFile.FileName, msg, False, System.Text.Encoding.ASCII)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim a As Integer
        Dim b As Integer
        a = SchemeTableDisplay.CurrentCell.RowIndex
        b = SchemeTableDisplay.CurrentCell.ColumnIndex
        SchemeTableDisplay.Rows(a).Cells(b).Value = ""
        Timer1.Stop()
    End Sub
    Private Sub ToggleAdvancedToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleAdvancedToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage1) Then
            TabControl1.Controls.Remove(AdvancedTab)
            Return
        End If
        TabControl1.Controls.Add(tempTabpage1)
    End Sub
    Private Sub ToggleScenarioExaminerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleScenarioExaminerToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage2) Then
            TabControl1.Controls.Remove(ScenarioExaminerTab)
            Return
        End If
        TabControl1.Controls.Add(tempTabpage2)
    End Sub


    Private Sub ToggeWaterbodyExaminerToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggeWaterbodyExaminerToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage4) Then
            TabControl1.Controls.Remove(WaterbodyExaminerTab)
            Return
        End If
        TabControl1.Controls.Add(tempTabpage4)
    End Sub



    Private Sub ToggleMoreOutputToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ToggleMoreOutputToolStripMenuItem.Click
        If TabControl1.Controls.Contains(tempTabpage3) Then
            TabControl1.Controls.Remove(OptionalOutputTab)
            Return
        End If
        TabControl1.Controls.Add(tempTabpage3)
    End Sub







    Private Sub AdditionalOutputGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AdditionalOutputGridView.CellContentClick




        If AdditionalOutputGridView.Columns(e.ColumnIndex).HeaderText = "Delete" Then

            If AdditionalOutputGridView.Item(0, e.RowIndex).Value = "EoF" Then
                CalculateEoF.Visible = True
            End If

            If AdditionalOutputGridView.CurrentRow.IsNewRow Then
                Beep()
            Else
                AdditionalOutputGridView.Rows.Remove(AdditionalOutputGridView.Rows(e.RowIndex))
            End If




        End If




    End Sub

    Private Sub AppTableDisplay_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AppTableDisplay.CellContentClick, AppTableDisplay.CellValueChanged


        Select Case AppTableDisplay.Columns(e.ColumnIndex).Name

            Case "Delete"

                If AppTableDisplay.CurrentRow.IsNewRow Then

                    Beep()
                Else

                    'AppTableDisplay.Rows.Remove(AppTableDisplay.Rows(AppTableDisplay.SelectedCells.Item(0).RowIndex))

                    AppTableDisplay.Rows.Remove(AppTableDisplay.Rows(e.RowIndex))
                    Exit Sub

                    AppTableDisplay.ClearSelection()

                End If


            Case Else

                If e.RowIndex > -1 Then
                    Select Case AppTableDisplay.Rows(e.RowIndex).Cells(2).Value
                        Case Standard.method1, Standard.method2                    'above and below crop
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).Value = "4.0"
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).Value = "0.0"

                            AppTableDisplay.Rows(e.RowIndex).Cells(3).ReadOnly = True
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).ReadOnly = True
                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Gray
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Gray


                        Case Standard.method3, Standard.method4, Standard.method6, Standard.method7      'Uniform and triangles
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).Value = "0.0"

                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Gray
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).ReadOnly = False
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).ReadOnly = True


                        Case Else
                            AppTableDisplay.Item(3, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Item(4, e.RowIndex).Style.ForeColor = Color.Black
                            AppTableDisplay.Rows(e.RowIndex).Cells(3).ReadOnly = False
                            AppTableDisplay.Rows(e.RowIndex).Cells(4).ReadOnly = False

                    End Select


                End If



        End Select

    End Sub

    Private Sub EstimateHenryConst_Click(sender As Object, e As EventArgs) Handles EstimateHenryConst.Click

        Dim henryConstant As Single
        Dim TrueOrFalse As Boolean
        Dim msg As String

        msg = ""

        If MsgBox("Do you want To overwrite the Henry's Law value with an estimate based on the solubility and vapor pressure?", 4, "Overwrite Warning") = 7 Then
            Return
        End If


        TestRealNumbers(TrueOrFalse, msg, VaporPress1)

        If TrueOrFalse = False Then
            MsgBox(msg)


            Return
        End If

        TestRealNumbers(TrueOrFalse, msg, Sol1)
        If TrueOrFalse = False Then
            MsgBox(msg)
            Return
        End If

        TestRealNumbers(TrueOrFalse, msg, MWT1)
        If TrueOrFalse = False Then
            MsgBox(msg)
            Return
        End If

        henryConstant = Henry.UnitlessVolumetric(VaporPress1.Text, Sol1.Text, MWT1.Text)
        Henry1.Text = String.Format("{0:G3}", henryConstant)

        If DoDegradate1.Checked Then
            TestRealNumbers(TrueOrFalse, msg, VaporPress2)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Sol2)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            TestRealNumbers(TrueOrFalse, msg, MWT2)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            henryConstant = Henry.UnitlessVolumetric(VaporPress2.Text, Sol2.Text, MWT2.Text)
            Henry2.Text = String.Format("{0:G3}", henryConstant)
        End If

        If DoDegradate2.Checked Then
            TestRealNumbers(TrueOrFalse, msg, VaporPress3)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            TestRealNumbers(TrueOrFalse, msg, Sol3)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            TestRealNumbers(TrueOrFalse, msg, MWT3)
            If TrueOrFalse = False Then
                MsgBox(msg)
                Return
            End If

            henryConstant = Henry.UnitlessVolumetric(VaporPress3.Text, Sol3.Text, MWT3.Text)
            Henry3.Text = String.Format("{0:G3}", henryConstant)
        End If



    End Sub



    Private Sub HorizonGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles HorizonGridView.CellContentClick

        Select Case HorizonGridView.Columns(e.ColumnIndex).HeaderText
            Case "Delete"

                If HorizonGridView.CurrentRow.IsNewRow Then
                    Beep()
                Else
                    HorizonGridView.Rows.Remove(HorizonGridView.Rows(e.RowIndex))
                End If
            Case Else
                Exit Sub

        End Select

    End Sub

    Private Sub SelectScenarioBatchFile_Click(sender As Object, e As EventArgs) Handles SelectScenarioBatchFile.Click
        Dim result As System.Windows.Forms.DialogResult


        OpenSelectScenarioBatchFile.Filter = "Scenario Batch Files (*.CSV)|*.CSV| All files (*.*)|*.*"


        OpenSelectScenarioBatchFile.InitialDirectory = FileNames.DefaultScenarioDirectory

        If System.IO.Directory.Exists(FileNames.PreviousScenarioPath) Then
            OpenSelectScenarioBatchFile.InitialDirectory = FileNames.PreviousScenarioPath
        End If

        result = OpenSelectScenarioBatchFile.ShowDialog() 'display Open dialog box
        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSelectScenarioBatchFile.FileName)
        ScenarioBatchFileName.Text = OpenSelectScenarioBatchFile.FileName

        FileNames.PreviousScenarioPath = System.IO.Path.GetDirectoryName(OpenSelectScenarioBatchFile.FileName)

    End Sub

    Private Sub ScenarioListBox_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ScenarioListBox.MouseDoubleClick
        Dim intIndex As Integer = ScenarioListBox.Items.IndexOf(ScenarioListBox.SelectedItem)
        Dim objInputBox As Object = InputBox("Change Item :", "Edit", ScenarioListBox.SelectedItem)
        If Not objInputBox = Nothing Then
            ScenarioListBox.Items.Remove(ScenarioListBox.SelectedItem)
            ScenarioListBox.Items.Insert(intIndex, objInputBox)
        End If




    End Sub

    Private Sub ClearTable_Click(sender As Object, e As EventArgs) Handles ClearTable.Click

        AppTableDisplay.Rows.Clear()


    End Sub

    Private Sub ItsaPond_CheckedChanged(sender As Object, e As EventArgs) Handles ItsaPond.CheckedChanged
        If ItsaPond.Checked Then
            ItsTPEZWPEZ.Enabled = True
        Else
            ItsTPEZWPEZ.Enabled = False
            ItsTPEZWPEZ.Checked = False
        End If
    End Sub

    Private Sub ModifyScenarios_Click(sender As Object, e As EventArgs) Handles ModifyScenarios.Click
        'Dim msg As String
        'Dim newfilename As String

        MsgBox("disabled, for developer only")

        'For Each scenariofilename As String In ScenarioListBox.Items

        '    ReadScenarioParameters(scenariofilename)

        '    'Put modifications here:
        '    useAutoGWprofile.Checked = True


        '    'Version numbering
        '    newfilename = Replace(scenariofilename, "V4.scn2", "v5.scn2")

        '    msg = CreateScenarioString()

        '    Try
        '        My.Computer.FileSystem.WriteAllText(newfilename, msg, False, System.Text.Encoding.ASCII)
        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        'Next
    End Sub

    Private Sub WriteSchemeTableToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WriteSchemeTableToFileToolStripMenuItem.Click

        Dim result As System.Windows.Forms.DialogResult

        SaveFileDialogMain.Filter = "PWC 3 Scheme File (*.sch)|*.SCH|CSV File (*.csv)|*.CSV|ALL Files (*.*)|*.*"
        SaveFileDialogMain.FilterIndex = 1

        SaveFileDialogMain.InitialDirectory = FileNames.WorkingDirectory
        SaveFileDialogMain.FileName = ""
        result = SaveFileDialogMain.ShowDialog(Me)

        'Cancel button will cuase return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If

        FileNames.SchemeFileName = SaveFileDialogMain.FileName


        'FileNames.WorkingDirectory = System.IO.Path.GetDirectoryName(SaveFileDialogMain.FileName) & "\"
        'WorkingDirectoryLabel.Text = FileNames.WorkingDirectory
        'SaveFileDialogMain.InitialDirectory = WorkingDirectoryLabel.Text

        'IOFamilyName.Text = System.IO.Path.GetFileNameWithoutExtension(SaveFileDialogMain.FileName)

        SaveSchemeTableAsTextFile(SaveFileDialogMain.FileName)

    End Sub

    Private Sub LoadSchemeTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoadSchemeTableToolStripMenuItem.Click


        Dim result As System.Windows.Forms.DialogResult

        RetrieveMainInput.Filter = "PWC 3 Scheme Files (*.SCH)|*.SCH|CSV Files (*.CSV)|*.CSV|ALL Files (*.*)|*.*"

        'Opens the desktop if there is no previous open
        If System.IO.Directory.Exists(FileNames.WorkingDirectory) Then
            RetrieveMainInput.InitialDirectory = FileNames.WorkingDirectory
        Else
            '  RetrieveMainInput.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        End If

        RetrieveMainInput.FileName = ""

        result = RetrieveMainInput.ShowDialog(Me)

        'Cancel button will cause return without further execution
        If result = Windows.Forms.DialogResult.Cancel Then
            Return
        End If



        ReadSchemeFile(RetrieveMainInput.FileName)

        'disable all edit buttons in scheme table on first retrieve
        Dim buttonCell As DataGridViewDisableButtonCell
        For i As Integer = 0 To SchemeTableDisplay.RowCount - 1
            buttonCell = CType(SchemeTableDisplay.Rows(i).Cells("Commit"), DataGridViewDisableButtonCell)
            buttonCell.Enabled = False
        Next

        'Disable the last new row button
        buttonCell = CType(SchemeTableDisplay.Rows(SchemeTableDisplay.Rows.Count - 1).Cells("Delete"), DataGridViewDisableButtonCell)
        buttonCell.Enabled = False


    End Sub

    Private Sub BackgroundWorker1_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork


        'The file name should be stored somewhere already but for now here it is
        Dim PRZMVVWMinputFile As String = FileNames.WorkingDirectory & "PRZMVVWM.txt"
        SaveInputsAsTextFile(PRZMVVWMinputFile)


        Dim p As Process = New Process
        p.StartInfo.FileName = My.Application.Info.DirectoryPath() & "\PRZM-VVWM.exe"
        p.StartInfo.Arguments = """" & PRZMVVWMinputFile & """"



        p.StartInfo.UseShellExecute = False
        p.StartInfo.RedirectStandardOutput = True
        p.StartInfo.RedirectStandardError = True
        p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden
        p.StartInfo.CreateNoWindow = True
        p.Start()

        Dim output As String = p.StandardOutput.ReadToEnd
        Dim output2 As String = p.StandardError.ReadToEnd

        '  p.WaitForExit()
        My.Computer.FileSystem.WriteAllText("run_status.txt", output & output2, False, System.Text.Encoding.ASCII)



    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        CalculateButton.Text = "Calculate"
        CalculateButton.Enabled = True
    End Sub

    Private Sub ContactToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ContactToolStripMenuItem.Click
        MsgBox("Technical Support:" & vbCr & "Dirk Young" & vbCr & "USEPA" & vbCr & "young.dirk@epa.gov")
    End Sub

    Private Sub poundToKiloConversion_CheckedChanged(sender As Object, e As EventArgs) Handles poundToKiloConversion.CheckedChanged
        If poundToKiloConversion.Checked Then
            AppTableDisplay.Columns(1).Name = "Amount (lb/acre)"
        Else
            AppTableDisplay.Columns(1).Name = "Amount (kg/ha)"
        End If


    End Sub

    Private Sub Evergreen_CheckedChanged(sender As Object, e As EventArgs) Handles Evergreen.CheckedChanged
        If Evergreen.Checked = True Then
            EvergreenPanel.Visible = True
        Else
            EvergreenPanel.Visible = False
        End If
    End Sub


End Class



Public Class DataGridViewDisableButtonColumn
    Inherits DataGridViewButtonColumn

    Public Sub New()
        Me.CellTemplate = New DataGridViewDisableButtonCell()
    End Sub
End Class

Public Class DataGridViewDisableButtonCell
    Inherits DataGridViewButtonCell

    Private enabledValue As Boolean
    Public Property Enabled() As Boolean
        Get
            Return enabledValue
        End Get
        Set(ByVal value As Boolean)
            enabledValue = value
        End Set
    End Property

    ' Override the Clone method so that the Enabled property is copied.
    Public Overrides Function Clone() As Object
        Dim Cell As DataGridViewDisableButtonCell =
            CType(MyBase.Clone(), DataGridViewDisableButtonCell)
        Cell.Enabled = Me.Enabled
        Return Cell
    End Function

    ' By default, enable the button cell.
    Public Sub New()
        Me.enabledValue = True
    End Sub

    Protected Overrides Sub Paint(ByVal graphics As Graphics,
        ByVal clipBounds As Rectangle, ByVal cellBounds As Rectangle,
        ByVal rowIndex As Integer,
        ByVal elementState As DataGridViewElementStates,
        ByVal value As Object, ByVal formattedValue As Object,
        ByVal errorText As String,
        ByVal cellStyle As DataGridViewCellStyle,
        ByVal advancedBorderStyle As DataGridViewAdvancedBorderStyle,
        ByVal paintParts As DataGridViewPaintParts)

        ' The button cell is disabled, so paint the border,  
        ' background, and disabled button for the cell.
        If Not Me.enabledValue Then

            ' Draw the background of the cell, if specified.
            If (paintParts And DataGridViewPaintParts.Background) =
                DataGridViewPaintParts.Background Then

                Dim cellBackground As New SolidBrush(cellStyle.BackColor)
                graphics.FillRectangle(cellBackground, cellBounds)
                cellBackground.Dispose()
            End If

            ' Draw the cell borders, if specified.
            If (paintParts And DataGridViewPaintParts.Border) =
                DataGridViewPaintParts.Border Then

                PaintBorder(graphics, clipBounds, cellBounds, cellStyle,
                    advancedBorderStyle)
            End If

            ' Calculate the area in which to draw the button.
            Dim buttonArea As Rectangle = cellBounds
            Dim buttonAdjustment As Rectangle =
                Me.BorderWidths(advancedBorderStyle)
            buttonArea.X += buttonAdjustment.X
            buttonArea.Y += buttonAdjustment.Y
            buttonArea.Height -= buttonAdjustment.Height
            buttonArea.Width -= buttonAdjustment.Width

            ' Draw the disabled button.                
            ButtonRenderer.DrawButton(graphics, buttonArea, PushButtonState.Disabled)

            ' Draw the disabled button text. 
            If TypeOf Me.FormattedValue Is String Then
                TextRenderer.DrawText(graphics, CStr(Me.FormattedValue),
                    Me.DataGridView.Font, buttonArea, SystemColors.GrayText)
            End If

        Else
            ' The button cell is enabled, so let the base class 
            ' handle the painting.
            MyBase.Paint(graphics, clipBounds, cellBounds, rowIndex,
                elementState, value, formattedValue, errorText,
                cellStyle, advancedBorderStyle, paintParts)
        End If
    End Sub

End Class