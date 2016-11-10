Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmJobCard
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public WithEvents AgCustomGrid1 As New AgCustomFields.AgCustomGrid

    Protected Const ColSNo As String = "S.No."
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const Col1Trouble As String = "Trouble"
    Protected Const Col1Specification As String = "Specification"

    Public WithEvents Dgl2 As New AgControls.AgDataGrid
    Protected Const Col2Item As String = "Item"
    Protected WithEvents Label28 As System.Windows.Forms.Label
    Protected WithEvents Label8 As System.Windows.Forms.Label

    Dim mNewRegNo As Boolean = False

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        EntryNCat = ClsMain.Temp_NCat.ServiceJobCard
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtRegistrationNo = New AgControls.AgTextBox
        Me.LblRegistrationNo = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtOwnerName = New AgControls.AgTextBox
        Me.LblOwnerName = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.TxtEngineNo = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.Label1 = New System.Windows.Forms.Label
        Me.LblCreditLimit = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.PnlCustomGrid = New System.Windows.Forms.Panel
        Me.TxtCustomFields = New AgControls.AgTextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtModel = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtChassisNo = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtOwnerAdd2 = New AgControls.AgTextBox
        Me.TxtOwnerCity = New AgControls.AgTextBox
        Me.LblCity = New System.Windows.Forms.Label
        Me.TxtOwnerAdd1 = New AgControls.AgTextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.TxtOwnerMobile = New AgControls.AgTextBox
        Me.LblOwnerMobile = New System.Windows.Forms.Label
        Me.TxtService_Type = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.TxtCouponNo = New AgControls.AgTextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.TxtEstSparesAmt = New AgControls.AgTextBox
        Me.TxtEstDelDate = New AgControls.AgTextBox
        Me.TxtEstLabAmt = New AgControls.AgTextBox
        Me.TxtEstDelTime = New AgControls.AgTextBox
        Me.TxtVehicleSpecification = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtInsuranceCompany = New AgControls.AgTextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtPolicyNo = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtPolicyDate = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtPolicyExpiryDate = New AgControls.AgTextBox
        Me.TxtV_Time = New AgControls.AgTextBox
        Me.TxtServiceAdvisor = New AgControls.AgTextBox
        Me.LblServiceAdvisor = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtCustomerId = New AgControls.AgTextBox
        Me.TxtServiceAdvisorMobile = New AgControls.AgTextBox
        Me.LblAvisorMobile = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.TxtVehicleUserName = New AgControls.AgTextBox
        Me.TxtMilage = New AgControls.AgTextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.TxtKeyNo = New AgControls.AgTextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.TxtSoldBy = New AgControls.AgTextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.TxtSoldDate = New AgControls.AgTextBox
        Me.LinkLabel2 = New System.Windows.Forms.LinkLabel
        Me.Pnl2 = New System.Windows.Forms.Panel
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(829, 571)
        Me.GroupBox2.Size = New System.Drawing.Size(148, 40)
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Location = New System.Drawing.Point(29, 19)
        Me.TxtStatus.Tag = ""
        '
        'CmdStatus
        '
        Me.CmdStatus.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(648, 571)
        Me.GBoxMoveToLog.Size = New System.Drawing.Size(148, 40)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Location = New System.Drawing.Point(29, 19)
        Me.TxtMoveToLog.Tag = ""
        '
        'CmdMoveToLog
        '
        Me.CmdMoveToLog.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(467, 571)
        Me.GBoxApprove.Size = New System.Drawing.Size(148, 40)
        Me.GBoxApprove.Text = "Approved By"
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(29, 19)
        Me.TxtApproveBy.Size = New System.Drawing.Size(116, 18)
        Me.TxtApproveBy.Tag = ""
        '
        'CmdDiscard
        '
        Me.CmdDiscard.Size = New System.Drawing.Size(26, 19)
        '
        'CmdApprove
        '
        Me.CmdApprove.Size = New System.Drawing.Size(26, 19)
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(168, 571)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 567)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(320, 571)
        Me.GBoxDivision.Size = New System.Drawing.Size(114, 40)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Location = New System.Drawing.Point(3, 19)
        Me.TxtDivision.Tag = ""
        '
        'TxtDocId
        '
        Me.TxtDocId.AgSelectedValue = ""
        Me.TxtDocId.BackColor = System.Drawing.Color.White
        Me.TxtDocId.Location = New System.Drawing.Point(869, 389)
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(394, 394)
        Me.LblV_No.Size = New System.Drawing.Size(71, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Invoice No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(502, 393)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(349, 39)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(275, 34)
        Me.LblV_Date.Size = New System.Drawing.Size(59, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Job Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(349, 19)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(368, 33)
        Me.TxtV_Date.Size = New System.Drawing.Size(89, 18)
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(275, 15)
        Me.LblV_Type.Size = New System.Drawing.Size(60, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Job Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(368, 13)
        Me.TxtV_Type.Size = New System.Drawing.Size(184, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(123, 19)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(8, 14)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(139, 13)
        Me.TxtSite_Code.Size = New System.Drawing.Size(131, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(822, 391)
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(454, 394)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 17)
        Me.TabControl1.Size = New System.Drawing.Size(992, 347)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.Label8)
        Me.TP1.Controls.Add(Me.TxtSoldBy)
        Me.TP1.Controls.Add(Me.Label24)
        Me.TP1.Controls.Add(Me.Label26)
        Me.TP1.Controls.Add(Me.TxtSoldDate)
        Me.TP1.Controls.Add(Me.TxtKeyNo)
        Me.TP1.Controls.Add(Me.Label23)
        Me.TP1.Controls.Add(Me.TxtMilage)
        Me.TP1.Controls.Add(Me.Label22)
        Me.TP1.Controls.Add(Me.Label21)
        Me.TP1.Controls.Add(Me.TxtVehicleUserName)
        Me.TP1.Controls.Add(Me.Label19)
        Me.TP1.Controls.Add(Me.TxtCustomerId)
        Me.TP1.Controls.Add(Me.TxtV_Time)
        Me.TP1.Controls.Add(Me.Label14)
        Me.TP1.Controls.Add(Me.TxtOwnerMobile)
        Me.TP1.Controls.Add(Me.TxtOwnerAdd2)
        Me.TP1.Controls.Add(Me.LblCity)
        Me.TP1.Controls.Add(Me.TxtOwnerAdd1)
        Me.TP1.Controls.Add(Me.LblAddress)
        Me.TP1.Controls.Add(Me.TxtChassisNo)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.TxtVehicleSpecification)
        Me.TP1.Controls.Add(Me.Label7)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.TxtInsuranceCompany)
        Me.TP1.Controls.Add(Me.TxtPolicyNo)
        Me.TP1.Controls.Add(Me.PnlCustomGrid)
        Me.TP1.Controls.Add(Me.Label16)
        Me.TP1.Controls.Add(Me.LblOwnerMobile)
        Me.TP1.Controls.Add(Me.Label15)
        Me.TP1.Controls.Add(Me.TxtModel)
        Me.TP1.Controls.Add(Me.Label6)
        Me.TP1.Controls.Add(Me.TxtOwnerCity)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtRegistrationNo)
        Me.TP1.Controls.Add(Me.TxtService_Type)
        Me.TP1.Controls.Add(Me.LblRegistrationNo)
        Me.TP1.Controls.Add(Me.TxtEngineNo)
        Me.TP1.Controls.Add(Me.Label18)
        Me.TP1.Controls.Add(Me.TxtPolicyExpiryDate)
        Me.TP1.Controls.Add(Me.Label17)
        Me.TP1.Controls.Add(Me.TxtPolicyDate)
        Me.TP1.Controls.Add(Me.LblCurrency)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblOwnerName)
        Me.TP1.Controls.Add(Me.TxtOwnerName)
        Me.TP1.Controls.Add(Me.Label11)
        Me.TP1.Controls.Add(Me.TxtCouponNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 321)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtCouponNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label11, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOwnerName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOwnerName, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label10, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPolicyDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label17, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPolicyExpiryDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label18, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtEngineNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRegistrationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtService_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRegistrationNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOwnerCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label6, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtModel, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label15, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblOwnerMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label16, 0)
        Me.TP1.Controls.SetChildIndex(Me.PnlCustomGrid, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtPolicyNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtInsuranceCompany, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label7, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleSpecification, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label9, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtChassisNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOwnerAdd1, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblCity, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOwnerAdd2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtOwnerMobile, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label14, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Time, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCustomerId, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label19, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleUserName, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label21, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label22, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtMilage, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label23, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtKeyNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSoldDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label26, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label24, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSoldBy, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label8, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        Me.Topctrl1.TabIndex = 10
        '
        'Dgl1
        '
        Me.Dgl1.AgAllowFind = True
        Me.Dgl1.AgLastColumn = -1
        Me.Dgl1.AgMandatoryColumn = 0
        Me.Dgl1.AgReadOnlyColumnColor = System.Drawing.Color.Ivory
        Me.Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.Dgl1.AgSkipReadOnlyColumns = False
        Me.Dgl1.CancelEditingControlValidating = False
        Me.Dgl1.GridSearchMethod = AgControls.AgLib.TxtSearchMethod.Comprehensive
        Me.Dgl1.Location = New System.Drawing.Point(0, 0)
        Me.Dgl1.Name = "Dgl1"
        Me.Dgl1.Size = New System.Drawing.Size(240, 150)
        Me.Dgl1.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(123, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtRegistrationNo
        '
        Me.TxtRegistrationNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtRegistrationNo.AgLastValueTag = Nothing
        Me.TxtRegistrationNo.AgLastValueText = Nothing
        Me.TxtRegistrationNo.AgMandatory = True
        Me.TxtRegistrationNo.AgMasterHelp = False
        Me.TxtRegistrationNo.AgNumberLeftPlaces = 8
        Me.TxtRegistrationNo.AgNumberNegetiveAllow = False
        Me.TxtRegistrationNo.AgNumberRightPlaces = 2
        Me.TxtRegistrationNo.AgPickFromLastValue = False
        Me.TxtRegistrationNo.AgRowFilter = ""
        Me.TxtRegistrationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRegistrationNo.AgSelectedValue = Nothing
        Me.TxtRegistrationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRegistrationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRegistrationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegistrationNo.Location = New System.Drawing.Point(139, 53)
        Me.TxtRegistrationNo.MaxLength = 20
        Me.TxtRegistrationNo.Name = "TxtRegistrationNo"
        Me.TxtRegistrationNo.Size = New System.Drawing.Size(131, 18)
        Me.TxtRegistrationNo.TabIndex = 5
        '
        'LblRegistrationNo
        '
        Me.LblRegistrationNo.AutoSize = True
        Me.LblRegistrationNo.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistrationNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistrationNo.Location = New System.Drawing.Point(8, 53)
        Me.LblRegistrationNo.Name = "LblRegistrationNo"
        Me.LblRegistrationNo.Size = New System.Drawing.Size(97, 16)
        Me.LblRegistrationNo.TabIndex = 693
        Me.LblRegistrationNo.Text = "Registration No"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(6, 393)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(356, 172)
        Me.Pnl1.TabIndex = 1
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(671, 391)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
        '
        'TxtOwnerName
        '
        Me.TxtOwnerName.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerName.AgLastValueTag = Nothing
        Me.TxtOwnerName.AgLastValueText = Nothing
        Me.TxtOwnerName.AgMandatory = True
        Me.TxtOwnerName.AgMasterHelp = False
        Me.TxtOwnerName.AgNumberLeftPlaces = 8
        Me.TxtOwnerName.AgNumberNegetiveAllow = False
        Me.TxtOwnerName.AgNumberRightPlaces = 2
        Me.TxtOwnerName.AgPickFromLastValue = False
        Me.TxtOwnerName.AgRowFilter = ""
        Me.TxtOwnerName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerName.AgSelectedValue = Nothing
        Me.TxtOwnerName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerName.Location = New System.Drawing.Point(139, 133)
        Me.TxtOwnerName.MaxLength = 100
        Me.TxtOwnerName.Name = "TxtOwnerName"
        Me.TxtOwnerName.Size = New System.Drawing.Size(413, 18)
        Me.TxtOwnerName.TabIndex = 12
        '
        'LblOwnerName
        '
        Me.LblOwnerName.AutoSize = True
        Me.LblOwnerName.BackColor = System.Drawing.Color.Transparent
        Me.LblOwnerName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerName.Location = New System.Drawing.Point(8, 134)
        Me.LblOwnerName.Name = "LblOwnerName"
        Me.LblOwnerName.Size = New System.Drawing.Size(83, 16)
        Me.LblOwnerName.TabIndex = 717
        Me.LblOwnerName.Text = "Owner Name"
        '
        'TxtRemarks
        '
        Me.TxtRemarks.AgAllowUserToEnableMasterHelp = False
        Me.TxtRemarks.AgLastValueTag = Nothing
        Me.TxtRemarks.AgLastValueText = Nothing
        Me.TxtRemarks.AgMandatory = False
        Me.TxtRemarks.AgMasterHelp = False
        Me.TxtRemarks.AgNumberLeftPlaces = 0
        Me.TxtRemarks.AgNumberNegetiveAllow = False
        Me.TxtRemarks.AgNumberRightPlaces = 0
        Me.TxtRemarks.AgPickFromLastValue = False
        Me.TxtRemarks.AgRowFilter = ""
        Me.TxtRemarks.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRemarks.AgSelectedValue = Nothing
        Me.TxtRemarks.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRemarks.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRemarks.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRemarks.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRemarks.Location = New System.Drawing.Point(690, 452)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(287, 113)
        Me.TxtRemarks.TabIndex = 9
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(586, 450)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
        '
        'TxtManualRefNo
        '
        Me.TxtManualRefNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtManualRefNo.AgLastValueTag = Nothing
        Me.TxtManualRefNo.AgLastValueText = Nothing
        Me.TxtManualRefNo.AgMandatory = False
        Me.TxtManualRefNo.AgMasterHelp = True
        Me.TxtManualRefNo.AgNumberLeftPlaces = 8
        Me.TxtManualRefNo.AgNumberNegetiveAllow = False
        Me.TxtManualRefNo.AgNumberRightPlaces = 2
        Me.TxtManualRefNo.AgPickFromLastValue = False
        Me.TxtManualRefNo.AgRowFilter = ""
        Me.TxtManualRefNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtManualRefNo.AgSelectedValue = Nothing
        Me.TxtManualRefNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtManualRefNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtManualRefNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtManualRefNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtManualRefNo.Location = New System.Drawing.Point(139, 33)
        Me.TxtManualRefNo.MaxLength = 20
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(131, 18)
        Me.TxtManualRefNo.TabIndex = 2
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(8, 34)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(83, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Job Card No."
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(275, 73)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(68, 16)
        Me.LblCurrency.TabIndex = 735
        Me.LblCurrency.Text = "Engine No"
        '
        'TxtEngineNo
        '
        Me.TxtEngineNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtEngineNo.AgLastValueTag = Nothing
        Me.TxtEngineNo.AgLastValueText = Nothing
        Me.TxtEngineNo.AgMandatory = False
        Me.TxtEngineNo.AgMasterHelp = False
        Me.TxtEngineNo.AgNumberLeftPlaces = 8
        Me.TxtEngineNo.AgNumberNegetiveAllow = False
        Me.TxtEngineNo.AgNumberRightPlaces = 2
        Me.TxtEngineNo.AgPickFromLastValue = False
        Me.TxtEngineNo.AgRowFilter = ""
        Me.TxtEngineNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEngineNo.AgSelectedValue = Nothing
        Me.TxtEngineNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEngineNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEngineNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEngineNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEngineNo.Location = New System.Drawing.Point(368, 73)
        Me.TxtEngineNo.MaxLength = 50
        Me.TxtEngineNo.Name = "TxtEngineNo"
        Me.TxtEngineNo.Size = New System.Drawing.Size(184, 18)
        Me.TxtEngineNo.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 372)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(97, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Trouble List"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(123, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Ä"
        '
        'LblCreditLimit
        '
        Me.LblCreditLimit.AutoSize = True
        Me.LblCreditLimit.BackColor = System.Drawing.Color.Transparent
        Me.LblCreditLimit.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCreditLimit.Location = New System.Drawing.Point(586, 393)
        Me.LblCreditLimit.Name = "LblCreditLimit"
        Me.LblCreditLimit.Size = New System.Drawing.Size(82, 16)
        Me.LblCreditLimit.TabIndex = 741
        Me.LblCreditLimit.Text = "Est Del Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(586, 372)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 16)
        Me.Label3.TabIndex = 743
        Me.Label3.Text = "Est Spares Amt"
        '
        'PnlCustomGrid
        '
        Me.PnlCustomGrid.Location = New System.Drawing.Point(567, 13)
        Me.PnlCustomGrid.Name = "PnlCustomGrid"
        Me.PnlCustomGrid.Size = New System.Drawing.Size(405, 297)
        Me.PnlCustomGrid.TabIndex = 27
        '
        'TxtCustomFields
        '
        Me.TxtCustomFields.AgAllowUserToEnableMasterHelp = False
        Me.TxtCustomFields.AgLastValueTag = Nothing
        Me.TxtCustomFields.AgLastValueText = Nothing
        Me.TxtCustomFields.AgMandatory = False
        Me.TxtCustomFields.AgMasterHelp = False
        Me.TxtCustomFields.AgNumberLeftPlaces = 8
        Me.TxtCustomFields.AgNumberNegetiveAllow = False
        Me.TxtCustomFields.AgNumberRightPlaces = 2
        Me.TxtCustomFields.AgPickFromLastValue = False
        Me.TxtCustomFields.AgRowFilter = ""
        Me.TxtCustomFields.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCustomFields.AgSelectedValue = Nothing
        Me.TxtCustomFields.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCustomFields.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCustomFields.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCustomFields.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustomFields.Location = New System.Drawing.Point(660, 593)
        Me.TxtCustomFields.MaxLength = 20
        Me.TxtCustomFields.Name = "TxtCustomFields"
        Me.TxtCustomFields.Size = New System.Drawing.Size(142, 18)
        Me.TxtCustomFields.TabIndex = 1011
        Me.TxtCustomFields.Text = "TxtCustomFields"
        Me.TxtCustomFields.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(123, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 3003
        Me.Label5.Text = "Ä"
        '
        'TxtModel
        '
        Me.TxtModel.AgAllowUserToEnableMasterHelp = False
        Me.TxtModel.AgLastValueTag = Nothing
        Me.TxtModel.AgLastValueText = Nothing
        Me.TxtModel.AgMandatory = True
        Me.TxtModel.AgMasterHelp = False
        Me.TxtModel.AgNumberLeftPlaces = 8
        Me.TxtModel.AgNumberNegetiveAllow = False
        Me.TxtModel.AgNumberRightPlaces = 2
        Me.TxtModel.AgPickFromLastValue = False
        Me.TxtModel.AgRowFilter = ""
        Me.TxtModel.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtModel.AgSelectedValue = Nothing
        Me.TxtModel.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtModel.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtModel.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtModel.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtModel.Location = New System.Drawing.Point(139, 73)
        Me.TxtModel.MaxLength = 0
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(131, 18)
        Me.TxtModel.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 3002
        Me.Label6.Text = "Model"
        '
        'TxtChassisNo
        '
        Me.TxtChassisNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtChassisNo.AgLastValueTag = Nothing
        Me.TxtChassisNo.AgLastValueText = Nothing
        Me.TxtChassisNo.AgMandatory = False
        Me.TxtChassisNo.AgMasterHelp = False
        Me.TxtChassisNo.AgNumberLeftPlaces = 8
        Me.TxtChassisNo.AgNumberNegetiveAllow = False
        Me.TxtChassisNo.AgNumberRightPlaces = 2
        Me.TxtChassisNo.AgPickFromLastValue = False
        Me.TxtChassisNo.AgRowFilter = ""
        Me.TxtChassisNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChassisNo.AgSelectedValue = Nothing
        Me.TxtChassisNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChassisNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtChassisNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChassisNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChassisNo.Location = New System.Drawing.Point(368, 53)
        Me.TxtChassisNo.MaxLength = 50
        Me.TxtChassisNo.Name = "TxtChassisNo"
        Me.TxtChassisNo.Size = New System.Drawing.Size(184, 18)
        Me.TxtChassisNo.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(275, 53)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 3007
        Me.Label9.Text = "Chassis No"
        '
        'TxtOwnerAdd2
        '
        Me.TxtOwnerAdd2.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerAdd2.AgLastValueTag = Nothing
        Me.TxtOwnerAdd2.AgLastValueText = Nothing
        Me.TxtOwnerAdd2.AgMandatory = False
        Me.TxtOwnerAdd2.AgMasterHelp = False
        Me.TxtOwnerAdd2.AgNumberLeftPlaces = 8
        Me.TxtOwnerAdd2.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd2.AgNumberRightPlaces = 2
        Me.TxtOwnerAdd2.AgPickFromLastValue = False
        Me.TxtOwnerAdd2.AgRowFilter = ""
        Me.TxtOwnerAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd2.AgSelectedValue = Nothing
        Me.TxtOwnerAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd2.Location = New System.Drawing.Point(139, 173)
        Me.TxtOwnerAdd2.MaxLength = 100
        Me.TxtOwnerAdd2.Name = "TxtOwnerAdd2"
        Me.TxtOwnerAdd2.Size = New System.Drawing.Size(413, 18)
        Me.TxtOwnerAdd2.TabIndex = 14
        '
        'TxtOwnerCity
        '
        Me.TxtOwnerCity.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerCity.AgLastValueTag = Nothing
        Me.TxtOwnerCity.AgLastValueText = Nothing
        Me.TxtOwnerCity.AgMandatory = False
        Me.TxtOwnerCity.AgMasterHelp = False
        Me.TxtOwnerCity.AgNumberLeftPlaces = 8
        Me.TxtOwnerCity.AgNumberNegetiveAllow = False
        Me.TxtOwnerCity.AgNumberRightPlaces = 2
        Me.TxtOwnerCity.AgPickFromLastValue = False
        Me.TxtOwnerCity.AgRowFilter = ""
        Me.TxtOwnerCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerCity.AgSelectedValue = Nothing
        Me.TxtOwnerCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerCity.Location = New System.Drawing.Point(139, 193)
        Me.TxtOwnerCity.MaxLength = 0
        Me.TxtOwnerCity.Name = "TxtOwnerCity"
        Me.TxtOwnerCity.Size = New System.Drawing.Size(120, 18)
        Me.TxtOwnerCity.TabIndex = 15
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.BackColor = System.Drawing.Color.Transparent
        Me.LblCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(8, 194)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(31, 16)
        Me.LblCity.TabIndex = 3012
        Me.LblCity.Text = "City"
        '
        'TxtOwnerAdd1
        '
        Me.TxtOwnerAdd1.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerAdd1.AgLastValueTag = Nothing
        Me.TxtOwnerAdd1.AgLastValueText = Nothing
        Me.TxtOwnerAdd1.AgMandatory = False
        Me.TxtOwnerAdd1.AgMasterHelp = False
        Me.TxtOwnerAdd1.AgNumberLeftPlaces = 8
        Me.TxtOwnerAdd1.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd1.AgNumberRightPlaces = 2
        Me.TxtOwnerAdd1.AgPickFromLastValue = False
        Me.TxtOwnerAdd1.AgRowFilter = ""
        Me.TxtOwnerAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd1.AgSelectedValue = Nothing
        Me.TxtOwnerAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd1.Location = New System.Drawing.Point(139, 153)
        Me.TxtOwnerAdd1.MaxLength = 100
        Me.TxtOwnerAdd1.Name = "TxtOwnerAdd1"
        Me.TxtOwnerAdd1.Size = New System.Drawing.Size(413, 18)
        Me.TxtOwnerAdd1.TabIndex = 13
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.BackColor = System.Drawing.Color.Transparent
        Me.LblAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(8, 154)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(56, 16)
        Me.LblAddress.TabIndex = 3011
        Me.LblAddress.Text = "Address"
        '
        'TxtOwnerMobile
        '
        Me.TxtOwnerMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerMobile.AgLastValueTag = Nothing
        Me.TxtOwnerMobile.AgLastValueText = Nothing
        Me.TxtOwnerMobile.AgMandatory = False
        Me.TxtOwnerMobile.AgMasterHelp = False
        Me.TxtOwnerMobile.AgNumberLeftPlaces = 8
        Me.TxtOwnerMobile.AgNumberNegetiveAllow = False
        Me.TxtOwnerMobile.AgNumberRightPlaces = 2
        Me.TxtOwnerMobile.AgPickFromLastValue = False
        Me.TxtOwnerMobile.AgRowFilter = ""
        Me.TxtOwnerMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerMobile.AgSelectedValue = Nothing
        Me.TxtOwnerMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerMobile.Location = New System.Drawing.Point(311, 193)
        Me.TxtOwnerMobile.MaxLength = 35
        Me.TxtOwnerMobile.Name = "TxtOwnerMobile"
        Me.TxtOwnerMobile.Size = New System.Drawing.Size(241, 18)
        Me.TxtOwnerMobile.TabIndex = 16
        '
        'LblOwnerMobile
        '
        Me.LblOwnerMobile.AutoSize = True
        Me.LblOwnerMobile.BackColor = System.Drawing.Color.Transparent
        Me.LblOwnerMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerMobile.Location = New System.Drawing.Point(259, 194)
        Me.LblOwnerMobile.Name = "LblOwnerMobile"
        Me.LblOwnerMobile.Size = New System.Drawing.Size(46, 16)
        Me.LblOwnerMobile.TabIndex = 3015
        Me.LblOwnerMobile.Text = "Mobile"
        '
        'TxtService_Type
        '
        Me.TxtService_Type.AgAllowUserToEnableMasterHelp = False
        Me.TxtService_Type.AgLastValueTag = Nothing
        Me.TxtService_Type.AgLastValueText = Nothing
        Me.TxtService_Type.AgMandatory = False
        Me.TxtService_Type.AgMasterHelp = False
        Me.TxtService_Type.AgNumberLeftPlaces = 8
        Me.TxtService_Type.AgNumberNegetiveAllow = False
        Me.TxtService_Type.AgNumberRightPlaces = 2
        Me.TxtService_Type.AgPickFromLastValue = False
        Me.TxtService_Type.AgRowFilter = ""
        Me.TxtService_Type.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtService_Type.AgSelectedValue = Nothing
        Me.TxtService_Type.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtService_Type.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtService_Type.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtService_Type.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtService_Type.Location = New System.Drawing.Point(138, 253)
        Me.TxtService_Type.MaxLength = 0
        Me.TxtService_Type.Name = "TxtService_Type"
        Me.TxtService_Type.Size = New System.Drawing.Size(249, 18)
        Me.TxtService_Type.TabIndex = 21
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 254)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(82, 16)
        Me.Label10.TabIndex = 3017
        Me.Label10.Text = "Service Type"
        '
        'TxtCouponNo
        '
        Me.TxtCouponNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtCouponNo.AgLastValueTag = Nothing
        Me.TxtCouponNo.AgLastValueText = Nothing
        Me.TxtCouponNo.AgMandatory = False
        Me.TxtCouponNo.AgMasterHelp = False
        Me.TxtCouponNo.AgNumberLeftPlaces = 8
        Me.TxtCouponNo.AgNumberNegetiveAllow = False
        Me.TxtCouponNo.AgNumberRightPlaces = 2
        Me.TxtCouponNo.AgPickFromLastValue = False
        Me.TxtCouponNo.AgRowFilter = ""
        Me.TxtCouponNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCouponNo.AgSelectedValue = Nothing
        Me.TxtCouponNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCouponNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCouponNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCouponNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCouponNo.Location = New System.Drawing.Point(468, 253)
        Me.TxtCouponNo.MaxLength = 10
        Me.TxtCouponNo.Name = "TxtCouponNo"
        Me.TxtCouponNo.Size = New System.Drawing.Size(84, 18)
        Me.TxtCouponNo.TabIndex = 22
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(390, 255)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 3019
        Me.Label11.Text = "Coupon No"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(808, 372)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(81, 16)
        Me.Label12.TabIndex = 3021
        Me.Label12.Text = "Est Lab Amt"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.Transparent
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(808, 393)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(83, 16)
        Me.Label13.TabIndex = 3023
        Me.Label13.Text = "Est Del Time"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.BackColor = System.Drawing.Color.Transparent
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(465, 34)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 16)
        Me.Label14.TabIndex = 3024
        Me.Label14.Text = "Time"
        '
        'TxtEstSparesAmt
        '
        Me.TxtEstSparesAmt.AgAllowUserToEnableMasterHelp = False
        Me.TxtEstSparesAmt.AgLastValueTag = Nothing
        Me.TxtEstSparesAmt.AgLastValueText = Nothing
        Me.TxtEstSparesAmt.AgMandatory = False
        Me.TxtEstSparesAmt.AgMasterHelp = False
        Me.TxtEstSparesAmt.AgNumberLeftPlaces = 8
        Me.TxtEstSparesAmt.AgNumberNegetiveAllow = False
        Me.TxtEstSparesAmt.AgNumberRightPlaces = 2
        Me.TxtEstSparesAmt.AgPickFromLastValue = False
        Me.TxtEstSparesAmt.AgRowFilter = ""
        Me.TxtEstSparesAmt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEstSparesAmt.AgSelectedValue = Nothing
        Me.TxtEstSparesAmt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEstSparesAmt.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtEstSparesAmt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEstSparesAmt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstSparesAmt.Location = New System.Drawing.Point(690, 372)
        Me.TxtEstSparesAmt.MaxLength = 0
        Me.TxtEstSparesAmt.Name = "TxtEstSparesAmt"
        Me.TxtEstSparesAmt.Size = New System.Drawing.Size(112, 18)
        Me.TxtEstSparesAmt.TabIndex = 3
        Me.TxtEstSparesAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEstDelDate
        '
        Me.TxtEstDelDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtEstDelDate.AgLastValueTag = Nothing
        Me.TxtEstDelDate.AgLastValueText = Nothing
        Me.TxtEstDelDate.AgMandatory = False
        Me.TxtEstDelDate.AgMasterHelp = False
        Me.TxtEstDelDate.AgNumberLeftPlaces = 8
        Me.TxtEstDelDate.AgNumberNegetiveAllow = False
        Me.TxtEstDelDate.AgNumberRightPlaces = 2
        Me.TxtEstDelDate.AgPickFromLastValue = False
        Me.TxtEstDelDate.AgRowFilter = ""
        Me.TxtEstDelDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEstDelDate.AgSelectedValue = Nothing
        Me.TxtEstDelDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEstDelDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtEstDelDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEstDelDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstDelDate.Location = New System.Drawing.Point(690, 392)
        Me.TxtEstDelDate.MaxLength = 0
        Me.TxtEstDelDate.Name = "TxtEstDelDate"
        Me.TxtEstDelDate.Size = New System.Drawing.Size(112, 18)
        Me.TxtEstDelDate.TabIndex = 5
        '
        'TxtEstLabAmt
        '
        Me.TxtEstLabAmt.AgAllowUserToEnableMasterHelp = False
        Me.TxtEstLabAmt.AgLastValueTag = Nothing
        Me.TxtEstLabAmt.AgLastValueText = Nothing
        Me.TxtEstLabAmt.AgMandatory = False
        Me.TxtEstLabAmt.AgMasterHelp = False
        Me.TxtEstLabAmt.AgNumberLeftPlaces = 8
        Me.TxtEstLabAmt.AgNumberNegetiveAllow = False
        Me.TxtEstLabAmt.AgNumberRightPlaces = 2
        Me.TxtEstLabAmt.AgPickFromLastValue = False
        Me.TxtEstLabAmt.AgRowFilter = ""
        Me.TxtEstLabAmt.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEstLabAmt.AgSelectedValue = Nothing
        Me.TxtEstLabAmt.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEstLabAmt.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtEstLabAmt.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEstLabAmt.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstLabAmt.Location = New System.Drawing.Point(895, 372)
        Me.TxtEstLabAmt.MaxLength = 0
        Me.TxtEstLabAmt.Name = "TxtEstLabAmt"
        Me.TxtEstLabAmt.Size = New System.Drawing.Size(82, 18)
        Me.TxtEstLabAmt.TabIndex = 4
        Me.TxtEstLabAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'TxtEstDelTime
        '
        Me.TxtEstDelTime.AgAllowUserToEnableMasterHelp = False
        Me.TxtEstDelTime.AgLastValueTag = Nothing
        Me.TxtEstDelTime.AgLastValueText = Nothing
        Me.TxtEstDelTime.AgMandatory = False
        Me.TxtEstDelTime.AgMasterHelp = False
        Me.TxtEstDelTime.AgNumberLeftPlaces = 2
        Me.TxtEstDelTime.AgNumberNegetiveAllow = False
        Me.TxtEstDelTime.AgNumberRightPlaces = 2
        Me.TxtEstDelTime.AgPickFromLastValue = False
        Me.TxtEstDelTime.AgRowFilter = ""
        Me.TxtEstDelTime.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEstDelTime.AgSelectedValue = Nothing
        Me.TxtEstDelTime.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEstDelTime.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtEstDelTime.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEstDelTime.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEstDelTime.Location = New System.Drawing.Point(895, 392)
        Me.TxtEstDelTime.MaxLength = 0
        Me.TxtEstDelTime.Name = "TxtEstDelTime"
        Me.TxtEstDelTime.Size = New System.Drawing.Size(82, 18)
        Me.TxtEstDelTime.TabIndex = 6
        '
        'TxtVehicleSpecification
        '
        Me.TxtVehicleSpecification.AgAllowUserToEnableMasterHelp = False
        Me.TxtVehicleSpecification.AgLastValueTag = Nothing
        Me.TxtVehicleSpecification.AgLastValueText = Nothing
        Me.TxtVehicleSpecification.AgMandatory = False
        Me.TxtVehicleSpecification.AgMasterHelp = False
        Me.TxtVehicleSpecification.AgNumberLeftPlaces = 8
        Me.TxtVehicleSpecification.AgNumberNegetiveAllow = False
        Me.TxtVehicleSpecification.AgNumberRightPlaces = 2
        Me.TxtVehicleSpecification.AgPickFromLastValue = False
        Me.TxtVehicleSpecification.AgRowFilter = ""
        Me.TxtVehicleSpecification.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleSpecification.AgSelectedValue = Nothing
        Me.TxtVehicleSpecification.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleSpecification.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleSpecification.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleSpecification.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleSpecification.Location = New System.Drawing.Point(139, 93)
        Me.TxtVehicleSpecification.MaxLength = 100
        Me.TxtVehicleSpecification.Name = "TxtVehicleSpecification"
        Me.TxtVehicleSpecification.Size = New System.Drawing.Size(413, 18)
        Me.TxtVehicleSpecification.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 94)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 16)
        Me.Label7.TabIndex = 3005
        Me.Label7.Text = "Vehicle Specification"
        '
        'TxtInsuranceCompany
        '
        Me.TxtInsuranceCompany.AgAllowUserToEnableMasterHelp = False
        Me.TxtInsuranceCompany.AgLastValueTag = Nothing
        Me.TxtInsuranceCompany.AgLastValueText = Nothing
        Me.TxtInsuranceCompany.AgMandatory = False
        Me.TxtInsuranceCompany.AgMasterHelp = False
        Me.TxtInsuranceCompany.AgNumberLeftPlaces = 8
        Me.TxtInsuranceCompany.AgNumberNegetiveAllow = False
        Me.TxtInsuranceCompany.AgNumberRightPlaces = 2
        Me.TxtInsuranceCompany.AgPickFromLastValue = False
        Me.TxtInsuranceCompany.AgRowFilter = ""
        Me.TxtInsuranceCompany.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInsuranceCompany.AgSelectedValue = Nothing
        Me.TxtInsuranceCompany.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInsuranceCompany.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtInsuranceCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInsuranceCompany.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInsuranceCompany.Location = New System.Drawing.Point(139, 213)
        Me.TxtInsuranceCompany.MaxLength = 0
        Me.TxtInsuranceCompany.Name = "TxtInsuranceCompany"
        Me.TxtInsuranceCompany.Size = New System.Drawing.Size(413, 18)
        Me.TxtInsuranceCompany.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(8, 214)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 16)
        Me.Label15.TabIndex = 3026
        Me.Label15.Text = "Insurance Co"
        '
        'TxtPolicyNo
        '
        Me.TxtPolicyNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyNo.AgLastValueTag = Nothing
        Me.TxtPolicyNo.AgLastValueText = Nothing
        Me.TxtPolicyNo.AgMandatory = False
        Me.TxtPolicyNo.AgMasterHelp = False
        Me.TxtPolicyNo.AgNumberLeftPlaces = 8
        Me.TxtPolicyNo.AgNumberNegetiveAllow = False
        Me.TxtPolicyNo.AgNumberRightPlaces = 2
        Me.TxtPolicyNo.AgPickFromLastValue = False
        Me.TxtPolicyNo.AgRowFilter = ""
        Me.TxtPolicyNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyNo.AgSelectedValue = Nothing
        Me.TxtPolicyNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPolicyNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyNo.Location = New System.Drawing.Point(139, 233)
        Me.TxtPolicyNo.MaxLength = 20
        Me.TxtPolicyNo.Name = "TxtPolicyNo"
        Me.TxtPolicyNo.Size = New System.Drawing.Size(120, 18)
        Me.TxtPolicyNo.TabIndex = 18
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(8, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 16)
        Me.Label16.TabIndex = 3028
        Me.Label16.Text = "Policy No"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(260, 233)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 16)
        Me.Label17.TabIndex = 3030
        Me.Label17.Text = "Date"
        '
        'TxtPolicyDate
        '
        Me.TxtPolicyDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyDate.AgLastValueTag = Nothing
        Me.TxtPolicyDate.AgLastValueText = Nothing
        Me.TxtPolicyDate.AgMandatory = False
        Me.TxtPolicyDate.AgMasterHelp = False
        Me.TxtPolicyDate.AgNumberLeftPlaces = 8
        Me.TxtPolicyDate.AgNumberNegetiveAllow = False
        Me.TxtPolicyDate.AgNumberRightPlaces = 2
        Me.TxtPolicyDate.AgPickFromLastValue = False
        Me.TxtPolicyDate.AgRowFilter = ""
        Me.TxtPolicyDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyDate.AgSelectedValue = Nothing
        Me.TxtPolicyDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPolicyDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyDate.Location = New System.Drawing.Point(304, 233)
        Me.TxtPolicyDate.MaxLength = 0
        Me.TxtPolicyDate.Name = "TxtPolicyDate"
        Me.TxtPolicyDate.Size = New System.Drawing.Size(83, 18)
        Me.TxtPolicyDate.TabIndex = 19
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(390, 234)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 16)
        Me.Label18.TabIndex = 3032
        Me.Label18.Text = "Expiry Date"
        '
        'TxtPolicyExpiryDate
        '
        Me.TxtPolicyExpiryDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyExpiryDate.AgLastValueTag = Nothing
        Me.TxtPolicyExpiryDate.AgLastValueText = Nothing
        Me.TxtPolicyExpiryDate.AgMandatory = False
        Me.TxtPolicyExpiryDate.AgMasterHelp = False
        Me.TxtPolicyExpiryDate.AgNumberLeftPlaces = 8
        Me.TxtPolicyExpiryDate.AgNumberNegetiveAllow = False
        Me.TxtPolicyExpiryDate.AgNumberRightPlaces = 2
        Me.TxtPolicyExpiryDate.AgPickFromLastValue = False
        Me.TxtPolicyExpiryDate.AgRowFilter = ""
        Me.TxtPolicyExpiryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyExpiryDate.AgSelectedValue = Nothing
        Me.TxtPolicyExpiryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyExpiryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPolicyExpiryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyExpiryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyExpiryDate.Location = New System.Drawing.Point(468, 233)
        Me.TxtPolicyExpiryDate.MaxLength = 0
        Me.TxtPolicyExpiryDate.Name = "TxtPolicyExpiryDate"
        Me.TxtPolicyExpiryDate.Size = New System.Drawing.Size(84, 18)
        Me.TxtPolicyExpiryDate.TabIndex = 20
        '
        'TxtV_Time
        '
        Me.TxtV_Time.AgAllowUserToEnableMasterHelp = False
        Me.TxtV_Time.AgLastValueTag = Nothing
        Me.TxtV_Time.AgLastValueText = Nothing
        Me.TxtV_Time.AgMandatory = False
        Me.TxtV_Time.AgMasterHelp = False
        Me.TxtV_Time.AgNumberLeftPlaces = 2
        Me.TxtV_Time.AgNumberNegetiveAllow = False
        Me.TxtV_Time.AgNumberRightPlaces = 2
        Me.TxtV_Time.AgPickFromLastValue = False
        Me.TxtV_Time.AgRowFilter = ""
        Me.TxtV_Time.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtV_Time.AgSelectedValue = Nothing
        Me.TxtV_Time.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtV_Time.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtV_Time.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtV_Time.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtV_Time.Location = New System.Drawing.Point(506, 33)
        Me.TxtV_Time.MaxLength = 0
        Me.TxtV_Time.Name = "TxtV_Time"
        Me.TxtV_Time.Size = New System.Drawing.Size(46, 18)
        Me.TxtV_Time.TabIndex = 4
        '
        'TxtServiceAdvisor
        '
        Me.TxtServiceAdvisor.AgAllowUserToEnableMasterHelp = False
        Me.TxtServiceAdvisor.AgLastValueTag = Nothing
        Me.TxtServiceAdvisor.AgLastValueText = Nothing
        Me.TxtServiceAdvisor.AgMandatory = True
        Me.TxtServiceAdvisor.AgMasterHelp = False
        Me.TxtServiceAdvisor.AgNumberLeftPlaces = 8
        Me.TxtServiceAdvisor.AgNumberNegetiveAllow = False
        Me.TxtServiceAdvisor.AgNumberRightPlaces = 2
        Me.TxtServiceAdvisor.AgPickFromLastValue = False
        Me.TxtServiceAdvisor.AgRowFilter = ""
        Me.TxtServiceAdvisor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServiceAdvisor.AgSelectedValue = Nothing
        Me.TxtServiceAdvisor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServiceAdvisor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtServiceAdvisor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtServiceAdvisor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServiceAdvisor.Location = New System.Drawing.Point(690, 412)
        Me.TxtServiceAdvisor.MaxLength = 0
        Me.TxtServiceAdvisor.Name = "TxtServiceAdvisor"
        Me.TxtServiceAdvisor.Size = New System.Drawing.Size(287, 18)
        Me.TxtServiceAdvisor.TabIndex = 7
        '
        'LblServiceAdvisor
        '
        Me.LblServiceAdvisor.AutoSize = True
        Me.LblServiceAdvisor.BackColor = System.Drawing.Color.Transparent
        Me.LblServiceAdvisor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblServiceAdvisor.Location = New System.Drawing.Point(586, 412)
        Me.LblServiceAdvisor.Name = "LblServiceAdvisor"
        Me.LblServiceAdvisor.Size = New System.Drawing.Size(96, 16)
        Me.LblServiceAdvisor.TabIndex = 3028
        Me.LblServiceAdvisor.Text = "Service Advisor"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(8, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 16)
        Me.Label19.TabIndex = 3034
        Me.Label19.Text = "Customer Id"
        '
        'TxtCustomerId
        '
        Me.TxtCustomerId.AgAllowUserToEnableMasterHelp = False
        Me.TxtCustomerId.AgLastValueTag = Nothing
        Me.TxtCustomerId.AgLastValueText = Nothing
        Me.TxtCustomerId.AgMandatory = False
        Me.TxtCustomerId.AgMasterHelp = False
        Me.TxtCustomerId.AgNumberLeftPlaces = 8
        Me.TxtCustomerId.AgNumberNegetiveAllow = False
        Me.TxtCustomerId.AgNumberRightPlaces = 2
        Me.TxtCustomerId.AgPickFromLastValue = False
        Me.TxtCustomerId.AgRowFilter = ""
        Me.TxtCustomerId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCustomerId.AgSelectedValue = Nothing
        Me.TxtCustomerId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCustomerId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCustomerId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCustomerId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustomerId.Location = New System.Drawing.Point(139, 113)
        Me.TxtCustomerId.MaxLength = 20
        Me.TxtCustomerId.Name = "TxtCustomerId"
        Me.TxtCustomerId.Size = New System.Drawing.Size(131, 18)
        Me.TxtCustomerId.TabIndex = 10
        '
        'TxtServiceAdvisorMobile
        '
        Me.TxtServiceAdvisorMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtServiceAdvisorMobile.AgLastValueTag = Nothing
        Me.TxtServiceAdvisorMobile.AgLastValueText = Nothing
        Me.TxtServiceAdvisorMobile.AgMandatory = False
        Me.TxtServiceAdvisorMobile.AgMasterHelp = False
        Me.TxtServiceAdvisorMobile.AgNumberLeftPlaces = 8
        Me.TxtServiceAdvisorMobile.AgNumberNegetiveAllow = False
        Me.TxtServiceAdvisorMobile.AgNumberRightPlaces = 2
        Me.TxtServiceAdvisorMobile.AgPickFromLastValue = False
        Me.TxtServiceAdvisorMobile.AgRowFilter = ""
        Me.TxtServiceAdvisorMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServiceAdvisorMobile.AgSelectedValue = Nothing
        Me.TxtServiceAdvisorMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServiceAdvisorMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtServiceAdvisorMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtServiceAdvisorMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServiceAdvisorMobile.Location = New System.Drawing.Point(690, 432)
        Me.TxtServiceAdvisorMobile.MaxLength = 35
        Me.TxtServiceAdvisorMobile.Name = "TxtServiceAdvisorMobile"
        Me.TxtServiceAdvisorMobile.Size = New System.Drawing.Size(287, 18)
        Me.TxtServiceAdvisorMobile.TabIndex = 8
        '
        'LblAvisorMobile
        '
        Me.LblAvisorMobile.AutoSize = True
        Me.LblAvisorMobile.BackColor = System.Drawing.Color.Transparent
        Me.LblAvisorMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAvisorMobile.Location = New System.Drawing.Point(586, 431)
        Me.LblAvisorMobile.Name = "LblAvisorMobile"
        Me.LblAvisorMobile.Size = New System.Drawing.Size(92, 16)
        Me.LblAvisorMobile.TabIndex = 3030
        Me.LblAvisorMobile.Text = "Advisor Mobile"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(275, 114)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(120, 16)
        Me.Label21.TabIndex = 3036
        Me.Label21.Text = "Vehicle User Name"
        '
        'TxtVehicleUserName
        '
        Me.TxtVehicleUserName.AgAllowUserToEnableMasterHelp = False
        Me.TxtVehicleUserName.AgLastValueTag = Nothing
        Me.TxtVehicleUserName.AgLastValueText = Nothing
        Me.TxtVehicleUserName.AgMandatory = False
        Me.TxtVehicleUserName.AgMasterHelp = False
        Me.TxtVehicleUserName.AgNumberLeftPlaces = 8
        Me.TxtVehicleUserName.AgNumberNegetiveAllow = False
        Me.TxtVehicleUserName.AgNumberRightPlaces = 2
        Me.TxtVehicleUserName.AgPickFromLastValue = False
        Me.TxtVehicleUserName.AgRowFilter = ""
        Me.TxtVehicleUserName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleUserName.AgSelectedValue = Nothing
        Me.TxtVehicleUserName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleUserName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleUserName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleUserName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleUserName.Location = New System.Drawing.Point(398, 113)
        Me.TxtVehicleUserName.MaxLength = 100
        Me.TxtVehicleUserName.Name = "TxtVehicleUserName"
        Me.TxtVehicleUserName.Size = New System.Drawing.Size(154, 18)
        Me.TxtVehicleUserName.TabIndex = 11
        '
        'TxtMilage
        '
        Me.TxtMilage.AgAllowUserToEnableMasterHelp = False
        Me.TxtMilage.AgLastValueTag = Nothing
        Me.TxtMilage.AgLastValueText = Nothing
        Me.TxtMilage.AgMandatory = False
        Me.TxtMilage.AgMasterHelp = False
        Me.TxtMilage.AgNumberLeftPlaces = 8
        Me.TxtMilage.AgNumberNegetiveAllow = False
        Me.TxtMilage.AgNumberRightPlaces = 2
        Me.TxtMilage.AgPickFromLastValue = False
        Me.TxtMilage.AgRowFilter = ""
        Me.TxtMilage.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtMilage.AgSelectedValue = Nothing
        Me.TxtMilage.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtMilage.AgValueType = AgControls.AgTextBox.TxtValueType.Number_Value
        Me.TxtMilage.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtMilage.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMilage.Location = New System.Drawing.Point(468, 273)
        Me.TxtMilage.MaxLength = 0
        Me.TxtMilage.Name = "TxtMilage"
        Me.TxtMilage.Size = New System.Drawing.Size(84, 18)
        Me.TxtMilage.TabIndex = 24
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(390, 274)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(46, 16)
        Me.Label22.TabIndex = 3038
        Me.Label22.Text = "Milage"
        '
        'TxtKeyNo
        '
        Me.TxtKeyNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtKeyNo.AgLastValueTag = Nothing
        Me.TxtKeyNo.AgLastValueText = Nothing
        Me.TxtKeyNo.AgMandatory = False
        Me.TxtKeyNo.AgMasterHelp = False
        Me.TxtKeyNo.AgNumberLeftPlaces = 8
        Me.TxtKeyNo.AgNumberNegetiveAllow = False
        Me.TxtKeyNo.AgNumberRightPlaces = 2
        Me.TxtKeyNo.AgPickFromLastValue = False
        Me.TxtKeyNo.AgRowFilter = ""
        Me.TxtKeyNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtKeyNo.AgSelectedValue = Nothing
        Me.TxtKeyNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtKeyNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtKeyNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtKeyNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtKeyNo.Location = New System.Drawing.Point(138, 273)
        Me.TxtKeyNo.MaxLength = 50
        Me.TxtKeyNo.Name = "TxtKeyNo"
        Me.TxtKeyNo.Size = New System.Drawing.Size(249, 18)
        Me.TxtKeyNo.TabIndex = 23
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(8, 274)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 16)
        Me.Label23.TabIndex = 3040
        Me.Label23.Text = "Key No"
        '
        'TxtSoldBy
        '
        Me.TxtSoldBy.AgAllowUserToEnableMasterHelp = False
        Me.TxtSoldBy.AgLastValueTag = Nothing
        Me.TxtSoldBy.AgLastValueText = Nothing
        Me.TxtSoldBy.AgMandatory = False
        Me.TxtSoldBy.AgMasterHelp = False
        Me.TxtSoldBy.AgNumberLeftPlaces = 8
        Me.TxtSoldBy.AgNumberNegetiveAllow = False
        Me.TxtSoldBy.AgNumberRightPlaces = 2
        Me.TxtSoldBy.AgPickFromLastValue = False
        Me.TxtSoldBy.AgRowFilter = ""
        Me.TxtSoldBy.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSoldBy.AgSelectedValue = Nothing
        Me.TxtSoldBy.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSoldBy.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSoldBy.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSoldBy.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSoldBy.Location = New System.Drawing.Point(138, 293)
        Me.TxtSoldBy.MaxLength = 0
        Me.TxtSoldBy.Name = "TxtSoldBy"
        Me.TxtSoldBy.Size = New System.Drawing.Size(249, 18)
        Me.TxtSoldBy.TabIndex = 25
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 294)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(54, 16)
        Me.Label24.TabIndex = 3043
        Me.Label24.Text = "Sold By"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(390, 293)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(65, 16)
        Me.Label26.TabIndex = 3044
        Me.Label26.Text = "Sold Date"
        '
        'TxtSoldDate
        '
        Me.TxtSoldDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtSoldDate.AgLastValueTag = Nothing
        Me.TxtSoldDate.AgLastValueText = Nothing
        Me.TxtSoldDate.AgMandatory = False
        Me.TxtSoldDate.AgMasterHelp = False
        Me.TxtSoldDate.AgNumberLeftPlaces = 8
        Me.TxtSoldDate.AgNumberNegetiveAllow = False
        Me.TxtSoldDate.AgNumberRightPlaces = 2
        Me.TxtSoldDate.AgPickFromLastValue = False
        Me.TxtSoldDate.AgRowFilter = ""
        Me.TxtSoldDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSoldDate.AgSelectedValue = Nothing
        Me.TxtSoldDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSoldDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtSoldDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSoldDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSoldDate.Location = New System.Drawing.Point(468, 293)
        Me.TxtSoldDate.MaxLength = 0
        Me.TxtSoldDate.Name = "TxtSoldDate"
        Me.TxtSoldDate.Size = New System.Drawing.Size(84, 18)
        Me.TxtSoldDate.TabIndex = 26
        '
        'LinkLabel2
        '
        Me.LinkLabel2.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel2.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel2.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel2.LinkColor = System.Drawing.Color.White
        Me.LinkLabel2.Location = New System.Drawing.Point(369, 372)
        Me.LinkLabel2.Name = "LinkLabel2"
        Me.LinkLabel2.Size = New System.Drawing.Size(212, 20)
        Me.LinkLabel2.TabIndex = 3032
        Me.LinkLabel2.TabStop = True
        Me.LinkLabel2.Text = "Labour/Spare Parts List"
        Me.LinkLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Pnl2
        '
        Me.Pnl2.Location = New System.Drawing.Point(369, 393)
        Me.Pnl2.Name = "Pnl2"
        Me.Pnl2.Size = New System.Drawing.Size(212, 172)
        Me.Pnl2.TabIndex = 2
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label28.Location = New System.Drawing.Point(678, 417)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 7)
        Me.Label28.TabIndex = 3033
        Me.Label28.Text = "Ä"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(123, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 7)
        Me.Label8.TabIndex = 3045
        Me.Label8.Text = "Ä"
        '
        'FrmJobCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 612)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.LinkLabel2)
        Me.Controls.Add(Me.Pnl2)
        Me.Controls.Add(Me.TxtServiceAdvisorMobile)
        Me.Controls.Add(Me.LblAvisorMobile)
        Me.Controls.Add(Me.TxtServiceAdvisor)
        Me.Controls.Add(Me.LblServiceAdvisor)
        Me.Controls.Add(Me.TxtCustomFields)
        Me.Controls.Add(Me.TxtEstLabAmt)
        Me.Controls.Add(Me.TxtEstDelTime)
        Me.Controls.Add(Me.LblCreditLimit)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtEstDelDate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtEstSparesAmt)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label30)
        Me.Name = "FrmJobCard"
        Me.Text = "Sale Invoice"
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtEstSparesAmt, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.TxtEstDelDate, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.LblCreditLimit, 0)
        Me.Controls.SetChildIndex(Me.TxtEstDelTime, 0)
        Me.Controls.SetChildIndex(Me.TxtEstLabAmt, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomFields, 0)
        Me.Controls.SetChildIndex(Me.LblServiceAdvisor, 0)
        Me.Controls.SetChildIndex(Me.TxtServiceAdvisor, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.LblAvisorMobile, 0)
        Me.Controls.SetChildIndex(Me.TxtServiceAdvisorMobile, 0)
        Me.Controls.SetChildIndex(Me.Pnl2, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel2, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TP1.ResumeLayout(False)
        Me.TP1.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Dgl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblRegistrationNo As System.Windows.Forms.Label
    Protected WithEvents TxtRegistrationNo As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerName As AgControls.AgTextBox
    Protected WithEvents LblOwnerName As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtEngineNo As AgControls.AgTextBox
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LblCreditLimit As System.Windows.Forms.Label
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents PnlCustomGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtCustomFields As AgControls.AgTextBox
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtModel As AgControls.AgTextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents TxtChassisNo As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerAdd2 As AgControls.AgTextBox
    Protected WithEvents TxtOwnerCity As AgControls.AgTextBox
    Protected WithEvents LblCity As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerAdd1 As AgControls.AgTextBox
    Protected WithEvents LblAddress As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerMobile As AgControls.AgTextBox
    Protected WithEvents LblOwnerMobile As System.Windows.Forms.Label
    Protected WithEvents TxtCouponNo As AgControls.AgTextBox
    Protected WithEvents Label11 As System.Windows.Forms.Label
    Protected WithEvents TxtService_Type As AgControls.AgTextBox
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents Label14 As System.Windows.Forms.Label
    Protected WithEvents Label13 As System.Windows.Forms.Label
    Protected WithEvents Label12 As System.Windows.Forms.Label
    Protected WithEvents TxtEstDelTime As AgControls.AgTextBox
    Protected WithEvents TxtEstLabAmt As AgControls.AgTextBox
    Protected WithEvents TxtEstDelDate As AgControls.AgTextBox
    Protected WithEvents TxtEstSparesAmt As AgControls.AgTextBox
    Protected WithEvents TxtVehicleSpecification As AgControls.AgTextBox
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents Label17 As System.Windows.Forms.Label
    Protected WithEvents TxtPolicyDate As AgControls.AgTextBox
    Protected WithEvents TxtPolicyNo As AgControls.AgTextBox
    Protected WithEvents Label16 As System.Windows.Forms.Label
    Protected WithEvents TxtInsuranceCompany As AgControls.AgTextBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents Label18 As System.Windows.Forms.Label
    Protected WithEvents TxtPolicyExpiryDate As AgControls.AgTextBox
    Protected WithEvents TxtV_Time As AgControls.AgTextBox
    Protected WithEvents TxtServiceAdvisor As AgControls.AgTextBox
    Protected WithEvents LblServiceAdvisor As System.Windows.Forms.Label
    Protected WithEvents TxtSoldBy As AgControls.AgTextBox
    Protected WithEvents Label24 As System.Windows.Forms.Label
    Protected WithEvents Label26 As System.Windows.Forms.Label
    Protected WithEvents TxtSoldDate As AgControls.AgTextBox
    Protected WithEvents TxtKeyNo As AgControls.AgTextBox
    Protected WithEvents Label23 As System.Windows.Forms.Label
    Protected WithEvents TxtMilage As AgControls.AgTextBox
    Protected WithEvents Label22 As System.Windows.Forms.Label
    Protected WithEvents Label21 As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleUserName As AgControls.AgTextBox
    Protected WithEvents Label19 As System.Windows.Forms.Label
    Protected WithEvents TxtCustomerId As AgControls.AgTextBox
    Protected WithEvents TxtServiceAdvisorMobile As AgControls.AgTextBox
    Protected WithEvents LblAvisorMobile As System.Windows.Forms.Label
    Protected WithEvents LinkLabel2 As System.Windows.Forms.LinkLabel
    Protected WithEvents Pnl2 As System.Windows.Forms.Panel
#End Region

    Private Sub FrmJobCard_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = " Delete From CostCenterMast Where Code = '" & TxtManualRefNo.Tag & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Service_JobCard"
        LogTableName = "Service_JobCard_Log"
        MainLineTableCsv = "Service_JobTrouble"
        LogLineTableCsv = "Service_JobTrouble_Log"

        AgL.GridDesign(Dgl1)
        AgL.GridDesign(Dgl2)

        AgL.AddAgDataGrid(AgCustomGrid1, PnlCustomGrid)

        AgCustomGrid1.AgLibVar = AgL
        AgCustomGrid1.SplitGrid = True
        AgCustomGrid1.MnuText = Me.Name
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " And H.Div_Code = '" & AgL.PubDivCode & "' "
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From Service_JobCard H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " And H.Div_Code = '" & AgL.PubDivCode & "'"
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, Vt.Description AS Job_Card_Type, H.V_Date AS Job_Card_Date, " & _
                            " H.ManualRefNo AS [Manual_No], Iu.RegistrationNo As Registration_No, Iu.ChassisNo As Chassis_No, " & _
                            " Iu.EngineNo As Engine_No, Iu.OwnerName As Owner_Name, " & _
                            " IsNull(Iu.OwnerAdd1,'') + IsNull(Iu.OwnerAdd2,'') As Owner_Address, C.CityName, " & _
                            " Insurance.DispName As Insurance_Company, Type.Description As Service_Type, H.Remarks, " & _
                            " H.EntryBy AS [Entry_By], H.EntryDate AS [Entry_Date], H.EntryType AS [Entry_Type] " & _
                            " FROM Service_JobCard H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN Item_Uid Iu ON H.Item_Uid = Iu.Code " & _
                            " LEFT JOIN City C ON H.OwnerCity = C.CityCode " & _
                            " LEFT JOIN SubGroup Insurance On H.InsuranceCompany = Insurance.SubCode " & _
                            " LEFT JOIN Service_Type Type On H.Service_Type = Type.Code " & _
                            " Where 1 = 1 " & mCondStr
        AgL.PubFindQryOrdBy = "[Entry_Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Trouble, 150, 0, Col1Trouble, True, False)
            .AddAgTextColumn(Dgl1, Col1Specification, 250, 255, Col1Specification, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True
        Dgl1.AllowUserToOrderColumns = True

        Dgl2.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl2, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl2, Col2Item, 250, 0, Col2Item, True, False)
        End With
        AgL.AddAgDataGrid(Dgl2, Pnl2)
        Dgl2.EnableHeadersVisualStyles = False
        Dgl2.ColumnHeadersHeight = 35
        Dgl2.AgSkipReadOnlyColumns = True
        Dgl2.AllowUserToOrderColumns = True

        Dgl2.Name = "Dgl2"

        AgCustomGrid1.Ini_Grid(mSearchCode)
        AgCustomGrid1.SplitGrid = False

        AgCustomGrid1.Name = "AgCustomGrid1"

        AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        AgCL.GridSetiingShowXml(Me.Text & Dgl2.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl2)
        AgCL.GridSetiingShowXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim bSelectionQry$ = "", bInvoiceType$ = ""
        Dim MinutesCnt As Double = 0

        mQry = " Select Count(*) From Item_Uid With (NoLock) Where Replace(Replace(Replace(RegistrationNo, ' ', ''), '-', ''), '.', '') = '" & Replace(Replace(Replace(TxtRegistrationNo.Text, " ", ""), "-", ""), ".", "") & "'"
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) = 0 Then
            TxtRegistrationNo.Tag = FCrateItem_Uid(Conn, Cmd)
        Else
            mQry = " UPDATE Item_UID " & _
                     " SET " & _
                     " OwnerMobile = " & AgL.Chk_Text(TxtOwnerMobile.Text) & ", " & _
                     " InsuranceCompany = " & AgL.Chk_Text(TxtInsuranceCompany.Tag) & ", " & _
                     " PolicyNo = " & AgL.Chk_Text(TxtPolicyNo.Text) & ", " & _
                     " PolicyDate = " & AgL.Chk_Text(TxtPolicyDate.Text) & ", " & _
                     " PolicyExpiryDate = " & AgL.Chk_Text(TxtPolicyExpiryDate.Text) & " " & _
                     " WHERE Code = '" & TxtRegistrationNo.Tag & "' "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        mQry = " Select Count(*) From CostCenterMast With (NoLock) Where Name = '" & TxtManualRefNo.Text & "'"
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) = 0 Then
            TxtManualRefNo.Tag = AgL.GetMaxId("CostCenterMast", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 4, True, True, , AgL.Gcn_ConnectionString)
            mQry = " INSERT INTO CostCenterMast (Code, Name, U_Name, U_EntDt, U_AE) " & _
                    " VALUES ('" & TxtManualRefNo.Tag & "', " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                    " '" & AgL.PubUserName & "', '" & AgL.PubLoginDate & "', 'A')"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        Else
            mQry = "Update CostCenterMast Set Name = " & AgL.Chk_Text(TxtManualRefNo.Text) & " Where Code = " & AgL.Chk_Text(TxtManualRefNo.Tag) & ""
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        MinutesCnt = Math.Floor(Val(TxtV_Time.Text)) * 60 + ((Val(TxtV_Time.Text) - Math.Floor(Val(TxtV_Time.Text))) * 100)
        Dim JobCardDateTime$ = CDate(TxtV_Date.Text).AddMinutes(MinutesCnt)

        MinutesCnt = Math.Floor(Val(TxtEstDelTime.Text)) * 60 + ((Val(TxtEstDelTime.Text) - Math.Floor(Val(TxtEstDelTime.Text))) * 100)
        Dim EstDelDateTime$ = CDate(TxtEstDelDate.Text).AddMinutes(MinutesCnt)

        mQry = " Update Service_JobCard " & _
                " SET  " & _
                " V_Date = " & AgL.Chk_Text(JobCardDateTime) & ", " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                " Item_Uid = " & AgL.Chk_Text(TxtRegistrationNo.Tag) & ", " & _
                " CustomerId = " & AgL.Chk_Text(TxtCustomerId.Text) & ", " & _
                " OwnerName = " & AgL.Chk_Text(TxtOwnerName.Text) & ", " & _
                " OwnerAdd1 = " & AgL.Chk_Text(TxtOwnerAdd1.Text) & ", " & _
                " OwnerAdd2 = " & AgL.Chk_Text(TxtOwnerAdd2.Text) & ", " & _
                " OwnerCity = " & AgL.Chk_Text(TxtOwnerCity.Tag) & ", " & _
                " OwnerMobile = " & AgL.Chk_Text(TxtOwnerMobile.Text) & ", " & _
                " VehicleUserName = " & AgL.Chk_Text(TxtVehicleUserName.Text) & ", " & _
                " InsuranceCompany = " & AgL.Chk_Text(TxtInsuranceCompany.Tag) & ", " & _
                " PolicyNo = " & AgL.Chk_Text(TxtPolicyNo.Text) & ", " & _
                " PolicyDate = " & AgL.Chk_Text(TxtPolicyDate.Text) & ", " & _
                " PolicyExpiryDate = " & AgL.Chk_Text(TxtPolicyExpiryDate.Text) & ", " & _
                " Service_Type = " & AgL.Chk_Text(TxtService_Type.Tag) & ", " & _
                " CouponNo = " & AgL.Chk_Text(TxtCouponNo.Text) & ", " & _
                " Milage = " & Val(TxtMilage.Text) & ", " & _
                " KeyNo = " & AgL.Chk_Text(TxtKeyNo.Text) & ", " & _
                " SoldBy = " & AgL.Chk_Text(TxtSoldBy.Tag) & ", " & _
                " SoldDate = " & AgL.Chk_Text(TxtSoldDate.Text) & ", " & _
                " CostCenter = " & AgL.Chk_Text(TxtManualRefNo.Tag) & ", " & _
                " ServiceAdvisor = " & AgL.Chk_Text(TxtServiceAdvisor.Tag) & ", " & _
                " ServiceAdvisorMobile = " & AgL.Chk_Text(TxtServiceAdvisorMobile.Text) & ", " & _
                " EstSparesAmt = " & Val(TxtEstSparesAmt.Text) & ", " & _
                " EstLabAmt = " & Val(TxtEstLabAmt.Text) & ", " & _
                " EstDelDate = " & AgL.Chk_Text(EstDelDateTime) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " " & AgCustomGrid1.FFooterTableUpdateStr() & " " & _
                " Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Service_JobTrouble Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From Service_JobItem Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Trouble, I).Value <> "" Then
                mSr += 1
                If bSelectionQry <> "" Then bSelectionQry += " UNION ALL "
                bSelectionQry += " Select " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & _
                                    " " & AgL.Chk_Text(Dgl1.Item(Col1Trouble, I).Tag) & ", " & _
                                    " " & AgL.Chk_Text(Dgl1.Item(Col1Specification, I).Value) & ""
            End If
        Next

        If bSelectionQry <> "" Then
            mQry = "Insert Into Service_JobTrouble(DocId, Sr, Trouble, Specification) " + bSelectionQry
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        bSelectionQry = ""

        For I = 0 To Dgl2.RowCount - 1
            If Dgl2.Item(Col2Item, I).Value <> "" Then
                mSr += 1
                If bSelectionQry <> "" Then bSelectionQry += " UNION ALL "
                bSelectionQry += " Select " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & _
                                    " " & AgL.Chk_Text(Dgl2.Item(Col2Item, I).Tag) & "  "
            End If
        Next

        If bSelectionQry <> "" Then
            mQry = "Insert Into Service_JobItem(DocId, Sr, Item) " + bSelectionQry
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
            AgCL.GridSetiingWriteXml(Me.Text & Dgl2.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl2)
            AgCL.GridSetiingWriteXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DsTemp As DataSet

        mQry = " Select H.*, C.CityName As OwnerCityName, S.Description As Service_TypeDesc, " & _
               " Iu.RegistrationNo As RegistrationNo, Iu.Item, I.Description As ItemDesc, " & _
               " Iu.ChassisNo, Iu.EngineNo, Iu.VehicleSpecification, " & _
               " Sg.Name As InsuranceCompanyName, Sg1.Name As ServiceAdvisorName, Sg2.Name As SoldByName  " & _
               " From (Select * From Service_JobCard With (NoLock) Where DocID='" & SearchCode & "') H " & _
               " LEFT JOIN City C With (NoLock) On H.OwnerCity = C.CityCode " & _
               " LEFT JOIN Service_Type S With (NoLock) On H.Service_Type = S.Code " & _
               " LEFT JOIN Item_Uid Iu With (NoLock) On H.Item_Uid = Iu.Code " & _
               " LEFT JOIN Item I With (NoLock) On Iu.Item = I.Code " & _
               " LEFT JOIN SuBGroup Sg With (NoLock) On H.InsuranceCompany = Sg.SubCode " & _
               " LEFT JOIN SuBGroup Sg1 With (NoLock) On H.ServiceAdvisor = Sg1.SubCode " & _
               " LEFT JOIN SubGroup Sg2 With (NoLock) On H.SoldBy = Sg2.SubCode "
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("CustomFields")) <> "" Then
                    TxtCustomFields.AgSelectedValue = AgL.XNull(.Rows(0)("CustomFields"))
                End If
                AgCustomGrid1.FrmType = Me.FrmType
                AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

                IniGrid()

                TxtV_Date.Text = CDate(AgL.XNull(.Rows(0)("V_Date"))).Date
                TxtV_Time.Text = Format(CDate(AgL.XNull(.Rows(0)("V_Date"))).Hour + (CDate(AgL.XNull(.Rows(0)("V_Date"))).Minute / 100), "00.00")

                If AgL.XNull(.Rows(0)("EstDelDate")) <> "" Then
                    TxtEstDelDate.Text = CDate(AgL.XNull(.Rows(0)("EstDelDate"))).Date
                    TxtEstDelTime.Text = Format(CDate(AgL.XNull(.Rows(0)("EstDelDate"))).Hour + (CDate(AgL.XNull(.Rows(0)("EstDelDate"))).Minute / 100), "00.00")
                End If

                TxtManualRefNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtManualRefNo.Tag = AgL.XNull(.Rows(0)("CostCenter"))

                TxtRegistrationNo.Tag = AgL.XNull(.Rows(0)("Item_Uid"))
                TxtRegistrationNo.Text = AgL.XNull(.Rows(0)("RegistrationNo"))

                TxtChassisNo.Text = AgL.XNull(.Rows(0)("ChassisNo"))
                TxtEngineNo.Text = AgL.XNull(.Rows(0)("EngineNo"))

                TxtModel.Tag = AgL.XNull(.Rows(0)("Item"))
                TxtModel.Text = AgL.XNull(.Rows(0)("ItemDesc"))

                TxtVehicleSpecification.Text = AgL.XNull(.Rows(0)("VehicleSpecification"))

                TxtCustomerId.Text = AgL.XNull(.Rows(0)("CustomerId"))
                TxtOwnerName.Text = AgL.XNull(.Rows(0)("OwnerName"))
                TxtOwnerAdd1.Text = AgL.XNull(.Rows(0)("OwnerAdd1"))
                TxtOwnerAdd2.Text = AgL.XNull(.Rows(0)("OwnerAdd2"))

                TxtOwnerCity.Tag = AgL.XNull(.Rows(0)("OwnerCity"))
                TxtOwnerCity.Text = AgL.XNull(.Rows(0)("OwnerCityName"))

                TxtOwnerMobile.Text = AgL.XNull(.Rows(0)("OwnerMobile"))

                TxtVehicleUserName.Text = AgL.XNull(.Rows(0)("VehicleUserName"))

                TxtMilage.Text = AgL.VNull(.Rows(0)("Milage"))
                TxtKeyNo.Text = AgL.XNull(.Rows(0)("KeyNo"))

                TxtSoldBy.Tag = AgL.XNull(.Rows(0)("SoldBy"))
                TxtSoldBy.Text = AgL.XNull(.Rows(0)("SoldByName"))

                TxtSoldDate.Text = AgL.XNull(.Rows(0)("SoldDate"))

                TxtInsuranceCompany.Tag = AgL.XNull(.Rows(0)("InsuranceCompany"))
                TxtInsuranceCompany.Text = AgL.XNull(.Rows(0)("InsuranceCompanyName"))

                TxtServiceAdvisor.Tag = AgL.XNull(.Rows(0)("ServiceAdvisor"))
                TxtServiceAdvisor.Text = AgL.XNull(.Rows(0)("ServiceAdvisorName"))

                TxtServiceAdvisor.AgLastValueTag = TxtServiceAdvisor.Tag
                TxtServiceAdvisor.AgLastValueText = TxtServiceAdvisor.Text

                TxtServiceAdvisorMobile.Text = AgL.XNull(.Rows(0)("ServiceAdvisorMobile"))
                TxtServiceAdvisorMobile.AgLastValueText = TxtServiceAdvisorMobile.Text

                TxtPolicyNo.Text = AgL.XNull(.Rows(0)("PolicyNo"))
                TxtPolicyDate.Text = AgL.XNull(.Rows(0)("PolicyDate"))
                TxtPolicyExpiryDate.Text = AgL.XNull(.Rows(0)("PolicyExpiryDate"))

                TxtService_Type.Tag = AgL.XNull(.Rows(0)("Service_Type"))
                TxtService_Type.Text = AgL.XNull(.Rows(0)("Service_TypeDesc"))

                TxtCouponNo.Text = AgL.XNull(.Rows(0)("CouponNo"))

                TxtEstSparesAmt.Text = AgL.XNull(.Rows(0)("EstSparesAmt"))
                TxtEstLabAmt.Text = AgL.XNull(.Rows(0)("EstLabAmt"))

                TxtServiceAdvisor.Tag = AgL.XNull(.Rows(0)("ServiceAdvisor"))
                TxtServiceAdvisor.Text = AgL.XNull(.Rows(0)("ServiceAdvisorName"))

                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                AgCustomGrid1.FMoveRecFooterTable(DsTemp.Tables(0))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                mQry = "Select L.*, T.Description As TroubleDesc, T.ManualCode As TroubleManualCode " & _
                        " From (Select * From Service_JobTrouble With (NoLock) Where DocId = '" & SearchCode & "') As L " & _
                        " LEFT JOIN Service_Trouble T With (NoLock) ON L.Trouble = T.Code " & _
                        " Order By L.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.Item(Col1Trouble, I).Tag = AgL.XNull(.Rows(I)("Trouble"))
                            Dgl1.Item(Col1Trouble, I).Value = AgL.XNull(.Rows(I)("TroubleDesc"))
                            Dgl1.Item(Col1Specification, I).Value = AgL.XNull(.Rows(I)("Specification"))
                        Next I
                    End If
                End With

                mQry = "Select L.*, I.Description As ItemDesc " & _
                        " From (Select * From Service_JobItem With (NoLock) Where DocId = '" & SearchCode & "') As L " & _
                        " LEFT JOIN Item I With (NoLock) ON L.Item = I.Code " & _
                        " Order By L.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl2.RowCount = 1
                    Dgl2.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl2.Rows.Add()
                            Dgl2.Item(ColSNo, I).Value = Dgl2.Rows.Count - 1
                            Dgl2.Item(Col2Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl2.Item(Col2Item, I).Value = AgL.XNull(.Rows(I)("ItemDesc"))
                        Next I
                    End If
                End With

                If AgCustomGrid1.Rows.Count = 0 Then AgCustomGrid1.Visible = False
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        Topctrl1.ChangeAgGridState(Dgl2, False)
        AgCustomGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtRegistrationNo.Validating, TxtOwnerName.Validating, TxtManualRefNo.Validating, TxtV_Time.Validating, TxtEstDelTime.Validating, TxtChassisNo.Validating, TxtEngineNo.Validating, TxtPolicyDate.Validating, TxtPolicyExpiryDate.Validating, TxtServiceAdvisor.Validating, TxtInsuranceCompany.Validating, TxtOwnerMobile.Validating, TxtServiceAdvisorMobile.Validating
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)
                    AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue
                    IniGrid()
                    TxtManualRefNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "Service_JobCard", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)

                Case TxtManualRefNo.Name
                    e.Cancel = Not AgTemplate.ClsMain.FCheckDuplicateRefNo("ManualRefNo", "Service_JobCard", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtManualRefNo.Text, mSearchCode)


                Case TxtV_Time.Name
                    If Val(TxtV_Time.Text) > 24 Then
                        Dim CurrDateTime$ = AgL.XNull(AgL.Dman_Execute("Select getdate()", AgL.GcnRead).ExecuteScalar)
                        TxtV_Time.Text = Format(CDate(CurrDateTime).Hour + (CDate(CurrDateTime).Minute / 100), "00.00")
                    End If

                Case TxtEstDelTime.Name
                    If Val(TxtEstDelTime.Text) > 24 Then
                        Dim CurrDateTime$ = AgL.XNull(AgL.Dman_Execute("Select getdate()", AgL.GcnRead).ExecuteScalar)
                        TxtEstDelTime.Text = Format(CDate(CurrDateTime).Hour + (CDate(CurrDateTime).Minute / 100), "00.00")
                    End If

                Case TxtRegistrationNo.Name
                    e.Cancel = Not FCheckDuplicateJobCardForVehicle()
                    If TxtRegistrationNo.Tag <> "" And TxtRegistrationNo.Tag IsNot Nothing Then
                        Call FValidate_Item_Uid(TxtRegistrationNo.Tag)
                    Else
                        If TxtRegistrationNo.Text <> "" Then
                            If FIsDuplicate("RegistrationNo", TxtRegistrationNo.Text) = True Then
                                MsgBox("Registration No Already Exists...!", MsgBoxStyle.Information)
                                e.Cancel = True
                            End If
                        End If

                        'TxtChassisNo.Text = "" : TxtEngineNo.Text = "" : TxtModel.Tag = ""
                        'TxtModel.Text = "" : TxtOwnerName.Text = "" : TxtOwnerAdd1.Text = ""
                        'TxtOwnerAdd2.Text = "" : TxtOwnerCity.Tag = "" : TxtOwnerCity.Text = ""
                        'TxtOwnerMobile.Text = "" : TxtInsuranceCompany.Tag = "" : TxtInsuranceCompany.Text = ""
                        'TxtPolicyNo.Text = "" : TxtPolicyDate.Text = "" : TxtPolicyExpiryDate.Text = ""
                        'TxtVehicleSpecification.Text = ""

                        TxtChassisNo.Enabled = True : TxtEngineNo.Enabled = True : TxtModel.Enabled = True : TxtCustomerId.Enabled = True
                        TxtOwnerName.Enabled = True : TxtOwnerAdd1.Enabled = True : TxtOwnerAdd2.Enabled = True
                        TxtOwnerCity.Enabled = True : TxtVehicleSpecification.Enabled = True

                        TxtChassisNo.Focus()
                    End If

                Case TxtChassisNo.Name
                    If TxtChassisNo.Text <> "" Then
                        If FIsDuplicate("ChassisNo", TxtChassisNo.Text) = True Then
                            MsgBox("Chassis No Already Exists...!", MsgBoxStyle.Information)
                            e.Cancel = True
                        End If
                    End If

                Case TxtEngineNo.Name
                    If TxtEngineNo.Text <> "" Then
                        If FIsDuplicate("EngineNo", TxtEngineNo.Text) = True Then
                            MsgBox("Engine No Already Exists...!", MsgBoxStyle.Information)
                            e.Cancel = True
                        End If
                    End If

                Case TxtPolicyDate.Name
                    If TxtPolicyDate.Text <> "" And TxtPolicyExpiryDate.Text = "" Then
                        TxtPolicyExpiryDate.Text = DateAdd(DateInterval.Day, -1, CDate(DateAdd(DateInterval.Year, 1, CDate(TxtPolicyDate.Text))))
                    End If

                Case TxtServiceAdvisor.Name
                    If sender.AgDataRow IsNot Nothing Then
                        TxtServiceAdvisorMobile.Text = AgL.XNull(sender.AgDataRow.Cells("Mobile").Value)
                    End If

                Case TxtInsuranceCompany.Name
                    If TxtInsuranceCompany.Text = "" Then
                        TxtService_Type.Focus()
                    End If

                Case TxtOwnerMobile.Name
                    e.Cancel = Not ClsMain.FValidateMobile(TxtOwnerMobile.Text, LblOwnerMobile.Text)

                Case TxtServiceAdvisorMobile.Name
                    e.Cancel = Not ClsMain.FValidateMobile(TxtServiceAdvisorMobile.Text, LblAvisorMobile.Text)
            End Select
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GCn)
        AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue
        IniGrid()
        TabControl1.SelectedTab = TP1

        Dim CurrDateTime$ = AgL.XNull(AgL.Dman_Execute("Select getdate()", AgL.GcnRead).ExecuteScalar)
        TxtV_Time.Text = Format(CDate(CurrDateTime).Hour + (CDate(CurrDateTime).Minute / 100), "00.00")

        TxtEstDelDate.Text = AgL.PubLoginDate
        TxtEstDelTime.Text = TxtV_Time.Text

        TxtServiceAdvisor.Tag = IIf(TxtServiceAdvisor.AgLastValueTag Is Nothing, "", TxtServiceAdvisor.AgLastValueTag)
        TxtServiceAdvisor.Text = IIf(TxtServiceAdvisor.AgLastValueText Is Nothing, "", TxtServiceAdvisor.AgLastValueText)
        TxtServiceAdvisorMobile.Text = IIf(TxtServiceAdvisorMobile.AgLastValueText Is Nothing, "", TxtServiceAdvisorMobile.AgLastValueText)

        TxtManualRefNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "Service_JobCard", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
        TxtManualRefNo.Focus()
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name

            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl2.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If AgL.RequiredField(TxtRegistrationNo, LblRegistrationNo.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtServiceAdvisor, LblServiceAdvisor.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtOwnerName, LblOwnerName.Text) Then passed = False : Exit Sub

        If TxtV_Date.Text <> "" And TxtSoldDate.Text <> "" Then
            If CDate(TxtV_Date.Text) < CDate(TxtSoldDate.Text) Then
                MsgBox("Sold Date Can't Be Greater Then Job Card Date...!", MsgBoxStyle.Information)
                TxtSoldDate.Focus() : passed = False : Exit Sub
            End If
        End If

        If TxtPolicyDate.Text <> "" And TxtPolicyExpiryDate.Text <> "" Then
            If CDate(TxtPolicyDate.Text) >= CDate(TxtPolicyExpiryDate.Text) Then
                MsgBox("Policy Date Can't Be Greater Then Policy Expiry Date...!", MsgBoxStyle.Information)
                TxtPolicyExpiryDate.Focus() : passed = False : Exit Sub
            End If
        End If

        Dim MinutesCnt As Double = 0
        MinutesCnt = Math.Floor(Val(TxtV_Time.Text)) * 60 + ((Val(TxtV_Time.Text) - Math.Floor(Val(TxtV_Time.Text))) * 100)
        Dim JobCardDateTime$ = CDate(TxtV_Date.Text).AddMinutes(MinutesCnt)

        MinutesCnt = Math.Floor(Val(TxtEstDelTime.Text)) * 60 + ((Val(TxtEstDelTime.Text) - Math.Floor(Val(TxtEstDelTime.Text))) * 100)
        Dim EstDelDateTime$ = CDate(TxtEstDelDate.Text).AddMinutes(MinutesCnt)

        If JobCardDateTime <> "" And EstDelDateTime <> "" Then
            If CDate(JobCardDateTime) > CDate(EstDelDateTime) Then
                MsgBox("Job Card Date Can't Be Greater Then Estimated Delivery Date...!", MsgBoxStyle.Information)
                TxtEstDelDate.Focus() : passed = False : Exit Sub
            End If
        End If

        If TxtInsuranceCompany.Text = "" Then
            If TxtPolicyDate.Text <> "" Then
                MsgBox("Policy Date should be blank because insurance company is blank.", MsgBoxStyle.Information)
                TxtPolicyDate.Focus() : passed = False : Exit Sub
            End If

            If TxtPolicyNo.Text <> "" Then
                MsgBox("Policy No should be blank because insurance company is blank.", MsgBoxStyle.Information)
                TxtPolicyNo.Focus() : passed = False : Exit Sub
            End If

            If TxtPolicyExpiryDate.Text <> "" Then
                MsgBox("Policy Expiry Date should be blank because insurance company is blank.", MsgBoxStyle.Information)
                TxtPolicyExpiryDate.Focus() : passed = False : Exit Sub
            End If
        End If


        If FCheckDuplicateJobCardForVehicle() = False Then passed = False : Exit Sub
        If ClsMain.FValidateMobile(TxtOwnerMobile.Text, LblOwnerMobile.Text) = False Then TxtOwnerMobile.Focus() : passed = False : Exit Sub
        If ClsMain.FValidateMobile(TxtServiceAdvisorMobile.Text, LblAvisorMobile.Text) = False Then TxtServiceAdvisorMobile.Focus() : passed = False : Exit Sub
        If AgTemplate.ClsMain.FCheckDuplicateRefNo("ManualRefNo", "Service_JobCard", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtManualRefNo.Text, mSearchCode) = False Then passed = False : Exit Sub
    End Sub

    Private Sub TxtBuyer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtModel.KeyDown, TxtService_Type.KeyDown, TxtOwnerCity.KeyDown, TxtRegistrationNo.KeyDown, TxtInsuranceCompany.KeyDown, TxtServiceAdvisor.KeyDown, TxtSoldBy.KeyDown
        Try
            Select Case sender.name
                Case TxtModel.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT H.Code, H.Description " & _
                                    " FROM Item H " & _
                                    " WHERE IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                    " And H.ItemType = '" & ClsMain.ItemType.Model & "'"
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtService_Type.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT H.Code, H.Description " & _
                                    " FROM Service_Type H " & _
                                    " WHERE IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtOwnerCity.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT C.CityCode AS Code, C.CityName FROM City C "
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtInsuranceCompany.Name
                    If e.KeyCode <> Keys.Enter Then
                        If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                            mQry = " SELECT Sg.SubCode, Sg.DispName As Name FROM SubGroup Sg Where Sg.MasterType = '" & ClsMain.MasterType.Insurance & "'"
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtServiceAdvisor.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT Sg.SubCode, Sg.DispName As Name, Sg.Mobile FROM SubGroup Sg Where Sg.MasterType = '" & ClsMain.MasterType.Employee & "'"
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(1) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtSoldBy.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT Sg.SubCode, Sg.Name As Name FROM SubGroup Sg Where Sg.MasterType = '" & ClsMain.MasterType.Dealer & "'"
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case TxtRegistrationNo.Name
                    If e.KeyCode = Keys.Insert Then
                        If mNewRegNo = False Then
                            If MsgBox("Do You Want To Create New Registration No ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                                TxtRegistrationNo.AgHelpDataSet = Nothing
                                TxtRegistrationNo.Text = "" : TxtRegistrationNo.Tag = ""
                                mNewRegNo = True
                            End If
                        Else
                            mNewRegNo = False
                        End If
                    Else
                        If mNewRegNo = False Then
                            If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                                If e.KeyCode <> Keys.Enter Then
                                    mQry = " SELECT I.Code, I.RegistrationNo  FROM Item_UID I  "
                                    CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                                End If
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
        Dgl2.RowCount = 1 : Dgl2.Rows.Clear()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown, Dgl2.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub
    End Sub

    Private Sub FrmCarpetMaterialPlan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        Topctrl1.ChangeAgGridState(Dgl2, False)
        AgL.WinSetting(Me, 650, 990, 0, 0)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub BtnFillSaleChallan_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub

            Dgl1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmService_JobCard_BaseEvent_Topctrl_tbRef() Handles Me.BaseEvent_Topctrl_tbRef
        If Dgl1.AgHelpDataSet(Col1Trouble) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Trouble).Dispose() : Dgl1.AgHelpDataSet(Col1Trouble) = Nothing
        If Dgl2.AgHelpDataSet(Col2Item) IsNot Nothing Then Dgl2.AgHelpDataSet(Col2Item).Dispose() : Dgl2.AgHelpDataSet(Col2Item) = Nothing
        If TxtModel.AgHelpDataSet IsNot Nothing Then TxtModel.AgHelpDataSet.Dispose() : TxtModel.AgHelpDataSet = Nothing
        If TxtService_Type.AgHelpDataSet IsNot Nothing Then TxtService_Type.AgHelpDataSet.Dispose() : TxtService_Type.AgHelpDataSet = Nothing
        If TxtRegistrationNo.AgHelpDataSet IsNot Nothing Then TxtRegistrationNo.AgHelpDataSet.Dispose() : TxtRegistrationNo.AgHelpDataSet = Nothing
        If TxtInsuranceCompany.AgHelpDataSet IsNot Nothing Then TxtInsuranceCompany.AgHelpDataSet.Dispose() : TxtInsuranceCompany.AgHelpDataSet = Nothing
        If TxtServiceAdvisor.AgHelpDataSet IsNot Nothing Then TxtServiceAdvisor.AgHelpDataSet.Dispose() : TxtServiceAdvisor.AgHelpDataSet = Nothing
        If TxtOwnerCity.AgHelpDataSet IsNot Nothing Then TxtOwnerCity.AgHelpDataSet.Dispose() : TxtOwnerCity.AgHelpDataSet = Nothing
        If TxtSoldBy.AgHelpDataSet IsNot Nothing Then TxtSoldBy.AgHelpDataSet.Dispose() : TxtSoldBy.AgHelpDataSet = Nothing
    End Sub

    Private Sub Dgl1_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.EditingControl_KeyDown
        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Trouble
                    If Dgl1.AgHelpDataSet(Col1Trouble) Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT H.Code, H.Description, H.ManualCode " & _
                                    " FROM Service_Trouble H " & _
                                    " WHERE IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            Dgl1.AgHelpDataSet(Col1Trouble) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl2_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl2.EditingControl_KeyDown
        Try
            Select Case Dgl2.Columns(Dgl2.CurrentCell.ColumnIndex).Name
                Case Col2Item
                    If Dgl2.AgHelpDataSet(Col2Item) Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = " SELECT H.Code, H.Description " & _
                                    " FROM Item H " & _
                                    " WHERE IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                    " And H.ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "')"
                            Dgl2.AgHelpDataSet(Col2Item) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FCrateItem_Uid(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand) As String
        Dim Item_UidCode$ = ""
        Item_UidCode = AgL.GetMaxId("Item_Uid", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 4, True, True, , AgL.Gcn_ConnectionString)

        mQry = " INSERT INTO Item_UID(GenDocID, Item, Code, Item_UID, " & _
                " ChassisNo, EngineNo, CustomerId, OwnerName, OwnerAdd1, OwnerAdd2, OwnerCity, OwnerMobile,  " & _
                " InsuranceCompany, PolicyNo, PolicyDate, PolicyExpiryDate, VehicleSpecification, RegistrationNo, " & _
                " EntryBy, EntryDate, EntryType, EntryStatus, Status, Div_Code) " & _
                " VALUES ('" & mSearchCode & "', " & AgL.Chk_Text(TxtModel.Tag) & ", '" & Item_UidCode & "', " & _
                " " & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                " " & AgL.Chk_Text(TxtChassisNo.Text) & ", " & AgL.Chk_Text(TxtEngineNo.Text) & ", " & AgL.Chk_Text(TxtCustomerId.Text) & ", " & _
                " " & AgL.Chk_Text(TxtOwnerName.Text) & ", " & AgL.Chk_Text(TxtOwnerAdd1.Text) & ", " & AgL.Chk_Text(TxtOwnerAdd2.Text) & ",  " & _
                " " & AgL.Chk_Text(TxtOwnerCity.Tag) & ", " & AgL.Chk_Text(TxtOwnerMobile.Text) & ", " & _
                " " & AgL.Chk_Text(TxtInsuranceCompany.Tag) & ", " & AgL.Chk_Text(TxtPolicyNo.Text) & ", " & _
                " " & AgL.Chk_Text(TxtPolicyDate.Text) & ", " & AgL.Chk_Text(TxtPolicyExpiryDate.Text) & ", " & _
                " " & AgL.Chk_Text(TxtVehicleSpecification.Text) & ", " & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                " " & AgL.Chk_Text(AgL.PubUserName) & ", " & _
                " " & AgL.Chk_Text(AgL.GetDateTime(AgL.GcnRead)) & ", " & AgL.Chk_Text(Topctrl1.Mode) & ", " & _
                " " & AgL.Chk_Text(LogStatus.LogOpen) & ", " & AgL.Chk_Text(TxtStatus.Text) & ", '" & AgL.PubDivCode & "' " & _
                " ) "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        FCrateItem_Uid = Item_UidCode
    End Function

    Private Sub FValidate_Item_Uid(ByVal Item_Uid As String)
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0

        mQry = " SELECT I.ChassisNo, I.EngineNo, I.CustomerId, I.OwnerName, I.OwnerAdd1, I.OwnerAdd2, " & _
                " I.OwnerCity, I.OwnerMobile, I.InsuranceCompany, I.PolicyNo, I.PolicyDate,  " & _
                " I.PolicyExpiryDate, I.VehicleSpecification, C.CityName AS OwnerCityName, " & _
                " Sg.DispName AS InsuranceCompanyName, I.Item, Item.Description ItemDesc " & _
                " FROM Item_UID I  " & _
                " LEFT JOIN City C ON I.OwnerCity = C.CityCode " & _
                " LEFT JOIN SubGroup Sg ON I.InsuranceCompany = Sg.SubCode " & _
                " LEFT JOIN Item Item On I.Item = Item.Code " & _
                " Where I.Code = '" & Item_Uid & "'"
        DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        If DtTemp.Rows.Count > 0 Then
            For I = 0 To DtTemp.Rows.Count - 1
                TxtChassisNo.Text = AgL.XNull(DtTemp.Rows(0)("ChassisNo"))
                TxtEngineNo.Text = AgL.XNull(DtTemp.Rows(0)("EngineNo"))
                TxtModel.Tag = AgL.XNull(DtTemp.Rows(0)("Item"))
                TxtModel.Text = AgL.XNull(DtTemp.Rows(0)("ItemDesc"))
                TxtCustomerId.Text = AgL.XNull(DtTemp.Rows(0)("CustomerId"))
                TxtOwnerName.Text = AgL.XNull(DtTemp.Rows(0)("OwnerName"))
                TxtOwnerAdd1.Text = AgL.XNull(DtTemp.Rows(0)("OwnerAdd1"))
                TxtOwnerAdd2.Text = AgL.XNull(DtTemp.Rows(0)("OwnerAdd2"))
                TxtOwnerCity.Tag = AgL.XNull(DtTemp.Rows(0)("OwnerCity"))
                TxtOwnerCity.Text = AgL.XNull(DtTemp.Rows(0)("OwnerCityName"))
                TxtOwnerMobile.Text = AgL.XNull(DtTemp.Rows(0)("OwnerMobile"))
                TxtInsuranceCompany.Tag = AgL.XNull(DtTemp.Rows(0)("InsuranceCompany"))
                TxtInsuranceCompany.Text = AgL.XNull(DtTemp.Rows(0)("InsuranceCompanyName"))
                TxtPolicyNo.Text = AgL.XNull(DtTemp.Rows(0)("PolicyNo"))
                TxtPolicyDate.Text = AgL.XNull(DtTemp.Rows(0)("PolicyDate"))
                TxtPolicyExpiryDate.Text = AgL.XNull(DtTemp.Rows(0)("PolicyExpiryDate"))
                TxtVehicleSpecification.Text = AgL.XNull(DtTemp.Rows(0)("VehicleSpecification"))

                TxtChassisNo.Enabled = False : TxtEngineNo.Enabled = False : TxtModel.Enabled = False : TxtCustomerId.Enabled = False
                TxtOwnerName.Enabled = False : TxtOwnerAdd1.Enabled = False : TxtOwnerAdd2.Enabled = False
                TxtOwnerCity.Enabled = False : TxtVehicleSpecification.Enabled = False

                TxtService_Type.Focus()
            Next
        End If
    End Sub

    Private Sub FrmJobCard_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        TxtV_Time.Text = Format(Val(TxtV_Time.Text), "00.00")
        TxtEstDelTime.Text = Format(Val(TxtEstDelTime.Text), "00.00")
    End Sub

    Private Function FIsDuplicate(ByVal FieldName As String, ByVal FieldValue As String) As Boolean
        mQry = " SELECT Count(*) FROM Item_UID WHERE Replace(Replace(Replace(" & FieldName & ", ' ', ''), '-', ''), '.', '') = '" & Replace(Replace(Replace(FieldValue, " ", ""), "-", ""), ".", "") & "' And GenDocId <> '" & mSearchCode & "'"
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar) = 0 Then
            FIsDuplicate = False
        Else
            FIsDuplicate = True
        End If
    End Function

    Private Sub FrmJobCard_BaseEvent_Save_PostTrans(ByVal SearchCode As String) Handles Me.BaseEvent_Save_PostTrans
        If TxtRegistrationNo.AgHelpDataSet IsNot Nothing Then TxtRegistrationNo.AgHelpDataSet = Nothing
        mNewRegNo = False
    End Sub

    Private Sub FrmJobCard_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtChassisNo.Enabled = False : TxtEngineNo.Enabled = False : TxtModel.Enabled = False : TxtCustomerId.Enabled = False
        TxtOwnerName.Enabled = False : TxtOwnerAdd1.Enabled = False : TxtOwnerAdd2.Enabled = False
        TxtOwnerCity.Enabled = False : TxtVehicleSpecification.Enabled = False
    End Sub

    Private Sub FPrintDocument()
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0

        Dim SubReport_QueryList$ = ""

        Try
            mQry = "SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ManualRefNo, H.Item_Uid, H.OwnerName, " & _
                        " H.OwnerAdd1, H.OwnerAdd2, H.OwnerCity, H.OwnerMobile, H.Service_Type, H.CouponNo, H.EstSparesAmt, H.EstLabAmt,  " & _
                        " H.EstDelDate, H.InsuranceCompany, H.PolicyNo, H.PolicyDate, H.PolicyExpiryDate, H.CustomFields, H.Remarks, H.EntryBy,  " & _
                        " H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status,  " & _
                        " H.CostCenter, H.ServiceAdvisor, H.VehicleSrlNo, H.CustomerId, H.VehicleUserName,  " & _
                        " H.Milage, H.KeyNo, H.SoldBy, H.SoldDate, H.ServiceAdvisorMobile, " & _
                        " C.CityName AS OwnerCityName, S.Description AS Service_TypeDesc, " & _
                        " Sg.DispName AS ServiceAdvisorName, Model.Description AS ModelDesc, " & _
                        " Iu.RegistrationNo, Iu.ChassisNo, Iu.EngineNo, Dealer.DispName As SoldByName " & _
                        " " & AgCustomGrid1.FHeaderTableFieldNameStr("H.", "H_") & " " & _
                        " FROM Service_JobCard H  " & _
                        " LEFT JOIN City C ON H.OwnerCity = C.CityCode " & _
                        " LEFT JOIN Service_Type S ON H.Service_Type = S.Code " & _
                        " LEFT JOIN SubGroup Sg ON H.ServiceAdvisor = Sg.SubCode " & _
                        " LEFT JOIN Item_Uid Iu On H.Item_Uid = Iu.Code" & _
                        " LEFT JOIN Item Model ON Iu.Item = Model.Code " & _
                        " LEFT JOIN SubGroup Dealer On H.SoldBy = Dealer.SubCode " & _
                        " Where H.DocId = '" & mSearchCode & "'"

            SubReport_QueryList = " SELECT T.Description, L.Specification " & _
                            " FROM Service_JobTrouble L  " & _
                            " LEFT JOIN Service_Trouble T ON l.Trouble = T.Code  " & _
                            " WHERE L.DocId = '" & mSearchCode & "' "

            SubReport_QueryList += "|"

            SubReport_QueryList += " SELECT I.Description " & _
                            " FROM Service_JobItem L  " & _
                            " LEFT JOIN Item I ON L.Item = I.Code " & _
                            " WHERE L.DocId = '" & mSearchCode & "' "

            SubReport_QueryList += "|"

            SubReport_QueryList += " SELECT H.ManualRefNo As JobCardNo, H.V_Date As JobCardDate, H.Milage, " & _
                            " T.Description As Service_TypeDesc  " & _
                            " FROM Service_JobCard H  " & _
                            " LEFT JOIN Service_Type T ON H.Service_Type = T.Code " & _
                            " WHERE H.Item_Uid = (Select Item_Uid From Service_JobCard Where DocId = '" & mSearchCode & "') " & _
                            " And H.DocId <> '" & mSearchCode & "'"

            ClsMain.FPrintThisDocument(Me, TxtV_Type.Tag, mQry, "Service_JobCard_Print", "Repair Order", SubReport_QueryList, "SUBREP1|SUBREP2|SUBREP3")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmJobCard_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        FPrintDocument()
    End Sub

    Private Function FGetRelationalData(ByVal UserAction As String) As Boolean
        Try
            Dim bRData As String

            If UserAction = "Delete" Then
                '// Check for relational data in Job Card Claim Intimation
                mQry = " DECLARE @Temp NVARCHAR(Max); "
                mQry += " SET @Temp=''; "
                mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ManualRefNo As ReferenceNo From Service_InsuranceClaimIntimation H WHERE H.Service_JobCard = '" & TxtDocId.Text & "') AS X  "
                mQry += " SELECT @Temp as RelationalData "
                bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                If bRData.Trim <> "" Then
                    MsgBox(" Job Card Claim Intimation " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                    FGetRelationalData = True
                    Exit Function
                End If

                '// Check for relational data in Job Estimate
                mQry = " DECLARE @Temp NVARCHAR(Max); "
                mQry += " SET @Temp=''; "
                mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ReferenceNo As ReferenceNo From SaleQuotation H LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type WHERE H.Service_JobCard = '" & TxtDocId.Text & "' And Vt.NCat = '" & ClsMain.Temp_NCat.ServiceQuotation & "') AS X  "
                mQry += " SELECT @Temp as RelationalData "
                bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                If bRData.Trim <> "" Then
                    MsgBox(" Job Estimate " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                    FGetRelationalData = True
                    Exit Function
                End If

                '// Check for relational data in Job Estimate Approval
                mQry = " DECLARE @Temp NVARCHAR(Max); "
                mQry += " SET @Temp=''; "
                mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ReferenceNo As ReferenceNo From SaleQuotation H LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type WHERE H.Service_JobCard = '" & TxtDocId.Text & "' And Vt.NCat = '" & ClsMain.Temp_NCat.ServiceQuotationApproved & "') AS X  "
                mQry += " SELECT @Temp as RelationalData "
                bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                If bRData.Trim <> "" Then
                    MsgBox(" Job Estimate " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                    FGetRelationalData = True
                    Exit Function
                End If


                '// Check for relational data in Material Issue
                mQry = " DECLARE @Temp NVARCHAR(Max); "
                mQry += " SET @Temp=''; "
                mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ReferenceNo As ReferenceNo From SaleChallan H LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type WHERE H.Service_JobCard = '" & TxtDocId.Text & "' And Vt.NCat = '" & ClsMain.Temp_NCat.ServiceMaterialIssue & "') AS X  "
                mQry += " SELECT @Temp as RelationalData "
                bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                If bRData.Trim <> "" Then
                    MsgBox(" Material Issue " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                    FGetRelationalData = True
                    Exit Function
                End If

                '// Check for relational data in Labour Issue
                mQry = " DECLARE @Temp NVARCHAR(Max); "
                mQry += " SET @Temp=''; "
                mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ReferenceNo As ReferenceNo From SaleChallan H LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type WHERE H.Service_JobCard = '" & TxtDocId.Text & "' And Vt.NCat = '" & ClsMain.Temp_NCat.ServiceLabourDone & "') AS X  "
                mQry += " SELECT @Temp as RelationalData "
                bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
                If bRData.Trim <> "" Then
                    MsgBox(" Labour Done " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                    FGetRelationalData = True
                    Exit Function
                End If
            End If

            '// Check for relational data In Job Card Detail
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ManualRefNo As ReferenceNo From Service_JobCardDetail H WHERE H.Service_JobCard = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Job Card Detail " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                FGetRelationalData = True
                Exit Function
            End If

            '// Check for relational data In Sale Invoice
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.ReferenceNo + ', ' FROM (SELECT DISTINCT H.ReferenceNo As ReferenceNo From SaleInvoice H WHERE H.Service_JobCard = '" & TxtDocId.Text & "') AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Sale Invoice " & bRData & " Created Against Job Card No. " & TxtManualRefNo.Text & ". Can't Modify Entry", MsgBoxStyle.Information)
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " In FGetRelationalData In Job Card")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData("Delete")
    End Sub

    Private Sub FrmJobCard_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData("Edit")
    End Sub

    Private Function FCheckDuplicateJobCardForVehicle() As Boolean
        FCheckDuplicateJobCardForVehicle = True
        Dim mJobCardNo

        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT H.ManualRefNo  FROM Service_JobCard H WHERE H.Item_Uid = '" & TxtRegistrationNo.Tag & "'   " & _
                   " And H.DocId Not In (Select Service_JobCard From SaleInvoice) " & _
                   " And H.DocId Not In (SELECT Service_JobCard FROM Service_JobCardDetail WHERE Job_Close_Date IS NOT NULL) "
            mJobCardNo = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
            If mJobCardNo <> "" Then FCheckDuplicateJobCardForVehicle = False : MsgBox("Job Card No " & mJobCardNo & " already exists for this vehicle, Which is neither closed nor invoiced yet.", MsgBoxStyle.Information) : TxtManualRefNo.Focus()
        Else
            mQry = " SELECT H.ManualRefNo  FROM Service_JobCard H WHERE H.Item_Uid = '" & TxtRegistrationNo.Tag & "'   " & _
                   " And H.DocId Not In (Select Service_JobCard From SaleInvoice) " & _
                   " And H.DocId Not In (SELECT Service_JobCard FROM Service_JobCardDetail WHERE Job_Close_Date IS NOT NULL)  " & _
                   " And DocID <>'" & mSearchCode & "'  "
            mJobCardNo = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
            If mJobCardNo <> "" Then FCheckDuplicateJobCardForVehicle = False : MsgBox("Job Card No " & mJobCardNo & " already exists for this vehicle, Which is neither closed nor invoiced yet.", MsgBoxStyle.Information) : TxtManualRefNo.Focus()
        End If
    End Function
End Class
