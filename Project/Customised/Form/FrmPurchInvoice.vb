Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms

Public Class FrmPurchInvoice
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public Event BaseFunction_MoveRecLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer)
    Public Event BaseEvent_Save_InTransLine(ByVal SearchCode As String, ByVal Sr As Integer, ByVal mGridRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)

    Public WithEvents AgCalcGrid1 As New AgStructure.AgCalcGrid
    Public WithEvents AgCustomGrid1 As New AgCustomFields.AgCustomGrid
    Dim RowLockedColour As Color = Color.Pink

    Public WithEvents Dgl1 As New AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1PurchChallan As String = "Challan No"
    Protected Const Col1PurchChallanSr As String = "Purch Challan Sr"
    Protected Const Col1Item_UID As String = "Item UID"
    Protected Const Col1ItemCode As String = "Item Code"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1BaleNo As String = "Bale No"
    Protected Const Col1LotNo As String = "Lot No"
    Protected Const Col1SalesTaxGroup As String = "Sales Tax Group Item"
    Protected Const Col1DocQty As String = "Doc Qty"
    Protected Const Col1FreeQty As String = "Free Qty"
    Protected Const Col1RejQty As String = "Rej Qty"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1QtyDecimalPlaces As String = "Qty Decimal Places"
    Protected Const Col1DeliveryMeasure As String = "Delivery Measure"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1PcsPerMeasure As String = "Pcs Per Measure"
    Protected Const Col1TotalDocMeasure As String = "Total Doc Measure"
    Protected Const Col1TotalFreeMeasure As String = "Total Free Measure"
    Protected Const Col1TotalRejMeasure As String = "Total Rej Measure"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1MeasureDecimalPlaces As String = "Measure Decimal Places"
    Protected Const Col1DeliveryMeasureMultiplier As String = "Delivery Measure Multiplier"
    Protected Const Col1DeliveryMeasurePerPcs As String = "Delivery Measure Per Qty"
    Protected Const Col1TotalDocDeliveryMeasure As String = "Total Doc Delivery Measure"
    Protected Const Col1TotalFreeDeliveryMeasure As String = "Total Doc Delivery Measure"
    Protected Const Col1TotalRejDeliveryMeasure As String = "Total Rej Delivery Measure"
    Protected Const Col1TotalDeliveryMeasure As String = "Total Delivery Measure"
    Protected Const Col1DeliveryMeasureDecimalPlaces As String = "Delivery Measure Decimal Places"    
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1ExpiryDate As String = "Expiry Date"
    Protected Const Col1Remark As String = "Remark"
    Protected Const Col1BillingType As String = "Billing Type"
    Protected Const Col1MRP As String = "MRP"
    Protected Const Col1Deal As String = "Deal"
    Protected Const Col1ProfitMarginPer As String = "Profit Margin %"
    Protected Const Col1PurchIndent As String = "PurchIndent"
    Protected Const Col1PurchIndentSr As String = "Purch Indent Sr"
    Protected Const Col1SaleRate As String = "Sale Rate"

    Dim IsSameUnit As Boolean = True
    Dim IsSameMeasureUnit As Boolean = True
    Dim IsSameDeliveryMeasureUnit As Boolean = True

    Dim intQtyDecimalPlaces As Integer = 0
    Dim intMeasureDecimalPlaces As Integer = 0
    Dim intDeliveryMeasureDecimalPlaces As Integer = 0

    Dim Dgl As New AgControls.AgDataGrid

    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblGodown As System.Windows.Forms.Label
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents TxtBillToParty As AgControls.AgTextBox
    Protected WithEvents LblPostToAc As System.Windows.Forms.Label
    Dim BlnIsDirectInvoice As Boolean = False
    Public blnIsCarpetTrans As Boolean

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable, ByVal strNCat As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        EntryNCat = strNCat

        mQry = "Select H.* from Voucher_Type_Settings H Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  Where Vt.NCat In ('" & EntryNCat & "') And H.Div_Code = '" & AgL.PubDivCode & "' And H.Site_Code ='" & AgL.PubSiteCode & "' "
        DtV_TypeSettings = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub

