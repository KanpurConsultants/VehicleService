Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmLabourDoneOnJobCard
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1SubCode As String = "Work Done By"
    Protected Const Col1ItemCode As String = "Item Code"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1ChargeType As String = "Charge Type"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1QtyDecimalPlaces As String = "Qty Decimal Places"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remarks As String = "Remarks"

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        Me.EntryNCat = ClsMain.Temp_NCat.ServiceLabourDone
        mQry = "Select H.* from Voucher_Type_Settings H Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  Where Vt.NCat In ('" & EntryNCat & "') And H.Div_Code = '" & AgL.PubDivCode & "' And H.Site_Code ='" & AgL.PubSiteCode & "' "
        DtV_TypeSettings = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.LblTableReq = New System.Windows.Forms.Label
        Me.TxtJobcard = New AgControls.AgTextBox
        Me.LblTable = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCShowGrid2 = New System.Windows.Forms.Panel
        Me.PnlCShowGrid = New System.Windows.Forms.Panel
        Me.LblReferenceNoReq = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.LblRemarks = New System.Windows.Forms.Label
        Me.LblKOTNature = New System.Windows.Forms.Label
        Me.TxtSlipNature = New AgControls.AgTextBox
        Me.TxtVehicleNo = New AgControls.AgTextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtModel = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblHelp = New System.Windows.Forms.Label
        Me.TxtCostCenter = New AgControls.AgTextBox
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
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(758, 471)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(653, 497)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(368, 471)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(193, 471)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 471)
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
        Me.GroupBox1.Location = New System.Drawing.Point(-6, 468)
        Me.GroupBox1.Size = New System.Drawing.Size(1000, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(571, 471)
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
        Me.TxtDocId.Tag = ""
        Me.TxtDocId.Text = ""
        '
        'LblV_No
        '
        Me.LblV_No.Location = New System.Drawing.Point(121, 151)
        Me.LblV_No.Size = New System.Drawing.Size(80, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Voucher No."
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(227, 154)
        Me.TxtV_No.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(594, 15)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(511, 10)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(809, 80)
        Me.LblV_TypeReq.Tag = ""
        Me.LblV_TypeReq.Visible = False
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(613, 9)
        Me.TxtV_Date.Size = New System.Drawing.Size(143, 18)
        Me.TxtV_Date.TabIndex = 1
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(808, 58)
        Me.LblV_Type.Size = New System.Drawing.Size(88, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Voucher Type"
        Me.LblV_Type.Visible = False
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(827, 77)
        Me.TxtV_Type.Size = New System.Drawing.Size(151, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        Me.TxtV_Type.Visible = False
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(344, 15)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(226, 10)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(363, 9)
        Me.TxtSite_Code.Size = New System.Drawing.Size(132, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(179, 155)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-5, 19)
        Me.TabControl1.Size = New System.Drawing.Size(990, 166)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtCostCenter)
        Me.TP1.Controls.Add(Me.TxtModel)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtVehicleNo)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.LblReferenceNoReq)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.LblKOTNature)
        Me.TP1.Controls.Add(Me.LblRemarks)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.TxtSlipNature)
        Me.TP1.Controls.Add(Me.LblTableReq)
        Me.TP1.Controls.Add(Me.TxtJobcard)
        Me.TP1.Controls.Add(Me.LblTable)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(982, 140)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobcard, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTableReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSlipNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblKOTNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNoReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.TxtCostCenter, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(982, 41)
        Me.Topctrl1.TabIndex = 2
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
        'LblTableReq
        '
        Me.LblTableReq.AutoSize = True
        Me.LblTableReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTableReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTableReq.Location = New System.Drawing.Point(594, 35)
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
        Me.TxtJobcard.Location = New System.Drawing.Point(613, 29)
        Me.TxtJobcard.MaxLength = 0
        Me.TxtJobcard.Name = "TxtJobcard"
        Me.TxtJobcard.Size = New System.Drawing.Size(143, 18)
        Me.TxtJobcard.TabIndex = 3
        '
        'LblTable
        '
        Me.LblTable.AutoSize = True
        Me.LblTable.BackColor = System.Drawing.Color.Transparent
        Me.LblTable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTable.Location = New System.Drawing.Point(511, 30)
        Me.LblTable.Name = "LblTable"
        Me.LblTable.Size = New System.Drawing.Size(83, 16)
        Me.LblTable.TabIndex = 693
        Me.LblTable.Text = "Job Card No."
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 439)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(973, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(97, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(465, 4)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 662
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(12, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'LblTotalAmountText
        '
        Me.LblTotalAmountText.AutoSize = True
        Me.LblTotalAmountText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmountText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalAmountText.Location = New System.Drawing.Point(361, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 212)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 227)
        Me.Pnl1.TabIndex = 0
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 191)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(109, 20)
        Me.LinkLabel1.TabIndex = 2
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Item Details"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        'LblReferenceNoReq
        '
        Me.LblReferenceNoReq.AutoSize = True
        Me.LblReferenceNoReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblReferenceNoReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblReferenceNoReq.Location = New System.Drawing.Point(344, 35)
        Me.LblReferenceNoReq.Name = "LblReferenceNoReq"
        Me.LblReferenceNoReq.Size = New System.Drawing.Size(10, 7)
        Me.LblReferenceNoReq.TabIndex = 752
        Me.LblReferenceNoReq.Text = "Ä"
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtReferenceNo.AgLastValueTag = Nothing
        Me.TxtReferenceNo.AgLastValueText = Nothing
        Me.TxtReferenceNo.AgMandatory = True
        Me.TxtReferenceNo.AgMasterHelp = False
        Me.TxtReferenceNo.AgNumberLeftPlaces = 8
        Me.TxtReferenceNo.AgNumberNegetiveAllow = False
        Me.TxtReferenceNo.AgNumberRightPlaces = 2
        Me.TxtReferenceNo.AgPickFromLastValue = False
        Me.TxtReferenceNo.AgRowFilter = ""
        Me.TxtReferenceNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtReferenceNo.AgSelectedValue = Nothing
        Me.TxtReferenceNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtReferenceNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtReferenceNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtReferenceNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtReferenceNo.Location = New System.Drawing.Point(363, 29)
        Me.TxtReferenceNo.MaxLength = 0
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(132, 18)
        Me.TxtReferenceNo.TabIndex = 2
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(226, 30)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(63, 16)
        Me.LblReferenceNo.TabIndex = 751
        Me.LblReferenceNo.Text = "Entry No."
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
        Me.TxtRemarks.Location = New System.Drawing.Point(363, 69)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(393, 18)
        Me.TxtRemarks.TabIndex = 8
        '
        'LblRemarks
        '
        Me.LblRemarks.AutoSize = True
        Me.LblRemarks.BackColor = System.Drawing.Color.Transparent
        Me.LblRemarks.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRemarks.Location = New System.Drawing.Point(226, 70)
        Me.LblRemarks.Name = "LblRemarks"
        Me.LblRemarks.Size = New System.Drawing.Size(60, 16)
        Me.LblRemarks.TabIndex = 755
        Me.LblRemarks.Text = "Remarks"
        '
        'LblKOTNature
        '
        Me.LblKOTNature.AutoSize = True
        Me.LblKOTNature.BackColor = System.Drawing.Color.Transparent
        Me.LblKOTNature.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblKOTNature.Location = New System.Drawing.Point(808, 74)
        Me.LblKOTNature.Name = "LblKOTNature"
        Me.LblKOTNature.Size = New System.Drawing.Size(107, 16)
        Me.LblKOTNature.TabIndex = 754
        Me.LblKOTNature.Text = "Issue Slip Nature"
        Me.LblKOTNature.Visible = False
        '
        'TxtSlipNature
        '
        Me.TxtSlipNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtSlipNature.AgLastValueTag = Nothing
        Me.TxtSlipNature.AgLastValueText = Nothing
        Me.TxtSlipNature.AgMandatory = True
        Me.TxtSlipNature.AgMasterHelp = False
        Me.TxtSlipNature.AgNumberLeftPlaces = 8
        Me.TxtSlipNature.AgNumberNegetiveAllow = False
        Me.TxtSlipNature.AgNumberRightPlaces = 2
        Me.TxtSlipNature.AgPickFromLastValue = False
        Me.TxtSlipNature.AgRowFilter = ""
        Me.TxtSlipNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSlipNature.AgSelectedValue = Nothing
        Me.TxtSlipNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSlipNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSlipNature.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSlipNature.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSlipNature.Location = New System.Drawing.Point(811, 93)
        Me.TxtSlipNature.MaxLength = 100
        Me.TxtSlipNature.Name = "TxtSlipNature"
        Me.TxtSlipNature.Size = New System.Drawing.Size(151, 18)
        Me.TxtSlipNature.TabIndex = 5
        Me.TxtSlipNature.Visible = False
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
        Me.TxtVehicleNo.Location = New System.Drawing.Point(363, 49)
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
        Me.Label3.Location = New System.Drawing.Point(226, 50)
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
        Me.TxtModel.Location = New System.Drawing.Point(613, 49)
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
        Me.Label4.Location = New System.Drawing.Point(511, 50)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 16)
        Me.Label4.TabIndex = 760
        Me.Label4.Text = "Model"
        '
        'LblHelp
        '
        Me.LblHelp.AutoSize = True
        Me.LblHelp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHelp.Location = New System.Drawing.Point(119, 193)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(145, 16)
        Me.LblHelp.TabIndex = 3007
        Me.LblHelp.Text = "I -Issue  R - Return"
        Me.LblHelp.Visible = False
        '
        'TxtCostCenter
        '
        Me.TxtCostCenter.AgAllowUserToEnableMasterHelp = False
        Me.TxtCostCenter.AgLastValueTag = Nothing
        Me.TxtCostCenter.AgLastValueText = Nothing
        Me.TxtCostCenter.AgMandatory = True
        Me.TxtCostCenter.AgMasterHelp = False
        Me.TxtCostCenter.AgNumberLeftPlaces = 8
        Me.TxtCostCenter.AgNumberNegetiveAllow = False
        Me.TxtCostCenter.AgNumberRightPlaces = 2
        Me.TxtCostCenter.AgPickFromLastValue = False
        Me.TxtCostCenter.AgRowFilter = ""
        Me.TxtCostCenter.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCostCenter.AgSelectedValue = Nothing
        Me.TxtCostCenter.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCostCenter.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCostCenter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCostCenter.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCostCenter.Location = New System.Drawing.Point(772, 27)
        Me.TxtCostCenter.MaxLength = 0
        Me.TxtCostCenter.Name = "TxtCostCenter"
        Me.TxtCostCenter.Size = New System.Drawing.Size(132, 18)
        Me.TxtCostCenter.TabIndex = 764
        Me.TxtCostCenter.Text = "TxtCostCenter"
        Me.TxtCostCenter.Visible = False
        '
        'FrmLabourDoneOnJobCard
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(982, 519)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.PnlCShowGrid2)
        Me.Controls.Add(Me.PnlCShowGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmLabourDoneOnJobCard"
        Me.Text = "Template Goods Receive"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCShowGrid2, 0)
        Me.Controls.SetChildIndex(Me.LblHelp, 0)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblTable As System.Windows.Forms.Label
    Public WithEvents TxtJobcard As AgControls.AgTextBox
    Protected WithEvents LblTableReq As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCShowGrid2 As System.Windows.Forms.Panel
    Protected WithEvents PnlCShowGrid As System.Windows.Forms.Panel
    Protected WithEvents LblReferenceNoReq As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents LblRemarks As System.Windows.Forms.Label
    Protected WithEvents LblKOTNature As System.Windows.Forms.Label
    Protected WithEvents TxtSlipNature As AgControls.AgTextBox
    Protected WithEvents TxtVehicleNo As AgControls.AgTextBox
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtModel As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents LblHelp As System.Windows.Forms.Label
    Public WithEvents TxtCostCenter As AgControls.AgTextBox
