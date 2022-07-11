<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RetrieveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MorenTabsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleAdvancedToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleMoreOutputToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggleScenarioExaminerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToggeWaterbodyExaminerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFileDialogMain = New System.Windows.Forms.SaveFileDialog()
        Me.WorkingDirectoryLabel = New System.Windows.Forms.Label()
        Me.IOFamilyName = New System.Windows.Forms.Label()
        Me.RetrieveMainInput = New System.Windows.Forms.OpenFileDialog()
        Me.CalculateButton = New System.Windows.Forms.Button()
        Me.WeatherFolderBrowser = New System.Windows.Forms.FolderBrowserDialog()
        Me.GetWeatherFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.OpenAndSelectScenarios = New System.Windows.Forms.OpenFileDialog()
        Me.DataGridViewDisableButtonColumn1 = New PWC_2020.DataGridViewDisableButtonColumn()
        Me.DataGridViewButtonColumn1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.AdvancedTab = New System.Windows.Forms.TabPage()
        Me.ConstantProfile = New System.Windows.Forms.RadioButton()
        Me.Label109 = New System.Windows.Forms.Label()
        Me.Label110 = New System.Windows.Forms.Label()
        Me.ExpParameter2 = New System.Windows.Forms.TextBox()
        Me.ExpParameter1 = New System.Windows.Forms.TextBox()
        Me.ExponentialProfile = New System.Windows.Forms.RadioButton()
        Me.Label108 = New System.Windows.Forms.Label()
        Me.Label107 = New System.Windows.Forms.Label()
        Me.Label106 = New System.Windows.Forms.Label()
        Me.RampEndValue = New System.Windows.Forms.TextBox()
        Me.ProfileDepth2 = New System.Windows.Forms.TextBox()
        Me.profileDepth1 = New System.Windows.Forms.TextBox()
        Me.RampProfile = New System.Windows.Forms.RadioButton()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label103 = New System.Windows.Forms.Label()
        Me.ErosionFlag = New System.Windows.Forms.TextBox()
        Me.Q10 = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.AdjustCN = New System.Windows.Forms.CheckBox()
        Me.outputEquilibriumMass = New System.Windows.Forms.CheckBox()
        Me.outputNonEquilibriumMass = New System.Windows.Forms.CheckBox()
        Me.Label90 = New System.Windows.Forms.Label()
        Me.UseNonequilibrium = New System.Windows.Forms.CheckBox()
        Me.Label85 = New System.Windows.Forms.Label()
        Me.ReturnFrequency = New System.Windows.Forms.TextBox()
        Me.MassTransferRegion2GrandDaughter = New System.Windows.Forms.TextBox()
        Me.MassTransferRegion2Daughter = New System.Windows.Forms.TextBox()
        Me.MassTransferRegion2 = New System.Windows.Forms.TextBox()
        Me.FreundlichMinimumConc = New System.Windows.Forms.TextBox()
        Me.Nexp3Reg1 = New System.Windows.Forms.TextBox()
        Me.Nexp2Reg1 = New System.Windows.Forms.TextBox()
        Me.Nexp1Reg1 = New System.Windows.Forms.TextBox()
        Me.Nexp3Reg2 = New System.Windows.Forms.TextBox()
        Me.Nexp2Reg2 = New System.Windows.Forms.TextBox()
        Me.Nexp1Reg2 = New System.Windows.Forms.TextBox()
        Me.Kf3Reg2 = New System.Windows.Forms.TextBox()
        Me.Kf2Reg2 = New System.Windows.Forms.TextBox()
        Me.Kf1Reg2 = New System.Windows.Forms.TextBox()
        Me.SubTimeSteps = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.DoAdditionalFrequencies = New System.Windows.Forms.CheckBox()
        Me.MakeHedFiles = New System.Windows.Forms.CheckBox()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.UseFreundlich = New System.Windows.Forms.CheckBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.VolatilizationBounday = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.WaterBodyType = New System.Windows.Forms.TextBox()
        Me.Label93 = New System.Windows.Forms.Label()
        Me.ScenarioExaminerTab = New System.Windows.Forms.TabPage()
        Me.Label133 = New System.Windows.Forms.Label()
        Me.Label91 = New System.Windows.Forms.Label()
        Me.PushToSaveScenario = New System.Windows.Forms.Button()
        Me.PushToLoadScenario = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label171 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label170 = New System.Windows.Forms.Label()
        Me.Label169 = New System.Windows.Forms.Label()
        Me.Label168 = New System.Windows.Forms.Label()
        Me.Label167 = New System.Windows.Forms.Label()
        Me.Label166 = New System.Windows.Forms.Label()
        Me.Label165 = New System.Windows.Forms.Label()
        Me.Label164 = New System.Windows.Forms.Label()
        Me.Label163 = New System.Windows.Forms.Label()
        Me.Label162 = New System.Windows.Forms.Label()
        Me.Label161 = New System.Windows.Forms.Label()
        Me.Label160 = New System.Windows.Forms.Label()
        Me.Label159 = New System.Windows.Forms.Label()
        Me.Label158 = New System.Windows.Forms.Label()
        Me.Label157 = New System.Windows.Forms.Label()
        Me.Label156 = New System.Windows.Forms.Label()
        Me.Label155 = New System.Windows.Forms.Label()
        Me.Label154 = New System.Windows.Forms.Label()
        Me.Label151 = New System.Windows.Forms.Label()
        Me.Label150 = New System.Windows.Forms.Label()
        Me.Label149 = New System.Windows.Forms.Label()
        Me.Label146 = New System.Windows.Forms.Label()
        Me.Label145 = New System.Windows.Forms.Label()
        Me.Label144 = New System.Windows.Forms.Label()
        Me.Label140 = New System.Windows.Forms.Label()
        Me.Label138 = New System.Windows.Forms.Label()
        Me.Label137 = New System.Windows.Forms.Label()
        Me.Label141 = New System.Windows.Forms.Label()
        Me.Label153 = New System.Windows.Forms.Label()
        Me.Label152 = New System.Windows.Forms.Label()
        Me.Label148 = New System.Windows.Forms.Label()
        Me.Label147 = New System.Windows.Forms.Label()
        Me.Label143 = New System.Windows.Forms.Label()
        Me.Label142 = New System.Windows.Forms.Label()
        Me.Label136 = New System.Windows.Forms.Label()
        Me.Label139 = New System.Windows.Forms.Label()
        Me.Label135 = New System.Windows.Forms.Label()
        Me.useAutoGWprofile = New System.Windows.Forms.CheckBox()
        Me.Label132 = New System.Windows.Forms.Label()
        Me.Label131 = New System.Windows.Forms.Label()
        Me.DiscretizationGridView = New System.Windows.Forms.DataGridView()
        Me.Thickness = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Increments = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label99 = New System.Windows.Forms.Label()
        Me.Label98 = New System.Windows.Forms.Label()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.Label96 = New System.Windows.Forms.Label()
        Me.Label84 = New System.Windows.Forms.Label()
        Me.GetWeatherFile = New System.Windows.Forms.Button()
        Me.albedo = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.evapDepth = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.PETadjustment = New System.Windows.Forms.TextBox()
        Me.Evergreen = New System.Windows.Forms.CheckBox()
        Me.snowMelt = New System.Windows.Forms.TextBox()
        Me.WeatherFileName = New System.Windows.Forms.TextBox()
        Me.EvergreenPanel = New System.Windows.Forms.Panel()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.EvergreenHoldup = New System.Windows.Forms.TextBox()
        Me.EvergreenHt = New System.Windows.Forms.TextBox()
        Me.EvergreenCover = New System.Windows.Forms.TextBox()
        Me.EvergreenRoot = New System.Windows.Forms.TextBox()
        Me.bcTemp = New System.Windows.Forms.TextBox()
        Me.Label83 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.IrrigateOnlyCrops = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.IrrigDepthRootZone = New System.Windows.Forms.RadioButton()
        Me.UserSpecifiesIrrigDepth = New System.Windows.Forms.RadioButton()
        Me.Label304 = New System.Windows.Forms.Label()
        Me.IrrigationDepthUserSpec = New System.Windows.Forms.TextBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.rateIrrig = New System.Windows.Forms.TextBox()
        Me.depletion = New System.Windows.Forms.TextBox()
        Me.fleach = New System.Windows.Forms.TextBox()
        Me.underCanopy = New System.Windows.Forms.RadioButton()
        Me.overCanopy = New System.Windows.Forms.RadioButton()
        Me.noIrrigation = New System.Windows.Forms.RadioButton()
        Me.eInteracting = New System.Windows.Forms.TextBox()
        Me.rDecline = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.rInteracting = New System.Windows.Forms.TextBox()
        Me.eDepth = New System.Windows.Forms.TextBox()
        Me.eDecline = New System.Windows.Forms.TextBox()
        Me.rDepth = New System.Windows.Forms.TextBox()
        Me.latitude = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ScenarioID = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.HorizonGridView = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column13 = New PWC_2020.DataGridViewDisableButtonColumn()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.SimTemperature = New System.Windows.Forms.CheckBox()
        Me.CropGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewComboBoxColumn1 = New System.Windows.Forms.DataGridViewComboBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RunoffErosionYearSpecific = New System.Windows.Forms.RadioButton()
        Me.YearlyCycleButton = New System.Windows.Forms.RadioButton()
        Me.HydroDataGrid = New System.Windows.Forms.DataGridView()
        Me.Column20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column23 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.usleLS = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.usleK = New System.Windows.Forms.TextBox()
        Me.usleP = New System.Windows.Forms.TextBox()
        Me.ireg = New System.Windows.Forms.TextBox()
        Me.slope = New System.Windows.Forms.TextBox()
        Me.Label92 = New System.Windows.Forms.Label()
        Me.PushToSaveWaterBody = New System.Windows.Forms.Button()
        Me.PushToLoadWaterBody = New System.Windows.Forms.Button()
        Me.Label100 = New System.Windows.Forms.Label()
        Me.FractionCroppedArea = New System.Windows.Forms.TextBox()
        Me.BaseFlow = New System.Windows.Forms.TextBox()
        Me.FlowAveraging = New System.Windows.Forms.TextBox()
        Me.MaxDepth = New System.Windows.Forms.TextBox()
        Me.FlowLength = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.InitialDepth = New System.Windows.Forms.TextBox()
        Me.WaterBodyArea = New System.Windows.Forms.TextBox()
        Me.FieldSize = New System.Windows.Forms.TextBox()
        Me.Label82 = New System.Windows.Forms.Label()
        Me.Label80 = New System.Windows.Forms.Label()
        Me.Label81 = New System.Windows.Forms.Label()
        Me.Label72 = New System.Windows.Forms.Label()
        Me.Label75 = New System.Windows.Forms.Label()
        Me.Label69 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.WaterColumnBiomass = New System.Windows.Forms.TextBox()
        Me.WaterColumnDoc = New System.Windows.Forms.TextBox()
        Me.WaterColumnFoc = New System.Windows.Forms.TextBox()
        Me.Chlorophyll = New System.Windows.Forms.TextBox()
        Me.SuspendedSolids = New System.Windows.Forms.TextBox()
        Me.Dfac = New System.Windows.Forms.TextBox()
        Me.Label73 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.Label77 = New System.Windows.Forms.Label()
        Me.Label78 = New System.Windows.Forms.Label()
        Me.Label79 = New System.Windows.Forms.Label()
        Me.Label68 = New System.Windows.Forms.Label()
        Me.BenthicBiomass = New System.Windows.Forms.TextBox()
        Me.BenthicDOC = New System.Windows.Forms.TextBox()
        Me.BenthicFoc = New System.Windows.Forms.TextBox()
        Me.BenthicBulkDensity = New System.Windows.Forms.TextBox()
        Me.BenthicPorosity = New System.Windows.Forms.TextBox()
        Me.BenthicDepth = New System.Windows.Forms.TextBox()
        Me.DoverDx = New System.Windows.Forms.TextBox()
        Me.Label76 = New System.Windows.Forms.Label()
        Me.Label70 = New System.Windows.Forms.Label()
        Me.Label71 = New System.Windows.Forms.Label()
        Me.Label67 = New System.Windows.Forms.Label()
        Me.Label66 = New System.Windows.Forms.Label()
        Me.Label65 = New System.Windows.Forms.Label()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.spray14 = New System.Windows.Forms.TextBox()
        Me.spray13 = New System.Windows.Forms.TextBox()
        Me.Label126 = New System.Windows.Forms.Label()
        Me.Label127 = New System.Windows.Forms.Label()
        Me.spray12 = New System.Windows.Forms.TextBox()
        Me.spray11 = New System.Windows.Forms.TextBox()
        Me.spray10 = New System.Windows.Forms.TextBox()
        Me.spray9 = New System.Windows.Forms.TextBox()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label125 = New System.Windows.Forms.Label()
        Me.Label118 = New System.Windows.Forms.Label()
        Me.Label119 = New System.Windows.Forms.Label()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.spray8 = New System.Windows.Forms.TextBox()
        Me.spray7 = New System.Windows.Forms.TextBox()
        Me.spray6 = New System.Windows.Forms.TextBox()
        Me.spray5 = New System.Windows.Forms.TextBox()
        Me.Label117 = New System.Windows.Forms.Label()
        Me.Label116 = New System.Windows.Forms.Label()
        Me.Label115 = New System.Windows.Forms.Label()
        Me.Label114 = New System.Windows.Forms.Label()
        Me.spray4 = New System.Windows.Forms.TextBox()
        Me.spray3 = New System.Windows.Forms.TextBox()
        Me.spray2 = New System.Windows.Forms.TextBox()
        Me.spray1 = New System.Windows.Forms.TextBox()
        Me.Label111 = New System.Windows.Forms.Label()
        Me.WeatherDirectoryBox = New System.Windows.Forms.TextBox()
        Me.GetWeatherFileDirectory = New System.Windows.Forms.Button()
        Me.SchemeScenarios = New System.Windows.Forms.TabPage()
        Me.ClearAllScenarios = New System.Windows.Forms.Button()
        Me.ClearSelectedScenarios = New System.Windows.Forms.Button()
        Me.SelectScenarios = New System.Windows.Forms.Button()
        Me.ScenarioListBox = New System.Windows.Forms.ListBox()
        Me.Label87 = New System.Windows.Forms.Label()
        Me.Label89 = New System.Windows.Forms.Label()
        Me.waterbodypanel = New System.Windows.Forms.Panel()
        Me.ClearAllWaterBodies = New System.Windows.Forms.Button()
        Me.ClearSelectedWaterBody = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.WaterbodyList = New System.Windows.Forms.ListBox()
        Me.ItsOther = New System.Windows.Forms.CheckBox()
        Me.ItsaReservoir = New System.Windows.Forms.CheckBox()
        Me.ItsaPond = New System.Windows.Forms.CheckBox()
        Me.Label95 = New System.Windows.Forms.Label()
        Me.SchemeApplications = New System.Windows.Forms.TabPage()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.UseApplicationWindow = New System.Windows.Forms.CheckBox()
        Me.Label113 = New System.Windows.Forms.Label()
        Me.Label112 = New System.Windows.Forms.Label()
        Me.ApplicationWindowStep = New System.Windows.Forms.TextBox()
        Me.ApplicationWindowDays = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label344 = New System.Windows.Forms.Label()
        Me.Label342 = New System.Windows.Forms.Label()
        Me.Label343 = New System.Windows.Forms.Label()
        Me.Label341 = New System.Windows.Forms.Label()
        Me.MinDaysBetweenApps = New System.Windows.Forms.TextBox()
        Me.OptimumApplicationWindow = New System.Windows.Forms.TextBox()
        Me.IntolerableRainWindow = New System.Windows.Forms.TextBox()
        Me.RainLimit = New System.Windows.Forms.TextBox()
        Me.UseRainFast = New System.Windows.Forms.CheckBox()
        Me.Label88 = New System.Windows.Forms.Label()
        Me.Label86 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.removal = New System.Windows.Forms.RadioButton()
        Me.maturity = New System.Windows.Forms.RadioButton()
        Me.emerge = New System.Windows.Forms.RadioButton()
        Me.AbsoluteDaysButton = New System.Windows.Forms.RadioButton()
        Me.AppTableDisplay = New System.Windows.Forms.DataGridView()
        Me.Schemes = New System.Windows.Forms.TabPage()
        Me.Label101 = New System.Windows.Forms.Label()
        Me.SchemeTableDisplay = New System.Windows.Forms.DataGridView()
        Me.Column21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Edit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Commit = New PWC_2020.DataGridViewDisableButtonColumn()
        Me.Column24 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Delete = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Chemical = New System.Windows.Forms.TabPage()
        Me.ChemPropertyPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.FoliarDeg3 = New System.Windows.Forms.TextBox()
        Me.FoliarDeg2 = New System.Windows.Forms.TextBox()
        Me.SoilDegradation2 = New System.Windows.Forms.TextBox()
        Me.SoilRef2 = New System.Windows.Forms.TextBox()
        Me.Hydrolysis2 = New System.Windows.Forms.TextBox()
        Me.SoilDegradation3 = New System.Windows.Forms.TextBox()
        Me.Hydrolysis3 = New System.Windows.Forms.TextBox()
        Me.PhotoLat3 = New System.Windows.Forms.TextBox()
        Me.PhotoLat2 = New System.Windows.Forms.TextBox()
        Me.Photo3 = New System.Windows.Forms.TextBox()
        Me.BenthicRef3 = New System.Windows.Forms.TextBox()
        Me.Photo2 = New System.Windows.Forms.TextBox()
        Me.BenthicMetab2 = New System.Windows.Forms.TextBox()
        Me.BenthicMetab3 = New System.Windows.Forms.TextBox()
        Me.BenthicRef2 = New System.Windows.Forms.TextBox()
        Me.WaterColRef3 = New System.Windows.Forms.TextBox()
        Me.WaterColMetab3 = New System.Windows.Forms.TextBox()
        Me.WaterColRef2 = New System.Windows.Forms.TextBox()
        Me.sorption3 = New System.Windows.Forms.TextBox()
        Me.WaterColMetab2 = New System.Windows.Forms.TextBox()
        Me.sorption2 = New System.Windows.Forms.TextBox()
        Me.SoilRef1 = New System.Windows.Forms.TextBox()
        Me.SoilMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.SoilMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.HydroMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.HydroMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.SoilDegradation1 = New System.Windows.Forms.TextBox()
        Me.Hydrolysis1 = New System.Windows.Forms.TextBox()
        Me.PhotoLat1 = New System.Windows.Forms.TextBox()
        Me.Photo1 = New System.Windows.Forms.TextBox()
        Me.BenthicRef1 = New System.Windows.Forms.TextBox()
        Me.BenthicMetab1 = New System.Windows.Forms.TextBox()
        Me.WaterColRef1 = New System.Windows.Forms.TextBox()
        Me.WaterColMetab1 = New System.Windows.Forms.TextBox()
        Me.PhotoMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.PhotoMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.BenthicMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.BenthicMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.WaterMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.sorption1 = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.WaterMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.RadioButton9 = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.isKoc = New System.Windows.Forms.RadioButton()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.FoliarDeg1 = New System.Windows.Forms.TextBox()
        Me.DoDegradate2 = New System.Windows.Forms.CheckBox()
        Me.DoDegradate1 = New System.Windows.Forms.CheckBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.HeatHenry1 = New System.Windows.Forms.TextBox()
        Me.HeatHenry2 = New System.Windows.Forms.TextBox()
        Me.HeatHenry3 = New System.Windows.Forms.TextBox()
        Me.AirDiff3 = New System.Windows.Forms.TextBox()
        Me.AirDiff1 = New System.Windows.Forms.TextBox()
        Me.Henry1 = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Sol1 = New System.Windows.Forms.TextBox()
        Me.Henry2 = New System.Windows.Forms.TextBox()
        Me.Henry3 = New System.Windows.Forms.TextBox()
        Me.Sol3 = New System.Windows.Forms.TextBox()
        Me.VaporPress3 = New System.Windows.Forms.TextBox()
        Me.Sol2 = New System.Windows.Forms.TextBox()
        Me.VaporPress2 = New System.Windows.Forms.TextBox()
        Me.VaporPress1 = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.MWT1 = New System.Windows.Forms.TextBox()
        Me.MWT2 = New System.Windows.Forms.TextBox()
        Me.MWT3 = New System.Windows.Forms.TextBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.FoliarWashoff1 = New System.Windows.Forms.TextBox()
        Me.FoliarWashoff2 = New System.Windows.Forms.TextBox()
        Me.FoliarWashoff3 = New System.Windows.Forms.TextBox()
        Me.FoliarMolarRatio1 = New System.Windows.Forms.TextBox()
        Me.FoliarMolarRatio2 = New System.Windows.Forms.TextBox()
        Me.EstimateHenryConst = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.IsAqueousDegradation = New System.Windows.Forms.RadioButton()
        Me.IsAllMedia = New System.Windows.Forms.RadioButton()
        Me.AirDiff2 = New System.Windows.Forms.TextBox()
        Me.SoilRef3 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.WatershedTab = New System.Windows.Forms.TabPage()
        Me.OptionalOutputTab = New System.Windows.Forms.TabPage()
        Me.Label128 = New System.Windows.Forms.Label()
        Me.outputWaterConc = New System.Windows.Forms.CheckBox()
        Me.OutputInfiltrationDepth = New System.Windows.Forms.TextBox()
        Me.OutputDailyPestLeached = New System.Windows.Forms.CheckBox()
        Me.Label105 = New System.Windows.Forms.Label()
        Me.chemInfiltrationDepth = New System.Windows.Forms.TextBox()
        Me.Label104 = New System.Windows.Forms.Label()
        Me.AdditionalOutputGridView = New System.Windows.Forms.DataGridView()
        Me.Item = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Mode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bound1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Bound2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column12 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.OutputMassDepth1 = New System.Windows.Forms.TextBox()
        Me.OutputDecayDepth2 = New System.Windows.Forms.TextBox()
        Me.OutputDecayDepth1 = New System.Windows.Forms.TextBox()
        Me.OutputMassDepth2 = New System.Windows.Forms.TextBox()
        Me.Label102 = New System.Windows.Forms.Label()
        Me.outputInfiltratedWaterLastLayer = New System.Windows.Forms.CheckBox()
        Me.outputConcLastLayer = New System.Windows.Forms.CheckBox()
        Me.outputPestErosion = New System.Windows.Forms.CheckBox()
        Me.outputErosion = New System.Windows.Forms.CheckBox()
        Me.outputPestRunoff = New System.Windows.Forms.CheckBox()
        Me.outputRunoff = New System.Windows.Forms.CheckBox()
        Me.Label293 = New System.Windows.Forms.Label()
        Me.Label294 = New System.Windows.Forms.Label()
        Me.Label288 = New System.Windows.Forms.Label()
        Me.Label289 = New System.Windows.Forms.Label()
        Me.Label286 = New System.Windows.Forms.Label()
        Me.Label285 = New System.Windows.Forms.Label()
        Me.outputPrecipitation = New System.Windows.Forms.CheckBox()
        Me.outputIrrigation = New System.Windows.Forms.CheckBox()
        Me.Label284 = New System.Windows.Forms.Label()
        Me.outputInfiltrationAtDepth = New System.Windows.Forms.CheckBox()
        Me.outputTotalSoilWater = New System.Windows.Forms.CheckBox()
        Me.outputActualEvap = New System.Windows.Forms.CheckBox()
        Me.outputMassSoilSpecific = New System.Windows.Forms.CheckBox()
        Me.OutputDecayedPest = New System.Windows.Forms.CheckBox()
        Me.outputMassOnFoliage = New System.Windows.Forms.CheckBox()
        Me.outputMassInSoilProfile = New System.Windows.Forms.CheckBox()
        Me.outputDailyFieldVolatilization = New System.Windows.Forms.CheckBox()
        Me.WaterbodyExaminerTab = New System.Windows.Forms.TabPage()
        Me.SprayGridView = New System.Windows.Forms.DataGridView()
        Me.Column14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column25 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column26 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column27 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column28 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column29 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column30 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column31 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.TextBox171 = New System.Windows.Forms.TextBox()
        Me.TextBox170 = New System.Windows.Forms.TextBox()
        Me.TextBox169 = New System.Windows.Forms.TextBox()
        Me.TextBox168 = New System.Windows.Forms.TextBox()
        Me.TextBox167 = New System.Windows.Forms.TextBox()
        Me.TextBox166 = New System.Windows.Forms.TextBox()
        Me.TextBox165 = New System.Windows.Forms.TextBox()
        Me.TextBox164 = New System.Windows.Forms.TextBox()
        Me.TextBox163 = New System.Windows.Forms.TextBox()
        Me.TextBox162 = New System.Windows.Forms.TextBox()
        Me.TextBox161 = New System.Windows.Forms.TextBox()
        Me.TextBox160 = New System.Windows.Forms.TextBox()
        Me.TextBox159 = New System.Windows.Forms.TextBox()
        Me.TextBox158 = New System.Windows.Forms.TextBox()
        Me.TextBox157 = New System.Windows.Forms.TextBox()
        Me.TextBox156 = New System.Windows.Forms.TextBox()
        Me.TextBox155 = New System.Windows.Forms.TextBox()
        Me.TextBox154 = New System.Windows.Forms.TextBox()
        Me.TextBox153 = New System.Windows.Forms.TextBox()
        Me.TextBox152 = New System.Windows.Forms.TextBox()
        Me.TextBox151 = New System.Windows.Forms.TextBox()
        Me.TextBox150 = New System.Windows.Forms.TextBox()
        Me.TextBox149 = New System.Windows.Forms.TextBox()
        Me.TextBox148 = New System.Windows.Forms.TextBox()
        Me.TextBox147 = New System.Windows.Forms.TextBox()
        Me.TextBox146 = New System.Windows.Forms.TextBox()
        Me.TextBox145 = New System.Windows.Forms.TextBox()
        Me.TextBox144 = New System.Windows.Forms.TextBox()
        Me.TextBox143 = New System.Windows.Forms.TextBox()
        Me.TextBox142 = New System.Windows.Forms.TextBox()
        Me.TextBox141 = New System.Windows.Forms.TextBox()
        Me.TextBox140 = New System.Windows.Forms.TextBox()
        Me.TextBox139 = New System.Windows.Forms.TextBox()
        Me.TextBox138 = New System.Windows.Forms.TextBox()
        Me.TextBox137 = New System.Windows.Forms.TextBox()
        Me.TextBox136 = New System.Windows.Forms.TextBox()
        Me.TextBox135 = New System.Windows.Forms.TextBox()
        Me.TextBox134 = New System.Windows.Forms.TextBox()
        Me.TextBox133 = New System.Windows.Forms.TextBox()
        Me.TextBox132 = New System.Windows.Forms.TextBox()
        Me.TextBox131 = New System.Windows.Forms.TextBox()
        Me.TextBox130 = New System.Windows.Forms.TextBox()
        Me.TextBox129 = New System.Windows.Forms.TextBox()
        Me.TextBox128 = New System.Windows.Forms.TextBox()
        Me.TextBox127 = New System.Windows.Forms.TextBox()
        Me.TextBox126 = New System.Windows.Forms.TextBox()
        Me.TextBox125 = New System.Windows.Forms.TextBox()
        Me.TextBox124 = New System.Windows.Forms.TextBox()
        Me.TextBox123 = New System.Windows.Forms.TextBox()
        Me.TextBox120 = New System.Windows.Forms.TextBox()
        Me.TextBox122 = New System.Windows.Forms.TextBox()
        Me.TextBox121 = New System.Windows.Forms.TextBox()
        Me.TextBox119 = New System.Windows.Forms.TextBox()
        Me.TextBox118 = New System.Windows.Forms.TextBox()
        Me.TextBox117 = New System.Windows.Forms.TextBox()
        Me.TextBox116 = New System.Windows.Forms.TextBox()
        Me.TextBox115 = New System.Windows.Forms.TextBox()
        Me.TextBox114 = New System.Windows.Forms.TextBox()
        Me.TextBox113 = New System.Windows.Forms.TextBox()
        Me.TextBox112 = New System.Windows.Forms.TextBox()
        Me.TextBox111 = New System.Windows.Forms.TextBox()
        Me.TextBox110 = New System.Windows.Forms.TextBox()
        Me.TextBox109 = New System.Windows.Forms.TextBox()
        Me.TextBox108 = New System.Windows.Forms.TextBox()
        Me.TextBox107 = New System.Windows.Forms.TextBox()
        Me.TextBox106 = New System.Windows.Forms.TextBox()
        Me.TextBox105 = New System.Windows.Forms.TextBox()
        Me.TextBox104 = New System.Windows.Forms.TextBox()
        Me.TextBox103 = New System.Windows.Forms.TextBox()
        Me.TextBox102 = New System.Windows.Forms.TextBox()
        Me.TextBox101 = New System.Windows.Forms.TextBox()
        Me.TextBox100 = New System.Windows.Forms.TextBox()
        Me.TextBox99 = New System.Windows.Forms.TextBox()
        Me.TextBox98 = New System.Windows.Forms.TextBox()
        Me.TextBox97 = New System.Windows.Forms.TextBox()
        Me.TextBox96 = New System.Windows.Forms.TextBox()
        Me.TextBox95 = New System.Windows.Forms.TextBox()
        Me.TextBox94 = New System.Windows.Forms.TextBox()
        Me.TextBox93 = New System.Windows.Forms.TextBox()
        Me.TextBox92 = New System.Windows.Forms.TextBox()
        Me.TextBox91 = New System.Windows.Forms.TextBox()
        Me.TextBox90 = New System.Windows.Forms.TextBox()
        Me.TextBox89 = New System.Windows.Forms.TextBox()
        Me.TextBox88 = New System.Windows.Forms.TextBox()
        Me.TextBox87 = New System.Windows.Forms.TextBox()
        Me.TextBox86 = New System.Windows.Forms.TextBox()
        Me.TextBox85 = New System.Windows.Forms.TextBox()
        Me.TextBox84 = New System.Windows.Forms.TextBox()
        Me.TextBox83 = New System.Windows.Forms.TextBox()
        Me.TextBox82 = New System.Windows.Forms.TextBox()
        Me.TextBox81 = New System.Windows.Forms.TextBox()
        Me.TextBox80 = New System.Windows.Forms.TextBox()
        Me.TextBox79 = New System.Windows.Forms.TextBox()
        Me.TextBox78 = New System.Windows.Forms.TextBox()
        Me.TextBox77 = New System.Windows.Forms.TextBox()
        Me.TextBox76 = New System.Windows.Forms.TextBox()
        Me.TextBox75 = New System.Windows.Forms.TextBox()
        Me.TextBox74 = New System.Windows.Forms.TextBox()
        Me.TextBox73 = New System.Windows.Forms.TextBox()
        Me.TextBox72 = New System.Windows.Forms.TextBox()
        Me.TextBox71 = New System.Windows.Forms.TextBox()
        Me.TextBox70 = New System.Windows.Forms.TextBox()
        Me.TextBox69 = New System.Windows.Forms.TextBox()
        Me.TextBox68 = New System.Windows.Forms.TextBox()
        Me.TextBox67 = New System.Windows.Forms.TextBox()
        Me.TextBox66 = New System.Windows.Forms.TextBox()
        Me.TextBox65 = New System.Windows.Forms.TextBox()
        Me.TextBox64 = New System.Windows.Forms.TextBox()
        Me.TextBox63 = New System.Windows.Forms.TextBox()
        Me.TextBox62 = New System.Windows.Forms.TextBox()
        Me.TextBox61 = New System.Windows.Forms.TextBox()
        Me.TextBox60 = New System.Windows.Forms.TextBox()
        Me.TextBox59 = New System.Windows.Forms.TextBox()
        Me.TextBox58 = New System.Windows.Forms.TextBox()
        Me.TextBox57 = New System.Windows.Forms.TextBox()
        Me.TextBox52 = New System.Windows.Forms.TextBox()
        Me.TextBox51 = New System.Windows.Forms.TextBox()
        Me.TextBox50 = New System.Windows.Forms.TextBox()
        Me.TextBox49 = New System.Windows.Forms.TextBox()
        Me.TextBox48 = New System.Windows.Forms.TextBox()
        Me.TextBox47 = New System.Windows.Forms.TextBox()
        Me.TextBox46 = New System.Windows.Forms.TextBox()
        Me.TextBox45 = New System.Windows.Forms.TextBox()
        Me.TextBox44 = New System.Windows.Forms.TextBox()
        Me.TextBox43 = New System.Windows.Forms.TextBox()
        Me.TextBox42 = New System.Windows.Forms.TextBox()
        Me.TextBox41 = New System.Windows.Forms.TextBox()
        Me.TextBox40 = New System.Windows.Forms.TextBox()
        Me.TextBox39 = New System.Windows.Forms.TextBox()
        Me.TextBox38 = New System.Windows.Forms.TextBox()
        Me.TextBox37 = New System.Windows.Forms.TextBox()
        Me.TextBox36 = New System.Windows.Forms.TextBox()
        Me.TextBox35 = New System.Windows.Forms.TextBox()
        Me.TextBox34 = New System.Windows.Forms.TextBox()
        Me.TextBox33 = New System.Windows.Forms.TextBox()
        Me.TextBox32 = New System.Windows.Forms.TextBox()
        Me.TextBox31 = New System.Windows.Forms.TextBox()
        Me.TextBox30 = New System.Windows.Forms.TextBox()
        Me.TextBox29 = New System.Windows.Forms.TextBox()
        Me.TextBox28 = New System.Windows.Forms.TextBox()
        Me.TextBox27 = New System.Windows.Forms.TextBox()
        Me.TextBox26 = New System.Windows.Forms.TextBox()
        Me.TextBox25 = New System.Windows.Forms.TextBox()
        Me.TextBox24 = New System.Windows.Forms.TextBox()
        Me.TextBox23 = New System.Windows.Forms.TextBox()
        Me.TextBox22 = New System.Windows.Forms.TextBox()
        Me.TextBox21 = New System.Windows.Forms.TextBox()
        Me.TextBox20 = New System.Windows.Forms.TextBox()
        Me.TextBox19 = New System.Windows.Forms.TextBox()
        Me.TextBox18 = New System.Windows.Forms.TextBox()
        Me.TextBox17 = New System.Windows.Forms.TextBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.spray1_25 = New System.Windows.Forms.TextBox()
        Me.spray1_10 = New System.Windows.Forms.TextBox()
        Me.spray1_5 = New System.Windows.Forms.TextBox()
        Me.Label184 = New System.Windows.Forms.Label()
        Me.Label183 = New System.Windows.Forms.Label()
        Me.Label182 = New System.Windows.Forms.Label()
        Me.Label181 = New System.Windows.Forms.Label()
        Me.Label180 = New System.Windows.Forms.Label()
        Me.Label179 = New System.Windows.Forms.Label()
        Me.Label178 = New System.Windows.Forms.Label()
        Me.Label177 = New System.Windows.Forms.Label()
        Me.Label176 = New System.Windows.Forms.Label()
        Me.Label175 = New System.Windows.Forms.Label()
        Me.Label174 = New System.Windows.Forms.Label()
        Me.Label173 = New System.Windows.Forms.Label()
        Me.Label134 = New System.Windows.Forms.Label()
        Me.Label172 = New System.Windows.Forms.Label()
        Me.TextBox53 = New System.Windows.Forms.TextBox()
        Me.TextBox54 = New System.Windows.Forms.TextBox()
        Me.TextBox56 = New System.Windows.Forms.TextBox()
        Me.TextBox55 = New System.Windows.Forms.TextBox()
        Me.Label94 = New System.Windows.Forms.Label()
        Me.OpenSingleScenarioFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveSingleScenarioFile = New System.Windows.Forms.SaveFileDialog()
        Me.OpenWaterbodyFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveWaterbodyFile = New System.Windows.Forms.SaveFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label129 = New System.Windows.Forms.Label()
        Me.Label130 = New System.Windows.Forms.Label()
        Me.MenuStrip1.SuspendLayout
        Me.AdvancedTab.SuspendLayout
        Me.ScenarioExaminerTab.SuspendLayout
        Me.Panel2.SuspendLayout
        Me.TableLayoutPanel3.SuspendLayout
        CType(Me.DiscretizationGridView, System.ComponentModel.ISupportInitialize).BeginInit
        Me.EvergreenPanel.SuspendLayout
        Me.GroupBox4.SuspendLayout
        Me.Panel3.SuspendLayout
        CType(Me.HorizonGridView, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.CropGridView, System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.HydroDataGrid, System.ComponentModel.ISupportInitialize).BeginInit
        Me.SchemeScenarios.SuspendLayout
        Me.waterbodypanel.SuspendLayout
        Me.SchemeApplications.SuspendLayout
        Me.Panel5.SuspendLayout
        Me.Panel4.SuspendLayout
        CType(Me.AppTableDisplay, System.ComponentModel.ISupportInitialize).BeginInit
        Me.Schemes.SuspendLayout
        CType(Me.SchemeTableDisplay, System.ComponentModel.ISupportInitialize).BeginInit
        Me.Chemical.SuspendLayout
        Me.ChemPropertyPanel.SuspendLayout
        Me.TableLayoutPanel4.SuspendLayout
        Me.TableLayoutPanel1.SuspendLayout
        Me.TableLayoutPanel2.SuspendLayout
        Me.TabControl1.SuspendLayout
        Me.WatershedTab.SuspendLayout
        Me.OptionalOutputTab.SuspendLayout
        CType(Me.AdditionalOutputGridView, System.ComponentModel.ISupportInitialize).BeginInit
        Me.WaterbodyExaminerTab.SuspendLayout
        CType(Me.SprayGridView, System.ComponentModel.ISupportInitialize).BeginInit
        Me.TableLayoutPanel5.SuspendLayout
        Me.SuspendLayout
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.MorenTabsToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.MenuStrip1.Size = New System.Drawing.Size(989, 28)
        Me.MenuStrip1.TabIndex = 1
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.SaveToolStripMenuItem, Me.RetrieveToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(46, 24)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'SaveToolStripMenuItem
        '
        Me.SaveToolStripMenuItem.Name = "SaveToolStripMenuItem"
        Me.SaveToolStripMenuItem.Size = New System.Drawing.Size(146, 26)
        Me.SaveToolStripMenuItem.Text = "Save"
        '
        'RetrieveToolStripMenuItem
        '
        Me.RetrieveToolStripMenuItem.Name = "RetrieveToolStripMenuItem"
        Me.RetrieveToolStripMenuItem.Size = New System.Drawing.Size(146, 26)
        Me.RetrieveToolStripMenuItem.Text = "Retrieve"
        '
        'MorenTabsToolStripMenuItem
        '
        Me.MorenTabsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToggleAdvancedToolStripMenuItem, Me.ToggleMoreOutputToolStripMenuItem, Me.ToggleScenarioExaminerToolStripMenuItem, Me.ToggeWaterbodyExaminerToolStripMenuItem})
        Me.MorenTabsToolStripMenuItem.Name = "MorenTabsToolStripMenuItem"
        Me.MorenTabsToolStripMenuItem.Size = New System.Drawing.Size(91, 24)
        Me.MorenTabsToolStripMenuItem.Text = "More Tabs"
        '
        'ToggleAdvancedToolStripMenuItem
        '
        Me.ToggleAdvancedToolStripMenuItem.Name = "ToggleAdvancedToolStripMenuItem"
        Me.ToggleAdvancedToolStripMenuItem.Size = New System.Drawing.Size(280, 26)
        Me.ToggleAdvancedToolStripMenuItem.Text = "Toggle Advanced"
        '
        'ToggleMoreOutputToolStripMenuItem
        '
        Me.ToggleMoreOutputToolStripMenuItem.Name = "ToggleMoreOutputToolStripMenuItem"
        Me.ToggleMoreOutputToolStripMenuItem.Size = New System.Drawing.Size(280, 26)
        Me.ToggleMoreOutputToolStripMenuItem.Text = "Toggle More Output"
        '
        'ToggleScenarioExaminerToolStripMenuItem
        '
        Me.ToggleScenarioExaminerToolStripMenuItem.Name = "ToggleScenarioExaminerToolStripMenuItem"
        Me.ToggleScenarioExaminerToolStripMenuItem.Size = New System.Drawing.Size(280, 26)
        Me.ToggleScenarioExaminerToolStripMenuItem.Text = "Toggle Scenario Examiner"
        '
        'ToggeWaterbodyExaminerToolStripMenuItem
        '
        Me.ToggeWaterbodyExaminerToolStripMenuItem.Name = "ToggeWaterbodyExaminerToolStripMenuItem"
        Me.ToggeWaterbodyExaminerToolStripMenuItem.Size = New System.Drawing.Size(280, 26)
        Me.ToggeWaterbodyExaminerToolStripMenuItem.Text = "Toggle Waterbody Examiner"
        '
        'WorkingDirectoryLabel
        '
        Me.WorkingDirectoryLabel.AutoSize = True
        Me.WorkingDirectoryLabel.Location = New System.Drawing.Point(166, 654)
        Me.WorkingDirectoryLabel.Name = "WorkingDirectoryLabel"
        Me.WorkingDirectoryLabel.Size = New System.Drawing.Size(137, 17)
        Me.WorkingDirectoryLabel.TabIndex = 2
        Me.WorkingDirectoryLabel.Text = "Working Directory ..."
        '
        'IOFamilyName
        '
        Me.IOFamilyName.AutoSize = True
        Me.IOFamilyName.Location = New System.Drawing.Point(166, 686)
        Me.IOFamilyName.Name = "IOFamilyName"
        Me.IOFamilyName.Size = New System.Drawing.Size(123, 17)
        Me.IOFamilyName.TabIndex = 3
        Me.IOFamilyName.Text = "IO Family Name ..."
        '
        'CalculateButton
        '
        Me.CalculateButton.BackColor = System.Drawing.Color.BlanchedAlmond
        Me.CalculateButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CalculateButton.ForeColor = System.Drawing.Color.DarkMagenta
        Me.CalculateButton.Location = New System.Drawing.Point(763, 654)
        Me.CalculateButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CalculateButton.Name = "CalculateButton"
        Me.CalculateButton.Size = New System.Drawing.Size(156, 49)
        Me.CalculateButton.TabIndex = 4
        Me.CalculateButton.Text = "Calculate"
        Me.CalculateButton.UseVisualStyleBackColor = False
        '
        'GetWeatherFileDialog
        '
        Me.GetWeatherFileDialog.FileName = "OpenFileDialog1"
        '
        'OpenAndSelectScenarios
        '
        Me.OpenAndSelectScenarios.Multiselect = True
        '
        'DataGridViewDisableButtonColumn1
        '
        Me.DataGridViewDisableButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewDisableButtonColumn1.FillWeight = 15.0!
        Me.DataGridViewDisableButtonColumn1.HeaderText = "Commit"
        Me.DataGridViewDisableButtonColumn1.MinimumWidth = 6
        Me.DataGridViewDisableButtonColumn1.Name = "DataGridViewDisableButtonColumn1"
        Me.DataGridViewDisableButtonColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewDisableButtonColumn1.Width = 125
        '
        'DataGridViewButtonColumn1
        '
        Me.DataGridViewButtonColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewButtonColumn1.FillWeight = 10.0!
        Me.DataGridViewButtonColumn1.HeaderText = "Delete"
        Me.DataGridViewButtonColumn1.MinimumWidth = 6
        Me.DataGridViewButtonColumn1.Name = "DataGridViewButtonColumn1"
        Me.DataGridViewButtonColumn1.Text = "X"
        Me.DataGridViewButtonColumn1.UseColumnTextForButtonValue = True
        Me.DataGridViewButtonColumn1.Width = 125
        '
        'AdvancedTab
        '
        Me.AdvancedTab.Controls.Add(Me.ConstantProfile)
        Me.AdvancedTab.Controls.Add(Me.Label109)
        Me.AdvancedTab.Controls.Add(Me.Label110)
        Me.AdvancedTab.Controls.Add(Me.ExpParameter2)
        Me.AdvancedTab.Controls.Add(Me.ExpParameter1)
        Me.AdvancedTab.Controls.Add(Me.ExponentialProfile)
        Me.AdvancedTab.Controls.Add(Me.Label108)
        Me.AdvancedTab.Controls.Add(Me.Label107)
        Me.AdvancedTab.Controls.Add(Me.Label106)
        Me.AdvancedTab.Controls.Add(Me.RampEndValue)
        Me.AdvancedTab.Controls.Add(Me.ProfileDepth2)
        Me.AdvancedTab.Controls.Add(Me.profileDepth1)
        Me.AdvancedTab.Controls.Add(Me.RampProfile)
        Me.AdvancedTab.Controls.Add(Me.Label60)
        Me.AdvancedTab.Controls.Add(Me.Label103)
        Me.AdvancedTab.Controls.Add(Me.ErosionFlag)
        Me.AdvancedTab.Controls.Add(Me.Q10)
        Me.AdvancedTab.Controls.Add(Me.Label45)
        Me.AdvancedTab.Controls.Add(Me.AdjustCN)
        Me.AdvancedTab.Controls.Add(Me.outputEquilibriumMass)
        Me.AdvancedTab.Controls.Add(Me.outputNonEquilibriumMass)
        Me.AdvancedTab.Controls.Add(Me.Label90)
        Me.AdvancedTab.Controls.Add(Me.UseNonequilibrium)
        Me.AdvancedTab.Controls.Add(Me.Label85)
        Me.AdvancedTab.Controls.Add(Me.ReturnFrequency)
        Me.AdvancedTab.Controls.Add(Me.MassTransferRegion2GrandDaughter)
        Me.AdvancedTab.Controls.Add(Me.MassTransferRegion2Daughter)
        Me.AdvancedTab.Controls.Add(Me.MassTransferRegion2)
        Me.AdvancedTab.Controls.Add(Me.FreundlichMinimumConc)
        Me.AdvancedTab.Controls.Add(Me.Nexp3Reg1)
        Me.AdvancedTab.Controls.Add(Me.Nexp2Reg1)
        Me.AdvancedTab.Controls.Add(Me.Nexp1Reg1)
        Me.AdvancedTab.Controls.Add(Me.Nexp3Reg2)
        Me.AdvancedTab.Controls.Add(Me.Nexp2Reg2)
        Me.AdvancedTab.Controls.Add(Me.Nexp1Reg2)
        Me.AdvancedTab.Controls.Add(Me.Kf3Reg2)
        Me.AdvancedTab.Controls.Add(Me.Kf2Reg2)
        Me.AdvancedTab.Controls.Add(Me.Kf1Reg2)
        Me.AdvancedTab.Controls.Add(Me.SubTimeSteps)
        Me.AdvancedTab.Controls.Add(Me.TextBox5)
        Me.AdvancedTab.Controls.Add(Me.TextBox3)
        Me.AdvancedTab.Controls.Add(Me.TextBox2)
        Me.AdvancedTab.Controls.Add(Me.DoAdditionalFrequencies)
        Me.AdvancedTab.Controls.Add(Me.MakeHedFiles)
        Me.AdvancedTab.Controls.Add(Me.Label61)
        Me.AdvancedTab.Controls.Add(Me.Label59)
        Me.AdvancedTab.Controls.Add(Me.Label58)
        Me.AdvancedTab.Controls.Add(Me.Label57)
        Me.AdvancedTab.Controls.Add(Me.Label56)
        Me.AdvancedTab.Controls.Add(Me.Label55)
        Me.AdvancedTab.Controls.Add(Me.Label54)
        Me.AdvancedTab.Controls.Add(Me.Label50)
        Me.AdvancedTab.Controls.Add(Me.Label49)
        Me.AdvancedTab.Controls.Add(Me.Label48)
        Me.AdvancedTab.Controls.Add(Me.Label47)
        Me.AdvancedTab.Controls.Add(Me.Label34)
        Me.AdvancedTab.Controls.Add(Me.UseFreundlich)
        Me.AdvancedTab.Controls.Add(Me.Label22)
        Me.AdvancedTab.Controls.Add(Me.Label15)
        Me.AdvancedTab.Controls.Add(Me.Button3)
        Me.AdvancedTab.Location = New System.Drawing.Point(4, 25)
        Me.AdvancedTab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AdvancedTab.Name = "AdvancedTab"
        Me.AdvancedTab.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AdvancedTab.Size = New System.Drawing.Size(929, 589)
        Me.AdvancedTab.TabIndex = 4
        Me.AdvancedTab.Text = "Advanced"
        Me.AdvancedTab.UseVisualStyleBackColor = True
        '
        'ConstantProfile
        '
        Me.ConstantProfile.AutoSize = True
        Me.ConstantProfile.Checked = True
        Me.ConstantProfile.Location = New System.Drawing.Point(542, 363)
        Me.ConstantProfile.Name = "ConstantProfile"
        Me.ConstantProfile.Size = New System.Drawing.Size(85, 21)
        Me.ConstantProfile.TabIndex = 208
        Me.ConstantProfile.TabStop = True
        Me.ConstantProfile.Text = "Constant"
        Me.ConstantProfile.UseVisualStyleBackColor = True
        '
        'Label109
        '
        Me.Label109.AutoSize = True
        Me.Label109.Location = New System.Drawing.Point(618, 529)
        Me.Label109.Name = "Label109"
        Me.Label109.Size = New System.Drawing.Size(248, 17)
        Me.Label109.TabIndex = 207
        Me.Label109.Text = "Asymptote Value (Fraction of Surface)"
        '
        'Label110
        '
        Me.Label110.AutoSize = True
        Me.Label110.Location = New System.Drawing.Point(618, 507)
        Me.Label110.Name = "Label110"
        Me.Label110.Size = New System.Drawing.Size(67, 17)
        Me.Label110.TabIndex = 206
        Me.Label110.Text = "Exponent"
        '
        'ExpParameter2
        '
        Me.ExpParameter2.Location = New System.Drawing.Point(569, 526)
        Me.ExpParameter2.Name = "ExpParameter2"
        Me.ExpParameter2.Size = New System.Drawing.Size(41, 22)
        Me.ExpParameter2.TabIndex = 205
        '
        'ExpParameter1
        '
        Me.ExpParameter1.Location = New System.Drawing.Point(569, 504)
        Me.ExpParameter1.Name = "ExpParameter1"
        Me.ExpParameter1.Size = New System.Drawing.Size(41, 22)
        Me.ExpParameter1.TabIndex = 204
        '
        'ExponentialProfile
        '
        Me.ExponentialProfile.AutoSize = True
        Me.ExponentialProfile.Location = New System.Drawing.Point(542, 480)
        Me.ExponentialProfile.Name = "ExponentialProfile"
        Me.ExponentialProfile.Size = New System.Drawing.Size(102, 21)
        Me.ExponentialProfile.TabIndex = 203
        Me.ExponentialProfile.Text = "Exponential"
        Me.ExponentialProfile.UseVisualStyleBackColor = True
        '
        'Label108
        '
        Me.Label108.AutoSize = True
        Me.Label108.Location = New System.Drawing.Point(618, 456)
        Me.Label108.Name = "Label108"
        Me.Label108.Size = New System.Drawing.Size(258, 17)
        Me.Label108.TabIndex = 202
        Me.Label108.Text = "2nd Plateau Value (Fraction of Surface)"
        '
        'Label107
        '
        Me.Label107.AutoSize = True
        Me.Label107.Location = New System.Drawing.Point(618, 434)
        Me.Label107.Name = "Label107"
        Me.Label107.Size = New System.Drawing.Size(158, 17)
        Me.Label107.TabIndex = 201
        Me.Label107.Text = "2nd Plateau Depth (cm)"
        '
        'Label106
        '
        Me.Label106.AutoSize = True
        Me.Label106.Location = New System.Drawing.Point(618, 412)
        Me.Label106.Name = "Label106"
        Me.Label106.Size = New System.Drawing.Size(153, 17)
        Me.Label106.TabIndex = 200
        Me.Label106.Text = "1st Plateau Depth (cm)"
        '
        'RampEndValue
        '
        Me.RampEndValue.Location = New System.Drawing.Point(569, 453)
        Me.RampEndValue.Name = "RampEndValue"
        Me.RampEndValue.Size = New System.Drawing.Size(41, 22)
        Me.RampEndValue.TabIndex = 199
        '
        'ProfileDepth2
        '
        Me.ProfileDepth2.Location = New System.Drawing.Point(569, 431)
        Me.ProfileDepth2.Name = "ProfileDepth2"
        Me.ProfileDepth2.Size = New System.Drawing.Size(41, 22)
        Me.ProfileDepth2.TabIndex = 198
        '
        'profileDepth1
        '
        Me.profileDepth1.Location = New System.Drawing.Point(569, 409)
        Me.profileDepth1.Name = "profileDepth1"
        Me.profileDepth1.Size = New System.Drawing.Size(41, 22)
        Me.profileDepth1.TabIndex = 197
        '
        'RampProfile
        '
        Me.RampProfile.AutoSize = True
        Me.RampProfile.Location = New System.Drawing.Point(542, 386)
        Me.RampProfile.Name = "RampProfile"
        Me.RampProfile.Size = New System.Drawing.Size(66, 21)
        Me.RampProfile.TabIndex = 196
        Me.RampProfile.Text = "Ramp"
        Me.RampProfile.UseVisualStyleBackColor = True
        '
        'Label60
        '
        Me.Label60.AutoSize = True
        Me.Label60.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label60.Location = New System.Drawing.Point(524, 329)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(282, 25)
        Me.Label60.TabIndex = 195
        Me.Label60.Text = "Subsurface Degradation Profile"
        '
        'Label103
        '
        Me.Label103.AutoSize = True
        Me.Label103.Location = New System.Drawing.Point(374, 103)
        Me.Label103.Name = "Label103"
        Me.Label103.Size = New System.Drawing.Size(67, 17)
        Me.Label103.TabIndex = 194
        Me.Label103.Text = "Label103"
        '
        'ErosionFlag
        '
        Me.ErosionFlag.Location = New System.Drawing.Point(159, 157)
        Me.ErosionFlag.Name = "ErosionFlag"
        Me.ErosionFlag.Size = New System.Drawing.Size(40, 22)
        Me.ErosionFlag.TabIndex = 191
        Me.ErosionFlag.Text = "3"
        '
        'Q10
        '
        Me.Q10.Location = New System.Drawing.Point(253, 209)
        Me.Q10.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Q10.Name = "Q10"
        Me.Q10.Size = New System.Drawing.Size(100, 22)
        Me.Q10.TabIndex = 131
        Me.Q10.Text = "2"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Location = New System.Drawing.Point(203, 209)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(35, 17)
        Me.Label45.TabIndex = 132
        Me.Label45.Text = "Q10"
        '
        'AdjustCN
        '
        Me.AdjustCN.AutoSize = True
        Me.AdjustCN.Checked = True
        Me.AdjustCN.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AdjustCN.Location = New System.Drawing.Point(9, 79)
        Me.AdjustCN.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AdjustCN.Name = "AdjustCN"
        Me.AdjustCN.Size = New System.Drawing.Size(196, 21)
        Me.AdjustCN.TabIndex = 110
        Me.AdjustCN.Text = "Adjust CN for soil moisture"
        Me.AdjustCN.UseVisualStyleBackColor = True
        '
        'outputEquilibriumMass
        '
        Me.outputEquilibriumMass.AutoSize = True
        Me.outputEquilibriumMass.Location = New System.Drawing.Point(26, 558)
        Me.outputEquilibriumMass.Margin = New System.Windows.Forms.Padding(4)
        Me.outputEquilibriumMass.Name = "outputEquilibriumMass"
        Me.outputEquilibriumMass.Size = New System.Drawing.Size(261, 21)
        Me.outputEquilibriumMass.TabIndex = 53
        Me.outputEquilibriumMass.Text = "Pesticide Mass in Equilibrium Region"
        Me.outputEquilibriumMass.UseVisualStyleBackColor = True
        '
        'outputNonEquilibriumMass
        '
        Me.outputNonEquilibriumMass.AutoSize = True
        Me.outputNonEquilibriumMass.Location = New System.Drawing.Point(26, 538)
        Me.outputNonEquilibriumMass.Margin = New System.Windows.Forms.Padding(4)
        Me.outputNonEquilibriumMass.Name = "outputNonEquilibriumMass"
        Me.outputNonEquilibriumMass.Size = New System.Drawing.Size(281, 21)
        Me.outputNonEquilibriumMass.TabIndex = 54
        Me.outputNonEquilibriumMass.Text = "Pesticide Mass in Nonequilibium Region"
        Me.outputNonEquilibriumMass.UseVisualStyleBackColor = True
        '
        'Label90
        '
        Me.Label90.AutoSize = True
        Me.Label90.Location = New System.Drawing.Point(9, 157)
        Me.Label90.Name = "Label90"
        Me.Label90.Size = New System.Drawing.Size(144, 34)
        Me.Label90.TabIndex = 192
        Me.Label90.Text = "Erosion model (1,2,3)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "MUSL, MUST,MUSS"
        '
        'UseNonequilibrium
        '
        Me.UseNonequilibrium.AutoSize = True
        Me.UseNonequilibrium.Location = New System.Drawing.Point(9, 117)
        Me.UseNonequilibrium.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UseNonequilibrium.Name = "UseNonequilibrium"
        Me.UseNonequilibrium.Size = New System.Drawing.Size(151, 21)
        Me.UseNonequilibrium.TabIndex = 112
        Me.UseNonequilibrium.Text = "Use nonequilibrium"
        Me.UseNonequilibrium.UseVisualStyleBackColor = True
        '
        'Label85
        '
        Me.Label85.AutoSize = True
        Me.Label85.Location = New System.Drawing.Point(548, 258)
        Me.Label85.Name = "Label85"
        Me.Label85.Size = New System.Drawing.Size(187, 17)
        Me.Label85.TabIndex = 61
        Me.Label85.Text = "If so, what frequency (years)"
        '
        'ReturnFrequency
        '
        Me.ReturnFrequency.Location = New System.Drawing.Point(739, 255)
        Me.ReturnFrequency.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ReturnFrequency.Name = "ReturnFrequency"
        Me.ReturnFrequency.Size = New System.Drawing.Size(79, 22)
        Me.ReturnFrequency.TabIndex = 60
        '
        'MassTransferRegion2GrandDaughter
        '
        Me.MassTransferRegion2GrandDaughter.Location = New System.Drawing.Point(261, 505)
        Me.MassTransferRegion2GrandDaughter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MassTransferRegion2GrandDaughter.Name = "MassTransferRegion2GrandDaughter"
        Me.MassTransferRegion2GrandDaughter.Size = New System.Drawing.Size(100, 22)
        Me.MassTransferRegion2GrandDaughter.TabIndex = 55
        '
        'MassTransferRegion2Daughter
        '
        Me.MassTransferRegion2Daughter.Location = New System.Drawing.Point(157, 505)
        Me.MassTransferRegion2Daughter.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MassTransferRegion2Daughter.Name = "MassTransferRegion2Daughter"
        Me.MassTransferRegion2Daughter.Size = New System.Drawing.Size(100, 22)
        Me.MassTransferRegion2Daughter.TabIndex = 54
        '
        'MassTransferRegion2
        '
        Me.MassTransferRegion2.Location = New System.Drawing.Point(54, 505)
        Me.MassTransferRegion2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MassTransferRegion2.Name = "MassTransferRegion2"
        Me.MassTransferRegion2.Size = New System.Drawing.Size(100, 22)
        Me.MassTransferRegion2.TabIndex = 53
        '
        'FreundlichMinimumConc
        '
        Me.FreundlichMinimumConc.Location = New System.Drawing.Point(63, 290)
        Me.FreundlichMinimumConc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FreundlichMinimumConc.Name = "FreundlichMinimumConc"
        Me.FreundlichMinimumConc.Size = New System.Drawing.Size(64, 22)
        Me.FreundlichMinimumConc.TabIndex = 51
        '
        'Nexp3Reg1
        '
        Me.Nexp3Reg1.Location = New System.Drawing.Point(261, 389)
        Me.Nexp3Reg1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp3Reg1.Name = "Nexp3Reg1"
        Me.Nexp3Reg1.Size = New System.Drawing.Size(100, 22)
        Me.Nexp3Reg1.TabIndex = 44
        Me.Nexp3Reg1.Text = "1"
        '
        'Nexp2Reg1
        '
        Me.Nexp2Reg1.Location = New System.Drawing.Point(157, 389)
        Me.Nexp2Reg1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp2Reg1.Name = "Nexp2Reg1"
        Me.Nexp2Reg1.Size = New System.Drawing.Size(100, 22)
        Me.Nexp2Reg1.TabIndex = 43
        Me.Nexp2Reg1.Text = "1"
        '
        'Nexp1Reg1
        '
        Me.Nexp1Reg1.Location = New System.Drawing.Point(54, 389)
        Me.Nexp1Reg1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp1Reg1.Name = "Nexp1Reg1"
        Me.Nexp1Reg1.Size = New System.Drawing.Size(100, 22)
        Me.Nexp1Reg1.TabIndex = 42
        Me.Nexp1Reg1.Text = "1"
        '
        'Nexp3Reg2
        '
        Me.Nexp3Reg2.Location = New System.Drawing.Point(261, 458)
        Me.Nexp3Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp3Reg2.Name = "Nexp3Reg2"
        Me.Nexp3Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Nexp3Reg2.TabIndex = 39
        '
        'Nexp2Reg2
        '
        Me.Nexp2Reg2.Location = New System.Drawing.Point(157, 458)
        Me.Nexp2Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp2Reg2.Name = "Nexp2Reg2"
        Me.Nexp2Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Nexp2Reg2.TabIndex = 38
        '
        'Nexp1Reg2
        '
        Me.Nexp1Reg2.Location = New System.Drawing.Point(54, 458)
        Me.Nexp1Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Nexp1Reg2.Name = "Nexp1Reg2"
        Me.Nexp1Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Nexp1Reg2.TabIndex = 37
        '
        'Kf3Reg2
        '
        Me.Kf3Reg2.Location = New System.Drawing.Point(261, 435)
        Me.Kf3Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Kf3Reg2.Name = "Kf3Reg2"
        Me.Kf3Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Kf3Reg2.TabIndex = 36
        '
        'Kf2Reg2
        '
        Me.Kf2Reg2.Location = New System.Drawing.Point(157, 435)
        Me.Kf2Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Kf2Reg2.Name = "Kf2Reg2"
        Me.Kf2Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Kf2Reg2.TabIndex = 35
        '
        'Kf1Reg2
        '
        Me.Kf1Reg2.Location = New System.Drawing.Point(54, 435)
        Me.Kf1Reg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Kf1Reg2.Name = "Kf1Reg2"
        Me.Kf1Reg2.Size = New System.Drawing.Size(100, 22)
        Me.Kf1Reg2.TabIndex = 0
        '
        'SubTimeSteps
        '
        Me.SubTimeSteps.Location = New System.Drawing.Point(63, 262)
        Me.SubTimeSteps.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SubTimeSteps.Name = "SubTimeSteps"
        Me.SubTimeSteps.Size = New System.Drawing.Size(40, 22)
        Me.SubTimeSteps.TabIndex = 21
        Me.SubTimeSteps.Text = "1"
        '
        'TextBox5
        '
        Me.TextBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.Location = New System.Drawing.Point(621, 89)
        Me.TextBox5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(197, 38)
        Me.TextBox5.TabIndex = 3
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(641, 16)
        Me.TextBox3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(57, 22)
        Me.TextBox3.TabIndex = 2
        Me.TextBox3.Text = "l"
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(621, 46)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(197, 38)
        Me.TextBox2.TabIndex = 1
        '
        'DoAdditionalFrequencies
        '
        Me.DoAdditionalFrequencies.AutoSize = True
        Me.DoAdditionalFrequencies.Location = New System.Drawing.Point(548, 234)
        Me.DoAdditionalFrequencies.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DoAdditionalFrequencies.Name = "DoAdditionalFrequencies"
        Me.DoAdditionalFrequencies.Size = New System.Drawing.Size(241, 21)
        Me.DoAdditionalFrequencies.TabIndex = 59
        Me.DoAdditionalFrequencies.Text = "Do additional return frequencies?"
        Me.DoAdditionalFrequencies.UseVisualStyleBackColor = True
        '
        'MakeHedFiles
        '
        Me.MakeHedFiles.AutoSize = True
        Me.MakeHedFiles.Location = New System.Drawing.Point(539, 209)
        Me.MakeHedFiles.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MakeHedFiles.Name = "MakeHedFiles"
        Me.MakeHedFiles.Size = New System.Drawing.Size(126, 21)
        Me.MakeHedFiles.TabIndex = 58
        Me.MakeHedFiles.Text = "Make HED files"
        Me.MakeHedFiles.UseVisualStyleBackColor = True
        '
        'Label61
        '
        Me.Label61.AutoSize = True
        Me.Label61.Location = New System.Drawing.Point(96, 486)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(219, 17)
        Me.Label61.TabIndex = 57
        Me.Label61.Text = "Mass Transfer Coefficient k₂ (1/d)"
        '
        'Label59
        '
        Me.Label59.AutoSize = True
        Me.Label59.Location = New System.Drawing.Point(133, 295)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(280, 17)
        Me.Label59.TabIndex = 52
        Me.Label59.Text = "Lowest Concentration for Freundlich (mg/L)"
        '
        'Label58
        '
        Me.Label58.AutoSize = True
        Me.Label58.Location = New System.Drawing.Point(260, 369)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(105, 17)
        Me.Label58.TabIndex = 50
        Me.Label58.Text = "Granddaughter"
        '
        'Label57
        '
        Me.Label57.AutoSize = True
        Me.Label57.Location = New System.Drawing.Point(174, 370)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(67, 17)
        Me.Label57.TabIndex = 49
        Me.Label57.Text = "Daughter"
        '
        'Label56
        '
        Me.Label56.AutoSize = True
        Me.Label56.Location = New System.Drawing.Point(78, 370)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(50, 17)
        Me.Label56.TabIndex = 48
        Me.Label56.Text = "Parent"
        '
        'Label55
        '
        Me.Label55.AutoSize = True
        Me.Label55.Location = New System.Drawing.Point(174, 417)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(65, 17)
        Me.Label55.TabIndex = 47
        Me.Label55.Text = "Region 2"
        '
        'Label54
        '
        Me.Label54.AutoSize = True
        Me.Label54.Location = New System.Drawing.Point(174, 353)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(65, 17)
        Me.Label54.TabIndex = 46
        Me.Label54.Text = "Region 1"
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.Location = New System.Drawing.Point(28, 394)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(18, 17)
        Me.Label50.TabIndex = 45
        Me.Label50.Text = "N"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.Location = New System.Drawing.Point(28, 463)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(18, 17)
        Me.Label49.TabIndex = 41
        Me.Label49.Text = "N"
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.Location = New System.Drawing.Point(28, 440)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(21, 17)
        Me.Label48.TabIndex = 40
        Me.Label48.Text = "Kf"
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.ForeColor = System.Drawing.Color.Red
        Me.Label47.Location = New System.Drawing.Point(359, -12)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(73, 69)
        Me.Label47.TabIndex = 34
        Me.Label47.Text = "⇨"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(109, 265)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(108, 17)
        Me.Label34.TabIndex = 22
        Me.Label34.Text = "Sub Time Steps"
        '
        'UseFreundlich
        '
        Me.UseFreundlich.AutoSize = True
        Me.UseFreundlich.Location = New System.Drawing.Point(9, 99)
        Me.UseFreundlich.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.UseFreundlich.Name = "UseFreundlich"
        Me.UseFreundlich.Size = New System.Drawing.Size(178, 21)
        Me.UseFreundlich.TabIndex = 18
        Me.UseFreundlich.Text = "Use Feundlich Isotherm"
        Me.UseFreundlich.UseVisualStyleBackColor = True
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(563, 105)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 17)
        Me.Label22.TabIndex = 5
        Me.Label22.Text = "ChrW"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(555, 62)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 17)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Chr"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(705, 16)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 0
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'VolatilizationBounday
        '
        Me.VolatilizationBounday.Location = New System.Drawing.Point(712, 91)
        Me.VolatilizationBounday.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VolatilizationBounday.Name = "VolatilizationBounday"
        Me.VolatilizationBounday.Size = New System.Drawing.Size(73, 22)
        Me.VolatilizationBounday.TabIndex = 139
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Location = New System.Drawing.Point(476, 91)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(224, 17)
        Me.Label44.TabIndex = 140
        Me.Label44.Text = "Volatilization Boundary Layer (cm)"
        '
        'WaterBodyType
        '
        Me.WaterBodyType.Location = New System.Drawing.Point(169, 357)
        Me.WaterBodyType.Name = "WaterBodyType"
        Me.WaterBodyType.Size = New System.Drawing.Size(39, 22)
        Me.WaterBodyType.TabIndex = 197
        Me.WaterBodyType.Text = "1"
        '
        'Label93
        '
        Me.Label93.AutoSize = True
        Me.Label93.Location = New System.Drawing.Point(42, 360)
        Me.Label93.Name = "Label93"
        Me.Label93.Size = New System.Drawing.Size(94, 17)
        Me.Label93.TabIndex = 198
        Me.Label93.Text = "SimType Flag"
        '
        'ScenarioExaminerTab
        '
        Me.ScenarioExaminerTab.AutoScroll = True
        Me.ScenarioExaminerTab.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ScenarioExaminerTab.Controls.Add(Me.Label133)
        Me.ScenarioExaminerTab.Controls.Add(Me.Label91)
        Me.ScenarioExaminerTab.Controls.Add(Me.PushToSaveScenario)
        Me.ScenarioExaminerTab.Controls.Add(Me.PushToLoadScenario)
        Me.ScenarioExaminerTab.Controls.Add(Me.Panel2)
        Me.ScenarioExaminerTab.Location = New System.Drawing.Point(4, 25)
        Me.ScenarioExaminerTab.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScenarioExaminerTab.Name = "ScenarioExaminerTab"
        Me.ScenarioExaminerTab.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScenarioExaminerTab.Size = New System.Drawing.Size(929, 589)
        Me.ScenarioExaminerTab.TabIndex = 2
        Me.ScenarioExaminerTab.Text = "Scenario Examiner"
        '
        'Label133
        '
        Me.Label133.AutoSize = True
        Me.Label133.Font = New System.Drawing.Font("Modern No. 20", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label133.ForeColor = System.Drawing.Color.DarkGoldenrod
        Me.Label133.Location = New System.Drawing.Point(316, 24)
        Me.Label133.Name = "Label133"
        Me.Label133.Size = New System.Drawing.Size(269, 41)
        Me.Label133.TabIndex = 207
        Me.Label133.Text = "Field Scenario"
        '
        'Label91
        '
        Me.Label91.AutoSize = True
        Me.Label91.Font = New System.Drawing.Font("Algerian", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label91.ForeColor = System.Drawing.Color.Moccasin
        Me.Label91.Location = New System.Drawing.Point(1219, 94)
        Me.Label91.Name = "Label91"
        Me.Label91.Size = New System.Drawing.Size(335, 45)
        Me.Label91.TabIndex = 205
        Me.Label91.Text = "Field Scenario"
        '
        'PushToSaveScenario
        '
        Me.PushToSaveScenario.BackColor = System.Drawing.Color.Lime
        Me.PushToSaveScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PushToSaveScenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PushToSaveScenario.Location = New System.Drawing.Point(694, 25)
        Me.PushToSaveScenario.Name = "PushToSaveScenario"
        Me.PushToSaveScenario.Size = New System.Drawing.Size(203, 45)
        Me.PushToSaveScenario.TabIndex = 202
        Me.PushToSaveScenario.Text = "Push Here to Save this Scenario"
        Me.PushToSaveScenario.UseVisualStyleBackColor = False
        '
        'PushToLoadScenario
        '
        Me.PushToLoadScenario.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PushToLoadScenario.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PushToLoadScenario.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PushToLoadScenario.Location = New System.Drawing.Point(23, 24)
        Me.PushToLoadScenario.Name = "PushToLoadScenario"
        Me.PushToLoadScenario.Size = New System.Drawing.Size(201, 46)
        Me.PushToLoadScenario.TabIndex = 201
        Me.PushToLoadScenario.Text = "Push Here to Examine a Scenario"
        Me.PushToLoadScenario.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.AutoScroll = True
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Label171)
        Me.Panel2.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel2.Controls.Add(Me.Label135)
        Me.Panel2.Controls.Add(Me.useAutoGWprofile)
        Me.Panel2.Controls.Add(Me.Label132)
        Me.Panel2.Controls.Add(Me.Label131)
        Me.Panel2.Controls.Add(Me.DiscretizationGridView)
        Me.Panel2.Controls.Add(Me.Label99)
        Me.Panel2.Controls.Add(Me.Label98)
        Me.Panel2.Controls.Add(Me.Label97)
        Me.Panel2.Controls.Add(Me.Label96)
        Me.Panel2.Controls.Add(Me.Label84)
        Me.Panel2.Controls.Add(Me.Label44)
        Me.Panel2.Controls.Add(Me.VolatilizationBounday)
        Me.Panel2.Controls.Add(Me.GetWeatherFile)
        Me.Panel2.Controls.Add(Me.albedo)
        Me.Panel2.Controls.Add(Me.Label37)
        Me.Panel2.Controls.Add(Me.Label36)
        Me.Panel2.Controls.Add(Me.evapDepth)
        Me.Panel2.Controls.Add(Me.Label35)
        Me.Panel2.Controls.Add(Me.PETadjustment)
        Me.Panel2.Controls.Add(Me.Evergreen)
        Me.Panel2.Controls.Add(Me.snowMelt)
        Me.Panel2.Controls.Add(Me.WeatherFileName)
        Me.Panel2.Controls.Add(Me.EvergreenPanel)
        Me.Panel2.Controls.Add(Me.bcTemp)
        Me.Panel2.Controls.Add(Me.Label83)
        Me.Panel2.Controls.Add(Me.GroupBox4)
        Me.Panel2.Controls.Add(Me.eInteracting)
        Me.Panel2.Controls.Add(Me.rDecline)
        Me.Panel2.Controls.Add(Me.Label21)
        Me.Panel2.Controls.Add(Me.rInteracting)
        Me.Panel2.Controls.Add(Me.eDepth)
        Me.Panel2.Controls.Add(Me.eDecline)
        Me.Panel2.Controls.Add(Me.rDepth)
        Me.Panel2.Controls.Add(Me.latitude)
        Me.Panel2.Controls.Add(Me.Label26)
        Me.Panel2.Controls.Add(Me.ScenarioID)
        Me.Panel2.Controls.Add(Me.Label27)
        Me.Panel2.Controls.Add(Me.Label28)
        Me.Panel2.Controls.Add(Me.Label25)
        Me.Panel2.Controls.Add(Me.HorizonGridView)
        Me.Panel2.Controls.Add(Me.Label24)
        Me.Panel2.Controls.Add(Me.Label23)
        Me.Panel2.Controls.Add(Me.Label62)
        Me.Panel2.Controls.Add(Me.SimTemperature)
        Me.Panel2.Controls.Add(Me.CropGridView)
        Me.Panel2.Controls.Add(Me.RunoffErosionYearSpecific)
        Me.Panel2.Controls.Add(Me.YearlyCycleButton)
        Me.Panel2.Controls.Add(Me.HydroDataGrid)
        Me.Panel2.Controls.Add(Me.usleLS)
        Me.Panel2.Controls.Add(Me.Label29)
        Me.Panel2.Controls.Add(Me.Label30)
        Me.Panel2.Controls.Add(Me.Label31)
        Me.Panel2.Controls.Add(Me.Label32)
        Me.Panel2.Controls.Add(Me.Label33)
        Me.Panel2.Controls.Add(Me.usleK)
        Me.Panel2.Controls.Add(Me.usleP)
        Me.Panel2.Controls.Add(Me.ireg)
        Me.Panel2.Controls.Add(Me.slope)
        Me.Panel2.Location = New System.Drawing.Point(23, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(874, 2184)
        Me.Panel2.TabIndex = 200
        '
        'Label171
        '
        Me.Label171.AutoSize = True
        Me.Label171.Location = New System.Drawing.Point(305, 1071)
        Me.Label171.Name = "Label171"
        Me.Label171.Size = New System.Drawing.Size(482, 34)
        Me.Label171.TabIndex = 212
        Me.Label171.Text = "*This value can be adjusted for different aquifer depths, but increment size " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "sh" &
    "ould be kept at 50 cm."
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 5
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.49763!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.50237!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 97.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 145.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Label170, 4, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label169, 3, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label168, 2, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label167, 1, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label166, 0, 6)
        Me.TableLayoutPanel3.Controls.Add(Me.Label165, 4, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label164, 3, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label163, 2, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label162, 1, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label161, 0, 5)
        Me.TableLayoutPanel3.Controls.Add(Me.Label160, 4, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label159, 3, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label158, 2, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label157, 1, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label156, 0, 4)
        Me.TableLayoutPanel3.Controls.Add(Me.Label155, 4, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label154, 3, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label151, 0, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label150, 4, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label149, 3, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label146, 4, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label145, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label144, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label140, 4, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label138, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label137, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label141, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label153, 1, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label152, 2, 3)
        Me.TableLayoutPanel3.Controls.Add(Me.Label148, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label147, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.Label143, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label142, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label136, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label139, 3, 0)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(302, 885)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 7
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(491, 180)
        Me.TableLayoutPanel3.TabIndex = 211
        '
        'Label170
        '
        Me.Label170.AutoSize = True
        Me.Label170.Location = New System.Drawing.Point(348, 150)
        Me.Label170.Name = "Label170"
        Me.Label170.Size = New System.Drawing.Size(32, 17)
        Me.Label170.TabIndex = 237
        Me.Label170.Text = "400"
        '
        'Label169
        '
        Me.Label169.AutoSize = True
        Me.Label169.Location = New System.Drawing.Point(251, 150)
        Me.Label169.Name = "Label169"
        Me.Label169.Size = New System.Drawing.Size(32, 17)
        Me.Label169.TabIndex = 236
        Me.Label169.Text = "300"
        '
        'Label168
        '
        Me.Label168.AutoSize = True
        Me.Label168.Location = New System.Drawing.Point(151, 150)
        Me.Label168.Name = "Label168"
        Me.Label168.Size = New System.Drawing.Size(24, 17)
        Me.Label168.TabIndex = 235
        Me.Label168.Text = "50"
        '
        'Label167
        '
        Me.Label167.AutoSize = True
        Me.Label167.Location = New System.Drawing.Point(70, 150)
        Me.Label167.Name = "Label167"
        Me.Label167.Size = New System.Drawing.Size(16, 17)
        Me.Label167.TabIndex = 234
        Me.Label167.Text = "2"
        '
        'Label166
        '
        Me.Label166.AutoSize = True
        Me.Label166.Location = New System.Drawing.Point(3, 150)
        Me.Label166.Name = "Label166"
        Me.Label166.Size = New System.Drawing.Size(32, 17)
        Me.Label166.TabIndex = 233
        Me.Label166.Text = "100"
        '
        'Label165
        '
        Me.Label165.AutoSize = True
        Me.Label165.Location = New System.Drawing.Point(348, 130)
        Me.Label165.Name = "Label165"
        Me.Label165.Size = New System.Drawing.Size(32, 17)
        Me.Label165.TabIndex = 232
        Me.Label165.Text = "300"
        '
        'Label164
        '
        Me.Label164.AutoSize = True
        Me.Label164.Location = New System.Drawing.Point(251, 130)
        Me.Label164.Name = "Label164"
        Me.Label164.Size = New System.Drawing.Size(32, 17)
        Me.Label164.TabIndex = 231
        Me.Label164.Text = "100"
        '
        'Label163
        '
        Me.Label163.AutoSize = True
        Me.Label163.Location = New System.Drawing.Point(151, 130)
        Me.Label163.Name = "Label163"
        Me.Label163.Size = New System.Drawing.Size(24, 17)
        Me.Label163.TabIndex = 230
        Me.Label163.Text = "50"
        '
        'Label162
        '
        Me.Label162.AutoSize = True
        Me.Label162.Location = New System.Drawing.Point(70, 130)
        Me.Label162.Name = "Label162"
        Me.Label162.Size = New System.Drawing.Size(16, 17)
        Me.Label162.TabIndex = 229
        Me.Label162.Text = "4"
        '
        'Label161
        '
        Me.Label161.AutoSize = True
        Me.Label161.Location = New System.Drawing.Point(3, 130)
        Me.Label161.Name = "Label161"
        Me.Label161.Size = New System.Drawing.Size(37, 17)
        Me.Label161.TabIndex = 228
        Me.Label161.Text = "200*"
        '
        'Label160
        '
        Me.Label160.AutoSize = True
        Me.Label160.Location = New System.Drawing.Point(348, 110)
        Me.Label160.Name = "Label160"
        Me.Label160.Size = New System.Drawing.Size(32, 17)
        Me.Label160.TabIndex = 227
        Me.Label160.Text = "100"
        '
        'Label159
        '
        Me.Label159.AutoSize = True
        Me.Label159.Location = New System.Drawing.Point(251, 110)
        Me.Label159.Name = "Label159"
        Me.Label159.Size = New System.Drawing.Size(24, 17)
        Me.Label159.TabIndex = 226
        Me.Label159.Text = "20"
        '
        'Label158
        '
        Me.Label158.AutoSize = True
        Me.Label158.Location = New System.Drawing.Point(151, 110)
        Me.Label158.Name = "Label158"
        Me.Label158.Size = New System.Drawing.Size(24, 17)
        Me.Label158.TabIndex = 225
        Me.Label158.Text = "20"
        '
        'Label157
        '
        Me.Label157.AutoSize = True
        Me.Label157.Location = New System.Drawing.Point(70, 110)
        Me.Label157.Name = "Label157"
        Me.Label157.Size = New System.Drawing.Size(16, 17)
        Me.Label157.TabIndex = 224
        Me.Label157.Text = "4"
        '
        'Label156
        '
        Me.Label156.AutoSize = True
        Me.Label156.Location = New System.Drawing.Point(3, 110)
        Me.Label156.Name = "Label156"
        Me.Label156.Size = New System.Drawing.Size(24, 17)
        Me.Label156.TabIndex = 223
        Me.Label156.Text = "80"
        '
        'Label155
        '
        Me.Label155.AutoSize = True
        Me.Label155.Location = New System.Drawing.Point(348, 90)
        Me.Label155.Name = "Label155"
        Me.Label155.Size = New System.Drawing.Size(24, 17)
        Me.Label155.TabIndex = 222
        Me.Label155.Text = "20"
        '
        'Label154
        '
        Me.Label154.AutoSize = True
        Me.Label154.Location = New System.Drawing.Point(251, 90)
        Me.Label154.Name = "Label154"
        Me.Label154.Size = New System.Drawing.Size(24, 17)
        Me.Label154.TabIndex = 221
        Me.Label154.Text = "10"
        '
        'Label151
        '
        Me.Label151.AutoSize = True
        Me.Label151.Location = New System.Drawing.Point(3, 90)
        Me.Label151.Name = "Label151"
        Me.Label151.Size = New System.Drawing.Size(24, 17)
        Me.Label151.TabIndex = 218
        Me.Label151.Text = "10"
        '
        'Label150
        '
        Me.Label150.AutoSize = True
        Me.Label150.Location = New System.Drawing.Point(348, 70)
        Me.Label150.Name = "Label150"
        Me.Label150.Size = New System.Drawing.Size(24, 17)
        Me.Label150.TabIndex = 217
        Me.Label150.Text = "10"
        '
        'Label149
        '
        Me.Label149.AutoSize = True
        Me.Label149.Location = New System.Drawing.Point(251, 70)
        Me.Label149.Name = "Label149"
        Me.Label149.Size = New System.Drawing.Size(16, 17)
        Me.Label149.TabIndex = 216
        Me.Label149.Text = "3"
        '
        'Label146
        '
        Me.Label146.AutoSize = True
        Me.Label146.Location = New System.Drawing.Point(348, 50)
        Me.Label146.Name = "Label146"
        Me.Label146.Size = New System.Drawing.Size(16, 17)
        Me.Label146.TabIndex = 213
        Me.Label146.Text = "3"
        '
        'Label145
        '
        Me.Label145.AutoSize = True
        Me.Label145.Location = New System.Drawing.Point(3, 70)
        Me.Label145.Name = "Label145"
        Me.Label145.Size = New System.Drawing.Size(16, 17)
        Me.Label145.TabIndex = 212
        Me.Label145.Text = "7"
        '
        'Label144
        '
        Me.Label144.AutoSize = True
        Me.Label144.Location = New System.Drawing.Point(251, 50)
        Me.Label144.Name = "Label144"
        Me.Label144.Size = New System.Drawing.Size(16, 17)
        Me.Label144.TabIndex = 8
        Me.Label144.Text = "0"
        '
        'Label140
        '
        Me.Label140.AutoSize = True
        Me.Label140.Location = New System.Drawing.Point(348, 0)
        Me.Label140.Name = "Label140"
        Me.Label140.Size = New System.Drawing.Size(44, 34)
        Me.Label140.TabIndex = 4
        Me.Label140.Text = "end " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "depth"
        '
        'Label138
        '
        Me.Label138.AutoSize = True
        Me.Label138.Location = New System.Drawing.Point(151, 0)
        Me.Label138.Name = "Label138"
        Me.Label138.Size = New System.Drawing.Size(74, 34)
        Me.Label138.TabIndex = 2
        Me.Label138.Text = "Increment " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "size (cm)"
        '
        'Label137
        '
        Me.Label137.AutoSize = True
        Me.Label137.Location = New System.Drawing.Point(70, 0)
        Me.Label137.Name = "Label137"
        Me.Label137.Size = New System.Drawing.Size(74, 50)
        Me.Label137.TabIndex = 1
        Me.Label137.Text = "Number of " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Increments"
        '
        'Label141
        '
        Me.Label141.AutoSize = True
        Me.Label141.Location = New System.Drawing.Point(3, 50)
        Me.Label141.Name = "Label141"
        Me.Label141.Size = New System.Drawing.Size(16, 17)
        Me.Label141.TabIndex = 5
        Me.Label141.Text = "3"
        '
        'Label153
        '
        Me.Label153.AutoSize = True
        Me.Label153.Location = New System.Drawing.Point(70, 90)
        Me.Label153.Name = "Label153"
        Me.Label153.Size = New System.Drawing.Size(16, 17)
        Me.Label153.TabIndex = 220
        Me.Label153.Text = "2"
        '
        'Label152
        '
        Me.Label152.AutoSize = True
        Me.Label152.Location = New System.Drawing.Point(151, 90)
        Me.Label152.Name = "Label152"
        Me.Label152.Size = New System.Drawing.Size(28, 17)
        Me.Label152.TabIndex = 219
        Me.Label152.Text = "5.0"
        '
        'Label148
        '
        Me.Label148.AutoSize = True
        Me.Label148.Location = New System.Drawing.Point(70, 70)
        Me.Label148.Name = "Label148"
        Me.Label148.Size = New System.Drawing.Size(16, 17)
        Me.Label148.TabIndex = 215
        Me.Label148.Text = "7"
        '
        'Label147
        '
        Me.Label147.AutoSize = True
        Me.Label147.Location = New System.Drawing.Point(151, 70)
        Me.Label147.Name = "Label147"
        Me.Label147.Size = New System.Drawing.Size(28, 17)
        Me.Label147.TabIndex = 214
        Me.Label147.Text = "1.0"
        '
        'Label143
        '
        Me.Label143.AutoSize = True
        Me.Label143.Location = New System.Drawing.Point(70, 50)
        Me.Label143.Name = "Label143"
        Me.Label143.Size = New System.Drawing.Size(24, 17)
        Me.Label143.TabIndex = 7
        Me.Label143.Text = "30"
        '
        'Label142
        '
        Me.Label142.AutoSize = True
        Me.Label142.Location = New System.Drawing.Point(151, 50)
        Me.Label142.Name = "Label142"
        Me.Label142.Size = New System.Drawing.Size(28, 17)
        Me.Label142.TabIndex = 6
        Me.Label142.Text = "0.1"
        '
        'Label136
        '
        Me.Label136.AutoSize = True
        Me.Label136.Location = New System.Drawing.Point(3, 0)
        Me.Label136.Name = "Label136"
        Me.Label136.Size = New System.Drawing.Size(60, 50)
        Me.Label136.TabIndex = 0
        Me.Label136.Text = "thickness" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(cm)"
        '
        'Label139
        '
        Me.Label139.AutoSize = True
        Me.Label139.Location = New System.Drawing.Point(251, 0)
        Me.Label139.Name = "Label139"
        Me.Label139.Size = New System.Drawing.Size(44, 34)
        Me.Label139.TabIndex = 3
        Me.Label139.Text = "start " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "depth"
        '
        'Label135
        '
        Me.Label135.AutoSize = True
        Me.Label135.Location = New System.Drawing.Point(19, 636)
        Me.Label135.Name = "Label135"
        Me.Label135.Size = New System.Drawing.Size(719, 85)
        Me.Label135.TabIndex = 210
        Me.Label135.Text = resources.GetString("Label135.Text")
        '
        'useAutoGWprofile
        '
        Me.useAutoGWprofile.AutoSize = True
        Me.useAutoGWprofile.Location = New System.Drawing.Point(263, 612)
        Me.useAutoGWprofile.Name = "useAutoGWprofile"
        Me.useAutoGWprofile.Size = New System.Drawing.Size(249, 21)
        Me.useAutoGWprofile.TabIndex = 209
        Me.useAutoGWprofile.Text = "Use automatic standardized profile"
        Me.useAutoGWprofile.UseVisualStyleBackColor = False
        '
        'Label132
        '
        Me.Label132.AutoSize = True
        Me.Label132.Location = New System.Drawing.Point(305, 733)
        Me.Label132.Name = "Label132"
        Me.Label132.Size = New System.Drawing.Size(516, 136)
        Me.Label132.TabIndex = 204
        Me.Label132.Text = resources.GetString("Label132.Text")
        '
        'Label131
        '
        Me.Label131.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label131.Location = New System.Drawing.Point(9, 605)
        Me.Label131.Name = "Label131"
        Me.Label131.Size = New System.Drawing.Size(271, 31)
        Me.Label131.TabIndex = 203
        Me.Label131.Text = "Dispersion Control"
        '
        'DiscretizationGridView
        '
        Me.DiscretizationGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DiscretizationGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Thickness, Me.Increments})
        Me.DiscretizationGridView.Location = New System.Drawing.Point(8, 775)
        Me.DiscretizationGridView.Name = "DiscretizationGridView"
        Me.DiscretizationGridView.RowHeadersVisible = False
        Me.DiscretizationGridView.RowHeadersWidth = 51
        Me.DiscretizationGridView.RowTemplate.Height = 24
        Me.DiscretizationGridView.Size = New System.Drawing.Size(281, 293)
        Me.DiscretizationGridView.TabIndex = 202
        '
        'Thickness
        '
        Me.Thickness.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Thickness.HeaderText = "Thickness (cm)"
        Me.Thickness.MinimumWidth = 6
        Me.Thickness.Name = "Thickness"
        '
        'Increments
        '
        Me.Increments.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Increments.HeaderText = "Number of Increments"
        Me.Increments.MinimumWidth = 6
        Me.Increments.Name = "Increments"
        '
        'Label99
        '
        Me.Label99.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label99.Location = New System.Drawing.Point(346, 2122)
        Me.Label99.Name = "Label99"
        Me.Label99.Size = New System.Drawing.Size(166, 31)
        Me.Label99.TabIndex = 201
        Me.Label99.Text = "Scenario End"
        '
        'Label98
        '
        Me.Label98.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label98.Location = New System.Drawing.Point(20, 1604)
        Me.Label98.Name = "Label98"
        Me.Label98.Size = New System.Drawing.Size(348, 31)
        Me.Label98.TabIndex = 200
        Me.Label98.Text = "Runoff and Erosion"
        '
        'Label97
        '
        Me.Label97.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label97.Location = New System.Drawing.Point(10, 257)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(177, 31)
        Me.Label97.TabIndex = 199
        Me.Label97.Text = "Soil Profile"
        '
        'Label96
        '
        Me.Label96.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label96.Location = New System.Drawing.Point(9, 1106)
        Me.Label96.Name = "Label96"
        Me.Label96.Size = New System.Drawing.Size(78, 31)
        Me.Label96.TabIndex = 0
        Me.Label96.Text = "Crop"
        '
        'Label84
        '
        Me.Label84.AutoSize = True
        Me.Label84.Location = New System.Drawing.Point(649, 303)
        Me.Label84.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label84.Name = "Label84"
        Me.Label84.Size = New System.Drawing.Size(52, 17)
        Me.Label84.TabIndex = 84
        Me.Label84.Text = "Albedo"
        '
        'GetWeatherFile
        '
        Me.GetWeatherFile.Location = New System.Drawing.Point(8, 39)
        Me.GetWeatherFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GetWeatherFile.Name = "GetWeatherFile"
        Me.GetWeatherFile.Size = New System.Drawing.Size(132, 28)
        Me.GetWeatherFile.TabIndex = 1
        Me.GetWeatherFile.Text = "Get Weather File"
        Me.GetWeatherFile.UseVisualStyleBackColor = True
        '
        'albedo
        '
        Me.albedo.Location = New System.Drawing.Point(709, 303)
        Me.albedo.Margin = New System.Windows.Forms.Padding(4)
        Me.albedo.Name = "albedo"
        Me.albedo.Size = New System.Drawing.Size(55, 22)
        Me.albedo.TabIndex = 82
        Me.albedo.Tag = "albedo."
        Me.albedo.Text = "0.2"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(251, 91)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(118, 17)
        Me.Label37.TabIndex = 138
        Me.Label37.Text = "Adjust PET factor"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(5, 91)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(112, 17)
        Me.Label36.TabIndex = 136
        Me.Label36.Text = "Snowmelt Factor"
        '
        'evapDepth
        '
        Me.evapDepth.Location = New System.Drawing.Point(221, 298)
        Me.evapDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.evapDepth.Name = "evapDepth"
        Me.evapDepth.Size = New System.Drawing.Size(59, 22)
        Me.evapDepth.TabIndex = 133
        Me.evapDepth.Text = "5"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(12, 299)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(198, 17)
        Me.Label35.TabIndex = 134
        Me.Label35.Text = "Depth of soil evaporation (cm)"
        '
        'PETadjustment
        '
        Me.PETadjustment.Location = New System.Drawing.Point(375, 88)
        Me.PETadjustment.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PETadjustment.Name = "PETadjustment"
        Me.PETadjustment.Size = New System.Drawing.Size(52, 22)
        Me.PETadjustment.TabIndex = 137
        Me.PETadjustment.Text = "1"
        '
        'Evergreen
        '
        Me.Evergreen.AutoSize = True
        Me.Evergreen.CheckAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Evergreen.Location = New System.Drawing.Point(110, 1474)
        Me.Evergreen.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Evergreen.Name = "Evergreen"
        Me.Evergreen.Size = New System.Drawing.Size(78, 38)
        Me.Evergreen.TabIndex = 90
        Me.Evergreen.Text = "Evergreen"
        Me.Evergreen.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Evergreen.UseVisualStyleBackColor = True
        '
        'snowMelt
        '
        Me.snowMelt.Location = New System.Drawing.Point(123, 91)
        Me.snowMelt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.snowMelt.Name = "snowMelt"
        Me.snowMelt.Size = New System.Drawing.Size(73, 22)
        Me.snowMelt.TabIndex = 135
        Me.snowMelt.Text = "0.274"
        '
        'WeatherFileName
        '
        Me.WeatherFileName.Location = New System.Drawing.Point(158, 42)
        Me.WeatherFileName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WeatherFileName.Name = "WeatherFileName"
        Me.WeatherFileName.Size = New System.Drawing.Size(369, 22)
        Me.WeatherFileName.TabIndex = 2
        '
        'EvergreenPanel
        '
        Me.EvergreenPanel.Controls.Add(Me.Label43)
        Me.EvergreenPanel.Controls.Add(Me.Label42)
        Me.EvergreenPanel.Controls.Add(Me.Label41)
        Me.EvergreenPanel.Controls.Add(Me.Label40)
        Me.EvergreenPanel.Controls.Add(Me.EvergreenHoldup)
        Me.EvergreenPanel.Controls.Add(Me.EvergreenHt)
        Me.EvergreenPanel.Controls.Add(Me.EvergreenCover)
        Me.EvergreenPanel.Controls.Add(Me.EvergreenRoot)
        Me.EvergreenPanel.Location = New System.Drawing.Point(302, 1446)
        Me.EvergreenPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EvergreenPanel.Name = "EvergreenPanel"
        Me.EvergreenPanel.Size = New System.Drawing.Size(316, 98)
        Me.EvergreenPanel.TabIndex = 91
        Me.EvergreenPanel.Visible = False
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Location = New System.Drawing.Point(232, 18)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(57, 34)
        Me.Label43.TabIndex = 9
        Me.Label43.Text = "Holdup " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(cm)"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Location = New System.Drawing.Point(157, 18)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(53, 34)
        Me.Label42.TabIndex = 8
        Me.Label42.Text = "Height " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(cm)"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Location = New System.Drawing.Point(90, 18)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(49, 34)
        Me.Label41.TabIndex = 7
        Me.Label41.Text = "Cover " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(%)"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Location = New System.Drawing.Point(24, 4)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(50, 51)
        Me.Label40.TabIndex = 6
        Me.Label40.Text = "Root " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Depth " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "(cm)"
        '
        'EvergreenHoldup
        '
        Me.EvergreenHoldup.Location = New System.Drawing.Point(228, 57)
        Me.EvergreenHoldup.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EvergreenHoldup.Name = "EvergreenHoldup"
        Me.EvergreenHoldup.Size = New System.Drawing.Size(61, 22)
        Me.EvergreenHoldup.TabIndex = 5
        '
        'EvergreenHt
        '
        Me.EvergreenHt.Location = New System.Drawing.Point(149, 57)
        Me.EvergreenHt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EvergreenHt.Name = "EvergreenHt"
        Me.EvergreenHt.Size = New System.Drawing.Size(61, 22)
        Me.EvergreenHt.TabIndex = 4
        '
        'EvergreenCover
        '
        Me.EvergreenCover.Location = New System.Drawing.Point(80, 57)
        Me.EvergreenCover.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EvergreenCover.Name = "EvergreenCover"
        Me.EvergreenCover.Size = New System.Drawing.Size(61, 22)
        Me.EvergreenCover.TabIndex = 3
        '
        'EvergreenRoot
        '
        Me.EvergreenRoot.Location = New System.Drawing.Point(15, 57)
        Me.EvergreenRoot.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EvergreenRoot.Name = "EvergreenRoot"
        Me.EvergreenRoot.Size = New System.Drawing.Size(59, 22)
        Me.EvergreenRoot.TabIndex = 2
        '
        'bcTemp
        '
        Me.bcTemp.Location = New System.Drawing.Point(532, 298)
        Me.bcTemp.Margin = New System.Windows.Forms.Padding(4)
        Me.bcTemp.Name = "bcTemp"
        Me.bcTemp.Size = New System.Drawing.Size(55, 22)
        Me.bcTemp.TabIndex = 83
        Me.bcTemp.Tag = "lower temperature boundary condition."
        '
        'Label83
        '
        Me.Label83.AutoSize = True
        Me.Label83.Location = New System.Drawing.Point(341, 301)
        Me.Label83.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label83.Name = "Label83"
        Me.Label83.Size = New System.Drawing.Size(183, 17)
        Me.Label83.TabIndex = 81
        Me.Label83.Tag = ""
        Me.Label83.Text = "Lower BC Temperature (°C)"
        '
        'GroupBox4
        '
        Me.GroupBox4.BackColor = System.Drawing.Color.PapayaWhip
        Me.GroupBox4.Controls.Add(Me.IrrigateOnlyCrops)
        Me.GroupBox4.Controls.Add(Me.Panel3)
        Me.GroupBox4.Controls.Add(Me.Label304)
        Me.GroupBox4.Controls.Add(Me.IrrigationDepthUserSpec)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.rateIrrig)
        Me.GroupBox4.Controls.Add(Me.depletion)
        Me.GroupBox4.Controls.Add(Me.fleach)
        Me.GroupBox4.Controls.Add(Me.underCanopy)
        Me.GroupBox4.Controls.Add(Me.overCanopy)
        Me.GroupBox4.Controls.Add(Me.noIrrigation)
        Me.GroupBox4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox4.Location = New System.Drawing.Point(7, 135)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox4.Size = New System.Drawing.Size(786, 118)
        Me.GroupBox4.TabIndex = 10
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Irrigation"
        '
        'IrrigateOnlyCrops
        '
        Me.IrrigateOnlyCrops.AutoSize = True
        Me.IrrigateOnlyCrops.Location = New System.Drawing.Point(7, 95)
        Me.IrrigateOnlyCrops.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IrrigateOnlyCrops.Name = "IrrigateOnlyCrops"
        Me.IrrigateOnlyCrops.Size = New System.Drawing.Size(230, 21)
        Me.IrrigateOnlyCrops.TabIndex = 90
        Me.IrrigateOnlyCrops.Text = "Irrigate only during crop season"
        Me.IrrigateOnlyCrops.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.IrrigDepthRootZone)
        Me.Panel3.Controls.Add(Me.UserSpecifiesIrrigDepth)
        Me.Panel3.Location = New System.Drawing.Point(508, 38)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(164, 48)
        Me.Panel3.TabIndex = 89
        '
        'IrrigDepthRootZone
        '
        Me.IrrigDepthRootZone.AutoSize = True
        Me.IrrigDepthRootZone.Checked = True
        Me.IrrigDepthRootZone.Location = New System.Drawing.Point(4, 4)
        Me.IrrigDepthRootZone.Margin = New System.Windows.Forms.Padding(4)
        Me.IrrigDepthRootZone.Name = "IrrigDepthRootZone"
        Me.IrrigDepthRootZone.Size = New System.Drawing.Size(96, 21)
        Me.IrrigDepthRootZone.TabIndex = 18
        Me.IrrigDepthRootZone.TabStop = True
        Me.IrrigDepthRootZone.Text = "Root Zone"
        Me.IrrigDepthRootZone.UseVisualStyleBackColor = True
        '
        'UserSpecifiesIrrigDepth
        '
        Me.UserSpecifiesIrrigDepth.AutoSize = True
        Me.UserSpecifiesIrrigDepth.Location = New System.Drawing.Point(4, 25)
        Me.UserSpecifiesIrrigDepth.Margin = New System.Windows.Forms.Padding(4)
        Me.UserSpecifiesIrrigDepth.Name = "UserSpecifiesIrrigDepth"
        Me.UserSpecifiesIrrigDepth.Size = New System.Drawing.Size(153, 21)
        Me.UserSpecifiesIrrigDepth.TabIndex = 17
        Me.UserSpecifiesIrrigDepth.Text = "User Specified (cm)"
        Me.UserSpecifiesIrrigDepth.UseVisualStyleBackColor = True
        '
        'Label304
        '
        Me.Label304.AutoSize = True
        Me.Label304.Location = New System.Drawing.Point(505, 14)
        Me.Label304.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label304.Name = "Label304"
        Me.Label304.Size = New System.Drawing.Size(132, 17)
        Me.Label304.TabIndex = 19
        Me.Label304.Text = "Soil Irrigation Depth"
        '
        'IrrigationDepthUserSpec
        '
        Me.IrrigationDepthUserSpec.Location = New System.Drawing.Point(692, 59)
        Me.IrrigationDepthUserSpec.Margin = New System.Windows.Forms.Padding(4)
        Me.IrrigationDepthUserSpec.Name = "IrrigationDepthUserSpec"
        Me.IrrigationDepthUserSpec.Size = New System.Drawing.Size(55, 22)
        Me.IrrigationDepthUserSpec.TabIndex = 16
        Me.IrrigationDepthUserSpec.Tag = "user-specified irrigation depth."
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.Location = New System.Drawing.Point(234, 17)
        Me.Label53.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(126, 17)
        Me.Label53.TabIndex = 10
        Me.Label53.Text = "Max Rate (cm/day)"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.Location = New System.Drawing.Point(240, 41)
        Me.Label52.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(120, 17)
        Me.Label52.TabIndex = 13
        Me.Label52.Text = "Allowed Depletion"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.Location = New System.Drawing.Point(223, 65)
        Me.Label51.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(137, 17)
        Me.Label51.TabIndex = 12
        Me.Label51.Text = "Extra Water Fraction"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rateIrrig
        '
        Me.rateIrrig.Location = New System.Drawing.Point(368, 14)
        Me.rateIrrig.Margin = New System.Windows.Forms.Padding(4)
        Me.rateIrrig.Name = "rateIrrig"
        Me.rateIrrig.Size = New System.Drawing.Size(55, 22)
        Me.rateIrrig.TabIndex = 11
        Me.rateIrrig.Tag = "irrigation max rate."
        '
        'depletion
        '
        Me.depletion.Location = New System.Drawing.Point(368, 38)
        Me.depletion.Margin = New System.Windows.Forms.Padding(4)
        Me.depletion.Name = "depletion"
        Me.depletion.Size = New System.Drawing.Size(55, 22)
        Me.depletion.TabIndex = 10
        Me.depletion.Tag = "irrigation allowed depetion."
        '
        'fleach
        '
        Me.fleach.Location = New System.Drawing.Point(368, 62)
        Me.fleach.Margin = New System.Windows.Forms.Padding(4)
        Me.fleach.Name = "fleach"
        Me.fleach.Size = New System.Drawing.Size(55, 22)
        Me.fleach.TabIndex = 9
        Me.fleach.Tag = "extra water fraction."
        '
        'underCanopy
        '
        Me.underCanopy.AutoSize = True
        Me.underCanopy.Location = New System.Drawing.Point(7, 60)
        Me.underCanopy.Margin = New System.Windows.Forms.Padding(4)
        Me.underCanopy.Name = "underCanopy"
        Me.underCanopy.Size = New System.Drawing.Size(120, 21)
        Me.underCanopy.TabIndex = 8
        Me.underCanopy.Text = "Under Canopy"
        Me.underCanopy.UseVisualStyleBackColor = True
        '
        'overCanopy
        '
        Me.overCanopy.AutoSize = True
        Me.overCanopy.Location = New System.Drawing.Point(7, 41)
        Me.overCanopy.Margin = New System.Windows.Forms.Padding(4)
        Me.overCanopy.Name = "overCanopy"
        Me.overCanopy.Size = New System.Drawing.Size(116, 21)
        Me.overCanopy.TabIndex = 7
        Me.overCanopy.Text = "Over  Canopy"
        Me.overCanopy.UseVisualStyleBackColor = True
        '
        'noIrrigation
        '
        Me.noIrrigation.AutoSize = True
        Me.noIrrigation.Location = New System.Drawing.Point(7, 23)
        Me.noIrrigation.Margin = New System.Windows.Forms.Padding(4)
        Me.noIrrigation.Name = "noIrrigation"
        Me.noIrrigation.Size = New System.Drawing.Size(63, 21)
        Me.noIrrigation.TabIndex = 6
        Me.noIrrigation.Text = "None"
        Me.noIrrigation.UseVisualStyleBackColor = True
        '
        'eInteracting
        '
        Me.eInteracting.Location = New System.Drawing.Point(637, 2056)
        Me.eInteracting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.eInteracting.Name = "eInteracting"
        Me.eInteracting.Size = New System.Drawing.Size(100, 22)
        Me.eInteracting.TabIndex = 122
        '
        'rDecline
        '
        Me.rDecline.Location = New System.Drawing.Point(235, 2036)
        Me.rDecline.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rDecline.Name = "rDecline"
        Me.rDecline.Size = New System.Drawing.Size(100, 22)
        Me.rDecline.TabIndex = 115
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(12, 15)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 17)
        Me.Label21.TabIndex = 4
        Me.Label21.Text = "Scenario ID"
        '
        'rInteracting
        '
        Me.rInteracting.Location = New System.Drawing.Point(235, 2058)
        Me.rInteracting.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rInteracting.Name = "rInteracting"
        Me.rInteracting.Size = New System.Drawing.Size(100, 22)
        Me.rInteracting.TabIndex = 114
        '
        'eDepth
        '
        Me.eDepth.Location = New System.Drawing.Point(637, 2013)
        Me.eDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.eDepth.Name = "eDepth"
        Me.eDepth.Size = New System.Drawing.Size(100, 22)
        Me.eDepth.TabIndex = 113
        '
        'eDecline
        '
        Me.eDecline.Location = New System.Drawing.Point(637, 2034)
        Me.eDecline.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.eDecline.Name = "eDecline"
        Me.eDecline.Size = New System.Drawing.Size(100, 22)
        Me.eDecline.TabIndex = 112
        '
        'rDepth
        '
        Me.rDepth.Location = New System.Drawing.Point(235, 2014)
        Me.rDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rDepth.Name = "rDepth"
        Me.rDepth.Size = New System.Drawing.Size(100, 22)
        Me.rDepth.TabIndex = 111
        '
        'latitude
        '
        Me.latitude.Location = New System.Drawing.Point(685, 42)
        Me.latitude.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.latitude.Name = "latitude"
        Me.latitude.Size = New System.Drawing.Size(100, 22)
        Me.latitude.TabIndex = 86
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(451, 2062)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(181, 17)
        Me.Label26.TabIndex = 121
        Me.Label26.Text = "Erosion Interacting Fraction"
        '
        'ScenarioID
        '
        Me.ScenarioID.Location = New System.Drawing.Point(158, 11)
        Me.ScenarioID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScenarioID.Name = "ScenarioID"
        Me.ScenarioID.Size = New System.Drawing.Size(684, 22)
        Me.ScenarioID.TabIndex = 3
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(459, 2036)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(173, 17)
        Me.Label27.TabIndex = 120
        Me.Label27.Text = "Erosion Extraction Decline"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(435, 2016)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(196, 17)
        Me.Label28.TabIndex = 119
        Me.Label28.Text = "Erosion Extraction Depth (cm)"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(55, 2061)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(175, 17)
        Me.Label25.TabIndex = 118
        Me.Label25.Text = "Runoff Interacting Fraction"
        '
        'HorizonGridView
        '
        Me.HorizonGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HorizonGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5, Me.Column6, Me.Column7, Me.Column8, Me.Column9, Me.Column13})
        Me.HorizonGridView.Location = New System.Drawing.Point(4, 348)
        Me.HorizonGridView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HorizonGridView.Name = "HorizonGridView"
        Me.HorizonGridView.RowHeadersVisible = False
        Me.HorizonGridView.RowHeadersWidth = 51
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HorizonGridView.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.HorizonGridView.RowTemplate.Height = 24
        Me.HorizonGridView.Size = New System.Drawing.Size(847, 252)
        Me.HorizonGridView.TabIndex = 0
        '
        'Column1
        '
        Me.Column1.FillWeight = 11.0!
        Me.Column1.HeaderText = "  #"
        Me.Column1.MinimumWidth = 6
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column1.Width = 54
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.FillWeight = 22.0!
        Me.Column2.HeaderText = "Thickness (cm)"
        Me.Column2.MinimumWidth = 6
        Me.Column2.Name = "Column2"
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column3.FillWeight = 25.0!
        Me.Column3.HeaderText = "   ρ              (g/cm³)"
        Me.Column3.MinimumWidth = 6
        Me.Column3.Name = "Column3"
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Column3.Width = 81
        '
        'Column4
        '
        Me.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column4.FillWeight = 24.0!
        Me.Column4.HeaderText = "Max Cap (fraction)"
        Me.Column4.MinimumWidth = 6
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column5.FillWeight = 24.0!
        Me.Column5.HeaderText = "Min Cap (fraction)"
        Me.Column5.MinimumWidth = 6
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column6.FillWeight = 20.0!
        Me.Column6.HeaderText = "O.C. (%)"
        Me.Column6.MinimumWidth = 6
        Me.Column6.Name = "Column6"
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column7
        '
        Me.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column7.FillWeight = 12.0!
        Me.Column7.HeaderText = "  ∆"
        Me.Column7.MinimumWidth = 6
        Me.Column7.Name = "Column7"
        Me.Column7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column8
        '
        Me.Column8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column8.FillWeight = 20.0!
        Me.Column8.HeaderText = "Sand (%)"
        Me.Column8.MinimumWidth = 6
        Me.Column8.Name = "Column8"
        Me.Column8.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column9
        '
        Me.Column9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column9.FillWeight = 20.0!
        Me.Column9.HeaderText = "Clay (%)"
        Me.Column9.MinimumWidth = 6
        Me.Column9.Name = "Column9"
        Me.Column9.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column13
        '
        Me.Column13.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column13.FillWeight = 14.0!
        Me.Column13.HeaderText = "Delete"
        Me.Column13.MinimumWidth = 6
        Me.Column13.Name = "Column13"
        Me.Column13.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column13.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column13.Text = "X"
        Me.Column13.UseColumnTextForButtonValue = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(63, 2038)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(167, 17)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "Runoff Extraction Decline"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(40, 2017)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(190, 17)
        Me.Label23.TabIndex = 116
        Me.Label23.Text = "Runoff Extraction Depth (cm)"
        '
        'Label62
        '
        Me.Label62.AutoSize = True
        Me.Label62.Location = New System.Drawing.Point(560, 45)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(119, 17)
        Me.Label62.TabIndex = 87
        Me.Label62.Text = "Scenario Latitude"
        '
        'SimTemperature
        '
        Me.SimTemperature.AutoSize = True
        Me.SimTemperature.Location = New System.Drawing.Point(467, 279)
        Me.SimTemperature.Margin = New System.Windows.Forms.Padding(4)
        Me.SimTemperature.Name = "SimTemperature"
        Me.SimTemperature.Size = New System.Drawing.Size(170, 21)
        Me.SimTemperature.TabIndex = 76
        Me.SimTemperature.Text = "Simulate Temperature"
        Me.SimTemperature.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.SimTemperature.UseVisualStyleBackColor = True
        '
        'CropGridView
        '
        Me.CropGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.CropGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewComboBoxColumn1, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9})
        Me.CropGridView.Location = New System.Drawing.Point(7, 1146)
        Me.CropGridView.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CropGridView.Name = "CropGridView"
        Me.CropGridView.RowHeadersVisible = False
        Me.CropGridView.RowHeadersWidth = 51
        Me.CropGridView.RowTemplate.Height = 24
        Me.CropGridView.Size = New System.Drawing.Size(844, 286)
        Me.CropGridView.TabIndex = 109
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn1.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn1.HeaderText = "Emerge (m/d)"
        Me.DataGridViewTextBoxColumn1.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn2.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn2.HeaderText = "Maturity (m/d)"
        Me.DataGridViewTextBoxColumn2.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn3.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn3.HeaderText = "Removal (m/d)"
        Me.DataGridViewTextBoxColumn3.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn4.FillWeight = 6.0!
        Me.DataGridViewTextBoxColumn4.HeaderText = "Root Depth (cm)"
        Me.DataGridViewTextBoxColumn4.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn5.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn5.HeaderText = "Cover (fraction)"
        Me.DataGridViewTextBoxColumn5.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn6.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn6.HeaderText = "Height (cm)"
        Me.DataGridViewTextBoxColumn6.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn7.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn7.HeaderText = "Holdup (cm)"
        Me.DataGridViewTextBoxColumn7.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        '
        'DataGridViewComboBoxColumn1
        '
        Me.DataGridViewComboBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewComboBoxColumn1.DropDownWidth = 2
        Me.DataGridViewComboBoxColumn1.FillWeight = 12.0!
        Me.DataGridViewComboBoxColumn1.HeaderText = "Removal Type"
        Me.DataGridViewComboBoxColumn1.Items.AddRange(New Object() {"Surface Applied", "Removed", "Left on Plant"})
        Me.DataGridViewComboBoxColumn1.MinimumWidth = 6
        Me.DataGridViewComboBoxColumn1.Name = "DataGridViewComboBoxColumn1"
        Me.DataGridViewComboBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.DataGridViewTextBoxColumn8.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn8.HeaderText = "Periodicity"
        Me.DataGridViewTextBoxColumn8.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.Width = 102
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.DataGridViewTextBoxColumn9.FillWeight = 5.0!
        Me.DataGridViewTextBoxColumn9.HeaderText = "Lag"
        Me.DataGridViewTextBoxColumn9.MinimumWidth = 6
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        '
        'RunoffErosionYearSpecific
        '
        Me.RunoffErosionYearSpecific.AutoSize = True
        Me.RunoffErosionYearSpecific.Location = New System.Drawing.Point(25, 1675)
        Me.RunoffErosionYearSpecific.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RunoffErosionYearSpecific.Name = "RunoffErosionYearSpecific"
        Me.RunoffErosionYearSpecific.Size = New System.Drawing.Size(363, 21)
        Me.RunoffErosionYearSpecific.TabIndex = 96
        Me.RunoffErosionYearSpecific.Text = "Events are specific to particular year (requires m/d/y)"
        Me.RunoffErosionYearSpecific.UseVisualStyleBackColor = True
        '
        'YearlyCycleButton
        '
        Me.YearlyCycleButton.AutoSize = True
        Me.YearlyCycleButton.Checked = True
        Me.YearlyCycleButton.Location = New System.Drawing.Point(25, 1655)
        Me.YearlyCycleButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.YearlyCycleButton.Name = "YearlyCycleButton"
        Me.YearlyCycleButton.Size = New System.Drawing.Size(343, 21)
        Me.YearlyCycleButton.TabIndex = 95
        Me.YearlyCycleButton.TabStop = True
        Me.YearlyCycleButton.Text = "Events repeat on yearly cycle (requires only (m/d)"
        Me.YearlyCycleButton.UseVisualStyleBackColor = True
        '
        'HydroDataGrid
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HydroDataGrid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.HydroDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HydroDataGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column20, Me.Column22, Me.Column23})
        Me.HydroDataGrid.Location = New System.Drawing.Point(14, 1710)
        Me.HydroDataGrid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HydroDataGrid.Name = "HydroDataGrid"
        Me.HydroDataGrid.RowHeadersWidth = 51
        Me.HydroDataGrid.RowTemplate.Height = 24
        Me.HydroDataGrid.Size = New System.Drawing.Size(421, 278)
        Me.HydroDataGrid.TabIndex = 94
        '
        'Column20
        '
        Me.Column20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column20.FillWeight = 30.0!
        Me.Column20.HeaderText = "Date (m/d)"
        Me.Column20.MinimumWidth = 6
        Me.Column20.Name = "Column20"
        '
        'Column22
        '
        Me.Column22.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column22.FillWeight = 20.0!
        Me.Column22.HeaderText = "CN"
        Me.Column22.MinimumWidth = 6
        Me.Column22.Name = "Column22"
        '
        'Column23
        '
        Me.Column23.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column23.FillWeight = 20.0!
        Me.Column23.HeaderText = "USLE-C"
        Me.Column23.MinimumWidth = 6
        Me.Column23.Name = "Column23"
        '
        'usleLS
        '
        Me.usleLS.Location = New System.Drawing.Point(633, 1738)
        Me.usleLS.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.usleLS.Name = "usleLS"
        Me.usleLS.Size = New System.Drawing.Size(100, 22)
        Me.usleLS.TabIndex = 98
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(569, 1719)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 17)
        Me.Label29.TabIndex = 102
        Me.Label29.Text = "USLE-K"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(561, 1741)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(66, 17)
        Me.Label30.TabIndex = 103
        Me.Label30.Text = "USLE-LS"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(569, 1763)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(58, 17)
        Me.Label31.TabIndex = 104
        Me.Label31.Text = "USLE-P"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(585, 1785)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(41, 17)
        Me.Label32.TabIndex = 105
        Me.Label32.Text = "IREG"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(556, 1807)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 17)
        Me.Label33.TabIndex = 106
        Me.Label33.Text = "Slope (%)"
        '
        'usleK
        '
        Me.usleK.Location = New System.Drawing.Point(633, 1716)
        Me.usleK.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.usleK.Name = "usleK"
        Me.usleK.Size = New System.Drawing.Size(100, 22)
        Me.usleK.TabIndex = 97
        '
        'usleP
        '
        Me.usleP.Location = New System.Drawing.Point(633, 1761)
        Me.usleP.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.usleP.Name = "usleP"
        Me.usleP.Size = New System.Drawing.Size(100, 22)
        Me.usleP.TabIndex = 99
        '
        'ireg
        '
        Me.ireg.Location = New System.Drawing.Point(633, 1782)
        Me.ireg.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ireg.Name = "ireg"
        Me.ireg.Size = New System.Drawing.Size(100, 22)
        Me.ireg.TabIndex = 100
        '
        'slope
        '
        Me.slope.Location = New System.Drawing.Point(633, 1804)
        Me.slope.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.slope.Name = "slope"
        Me.slope.Size = New System.Drawing.Size(100, 22)
        Me.slope.TabIndex = 101
        '
        'Label92
        '
        Me.Label92.AutoSize = True
        Me.Label92.Font = New System.Drawing.Font("Algerian", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label92.ForeColor = System.Drawing.Color.Green
        Me.Label92.Location = New System.Drawing.Point(270, 15)
        Me.Label92.Name = "Label92"
        Me.Label92.Size = New System.Drawing.Size(376, 45)
        Me.Label92.TabIndex = 206
        Me.Label92.Text = "Watershed Body"
        '
        'PushToSaveWaterBody
        '
        Me.PushToSaveWaterBody.BackColor = System.Drawing.Color.Gold
        Me.PushToSaveWaterBody.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PushToSaveWaterBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PushToSaveWaterBody.Location = New System.Drawing.Point(656, 76)
        Me.PushToSaveWaterBody.Name = "PushToSaveWaterBody"
        Me.PushToSaveWaterBody.Size = New System.Drawing.Size(229, 51)
        Me.PushToSaveWaterBody.TabIndex = 204
        Me.PushToSaveWaterBody.Text = "Push Here To Save Water Body"
        Me.PushToSaveWaterBody.UseVisualStyleBackColor = False
        '
        'PushToLoadWaterBody
        '
        Me.PushToLoadWaterBody.BackColor = System.Drawing.Color.SpringGreen
        Me.PushToLoadWaterBody.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PushToLoadWaterBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PushToLoadWaterBody.Location = New System.Drawing.Point(9, 76)
        Me.PushToLoadWaterBody.Name = "PushToLoadWaterBody"
        Me.PushToLoadWaterBody.Size = New System.Drawing.Size(229, 51)
        Me.PushToLoadWaterBody.TabIndex = 203
        Me.PushToLoadWaterBody.Text = "Push Here To Examine a Water Body"
        Me.PushToLoadWaterBody.UseVisualStyleBackColor = False
        '
        'Label100
        '
        Me.Label100.AutoSize = True
        Me.Label100.BackColor = System.Drawing.Color.Transparent
        Me.Label100.Location = New System.Drawing.Point(237, 345)
        Me.Label100.Name = "Label100"
        Me.Label100.Size = New System.Drawing.Size(213, 51)
        Me.Label100.TabIndex = 199
        Me.Label100.Text = "1 is varying volume with flow" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "2 is constant volume with no flow" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "3 is constant v" &
    "olume with flow"
        '
        'FractionCroppedArea
        '
        Me.FractionCroppedArea.Location = New System.Drawing.Point(540, 486)
        Me.FractionCroppedArea.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FractionCroppedArea.Name = "FractionCroppedArea"
        Me.FractionCroppedArea.Size = New System.Drawing.Size(100, 22)
        Me.FractionCroppedArea.TabIndex = 180
        Me.FractionCroppedArea.Text = "1"
        '
        'BaseFlow
        '
        Me.BaseFlow.Location = New System.Drawing.Point(204, 545)
        Me.BaseFlow.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BaseFlow.Name = "BaseFlow"
        Me.BaseFlow.Size = New System.Drawing.Size(100, 22)
        Me.BaseFlow.TabIndex = 178
        Me.BaseFlow.Text = "0"
        '
        'FlowAveraging
        '
        Me.FlowAveraging.Location = New System.Drawing.Point(204, 525)
        Me.FlowAveraging.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowAveraging.Name = "FlowAveraging"
        Me.FlowAveraging.Size = New System.Drawing.Size(100, 22)
        Me.FlowAveraging.TabIndex = 176
        Me.FlowAveraging.Text = "1"
        '
        'MaxDepth
        '
        Me.MaxDepth.Location = New System.Drawing.Point(204, 491)
        Me.MaxDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaxDepth.Name = "MaxDepth"
        Me.MaxDepth.Size = New System.Drawing.Size(100, 22)
        Me.MaxDepth.TabIndex = 174
        Me.MaxDepth.Text = "2"
        '
        'FlowLength
        '
        Me.FlowLength.Location = New System.Drawing.Point(540, 464)
        Me.FlowLength.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FlowLength.Name = "FlowLength"
        Me.FlowLength.Size = New System.Drawing.Size(100, 22)
        Me.FlowLength.TabIndex = 107
        Me.FlowLength.Text = "100"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Location = New System.Drawing.Point(422, 467)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(109, 17)
        Me.Label39.TabIndex = 108
        Me.Label39.Text = "Flow Length (m)"
        '
        'InitialDepth
        '
        Me.InitialDepth.Location = New System.Drawing.Point(204, 469)
        Me.InitialDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.InitialDepth.Name = "InitialDepth"
        Me.InitialDepth.Size = New System.Drawing.Size(100, 22)
        Me.InitialDepth.TabIndex = 172
        Me.InitialDepth.Text = "2"
        '
        'WaterBodyArea
        '
        Me.WaterBodyArea.Location = New System.Drawing.Point(204, 447)
        Me.WaterBodyArea.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterBodyArea.Name = "WaterBodyArea"
        Me.WaterBodyArea.Size = New System.Drawing.Size(100, 22)
        Me.WaterBodyArea.TabIndex = 170
        Me.WaterBodyArea.Text = "10000"
        '
        'FieldSize
        '
        Me.FieldSize.Location = New System.Drawing.Point(540, 442)
        Me.FieldSize.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FieldSize.Name = "FieldSize"
        Me.FieldSize.Size = New System.Drawing.Size(100, 22)
        Me.FieldSize.TabIndex = 168
        Me.FieldSize.Text = "100000"
        '
        'Label82
        '
        Me.Label82.AutoSize = True
        Me.Label82.Location = New System.Drawing.Point(372, 489)
        Me.Label82.Name = "Label82"
        Me.Label82.Size = New System.Drawing.Size(162, 17)
        Me.Label82.TabIndex = 181
        Me.Label82.Text = "Fractional Cropped Area"
        '
        'Label80
        '
        Me.Label80.AutoSize = True
        Me.Label80.Location = New System.Drawing.Point(82, 549)
        Me.Label80.Name = "Label80"
        Me.Label80.Size = New System.Drawing.Size(113, 17)
        Me.Label80.TabIndex = 179
        Me.Label80.Text = "Base Flow (m³/s)"
        '
        'Label81
        '
        Me.Label81.AutoSize = True
        Me.Label81.Location = New System.Drawing.Point(50, 525)
        Me.Label81.Name = "Label81"
        Me.Label81.Size = New System.Drawing.Size(148, 17)
        Me.Label81.TabIndex = 177
        Me.Label81.Text = "Flow Averaging (days)"
        '
        'Label72
        '
        Me.Label72.AutoSize = True
        Me.Label72.Location = New System.Drawing.Point(62, 491)
        Me.Label72.Name = "Label72"
        Me.Label72.Size = New System.Drawing.Size(133, 17)
        Me.Label72.TabIndex = 175
        Me.Label72.Text = "Maximum Depth (m)"
        '
        'Label75
        '
        Me.Label75.AutoSize = True
        Me.Label75.Location = New System.Drawing.Point(88, 469)
        Me.Label75.Name = "Label75"
        Me.Label75.Size = New System.Drawing.Size(107, 17)
        Me.Label75.TabIndex = 173
        Me.Label75.Text = "Initial Depth (m)"
        '
        'Label69
        '
        Me.Label69.AutoSize = True
        Me.Label69.Location = New System.Drawing.Point(53, 449)
        Me.Label69.Name = "Label69"
        Me.Label69.Size = New System.Drawing.Size(145, 17)
        Me.Label69.TabIndex = 171
        Me.Label69.Text = "Water body Area (m²)"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(429, 445)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(102, 17)
        Me.Label38.TabIndex = 169
        Me.Label38.Text = "Field Area (m²)"
        '
        'WaterColumnBiomass
        '
        Me.WaterColumnBiomass.Location = New System.Drawing.Point(713, 284)
        Me.WaterColumnBiomass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColumnBiomass.Name = "WaterColumnBiomass"
        Me.WaterColumnBiomass.Size = New System.Drawing.Size(100, 22)
        Me.WaterColumnBiomass.TabIndex = 161
        Me.WaterColumnBiomass.Text = "0.4"
        '
        'WaterColumnDoc
        '
        Me.WaterColumnDoc.Location = New System.Drawing.Point(713, 262)
        Me.WaterColumnDoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColumnDoc.Name = "WaterColumnDoc"
        Me.WaterColumnDoc.Size = New System.Drawing.Size(100, 22)
        Me.WaterColumnDoc.TabIndex = 160
        Me.WaterColumnDoc.Text = "5.0"
        '
        'WaterColumnFoc
        '
        Me.WaterColumnFoc.Location = New System.Drawing.Point(713, 240)
        Me.WaterColumnFoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColumnFoc.Name = "WaterColumnFoc"
        Me.WaterColumnFoc.Size = New System.Drawing.Size(100, 22)
        Me.WaterColumnFoc.TabIndex = 159
        Me.WaterColumnFoc.Text = "0.04"
        '
        'Chlorophyll
        '
        Me.Chlorophyll.Location = New System.Drawing.Point(713, 217)
        Me.Chlorophyll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chlorophyll.Name = "Chlorophyll"
        Me.Chlorophyll.Size = New System.Drawing.Size(100, 22)
        Me.Chlorophyll.TabIndex = 158
        Me.Chlorophyll.Text = "0.005"
        '
        'SuspendedSolids
        '
        Me.SuspendedSolids.Location = New System.Drawing.Point(713, 197)
        Me.SuspendedSolids.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SuspendedSolids.Name = "SuspendedSolids"
        Me.SuspendedSolids.Size = New System.Drawing.Size(100, 22)
        Me.SuspendedSolids.TabIndex = 157
        Me.SuspendedSolids.Text = "30"
        '
        'Dfac
        '
        Me.Dfac.Location = New System.Drawing.Point(713, 174)
        Me.Dfac.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Dfac.Name = "Dfac"
        Me.Dfac.Size = New System.Drawing.Size(100, 22)
        Me.Dfac.TabIndex = 155
        Me.Dfac.Text = "1.19"
        '
        'Label73
        '
        Me.Label73.AutoSize = True
        Me.Label73.Location = New System.Drawing.Point(497, 286)
        Me.Label73.Name = "Label73"
        Me.Label73.Size = New System.Drawing.Size(199, 17)
        Me.Label73.TabIndex = 166
        Me.Label73.Text = "Water Column Biomass (mg/L)"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(575, 243)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(120, 17)
        Me.Label74.TabIndex = 165
        Me.Label74.Text = "Water Column foc"
        '
        'Label77
        '
        Me.Label77.AutoSize = True
        Me.Label77.Location = New System.Drawing.Point(519, 265)
        Me.Label77.Name = "Label77"
        Me.Label77.Size = New System.Drawing.Size(176, 17)
        Me.Label77.TabIndex = 164
        Me.Label77.Text = "Water Column DOC (mg/L)"
        '
        'Label78
        '
        Me.Label78.AutoSize = True
        Me.Label78.Location = New System.Drawing.Point(573, 221)
        Me.Label78.Name = "Label78"
        Me.Label78.Size = New System.Drawing.Size(123, 17)
        Me.Label78.TabIndex = 163
        Me.Label78.Text = "Chlorophyll (mg/L)"
        '
        'Label79
        '
        Me.Label79.AutoSize = True
        Me.Label79.Location = New System.Drawing.Point(529, 199)
        Me.Label79.Name = "Label79"
        Me.Label79.Size = New System.Drawing.Size(167, 17)
        Me.Label79.TabIndex = 162
        Me.Label79.Text = "Suspended Solids (mg/L)"
        '
        'Label68
        '
        Me.Label68.AutoSize = True
        Me.Label68.Location = New System.Drawing.Point(653, 177)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(44, 17)
        Me.Label68.TabIndex = 156
        Me.Label68.Text = "DFAC"
        '
        'BenthicBiomass
        '
        Me.BenthicBiomass.Location = New System.Drawing.Point(223, 286)
        Me.BenthicBiomass.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicBiomass.Name = "BenthicBiomass"
        Me.BenthicBiomass.Size = New System.Drawing.Size(100, 22)
        Me.BenthicBiomass.TabIndex = 147
        Me.BenthicBiomass.Text = "0.006"
        '
        'BenthicDOC
        '
        Me.BenthicDOC.Location = New System.Drawing.Point(223, 264)
        Me.BenthicDOC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicDOC.Name = "BenthicDOC"
        Me.BenthicDOC.Size = New System.Drawing.Size(100, 22)
        Me.BenthicDOC.TabIndex = 146
        Me.BenthicDOC.Text = "5.0"
        '
        'BenthicFoc
        '
        Me.BenthicFoc.Location = New System.Drawing.Point(223, 242)
        Me.BenthicFoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicFoc.Name = "BenthicFoc"
        Me.BenthicFoc.Size = New System.Drawing.Size(100, 22)
        Me.BenthicFoc.TabIndex = 145
        Me.BenthicFoc.Text = "0.04"
        '
        'BenthicBulkDensity
        '
        Me.BenthicBulkDensity.Location = New System.Drawing.Point(223, 220)
        Me.BenthicBulkDensity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicBulkDensity.Name = "BenthicBulkDensity"
        Me.BenthicBulkDensity.Size = New System.Drawing.Size(100, 22)
        Me.BenthicBulkDensity.TabIndex = 144
        Me.BenthicBulkDensity.Text = "1.35"
        '
        'BenthicPorosity
        '
        Me.BenthicPorosity.Location = New System.Drawing.Point(223, 198)
        Me.BenthicPorosity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicPorosity.Name = "BenthicPorosity"
        Me.BenthicPorosity.Size = New System.Drawing.Size(100, 22)
        Me.BenthicPorosity.TabIndex = 143
        Me.BenthicPorosity.Text = "0.50"
        '
        'BenthicDepth
        '
        Me.BenthicDepth.Location = New System.Drawing.Point(223, 175)
        Me.BenthicDepth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicDepth.Name = "BenthicDepth"
        Me.BenthicDepth.Size = New System.Drawing.Size(100, 22)
        Me.BenthicDepth.TabIndex = 142
        Me.BenthicDepth.Text = "0.05"
        '
        'DoverDx
        '
        Me.DoverDx.Location = New System.Drawing.Point(223, 154)
        Me.DoverDx.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DoverDx.Name = "DoverDx"
        Me.DoverDx.Size = New System.Drawing.Size(100, 22)
        Me.DoverDx.TabIndex = 141
        Me.DoverDx.Text = "1e-8"
        '
        'Label76
        '
        Me.Label76.AutoSize = True
        Me.Label76.Location = New System.Drawing.Point(52, 289)
        Me.Label76.Name = "Label76"
        Me.Label76.Size = New System.Drawing.Size(154, 17)
        Me.Label76.TabIndex = 154
        Me.Label76.Text = "Benthic Biomass (g/m²)"
        '
        'Label70
        '
        Me.Label70.AutoSize = True
        Me.Label70.Location = New System.Drawing.Point(72, 266)
        Me.Label70.Name = "Label70"
        Me.Label70.Size = New System.Drawing.Size(134, 17)
        Me.Label70.TabIndex = 153
        Me.Label70.Text = "Benthic DOC (mg/L)"
        '
        'Label71
        '
        Me.Label71.AutoSize = True
        Me.Label71.Location = New System.Drawing.Point(128, 246)
        Me.Label71.Name = "Label71"
        Me.Label71.Size = New System.Drawing.Size(78, 17)
        Me.Label71.TabIndex = 152
        Me.Label71.Text = "Benthic foc"
        '
        'Label67
        '
        Me.Label67.AutoSize = True
        Me.Label67.Location = New System.Drawing.Point(20, 223)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(186, 17)
        Me.Label67.TabIndex = 151
        Me.Label67.Text = "Benthic Bulk Density (g/cm³)"
        '
        'Label66
        '
        Me.Label66.AutoSize = True
        Me.Label66.Location = New System.Drawing.Point(96, 201)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(110, 17)
        Me.Label66.TabIndex = 150
        Me.Label66.Text = "Benthic Porosity"
        '
        'Label65
        '
        Me.Label65.AutoSize = True
        Me.Label65.Location = New System.Drawing.Point(76, 179)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(122, 17)
        Me.Label65.TabIndex = 149
        Me.Label65.Text = "Benthic Depth (m)"
        '
        'Label64
        '
        Me.Label64.AutoSize = True
        Me.Label64.Location = New System.Drawing.Point(133, 154)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(72, 17)
        Me.Label64.TabIndex = 148
        Me.Label64.Text = "D/dx (m/s)"
        '
        'spray14
        '
        Me.spray14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray14.Location = New System.Drawing.Point(207, 382)
        Me.spray14.Name = "spray14"
        Me.spray14.Size = New System.Drawing.Size(43, 22)
        Me.spray14.TabIndex = 232
        Me.spray14.Text = "0.0"
        '
        'spray13
        '
        Me.spray13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray13.Location = New System.Drawing.Point(207, 356)
        Me.spray13.Name = "spray13"
        Me.spray13.Size = New System.Drawing.Size(43, 22)
        Me.spray13.TabIndex = 231
        Me.spray13.Text = "1.0"
        '
        'Label126
        '
        Me.Label126.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label126.AutoSize = True
        Me.Label126.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label126.Location = New System.Drawing.Point(3, 385)
        Me.Label126.Name = "Label126"
        Me.Label126.Size = New System.Drawing.Size(52, 17)
        Me.Label126.TabIndex = 230
        Me.Label126.Text = "14. None"
        '
        'Label127
        '
        Me.Label127.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label127.AutoSize = True
        Me.Label127.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label127.Location = New System.Drawing.Point(3, 357)
        Me.Label127.Name = "Label127"
        Me.Label127.Size = New System.Drawing.Size(53, 17)
        Me.Label127.TabIndex = 229
        Me.Label127.Text = "13. Other"
        '
        'spray12
        '
        Me.spray12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray12.Location = New System.Drawing.Point(207, 330)
        Me.spray12.Name = "spray12"
        Me.spray12.Size = New System.Drawing.Size(43, 22)
        Me.spray12.TabIndex = 228
        Me.spray12.Text = "0.022"
        '
        'spray11
        '
        Me.spray11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray11.Location = New System.Drawing.Point(207, 304)
        Me.spray11.Name = "spray11"
        Me.spray11.Size = New System.Drawing.Size(43, 22)
        Me.spray11.TabIndex = 227
        Me.spray11.Text = "0.002"
        '
        'spray10
        '
        Me.spray10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray10.Location = New System.Drawing.Point(207, 278)
        Me.spray10.Name = "spray10"
        Me.spray10.Size = New System.Drawing.Size(43, 22)
        Me.spray10.TabIndex = 226
        Me.spray10.Text = "0.015"
        '
        'spray9
        '
        Me.spray9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray9.Location = New System.Drawing.Point(207, 252)
        Me.spray9.Name = "spray9"
        Me.spray9.Size = New System.Drawing.Size(43, 22)
        Me.spray9.TabIndex = 225
        Me.spray9.Text = "0.042"
        '
        'Label122
        '
        Me.Label122.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label122.AutoSize = True
        Me.Label122.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label122.Location = New System.Drawing.Point(3, 331)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(111, 17)
        Me.Label122.TabIndex = 224
        Me.Label122.Text = "12. Airblast(Orchard)"
        '
        'Label123
        '
        Me.Label123.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label123.AutoSize = True
        Me.Label123.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label123.Location = New System.Drawing.Point(3, 305)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(116, 17)
        Me.Label123.TabIndex = 223
        Me.Label123.Text = "11. Airblast (Vineyard)"
        '
        'Label124
        '
        Me.Label124.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label124.AutoSize = True
        Me.Label124.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label124.Location = New System.Drawing.Point(3, 279)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(105, 17)
        Me.Label124.TabIndex = 222
        Me.Label124.Text = "10. Airblast (Dense)"
        '
        'Label125
        '
        Me.Label125.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label125.AutoSize = True
        Me.Label125.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label125.Location = New System.Drawing.Point(3, 253)
        Me.Label125.Name = "Label125"
        Me.Label125.Size = New System.Drawing.Size(106, 17)
        Me.Label125.TabIndex = 221
        Me.Label125.Text = " 9. Airblast (Sparse)"
        '
        'Label118
        '
        Me.Label118.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label118.AutoSize = True
        Me.Label118.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label118.Location = New System.Drawing.Point(3, 227)
        Me.Label118.Name = "Label118"
        Me.Label118.Size = New System.Drawing.Size(167, 17)
        Me.Label118.TabIndex = 220
        Me.Label118.Text = " 8. Ground Low Boom (F to MC)"
        '
        'Label119
        '
        Me.Label119.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label119.AutoSize = True
        Me.Label119.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label119.Location = New System.Drawing.Point(3, 201)
        Me.Label119.Name = "Label119"
        Me.Label119.Size = New System.Drawing.Size(169, 17)
        Me.Label119.TabIndex = 219
        Me.Label119.Text = " 7. Ground High Boom (F to MC)"
        '
        'Label120
        '
        Me.Label120.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label120.AutoSize = True
        Me.Label120.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label120.Location = New System.Drawing.Point(3, 175)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(162, 17)
        Me.Label120.TabIndex = 218
        Me.Label120.Text = " 6. Ground Low Boom (VF to F)"
        '
        'Label121
        '
        Me.Label121.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label121.AutoSize = True
        Me.Label121.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label121.Location = New System.Drawing.Point(3, 149)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(178, 17)
        Me.Label121.TabIndex = 217
        Me.Label121.Text = " 5. Ground High Boom (VF to Fine)"
        '
        'spray8
        '
        Me.spray8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray8.Location = New System.Drawing.Point(207, 226)
        Me.spray8.Name = "spray8"
        Me.spray8.Size = New System.Drawing.Size(43, 22)
        Me.spray8.TabIndex = 216
        Me.spray8.Text = "0.0109"
        '
        'spray7
        '
        Me.spray7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray7.Location = New System.Drawing.Point(207, 200)
        Me.spray7.Name = "spray7"
        Me.spray7.Size = New System.Drawing.Size(43, 22)
        Me.spray7.TabIndex = 215
        Me.spray7.Text = "0.0165"
        '
        'spray6
        '
        Me.spray6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray6.Location = New System.Drawing.Point(207, 174)
        Me.spray6.Name = "spray6"
        Me.spray6.Size = New System.Drawing.Size(43, 22)
        Me.spray6.TabIndex = 214
        Me.spray6.Text = "0.027"
        '
        'spray5
        '
        Me.spray5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray5.Location = New System.Drawing.Point(207, 148)
        Me.spray5.Name = "spray5"
        Me.spray5.Size = New System.Drawing.Size(43, 22)
        Me.spray5.TabIndex = 213
        Me.spray5.Text = "0.0616"
        '
        'Label117
        '
        Me.Label117.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label117.AutoSize = True
        Me.Label117.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label117.Location = New System.Drawing.Point(3, 123)
        Me.Label117.Name = "Label117"
        Me.Label117.Size = New System.Drawing.Size(161, 17)
        Me.Label117.TabIndex = 212
        Me.Label117.Text = " 4. Aerial (Coarse to V. Coarse)"
        '
        'Label116
        '
        Me.Label116.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label116.AutoSize = True
        Me.Label116.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label116.Location = New System.Drawing.Point(3, 97)
        Me.Label116.Name = "Label116"
        Me.Label116.Size = New System.Drawing.Size(153, 17)
        Me.Label116.TabIndex = 211
        Me.Label116.Text = " 3. Aerial (Medium to Coarse)"
        '
        'Label115
        '
        Me.Label115.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label115.AutoSize = True
        Me.Label115.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label115.Location = New System.Drawing.Point(3, 71)
        Me.Label115.Name = "Label115"
        Me.Label115.Size = New System.Drawing.Size(138, 17)
        Me.Label115.TabIndex = 210
        Me.Label115.Text = " 2. Aerial (Fine to Medium)"
        '
        'Label114
        '
        Me.Label114.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label114.AutoSize = True
        Me.Label114.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label114.Location = New System.Drawing.Point(3, 45)
        Me.Label114.Name = "Label114"
        Me.Label114.Size = New System.Drawing.Size(144, 17)
        Me.Label114.TabIndex = 209
        Me.Label114.Text = " 1. Aerial (Very Fine to Fine)"
        '
        'spray4
        '
        Me.spray4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray4.Location = New System.Drawing.Point(207, 122)
        Me.spray4.Name = "spray4"
        Me.spray4.Size = New System.Drawing.Size(43, 22)
        Me.spray4.TabIndex = 205
        Me.spray4.Text = "0.068"
        '
        'spray3
        '
        Me.spray3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray3.Location = New System.Drawing.Point(207, 96)
        Me.spray3.Name = "spray3"
        Me.spray3.Size = New System.Drawing.Size(43, 22)
        Me.spray3.TabIndex = 204
        Me.spray3.Text = "0.0885"
        '
        'spray2
        '
        Me.spray2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray2.Location = New System.Drawing.Point(207, 70)
        Me.spray2.Name = "spray2"
        Me.spray2.Size = New System.Drawing.Size(43, 22)
        Me.spray2.TabIndex = 202
        Me.spray2.Text = "0.125"
        '
        'spray1
        '
        Me.spray1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray1.Location = New System.Drawing.Point(206, 43)
        Me.spray1.Margin = New System.Windows.Forms.Padding(0)
        Me.spray1.Name = "spray1"
        Me.spray1.Size = New System.Drawing.Size(45, 22)
        Me.spray1.TabIndex = 201
        Me.spray1.Text = "0.242"
        '
        'Label111
        '
        Me.Label111.AutoSize = True
        Me.Label111.Font = New System.Drawing.Font("Courier New", 7.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label111.Location = New System.Drawing.Point(19, 606)
        Me.Label111.Name = "Label111"
        Me.Label111.Size = New System.Drawing.Size(176, 16)
        Me.Label111.TabIndex = 200
        Me.Label111.Text = "Spray Drift Fractions"
        '
        'WeatherDirectoryBox
        '
        Me.WeatherDirectoryBox.Location = New System.Drawing.Point(146, 48)
        Me.WeatherDirectoryBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WeatherDirectoryBox.Name = "WeatherDirectoryBox"
        Me.WeatherDirectoryBox.Size = New System.Drawing.Size(723, 22)
        Me.WeatherDirectoryBox.TabIndex = 89
        '
        'GetWeatherFileDirectory
        '
        Me.GetWeatherFileDirectory.Location = New System.Drawing.Point(19, 33)
        Me.GetWeatherFileDirectory.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.GetWeatherFileDirectory.Name = "GetWeatherFileDirectory"
        Me.GetWeatherFileDirectory.Size = New System.Drawing.Size(109, 52)
        Me.GetWeatherFileDirectory.TabIndex = 88
        Me.GetWeatherFileDirectory.Text = "Weather File Directory"
        Me.GetWeatherFileDirectory.UseVisualStyleBackColor = True
        '
        'SchemeScenarios
        '
        Me.SchemeScenarios.Controls.Add(Me.ClearAllScenarios)
        Me.SchemeScenarios.Controls.Add(Me.ClearSelectedScenarios)
        Me.SchemeScenarios.Controls.Add(Me.SelectScenarios)
        Me.SchemeScenarios.Controls.Add(Me.ScenarioListBox)
        Me.SchemeScenarios.Controls.Add(Me.Label87)
        Me.SchemeScenarios.Controls.Add(Me.WeatherDirectoryBox)
        Me.SchemeScenarios.Controls.Add(Me.Label89)
        Me.SchemeScenarios.Controls.Add(Me.GetWeatherFileDirectory)
        Me.SchemeScenarios.Location = New System.Drawing.Point(4, 25)
        Me.SchemeScenarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SchemeScenarios.Name = "SchemeScenarios"
        Me.SchemeScenarios.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SchemeScenarios.Size = New System.Drawing.Size(929, 589)
        Me.SchemeScenarios.TabIndex = 8
        Me.SchemeScenarios.Text = "Scenarios"
        Me.SchemeScenarios.UseVisualStyleBackColor = True
        '
        'ClearAllScenarios
        '
        Me.ClearAllScenarios.BackColor = System.Drawing.Color.Wheat
        Me.ClearAllScenarios.Location = New System.Drawing.Point(19, 229)
        Me.ClearAllScenarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClearAllScenarios.Name = "ClearAllScenarios"
        Me.ClearAllScenarios.Size = New System.Drawing.Size(109, 47)
        Me.ClearAllScenarios.TabIndex = 15
        Me.ClearAllScenarios.Text = "Clear All"
        Me.ClearAllScenarios.UseVisualStyleBackColor = False
        '
        'ClearSelectedScenarios
        '
        Me.ClearSelectedScenarios.BackColor = System.Drawing.Color.Wheat
        Me.ClearSelectedScenarios.Location = New System.Drawing.Point(19, 177)
        Me.ClearSelectedScenarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClearSelectedScenarios.Name = "ClearSelectedScenarios"
        Me.ClearSelectedScenarios.Size = New System.Drawing.Size(109, 47)
        Me.ClearSelectedScenarios.TabIndex = 14
        Me.ClearSelectedScenarios.Text = "Clear Selected"
        Me.ClearSelectedScenarios.UseVisualStyleBackColor = False
        '
        'SelectScenarios
        '
        Me.SelectScenarios.BackColor = System.Drawing.Color.Wheat
        Me.SelectScenarios.Location = New System.Drawing.Point(19, 124)
        Me.SelectScenarios.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SelectScenarios.Name = "SelectScenarios"
        Me.SelectScenarios.Size = New System.Drawing.Size(109, 47)
        Me.SelectScenarios.TabIndex = 13
        Me.SelectScenarios.Text = "Select Scenarios"
        Me.SelectScenarios.UseVisualStyleBackColor = False
        '
        'ScenarioListBox
        '
        Me.ScenarioListBox.BackColor = System.Drawing.Color.PapayaWhip
        Me.ScenarioListBox.FormattingEnabled = True
        Me.ScenarioListBox.HorizontalScrollbar = True
        Me.ScenarioListBox.ItemHeight = 16
        Me.ScenarioListBox.Location = New System.Drawing.Point(146, 89)
        Me.ScenarioListBox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ScenarioListBox.Name = "ScenarioListBox"
        Me.ScenarioListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.ScenarioListBox.Size = New System.Drawing.Size(723, 244)
        Me.ScenarioListBox.TabIndex = 12
        '
        'Label87
        '
        Me.Label87.AutoSize = True
        Me.Label87.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label87.Location = New System.Drawing.Point(257, 11)
        Me.Label87.Name = "Label87"
        Me.Label87.Size = New System.Drawing.Size(68, 20)
        Me.Label87.TabIndex = 10
        Me.Label87.Text = "Label87"
        '
        'Label89
        '
        Me.Label89.AutoSize = True
        Me.Label89.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label89.Location = New System.Drawing.Point(15, 11)
        Me.Label89.Name = "Label89"
        Me.Label89.Size = New System.Drawing.Size(136, 20)
        Me.Label89.TabIndex = 11
        Me.Label89.Text = "Editing Scheme: "
        '
        'waterbodypanel
        '
        Me.waterbodypanel.Controls.Add(Me.ClearAllWaterBodies)
        Me.waterbodypanel.Controls.Add(Me.ClearSelectedWaterBody)
        Me.waterbodypanel.Controls.Add(Me.Button2)
        Me.waterbodypanel.Controls.Add(Me.WaterbodyList)
        Me.waterbodypanel.Location = New System.Drawing.Point(35, 167)
        Me.waterbodypanel.Name = "waterbodypanel"
        Me.waterbodypanel.Size = New System.Drawing.Size(815, 289)
        Me.waterbodypanel.TabIndex = 106
        '
        'ClearAllWaterBodies
        '
        Me.ClearAllWaterBodies.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClearAllWaterBodies.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearAllWaterBodies.ForeColor = System.Drawing.Color.Black
        Me.ClearAllWaterBodies.Location = New System.Drawing.Point(9, 107)
        Me.ClearAllWaterBodies.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClearAllWaterBodies.Name = "ClearAllWaterBodies"
        Me.ClearAllWaterBodies.Size = New System.Drawing.Size(126, 47)
        Me.ClearAllWaterBodies.TabIndex = 101
        Me.ClearAllWaterBodies.Text = "Clear All"
        Me.ClearAllWaterBodies.UseVisualStyleBackColor = False
        '
        'ClearSelectedWaterBody
        '
        Me.ClearSelectedWaterBody.BackColor = System.Drawing.Color.LightSkyBlue
        Me.ClearSelectedWaterBody.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ClearSelectedWaterBody.ForeColor = System.Drawing.Color.Black
        Me.ClearSelectedWaterBody.Location = New System.Drawing.Point(9, 57)
        Me.ClearSelectedWaterBody.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ClearSelectedWaterBody.Name = "ClearSelectedWaterBody"
        Me.ClearSelectedWaterBody.Size = New System.Drawing.Size(126, 47)
        Me.ClearSelectedWaterBody.TabIndex = 100
        Me.ClearSelectedWaterBody.Text = "Clear Selected"
        Me.ClearSelectedWaterBody.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LightSkyBlue
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.Black
        Me.Button2.Location = New System.Drawing.Point(9, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(126, 47)
        Me.Button2.TabIndex = 99
        Me.Button2.Text = "Select Special " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Water Bodies"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'WaterbodyList
        '
        Me.WaterbodyList.BackColor = System.Drawing.Color.AliceBlue
        Me.WaterbodyList.FormattingEnabled = True
        Me.WaterbodyList.HorizontalScrollbar = True
        Me.WaterbodyList.ItemHeight = 16
        Me.WaterbodyList.Location = New System.Drawing.Point(157, 7)
        Me.WaterbodyList.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterbodyList.Name = "WaterbodyList"
        Me.WaterbodyList.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.WaterbodyList.Size = New System.Drawing.Size(627, 260)
        Me.WaterbodyList.TabIndex = 98
        '
        'ItsOther
        '
        Me.ItsOther.AutoSize = True
        Me.ItsOther.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItsOther.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ItsOther.Location = New System.Drawing.Point(54, 130)
        Me.ItsOther.Name = "ItsOther"
        Me.ItsOther.Size = New System.Drawing.Size(79, 21)
        Me.ItsOther.TabIndex = 105
        Me.ItsOther.Text = "Others"
        Me.ItsOther.UseVisualStyleBackColor = True
        '
        'ItsaReservoir
        '
        Me.ItsaReservoir.AutoSize = True
        Me.ItsaReservoir.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItsaReservoir.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ItsaReservoir.Location = New System.Drawing.Point(54, 103)
        Me.ItsaReservoir.Name = "ItsaReservoir"
        Me.ItsaReservoir.Size = New System.Drawing.Size(239, 21)
        Me.ItsaReservoir.TabIndex = 104
        Me.ItsaReservoir.Text = "USEPA Reservoir Watershed"
        Me.ItsaReservoir.UseVisualStyleBackColor = True
        '
        'ItsaPond
        '
        Me.ItsaPond.AutoSize = True
        Me.ItsaPond.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ItsaPond.ForeColor = System.Drawing.Color.RoyalBlue
        Me.ItsaPond.Location = New System.Drawing.Point(54, 76)
        Me.ItsaPond.Name = "ItsaPond"
        Me.ItsaPond.Size = New System.Drawing.Size(206, 21)
        Me.ItsaPond.TabIndex = 103
        Me.ItsaPond.Text = "USEPA Pond Watershed"
        Me.ItsaPond.UseVisualStyleBackColor = True
        '
        'Label95
        '
        Me.Label95.AutoSize = True
        Me.Label95.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label95.ForeColor = System.Drawing.Color.RoyalBlue
        Me.Label95.Location = New System.Drawing.Point(274, 19)
        Me.Label95.Name = "Label95"
        Me.Label95.Size = New System.Drawing.Size(340, 25)
        Me.Label95.TabIndex = 102
        Me.Label95.Text = "Select the Watershed/Water Body"
        '
        'SchemeApplications
        '
        Me.SchemeApplications.Controls.Add(Me.Panel5)
        Me.SchemeApplications.Controls.Add(Me.Panel4)
        Me.SchemeApplications.Controls.Add(Me.Label88)
        Me.SchemeApplications.Controls.Add(Me.Label86)
        Me.SchemeApplications.Controls.Add(Me.Label9)
        Me.SchemeApplications.Controls.Add(Me.removal)
        Me.SchemeApplications.Controls.Add(Me.maturity)
        Me.SchemeApplications.Controls.Add(Me.emerge)
        Me.SchemeApplications.Controls.Add(Me.AbsoluteDaysButton)
        Me.SchemeApplications.Controls.Add(Me.AppTableDisplay)
        Me.SchemeApplications.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SchemeApplications.Location = New System.Drawing.Point(4, 25)
        Me.SchemeApplications.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SchemeApplications.Name = "SchemeApplications"
        Me.SchemeApplications.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SchemeApplications.Size = New System.Drawing.Size(929, 589)
        Me.SchemeApplications.TabIndex = 1
        Me.SchemeApplications.Text = "Applications"
        Me.SchemeApplications.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.UseApplicationWindow)
        Me.Panel5.Controls.Add(Me.Label113)
        Me.Panel5.Controls.Add(Me.Label112)
        Me.Panel5.Controls.Add(Me.ApplicationWindowStep)
        Me.Panel5.Controls.Add(Me.ApplicationWindowDays)
        Me.Panel5.Location = New System.Drawing.Point(36, 413)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(320, 171)
        Me.Panel5.TabIndex = 23
        '
        'UseApplicationWindow
        '
        Me.UseApplicationWindow.AutoSize = True
        Me.UseApplicationWindow.Location = New System.Drawing.Point(7, 10)
        Me.UseApplicationWindow.Name = "UseApplicationWindow"
        Me.UseApplicationWindow.Size = New System.Drawing.Size(283, 40)
        Me.UseApplicationWindow.TabIndex = 16
        Me.UseApplicationWindow.Text = " Use an application window to account" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " for application day uncertainty:"
        Me.UseApplicationWindow.UseVisualStyleBackColor = True
        '
        'Label113
        '
        Me.Label113.AutoSize = True
        Me.Label113.Location = New System.Drawing.Point(113, 107)
        Me.Label113.Name = "Label113"
        Me.Label113.Size = New System.Drawing.Size(83, 18)
        Me.Label113.TabIndex = 15
        Me.Label113.Text = "Step (days)"
        '
        'Label112
        '
        Me.Label112.AutoSize = True
        Me.Label112.Location = New System.Drawing.Point(113, 77)
        Me.Label112.Name = "Label112"
        Me.Label112.Size = New System.Drawing.Size(143, 18)
        Me.Label112.TabIndex = 14
        Me.Label112.Text = "Window span (days)"
        '
        'ApplicationWindowStep
        '
        Me.ApplicationWindowStep.Location = New System.Drawing.Point(7, 104)
        Me.ApplicationWindowStep.Name = "ApplicationWindowStep"
        Me.ApplicationWindowStep.Size = New System.Drawing.Size(100, 24)
        Me.ApplicationWindowStep.TabIndex = 13
        '
        'ApplicationWindowDays
        '
        Me.ApplicationWindowDays.Location = New System.Drawing.Point(7, 71)
        Me.ApplicationWindowDays.Name = "ApplicationWindowDays"
        Me.ApplicationWindowDays.Size = New System.Drawing.Size(100, 24)
        Me.ApplicationWindowDays.TabIndex = 12
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label344)
        Me.Panel4.Controls.Add(Me.Label342)
        Me.Panel4.Controls.Add(Me.Label343)
        Me.Panel4.Controls.Add(Me.Label341)
        Me.Panel4.Controls.Add(Me.MinDaysBetweenApps)
        Me.Panel4.Controls.Add(Me.OptimumApplicationWindow)
        Me.Panel4.Controls.Add(Me.IntolerableRainWindow)
        Me.Panel4.Controls.Add(Me.RainLimit)
        Me.Panel4.Controls.Add(Me.UseRainFast)
        Me.Panel4.Location = New System.Drawing.Point(492, 411)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(376, 173)
        Me.Panel4.TabIndex = 22
        '
        'Label344
        '
        Me.Label344.AutoSize = True
        Me.Label344.Location = New System.Drawing.Point(119, 133)
        Me.Label344.Name = "Label344"
        Me.Label344.Size = New System.Drawing.Size(251, 18)
        Me.Label344.TabIndex = 25
        Me.Label344.Text = "Minimum Days Between Applications"
        '
        'Label342
        '
        Me.Label342.AutoSize = True
        Me.Label342.Location = New System.Drawing.Point(119, 106)
        Me.Label342.Name = "Label342"
        Me.Label342.Size = New System.Drawing.Size(247, 18)
        Me.Label342.TabIndex = 24
        Me.Label342.Text = "Optimum Application Window (days)"
        '
        'Label343
        '
        Me.Label343.AutoSize = True
        Me.Label343.Location = New System.Drawing.Point(119, 79)
        Me.Label343.Name = "Label343"
        Me.Label343.Size = New System.Drawing.Size(212, 18)
        Me.Label343.TabIndex = 23
        Me.Label343.Text = "Intolerable Rain Window (days)"
        '
        'Label341
        '
        Me.Label341.AutoSize = True
        Me.Label341.Location = New System.Drawing.Point(119, 49)
        Me.Label341.Name = "Label341"
        Me.Label341.Size = New System.Drawing.Size(144, 18)
        Me.Label341.TabIndex = 22
        Me.Label341.Text = "Intolerable Rain (cm)"
        '
        'MinDaysBetweenApps
        '
        Me.MinDaysBetweenApps.Location = New System.Drawing.Point(13, 133)
        Me.MinDaysBetweenApps.Name = "MinDaysBetweenApps"
        Me.MinDaysBetweenApps.Size = New System.Drawing.Size(100, 24)
        Me.MinDaysBetweenApps.TabIndex = 21
        '
        'OptimumApplicationWindow
        '
        Me.OptimumApplicationWindow.Location = New System.Drawing.Point(13, 103)
        Me.OptimumApplicationWindow.Name = "OptimumApplicationWindow"
        Me.OptimumApplicationWindow.Size = New System.Drawing.Size(100, 24)
        Me.OptimumApplicationWindow.TabIndex = 20
        '
        'IntolerableRainWindow
        '
        Me.IntolerableRainWindow.Location = New System.Drawing.Point(13, 73)
        Me.IntolerableRainWindow.Name = "IntolerableRainWindow"
        Me.IntolerableRainWindow.Size = New System.Drawing.Size(100, 24)
        Me.IntolerableRainWindow.TabIndex = 19
        '
        'RainLimit
        '
        Me.RainLimit.Location = New System.Drawing.Point(13, 43)
        Me.RainLimit.Name = "RainLimit"
        Me.RainLimit.Size = New System.Drawing.Size(100, 24)
        Me.RainLimit.TabIndex = 18
        '
        'UseRainFast
        '
        Me.UseRainFast.AutoSize = True
        Me.UseRainFast.Location = New System.Drawing.Point(13, 12)
        Me.UseRainFast.Name = "UseRainFast"
        Me.UseRainFast.Size = New System.Drawing.Size(256, 22)
        Me.UseRainFast.TabIndex = 17
        Me.UseRainFast.Text = "Adjust Application Dates if Raining "
        Me.UseRainFast.UseVisualStyleBackColor = True
        '
        'Label88
        '
        Me.Label88.AutoSize = True
        Me.Label88.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label88.Location = New System.Drawing.Point(203, 15)
        Me.Label88.Name = "Label88"
        Me.Label88.Size = New System.Drawing.Size(146, 20)
        Me.Label88.TabIndex = 10
        Me.Label88.Text = "Scheme Unnamed"
        '
        'Label86
        '
        Me.Label86.AutoSize = True
        Me.Label86.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label86.Location = New System.Drawing.Point(8, 15)
        Me.Label86.Name = "Label86"
        Me.Label86.Size = New System.Drawing.Size(136, 20)
        Me.Label86.TabIndex = 9
        Me.Label86.Text = "Editing Scheme: "
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(143, 18)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Dates are relative to:"
        '
        'removal
        '
        Me.removal.AutoSize = True
        Me.removal.Location = New System.Drawing.Point(384, 71)
        Me.removal.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.removal.Name = "removal"
        Me.removal.Size = New System.Drawing.Size(88, 22)
        Me.removal.TabIndex = 5
        Me.removal.Text = "Removal"
        Me.removal.UseVisualStyleBackColor = True
        '
        'maturity
        '
        Me.maturity.AutoSize = True
        Me.maturity.Location = New System.Drawing.Point(286, 71)
        Me.maturity.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.maturity.Name = "maturity"
        Me.maturity.Size = New System.Drawing.Size(81, 22)
        Me.maturity.TabIndex = 4
        Me.maturity.Text = "Maturity"
        Me.maturity.UseVisualStyleBackColor = True
        '
        'emerge
        '
        Me.emerge.AutoSize = True
        Me.emerge.Checked = True
        Me.emerge.Location = New System.Drawing.Point(170, 71)
        Me.emerge.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.emerge.Name = "emerge"
        Me.emerge.Size = New System.Drawing.Size(105, 22)
        Me.emerge.TabIndex = 3
        Me.emerge.TabStop = True
        Me.emerge.Text = "Emergence"
        Me.emerge.UseVisualStyleBackColor = True
        '
        'AbsoluteDaysButton
        '
        Me.AbsoluteDaysButton.AutoSize = True
        Me.AbsoluteDaysButton.Location = New System.Drawing.Point(606, 72)
        Me.AbsoluteDaysButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AbsoluteDaysButton.Name = "AbsoluteDaysButton"
        Me.AbsoluteDaysButton.Size = New System.Drawing.Size(224, 22)
        Me.AbsoluteDaysButton.TabIndex = 1
        Me.AbsoluteDaysButton.Text = "Dates are absolute (mon/day)"
        Me.AbsoluteDaysButton.UseVisualStyleBackColor = True
        '
        'AppTableDisplay
        '
        Me.AppTableDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AppTableDisplay.Location = New System.Drawing.Point(9, 110)
        Me.AppTableDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AppTableDisplay.Name = "AppTableDisplay"
        Me.AppTableDisplay.RowHeadersVisible = False
        Me.AppTableDisplay.RowHeadersWidth = 51
        Me.AppTableDisplay.RowTemplate.Height = 24
        Me.AppTableDisplay.Size = New System.Drawing.Size(896, 283)
        Me.AppTableDisplay.TabIndex = 0
        '
        'Schemes
        '
        Me.Schemes.Controls.Add(Me.Label101)
        Me.Schemes.Controls.Add(Me.SchemeTableDisplay)
        Me.Schemes.Location = New System.Drawing.Point(4, 25)
        Me.Schemes.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Schemes.Name = "Schemes"
        Me.Schemes.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Schemes.Size = New System.Drawing.Size(929, 589)
        Me.Schemes.TabIndex = 7
        Me.Schemes.Text = "Schemes"
        Me.Schemes.UseVisualStyleBackColor = True
        '
        'Label101
        '
        Me.Label101.AutoSize = True
        Me.Label101.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label101.ForeColor = System.Drawing.Color.Purple
        Me.Label101.Location = New System.Drawing.Point(21, 19)
        Me.Label101.Name = "Label101"
        Me.Label101.Size = New System.Drawing.Size(781, 54)
        Me.Label101.TabIndex = 1
        Me.Label101.Text = resources.GetString("Label101.Text")
        '
        'SchemeTableDisplay
        '
        Me.SchemeTableDisplay.BackgroundColor = System.Drawing.SystemColors.ControlLightLight
        Me.SchemeTableDisplay.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.SchemeTableDisplay.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.SchemeTableDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SchemeTableDisplay.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column21, Me.Edit, Me.Commit, Me.Column24, Me.Delete})
        Me.SchemeTableDisplay.Location = New System.Drawing.Point(23, 88)
        Me.SchemeTableDisplay.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SchemeTableDisplay.Name = "SchemeTableDisplay"
        Me.SchemeTableDisplay.RowHeadersVisible = False
        Me.SchemeTableDisplay.RowHeadersWidth = 51
        Me.SchemeTableDisplay.RowTemplate.Height = 24
        Me.SchemeTableDisplay.Size = New System.Drawing.Size(787, 470)
        Me.SchemeTableDisplay.TabIndex = 0
        '
        'Column21
        '
        Me.Column21.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Column21.FillWeight = 8.0!
        Me.Column21.HeaderText = "No."
        Me.Column21.MinimumWidth = 6
        Me.Column21.Name = "Column21"
        Me.Column21.Width = 59
        '
        'Edit
        '
        Me.Edit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Edit.FillWeight = 10.0!
        Me.Edit.HeaderText = "Edit"
        Me.Edit.MinimumWidth = 6
        Me.Edit.Name = "Edit"
        Me.Edit.Width = 38
        '
        'Commit
        '
        Me.Commit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Commit.FillWeight = 15.0!
        Me.Commit.HeaderText = "Commit"
        Me.Commit.MinimumWidth = 6
        Me.Commit.Name = "Commit"
        Me.Commit.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Commit.Width = 60
        '
        'Column24
        '
        Me.Column24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column24.HeaderText = "Scheme Description"
        Me.Column24.MinimumWidth = 6
        Me.Column24.Name = "Column24"
        '
        'Delete
        '
        Me.Delete.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.Delete.FillWeight = 10.0!
        Me.Delete.HeaderText = "Delete"
        Me.Delete.MinimumWidth = 6
        Me.Delete.Name = "Delete"
        Me.Delete.Text = "X"
        Me.Delete.UseColumnTextForButtonValue = True
        Me.Delete.Width = 55
        '
        'Chemical
        '
        Me.Chemical.BackColor = System.Drawing.Color.LightCyan
        Me.Chemical.Controls.Add(Me.ChemPropertyPanel)
        Me.Chemical.Location = New System.Drawing.Point(4, 25)
        Me.Chemical.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Chemical.Name = "Chemical"
        Me.Chemical.Size = New System.Drawing.Size(929, 589)
        Me.Chemical.TabIndex = 0
        Me.Chemical.Text = "Chemical"
        '
        'ChemPropertyPanel
        '
        Me.ChemPropertyPanel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChemPropertyPanel.ColumnCount = 6
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.40767!))
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.77559!))
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.63278!))
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.77559!))
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.63278!))
        Me.ChemPropertyPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.77559!))
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarDeg3, 5, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarDeg2, 3, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilDegradation2, 3, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilRef2, 3, 10)
        Me.ChemPropertyPanel.Controls.Add(Me.Hydrolysis2, 3, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilDegradation3, 5, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.Hydrolysis3, 5, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.PhotoLat3, 5, 7)
        Me.ChemPropertyPanel.Controls.Add(Me.PhotoLat2, 3, 7)
        Me.ChemPropertyPanel.Controls.Add(Me.Photo3, 5, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicRef3, 5, 5)
        Me.ChemPropertyPanel.Controls.Add(Me.Photo2, 3, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicMetab2, 3, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicMetab3, 5, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicRef2, 3, 5)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColRef3, 5, 3)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColMetab3, 5, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColRef2, 3, 3)
        Me.ChemPropertyPanel.Controls.Add(Me.sorption3, 5, 1)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColMetab2, 3, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.sorption2, 3, 1)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilRef1, 1, 10)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilMolarRatio2, 4, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilMolarRatio1, 2, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.HydroMolarRatio2, 4, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.HydroMolarRatio1, 2, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilDegradation1, 1, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.Hydrolysis1, 1, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.PhotoLat1, 1, 7)
        Me.ChemPropertyPanel.Controls.Add(Me.Photo1, 1, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicRef1, 1, 5)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicMetab1, 1, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColRef1, 1, 3)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterColMetab1, 1, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.PhotoMolarRatio2, 4, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.PhotoMolarRatio1, 2, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicMolarRatio2, 4, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.BenthicMolarRatio1, 2, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterMolarRatio2, 4, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.Label20, 3, 0)
        Me.ChemPropertyPanel.Controls.Add(Me.Label19, 1, 0)
        Me.ChemPropertyPanel.Controls.Add(Me.sorption1, 1, 1)
        Me.ChemPropertyPanel.Controls.Add(Me.Label18, 5, 0)
        Me.ChemPropertyPanel.Controls.Add(Me.Label3, 0, 3)
        Me.ChemPropertyPanel.Controls.Add(Me.Label11, 0, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.Label10, 0, 10)
        Me.ChemPropertyPanel.Controls.Add(Me.WaterMolarRatio1, 2, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.Label8, 0, 8)
        Me.ChemPropertyPanel.Controls.Add(Me.Label7, 0, 7)
        Me.ChemPropertyPanel.Controls.Add(Me.Label6, 0, 6)
        Me.ChemPropertyPanel.Controls.Add(Me.Label4, 0, 4)
        Me.ChemPropertyPanel.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.ChemPropertyPanel.Controls.Add(Me.Label5, 0, 5)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarDeg1, 1, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.DoDegradate2, 4, 0)
        Me.ChemPropertyPanel.Controls.Add(Me.DoDegradate1, 2, 0)
        Me.ChemPropertyPanel.Controls.Add(Me.Label17, 0, 18)
        Me.ChemPropertyPanel.Controls.Add(Me.HeatHenry1, 1, 18)
        Me.ChemPropertyPanel.Controls.Add(Me.HeatHenry2, 3, 18)
        Me.ChemPropertyPanel.Controls.Add(Me.HeatHenry3, 5, 18)
        Me.ChemPropertyPanel.Controls.Add(Me.AirDiff3, 5, 17)
        Me.ChemPropertyPanel.Controls.Add(Me.AirDiff1, 1, 17)
        Me.ChemPropertyPanel.Controls.Add(Me.Henry1, 1, 16)
        Me.ChemPropertyPanel.Controls.Add(Me.Label16, 0, 17)
        Me.ChemPropertyPanel.Controls.Add(Me.Label14, 0, 15)
        Me.ChemPropertyPanel.Controls.Add(Me.Sol1, 1, 15)
        Me.ChemPropertyPanel.Controls.Add(Me.Henry2, 3, 16)
        Me.ChemPropertyPanel.Controls.Add(Me.Henry3, 5, 16)
        Me.ChemPropertyPanel.Controls.Add(Me.Sol3, 5, 15)
        Me.ChemPropertyPanel.Controls.Add(Me.VaporPress3, 5, 14)
        Me.ChemPropertyPanel.Controls.Add(Me.Sol2, 3, 15)
        Me.ChemPropertyPanel.Controls.Add(Me.VaporPress2, 3, 14)
        Me.ChemPropertyPanel.Controls.Add(Me.VaporPress1, 1, 14)
        Me.ChemPropertyPanel.Controls.Add(Me.Label13, 0, 14)
        Me.ChemPropertyPanel.Controls.Add(Me.Label12, 0, 13)
        Me.ChemPropertyPanel.Controls.Add(Me.MWT1, 1, 13)
        Me.ChemPropertyPanel.Controls.Add(Me.MWT2, 3, 13)
        Me.ChemPropertyPanel.Controls.Add(Me.MWT3, 5, 13)
        Me.ChemPropertyPanel.Controls.Add(Me.Label46, 0, 12)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarWashoff1, 1, 12)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarWashoff2, 3, 12)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarWashoff3, 5, 12)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarMolarRatio1, 2, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.FoliarMolarRatio2, 4, 11)
        Me.ChemPropertyPanel.Controls.Add(Me.EstimateHenryConst, 0, 16)
        Me.ChemPropertyPanel.Controls.Add(Me.TableLayoutPanel1, 0, 2)
        Me.ChemPropertyPanel.Controls.Add(Me.TableLayoutPanel2, 0, 9)
        Me.ChemPropertyPanel.Controls.Add(Me.AirDiff2, 3, 17)
        Me.ChemPropertyPanel.Controls.Add(Me.SoilRef3, 5, 10)
        Me.ChemPropertyPanel.Location = New System.Drawing.Point(3, 2)
        Me.ChemPropertyPanel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.ChemPropertyPanel.Name = "ChemPropertyPanel"
        Me.ChemPropertyPanel.RowCount = 19
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.558804!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.555364!))
        Me.ChemPropertyPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.ChemPropertyPanel.Size = New System.Drawing.Size(852, 571)
        Me.ChemPropertyPanel.TabIndex = 1
        '
        'FoliarDeg3
        '
        Me.FoliarDeg3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarDeg3.Location = New System.Drawing.Point(725, 334)
        Me.FoliarDeg3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarDeg3.Name = "FoliarDeg3"
        Me.FoliarDeg3.Size = New System.Drawing.Size(124, 22)
        Me.FoliarDeg3.TabIndex = 31
        Me.FoliarDeg3.Tag = "granddaughter foliar halflife."
        Me.FoliarDeg3.Visible = False
        '
        'FoliarDeg2
        '
        Me.FoliarDeg2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarDeg2.Location = New System.Drawing.Point(553, 334)
        Me.FoliarDeg2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarDeg2.Name = "FoliarDeg2"
        Me.FoliarDeg2.Size = New System.Drawing.Size(119, 22)
        Me.FoliarDeg2.TabIndex = 32
        Me.FoliarDeg2.Tag = "daughter foliar halflife."
        Me.FoliarDeg2.Visible = False
        '
        'SoilDegradation2
        '
        Me.SoilDegradation2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilDegradation2.Location = New System.Drawing.Point(553, 274)
        Me.SoilDegradation2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilDegradation2.Name = "SoilDegradation2"
        Me.SoilDegradation2.Size = New System.Drawing.Size(119, 22)
        Me.SoilDegradation2.TabIndex = 34
        Me.SoilDegradation2.Tag = "daughter soil halflife."
        Me.SoilDegradation2.Visible = False
        '
        'SoilRef2
        '
        Me.SoilRef2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilRef2.Location = New System.Drawing.Point(553, 304)
        Me.SoilRef2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilRef2.Name = "SoilRef2"
        Me.SoilRef2.Size = New System.Drawing.Size(119, 22)
        Me.SoilRef2.TabIndex = 31
        Me.SoilRef2.Tag = "daughter soil ref temp."
        Me.SoilRef2.Visible = False
        '
        'Hydrolysis2
        '
        Me.Hydrolysis2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Hydrolysis2.Location = New System.Drawing.Point(553, 244)
        Me.Hydrolysis2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Hydrolysis2.Name = "Hydrolysis2"
        Me.Hydrolysis2.Size = New System.Drawing.Size(119, 22)
        Me.Hydrolysis2.TabIndex = 32
        Me.Hydrolysis2.Tag = "daughter  hydrolysis."
        Me.Hydrolysis2.Visible = False
        '
        'SoilDegradation3
        '
        Me.SoilDegradation3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilDegradation3.Location = New System.Drawing.Point(725, 274)
        Me.SoilDegradation3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilDegradation3.Name = "SoilDegradation3"
        Me.SoilDegradation3.Size = New System.Drawing.Size(124, 22)
        Me.SoilDegradation3.TabIndex = 34
        Me.SoilDegradation3.Tag = "granddaughter soil halflife."
        Me.SoilDegradation3.Visible = False
        '
        'Hydrolysis3
        '
        Me.Hydrolysis3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Hydrolysis3.Location = New System.Drawing.Point(725, 244)
        Me.Hydrolysis3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Hydrolysis3.Name = "Hydrolysis3"
        Me.Hydrolysis3.Size = New System.Drawing.Size(124, 22)
        Me.Hydrolysis3.TabIndex = 35
        Me.Hydrolysis3.Tag = "granddaughter  hydrolysis."
        Me.Hydrolysis3.Visible = False
        '
        'PhotoLat3
        '
        Me.PhotoLat3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PhotoLat3.Location = New System.Drawing.Point(725, 214)
        Me.PhotoLat3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PhotoLat3.Name = "PhotoLat3"
        Me.PhotoLat3.Size = New System.Drawing.Size(124, 22)
        Me.PhotoLat3.TabIndex = 31
        Me.PhotoLat3.Tag = "granddaughter ref photolysis lat."
        Me.PhotoLat3.Visible = False
        '
        'PhotoLat2
        '
        Me.PhotoLat2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PhotoLat2.Location = New System.Drawing.Point(553, 214)
        Me.PhotoLat2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PhotoLat2.Name = "PhotoLat2"
        Me.PhotoLat2.Size = New System.Drawing.Size(119, 22)
        Me.PhotoLat2.TabIndex = 32
        Me.PhotoLat2.Tag = "daughter ref photolysis lat."
        Me.PhotoLat2.Visible = False
        '
        'Photo3
        '
        Me.Photo3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Photo3.Location = New System.Drawing.Point(725, 184)
        Me.Photo3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Photo3.Name = "Photo3"
        Me.Photo3.Size = New System.Drawing.Size(124, 22)
        Me.Photo3.TabIndex = 33
        Me.Photo3.Tag = "granddaughter photolysis."
        Me.Photo3.Visible = False
        '
        'BenthicRef3
        '
        Me.BenthicRef3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicRef3.Location = New System.Drawing.Point(725, 154)
        Me.BenthicRef3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicRef3.Name = "BenthicRef3"
        Me.BenthicRef3.Size = New System.Drawing.Size(124, 22)
        Me.BenthicRef3.TabIndex = 34
        Me.BenthicRef3.Tag = "granddaughter ref temp."
        Me.BenthicRef3.Visible = False
        '
        'Photo2
        '
        Me.Photo2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Photo2.Location = New System.Drawing.Point(553, 184)
        Me.Photo2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Photo2.Name = "Photo2"
        Me.Photo2.Size = New System.Drawing.Size(119, 22)
        Me.Photo2.TabIndex = 31
        Me.Photo2.Tag = "daughter photolysis."
        Me.Photo2.Visible = False
        '
        'BenthicMetab2
        '
        Me.BenthicMetab2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicMetab2.Location = New System.Drawing.Point(553, 124)
        Me.BenthicMetab2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicMetab2.Name = "BenthicMetab2"
        Me.BenthicMetab2.Size = New System.Drawing.Size(119, 22)
        Me.BenthicMetab2.TabIndex = 32
        Me.BenthicMetab2.Tag = "daughter benthic metabolism."
        Me.BenthicMetab2.Visible = False
        '
        'BenthicMetab3
        '
        Me.BenthicMetab3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicMetab3.Location = New System.Drawing.Point(725, 124)
        Me.BenthicMetab3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicMetab3.Name = "BenthicMetab3"
        Me.BenthicMetab3.Size = New System.Drawing.Size(124, 22)
        Me.BenthicMetab3.TabIndex = 33
        Me.BenthicMetab3.Tag = "granddaughter benthic metabolism."
        Me.BenthicMetab3.Visible = False
        '
        'BenthicRef2
        '
        Me.BenthicRef2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicRef2.Location = New System.Drawing.Point(553, 154)
        Me.BenthicRef2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicRef2.Name = "BenthicRef2"
        Me.BenthicRef2.Size = New System.Drawing.Size(119, 22)
        Me.BenthicRef2.TabIndex = 34
        Me.BenthicRef2.Tag = "daughter ref temp."
        Me.BenthicRef2.Visible = False
        '
        'WaterColRef3
        '
        Me.WaterColRef3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColRef3.Location = New System.Drawing.Point(725, 94)
        Me.WaterColRef3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColRef3.Name = "WaterColRef3"
        Me.WaterColRef3.Size = New System.Drawing.Size(124, 22)
        Me.WaterColRef3.TabIndex = 31
        Me.WaterColRef3.Tag = "granddaughter ref temp."
        Me.WaterColRef3.Visible = False
        '
        'WaterColMetab3
        '
        Me.WaterColMetab3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColMetab3.Location = New System.Drawing.Point(725, 64)
        Me.WaterColMetab3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColMetab3.Name = "WaterColMetab3"
        Me.WaterColMetab3.Size = New System.Drawing.Size(124, 22)
        Me.WaterColMetab3.TabIndex = 32
        Me.WaterColMetab3.Tag = "granddaughter water col halflife."
        Me.WaterColMetab3.Visible = False
        '
        'WaterColRef2
        '
        Me.WaterColRef2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColRef2.Location = New System.Drawing.Point(553, 94)
        Me.WaterColRef2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColRef2.Name = "WaterColRef2"
        Me.WaterColRef2.Size = New System.Drawing.Size(119, 22)
        Me.WaterColRef2.TabIndex = 33
        Me.WaterColRef2.Tag = "daughter ref temp."
        Me.WaterColRef2.Visible = False
        '
        'sorption3
        '
        Me.sorption3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sorption3.Location = New System.Drawing.Point(725, 34)
        Me.sorption3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sorption3.Name = "sorption3"
        Me.sorption3.Size = New System.Drawing.Size(124, 22)
        Me.sorption3.TabIndex = 31
        Me.sorption3.Visible = False
        '
        'WaterColMetab2
        '
        Me.WaterColMetab2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColMetab2.Location = New System.Drawing.Point(553, 64)
        Me.WaterColMetab2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColMetab2.Name = "WaterColMetab2"
        Me.WaterColMetab2.Size = New System.Drawing.Size(119, 22)
        Me.WaterColMetab2.TabIndex = 32
        Me.WaterColMetab2.Tag = "daughter water col halflife."
        Me.WaterColMetab2.Visible = False
        '
        'sorption2
        '
        Me.sorption2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sorption2.Location = New System.Drawing.Point(553, 34)
        Me.sorption2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sorption2.Name = "sorption2"
        Me.sorption2.Size = New System.Drawing.Size(119, 22)
        Me.sorption2.TabIndex = 33
        Me.sorption2.Tag = "daughter sorption."
        Me.sorption2.Visible = False
        '
        'SoilRef1
        '
        Me.SoilRef1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilRef1.Location = New System.Drawing.Point(381, 304)
        Me.SoilRef1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilRef1.Name = "SoilRef1"
        Me.SoilRef1.Size = New System.Drawing.Size(119, 22)
        Me.SoilRef1.TabIndex = 31
        Me.SoilRef1.Tag = "parent soil ref temp."
        '
        'SoilMolarRatio2
        '
        Me.SoilMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilMolarRatio2.BackColor = System.Drawing.SystemColors.Window
        Me.SoilMolarRatio2.Location = New System.Drawing.Point(678, 274)
        Me.SoilMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilMolarRatio2.Name = "SoilMolarRatio2"
        Me.SoilMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.SoilMolarRatio2.TabIndex = 67
        Me.ToolTip1.SetToolTip(Me.SoilMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.SoilMolarRatio2.Visible = False
        '
        'SoilMolarRatio1
        '
        Me.SoilMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.SoilMolarRatio1.Location = New System.Drawing.Point(506, 274)
        Me.SoilMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilMolarRatio1.Name = "SoilMolarRatio1"
        Me.SoilMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.SoilMolarRatio1.TabIndex = 68
        Me.SoilMolarRatio1.Tag = "molasr conversion soil/"
        Me.ToolTip1.SetToolTip(Me.SoilMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.SoilMolarRatio1.Visible = False
        '
        'HydroMolarRatio2
        '
        Me.HydroMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HydroMolarRatio2.BackColor = System.Drawing.SystemColors.Window
        Me.HydroMolarRatio2.Location = New System.Drawing.Point(678, 244)
        Me.HydroMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HydroMolarRatio2.Name = "HydroMolarRatio2"
        Me.HydroMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.HydroMolarRatio2.TabIndex = 69
        Me.ToolTip1.SetToolTip(Me.HydroMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.HydroMolarRatio2.Visible = False
        '
        'HydroMolarRatio1
        '
        Me.HydroMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HydroMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.HydroMolarRatio1.Location = New System.Drawing.Point(506, 244)
        Me.HydroMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HydroMolarRatio1.Name = "HydroMolarRatio1"
        Me.HydroMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.HydroMolarRatio1.TabIndex = 67
        Me.HydroMolarRatio1.Tag = "molar conversion hydro."
        Me.ToolTip1.SetToolTip(Me.HydroMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.HydroMolarRatio1.Visible = False
        '
        'SoilDegradation1
        '
        Me.SoilDegradation1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilDegradation1.Location = New System.Drawing.Point(381, 274)
        Me.SoilDegradation1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilDegradation1.Name = "SoilDegradation1"
        Me.SoilDegradation1.Size = New System.Drawing.Size(119, 22)
        Me.SoilDegradation1.TabIndex = 21
        Me.SoilDegradation1.Tag = "parent soil halflife."
        '
        'Hydrolysis1
        '
        Me.Hydrolysis1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Hydrolysis1.Location = New System.Drawing.Point(381, 244)
        Me.Hydrolysis1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Hydrolysis1.Name = "Hydrolysis1"
        Me.Hydrolysis1.Size = New System.Drawing.Size(119, 22)
        Me.Hydrolysis1.TabIndex = 24
        Me.Hydrolysis1.Tag = "parent  hydrolysis."
        '
        'PhotoLat1
        '
        Me.PhotoLat1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PhotoLat1.Location = New System.Drawing.Point(381, 214)
        Me.PhotoLat1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PhotoLat1.Name = "PhotoLat1"
        Me.PhotoLat1.Size = New System.Drawing.Size(119, 22)
        Me.PhotoLat1.TabIndex = 15
        Me.PhotoLat1.Tag = "parent ref photolysis lat."
        '
        'Photo1
        '
        Me.Photo1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Photo1.Location = New System.Drawing.Point(381, 184)
        Me.Photo1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Photo1.Name = "Photo1"
        Me.Photo1.Size = New System.Drawing.Size(119, 22)
        Me.Photo1.TabIndex = 18
        Me.Photo1.Tag = "parent photolysis."
        '
        'BenthicRef1
        '
        Me.BenthicRef1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicRef1.Location = New System.Drawing.Point(381, 154)
        Me.BenthicRef1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicRef1.Name = "BenthicRef1"
        Me.BenthicRef1.Size = New System.Drawing.Size(119, 22)
        Me.BenthicRef1.TabIndex = 9
        Me.BenthicRef1.Tag = "parent ref temp."
        '
        'BenthicMetab1
        '
        Me.BenthicMetab1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicMetab1.Location = New System.Drawing.Point(381, 124)
        Me.BenthicMetab1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicMetab1.Name = "BenthicMetab1"
        Me.BenthicMetab1.Size = New System.Drawing.Size(119, 22)
        Me.BenthicMetab1.TabIndex = 12
        Me.BenthicMetab1.Tag = "parent benthic metabolism."
        '
        'WaterColRef1
        '
        Me.WaterColRef1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColRef1.Location = New System.Drawing.Point(381, 94)
        Me.WaterColRef1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColRef1.Name = "WaterColRef1"
        Me.WaterColRef1.Size = New System.Drawing.Size(119, 22)
        Me.WaterColRef1.TabIndex = 6
        Me.WaterColRef1.Tag = "parent ref temp."
        '
        'WaterColMetab1
        '
        Me.WaterColMetab1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterColMetab1.Location = New System.Drawing.Point(381, 64)
        Me.WaterColMetab1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterColMetab1.Name = "WaterColMetab1"
        Me.WaterColMetab1.Size = New System.Drawing.Size(119, 22)
        Me.WaterColMetab1.TabIndex = 0
        Me.WaterColMetab1.Tag = "parents water col halflife."
        '
        'PhotoMolarRatio2
        '
        Me.PhotoMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PhotoMolarRatio2.BackColor = System.Drawing.SystemColors.Window
        Me.PhotoMolarRatio2.Location = New System.Drawing.Point(678, 184)
        Me.PhotoMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PhotoMolarRatio2.Name = "PhotoMolarRatio2"
        Me.PhotoMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.PhotoMolarRatio2.TabIndex = 68
        Me.ToolTip1.SetToolTip(Me.PhotoMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.PhotoMolarRatio2.Visible = False
        '
        'PhotoMolarRatio1
        '
        Me.PhotoMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PhotoMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.PhotoMolarRatio1.Location = New System.Drawing.Point(506, 184)
        Me.PhotoMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PhotoMolarRatio1.Name = "PhotoMolarRatio1"
        Me.PhotoMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.PhotoMolarRatio1.TabIndex = 69
        Me.PhotoMolarRatio1.Tag = "molar conversion photo."
        Me.ToolTip1.SetToolTip(Me.PhotoMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.PhotoMolarRatio1.Visible = False
        '
        'BenthicMolarRatio2
        '
        Me.BenthicMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicMolarRatio2.BackColor = System.Drawing.SystemColors.Window
        Me.BenthicMolarRatio2.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.BenthicMolarRatio2.Location = New System.Drawing.Point(678, 124)
        Me.BenthicMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicMolarRatio2.Name = "BenthicMolarRatio2"
        Me.BenthicMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.BenthicMolarRatio2.TabIndex = 67
        Me.ToolTip1.SetToolTip(Me.BenthicMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.BenthicMolarRatio2.Visible = False
        '
        'BenthicMolarRatio1
        '
        Me.BenthicMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BenthicMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.BenthicMolarRatio1.Location = New System.Drawing.Point(506, 124)
        Me.BenthicMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.BenthicMolarRatio1.Name = "BenthicMolarRatio1"
        Me.BenthicMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.BenthicMolarRatio1.TabIndex = 68
        Me.BenthicMolarRatio1.Tag = "molar conversion bentrhic."
        Me.ToolTip1.SetToolTip(Me.BenthicMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.BenthicMolarRatio1.Visible = False
        '
        'WaterMolarRatio2
        '
        Me.WaterMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterMolarRatio2.BackColor = System.Drawing.Color.White
        Me.WaterMolarRatio2.Location = New System.Drawing.Point(678, 64)
        Me.WaterMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterMolarRatio2.Name = "WaterMolarRatio2"
        Me.WaterMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.WaterMolarRatio2.TabIndex = 69
        Me.ToolTip1.SetToolTip(Me.WaterMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.WaterMolarRatio2.Visible = False
        '
        'Label20
        '
        Me.Label20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(575, 6)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 17)
        Me.Label20.TabIndex = 73
        Me.Label20.Text = "Daughter"
        '
        'Label19
        '
        Me.Label19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(412, 6)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 17)
        Me.Label19.TabIndex = 72
        Me.Label19.Text = "Parent"
        '
        'sorption1
        '
        Me.sorption1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.sorption1.Location = New System.Drawing.Point(381, 34)
        Me.sorption1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.sorption1.Name = "sorption1"
        Me.sorption1.Size = New System.Drawing.Size(119, 22)
        Me.sorption1.TabIndex = 30
        Me.sorption1.Tag = "parent sorption."
        '
        'Label18
        '
        Me.Label18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(727, 6)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(120, 17)
        Me.Label18.TabIndex = 74
        Me.Label18.Text = "GrandDaughter"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(144, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(231, 17)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Water Reference Temperature (°C)"
        '
        'Label11
        '
        Me.Label11.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(263, 336)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 17)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Foliar Halflife (d)"
        '
        'Label10
        '
        Me.Label10.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(159, 306)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(216, 17)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Soil Reference Temperature (°C)"
        '
        'WaterMolarRatio1
        '
        Me.WaterMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WaterMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.WaterMolarRatio1.Location = New System.Drawing.Point(506, 64)
        Me.WaterMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.WaterMolarRatio1.Name = "WaterMolarRatio1"
        Me.WaterMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.WaterMolarRatio1.TabIndex = 66
        Me.WaterMolarRatio1.Tag = "Molar Conversion Water Column."
        Me.ToolTip1.SetToolTip(Me.WaterMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.WaterMolarRatio1.Visible = False
        '
        'Label8
        '
        Me.Label8.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(233, 246)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(142, 17)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Hydrolysis Halflife (d)"
        '
        'Label7
        '
        Me.Label7.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(148, 216)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(227, 17)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Photolysis Reference Latitude (°N)"
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(174, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(201, 17)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Aqueous Photolysis Halflife (d)"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(179, 126)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(199, 17)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Benthic Metabolism Halflife (d)"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.17989!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.46032!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.09524!))
        Me.TableLayoutPanel4.Controls.Add(Me.RadioButton9, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.isKoc, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(0, 32)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 1
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(378, 26)
        Me.TableLayoutPanel4.TabIndex = 40
        '
        'RadioButton9
        '
        Me.RadioButton9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RadioButton9.AutoSize = True
        Me.RadioButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton9.Location = New System.Drawing.Point(187, 2)
        Me.RadioButton9.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioButton9.Name = "RadioButton9"
        Me.RadioButton9.Size = New System.Drawing.Size(43, 19)
        Me.RadioButton9.TabIndex = 38
        Me.RadioButton9.TabStop = True
        Me.RadioButton9.Text = "Kd"
        Me.RadioButton9.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.RadioButton9.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(274, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 17)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Sorption (ml/g)"
        '
        'isKoc
        '
        Me.isKoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.isKoc.AutoSize = True
        Me.isKoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.isKoc.Location = New System.Drawing.Point(115, 2)
        Me.isKoc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.isKoc.Name = "isKoc"
        Me.isKoc.Size = New System.Drawing.Size(49, 19)
        Me.isKoc.TabIndex = 39
        Me.isKoc.TabStop = True
        Me.isKoc.Text = "Koc"
        Me.isKoc.TextAlign = System.Drawing.ContentAlignment.TopLeft
        Me.isKoc.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(135, 156)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(240, 17)
        Me.Label5.TabIndex = 70
        Me.Label5.Text = "Benthic Reference Temperature (°C)"
        '
        'FoliarDeg1
        '
        Me.FoliarDeg1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarDeg1.Location = New System.Drawing.Point(381, 334)
        Me.FoliarDeg1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarDeg1.Name = "FoliarDeg1"
        Me.FoliarDeg1.Size = New System.Drawing.Size(119, 22)
        Me.FoliarDeg1.TabIndex = 33
        Me.FoliarDeg1.Tag = "parent foliar halflife."
        '
        'DoDegradate2
        '
        Me.DoDegradate2.AutoSize = True
        Me.DoDegradate2.Enabled = False
        Me.DoDegradate2.Font = New System.Drawing.Font("Symbol", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.DoDegradate2.Location = New System.Drawing.Point(678, 2)
        Me.DoDegradate2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DoDegradate2.Name = "DoDegradate2"
        Me.DoDegradate2.Size = New System.Drawing.Size(41, 21)
        Me.DoDegradate2.TabIndex = 81
        Me.DoDegradate2.Text = "®"
        Me.DoDegradate2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.DoDegradate2.UseVisualStyleBackColor = True
        '
        'DoDegradate1
        '
        Me.DoDegradate1.AutoSize = True
        Me.DoDegradate1.Font = New System.Drawing.Font("Symbol", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.DoDegradate1.Location = New System.Drawing.Point(506, 2)
        Me.DoDegradate1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.DoDegradate1.Name = "DoDegradate1"
        Me.DoDegradate1.Size = New System.Drawing.Size(41, 21)
        Me.DoDegradate1.TabIndex = 80
        Me.DoDegradate1.Text = "®"
        Me.DoDegradate1.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(232, 547)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(143, 17)
        Me.Label17.TabIndex = 75
        Me.Label17.Text = "Heat of Henry (J/mol)"
        '
        'HeatHenry1
        '
        Me.HeatHenry1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HeatHenry1.Location = New System.Drawing.Point(381, 544)
        Me.HeatHenry1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HeatHenry1.Name = "HeatHenry1"
        Me.HeatHenry1.Size = New System.Drawing.Size(119, 22)
        Me.HeatHenry1.TabIndex = 31
        Me.HeatHenry1.Tag = "parent heat of Henry."
        '
        'HeatHenry2
        '
        Me.HeatHenry2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HeatHenry2.Location = New System.Drawing.Point(553, 544)
        Me.HeatHenry2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HeatHenry2.Name = "HeatHenry2"
        Me.HeatHenry2.Size = New System.Drawing.Size(119, 22)
        Me.HeatHenry2.TabIndex = 32
        Me.HeatHenry2.Tag = "daughter heat of Henry."
        Me.HeatHenry2.Visible = False
        '
        'HeatHenry3
        '
        Me.HeatHenry3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.HeatHenry3.Location = New System.Drawing.Point(725, 544)
        Me.HeatHenry3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.HeatHenry3.Name = "HeatHenry3"
        Me.HeatHenry3.Size = New System.Drawing.Size(124, 22)
        Me.HeatHenry3.TabIndex = 33
        Me.HeatHenry3.Tag = "granddaughter heat of Henry."
        Me.HeatHenry3.Visible = False
        '
        'AirDiff3
        '
        Me.AirDiff3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AirDiff3.Location = New System.Drawing.Point(725, 514)
        Me.AirDiff3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AirDiff3.Name = "AirDiff3"
        Me.AirDiff3.Size = New System.Drawing.Size(124, 22)
        Me.AirDiff3.TabIndex = 32
        Me.AirDiff3.Tag = "granddaughter air diff coef.."
        Me.AirDiff3.Visible = False
        '
        'AirDiff1
        '
        Me.AirDiff1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AirDiff1.Location = New System.Drawing.Point(381, 514)
        Me.AirDiff1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AirDiff1.Name = "AirDiff1"
        Me.AirDiff1.Size = New System.Drawing.Size(119, 22)
        Me.AirDiff1.TabIndex = 31
        Me.AirDiff1.Tag = "parent air diff coef.."
        '
        'Henry1
        '
        Me.Henry1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Henry1.Location = New System.Drawing.Point(381, 484)
        Me.Henry1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Henry1.Name = "Henry1"
        Me.Henry1.Size = New System.Drawing.Size(119, 22)
        Me.Henry1.TabIndex = 32
        Me.Henry1.Tag = "parent Henry's coefficient."
        '
        'Label16
        '
        Me.Label16.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(157, 516)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(218, 17)
        Me.Label16.TabIndex = 55
        Me.Label16.Text = "Air Diffusion Coefficient (cm²/day)"
        '
        'Label14
        '
        Me.Label14.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(266, 456)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 17)
        Me.Label14.TabIndex = 53
        Me.Label14.Text = "Solubility (mg/L)"
        '
        'Sol1
        '
        Me.Sol1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sol1.Location = New System.Drawing.Point(381, 454)
        Me.Sol1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Sol1.Name = "Sol1"
        Me.Sol1.Size = New System.Drawing.Size(119, 22)
        Me.Sol1.TabIndex = 33
        Me.Sol1.Tag = "parent sol."
        '
        'Henry2
        '
        Me.Henry2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Henry2.Location = New System.Drawing.Point(553, 484)
        Me.Henry2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Henry2.Name = "Henry2"
        Me.Henry2.Size = New System.Drawing.Size(119, 22)
        Me.Henry2.TabIndex = 32
        Me.Henry2.Tag = "daughter Henry's coefficient."
        Me.Henry2.Visible = False
        '
        'Henry3
        '
        Me.Henry3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Henry3.Location = New System.Drawing.Point(725, 484)
        Me.Henry3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Henry3.Name = "Henry3"
        Me.Henry3.Size = New System.Drawing.Size(124, 22)
        Me.Henry3.TabIndex = 33
        Me.Henry3.Tag = "granddaughter Henry's coefficient."
        Me.Henry3.Visible = False
        '
        'Sol3
        '
        Me.Sol3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sol3.Location = New System.Drawing.Point(725, 454)
        Me.Sol3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Sol3.Name = "Sol3"
        Me.Sol3.Size = New System.Drawing.Size(124, 22)
        Me.Sol3.TabIndex = 34
        Me.Sol3.Tag = "granddaughter sol."
        Me.Sol3.Visible = False
        '
        'VaporPress3
        '
        Me.VaporPress3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VaporPress3.Location = New System.Drawing.Point(725, 424)
        Me.VaporPress3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VaporPress3.Name = "VaporPress3"
        Me.VaporPress3.Size = New System.Drawing.Size(124, 22)
        Me.VaporPress3.TabIndex = 35
        Me.VaporPress3.Tag = "granddaughter vp."
        Me.VaporPress3.Visible = False
        '
        'Sol2
        '
        Me.Sol2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Sol2.Location = New System.Drawing.Point(553, 454)
        Me.Sol2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Sol2.Name = "Sol2"
        Me.Sol2.Size = New System.Drawing.Size(119, 22)
        Me.Sol2.TabIndex = 33
        Me.Sol2.Tag = "daughter sol."
        Me.Sol2.Visible = False
        '
        'VaporPress2
        '
        Me.VaporPress2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VaporPress2.Location = New System.Drawing.Point(553, 424)
        Me.VaporPress2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VaporPress2.Name = "VaporPress2"
        Me.VaporPress2.Size = New System.Drawing.Size(119, 22)
        Me.VaporPress2.TabIndex = 34
        Me.VaporPress2.Tag = "daughter vp."
        Me.VaporPress2.Visible = False
        '
        'VaporPress1
        '
        Me.VaporPress1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VaporPress1.Location = New System.Drawing.Point(381, 424)
        Me.VaporPress1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.VaporPress1.Name = "VaporPress1"
        Me.VaporPress1.Size = New System.Drawing.Size(119, 22)
        Me.VaporPress1.TabIndex = 34
        Me.VaporPress1.Tag = "parent vp."
        '
        'Label13
        '
        Me.Label13.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(232, 426)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(143, 17)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Vapor Pressure (torr)"
        '
        'Label12
        '
        Me.Label12.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(210, 396)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(165, 17)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Molecular Weight (g/mol)"
        '
        'MWT1
        '
        Me.MWT1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MWT1.Location = New System.Drawing.Point(381, 394)
        Me.MWT1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MWT1.Name = "MWT1"
        Me.MWT1.Size = New System.Drawing.Size(119, 22)
        Me.MWT1.TabIndex = 35
        Me.MWT1.Tag = "parent mwt."
        '
        'MWT2
        '
        Me.MWT2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MWT2.Location = New System.Drawing.Point(553, 394)
        Me.MWT2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MWT2.Name = "MWT2"
        Me.MWT2.Size = New System.Drawing.Size(119, 22)
        Me.MWT2.TabIndex = 31
        Me.MWT2.Tag = "daughter mwt."
        Me.MWT2.Visible = False
        '
        'MWT3
        '
        Me.MWT3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MWT3.Location = New System.Drawing.Point(725, 394)
        Me.MWT3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MWT3.Name = "MWT3"
        Me.MWT3.Size = New System.Drawing.Size(124, 22)
        Me.MWT3.TabIndex = 36
        Me.MWT3.Tag = "granddaughter mwt."
        Me.MWT3.Visible = False
        '
        'Label46
        '
        Me.Label46.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label46.AutoSize = True
        Me.Label46.Location = New System.Drawing.Point(234, 366)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(141, 17)
        Me.Label46.TabIndex = 82
        Me.Label46.Text = "Foliar Washoff (cm⁻¹)"
        '
        'FoliarWashoff1
        '
        Me.FoliarWashoff1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarWashoff1.Location = New System.Drawing.Point(381, 364)
        Me.FoliarWashoff1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarWashoff1.Name = "FoliarWashoff1"
        Me.FoliarWashoff1.Size = New System.Drawing.Size(119, 22)
        Me.FoliarWashoff1.TabIndex = 83
        Me.FoliarWashoff1.Tag = "parent foliar washoff."
        Me.FoliarWashoff1.Text = "0.5"
        '
        'FoliarWashoff2
        '
        Me.FoliarWashoff2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarWashoff2.Location = New System.Drawing.Point(553, 364)
        Me.FoliarWashoff2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarWashoff2.Name = "FoliarWashoff2"
        Me.FoliarWashoff2.Size = New System.Drawing.Size(119, 22)
        Me.FoliarWashoff2.TabIndex = 84
        Me.FoliarWashoff2.Tag = "daughter foliar washoff."
        Me.FoliarWashoff2.Text = "0.5"
        Me.FoliarWashoff2.Visible = False
        '
        'FoliarWashoff3
        '
        Me.FoliarWashoff3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarWashoff3.Location = New System.Drawing.Point(725, 364)
        Me.FoliarWashoff3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarWashoff3.Name = "FoliarWashoff3"
        Me.FoliarWashoff3.Size = New System.Drawing.Size(124, 22)
        Me.FoliarWashoff3.TabIndex = 85
        Me.FoliarWashoff3.Tag = "granddaughter foliar washoff."
        Me.FoliarWashoff3.Text = "0.5"
        Me.FoliarWashoff3.Visible = False
        '
        'FoliarMolarRatio1
        '
        Me.FoliarMolarRatio1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarMolarRatio1.BackColor = System.Drawing.SystemColors.Window
        Me.FoliarMolarRatio1.Location = New System.Drawing.Point(506, 334)
        Me.FoliarMolarRatio1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarMolarRatio1.Name = "FoliarMolarRatio1"
        Me.FoliarMolarRatio1.Size = New System.Drawing.Size(41, 22)
        Me.FoliarMolarRatio1.TabIndex = 86
        Me.FoliarMolarRatio1.Tag = "molar conversion foliar."
        Me.ToolTip1.SetToolTip(Me.FoliarMolarRatio1, "Moles of daughter produced per mole of parent degraded")
        Me.FoliarMolarRatio1.Visible = False
        '
        'FoliarMolarRatio2
        '
        Me.FoliarMolarRatio2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FoliarMolarRatio2.BackColor = System.Drawing.SystemColors.Window
        Me.FoliarMolarRatio2.Location = New System.Drawing.Point(678, 334)
        Me.FoliarMolarRatio2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FoliarMolarRatio2.Name = "FoliarMolarRatio2"
        Me.FoliarMolarRatio2.Size = New System.Drawing.Size(41, 22)
        Me.FoliarMolarRatio2.TabIndex = 87
        Me.ToolTip1.SetToolTip(Me.FoliarMolarRatio2, "Moles of granddaughter produced per mole of daughter degraded")
        Me.FoliarMolarRatio2.Visible = False
        '
        'EstimateHenryConst
        '
        Me.EstimateHenryConst.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.EstimateHenryConst.BackColor = System.Drawing.SystemColors.Info
        Me.EstimateHenryConst.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EstimateHenryConst.Location = New System.Drawing.Point(0, 482)
        Me.EstimateHenryConst.Margin = New System.Windows.Forms.Padding(0)
        Me.EstimateHenryConst.Name = "EstimateHenryConst"
        Me.EstimateHenryConst.Size = New System.Drawing.Size(378, 25)
        Me.EstimateHenryConst.TabIndex = 79
        Me.EstimateHenryConst.Text = "(Enter or Push to estimate) Henry's Coefficient (vol/vol)"
        Me.EstimateHenryConst.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.EstimateHenryConst.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.50265!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.49735!))
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 60)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(378, 30)
        Me.TableLayoutPanel1.TabIndex = 88
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(212, 6)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(166, 17)
        Me.Label2.TabIndex = 69
        Me.Label2.Text = "Water Column Halflife (d)"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.96535!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.6412!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.39344!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label63, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IsAqueousDegradation, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.IsAllMedia, 1, 0)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 270)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(378, 30)
        Me.TableLayoutPanel2.TabIndex = 89
        '
        'Label63
        '
        Me.Label63.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label63.AutoSize = True
        Me.Label63.Location = New System.Drawing.Point(275, 6)
        Me.Label63.Name = "Label63"
        Me.Label63.Size = New System.Drawing.Size(100, 17)
        Me.Label63.TabIndex = 69
        Me.Label63.Text = "Soil Halflife (d)"
        '
        'IsAqueousDegradation
        '
        Me.IsAqueousDegradation.AutoSize = True
        Me.IsAqueousDegradation.Location = New System.Drawing.Point(112, 2)
        Me.IsAqueousDegradation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IsAqueousDegradation.Name = "IsAqueousDegradation"
        Me.IsAqueousDegradation.Size = New System.Drawing.Size(118, 21)
        Me.IsAqueousDegradation.TabIndex = 71
        Me.IsAqueousDegradation.Text = "Aqueous Only"
        Me.IsAqueousDegradation.UseVisualStyleBackColor = True
        '
        'IsAllMedia
        '
        Me.IsAllMedia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.IsAllMedia.AutoSize = True
        Me.IsAllMedia.Checked = True
        Me.IsAllMedia.Location = New System.Drawing.Point(45, 2)
        Me.IsAllMedia.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.IsAllMedia.Name = "IsAllMedia"
        Me.IsAllMedia.Size = New System.Drawing.Size(61, 21)
        Me.IsAllMedia.TabIndex = 72
        Me.IsAllMedia.TabStop = True
        Me.IsAllMedia.Text = "Total"
        Me.IsAllMedia.UseVisualStyleBackColor = True
        '
        'AirDiff2
        '
        Me.AirDiff2.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AirDiff2.Location = New System.Drawing.Point(553, 514)
        Me.AirDiff2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.AirDiff2.Name = "AirDiff2"
        Me.AirDiff2.Size = New System.Drawing.Size(119, 22)
        Me.AirDiff2.TabIndex = 31
        Me.AirDiff2.Tag = "daughter air diff coef.."
        Me.AirDiff2.Visible = False
        '
        'SoilRef3
        '
        Me.SoilRef3.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SoilRef3.Location = New System.Drawing.Point(725, 304)
        Me.SoilRef3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SoilRef3.Name = "SoilRef3"
        Me.SoilRef3.Size = New System.Drawing.Size(124, 22)
        Me.SoilRef3.TabIndex = 33
        Me.SoilRef3.Tag = "granddaughter soil ref temp."
        Me.SoilRef3.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.Chemical)
        Me.TabControl1.Controls.Add(Me.WatershedTab)
        Me.TabControl1.Controls.Add(Me.Schemes)
        Me.TabControl1.Controls.Add(Me.SchemeApplications)
        Me.TabControl1.Controls.Add(Me.SchemeScenarios)
        Me.TabControl1.Controls.Add(Me.AdvancedTab)
        Me.TabControl1.Controls.Add(Me.ScenarioExaminerTab)
        Me.TabControl1.Controls.Add(Me.OptionalOutputTab)
        Me.TabControl1.Controls.Add(Me.WaterbodyExaminerTab)
        Me.TabControl1.Location = New System.Drawing.Point(2, 32)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(953, 618)
        Me.TabControl1.TabIndex = 0
        '
        'WatershedTab
        '
        Me.WatershedTab.Controls.Add(Me.Label95)
        Me.WatershedTab.Controls.Add(Me.waterbodypanel)
        Me.WatershedTab.Controls.Add(Me.ItsOther)
        Me.WatershedTab.Controls.Add(Me.ItsaReservoir)
        Me.WatershedTab.Controls.Add(Me.ItsaPond)
        Me.WatershedTab.Location = New System.Drawing.Point(4, 25)
        Me.WatershedTab.Name = "WatershedTab"
        Me.WatershedTab.Padding = New System.Windows.Forms.Padding(3)
        Me.WatershedTab.Size = New System.Drawing.Size(929, 589)
        Me.WatershedTab.TabIndex = 9
        Me.WatershedTab.Text = "Watershed/Waterbody"
        Me.WatershedTab.UseVisualStyleBackColor = True
        '
        'OptionalOutputTab
        '
        Me.OptionalOutputTab.BackColor = System.Drawing.Color.Yellow
        Me.OptionalOutputTab.Controls.Add(Me.Label128)
        Me.OptionalOutputTab.Controls.Add(Me.outputWaterConc)
        Me.OptionalOutputTab.Controls.Add(Me.OutputInfiltrationDepth)
        Me.OptionalOutputTab.Controls.Add(Me.OutputDailyPestLeached)
        Me.OptionalOutputTab.Controls.Add(Me.Label105)
        Me.OptionalOutputTab.Controls.Add(Me.chemInfiltrationDepth)
        Me.OptionalOutputTab.Controls.Add(Me.Label104)
        Me.OptionalOutputTab.Controls.Add(Me.AdditionalOutputGridView)
        Me.OptionalOutputTab.Controls.Add(Me.OutputMassDepth1)
        Me.OptionalOutputTab.Controls.Add(Me.OutputDecayDepth2)
        Me.OptionalOutputTab.Controls.Add(Me.OutputDecayDepth1)
        Me.OptionalOutputTab.Controls.Add(Me.OutputMassDepth2)
        Me.OptionalOutputTab.Controls.Add(Me.Label102)
        Me.OptionalOutputTab.Controls.Add(Me.outputInfiltratedWaterLastLayer)
        Me.OptionalOutputTab.Controls.Add(Me.outputConcLastLayer)
        Me.OptionalOutputTab.Controls.Add(Me.outputPestErosion)
        Me.OptionalOutputTab.Controls.Add(Me.outputErosion)
        Me.OptionalOutputTab.Controls.Add(Me.outputPestRunoff)
        Me.OptionalOutputTab.Controls.Add(Me.outputRunoff)
        Me.OptionalOutputTab.Controls.Add(Me.Label293)
        Me.OptionalOutputTab.Controls.Add(Me.Label294)
        Me.OptionalOutputTab.Controls.Add(Me.Label288)
        Me.OptionalOutputTab.Controls.Add(Me.Label289)
        Me.OptionalOutputTab.Controls.Add(Me.Label286)
        Me.OptionalOutputTab.Controls.Add(Me.Label285)
        Me.OptionalOutputTab.Controls.Add(Me.outputPrecipitation)
        Me.OptionalOutputTab.Controls.Add(Me.outputIrrigation)
        Me.OptionalOutputTab.Controls.Add(Me.Label284)
        Me.OptionalOutputTab.Controls.Add(Me.outputInfiltrationAtDepth)
        Me.OptionalOutputTab.Controls.Add(Me.outputTotalSoilWater)
        Me.OptionalOutputTab.Controls.Add(Me.outputActualEvap)
        Me.OptionalOutputTab.Controls.Add(Me.outputMassSoilSpecific)
        Me.OptionalOutputTab.Controls.Add(Me.OutputDecayedPest)
        Me.OptionalOutputTab.Controls.Add(Me.outputMassOnFoliage)
        Me.OptionalOutputTab.Controls.Add(Me.outputMassInSoilProfile)
        Me.OptionalOutputTab.Controls.Add(Me.outputDailyFieldVolatilization)
        Me.OptionalOutputTab.Location = New System.Drawing.Point(4, 25)
        Me.OptionalOutputTab.Name = "OptionalOutputTab"
        Me.OptionalOutputTab.Padding = New System.Windows.Forms.Padding(3)
        Me.OptionalOutputTab.Size = New System.Drawing.Size(929, 589)
        Me.OptionalOutputTab.TabIndex = 10
        Me.OptionalOutputTab.Text = "Optional Output"
        '
        'Label128
        '
        Me.Label128.AutoSize = True
        Me.Label128.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label128.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label128.Location = New System.Drawing.Point(29, 480)
        Me.Label128.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label128.Name = "Label128"
        Me.Label128.Size = New System.Drawing.Size(443, 20)
        Me.Label128.TabIndex = 86
        Me.Label128.Text = "Optional Daily Waterbody Output to a water.out File"
        '
        'outputWaterConc
        '
        Me.outputWaterConc.AutoSize = True
        Me.outputWaterConc.Location = New System.Drawing.Point(33, 513)
        Me.outputWaterConc.Margin = New System.Windows.Forms.Padding(4)
        Me.outputWaterConc.Name = "outputWaterConc"
        Me.outputWaterConc.Size = New System.Drawing.Size(476, 21)
        Me.outputWaterConc.TabIndex = 83
        Me.outputWaterConc.Text = "Waterbody depth, concentration, and benthic pore water concentration"
        Me.outputWaterConc.UseVisualStyleBackColor = True
        '
        'OutputInfiltrationDepth
        '
        Me.OutputInfiltrationDepth.Location = New System.Drawing.Point(791, 177)
        Me.OutputInfiltrationDepth.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputInfiltrationDepth.Name = "OutputInfiltrationDepth"
        Me.OutputInfiltrationDepth.Size = New System.Drawing.Size(44, 22)
        Me.OutputInfiltrationDepth.TabIndex = 58
        Me.OutputInfiltrationDepth.Tag = "user-specified infiltration depth output."
        '
        'OutputDailyPestLeached
        '
        Me.OutputDailyPestLeached.AutoSize = True
        Me.OutputDailyPestLeached.Location = New System.Drawing.Point(29, 91)
        Me.OutputDailyPestLeached.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputDailyPestLeached.Name = "OutputDailyPestLeached"
        Me.OutputDailyPestLeached.Size = New System.Drawing.Size(300, 21)
        Me.OutputDailyPestLeached.TabIndex = 48
        Me.OutputDailyPestLeached.Text = "Daily pesticide leached (kg/ha) at depth of "
        Me.OutputDailyPestLeached.UseVisualStyleBackColor = True
        '
        'Label105
        '
        Me.Label105.AutoSize = True
        Me.Label105.Location = New System.Drawing.Point(397, 92)
        Me.Label105.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label105.Name = "Label105"
        Me.Label105.Size = New System.Drawing.Size(26, 17)
        Me.Label105.TabIndex = 82
        Me.Label105.Text = "cm"
        '
        'chemInfiltrationDepth
        '
        Me.chemInfiltrationDepth.Location = New System.Drawing.Point(343, 89)
        Me.chemInfiltrationDepth.Margin = New System.Windows.Forms.Padding(4)
        Me.chemInfiltrationDepth.Name = "chemInfiltrationDepth"
        Me.chemInfiltrationDepth.Size = New System.Drawing.Size(44, 22)
        Me.chemInfiltrationDepth.TabIndex = 81
        Me.chemInfiltrationDepth.Tag = "user-specified infiltration depth output."
        '
        'Label104
        '
        Me.Label104.AutoSize = True
        Me.Label104.Location = New System.Drawing.Point(26, 238)
        Me.Label104.Name = "Label104"
        Me.Label104.Size = New System.Drawing.Size(746, 17)
        Me.Label104.TabIndex = 80
        Me.Label104.Text = "Include any other desired output using  traditional PRZM time series specificatio" &
    "ns (Example: TPST, TCUM,1, 60, 1.0)"
        '
        'AdditionalOutputGridView
        '
        Me.AdditionalOutputGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.AdditionalOutputGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Item, Me.Column10, Me.Mode, Me.Bound1, Me.Bound2, Me.Column11, Me.Column12})
        Me.AdditionalOutputGridView.Location = New System.Drawing.Point(28, 258)
        Me.AdditionalOutputGridView.Name = "AdditionalOutputGridView"
        Me.AdditionalOutputGridView.RowHeadersVisible = False
        Me.AdditionalOutputGridView.RowHeadersWidth = 51
        Me.AdditionalOutputGridView.RowTemplate.Height = 24
        Me.AdditionalOutputGridView.Size = New System.Drawing.Size(583, 176)
        Me.AdditionalOutputGridView.TabIndex = 79
        '
        'Item
        '
        Me.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Item.FillWeight = 75.0!
        Me.Item.HeaderText = "Item"
        Me.Item.MinimumWidth = 6
        Me.Item.Name = "Item"
        '
        'Column10
        '
        Me.Column10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column10.FillWeight = 75.0!
        Me.Column10.HeaderText = "Chem"
        Me.Column10.MinimumWidth = 6
        Me.Column10.Name = "Column10"
        '
        'Mode
        '
        Me.Mode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Mode.FillWeight = 75.0!
        Me.Mode.HeaderText = "Mode"
        Me.Mode.MinimumWidth = 6
        Me.Mode.Name = "Mode"
        '
        'Bound1
        '
        Me.Bound1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Bound1.FillWeight = 75.0!
        Me.Bound1.HeaderText = "Arg 1"
        Me.Bound1.MinimumWidth = 6
        Me.Bound1.Name = "Bound1"
        '
        'Bound2
        '
        Me.Bound2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Bound2.FillWeight = 75.0!
        Me.Bound2.HeaderText = "Arg 2"
        Me.Bound2.MinimumWidth = 6
        Me.Bound2.Name = "Bound2"
        '
        'Column11
        '
        Me.Column11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column11.FillWeight = 75.0!
        Me.Column11.HeaderText = "Multiplier"
        Me.Column11.MinimumWidth = 6
        Me.Column11.Name = "Column11"
        '
        'Column12
        '
        Me.Column12.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column12.FillWeight = 50.0!
        Me.Column12.HeaderText = "Delete"
        Me.Column12.MinimumWidth = 6
        Me.Column12.Name = "Column12"
        Me.Column12.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column12.Text = "X"
        Me.Column12.UseColumnTextForButtonValue = True
        '
        'OutputMassDepth1
        '
        Me.OutputMassDepth1.Location = New System.Drawing.Point(343, 194)
        Me.OutputMassDepth1.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputMassDepth1.Name = "OutputMassDepth1"
        Me.OutputMassDepth1.Size = New System.Drawing.Size(44, 22)
        Me.OutputMassDepth1.TabIndex = 62
        Me.OutputMassDepth1.Tag = "user-specified output for pesticide mass depth."
        '
        'OutputDecayDepth2
        '
        Me.OutputDecayDepth2.Location = New System.Drawing.Point(448, 154)
        Me.OutputDecayDepth2.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputDecayDepth2.Name = "OutputDecayDepth2"
        Me.OutputDecayDepth2.Size = New System.Drawing.Size(37, 22)
        Me.OutputDecayDepth2.TabIndex = 67
        Me.OutputDecayDepth2.Tag = "user-specified output for pesticide decay depth."
        '
        'OutputDecayDepth1
        '
        Me.OutputDecayDepth1.Location = New System.Drawing.Point(343, 154)
        Me.OutputDecayDepth1.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputDecayDepth1.Name = "OutputDecayDepth1"
        Me.OutputDecayDepth1.Size = New System.Drawing.Size(44, 22)
        Me.OutputDecayDepth1.TabIndex = 66
        Me.OutputDecayDepth1.Tag = "user-specified output for pesticide decay depth."
        '
        'OutputMassDepth2
        '
        Me.OutputMassDepth2.Location = New System.Drawing.Point(448, 194)
        Me.OutputMassDepth2.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputMassDepth2.Name = "OutputMassDepth2"
        Me.OutputMassDepth2.Size = New System.Drawing.Size(37, 22)
        Me.OutputMassDepth2.TabIndex = 63
        Me.OutputMassDepth2.Tag = "user-specified output for pesticide mass depth."
        '
        'Label102
        '
        Me.Label102.AutoSize = True
        Me.Label102.Location = New System.Drawing.Point(297, 157)
        Me.Label102.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label102.Name = "Label102"
        Me.Label102.Size = New System.Drawing.Size(40, 17)
        Me.Label102.TabIndex = 78
        Me.Label102.Text = "from:"
        '
        'outputInfiltratedWaterLastLayer
        '
        Me.outputInfiltratedWaterLastLayer.AutoSize = True
        Me.outputInfiltratedWaterLastLayer.Location = New System.Drawing.Point(574, 156)
        Me.outputInfiltratedWaterLastLayer.Margin = New System.Windows.Forms.Padding(4)
        Me.outputInfiltratedWaterLastLayer.Name = "outputInfiltratedWaterLastLayer"
        Me.outputInfiltratedWaterLastLayer.Size = New System.Drawing.Size(240, 21)
        Me.outputInfiltratedWaterLastLayer.TabIndex = 77
        Me.outputInfiltratedWaterLastLayer.Text = "Infiltration at lower boundary (cm)"
        Me.outputInfiltratedWaterLastLayer.UseVisualStyleBackColor = True
        '
        'outputConcLastLayer
        '
        Me.outputConcLastLayer.AutoSize = True
        Me.outputConcLastLayer.Location = New System.Drawing.Point(29, 112)
        Me.outputConcLastLayer.Margin = New System.Windows.Forms.Padding(4)
        Me.outputConcLastLayer.Name = "outputConcLastLayer"
        Me.outputConcLastLayer.Size = New System.Drawing.Size(253, 21)
        Me.outputConcLastLayer.TabIndex = 76
        Me.outputConcLastLayer.Text = "Concentration in bottom layer (ppb)"
        Me.outputConcLastLayer.UseVisualStyleBackColor = True
        '
        'outputPestErosion
        '
        Me.outputPestErosion.AutoSize = True
        Me.outputPestErosion.Location = New System.Drawing.Point(29, 49)
        Me.outputPestErosion.Margin = New System.Windows.Forms.Padding(4)
        Me.outputPestErosion.Name = "outputPestErosion"
        Me.outputPestErosion.Size = New System.Drawing.Size(185, 21)
        Me.outputPestErosion.TabIndex = 75
        Me.outputPestErosion.Text = "Pesticide eroded (kg/ha)"
        Me.outputPestErosion.UseVisualStyleBackColor = True
        '
        'outputErosion
        '
        Me.outputErosion.AutoSize = True
        Me.outputErosion.Location = New System.Drawing.Point(574, 49)
        Me.outputErosion.Margin = New System.Windows.Forms.Padding(4)
        Me.outputErosion.Name = "outputErosion"
        Me.outputErosion.Size = New System.Drawing.Size(111, 21)
        Me.outputErosion.TabIndex = 74
        Me.outputErosion.Text = "Erosion (Mg)"
        Me.outputErosion.UseVisualStyleBackColor = True
        '
        'outputPestRunoff
        '
        Me.outputPestRunoff.AutoSize = True
        Me.outputPestRunoff.Location = New System.Drawing.Point(29, 28)
        Me.outputPestRunoff.Margin = New System.Windows.Forms.Padding(4)
        Me.outputPestRunoff.Name = "outputPestRunoff"
        Me.outputPestRunoff.Size = New System.Drawing.Size(177, 21)
        Me.outputPestRunoff.TabIndex = 73
        Me.outputPestRunoff.Text = "Pesticide runoff (kg/ha)"
        Me.outputPestRunoff.UseVisualStyleBackColor = True
        '
        'outputRunoff
        '
        Me.outputRunoff.AutoSize = True
        Me.outputRunoff.ForeColor = System.Drawing.Color.Black
        Me.outputRunoff.Location = New System.Drawing.Point(574, 28)
        Me.outputRunoff.Margin = New System.Windows.Forms.Padding(4)
        Me.outputRunoff.Name = "outputRunoff"
        Me.outputRunoff.Size = New System.Drawing.Size(104, 21)
        Me.outputRunoff.TabIndex = 72
        Me.outputRunoff.Text = "Runoff (cm)"
        Me.outputRunoff.UseVisualStyleBackColor = True
        '
        'Label293
        '
        Me.Label293.AutoSize = True
        Me.Label293.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label293.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label293.Location = New System.Drawing.Point(24, 3)
        Me.Label293.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label293.Name = "Label293"
        Me.Label293.Size = New System.Drawing.Size(353, 20)
        Me.Label293.TabIndex = 71
        Me.Label293.Text = "Optional Daily Field Output to a .Out File"
        '
        'Label294
        '
        Me.Label294.AutoSize = True
        Me.Label294.Location = New System.Drawing.Point(297, 197)
        Me.Label294.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label294.Name = "Label294"
        Me.Label294.Size = New System.Drawing.Size(40, 17)
        Me.Label294.TabIndex = 70
        Me.Label294.Text = "from:"
        '
        'Label288
        '
        Me.Label288.AutoSize = True
        Me.Label288.Location = New System.Drawing.Point(392, 157)
        Me.Label288.Margin = New System.Windows.Forms.Padding(0)
        Me.Label288.Name = "Label288"
        Me.Label288.Size = New System.Drawing.Size(54, 17)
        Me.Label288.TabIndex = 69
        Me.Label288.Text = "cm   to:"
        '
        'Label289
        '
        Me.Label289.AutoSize = True
        Me.Label289.Location = New System.Drawing.Point(493, 157)
        Me.Label289.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label289.Name = "Label289"
        Me.Label289.Size = New System.Drawing.Size(26, 17)
        Me.Label289.TabIndex = 68
        Me.Label289.Text = "cm"
        '
        'Label286
        '
        Me.Label286.AutoSize = True
        Me.Label286.Location = New System.Drawing.Point(393, 197)
        Me.Label286.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label286.Name = "Label286"
        Me.Label286.Size = New System.Drawing.Size(54, 17)
        Me.Label286.TabIndex = 65
        Me.Label286.Text = "cm   to:"
        '
        'Label285
        '
        Me.Label285.AutoSize = True
        Me.Label285.Location = New System.Drawing.Point(493, 197)
        Me.Label285.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label285.Name = "Label285"
        Me.Label285.Size = New System.Drawing.Size(26, 17)
        Me.Label285.TabIndex = 64
        Me.Label285.Text = "cm"
        '
        'outputPrecipitation
        '
        Me.outputPrecipitation.AutoSize = True
        Me.outputPrecipitation.Location = New System.Drawing.Point(574, 70)
        Me.outputPrecipitation.Margin = New System.Windows.Forms.Padding(4)
        Me.outputPrecipitation.Name = "outputPrecipitation"
        Me.outputPrecipitation.Size = New System.Drawing.Size(140, 21)
        Me.outputPrecipitation.TabIndex = 61
        Me.outputPrecipitation.Text = "Precipitation (cm)"
        Me.outputPrecipitation.UseVisualStyleBackColor = True
        '
        'outputIrrigation
        '
        Me.outputIrrigation.AutoSize = True
        Me.outputIrrigation.Location = New System.Drawing.Point(574, 133)
        Me.outputIrrigation.Margin = New System.Windows.Forms.Padding(4)
        Me.outputIrrigation.Name = "outputIrrigation"
        Me.outputIrrigation.Size = New System.Drawing.Size(117, 21)
        Me.outputIrrigation.TabIndex = 60
        Me.outputIrrigation.Text = "Irrigation (cm)"
        Me.outputIrrigation.UseVisualStyleBackColor = True
        '
        'Label284
        '
        Me.Label284.AutoSize = True
        Me.Label284.Location = New System.Drawing.Point(843, 180)
        Me.Label284.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label284.Name = "Label284"
        Me.Label284.Size = New System.Drawing.Size(26, 17)
        Me.Label284.TabIndex = 59
        Me.Label284.Text = "cm"
        '
        'outputInfiltrationAtDepth
        '
        Me.outputInfiltrationAtDepth.AutoSize = True
        Me.outputInfiltrationAtDepth.Location = New System.Drawing.Point(574, 178)
        Me.outputInfiltrationAtDepth.Margin = New System.Windows.Forms.Padding(4)
        Me.outputInfiltrationAtDepth.Name = "outputInfiltrationAtDepth"
        Me.outputInfiltrationAtDepth.Size = New System.Drawing.Size(211, 21)
        Me.outputInfiltrationAtDepth.TabIndex = 57
        Me.outputInfiltrationAtDepth.Text = "Infiltration (cm) at a depth of "
        Me.outputInfiltrationAtDepth.UseVisualStyleBackColor = True
        '
        'outputTotalSoilWater
        '
        Me.outputTotalSoilWater.AutoSize = True
        Me.outputTotalSoilWater.Location = New System.Drawing.Point(574, 112)
        Me.outputTotalSoilWater.Margin = New System.Windows.Forms.Padding(4)
        Me.outputTotalSoilWater.Name = "outputTotalSoilWater"
        Me.outputTotalSoilWater.Size = New System.Drawing.Size(221, 21)
        Me.outputTotalSoilWater.TabIndex = 56
        Me.outputTotalSoilWater.Text = "Soil water in entire profile (cm)"
        Me.outputTotalSoilWater.UseVisualStyleBackColor = True
        '
        'outputActualEvap
        '
        Me.outputActualEvap.AutoSize = True
        Me.outputActualEvap.Location = New System.Drawing.Point(574, 91)
        Me.outputActualEvap.Margin = New System.Windows.Forms.Padding(4)
        Me.outputActualEvap.Name = "outputActualEvap"
        Me.outputActualEvap.Size = New System.Drawing.Size(181, 21)
        Me.outputActualEvap.TabIndex = 55
        Me.outputActualEvap.Text = "Evapotranspiration (cm)"
        Me.outputActualEvap.UseVisualStyleBackColor = True
        '
        'outputMassSoilSpecific
        '
        Me.outputMassSoilSpecific.AutoSize = True
        Me.outputMassSoilSpecific.Location = New System.Drawing.Point(29, 196)
        Me.outputMassSoilSpecific.Margin = New System.Windows.Forms.Padding(4)
        Me.outputMassSoilSpecific.Name = "outputMassSoilSpecific"
        Me.outputMassSoilSpecific.Size = New System.Drawing.Size(264, 21)
        Me.outputMassSoilSpecific.TabIndex = 50
        Me.outputMassSoilSpecific.Text = "Pesticide in part of soil profile (kg/ha)"
        Me.outputMassSoilSpecific.UseVisualStyleBackColor = True
        '
        'OutputDecayedPest
        '
        Me.OutputDecayedPest.AutoSize = True
        Me.OutputDecayedPest.Location = New System.Drawing.Point(29, 154)
        Me.OutputDecayedPest.Margin = New System.Windows.Forms.Padding(4)
        Me.OutputDecayedPest.Name = "OutputDecayedPest"
        Me.OutputDecayedPest.Size = New System.Drawing.Size(239, 21)
        Me.OutputDecayedPest.TabIndex = 49
        Me.OutputDecayedPest.Text = "Pesticide decayed in field (kg/ha)"
        Me.OutputDecayedPest.UseVisualStyleBackColor = True
        '
        'outputMassOnFoliage
        '
        Me.outputMassOnFoliage.AutoSize = True
        Me.outputMassOnFoliage.Location = New System.Drawing.Point(29, 133)
        Me.outputMassOnFoliage.Margin = New System.Windows.Forms.Padding(4)
        Me.outputMassOnFoliage.Name = "outputMassOnFoliage"
        Me.outputMassOnFoliage.Size = New System.Drawing.Size(239, 21)
        Me.outputMassOnFoliage.TabIndex = 47
        Me.outputMassOnFoliage.Text = "Pesticide mass on foliage (kg/ha)"
        Me.outputMassOnFoliage.UseVisualStyleBackColor = True
        '
        'outputMassInSoilProfile
        '
        Me.outputMassInSoilProfile.AutoSize = True
        Me.outputMassInSoilProfile.Location = New System.Drawing.Point(29, 175)
        Me.outputMassInSoilProfile.Margin = New System.Windows.Forms.Padding(4)
        Me.outputMassInSoilProfile.Name = "outputMassInSoilProfile"
        Me.outputMassInSoilProfile.Size = New System.Drawing.Size(259, 21)
        Me.outputMassInSoilProfile.TabIndex = 46
        Me.outputMassInSoilProfile.Text = "Pesticide in entire soil profile (kg/ha)"
        Me.outputMassInSoilProfile.UseVisualStyleBackColor = True
        '
        'outputDailyFieldVolatilization
        '
        Me.outputDailyFieldVolatilization.AutoSize = True
        Me.outputDailyFieldVolatilization.ForeColor = System.Drawing.Color.Black
        Me.outputDailyFieldVolatilization.Location = New System.Drawing.Point(29, 70)
        Me.outputDailyFieldVolatilization.Margin = New System.Windows.Forms.Padding(4)
        Me.outputDailyFieldVolatilization.Name = "outputDailyFieldVolatilization"
        Me.outputDailyFieldVolatilization.Size = New System.Drawing.Size(250, 21)
        Me.outputDailyFieldVolatilization.TabIndex = 1
        Me.outputDailyFieldVolatilization.Text = "Daily volatilzation from field (kg/ha)"
        Me.outputDailyFieldVolatilization.UseVisualStyleBackColor = True
        '
        'WaterbodyExaminerTab
        '
        Me.WaterbodyExaminerTab.AutoScroll = True
        Me.WaterbodyExaminerTab.BackColor = System.Drawing.Color.Aqua
        Me.WaterbodyExaminerTab.Controls.Add(Me.SprayGridView)
        Me.WaterbodyExaminerTab.Controls.Add(Me.TableLayoutPanel5)
        Me.WaterbodyExaminerTab.Controls.Add(Me.WaterColumnBiomass)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label100)
        Me.WaterbodyExaminerTab.Controls.Add(Me.WaterColumnDoc)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label111)
        Me.WaterbodyExaminerTab.Controls.Add(Me.WaterColumnFoc)
        Me.WaterbodyExaminerTab.Controls.Add(Me.WaterBodyType)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Chlorophyll)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label93)
        Me.WaterbodyExaminerTab.Controls.Add(Me.SuspendedSolids)
        Me.WaterbodyExaminerTab.Controls.Add(Me.FractionCroppedArea)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Dfac)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label73)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label74)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BaseFlow)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label77)
        Me.WaterbodyExaminerTab.Controls.Add(Me.FlowLength)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label78)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label94)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label79)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label39)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label68)
        Me.WaterbodyExaminerTab.Controls.Add(Me.FlowAveraging)
        Me.WaterbodyExaminerTab.Controls.Add(Me.FieldSize)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicBiomass)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicDOC)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label82)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicFoc)
        Me.WaterbodyExaminerTab.Controls.Add(Me.MaxDepth)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicBulkDensity)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label38)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicPorosity)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label92)
        Me.WaterbodyExaminerTab.Controls.Add(Me.BenthicDepth)
        Me.WaterbodyExaminerTab.Controls.Add(Me.PushToSaveWaterBody)
        Me.WaterbodyExaminerTab.Controls.Add(Me.DoverDx)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label76)
        Me.WaterbodyExaminerTab.Controls.Add(Me.PushToLoadWaterBody)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label70)
        Me.WaterbodyExaminerTab.Controls.Add(Me.WaterBodyArea)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label71)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label69)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label67)
        Me.WaterbodyExaminerTab.Controls.Add(Me.InitialDepth)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label66)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label75)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label65)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label72)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label64)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label81)
        Me.WaterbodyExaminerTab.Controls.Add(Me.Label80)
        Me.WaterbodyExaminerTab.Location = New System.Drawing.Point(4, 25)
        Me.WaterbodyExaminerTab.Name = "WaterbodyExaminerTab"
        Me.WaterbodyExaminerTab.Padding = New System.Windows.Forms.Padding(3)
        Me.WaterbodyExaminerTab.Size = New System.Drawing.Size(945, 589)
        Me.WaterbodyExaminerTab.TabIndex = 11
        Me.WaterbodyExaminerTab.Text = "Waterbody Examiner"
        '
        'SprayGridView
        '
        Me.SprayGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.SprayGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column14, Me.Column15, Me.Column16, Me.Column17, Me.Column18, Me.Column19, Me.Column25, Me.Column26, Me.Column27, Me.Column28, Me.Column29, Me.Column30, Me.Column31})
        Me.SprayGridView.Location = New System.Drawing.Point(19, 1064)
        Me.SprayGridView.Name = "SprayGridView"
        Me.SprayGridView.RowHeadersVisible = False
        Me.SprayGridView.RowHeadersWidth = 51
        Me.SprayGridView.RowTemplate.Height = 24
        Me.SprayGridView.Size = New System.Drawing.Size(875, 413)
        Me.SprayGridView.TabIndex = 209
        '
        'Column14
        '
        Me.Column14.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column14.HeaderText = "Method\Buffer"
        Me.Column14.MinimumWidth = 6
        Me.Column14.Name = "Column14"
        Me.Column14.Width = 126
        '
        'Column15
        '
        Me.Column15.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column15.HeaderText = "5"
        Me.Column15.MinimumWidth = 6
        Me.Column15.Name = "Column15"
        Me.Column15.Width = 45
        '
        'Column16
        '
        Me.Column16.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column16.HeaderText = "10"
        Me.Column16.MinimumWidth = 6
        Me.Column16.Name = "Column16"
        Me.Column16.Width = 53
        '
        'Column17
        '
        Me.Column17.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column17.HeaderText = "25"
        Me.Column17.MinimumWidth = 6
        Me.Column17.Name = "Column17"
        Me.Column17.Width = 53
        '
        'Column18
        '
        Me.Column18.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column18.HeaderText = "50"
        Me.Column18.MinimumWidth = 6
        Me.Column18.Name = "Column18"
        Me.Column18.Width = 53
        '
        'Column19
        '
        Me.Column19.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column19.HeaderText = "100"
        Me.Column19.MinimumWidth = 6
        Me.Column19.Name = "Column19"
        Me.Column19.Width = 61
        '
        'Column25
        '
        Me.Column25.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column25.HeaderText = "150"
        Me.Column25.MinimumWidth = 6
        Me.Column25.Name = "Column25"
        Me.Column25.Width = 61
        '
        'Column26
        '
        Me.Column26.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column26.HeaderText = "200"
        Me.Column26.MinimumWidth = 6
        Me.Column26.Name = "Column26"
        Me.Column26.Width = 61
        '
        'Column27
        '
        Me.Column27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column27.HeaderText = "250"
        Me.Column27.MinimumWidth = 6
        Me.Column27.Name = "Column27"
        Me.Column27.Width = 61
        '
        'Column28
        '
        Me.Column28.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column28.HeaderText = "300"
        Me.Column28.MinimumWidth = 6
        Me.Column28.Name = "Column28"
        Me.Column28.Width = 61
        '
        'Column29
        '
        Me.Column29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column29.HeaderText = "350"
        Me.Column29.MinimumWidth = 6
        Me.Column29.Name = "Column29"
        Me.Column29.Width = 61
        '
        'Column30
        '
        Me.Column30.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column30.HeaderText = "400"
        Me.Column30.MinimumWidth = 6
        Me.Column30.Name = "Column30"
        Me.Column30.Width = 61
        '
        'Column31
        '
        Me.Column31.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells
        Me.Column31.HeaderText = "500"
        Me.Column31.MinimumWidth = 6
        Me.Column31.Name = "Column31"
        Me.Column31.Width = 61
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 14
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.30306!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.97755!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.973815!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.973815!))
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.973815!))
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox171, 13, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox170, 12, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox169, 11, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox168, 10, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox167, 9, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox166, 8, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox165, 7, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox164, 6, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox163, 5, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox162, 4, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox161, 3, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox160, 2, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox159, 13, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox158, 12, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox157, 11, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox156, 10, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox155, 9, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox154, 8, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox153, 7, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox152, 6, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox151, 5, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox150, 4, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox149, 3, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox148, 2, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox147, 13, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox146, 12, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox145, 11, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox144, 10, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox143, 9, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox142, 8, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox141, 7, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox140, 6, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox139, 5, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox138, 4, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox137, 3, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox136, 2, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox135, 13, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox134, 12, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox133, 11, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox132, 10, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox131, 9, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox130, 8, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox129, 7, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox128, 6, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox127, 5, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox126, 4, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox125, 3, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox124, 2, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox123, 13, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox120, 12, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox122, 11, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox121, 10, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox119, 9, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox118, 8, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox117, 7, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox116, 6, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox115, 5, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox114, 4, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox113, 3, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox112, 2, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox111, 13, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox110, 12, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox109, 11, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox108, 10, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox107, 9, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox106, 8, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox105, 7, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox104, 6, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox103, 5, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox102, 4, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox101, 3, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox100, 2, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox99, 13, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox98, 12, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox97, 11, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox96, 10, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox95, 9, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox94, 8, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox93, 7, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox92, 6, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox91, 5, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox90, 4, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox89, 3, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox88, 2, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox87, 13, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox86, 12, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox85, 11, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox84, 10, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox83, 9, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox82, 8, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox81, 7, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox80, 6, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox79, 5, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox78, 4, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox77, 3, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox76, 2, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox75, 13, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox74, 12, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox73, 11, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox72, 10, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox71, 9, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox70, 8, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox69, 7, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox68, 6, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox67, 5, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox66, 4, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox65, 3, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox64, 2, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox63, 13, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox62, 12, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox61, 11, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox60, 10, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox59, 9, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox58, 8, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox57, 7, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox52, 2, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox51, 13, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox50, 12, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox49, 11, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox48, 10, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox47, 9, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox46, 8, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox45, 7, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox44, 6, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox43, 5, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox42, 4, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox41, 3, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox40, 2, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox39, 13, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox38, 12, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox37, 11, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox36, 10, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox35, 9, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox34, 8, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox33, 7, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox32, 6, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox31, 5, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox30, 4, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox29, 3, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox28, 2, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox27, 13, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox26, 12, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox25, 11, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox24, 10, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox23, 9, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox22, 8, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox21, 7, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox20, 6, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox19, 5, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox18, 4, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox17, 3, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox16, 2, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox15, 13, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox14, 12, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox13, 11, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox12, 10, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox11, 9, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox10, 8, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox9, 7, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox8, 6, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox7, 5, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.spray1_25, 4, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.spray1_10, 3, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.spray1_5, 2, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label184, 13, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label183, 12, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label182, 11, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label181, 10, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label180, 9, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label179, 8, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label178, 7, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label177, 6, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label176, 5, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label175, 4, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label174, 3, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label173, 2, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label134, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.Label126, 0, 14)
        Me.TableLayoutPanel5.Controls.Add(Me.Label114, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.spray13, 1, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.spray1, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.Label115, 0, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.Label127, 0, 13)
        Me.TableLayoutPanel5.Controls.Add(Me.Label116, 0, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.Label122, 0, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.spray12, 1, 12)
        Me.TableLayoutPanel5.Controls.Add(Me.spray2, 1, 2)
        Me.TableLayoutPanel5.Controls.Add(Me.spray11, 1, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.spray3, 1, 3)
        Me.TableLayoutPanel5.Controls.Add(Me.spray10, 1, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.Label123, 0, 11)
        Me.TableLayoutPanel5.Controls.Add(Me.spray4, 1, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Label124, 0, 10)
        Me.TableLayoutPanel5.Controls.Add(Me.spray9, 1, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.Label117, 0, 4)
        Me.TableLayoutPanel5.Controls.Add(Me.Label121, 0, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.Label125, 0, 9)
        Me.TableLayoutPanel5.Controls.Add(Me.spray5, 1, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.spray6, 1, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.Label120, 0, 6)
        Me.TableLayoutPanel5.Controls.Add(Me.spray8, 1, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.Label118, 0, 8)
        Me.TableLayoutPanel5.Controls.Add(Me.spray7, 1, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.Label119, 0, 7)
        Me.TableLayoutPanel5.Controls.Add(Me.Label172, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox53, 3, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox54, 4, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox56, 5, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.TextBox55, 6, 5)
        Me.TableLayoutPanel5.Controls.Add(Me.spray14, 1, 14)
        Me.TableLayoutPanel5.Font = New System.Drawing.Font("Arial Narrow", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(3, 625)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 15
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.25658!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.410427!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.407863!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(910, 408)
        Me.TableLayoutPanel5.TabIndex = 208
        '
        'TextBox171
        '
        Me.TextBox171.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox171.Location = New System.Drawing.Point(857, 382)
        Me.TextBox171.Name = "TextBox171"
        Me.TextBox171.Size = New System.Drawing.Size(45, 22)
        Me.TextBox171.TabIndex = 400
        Me.TextBox171.Text = "0"
        '
        'TextBox170
        '
        Me.TextBox170.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox170.Location = New System.Drawing.Point(801, 382)
        Me.TextBox170.Name = "TextBox170"
        Me.TextBox170.Size = New System.Drawing.Size(43, 22)
        Me.TextBox170.TabIndex = 399
        Me.TextBox170.Text = "0"
        '
        'TextBox169
        '
        Me.TextBox169.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox169.Location = New System.Drawing.Point(747, 382)
        Me.TextBox169.Name = "TextBox169"
        Me.TextBox169.Size = New System.Drawing.Size(43, 22)
        Me.TextBox169.TabIndex = 398
        Me.TextBox169.Text = "0"
        '
        'TextBox168
        '
        Me.TextBox168.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox168.Location = New System.Drawing.Point(693, 382)
        Me.TextBox168.Name = "TextBox168"
        Me.TextBox168.Size = New System.Drawing.Size(43, 22)
        Me.TextBox168.TabIndex = 397
        Me.TextBox168.Text = "0"
        '
        'TextBox167
        '
        Me.TextBox167.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox167.Location = New System.Drawing.Point(639, 382)
        Me.TextBox167.Name = "TextBox167"
        Me.TextBox167.Size = New System.Drawing.Size(43, 22)
        Me.TextBox167.TabIndex = 396
        Me.TextBox167.Text = "0"
        '
        'TextBox166
        '
        Me.TextBox166.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox166.Location = New System.Drawing.Point(585, 382)
        Me.TextBox166.Name = "TextBox166"
        Me.TextBox166.Size = New System.Drawing.Size(43, 22)
        Me.TextBox166.TabIndex = 395
        Me.TextBox166.Text = "0"
        '
        'TextBox165
        '
        Me.TextBox165.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox165.Location = New System.Drawing.Point(531, 382)
        Me.TextBox165.Name = "TextBox165"
        Me.TextBox165.Size = New System.Drawing.Size(43, 22)
        Me.TextBox165.TabIndex = 394
        Me.TextBox165.Text = "0"
        '
        'TextBox164
        '
        Me.TextBox164.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox164.Location = New System.Drawing.Point(477, 382)
        Me.TextBox164.Name = "TextBox164"
        Me.TextBox164.Size = New System.Drawing.Size(43, 22)
        Me.TextBox164.TabIndex = 393
        Me.TextBox164.Text = "0"
        '
        'TextBox163
        '
        Me.TextBox163.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox163.Location = New System.Drawing.Point(423, 382)
        Me.TextBox163.Name = "TextBox163"
        Me.TextBox163.Size = New System.Drawing.Size(43, 22)
        Me.TextBox163.TabIndex = 392
        Me.TextBox163.Text = "0"
        '
        'TextBox162
        '
        Me.TextBox162.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox162.Location = New System.Drawing.Point(369, 382)
        Me.TextBox162.Name = "TextBox162"
        Me.TextBox162.Size = New System.Drawing.Size(43, 22)
        Me.TextBox162.TabIndex = 391
        Me.TextBox162.Text = "0"
        '
        'TextBox161
        '
        Me.TextBox161.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox161.Location = New System.Drawing.Point(315, 382)
        Me.TextBox161.Name = "TextBox161"
        Me.TextBox161.Size = New System.Drawing.Size(43, 22)
        Me.TextBox161.TabIndex = 390
        Me.TextBox161.Text = "0"
        '
        'TextBox160
        '
        Me.TextBox160.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox160.Location = New System.Drawing.Point(261, 382)
        Me.TextBox160.Name = "TextBox160"
        Me.TextBox160.Size = New System.Drawing.Size(43, 22)
        Me.TextBox160.TabIndex = 389
        Me.TextBox160.Text = "0"
        '
        'TextBox159
        '
        Me.TextBox159.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox159.Location = New System.Drawing.Point(857, 356)
        Me.TextBox159.Name = "TextBox159"
        Me.TextBox159.Size = New System.Drawing.Size(45, 22)
        Me.TextBox159.TabIndex = 388
        Me.TextBox159.Text = "0.042"
        '
        'TextBox158
        '
        Me.TextBox158.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox158.Location = New System.Drawing.Point(801, 356)
        Me.TextBox158.Name = "TextBox158"
        Me.TextBox158.Size = New System.Drawing.Size(43, 22)
        Me.TextBox158.TabIndex = 387
        Me.TextBox158.Text = "0.042"
        '
        'TextBox157
        '
        Me.TextBox157.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox157.Location = New System.Drawing.Point(747, 356)
        Me.TextBox157.Name = "TextBox157"
        Me.TextBox157.Size = New System.Drawing.Size(43, 22)
        Me.TextBox157.TabIndex = 386
        Me.TextBox157.Text = "0.042"
        '
        'TextBox156
        '
        Me.TextBox156.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox156.Location = New System.Drawing.Point(693, 356)
        Me.TextBox156.Name = "TextBox156"
        Me.TextBox156.Size = New System.Drawing.Size(43, 22)
        Me.TextBox156.TabIndex = 385
        Me.TextBox156.Text = "0.042"
        '
        'TextBox155
        '
        Me.TextBox155.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox155.Location = New System.Drawing.Point(639, 356)
        Me.TextBox155.Name = "TextBox155"
        Me.TextBox155.Size = New System.Drawing.Size(43, 22)
        Me.TextBox155.TabIndex = 384
        Me.TextBox155.Text = "0.042"
        '
        'TextBox154
        '
        Me.TextBox154.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox154.Location = New System.Drawing.Point(585, 356)
        Me.TextBox154.Name = "TextBox154"
        Me.TextBox154.Size = New System.Drawing.Size(43, 22)
        Me.TextBox154.TabIndex = 383
        Me.TextBox154.Text = "0.042"
        '
        'TextBox153
        '
        Me.TextBox153.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox153.Location = New System.Drawing.Point(531, 356)
        Me.TextBox153.Name = "TextBox153"
        Me.TextBox153.Size = New System.Drawing.Size(43, 22)
        Me.TextBox153.TabIndex = 382
        Me.TextBox153.Text = "0.042"
        '
        'TextBox152
        '
        Me.TextBox152.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox152.Location = New System.Drawing.Point(477, 356)
        Me.TextBox152.Name = "TextBox152"
        Me.TextBox152.Size = New System.Drawing.Size(43, 22)
        Me.TextBox152.TabIndex = 381
        Me.TextBox152.Text = "0.042"
        '
        'TextBox151
        '
        Me.TextBox151.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox151.Location = New System.Drawing.Point(423, 356)
        Me.TextBox151.Name = "TextBox151"
        Me.TextBox151.Size = New System.Drawing.Size(43, 22)
        Me.TextBox151.TabIndex = 380
        Me.TextBox151.Text = "0.042"
        '
        'TextBox150
        '
        Me.TextBox150.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox150.Location = New System.Drawing.Point(369, 356)
        Me.TextBox150.Name = "TextBox150"
        Me.TextBox150.Size = New System.Drawing.Size(43, 22)
        Me.TextBox150.TabIndex = 379
        Me.TextBox150.Text = "0.042"
        '
        'TextBox149
        '
        Me.TextBox149.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox149.Location = New System.Drawing.Point(315, 356)
        Me.TextBox149.Name = "TextBox149"
        Me.TextBox149.Size = New System.Drawing.Size(43, 22)
        Me.TextBox149.TabIndex = 378
        Me.TextBox149.Text = "0.042"
        '
        'TextBox148
        '
        Me.TextBox148.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox148.Location = New System.Drawing.Point(261, 356)
        Me.TextBox148.Name = "TextBox148"
        Me.TextBox148.Size = New System.Drawing.Size(43, 22)
        Me.TextBox148.TabIndex = 377
        Me.TextBox148.Text = "0.042"
        '
        'TextBox147
        '
        Me.TextBox147.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox147.Location = New System.Drawing.Point(857, 330)
        Me.TextBox147.Name = "TextBox147"
        Me.TextBox147.Size = New System.Drawing.Size(45, 22)
        Me.TextBox147.TabIndex = 376
        Me.TextBox147.Text = "0.042"
        '
        'TextBox146
        '
        Me.TextBox146.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox146.Location = New System.Drawing.Point(801, 330)
        Me.TextBox146.Name = "TextBox146"
        Me.TextBox146.Size = New System.Drawing.Size(43, 22)
        Me.TextBox146.TabIndex = 375
        Me.TextBox146.Text = "0.042"
        '
        'TextBox145
        '
        Me.TextBox145.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox145.Location = New System.Drawing.Point(747, 330)
        Me.TextBox145.Name = "TextBox145"
        Me.TextBox145.Size = New System.Drawing.Size(43, 22)
        Me.TextBox145.TabIndex = 374
        Me.TextBox145.Text = "0.042"
        '
        'TextBox144
        '
        Me.TextBox144.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox144.Location = New System.Drawing.Point(693, 330)
        Me.TextBox144.Name = "TextBox144"
        Me.TextBox144.Size = New System.Drawing.Size(43, 22)
        Me.TextBox144.TabIndex = 373
        Me.TextBox144.Text = "0.042"
        '
        'TextBox143
        '
        Me.TextBox143.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox143.Location = New System.Drawing.Point(639, 330)
        Me.TextBox143.Name = "TextBox143"
        Me.TextBox143.Size = New System.Drawing.Size(43, 22)
        Me.TextBox143.TabIndex = 372
        Me.TextBox143.Text = "0.042"
        '
        'TextBox142
        '
        Me.TextBox142.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox142.Location = New System.Drawing.Point(585, 330)
        Me.TextBox142.Name = "TextBox142"
        Me.TextBox142.Size = New System.Drawing.Size(43, 22)
        Me.TextBox142.TabIndex = 371
        Me.TextBox142.Text = "0.042"
        '
        'TextBox141
        '
        Me.TextBox141.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox141.Location = New System.Drawing.Point(531, 330)
        Me.TextBox141.Name = "TextBox141"
        Me.TextBox141.Size = New System.Drawing.Size(43, 22)
        Me.TextBox141.TabIndex = 370
        Me.TextBox141.Text = "0.042"
        '
        'TextBox140
        '
        Me.TextBox140.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox140.Location = New System.Drawing.Point(477, 330)
        Me.TextBox140.Name = "TextBox140"
        Me.TextBox140.Size = New System.Drawing.Size(43, 22)
        Me.TextBox140.TabIndex = 369
        Me.TextBox140.Text = "0.042"
        '
        'TextBox139
        '
        Me.TextBox139.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox139.Location = New System.Drawing.Point(423, 330)
        Me.TextBox139.Name = "TextBox139"
        Me.TextBox139.Size = New System.Drawing.Size(43, 22)
        Me.TextBox139.TabIndex = 368
        Me.TextBox139.Text = "0.042"
        '
        'TextBox138
        '
        Me.TextBox138.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox138.Location = New System.Drawing.Point(369, 330)
        Me.TextBox138.Name = "TextBox138"
        Me.TextBox138.Size = New System.Drawing.Size(43, 22)
        Me.TextBox138.TabIndex = 367
        Me.TextBox138.Text = "0.042"
        '
        'TextBox137
        '
        Me.TextBox137.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox137.Location = New System.Drawing.Point(315, 330)
        Me.TextBox137.Name = "TextBox137"
        Me.TextBox137.Size = New System.Drawing.Size(43, 22)
        Me.TextBox137.TabIndex = 366
        Me.TextBox137.Text = "0.042"
        '
        'TextBox136
        '
        Me.TextBox136.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox136.Location = New System.Drawing.Point(261, 330)
        Me.TextBox136.Name = "TextBox136"
        Me.TextBox136.Size = New System.Drawing.Size(43, 22)
        Me.TextBox136.TabIndex = 365
        Me.TextBox136.Text = "0.042"
        '
        'TextBox135
        '
        Me.TextBox135.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox135.Location = New System.Drawing.Point(857, 304)
        Me.TextBox135.Name = "TextBox135"
        Me.TextBox135.Size = New System.Drawing.Size(45, 22)
        Me.TextBox135.TabIndex = 364
        Me.TextBox135.Text = "0.042"
        '
        'TextBox134
        '
        Me.TextBox134.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox134.Location = New System.Drawing.Point(801, 304)
        Me.TextBox134.Name = "TextBox134"
        Me.TextBox134.Size = New System.Drawing.Size(43, 22)
        Me.TextBox134.TabIndex = 363
        Me.TextBox134.Text = "0.042"
        '
        'TextBox133
        '
        Me.TextBox133.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox133.Location = New System.Drawing.Point(747, 304)
        Me.TextBox133.Name = "TextBox133"
        Me.TextBox133.Size = New System.Drawing.Size(43, 22)
        Me.TextBox133.TabIndex = 362
        Me.TextBox133.Text = "0.042"
        '
        'TextBox132
        '
        Me.TextBox132.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox132.Location = New System.Drawing.Point(693, 304)
        Me.TextBox132.Name = "TextBox132"
        Me.TextBox132.Size = New System.Drawing.Size(43, 22)
        Me.TextBox132.TabIndex = 361
        Me.TextBox132.Text = "0.042"
        '
        'TextBox131
        '
        Me.TextBox131.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox131.Location = New System.Drawing.Point(639, 304)
        Me.TextBox131.Name = "TextBox131"
        Me.TextBox131.Size = New System.Drawing.Size(43, 22)
        Me.TextBox131.TabIndex = 360
        Me.TextBox131.Text = "0.042"
        '
        'TextBox130
        '
        Me.TextBox130.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox130.Location = New System.Drawing.Point(585, 304)
        Me.TextBox130.Name = "TextBox130"
        Me.TextBox130.Size = New System.Drawing.Size(43, 22)
        Me.TextBox130.TabIndex = 359
        Me.TextBox130.Text = "0.042"
        '
        'TextBox129
        '
        Me.TextBox129.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox129.Location = New System.Drawing.Point(531, 304)
        Me.TextBox129.Name = "TextBox129"
        Me.TextBox129.Size = New System.Drawing.Size(43, 22)
        Me.TextBox129.TabIndex = 358
        Me.TextBox129.Text = "0.042"
        '
        'TextBox128
        '
        Me.TextBox128.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox128.Location = New System.Drawing.Point(477, 304)
        Me.TextBox128.Name = "TextBox128"
        Me.TextBox128.Size = New System.Drawing.Size(43, 22)
        Me.TextBox128.TabIndex = 357
        Me.TextBox128.Text = "0.042"
        '
        'TextBox127
        '
        Me.TextBox127.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox127.Location = New System.Drawing.Point(423, 304)
        Me.TextBox127.Name = "TextBox127"
        Me.TextBox127.Size = New System.Drawing.Size(43, 22)
        Me.TextBox127.TabIndex = 356
        Me.TextBox127.Text = "0.042"
        '
        'TextBox126
        '
        Me.TextBox126.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox126.Location = New System.Drawing.Point(369, 304)
        Me.TextBox126.Name = "TextBox126"
        Me.TextBox126.Size = New System.Drawing.Size(43, 22)
        Me.TextBox126.TabIndex = 355
        Me.TextBox126.Text = "0.042"
        '
        'TextBox125
        '
        Me.TextBox125.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox125.Location = New System.Drawing.Point(315, 304)
        Me.TextBox125.Name = "TextBox125"
        Me.TextBox125.Size = New System.Drawing.Size(43, 22)
        Me.TextBox125.TabIndex = 354
        Me.TextBox125.Text = "0.042"
        '
        'TextBox124
        '
        Me.TextBox124.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox124.Location = New System.Drawing.Point(261, 304)
        Me.TextBox124.Name = "TextBox124"
        Me.TextBox124.Size = New System.Drawing.Size(43, 22)
        Me.TextBox124.TabIndex = 353
        Me.TextBox124.Text = "0.042"
        '
        'TextBox123
        '
        Me.TextBox123.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox123.Location = New System.Drawing.Point(857, 278)
        Me.TextBox123.Name = "TextBox123"
        Me.TextBox123.Size = New System.Drawing.Size(45, 22)
        Me.TextBox123.TabIndex = 352
        Me.TextBox123.Text = "0.042"
        '
        'TextBox120
        '
        Me.TextBox120.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox120.Location = New System.Drawing.Point(801, 278)
        Me.TextBox120.Name = "TextBox120"
        Me.TextBox120.Size = New System.Drawing.Size(43, 22)
        Me.TextBox120.TabIndex = 288
        Me.TextBox120.Text = "0.042"
        '
        'TextBox122
        '
        Me.TextBox122.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox122.Location = New System.Drawing.Point(747, 278)
        Me.TextBox122.Name = "TextBox122"
        Me.TextBox122.Size = New System.Drawing.Size(43, 22)
        Me.TextBox122.TabIndex = 351
        Me.TextBox122.Text = "0.042"
        '
        'TextBox121
        '
        Me.TextBox121.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox121.Location = New System.Drawing.Point(693, 278)
        Me.TextBox121.Name = "TextBox121"
        Me.TextBox121.Size = New System.Drawing.Size(43, 22)
        Me.TextBox121.TabIndex = 350
        Me.TextBox121.Text = "0.042"
        '
        'TextBox119
        '
        Me.TextBox119.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox119.Location = New System.Drawing.Point(639, 278)
        Me.TextBox119.Name = "TextBox119"
        Me.TextBox119.Size = New System.Drawing.Size(43, 22)
        Me.TextBox119.TabIndex = 349
        Me.TextBox119.Text = "0.042"
        '
        'TextBox118
        '
        Me.TextBox118.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox118.Location = New System.Drawing.Point(585, 278)
        Me.TextBox118.Name = "TextBox118"
        Me.TextBox118.Size = New System.Drawing.Size(43, 22)
        Me.TextBox118.TabIndex = 348
        Me.TextBox118.Text = "0.042"
        '
        'TextBox117
        '
        Me.TextBox117.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox117.Location = New System.Drawing.Point(531, 278)
        Me.TextBox117.Name = "TextBox117"
        Me.TextBox117.Size = New System.Drawing.Size(43, 22)
        Me.TextBox117.TabIndex = 347
        Me.TextBox117.Text = "0.042"
        '
        'TextBox116
        '
        Me.TextBox116.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox116.Location = New System.Drawing.Point(477, 278)
        Me.TextBox116.Name = "TextBox116"
        Me.TextBox116.Size = New System.Drawing.Size(43, 22)
        Me.TextBox116.TabIndex = 346
        Me.TextBox116.Text = "0.042"
        '
        'TextBox115
        '
        Me.TextBox115.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox115.Location = New System.Drawing.Point(423, 278)
        Me.TextBox115.Name = "TextBox115"
        Me.TextBox115.Size = New System.Drawing.Size(43, 22)
        Me.TextBox115.TabIndex = 345
        Me.TextBox115.Text = "0.042"
        '
        'TextBox114
        '
        Me.TextBox114.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox114.Location = New System.Drawing.Point(369, 278)
        Me.TextBox114.Name = "TextBox114"
        Me.TextBox114.Size = New System.Drawing.Size(43, 22)
        Me.TextBox114.TabIndex = 344
        Me.TextBox114.Text = "0.042"
        '
        'TextBox113
        '
        Me.TextBox113.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox113.Location = New System.Drawing.Point(315, 278)
        Me.TextBox113.Name = "TextBox113"
        Me.TextBox113.Size = New System.Drawing.Size(43, 22)
        Me.TextBox113.TabIndex = 343
        Me.TextBox113.Text = "0.042"
        '
        'TextBox112
        '
        Me.TextBox112.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox112.Location = New System.Drawing.Point(261, 278)
        Me.TextBox112.Name = "TextBox112"
        Me.TextBox112.Size = New System.Drawing.Size(43, 22)
        Me.TextBox112.TabIndex = 342
        Me.TextBox112.Text = "0"
        '
        'TextBox111
        '
        Me.TextBox111.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox111.Location = New System.Drawing.Point(857, 252)
        Me.TextBox111.Name = "TextBox111"
        Me.TextBox111.Size = New System.Drawing.Size(45, 22)
        Me.TextBox111.TabIndex = 341
        Me.TextBox111.Text = "0"
        '
        'TextBox110
        '
        Me.TextBox110.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox110.Location = New System.Drawing.Point(801, 252)
        Me.TextBox110.Name = "TextBox110"
        Me.TextBox110.Size = New System.Drawing.Size(43, 22)
        Me.TextBox110.TabIndex = 340
        Me.TextBox110.Text = "0"
        '
        'TextBox109
        '
        Me.TextBox109.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox109.Location = New System.Drawing.Point(747, 252)
        Me.TextBox109.Name = "TextBox109"
        Me.TextBox109.Size = New System.Drawing.Size(43, 22)
        Me.TextBox109.TabIndex = 339
        Me.TextBox109.Text = "0"
        '
        'TextBox108
        '
        Me.TextBox108.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox108.Location = New System.Drawing.Point(693, 252)
        Me.TextBox108.Name = "TextBox108"
        Me.TextBox108.Size = New System.Drawing.Size(43, 22)
        Me.TextBox108.TabIndex = 338
        Me.TextBox108.Text = "0"
        '
        'TextBox107
        '
        Me.TextBox107.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox107.Location = New System.Drawing.Point(639, 252)
        Me.TextBox107.Name = "TextBox107"
        Me.TextBox107.Size = New System.Drawing.Size(43, 22)
        Me.TextBox107.TabIndex = 337
        Me.TextBox107.Text = "0"
        '
        'TextBox106
        '
        Me.TextBox106.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox106.Location = New System.Drawing.Point(585, 252)
        Me.TextBox106.Name = "TextBox106"
        Me.TextBox106.Size = New System.Drawing.Size(43, 22)
        Me.TextBox106.TabIndex = 336
        Me.TextBox106.Text = "0"
        '
        'TextBox105
        '
        Me.TextBox105.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox105.Location = New System.Drawing.Point(531, 252)
        Me.TextBox105.Name = "TextBox105"
        Me.TextBox105.Size = New System.Drawing.Size(43, 22)
        Me.TextBox105.TabIndex = 335
        Me.TextBox105.Text = "0"
        '
        'TextBox104
        '
        Me.TextBox104.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox104.Location = New System.Drawing.Point(477, 252)
        Me.TextBox104.Name = "TextBox104"
        Me.TextBox104.Size = New System.Drawing.Size(43, 22)
        Me.TextBox104.TabIndex = 334
        Me.TextBox104.Text = "0"
        '
        'TextBox103
        '
        Me.TextBox103.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox103.Location = New System.Drawing.Point(423, 252)
        Me.TextBox103.Name = "TextBox103"
        Me.TextBox103.Size = New System.Drawing.Size(43, 22)
        Me.TextBox103.TabIndex = 333
        Me.TextBox103.Text = "0"
        '
        'TextBox102
        '
        Me.TextBox102.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox102.Location = New System.Drawing.Point(369, 252)
        Me.TextBox102.Name = "TextBox102"
        Me.TextBox102.Size = New System.Drawing.Size(43, 22)
        Me.TextBox102.TabIndex = 332
        Me.TextBox102.Text = "0"
        '
        'TextBox101
        '
        Me.TextBox101.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox101.Location = New System.Drawing.Point(315, 252)
        Me.TextBox101.Name = "TextBox101"
        Me.TextBox101.Size = New System.Drawing.Size(43, 22)
        Me.TextBox101.TabIndex = 331
        Me.TextBox101.Text = "0"
        '
        'TextBox100
        '
        Me.TextBox100.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox100.Location = New System.Drawing.Point(261, 252)
        Me.TextBox100.Name = "TextBox100"
        Me.TextBox100.Size = New System.Drawing.Size(43, 22)
        Me.TextBox100.TabIndex = 330
        Me.TextBox100.Text = "0"
        '
        'TextBox99
        '
        Me.TextBox99.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox99.Location = New System.Drawing.Point(857, 226)
        Me.TextBox99.Name = "TextBox99"
        Me.TextBox99.Size = New System.Drawing.Size(45, 22)
        Me.TextBox99.TabIndex = 329
        Me.TextBox99.Text = "0.001"
        '
        'TextBox98
        '
        Me.TextBox98.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox98.Location = New System.Drawing.Point(801, 226)
        Me.TextBox98.Name = "TextBox98"
        Me.TextBox98.Size = New System.Drawing.Size(43, 22)
        Me.TextBox98.TabIndex = 328
        Me.TextBox98.Text = "0.0012"
        '
        'TextBox97
        '
        Me.TextBox97.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox97.Location = New System.Drawing.Point(747, 226)
        Me.TextBox97.Name = "TextBox97"
        Me.TextBox97.Size = New System.Drawing.Size(43, 22)
        Me.TextBox97.TabIndex = 327
        Me.TextBox97.Text = "0.0013"
        '
        'TextBox96
        '
        Me.TextBox96.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox96.Location = New System.Drawing.Point(693, 226)
        Me.TextBox96.Name = "TextBox96"
        Me.TextBox96.Size = New System.Drawing.Size(43, 22)
        Me.TextBox96.TabIndex = 326
        Me.TextBox96.Text = "0.0015"
        '
        'TextBox95
        '
        Me.TextBox95.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox95.Location = New System.Drawing.Point(639, 226)
        Me.TextBox95.Name = "TextBox95"
        Me.TextBox95.Size = New System.Drawing.Size(43, 22)
        Me.TextBox95.TabIndex = 325
        Me.TextBox95.Text = "0.0017"
        '
        'TextBox94
        '
        Me.TextBox94.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox94.Location = New System.Drawing.Point(585, 226)
        Me.TextBox94.Name = "TextBox94"
        Me.TextBox94.Size = New System.Drawing.Size(43, 22)
        Me.TextBox94.TabIndex = 324
        Me.TextBox94.Text = "0.0019"
        '
        'TextBox93
        '
        Me.TextBox93.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox93.Location = New System.Drawing.Point(531, 226)
        Me.TextBox93.Name = "TextBox93"
        Me.TextBox93.Size = New System.Drawing.Size(43, 22)
        Me.TextBox93.TabIndex = 323
        Me.TextBox93.Text = "0.0023"
        '
        'TextBox92
        '
        Me.TextBox92.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox92.Location = New System.Drawing.Point(477, 226)
        Me.TextBox92.Name = "TextBox92"
        Me.TextBox92.Size = New System.Drawing.Size(43, 22)
        Me.TextBox92.TabIndex = 322
        Me.TextBox92.Text = "0.0028"
        '
        'TextBox91
        '
        Me.TextBox91.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox91.Location = New System.Drawing.Point(423, 226)
        Me.TextBox91.Name = "TextBox91"
        Me.TextBox91.Size = New System.Drawing.Size(43, 22)
        Me.TextBox91.TabIndex = 321
        Me.TextBox91.Text = "0.0036"
        '
        'TextBox90
        '
        Me.TextBox90.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox90.Location = New System.Drawing.Point(369, 226)
        Me.TextBox90.Name = "TextBox90"
        Me.TextBox90.Size = New System.Drawing.Size(43, 22)
        Me.TextBox90.TabIndex = 320
        Me.TextBox90.Text = "0.0045"
        '
        'TextBox89
        '
        Me.TextBox89.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox89.Location = New System.Drawing.Point(315, 226)
        Me.TextBox89.Name = "TextBox89"
        Me.TextBox89.Size = New System.Drawing.Size(43, 22)
        Me.TextBox89.TabIndex = 319
        Me.TextBox89.Text = "0.0056"
        '
        'TextBox88
        '
        Me.TextBox88.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox88.Location = New System.Drawing.Point(261, 226)
        Me.TextBox88.Name = "TextBox88"
        Me.TextBox88.Size = New System.Drawing.Size(43, 22)
        Me.TextBox88.TabIndex = 318
        Me.TextBox88.Text = "0.0065"
        '
        'TextBox87
        '
        Me.TextBox87.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox87.Location = New System.Drawing.Point(857, 200)
        Me.TextBox87.Name = "TextBox87"
        Me.TextBox87.Size = New System.Drawing.Size(45, 22)
        Me.TextBox87.TabIndex = 317
        Me.TextBox87.Text = "0.0014"
        '
        'TextBox86
        '
        Me.TextBox86.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox86.Location = New System.Drawing.Point(801, 200)
        Me.TextBox86.Name = "TextBox86"
        Me.TextBox86.Size = New System.Drawing.Size(43, 22)
        Me.TextBox86.TabIndex = 316
        Me.TextBox86.Text = "0.0017"
        '
        'TextBox85
        '
        Me.TextBox85.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox85.Location = New System.Drawing.Point(747, 200)
        Me.TextBox85.Name = "TextBox85"
        Me.TextBox85.Size = New System.Drawing.Size(43, 22)
        Me.TextBox85.TabIndex = 315
        Me.TextBox85.Text = "0.0019"
        '
        'TextBox84
        '
        Me.TextBox84.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox84.Location = New System.Drawing.Point(693, 200)
        Me.TextBox84.Name = "TextBox84"
        Me.TextBox84.Size = New System.Drawing.Size(43, 22)
        Me.TextBox84.TabIndex = 314
        Me.TextBox84.Text = "0.0021"
        '
        'TextBox83
        '
        Me.TextBox83.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox83.Location = New System.Drawing.Point(639, 200)
        Me.TextBox83.Name = "TextBox83"
        Me.TextBox83.Size = New System.Drawing.Size(43, 22)
        Me.TextBox83.TabIndex = 313
        Me.TextBox83.Text = "0.0024"
        '
        'TextBox82
        '
        Me.TextBox82.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox82.Location = New System.Drawing.Point(585, 200)
        Me.TextBox82.Name = "TextBox82"
        Me.TextBox82.Size = New System.Drawing.Size(43, 22)
        Me.TextBox82.TabIndex = 312
        Me.TextBox82.Text = "0.0028"
        '
        'TextBox81
        '
        Me.TextBox81.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox81.Location = New System.Drawing.Point(531, 200)
        Me.TextBox81.Name = "TextBox81"
        Me.TextBox81.Size = New System.Drawing.Size(43, 22)
        Me.TextBox81.TabIndex = 311
        Me.TextBox81.Text = "0.0034"
        '
        'TextBox80
        '
        Me.TextBox80.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox80.Location = New System.Drawing.Point(477, 200)
        Me.TextBox80.Name = "TextBox80"
        Me.TextBox80.Size = New System.Drawing.Size(43, 22)
        Me.TextBox80.TabIndex = 310
        Me.TextBox80.Text = "0.0042"
        '
        'TextBox79
        '
        Me.TextBox79.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox79.Location = New System.Drawing.Point(423, 200)
        Me.TextBox79.Name = "TextBox79"
        Me.TextBox79.Size = New System.Drawing.Size(43, 22)
        Me.TextBox79.TabIndex = 309
        Me.TextBox79.Text = "0.0056"
        '
        'TextBox78
        '
        Me.TextBox78.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox78.Location = New System.Drawing.Point(369, 200)
        Me.TextBox78.Name = "TextBox78"
        Me.TextBox78.Size = New System.Drawing.Size(43, 22)
        Me.TextBox78.TabIndex = 308
        Me.TextBox78.Text = "0.0071"
        '
        'TextBox77
        '
        Me.TextBox77.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox77.Location = New System.Drawing.Point(315, 200)
        Me.TextBox77.Name = "TextBox77"
        Me.TextBox77.Size = New System.Drawing.Size(43, 22)
        Me.TextBox77.TabIndex = 307
        Me.TextBox77.Text = "0.009"
        '
        'TextBox76
        '
        Me.TextBox76.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox76.Location = New System.Drawing.Point(261, 200)
        Me.TextBox76.Name = "TextBox76"
        Me.TextBox76.Size = New System.Drawing.Size(43, 22)
        Me.TextBox76.TabIndex = 306
        Me.TextBox76.Text = "0.0104"
        '
        'TextBox75
        '
        Me.TextBox75.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox75.Location = New System.Drawing.Point(857, 174)
        Me.TextBox75.Name = "TextBox75"
        Me.TextBox75.Size = New System.Drawing.Size(45, 22)
        Me.TextBox75.TabIndex = 305
        Me.TextBox75.Text = "0"
        '
        'TextBox74
        '
        Me.TextBox74.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox74.Location = New System.Drawing.Point(801, 174)
        Me.TextBox74.Name = "TextBox74"
        Me.TextBox74.Size = New System.Drawing.Size(43, 22)
        Me.TextBox74.TabIndex = 304
        Me.TextBox74.Text = "0"
        '
        'TextBox73
        '
        Me.TextBox73.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox73.Location = New System.Drawing.Point(747, 174)
        Me.TextBox73.Name = "TextBox73"
        Me.TextBox73.Size = New System.Drawing.Size(43, 22)
        Me.TextBox73.TabIndex = 303
        Me.TextBox73.Text = "0"
        '
        'TextBox72
        '
        Me.TextBox72.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox72.Location = New System.Drawing.Point(693, 174)
        Me.TextBox72.Name = "TextBox72"
        Me.TextBox72.Size = New System.Drawing.Size(43, 22)
        Me.TextBox72.TabIndex = 302
        Me.TextBox72.Text = "0"
        '
        'TextBox71
        '
        Me.TextBox71.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox71.Location = New System.Drawing.Point(639, 174)
        Me.TextBox71.Name = "TextBox71"
        Me.TextBox71.Size = New System.Drawing.Size(43, 22)
        Me.TextBox71.TabIndex = 301
        Me.TextBox71.Text = "0"
        '
        'TextBox70
        '
        Me.TextBox70.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox70.Location = New System.Drawing.Point(585, 174)
        Me.TextBox70.Name = "TextBox70"
        Me.TextBox70.Size = New System.Drawing.Size(43, 22)
        Me.TextBox70.TabIndex = 300
        Me.TextBox70.Text = "0"
        '
        'TextBox69
        '
        Me.TextBox69.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox69.Location = New System.Drawing.Point(531, 174)
        Me.TextBox69.Name = "TextBox69"
        Me.TextBox69.Size = New System.Drawing.Size(43, 22)
        Me.TextBox69.TabIndex = 299
        Me.TextBox69.Text = "0"
        '
        'TextBox68
        '
        Me.TextBox68.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox68.Location = New System.Drawing.Point(477, 174)
        Me.TextBox68.Name = "TextBox68"
        Me.TextBox68.Size = New System.Drawing.Size(43, 22)
        Me.TextBox68.TabIndex = 298
        Me.TextBox68.Text = "0"
        '
        'TextBox67
        '
        Me.TextBox67.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox67.Location = New System.Drawing.Point(423, 174)
        Me.TextBox67.Name = "TextBox67"
        Me.TextBox67.Size = New System.Drawing.Size(43, 22)
        Me.TextBox67.TabIndex = 297
        Me.TextBox67.Text = "0"
        '
        'TextBox66
        '
        Me.TextBox66.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox66.Location = New System.Drawing.Point(369, 174)
        Me.TextBox66.Name = "TextBox66"
        Me.TextBox66.Size = New System.Drawing.Size(43, 22)
        Me.TextBox66.TabIndex = 296
        Me.TextBox66.Text = "0"
        '
        'TextBox65
        '
        Me.TextBox65.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox65.Location = New System.Drawing.Point(315, 174)
        Me.TextBox65.Name = "TextBox65"
        Me.TextBox65.Size = New System.Drawing.Size(43, 22)
        Me.TextBox65.TabIndex = 295
        Me.TextBox65.Text = "0"
        '
        'TextBox64
        '
        Me.TextBox64.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox64.Location = New System.Drawing.Point(261, 174)
        Me.TextBox64.Name = "TextBox64"
        Me.TextBox64.Size = New System.Drawing.Size(43, 22)
        Me.TextBox64.TabIndex = 294
        Me.TextBox64.Text = "0"
        '
        'TextBox63
        '
        Me.TextBox63.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox63.Location = New System.Drawing.Point(857, 148)
        Me.TextBox63.Name = "TextBox63"
        Me.TextBox63.Size = New System.Drawing.Size(45, 22)
        Me.TextBox63.TabIndex = 293
        Me.TextBox63.Text = "0.003"
        '
        'TextBox62
        '
        Me.TextBox62.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox62.Location = New System.Drawing.Point(801, 148)
        Me.TextBox62.Name = "TextBox62"
        Me.TextBox62.Size = New System.Drawing.Size(43, 22)
        Me.TextBox62.TabIndex = 292
        Me.TextBox62.Text = "0.0039"
        '
        'TextBox61
        '
        Me.TextBox61.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox61.Location = New System.Drawing.Point(747, 148)
        Me.TextBox61.Name = "TextBox61"
        Me.TextBox61.Size = New System.Drawing.Size(43, 22)
        Me.TextBox61.TabIndex = 291
        Me.TextBox61.Text = "0.0046"
        '
        'TextBox60
        '
        Me.TextBox60.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox60.Location = New System.Drawing.Point(693, 148)
        Me.TextBox60.Name = "TextBox60"
        Me.TextBox60.Size = New System.Drawing.Size(43, 22)
        Me.TextBox60.TabIndex = 290
        Me.TextBox60.Text = "0.0053"
        '
        'TextBox59
        '
        Me.TextBox59.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox59.Location = New System.Drawing.Point(639, 148)
        Me.TextBox59.Name = "TextBox59"
        Me.TextBox59.Size = New System.Drawing.Size(43, 22)
        Me.TextBox59.TabIndex = 289
        Me.TextBox59.Text = "0.0064"
        '
        'TextBox58
        '
        Me.TextBox58.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox58.Location = New System.Drawing.Point(585, 148)
        Me.TextBox58.Name = "TextBox58"
        Me.TextBox58.Size = New System.Drawing.Size(43, 22)
        Me.TextBox58.TabIndex = 288
        Me.TextBox58.Text = "0.0078"
        '
        'TextBox57
        '
        Me.TextBox57.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox57.Location = New System.Drawing.Point(531, 148)
        Me.TextBox57.Name = "TextBox57"
        Me.TextBox57.Size = New System.Drawing.Size(43, 22)
        Me.TextBox57.TabIndex = 288
        Me.TextBox57.Text = "0.0098"
        '
        'TextBox52
        '
        Me.TextBox52.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox52.Location = New System.Drawing.Point(261, 148)
        Me.TextBox52.Name = "TextBox52"
        Me.TextBox52.Size = New System.Drawing.Size(43, 22)
        Me.TextBox52.TabIndex = 284
        Me.TextBox52.Text = "0.0455"
        '
        'TextBox51
        '
        Me.TextBox51.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox51.Location = New System.Drawing.Point(857, 122)
        Me.TextBox51.Name = "TextBox51"
        Me.TextBox51.Size = New System.Drawing.Size(45, 22)
        Me.TextBox51.TabIndex = 283
        Me.TextBox51.Text = "0.042"
        '
        'TextBox50
        '
        Me.TextBox50.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox50.Location = New System.Drawing.Point(801, 122)
        Me.TextBox50.Name = "TextBox50"
        Me.TextBox50.Size = New System.Drawing.Size(43, 22)
        Me.TextBox50.TabIndex = 282
        Me.TextBox50.Text = "0.042"
        '
        'TextBox49
        '
        Me.TextBox49.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox49.Location = New System.Drawing.Point(747, 122)
        Me.TextBox49.Name = "TextBox49"
        Me.TextBox49.Size = New System.Drawing.Size(43, 22)
        Me.TextBox49.TabIndex = 281
        Me.TextBox49.Text = "0.042"
        '
        'TextBox48
        '
        Me.TextBox48.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox48.Location = New System.Drawing.Point(693, 122)
        Me.TextBox48.Name = "TextBox48"
        Me.TextBox48.Size = New System.Drawing.Size(43, 22)
        Me.TextBox48.TabIndex = 280
        Me.TextBox48.Text = "0.042"
        '
        'TextBox47
        '
        Me.TextBox47.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox47.Location = New System.Drawing.Point(639, 122)
        Me.TextBox47.Name = "TextBox47"
        Me.TextBox47.Size = New System.Drawing.Size(43, 22)
        Me.TextBox47.TabIndex = 279
        Me.TextBox47.Text = "0.042"
        '
        'TextBox46
        '
        Me.TextBox46.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox46.Location = New System.Drawing.Point(585, 122)
        Me.TextBox46.Name = "TextBox46"
        Me.TextBox46.Size = New System.Drawing.Size(43, 22)
        Me.TextBox46.TabIndex = 278
        Me.TextBox46.Text = "0"
        '
        'TextBox45
        '
        Me.TextBox45.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox45.Location = New System.Drawing.Point(531, 122)
        Me.TextBox45.Name = "TextBox45"
        Me.TextBox45.Size = New System.Drawing.Size(43, 22)
        Me.TextBox45.TabIndex = 277
        Me.TextBox45.Text = "0"
        '
        'TextBox44
        '
        Me.TextBox44.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox44.Location = New System.Drawing.Point(477, 122)
        Me.TextBox44.Name = "TextBox44"
        Me.TextBox44.Size = New System.Drawing.Size(43, 22)
        Me.TextBox44.TabIndex = 276
        Me.TextBox44.Text = "0"
        '
        'TextBox43
        '
        Me.TextBox43.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox43.Location = New System.Drawing.Point(423, 122)
        Me.TextBox43.Name = "TextBox43"
        Me.TextBox43.Size = New System.Drawing.Size(43, 22)
        Me.TextBox43.TabIndex = 275
        Me.TextBox43.Text = "0"
        '
        'TextBox42
        '
        Me.TextBox42.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox42.Location = New System.Drawing.Point(369, 122)
        Me.TextBox42.Name = "TextBox42"
        Me.TextBox42.Size = New System.Drawing.Size(43, 22)
        Me.TextBox42.TabIndex = 274
        Me.TextBox42.Text = "0"
        '
        'TextBox41
        '
        Me.TextBox41.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox41.Location = New System.Drawing.Point(315, 122)
        Me.TextBox41.Name = "TextBox41"
        Me.TextBox41.Size = New System.Drawing.Size(43, 22)
        Me.TextBox41.TabIndex = 273
        Me.TextBox41.Text = "0"
        '
        'TextBox40
        '
        Me.TextBox40.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox40.Location = New System.Drawing.Point(261, 122)
        Me.TextBox40.Name = "TextBox40"
        Me.TextBox40.Size = New System.Drawing.Size(43, 22)
        Me.TextBox40.TabIndex = 272
        Me.TextBox40.Text = "0"
        '
        'TextBox39
        '
        Me.TextBox39.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox39.Location = New System.Drawing.Point(857, 96)
        Me.TextBox39.Name = "TextBox39"
        Me.TextBox39.Size = New System.Drawing.Size(45, 22)
        Me.TextBox39.TabIndex = 271
        Me.TextBox39.Text = "0.0074"
        '
        'TextBox38
        '
        Me.TextBox38.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox38.Location = New System.Drawing.Point(801, 96)
        Me.TextBox38.Name = "TextBox38"
        Me.TextBox38.Size = New System.Drawing.Size(43, 22)
        Me.TextBox38.TabIndex = 270
        Me.TextBox38.Text = "0.0081"
        '
        'TextBox37
        '
        Me.TextBox37.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox37.Location = New System.Drawing.Point(747, 96)
        Me.TextBox37.Name = "TextBox37"
        Me.TextBox37.Size = New System.Drawing.Size(43, 22)
        Me.TextBox37.TabIndex = 269
        Me.TextBox37.Text = "0.0095"
        '
        'TextBox36
        '
        Me.TextBox36.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox36.Location = New System.Drawing.Point(693, 96)
        Me.TextBox36.Name = "TextBox36"
        Me.TextBox36.Size = New System.Drawing.Size(43, 22)
        Me.TextBox36.TabIndex = 268
        Me.TextBox36.Text = "0.0108"
        '
        'TextBox35
        '
        Me.TextBox35.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox35.Location = New System.Drawing.Point(639, 96)
        Me.TextBox35.Name = "TextBox35"
        Me.TextBox35.Size = New System.Drawing.Size(43, 22)
        Me.TextBox35.TabIndex = 267
        Me.TextBox35.Text = "0.0126"
        '
        'TextBox34
        '
        Me.TextBox34.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox34.Location = New System.Drawing.Point(585, 96)
        Me.TextBox34.Name = "TextBox34"
        Me.TextBox34.Size = New System.Drawing.Size(43, 22)
        Me.TextBox34.TabIndex = 266
        Me.TextBox34.Text = "0.0154"
        '
        'TextBox33
        '
        Me.TextBox33.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox33.Location = New System.Drawing.Point(531, 96)
        Me.TextBox33.Name = "TextBox33"
        Me.TextBox33.Size = New System.Drawing.Size(43, 22)
        Me.TextBox33.TabIndex = 265
        Me.TextBox33.Text = "0.0197"
        '
        'TextBox32
        '
        Me.TextBox32.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox32.Location = New System.Drawing.Point(477, 96)
        Me.TextBox32.Name = "TextBox32"
        Me.TextBox32.Size = New System.Drawing.Size(43, 22)
        Me.TextBox32.TabIndex = 264
        Me.TextBox32.Text = "0.0271"
        '
        'TextBox31
        '
        Me.TextBox31.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox31.Location = New System.Drawing.Point(423, 96)
        Me.TextBox31.Name = "TextBox31"
        Me.TextBox31.Size = New System.Drawing.Size(43, 22)
        Me.TextBox31.TabIndex = 263
        Me.TextBox31.Text = "0.0428"
        '
        'TextBox30
        '
        Me.TextBox30.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox30.Location = New System.Drawing.Point(369, 96)
        Me.TextBox30.Name = "TextBox30"
        Me.TextBox30.Size = New System.Drawing.Size(43, 22)
        Me.TextBox30.TabIndex = 262
        Me.TextBox30.Text = "0.0564"
        '
        'TextBox29
        '
        Me.TextBox29.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox29.Location = New System.Drawing.Point(315, 96)
        Me.TextBox29.Name = "TextBox29"
        Me.TextBox29.Size = New System.Drawing.Size(43, 22)
        Me.TextBox29.TabIndex = 261
        Me.TextBox29.Text = "0.0713"
        '
        'TextBox28
        '
        Me.TextBox28.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox28.Location = New System.Drawing.Point(261, 96)
        Me.TextBox28.Name = "TextBox28"
        Me.TextBox28.Size = New System.Drawing.Size(43, 22)
        Me.TextBox28.TabIndex = 260
        Me.TextBox28.Text = "0.0789"
        '
        'TextBox27
        '
        Me.TextBox27.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox27.Location = New System.Drawing.Point(857, 70)
        Me.TextBox27.Name = "TextBox27"
        Me.TextBox27.Size = New System.Drawing.Size(45, 22)
        Me.TextBox27.TabIndex = 259
        Me.TextBox27.Text = "0.016"
        '
        'TextBox26
        '
        Me.TextBox26.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox26.Location = New System.Drawing.Point(801, 70)
        Me.TextBox26.Name = "TextBox26"
        Me.TextBox26.Size = New System.Drawing.Size(43, 22)
        Me.TextBox26.TabIndex = 258
        Me.TextBox26.Text = "0.0186"
        '
        'TextBox25
        '
        Me.TextBox25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox25.Location = New System.Drawing.Point(747, 70)
        Me.TextBox25.Name = "TextBox25"
        Me.TextBox25.Size = New System.Drawing.Size(43, 22)
        Me.TextBox25.TabIndex = 257
        Me.TextBox25.Text = "0.0205"
        '
        'TextBox24
        '
        Me.TextBox24.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox24.Location = New System.Drawing.Point(693, 70)
        Me.TextBox24.Name = "TextBox24"
        Me.TextBox24.Size = New System.Drawing.Size(43, 22)
        Me.TextBox24.TabIndex = 256
        Me.TextBox24.Text = "0.0231"
        '
        'TextBox23
        '
        Me.TextBox23.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox23.Location = New System.Drawing.Point(639, 70)
        Me.TextBox23.Name = "TextBox23"
        Me.TextBox23.Size = New System.Drawing.Size(43, 22)
        Me.TextBox23.TabIndex = 255
        Me.TextBox23.Text = "0.0266"
        '
        'TextBox22
        '
        Me.TextBox22.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox22.Location = New System.Drawing.Point(585, 70)
        Me.TextBox22.Name = "TextBox22"
        Me.TextBox22.Size = New System.Drawing.Size(43, 22)
        Me.TextBox22.TabIndex = 254
        Me.TextBox22.Text = "0.0314"
        '
        'TextBox21
        '
        Me.TextBox21.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox21.Location = New System.Drawing.Point(531, 70)
        Me.TextBox21.Name = "TextBox21"
        Me.TextBox21.Size = New System.Drawing.Size(43, 22)
        Me.TextBox21.TabIndex = 253
        Me.TextBox21.Text = "0.0385"
        '
        'TextBox20
        '
        Me.TextBox20.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox20.Location = New System.Drawing.Point(477, 70)
        Me.TextBox20.Name = "TextBox20"
        Me.TextBox20.Size = New System.Drawing.Size(43, 22)
        Me.TextBox20.TabIndex = 252
        Me.TextBox20.Text = "0.0503"
        '
        'TextBox19
        '
        Me.TextBox19.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox19.Location = New System.Drawing.Point(423, 70)
        Me.TextBox19.Name = "TextBox19"
        Me.TextBox19.Size = New System.Drawing.Size(43, 22)
        Me.TextBox19.TabIndex = 251
        Me.TextBox19.Text = "0.0733"
        '
        'TextBox18
        '
        Me.TextBox18.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox18.Location = New System.Drawing.Point(369, 70)
        Me.TextBox18.Name = "TextBox18"
        Me.TextBox18.Size = New System.Drawing.Size(43, 22)
        Me.TextBox18.TabIndex = 250
        Me.TextBox18.Text = "0.0916"
        '
        'TextBox17
        '
        Me.TextBox17.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox17.Location = New System.Drawing.Point(315, 70)
        Me.TextBox17.Name = "TextBox17"
        Me.TextBox17.Size = New System.Drawing.Size(43, 22)
        Me.TextBox17.TabIndex = 249
        Me.TextBox17.Text = "0.108"
        '
        'TextBox16
        '
        Me.TextBox16.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox16.Location = New System.Drawing.Point(261, 70)
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(43, 22)
        Me.TextBox16.TabIndex = 248
        Me.TextBox16.Text = "0.116"
        '
        'TextBox15
        '
        Me.TextBox15.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox15.Location = New System.Drawing.Point(857, 44)
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(45, 22)
        Me.TextBox15.TabIndex = 247
        Me.TextBox15.Text = "0.058"
        '
        'TextBox14
        '
        Me.TextBox14.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox14.Location = New System.Drawing.Point(801, 44)
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(43, 22)
        Me.TextBox14.TabIndex = 246
        Me.TextBox14.Text = "0.067"
        '
        'TextBox13
        '
        Me.TextBox13.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox13.Location = New System.Drawing.Point(747, 44)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(43, 22)
        Me.TextBox13.TabIndex = 245
        Me.TextBox13.Text = "0.073"
        '
        'TextBox12
        '
        Me.TextBox12.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox12.Location = New System.Drawing.Point(693, 44)
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(43, 22)
        Me.TextBox12.TabIndex = 244
        Me.TextBox12.Text = "0.080"
        '
        'TextBox11
        '
        Me.TextBox11.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox11.Location = New System.Drawing.Point(639, 44)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(43, 22)
        Me.TextBox11.TabIndex = 243
        Me.TextBox11.Text = "0.089"
        '
        'TextBox10
        '
        Me.TextBox10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox10.Location = New System.Drawing.Point(585, 44)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(43, 22)
        Me.TextBox10.TabIndex = 242
        Me.TextBox10.Text = "0.102"
        '
        'TextBox9
        '
        Me.TextBox9.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox9.Location = New System.Drawing.Point(530, 43)
        Me.TextBox9.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(45, 22)
        Me.TextBox9.TabIndex = 241
        Me.TextBox9.Text = "0.120"
        '
        'TextBox8
        '
        Me.TextBox8.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox8.Location = New System.Drawing.Point(476, 43)
        Me.TextBox8.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(45, 22)
        Me.TextBox8.TabIndex = 240
        Me.TextBox8.Text = "0.145"
        '
        'TextBox7
        '
        Me.TextBox7.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox7.Location = New System.Drawing.Point(422, 43)
        Me.TextBox7.Margin = New System.Windows.Forms.Padding(0)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(45, 22)
        Me.TextBox7.TabIndex = 239
        Me.TextBox7.Text = "0.182"
        '
        'spray1_25
        '
        Me.spray1_25.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray1_25.Location = New System.Drawing.Point(368, 43)
        Me.spray1_25.Margin = New System.Windows.Forms.Padding(0)
        Me.spray1_25.Name = "spray1_25"
        Me.spray1_25.Size = New System.Drawing.Size(45, 22)
        Me.spray1_25.TabIndex = 238
        Me.spray1_25.Text = "0.208"
        '
        'spray1_10
        '
        Me.spray1_10.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray1_10.Location = New System.Drawing.Point(314, 43)
        Me.spray1_10.Margin = New System.Windows.Forms.Padding(0)
        Me.spray1_10.Name = "spray1_10"
        Me.spray1_10.Size = New System.Drawing.Size(45, 22)
        Me.spray1_10.TabIndex = 237
        Me.spray1_10.Text = "0.227"
        '
        'spray1_5
        '
        Me.spray1_5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.spray1_5.Location = New System.Drawing.Point(260, 43)
        Me.spray1_5.Margin = New System.Windows.Forms.Padding(0)
        Me.spray1_5.Name = "spray1_5"
        Me.spray1_5.Size = New System.Drawing.Size(45, 22)
        Me.spray1_5.TabIndex = 236
        Me.spray1_5.Text = "0.234"
        '
        'Label184
        '
        Me.Label184.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label184.AutoSize = True
        Me.Label184.Location = New System.Drawing.Point(867, 12)
        Me.Label184.Name = "Label184"
        Me.Label184.Size = New System.Drawing.Size(26, 17)
        Me.Label184.TabIndex = 235
        Me.Label184.Text = "500"
        '
        'Label183
        '
        Me.Label183.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label183.AutoSize = True
        Me.Label183.Location = New System.Drawing.Point(810, 12)
        Me.Label183.Name = "Label183"
        Me.Label183.Size = New System.Drawing.Size(26, 17)
        Me.Label183.TabIndex = 235
        Me.Label183.Text = "400"
        '
        'Label182
        '
        Me.Label182.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label182.AutoSize = True
        Me.Label182.Location = New System.Drawing.Point(756, 12)
        Me.Label182.Name = "Label182"
        Me.Label182.Size = New System.Drawing.Size(26, 17)
        Me.Label182.TabIndex = 235
        Me.Label182.Text = "350"
        '
        'Label181
        '
        Me.Label181.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label181.AutoSize = True
        Me.Label181.Location = New System.Drawing.Point(702, 12)
        Me.Label181.Name = "Label181"
        Me.Label181.Size = New System.Drawing.Size(26, 17)
        Me.Label181.TabIndex = 234
        Me.Label181.Text = "300"
        '
        'Label180
        '
        Me.Label180.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label180.AutoSize = True
        Me.Label180.Location = New System.Drawing.Point(648, 12)
        Me.Label180.Name = "Label180"
        Me.Label180.Size = New System.Drawing.Size(26, 17)
        Me.Label180.TabIndex = 234
        Me.Label180.Text = "250"
        '
        'Label179
        '
        Me.Label179.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label179.AutoSize = True
        Me.Label179.Location = New System.Drawing.Point(594, 12)
        Me.Label179.Name = "Label179"
        Me.Label179.Size = New System.Drawing.Size(26, 17)
        Me.Label179.TabIndex = 234
        Me.Label179.Text = "200"
        '
        'Label178
        '
        Me.Label178.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label178.AutoSize = True
        Me.Label178.Location = New System.Drawing.Point(540, 12)
        Me.Label178.Name = "Label178"
        Me.Label178.Size = New System.Drawing.Size(26, 17)
        Me.Label178.TabIndex = 234
        Me.Label178.Text = "150"
        '
        'Label177
        '
        Me.Label177.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label177.AutoSize = True
        Me.Label177.Location = New System.Drawing.Point(486, 12)
        Me.Label177.Name = "Label177"
        Me.Label177.Size = New System.Drawing.Size(26, 17)
        Me.Label177.TabIndex = 234
        Me.Label177.Text = "100"
        '
        'Label176
        '
        Me.Label176.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label176.AutoSize = True
        Me.Label176.Location = New System.Drawing.Point(435, 12)
        Me.Label176.Name = "Label176"
        Me.Label176.Size = New System.Drawing.Size(20, 17)
        Me.Label176.TabIndex = 234
        Me.Label176.Text = "50"
        '
        'Label175
        '
        Me.Label175.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label175.AutoSize = True
        Me.Label175.Location = New System.Drawing.Point(381, 12)
        Me.Label175.Name = "Label175"
        Me.Label175.Size = New System.Drawing.Size(20, 17)
        Me.Label175.TabIndex = 234
        Me.Label175.Text = "25"
        '
        'Label174
        '
        Me.Label174.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label174.AutoSize = True
        Me.Label174.Location = New System.Drawing.Point(327, 12)
        Me.Label174.Name = "Label174"
        Me.Label174.Size = New System.Drawing.Size(20, 17)
        Me.Label174.TabIndex = 234
        Me.Label174.Text = "10"
        '
        'Label173
        '
        Me.Label173.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label173.AutoSize = True
        Me.Label173.Location = New System.Drawing.Point(276, 12)
        Me.Label173.Name = "Label173"
        Me.Label173.Size = New System.Drawing.Size(14, 17)
        Me.Label173.TabIndex = 234
        Me.Label173.Text = "5"
        '
        'Label134
        '
        Me.Label134.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Label134.AutoSize = True
        Me.Label134.Font = New System.Drawing.Font("Courier New", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label134.Location = New System.Drawing.Point(3, 3)
        Me.Label134.Name = "Label134"
        Me.Label134.Size = New System.Drawing.Size(192, 34)
        Me.Label134.TabIndex = 210
        Me.Label134.Text = " Method ↓   \    Buffer (ft) →"
        '
        'Label172
        '
        Me.Label172.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label172.AutoSize = True
        Me.Label172.Location = New System.Drawing.Point(222, 12)
        Me.Label172.Name = "Label172"
        Me.Label172.Size = New System.Drawing.Size(14, 17)
        Me.Label172.TabIndex = 233
        Me.Label172.Text = "0"
        '
        'TextBox53
        '
        Me.TextBox53.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox53.Location = New System.Drawing.Point(315, 148)
        Me.TextBox53.Name = "TextBox53"
        Me.TextBox53.Size = New System.Drawing.Size(43, 22)
        Me.TextBox53.TabIndex = 285
        Me.TextBox53.Text = "0.0376"
        '
        'TextBox54
        '
        Me.TextBox54.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox54.Location = New System.Drawing.Point(369, 148)
        Me.TextBox54.Name = "TextBox54"
        Me.TextBox54.Size = New System.Drawing.Size(43, 22)
        Me.TextBox54.TabIndex = 286
        Me.TextBox54.Text = "0.0267"
        '
        'TextBox56
        '
        Me.TextBox56.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox56.Location = New System.Drawing.Point(423, 148)
        Me.TextBox56.Name = "TextBox56"
        Me.TextBox56.Size = New System.Drawing.Size(43, 22)
        Me.TextBox56.TabIndex = 288
        Me.TextBox56.Text = "0.0194"
        '
        'TextBox55
        '
        Me.TextBox55.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TextBox55.Location = New System.Drawing.Point(477, 148)
        Me.TextBox55.Name = "TextBox55"
        Me.TextBox55.Size = New System.Drawing.Size(43, 22)
        Me.TextBox55.TabIndex = 287
        Me.TextBox55.Text = "0.013"
        '
        'Label94
        '
        Me.Label94.AutoSize = True
        Me.Label94.Location = New System.Drawing.Point(365, 1536)
        Me.Label94.Name = "Label94"
        Me.Label94.Size = New System.Drawing.Size(109, 17)
        Me.Label94.TabIndex = 207
        Me.Label94.Text = "end waterbpody"
        '
        'OpenSingleScenarioFile
        '
        Me.OpenSingleScenarioFile.FileName = "OpenFileDialog1"
        '
        'OpenWaterbodyFile
        '
        Me.OpenWaterbodyFile.FileName = "OpenFileDialog1"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'Label129
        '
        Me.Label129.AutoSize = True
        Me.Label129.Location = New System.Drawing.Point(3, 654)
        Me.Label129.Name = "Label129"
        Me.Label129.Size = New System.Drawing.Size(161, 17)
        Me.Label129.TabIndex = 5
        Me.Label129.Text = "Directory (Double Click):"
        '
        'Label130
        '
        Me.Label130.AutoSize = True
        Me.Label130.Location = New System.Drawing.Point(3, 686)
        Me.Label130.Name = "Label130"
        Me.Label130.Size = New System.Drawing.Size(93, 17)
        Me.Label130.TabIndex = 6
        Me.Label130.Text = "Family Name:"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(989, 709)
        Me.Controls.Add(Me.Label130)
        Me.Controls.Add(Me.Label129)
        Me.Controls.Add(Me.CalculateButton)
        Me.Controls.Add(Me.IOFamilyName)
        Me.Controls.Add(Me.WorkingDirectoryLabel)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "Pesticide Water Calculator  3"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout
        Me.AdvancedTab.ResumeLayout(False)
        Me.AdvancedTab.PerformLayout
        Me.ScenarioExaminerTab.ResumeLayout(False)
        Me.ScenarioExaminerTab.PerformLayout
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel3.PerformLayout
        CType(Me.DiscretizationGridView, System.ComponentModel.ISupportInitialize).EndInit
        Me.EvergreenPanel.ResumeLayout(False)
        Me.EvergreenPanel.PerformLayout
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout
        CType(Me.HorizonGridView, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.CropGridView, System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.HydroDataGrid, System.ComponentModel.ISupportInitialize).EndInit
        Me.SchemeScenarios.ResumeLayout(False)
        Me.SchemeScenarios.PerformLayout
        Me.waterbodypanel.ResumeLayout(False)
        Me.SchemeApplications.ResumeLayout(False)
        Me.SchemeApplications.PerformLayout
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout
        CType(Me.AppTableDisplay, System.ComponentModel.ISupportInitialize).EndInit
        Me.Schemes.ResumeLayout(False)
        Me.Schemes.PerformLayout
        CType(Me.SchemeTableDisplay, System.ComponentModel.ISupportInitialize).EndInit
        Me.Chemical.ResumeLayout(False)
        Me.ChemPropertyPanel.ResumeLayout(False)
        Me.ChemPropertyPanel.PerformLayout
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout
        Me.TabControl1.ResumeLayout(False)
        Me.WatershedTab.ResumeLayout(False)
        Me.WatershedTab.PerformLayout
        Me.OptionalOutputTab.ResumeLayout(False)
        Me.OptionalOutputTab.PerformLayout
        CType(Me.AdditionalOutputGridView, System.ComponentModel.ISupportInitialize).EndInit
        Me.WaterbodyExaminerTab.ResumeLayout(False)
        Me.WaterbodyExaminerTab.PerformLayout
        CType(Me.SprayGridView, System.ComponentModel.ISupportInitialize).EndInit
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.TableLayoutPanel5.PerformLayout
        Me.ResumeLayout(False)
        Me.PerformLayout

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RetrieveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SaveFileDialogMain As SaveFileDialog
    Friend WithEvents WorkingDirectoryLabel As Label
    Friend WithEvents IOFamilyName As Label
    Friend WithEvents RetrieveMainInput As OpenFileDialog
    Friend WithEvents CalculateButton As Button
    Friend WithEvents WeatherFolderBrowser As FolderBrowserDialog
    Friend WithEvents GetWeatherFileDialog As OpenFileDialog
    Friend WithEvents OpenAndSelectScenarios As OpenFileDialog
    Friend WithEvents DataGridViewDisableButtonColumn1 As DataGridViewDisableButtonColumn
    Friend WithEvents DataGridViewButtonColumn1 As DataGridViewButtonColumn
    Friend WithEvents AdvancedTab As TabPage
    Friend WithEvents Label85 As Label
    Friend WithEvents ReturnFrequency As TextBox
    Friend WithEvents MassTransferRegion2GrandDaughter As TextBox
    Friend WithEvents MassTransferRegion2Daughter As TextBox
    Friend WithEvents MassTransferRegion2 As TextBox
    Friend WithEvents FreundlichMinimumConc As TextBox
    Friend WithEvents Nexp3Reg1 As TextBox
    Friend WithEvents Nexp2Reg1 As TextBox
    Friend WithEvents Nexp1Reg1 As TextBox
    Friend WithEvents Nexp3Reg2 As TextBox
    Friend WithEvents Nexp2Reg2 As TextBox
    Friend WithEvents Nexp1Reg2 As TextBox
    Friend WithEvents Kf3Reg2 As TextBox
    Friend WithEvents Kf2Reg2 As TextBox
    Friend WithEvents Kf1Reg2 As TextBox
    Friend WithEvents SubTimeSteps As TextBox
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents DoAdditionalFrequencies As CheckBox
    Friend WithEvents MakeHedFiles As CheckBox
    Friend WithEvents Label61 As Label
    Friend WithEvents Label59 As Label
    Friend WithEvents Label58 As Label
    Friend WithEvents Label57 As Label
    Friend WithEvents Label56 As Label
    Friend WithEvents Label55 As Label
    Friend WithEvents Label54 As Label
    Friend WithEvents Label50 As Label
    Friend WithEvents Label49 As Label
    Friend WithEvents Label48 As Label
    Friend WithEvents Label47 As Label
    Friend WithEvents Label34 As Label
    Friend WithEvents UseFreundlich As CheckBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ScenarioExaminerTab As TabPage
    Friend WithEvents EvergreenPanel As Panel
    Friend WithEvents Label43 As Label
    Friend WithEvents Label42 As Label
    Friend WithEvents Label41 As Label
    Friend WithEvents Label40 As Label
    Friend WithEvents EvergreenHoldup As TextBox
    Friend WithEvents EvergreenHt As TextBox
    Friend WithEvents EvergreenCover As TextBox
    Friend WithEvents EvergreenRoot As TextBox
    Friend WithEvents Evergreen As CheckBox
    Friend WithEvents WeatherDirectoryBox As TextBox
    Friend WithEvents latitude As TextBox
    Friend WithEvents ScenarioID As TextBox
    Friend WithEvents WeatherFileName As TextBox
    Friend WithEvents GetWeatherFileDirectory As Button
    Friend WithEvents Label62 As Label
    Friend WithEvents Label84 As Label
    Friend WithEvents albedo As TextBox
    Friend WithEvents Label83 As Label
    Friend WithEvents bcTemp As TextBox
    Friend WithEvents SimTemperature As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents IrrigateOnlyCrops As CheckBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents IrrigDepthRootZone As RadioButton
    Friend WithEvents UserSpecifiesIrrigDepth As RadioButton
    Friend WithEvents Label304 As Label
    Friend WithEvents IrrigationDepthUserSpec As TextBox
    Friend WithEvents Label53 As Label
    Friend WithEvents Label52 As Label
    Friend WithEvents Label51 As Label
    Friend WithEvents rateIrrig As TextBox
    Friend WithEvents depletion As TextBox
    Friend WithEvents fleach As TextBox
    Friend WithEvents underCanopy As RadioButton
    Friend WithEvents overCanopy As RadioButton
    Friend WithEvents noIrrigation As RadioButton
    Friend WithEvents Label21 As Label
    Friend WithEvents GetWeatherFile As Button
    Friend WithEvents HorizonGridView As DataGridView
    Friend WithEvents SchemeScenarios As TabPage
    Friend WithEvents ClearAllScenarios As Button
    Friend WithEvents ClearSelectedScenarios As Button
    Friend WithEvents SelectScenarios As Button
    Friend WithEvents ScenarioListBox As ListBox
    Friend WithEvents Label87 As Label
    Friend WithEvents Label89 As Label
    Friend WithEvents SchemeApplications As TabPage
    Friend WithEvents Label88 As Label
    Friend WithEvents Label86 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents removal As RadioButton
    Friend WithEvents maturity As RadioButton
    Friend WithEvents emerge As RadioButton
    Friend WithEvents AbsoluteDaysButton As RadioButton
    Friend WithEvents AppTableDisplay As DataGridView
    Friend WithEvents Schemes As TabPage
    Friend WithEvents SchemeTableDisplay As DataGridView
    Friend WithEvents Chemical As TabPage
    Friend WithEvents ChemPropertyPanel As TableLayoutPanel
    Friend WithEvents FoliarDeg3 As TextBox
    Friend WithEvents FoliarDeg2 As TextBox
    Friend WithEvents SoilDegradation2 As TextBox
    Friend WithEvents SoilRef2 As TextBox
    Friend WithEvents Hydrolysis2 As TextBox
    Friend WithEvents SoilRef3 As TextBox
    Friend WithEvents SoilDegradation3 As TextBox
    Friend WithEvents Hydrolysis3 As TextBox
    Friend WithEvents PhotoLat3 As TextBox
    Friend WithEvents PhotoLat2 As TextBox
    Friend WithEvents Photo3 As TextBox
    Friend WithEvents BenthicRef3 As TextBox
    Friend WithEvents Photo2 As TextBox
    Friend WithEvents BenthicMetab2 As TextBox
    Friend WithEvents BenthicMetab3 As TextBox
    Friend WithEvents BenthicRef2 As TextBox
    Friend WithEvents WaterColRef3 As TextBox
    Friend WithEvents WaterColMetab3 As TextBox
    Friend WithEvents WaterColRef2 As TextBox
    Friend WithEvents sorption3 As TextBox
    Friend WithEvents WaterColMetab2 As TextBox
    Friend WithEvents sorption2 As TextBox
    Friend WithEvents SoilRef1 As TextBox
    Friend WithEvents SoilMolarRatio2 As TextBox
    Friend WithEvents SoilMolarRatio1 As TextBox
    Friend WithEvents HydroMolarRatio2 As TextBox
    Friend WithEvents HydroMolarRatio1 As TextBox
    Friend WithEvents SoilDegradation1 As TextBox
    Friend WithEvents Hydrolysis1 As TextBox
    Friend WithEvents PhotoLat1 As TextBox
    Friend WithEvents Photo1 As TextBox
    Friend WithEvents BenthicRef1 As TextBox
    Friend WithEvents BenthicMetab1 As TextBox
    Friend WithEvents WaterColRef1 As TextBox
    Friend WithEvents WaterColMetab1 As TextBox
    Friend WithEvents PhotoMolarRatio2 As TextBox
    Friend WithEvents PhotoMolarRatio1 As TextBox
    Friend WithEvents BenthicMolarRatio2 As TextBox
    Friend WithEvents BenthicMolarRatio1 As TextBox
    Friend WithEvents WaterMolarRatio2 As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents sorption1 As TextBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents WaterMolarRatio1 As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents RadioButton9 As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents isKoc As RadioButton
    Friend WithEvents Label5 As Label
    Friend WithEvents FoliarDeg1 As TextBox
    Friend WithEvents DoDegradate2 As CheckBox
    Friend WithEvents DoDegradate1 As CheckBox
    Friend WithEvents Label17 As Label
    Friend WithEvents HeatHenry1 As TextBox
    Friend WithEvents HeatHenry2 As TextBox
    Friend WithEvents HeatHenry3 As TextBox
    Friend WithEvents AirDiff3 As TextBox
    Friend WithEvents AirDiff2 As TextBox
    Friend WithEvents AirDiff1 As TextBox
    Friend WithEvents Henry1 As TextBox
    Friend WithEvents Label16 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Sol1 As TextBox
    Friend WithEvents Henry2 As TextBox
    Friend WithEvents Henry3 As TextBox
    Friend WithEvents Sol3 As TextBox
    Friend WithEvents VaporPress3 As TextBox
    Friend WithEvents Sol2 As TextBox
    Friend WithEvents VaporPress2 As TextBox
    Friend WithEvents VaporPress1 As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents MWT1 As TextBox
    Friend WithEvents MWT2 As TextBox
    Friend WithEvents MWT3 As TextBox
    Friend WithEvents Label46 As Label
    Friend WithEvents FoliarWashoff1 As TextBox
    Friend WithEvents FoliarWashoff2 As TextBox
    Friend WithEvents FoliarWashoff3 As TextBox
    Friend WithEvents FoliarMolarRatio1 As TextBox
    Friend WithEvents FoliarMolarRatio2 As TextBox
    Friend WithEvents EstimateHenryConst As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents Label39 As Label
    Friend WithEvents FlowLength As TextBox
    Friend WithEvents slope As TextBox
    Friend WithEvents ireg As TextBox
    Friend WithEvents usleP As TextBox
    Friend WithEvents usleLS As TextBox
    Friend WithEvents usleK As TextBox
    Friend WithEvents Label33 As Label
    Friend WithEvents Label32 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents Label29 As Label
    Friend WithEvents RunoffErosionYearSpecific As RadioButton
    Friend WithEvents YearlyCycleButton As RadioButton
    Friend WithEvents HydroDataGrid As DataGridView
    Friend WithEvents Column20 As DataGridViewTextBoxColumn
    Friend WithEvents Column22 As DataGridViewTextBoxColumn
    Friend WithEvents Column23 As DataGridViewTextBoxColumn
    Friend WithEvents UseNonequilibrium As CheckBox
    Friend WithEvents Label93 As Label
    Friend WithEvents WaterBodyType As TextBox
    Friend WithEvents ErosionFlag As TextBox
    Friend WithEvents Label90 As Label
    Friend WithEvents FractionCroppedArea As TextBox
    Friend WithEvents BaseFlow As TextBox
    Friend WithEvents FlowAveraging As TextBox
    Friend WithEvents MaxDepth As TextBox
    Friend WithEvents InitialDepth As TextBox
    Friend WithEvents WaterBodyArea As TextBox
    Friend WithEvents FieldSize As TextBox
    Friend WithEvents Label82 As Label
    Friend WithEvents Label80 As Label
    Friend WithEvents Label81 As Label
    Friend WithEvents Label72 As Label
    Friend WithEvents Label75 As Label
    Friend WithEvents Label69 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents WaterColumnBiomass As TextBox
    Friend WithEvents WaterColumnDoc As TextBox
    Friend WithEvents WaterColumnFoc As TextBox
    Friend WithEvents Chlorophyll As TextBox
    Friend WithEvents SuspendedSolids As TextBox
    Friend WithEvents Dfac As TextBox
    Friend WithEvents Label73 As Label
    Friend WithEvents Label74 As Label
    Friend WithEvents Label77 As Label
    Friend WithEvents Label78 As Label
    Friend WithEvents Label79 As Label
    Friend WithEvents Label68 As Label
    Friend WithEvents BenthicBiomass As TextBox
    Friend WithEvents BenthicDOC As TextBox
    Friend WithEvents BenthicFoc As TextBox
    Friend WithEvents BenthicBulkDensity As TextBox
    Friend WithEvents BenthicPorosity As TextBox
    Friend WithEvents BenthicDepth As TextBox
    Friend WithEvents DoverDx As TextBox
    Friend WithEvents Label76 As Label
    Friend WithEvents Label70 As Label
    Friend WithEvents Label71 As Label
    Friend WithEvents Label67 As Label
    Friend WithEvents Label66 As Label
    Friend WithEvents Label65 As Label
    Friend WithEvents Label64 As Label
    Friend WithEvents VolatilizationBounday As TextBox
    Friend WithEvents PETadjustment As TextBox
    Friend WithEvents snowMelt As TextBox
    Friend WithEvents evapDepth As TextBox
    Friend WithEvents Label44 As Label
    Friend WithEvents Label37 As Label
    Friend WithEvents Label36 As Label
    Friend WithEvents Label35 As Label
    Friend WithEvents Q10 As TextBox
    Friend WithEvents eInteracting As TextBox
    Friend WithEvents rDecline As TextBox
    Friend WithEvents rInteracting As TextBox
    Friend WithEvents eDepth As TextBox
    Friend WithEvents eDecline As TextBox
    Friend WithEvents rDepth As TextBox
    Friend WithEvents Label45 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label28 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents AdjustCN As CheckBox
    Friend WithEvents CropGridView As DataGridView
    Friend WithEvents waterbodypanel As Panel
    Friend WithEvents ClearAllWaterBodies As Button
    Friend WithEvents ClearSelectedWaterBody As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents WaterbodyList As ListBox
    Friend WithEvents ItsOther As CheckBox
    Friend WithEvents ItsaReservoir As CheckBox
    Friend WithEvents ItsaPond As CheckBox
    Friend WithEvents Label95 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PushToSaveScenario As Button
    Friend WithEvents PushToLoadScenario As Button
    Friend WithEvents PushToSaveWaterBody As Button
    Friend WithEvents PushToLoadWaterBody As Button
    Friend WithEvents Label92 As Label
    Friend WithEvents Label91 As Label
    Friend WithEvents Label97 As Label
    Friend WithEvents Label96 As Label
    Friend WithEvents Label98 As Label
    Friend WithEvents Label99 As Label
    Friend WithEvents OpenSingleScenarioFile As OpenFileDialog
    Friend WithEvents SaveSingleScenarioFile As SaveFileDialog
    Friend WithEvents OpenWaterbodyFile As OpenFileDialog
    Friend WithEvents SaveWaterbodyFile As SaveFileDialog
    Friend WithEvents Label100 As Label
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents IsAqueousDegradation As RadioButton
    Friend WithEvents IsAllMedia As RadioButton
    Friend WithEvents Label63 As Label
    Friend WithEvents Label101 As Label
    Friend WithEvents Column21 As DataGridViewTextBoxColumn
    Friend WithEvents Edit As DataGridViewCheckBoxColumn
    Friend WithEvents Commit As DataGridViewDisableButtonColumn
    Friend WithEvents Column24 As DataGridViewTextBoxColumn
    Friend WithEvents Delete As DataGridViewButtonColumn
    Friend WithEvents WatershedTab As TabPage
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer1 As Timer
    Friend WithEvents Label103 As Label
    Friend WithEvents OptionalOutputTab As TabPage
    Friend WithEvents outputPestErosion As CheckBox
    Friend WithEvents outputErosion As CheckBox
    Friend WithEvents outputPestRunoff As CheckBox
    Friend WithEvents outputRunoff As CheckBox
    Friend WithEvents Label293 As Label
    Friend WithEvents OutputMassDepth1 As TextBox
    Friend WithEvents Label294 As Label
    Friend WithEvents Label288 As Label
    Friend WithEvents Label289 As Label
    Friend WithEvents OutputDecayDepth2 As TextBox
    Friend WithEvents OutputDecayDepth1 As TextBox
    Friend WithEvents Label286 As Label
    Friend WithEvents Label285 As Label
    Friend WithEvents OutputMassDepth2 As TextBox
    Friend WithEvents outputPrecipitation As CheckBox
    Friend WithEvents outputIrrigation As CheckBox
    Friend WithEvents Label284 As Label
    Friend WithEvents OutputInfiltrationDepth As TextBox
    Friend WithEvents outputInfiltrationAtDepth As CheckBox
    Friend WithEvents outputTotalSoilWater As CheckBox
    Friend WithEvents outputActualEvap As CheckBox
    Friend WithEvents outputNonEquilibriumMass As CheckBox
    Friend WithEvents outputEquilibriumMass As CheckBox
    Friend WithEvents outputMassSoilSpecific As CheckBox
    Friend WithEvents OutputDecayedPest As CheckBox
    Friend WithEvents OutputDailyPestLeached As CheckBox
    Friend WithEvents outputMassOnFoliage As CheckBox
    Friend WithEvents outputMassInSoilProfile As CheckBox
    Friend WithEvents outputDailyFieldVolatilization As CheckBox
    Friend WithEvents outputConcLastLayer As CheckBox
    Friend WithEvents outputInfiltratedWaterLastLayer As CheckBox
    Friend WithEvents Label102 As Label
    Friend WithEvents MorenTabsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToggleAdvancedToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToggleMoreOutputToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToggleScenarioExaminerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AdditionalOutputGridView As DataGridView
    Friend WithEvents Label104 As Label
    Friend WithEvents Label105 As Label
    Friend WithEvents chemInfiltrationDepth As TextBox
    Friend WithEvents Item As DataGridViewTextBoxColumn
    Friend WithEvents Column10 As DataGridViewTextBoxColumn
    Friend WithEvents Mode As DataGridViewTextBoxColumn
    Friend WithEvents Bound1 As DataGridViewTextBoxColumn
    Friend WithEvents Bound2 As DataGridViewTextBoxColumn
    Friend WithEvents Column11 As DataGridViewTextBoxColumn
    Friend WithEvents Column12 As DataGridViewButtonColumn
    Friend WithEvents Label109 As Label
    Friend WithEvents Label110 As Label
    Friend WithEvents ExpParameter2 As TextBox
    Friend WithEvents ExpParameter1 As TextBox
    Friend WithEvents ExponentialProfile As RadioButton
    Friend WithEvents Label108 As Label
    Friend WithEvents Label107 As Label
    Friend WithEvents Label106 As Label
    Friend WithEvents RampEndValue As TextBox
    Friend WithEvents ProfileDepth2 As TextBox
    Friend WithEvents profileDepth1 As TextBox
    Friend WithEvents RampProfile As RadioButton
    Friend WithEvents Label60 As Label
    Friend WithEvents ConstantProfile As RadioButton
    Friend WithEvents UseApplicationWindow As CheckBox
    Friend WithEvents Label113 As Label
    Friend WithEvents Label112 As Label
    Friend WithEvents ApplicationWindowStep As TextBox
    Friend WithEvents ApplicationWindowDays As TextBox
    Friend WithEvents DataGridViewTextBoxColumn1 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewComboBoxColumn1 As DataGridViewComboBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As DataGridViewTextBoxColumn
    Friend WithEvents Label115 As Label
    Friend WithEvents Label114 As Label
    Friend WithEvents spray4 As TextBox
    Friend WithEvents spray3 As TextBox
    Friend WithEvents spray2 As TextBox
    Friend WithEvents spray1 As TextBox
    Friend WithEvents Label111 As Label
    Friend WithEvents Label117 As Label
    Friend WithEvents Label116 As Label
    Friend WithEvents spray12 As TextBox
    Friend WithEvents spray11 As TextBox
    Friend WithEvents spray10 As TextBox
    Friend WithEvents spray9 As TextBox
    Friend WithEvents Label122 As Label
    Friend WithEvents Label123 As Label
    Friend WithEvents Label124 As Label
    Friend WithEvents Label125 As Label
    Friend WithEvents Label118 As Label
    Friend WithEvents Label119 As Label
    Friend WithEvents Label120 As Label
    Friend WithEvents Label121 As Label
    Friend WithEvents spray8 As TextBox
    Friend WithEvents spray7 As TextBox
    Friend WithEvents spray6 As TextBox
    Friend WithEvents spray5 As TextBox
    Friend WithEvents spray14 As TextBox
    Friend WithEvents spray13 As TextBox
    Friend WithEvents Label126 As Label
    Friend WithEvents Label127 As Label
    Friend WithEvents Label128 As Label
    Friend WithEvents outputWaterConc As CheckBox
    Friend WithEvents UseRainFast As CheckBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label344 As Label
    Friend WithEvents Label342 As Label
    Friend WithEvents Label343 As Label
    Friend WithEvents Label341 As Label
    Friend WithEvents MinDaysBetweenApps As TextBox
    Friend WithEvents OptimumApplicationWindow As TextBox
    Friend WithEvents IntolerableRainWindow As TextBox
    Friend WithEvents RainLimit As TextBox
    Friend WithEvents Label129 As Label
    Friend WithEvents Label130 As Label
    Friend WithEvents Label132 As Label
    Friend WithEvents Label131 As Label
    Friend WithEvents DiscretizationGridView As DataGridView
    Friend WithEvents Label135 As Label
    Friend WithEvents useAutoGWprofile As CheckBox
    Friend WithEvents Thickness As DataGridViewTextBoxColumn
    Friend WithEvents Increments As DataGridViewTextBoxColumn
    Friend WithEvents Column1 As DataGridViewTextBoxColumn
    Friend WithEvents Column2 As DataGridViewTextBoxColumn
    Friend WithEvents Column3 As DataGridViewTextBoxColumn
    Friend WithEvents Column4 As DataGridViewTextBoxColumn
    Friend WithEvents Column5 As DataGridViewTextBoxColumn
    Friend WithEvents Column6 As DataGridViewTextBoxColumn
    Friend WithEvents Column7 As DataGridViewTextBoxColumn
    Friend WithEvents Column8 As DataGridViewTextBoxColumn
    Friend WithEvents Column9 As DataGridViewTextBoxColumn
    Friend WithEvents Column13 As DataGridViewDisableButtonColumn
    Friend WithEvents Label133 As Label
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Label170 As Label
    Friend WithEvents Label169 As Label
    Friend WithEvents Label168 As Label
    Friend WithEvents Label167 As Label
    Friend WithEvents Label166 As Label
    Friend WithEvents Label165 As Label
    Friend WithEvents Label164 As Label
    Friend WithEvents Label163 As Label
    Friend WithEvents Label162 As Label
    Friend WithEvents Label161 As Label
    Friend WithEvents Label160 As Label
    Friend WithEvents Label159 As Label
    Friend WithEvents Label158 As Label
    Friend WithEvents Label157 As Label
    Friend WithEvents Label156 As Label
    Friend WithEvents Label155 As Label
    Friend WithEvents Label154 As Label
    Friend WithEvents Label151 As Label
    Friend WithEvents Label150 As Label
    Friend WithEvents Label149 As Label
    Friend WithEvents Label146 As Label
    Friend WithEvents Label145 As Label
    Friend WithEvents Label144 As Label
    Friend WithEvents Label140 As Label
    Friend WithEvents Label139 As Label
    Friend WithEvents Label138 As Label
    Friend WithEvents Label137 As Label
    Friend WithEvents Label141 As Label
    Friend WithEvents Label153 As Label
    Friend WithEvents Label152 As Label
    Friend WithEvents Label148 As Label
    Friend WithEvents Label147 As Label
    Friend WithEvents Label143 As Label
    Friend WithEvents Label142 As Label
    Friend WithEvents Label136 As Label
    Friend WithEvents Label171 As Label
    Friend WithEvents ToggeWaterbodyExaminerToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WaterbodyExaminerTab As TabPage
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Label134 As Label
    Friend WithEvents Label94 As Label
    Friend WithEvents Label181 As Label
    Friend WithEvents Label180 As Label
    Friend WithEvents Label179 As Label
    Friend WithEvents Label178 As Label
    Friend WithEvents Label177 As Label
    Friend WithEvents Label176 As Label
    Friend WithEvents Label175 As Label
    Friend WithEvents Label174 As Label
    Friend WithEvents Label173 As Label
    Friend WithEvents Label172 As Label
    Friend WithEvents Label184 As Label
    Friend WithEvents Label183 As Label
    Friend WithEvents Label182 As Label
    Friend WithEvents TextBox52 As TextBox
    Friend WithEvents TextBox51 As TextBox
    Friend WithEvents TextBox50 As TextBox
    Friend WithEvents TextBox49 As TextBox
    Friend WithEvents TextBox48 As TextBox
    Friend WithEvents TextBox47 As TextBox
    Friend WithEvents TextBox46 As TextBox
    Friend WithEvents TextBox45 As TextBox
    Friend WithEvents TextBox44 As TextBox
    Friend WithEvents TextBox43 As TextBox
    Friend WithEvents TextBox42 As TextBox
    Friend WithEvents TextBox41 As TextBox
    Friend WithEvents TextBox40 As TextBox
    Friend WithEvents TextBox39 As TextBox
    Friend WithEvents TextBox38 As TextBox
    Friend WithEvents TextBox37 As TextBox
    Friend WithEvents TextBox36 As TextBox
    Friend WithEvents TextBox35 As TextBox
    Friend WithEvents TextBox34 As TextBox
    Friend WithEvents TextBox33 As TextBox
    Friend WithEvents TextBox32 As TextBox
    Friend WithEvents TextBox31 As TextBox
    Friend WithEvents TextBox30 As TextBox
    Friend WithEvents TextBox29 As TextBox
    Friend WithEvents TextBox28 As TextBox
    Friend WithEvents TextBox27 As TextBox
    Friend WithEvents TextBox26 As TextBox
    Friend WithEvents TextBox25 As TextBox
    Friend WithEvents TextBox24 As TextBox
    Friend WithEvents TextBox23 As TextBox
    Friend WithEvents TextBox22 As TextBox
    Friend WithEvents TextBox21 As TextBox
    Friend WithEvents TextBox20 As TextBox
    Friend WithEvents TextBox19 As TextBox
    Friend WithEvents TextBox18 As TextBox
    Friend WithEvents TextBox17 As TextBox
    Friend WithEvents TextBox16 As TextBox
    Friend WithEvents TextBox15 As TextBox
    Friend WithEvents TextBox14 As TextBox
    Friend WithEvents TextBox13 As TextBox
    Friend WithEvents TextBox12 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox9 As TextBox
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents spray1_25 As TextBox
    Friend WithEvents spray1_10 As TextBox
    Friend WithEvents spray1_5 As TextBox
    Friend WithEvents TextBox171 As TextBox
    Friend WithEvents TextBox170 As TextBox
    Friend WithEvents TextBox169 As TextBox
    Friend WithEvents TextBox168 As TextBox
    Friend WithEvents TextBox167 As TextBox
    Friend WithEvents TextBox166 As TextBox
    Friend WithEvents TextBox165 As TextBox
    Friend WithEvents TextBox164 As TextBox
    Friend WithEvents TextBox163 As TextBox
    Friend WithEvents TextBox162 As TextBox
    Friend WithEvents TextBox161 As TextBox
    Friend WithEvents TextBox160 As TextBox
    Friend WithEvents TextBox159 As TextBox
    Friend WithEvents TextBox158 As TextBox
    Friend WithEvents TextBox157 As TextBox
    Friend WithEvents TextBox156 As TextBox
    Friend WithEvents TextBox155 As TextBox
    Friend WithEvents TextBox154 As TextBox
    Friend WithEvents TextBox153 As TextBox
    Friend WithEvents TextBox152 As TextBox
    Friend WithEvents TextBox151 As TextBox
    Friend WithEvents TextBox150 As TextBox
    Friend WithEvents TextBox149 As TextBox
    Friend WithEvents TextBox148 As TextBox
    Friend WithEvents TextBox147 As TextBox
    Friend WithEvents TextBox146 As TextBox
    Friend WithEvents TextBox145 As TextBox
    Friend WithEvents TextBox144 As TextBox
    Friend WithEvents TextBox143 As TextBox
    Friend WithEvents TextBox142 As TextBox
    Friend WithEvents TextBox141 As TextBox
    Friend WithEvents TextBox140 As TextBox
    Friend WithEvents TextBox139 As TextBox
    Friend WithEvents TextBox138 As TextBox
    Friend WithEvents TextBox137 As TextBox
    Friend WithEvents TextBox136 As TextBox
    Friend WithEvents TextBox135 As TextBox
    Friend WithEvents TextBox134 As TextBox
    Friend WithEvents TextBox133 As TextBox
    Friend WithEvents TextBox132 As TextBox
    Friend WithEvents TextBox131 As TextBox
    Friend WithEvents TextBox130 As TextBox
    Friend WithEvents TextBox129 As TextBox
    Friend WithEvents TextBox128 As TextBox
    Friend WithEvents TextBox127 As TextBox
    Friend WithEvents TextBox126 As TextBox
    Friend WithEvents TextBox125 As TextBox
    Friend WithEvents TextBox124 As TextBox
    Friend WithEvents TextBox123 As TextBox
    Friend WithEvents TextBox120 As TextBox
    Friend WithEvents TextBox122 As TextBox
    Friend WithEvents TextBox121 As TextBox
    Friend WithEvents TextBox119 As TextBox
    Friend WithEvents TextBox118 As TextBox
    Friend WithEvents TextBox117 As TextBox
    Friend WithEvents TextBox116 As TextBox
    Friend WithEvents TextBox115 As TextBox
    Friend WithEvents TextBox114 As TextBox
    Friend WithEvents TextBox113 As TextBox
    Friend WithEvents TextBox112 As TextBox
    Friend WithEvents TextBox111 As TextBox
    Friend WithEvents TextBox110 As TextBox
    Friend WithEvents TextBox109 As TextBox
    Friend WithEvents TextBox108 As TextBox
    Friend WithEvents TextBox107 As TextBox
    Friend WithEvents TextBox106 As TextBox
    Friend WithEvents TextBox105 As TextBox
    Friend WithEvents TextBox104 As TextBox
    Friend WithEvents TextBox103 As TextBox
    Friend WithEvents TextBox102 As TextBox
    Friend WithEvents TextBox101 As TextBox
    Friend WithEvents TextBox100 As TextBox
    Friend WithEvents TextBox99 As TextBox
    Friend WithEvents TextBox98 As TextBox
    Friend WithEvents TextBox97 As TextBox
    Friend WithEvents TextBox96 As TextBox
    Friend WithEvents TextBox95 As TextBox
    Friend WithEvents TextBox94 As TextBox
    Friend WithEvents TextBox93 As TextBox
    Friend WithEvents TextBox92 As TextBox
    Friend WithEvents TextBox91 As TextBox
    Friend WithEvents TextBox90 As TextBox
    Friend WithEvents TextBox89 As TextBox
    Friend WithEvents TextBox88 As TextBox
    Friend WithEvents TextBox87 As TextBox
    Friend WithEvents TextBox86 As TextBox
    Friend WithEvents TextBox85 As TextBox
    Friend WithEvents TextBox84 As TextBox
    Friend WithEvents TextBox83 As TextBox
    Friend WithEvents TextBox82 As TextBox
    Friend WithEvents TextBox81 As TextBox
    Friend WithEvents TextBox80 As TextBox
    Friend WithEvents TextBox79 As TextBox
    Friend WithEvents TextBox78 As TextBox
    Friend WithEvents TextBox77 As TextBox
    Friend WithEvents TextBox76 As TextBox
    Friend WithEvents TextBox75 As TextBox
    Friend WithEvents TextBox74 As TextBox
    Friend WithEvents TextBox73 As TextBox
    Friend WithEvents TextBox72 As TextBox
    Friend WithEvents TextBox71 As TextBox
    Friend WithEvents TextBox70 As TextBox
    Friend WithEvents TextBox69 As TextBox
    Friend WithEvents TextBox68 As TextBox
    Friend WithEvents TextBox67 As TextBox
    Friend WithEvents TextBox66 As TextBox
    Friend WithEvents TextBox65 As TextBox
    Friend WithEvents TextBox64 As TextBox
    Friend WithEvents TextBox63 As TextBox
    Friend WithEvents TextBox62 As TextBox
    Friend WithEvents TextBox61 As TextBox
    Friend WithEvents TextBox60 As TextBox
    Friend WithEvents TextBox59 As TextBox
    Friend WithEvents TextBox58 As TextBox
    Friend WithEvents TextBox57 As TextBox
    Friend WithEvents TextBox53 As TextBox
    Friend WithEvents TextBox54 As TextBox
    Friend WithEvents TextBox56 As TextBox
    Friend WithEvents TextBox55 As TextBox
    Friend WithEvents SprayGridView As DataGridView
    Friend WithEvents Column14 As DataGridViewTextBoxColumn
    Friend WithEvents Column15 As DataGridViewTextBoxColumn
    Friend WithEvents Column16 As DataGridViewTextBoxColumn
    Friend WithEvents Column17 As DataGridViewTextBoxColumn
    Friend WithEvents Column18 As DataGridViewTextBoxColumn
    Friend WithEvents Column19 As DataGridViewTextBoxColumn
    Friend WithEvents Column25 As DataGridViewTextBoxColumn
    Friend WithEvents Column26 As DataGridViewTextBoxColumn
    Friend WithEvents Column27 As DataGridViewTextBoxColumn
    Friend WithEvents Column28 As DataGridViewTextBoxColumn
    Friend WithEvents Column29 As DataGridViewTextBoxColumn
    Friend WithEvents Column30 As DataGridViewTextBoxColumn
    Friend WithEvents Column31 As DataGridViewTextBoxColumn
End Class