#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.Label4 = New System.Windows.Forms.Label
        Me.TxtVendor = New AgControls.AgTextBox
        Me.LblVendor = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalDeliveryMeasure = New System.Windows.Forms.Label
        Me.LblTotalDeliveryMeasureText = New System.Windows.Forms.Label
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.LblTotalMeasureText = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.LblTotalAmountText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtStructure = New AgControls.AgTextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.TxtSalesTaxGroupParty = New AgControls.AgTextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label30 = New System.Windows.Forms.Label
        Me.TxtReferenceNo = New AgControls.AgTextBox
        Me.LblReferenceNo = New System.Windows.Forms.Label
        Me.LblVendorDocNo = New System.Windows.Forms.Label
        Me.TxtVendorDocNo = New AgControls.AgTextBox
        Me.LvlVendorDocDate = New System.Windows.Forms.Label
        Me.TxtVendorDocDate = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.TxtCurrency = New AgControls.AgTextBox
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.PnlCalcGrid = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.RbtInvoiceDirect = New System.Windows.Forms.RadioButton
        Me.RbtInvoiceForChallan = New System.Windows.Forms.RadioButton
        Me.GrpDirectInvoice = New System.Windows.Forms.GroupBox
        Me.BtnFillPurchChallan = New System.Windows.Forms.Button
        Me.PnlCustomGrid = New System.Windows.Forms.Panel
        Me.TxtCustomFields = New AgControls.AgTextBox
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblGodown = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtBillToParty = New AgControls.AgTextBox
        Me.LblPostToAc = New System.Windows.Forms.Label
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
        Me.GrpDirectInvoice.SuspendLayout()
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
        Me.Label2.Location = New System.Drawing.Point(141, 39)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(40, 34)
        Me.LblV_Date.Size = New System.Drawing.Size(78, 16)
        Me.LblV_Date.Tag = ""
        Me.LblV_Date.Text = "Invoice Date"
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(356, 19)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(160, 33)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(266, 15)
        Me.LblV_Type.Size = New System.Drawing.Size(79, 16)
        Me.LblV_Type.Tag = ""
        Me.LblV_Type.Text = "Invoice Type"
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(374, 13)
        Me.TxtV_Type.Size = New System.Drawing.Size(195, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(141, 19)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(40, 14)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(160, 13)
        Me.TxtSite_Code.Size = New System.Drawing.Size(100, 18)
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
        Me.TabControl1.Size = New System.Drawing.Size(992, 125)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtSalesTaxGroupParty)
        Me.TP1.Controls.Add(Me.Label27)
        Me.TP1.Controls.Add(Me.Label5)
        Me.TP1.Controls.Add(Me.TxtBillToParty)
        Me.TP1.Controls.Add(Me.LblPostToAc)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.Label4)
        Me.TP1.Controls.Add(Me.TxtVendor)
        Me.TP1.Controls.Add(Me.LblVendor)
        Me.TP1.Controls.Add(Me.TxtVendorDocNo)
        Me.TP1.Controls.Add(Me.LblVendorDocNo)
        Me.TP1.Controls.Add(Me.TxtVendorDocDate)
        Me.TP1.Controls.Add(Me.LvlVendorDocDate)
        Me.TP1.Controls.Add(Me.Label25)
        Me.TP1.Controls.Add(Me.TxtReferenceNo)
        Me.TP1.Controls.Add(Me.TxtStructure)
        Me.TP1.Controls.Add(Me.LblReferenceNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(984, 99)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.LblReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtStructure, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtReferenceNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label25, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.LvlVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocDate, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendorDocNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblVendor, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtVendor, 0)
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
        Me.TP1.Controls.SetChildIndex(Me.LblPostToAc, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtBillToParty, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label5, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label27, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSalesTaxGroupParty, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(984, 41)
        Me.Topctrl1.TabIndex = 3
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
        Me.Label4.Location = New System.Drawing.Point(141, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 694
        Me.Label4.Text = "Ä"
        '
        'TxtVendor
        '
        Me.TxtVendor.AgAllowUserToEnableMasterHelp = False
        Me.TxtVendor.AgLastValueTag = Nothing
        Me.TxtVendor.AgLastValueText = Nothing
        Me.TxtVendor.AgMandatory = True
        Me.TxtVendor.AgMasterHelp = False
        Me.TxtVendor.AgNumberLeftPlaces = 8
        Me.TxtVendor.AgNumberNegetiveAllow = False
        Me.TxtVendor.AgNumberRightPlaces = 2
        Me.TxtVendor.AgPickFromLastValue = False
        Me.TxtVendor.AgRowFilter = ""
        Me.TxtVendor.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendor.AgSelectedValue = Nothing
        Me.TxtVendor.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendor.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendor.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendor.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendor.Location = New System.Drawing.Point(160, 53)
        Me.TxtVendor.MaxLength = 0
        Me.TxtVendor.Name = "TxtVendor"
        Me.TxtVendor.Size = New System.Drawing.Size(409, 18)
        Me.TxtVendor.TabIndex = 4
        '
        'LblVendor
        '
        Me.LblVendor.AutoSize = True
        Me.LblVendor.BackColor = System.Drawing.Color.Transparent
        Me.LblVendor.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendor.Location = New System.Drawing.Point(40, 53)
        Me.LblVendor.Name = "LblVendor"
        Me.LblVendor.Size = New System.Drawing.Size(55, 16)
        Me.LblVendor.TabIndex = 693
        Me.LblVendor.Text = "Supplier"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalDeliveryMeasure)
        Me.Panel1.Controls.Add(Me.LblTotalDeliveryMeasureText)
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.LblTotalMeasureText)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Controls.Add(Me.LblTotalAmountText)
        Me.Panel1.Location = New System.Drawing.Point(4, 386)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(975, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalDeliveryMeasure
        '
        Me.LblTotalDeliveryMeasure.AutoSize = True
        Me.LblTotalDeliveryMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDeliveryMeasure.ForeColor = System.Drawing.Color.Black
        Me.LblTotalDeliveryMeasure.Location = New System.Drawing.Point(869, 3)
        Me.LblTotalDeliveryMeasure.Name = "LblTotalDeliveryMeasure"
        Me.LblTotalDeliveryMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalDeliveryMeasure.TabIndex = 716
        Me.LblTotalDeliveryMeasure.Text = "."
        '
        'LblTotalDeliveryMeasureText
        '
        Me.LblTotalDeliveryMeasureText.AutoSize = True
        Me.LblTotalDeliveryMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalDeliveryMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalDeliveryMeasureText.Location = New System.Drawing.Point(702, 3)
        Me.LblTotalDeliveryMeasureText.Name = "LblTotalDeliveryMeasureText"
        Me.LblTotalDeliveryMeasureText.Size = New System.Drawing.Size(162, 16)
        Me.LblTotalDeliveryMeasureText.TabIndex = 715
        Me.LblTotalDeliveryMeasureText.Text = "Total Deilvery Measure :"
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(576, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 666
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalMeasureText
        '
        Me.LblTotalMeasureText.AutoSize = True
        Me.LblTotalMeasureText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasureText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalMeasureText.Location = New System.Drawing.Point(465, 3)
        Me.LblTotalMeasureText.Name = "LblTotalMeasureText"
        Me.LblTotalMeasureText.Size = New System.Drawing.Size(106, 16)
        Me.LblTotalMeasureText.TabIndex = 665
        Me.LblTotalMeasureText.Text = "Total Measure :"
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
        Me.LblTotalAmount.Location = New System.Drawing.Point(332, 4)
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
        Me.LblTotalAmountText.Location = New System.Drawing.Point(228, 3)
        Me.LblTotalAmountText.Name = "LblTotalAmountText"
        Me.LblTotalAmountText.Size = New System.Drawing.Size(101, 16)
        Me.LblTotalAmountText.TabIndex = 661
        Me.LblTotalAmountText.Text = "Total Amount :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(4, 176)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(975, 210)
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
        Me.TxtStructure.Location = New System.Drawing.Point(641, 221)
        Me.TxtStructure.MaxLength = 20
        Me.TxtStructure.Name = "TxtStructure"
        Me.TxtStructure.Size = New System.Drawing.Size(60, 18)
        Me.TxtStructure.TabIndex = 15
        Me.TxtStructure.Visible = False
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(569, 222)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(61, 16)
        Me.Label25.TabIndex = 715
        Me.Label25.Text = "Structure"
        Me.Label25.Visible = False
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
        Me.TxtSalesTaxGroupParty.Location = New System.Drawing.Point(708, 54)
        Me.TxtSalesTaxGroupParty.MaxLength = 20
        Me.TxtSalesTaxGroupParty.Name = "TxtSalesTaxGroupParty"
        Me.TxtSalesTaxGroupParty.Size = New System.Drawing.Size(188, 18)
        Me.TxtSalesTaxGroupParty.TabIndex = 8
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(586, 54)
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
        Me.TxtRemarks.Location = New System.Drawing.Point(75, 434)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(421, 18)
        Me.TxtRemarks.TabIndex = 10
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(2, 435)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(60, 16)
        Me.Label30.TabIndex = 723
        Me.Label30.Text = "Remarks"
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
        Me.TxtReferenceNo.Location = New System.Drawing.Point(374, 33)
        Me.TxtReferenceNo.MaxLength = 20
        Me.TxtReferenceNo.Name = "TxtReferenceNo"
        Me.TxtReferenceNo.Size = New System.Drawing.Size(195, 18)
        Me.TxtReferenceNo.TabIndex = 3
        '
        'LblReferenceNo
        '
        Me.LblReferenceNo.AutoSize = True
        Me.LblReferenceNo.BackColor = System.Drawing.Color.Transparent
        Me.LblReferenceNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblReferenceNo.Location = New System.Drawing.Point(266, 33)
        Me.LblReferenceNo.Name = "LblReferenceNo"
        Me.LblReferenceNo.Size = New System.Drawing.Size(71, 16)
        Me.LblReferenceNo.TabIndex = 731
        Me.LblReferenceNo.Text = "Invoice No."
        '
        'LblVendorDocNo
        '
        Me.LblVendorDocNo.AutoSize = True
        Me.LblVendorDocNo.BackColor = System.Drawing.Color.Transparent
        Me.LblVendorDocNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblVendorDocNo.Location = New System.Drawing.Point(586, 14)
        Me.LblVendorDocNo.Name = "LblVendorDocNo"
        Me.LblVendorDocNo.Size = New System.Drawing.Size(106, 16)
        Me.LblVendorDocNo.TabIndex = 706
        Me.LblVendorDocNo.Text = "Supplier Doc No."
        '
        'TxtVendorDocNo
        '
        Me.TxtVendorDocNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtVendorDocNo.AgLastValueTag = Nothing
        Me.TxtVendorDocNo.AgLastValueText = Nothing
        Me.TxtVendorDocNo.AgMandatory = False
        Me.TxtVendorDocNo.AgMasterHelp = True
        Me.TxtVendorDocNo.AgNumberLeftPlaces = 8
        Me.TxtVendorDocNo.AgNumberNegetiveAllow = False
        Me.TxtVendorDocNo.AgNumberRightPlaces = 2
        Me.TxtVendorDocNo.AgPickFromLastValue = False
        Me.TxtVendorDocNo.AgRowFilter = ""
        Me.TxtVendorDocNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorDocNo.AgSelectedValue = Nothing
        Me.TxtVendorDocNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorDocNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVendorDocNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorDocNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorDocNo.Location = New System.Drawing.Point(708, 14)
        Me.TxtVendorDocNo.MaxLength = 20
        Me.TxtVendorDocNo.Name = "TxtVendorDocNo"
        Me.TxtVendorDocNo.Size = New System.Drawing.Size(188, 18)
        Me.TxtVendorDocNo.TabIndex = 6
        '
        'LvlVendorDocDate
        '
        Me.LvlVendorDocDate.AutoSize = True
        Me.LvlVendorDocDate.BackColor = System.Drawing.Color.Transparent
        Me.LvlVendorDocDate.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvlVendorDocDate.Location = New System.Drawing.Point(586, 34)
        Me.LvlVendorDocDate.Name = "LvlVendorDocDate"
        Me.LvlVendorDocDate.Size = New System.Drawing.Size(103, 16)
        Me.LvlVendorDocDate.TabIndex = 708
        Me.LvlVendorDocDate.Text = "Supplier Doc Dt."
        '
        'TxtVendorDocDate
        '
        Me.TxtVendorDocDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtVendorDocDate.AgLastValueTag = Nothing
        Me.TxtVendorDocDate.AgLastValueText = Nothing
        Me.TxtVendorDocDate.AgMandatory = False
        Me.TxtVendorDocDate.AgMasterHelp = True
        Me.TxtVendorDocDate.AgNumberLeftPlaces = 8
        Me.TxtVendorDocDate.AgNumberNegetiveAllow = False
        Me.TxtVendorDocDate.AgNumberRightPlaces = 2
        Me.TxtVendorDocDate.AgPickFromLastValue = False
        Me.TxtVendorDocDate.AgRowFilter = ""
        Me.TxtVendorDocDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVendorDocDate.AgSelectedValue = Nothing
        Me.TxtVendorDocDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVendorDocDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtVendorDocDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVendorDocDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVendorDocDate.Location = New System.Drawing.Point(708, 34)
        Me.TxtVendorDocDate.MaxLength = 20
        Me.TxtVendorDocDate.Name = "TxtVendorDocDate"
        Me.TxtVendorDocDate.Size = New System.Drawing.Size(188, 18)
        Me.TxtVendorDocDate.TabIndex = 7
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(312, 414)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(60, 16)
        Me.LblCurrency.TabIndex = 735
        Me.LblCurrency.Text = "Currency"
        '
        'TxtCurrency
        '
        Me.TxtCurrency.AgAllowUserToEnableMasterHelp = False
        Me.TxtCurrency.AgLastValueTag = Nothing
        Me.TxtCurrency.AgLastValueText = Nothing
        Me.TxtCurrency.AgMandatory = False
        Me.TxtCurrency.AgMasterHelp = False
        Me.TxtCurrency.AgNumberLeftPlaces = 8
        Me.TxtCurrency.AgNumberNegetiveAllow = False
        Me.TxtCurrency.AgNumberRightPlaces = 2
        Me.TxtCurrency.AgPickFromLastValue = False
        Me.TxtCurrency.AgRowFilter = ""
        Me.TxtCurrency.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCurrency.AgSelectedValue = Nothing
        Me.TxtCurrency.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCurrency.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCurrency.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCurrency.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCurrency.Location = New System.Drawing.Point(376, 414)
        Me.TxtCurrency.MaxLength = 20
        Me.TxtCurrency.Name = "TxtCurrency"
        Me.TxtCurrency.Size = New System.Drawing.Size(120, 18)
        Me.TxtCurrency.TabIndex = 8
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(4, 155)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(230, 20)
        Me.LinkLabel1.TabIndex = 739
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Purchase Invoice For Following Items"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PnlCalcGrid
        '
        Me.PnlCalcGrid.Location = New System.Drawing.Point(670, 415)
        Me.PnlCalcGrid.Name = "PnlCalcGrid"
        Me.PnlCalcGrid.Size = New System.Drawing.Size(310, 160)
        Me.PnlCalcGrid.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(356, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 737
        Me.Label1.Text = "Ä"
        '
        'RbtInvoiceDirect
        '
        Me.RbtInvoiceDirect.AutoSize = True
        Me.RbtInvoiceDirect.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtInvoiceDirect.Location = New System.Drawing.Point(8, 7)
        Me.RbtInvoiceDirect.Name = "RbtInvoiceDirect"
        Me.RbtInvoiceDirect.Size = New System.Drawing.Size(117, 17)
        Me.RbtInvoiceDirect.TabIndex = 0
        Me.RbtInvoiceDirect.TabStop = True
        Me.RbtInvoiceDirect.Text = "Invoice Direct"
        Me.RbtInvoiceDirect.UseVisualStyleBackColor = True
        '
        'RbtInvoiceForChallan
        '
        Me.RbtInvoiceForChallan.AutoSize = True
        Me.RbtInvoiceForChallan.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RbtInvoiceForChallan.Location = New System.Drawing.Point(127, 7)
        Me.RbtInvoiceForChallan.Name = "RbtInvoiceForChallan"
        Me.RbtInvoiceForChallan.Size = New System.Drawing.Size(152, 17)
        Me.RbtInvoiceForChallan.TabIndex = 1
        Me.RbtInvoiceForChallan.TabStop = True
        Me.RbtInvoiceForChallan.Text = "Invoice For Challan"
        Me.RbtInvoiceForChallan.UseVisualStyleBackColor = True
        '
        'GrpDirectInvoice
        '
        Me.GrpDirectInvoice.BackColor = System.Drawing.Color.Transparent
        Me.GrpDirectInvoice.Controls.Add(Me.RbtInvoiceDirect)
        Me.GrpDirectInvoice.Controls.Add(Me.RbtInvoiceForChallan)
        Me.GrpDirectInvoice.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GrpDirectInvoice.Location = New System.Drawing.Point(240, 148)
        Me.GrpDirectInvoice.Name = "GrpDirectInvoice"
        Me.GrpDirectInvoice.Size = New System.Drawing.Size(284, 26)
        Me.GrpDirectInvoice.TabIndex = 1
        Me.GrpDirectInvoice.TabStop = False
        '
        'BtnFillPurchChallan
        '
        Me.BtnFillPurchChallan.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnFillPurchChallan.Font = New System.Drawing.Font("Lucida Console", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnFillPurchChallan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BtnFillPurchChallan.Location = New System.Drawing.Point(534, 153)
        Me.BtnFillPurchChallan.Margin = New System.Windows.Forms.Padding(0)
        Me.BtnFillPurchChallan.Name = "BtnFillPurchChallan"
        Me.BtnFillPurchChallan.Size = New System.Drawing.Size(35, 20)
        Me.BtnFillPurchChallan.TabIndex = 2
        Me.BtnFillPurchChallan.Text = "..."
        Me.BtnFillPurchChallan.UseVisualStyleBackColor = True
        '
        'PnlCustomGrid
        '
        Me.PnlCustomGrid.Location = New System.Drawing.Point(4, 455)
        Me.PnlCustomGrid.Name = "PnlCustomGrid"
        Me.PnlCustomGrid.Size = New System.Drawing.Size(492, 120)
        Me.PnlCustomGrid.TabIndex = 2
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
        Me.TxtCustomFields.Location = New System.Drawing.Point(522, 587)
        Me.TxtCustomFields.MaxLength = 20
        Me.TxtCustomFields.Name = "TxtCustomFields"
        Me.TxtCustomFields.Size = New System.Drawing.Size(72, 18)
        Me.TxtCustomFields.TabIndex = 1012
        Me.TxtCustomFields.Text = "AgTextBox1"
        Me.TxtCustomFields.Visible = False
        '
        'TxtGodown
        '
        Me.TxtGodown.AgAllowUserToEnableMasterHelp = False
        Me.TxtGodown.AgLastValueTag = Nothing
        Me.TxtGodown.AgLastValueText = Nothing
        Me.TxtGodown.AgMandatory = False
        Me.TxtGodown.AgMasterHelp = False
        Me.TxtGodown.AgNumberLeftPlaces = 8
        Me.TxtGodown.AgNumberNegetiveAllow = False
        Me.TxtGodown.AgNumberRightPlaces = 2
        Me.TxtGodown.AgPickFromLastValue = False
        Me.TxtGodown.AgRowFilter = ""
        Me.TxtGodown.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtGodown.AgSelectedValue = Nothing
        Me.TxtGodown.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtGodown.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtGodown.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtGodown.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtGodown.Location = New System.Drawing.Point(75, 414)
        Me.TxtGodown.MaxLength = 0
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(229, 18)
        Me.TxtGodown.TabIndex = 9
        '
        'LblGodown
        '
        Me.LblGodown.AutoSize = True
        Me.LblGodown.BackColor = System.Drawing.Color.Transparent
        Me.LblGodown.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblGodown.Location = New System.Drawing.Point(2, 414)
        Me.LblGodown.Name = "LblGodown"
        Me.LblGodown.Size = New System.Drawing.Size(55, 16)
        Me.LblGodown.TabIndex = 742
        Me.LblGodown.Text = "Godown"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(141, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 3006
        Me.Label5.Text = "Ä"
        '
        'TxtBillToParty
        '
        Me.TxtBillToParty.AgAllowUserToEnableMasterHelp = False
        Me.TxtBillToParty.AgLastValueTag = Nothing
        Me.TxtBillToParty.AgLastValueText = Nothing
        Me.TxtBillToParty.AgMandatory = True
        Me.TxtBillToParty.AgMasterHelp = False
        Me.TxtBillToParty.AgNumberLeftPlaces = 8
        Me.TxtBillToParty.AgNumberNegetiveAllow = False
        Me.TxtBillToParty.AgNumberRightPlaces = 2
        Me.TxtBillToParty.AgPickFromLastValue = False
        Me.TxtBillToParty.AgRowFilter = ""
        Me.TxtBillToParty.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtBillToParty.AgSelectedValue = Nothing
        Me.TxtBillToParty.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtBillToParty.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtBillToParty.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtBillToParty.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtBillToParty.Location = New System.Drawing.Point(160, 73)
        Me.TxtBillToParty.MaxLength = 0
        Me.TxtBillToParty.Name = "TxtBillToParty"
        Me.TxtBillToParty.Size = New System.Drawing.Size(409, 18)
        Me.TxtBillToParty.TabIndex = 5
        '
        'LblPostToAc
        '
        Me.LblPostToAc.AutoSize = True
        Me.LblPostToAc.BackColor = System.Drawing.Color.Transparent
        Me.LblPostToAc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblPostToAc.Location = New System.Drawing.Point(40, 74)
        Me.LblPostToAc.Name = "LblPostToAc"
        Me.LblPostToAc.Size = New System.Drawing.Size(74, 16)
        Me.LblPostToAc.TabIndex = 3005
        Me.LblPostToAc.Text = "Post to A/c"
        '
        'FrmPurchInvoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(984, 622)
        Me.Controls.Add(Me.TxtCustomFields)
        Me.Controls.Add(Me.PnlCustomGrid)
        Me.Controls.Add(Me.BtnFillPurchChallan)
        Me.Controls.Add(Me.GrpDirectInvoice)
        Me.Controls.Add(Me.PnlCalcGrid)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Controls.Add(Me.TxtGodown)
        Me.Controls.Add(Me.TxtRemarks)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.LblGodown)
        Me.Controls.Add(Me.TxtCurrency)
        Me.Controls.Add(Me.LblCurrency)
        Me.Name = "FrmPurchInvoice"
        Me.Text = "Purchase Invoice"
        Me.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.Controls.SetChildIndex(Me.TxtCurrency, 0)
        Me.Controls.SetChildIndex(Me.LblGodown, 0)
        Me.Controls.SetChildIndex(Me.Label30, 0)
        Me.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.PnlCalcGrid, 0)
        Me.Controls.SetChildIndex(Me.GrpDirectInvoice, 0)
        Me.Controls.SetChildIndex(Me.BtnFillPurchChallan, 0)
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
        Me.GrpDirectInvoice.ResumeLayout(False)
        Me.GrpDirectInvoice.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents LblVendor As System.Windows.Forms.Label
    Protected WithEvents TxtVendor As AgControls.AgTextBox
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtStructure As AgControls.AgTextBox
    Protected WithEvents Label25 As System.Windows.Forms.Label
    Protected WithEvents TxtSalesTaxGroupParty As AgControls.AgTextBox
    Protected WithEvents Label27 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmountText As System.Windows.Forms.Label
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label30 As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalMeasureText As System.Windows.Forms.Label
    Protected WithEvents TxtReferenceNo As AgControls.AgTextBox
    Protected WithEvents LblReferenceNo As System.Windows.Forms.Label
    Protected WithEvents TxtCurrency As AgControls.AgTextBox
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents TxtVendorDocDate As AgControls.AgTextBox
    Protected WithEvents LvlVendorDocDate As System.Windows.Forms.Label
    Protected WithEvents TxtVendorDocNo As AgControls.AgTextBox
    Protected WithEvents LblVendorDocNo As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents PnlCalcGrid As System.Windows.Forms.Panel
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents RbtInvoiceDirect As System.Windows.Forms.RadioButton
    Protected WithEvents RbtInvoiceForChallan As System.Windows.Forms.RadioButton
    Protected WithEvents GrpDirectInvoice As System.Windows.Forms.GroupBox
    Protected WithEvents BtnFillPurchChallan As System.Windows.Forms.Button
    Protected WithEvents PnlCustomGrid As System.Windows.Forms.Panel
    Protected WithEvents TxtCustomFields As AgControls.AgTextBox
    Protected WithEvents LblTotalDeliveryMeasure As System.Windows.Forms.Label
    Protected WithEvents LblTotalDeliveryMeasureText As System.Windows.Forms.Label
#End Region

    Private Sub FrmPurchInvoice_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = " UPDATE PurchInvoiceDetail Set PurchChallan = NULL Where DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " Delete From PurchChallanDetail Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " Delete From PurchChallan Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " Delete From Stock Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

        mQry = " Delete From Ledger Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmQuality1_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "PurchInvoice"
        MainLineTableCsv = "PurchInvoiceDetail"
        LogTableName = "PurchInvoice_Log"
        LogLineTableCsv = "PurchInvoiceDetail_Log"

        AgL.GridDesign(Dgl1)
        AgL.AddAgDataGrid(AgCalcGrid1, PnlCalcGrid)

        AgCalcGrid1.AgLibVar = AgL

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
                " From PurchInvoice H " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
                " Where IsNull(IsDeleted,0)=0  " & mCondStr & "  Order By V_Date Desc "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " And H.Div_Code = '" & AgL.PubDivCode & "'"
        mCondStr = mCondStr & " And Vt.NCat In ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, Vt.Description AS [Invoice_Type], H.V_Date AS Date, " & _
                            " H.ReferenceNo AS [Manual_No], SGV.DispName As Vendor, H.SalesTaxGroupParty AS [Sales_Tax_Group_Party], H.VendorDocNo AS [Vendor_Doc_No],  " & _
                            " H.VendorDocDate AS [Vendor_Doc_Date], H.Remarks, H.TotalQty AS [Total_Qty], " & _
                            " H.TotalMeasure AS [Total_Measure], H.TotalAmount AS [Total_Amount],  " & _
                            " H.EntryBy AS [Entry_By], H.EntryDate AS [Entry_Date], H.EntryType AS [Entry_Type] " & _
                            " FROM PurchInvoice H " & _
                            " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                            " LEFT JOIN SubGroup SGV ON SGV.SubCode  = H.Vendor  " & _
                            " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item_UID, 60, 0, Col1Item_UID, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ItemUID")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1ItemCode, 60, 0, Col1ItemCode, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ItemCode")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1Item, 140, 0, Col1Item, True, False)
            .AddAgTextColumn(Dgl1, Col1BaleNo, 50, 0, Col1BaleNo, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_BaleNo")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1LotNo, 50, 0, Col1LotNo, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_LotNo")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1PurchChallan, 70, 0, Col1PurchChallan, True, True)
            .AddAgTextColumn(Dgl1, Col1PurchChallanSr, 40, 5, Col1PurchChallanSr, False, True, False)
            .AddAgTextColumn(Dgl1, Col1SalesTaxGroup, 60, 0, Col1SalesTaxGroup, True, False)
            .AddAgTextColumn(Dgl1, Col1BillingType, 50, 255, Col1BillingType, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_BillingType")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1DeliveryMeasure, 70, 50, Col1DeliveryMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_MeasureUnit")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_MeasureUnit")), Boolean), False)
            .AddAgNumberColumn(Dgl1, Col1DocQty, 70, 8, 4, False, Col1DocQty, True, False, True)
            .AddAgNumberColumn(Dgl1, Col1FreeQty, 60, 8, 3, False, Col1FreeQty, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_FreeQty")), Boolean), False, True)
            .AddAgNumberColumn(Dgl1, Col1RejQty, 70, 8, 4, False, Col1RejQty, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_RejQty")), Boolean), False, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 70, 8, 4, False, Col1Qty, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Qty")), Boolean), False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 50, 0, Col1Unit, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Unit")), Boolean), True)
            .AddAgTextColumn(Dgl1, Col1QtyDecimalPlaces, 50, 0, Col1QtyDecimalPlaces, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 70, 8, 3, False, Col1MeasurePerPcs, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1PcsPerMeasure, 70, 8, 3, False, Col1PcsPerMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocMeasure, 70, 8, 3, False, Col1TotalDocMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalFreeMeasure, 70, 8, 3, False, Col1TotalFreeMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalRejMeasure, 70, 8, 3, False, Col1TotalRejMeasure, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 70, 8, 3, False, Col1TotalMeasure, False, True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 60, 0, Col1MeasureUnit, False, True)
            .AddAgTextColumn(Dgl1, Col1MeasureDecimalPlaces, 50, 0, Col1MeasureDecimalPlaces, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1DeliveryMeasureMultiplier, 100, 8, 4, False, Col1DeliveryMeasureMultiplier, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1DeliveryMeasurePerPcs, 110, 8, 4, False, Col1DeliveryMeasurePerPcs, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_MeasurePerPcs")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_MeasurePerPcs")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1TotalDocDeliveryMeasure, 70, 8, 3, False, Col1TotalDocDeliveryMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Measure")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Measure")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1TotalFreeDeliveryMeasure, 70, 8, 3, False, Col1TotalFreeDeliveryMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_FreeMeasure")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Measure")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1TotalRejDeliveryMeasure, 70, 8, 3, False, Col1TotalRejDeliveryMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_RejMeasure")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Measure")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1TotalDeliveryMeasure, 70, 8, 4, False, Col1TotalDeliveryMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Measure")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Measure")), Boolean), True)
            .AddAgTextColumn(Dgl1, Col1DeliveryMeasureDecimalPlaces, 50, 0, Col1DeliveryMeasureDecimalPlaces, False, True, False)
            .AddAgNumberColumn(Dgl1, Col1Rate, 80, 8, 2, False, Col1Rate, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Rate")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Rate")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Amount")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_Amount")), Boolean), True)
            .AddAgNumberColumn(Dgl1, Col1MRP, 80, 8, 2, False, Col1MRP, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_MRP")), Boolean), False, True)
            .AddAgNumberColumn(Dgl1, Col1SaleRate, 80, 8, 2, False, Col1SaleRate, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_SaleRate")), Boolean), False, True)
            .AddAgDateColumn(Dgl1, Col1ExpiryDate, 90, Col1ExpiryDate, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ExpiryDate")), Boolean), False)
            .AddAgTextColumn(Dgl1, Col1Remark, 200, 255, Col1Remark, True, False)
            .AddAgTextColumn(Dgl1, Col1Deal, 70, 255, Col1Deal, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Deal")), Boolean), False)
            .AddAgNumberColumn(Dgl1, Col1ProfitMarginPer, 100, 8, 2, False, Col1ProfitMarginPer, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ProfitMarginPer")), Boolean), Not CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsEditable_ProfitMarginPer")), Boolean), True)
            .AddAgTextColumn(Dgl1, Col1PurchIndent, 70, 255, Col1PurchIndent, False, False)
            .AddAgTextColumn(Dgl1, Col1PurchIndentSr, 40, 5, Col1PurchIndentSr, False, True, False)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 50

        AgCalcGrid1.Ini_Grid(LblV_Type.Tag, TxtV_Date.Text)

        AgCalcGrid1.AgFixedRows = 6

        If CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Measure")), Boolean) = False Then LblTotalDeliveryMeasure.Visible = False : LblTotalDeliveryMeasureText.Visible = False
        If CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Measure")), Boolean) = False Then LblTotalMeasure.Visible = False : LblTotalMeasureText.Visible = False


        Dgl1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple

        AgCalcGrid1.AgLineGrid = Dgl1
        AgCalcGrid1.AgLineGridMandatoryColumn = Dgl1.Columns(Col1Item).Index
        AgCalcGrid1.AgLineGridGrossColumn = Dgl1.Columns(Col1Amount).Index
        AgCalcGrid1.AgLineGridPostingGroupSalesTaxProd = Dgl1.Columns(Col1SalesTaxGroup).Index
        AgCalcGrid1.AgPostingPartyAc = TxtVendor.AgSelectedValue

        AgCustomGrid1.Ini_Grid(mSearchCode)
        AgCustomGrid1.SplitGrid = False

        If BlnIsDirectInvoice Then
            Dgl1.Columns(Col1PurchChallan).Visible = False
        End If



        Dgl1.AgLastColumn = Dgl1.Columns(Col1Remark).Index
        'AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        Dgl1.AgSkipReadOnlyColumns = True
        Dgl1.AllowUserToOrderColumns = True
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer
        Dim bSelectionQry$ = ""

        mQry = " Update PurchInvoice " & _
                " SET  " & _
                " ReferenceNo = " & AgL.Chk_Text(TxtReferenceNo.Text) & ", " & _
                " Vendor = " & AgL.Chk_Text(TxtVendor.AgSelectedValue) & ", " & _
                " BillToParty = " & AgL.Chk_Text(TxtBillToParty.Tag) & ", " & _
                " Currency = " & AgL.Chk_Text(TxtCurrency.AgSelectedValue) & ", " & _
                " SalesTaxGroupParty = " & AgL.Chk_Text(TxtSalesTaxGroupParty.Text) & ", " & _
                " Godown = " & AgL.Chk_Text(AgL.XNull(TxtGodown.Tag)) & ", " & _
                " Structure = " & AgL.Chk_Text(TxtStructure.AgSelectedValue) & ", " & _
                " CustomFields = " & AgL.Chk_Text(TxtCustomFields.AgSelectedValue) & ", " & _
                " VendorDocNo = " & AgL.Chk_Text(TxtVendorDocNo.Text) & ", " & _
                " VendorDocDate = " & AgL.Chk_Text(TxtVendorDocDate.Text) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " TotalAmount = " & Val(LblTotalAmount.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                " TotalDeliveryMeasure = " & Val(LblTotalDeliveryMeasure.Text) & ", " & _
                " " & AgCalcGrid1.FFooterTableUpdateStr() & " " & _
                " " & AgCustomGrid1.FFooterTableUpdateStr() & " " & _
                " Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'mQry = "Delete From PurchInvoiceDetail Where DocId = '" & SearchCode & "'"
        'AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mSr = AgL.VNull(AgL.Dman_Execute("Select Max(Sr) From PurchInvoiceDetail With (NoLock) Where DocID = '" & mSearchCode & "'", AgL.GcnRead).ExecuteScalar)
        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                If Dgl1.Item(ColSNo, I).Tag Is Nothing And Dgl1.Rows(I).Visible = True Then
                    mSr += 1
                    If bSelectionQry <> "" Then bSelectionQry += " UNION ALL "
                    bSelectionQry += " Select " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1PurchChallan, I).Tag) & ", " & _
                                        " " & AgL.Chk_Text(IIf(Val(Dgl1.Item(Col1PurchChallanSr, I).Value) = 0, "", Dgl1.Item(Col1PurchChallanSr, I).Value)) & ", " & _
                                        " " & AgL.Chk_Text(mSearchCode) & ", " & mSr & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Item_UID, I).Tag) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Item, I).Tag) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1BaleNo, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1SalesTaxGroup, I).Tag) & ", " & _
                                        " " & Val(Dgl1.Item(Col1ProfitMarginPer, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1DocQty, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1FreeQty, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1RejQty, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1PcsPerMeasure, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalFreeMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1SaleRate, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1MRP, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1Deal, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1ExpiryDate, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1BillingType, I).Value) & " , " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1DeliveryMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalDocDeliveryMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalFreeDeliveryMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalRejDeliveryMeasure, I).Value) & ", " & _
                                        " " & Val(Dgl1.Item(Col1TotalDeliveryMeasure, I).Value) & ", " & _
                                        " " & AgL.Chk_Text(Dgl1.Item(Col1PurchIndent, I).Value) & ", " & _
                                        " " & AgCalcGrid1.FLineTableFieldValuesStr(I) & " "
                    Call FUpdateDeal(I, Conn, Cmd)
                Else

                    If Dgl1.Rows(I).Visible = True Then
                        If Dgl1.Rows(I).DefaultCellStyle.BackColor <> RowLockedColour Then
                            mQry = "Update dbo.PurchInvoiceDetail " & _
                                    " SET Item = " & AgL.Chk_Text(Dgl1.Item(Col1Item, I).Tag) & ", " & _
                                    " 	SalesTaxGroupItem = " & AgL.Chk_Text(Dgl1.Item(Col1SalesTaxGroup, I).Tag) & ", " & _
                                    " 	ProfitMarginPer = " & Val(Dgl1.Item(Col1ProfitMarginPer, I).Value) & ", " & _
                                    " 	DocQty = " & Val(Dgl1.Item(Col1DocQty, I).Value) & ", " & _
                                    " 	RejQty = " & Val(Dgl1.Item(Col1RejQty, I).Value) & ", " & _
                                    " 	FreeQty = " & Val(Dgl1.Item(Col1FreeQty, I).Value) & ", " & _
                                    " 	Qty = " & Val(Dgl1.Item(Col1Qty, I).Value) & ", " & _
                                    " 	Unit = " & AgL.Chk_Text(Dgl1.Item(Col1Unit, I).Value) & ", " & _
                                    " 	MeasurePerPcs = " & Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                                    " 	MeasureUnit = " & AgL.Chk_Text(Dgl1.Item(Col1MeasureUnit, I).Value) & ", " & _
                                    " 	TotalDocMeasure = " & Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) & ", " & _
                                    " 	TotalMeasure = " & Val(Dgl1.Item(Col1TotalMeasure, I).Value) & ", " & _
                                    " 	Rate = " & Val(Dgl1.Item(Col1Rate, I).Value) & ", " & _
                                    " 	Amount = " & Val(Dgl1.Item(Col1Amount, I).Value) & ", " & _
                                    " 	Sale_Rate = " & Val(Dgl1.Item(Col1SaleRate, I).Value) & ", " & _
                                    " 	MRP = " & Val(Dgl1.Item(Col1MRP, I).Value) & ", " & _
                                    " 	Remark = " & AgL.Chk_Text(Dgl1.Item(Col1Remark, I).Value) & ", " & _
                                    " 	LotNo = " & AgL.Chk_Text(Dgl1.Item(Col1LotNo, I).Value) & ", " & _
                                    " 	PurchIndent = " & AgL.Chk_Text(Dgl1.Item(Col1PurchIndent, I).Tag) & ", " & _
                                    " 	PurchIndentSr = " & AgL.Chk_Text(Dgl1.Item(Col1PurchIndentSr, I).Value) & ", " & _
                                    " 	PurchChallan = " & AgL.Chk_Text(Dgl1.Item(Col1PurchChallan, I).Tag) & ", " & _
                                    " 	PurchChallanSr = " & AgL.Chk_Text(IIf(Val(Dgl1.Item(Col1PurchChallanSr, I).Value) > 0, Dgl1.Item(Col1PurchChallanSr, I).Value, "")) & ", " & _
                                    " 	BillingType = " & AgL.Chk_Text(Dgl1.Item(Col1BillingType, I).Value) & ", " & _
                                    " 	BaleNo = " & AgL.Chk_Text(Dgl1.Item(Col1BaleNo, I).Value) & ", " & _
                                    " 	TotalRejMeasure = " & Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) & ", " & _
                                    " 	Item_Uid = " & AgL.Chk_Text(Dgl1.Item(Col1Item_UID, I).Tag) & ", " & _
                                    " 	DeliveryMeasure = " & AgL.Chk_Text(Dgl1.Item(Col1DeliveryMeasure, I).Value) & ", " & _
                                    " 	DeliveryMeasureMultiplier = " & Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value) & ", " & _
                                    " 	DeliveryMeasurePerPcs = " & Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value) & ", " & _
                                    " 	PcsPerMeasure = " & Val(Dgl1.Item(Col1PcsPerMeasure, I).Value) & ", " & _
                                    " 	TotalDocDeliveryMeasure = " & Val(Dgl1.Item(Col1TotalDocDeliveryMeasure, I).Value) & ", " & _
                                    " 	TotalRejDeliveryMeasure = " & Val(Dgl1.Item(Col1TotalRejDeliveryMeasure, I).Value) & ", " & _
                                    " 	TotalDeliveryMeasure = " & Val(Dgl1.Item(Col1TotalDeliveryMeasure, I).Value) & ", " & _
                                    " 	ExpiryDate = " & AgL.Chk_Text(Dgl1.Item(Col1ExpiryDate, I).Value) & ", " & _
                                    " 	TotalFreeMeasure = " & Val(Dgl1.Item(Col1TotalFreeMeasure, I).Value) & ", " & _
                                    " 	TotalFreeDeliveryMeasure = " & Val(Dgl1.Item(Col1TotalFreeDeliveryMeasure, I).Value) & ", " & _
                                    " 	Deal = " & AgL.Chk_Text(Dgl1.Item(Col1Deal, I).Value) & ", " & _
                                    " " & AgCalcGrid1.FLineTableUpdateStr(I) & " " & _
                                    "   Where DocId = '" & mSearchCode & "' " & _
                                    "   And Sr = " & Dgl1.Item(ColSNo, I).Tag & " "

                            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

                        End If
                    Else
                        mQry = " Delete From PurchInvoiceDetail Where DocId = '" & mSearchCode & "' And Sr = " & Val(Dgl1.Item(ColSNo, I).Tag) & "  "
                        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                    End If
                End If
            End If
        Next

        mQry = "Insert Into PurchInvoiceDetail(DocId, Sr, PurchChallan, PurchChallanSr, PurchInvoice, PurchInvoiceSr, " & _
                " Item_Uid, Item, BaleNo, SalesTaxGroupItem, " & _
                " ProfitMarginPer, DocQty, FreeQty, RejQty, Qty, Unit, MeasurePerPcs, PcsPerMeasure, MeasureUnit, TotalDocMeasure, TotalFreeMeasure, TotalRejMeasure, " & _
                " TotalMeasure, Rate, Amount, Sale_Rate, MRP, Remark, Deal, ExpiryDate, BillingType, " & _
                " DeliveryMeasure, DeliveryMeasureMultiplier, DeliveryMeasurePerPcs, TotalDocDeliveryMeasure, TotalFreeDeliveryMeasure, TotalRejDeliveryMeasure, " & _
                " TotalDeliveryMeasure, PurchIndent, " & AgCalcGrid1.FLineTableFieldNameStr() & ") "
        mQry = mQry + bSelectionQry
        If bSelectionQry <> "" Then
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If
        Call FPostInPurchChallan(Conn, Cmd)



        Call ClsMain.PostStructureLineToAccounts(AgCalcGrid1, TxtRemarks.Text, mSearchCode, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, TxtDivision.AgSelectedValue, _
                                             TxtV_Type.AgSelectedValue, LblPrefix.Text, TxtV_No.Text, TxtReferenceNo.Text, TxtBillToParty.Tag, TxtV_Date.Text, Conn, Cmd)


        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer

        Dim DsTemp As DataSet

        mQry = " Select H.*, Sg.DispName As VendorDispName, C.Description As CurrencyDesc, " & _
                " G.Description as GodownDesc, Sg1.Name As BillToPartyName, Vt.Category as Voucher_Category " & _
                " From (Select * From PurchInvoice Where DocID='" & SearchCode & "') H " & _
                " LEFT JOIN SubGroup Sg ON H.Vendor = Sg.SubCode " & _
                " LEFT JOIN Currency C ON H.Currency = C.Code " & _
                " LEFT JOIN SubGroup Sg1 On H.BillToParty = Sg1.SubCode " & _
                " Left Join Godown G With (NoLock) On H.Godown = G.Code  " & _
                " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type "
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)

                If AgL.XNull(.Rows(0)("Structure")) <> "" Then
                    TxtStructure.Tag = AgL.XNull(.Rows(0)("Structure"))
                End If
                AgCalcGrid1.FrmType = Me.FrmType
                AgCalcGrid1.AgStructure = TxtStructure.Tag
                AgCalcGrid1.AgVoucherCategory = "PURCH"

                If AgL.XNull(.Rows(0)("CustomFields")) <> "" Then
                    TxtCustomFields.AgSelectedValue = AgL.XNull(.Rows(0)("CustomFields"))
                End If
                AgCustomGrid1.FrmType = Me.FrmType
                AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue


                IniGrid()

                TxtReferenceNo.Text = AgL.XNull(.Rows(0)("ReferenceNo"))
                TxtVendor.Tag = AgL.XNull(.Rows(0)("Vendor"))
                TxtVendor.Text = AgL.XNull(.Rows(0)("VendorDispName"))

                TxtBillToParty.Tag = AgL.XNull(.Rows(0)("BillToParty"))
                TxtBillToParty.Text = AgL.XNull(.Rows(0)("BillToPartyName"))

                TxtCurrency.Tag = AgL.XNull(.Rows(0)("Currency"))
                TxtCurrency.Text = AgL.XNull(.Rows(0)("CurrencyDesc"))
                TxtVendorDocNo.Text = AgL.XNull(.Rows(0)("VendorDocNo"))
                TxtVendorDocDate.Text = AgL.XNull(.Rows(0)("VendorDocDate"))

                TxtGodown.Tag = AgL.XNull(.Rows(0)("Godown"))
                TxtGodown.Text = AgL.XNull(.Rows(0)("GodownDesc"))

                TxtSalesTaxGroupParty.Tag = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                TxtSalesTaxGroupParty.Text = AgL.XNull(.Rows(0)("SalesTaxGroupParty"))
                AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                AgCalcGrid1.AgPostingGroupSalesTaxItem = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))

                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))

                AgCalcGrid1.FMoveRecFooterTable(DsTemp.Tables(0), LblV_Type.Tag, TxtV_Date.Text)

                AgCustomGrid1.FMoveRecFooterTable(DsTemp.Tables(0))


                LblTotalQty.Text = "0"
                LblTotalAmount.Text = "0"
                LblTotalMeasure.Text = "0"
                LblTotalDeliveryMeasure.Text = "0"


                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------
                Dim strQryPurchaseShipped$ = "SELECT L.ReferenceDocId, L.ReferenceDocIdSr, Sum(L.Qty) AS Qty " & _
                                             "FROM SaleChallanDetail L " & _
                                             "GROUP BY L.ReferenceDocId, L.ReferenceDocIdSr "

                mQry = "Select L.*, I.Description As ItemDesc, I.ManualCode, C.V_Type + '-' + C.ReferenceNo As ChallanRefNo, " & _
                        " U.DecimalPlaces as QtyDecimalPlaces, MU.DecimalPlaces as MeasureDecimalPlaces, DMU.DecimalPlaces as DeliveryMeasureDecimalPlaces, " & _
                        " (Case When IsNull(PurShipped.Qty,0) > 0 Then 1 Else 0 End) as RowLocked " & _
                        " From (Select * From PurchInvoiceDetail Where DocId = '" & SearchCode & "') As L " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN PurchChallan C On L.PurchChallan = C.DocId " & _
                        " LEFT JOIN Unit U On L.Unit = U.Code " & _
                        " LEFT JOIN Unit MU ON L.MeasureUnit = MU.Code " & _
                        " LEFT JOIN Unit Dmu On L.DeliveryMeasure = Dmu.Code " & _
                        " Left Join (" & strQryPurchaseShipped & ") as PurShipped On L.DocID = PurShipped.ReferenceDocID and L.Sr = PurShipped.ReferenceDocIDSr " & _
                        " Order By L.Sr"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                            Dgl1.Item(ColSNo, I).Tag = AgL.XNull(.Rows(I)("Sr"))
                            Dgl1.Item(Col1PurchChallan, I).Tag = AgL.XNull(.Rows(I)("PurchChallan"))
                            Dgl1.Item(Col1PurchChallan, I).Value = AgL.XNull(.Rows(I)("ChallanRefNo"))
                            Dgl1.Item(Col1PurchChallanSr, I).Value = AgL.XNull(.Rows(I)("PurchChallanSr"))
                            Dgl1.Item(Col1Item_UID, I).Value = AgL.XNull(.Rows(I)("Item_UID"))
                            Dgl1.Item(Col1ItemCode, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1ItemCode, I).Value = AgL.XNull(.Rows(I)("ManualCode"))
                            Dgl1.Item(Col1Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Item, I).Value = AgL.XNull(.Rows(I)("ItemDesc"))
                            Dgl1.Item(Col1BaleNo, I).Value = AgL.XNull(.Rows(I)("BaleNo"))
                            Dgl1.Item(Col1SalesTaxGroup, I).Tag = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1SalesTaxGroup, I).Value = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                            Dgl1.Item(Col1QtyDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("QtyDecimalPlaces"))
                            Dgl1.Item(Col1ProfitMarginPer, I).Value = AgL.VNull(.Rows(I)("ProfitMarginPer"))
                            Dgl1.Item(Col1DocQty, I).Value = Format(AgL.VNull(.Rows(I)("DocQty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1FreeQty, I).Value = Format(AgL.VNull(.Rows(I)("FreeQty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1RejQty, I).Value = Format(AgL.VNull(.Rows(I)("RejQty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1Qty, I).Value = Format(AgL.VNull(.Rows(I)("Qty")), "0.".PadRight(AgL.VNull(.Rows(I)("QtyDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasureDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("MeasureDecimalPlaces"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1PcsPerMeasure, I).Value = Format(AgL.VNull(.Rows(I)("PcsPerMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalFreeMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalFreeMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalRejMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("MeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.VNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Amount, I).Value = Format(AgL.VNull(.Rows(I)("Amount")), "0.00")
                            Dgl1.Item(Col1SaleRate, I).Value = AgL.VNull(.Rows(I)("Sale_Rate"))
                            Dgl1.Item(Col1MRP, I).Value = AgL.VNull(.Rows(I)("MRP"))
                            Dgl1.Item(Col1ExpiryDate, I).Value = AgL.XNull(.Rows(I)("ExpiryDate"))

                            Dgl1.Item(Col1Remark, I).Value = AgL.XNull(.Rows(I)("Remark"))
                            Dgl1.Item(Col1Deal, I).Value = AgL.XNull(.Rows(I)("Deal"))

                            Dgl1.Item(Col1BillingType, I).Value = AgL.XNull(.Rows(I)("BillingType"))

                            Dgl1.Item(Col1PurchIndent, I).Value = AgL.XNull(.Rows(I)("PurchIndent"))

                            Dgl1.Item(Col1DeliveryMeasure, I).Value = AgL.XNull(.Rows(I)("DeliveryMeasure"))
                            Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("DeliveryMeasurePerPcs")), "0.".PadRight(AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces"))
                            Dgl1.Item(Col1TotalDocDeliveryMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDocDeliveryMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalFreeDeliveryMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalFreeDeliveryMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalRejDeliveryMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalRejDeliveryMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces")) + 2, "0"))
                            Dgl1.Item(Col1TotalDeliveryMeasure, I).Value = Format(AgL.VNull(.Rows(I)("TotalDeliveryMeasure")), "0.".PadRight(AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces")) + 2, "0"))


                            'If .Rows(I)("RowLocked") > 0 Then Dgl1.Rows(I).DefaultCellStyle.BackColor = RowLockedColour


                            If Not AgL.StrCmp(Dgl1.Item(Col1Unit, I).Value, Dgl1.Item(Col1Unit, 0).Value) Then IsSameUnit = False
                            If Not AgL.StrCmp(Dgl1.Item(Col1MeasureUnit, I).Value, Dgl1.Item(Col1MeasureUnit, 0).Value) Then IsSameMeasureUnit = False
                            If Not AgL.StrCmp(Dgl1.Item(Col1DeliveryMeasure, I).Value, Dgl1.Item(Col1DeliveryMeasure, 0).Value) Then IsSameDeliveryMeasureUnit = False

                            If intQtyDecimalPlaces < Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value) Then intQtyDecimalPlaces = Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value)
                            If intMeasureDecimalPlaces < Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) Then intMeasureDecimalPlaces = Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value)
                            If intDeliveryMeasureDecimalPlaces < Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) Then intDeliveryMeasureDecimalPlaces = Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value)

                            LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                            LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                            LblTotalDeliveryMeasure.Text = Val(LblTotalDeliveryMeasure.Text) + Val(Dgl1.Item(Col1TotalDeliveryMeasure, I).Value)
                            LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)




                            Call AgCalcGrid1.FMoveRecLineTable(DsTemp.Tables(0), I)

                        Next I
                    End If
                End With
                AgCalcGrid1.FMoveRecLineLedgerAc()
                If AgCustomGrid1.Rows.Count = 0 Then AgCustomGrid1.Visible = False

                'If Dgl1.Item(Col1PurchChallan, 0).Tag = mSearchCode Then
                '    RbtInvoiceDirect.Checked = True
                'Else
                '    RbtInvoiceForChallan.Checked = True
                'End If

                'Calculation()
                '-------------------------------------------------------------
            End If
        End With
    End Sub



    Private Sub FrmSaleOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
        AgCalcGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Txt_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtV_Type.Validating, TxtVendor.Validating, TxtSalesTaxGroupParty.Validating, TxtReferenceNo.Validating
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtV_Type.Name
                    TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
                    AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
                    AgCalcGrid1.AgNCat = LblV_Type.Tag

                    TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GcnRead)
                    AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

                    IniGrid()
                    TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "PurchInvoice", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)

                Case TxtVendor.Name
                    If TxtV_Date.Text <> "" And TxtVendor.Text <> "" Then
                        If sender.AgDataRow IsNot Nothing Then
                            TxtCurrency.AgSelectedValue = AgL.XNull(sender.AgDataRow.Cells("Currency").Value)
                        End If

                    End If
                    TxtBillToParty.Tag = TxtVendor.Tag
                    TxtBillToParty.Text = TxtVendor.Text
                    BtnFillPurchChallan.Tag = Nothing

                Case TxtSalesTaxGroupParty.Name
                    AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
                    Calculation()

                Case TxtReferenceNo.Name
                    e.Cancel = Not AgTemplate.ClsMain.FCheckDuplicateRefNo("ReferenceNo", "PurchInvoice", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtReferenceNo.Text, mSearchCode)


                Case TxtReferenceNo.Name
                    e.Cancel = Not FCheckDuplicateRefNo()

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtStructure.AgSelectedValue = AgStructure.ClsMain.FGetStructureFromNCat(LblV_Type.Tag, AgL.GcnRead)
        AgCalcGrid1.AgStructure = TxtStructure.AgSelectedValue
        AgCalcGrid1.AgNCat = LblV_Type.Tag

        TxtCustomFields.AgSelectedValue = AgCustomFields.ClsMain.FGetCustomFieldFromV_Type(TxtV_Type.AgSelectedValue, AgL.GCn)
        AgCustomGrid1.AgCustom = TxtCustomFields.AgSelectedValue

        If DtV_TypeSettings IsNot Nothing Then
            If DtV_TypeSettings.Rows.Count > 0 Then
                TxtGodown.Tag = DtV_TypeSettings.Rows(0)("DEFAULT_Godown")
                TxtGodown.Text = AgL.XNull(AgL.Dman_Execute(" Select Description From Godown Where Code = '" & TxtGodown.Tag & "'", AgL.GCn).ExecuteScalar)
            End If
        End If

        IniGrid()
        TabControl1.SelectedTab = TP1
        TxtSalesTaxGroupParty.AgSelectedValue = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupParty"))
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        AgCalcGrid1.AgPostingGroupSalesTaxItem = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
        RbtInvoiceDirect.Checked = True
        TxtReferenceNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ReferenceNo", "PurchInvoice", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
        'TxtVendor.Focus()
    End Sub

    Private Sub Dgl1_EditingControl_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgl1.EditingControl_LostFocus
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Rate
                    Calculation()
            End Select            
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub Validating_Item(ByVal Code As String, ByVal mRow As Integer)
    '    Dim DrTemp As DataRow() = Nothing
    '    Dim DtTemp As DataTable = Nothing
    '    Try
    '        If Dgl1.Item(Col1Item, mRow).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRow).ToString.Trim = "" Then
    '            Dgl1.Item(Col1Unit, mRow).Value = ""
    '            Dgl1.Item(Col1SalesTaxGroup, mRow).Value = ""
    '            Dgl1.Item(Col1MeasureUnit, mRow).Value = ""
    '            Dgl1.Item(Col1MeasurePerPcs, mRow).Value = ""
    '            Dgl1.Item(Col1Rate, mRow).Value = ""
    '            Dgl1.Item(Col1DocQty, mRow).Value = ""
    '        Else
    '            If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
    '                DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Code & "'")
    '                Call FSetColumnDecimalPlace(Dgl1.AgSelectedValue(Col1Item, mRow), mRow)
    '                Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DrTemp(0)("Unit"))
    '                Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
    '                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(DrTemp(0)("MeasurePerPcs"))
    '                Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DrTemp(0)("Rate"))
    '                Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
    '                If AgL.StrCmp(Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow), "") Then
    '                    Dgl1.AgSelectedValue(Col1SalesTaxGroup, mRow) = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
    '                End If

    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message & " On Validating_Item Function ")
    '    End Try
    'End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        If Topctrl1.Mode = "Browse" Then Exit Sub
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item_UID
                    Validating_Item_Uid(Dgl1.Item(Col1Item_UID, mRowIndex).Value, mRowIndex)
                    Call FGetDeliveryMeasureMultiplier(mRowIndex)

                Case Col1Item
                    Validating_ItemCode(mColumnIndex, mRowIndex)
                    Call FGetDeliveryMeasureMultiplier(mRowIndex)

                Case Col1ItemCode
                    Validating_ItemCode(mColumnIndex, mRowIndex)
                    Call FGetDeliveryMeasureMultiplier(mRowIndex)

                Case Col1DeliveryMeasure
                    Call FGetDeliveryMeasureMultiplier(mRowIndex)
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
        LblTotalMeasure.Text = 0
        LblTotalDeliveryMeasure.Text = 0
        LblTotalAmount.Text = 0

        Dim DEALARR() As String = Nothing
        Dim DEALRATE As Double

        Dim MRATE As Double = 0
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        AgCalcGrid1.AgVoucherCategory = "PURCH"

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" And Dgl1.Rows(I).Visible Then

                Dgl1.Item(Col1Qty, I).Value = Val(Dgl1.Item(Col1DocQty, I).Value) - Val(Dgl1.Item(Col1RejQty, I).Value) + Val(Dgl1.Item(Col1FreeQty, I).Value)



                DEALRATE = 0
                If Dgl1.Item(Col1Deal, I).Value <> "" Then
                    DEALARR = Split(Dgl1.Item(Col1Deal, I).Value.ToString, "+", 2)
                    If DEALARR.Length = 2 Then
                        DEALRATE = Format((Val(Dgl1.Item(Col1Rate, I).Value) * Val(DEALARR(0))) / (Val(DEALARR(0)) + Val(DEALARR(1))), "0.00")
                    End If
                End If


                If DEALRATE <> 0 Then
                    MRATE = DEALRATE
                Else
                    MRATE = Val(Dgl1.Item(Col1Rate, I).Value)
                End If


                'If In Item Master Measure Per Pcs Is Defined then this calculation will be executed.
                'For Example In Carpet Area Per Pcs Is Defined in Item Master and Total Area will be calculated
                'with that Area per pcs. 
                If Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) <> 0 Then
                    Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalFreeMeasure, I).Value = Format(Val(Dgl1.Item(Col1FreeQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(Val(Dgl1.Item(Col1RejQty, I).Value) * Val(Dgl1.Item(Col1MeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                End If

                'If in item master Pcs Per Measure is defined this calculation will be executed.
                'for example in case of soap user will feed how many cartons he purchased in the measure field and
                'qty will be calculated on the basis of the pcs per measure.
                If Val(Dgl1.Item(Col1PcsPerMeasure, I).Value) <> 0 Then
                    Dgl1.Item(Col1Qty, I).Value = Format(Val(Dgl1.Item(Col1TotalMeasure, I).Value) * Val(Dgl1.Item(Col1PcsPerMeasure, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1DocQty, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * Val(Dgl1.Item(Col1PcsPerMeasure, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1FreeQty, I).Value = Format(Val(Dgl1.Item(Col1TotalFreeMeasure, I).Value) * Val(Dgl1.Item(Col1PcsPerMeasure, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1RejQty, I).Value = Format(Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) * Val(Dgl1.Item(Col1PcsPerMeasure, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1QtyDecimalPlaces, I).Value) + 2, "0"))
                End If

                'if the qty unit and mesure units are equal then qty will auto come in mesure fields
                'for example yarn's unit and measure unit is Kg
                'In this case same figure will be copied in the measure.
                If AgL.StrCmp(Dgl1.Item(Col1MeasureUnit, I).Value, Dgl1.Item(Col1Unit, I).Value) Then
                    Dgl1.Item(Col1TotalMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalDocMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalFreeMeasure, I).Value = Format(Val(Dgl1.Item(Col1FreeQty, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalRejMeasure, I).Value = Format(Val(Dgl1.Item(Col1RejQty, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1MeasureDecimalPlaces, I).Value) + 2, "0"))
                End If

                'By default measure unit will automatically come in delivery meaure unit and delivery measure
                'multiplier will be set to 1.
                If Val(Dgl1.Item(Col1TotalMeasure, I).Value) = 0 Then
                    Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value = 0
                ElseIf AgL.StrCmp(Dgl1.Item(Col1MeasureUnit, I).Value, Dgl1.Item(Col1DeliveryMeasure, I).Value) Then
                    Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value = 1
                End If

                'Delivery measure calculation
                'Delivery measure will be automatically calculated on the basis of delivery measure multiplier.
                'Dgl1.Item(Col1TotalDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1TotalMeasure, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(CType(Dgl1.Columns(Col1TotalDeliveryMeasure), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                If Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value) <> 0 Then
                    Dgl1.Item(Col1TotalDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1Qty, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalDocDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalFreeDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1FreeQty, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalRejDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1RejQty, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                ElseIf Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value) <> 0 Then
                    'Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value = Format(Val(Dgl1.Item(Col1MeasurePerPcs, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1TotalMeasure, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalDocDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalFreeDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1TotalFreeMeasure, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                    Dgl1.Item(Col1TotalRejDeliveryMeasure, I).Value = Format(Val(Dgl1.Item(Col1TotalRejMeasure, I).Value) * Val(Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value), "0.".PadRight(Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value) + 2, "0"))
                End If



                If AgL.StrCmp(Dgl1.Item(Col1BillingType, I).Value, "Measure") Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalDeliveryMeasure, I).Value) * MRATE, "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                ElseIf AgL.StrCmp(Dgl1.Item(Col1BillingType, I).Value, "Qty") Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * MRATE, "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                ElseIf AgL.StrCmp(Dgl1.Item(Col1BillingType, I).Value, "Doc Qty") Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * MRATE, "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                ElseIf AgL.StrCmp(Dgl1.Item(Col1BillingType, I).Value, "Doc Measure") Then
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1TotalDocMeasure, I).Value) * MRATE, "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                Else
                    Dgl1.Item(Col1Amount, I).Value = Format(Val(Dgl1.Item(Col1DocQty, I).Value) * MRATE, "0.".PadRight(CType(Dgl1.Columns(Col1Amount), AgControls.AgTextColumn).AgNumberRightPlaces + 2, "0"))
                End If

                'Footer Calculation
                LblTotalQty.Text = Val(LblTotalQty.Text) + Val(Dgl1.Item(Col1Qty, I).Value)
                LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(Dgl1.Item(Col1TotalMeasure, I).Value)
                LblTotalDeliveryMeasure.Text = Val(LblTotalDeliveryMeasure.Text) + Val(Dgl1.Item(Col1TotalDeliveryMeasure, I).Value)
                LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(Dgl1.Item(Col1Amount, I).Value)
            End If
        Next
        AgCalcGrid1.AgPostingGroupSalesTaxParty = TxtSalesTaxGroupParty.AgSelectedValue
        AgCalcGrid1.AgVoucherCategory = "PURCH"
        AgCalcGrid1.Calculation()

        For I = 0 To Dgl1.RowCount - 1
            If Dgl1.Item(Col1Item, I).Value <> "" Then
                If Val(Dgl1.Item(Col1ProfitMarginPer, I).Value) > 0 Then
                    Dgl1.Item(Col1SaleRate, I).Value = Format((Val(AgCalcGrid1.AgChargesValue("LV", I, AgStructure.AgCalcGrid.LineColumnType.Amount)) + (Val(AgCalcGrid1.AgChargesValue("LV", I, AgStructure.AgCalcGrid.LineColumnType.Amount)) * Val(Dgl1.Item(Col1ProfitMarginPer, I).Value) / 100)) / Val(Dgl1.Item(Col1Qty, I).Value), "0.00")
                End If
            End If
        Next I


        LblTotalQty.Text = Val(LblTotalQty.Text)
        LblTotalMeasure.Text = Val(LblTotalMeasure.Text)
        LblTotalAmount.Text = Val(LblTotalAmount.Text)
    End Sub

    Private Sub FrmSaleOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        If AgL.RequiredField(TxtVendor, LblVendor.Text) Then passed = False : Exit Sub
        If AgL.RequiredField(TxtBillToParty, LblPostToAc.Text) Then passed = False : Exit Sub
        If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) Then passed = False : Exit Sub        
        If AgCL.AgIsDuplicate(Dgl1, "" + Dgl1.Columns(Col1Item).Index.ToString + "," + Dgl1.Columns(Col1PurchChallan).Index.ToString + "," + Dgl1.Columns(Col1PurchChallanSr).Index.ToString + "") = True Then passed = False : Exit Sub

        With Dgl1
            For I = 0 To .Rows.Count - 1
                If .Item(Col1Item, I).Value <> "" Then
                    If Val(.Item(Col1DocQty, I).Value) = 0 Then
                        MsgBox("Doc Qty Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                        .CurrentCell = .Item(Col1DocQty, I) : Dgl1.Focus()
                        passed = False : Exit Sub
                    End If

                    'If Val(.Item(Col1Rate, I).Value) = 0 Then
                    '    MsgBox("Rate Is 0 At Row No " & Dgl1.Item(ColSNo, I).Value & "")
                    '    .CurrentCell = .Item(Col1Rate, I) : Dgl1.Focus()
                    '    passed = False : Exit Sub
                    'End If
                End If
            Next
        End With

        passed = AgTemplate.ClsMain.FCheckDuplicateRefNo("ReferenceNo", "PurchInvoice", _
                                    TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, _
                                    TxtSite_Code.AgSelectedValue, Topctrl1.Mode, _
                                    TxtReferenceNo.Text, mSearchCode)

        If TxtVendorDocNo.Text <> "" Then
            passed = ClsMain.FCheckDuplicatePartyDocNo("VendorDocNo", "PurchInvoice", _
                    TxtV_Type.AgSelectedValue, TxtVendorDocNo.Text, mSearchCode)
        End If
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub Dgl1_CellEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.CellEnter
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Qty, Col1DocQty, Col1RejQty
                    CType(Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex), AgControls.AgTextColumn).AgNumberRightPlaces = Val(Dgl1.Item(Col1QtyDecimalPlaces, Dgl1.CurrentCell.RowIndex).Value)

                Case Col1MeasurePerPcs, Col1TotalMeasure, Col1TotalDocMeasure, Col1TotalRejMeasure
                    CType(Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex), AgControls.AgTextColumn).AgNumberRightPlaces = Val(Dgl1.Item(Col1MeasureDecimalPlaces, Dgl1.CurrentCell.RowIndex).Value)

                Case Col1TotalDeliveryMeasure, Col1TotalDocDeliveryMeasure, Col1TotalRejDeliveryMeasure
                    CType(Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex), AgControls.AgTextColumn).AgNumberRightPlaces = Val(Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, Dgl1.CurrentCell.RowIndex).Value)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ProcFillItems(ByVal bChallanNoStr As String)
        Dim I As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Try
            If bChallanNoStr = "" Then Exit Sub

            mQry = "SELECT Max(L.Item) As Item, Max(I.Description) as Item_Name, " & _
                        " Max(I.ManualCode) as ItemManualCode,  " & _
                        " Max(H.V_Type) + '-' +  Max(H.ReferenceNo) AS ChallanNo,   " & _
                        " Max(H.V_Date) as ChallanDate, Max(L.BillingType) as BillingType, " & _
                        " Sum(L.Qty) - IsNull(Sum(Cd.Qty), 0) as [Bal.Qty],   " & _
                        " Sum(L.TotalMeasure) - IsNull(Sum(Cd.TotalMeasure), 0) as [Bal.Measure],   " & _
                        " Sum(L.TotalDeliveryMeasure) - IsNull(Sum(Cd.TotalDeliveryMeasure), 0) as [Bal.DeliveryMeasure],   " & _
                        " Max(L.Unit) as Unit, Max(L.MeasureUnit) as MeasureUnit, Max(L.DeliveryMeasure) as DeliveryMeasure, Max(L.Rate) as Rate,  " & _
                        " Max(L.SalesTaxGroupItem) SalesTaxGroupItem, L.PurchChallan, L.PurchChallanSr, " & _
                        " Max(L.MeasurePerPcs) As MeasurePerPcs, Max(L.DeliveryMeasurePerPcs) as DeliveryMeasurePerPcs, Max(L.DeliveryMeasureMultiplier) as DeliveryMeasureMultiplier, " & _
                        " Max(L.MeasureUnit) As MeasureUnit,  Max(L.Deal) as Deal, Max(L.ProfitMarginPer) as ProfitMarginPer, Max(L.Mrp) as Mrp, Max(L.Sale_Rate) as Sale_Rate, max(L.ExpiryDate) as ExpiryDate, " & _
                        " Max(U.DecimalPlaces) As QtyDecimalPlaces, Max(U1.DecimalPlaces) As MeasureDecimalPlaces, Max(U2.DecimalPlaces) As DeliveryMeasureDecimalPlaces   " & _
                        " FROM (  " & _
                        "    SELECT DocID, V_Type, ReferenceNo, V_Date   " & _
                        "    FROM PurchChallan With (nolock)   " & _
                        " ) AS  H   " & _
                        " LEFT JOIN PurchChallanDetail L With (nolock) ON H.DocID = L.DocId    " & _
                        " Left Join Item I With (NoLock) On L.Item  = I.Code   " & _
                        " LEFT JOIN Voucher_Type Vt With (nolock) ON H.V_Type = Vt.V_Type    " & _
                        " Left Join (   " & _
                        "    SELECT L.PurchChallan, L.PurchChallanSr, Sum (L.Qty) AS Qty, Sum(L.TotalMeasure) as TotalMeasure, Sum(L.TotalDeliveryMeasure) as TotalDeliveryMeasure  " & _
                        "    FROM PurchInvoiceDetail L  With (nolock)   " & _
                        "    GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                        " ) AS CD ON L.DocId = CD.PurchChallan AND L.Sr = CD.PurchChallanSr " & _
                        " LEFT JOIN Unit U On L.Unit = U.Code   " & _
                        " LEFT JOIN Unit U1 On L.MeasureUnit = U1.Code   " & _
                        " LEFT JOIN Unit U2 On L.DeliveryMeasure = U2.Code   " & _
                        " WHERE L.Qty - IsNull(Cd.Qty, 0) > 0  " & _
                        " And L.PurchChallan + Convert(nVarChar,L.PurchChallanSr) In (" & bChallanNoStr & ")" & _
                        " GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                        " Order By ChallanDate "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            With DtTemp
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
                If .Rows.Count > 0 Then
                    For I = 0 To .Rows.Count - 1
                        Dgl1.Rows.Add()
                        Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1
                        Dgl1.Item(Col1PurchChallan, I).Tag = AgL.XNull(.Rows(I)("PurchChallan"))
                        Dgl1.Item(Col1PurchChallan, I).Value = AgL.XNull(.Rows(I)("ChallanNo"))
                        Dgl1.Item(Col1PurchChallanSr, I).Value = AgL.XNull(.Rows(I)("PurchChallanSr"))
                        Dgl1.Item(Col1Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                        Dgl1.Item(Col1BillingType, I).Value = AgL.XNull(.Rows(I)("Billingtype"))
                        Dgl1.Item(Col1DeliveryMeasure, I).Value = AgL.XNull(.Rows(I)("DeliveryMeasure"))
                        Dgl1.Item(Col1Item, I).Value = AgL.XNull(.Rows(I)("Item_Name"))
                        Dgl1.Item(Col1SalesTaxGroup, I).Tag = AgL.XNull(.Rows(I)("SalesTaxGroupItem"))
                        Dgl1.Item(Col1DocQty, I).Value = AgL.VNull(.Rows(I)("Bal.Qty"))
                        Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Bal.Qty"))
                        Dgl1.Item(Col1QtyDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("QtyDecimalPlaces"))
                        Dgl1.Item(Col1MeasureDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("MeasureDecimalPlaces"))
                        Dgl1.Item(Col1DeliveryMeasureDecimalPlaces, I).Value = AgL.VNull(.Rows(I)("DeliveryMeasureDecimalPlaces"))
                        Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("Bal.Measure"))
                        Dgl1.Item(Col1TotalDeliveryMeasure, I).Value = AgL.VNull(.Rows(I)("Bal.DeliveryMeasure"))
                        Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1MeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("MeasurePerPcs")), "0.0000")
                        Dgl1.Item(Col1DeliveryMeasurePerPcs, I).Value = Format(AgL.VNull(.Rows(I)("DeliveryMeasurePerPcs")), "0.0000")
                        Dgl1.Item(Col1DeliveryMeasureMultiplier, I).Value = Format(AgL.VNull(.Rows(I)("DeliveryMeasureMultiplier")), "0.0000")
                        Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                        Dgl1.Item(Col1Rate, I).Value = Format(AgL.VNull(.Rows(I)("Rate")), "0.00")
                        Dgl1.Item(Col1MRP, I).Value = Format(AgL.VNull(.Rows(I)("Mrp")), "0.00")
                        Dgl1.Item(Col1SaleRate, I).Value = Format(AgL.VNull(.Rows(I)("Sale_Rate")), "0.00")
                        Dgl1.Item(Col1ProfitMarginPer, I).Value = Format(AgL.VNull(.Rows(I)("ProfitMarginPer")), "0.00")
                        Dgl1.Item(Col1Deal, I).Value = AgL.XNull(.Rows(I)("Deal"))
                        Dgl1.Item(Col1ExpiryDate, I).Value = AgL.XNull(.Rows(I)("ExpiryDate"))

                        'FGetPurchIndent(Dgl1.Item(Col1Item, I).Tag, Dgl1.Item(Col1PurchIndent, I).Value)

                        AgCalcGrid1.FCopyStructureLine(AgL.XNull(.Rows(I)("PurchChallan")), Dgl1, I, AgL.VNull(.Rows(I)("PurchChallan")))
                    Next I
                End If
            End With
            AgCalcGrid1.Calculation(True)
            Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TempPurchInvoice_BaseFunction_DispText() Handles Me.BaseFunction_DispText

        If Not AgL.StrCmp(Topctrl1.Mode, "Add") Then
            RbtInvoiceDirect.Enabled = False : RbtInvoiceForChallan.Enabled = False
        Else
            RbtInvoiceDirect.Enabled = True : RbtInvoiceForChallan.Enabled = True
        End If

        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then
            BtnFillPurchChallan.Enabled = False
        ElseIf RbtInvoiceForChallan.Checked = True Then
            BtnFillPurchChallan.Enabled = True
        Else
            BtnFillPurchChallan.Enabled = False
        End If

        If BlnIsDirectInvoice Then
            GrpDirectInvoice.Visible = False
            BtnFillPurchChallan.Visible = False
            Dgl1.Columns(Col1PurchChallan).Visible = False
        End If

        'If BlnIsTotalDeliveryMeasureVisible = False Then LblTotalDeliveryMeasure.Visible = False : LblTotalDeliveryMeasureText.Visible = False
        'If BlnIsMeasureVisible = False Then LblTotalMeasure.Visible = False : LblTotalMeasureText.Visible = False
    End Sub

    Private Sub DGL1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.KeyDown
        If e.Control And e.KeyCode = Keys.D Then
            sender.CurrentRow.Selected = True
        End If

        If e.KeyCode = Keys.Delete Then
            If sender.currentrow.selected Then
                If sender.Rows(sender.currentcell.rowindex).DefaultCellStyle.BackColor = RowLockedColour Then
                    MsgBox("Locked Row is not allowed to select.")
                    e.Handled = True
                Else
                    sender.Rows(sender.currentcell.rowindex).Visible = False
                    Calculation()
                    e.Handled = True
                End If
            End If
        End If

        If e.Control Or e.Shift Or e.Alt Then Exit Sub

            If e.KeyCode = Keys.Insert Then
                FOpenItemMaster()
            End If

            If e.KeyCode = Keys.Enter Then
                If Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name = Col1Item Then
                    If Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value Is Nothing Then Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value = ""
                    If Dgl1.Item(Dgl1.CurrentCell.ColumnIndex, Dgl1.CurrentCell.RowIndex).Value = "" Then
                        AgCalcGrid1.Focus()
                    End If
                End If
            End If


            'Call FOpenMaster(e)
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            Dim bRData As String
            '// Check for relational data in Purchase Return
            mQry = " DECLARE @Temp NVARCHAR(Max); "
            mQry += " SET @Temp=''; "
            mQry += " SELECT  @Temp=@Temp +  X.VNo + ', ' FROM (SELECT DISTINCT H.V_Type + '-' + Convert(VARCHAR,H.V_No) AS VNo From PurchInvoiceDetail  L LEFT JOIN PurchInvoice H ON L.DocId = H.DocID WHERE L.ReferenceDocID  = '" & TxtDocId.Text & "' And IsNull(H.IsDeleted,0) = 0) AS X  "
            mQry += " SELECT @Temp as RelationalData "
            bRData = AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar
            If bRData.Trim <> "" Then
                MsgBox(" Purchase Return " & bRData & " created against Invoice No. " & TxtV_Type.Tag & "-" & TxtV_No.Text & ". Can't Modify Entry")
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " in FGetRelationalData in TempRequisition")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbEdit(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbEdit
        Passed = Not FGetRelationalData()
    End Sub

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    Private Function FCheckDuplicateRefNo() As Boolean
        FCheckDuplicateRefNo = True

        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'   " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE ReferenceNo = '" & TxtReferenceNo.Text & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mSearchCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Reference No. Already Exists") : TxtReferenceNo.Focus()
        End If

        If Topctrl1.Mode = "Add" Then
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE VendorDocNo = '" & TxtVendorDocNo.Text & "' And Vendor = '" & TxtVendor.AgSelectedValue & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Vendor Doc. No. Already Exists") : TxtReferenceNo.Focus()
        Else
            mQry = " SELECT COUNT(*) FROM PurchInvoice WHERE VendorDocNo = '" & TxtVendorDocNo.Text & "'  And Vendor = '" & TxtVendor.AgSelectedValue & "'  " & _
                   " AND V_Type ='" & TxtV_Type.AgSelectedValue & "'  And Div_Code = '" & TxtDivision.AgSelectedValue & "' And Site_Code = '" & TxtSite_Code.AgSelectedValue & "' And IsNull(IsDeleted,0) = 0 AND DocID <>'" & mSearchCode & "'  "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateRefNo = False : MsgBox("Vendor Doc No. Already Exists") : TxtReferenceNo.Focus()
        End If
    End Function

    Private Sub FrmCarpetMaterialPlan_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 654, 990, 0, 0)
        AgCustomGrid1.FrmType = Me.FrmType
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub BtnFillSaleChallan_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnFillPurchChallan.Click
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            Dim StrTicked As String

            StrTicked = FHPGD_PendingSaleChallan()
            If StrTicked <> "" Then
                ProcFillItems(StrTicked)
            Else
                Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
            End If

            Dgl1.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FHPGD_PendingSaleChallan() As String
        Dim FRH_Multiple As DMHelpGrid.FrmHelpGrid_Multi
        Dim StrSendText As String
        Dim StrRtn As String = ""

        StrSendText = RbtInvoiceForChallan.Tag

        mQry = " SELECT 'o' As Tick, L.PurchChallan + Convert(nVarChar,L.PurchChallanSr) As PurchChallanDocIdSr, " & _
                " Max(H.V_Type) + '-' +  Max(H.ReferenceNo) AS ChallanNo, " & _
                " Max(H.V_Date) as ChallanDate, Max(I.Description) as Item_Name,  " & _
                " Sum(L.Qty) - IsNull(Sum(Cd.Qty), 0) as [Bal.Qty],   " & _
                " Max(L.Unit) as Unit " & _
                " FROM (  " & _
                "       SELECT DocID, V_Type, ReferenceNo, V_Date   " & _
                "       FROM PurchChallan With (nolock)   " & _
                "       WHERE Vendor='" & TxtVendor.Tag & "' " & _
                "       And Div_Code = '" & TxtDivision.Tag & "' " & _
                "       AND Site_Code = '" & TxtSite_Code.Tag & "' " & _
                "       AND V_Date<='" & TxtV_Date.Text & "'" & _
                " ) AS  H   " & _
                " LEFT JOIN PurchChallanDetail L With (nolock) ON H.DocID = L.DocId    " & _
                " Left Join Item I With (NoLock) On L.Item  = I.Code   " & _
                " LEFT JOIN Voucher_Type Vt With (nolock) ON H.V_Type = Vt.V_Type    " & _
                " Left Join (   " & _
                "       SELECT L.PurchChallan, L.PurchChallanSr, Sum (L.Qty) AS Qty  " & _
                "       FROM PurchInvoiceDetail L  With (nolock)   " & _
                "       GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                " ) AS CD ON L.DocId = CD.PurchChallan AND L.Sr = CD.PurchChallanSr " & _
                " LEFT JOIN Unit U On L.Unit = U.Code   " & _
                " LEFT JOIN Unit U1 On L.MeasureUnit = U1.Code   " & _
                " WHERE L.Qty - IsNull(Cd.Qty, 0) > 0  " & _
                " GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                " Order By ChallanDate "

        FRH_Multiple = New DMHelpGrid.FrmHelpGrid_Multi(New DataView(AgL.FillData(mQry, AgL.GCn).TABLES(0)), "", 300, 730, , , False)
        FRH_Multiple.FFormatColumn(0, "Tick", 40, DataGridViewContentAlignment.MiddleCenter, True)
        FRH_Multiple.FFormatColumn(1, , 0, , False)
        FRH_Multiple.FFormatColumn(2, "Challan No.", 100, DataGridViewContentAlignment.MiddleLeft)
        FRH_Multiple.FFormatColumn(3, "Challan Date", 100, DataGridViewContentAlignment.MiddleLeft)
        FRH_Multiple.FFormatColumn(4, "Item Name", 200, DataGridViewContentAlignment.MiddleLeft)
        FRH_Multiple.FFormatColumn(5, "Bal Qty", 100, DataGridViewContentAlignment.MiddleRight)
        FRH_Multiple.FFormatColumn(6, "Unit", 100, DataGridViewContentAlignment.MiddleLeft)

        FRH_Multiple.StartPosition = FormStartPosition.CenterScreen
        FRH_Multiple.ShowDialog()

        If FRH_Multiple.BytBtnValue = 0 Then
            StrRtn = FRH_Multiple.FFetchData(1, "'", "'", ",", True)
        End If
        FHPGD_PendingSaleChallan = StrRtn

        FRH_Multiple = Nothing
    End Function

    'Private Sub FPostInPurchChallan(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    '    Dim I As Integer = 0, Cnt As Integer = 0
    '    Dim bSelectionQry$ = ""



    '    For I = 0 To Dgl1.Rows.Count - 1
    '        If Dgl1.Item(Col1PurchChallan, I).Value = "" Then
    '            mQry = " INSERT INTO PurchChallan(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, ReferenceNo, Vendor, " & _
    '                    " Currency, SalesTaxGroupParty, Structure, BillingType, VendorDocNo, VendorDocDate, Form, FormNo,  " & _
    '                    " Remarks, TotalQty, TotalMeasure, TotalAmount, EntryBy, EntryDate, EntryType,  " & _
    '                    " EntryStatus, ApproveBy, ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status, Godown) " & _
    '                    " SELECT DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, ReferenceNo, Vendor,  " & _
    '                    " Currency, SalesTaxGroupParty, Structure, BillingType, VendorDocNo, VendorDocDate, Form, FormNo,  " & _
    '                    " Remarks, TotalQty, TotalMeasure, TotalAmount, EntryBy, EntryDate, EntryType,  " & _
    '                    " EntryStatus, ApproveBy, ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status, Godown " & _
    '                    " FROM PurchInvoice  " & _
    '                    " Where DocId = '" & mSearchCode & "'"
    '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '            Call FPostInPurchChallanDetail(Conn, Cmd)
    '        ElseIf Dgl1.Item(Col1PurchChallan, I).Tag = mSearchCode Then
    '            mQry = " UPDATE PurchChallan " & _
    '                        " SET   " & _
    '                        " PurchChallan.V_Date = PurchInvoice.V_Date,  " & _
    '                        " PurchChallan.ReferenceNo = PurchInvoice.ReferenceNo,  " & _
    '                        " PurchChallan.Vendor = PurchInvoice.Vendor,  " & _
    '                        " PurchChallan.Currency = PurchInvoice.Currency,  " & _
    '                        " PurchChallan.SalesTaxGroupParty = PurchInvoice.SalesTaxGroupParty,  " & _
    '                        " PurchChallan.Structure = PurchInvoice.Structure,  " & _
    '                        " PurchChallan.BillingType = PurchInvoice.BillingType,  " & _
    '                        " PurchChallan.VendorDocNo = PurchInvoice.VendorDocNo,  " & _
    '                        " PurchChallan.VendorDocDate = PurchInvoice.VendorDocDate,  " & _
    '                        " PurchChallan.Form = PurchInvoice.Form,  " & _
    '                        " PurchChallan.FormNo = PurchInvoice.FormNo,  " & _
    '                        " PurchChallan.Godown = PurchInvoice.Godown,  " & _
    '                        " PurchChallan.Remarks = PurchInvoice.Remarks,  " & _
    '                        " PurchChallan.TotalQty = PurchInvoice.TotalQty,  " & _
    '                        " PurchChallan.TotalMeasure = PurchInvoice.TotalMeasure,  " & _
    '                        " PurchChallan.TotalAmount = PurchInvoice.TotalAmount,  " & _
    '                        " PurchChallan.EntryBy = PurchInvoice.EntryBy,  " & _
    '                        " PurchChallan.EntryDate = PurchInvoice.EntryDate,  " & _
    '                        " PurchChallan.EntryType = PurchInvoice.EntryType,  " & _
    '                        " PurchChallan.EntryStatus = PurchInvoice.EntryStatus,  " & _
    '                        " PurchChallan.ApproveBy = PurchInvoice.ApproveBy,  " & _
    '                        " PurchChallan.ApproveDate = PurchInvoice.ApproveDate,  " & _
    '                        " PurchChallan.MoveToLog = PurchInvoice.MoveToLog,  " & _
    '                        " PurchChallan.MoveToLogDate = PurchInvoice.MoveToLogDate,  " & _
    '                        " PurchChallan.IsDeleted = PurchInvoice.IsDeleted,  " & _
    '                        " PurchChallan.Status = PurchInvoice.Status  " & _
    '                        " From PurchInvoice " & _
    '                        " Where PurchChallan.DocId = PurchInvoice.DocId " & _
    '                        " And PurchChallan.DocId = '" & mSearchCode & "'"
    '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '            mQry = " Delete From PurchChallanDetail Where DocId = '" & mSearchCode & "' "
    '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '            mQry = " Delete From Stock Where DocId = '" & mSearchCode & "' "
    '            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '            Call FPostInPurchChallanDetail(Conn, Cmd)
    '        End If
    '    Next
    'End Sub

    'Private Sub FPostInPurchChallanDetail(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
    '    mQry = "Insert Into PurchChallanDetail(DocId, Sr, PurchChallan, PurchChallanSr, PurchInvoice, PurchInvoiceSr, " & _
    '            " Item_Uid, Item, BaleNo, SalesTaxGroupItem, " & _
    '            " DocQty, FreeQty, RejQty, Qty, Unit, MeasurePerPcs, PcsPerMeasure, MeasureUnit, TotalDocMeasure, TotalFreeMeasure, TotalRejMeasure, " & _
    '            " TotalMeasure, Rate, Amount, Remark, Deal, ExpiryDate, BillingType, " & _
    '            " DeliveryMeasure, DeliveryMeasureMultiplier, TotalDocDeliveryMeasure, TotalFreeDeliveryMeasure, TotalRejDeliveryMeasure, " & _
    '            " TotalDeliveryMeasure, " & AgCalcGrid1.FLineTableFieldNameStr() & ") " & _
    '            " Select DocId, Sr, DocId, Sr, PurchInvoice, PurchInvoiceSr, " & _
    '            " Item_Uid, Item, BaleNo, SalesTaxGroupItem, " & _
    '            " DocQty, FreeQty, RejQty, Qty, Unit, MeasurePerPcs, PcsPerMeasure, MeasureUnit, TotalDocMeasure, TotalFreeMeasure, TotalRejMeasure, " & _
    '            " TotalMeasure, Rate, Amount, Remark, Deal, ExpiryDate, BillingType, " & _
    '            " DeliveryMeasure, DeliveryMeasureMultiplier, TotalDocDeliveryMeasure, TotalFreeDeliveryMeasure, TotalRejDeliveryMeasure, " & _
    '            " TotalDeliveryMeasure, " & AgCalcGrid1.FLineTableFieldNameStr() & " " & _
    '            " FROM PurchInvoiceDetail L  " & _
    '            " Where L.DocId = '" & mSearchCode & "'"
    '    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '    mQry = " INSERT INTO  Stock(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code,   " & _
    '            " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item,  " & _
    '            " Godown, Qty_Iss, Qty_Rec, Unit, LotNo, MeasurePerPcs, Measure_Iss, Measure_Rec, MeasureUnit, " & _
    '            " Rate, Amount, NetAmount, Remarks, RecId, ReferenceDocId, ReferenceDocIdSr, ExpiryDate) " & _
    '            " SELECT L.DocId, L.Sr, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
    '            " H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, H.BillingType, L.Item, H.Godown, 0, L.Qty, " & _
    '            " L.Unit, L.LotNo, L.MeasurePerPcs,0, L.TotalMeasure, L.MeasureUnit, L.Rate, L.Amount, L.Amount, " & _
    '            " L.Remark, H.ReferenceNo, L.DocId, L.Sr, L.ExpiryDate " & _
    '            " FROM PurchChallanDetail L  " & _
    '            " LEFT JOIN PurchChallan H ON L.DocId = H.DocID " & _
    '            " Where L.DocId = '" & mSearchCode & "'"
    '    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    '    mQry = " UPDATE PurchInvoiceDetail " & _
    '            " Set " & _
    '            " PurchChallan = DocId, " & _
    '            " PurchChallanSr = Sr " & _
    '            " Where DocId = '" & mSearchCode & "'"
    '    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    'End Sub

    Private Sub FPostInPurchChallan(ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Dim I As Integer = 0, Cnt As Integer = 0
        Dim bSelectionQry$ = ""

        mQry = " UPDATE PurchInvoiceDetail " & _
                " Set " & _
                " PurchChallan = NULL, " & _
                " PurchChallanSr = NULL " & _
                " Where DocId = '" & mSearchCode & "' " & _
                " And PurchChallan = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Select Count(*) From PurchInvoiceDetail L With (NoLock) Where L.DocId = '" & mSearchCode & "' And L.PurchChallan Is Null "
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) > 0 Then


            mQry = " Select Count(*) From PurchChallan  With (NoLock) Where DocId = '" & mSearchCode & "' "
            If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) > 0 Then
                mQry = " Update dbo.PurchChallan " & _
                       " SET DocID = PurchInvoice.docid, " & _
                       " 	V_Type = PurchInvoice.v_type," & _
                       " 	V_Prefix = PurchInvoice.v_prefix, " & _
                       " 	V_Date = PurchInvoice.v_date, " & _
                       " 	V_No = PurchInvoice.v_no, " & _
                       " 	Div_Code = PurchInvoice.div_code, " & _
                       " 	Site_Code = PurchInvoice.site_code, " & _
                       " 	ReferenceNo = PurchInvoice.referenceno, " & _
                       " 	Vendor = PurchInvoice.vendor, " & _
                       " 	PurchOrder = PurchInvoice.purchorder, " & _
                       " 	Currency = PurchInvoice.currency, " & _
                       " 	SalesTaxGroupParty = PurchInvoice.salestaxgroupparty, " & _
                       " 	Structure = PurchInvoice.structure, " & _
                       " 	BillingType = PurchInvoice.billingtype, " & _
                       " 	VendorDocNo = PurchInvoice.vendordocno, " & _
                       " 	VendorDocDate = PurchInvoice.vendordocdate, " & _
                       " 	Form = PurchInvoice.form, " & _
                       " 	FormNo = PurchInvoice.formno, " & _
                       " 	Godown = PurchInvoice.godown, " & _
                       " 	Remarks = PurchInvoice.remarks, " & _
                       " 	TotalQty = PurchInvoice.totalqty, " & _
                       " 	TotalMeasure = PurchInvoice.totalmeasure, " & _
                       " 	TotalAmount = PurchInvoice.totalamount, " & _
                       " 	EntryBy = PurchInvoice.entryby, " & _
                       " 	EntryDate = PurchInvoice.entrydate, " & _
                       " 	EntryType = PurchInvoice.entrytype, " & _
                       " 	EntryStatus = PurchInvoice.entrystatus, " & _
                       " 	ApproveBy = PurchInvoice.approveby, " & _
                       " 	ApproveDate = PurchInvoice.approvedate, " & _
                       " 	MoveToLog = PurchInvoice.movetolog, " & _
                       " 	MoveToLogDate = PurchInvoice.movetologdate, " & _
                       " 	IsDeleted = PurchInvoice.isdeleted, " & _
                       " 	Status = PurchInvoice.status, " & _
                       " 	UID = PurchInvoice.uid, " & _
                       " 	CustomFields = PurchInvoice.customfields, " & _
                       "    FROM PurchInvoice  " & _
                       "    WHERE PurchChallan.DocID = PurchInvoice.DocID " & _
                       "    And PurchInvoice.DocID ='" & mSearchCode & "'    "
            Else
                mQry = " INSERT INTO PurchChallan(DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, ReferenceNo, Vendor, " & _
                        " Currency, SalesTaxGroupParty, Structure, BillingType, VendorDocNo, VendorDocDate, Form, FormNo,  " & _
                        " Remarks, TotalQty, TotalMeasure, TotalAmount, EntryBy, EntryDate, EntryType,  " & _
                        " EntryStatus, ApproveBy, ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status, Godown) " & _
                        " SELECT DocID, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code, ReferenceNo, Vendor,  " & _
                        " Currency, SalesTaxGroupParty, Structure, BillingType, VendorDocNo, VendorDocDate, Form, FormNo,  " & _
                        " Remarks, TotalQty, TotalMeasure, TotalAmount, EntryBy, EntryDate, EntryType,  " & _
                        " EntryStatus, ApproveBy, ApproveDate, MoveToLog, MoveToLogDate, IsDeleted, Status, Godown " & _
                        " FROM PurchInvoice  " & _
                        " Where DocId = '" & mSearchCode & "'"
                AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
            End If

        End If


        mQry = "Delete PurchChallanDetail " & _
               "FROM PurchChallanDetail " & _
               "LEFT JOIN PurchInvoiceDetail ON PurchChallanDetail.DocId = PurchInvoiceDetail.PurchChallan AND Purchchallandetail.Sr = PurchInvoiceDetail.PurchChallanSr " & _
               "WHERE PurchChallanDetail.DocId + Convert(Varchar,Purchchallandetail.Sr) <> PurchInvoiceDetail.PurchChallan + Convert(Varchar, PurchInvoiceDetail.PurchChallanSr) " & _
               "AND PurchInvoiceDetail.DocId ='" & mSearchCode & "' And PurchChallanDetail.DocID ='" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)



        'mQry = "UPDATE dbo.PurchChallanDetail " & _
        '            "   SET PurchOrder = PurchInvoiceDetail.purchorder, " & _
        '            " 	PurchOrderSr = PurchInvoiceDetail.purchordersr, " & _
        '            " 	Item = PurchInvoiceDetail.item, " & _
        '            " 	Specification = PurchInvoiceDetail.specification, " & _
        '            " 	SalesTaxGroupItem = PurchInvoiceDetail.salestaxgroupitem, " & _
        '            " 	DocQty = PurchInvoiceDetail.docqty, " & _
        '            " 	RejQty = PurchInvoiceDetail.rejqty, " & _
        '            " 	Qty = PurchInvoiceDetail.qty, " & _
        '            " 	Unit = PurchInvoiceDetail.unit, " & _
        '            " 	MeasurePerPcs = PurchInvoiceDetail.measureperpcs, " & _
        '            " 	MeasureUnit = PurchInvoiceDetail.measureunit, " & _
        '            " 	TotalDocMeasure = PurchInvoiceDetail.totaldocmeasure, " & _
        '            " 	TotalRejMeasure = PurchInvoiceDetail.totalrejmeasure, " & _
        '            " 	TotalMeasure = PurchInvoiceDetail.totalmeasure, " & _
        '            " 	Rate = PurchInvoiceDetail.rate, " & _
        '            " 	Amount = PurchInvoiceDetail.amount, " & _
        '            " 	LotNo = PurchInvoiceDetail.lotno, " & _
        '            " 	BaleNo = PurchInvoiceDetail.baleno, " & _
        '            " 	Remark = PurchInvoiceDetail.remark, " & _
        '            " 	UID = PurchInvoiceDetail.uid, " & _
        '            " 	DeliveryMeasure = PurchInvoiceDetail.deliverymeasure, " & _
        '            " 	DeliveryMeasureMultiplier = PurchInvoiceDetail.deliverymeasuremultiplier, " & _
        '            " 	TotalDocDeliveryMeasure = PurchInvoiceDetail.totaldocdeliverymeasure, " & _
        '            " 	TotalRejDeliveryMeasure = PurchInvoiceDetail.totalrejdeliverymeasure, " & _
        '            " 	TotalDeliveryMeasure = PurchInvoiceDetail.totaldeliverymeasure, " & _
        '            " 	PcsPerMeasure = PurchInvoiceDetail.pcspermeasure, " & _
        '            " 	Item_Uid = PurchInvoiceDetail.item_uid, " & _
        '            " 	BillingType = PurchInvoiceDetail.billingtype, " & _
        '            " 	FreeQty = PurchInvoiceDetail.freeqty, " & _
        '            " 	ExpiryDate = PurchInvoiceDetail.expirydate, " & _
        '            " 	TotalFreeMeasure = PurchInvoiceDetail.totalfreemeasure, " & _
        '            " 	TotalFreeDeliveryMeasure = PurchInvoiceDetail.totalfreedeliverymeasure, " & _
        '            "   Deal = PurchInvoiceDetail.deal, " & _
        '            "   Sale_Rate = PurchInvoiceDetail.Sale_Rate, " & _
        '            "   MRP = PurchInvoiceDetail.MRP, " & _
        '            "   Landed_Value = PurchInvoiceDetail.Landed_Value " & _
        '            "   FROM PurchInvoiceDetail " & _
        '            "   WHERE PurchChallanDetail.DocId = IsNull(PurchInvoiceDetail.PurchChallan,PurchInvoiceDetail.DocID) " & _
        '            "   AND PurchChallanDetail.Sr = IsNull(PurchInvoiceDetail.PurchChallanSr,PurchInvoiceDetail.Sr)  " & _
        '            "   AND PurchInvoiceDetail.DocId ='" & mSearchCode & "' "
        'AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        mQry = "Insert Into PurchChallanDetail(DocId, Sr, PurchChallan, PurchChallanSr, " & _
                " Item_Uid, Item, BaleNo, SalesTaxGroupItem, " & _
                " DocQty, FreeQty, RejQty, Qty, Unit, MeasurePerPcs, PcsPerMeasure, MeasureUnit, TotalDocMeasure, TotalFreeMeasure, TotalRejMeasure, " & _
                " TotalMeasure, Rate, Amount, Remark, Deal, ExpiryDate, BillingType, " & _
                " DeliveryMeasure, DeliveryMeasureMultiplier, TotalDocDeliveryMeasure, TotalFreeDeliveryMeasure, TotalRejDeliveryMeasure, " & _
                " TotalDeliveryMeasure, Landed_Value) " & _
                " Select L.DocId, L.Sr, L.DocId, L.Sr, " & _
                " L.Item_Uid, L.Item, L.BaleNo, L.SalesTaxGroupItem, " & _
                " L.DocQty, L.FreeQty, L.RejQty, L.Qty, L.Unit, L.MeasurePerPcs, L.PcsPerMeasure, L.MeasureUnit, L.TotalDocMeasure, L.TotalFreeMeasure, L.TotalRejMeasure, " & _
                " L.TotalMeasure, L.Rate, L.Amount, L.Remark, L.Deal, L.ExpiryDate, L.BillingType, " & _
                " L.DeliveryMeasure, L.DeliveryMeasureMultiplier, L.TotalDocDeliveryMeasure, L.TotalFreeDeliveryMeasure, L.TotalRejDeliveryMeasure, " & _
                " L.TotalDeliveryMeasure, L.Landed_Value " & _
                " FROM PurchInvoiceDetail L " & _
                " Left Join PurchChallanDetail CD On IsNull(L.PurchChallan, L.DocID) = CD.DocID and IsNull(L.PurchChallanSr, L.Sr) = Cd.Sr   " & _
                " Where L.DocId = '" & mSearchCode & "' And CD.DocID Is Null "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        mQry = " Select Count(*) From PurchChallan H With (NoLock) Where H.DocId = '" & mSearchCode & "' And H.Structure = '" & TxtStructure.Tag & "' "
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) > 0 Then
            mQry = "UPDATE dbo.PurchChallanDetail " & _
                        "   SET  " & _
                        "   " & AgCalcGrid1.FLineTableFieldNameStr("", "= PurchInvoiceDetail.") & " " & _
                        "   FROM PurchInvoiceDetail " & _
                        "   WHERE PurchChallanDetail.DocId = IsNull(PurchInvoiceDetail.PurchChallan,PurchInvoiceDetail.DocID) " & _
                        "   AND PurchChallanDetail.Sr = IsNull(PurchInvoiceDetail.PurchChallanSr,PurchInvoiceDetail.Sr)  " & _
                        "   AND PurchInvoiceDetail.DocId ='" & mSearchCode & "' "
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If



        'End If

        mQry = " Delete Stock " & _
               " From Stock " & _
               " Left Join PurchChallanDetail On Stock.DocID = PurchChallanDetail.DocID And Stock.Sr = PurchChallanDetail.Sr " & _
               " Left Join PurchInvoiceDetail On PurchChallanDetail.DocID = IsNull(PurchInvoiceDetail.PurchChallan, PurchInvoiceDetail.DocID) And PurchChallanDetail.Sr = IsNull(PurchInvoiceDetail.PurchChallanSr, PurchInvoiceDetail.Sr)  " & _
               " Where PurchInvoiceDetail.DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)


        mQry = " INSERT INTO  Stock(DocID, Sr, V_Type, V_Prefix, V_Date, V_No, Div_Code, Site_Code,   " & _
                " SubCode, Currency, SalesTaxGroupParty, Structure, BillingType, Item,  " & _
                " Godown,EType_IR, Qty_Iss, Qty_Rec, Unit, LotNo, MeasurePerPcs, Measure_Iss, Measure_Rec, MeasureUnit, " & _
                " Rate, Amount, Landed_Value, Remarks, RecId, ReferenceDocId, ReferenceDocIdSr, ExpiryDate, Sale_Rate, MRP) " & _
                " SELECT L.DocId, L.Sr, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, " & _
                " H.Vendor, H.Currency, H.SalesTaxGroupParty, H.Structure, H.BillingType, L.Item, H.Godown,'R', 0, L.Qty, " & _
                " L.Unit, L.LotNo, L.MeasurePerPcs,0, L.TotalMeasure, L.MeasureUnit, L.Landed_Value/L.Qty, L.Landed_Value, L.Landed_Value, " & _
                " L.Remark, H.ReferenceNo, L.DocId, L.Sr, L.ExpiryDate, L.Sale_Rate, L.MRP " & _
                " FROM PurchChallanDetail L  " & _
                " LEFT JOIN PurchChallan H ON L.DocId = H.DocID " & _
                " Left Join PurchInvoiceDetail PID On L.DocID = IsNull(PID.PurchChallan, PID.DocID) And L.Sr = IsNull(PID.PurchChallanSr, PID.Sr)  " & _
                " Where PID.DocId = '" & mSearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " UPDATE PurchInvoiceDetail " & _
                " Set " & _
                " PurchChallan = DocId, " & _
                " PurchChallanSr = Sr " & _
                " Where DocId = '" & mSearchCode & "' " & _
                " And PurchChallan Is Null "
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

    End Sub

    Private Sub RbtInvoiceDirect_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RbtInvoiceDirect.Click, RbtInvoiceForChallan.Click
        Try
            Select Case sender.Name
                Case RbtInvoiceDirect.Name
                    BtnFillPurchChallan.Enabled = False

                Case RbtInvoiceForChallan.Name
                    BtnFillPurchChallan.Enabled = True
            End Select
            Dgl1.AgHelpDataSet(Col1Item) = Nothing
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmPurchInvoice_BaseEvent_Topctrl_tbRef() Handles Me.BaseEvent_Topctrl_tbRef
        Try
            If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Item).Dispose() : Dgl1.AgHelpDataSet(Col1Item) = Nothing
        Catch ex As Exception
        End Try
        Try
            If Dgl1.AgHelpDataSet(Col1BillingType) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1BillingType).Dispose() : Dgl1.AgHelpDataSet(Col1BillingType) = Nothing
        Catch ex As Exception
        End Try
        Try
            If Dgl1.AgHelpDataSet(Col1ItemCode) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1ItemCode).Dispose() : Dgl1.AgHelpDataSet(Col1ItemCode) = Nothing
        Catch ex As Exception
        End Try
        If TxtCurrency.AgHelpDataSet IsNot Nothing Then TxtCurrency.AgHelpDataSet.Dispose() : TxtCurrency.AgHelpDataSet = Nothing
        If TxtVendor.AgHelpDataSet IsNot Nothing Then TxtVendor.AgHelpDataSet.Dispose() : TxtVendor.AgHelpDataSet = Nothing
        If TxtSalesTaxGroupParty.AgHelpDataSet IsNot Nothing Then TxtSalesTaxGroupParty.AgHelpDataSet.Dispose() : TxtSalesTaxGroupParty.AgHelpDataSet = Nothing
    End Sub

    Private Sub FrmPurchInvoice_StoreItem_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        mQry = " SELECT H.DocID, H.V_Type, H.V_Date, H.ReferenceNo, " & _
                    " H.Currency, H.SalesTaxGroupParty, H.BillingType, H.VendorDocNo, H.VendorDocDate,  " & _
                    " H.Form, H.FormNo, H.Remarks, H.EntryBy, H.EntryDate, H.ApproveBy, H.ApproveDate, " & _
                    " L.DocId, L.Sr, L.Item, L.Specification, L.SalesTaxGroupItem, L.DocQty, L.RejQty, L.Qty, L.Unit,  " & _
                    " L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalRejMeasure, L.TotalMeasure, L.Rate, L.Amount, L.Remark, L.LotNo, " & _
                    " SG.DispName AS VendorName, Sg.Add1, Sg.Add2, Sg.Add3, Sg.Mobile As VendorMobile, " & _
                    " City.CityName As VendorCityName, I.Description AS ItemDesc, C.ReferenceNo as PurchChallanNo, PO.ReferenceNo as PurchOrderNo,  " & _
                    " " & AgCalcGrid1.FLineTableFieldNameStr("L.", "L_") & " " & _
                    " " & AgCustomGrid1.FHeaderTableFieldNameStr("H.", "H_") & " " & _
                    " FROM (SELECT * FROM PurchInvoice WHERE DocId = '" & mSearchCode & "') AS H  " & _
                    " LEFT JOIN (SELECT * FROM PurchInvoiceDetail WHERE DocId ='" & mSearchCode & "') AS  L ON H.DocID = L.DocId  " & _
                    " LEFT JOIN SubGroup Sg ON H.Vendor = Sg.SubCode " & _
                    " LEFT JOIN PurchChallan C ON L.PurchChallan = C.DocID " & _
                    " LEFT JOIN PurchOrder PO ON L.PurchOrder = PO.DocID " & _
                    " LEFT JOIN Item I ON L.Item = I.Code  " & _
                    " LEFT JOIN City ON Sg.CityCode = City.CityCode " & _
                    " Where H.DocId = '" & mSearchCode & "'"
        ClsMain.FPrintThisDocument(Me, TxtV_Type.Tag, mQry, "PurchInvoice_Print", "Purchase Invoice")
    End Sub

    Private Sub TxtDescription_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtRemarks.KeyDown
        'If e.KeyCode = Keys.Enter Then
        '    If MsgBox("Do you want to save?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Save") = MsgBoxResult.Yes Then
        '        Topctrl1.FButtonClick(13)
        '    End If
        'End If
    End Sub

    Private Function AccountPosting() As Boolean
        Dim LedgAry() As AgLibrary.ClsMain.LedgRec
        Dim I As Integer, J As Integer = 0
        Dim DsTemp As DataSet = Nothing
        Dim mNarr As String = "", mCommonNarr$ = ""
        Dim mNetAmount As Double, mRoundOff As Double = 0
        Dim GcnRead As SqlClient.SqlConnection
        GcnRead = New SqlClient.SqlConnection
        GcnRead.ConnectionString = AgL.Gcn_ConnectionString
        GcnRead.Open()

        mNetAmount = 0
        mCommonNarr = ""
        mCommonNarr = ""
        If mCommonNarr.Length > 255 Then mCommonNarr = AgL.MidStr(mCommonNarr, 0, 255)

        ReDim Preserve LedgAry(I)
        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = AgL.XNull(AgL.PubDtEnviro.Rows(0)("PurchaseAc"))
        LedgAry(I).ContraSub = TxtVendor.AgSelectedValue
        LedgAry(I).AmtCr = 0
        LedgAry(I).AmtDr = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        If mNarr.Length > 255 Then mNarr = AgL.MidStr(mNarr, 0, 255)
        LedgAry(I).Narration = mNarr

        I = UBound(LedgAry) + 1
        ReDim Preserve LedgAry(I)
        LedgAry(I).SubCode = TxtVendor.AgSelectedValue
        LedgAry(I).ContraSub = AgL.XNull(AgL.PubDtEnviro.Rows(0)("PurchaseAc"))
        LedgAry(I).AmtCr = Val(AgCalcGrid1.AgChargesValue(AgTemplate.ClsMain.Charges.NETAMOUNT, AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount))
        LedgAry(I).AmtDr = 0
        LedgAry(I).Narration = mNarr

        If AgL.PubManageOfflineData Then
            If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GcnSite, AgL.ECmdSite, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.GcnSite_ConnectionString) = False Then
                AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
            Else
            End If
        End If

        If AgL.LedgerPost(AgL.MidStr(Topctrl1.Mode, 0, 1), LedgAry, AgL.GCn, AgL.ECmd, mSearchCode, CDate(TxtV_Date.Text), AgL.PubUserName, AgL.PubLoginDate, mCommonNarr, , AgL.Gcn_ConnectionString) = False Then
            AccountPosting = False : Err.Raise(1, , "Error in Ledger Posting")
        End If
        GcnRead.Close()
        GcnRead.Dispose()
    End Function

    Private Sub Dgl1_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.EditingControl_KeyDown
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            If Dgl1.CurrentCell Is Nothing Then Exit Sub
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                'Case Col1ItemCode
                '    If e.KeyCode = Keys.Insert Then Call FOpenItemMaster()
                '    If Dgl1.AgHelpDataSet(Col1ItemCode) Is Nothing Then
                '        mQry = "SELECT I.Code, I.ManualCode, I.Description, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                '               " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                '               " I.MeasureUnit, I.Measure As MeasurePerPcs, I.Rate As Rate, 1 As PendingQty, I.Status, " & _
                '               " U.DecimalPlaces as QtyDecimalPlaces, U1.DecimalPlaces as MeasureDecimalPlaces " & _
                '               " FROM Item I " & _
                '               " LEFT JOIN Unit U On I.Unit = U.Code " & _
                '               " LEFT JOIN Unit U1 On I.MeasureUnit = U1.Code " & _
                '               " Where I.ItemType IN ('" & mItemType & "') " & _
                '               " And IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                '        Dgl1.AgHelpDataSet(Col1ItemCode, 13) = AgL.FillData(mQry, AgL.GCn)
                '    End If


                'Case Col1Item
                '    If e.KeyCode = Keys.Insert Then Call FOpenItemMaster()
                '    If Dgl1.AgHelpDataSet(Col1Item) Is Nothing Then
                '        mQry = "SELECT I.Code, I.Description, I.ManualCode, I.Unit, I.ItemType, I.SalesTaxPostingGroup , " & _
                '               " IsNull(I.IsDeleted ,0) AS IsDeleted, I.Div_Code, " & _
                '               " I.MeasureUnit, I.Measure As MeasurePerPcs, I.Rate As Rate, 1 As PendingQty, I.Status, " & _
                '               " U.DecimalPlaces as QtyDecimalPlaces, U1.DecimalPlaces as MeasureDecimalPlaces " & _
                '               " FROM Item I " & _
                '               " LEFT JOIN Unit U On I.Unit = U.Code " & _
                '               " LEFT JOIN Unit U1 On I.MeasureUnit = U1.Code " & _
                '               " Where I.ItemType IN ('" & mItemType & "') " & _
                '               " And IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                '        Dgl1.AgHelpDataSet(Col1Item, 13) = AgL.FillData(mQry, AgL.GCn)
                '    End If

                Case Col1Item
                    If e.KeyCode = Keys.Insert Then Call FOpenItemMaster()
                    If Dgl1.AgHelpDataSet(Col1Item) Is Nothing Then
                        If RbtInvoiceForChallan.Checked = True Then
                            mQry = "SELECT Max(L.Item) As Code, Max(I.Description) as Description, " & _
                                    " Max(H.V_Type) + '-' +  Max(H.ReferenceNo) AS ChallanNo,   " & _
                                    " Max(H.V_Date) as ChallanDate, Sum(L.Qty) - IsNull(Sum(Cd.Qty), 0) as [Bal.Qty],   " & _
                                    " Max(L.Unit) as Unit, Max(L.Rate) as Rate,  " & _
                                    " Max(I.ManualCode) as ManualCode,  " & _
                                    " Max(L.SalesTaxGroupItem) SalesTaxPostingGroup, L.PurchChallan, L.PurchChallanSr, " & _
                                    " Max(L.MeasurePerPcs) As MeasurePerPcs,  Max(L.MeasureUnit) As MeasureUnit, Max(L.Deal) as Deal, Max(L.ProfitMarginPer) as ProfitMarginPer, Max(L.Mrp) as Mrp, Max(L.Sale_Rate) as Sale_Rate, max(L.ExpiryDate) as ExpiryDate, " & _
                                    " Max(U.DecimalPlaces) As QtyDecimalPlaces, Max(U1.DecimalPlaces) As MeasureDecimalPlaces   " & _
                                    " FROM (  " & _
                                    "    SELECT DocID, V_Type, ReferenceNo, V_Date   " & _
                                    "    FROM PurchChallan With (nolock)   " & _
                                    "    WHERE Vendor='" & TxtVendor.Tag & "' " & _
                                    "    And Div_Code = '" & TxtDivision.Tag & "' " & _
                                    "    AND Site_Code = '" & TxtSite_Code.Tag & "' " & _
                                    "    AND V_Date<='" & TxtV_Date.Text & "'" & _
                                    " ) AS  H   " & _
                                    " LEFT JOIN PurchChallanDetail L With (nolock) ON H.DocID = L.DocId    " & _
                                    " Left Join Item I With (NoLock) On L.Item  = I.Code   " & _
                                    " LEFT JOIN Voucher_Type Vt With (nolock) ON H.V_Type = Vt.V_Type    " & _
                                    " Left Join (   " & _
                                    "    SELECT L.PurchChallan, L.PurchChallanSr, Sum (L.Qty) AS Qty  " & _
                                    "    FROM PurchInvoiceDetail L  With (nolock)   " & _
                                    "    GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                                    " ) AS CD ON L.DocId = CD.PurchChallan AND L.Sr = CD.PurchChallanSr " & _
                                    " LEFT JOIN Unit U On L.Unit = U.Code   " & _
                                    " LEFT JOIN Unit U1 On L.MeasureUnit = U1.Code   " & _
                                    " WHERE L.Qty - IsNull(Cd.Qty, 0) > 0  " & _
                                    " GROUP BY L.PurchChallan, L.PurchChallanSr "
                            Dgl1.AgHelpDataSet(Col1Item, 8) = AgL.FillData(mQry, AgL.GCn)
                        Else
                            mQry = "SELECT I.Code, I.Description, I.ManualCode, '' As ChallanNo, '' As ChallanDate, " & _
                                    " 0 As [Bal.Qty], I.Unit,0 As Rate, I.SalesTaxPostingGroup , " & _
                                    " '' As PurchChallan, 0 As PurchChallanSr, " & _
                                    " I.Measure As MeasurePerPcs, I.MeasureUnit, " & _
                                    " U.DecimalPlaces as QtyDecimalPlaces, U1.DecimalPlaces as MeasureDecimalPlaces, " & _
                                    " 0 As Qty " & _
                                    " FROM Item I " & _
                                    " LEFT JOIN Unit U On I.Unit = U.Code " & _
                                    " LEFT JOIN Unit U1 On I.MeasureUnit = U1.Code " & _
                                    " Where 1=1 " & _
                                    " And IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            Dgl1.AgHelpDataSet(Col1Item, 14) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case Col1ItemCode
                    If Dgl1.AgHelpDataSet(Col1ItemCode) Is Nothing Then
                        If RbtInvoiceForChallan.Checked = True Then
                            mQry = "SELECT Max(L.Item) As Code, Max(I.ManualCode) as ManualCode,  Max(I.Description) as Description, " & _
                                    " Max(H.V_Type) + '-' +  Max(H.ReferenceNo) AS ChallanNo,   " & _
                                    " Max(H.V_Date) as ChallanDate, Sum(L.Qty) - IsNull(Sum(Cd.Qty), 0) as [Bal.Qty],   " & _
                                    " Max(L.Unit) as Unit, Max(L.Rate) as Rate,  " & _
                                    " Max(L.SalesTaxGroupItem) SalesTaxPostingGroup, L.PurchChallan, L.PurchChallanSr, " & _
                                    " Max(L.MeasurePerPcs) As MeasurePerPcs,  Max(L.MeasureUnit) As MeasureUnit, Max(L.Deal) as Deal, Max(L.ProfitMarginPer) as ProfitMarginPer, Max(L.Mrp) as Mrp, Max(L.Sale_Rate) as Sale_Rate, max(L.ExpiryDate) as ExpiryDate, " & _
                                    " Max(U.DecimalPlaces) As QtyDecimalPlaces, Max(U1.DecimalPlaces) As MeasureDecimalPlaces   " & _
                                    " FROM (  " & _
                                    "    SELECT DocID, V_Type, ReferenceNo, V_Date   " & _
                                    "    FROM PurchChallan With (nolock)   " & _
                                    "    WHERE Vendor='" & TxtVendor.Tag & "' " & _
                                    "    And Div_Code = '" & TxtDivision.Tag & "' " & _
                                    "    AND Site_Code = '" & TxtSite_Code.Tag & "' " & _
                                    "    AND V_Date<='" & TxtV_Date.Text & "'" & _
                                    " ) AS  H   " & _
                                    " LEFT JOIN PurchChallanDetail L With (nolock) ON H.DocID = L.DocId    " & _
                                    " Left Join Item I With (NoLock) On L.Item  = I.Code   " & _
                                    " LEFT JOIN Voucher_Type Vt With (nolock) ON H.V_Type = Vt.V_Type    " & _
                                    " Left Join (   " & _
                                    "    SELECT L.PurchChallan, L.PurchChallanSr, Sum (L.Qty) AS Qty  " & _
                                    "    FROM PurchInvoiceDetail L  With (nolock)   " & _
                                    "    GROUP BY L.PurchChallan, L.PurchChallanSr " & _
                                    " ) AS CD ON L.DocId = CD.PurchChallan AND L.Sr = CD.PurchChallanSr " & _
                                    " LEFT JOIN Unit U On L.Unit = U.Code   " & _
                                    " LEFT JOIN Unit U1 On L.MeasureUnit = U1.Code   " & _
                                    " WHERE L.Qty - IsNull(Cd.Qty, 0) > 0  " & _
                                    " GROUP BY L.PurchChallan, L.PurchChallanSr "
                            Dgl1.AgHelpDataSet(Col1ItemCode, 8) = AgL.FillData(mQry, AgL.GCn)
                        Else
                            mQry = "SELECT I.Code, I.ManualCode, I.Description, '' As ChallanNo, '' As ChallanDate, " & _
                                    " 0 As [Bal.Qty], I.Unit,0 As Rate, I.SalesTaxPostingGroup , " & _
                                    " '' As PurchChallan, 0 As PurchChallanSr, " & _
                                    " I.Measure As MeasurePerPcs, I.MeasureUnit, " & _
                                    " U.DecimalPlaces as QtyDecimalPlaces, U1.DecimalPlaces as MeasureDecimalPlaces, " & _
                                    " 0 As Qty " & _
                                    " FROM Item I " & _
                                    " LEFT JOIN Unit U On I.Unit = U.Code " & _
                                    " LEFT JOIN Unit U1 On I.MeasureUnit = U1.Code " & _
                                    " Where 1=1 " & _
                                    " And IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            Dgl1.AgHelpDataSet(Col1ItemCode, 14) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case Col1BillingType
                    If Dgl1.AgHelpDataSet(Col1BillingType) Is Nothing Then
                        mQry = " SELECT 'Qty' AS Code, 'Qty' AS Name " & _
                            " Union ALL " & _
                            " SELECT 'Doc Qty' AS Code, 'Doc Qty' AS Name " & _
                            " Union ALL " & _
                            " SELECT 'Measure' AS Code, 'Measure' AS Name " & _
                            " Union ALL " & _
                            " SELECT 'Doc Measure' AS Code, 'Doc Measure' AS Name "
                        Dgl1.AgHelpDataSet(Col1BillingType) = AgL.FillData(mQry, AgL.GCn)
                    End If

                Case Col1DeliveryMeasure
                    If Dgl1.AgHelpDataSet(Col1DeliveryMeasure) Is Nothing Then
                        mQry = " SELECT Code, Code AS Description FROM Unit "
                        Dgl1.AgHelpDataSet(Col1DeliveryMeasure) = AgL.FillData(mQry, AgL.GCn)
                    End If
                Case Col1SalesTaxGroup
                    If Dgl1.AgHelpDataSet(Col1SalesTaxGroup) Is Nothing Then
                        mQry = " SELECT Description as Code, Description FROM PostingGroupSalesTaxItem "
                        Dgl1.AgHelpDataSet(Col1SalesTaxGroup) = AgL.FillData(mQry, AgL.GCn)
                    End If

            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Private Sub FOpenMaster(ByVal e As System.Windows.Forms.KeyEventArgs)
    '    Dim FrmObj As Object = Nothing
    '    Dim CFOpen As New ClsFunction
    '    Dim DtTemp As DataTable = Nothing
    '    Try
    '        If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub

    '        If e.KeyCode = Keys.Insert Then
    '            If Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name = Col1Item Then
    '                If Not mItemType.Contains(",") Then
    '                    mQry = " Select MnuName, MnuText From ItemType Where Code = '" & mItemType & "' "
    '                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
    '                    If DtTemp.Rows.Count > 0 Then
    '                        FrmObj = CFOpen.FOpen(DtTemp.Rows(0)("MnuName"), DtTemp.Rows(0)("MnuText"), True)
    '                        If FrmObj IsNot Nothing Then
    '                            FrmObj.MdiParent = Me.MdiParent
    '                            FrmObj.Show()
    '                            FrmObj.Topctrl1.FButtonClick(0)
    '                            FrmObj = Nothing
    '                        End If
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub Validating_Item_Uid(ByVal Item_Uid As String, ByVal mRow As Integer)
        Dim DrTemp As DataRow() = Nothing
        Dim DtTemp As DataTable = Nothing

        Try
            mQry = " SELECT I.Code, I.Description, I.Unit, I.ManualCode, I.MeasureUnit, I.Measure As MeasurePerPcs, " & _
                   " U.DecimalPlaces as QtyDecimalPlaces, MU.DecimalPlaces as MeasureDecimalPlaces, UI.Code as ItemUIDCode " & _
                   " FROM (Select Item, Code From Item_UID Where Item_Uid = '" & Dgl1.Item(Col1Item_UID, mRow).Value & "') UI " & _
                   " Left Join Item I With (NoLock) On UI.Item  = I.Code " & _
                   " Left Join Unit U With (NoLock) On I.Unit = U.Code " & _
                   " Left Join Unit MU With (NoLock) On I.MeasureUnit = MU.Code "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1Item_UID, mRow).Tag = AgL.XNull(DtTemp.Rows(0)("ItemUIDCode"))
                Dgl1.Item(Col1ItemCode, mRow).Tag = AgL.XNull(DtTemp.Rows(0)("Code"))
                Dgl1.Item(Col1ItemCode, mRow).Value = AgL.XNull(DtTemp.Rows(0)("ManualCode"))
                Dgl1.Item(Col1Item, mRow).Tag = AgL.XNull(DtTemp.Rows(0)("Code"))
                Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Description"))
                Dgl1.Item(Col1Qty, mRow).Value = 1
                Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Unit"))
                Dgl1.Item(Col1QtyDecimalPlaces, mRow).Value = AgL.VNull(DtTemp.Rows(0)("QtyDecimalPlaces"))
                Dgl1.Item(Col1MeasurePerPcs, mRow).Value = Format(AgL.VNull(DtTemp.Rows(0)("MeasurePerPcs")), "0.".PadRight(AgL.VNull(DtTemp.Rows(0)("MeasureDecimalPlaces")) + 2, "0"))
                Dgl1.Item(Col1TotalMeasure, mRow).Value = AgL.VNull(DtTemp.Rows(0)("MeasurePerPcs"))
                Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(DtTemp.Rows(0)("MeasureUnit"))
                Dgl1.Item(Col1MeasureDecimalPlaces, mRow).Value = AgL.VNull(DtTemp.Rows(0)("MeasureDecimalPlaces"))
            Else
                MsgBox("Invalid Item UID", MsgBoxStyle.Information)
                Dgl1.Item(Col1Item_UID, mRow).Value = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item_Uid Function ")
        End Try
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
                    Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Description").Value)
                    Dgl1.Item(Col1ItemCode, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value)
                    Dgl1.Item(Col1ItemCode, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("ManualCode").Value)
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Unit").Value)
                    Dgl1.Item(Col1Rate, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Rate").Value)
                    Dgl1.Item(Col1SalesTaxGroup, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                    Dgl1.Item(Col1SalesTaxGroup, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("SalesTaxPostingGroup").Value)
                    If AgL.StrCmp(Dgl1.Item(Col1SalesTaxGroup, mRow).Tag, "") Then
                        Dgl1.Item(Col1SalesTaxGroup, mRow).Tag = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                        Dgl1.Item(Col1SalesTaxGroup, mRow).Value = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                    End If
                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasurePerPcs").Value)
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                    Dgl1.Item(Col1QtyDecimalPlaces, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("QtyDecimalPlaces").Value)
                    Dgl1.Item(Col1MeasureDecimalPlaces, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("MeasureDecimalPlaces").Value)

                    mQry = " Select Top 1 L.Rate, L.MRP From PurchChallanDetail L LEFT JOIN PurchChallan H ON L.DocId = H.DocId Where L.Item = '" & Dgl1.Item(Col1Item, mRow).Tag & "' Order By H.V_Date Desc "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                    If DtTemp.Rows.Count > 0 Then
                        Dgl1.Item(Col1MRP, mRow).Value = AgL.VNull(DtTemp.Rows(0)("MRP"))
                        Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DtTemp.Rows(0)("Rate"))
                    End If

                    mQry = "Select ProfitMarginPer " & _
                           "From Item " & _
                           "Where Code = '" & AgL.XNull(Dgl1.AgDataRow.Cells("Code").Value) & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

                    If DtTemp.Rows.Count > 0 Then
                        Dgl1.Item(Col1ProfitMarginPer, mRow).Value = AgL.VNull(DtTemp.Rows(0)("ProfitMarginPer"))
                    End If


                    If RbtInvoiceDirect.Checked Then FGetPurchChallan(mRow)


                    If RbtInvoiceForChallan.Checked Then
                        Dgl1.Item(Col1Qty, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Bal.Qty").Value)

                        Dgl1.Item(Col1PurchChallan, mRow).Tag = AgL.XNull(Dgl1.AgDataRow.Cells("PurchChallan").Value)
                        Dgl1.Item(Col1PurchChallan, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("ChallanNo").Value)
                        Dgl1.Item(Col1PurchChallanSr, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("PurchChallanSr").Value)


                        Dgl1.Item(Col1DeliveryMeasure, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("MeasureUnit").Value)
                        Dgl1.Item(Col1DeliveryMeasureMultiplier, mRow).Value = 1

                        Dgl1.Item(Col1BillingType, mRow).Value = "Qty"

                        Dgl1.Item(Col1ProfitMarginPer, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("ProfitMarginPer").Value)
                        Dgl1.Item(Col1SaleRate, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Sale_Rate").Value)
                        Dgl1.Item(Col1MRP, mRow).Value = AgL.VNull(Dgl1.AgDataRow.Cells("Mrp").Value)
                        Dgl1.Item(Col1ExpiryDate, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("ExpiryDate").Value)
                        Dgl1.Item(Col1Deal, mRow).Value = AgL.XNull(Dgl1.AgDataRow.Cells("Deal").Value)

                    End If




                    'FGetPurchIndent(Dgl1.Item(Col1Item, mRow).Tag, Dgl1.Item(Col1PurchIndent, mRow).Value)
                End If

                Try
                    Dgl1.Item(Col1BillingType, mRow).Value = Dgl1.Item(Col1BillingType, mRow - 1).Value
                Catch ex As Exception
                End Try
                End If
        Catch ex As Exception
            MsgBox(ex.Message & " On Validating_Item Function ")
        End Try
    End Sub























    Private Sub FGetDeliveryMeasureMultiplier(ByVal mRow As Integer)
        Dim DtTemp As DataTable = Nothing
        Try
            If blnIsCarpetTrans Then
                Dgl1.Item(Col1DeliveryMeasureMultiplier, mRow).Value = 0
                If AgL.StrCmp(Dgl1.Item(Col1DeliveryMeasure, mRow).Value, "SQ.FEET") Then
                    mQry = "Select FeetArea From Rug_Size Size Left Join Rug_CarpetSku Cs On Size.Code = Cs.Size Where Cs.Code = '" & Dgl1.Item(Col1Item, mRow).Tag & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    If DtTemp.Rows.Count > 0 Then
                        Dgl1.Item(Col1DeliveryMeasurePerPcs, mRow).Value = AgL.VNull(DtTemp.Rows(0)(0))
                    End If
                ElseIf AgL.StrCmp(Dgl1.Item(Col1DeliveryMeasure, mRow).Value, "SQ.METER") Then
                    mQry = "Select MeterArea From Rug_Size Size Left Join Rug_CarpetSku Cs On Size.Code = Cs.Size Where Cs.Code = '" & Dgl1.Item(Col1Item, mRow).Tag & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    If DtTemp.Rows.Count > 0 Then
                        Dgl1.Item(Col1DeliveryMeasurePerPcs, mRow).Value = AgL.VNull(DtTemp.Rows(0)(0))
                    End If
                Else
                    mQry = "Select YardArea From Rug_Size Size Left Join Rug_CarpetSku Cs On Size.Code = Cs.Size Where Cs.Code = '" & Dgl1.Item(Col1Item, mRow).Tag & "' "
                    DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                    If DtTemp.Rows.Count > 0 Then
                        Dgl1.Item(Col1DeliveryMeasurePerPcs, mRow).Value = AgL.VNull(DtTemp.Rows(0)(0))
                    End If

                    'Dgl1.Item(Col1DeliveryMeasurePerPcs, mRow).Value = Dgl1.Item(Col1MeasurePerPcs, mRow).Value
                    'Dgl1.Item(Col1DeliveryMeasure, mRow).Value = Dgl1.Item(Col1MeasureUnit, mRow).Value
                    'Dgl1.Item(Col1DeliveryMeasure, mRow).Tag = Dgl1.Item(Col1MeasureUnit, mRow).Tag
                End If
            Else

                If Dgl1.Item(Col1MeasureUnit, mRow).Value <> "" And Dgl1.Item(Col1DeliveryMeasure, mRow).Value <> "" Then
                    If Dgl1.Item(Col1MeasureUnit, mRow).Value = Dgl1.Item(Col1DeliveryMeasure, mRow).Value Then
                        Dgl1.Item(Col1DeliveryMeasureMultiplier, mRow).Value = 1
                    Else
                        mQry = " SELECT Multiplier, Rounding FROM UnitConversion WHERE FromUnit = '" & Dgl1.Item(Col1MeasureUnit, mRow).Value & "' AND ToUnit =  '" & Dgl1.Item(Col1DeliveryMeasure, mRow).Value & "' "
                        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
                        With DtTemp
                            If .Rows.Count > 0 Then
                                Dgl1.Item(Col1DeliveryMeasureMultiplier, mRow).Value = AgL.VNull(.Rows(0)("Multiplier"))
                            Else
                                MsgBox("Define Multiplier In Unit Conversion To Convert " & Dgl1.Item(Col1DeliveryMeasure, mRow).Value & " From " & Dgl1.Item(Col1MeasureUnit, mRow).Value & " ", MsgBoxStyle.Information)
                                Dgl1.Item(Col1DeliveryMeasure, mRow).Value = ""
                            End If
                        End With
                    End If
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TxtCurrency_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtCurrency.KeyDown, TxtVendor.KeyDown, TxtSalesTaxGroupParty.KeyDown, TxtGodown.KeyDown, TxtBillToParty.KeyDown
        Try
            If AgL.StrCmp(Topctrl1.Mode, "Browse") Then Exit Sub
            Select Case sender.name
                Case TxtCurrency.Name
                    If TxtCurrency.AgHelpDataSet Is Nothing Then
                        mQry = "SELECT Code, Code AS Currency, IsNull(IsDeleted,0) AS IsDeleted " & _
                                " FROM Currency " & _
                                " ORDER BY Code "
                        TxtCurrency.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                    End If

                Case TxtVendor.Name
                    If TxtVendor.AgHelpDataSet Is Nothing Then
                        FCreateHelpSubgroup(sender)
                    End If


                Case TxtBillToParty.Name
                    If CType(sender, AgControls.AgTextBox).AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = "SELECT Sg.SubCode As Code, Sg.Name + ',' + IsNull(C.CityName,'') As Account_Name " & _
                                    " FROM SubGroup Sg " & _
                                    " LEFT JOIN City C ON Sg.CityCode = C.CityCode  " & _
                                    " Where IsNull(Sg.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                            CType(sender, AgControls.AgTextBox).AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If


                Case TxtSalesTaxGroupParty.Name
                    If TxtSalesTaxGroupParty.AgHelpDataSet Is Nothing Then
                        mQry = "SELECT Description AS Code, Description, IsNull(Active,0) FROM PostingGroupSalesTaxParty "
                        TxtSalesTaxGroupParty.AgHelpDataSet(1, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                    End If

                Case TxtGodown.Name
                    If TxtGodown.AgHelpDataSet Is Nothing Then
                        mQry = "SELECT H.Code, H.Description " & _
                                " FROM Godown H " & _
                                " Where H.Div_Code = '" & TxtDivision.Tag & "' " & _
                                " And H.Site_Code = '" & TxtSite_Code.Tag & "' " & _
                                " And IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                                " Order By H.Description"
                        TxtGodown.AgHelpDataSet(0, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FCreateHelpSubgroup(ByVal sender As AgControls.AgTextBox)
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

        strCond += " And H.Nature In ('" & ClsMain.SubGroupNature.Customer & "','" & ClsMain.SubGroupNature.Supplier & "','" & ClsMain.SubGroupNature.Cash & "','" & ClsMain.SubGroupNature.Bank & "')"

        mQry = " SELECT H.SubCode, H.DispName + ',' + IsNull(C.CityName,'') AS [Party], " & _
                " H.Currency, C1.Description As CurrencyDesc, H.Nature, H.SalesTaxPostingGroup " & _
                " FROM SubGroup H  " & _
                " LEFT JOIN City C ON H.CityCode = C.CityCode  " & _
                " LEFT JOIN Currency C1 On H.Currency = C1.Code " & _
                " Where IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & strCond
        sender.AgHelpDataSet(4, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FShowLastRates(ByVal Item As String)
        Dim DtTemp As DataTable = Nothing
        Try
            mQry = " SELECT TOP 5 H.V_Date AS [Purch_Date], Sg.DispName As Vendor, L.Item, " & _
                        " L.Rate, L.Qty " & _
                        " FROM PurchInvoiceDetail L  " & _
                        " LEFT JOIN  PurchInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN SubGroup Sg ON H.Vendor = Sg.SubCode " & _
                        " Where L.Item = '" & Item & "'" & _
                        " And H.DocId <> '" & mSearchCode & "'" & _
                        " ORDER BY H.V_Date DESC	 "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count = 0 Then Dgl.DataSource = Nothing : Dgl.Visible = False : Exit Sub

            Dgl.DataSource = DtTemp
            Dgl.Visible = True

            Dgl.DataSource.DefaultView.RowFilter = " Item = '" & Item & "' "

            Me.Controls.Add(Dgl)
            Dgl.Left = Me.Left + 3
            Dgl.Top = Me.Bottom - Dgl.Height - 130
            Dgl.Height = 130
            Dgl.Width = 450
            Dgl.ColumnHeadersHeight = 40
            Dgl.AllowUserToAddRows = False
            If Dgl.Columns.Count > 0 Then
                Dgl.Columns("Purch_Date").Width = 82
                Dgl.Columns("Vendor").Width = 200
                Dgl.Columns("Rate").Width = 60
                Dgl.Columns("Qty").Width = 60
                Dgl.Columns("Purch_Date").SortMode = DataGridViewColumnSortMode.NotSortable
                Dgl.Columns("Rate").SortMode = DataGridViewColumnSortMode.NotSortable
                Dgl.Columns("Qty").SortMode = DataGridViewColumnSortMode.NotSortable
                'Dgl.Columns("Rate").CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                'Dgl.Columns("Qty").CellTemplate.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                'Dgl.Columns("Rate").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                'Dgl.Columns("Qty").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
                Dgl.RowHeadersVisible = False
                Dgl.EnableHeadersVisualStyles = False
                Dgl.AllowUserToResizeRows = False
                Dgl.ReadOnly = True
                Dgl.Columns("Item").Visible = False
                Dgl.AutoResizeRows()
                Dgl.AutoResizeColumnHeadersHeight()
                Dgl.BackgroundColor = Color.Cornsilk
                Dgl.ColumnHeadersDefaultCellStyle.BackColor = Color.Cornsilk
                Dgl.DefaultCellStyle.BackColor = Color.Cornsilk
                Dgl.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None
                Dgl.CellBorderStyle = DataGridViewCellBorderStyle.None
                Dgl.Font = New Font(New FontFamily("Verdana"), 8)
                Dgl.ColumnHeadersDefaultCellStyle.Font = New Font(New FontFamily("Verdana"), 8, FontStyle.Bold)
                Dgl.BringToFront()
                Dgl.Show()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Dgl1_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles Dgl1.RowEnter
        FShowLastRates(Dgl1.Item(Col1Item, e.RowIndex).Tag)
    End Sub

    Private Sub Dgl1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dgl1.Leave
        Dgl.Visible = False
    End Sub

    Private Sub FCheckDuplicate(ByVal mRow As Integer)
        Dim I As Integer = 0
        Try
            With Dgl1
                For I = 0 To .Rows.Count - 1
                    If .Item(Col1Item, I).Value <> "" Then
                        If mRow <> I Then
                            If AgL.StrCmp(.Item(Col1Item, I).Value, .Item(Col1Item, mRow).Value) Then
                                If MsgBox("Item " & .Item(Col1Item, I).Value & " Is Already Feeded At Row No " & .Item(ColSNo, I).Value & ".Do You Want To Continue ?", MsgBoxStyle.Information + MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                                    Dgl1.Item(Col1Item, mRow).Tag = "" : Dgl1.Item(Col1Item, mRow).Value = ""
                                End If
                                '.CurrentCell = .Item(Col1Item, I) : Dgl1.Focus()
                                '.Rows.Remove(.Rows(mRow)) : Exit Sub
                            End If
                        End If
                    End If
                Next
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FUpdateDeal(ByVal mRow As Integer, ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Dim UPDATEQRY$ = ""

        UPDATEQRY = " UPDATE Item Set " & _
                " Deal = (Select TOP 1 L.DEAL From PURCHINVOICEDETAIL L LEFT JOIN PURCHINVOICE H ON L.DOCID = H.DOCID ORDER BY V_DATE DESC ) " & _
                " Where Code = '" & Dgl1.Item(Col1Item, mRow).Tag & "'"
        AgL.Dman_ExecuteNonQry(UPDATEQRY, Conn, Cmd)
    End Sub

    Private Sub FOpenItemMaster()
        Dim FrmObj As Object = Nothing
        Dim CFOpen As New ClsFunction
        Dim MDI As New MDIMain
        Dim DrTemp As DataRow() = Nothing
        Dim bRowIndex As Integer = 0, bColumnIndex As Integer = 0
        Dim bItemCode$ = ""
        Try
            bRowIndex = Dgl1.CurrentCell.RowIndex
            bColumnIndex = Dgl1.CurrentCell.ColumnIndex

            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    FrmObj = CFOpen.FOpen(MDI.MnuItemMaster.Name, MDI.MnuItemMaster.Text, True)
                    If FrmObj IsNot Nothing Then
                        FrmObj.StartPosition = FormStartPosition.Manual
                        FrmObj.IsReturnValue = True
                        FrmObj.Top = 50
                        FrmObj.ShowDialog()
                        bItemCode = FrmObj.mItemCode
                        FrmObj = Nothing

                        Dgl1.Item(Col1Item, bRowIndex).Value = ""
                        Dgl1.Item(Col1Item, bRowIndex).Tag = ""

                        Dgl1.CurrentCell = Dgl1.Item(Col1DocQty, bRowIndex)

                        mQry = "SELECT I.Code, I.Description, I.ManualCode, I.Unit, I.SalesTaxPostingGroup, I.Measure As MeasurePerPcs, " & _
                                  " I.MeasureUnit, I.Rate, " & _
                                  " U.DecimalPlaces As QtyDecimalPlaces, U1.DecimalPlaces As MeasureDecimalPlaces " & _
                                  " FROM Item I " & _
                                  " LEFT JOIN Unit U On I.Unit = U.Code " & _
                                  " LEFT JOIN Unit U1 On I.MeasureUnit = U1.Code " & _
                                  " Where IsNull(I.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' "
                        Dgl1.AgHelpDataSet(Col1Item, 7) = AgL.FillData(mQry, AgL.GCn)

                        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                            DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & bItemCode & "'")
                            If DrTemp.Length > 0 Then
                                Dgl1.Item(Col1Item, bRowIndex).Tag = AgL.XNull(DrTemp(0)("Code"))
                                Dgl1.Item(Col1Item, bRowIndex).Value = AgL.XNull(DrTemp(0)("Description"))
                                Dgl1.Item(Col1ItemCode, bRowIndex).Tag = AgL.XNull(DrTemp(0)("Code"))
                                Dgl1.Item(Col1ItemCode, bRowIndex).Value = AgL.XNull(DrTemp(0)("ManualCode"))
                                Dgl1.Item(Col1Unit, bRowIndex).Value = AgL.XNull(DrTemp(0)("Unit"))
                                Dgl1.Item(Col1QtyDecimalPlaces, bRowIndex).Value = AgL.VNull(DrTemp(0)("QtyDecimalPlaces"))
                                Dgl1.Item(Col1MeasurePerPcs, bRowIndex).Value = AgL.XNull(DrTemp(0)("MeasurePerPcs"))
                                Dgl1.Item(Col1MeasureUnit, bRowIndex).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                                Dgl1.Item(Col1MeasureDecimalPlaces, bRowIndex).Value = AgL.VNull(DrTemp(0)("MeasureDecimalPlaces"))
                                Dgl1.Item(Col1DeliveryMeasure, bRowIndex).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))
                                Dgl1.Item(Col1DeliveryMeasureMultiplier, bRowIndex).Value = 1
                                Dgl1.Item(Col1Rate, bRowIndex).Value = AgL.XNull(DrTemp(0)("Rate"))
                                Dgl1.Item(Col1SalesTaxGroup, bRowIndex).Tag = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                                Dgl1.Item(Col1SalesTaxGroup, bRowIndex).Value = AgL.XNull(DrTemp(0)("SalesTaxPostingGroup"))
                                If AgL.StrCmp(Dgl1.AgSelectedValue(Col1SalesTaxGroup, bRowIndex), "") Then
                                    Dgl1.Item(Col1SalesTaxGroup, bRowIndex).Tag = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                                    Dgl1.Item(Col1SalesTaxGroup, bRowIndex).Value = AgL.XNull(AgL.PubDtEnviro.Rows(0)("DefaultSalesTaxGroupItem"))
                                End If
                            End If
                        End If
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FGetPurchIndent(ByVal ItemCode As String, ByRef PurchIndent As String)
        mQry = " Select H.DocId From PurchIndent H LEFT JOIN PurchIndentDetail L On H.DocId = L.DocId " & _
                " Where L.Item = '" & ItemCode & "' " & _
                " And H.V_Date <= '" & TxtV_Date.Text & "' " & _
                " Order By H.V_Date  "
        PurchIndent = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
    End Sub

    Private Sub FGetPurchChallan(ByVal mRow As Integer)
        Dim FRH_Single As DMHelpGrid.FrmHelpGrid
        Dim StrRtn As String = ""
        Dim DtTemp As DataTable = Nothing

        mQry = " SELECT  L.PurchChallan + Convert(nVarChar,L.PurchChallanSr) As PurchChallanDocIdSr, " & _
                " Max(H.V_Type) + '-' +  Max(H.ReferenceNo) AS ChallanNo, " & _
                " Max(H.V_Date) as ChallanDate, Sum(L.Qty) - IsNull(Sum(Cd.Qty), 0) as [Bal.Qty],     " & _
                " Max(L.Unit) as Unit  " & _
                " FROM ( " & _
                "    SELECT DocID, V_Type, ReferenceNo, V_Date " & _
                "    FROM PurchChallan With (nolock)     " & _
                "    WHERE Vendor= '" & TxtVendor.Tag & "'   " & _
                "    And Div_Code = '" & TxtDivision.Tag & "'   " & _
                "    AND Site_Code = '" & TxtSite_Code.Tag & "'   " & _
                "    AND V_Date< = '" & TxtV_Date.Text & "'  " & _
                " ) AS  H     " & _
                " LEFT JOIN PurchChallanDetail L With (nolock) ON H.DocID = L.DocId      " & _
                " Left Join (     " & _
                "    SELECT L.PurchChallan, L.PurchChallanSr, Sum (L.Qty) AS Qty    " & _
                "    FROM PurchInvoiceDetail L  With (nolock)     " & _
                "    Where L.DocId <> '" & mSearchCode & "'   " & _
                "    GROUP BY L.PurchChallan, L.PurchChallanSr   " & _
                " ) AS CD ON L.DocId = CD.PurchChallan AND L.Sr = CD.PurchChallanSr   " & _
                " LEFT JOIN Unit U On L.Unit = U.Code     " & _
                " LEFT JOIN Unit U1 On L.MeasureUnit = U1.Code " & _
                " WHERE L.Qty - IsNull(Cd.Qty, 0) > 0    " & _
                " And L.Item = '" & Dgl1.Item(Col1Item, mRow).Tag & "' " & _
                " GROUP BY L.PurchChallan + Convert(nVarChar,L.PurchChallanSr) "

        If AgL.FillData(mQry, AgL.GCn).Tables(0).Rows.Count > 0 Then
            FRH_Single = New DMHelpGrid.FrmHelpGrid(New DataView(AgL.FillData(mQry, AgL.GCn).TABLES(0)), "", 300, 400, , , False)
            FRH_Single.FFormatColumn(0, , 0, , False)
            FRH_Single.FFormatColumn(1, "Challan No.", 100, DataGridViewContentAlignment.MiddleLeft)
            FRH_Single.FFormatColumn(2, "Challan Date", 100, DataGridViewContentAlignment.MiddleLeft)
            FRH_Single.FFormatColumn(3, "Bal Qty", 70, DataGridViewContentAlignment.MiddleRight)
            FRH_Single.FFormatColumn(4, "Unit", 60, DataGridViewContentAlignment.MiddleLeft)

            FRH_Single.StartPosition = FormStartPosition.CenterScreen
            FRH_Single.ShowDialog()

            If FRH_Single.DRReturn IsNot Nothing Then
                StrRtn = FRH_Single.DRReturn.Item(0)
            Else
                FGetPurchChallan(mRow)
            End If

            mQry = " Select L.DocId, H.V_Type + '-' + H.ReferenceNo as ChallanNo,L.Sr, L.Qty, L.Rate, L.MRP, L.ExpiryDate " & _
                    " From PurchChallanDetail L " & _
                    " LEFT JOIN PurchChallan H On L.DocId = H.DocId " & _
                    " Where L.DocId + Convert(nVarChar,L.Sr) = '" & StrRtn & "'"
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtTemp.Rows.Count > 0 Then
                Dgl1.Item(Col1PurchChallan, mRow).Tag = AgL.XNull(DtTemp.Rows(0)("DocId"))
                Dgl1.Item(Col1PurchChallan, mRow).Value = AgL.XNull(DtTemp.Rows(0)("ChallanNo"))
                Dgl1.Item(Col1PurchChallanSr, mRow).Value = AgL.XNull(DtTemp.Rows(0)("Sr"))
                Dgl1.Item(Col1DocQty, mRow).Value = AgL.VNull(DtTemp.Rows(0)("Qty"))
                Dgl1.Item(Col1Qty, mRow).Value = AgL.VNull(DtTemp.Rows(0)("Qty"))
                Dgl1.Item(Col1Rate, mRow).Value = AgL.VNull(DtTemp.Rows(0)("Rate"))
                Dgl1.Item(Col1MRP, mRow).Value = AgL.VNull(DtTemp.Rows(0)("MRP"))
            End If
        End If

        FRH_Single = Nothing
    End Sub

    Private Sub TxtVendorDocDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TxtVendorDocDate.Enter
        Try
            Select Case sender.Name
                Case TxtVendorDocDate.Name
                    If TxtVendorDocDate.Text = "" Then
                        TxtVendorDocDate.Text = TxtV_Date.Text
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
