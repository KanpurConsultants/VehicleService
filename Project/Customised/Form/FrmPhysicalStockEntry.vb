Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO
Public Class FrmPhysicalStockEntry
    Inherits AgTemplate.TempTransaction
    Dim mQry$

    Public WithEvents Dgl1 As AgControls.AgDataGrid
    Protected Const ColSNo As String = "S.No."
    Protected Const Col1Item_Uid As String = "Item_Uid"
    Protected Const Col1Item As String = "Item"
    Protected Const Col1Process As String = "Process"
    Protected Const Col1Status As String = "Status"
    Protected Const Col1Qty As String = "Qty"
    Protected Const Col1CurrentStock As String = "Current Stock"
    Protected Const Col1Unit As String = "Unit"
    Protected Const Col1MeasurePerPcs As String = "Measure Per Pcs"
    Protected Const Col1MeasureUnit As String = "Measure Unit"
    Protected Const Col1TotalMeasure As String = "Total Measure"
    Protected Const Col1CurrentStockMeasure As String = "Current Stock Measure"
    Protected Const Col1Rate As String = "Rate"
    Protected Const Col1Amount As String = "Amount"
    Protected Const Col1DifferenceQty As String = "Difference Qty"
    Protected Const Col1DifferenceMeasure As String = "Difference Measure"

    Dim ImportMessegeStr$ = ""
    Dim ImportMode As Boolean = False
    Dim mItemTypeStr$ = ""


    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable, ByVal NCatStr As String)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)

        EntryNCat = NCatStr
        mQry = "Select H.* from Voucher_Type_Settings H Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  Where Vt.NCat In ('" & EntryNCat & "') And H.Div_Code = '" & AgL.PubDivCode & "' And H.Site_Code ='" & AgL.PubSiteCode & "' "
        DtV_TypeSettings = AgL.FillData(mQry, AgL.GCn).Tables(0)
    End Sub