#End Region

    Private Sub FrmMaterialIssueToJobCard_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleChallan"
        MainLineTableCsv = "SaleChallanDetail"

        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        mQry = "Select DocID As SearchCode " & _
                " From SaleChallan H " & _
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
                            " H.V_Date AS [Entry_Date], H.ReferenceNo  " & _
                            " FROM SaleChallan H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where 1=1  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry_Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1SubCode, 120, 0, Col1SubCode, True, False)
            .AddAgTextColumn(Dgl1, Col1ItemCode, 120, 0, Col1ItemCode, True, False)
            .AddAgTextColumn(Dgl1, Col1Item, 200, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1ChargeType, 80, 0, Col1ChargeType, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 70, 8, 3, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True, False)
            .AddAgTextColumn(Dgl1, Col1QtyDecimalPlaces, 50, 0, Col1QtyDecimalPlaces, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1Remarks, 130, 0, Col1Remarks, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.Anchor = Pnl1.Anchor

        Dgl1.ColumnHeadersHeight = 35
        Dgl1.AgSkipReadOnlyColumns = True
        Dgl1.AgAllowFind = False

        AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "  Update SaleChallan " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Service_JobCard = " & AgL.Chk_Text(TxtJobcard.Tag) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & " " & _
                " Where DocID = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From SaleChallanDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                mSr += 1

                mQry = "Insert Into SaleChallanDetail(DocId, Sr, SubCode, Item, ChargeType, " & _
                        " Qty, Unit, TotalMeasure, MeasureUnit, Rate, Amount, Net_Amount, Remark, " & _
                        " SaleChallan, SaleChallanSr) " & _
                        " Values( " & _
                        " " & AgL.Chk_Text(SearchCode) & ", " & mSr & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1SubCode, I).Tag) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Item, I).Tag) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1ChargeType, I).Tag) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                        " " & AgL.Chk_Text(Dgl1.Item(Col1Remarks, I).Value) & ", " & _
                        " " & AgL.Chk_Text(SearchCode) & ", " & _
                        " " & Val(mSr) & " " & _
                        " ) "
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If
        Next

        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet


        mQry = "Select H.*, Sg.Name as IssuetoSubCodeName, JC.ManualRefNo as JobCardNo, JC.CostCenter, IU.Item_UID, I.Description as Model_Name, G.Description as Godown_Name " & _
                " From SaleChallan H  " & _
                " Left Join SubGroup Sg On H.IssueToSubcode = Sg.SubCode " & _
                " Left Join Service_JobCard JC On H.Service_JobCard = JC.DocID " & _
                " Left Join Item_UID IU On JC.Item_UID = IU.Code " & _
                " Left Join Item I On IU.Item = I.Code " & _
                " Left Join Godown G On H.Godown = G.Code " & _
                " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtJobcard.Tag = AgL.XNull(.Rows(0)("Service_JobCard"))
                TxtJobcard.Text = AgL.XNull(.Rows(0)("JobCardNo"))

                TxtCostCenter.Text = AgL.XNull(.Rows(0)("CostCenter"))

                TxtModel.Text = AgL.XNull(.Rows(0)("Model_Name"))
                TxtVehicleNo.Text = AgL.XNull(.Rows(0)("Item_UID"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                mQry = "Select L.*, I.Description as Item_Name, I.ManualCode as Item_Code, " & _
                        " U.DecimalPlaces as QtyDecimalPlaces, Sg.Name As SubCodeName  " & _
                        " from SaleChallanDetail L " & _
                        " Left Join Item I On L.Item = I.Code " & _
                        " Left Join Unit U On I.Unit = U.Code " & _
                        " LEFT JOIN SubGroup Sg On L.SubCode = Sg.SubCode " & _
                        " Where L.DocId = '" & SearchCode & "' " & _
                        " Order By L.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.Item(Col1SubCode, I).Tag = AgL.XNull(.Rows(I)("SubCode"))
                            Dgl1.Item(Col1SubCode, I).Value = AgL.XNull(.Rows(I)("SubCodeName"))
                            Dgl1.Item(Col1Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Item, I).Value = AgL.XNull(.Rows(I)("Item_Name"))
                            Dgl1.Item(Col1ItemCode, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1ItemCode, I).Value = AgL.XNull(.Rows(I)("Item_Code"))
                            Dgl1.Item(Col1ChargeType, I).Tag = AgL.XNull(.Rows(I)("ChargeType"))
                            Dgl1.Item(Col1ChargeType, I).Value = AgL.XNull(.Rows(I)("ChargeType"))
                            Dgl1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1QtyDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("QtyDecimalPlaces"))
                            Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            Dgl1.Item(Col1Remarks, I).Value = AgL.XNull(.Rows(I)("Remark"))
                        Next I
                    End If
                End With
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 551, 988, 0, 0)
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtReferenceNo.Validating, TxtJobcard.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtReferenceNo.Name
                    e.Cancel = FIsDuplicateReferenceNo()

                Case TxtJobcard.Name
                    If sender.AgDataRow IsNot Nothing Then
                        TxtVehicleNo.Text = AgL.XNull(sender.AgDataRow.Cells("Vehicle_No").Value)
                        TxtModel.Text = AgL.XNull(sender.AgDataRow.Cells("Model_Name").Value)
                        TxtCostCenter.Text = AgL.XNull(sender.AgDataRow.Cells("CostCenter").Value)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "SaleChallan", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max) 'TxtV_Type.AgSelectedValue + "-" + TxtV_No.Text.ToString
        TxtJobcard.Focus()
    End Sub

    Private Sub Validating_Item(ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(Col1Item, mRow).Value Is Nothing Then Dgl1.Item(Col1Item, mRow).Value = ""
            If Dgl1.Item(Col1ItemCode, mRow).Value Is Nothing Then Dgl1.Item(Col1ItemCode, mRow).Value = ""

            If Dgl1.Item(Col1Item, mRow).Tag Is Nothing Then Dgl1.Item(Col1Item, mRow).Tag = ""
            If Dgl1.Item(Col1ItemCode, mRow).Tag Is Nothing Then Dgl1.Item(Col1ItemCode, mRow).Tag = ""


            If (Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "") And (Dgl1.Item(Col1ItemCode, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1ItemCode, mRow).ToString.Trim = "") Then
                Dgl1.Item(Col1Rate, mRow).Value = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1ItemCode, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value)
                    Dgl1.Item(Col1ItemCode, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Item_No").Value)
                    Dgl1.Item(Col1Item, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value)
                    Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Item_Name").Value)
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Rate").Value)
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1QtyDecimalPlaces, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("QtyDecimalPlaces").Value)

                    Dgl1.Item(Col1ChargeType, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("ChargeTypeCode").Value)
                    Dgl1.Item(Col1ChargeType, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("ChargeType").Value)

                    If Val(Dgl1.Item(Col1Qty, mRow).Value) = 0 Then
                        Dgl1.Item(Col1Qty, mRow).Value = 1
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        If Dgl1.CurrentCell Is Nothing Then Exit Sub
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Qty
                CType(Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex), AgControls.AgTextColumn).AgNumberRightPlaces = Val(Dgl1.Item(Col1QtyDecimalPlaces, Dgl1.CurrentCell.RowIndex).Value)

            Case Col1SubCode
                If Dgl1.Item(Col1SubCode, e.RowIndex).Value = "" Then
                    Try
                        Dgl1.Item(Col1SubCode, e.RowIndex).Value = Dgl1.Item(Col1SubCode, e.RowIndex - 1).Value
                    Catch ex As Exception
                    End Try

                End If
        End Select
    End Sub

    Private Sub Dgl1_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.EditingControl_KeyDown
        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item, Col1ItemCode
                If e.KeyCode <> Keys.Enter Then
                    If Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex) Is Nothing Then
                        FCreateHelpItem()
                    End If
                End If

            Case Col1ChargeType
                If e.KeyCode <> Keys.Enter Then
                    If Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex) Is Nothing Then
                        mQry = "Select Code, Code as Name From Service_ChargeType Order By Code"
                        Dgl1.AgHelpDataSet(Col1ChargeType) = AgL.FillData(mQry, AgL.GCn)
                    End If
                End If

            Case Col1SubCode
                If e.KeyCode <> Keys.Enter Then
                    If Dgl1.AgHelpDataSet(Col1SubCode) Is Nothing Then
                        FCreateHelpSubgroup()
                    End If
                End If
        End Select
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim bItemCode$ = ""
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1ItemCode, Col1Item
                    Validating_Item(mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.00")

                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtJobcard, LblTable.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub
        If AgCL.AgIsDuplicate(Dgl1, "" & Dgl1.Columns(Col1Item).Index & "") Then passed = False : Exit Sub

        If FIsDuplicateReferenceNo() Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    If Val(.Item(Col1Rate, I).Value) = 0 Then
                        MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        If e.KeyCode = Keys.Enter Then
            If Dgl1.CurrentCell.ColumnIndex = 2 Then
                If Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value Is Nothing Then Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value = ""
                If Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value = "" Then
                    If MsgBox("Do you want to save?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Save") = MsgBoxResult.Yes Then
                        Topctrl1.FButtonClick(13)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub FCreateHelpSubgroup()
        Dim strCond As String = ""
        If DtV_TypeSettings.Rows.Count > 0 Then
            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_AcGroup")) <> "" Then
                strCond += " And CharIndex('|' + H.GroupCode + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_AcGroup")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_AcGroup")) <> "" Then
                strCond += " And CharIndex('|' + H.GroupCode + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_AcGroup")) & "') <= 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_SubgroupDivision")) <> "" Then
                strCond += " And CharIndex('|' + H.Div_Code + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_subGroupDivision")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_SubgroupSite")) <> "" Then
                strCond += " And CharIndex('|' + H.Site_Code + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_subGroupSite")) & "') > 0 "
            End If
        End If

        mQry = " SELECT H.SubCode AS Code, H.Name AS JobWorker, City.CityName as City_Name " & _
                " FROM Subgroup H  With (NoLock) " & _
                " Left Join City On H.CityCode = City.CityCode" & _
                " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') ='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                " And H.MasterType = '" & ClsMain.MasterType.Employee & "'" & strCond
        Dgl1.AgHelpDataSet(Col1SubCode) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FCreateHelpItem()
        Dim strCond As String = ""
        If DtV_TypeSettings.Rows.Count > 0 Then
            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemType")) <> "" Then
                strCond += " And CharIndex('|' + H.ItemType + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemType")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemGroup")) <> "" Then
                strCond += " And CharIndex('|' + H.ItemGroup + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemGroup")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_ItemGroup")) <> "" Then
                strCond += " And CharIndex('|' + H.ItemGroup + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_ItemGroup")) & "') <= 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_Item")) <> "" Then
                strCond += " And CharIndex('|' + H.Code + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_Item")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_Item")) <> "" Then
                strCond += " And CharIndex('|' + H.Item + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterExclude_Item")) & "') <= 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemDivision")) <> "" Then
                strCond += " And CharIndex('|' + H.Div_Code + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemDivision")) & "') > 0 "
            End If

            If AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemSite")) <> "" Then
                strCond += " And CharIndex('|' + H.Site_Code + '|','" & AgL.XNull(DtV_TypeSettings.Rows(0)("FilterInclude_ItemSite")) & "') > 0 "
            End If
        End If

        Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
            Case Col1Item
                mQry = "SELECT H.Code, H.Description as Item_Name, H.ManualCode as Item_No, H.Unit, " & _
                        " H.Measure As MeasurePerPcs, 0 As [Bal.Measure], H.MeasureUnit, U.DecimalPlaces as QtyDecimalPlaces, MU.DecimalPlaces as MeasureDecimalPlaces, H.Rate, " & _
                        " '' As SaleChallan, 0 As SaleChallanSr, 0 As [Bal.Qty],'' As SaleChallanNo, '' As ChargeTypeCode, '' As ChargeType   " & _
                        " FROM Item H " & _
                        " Left Join Unit U On H.Unit = U.Code " & _
                        " Left Join Unit MU On H.MeasureUnit = MU.Code " & _
                        " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & strCond
                Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex, 13) = AgL.FillData(mQry, AgL.GCn)

            Case Col1ItemCode
                mQry = "SELECT H.Code, H.ManualCode as Item_No, H.Description as Item_Name, H.Unit, " & _
                        " H.Measure As MeasurePerPcs, 0 As [Bal.Measure], H.MeasureUnit, U.DecimalPlaces as QtyDecimalPlaces, MU.DecimalPlaces as MeasureDecimalPlaces, H.Rate, " & _
                        " '' As SaleChallan, 0 As SaleChallanSr, 0 As [Bal.Qty],'' As SaleChallanNo, '' As ChargeTypeCode, '' As ChargeType   " & _
                        " FROM Item H " & _
                        " Left Join Unit U On H.Unit = U.Code " & _
                        " Left Join Unit MU On H.MeasureUnit = MU.Code " & _
                        " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & strCond
                Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex, 13) = AgL.FillData(mQry, AgL.GCn)
        End Select
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String

            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT Max(H.ReferenceNo) AS VNo FROM SaleInvoiceDetail L LEFT JOIN SaleInvoice H ON L.DocId = H.DocID WHERE L.SaleChallan  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0)=0 Group By H.DocID ) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Sale Invoice " & bRData & " created against KOT No. " & TxtReferenceNo.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in FrmKot")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub TempSaleChallanCommon_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub TempSaleChallanCommon_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Function FIsDuplicateReferenceNo() As Boolean

        mQry = "Select Count(*) from SaleChallan H " & _
               " Where H.ReferenceNo = '" & TxtReferenceNo.Text & "' " & _
               " And H.DocID <> '" & TxtDocId.Text & "' " & _
               " And H.Site_Code ='" & TxtSite_Code.AgSelectedValue & "' " & _
               " And H.Div_Code = '" & TxtDivision.AgSelectedValue & "' " & _
               " And H.V_Type = '" & TxtV_Type.AgSelectedValue & "'  " & _
               " And IsNull(H.IsDeleted,0)=0  "

        If AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar > 0 Then
            MsgBox("Reference No. already exists")
            FIsDuplicateReferenceNo = True
        End If
    End Function

    Private Sub FrmPurchaseEntry_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        'Dim mCrd As New ReportDocument
        'Dim ReportView As New AgLibrary.RepView
        'Dim DsRep As New DataSet
        'Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        'Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        'Dim bStructJoin As String = ""

        'Try
        '    Me.Cursor = Cursors.WaitCursor
        '    AgL.PubReportTitle = "KOT"
        '    RepName = "Ht_KOT_Print" : RepTitle = "KOT"
        '    bCondstr = " WHERE H.DocID = '" & mInternalCode & "'"

        '    mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.SaleToParty, " & _
        '                " H.SaleToPartyName, H.SaleToPartyAddress, H.SaleToPartyCity, H.SaleToPartyMobile, H.ShipToParty, H.ShipToPartyName,  " & _
        '                " H.ShipToPartyAddress, H.ShipToPartyCity, H.ShipToPartyMobile, H.Currency, H.GateEntryNo, H.TruckNo,  " & _
        '                " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.Godown, H.Remarks,  " & _
        '                " H.TotalQty, H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy,  " & _
        '                " H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Steward, H.KOTNature,  " & _
        '                " H.SaleInvoice, H.TableCode, H.Vendor, H.SaleOrder, H.DeliveryOrder, H.Vehicle, H.VehicleDescription, H.Driver,  " & _
        '                " H.DriverName, H.DriverContactNo, H.LrNo, H.LrDate, H.PrivateMark, H.PortOfLoading, H.DestinationPort,  " & _
        '                " H.FinalPlaceOfDelivery, H.PreCarriageBy, H.PlaceOfPreCarriage, H.ShipmentThrough, " & _
        '                " L.DocId, L.Sr, L.V_Date, L.Item, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, L.Unit, L.MeasurePerPcs,  " & _
        '                " L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, L.Rate, L.Amount, L.InvoicedQty, L.InvoicedMeasure,  " & _
        '                " L.QcQty, L.QcMeasure, L.Remark, L.UID, L.Outlet, L.SaleOrder, L.DeliveryOrder,  " & _
        '                " L.Specification, L.BaleNo, L.JobReceiveDocId, Sg.DispName AS StewardName, T.Description AS TableDesc, I.Description AS ItemDesc  " & _
        '                " FROM SaleChallan H  " & _
        '                " LEFT JOIN SaleChallanDetail L ON H.DocID = L.DocId " & _
        '                " LEFT JOIN SubGroup Sg ON H.Steward = Sg.SubCode " & _
        '                " LEFT JOIN HT_Table T ON H.TableCode = T.Code " & _
        '                " LEFT JOIN Item I ON L.Item = I.Code " & _
        '                " " & bCondstr & ""

        '    AgL.ADMain = New SqlClient.SqlDataAdapter(mQry, AgL.GCn)
        '    AgL.ADMain.Fill(DsRep)
        '    AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
        '    mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
        '    mCrd.SetDataSource(DsRep.Tables(0))
        '    CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
        '    AgPL.Formula_Set(mCrd, RepTitle)
        '    AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

        '    Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        'Catch Ex As Exception
        '    MsgBox(Ex.Message)
        'Finally
        '    Me.Cursor = Cursors.Default
        'End Try

    End Sub

    Private Sub TxtRemarks_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemarks.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dgl1.CurrentCell = Dgl1.Item(0, 0) : Dgl1.Focus()
            e.Handled = False
        End If
    End Sub

    Private Sub TxtFromGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtJobcard.KeyDown
        Select Case sender.Name
            Case TxtJobcard.Name
                If e.KeyCode <> Keys.Enter Then
                    If sender.AgHelpDataset Is Nothing Then
                        mQry = " SELECT H.DocId, H.ManualRefNo AS Jobcard_No, IU.Item_UID AS Vehicle_No, I.Description AS Model_Name, H.CostCenter   " & _
                                " FROM Service_JobCard H " & _
                                " LEFT JOIN Item_UID IU ON H.Item_UID = IU.Code " & _
                                " LEFT JOIN Item I ON IU.Item = I.Code " & _
                                " Where H.Div_Code = '" & AgL.PubDivCode & "' " & _
                                " And H.Site_Code = '" & TxtSite_Code.AgSelectedValue & "'  " & _
                                " And IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                " AND Convert(DATE,H.V_Date)  <= '" & TxtV_Date.Text & "' " & _
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

    Private Sub RbtIssue_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dgl1.AgHelpDataSet(Col1Item) = Nothing
    End Sub
End Class
