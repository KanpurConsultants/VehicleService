Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmJobCardDetail
    Inherits AgTemplate.TempTransaction
    Dim mQry$
    Protected WithEvents TxtCustomFields As AgControls.AgTextBox
    Public WithEvents AgCustomGrid1 As New AgCustomFields.AgCustomGrid

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.ServiceJobCardDetail
        mQry = "Select H.* from Voucher_Type_Settings H Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  Where Vt.NCat In ('" & EntryNCat & "') And H.Div_Code = '" & AgL.PubDivCode & "' And H.Site_Code ='" & AgL.PubSiteCode & "' "
        DtV_TypeSettings = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.LblTableReq = New System.Windows.Forms.Label
        Me.TxtJobcard = New AgControls.AgTextBox
        Me.LblJobCard = New System.Windows.Forms.Label
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblManualRefNoReq = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblManualRefNo = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblRemarks = New System.Windows.Forms.Label
        Me.TxtVehicleNo = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtModel = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.PnlCustomGrid = New System.Windows.Forms.Panel
        Me.TxtCustomFields = New AgControls.AgTextBox
        Me.GroupBox2.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GrpUP.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TP1.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(758, 282)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 306)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(368, 282)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(193, 282)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 282)
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
        Me.GroupBox1.Location = New System.Drawing.Point(-6, 277)
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(571, 282)
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
        Me.TxtDocId.Location = New System.Drawing.Point(853, 236)
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(139, 272)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Voucher No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(245, 275)
        Me.TxtV_No.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(366, 33)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(276, 28)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(465, 283)
        Me.LblV_TypeReq.Tag = ""
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(385, 27)
        Me.TxtV_Date.Size = New System.Drawing.Size(143, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(464, 261)
        Me.LblV_Type.Size = New System.Drawing.Size(88, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Voucher Type"
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(483, 280)
        Me.TxtV_Type.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(114, 33)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(13, 28)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(131, 27)
        Me.TxtSite_Code.Size = New System.Drawing.Size(132, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Location = New System.Drawing.Point(806, 238)
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(197, 276)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, 19)
        Me.TabControl1.Size = New System.Drawing.Size(990, 252)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtCustomFields)
        Me.TP1.Controls.Add(Me.PnlCustomGrid)
        Me.TP1.Controls.Add(Me.TxtModel)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtVehicleNo)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.LblManualRefNoReq)
        Me.TP1.Controls.Add(Me.LblManualRefNo)
        Me.TP1.Controls.Add(Me.LblRemarks)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.LblTableReq)
        Me.TP1.Controls.Add(Me.TxtJobcard)
        Me.TP1.Controls.Add(Me.LblJobCard)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(982, 226)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblJobCard, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobcard, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTableReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtModel, 0)
        Me.TP1.Controls.SetChildIndex(Me.PnlCustomGrid, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCustomFields, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(982, 41)
        Me.Topctrl1.TabIndex = 0
        '
        'LblTableReq
        '
        Me.LblTableReq.AutoSize = True
        Me.LblTableReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTableReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTableReq.Location = New System.Drawing.Point(366, 53)
        Me.LblTableReq.Name = "LblTableReq"
        Me.LblTableReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTableReq.TabIndex = 694
        Me.LblTableReq.Text = "Ä"
        '
        'TxtJobcard
        '
        Me.TxtJobcard.AgAllowUserToEnableMasterHelp = False
        Me.TxtJobcard.AgLastValueTag = Nothing
        Me.TxtJobcard.AgLastValueText = Nothing
        Me.TxtJobcard.AgMandatory = True
        Me.TxtJobcard.AgMasterHelp = False
        Me.TxtJobcard.AgNumberLeftPlaces = 8
        Me.TxtJobcard.AgNumberNegetiveAllow = False
        Me.TxtJobcard.AgNumberRightPlaces = 2
        Me.TxtJobcard.AgPickFromLastValue = False
        Me.TxtJobcard.AgRowFilter = ""
        Me.TxtJobcard.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtJobcard.AgSelectedValue = Nothing
        Me.TxtJobcard.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtJobcard.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtJobcard.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtJobcard.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtJobcard.Location = New System.Drawing.Point(385, 47)
        Me.TxtJobcard.MaxLength = 0
        Me.TxtJobcard.Name = "TxtJobcard"
        Me.TxtJobcard.Size = New System.Drawing.Size(143, 18)
        Me.TxtJobcard.TabIndex = 3
        '
        'LblJobCard
        '
        Me.LblJobCard.AutoSize = True
        Me.LblJobCard.BackColor = System.Drawing.Color.Transparent
        Me.LblJobCard.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblJobCard.Location = New System.Drawing.Point(276, 48)
        Me.LblJobCard.Name = "LblJobCard"
        Me.LblJobCard.Size = New System.Drawing.Size(83, 16)
        Me.LblJobCard.TabIndex = 693
        Me.LblJobCard.Text = "Job Card No."
        '
        'PnlCShowGrid2
        '
        Me.PnlCShowGrid2.Location = New System.Drawing.Point(502, 588)
        Me.PnlCShowGrid2.Name = "PnlCShowGrid2"
        Me.PnlCShowGrid2.Size = New System.Drawing.Size(7, 16)
        Me.PnlCShowGrid2.TabIndex = 741
        '
        'PnlCShowGrid
        '
        Me.PnlCShowGrid.Location = New System.Drawing.Point(523, 588)
        Me.PnlCShowGrid.Name = "PnlCShowGrid"
        Me.PnlCShowGrid.Size = New System.Drawing.Size(12, 16)
        Me.PnlCShowGrid.TabIndex = 740
        '
        'LblManualRefNoReq
        '
        Me.LblManualRefNoReq.AutoSize = True
        Me.LblManualRefNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblManualRefNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblManualRefNoReq.Location = New System.Drawing.Point(114, 53)
        Me.LblManualRefNoReq.Name = "LblManualRefNoReq"
        Me.LblManualRefNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblManualRefNoReq.TabIndex = 752
        Me.LblManualRefNoReq.Text = "Ä"
        '
        'TxtManualRefNo
        '
        Me.TxtManualRefNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtManualRefNo.AgLastValueTag = Nothing
        Me.TxtManualRefNo.AgLastValueText = Nothing
        Me.TxtManualRefNo.AgMandatory = True
        Me.TxtManualRefNo.AgMasterHelp = False
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
        Me.TxtManualRefNo.Location = New System.Drawing.Point(131, 47)
        Me.TxtManualRefNo.MaxLength = 0
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(132, 18)
        Me.TxtManualRefNo.TabIndex = 2
        '
        'LblManualRefNo
        '
        Me.LblManualRefNo.AutoSize = True
        Me.LblManualRefNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualRefNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualRefNo.Location = New System.Drawing.Point(13, 48)
        Me.LblManualRefNo.Name = "LblManualRefNo"
        Me.LblManualRefNo.Size = New System.Drawing.Size(63, 16)
        Me.LblManualRefNo.TabIndex = 751
        Me.LblManualRefNo.Text = "Entry No."
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
        Me.TxtRemarks.Location = New System.Drawing.Point(131, 87)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Multiline = True
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(397, 108)
        Me.TxtRemarks.TabIndex = 6
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.LblRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(13, 88)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(60, 16)
        Me.LblRemarks.TabIndex = 755
        Me.LblRemarks.Text = "Remarks"
        '
        'TxtVehicleNo
        '
        Me.TxtVehicleNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtVehicleNo.AgLastValueTag = Nothing
        Me.TxtVehicleNo.AgLastValueText = Nothing
        Me.TxtVehicleNo.AgMandatory = True
        Me.TxtVehicleNo.AgMasterHelp = False
        Me.TxtVehicleNo.AgNumberLeftPlaces = 8
        Me.TxtVehicleNo.AgNumberNegetiveAllow = False
        Me.TxtVehicleNo.AgNumberRightPlaces = 2
        Me.TxtVehicleNo.AgPickFromLastValue = False
        Me.TxtVehicleNo.AgRowFilter = ""
        Me.TxtVehicleNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleNo.AgSelectedValue = Nothing
        Me.TxtVehicleNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleNo.Location = New System.Drawing.Point(131, 67)
        Me.TxtVehicleNo.MaxLength = 0
        Me.TxtVehicleNo.Name = "TxtVehicleNo"
        Me.TxtVehicleNo.Size = New System.Drawing.Size(132, 18)
        Me.TxtVehicleNo.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(75, 16)
        Me.Label3.TabIndex = 758
        Me.Label3.Text = "Vehicle No."
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
        Me.TxtModel.Location = New System.Drawing.Point(385, 67)
        Me.TxtModel.MaxLength = 0
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(143, 18)
        Me.TxtModel.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(276, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 760
        Me.Label4.Text = "Model"
        '
        'PnlCustomGrid
        '
        Me.PnlCustomGrid.Location = New System.Drawing.Point(539, 28)
        Me.PnlCustomGrid.Name = "PnlCustomGrid"
        Me.PnlCustomGrid.Size = New System.Drawing.Size(435, 167)
        Me.PnlCustomGrid.TabIndex = 7
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
        Me.TxtCustomFields.Location = New System.Drawing.Point(724, 271)
        Me.TxtCustomFields.MaxLength = 20
        Me.TxtCustomFields.Name = "TxtCustomFields"
        Me.TxtCustomFields.Size = New System.Drawing.Size(142, 18)
        Me.TxtCustomFields.TabIndex = 1012
        Me.TxtCustomFields.Text = "TxtCustomFields"
        Me.TxtCustomFields.Visible = False
        '
        'FrmJobCardDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(982, 328)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Name = "FrmJobCardDetail"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
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
        Me.ResumeLayout(False)

    End Sub
    Protected WithEvents LblJobCard As System.Windows.Forms.Label
    Public WithEvents TxtJobcard As AgControls.AgTextBox
    Protected WithEvents LblTableReq As System.Windows.Forms.Label
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblManualRefNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblManualRefNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblRemarks As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleNo As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtModel As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents PnlCustomGrid As System.Windows.Forms.Panel
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Service_JobCardDetail"
        LogTableName = "Service_JobCardDetail_Log"

        AgL.AddAgDataGrid(AgCustomGrid1, PnlCustomGrid)

        AgCustomGrid1.AgLibVar = AgL
        AgCustomGrid1.SplitGrid = True
        AgCustomGrid1.MnuText = Me.Name
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From Service_JobCardDetail H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = "SELECT H.DocId as SearchCode, Vt.Description AS [Entry_Type], " & _
                            " H.V_Date AS [Entry_Date], H.ManualRefNo As Entry_No, " & _
                            " H.ActualInvoiceAmount As Actual_Invoice_Amount, H.ActualInsuranceClaimAmount As Actual_Insurance_Claim_Amount, " & _
                            " H.ActualCustomerPaybleAmount As Actual_Customer_Payble_Amount, " & _
                            " H.ActualCustomerReceiptAmount As Actual_Customer_Receipt_Amount, " & _
                            " H.ActualBalanceAmt As Actual_Balance_Amt, H.Remarks  " & _
                            " FROM Service_JobCardDetail H " & _
                            " Left Join Service_JobCard JC On H.Service_JobCard = JC.DocID " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where 1=1  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry_Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = "  Update Service_JobCardDetail " & _
                " SET  " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                " Service_JobCard = " & AgL.Chk_Text(TxtJobcard.Tag) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " " & AgCustomGrid1.FFooterTableUpdateStr() & " " & _
                " Where DocID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        mQry = "Select H.*, JC.ManualRefNo as JobCardNo, " & _
                " IU.Item_UID, I.Description as Model_Name " & _
                " From Service_JobCardDetail H  " & _
                " Left Join Service_JobCard JC On H.Service_JobCard = JC.DocID " & _
                " Left Join Item_UID IU On JC.Item_UID = IU.Code " & _
                " Left Join Item I On IU.Item = I.Code " & _
                " Where H.DocID='" & SearchCode & "'"
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

                TxtManualRefNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtJobcard.Tag = AgL.XNull(.Rows(0)("Service_JobCard"))
                TxtJobcard.Text = AgL.XNull(.Rows(0)("JobCardNo"))

                TxtModel.Text = AgL.XNull(.Rows(0)("Model_Name"))
                TxtVehicleNo.Text = AgL.XNull(.Rows(0)("Item_UID"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                AgCustomGrid1.FMoveRecFooterTable(DsTemp.Tables(0))
            End If
        End With

        If AgCustomGrid1.Rows.Count = 0 Then AgCustomGrid1.Visible = False
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 357, 988, 0, 0)
        AgCustomGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtManualRefNo.Validating, TxtJobcard.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)
                    AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue
                    IniGrid()
                    TxtManualRefNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "Service_JobCard", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)

                Case TxtManualRefNo.Name
                    e.Cancel = FIsDuplicateManualRefNo()

                Case TxtJobcard.Name
                    If sender.AgDataRow IsNot Nothing Then
                        TxtVehicleNo.Text = AgL.XNull(sender.AgDataRow.Cells("Vehicle_No").Value)
                        TxtModel.Text = AgL.XNull(sender.AgDataRow.Cells("Model_Name").Value)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GCn)
        AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue
        IniGrid()

        TxtManualRefNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "Service_JobCardDetail", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max) 'TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
        TxtJobcard.Focus()
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtJobcard, LblJobCard.Text) Then passed = False : Exit Sub

        If FIsDuplicateManualRefNo() Then passed = False : Exit Sub
    End Sub

    Private Function FIsDuplicateManualRefNo() As Boolean

        mQry = "Select Count(*) from Service_JobCardDetail H " & _
               " Where H.ManualRefNo = '" & TxtManualRefNo.Text & "' " & _
               " And H.DocID <> '" & TxtDocId.Text & "' " & _
               " And H.Site_Code ='" & TxtSite_Code.AgSelectedValue & "' " & _
               " And H.Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
               " And H.V_Type = '" & TxtV_Type.AgSelectedValue & "'  "

        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
            MsgBox("Reference No. already exists")
            FIsDuplicateManualRefNo = True
        End If
    End Function

    Private Sub TxtFromGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJobcard.KeyDown
        Select Case sender.Name
            Case TxtJobcard.Name
                If e.KeyCode <> Keys.Enter Then
                    If sender.AgHelpDataset Is Nothing Then
                        mQry = " SELECT H.DocId, H.ManualRefNo AS Jobcard_No, IU.Item_UID AS Vehicle_No, " & _
                                " I.Description AS Model_Name, H.CostCenter, Sg.Name As InsuranceCompanyName   " & _
                                " FROM Service_JobCard H " & _
                                " LEFT JOIN Item_UID IU ON H.Item_UID = IU.Code " & _
                                " LEFT JOIN Item I ON IU.Item = I.Code " & _
                                " LEFT JOIN SubGroup Sg On H.InsuranceCompany = Sg.SubCode " & _
                                " Where H.Div_Code = '" & AgL.PubDivCode & "' " & _
                                " And H.Site_Code = '" & TxtSite_Code.AgSelectedValue & "'  " & _
                                " And IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                " AND Convert(DATE,H.V_Date) <= '" & TxtV_Date.Text & "' " & _
                                " Order By H.V_Date, H.ManualRefNo "
                        sender.AgHelpDataset(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                    End If
                End If
        End Select
    End Sub

    Private Sub FrmMaterialIssueToJobCard_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtModel.Enabled = False
        TxtVehicleNo.Enabled = False
    End Sub

    Private Sub FrmInsuranceClaimIntimation_BaseEvent_Topctrl_tbRef() Handles Me.BaseEvent_Topctrl_tbRef
        If TxtJobcard.AgHelpDataSet IsNot Nothing Then TxtJobcard.AgHelpDataSet.Dispose() : TxtJobcard.AgHelpDataSet = Nothing
    End Sub

    Private Sub FrmJobCardDetail_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        AgCustomGrid1.Ini_Grid(mSearchCode)
        AgCustomGrid1.SplitGrid = False

        AgCustomGrid1.Name = "AgCustomGrid1"
        AgCL.GridSetiingShowXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
    End Sub
End Class