#Region "Form Designer Code"
    Private Sub InitializeComponent()
        Me.Dgl1 = New AgControls.AgDataGrid
        Me.TxtGodown = New AgControls.AgTextBox
        Me.LblSaleOrderNo = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.LblTotalMeasure = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.LblTotalAmount = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblTotalQty = New System.Windows.Forms.Label
        Me.LblTotalQtyText = New System.Windows.Forms.Label
        Me.Pnl1 = New System.Windows.Forms.Panel
        Me.TxtRemarks = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel
        Me.BtnImprtFromText = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtManualRefNo = New AgControls.AgTextBox
        Me.LblManualRefNo = New System.Windows.Forms.Label
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
        Me.GroupBox2.Location = New System.Drawing.Point(746, 577)
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
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(582, 577)
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
        Me.GBoxApprove.Location = New System.Drawing.Point(415, 577)
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
        Me.GBoxEntryType.Location = New System.Drawing.Point(150, 577)
        Me.GBoxEntryType.Size = New System.Drawing.Size(119, 40)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Location = New System.Drawing.Point(3, 19)
        Me.TxtEntryType.Tag = ""
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(16, 577)
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
        Me.GroupBox1.Location = New System.Drawing.Point(2, 573)
        Me.GroupBox1.Size = New System.Drawing.Size(919, 4)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(285, 577)
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
        Me.LblV_No.Location = New System.Drawing.Point(272, 155)
        Me.LblV_No.Tag = ""
        '
        'TxtV_No
        '
        Me.TxtV_No.AgSelectedValue = ""
        Me.TxtV_No.BackColor = System.Drawing.Color.White
        Me.TxtV_No.Location = New System.Drawing.Point(390, 154)
        Me.TxtV_No.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_No.TabIndex = 3
        Me.TxtV_No.Tag = ""
        Me.TxtV_No.TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(107, 38)
        Me.Label2.Tag = ""
        '
        'LblV_Date
        '
        Me.LblV_Date.BackColor = System.Drawing.Color.Transparent
        Me.LblV_Date.Location = New System.Drawing.Point(11, 33)
        Me.LblV_Date.Tag = ""
        '
        'LblV_TypeReq
        '
        Me.LblV_TypeReq.Location = New System.Drawing.Point(335, 18)
        Me.LblV_TypeReq.Tag = ""
        '
        'TxtV_Date
        '
        Me.TxtV_Date.AgSelectedValue = ""
        Me.TxtV_Date.BackColor = System.Drawing.Color.White
        Me.TxtV_Date.Location = New System.Drawing.Point(123, 32)
        Me.TxtV_Date.TabIndex = 2
        Me.TxtV_Date.Tag = ""
        '
        'LblV_Type
        '
        Me.LblV_Type.Location = New System.Drawing.Point(233, 14)
        Me.LblV_Type.Tag = ""
        '
        'TxtV_Type
        '
        Me.TxtV_Type.AgSelectedValue = ""
        Me.TxtV_Type.BackColor = System.Drawing.Color.White
        Me.TxtV_Type.Location = New System.Drawing.Point(351, 12)
        Me.TxtV_Type.Size = New System.Drawing.Size(149, 18)
        Me.TxtV_Type.TabIndex = 1
        Me.TxtV_Type.Tag = ""
        '
        'LblSite_CodeReq
        '
        Me.LblSite_CodeReq.Location = New System.Drawing.Point(107, 18)
        Me.LblSite_CodeReq.Tag = ""
        '
        'LblSite_Code
        '
        Me.LblSite_Code.BackColor = System.Drawing.Color.Transparent
        Me.LblSite_Code.Location = New System.Drawing.Point(11, 13)
        Me.LblSite_Code.Size = New System.Drawing.Size(87, 16)
        Me.LblSite_Code.Tag = ""
        Me.LblSite_Code.Text = "Branch Name"
        '
        'TxtSite_Code
        '
        Me.TxtSite_Code.AgSelectedValue = ""
        Me.TxtSite_Code.BackColor = System.Drawing.Color.White
        Me.TxtSite_Code.Location = New System.Drawing.Point(123, 12)
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
        Me.LblPrefix.Location = New System.Drawing.Point(728, 129)
        Me.LblPrefix.Tag = ""
        Me.LblPrefix.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(-4, 19)
        Me.TabControl1.Size = New System.Drawing.Size(909, 85)
        Me.TabControl1.TabIndex = 0
        '
        'TP1
        '
        Me.TP1.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.TP1.Controls.Add(Me.TxtManualRefNo)
        Me.TP1.Controls.Add(Me.LblManualRefNo)
        Me.TP1.Controls.Add(Me.Label3)
        Me.TP1.Controls.Add(Me.Label1)
        Me.TP1.Controls.Add(Me.TxtRemarks)
        Me.TP1.Controls.Add(Me.TxtGodown)
        Me.TP1.Controls.Add(Me.LblSaleOrderNo)
        Me.TP1.Location = New System.Drawing.Point(4, 22)
        Me.TP1.Size = New System.Drawing.Size(901, 59)
        Me.TP1.Text = "Document Detail"
        Me.TP1.Controls.SetChildIndex(Me.TxtV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label2, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_No, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_Code, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Date, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSite_CodeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblSaleOrderNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblPrefix, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtGodown, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblV_TypeReq, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtV_Type, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtRemarks, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtDocId, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label1, 0)
        Me.TP1.Controls.SetChildIndex(Me.Label3, 0)
        Me.TP1.Controls.SetChildIndex(Me.LblManualRefNo, 0)
        Me.TP1.Controls.SetChildIndex(Me.TxtManualRefNo, 0)
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(901, 41)
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
        'TxtGodown
        '
        Me.TxtGodown.AgAllowUserToEnableMasterHelp = False
        Me.TxtGodown.AgLastValueTag = Nothing
        Me.TxtGodown.AgLastValueText = Nothing
        Me.TxtGodown.AgMandatory = True
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
        Me.TxtGodown.Location = New System.Drawing.Point(578, 12)
        Me.TxtGodown.MaxLength = 20
        Me.TxtGodown.Name = "TxtGodown"
        Me.TxtGodown.Size = New System.Drawing.Size(316, 18)
        Me.TxtGodown.TabIndex = 4
        '
        'LblSaleOrderNo
        '
        Me.LblSaleOrderNo.AutoSize = True
        Me.LblSaleOrderNo.BackColor = System.Drawing.Color.Transparent
        Me.LblSaleOrderNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblSaleOrderNo.Location = New System.Drawing.Point(509, 12)
        Me.LblSaleOrderNo.Name = "LblSaleOrderNo"
        Me.LblSaleOrderNo.Size = New System.Drawing.Size(55, 16)
        Me.LblSaleOrderNo.TabIndex = 706
        Me.LblSaleOrderNo.Text = "Godown"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Cornsilk
        Me.Panel1.Controls.Add(Me.LblTotalMeasure)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.LblTotalAmount)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.LblTotalQty)
        Me.Panel1.Controls.Add(Me.LblTotalQtyText)
        Me.Panel1.Location = New System.Drawing.Point(6, 548)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 23)
        Me.Panel1.TabIndex = 694
        '
        'LblTotalMeasure
        '
        Me.LblTotalMeasure.AutoSize = True
        Me.LblTotalMeasure.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalMeasure.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalMeasure.Location = New System.Drawing.Point(482, 3)
        Me.LblTotalMeasure.Name = "LblTotalMeasure"
        Me.LblTotalMeasure.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalMeasure.TabIndex = 670
        Me.LblTotalMeasure.Text = "."
        Me.LblTotalMeasure.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Maroon
        Me.Label5.Location = New System.Drawing.Point(367, 3)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 669
        Me.Label5.Text = "Total Measure :"
        '
        'LblTotalAmount
        '
        Me.LblTotalAmount.AutoSize = True
        Me.LblTotalAmount.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalAmount.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalAmount.Location = New System.Drawing.Point(750, 3)
        Me.LblTotalAmount.Name = "LblTotalAmount"
        Me.LblTotalAmount.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalAmount.TabIndex = 668
        Me.LblTotalAmount.Text = "."
        Me.LblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Maroon
        Me.Label4.Location = New System.Drawing.Point(639, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(101, 16)
        Me.Label4.TabIndex = 667
        Me.Label4.Text = "Total Amount :"
        '
        'LblTotalQty
        '
        Me.LblTotalQty.AutoSize = True
        Me.LblTotalQty.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQty.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.LblTotalQty.Location = New System.Drawing.Point(113, 3)
        Me.LblTotalQty.Name = "LblTotalQty"
        Me.LblTotalQty.Size = New System.Drawing.Size(12, 16)
        Me.LblTotalQty.TabIndex = 660
        Me.LblTotalQty.Text = "."
        Me.LblTotalQty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LblTotalQtyText
        '
        Me.LblTotalQtyText.AutoSize = True
        Me.LblTotalQtyText.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblTotalQtyText.ForeColor = System.Drawing.Color.Maroon
        Me.LblTotalQtyText.Location = New System.Drawing.Point(32, 3)
        Me.LblTotalQtyText.Name = "LblTotalQtyText"
        Me.LblTotalQtyText.Size = New System.Drawing.Size(73, 16)
        Me.LblTotalQtyText.TabIndex = 659
        Me.LblTotalQtyText.Text = "Total Qty :"
        '
        'Pnl1
        '
        Me.Pnl1.Location = New System.Drawing.Point(6, 134)
        Me.Pnl1.Name = "Pnl1"
        Me.Pnl1.Size = New System.Drawing.Size(889, 413)
        Me.Pnl1.TabIndex = 1
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
        Me.TxtRemarks.Location = New System.Drawing.Point(578, 32)
        Me.TxtRemarks.MaxLength = 255
        Me.TxtRemarks.Name = "TxtRemarks"
        Me.TxtRemarks.Size = New System.Drawing.Size(316, 18)
        Me.TxtRemarks.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(565, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 724
        Me.Label1.Text = "Ä"
        '
        'LinkLabel1
        '
        Me.LinkLabel1.BackColor = System.Drawing.Color.SteelBlue
        Me.LinkLabel1.DisabledLinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline
        Me.LinkLabel1.LinkColor = System.Drawing.Color.White
        Me.LinkLabel1.Location = New System.Drawing.Point(6, 113)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(99, 20)
        Me.LinkLabel1.TabIndex = 740
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Item Detail"
        Me.LinkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'BtnImprtFromText
        '
        Me.BtnImprtFromText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BtnImprtFromText.Font = New System.Drawing.Font("Verdana", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnImprtFromText.Location = New System.Drawing.Point(825, 108)
        Me.BtnImprtFromText.Name = "BtnImprtFromText"
        Me.BtnImprtFromText.Size = New System.Drawing.Size(70, 25)
        Me.BtnImprtFromText.TabIndex = 763
        Me.BtnImprtFromText.TabStop = False
        Me.BtnImprtFromText.Text = "Import"
        Me.BtnImprtFromText.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(509, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 725
        Me.Label3.Text = "Remark"
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
        Me.TxtManualRefNo.Location = New System.Drawing.Point(351, 32)
        Me.TxtManualRefNo.MaxLength = 50
        Me.TxtManualRefNo.Name = "TxtManualRefNo"
        Me.TxtManualRefNo.Size = New System.Drawing.Size(149, 18)
        Me.TxtManualRefNo.TabIndex = 3
        '
        'LblManualRefNo
        '
        Me.LblManualRefNo.AutoSize = True
        Me.LblManualRefNo.BackColor = System.Drawing.Color.Transparent
        Me.LblManualRefNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblManualRefNo.Location = New System.Drawing.Point(233, 33)
        Me.LblManualRefNo.Name = "LblManualRefNo"
        Me.LblManualRefNo.Size = New System.Drawing.Size(101, 16)
        Me.LblManualRefNo.TabIndex = 728
        Me.LblManualRefNo.Text = "Manual Ref. No."
        '
        'FrmPhysicalStockEntry
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.ClientSize = New System.Drawing.Size(901, 618)
        Me.Controls.Add(Me.BtnImprtFromText)
        Me.Controls.Add(Me.LinkLabel1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Pnl1)
        Me.Name = "FrmPhysicalStockEntry"
        Me.Text = "Template Sale Order"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.Pnl1, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.LinkLabel1, 0)
        Me.Controls.SetChildIndex(Me.BtnImprtFromText, 0)
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

    End Sub
    Protected WithEvents TxtGodown As AgControls.AgTextBox
    Protected WithEvents LblSaleOrderNo As System.Windows.Forms.Label
    Protected WithEvents Panel1 As System.Windows.Forms.Panel
    Protected WithEvents LblTotalQty As System.Windows.Forms.Label
    Protected WithEvents LblTotalQtyText As System.Windows.Forms.Label
    Protected WithEvents Pnl1 As System.Windows.Forms.Panel
    Protected WithEvents TxtRemarks As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents LblTotalAmount As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Protected WithEvents LblTotalMeasure As System.Windows.Forms.Label
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents BtnImprtFromText As System.Windows.Forms.Button
    Protected WithEvents Label3 As System.Windows.Forms.Label
    Protected WithEvents TxtManualRefNo As AgControls.AgTextBox
    Protected WithEvents LblManualRefNo As System.Windows.Forms.Label
#End Region

    Private Sub Frm_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "StockHead"
        LogTableName = "StockHead_Log"
        MainLineTableCsv = "StockHeadDetail"
        LogLineTableCsv = "StockHeadDetail_LOG"
        AgL.GridDesign(Dgl1)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mCondStr$

        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        mQry = " Select H.DocID As SearchCode " & _
            " From StockHead H " & _
            " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type  " & _
            " Where IsNull(IsDeleted,0) = 0  " & mCondStr & "  Order By H.V_Date Desc "

        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mCondStr$
        mCondStr = " " & AgL.CondStrFinancialYear("H.V_Date", AgL.PubStartDate, AgL.PubEndDate) & _
                        " And " & AgL.PubSiteCondition("H.Site_Code", AgL.PubSiteCode) & " " & AgL.RetDivisionCondition(AgL, "H.Div_Code")
        mCondStr = mCondStr & " And Vt.NCat in ('" & EntryNCat & "')"

        AgL.PubFindQry = " SELECT H.DocID AS SearchCode, H.V_Type AS [Adjustment Type], H.V_Prefix AS Prefix, H.V_Date AS Date, H.V_No AS [Entry No], " & _
                " H.FromProcess AS [FROM Process], H.ToProcess AS [TO Process], H.TotalQty AS [Total Qty], H.TotalMeasure AS [Total Measure],  " & _
                " H.Amount, H.Addition, H.Deduction, H.NetAmount, H.Remarks,  H.EntryBy AS [Entry By], H.EntryDate AS [Entry Date], H.EntryType AS [Entry Type],  " & _
                " H.EntryStatus AS [Entry Status], H.ApproveBy AS [Approve By], H.ApproveDate AS [Approve Date], H.MoveToLog AS [Move To Log],  " & _
                " H.MoveToLogDate AS [Move To Log Date], H.Status, H.ReferenceDocID AS [Reference No], H.Structure, H.OrderBy AS [ORDER By], H.ManualRefNo AS [Manual No], " & _
                " D.Div_Name AS Division,SM.Name AS [Site Name],GF.Description AS [FROM Godown], GT.Description AS [To Godown] " & _
                " FROM  StockHead H  " & _
                " LEFT JOIN Division D ON D.Div_Code=H.Div_Code  " & _
                " LEFT JOIN SiteMast SM ON SM.Code=H.Site_Code  " & _
                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                " LEFT JOIN Godown GF ON GF.Code = H.FromGodown  " & _
                " LEFT JOIN Godown GT ON GT.Code = H.ToGodown  " & _
                " Where IsNull(H.IsDeleted,0) = 0  " & mCondStr

        AgL.PubFindQryOrdBy = "[Entry Date]"
    End Sub

    Private Sub FrmSaleOrder_BaseFunction_IniGrid() Handles Me.BaseFunction_IniGrid
        Dgl1.ColumnCount = 0
        With AgCL
            .AddAgTextColumn(Dgl1, ColSNo, 40, 5, ColSNo, True, True, False)
            .AddAgTextColumn(Dgl1, Col1Item_Uid, 80, 0, Col1Item_Uid, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_ItemUID")), Boolean), False, False)
            .AddAgTextColumn(Dgl1, Col1Item, 150, 0, Col1Item, True, False, False)
            .AddAgTextColumn(Dgl1, Col1Process, 100, 0, Col1Process, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Process")), Boolean), , False, False)
            .AddAgTextColumn(Dgl1, Col1Status, 85, 0, Col1Status, False, False, False)
            .AddAgNumberColumn(Dgl1, Col1CurrentStock, 85, 8, 4, False, Col1CurrentStock, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Qty, 85, 8, 4, False, Col1Qty, True, False, True)
            .AddAgTextColumn(Dgl1, Col1Unit, 75, 0, Col1Unit, True, True, False)
            .AddAgNumberColumn(Dgl1, Col1MeasurePerPcs, 100, 8, 4, False, Col1MeasurePerPcs, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_MeasurePerPcs")), Boolean), True, True)
            .AddAgNumberColumn(Dgl1, Col1TotalMeasure, 100, 8, 4, False, Col1TotalMeasure, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_Measure")), Boolean), True, True)
            .AddAgTextColumn(Dgl1, Col1MeasureUnit, 75, 0, Col1MeasureUnit, CType(AgL.VNull(DtV_TypeSettings.Rows(0)("IsVisible_MeasureUnit")), Boolean), True, False)
            .AddAgNumberColumn(Dgl1, Col1CurrentStockMeasure, 100, 8, 4, False, Col1CurrentStockMeasure, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1Rate, 70, 8, 2, False, Col1Rate, False, False, True)
            .AddAgNumberColumn(Dgl1, Col1Amount, 100, 8, 2, False, Col1Amount, False, True, True)
            .AddAgNumberColumn(Dgl1, Col1DifferenceQty, 100, 8, 2, False, Col1DifferenceQty, True, True, True)
            .AddAgNumberColumn(Dgl1, Col1DifferenceMeasure, 100, 8, 2, False, Col1DifferenceMeasure, True, True, True)
        End With
        AgL.AddAgDataGrid(Dgl1, Pnl1)
        Dgl1.EnableHeadersVisualStyles = False
        Dgl1.ColumnHeadersHeight = 35

        Dgl1.AgSkipReadOnlyColumns = True

        Dgl1.AllowUserToOrderColumns = True
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        Dim I As Integer, mSr As Integer

        mQry = "UPDATE StockHead " & _
                " SET " & _
                " ManualRefNo = " & AgL.Chk_Text(TxtManualRefNo.Text) & ", " & _
                " TotalQty = " & Val(LblTotalQty.Text) & ", " & _
                " Amount = " & Val(LblTotalAmount.Text) & ", " & _
                " TotalMeasure = " & Val(LblTotalMeasure.Text) & ", " & _
                " FromGodown = " & AgL.Chk_Text(TxtGodown.AgSelectedValue) & ", " & _
                " Remarks = " & AgL.Chk_Text(TxtRemarks.Text) & " " & _
                " Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = "Delete From StockHeadDetail Where DocId = '" & SearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        'Never Try to Serialise Sr in Line Items 
        'As Some other Entry points may updating values to this Search code and Sr
        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    mSr += 1
                    mQry = "INSERT INTO StockHeadDetail(DocId, Sr, Item_Uid, Item, Process, " & _
                            " Status, CurrentStock, Qty, Unit, " & _
                            " MeasurePerPcs, TotalMeasure, CurrentStockMeasure, MeasureUnit,  " & _
                            " Rate, Amount, DifferenceQty, DifferenceMeasure) " & _
                            " VALUES('" & mSearchCode & "', " & Val(mSr) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1Item_Uid, I).Tag) & ", " & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Item, I)) & ", " & _
                            " " & AgL.Chk_Text(.AgSelectedValue(Col1Process, I)) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1Status, I).Value) & ", " & _
                            " " & Val(.Item(Col1CurrentStock, I).Value) & ", " & _
                            " " & Val(.Item(Col1Qty, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1Unit, I).Value) & ", " & _
                            " " & Val(.Item(Col1MeasurePerPcs, I).Value) & ", " & _
                            " " & Val(.Item(Col1TotalMeasure, I).Value) & ", " & _
                            " " & Val(.Item(Col1CurrentStockMeasure, I).Value) & ", " & _
                            " " & AgL.Chk_Text(.Item(Col1MeasureUnit, I).Value) & ", " & _
                            " " & Val(.Item(Col1Rate, I).Value) & ", " & _
                            " " & Val(.Item(Col1Amount, I).Value) & ", " & _
                            " " & Val(.Item(Col1DifferenceQty, I).Value) & ", " & _
                            " " & Val(.Item(Col1DifferenceMeasure, I).Value) & " " & _
                            " ) "
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next
        End With

        If AgL.PubUserName.ToUpper = AgLibrary.ClsConstant.PubSuperUserName.ToUpper Then
            AgCL.GridSetiingWriteXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
        End If
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim I As Integer
        Dim DsTemp As DataSet

        mQry = "Select H.*, G.Description As GodownDesc " & _
            " From StockHead H " & _
            " LEFT JOIN Godown G ON H.FromGodown = G.Code " & _
            " Where H.DocID='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                IniGrid()
                TxtManualRefNo.Text = AgL.XNull(.Rows(0)("ManualRefNo"))
                TxtGodown.Tag = AgL.XNull(.Rows(0)("FromGodown"))
                TxtGodown.Text = AgL.XNull(.Rows(0)("GodownDesc"))
                TxtRemarks.Text = AgL.XNull(.Rows(0)("Remarks"))
                LblTotalQty.Text = AgL.VNull(.Rows(0)("TotalQty"))
                LblTotalMeasure.Text = AgL.VNull(.Rows(0)("TotalMeasure"))
                LblTotalAmount.Text = AgL.VNull(.Rows(0)("Amount"))

                '-------------------------------------------------------------
                'Line Records are showing in Grid
                '-------------------------------------------------------------

                mQry = "Select L.*, Iu.item_Uid As Item_UidDesc, I.Description As ItemDesc, P.Description As ProcessDesc " & _
                        " from StockHeadDetail L " & _
                        " LEFT JOIN Item I on l.Item = I.Code " & _
                        " LEFT JOIN Item_Uid Iu On L.Item_Uid = Iu.Code " & _
                        " LEFT JOIN Process P On L.Process = P.NCat " & _
                        " where DocId = '" & SearchCode & "' Order By Sr"
                DsTemp = AgL.FillData(mQry, AgL.GCn)
                With DsTemp.Tables(0)
                    Dgl1.RowCount = 1
                    Dgl1.Rows.Clear()
                    If .Rows.Count > 0 Then
                        For I = 0 To DsTemp.Tables(0).Rows.Count - 1
                            Dgl1.Rows.Add()
                            Dgl1.Item(ColSNo, I).Value = Dgl1.Rows.Count - 1

                            Dgl1.Item(Col1Item_Uid, I).Tag = AgL.XNull(.Rows(I)("Item_Uid"))
                            Dgl1.Item(Col1Item_Uid, I).Value = AgL.XNull(.Rows(I)("Item_UidDesc"))

                            Dgl1.Item(Col1Item, I).Tag = AgL.XNull(.Rows(I)("Item"))
                            Dgl1.Item(Col1Item, I).Value = AgL.XNull(.Rows(I)("Itemdesc"))

                            Dgl1.Item(Col1Process, I).Tag = AgL.XNull(.Rows(I)("Process"))
                            Dgl1.Item(Col1Process, I).Value = AgL.XNull(.Rows(I)("ProcessDesc"))


                            Dgl1.Item(Col1Status, I).Value = AgL.XNull(.Rows(I)("Status"))
                            Dgl1.Item(Col1CurrentStock, I).Value = AgL.VNull(.Rows(I)("CurrentStock"))
                            Dgl1.Item(Col1Qty, I).Value = AgL.VNull(.Rows(I)("Qty"))
                            Dgl1.Item(Col1Unit, I).Value = AgL.XNull(.Rows(I)("Unit"))
                            Dgl1.Item(Col1MeasurePerPcs, I).Value = AgL.VNull(.Rows(I)("MeasurePerPcs"))
                            Dgl1.Item(Col1TotalMeasure, I).Value = AgL.VNull(.Rows(I)("TotalMeasure"))
                            Dgl1.Item(Col1CurrentStockMeasure, I).Value = AgL.VNull(.Rows(I)("CurrentStockMeasure"))
                            Dgl1.Item(Col1MeasureUnit, I).Value = AgL.XNull(.Rows(I)("MeasureUnit"))
                            Dgl1.Item(Col1Rate, I).Value = AgL.XNull(.Rows(I)("Rate"))
                            Dgl1.Item(Col1Amount, I).Value = AgL.XNull(.Rows(I)("Amount"))
                            Dgl1.Item(Col1DifferenceQty, I).Value = AgL.XNull(.Rows(I)("DifferenceQty"))
                            Dgl1.Item(Col1DifferenceMeasure, I).Value = AgL.XNull(.Rows(I)("DifferenceMeasure"))
                        Next I
                    End If
                End With
                Calculation()
                '-------------------------------------------------------------
            End If
        End With

        AgCL.GridSetiingShowXml(Me.Text & Dgl1.Name & AgL.PubCompCode & AgL.PubDivCode & AgL.PubSiteCode, Dgl1)
    End Sub

    Private Sub FrmProductionOrder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Topctrl1.ChangeAgGridState(Dgl1, False)
    End Sub

    Private Sub Dgl1_EditingControl_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Dgl1.EditingControl_KeyDown
        Try
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    If Dgl1.AgHelpDataSet(Col1Item) Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            FCreateHelpItem()
                        End If
                    End If

                Case Col1Process
                    If Dgl1.AgHelpDataSet(Col1Process) Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = "Select P.NCat As Code, P.Description As Process, P.Div_Code " & _
                                     " From Process P "
                            Dgl1.AgHelpDataSet(Col1Process, 1) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If

                Case Col1Status
                    If Dgl1.AgHelpDataSet(Col1Status) Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            Dgl1.AgHelpDataSet(Col1Status) = AgL.FillData(AgTemplate.ClsMain.HelpQueries.StockStatus, AgL.GCn)
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

        mQry = "SELECT H.Code, H.Description, H.Unit, H.ItemType, H.SalesTaxPostingGroup, Measure, MeasureUnit , " & _
                " IsNull(H.IsDeleted ,0) AS IsDeleted, IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status, " & _
                " H.Div_Code, H.Unit, H.Prod_Measure As MeasurePerPcs, H.MeasureUnit " & _
                " FROM Item H " & _
                " Where IsNull(H.IsDeleted ,0)  = 0 " & _
                " And IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "')='" & AgTemplate.ClsMain.EntryStatus.Active & "' " & strCond
        Dgl1.AgHelpDataSet(Col1Item, 8) = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub Dgl1_EditingControl_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Dgl1.EditingControl_Validating
        Dim mRowIndex As Integer, mColumnIndex As Integer
        Dim DrTemp As DataRow() = Nothing
        Try
            If Topctrl1.Mode = "Browse" Then Exit Sub
            mRowIndex = Dgl1.CurrentCell.RowIndex
            mColumnIndex = Dgl1.CurrentCell.ColumnIndex
            If Dgl1.Item(mColumnIndex, mRowIndex).Value Is Nothing Then Dgl1.Item(mColumnIndex, mRowIndex).Value = ""
            Select Case Dgl1.Columns(Dgl1.CurrentCell.ColumnIndex).Name
                Case Col1Item
                    'If Dgl1.Item(Col1Item, mRowIndex).Value.ToString.Trim = "" Or Dgl1.AgSelectedValue(Col1Item, mRowIndex).ToString.Trim = "" Then
                    '    Dgl1.Item(Col1Unit, mRowIndex).Value = ""
                    '    Dgl1.Item(Col1CurrentStock, mRowIndex).Value = 0
                    'Else
                    '    If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then
                    '        DrTemp = Dgl1.AgHelpDataSet(Col1Item).Tables(0).Select("Code = '" & Dgl1.AgSelectedValue(Col1Item, mRowIndex) & "'")
                    '        Dgl1.Item(Col1Unit, mRowIndex).Value = AgL.XNull(DrTemp(0)("Unit"))

                    '        Dgl1.Item(Col1MeasurePerPcs, mRowIndex).Value = AgL.XNull(DrTemp(0)("MeasurePerPcs"))
                    '        Dgl1.Item(Col1MeasureUnit, mRowIndex).Value = AgL.XNull(DrTemp(0)("MeasureUnit"))

                    '        Dgl1.Item(Col1CurrentStock, mRowIndex).Value = FRetCarpetStock(Dgl1.Item(Col1Item, mRowIndex).Tag, TxtV_Date.Text)
                    '    End If
                    'End If
                    Validating_Item(Dgl1.Item(Col1Item, mRowIndex).Tag, mRowIndex)

                Case Col1Item_Uid
                    Validating_Item_Uid(Dgl1.Item(Col1Item_Uid, mRowIndex).Value, mRowIndex)
            End Select
            Call Calculation()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub DGL1_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles Dgl1.RowsAdded, Dgl1.RowsAdded
        sender(ColSNo, sender.Rows.Count - 1).Value = Trim(sender.Rows.Count)
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_Calculation() Handles Me.BaseFunction_Calculation
        Dim I As Integer

        LblTotalQty.Text = 0
        LblTotalAmount.Text = ""
        LblTotalMeasure.Text = ""

        'Dgl1.Columns(Col1Item).ReadOnly = True

        With Dgl1
            For I = 0 To .RowCount - 1
                If .Item(Col1Item, I).Value <> "" Then
                    .Item(Col1Amount, I).Value = Format(Val(.Item(Col1Qty, I).Value) * Val(.Item(Col1Rate, I).Value), "0.00")
                    .Item(Col1TotalMeasure, I).Value = Format(Val(.Item(Col1MeasurePerPcs, I).Value) * Val(.Item(Col1Qty, I).Value), "0.0000")
                    .Item(Col1CurrentStockMeasure, I).Value = Format(Val(.Item(Col1MeasurePerPcs, I).Value) * Val(.Item(Col1CurrentStock, I).Value), "0.0000")

                    .Item(Col1DifferenceQty, I).Value = Val(.Item(Col1CurrentStock, I).Value) - Val(.Item(Col1Qty, I).Value)
                    .Item(Col1DifferenceMeasure, I).Value = Format(Val(.Item(Col1CurrentStockMeasure, I).Value) - Val(.Item(Col1TotalMeasure, I).Value), "0.0000")

                    LblTotalQty.Text = Val(LblTotalQty.Text) + Val(.Item(Col1Qty, I).Value)
                    LblTotalMeasure.Text = Val(LblTotalMeasure.Text) + Val(.Item(Col1TotalMeasure, I).Value)
                    LblTotalAmount.Text = Val(LblTotalAmount.Text) + Val(.Item(Col1Amount, I).Value)
                End If
            Next
        End With
        LblTotalQty.Text = Format(Val(LblTotalQty.Text), "0.000")
        LblTotalMeasure.Text = Format(Val(LblTotalMeasure.Text), "0.00")
        LblTotalAmount.Text = Format(Val(LblTotalAmount.Text), "0.00")
    End Sub

    Private Sub FrmProductionOrder_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        Dim I As Integer = 0
        Dim ErrMsgStr$ = ""

        With Dgl1
            If AgL.RequiredField(TxtGodown, "Godown") Then passed = False : Exit Sub
            If AgCL.AgIsBlankGrid(Dgl1, Dgl1.Columns(Col1Item).Index) = True Then passed = False : Exit Sub
            'If AgCL.AgIsDuplicate(Dgl1, "" & Dgl1.Columns(Col1Item).Index & "," & Dgl1.Columns(Col1Item_Uid).Index & "") = True Then passed = False : Exit Sub

            'For I = 0 To .Rows.Count - 1
            '    If .Item(Col1Item, I).Value <> "" Then
            '        If .Item(Col1Item_Uid, I).Value <> "" Then
            '            ErrMsgStr += FCheck_Item_UID(Dgl1.Item(Col1Item_Uid, I).Value, I, False) & vbCrLf
            '        End If
            '    End If
            'Next
            'If ErrMsgStr <> "" Then Clipboard.SetText(ErrMsgStr, TextDataFormat.Text) : MsgBox("Some Bar Codes Are Wrongly Feeded Or Not Exist In Stock." & vbCrLf & "Details Of These BarCodes are pasted to clipboard.", MsgBoxStyle.Information) : passed = False : Exit Sub
        End With
    End Sub

    Private Sub FrmProductionOrder_BaseFunction_BlankText() Handles Me.BaseFunction_BlankText
        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()
    End Sub

    Private Sub FrmYarnSKUOpeningStock_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 646, 907)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Function FRetCarpetStock(ByVal ItemCode As String, ByVal AsOnDate As String, Optional ByVal CondStr As String = "") As Double
        Try
            mQry = " SELECT IsNull(Sum(L.Qty_Rec),0) - IsNull(Sum(L.Qty_Iss),0) AS Qty " & _
                      " FROM ( " & _
                      " SELECT * FROM Stock WHERE Item = '" & ItemCode & "' And V_Date <= '" & AsOnDate & "'   " & CondStr & _
                      " UNION ALL " & _
                      " SELECT * FROM StockProcess WHERE Item = '" & ItemCode & "' And V_Date <= '" & AsOnDate & "'" & CondStr & _
                      " ) AS L "
            FRetCarpetStock = AgL.VNull(AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Private Sub Validating_Item_Uid(ByVal Item_Uid As String, ByVal mRow As Integer)
        Dim DsTemp As DataSet = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim ErrMsgStr$ = ""

        Try
            If ImportMode = True Then
                'ErrMsgStr = FCheck_Item_UID(Dgl1.Item(Col1Item_Uid, mRow).Value, mRow, False)
                'If ErrMsgStr <> "" Then ImportMessegeStr += ErrMsgStr & vbCrLf
            Else
                'ErrMsgStr = FCheck_Item_UID(Dgl1.Item(Col1Item_Uid, mRow).Value, mRow, True)
                'If ErrMsgStr <> "" Then MsgBox(ErrMsgStr) : Exit Sub
            End If

            mQry = " SELECT Iu.Code As Item_UidCode, Iu.Item_UID , Iu.Item AS ItemCode, I.Description AS Item, " & _
                    " I.Unit, I.MeasureUnit, I.Prod_Measure As MeasurePerPcs " & _
                    " FROM Item_UID Iu  " & _
                    " LEFT JOIN Item I ON I.Code = Iu.Item   " & _
                    " WHERE Iu.Item_UID = '" & Item_Uid & "' "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    Dgl1.Item(Col1Item_Uid, mRow).Tag = AgL.XNull(.Rows(0)("Item_UidCode"))

                    Dgl1.Item(Col1Item, mRow).Tag = AgL.XNull(.Rows(0)("ItemCode"))
                    Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(.Rows(0)("Item"))

                    Dgl1.Item(Col1Qty, mRow).Value = 1
                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(.Rows(0)("Unit"))

                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(.Rows(0)("MeasurePerPcs"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(.Rows(0)("MeasureUnit"))


                    FGetPrevProcess(mRow)
                Else
                    'MsgBox("Invalid Item UID !")
                    'Dgl1.Item(Col1Item_Uid, mRow).Value = ""
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Validating_Item(ByVal ItemCode As String, ByVal mRow As Integer)
        Dim DsTemp As DataSet = Nothing
        Dim DtTemp As DataTable = Nothing
        Dim ErrMsgStr$ = ""

        Try
            mQry = " SELECT I.Description AS ItemDesc, I.Unit, I.MeasureUnit, I.Prod_Measure As MeasurePerPcs " & _
                    " FROM Item I " & _
                    " WHERE I.Code = '" & ItemCode & "' "
            DsTemp = AgL.FillData(mQry, AgL.GCn)
            With DsTemp.Tables(0)
                If .Rows.Count > 0 Then
                    Dgl1.Item(Col1Item, mRow).Value = AgL.XNull(.Rows(0)("ItemDesc"))

                    Dgl1.Item(Col1Unit, mRow).Value = AgL.XNull(.Rows(0)("Unit"))

                    Dgl1.Item(Col1MeasurePerPcs, mRow).Value = AgL.VNull(.Rows(0)("MeasurePerPcs"))
                    Dgl1.Item(Col1MeasureUnit, mRow).Value = AgL.XNull(.Rows(0)("MeasureUnit"))

                    'Dgl1.Item(Col1CurrentStock, mRow).Value = FRetCarpetStock(Dgl1.Item(Col1Item, mRow).Tag, TxtV_Date.Text)
                End If
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Function FCheck_Item_UID(ByVal Item_UID As String, ByVal mRowIndex As Integer, ByVal BlankItem_Uid As Boolean) As String
        Dim Item_UidCode$ = "", ErrMsgStr$ = ""
        Dim DtTemp As DataTable = Nothing

        mQry = " SELECT Code FROM Item_UID With (NoLock) WHERE Item_UID = '" & Item_UID & "'"
        Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)
        If Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = "" Then
            If BlankItem_Uid = True Then
                Dgl1.Item(Col1Item_Uid, mRowIndex).Value = ""
                Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = ""
            End If

            FCheck_Item_UID = "Carpet Id Is Not Valid."
            Dgl1.Rows(mRowIndex).DefaultCellStyle.BackColor = Color.Pink

            Exit Function
        Else
            FCheck_Item_UID = ""
        End If

        mQry = " Select I.Div_Code From Item_Uid Iu LEFT JOIN Item I ON Iu.Item = I.Code Where Iu.Code = '" & Dgl1.Item(Col1Item_Uid, mRowIndex).Tag & "'"
        If AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) <> AgL.PubDivCode Then
            If BlankItem_Uid = True Then
                Dgl1.Item(Col1Item_Uid, mRowIndex).Value = ""
                Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = ""
            End If

            FCheck_Item_UID = "Carpet Id " & Item_UID & " Does Not Belong To " & AgL.PubDivName & "."
            Exit Function
        Else
            FCheck_Item_UID = ""
        End If

        mQry = " Select RecDocID From Item_Uid With (NoLock) Where Code = '" & Dgl1.Item(Col1Item_Uid, mRowIndex).Tag & "' "
        If AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) = "" Then
            If BlankItem_Uid = True Then
                Dgl1.Item(Col1Item_Uid, mRowIndex).Value = ""
                Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = ""
            End If

            FCheck_Item_UID = "Carpet Id " & Item_UID & " Is Not Received From Weaving Process."
            Dgl1.Rows(mRowIndex).DefaultCellStyle.BackColor = Color.Pink
            Exit Function
        Else
            FCheck_Item_UID = ""
        End If


        mQry = "SELECT Count(I.DocID) " & _
               " FROM (SELECT DocID, Item_UID FROM JobIssRecUID WITH (NoLock) " & _
               " WHERE Item_UID ='" & Dgl1.Item(Col1Item_Uid, mRowIndex).Tag & "' And IssRec= 'I') I " & _
               " LEFT JOIN JobIssRecUID R WITH (NoLock) ON I.DocID = R.JobRecDocID AND I.Item_UID = R.Item_UID  " & _
               " WHERE R.DocID IS NULL AND I.DocID <> '" & mSearchCode & "'"
        If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) > 0 Then
            mQry = "SELECT TOP 1 Sg.Name, H.ManualRefNo, H.V_Date, Vc.NCatDescription AS ProcessDesc " & _
                    " FROM (SELECT DocID, Item_UID FROM JobIssRecUID WITH (NoLock) " & _
                    " WHERE Item_UID ='" & Dgl1.Item(Col1Item_Uid, mRowIndex).Tag & "' And IssRec='I') I " & _
                    " LEFT JOIN JobIssRecUID R WITH (NoLock) ON I.DocID = R.JobRecDocID AND I.Item_UID = R.Item_UID  " & _
                    " LEFT JOIN JobIssRec H WITH (NoLock) ON I.DocID = H.DocID " & _
                    " LEFT JOIN SubGroup Sg WITH (NoLock) ON H.JobWorker = Sg.SubCode " & _
                    " LEFT JOIN VoucherCat Vc WITH (NoLock) ON H.Process = Vc.NCat " & _
                    " WHERE R.DocID IS NULL AND I.DocID <> '" & mSearchCode & "' " & _
                    " ORDER BY H.V_Date Desc "

            DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
            If BlankItem_Uid = True Then
                Dgl1.Item(Col1Item_Uid, mRowIndex).Value = ""
                Dgl1.Item(Col1Item_Uid, mRowIndex).Tag = ""
            End If
            FCheck_Item_UID = "Carpet Id " & Item_UID & " Is Already Issued To " & AgL.XNull(DtTemp.Rows(0)("Name")) & " For " & AgL.XNull(DtTemp.Rows(0)("ProcessDesc")) & " On Date " & AgL.XNull(DtTemp.Rows(0)("V_Date")) & " Against Ref No " & AgL.XNull(DtTemp.Rows(0)("ManualRefNo")) & "."
            Dgl1.Rows(mRowIndex).DefaultCellStyle.BackColor = Color.Pink
            Exit Function
        End If
    End Function

    Private Sub FImportFromTextFile()
        Dim Sr As StreamReader
        Dim Opn As New OpenFileDialog

        Dim Line$ = "", mDateTime$ = "", mMachine$ = "", mProcess$ = "", mJobRecBy$ = "", mBarcode$ = "", mSKU$ = ""
        Dim mDefaultGodown$ = "", mJobType$ = "", mJobWorker$ = "", mIssRec$ = "", StrQry$ = ""
        Dim ErrorLog$ = "", StrMessage$ = ""

        Dim I As Integer, J As Integer = 0, bBarCodeQty As Integer = 0
        Dim DtTemp As DataTable = Nothing
        Dim strArr() As String


        ImportMessegeStr = ""
        ImportMode = True

        Opn.ShowDialog()

        If Opn.FileName = "" Then Exit Sub

        Sr = New StreamReader(Opn.FileName)

        StrMessage = ""

        Dgl1.RowCount = 1 : Dgl1.Rows.Clear()

        Do
            I += 1
            Line = Sr.ReadLine()
            If Line IsNot Nothing Then
                strArr = Split(Line, ",")

                If strArr.Length <> 8 Then
                    MsgBox("Invalid records in file")
                    Exit Sub
                End If

                Dgl1.Rows.Add()
                Dgl1.Item(ColSNo, I - 1).Value = Dgl1.Rows.Count - 1
                Dgl1.Item(Col1Item_Uid, I - 1).Value = strArr(7)
                Validating_Item_Uid(Dgl1.Item(Col1Item_Uid, Dgl1.Rows.Count - 2).Value, Dgl1.Rows.Count - 2)
                If StrMessage <> "" Then
                    MsgBox(StrMessage)
                    Exit Sub
                End If
            End If
        Loop Until Line Is Nothing
        Sr.Close()
        Calculation()
        ImportMode = False
    End Sub

    Private Sub BtnImprtFromText_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnImprtFromText.Click
        FImportFromTextFile()
    End Sub

    Private Sub TxtGodown_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TxtGodown.KeyDown
        Try
            Select Case sender.Name
                Case TxtGodown.Name
                    If TxtGodown.AgHelpDataSet Is Nothing Then
                        If e.KeyCode <> Keys.Enter Then
                            mQry = "SELECT Code, Description, Site_Code, IsNull(IsDeleted,0) as IsDeleted, IsNull(Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') AS Status FROM Godown Order By Description"
                            TxtGodown.AgHelpDataSet(3, TabControl1.Top + TP1.Top, TabControl1.Left + TP1.Left) = AgL.FillData(mQry, AgL.GCn)
                        End If
                    End If
            End Select

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub FrmPhysicalStockEntry_BaseEvent_Topctrl_tbRef() Handles Me.BaseEvent_Topctrl_tbRef
        If Dgl1.AgHelpDataSet(Col1Item) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Item) = Nothing
        If Dgl1.AgHelpDataSet(Col1Process) IsNot Nothing Then Dgl1.AgHelpDataSet(Col1Process) = Nothing
        If TxtGodown.AgHelpDataSet IsNot Nothing Then TxtGodown.AgHelpDataSet = Nothing
    End Sub

    Private Sub FrmPhysicalStockEntry_BaseEvent_ApproveDeletion_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_ApproveDeletion_InTrans
        mQry = " Delete From Stock Where DocId = '" & mSearchCode & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
    End Sub

    Private Sub FrmDyeingIssue_BaseEvent_Topctrl_tbPrn(ByVal SearchCode As String) Handles Me.BaseEvent_Topctrl_tbPrn
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bCondstr$ = ""
        Try
            Me.Cursor = Cursors.WaitCursor
            AgL.PubReportTitle = "Physical Stock Slip"
            RepName = "Rug_PhysicalStock_Print" : RepTitle = "Physical Stock Slip"
            bCondstr = "WHERE H.DocID = '" & SearchCode & "'"

            strQry = "SELECT H.DocID, H.V_Date, H.ManualRefNo, L.Item, I.Description AS ItemDesc, " & _
                        " L.Item_UID AS Item_UIDCode, Iu.Item_UID AS Item_UIDDesc, IsNull(L.Qty,0) As Qty, L.Unit, IsNull(L.TotalMeasure,0) As TotalMeasure  " & _
                        " FROM StockHead H  " & _
                        " LEFT JOIN StockHeadDetail L ON H.DocID = L.DocID " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN Item_UID Iu ON L.Item_UID = Iu.Code " & _
                        " " & bCondstr & " Order By L.DocID, L.Sr"

            AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)
            Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmPhysicalStockEntry_BaseEvent_Topctrl_tbAdd() Handles Me.BaseEvent_Topctrl_tbAdd
        TxtManualRefNo.Text = AgTemplate.ClsMain.FGetManualRefNo("ManualRefNo", "StockHead", TxtV_Type.AgSelectedValue, TxtV_Date.Text, TxtDivision.AgSelectedValue, TxtSite_Code.AgSelectedValue, AgTemplate.ClsMain.ManualRefType.Max)
    End Sub

    Private Sub FGetPrevProcess(ByVal mRow As Integer)
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0

        mQry = " SELECT Top 1 L.Process, P.Description " & _
                " FROM (SELECT DocId, Item_Uid, Process  FROM JobIssRecUID WHERE Item_UID = '" & Dgl1.Item(Col1Item_Uid, mRow).Tag & "') L  " & _
                " LEFT JOIN JobIssRec H ON L.DocID = H.DocID " & _
                " LEFT JOIN Process P ON L.Process = P.NCat " & _
                " ORDER BY H.V_Date DESC "
        DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

        If DtTemp.Rows.Count > 0 Then
            For I = 0 To DtTemp.Rows.Count - 1
                Dgl1.Item(Col1Process, mRow).Tag = AgL.XNull(DtTemp.Rows(I)("Process"))
                Dgl1.Item(Col1Process, mRow).Value = AgL.XNull(DtTemp.Rows(I)("Description"))
            Next
        End If
    End Sub
End Class
