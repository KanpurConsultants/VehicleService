Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Public Class FrmServiceQuotationApproved
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Public WithEvents AgCustomGrid1 As New AgCustomFields.AgCustomGrid

    '========================================================================
    '========================DATA GRID AND COLUMNS DEFINITION================
    '========================================================================
    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1ItemType As String = "Item Type"
    Protected Const Col1ItemCode As String = "Item Code"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1SaleQuotation As String = "Estimate No"
    Protected Const Col1SaleQuotationSr As String = "Sale Quotation Sr"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1QtyDecimalPlaces As String = "Qty Decimal Places"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1ServiceTaxOnModelYN As String = "Service Tax On Model Y/N"
    Protected Const Col1ServiceTaxYN As String = "Service Tax Y/N"

    Protected WithEvents TxtServiceTaxOnModelYN As AgControls.AgTextBox
    Protected WithEvents BtnFillSaleOrder As System.Windows.Forms.Button

    Public RowLockedColour As Color = Color.AliceBlue

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        EntryNCat = ClsMain.Temp_NCat.ServiceQuotationApproved
        mQry = "Select H.* from Voucher_Type_Settings H Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  Where Vt.NCat In ('" & EntryNCat & "') And H.Div_Code = '" & AgL.PubDivCode & "' And H.Site_Code ='" & AgL.PubSiteCode & "' "
        DtV_TypeSettings = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtSaleToParty = New AgControls.AgTextBox
        Me.LblBuyer = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtNature = New AgControls.AgTextBox
        Me.BtnFillPartyDetail = New System.Windows.Forms.Button
        Me.PnlCustomGrid = New System.Windows.Forms.Panel
        Me.TxtCustomFields = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtCostCenter = New AgControls.AgTextBox
        Me.LblTableReq = New System.Windows.Forms.Label
        Me.TxtJobcard = New AgControls.AgTextBox
        Me.LblTable = New System.Windows.Forms.Label
        Me.TxtModel = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtVehicleNo = New AgControls.AgTextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.LblHelp = New System.Windows.Forms.Label
        Me.TxtServiceTaxOnModelYN = New AgControls.AgTextBox
        Me.BtnFillSaleOrder = New System.Windows.Forms.Button
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
        Me.GroupBox2.Location = New System.Drawing.Point(829, 581)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(648, 581)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(467, 581)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(168, 581)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 581)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 577)
        Me.GroupBox1.Size = New System.Drawing.Size(1002, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(320, 581)
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
        Me.LblV_No.Location = New System.Drawing.Point(276, 267)
        Me.LblV_No.Size = New System.Drawing.Size(71, 16)
        Me.LblV_No.Tag = ""
        Me.LblV_No.Text = "Invoice No."
        Me.LblV_No.Visible = False
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(384, 266)
        Me.TxtV_No.Size = New System.Drawing.Size(163, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        Me.TxtV_No.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(108, 42)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(5, 37)
        Me.LblV_Date.Size = New System.Drawing.Size(95, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Quotation Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(337, 22)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(125, 36)
        Me.TxtV_Date.Size = New System.Drawing.Size(124, 18)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(255, 18)
        Me.LblV_Type.Size = New System.Drawing.Size(96, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Quotation Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(354, 16)
        Me.TxtV_Type.Size = New System.Drawing.Size(194, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(108, 22)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(5, 17)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(125, 16)
        Me.TxtSite_Code.Size = New System.Drawing.Size(124, 18)
        Me.TxtSite_Code.TabIndex = 0
        Me.TxtSite_Code.Tag = ""
        '
        'LblDocId
        '
        Me.LblDocId.Tag = ""
        '
        'LblPrefix
        '
        Me.LblPrefix.Location = New System.Drawing.Point(336, 267)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 17)
        Me.TabControl1.Size = New System.Drawing.Size(992, 126)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.BtnFillSaleOrder)
        Me.TP1.Controls.Add(Me.TxtServiceTaxOnModelYN)
        Me.TP1.Controls.Add(Me.TxtModel)
        Me.TP1.Controls.Add(Me.Label9)
        Me.TP1.Controls.Add(Me.TxtVehicleNo)
        Me.TP1.Controls.Add(Me.Label10)
        Me.TP1.Controls.Add(Me.TxtCostCenter)
        Me.TP1.Controls.Add(Me.LblTableReq)
        Me.TP1.Controls.Add(Me.TxtJobcard)
        Me.TP1.Controls.Add(Me.LblTable)
        Me.TP1.Controls.Add(Me.BtnFillPartyDetail)
        Me.TP1.Controls.Add(Me.TxtNature)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtSaleToParty)
        Me.TP1.Controls.Add(Me.LblBuyer)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 100)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblBuyer, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSaleToParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label4, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtNature, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFillPartyDetail, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTable, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtJobcard, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblTableReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtCostCenter, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label10, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVehicleNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label9, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtModel, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtServiceTaxOnModelYN, 0)
        Me.TP1.Controls.SetChildIndex(Me.BtnFillSaleOrder, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        Me.Topctrl1.TabIndex = 5
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
        Me.Label4.Location = New System.Drawing.Point(597, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtSaleToParty
        '
        Me.TxtSaleToParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtSaleToParty.AgLastValueTag = Nothing
        Me.TxtSaleToParty.AgLastValueText = Nothing
        Me.TxtSaleToParty.AgMandatory = True
        Me.TxtSaleToParty.AgMasterHelp = False
        Me.TxtSaleToParty.AgNumberLeftPlaces = 8
        Me.TxtSaleToParty.AgNumberNegetiveAllow = False
        Me.TxtSaleToParty.AgNumberRightPlaces = 2
        Me.TxtSaleToParty.AgPickFromLastValue = False
        Me.TxtSaleToParty.AgRowFilter = ""
        Me.TxtSaleToParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSaleToParty.AgSelectedValue = Nothing
        Me.TxtSaleToParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSaleToParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSaleToParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSaleToParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSaleToParty.Location = New System.Drawing.Point(612, 35)
        Me.TxtSaleToParty.MaxLength = 0
        Me.TxtSaleToParty.Name = "TxtSaleToParty"
        Me.TxtSaleToParty.Size = New System.Drawing.Size(329, 18)
        Me.TxtSaleToParty.TabIndex = 9
        '
        'LblBuyer
        '
        Me.LblBuyer.AutoSize = True
        Me.LblBuyer.BackColor = System.Drawing.Color.Transparent
        Me.LblBuyer.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblBuyer.Location = New System.Drawing.Point(554, 35)
        Me.LblBuyer.Name = "LblBuyer"
        Me.LblBuyer.Size = New System.Drawing.Size(39, 16)
        Me.LblBuyer.TabIndex = 693
        Me.LblBuyer.Text = "Party"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 386)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(974, 23)
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
        Me.LblTotalAmount.Location = New System.Drawing.Point(508, 4)
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
        Me.LblTotalAmountText.Location = New System.Drawing.Point(404, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 170)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(973, 216)
        Me.Pnl1.TabIndex = 1
        '
        'TxtStructure
        '
        Me.TxtStructure.AgAllowUserToEnableMasterHelp = False
        Me.TxtStructure.AgLastValueTag = Nothing
        Me.TxtStructure.AgLastValueText = Nothing
        Me.TxtStructure.AgMandatory = False
        Me.TxtStructure.AgMasterHelp = False
        Me.TxtStructure.AgNumberLeftPlaces = 8
        Me.TxtStructure.AgNumberNegetiveAllow = False
        Me.TxtStructure.AgNumberRightPlaces = 2
        Me.TxtStructure.AgPickFromLastValue = False
        Me.TxtStructure.AgRowFilter = ""
        Me.TxtStructure.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtStructure.AgSelectedValue = Nothing
        Me.TxtStructure.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtStructure.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtStructure.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtStructure.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtStructure.Location = New System.Drawing.Point(742, 203)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(60, 18)
        Me.TxtStructure.TabIndex = 15
        Me.TxtStructure.Text = "TxtStructure"
        Me.TxtStructure.Visible = False
        '
        'TxtSalesTaxGroupParty
        '
        Me.TxtSalesTaxGroupParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgLastValueTag = Nothing
        Me.TxtSalesTaxGroupParty.AgLastValueText = Nothing
        Me.TxtSalesTaxGroupParty.AgMandatory = False
        Me.TxtSalesTaxGroupParty.AgMasterHelp = False
        Me.TxtSalesTaxGroupParty.AgNumberLeftPlaces = 8
        Me.TxtSalesTaxGroupParty.AgNumberNegetiveAllow = False
        Me.TxtSalesTaxGroupParty.AgNumberRightPlaces = 2
        Me.TxtSalesTaxGroupParty.AgPickFromLastValue = False
        Me.TxtSalesTaxGroupParty.AgRowFilter = ""
        Me.TxtSalesTaxGroupParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtSalesTaxGroupParty.AgSelectedValue = Nothing
        Me.TxtSalesTaxGroupParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtSalesTaxGroupParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtSalesTaxGroupParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtSalesTaxGroupParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(855, 15)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(115, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(744, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(105, 16)
        Me.Label27.TabIndex = 717
        Me.Label27.Text = "Sales Tax Group"
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
        Me.TxtRemarks.Location = New System.Drawing.Point(66, 414)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(320, 18)
        Me.TxtRemarks.TabIndex = 2
        '
        'TxtReferenceNo
        '
        Me.TxtReferenceNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtReferenceNo.AgLastValueTag = Nothing
        Me.TxtReferenceNo.AgLastValueText = Nothing
        Me.TxtReferenceNo.AgMandatory = False
        Me.TxtReferenceNo.AgMasterHelp = True
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(354, 36)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(194, 18)
        Me.TxtReferenceNo.TabIndex = 3
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(255, 37)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(88, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Quotation No."
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 149)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Job Estimate For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(670, 413)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(308, 157)
        Me.PnlCalcGrid.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(337, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Ä"
        '
        'TxtNature
        '
        Me.TxtNature.AgAllowUserToEnableMasterHelp = False
        Me.TxtNature.AgLastValueTag = Nothing
        Me.TxtNature.AgLastValueText = Nothing
        Me.TxtNature.AgMandatory = False
        Me.TxtNature.AgMasterHelp = False
        Me.TxtNature.AgNumberLeftPlaces = 8
        Me.TxtNature.AgNumberNegetiveAllow = False
        Me.TxtNature.AgNumberRightPlaces = 2
        Me.TxtNature.AgPickFromLastValue = False
        Me.TxtNature.AgRowFilter = ""
        Me.TxtNature.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtNature.AgSelectedValue = Nothing
        Me.TxtNature.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtNature.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtNature.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtNature.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNature.Location = New System.Drawing.Point(724, 227)
        Me.TxtNature.MaxLength = 20
        Me.TxtNature.Name = "TxtNature"
        Me.TxtNature.Size = New System.Drawing.Size(95, 18)
        Me.TxtNature.TabIndex = 10
        Me.TxtNature.Text = "TxtNature"
        Me.TxtNature.Visible = False
        '
        'BtnFillPartyDetail
        '
        Me.BtnFillPartyDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillPartyDetail.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillPartyDetail.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnFillPartyDetail.Location = New System.Drawing.Point(944, 33)
        Me.BtnFillPartyDetail.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFillPartyDetail.Name = "BtnFillPartyDetail"
        Me.BtnFillPartyDetail.Size = New System.Drawing.Size(26, 20)
        Me.BtnFillPartyDetail.TabIndex = 5
        Me.BtnFillPartyDetail.TabStop = False
        Me.BtnFillPartyDetail.Text = "`"
        Me.BtnFillPartyDetail.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFillPartyDetail.UseVisualStyleBackColor = True
        '
        'PnlCustomGrid
        '
        Me.PnlCustomGrid.Location = New System.Drawing.Point(4, 441)
        Me.PnlCustomGrid.Name = "PnlCustomGrid"
        Me.PnlCustomGrid.Size = New System.Drawing.Size(382, 130)
        Me.PnlCustomGrid.TabIndex = 3
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
        Me.TxtCustomFields.Location = New System.Drawing.Point(486, 594)
        Me.TxtCustomFields.MaxLength = 20
        Me.TxtCustomFields.Name = "TxtCustomFields"
        Me.TxtCustomFields.Size = New System.Drawing.Size(72, 18)
        Me.TxtCustomFields.TabIndex = 1011
        Me.TxtCustomFields.Text = "AgTextBox1"
        Me.TxtCustomFields.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(1, 416)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 16)
        Me.Label7.TabIndex = 1013
        Me.Label7.Text = "Remarks"
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
        Me.TxtCostCenter.Location = New System.Drawing.Point(586, 220)
        Me.TxtCostCenter.MaxLength = 0
        Me.TxtCostCenter.Name = "TxtCostCenter"
        Me.TxtCostCenter.Size = New System.Drawing.Size(132, 18)
        Me.TxtCostCenter.TabIndex = 3007
        Me.TxtCostCenter.Text = "TxtCostCenter"
        Me.TxtCostCenter.Visible = False
        '
        'LblTableReq
        '
        Me.LblTableReq.AutoSize = True
        Me.LblTableReq.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.LblTableReq.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.LblTableReq.Location = New System.Drawing.Point(108, 62)
        Me.LblTableReq.Name = "LblTableReq"
        Me.LblTableReq.Size = New System.Drawing.Size(10, 7)
        Me.LblTableReq.TabIndex = 3006
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
        Me.TxtJobcard.Location = New System.Drawing.Point(125, 56)
        Me.TxtJobcard.MaxLength = 0
        Me.TxtJobcard.Name = "TxtJobcard"
        Me.TxtJobcard.Size = New System.Drawing.Size(93, 18)
        Me.TxtJobcard.TabIndex = 4
        '
        'LblTable
        '
        Me.LblTable.AutoSize = True
        Me.LblTable.BackColor = System.Drawing.Color.Transparent
        Me.LblTable.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTable.Location = New System.Drawing.Point(5, 57)
        Me.LblTable.Name = "LblTable"
        Me.LblTable.Size = New System.Drawing.Size(83, 16)
        Me.LblTable.TabIndex = 3005
        Me.LblTable.Text = "Job Card No."
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
        Me.TxtModel.Location = New System.Drawing.Point(612, 15)
        Me.TxtModel.MaxLength = 0
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(124, 18)
        Me.TxtModel.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(554, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(43, 16)
        Me.Label9.TabIndex = 3011
        Me.Label9.Text = "Model"
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
        Me.TxtVehicleNo.Location = New System.Drawing.Point(354, 56)
        Me.TxtVehicleNo.MaxLength = 0
        Me.TxtVehicleNo.Name = "TxtVehicleNo"
        Me.TxtVehicleNo.Size = New System.Drawing.Size(194, 18)
        Me.TxtVehicleNo.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(255, 56)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(75, 16)
        Me.Label10.TabIndex = 3010
        Me.Label10.Text = "Vehicle No."
        '
        'LblHelp
        '
        Me.LblHelp.AutoSize = True
        Me.LblHelp.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblHelp.Location = New System.Drawing.Point(241, 150)
        Me.LblHelp.Name = "LblHelp"
        Me.LblHelp.Size = New System.Drawing.Size(147, 16)
        Me.LblHelp.TabIndex = 3008
        Me.LblHelp.Text = "P -Parts  L - Labour"
        Me.LblHelp.Visible = False
        '
        'TxtServiceTaxOnModelYN
        '
        Me.TxtServiceTaxOnModelYN.AgAllowUserToEnableMasterHelp = False
        Me.TxtServiceTaxOnModelYN.AgLastValueTag = Nothing
        Me.TxtServiceTaxOnModelYN.AgLastValueText = Nothing
        Me.TxtServiceTaxOnModelYN.AgMandatory = True
        Me.TxtServiceTaxOnModelYN.AgMasterHelp = False
        Me.TxtServiceTaxOnModelYN.AgNumberLeftPlaces = 8
        Me.TxtServiceTaxOnModelYN.AgNumberNegetiveAllow = False
        Me.TxtServiceTaxOnModelYN.AgNumberRightPlaces = 2
        Me.TxtServiceTaxOnModelYN.AgPickFromLastValue = False
        Me.TxtServiceTaxOnModelYN.AgRowFilter = ""
        Me.TxtServiceTaxOnModelYN.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtServiceTaxOnModelYN.AgSelectedValue = Nothing
        Me.TxtServiceTaxOnModelYN.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtServiceTaxOnModelYN.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtServiceTaxOnModelYN.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtServiceTaxOnModelYN.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtServiceTaxOnModelYN.Location = New System.Drawing.Point(354, 76)
        Me.TxtServiceTaxOnModelYN.MaxLength = 0
        Me.TxtServiceTaxOnModelYN.Name = "TxtServiceTaxOnModelYN"
        Me.TxtServiceTaxOnModelYN.Size = New System.Drawing.Size(154, 18)
        Me.TxtServiceTaxOnModelYN.TabIndex = 3013
        Me.TxtServiceTaxOnModelYN.Text = "TxtServiceTaxOnModelYN"
        Me.TxtServiceTaxOnModelYN.Visible = False
        '
        'BtnFillSaleOrder
        '
        Me.BtnFillSaleOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillSaleOrder.Font = New System.Drawing.Font("Lucida Console", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillSaleOrder.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnFillSaleOrder.Location = New System.Drawing.Point(220, 56)
        Me.BtnFillSaleOrder.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFillSaleOrder.Name = "BtnFillSaleOrder"
        Me.BtnFillSaleOrder.Size = New System.Drawing.Size(29, 18)
        Me.BtnFillSaleOrder.TabIndex = 5
        Me.BtnFillSaleOrder.Text = "..."
        Me.BtnFillSaleOrder.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnFillSaleOrder.UseVisualStyleBackColor = True
        '
        'FrmJobEstimateApproved
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 622)
        Me.Controls.Add(Me.LblHelp)
        Me.Controls.Add(Me.TxtCustomFields)
        Me.Controls.Add(Me.PnlCustomGrid)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Name = "FrmJobEstimateApproved"
        Me.Text = "Sale Invoice"
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.PnlCustomGrid, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomFields, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
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
    Protected WithEvents LblBuyer As System.Windows.Forms.Label
    Protected WithEvents TxtSaleToParty As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtNature As AgControls.AgTextBox
    Protected WithEvents BtnFillPartyDetail As System.Windows.Forms.Button
    Protected WithEvents PnlCustomGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtCustomFields As AgControls.AgTextBox
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TxtCostCenter As AgControls.AgTextBox
    Protected WithEvents LblTableReq As System.Windows.Forms.Label
    Protected WithEvents TxtJobcard As AgControls.AgTextBox
    Protected WithEvents LblTable As System.Windows.Forms.Label
    Protected WithEvents TxtModel As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleNo As AgControls.AgTextBox
    Protected WithEvents Label10 As System.Windows.Forms.Label
    Protected WithEvents LblHelp As System.Windows.Forms.Label
#End Region

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "SaleQuotation"
        LogTableName = "SaleQuotation_Log"
        MainLineTableCsv = "SaleQuotationDetail"
        LogLineTableCsv = "SaleQuotationDetail_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)

        AgCalcGrid1.AgLibVar = AgL
        AgCalcGrid1.Visible = False

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
                " From SaleQuotation H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where 1=1  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " And H.Div_Code = '" & AgL.PubDivCode & "'"
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, Vt.Description AS [Invoice_Type], H.V_Date AS Date, " & _
                            " H.ReferenceNo AS [Manual_No], H.SalesTaxGroupParty AS [Sales_Tax_Group_Party], " & _
                            " H.Remarks, H.TotalQty AS [Total_Qty], H.TotalAmount AS [Total_Amount],  " & _
                            " H.EntryBy AS [Entry_By], H.EntryDate AS [Entry_Date], H.EntryType AS [Entry_Type] " & _
                            " FROM SaleQuotation H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " Where 1=1 " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1ItemType, 50, 0, Col1ItemType, True, True)
            .AddAgTextColumn(Dgl1, Col1ItemCode, 80, 0, Col1ItemCode, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ItemCode")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1Item, 130, 0, Col1Item, True, False)


            .AddAgTextColumn(Dgl1, Col1SaleQuotation, 130, 0, Col1SaleQuotation, True, True)
            .AddAgTextColumn(Dgl1, Col1SaleQuotationSr, 40, 5, Col1SaleQuotationSr, False, True, False)

            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 100, 0, Col1SalesTaxGroup, False, False)
            .AddAgTextColumn(Dgl1, Col1QtyDecimalPlaces, 50, 0, Col1QtyDecimalPlaces, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1Qty, 80, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, True, True, True)
            .AddAgTextColumn(Dgl1, Col1Remark, 150, 255, Col1Remark, True, False)
            .AddAgTextColumn(Dgl1, Col1ServiceTaxOnModelYN, 50, 0, Col1ServiceTaxOnModelYN, False, True)
            .AddAgTextColumn(Dgl1, Col1ServiceTaxYN, 50, 0, Col1ServiceTaxYN, False, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35

        AgCalcGrid1.Ini_Grid(EntryNCat, TxtV_Date.Text)

        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index
        AgCalcGrid1.AgPostingPartyAc = TxtSaleToParty.AgSelectedValue

        AgCustomGrid1.Ini_Grid(mSearchCode)
        AgCustomGrid1.SplitGrid = False

        Dgl1.AgSkipReadOnlyColumns = True

        Dgl1.AllowUserToOrderColumns = True

        Dgl1.AgAllowFind = False

        Try
            Dgl1.Item(Col1ServiceTaxOnModelYN, 0).Value = TxtServiceTaxOnModelYN.Text
            Dgl1.Item(Col1ItemType, 0).Value = ClsMain.ItemType.Parts
        Catch ex As Exception
        End Try

        AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        AgCL.GridSetiingShowXml(Me.Text & AgCalcGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCalcGrid1)
        AgCL.GridSetiingShowXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim bSelectionQry$ = "", bInvoiceType$ = ""
        Dim mSaleQuotation$ = ""
        Dim mSaleQuotationSr As Integer = 0

        mQry = " Update SaleQuotation " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " SaleToParty = " & AgL.Chk_Text(TxtSaleToParty.Tag) & ", " & _
                " SaleToPartyName = '" & BtnFillPartyDetail.Tag.TxtSaleToPartyName.Text & "', " & _
                " SaleToPartyAdd1 = '" & BtnFillPartyDetail.Tag.TxtSaleToPartyAdd1.Text & "', " & _
                " SaleToPartyAdd2 = '" & BtnFillPartyDetail.Tag.TxtSaleToPartyAdd2.Text & "', " & _
                " SaleToPartyCity = '" & BtnFillPartyDetail.Tag.TxtSaleToPartyCity.AgSelectedValue & "', " & _
                " SaleToPartyMobile = '" & BtnFillPartyDetail.Tag.TxtSaleToPartyMobile.Text & "', " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.Text) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.Tag) & ", " & _
                " Service_JobCard = " & AgL.Chk_Text(TxtJobcard.Tag) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " CustomFields = " & AgL.Chk_Text(TxtCustomFields.Tag) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                " " & AgCalcGrid1.FFooterTableUpdateStr() & " " & _
                " " & AgCustomGrid1.FFooterTableUpdateStr() & " " & _
                " Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mSr = AgL.VNull(AgL.Dman_Execute("Select Max(Sr) From SaleQuotationDetail With (NoLock) Where DocID = '" & mSearchCode & "'", AgL.GcnRead).ExecuteScalar)

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                If Dgl1.Item(ColSNo, I).Tag Is Nothing And Dgl1.Rows(I).Visible = True Then
                    mSr += 1

                    If Dgl1.Item(Col1SaleQuotation, I).Value <> "" Then
                        mSaleQuotation = Dgl1.Item(Col1SaleQuotation, I).Tag
                        mSaleQuotationSr = Dgl1.Item(Col1SaleQuotationSr, I).Value
                    Else
                        mSaleQuotation = mSearchCode
                        mSaleQuotationSr = mSr
                    End If

                    If bSelectionQry <> "" Then bSelectionQry += " UNION ALL "
                    bSelectionQry += " Select " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Item, I).Tag) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1SalesTaxGroup, I).Tag) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1ServiceTaxOnModelYN, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1ServiceTaxYN, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(mSaleQuotation) & ", " & _
                                        " " & Val(mSaleQuotationSr) & ", " & _
                                        " " & AgCalcGrid1.FLineTableFieldValuesStr(I) & " "
                Else
                    If Dgl1.Rows(I).Visible = True Then
                        mQry = " UPDATE SaleQuotationDetail " & _
                                    " SET " & _
                                    " Item = " & AgL.Chk_Text(Dgl1.Item(Col1Item, I).Tag) & ", " & _
                                    " SalesTaxGroupItem = " & AgL.Chk_Text(Dgl1.Item(Col1SalesTaxGroup, I).Value) & ", " & _
                                    " Qty = " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                                    " Unit = " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                                    " Rate = " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                                    " Amount = " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                                    " Remark = " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                                    " SaleQuotation = " & AgL.Chk_Text(mSaleQuotation) & ", " & _
                                    " SaleQuotationSr = " & Val(mSaleQuotationSr) & ", " & _
                                    " ServiceTaxOnModelYN = " & AgL.Chk_Text(Dgl1.Item(Col1ServiceTaxOnModelYN, I).Value) & ", " & _
                                    " ServiceTaxYN = " & AgL.Chk_Text(Dgl1.Item(Col1ServiceTaxYN, I).Value) & ", " & _
                                    " " & AgCalcGrid1.FLineTableUpdateStr(I) & " " & _
                                    " Where DocId = '" & mSearchCode & "' " & _
                                    " And Sr = " & Dgl1.Item(ColSNo, I).Tag & " "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    Else
                        mQry = " Delete From SaleQuotationDetail Where DocId = '" & mSearchCode & "' And Sr = " & Val(Dgl1.Item(ColSNo, I).Tag) & "  "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            End If
        Next

        If bSelectionQry <> "" Then
            mQry = "Insert Into SaleQuotationDetail(DocId, Sr, Item, SalesTaxGroupItem, " & _
                    " Qty, Unit, Rate, Amount, Remark, ServiceTaxOnModelYN, ServiceTaxYN, SaleQuotation, SaleQuotationSr, " & AgCalcGrid1.FLineTableFieldNameStr() & ") " + bSelectionQry
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
            AgCL.GridSetiingWriteXml(Me.Text & AgCalcGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCalcGrid1)
            AgCL.GridSetiingWriteXml(Me.Text & AgCustomGrid1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, AgCustomGrid1)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        mQry = " Select H.*, SaleToPartyName, JC.ManualRefNo as JobCardNo, JC.CostCenter, " & _
               " IU.Item_UID, I.Description as Model_Name  " & _
               " From (Select * From SaleQuotation With (NoLock) Where DocID='" & SearchCode & "') H " & _
               " Left Join Service_JobCard JC On H.Service_JobCard = JC.DocID " & _
               " Left Join Item_UID IU On JC.Item_UID = IU.Code " & _
               " Left Join Item I On IU.Item = I.Code "
        DsTemp = AgL.FillData(mQry, AgL.GCn)


        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.Tag = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.Tag

                If AgL.XNull(.Rows(0)("CustomFields")) <> "" Then
                    TxtCustomFields.AgSelectedValue = AgL.XNull(.Rows(0)("CustomFields"))
                End If
                AgCustomGrid1.FrmType = Me.FrmType
                AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtSaleToParty.Tag = AgL.XNull(.Rows(0)("SaleToParty"))
                TxtSaleToParty.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))

                TxtJobcard.Tag = AgL.XNull(.Rows(0)("Service_JobCard"))
                TxtJobcard.Text = AgL.XNull(.Rows(0)("JobCardNo"))

                TxtCostCenter.Text = AgL.XNull(.Rows(0)("CostCenter"))
                TxtModel.Text = AgL.XNull(.Rows(0)("Model_Name"))
                TxtVehicleNo.Text = AgL.XNull(.Rows(0)("Item_UID"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                TxtSalesTaxGroupParty.Tag = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtSalesTaxGroupParty.Text = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("TotalAmount"))

                Dim FrmObj As New FrmSaleInvoicePartyDetail
                FrmObj.TxtSaleToPartyMobile.Text = AgL.XNull(.Rows(0)("SaleToPartyMobile"))
                FrmObj.TxtSaleToPartyName.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                FrmObj.TxtSaleToPartyAdd1.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd1"))
                FrmObj.TxtSaleToPartyAdd2.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd2"))
                FrmObj.TxtSaleToPartyCity.Tag = AgL.XNull(.Rows(0)("SaleToPartyCity"))
                FrmObj.TxtSaleToPartyCity.Text = AgL.XNull(.Rows(0)("SaleToPartyCityName"))

                BtnFillPartyDetail.Tag = FrmObj

                AgCalcGrid1.FMoveRecFooterTable(DsTemp.Tables(0), EntryNCat, TxtV_Date.Text)

                AgCustomGrid1.FMoveRecFooterTable(DsTemp.Tables(0))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                mQry = "Select L.*, I.Description As ItemDesc, I.ManualCode, " & _
                        " U.DecimalPlaces As QtyDecimalPlaces, I.ItemType, Q.V_Type + '-' + Q.ReferenceNo As SaleQuotationNo " & _
                        " From (Select * From SaleQuotationDetail With (NoLock) Where DocId = '" & SearchCode & "') As L " & _
                        " LEFT JOIN Item I With (NoLock) ON L.Item = I.Code " & _
                        " Left Join Unit U On L.Unit = U.Code " & _
                        " LEFT JOIN SaleQuotation Q On L.SaleQuotation = Q.DocId " & _
                        " Order By L.Sr "
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1

                            Dgl1.Item(ColSNo, I).Tag = AgL.XNull(.Rows(I)("Sr"))


                            Dgl1.Item(Col1ItemType, I).Value = AgL.XNull(.Rows(I)("ItemType"))

                            Dgl1.Item(Col1ItemCode, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1ItemCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                            Dgl1.Item(Col1Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Item, I).Value = AgL.XNull(.Rows(I)("ItemDesc"))

                            Dgl1.Item(Col1SalesTaxGroup, I).Tag = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1SalesTaxGroup, I).Value = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))

                            Dgl1.Item(Col1QtyDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("QtyDecimalPlaces"))

                            Dgl1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))

                            Dgl1.Item(Col1SaleQuotation, I).Tag = AgL.XNull(.Rows(I)("SaleQuotation"))
                            Dgl1.Item(Col1SaleQuotation, I).Value = AgL.XNull(.Rows(I)("SaleQuotationNo"))
                            Dgl1.Item(Col1SaleQuotationSr, I).Value = AgL.XNull(.Rows(I)("SaleQuotationSr"))

                            Dgl1.Item(Col1ServiceTaxOnModelYN, I).Value = AgL.XNull(.Rows(I)("ServiceTaxOnModelYN"))
                            Dgl1.Item(Col1ServiceTaxYN, I).Value = AgL.XNull(.Rows(I)("ServiceTaxYN"))

                            Call AgCalcGrid1.FMoveRecLineTable(DsTemp.Tables(0), I)
                        Next I
                    End If
                End With
                If AgCustomGrid1.Rows.Count = 0 Then AgCustomGrid1.Visible = False
            End If
        End With
    End Sub

    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
        AgCustomGrid1.FrmType = Me.FrmType
        AgL.WinSetting(Me, 654, 990, 0, 0)
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtSaleToParty.Validating, TxtSalesTaxGroupParty.Validating, TxtReferenceNo.Validating, TxtJobcard.Validating
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim FrmObj As New FrmSaleInvoicePartyDetail
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue

                    TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)
                    AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

                    IniGrid()
                    TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "SaleQuotation", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtReferenceNo.Name
                    e.Cancel = Not AgTemplate.ClsMain.FCheckDuplicateRefNo("ReferenceNo", "SaleQuotation", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtReferenceNo.Text, mSearchCode)

                Case TxtJobcard.Name
                    If sender.AgDataRow IsNot Nothing Then
                        mQry = " SELECT H.OwnerMobile AS SaleToPartyMobile, H.OwnerName AS SaleToPartyName, " & _
                                " IsNull(H.OwnerAdd1,'') AS SaleToPartyAdd1, " & _
                                " IsNull(H.OwnerAdd2,'') AS SaleToPartyAdd2, " & _
                                " H.OwnerCity AS SaleToPartyCity, C.CityName As SaleToPartyCityName, " & _
                                " H.CostCenter, IU.Item_UID, I.Description as Model_Name, " & _
                                " IsNull(I.ServiceTaxYN,'N') As ServiceTaxOnModelYN " & _
                                " FROM Service_JobCard H  " & _
                                " Left Join Item_UID IU On H.Item_UID = IU.Code " & _
                                " Left Join Item I On IU.Item = I.Code " & _
                                " LEFT JOIN City C ON H.OwnerCity = C.CityCode  " & _
                                " WHERE H.DocID = '" & TxtJobcard.Tag & "' "
                        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                        With DtTemp
                            FrmObj.TxtSaleToPartyMobile.Text = AgL.XNull(.Rows(0)("SaleToPartyMobile"))
                            FrmObj.TxtSaleToPartyName.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                            FrmObj.TxtSaleToPartyAdd1.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd1"))
                            FrmObj.TxtSaleToPartyAdd2.Text = AgL.XNull(.Rows(0)("SaleToPartyAdd2"))
                            FrmObj.TxtSaleToPartyCity.Tag = AgL.XNull(.Rows(0)("SaleToPartyCity"))
                            FrmObj.TxtSaleToPartyCity.Text = AgL.XNull(.Rows(0)("SaleToPartyCityName"))

                            TxtSaleToParty.Text = AgL.XNull(.Rows(0)("SaleToPartyName"))
                            TxtVehicleNo.Text = AgL.XNull(.Rows(0)("Item_UID"))
                            TxtModel.Text = AgL.XNull(.Rows(0)("Model_Name"))
                            TxtCostCenter.Text = AgL.XNull(.Rows(0)("CostCenter"))
                            TxtServiceTaxOnModelYN.Text = AgL.XNull(.Rows(0)("ServiceTaxOnModelYN"))

                            Dim I As Integer = 0
                            For I = 0 To Dgl1.Rows.Count - 1
                                Dgl1.Item(Col1ServiceTaxOnModelYN, I).Value = TxtServiceTaxOnModelYN.Text
                            Next
                        End With
                        BtnFillPartyDetail.Tag = FrmObj
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        AgCalcGrid1.AgNCat = EntryNCat

        TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GCn)
        AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtSalesTaxGroupParty.Tag = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        TxtSalesTaxGroupParty.Text = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        AgCalcGrid1.AgPostingGroupSalesTaxItem = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))

        If TxtJobcard.AgHelpDataSet IsNot Nothing Then TxtJobcard.AgHelpDataSet.Dispose() : TxtJobcard.AgHelpDataSet = Nothing

        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "SaleQuotation", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
        TxtJobcard.Focus()
    End Sub

    Private Sub Validating_ItemCode(ByVal mColumn As Integer, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing
        Try
            If Dgl1.Item(mColumn, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(mColumn, mRow).ToString.Trim = "" Then
                Dgl1.Item(Col1Unit, mRow).Value = ""
            Else
                If Dgl1.AgDataRow IsNot Nothing Then
                    Dgl1.Item(Col1Item, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value)
                    Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Item_Name").Value)
                    Dgl1.Item(Col1ItemCode, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value)
                    Dgl1.Item(Col1ItemCode, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Item_No").Value)
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1QtyDecimalPlaces, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("QtyDecimalPlaces").Value)
                    Dgl1.Item(Col1Qty, mRow).Value = 1

                    Dgl1.Item(Col1ServiceTaxYN, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("ServiceTaxYN").Value)

                    Dgl1.Item(Col1SalesTaxGroup, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                    If AgL.StrCmp(Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow), "") Then
                        Dgl1.Item(Col1SalesTaxGroup, mRow).Tag = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Rate").Value)
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
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
                Case Col1Item
                    Validating_ItemCode(mColumnIndex, mRowIndex)

                Case Col1ItemCode
                    Validating_ItemCode(mColumnIndex, mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)

        Try
            Dgl1.Item(Col1ServiceTaxOnModelYN, e.RowIndex).Value = TxtServiceTaxOnModelYN.Text
        Catch ex As Exception
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        If Topctrl1.Mode = "Browse" Then Exit Sub

        LblTotalQty.Text = 0
        LblTotalAmount.Text = 0

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1Rate, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))

                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.AgVoucherCategory = "PURCH"
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        AgCalcGrid1.AgPostingGroupSalesTaxItem = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
        AgCalcGrid1.Calculation()
        LblTotalQty.Text = Val(LblTotalQty.Text)
        LblTotalAmount.Text = Val(LblTotalAmount.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        Dim bQcPassedQty As Double = 0, bInvoicedQty As Double = 0
        Dim bOrderQty As Double = 0, bInvoiceQty As Double = 0
        If AgL.RequiredField(TxtJobcard, LblTable.Text) Then passed = False : Exit Sub

        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1Qty, I).Value) = 0 Then
                        MsgBox("Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1Qty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If
                End If
            Next
        End With

        passed = AgTemplate.ClsMain.FCheckDuplicateRefNo("ReferenceNo", "SaleChallan", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtReferenceNo.Text, mSearchCode)

    End Sub

    Private Sub TxtBuyer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtSaleToParty.KeyDown, TxtSalesTaxGroupParty.KeyDown, TxtJobcard.KeyDown
        Try
            If e.KeyCode = Keys.Enter Then Exit Sub
            Select Case sender.name
                Case TxtSalesTaxGroupParty.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = "SELECT Description AS Code, Description FROM PostingGroupSalesTaxParty Where IsNull(Active,0)=1 "
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

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
                                    " AND Convert(DATE,H.V_Date) <= '" & TxtV_Date.Text & "' " & _
                                    " And H.DocId Not In (Select Service_JobCard From SaleQuotation Q LEFT JOIN Voucher_Type Vt On Q.V_Type = Vt.V_Type Where DocId <> '" & mSearchCode & "' And Vt.NCat = '" & LblV_Type.Tag & "') " & _
                                    " Order By H.V_Date, H.ManualRefNo "
                            sender.AgHelpDataset(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Qty
                    CType(Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex), AgControls.AgTextColumn).AgNumberRightPlaces = Val(Dgl1.Item(Col1QtyDecimalPlaces, Dgl1.CurrentCell.RowIndex).Value)
                    LblHelp.Visible = False

                Case Col1Item
                    Try
                        If Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value = "" Then Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value = Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex - 1).Value
                        LblHelp.Visible = False
                        If Dgl1.AgHelpDataSet(Col1ItemCode) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1ItemCode).Dispose() : Dgl1.AgHelpDataSet(Col1ItemCode) = Nothing
                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Item).Dispose() : Dgl1.AgHelpDataSet(Col1Item) = Nothing
                    Catch ex As Exception
                    End Try

                Case Col1ItemType
                    LblHelp.Visible = True

                Case Else
                    LblHelp.Visible = False
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If Dgl1.CurrentCell IsNot Nothing Then
            If Dgl1.Rows(Dgl1.CurrentCell.RowIndex).DefaultCellStyle.BackColor = RowLockedColour Then
                If e.Control And e.KeyCode = Keys.D Then
                    sender.CurrentRow.Selected = True
                    sender.CurrentRow.Visible = False
                End If
            End If
        End If
        If e.Control Or e.Shift Or e.Alt Then Exit Sub

        If Dgl1.CurrentCell IsNot Nothing Then
            If e.KeyCode = Keys.P Or e.KeyCode = Keys.L Then
                If Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name = Col1ItemType Then
                    If Dgl1.Item(Col1Item, Dgl1.CurrentCell.RowIndex).Value = "" Then
                        If e.KeyCode = Keys.P Then
                            Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value = ClsMain.ItemType.Parts
                        ElseIf e.KeyCode = Keys.L Then
                            Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value = ClsMain.ItemType.Labour
                        End If
                        Dgl1.Item(Col1Item, Dgl1.CurrentCell.RowIndex).Tag = ""
                        Dgl1.Item(Col1Item, Dgl1.CurrentCell.RowIndex).Value = ""
                        Dgl1.AgHelpDataSet(Col1Item) = Nothing
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmSaleQuotation_BaseEvent_Topctrl_tbRef() Handles Me.BaseEvent_Topctrl_tbRef
        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Item).Dispose() : Dgl1.AgHelpDataSet(Col1Item) = Nothing
        If TxtJobcard.AgHelpDataSet IsNot Nothing Then TxtJobcard.AgHelpDataSet.Dispose() : TxtJobcard.AgHelpDataSet = Nothing
        If TxtSaleToParty.AgHelpDataSet IsNot Nothing Then TxtSaleToParty.AgHelpDataSet.Dispose() : TxtSaleToParty.AgHelpDataSet = Nothing
        If TxtSalesTaxGroupParty.AgHelpDataSet IsNot Nothing Then TxtSalesTaxGroupParty.AgHelpDataSet.Dispose() : TxtSalesTaxGroupParty.AgHelpDataSet = Nothing
    End Sub

    Private Sub BtnFillPartyDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillPartyDetail.Click
        FOpenPartyDetail()
    End Sub

    Private Sub FOpenPartyDetail()
        Dim FrmObj As FrmSaleInvoicePartyDetail
        Try
            If BtnFillPartyDetail.Tag Is Nothing Then
                FrmObj = New FrmSaleInvoicePartyDetail
            Else
                FrmObj = BtnFillPartyDetail.Tag
            End If
            FrmObj.DispText(IIf(Topctrl1.Mode = "Browse", False, True))
            FrmObj.ShowDialog()
            If FrmObj.mOkButtonPressed Then BtnFillPartyDetail.Tag = FrmObj
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.EditingControl_KeyDown
        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1ItemCode
                    If e.KeyCode <> Keys.Enter Then
                        If Dgl1.AgHelpDataSet(Col1ItemCode) Is Nothing Then
                            FCreateHelpItem()
                        End If
                    End If

                Case Col1Item
                    If e.KeyCode <> Keys.Enter Then
                        If Dgl1.AgHelpDataSet(Col1Item) Is Nothing Then
                            FCreateHelpItem()
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
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
                        " H.Rate, U.DecimalPlaces as QtyDecimalPlaces, H.SalesTaxPostingGroup, IsNull(H.ServiceTaxYN,'N') As ServiceTaxYN " & _
                        " FROM Item H " & _
                        " Left Join Unit U On H.Unit = U.Code " & _
                        " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And H.ItemType = '" & Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value & "'" & strCond
                Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex, 1) = AgL.FillData(mQry, AgL.GCn)

            Case Col1ItemCode
                mQry = "SELECT H.Code, H.ManualCode as Item_No, H.Description as Item_Name, H.Unit, " & _
                        " H.Rate, U.DecimalPlaces as QtyDecimalPlaces, H.SalesTaxPostingGroup, IsNull(H.ServiceTaxYN,'N') As ServiceTaxYN " & _
                        " FROM Item H " & _
                        " Left Join Unit U On H.Unit = U.Code " & _
                        " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                        " And H.ItemType = '" & Dgl1.Item(Col1ItemType, Dgl1.CurrentCell.RowIndex).Value & "'" & strCond
                Dgl1.AgHelpDataSet(Dgl1.CurrentCell.ColumnIndex, 1) = AgL.FillData(mQry, AgL.GCn)
        End Select
    End Sub

    Private Sub FrmSaleQuotation_BaseFunction_DispText() Handles Me.BaseFunction_DispText
        TxtSaleToParty.Enabled = False
        TxtModel.Enabled = False
        TxtVehicleNo.Enabled = False
    End Sub

    Private Sub FrmPurchInvoice_StoreItem_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        FPrintDocument()
    End Sub

    Private Sub FPrintDocument()
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0
        Try
            mQry = "SELECT H.DocID, H.V_Date, H.ReferenceNo, H.SaleToParty,  " & _
                        " H.SaleToPartyName, H.SaleToPartyAdd1, H.SaleToPartyAdd2, H.SaleToPartyCity,  " & _
                        " H.SaleToPartyMobile, H.SalesTaxGroupParty, H.PartyDocNo,  " & _
                        " H.PartyDocDate, H.TotalDeliveryMeasure, H.SaleToPartyCityName, " & _
                        " L.DocId, L.Sr, L.Vendor, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit,  " & _
                        " L.TotalMeasure, L.Rate, L.Amount, L.NetAmount, L.PostingGroupSalesTaxItem, L.OrdQty,  " & _
                        " L.OrdMeasure, L.DispatchQty, L.DispatchMeasure, L.UID, L.Remarks, L.SaleEnquiry,  " & _
                        " L.Supplier, L.Specification, L.DeliveryMeasure, L.SalesTaxGroupItem,  " & _
                        " L.DeliveryMeasureMultiplier, L.TotalDeliveryMeasure, L.BillingType, L.RateType, L.SaleQuotation,  " & _
                        " L.SaleQuotationSr, L.Remark, L.ServiceTaxYN, L.ServiceTaxOnModelYN, " & _
                        " I.Description AS ItemDesc, I.ManualCode As ItemManualCode, " & _
                        " J.CustomerId, J.OwnerName, J.OwnerAdd1, J.OwnerAdd2, J.OwnerCity, J.OwnerMobile, C.CityName As OwnerCityName, " & _
                        " Sg1.Name As SoldByName, J.SoldDate, J.ServiceAdvisorMobile, J.KeyNo, J.VehicleUserName, J.Milage, " & _
                        " J.V_Date As JobCardDate, J.ManualRefNo As JobCardNo, Iu.RegistrationNo, J.Milage, " & _
                        " Iu.ChassisNo, Iu.EngineNo, Model.Description As ModelDesc, Sg2.DispName As ServiceAdvisorName, " & _
                        " T.Description As Service_TypeDesc, I.ItemType, " & _
                        " Case When I.ItemType = '" & ClsMain.ItemType.Parts & "' Then L.Amount End As PartAmount, " & _
                        " Case When I.ItemType = '" & ClsMain.ItemType.Labour & "' Then L.Amount End As LabourCharge, " & _
                        " Insurance.DispName As InsuranceCompanyName, J.PolicyNo, " & _
                        " " & AgCalcGrid1.FLineTableFieldNameStr("H.", "H_") & ", " & _
                        " " & AgCalcGrid1.FLineTableFieldNameStr("L.", "L_") & " " & _
                        " " & AgCustomGrid1.FHeaderTableFieldNameStr("H.", "H_") & " " & _
                        " FROM SaleQuotation H " & _
                        " LEFT JOIN SaleQuotationDetail L ON H.DocID = L.DocId " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN Service_JobCard J On H.Service_JobCard = J.DocId " & _
                        " LEFT JOIN City C On J.OwnerCity = C.CityCode " & _
                        " LEFT JOIN SubGroup Sg1 On J.SoldBy = Sg1.SubCode " & _
                        " LEFT JOIN Item_Uid Iu On J.Item_Uid = Iu.Code " & _
                        " LEFT JOIN Item Model ON Iu.Item = Model.Code " & _
                        " LEFT JOIN SubGroup Sg2 ON J.ServiceAdvisor = Sg2.SubCode " & _
                        " LEFT JOIN SubGroup Insurance On J.InsuranceCompany = Insurance.SubCode " & _
                        " LEFT JOIN Service_Type T On J.Service_Type = T.Code " & _
                        " WHERE H.DocID = '" & mSearchCode & "'"
            ClsMain.FPrintThisDocument(Me, TxtV_Type.Tag, mQry, "ServiceQuotation_Print", "Service Quotation")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub BtnFillSaleChallan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillSaleOrder.Click
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Dim StrTicked As String

            StrTicked = FHPGD_PendingJobEstimate()
            If StrTicked <> "" Then
                FFillItemsForEstimate(StrTicked)
            Else
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            End If
            Dgl1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FHPGD_PendingJobEstimate() As String
        Dim FRH_Multiple As DMHelpGrid.FrmHelpGrid_Multi
        Dim StrRtn As String = ""

        mQry = " SELECT 'o' As Tick, H.DocId, H.ReferenceNo As EstimateNo , " & _
                " H.V_Date AS EstimateDate  " & _
                " FROM SaleQuotation H With (nolock)   " & _
                " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                " WHERE H.Service_JobCard = '" & TxtJobcard.Tag & "'   " & _
                " ANd H.DocId Not In (Select Distinct SaleQuotation From SaleQuotation Q " & _
                "                     LEFT JOIN SaleQuotationDetail Qd On Q.DocId = Qd.DocId " & _
                "                     LEFT JOIN Voucher_Type V On Q.V_Type = V.V_Type " & _
                "                     Where V.NCat = '" & LblV_Type.Tag & "' " & _
                "                     And Q.DocId <> '" & mSearchCode & "' )" & _
                " And H.Div_Code = '" & TxtDivision.Tag & "'   " & _
                " AND H.Site_Code = '" & TxtSite_Code.Tag & "'   " & _
                " AND H.V_Date <= '" & TxtV_Date.Text & "'  " & _
                " And Vt.NCat = '" & ClsMain.Temp_NCat.ServiceQuotation & "'"

        FRH_Multiple = New DMHelpGrid.FrmHelpGrid_Multi(New DataView(AgL.FillData(mQry, AgL.GCn).TABLES(0)), "", 300, 600, , , False)
        FRH_Multiple.FFormatColumn(0, "Tick", 40, DataGridViewContentAlignment.MiddleCenter, True)
        FRH_Multiple.FFormatColumn(1, , 0, , False)
        FRH_Multiple.FFormatColumn(2, "Estimate No.", 100, DataGridViewContentAlignment.MiddleLeft)
        FRH_Multiple.FFormatColumn(3, "Estimate Date", 100, DataGridViewContentAlignment.MiddleLeft)

        FRH_Multiple.StartPosition = FormStartPosition.CenterScreen
        FRH_Multiple.ShowDialog()

        If FRH_Multiple.BytBtnValue = 0 Then
            StrRtn = FRH_Multiple.FFetchData(1, "'", "'", ",", True)
        End If
        FHPGD_PendingJobEstimate = StrRtn

        FRH_Multiple = Nothing
    End Function

    Private Sub FFillItemsForEstimate(ByVal bQuotationNoStr As String)
        Dim I As Integer = 0
        Dim DsTemp As DataSet = Nothing
        Try
            mQry = "Select L.*, I.Description As ItemDesc, I.ManualCode, " & _
                    " U.DecimalPlaces As QtyDecimalPlaces, I.ItemType, H.V_Type + '-' + H.ReferenceNo As SaleQuotationNo " & _
                    " From SaleQuotation H " & _
                    " LEFT JOIN SaleQuotationDetail  L On H.DocId = L.DocId  " & _
                    " LEFT JOIN Item I With (NoLock) ON L.Item = I.Code " & _
                    " Left Join Unit U On L.Unit = U.Code " & _
                    " Where H.DocId In (" & bQuotationNoStr & ") " & _
                    " Order By L.Sr "
            DsTemp = AgL.FillData(mQry, AgL.GCn)

            For I = 0 To Dgl1.Rows.Count - 1
                If Dgl1.Item(Col1Item, I).Value <> "" Then
                    Dgl1.Rows(I).Visible = False
                End If
            Next

            Dim J As Integer = Dgl1.Rows.Count - 1

            With DsTemp.Tables(0)
                'Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, J).Value = Dgl1.Rows.Count - 1

                        Dgl1.Item(Col1ItemType, J).Value = AgL.XNull(.Rows(I)("ItemType"))

                        Dgl1.Item(Col1ItemCode, J).Tag = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1ItemCode, J).Value = AgL.XNull(.Rows(I)("ManualCode"))
                        Dgl1.Item(Col1Item, J).Tag = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1Item, J).Value = AgL.XNull(.Rows(I)("ItemDesc"))

                        Dgl1.Item(Col1SalesTaxGroup, J).Tag = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1SalesTaxGroup, J).Value = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))

                        Dgl1.Item(Col1QtyDecimalPlaces, J).Value = AgL.VNull(.Rows(I)("QtyDecimalPlaces"))

                        Dgl1.Item(Col1Qty, J).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                        Dgl1.Item(Col1Unit, J).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1Rate, J).Value = AgL.VNull(.Rows(I)("Rate"))
                        Dgl1.Item(Col1Amount, J).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                        Dgl1.Item(Col1Remark, J).Value = AgL.XNull(.Rows(I)("Remark"))

                        Dgl1.Item(Col1SaleQuotation, J).Tag = AgL.XNull(.Rows(I)("SaleQuotation"))
                        Dgl1.Item(Col1SaleQuotation, J).Value = AgL.XNull(.Rows(I)("SaleQuotationNo"))
                        Dgl1.Item(Col1SaleQuotationSr, J).Value = AgL.XNull(.Rows(I)("SaleQuotationSr"))

                        Dgl1.Item(Col1ServiceTaxOnModelYN, J).Value = AgL.XNull(.Rows(I)("ServiceTaxOnModelYN"))
                        Dgl1.Item(Col1ServiceTaxYN, J).Value = AgL.XNull(.Rows(I)("ServiceTaxYN"))

                        Call AgCalcGrid1.FMoveRecLineTable(DsTemp.Tables(0), I)

                        J += 1
                    Next I
                End If
            End With

            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmJobEstimateApproved_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        If TxtJobcard.AgHelpDataSet IsNot Nothing Then TxtJobcard.AgHelpDataSet.Dispose() : TxtJobcard.AgHelpDataSet = Nothing
    End Sub
End Class
