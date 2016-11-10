Public Class ClsReportProcedures

#Region "Danger Zone"
    Dim StrArr1() As String = Nothing, StrArr2() As String = Nothing, StrArr3() As String = Nothing, StrArr4() As String = Nothing, StrArr5() As String = Nothing

    Dim mGRepFormName As String = ""

    Dim WithEvents ReportFrm As ReportLayout.FrmReportLayout

    Public Property GRepFormName() As String
        Get
            GRepFormName = mGRepFormName
        End Get
        Set(ByVal value As String)
            mGRepFormName = value
        End Set
    End Property

#End Region

#Region "Common Reports Constant"
    Private Const CityList As String = "CityList"
    Private Const UserWiseEntryReport As String = "UserWiseEntryReport"
    Private Const UserWiseEntryTargetReport As String = "UserWiseEntryTargetReport"
#End Region

#Region "Reports Constant"
    Private Const SaleReport As String = "SaleReport"
    Private Const ItemWiseSaleReport As String = "SaleReportItemWise"

    Private Const PurchaseReport As String = "PurchaseReport"
    Private Const ItemWisePurchaseReport As String = "PurchaseReportItemWise"

    Private Const PurchaseReturnReport As String = "PurchaseReturnReport"
    Private Const ItemWisePurchaseReturnReport As String = "PurchaseReturnReportItemWise"

    Private Const SaleOrderReport As String = "OrderReport"
    Private Const ItemWiseSaleOrderReport As String = "OrderReportItemWise"

    Private Const SaleOrderCancelReport As String = "OrderCancelReport"
    Private Const ItemWiseSaleOrderCancelReport As String = "OrderCancelReportItemWise"

    Private Const SaleQuotationReport As String = "SaleQuotationReport"
    Private Const ItemWiseSaleQuotationReport As String = "SaleQuotationReportItemWise"

    Private Const SaleOrderStatusReport As String = "OrderStatusReport"
    Private Const SaleOrderStatusReportFIFO As String = "OrderStatusReportFIFO"

    Private Const InspectionRequestReport As String = "InspectionRequestReport"
    Private Const InspectionReport As String = "InspectionReport"

    Private Const OrderInspectionRequestStatusReport As String = "OrderInspectionRequestStatusReport"
    Private Const OrderInspectionStatusReport As String = "OrderInspectionStatusReport"

    Private Const InspectionRequestStatusReport As String = "InspectionRequestStatusReport"
#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select 'o' As Tick, CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select 'o' As Tick, State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select 'o' As Tick, User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpSiteQry$ = "Select 'o' As Tick, Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    Dim mHelpItemQry$ = "Select 'o' As Tick, Code, Description As [Item] From Item "
    Dim mHelpVendorQry$ = " Select 'o' As Tick,  H.SubCode As Code, Sg.DispName AS Vendor FROM Vendor H LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode "
    Dim mHelpTableQry$ = "Select 'o' As Tick, H.Code, H.Description AS [Table] FROM HT_Table H "
    Dim mHelpPaymentModeQry$ = "Select 'o' As Tick, '" & ClsMain.PaymentMode.Cash & "' As Code, '" & ClsMain.PaymentMode.Cash & "' As Description " & _
                                " UNION ALL " & _
                                " Select 'o' As Tick, '" & ClsMain.PaymentMode.Credit & "' As Code, '" & ClsMain.PaymentMode.Credit & "' As Description "
    Dim mHelpOutletQry$ = "Select 'o' As Tick, H.Code, H.Description AS [Table] FROM Outlet H "
    Dim mHelpStewardQry$ = "Select 'o' As Tick,  Sg.SubCode AS Code, Sg.DispName AS Steward FROM SubGroup Sg  "
    Dim mHelpPartyQry$ = " Select 'o' As Tick,  Sg.SubCode As Code, Sg.DispName AS Party FROM SubGroup Sg Where Sg.Nature In ('Customer','Supplier','Cash') "
    Dim mHelpSaleOrderQry$ = " Select 'o' As Tick,  H.DocID AS Code, H.V_Type + '-' + H.ReferenceNo  FROM SaleOrder H "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = "", OrderByStr$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case SaleReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Supplier Wise Summary' as Code, 'Supplier Wise Summary' as Name  Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name Union All Select 'Size Wise Summary' as Code, 'Size Wise Summary' as Name  Union All Select 'Collection Wise Summary' as Code, 'Collection Wise Summary' as Name   Union All Select 'Item Wise Detail' as Code, 'Item Wise Detail' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("SaleInvoice"))

                Case ItemWiseSaleReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)

                Case PurchaseReport, PurchaseReturnReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("PurchInvoice"))

                Case ItemWisePurchaseReport, ItemWisePurchaseReturnReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("PurchInvoice"))

                Case SaleOrderReport, SaleOrderCancelReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Supplier Wise Summary' as Code, 'Supplier Wise Summary' as Name  Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name Union All Select 'Size Wise Summary' as Code, 'Size Wise Summary' as Name  Union All Select 'Collection Wise Summary' as Code, 'Collection Wise Summary' As Name Union All Select 'Item Wise Detail' As Code, 'Item Wise Detail' As Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("SaleOrder"))

                Case ItemWiseSaleOrderReport, ItemWiseSaleOrderCancelReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("SaleOrder", "Sale Order No", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSaleOrderQry)

                Case SaleQuotationReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("SaleQuotation"))

                Case ItemWiseSaleQuotationReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeQry("SaleQuotation"))

                Case SaleOrderStatusReport
                    ReportFrm.CreateHelpGrid("FromDate", "Order From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "Order Upto Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("AsOnDate", "Status On Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubLoginDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Order Detail Dispatch Detail' as Code, 'Order Detail Dispatch Detail' as Name Union All Select 'Order Detail Dispatch Summary' as Code, 'Order Detail Dispatch Summary' as Name Union All Select 'Supplier Wise Summary' as Code, 'Supplier Wise Summary' as Name Union All Select 'Order No Wise Summary' as Code, 'Order No Wise Summary' as Name Union All Select 'Item Wise Summary' as Code, 'Item Wise Summary' as Name", "Order Detail Dispatch Summary", , , 250)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)

                Case SaleOrderStatusReportFIFO
                    ReportFrm.CreateHelpGrid("FromDate", "Sale Order From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "Sale Order Upto Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("AsOnDate", "Status On Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubLoginDate)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)

                Case InspectionRequestReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Summary' as Code, 'Summary' as Name Union All Select 'Item Wise Detail' as Code, 'Item Wise Detail' as Name", "Summary", , , , , False)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)

                Case InspectionReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Summary' as Code, 'Summary' as Name Union All Select 'Item Wise Detail' as Code, 'Item Wise Detail' as Name", "Summary", , , , , False)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)

                Case OrderInspectionRequestStatusReport
                    ReportFrm.CreateHelpGrid("FromDate", "Order From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "Order Upto Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("AsOnDate", "Status On Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubLoginDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'All' As Code, 'All' as Name Union All Select 'Pending' as Code, 'Pending' as Name")
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)

                Case OrderInspectionStatusReport
                    ReportFrm.CreateHelpGrid("FromDate", "Order From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "Order Upto Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("AsOnDate", "Status On Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubLoginDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'All' As Code, 'All' as Name Union All Select 'Pending' as Code, 'Pending' as Name")
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)

                Case InspectionRequestStatusReport
                    ReportFrm.CreateHelpGrid("FromDate", "Order From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "Order Upto Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("AsOnDate", "Status On Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubLoginDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'All' As Code, 'All' as Name Union All Select 'Pending For QC' as Code, 'Pending For QC' as Name Union All Select 'Not Pending For QC' as Code, 'Not Pending For QC' as Name")
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Supplier", "Supplier", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRepFormGlobal_ProcessReport() Handles ReportFrm.ProcessReport
        Select Case mGRepFormName
            Case SaleReport
                ProcSaleReport()

            Case ItemWiseSaleReport
                ProcItemWiseSaleReport()

            Case PurchaseReport
                ProcPurchaseReport(AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, "Trade_PurchaseReport", "Purchase Report")

            Case ItemWisePurchaseReport
                ProcItemWisePurchaseReport(AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice, "Trade_ItemWisePurchaseReport", "Item Wise Purchase Report")

            Case PurchaseReturnReport
                ProcPurchaseReport(AgTemplate.ClsMain.Temp_NCat.PurchaseReturn, "Trade_PurchaseReport", "Purchase Return Report")

            Case ItemWisePurchaseReturnReport
                ProcItemWisePurchaseReport(AgTemplate.ClsMain.Temp_NCat.PurchaseReturn, "Trade_ItemWisePurchaseReport", "Item Wise Purchase Return Report")

            Case SaleOrderReport
                ProcSaleOrderReport(AgTemplate.ClsMain.Temp_NCat.SaleOrder, "Trade_SaleOrderReport", "Sale Order Report")

            Case ItemWiseSaleOrderReport
                ProcItemWiseSaleOrderReport(AgTemplate.ClsMain.Temp_NCat.SaleOrder, "Trade_ItemWiseSaleOrderReport", "Item Wise Sale Order Report")

            Case SaleOrderCancelReport
                ProcSaleOrderReport(AgTemplate.ClsMain.Temp_NCat.SaleOrderCancel, "Trade_SaleOrderReport", "Sale Order Cancel Report")

            Case ItemWiseSaleOrderCancelReport
                ProcItemWiseSaleOrderReport(AgTemplate.ClsMain.Temp_NCat.SaleOrderCancel, "Trade_ItemWiseSaleOrderReport", "Item Wise Sale Order Cancel Report")

            Case SaleQuotationReport
                ProcSaleQuotationReport()

            Case ItemWiseSaleQuotationReport
                ProcItemWiseSaleQuotationReport()

            Case SaleOrderStatusReport
                ProcSaleOrderStatusReport()

            Case SaleOrderStatusReportFIFO
                ProcSaleOrderStatusReportFIFO()

            Case InspectionRequestReport
                ProcOrderQCRequestReport()

            Case InspectionReport
                ProcOrderQCReport()

            Case OrderInspectionRequestStatusReport
                ProcOrderQCRequestStatusReport()

            Case OrderInspectionStatusReport
                ProcOrderQCStatusReport()

            Case InspectionRequestStatusReport
                ProcQCRequestStatusReport()
        End Select
    End Sub

    Public Sub New(ByVal mReportFrm As ReportLayout.FrmReportLayout)
        ReportFrm = mReportFrm
    End Sub

#Region "Sale Report"
    Private Sub ProcSaleReport()
        Try
            RepName = "Trade_SaleReport" : RepTitle = "Sale Report"


            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            If ReportFrm.FGetText(2) = "Detail" Then
                RepName = "Trade_SaleReport" : RepTitle = "Sale Invoice Report"
                OrderByStr = " Order By  Supplier.ManualCode, H.V_Date, H.V_No "
            ElseIf ReportFrm.FGetText(2) = "Party Wise Summary" Then
                RepName = "Trade_SaleReportSummary" : RepTitle = "Sale Invoice Report (" & ReportFrm.FGetText(2) & ")"
                strGrpFld = "H.SaleToParty"
                strGrpFldDesc = "Party.ManualCode"
                strGrpFldHead = "'Party Code'"
            ElseIf ReportFrm.FGetText(2) = "Supplier Wise Summary" Then
                RepName = "Trade_SaleReportSummary" : RepTitle = "Sale Invoice Report (" & ReportFrm.FGetText(2) & ")"
                'strGrpFld = "L.Supplier"
                strGrpFld = "Supplier.ManualCode"
                strGrpFldDesc = "Supplier.ManualCode"
                strGrpFldHead = "'Supplier Code'"
                OrderByStr = " Order By  Supplier.ManualCode "
            ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                RepName = "Trade_SaleReportSummary" : RepTitle = "Sale Invoice Report (" & ReportFrm.FGetText(2) & ")"
                strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                strGrpFldHead = "'Month'"
                OrderByStr = " Order By H.V_Date"
            ElseIf ReportFrm.FGetText(2) = "Size Wise Summary" Then
                RepName = "Trade_SaleReportSummary" : RepTitle = "Sale Invoice Report (" & ReportFrm.FGetText(2) & ")"
                strGrpFld = "(Case When Size.Code Is Null Then IG.Description Else Size.Code End)"
                strGrpFldDesc = "(Case When Size.Code Is Null Then IG.Description Else Size.Description End)"
                strGrpFldHead = "'Size'"
                OrderByStr = " Order By L.MeasurePerPcs Desc "
            ElseIf ReportFrm.FGetText(2) = "Collection Wise Summary" Then
                RepName = "Trade_SaleReportSummary" : RepTitle = "Sale Invoice Report (" & ReportFrm.FGetText(2) & ")"
                'strGrpFld = "Collection.Code"
                strGrpFld = "Collection.Description"
                strGrpFldDesc = "Collection.Description"
                strGrpFldHead = "'Collection'"
                OrderByStr = " Order By Collection.Description"
            ElseIf ReportFrm.FGetText(2) = "Item Wise Detail" Then
                RepName = "Trade_ItemWiseSaleReport" : RepTitle = "Item Wise Sale Report"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            mCondStr = " Where 1 = 1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 6)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 7)

            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                   " H.DocID, H.V_Type, H.V_Date, " & _
                    " H.SaleToParty, Party.ManualCode as SaleToPartyCode, H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') As SaleToPartyName , H.SaleToPartyAdd1, H.SaleToPartyAdd2,  " & _
                    " H.SaleToPartyCity, H.SaleToPartyCityName, H.SaleToPartyMobile,  " & _
                    " H.Currency, C.Description as Currency_Description, H.SalesTaxGroupParty, H.ReferenceNo,  " & _
                    " H.Remarks, H.EntryBy, H.EntryDate, I.Description As ItemDesc, Ig.Description As ItemGroupDesc, L.Rate, " & _
                    " H.EntryStatus, H.ApproveBy, H.ApproveDate, H.Status, H.ShipmentThrough, " & _
                    " L.Gross_Amount, L.Freight, L.Discount, L.Other_Charges, L.Net_Amount, L.Round_Off , L.Landed_Value, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, Supplier.ManualCode as Supplier_Code, SO.ReferenceNo as SaleOrderNo  " & _
                    " FROM SaleInvoice H " & _
                    " Left Join SaleInvoiceDetail L On H.DocID = L.DocID " & _
                    " Left Join SaleOrder SO On L.SaleOrder = SO.DocID " & _
                    " Left Join Item I On L.Item = I.Code " & _
                    " Left Join ItemGroup IG On I.ItemGroup = IG.Code " & _
                    " Left Join Rug_Size Size On I.Size = Size.Code " & _
                    " Left Join Rug_Collection Collection On I.Collection = Collection.Code " & _
                    " Left Join Currency C On H.Currency = C.Code " & _
                    " Left Join Subgroup Party On H.SaleToParty = Party.SubCode " & _
                    " Left Join Subgroup Supplier On H.Supplier = Supplier.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr

            DsRep = AgL.FillData(mQry, AgL.GCn)



            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Sale Report"
    Private Sub ProcItemWiseSaleReport()
        Try
            RepName = "Trade_ItemWiseSaleReport" : RepTitle = "Item Wise Sale Report"

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.SaleInvoice & "' "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 2)

            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 5)

            mQry = " SELECT L.DocId, L.Sr, L.SaleOrder, L.SaleOrderSr, L.SaleChallan, L.SaleChallanSr, L.BaleNo, L.Item, I.ManualCode AS ItemManualCode, L.SalesTaxGroupItem, L.DocQty, " & _
                        " L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.ReferenceDocId,  " & _
                        " L.LotNo, L.UID, L.Specification, L.Gross_Amount, " & _
                        " L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges, L.Round_Off, L.Net_Amount, L.Landed_Value, " & _
                        " I.Description AS ItemDesc, H.V_Date, H.ReferenceNo, " & _
                        " H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') AS SaleToPartyName, L.Remark, " & _
                        " Ig.Description As ItemGroupDesc, Supplier.ManualCode as Supplier_Code " & _
                        " FROM SaleInvoiceDetail L " & _
                        " LEFT JOIN SaleInvoice H ON L.DocId = H.DocId " & _
                        " Left Join SubGroup Supplier On Supplier.SubCode = H.Supplier " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN ItemGroup Ig On I.ItemGroup = Ig.Code " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Report"
    Private Sub ProcPurchaseReport(ByVal NCat As String, ByVal mRepName As String, ByVal mRepTitle As String)
        Try
            RepName = mRepName : RepTitle = mRepTitle

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & NCat & "' "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Vendor", 2)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 4)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code, H.ReferenceNo, H.Vendor, " & _
                        " Sg.DispName + ',' + IsNull(C.CityName,'') As VendorName, Sg.Add1, Sg.Add2, Sg.Add3, C.CityName As VendorCityName , H.PurchOrder, " & _
                        " H.PurchChallan, H.Currency,  " & _
                        " H.SalesTaxGroupParty, H.Structure, H.BillingType, H.Form, H.FormNo, H.ReferenceDocId, H.Remarks, H.TotalQty,  " & _
                        " H.TotalMeasure, H.TotalAmount, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus, H.ApproveBy, H.ApproveDate,  " & _
                        " H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status, H.UID, H.Godown, H.Vendor,  " & _
                        " H.Gross_Amount, " & _
                        " H.Discount_Per, H.Discount, H.Other_Charges_Per,  " & _
                        " H.Other_Charges, H.Round_Off, H.Net_Amount " & _
                        " FROM PurchInvoice H  " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & _
                        " LEFT JOIN City C On Sg.CityCode = C.CityCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Purchase Report"
    Private Sub ProcItemWisePurchaseReport(ByVal NCat As String, ByVal mRepName As String, ByVal mRepTitle As String)
        Try
            RepName = mRepName : RepTitle = mRepTitle

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & NCat & "' "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Vendor", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT L.DocId, L.Sr, L.PurchOrder, L.PurchChallan, L.PurchChallanSr, L.BaleNo, L.Item, I.ManualCode AS ItemManualCode, " & _
                        " L.SalesTaxGroupItem, L.DocQty, " & _
                        " L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalDocMeasure, L.TotalMeasure, L.Rate, L.Amount, L.ReferenceDocId,  " & _
                        " L.LotNo, L.UID, L.Specification, L.Gross_Amount, " & _
                        " L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges, L.Round_Off, L.Net_Amount, " & _
                        " I.Description AS ItemDesc, H.V_Date, H.ReferenceNo, Sg.DispName + ',' + IsNull(C.CityName,'') As VendorName, L.Remark " & _
                        " FROM PurchInvoiceDetail L " & _
                        " LEFT JOIN PurchInvoice H ON L.DocId = H.DocId " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN Item I ON L.Item = I.Code " & _
                        " LEFT JOIN SubGroup Sg On H.Vendor = Sg.SubCode " & _
                        " LEFT JOIN City C On Sg.CityCode = C.CityCode " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Order Report"
    Private Sub ProcSaleOrderReport(ByVal NCat As String, ByVal mRepName As String, ByVal mRepTitle As String)
        Try
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            If ReportFrm.FGetText(2) = "Detail" Then
                RepName = "Trade_SaleOrderReport" : RepTitle = "Order Report"
                OrderByStr = " Order By  H.V_Date "
            ElseIf ReportFrm.FGetText(2) = "Party Wise Summary" Then
                RepName = "Trade_SaleOrderReportSummary" : RepTitle = "Order Report (" & ReportFrm.FGetText(2) & ")"
                'strGrpFld = "H.SaleToParty"
                strGrpFld = "Party.ManualCode"
                strGrpFldDesc = "Party.ManualCode"
                strGrpFldHead = "'Party Code'"
            ElseIf ReportFrm.FGetText(2) = "Supplier Wise Summary" Then
                RepName = "Trade_SaleOrderReportSummary" : RepTitle = "Order Report (" & ReportFrm.FGetText(2) & ")"
                'strGrpFld = "L.Supplier"
                strGrpFld = "Supplier.ManualCode"
                strGrpFldDesc = "Supplier.ManualCode"
                strGrpFldHead = "'Supplier Code'"
                OrderByStr = " Order By Supplier.ManualCode "
            ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                RepName = "Trade_SaleOrderReportSummary" : RepTitle = "Order Report (" & ReportFrm.FGetText(2) & ")"
                strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                strGrpFldHead = "'Month'"
                OrderByStr = " Order By H.V_Date "
            ElseIf ReportFrm.FGetText(2) = "Size Wise Summary" Then
                RepName = "Trade_SaleOrderReportSummary" : RepTitle = "Order Report (" & ReportFrm.FGetText(2) & ")"
                strGrpFld = "(Case When Size.Code Is Null Then IG.Description Else Size.Code End)"
                strGrpFldDesc = "(Case When Size.Code Is Null Then IG.Description Else Size.Description End)"
                strGrpFldHead = "'Size'"
                OrderByStr = " Order By L.MeasurePerPcs Desc "
            ElseIf ReportFrm.FGetText(2) = "Collection Wise Summary" Then
                RepName = "Trade_SaleOrderReportSummary" : RepTitle = "Order Report (" & ReportFrm.FGetText(2) & ")"
                'strGrpFld = "Collection.Code"
                strGrpFld = "Collection.Description"
                strGrpFldDesc = "Collection.Description"
                strGrpFldHead = "'Collection'"
                OrderByStr = " Order By Collection.Description"
            ElseIf ReportFrm.FGetText(2) = "Item Wise Detail" Then
                RepName = "Trade_ItemWiseSaleOrderReport" : RepTitle = "Item Wise Order Report"
                OrderByStr = " Order By  H.V_Date, I.Description "
            End If

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1 And L.GenDocId Is Null "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 6)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 7)


            'If NCat = AgTemplate.ClsMain.Temp_NCat.SaleOrderCancel Then
            '    mCondStr = mCondStr & " And Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.SaleOrderCancel & "'"
            'End If

            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                   " H.DocID, L.DocID as LineDocId, H.V_Type, H.V_Date, LH.V_Date as LineV_Date, LH.V_Type as LineV_Type, LH.ReferenceNo as LineReferenceNo, " & _
                    " H.SaleToParty, Party.ManualCode as SaleToPartyCode, H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') As SaleToPartyName , H.SaleToPartyAdd1, H.SaleToPartyAdd2,  " & _
                    " H.SaleToPartyCity, H.SaleToPartyCityName, H.SaleToPartyState, H.SaleToPartyCountry,  H.SaleToPartyMobile,  " & _
                    " H.ShipToParty, H.ShipToPartyName, H.ShipToPartyAdd1, H.ShipToPartyAdd2,  " & _
                    " H.ShipToPartyCity, H.ShipToPartyCityName, H.ShipToPartyState, H.ShipToPartyCountry,  " & _
                    " H.Currency, C.Description as Currency_Description, H.SalesTaxGroupParty, H.ReferenceNo,  " & _
                    " H.PartyOrderNo, H.PartyOrderDate, H.PartyDeliveryDate, H.PartyDeliveryTime, " & _
                    " H.TermsAndConditions, H.Remarks, H.EntryBy, H.EntryDate, " & _
                    " H.EntryStatus, H.ApproveBy, H.ApproveDate, H.Status, H.ShipmentThrough, " & _
                    " H.PriceMode, H.Agent, H.ReferencePartyDocumentNo, H.ReferencePartyDocumentDate, H.OrderType, H.ReferenceParty,  " & _
                    " Sg.DispName AS ReferencePartyName, I.Description As ItemDesc, Ig.Description As ItemGroupDesc, L.Rate, " & _
                    " L.Gross_Amount, L.Freight, L.Discount, L.Other_Charges, L.Net_Amount, L.Round_Off , L.Landed_Value, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, Supplier.ManualCode as Supplier_Code " & _
                    " FROM SaleOrderDetail L " & _
                    " Left Join SaleOrder H On H.DocID = L.SaleOrder " & _
                    " Left Join SaleOrder LH On LH.DocID = L.DocID " & _
                    " Left Join Item I On L.Item = I.Code " & _
                    " Left Join ItemGroup IG On I.ItemGroup = IG.Code " & _
                    " Left Join Rug_Size Size On I.Size = Size.Code " & _
                    " Left Join Rug_Collection Collection On I.Collection = Collection.Code " & _
                    " Left Join Currency C On H.Currency = C.Code " & _
                    " Left Join Subgroup Party On H.SaleToParty = Party.SubCode " & _
                    " Left Join Subgroup Supplier On L.Supplier = Supplier.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On LH.V_Type = Vt.V_Type " & _
                    " LEFT JOIN SubGroup Sg ON H.ReferenceParty = Sg.SubCode  " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Sale Order Report"
    Private Sub ProcItemWiseSaleOrderReport(ByVal NCat As String, ByVal mRepName As String, ByVal mRepTitle As String)
        Try
            RepName = "Trade_ItemWiseSaleOrderReport" : RepTitle = "Item Wise Sale Order Report"

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.SaleOrder & "' "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 2)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.DocId", 6)

            mQry = " SELECT L.DocId, L.Sr, L.Vendor, L.Item, L.Specification, L.PartySKU, L.PartyUPC,  " & _
                         " L.SalesTaxGroupItem, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit, L.TotalMeasure,  " & _
                         " L.SaleOrder, L.BillingType, L.StockMeasurePerPcs, L.StockTotalMeasure, L.Rate, L.Amount,  " & _
                         " L.ShippedQty, L.ShippedMeasure, L.ProdOrdQty, L.ProdOrdMeasure, L.ProdPlanQty,  " & _
                         " L.ProdPlanMeasure, L.PurchQty, L.PurchMeasure, L.ProdIssQty, L.ProdIssMeasure,  " & _
                         " L.ProdRecQty, L.ProdRecMeasure, L.Priority, L.DeliveryOrderQty, L.DeliveryOrderMeasure,  " & _
                         " L.UID, L.Gross_Amount, L.Discount_Pre_Tax_Per, L.Discount_Pre_Tax,  " & _
                         " L.Other_Additions_Pre_Tax_Per, L.Other_Additions_Pre_Tax, L.Sales_Tax_Taxable_Amt,  " & _
                         " L.Vat_Per, L.Vat, L.Sat_Per, L.Sat, L.Discount_Per, L.Discount, L.Other_Charges_Per,  " & _
                         " L.Other_Charges, L.Round_Off, L.Net_Amount, L.Landed_Value, L.DeliveryMeasure,  " & _
                         " L.DeliveryMeasurePerPcs, L.TotalDeliveryMeasure, L.Supplier, L.Freight_Per, L.Freight,  " & _
                         " L.DeliveryMeasureMultiplier, L.PartySpecification, L.SaleOrderSr, L.RateType, " & _
                         " H.V_Date, H.ReferenceNo, H.SaleToPartyName + ',' + IsNull(H.ShipToPartyCityName,'') As SaleToPartyName , " & _
                         " I.Description AS ItemDesc, Ig.Description As ItemGroupDesc, H.PartyOrderNo, Supplier.ManualCode as Supplier_Code " & _
                         " FROM SaleOrderDetail L " & _
                         " LEFT JOIN SaleOrder H ON L.DocId = H.DocID " & _
                         " Left Join Subgroup Supplier On L.Supplier = Supplier.SubCode " & _
                         " LEFT JOIN Item I ON L.Item = I.Code " & _
                         " LEFT JOIN ItemGroup Ig On I.ItemGroup = Ig.Code " & _
                         " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Quotation Report"
    Private Sub ProcSaleQuotationReport()
        Try
            RepName = "Trade_SaleQuotationReport" : RepTitle = "Sale Quotation Report"

            Dim mCondStr$ = ""

            mCondStr = " Where 1=1 "
            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 2)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT H.DocID, H.V_Type, H.V_Prefix, H.V_Date, H.V_No, H.Div_Code, H.Site_Code,  " & _
                        " H.Party, H.Currency, H.Structure, H.BillingType, H.PartyEnquiryNo, H.PartyEnquiryDate,  " & _
                        " H.TermsAndConditions, H.Remarks, H.TotalQty, H.TotalMeasure, H.TotalAmount, H.NetAmount,  " & _
                        " H.PostingGroupSalesTaxParty, H.EntryBy, H.EntryDate, H.EntryType, H.EntryStatus,  " & _
                        " H.ApproveBy, H.ApproveDate, H.MoveToLog, H.MoveToLogDate, H.IsDeleted, H.Status,  " & _
                        " H.UID, H.PriceMode, H.ReferenceNo, H.Agent, H.SaleToParty,  " & _
                        " H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') AS SaleToPartyName,  " & _
                        " H.SaleToPartyAdd1, H.SaleToPartyAdd2, H.SaleToPartyCity, H.SaleToPartyMobile,  " & _
                        " H.Supplier, H.CustomFields, H.SalesTaxGroupParty, H.PartyDocNo, H.PartyDocDate,  " & _
                        " H.TotalDeliveryMeasure, H.SaleToPartyCityName, H.Gross_Amount, H.Freight_Per, H.Freight,  " & _
                        " H.Discount_Per, H.Discount, H.Other_Charges_Per, H.Other_Charges, H.Round_Off,  " & _
                        " H.Net_Amount, H.Landed_Value " & _
                        " FROM SaleQuotation H " & _
                        " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & mCondStr

            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Item Wise Sale Quotation Report"
    Private Sub ProcItemWiseSaleQuotationReport()
        Try
            RepName = "Trade_ItemWiseSaleQuotationReport" : RepTitle = "Item Wise Sale Quotation Report"

            Dim mCondStr$ = ""
            mCondStr = " Where 1=1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 2)

            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 5)

            mQry = " SELECT L.DocId, L.Sr, L.Vendor, L.Item, L.Qty, L.Unit, L.MeasurePerPcs, L.MeasureUnit,  " & _
                        " L.TotalMeasure, L.Rate, L.Amount, L.NetAmount, L.PostingGroupSalesTaxItem,  " & _
                        " L.OrdQty, L.OrdMeasure, L.DispatchQty, L.DispatchMeasure, L.UID, L.Remarks,  " & _
                        " L.SaleEnquiry, L.Supplier, L.Specification, L.DeliveryMeasure, L.SalesTaxGroupItem,  " & _
                        " L.DeliveryMeasureMultiplier, L.TotalDeliveryMeasure, L.Gross_Amount, L.Freight_Per,  " & _
                        " L.Freight, L.Discount_Per, L.Discount, L.Other_Charges_Per, L.Other_Charges,  " & _
                        " L.Round_Off, L.Net_Amount, L.Landed_Value, L.BillingType, L.RateType, L.SaleQuotation,  " & _
                        " L.SaleQuotationSr,H.V_Date, H.ReferenceNo,  " & _
                        " H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') AS SaleToPartyName, " & _
                        " I.Description As ItemDesc, Ig.Description As ItemGroupDesc " & _
                        " FROM SaleQuotationDetail L  " & _
                        " LEFT JOIN SaleQuotation H ON L.DocId = H.DocID " & _
                        " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type " & _
                        " LEFT JOIN Item I ON L.Item = i.Code " & _
                        " LEFT JOIN ItemGroup Ig ON I.ItemGroup = Ig.Code" & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Sale Order Status Report"
    Private Sub ProcSaleOrderStatusReport()
        Try


            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"


            If ReportFrm.FGetText(3) = "Order Detail Dispatch Detail" Then
                RepName = "Agency_SaleOrderStatusReport" : RepTitle = "Order Status Report (Dispatch Detail)"
            ElseIf ReportFrm.FGetText(3) = "Order Detail Dispatch Summary" Then
                RepName = "Agency_SaleOrderStatusReportDispatchSummary" : RepTitle = "Order Status Report (Dispatch Summary)"
                OrderByStr = " Order By  H.V_Date, (Case When IsNumeric(H.ReferenceNo)>0 Then Convert(Numeric,H.ReferenceNo) Else 0 End) "
            ElseIf ReportFrm.FGetText(3) = "Supplier Wise Summary" Then
                RepName = "Agency_SaleOrderStatusReportSupplierSummary" : RepTitle = "Order Status Report (Supplier Wise Summary) "
            ElseIf ReportFrm.FGetText(3) = "Order No Wise Summary" Then
                RepName = "Agency_SaleOrderStatusReportSummary" : RepTitle = "Order Status Report (Order No Wise Summary) "
                strGrpFld = "H.DocID"
                strGrpFldDesc = "H.ReferenceNo"
                strGrpFldHead = "'Order No'"
                OrderByStr = " Order By H.ReferenceNo "
            ElseIf ReportFrm.FGetText(3) = "Item Wise Summary" Then
                RepName = "Agency_SaleOrderStatusReportItemWiseSummary" : RepTitle = "Order Status Report (Item Wise Summary) "
                strGrpFld = "L.Item"
                strGrpFldDesc = "I.Description"
                strGrpFldHead = "'Item'"
                OrderByStr = " Order By I.Description "
            End If

            mCondStr = " Where 1=1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 6)

            mQry = "  SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                    " H.V_Date AS SaleOrderDate, I.Description AS ItemDesc, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, " & _
                    " VChallan.SaleChallanNo, VChallan.SaleChallanDate, IsNull(VChallan.ChallanQty,0) As ChallanQty, IsNull(VChallan.ChallanMeasure,0) As ChallanMeasure, " & _
                    " Party.ManualCode as Party_Code, Sg.ManualCode AS SupplierCode, " & _
                    " L.SaleOrder as DocId, L.SaleOrderSr as Sr, H.V_Type, H.ReferenceNo As SaleOrderRefNo, H.PartyOrderNo, H.PartyDeliveryDate, " & _
                    " L.DocId + Convert(nVarChar, L.Sr) As LineDocIdSr " & _
                    " FROM SaleOrderDetail L  " & _
                    " LEFT JOIN SaleOrder H ON L.SaleOrder = H.DocID " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Scd.SaleOrder, Scd.SaleOrderSr, " & _
                    "   Sc.V_Type + '-' + Sc.ReferenceNo AS SaleChallanNo,  " & _
                    " 	Sc.V_Date AS SaleChallanDate, 	Scd.Qty AS ChallanQty, Scd.TotalMeasure as ChallanMeasure " & _
                    " 	FROM SaleChallanDetail Scd " & _
                    " 	LEFT JOIN SaleChallan Sc ON Scd.DocId = Sc.DocID " & _
                    "   Where Sc.V_Date <= '" & ReportFrm.FGetText(2) & "' " & _
                    "   And IsNull(Sc.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " ) AS VChallan ON L.DocId = VChallan.SaleOrder AND L.Sr = VChallan.SaleOrderSr " & _
                    " LEFT JOIN Item I ON L.Item = I.Code " & _
                    " LEFT JOIN SubGroup Party ON H.SaleToParty = Party.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON L.Supplier = Sg.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

    '#Region "Sale Order Status Report FIFO"
    '    Private Sub ProcSaleOrderStatusReportFIFO()
    '        Dim DtTemp As DataTable = Nothing
    '        Dim bQry$ = ""
    '        Dim I As Integer = 0
    '        Dim bTempTable$ = ""
    '        Dim bPendingToAdjustQty As Double = 0
    '        Try
    '            RepName = "Agency_SaleOrderStatusReportFIFO" : RepTitle = "Sale Order Status Report (FIFO)"

    '            Dim mCondStr$ = ""
    '            mCondStr = " Where Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.SaleOrder & "' And IsNull(VChallan.ChallanQty,0) > 0 "

    '            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
    '            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
    '            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 4)
    '            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)


    '            mQry = " SELECT H.V_Date AS SaleOrderDate, I.Description AS ItemDesc, l.Unit,  " & _
    '                        " VChallan.SaleChallanNo, VChallan.SaleChallanDate,  " & _
    '                        " Sg.ManualCode AS SupplierCode,   " & _
    '                        " H.V_Type + '-' +  H.ReferenceNo As SaleOrderRefNo,  " & _
    '                        " Dl.DeliveryDate, L.DocId, DL.Sr, " & _
    '                        " Dl.Qty AS SaleOrderDeliveryQty, IsNull(VChallan.ChallanQty,0) As ChallanQty, 0 As AdjustmentQty " & _
    '                        " FROM SaleOrderDetail L  " & _
    '                        " LEFT JOIN SaleOrderDeliveryDetail Dl ON Dl.DocId = L.DocId AND Dl.TSr = L.Sr " & _
    '                        " LEFT JOIN SaleOrder H ON L.DocId = H.DocID " & _
    '                        " LEFT JOIN ( " & _
    '                        "  	SELECT Scd.SaleOrder, Scd.SaleOrderSr, Sc.V_Type + '-' + Sc.ReferenceNo AS SaleChallanNo,    " & _
    '                        "  	Sc.V_Date AS SaleChallanDate, 	Scd.Qty AS ChallanQty   " & _
    '                        "  	FROM SaleChallanDetail Scd   " & _
    '                        "  	LEFT JOIN SaleChallan Sc ON Scd.DocId = Sc.DocId " & _
    '                        "   Where Sc.V_Date <= '" & ReportFrm.FGetText(2) & "' " & _
    '                        "   And IsNull(Sc.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
    '                        " )  " & _
    '                        " AS VChallan ON L.DocId = VChallan.SaleOrder AND L.Sr = VChallan.SaleOrderSr   " & _
    '                        " LEFT JOIN Item I ON L.Item = I.Code   " & _
    '                        " LEFT JOIN SubGroup Sg ON L.Supplier = Sg.SubCode   " & _
    '                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type  " & mCondStr & _
    '                        " Order By L.DocId, L.Sr "
    '            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)

    '            If DtTemp.Rows.Count > 0 Then
    '                For I = 0 To DtTemp.Rows.Count - 1
    '                    If I <> 0 Then
    '                        If AgL.XNull(DtTemp.Rows(I)("DocId")) = AgL.XNull(DtTemp.Rows(I - 1)("DocId")) And AgL.XNull(DtTemp.Rows(I)("Sr")) = AgL.XNull(DtTemp.Rows(I - 1)("Sr")) Then
    '                            If AgL.VNull(DtTemp.Rows(I)("SaleOrderDeliveryQty")) <= bPendingToAdjustQty Then
    '                                DtTemp.Rows(I)("AdjustmentQty") = AgL.VNull(DtTemp.Rows(I)("SaleOrderDeliveryQty"))
    '                                bPendingToAdjustQty = bPendingToAdjustQty - AgL.VNull(DtTemp.Rows(I)("SaleOrderDeliveryQty"))
    '                            Else
    '                                DtTemp.Rows(I)("AdjustmentQty") = bPendingToAdjustQty
    '                                bPendingToAdjustQty = 0
    '                            End If
    '                        Else
    '                            If AgL.VNull(DtTemp.Rows(I)("SaleOrderDeliveryQty")) <= AgL.VNull(DtTemp.Rows(I)("ChallanQty")) Then
    '                                DtTemp.Rows(I)("AdjustmentQty") = AgL.VNull(DtTemp.Rows(I)("SaleOrderDeliveryQty"))
    '                                bPendingToAdjustQty = AgL.VNull(DtTemp.Rows(I)("ChallanQty")) - DtTemp.Rows(I)("AdjustmentQty")
    '                            Else
    '                                DtTemp.Rows(I)("AdjustmentQty") = AgL.VNull(DtTemp.Rows(I)("ChallanQty"))
    '                                bPendingToAdjustQty = 0
    '                            End If
    '                        End If
    '                    Else
    '                        If AgL.VNull(DtTemp.Rows(0)("SaleOrderDeliveryQty")) <= AgL.VNull(DtTemp.Rows(0)("ChallanQty")) Then
    '                            DtTemp.Rows(I)("AdjustmentQty") = AgL.VNull(DtTemp.Rows(0)("SaleOrderDeliveryQty"))
    '                            bPendingToAdjustQty = AgL.VNull(DtTemp.Rows(0)("ChallanQty")) - DtTemp.Rows(I)("AdjustmentQty")
    '                        Else
    '                            DtTemp.Rows(I)("AdjustmentQty") = AgL.VNull(DtTemp.Rows(0)("ChallanQty"))
    '                            bPendingToAdjustQty = 0
    '                        End If
    '                    End If
    '                Next
    '            End If

    '            DsRep = DtTemp.DataSet

    '            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

    '            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
    '        Catch ex As Exception
    '            MsgBox(ex.Message)
    '            DsRep = Nothing
    '        End Try
    '    End Sub
    '#End Region

#Region "Sale Order Status Report FIFO"
    Private Sub ProcSaleOrderStatusReportFIFO()
        Dim DtSaleOrderDelivery As DataTable = Nothing
        Dim DtSaleChallanDetail As DataTable = Nothing
        Dim DtMain As DataTable = Nothing
        Dim bQry$ = ""
        Dim I As Integer = 0, J As Integer = 0
        Dim bTempTable$ = ""
        Dim bPendingToAdjustQty As Double = 0
        Try
            RepName = "Agency_SaleOrderStatusReportFIFO" : RepTitle = "Sale Order Status Report (FIFO)"

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.SaleOrder & "' And IsNull(VChallan.ChallanQty,0) > 0 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)

            mQry = " SELECT H.V_Date AS SaleOrderDate, I.Description AS ItemDesc, l.Unit, " & _
                        " Sg.ManualCode AS SupplierCode,     " & _
                        " H.V_Type + '-' +  H.ReferenceNo As SaleOrderRefNo,    " & _
                        " Dl.DeliveryDate, L.DocId, DL.TSr, Dl.Sr, " & _
                        " Dl.Qty AS SaleOrderDeliveryQty,  Dl.Qty  As PendingToAdjustQty " & _
                        " FROM SaleOrderDetail L    " & _
                        " LEFT JOIN SaleOrderDeliveryDetail Dl ON Dl.DocId = L.DocId AND Dl.TSr = L.Sr   " & _
                        " LEFT JOIN SaleOrder H ON L.DocId = H.DocID   " & _
                        " LEFT JOIN Item I ON L.Item = I.Code     " & _
                        " LEFT JOIN SubGroup Sg ON L.Supplier = Sg.SubCode     " & _
                        " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type    " & _
                        " WHere H.ReferencenO = '2'" & _
                        " Order By L.DocId, DL.TSr, DL.Sr  "
            DtSaleOrderDelivery = AgL.FillData(mQry, AgL.GCn).Tables(0)

            mQry = " SELECT '' AS SaleOrderDate, '' ItemDesc, '' As Unit, " & _
                        " '' AS SupplierCode,     " & _
                        " '' As SaleOrderRefNo,    " & _
                        " '' As DeliveryDate, '' As DocId, '' As TSr, '' As Sr, " & _
                        " 0 AS SaleOrderDeliveryQty ,'' As  SaleChallanNo, '' As SaleChallanDate, 0 As ChallanQty " & _
                        " Where 1=2 "
            DtMain = AgL.FillData(mQry, AgL.GCn).Tables(0)

            If DtSaleOrderDelivery.Rows.Count > 0 Then
                While I < DtSaleOrderDelivery.Rows.Count

                    If I = 566 Then
                        MsgBox("")
                    End If

                    DtMain.Rows.Add()
                    DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderDate") = DtSaleOrderDelivery.Rows(I)("SaleOrderDate")
                    DtMain.Rows(DtMain.Rows.Count - 1)("ItemDesc") = DtSaleOrderDelivery.Rows(I)("ItemDesc")
                    DtMain.Rows(DtMain.Rows.Count - 1)("Unit") = DtSaleOrderDelivery.Rows(I)("Unit")
                    DtMain.Rows(DtMain.Rows.Count - 1)("SupplierCode") = DtSaleOrderDelivery.Rows(I)("SupplierCode")
                    DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderRefNo") = DtSaleOrderDelivery.Rows(I)("SaleOrderRefNo")
                    DtMain.Rows(DtMain.Rows.Count - 1)("DeliveryDate") = DtSaleOrderDelivery.Rows(I)("DeliveryDate")
                    DtMain.Rows(DtMain.Rows.Count - 1)("DocId") = DtSaleOrderDelivery.Rows(I)("DocId")
                    DtMain.Rows(DtMain.Rows.Count - 1)("TSr") = DtSaleOrderDelivery.Rows(I)("TSr")
                    DtMain.Rows(DtMain.Rows.Count - 1)("Sr") = DtSaleOrderDelivery.Rows(I)("Sr")
                    DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderDeliveryQty") = DtSaleOrderDelivery.Rows(I)("SaleOrderDeliveryQty")




                    mQry = " SELECT L.SaleOrder, L.SaleOrderSr, VChallan.SaleChallanNo, " & _
                            " VChallan.SaleChallanDate, VChallan.ChallanQty, VChallan.ChallanQty As ToBeAdjustQty " & _
                            " FROM SaleOrderDetail L  " & _
                            " LEFT JOIN ( " & _
                            " 	  SELECT Scd.SaleOrder, Scd.SaleOrderSr, Sc.V_Type + '-' + Sc.ReferenceNo AS SaleChallanNo,     " & _
                            "     Sc.V_Date AS SaleChallanDate, Scd.Qty AS ChallanQty    " & _
                            "     FROM SaleChallanDetail Scd    " & _
                            "     LEFT JOIN SaleChallan Sc ON Scd.DocId = Sc.DocId) " & _
                            " AS VChallan ON L.DocId = VChallan.SaleOrder AND L.Sr = VChallan.SaleOrderSr " & _
                            " WHERE L.DocId = '" & AgL.XNull(DtSaleOrderDelivery.Rows(I)("DocId")) & "'  AND L.Sr = " & AgL.VNull(DtSaleOrderDelivery.Rows(I)("TSr")) & " "
                    If I = 0 Then
                        DtSaleChallanDetail = AgL.FillData(mQry, AgL.GCn).Tables(0)
                        J = 0
                    Else
                        If AgL.XNull(DtSaleOrderDelivery.Rows(I)("DocId")) <> AgL.XNull(DtSaleOrderDelivery.Rows(I - 1)("DocId")) Or AgL.VNull(DtSaleOrderDelivery.Rows(I)("TSr")) <> AgL.VNull(DtSaleOrderDelivery.Rows(I - 1)("TSr")) Then
                            DtSaleChallanDetail = AgL.FillData(mQry, AgL.GCn).Tables(0)
                            J = 0
                        End If
                    End If
                    While J < DtSaleChallanDetail.Rows.Count
                        If J > 0 Then
                            DtMain.Rows.Add()
                            DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderDate") = DtSaleOrderDelivery.Rows(I)("SaleOrderDate")
                            DtMain.Rows(DtMain.Rows.Count - 1)("ItemDesc") = DtSaleOrderDelivery.Rows(I)("ItemDesc")
                            DtMain.Rows(DtMain.Rows.Count - 1)("Unit") = DtSaleOrderDelivery.Rows(I)("Unit")
                            DtMain.Rows(DtMain.Rows.Count - 1)("SupplierCode") = DtSaleOrderDelivery.Rows(I)("SupplierCode")
                            DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderRefNo") = DtSaleOrderDelivery.Rows(I)("SaleOrderRefNo")
                            DtMain.Rows(DtMain.Rows.Count - 1)("DeliveryDate") = DtSaleOrderDelivery.Rows(I)("DeliveryDate")
                            DtMain.Rows(DtMain.Rows.Count - 1)("DocId") = DtSaleOrderDelivery.Rows(I)("DocId")
                            DtMain.Rows(DtMain.Rows.Count - 1)("TSr") = DtSaleOrderDelivery.Rows(I)("TSr")
                            DtMain.Rows(DtMain.Rows.Count - 1)("Sr") = DtSaleOrderDelivery.Rows(I)("Sr")
                            DtMain.Rows(DtMain.Rows.Count - 1)("SaleOrderDeliveryQty") = DtSaleOrderDelivery.Rows(I)("SaleOrderDeliveryQty")
                        End If
                        If DtSaleChallanDetail.Rows(J)("ToBeAdjustQty") > 0 Then
                            DtMain.Rows(DtMain.Rows.Count - 1)("SaleChallanNo") = DtSaleChallanDetail.Rows(J)("SaleChallanNo")
                            DtMain.Rows(DtMain.Rows.Count - 1)("SaleChallanDate") = DtSaleChallanDetail.Rows(J)("SaleChallanDate")
                            If AgL.VNull(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty")) < AgL.VNull(DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty")) Then
                                DtMain.Rows(DtMain.Rows.Count - 1)("ChallanQty") = DtSaleChallanDetail.Rows(J)("ToBeAdjustQty")
                                DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty") = Val(DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty")) - Val(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty"))
                                DtSaleChallanDetail.Rows(J)("ToBeAdjustQty") = 0
                                J += 1

                            ElseIf AgL.VNull(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty")) > AgL.VNull(DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty")) Then
                                DtMain.Rows(DtMain.Rows.Count - 1)("ChallanQty") = DtSaleOrderDelivery.Rows(J)("PendingToAdjustQty")
                                DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty") = 0
                                DtSaleChallanDetail.Rows(J)("ToBeAdjustQty") = Val(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty")) - Val(DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty"))
                                I += 1
                            ElseIf AgL.VNull(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty")) = AgL.VNull(DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty")) Then
                                DtMain.Rows(DtMain.Rows.Count - 1)("ChallanQty") = AgL.VNull(DtSaleChallanDetail.Rows(J)("ToBeAdjustQty"))
                                DtSaleOrderDelivery.Rows(I)("PendingToAdjustQty") = 0
                                DtSaleChallanDetail.Rows(J)("ToBeAdjustQty") = 0
                                I += 1 : J += 1
                            End If


                        End If
                    End While
                    If J >= DtSaleChallanDetail.Rows.Count Then
                        I += 1
                    End If

                End While
            End If

            DsRep = DtMain.DataSet

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message & " I = " & I.ToString & " J = " & J.ToString)
            DsRep = Nothing
        End Try
    End Sub
#End Region

    Private Function FGetVoucher_TypeQry(ByVal TableName As String) As String
        FGetVoucher_TypeQry = " SELECT Distinct 'o' As Tick, H.V_Type AS Code, Vt.Description AS [Voucher Type] " & _
                                " FROM " & TableName & " H  " & _
                                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type "
    End Function

#Region "QC Request Status Report"
    Private Sub ProcOrderQCRequestStatusReport()
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepName = "Agency_SaleOrderQCReqStatusReport" : RepTitle = "Order Status for Inspection Request Report"

            mCondStr = " Where 1=1 "

            If ReportFrm.FGetText(3) = "Pending" Then
                mCondStr = mCondStr & " And L.Qty - IsNull(VQcReq.QCReqQty,0) > 0 "
            End If

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 6)

            mQry = "  SELECT H.V_Date AS SaleOrderDate, I.Description AS ItemDesc, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, " & _
                    " VQcReq.SaleQcReqNo, VQcReq.SaleQcReqDate, IsNull(VQcReq.QCReqQty,0) As QCReqQty, " & _
                    " IsNull(VQcReq.QCReqMeasure,0) As QCReqMeasure, " & _
                    " Party.ManualCode as Party_Code, Sg.ManualCode AS SupplierCode, " & _
                    " L.SaleOrder as DocId, L.SaleOrderSr as Sr, H.V_Type, H.ReferenceNo As SaleOrderRefNo, " & _
                    " H.PartyOrderNo, H.PartyDeliveryDate, " & _
                    " L.DocId + Convert(nVarChar, L.Sr) As LineDocIdSr " & _
                    " FROM SaleOrderDetail L  " & _
                    " LEFT JOIN SaleOrder H ON L.SaleOrder = H.DocID " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Sqd.SaleOrder, Sqd.SaleOrderSr, " & _
                    "   Sq.V_Type + '-' + Sq.ReferenceNo AS SaleQcReqNo,  " & _
                    " 	Sq.V_Date AS SaleQcReqDate, Sqd.Qty AS QCReqQty, Sqd.TotalMeasure as QCReqMeasure " & _
                    " 	FROM SaleQCReqDetail Sqd " & _
                    " 	LEFT JOIN SaleQCReq Sq ON Sqd.DocId = Sq.DocID " & _
                    "   Where Sq.V_Date <= '" & ReportFrm.FGetText(2) & "' " & _
                    "   And IsNull(Sq.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " ) AS VQcReq ON L.DocId = VQcReq.SaleOrder AND L.Sr = VQcReq.SaleOrderSr " & _
                    " LEFT JOIN Item I ON L.Item = I.Code " & _
                    " LEFT JOIN SubGroup Party ON H.SaleToParty = Party.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON L.Supplier = Sg.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "QC Status Report"
    Private Sub ProcOrderQCStatusReport()
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepName = "Agency_SaleOrderQCStatusReport" : RepTitle = "Order Status for Inspection Report"

            mCondStr = " Where 1=1 "

            If ReportFrm.FGetText(3) = "Pending" Then
                mCondStr = mCondStr & " And L.Qty - IsNull(VQc.QCQty,0) > 0 "
            End If

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.SaleToParty", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Supplier", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 6)

            mQry = "  SELECT H.V_Date AS SaleOrderDate, I.Description AS ItemDesc, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, " & _
                    " VQc.SaleQcNo, VQc.SaleQcDate, IsNull(VQc.QCQty,0) As QCQty, " & _
                    " IsNull(VQc.QCMeasure,0) As QCMeasure, " & _
                    " Party.ManualCode as Party_Code, Sg.ManualCode AS SupplierCode, " & _
                    " L.SaleOrder as DocId, L.SaleOrderSr as Sr, H.V_Type, H.ReferenceNo As SaleOrderRefNo, H.PartyOrderNo, H.PartyDeliveryDate, " & _
                    " L.DocId + Convert(nVarChar, L.Sr) As LineDocIdSr " & _
                    " FROM SaleOrderDetail L  " & _
                    " LEFT JOIN SaleOrder H ON L.SaleOrder = H.DocID " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Sqd.SaleOrder, Sqd.SaleOrderSr, " & _
                    "   Sq.V_Type + '-' + Sq.ReferenceNo AS SaleQcNo,  " & _
                    " 	Sq.V_Date AS SaleQcDate, Sqd.QCQty AS QCQty, Sqd.TotalQCMeasure as QCMeasure " & _
                    " 	FROM SaleQCDetail Sqd " & _
                    " 	LEFT JOIN SaleQC Sq ON Sqd.DocId = Sq.DocID " & _
                    "   Where Sq.V_Date <= '" & ReportFrm.FGetText(2) & "' " & _
                    "   And IsNull(Sq.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " ) AS VQc ON L.DocId = VQc.SaleOrder AND L.Sr = VQc.SaleOrderSr " & _
                    " LEFT JOIN Item I ON L.Item = I.Code " & _
                    " LEFT JOIN SubGroup Party ON H.SaleToParty = Party.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON L.Supplier = Sg.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "QC Request Status Report"
    Private Sub ProcQCRequestStatusReport()
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepName = "Agency_QCReqStatusReport" : RepTitle = "Inspection Request Status Report"

            mCondStr = " Where 1=1 "

            If ReportFrm.FGetText(3) = "Pending For QC" Then
                mCondStr = mCondStr & " And L.Qty - IsNull(VQc.QCQty,0) > 0 "
            ElseIf ReportFrm.FGetText(3) = "Not Pending For QC" Then
                mCondStr = mCondStr & " And L.Qty - IsNull(VQc.QCQty,0) = 0 "
            End If

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Buyer", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 6)

            mQry = "  SELECT H.V_Date AS SaleQCReqDate, I.Description AS ItemDesc, L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, " & _
                    " VQc.SaleQcNo, VQc.SaleQcDate, IsNull(VQc.QCQty,0) As QCQty, " & _
                    " IsNull(VQc.QCMeasure,0) As QCMeasure, " & _
                    " Party.ManualCode As Party_Code, Sg.ManualCode AS SupplierCode, " & _
                    " L.DocId As DocId, L.Sr As Sr, H.V_Type, H.ReferenceNo As SaleQCReqRefNo, " & _
                    " So.ReferenceNo As SaleOrderRefNo, " & _
                    " L.DocId + Convert(nVarChar, L.Sr) As LineDocIdSr, " & _
                    " DateDiff(DAY,H.V_Date, IsNull(VQc.SaleQcDate,'" & ReportFrm.FGetText(2) & "')) As DaysAfterReq, " & _
                    " IsNull(VQc.FailedQty,0) As FailedQty " & _
                    " FROM SaleQCReqDetail L  " & _
                    " LEFT JOIN SaleQCReq H ON L.DocId = H.DocID " & _
                    " LEFT JOIN SaleOrder So On L.SaleOrder = So.DocId " & _
                    " LEFT JOIN ( " & _
                    " 	SELECT Sqd.SaleQcReq, Sqd.SaleQcReqSr, " & _
                    "   Sq.V_Type + '-' + Sq.ReferenceNo AS SaleQcNo,  " & _
                    " 	Sq.V_Date AS SaleQcDate, Sqd.QCQty AS QCQty, Sqd.TotalQCMeasure as QCMeasure, " & _
                    "   Sqd.QCQty - Sqd.PassedQty As FailedQty " & _
                    " 	FROM SaleQCDetail Sqd " & _
                    " 	LEFT JOIN SaleQC Sq ON Sqd.DocId = Sq.DocID " & _
                    "   Where Sq.V_Date <= '" & ReportFrm.FGetText(2) & "' " & _
                    "   And IsNull(Sq.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                    " ) AS VQc ON L.DocId = VQc.SaleQcReq AND L.Sr = VQc.SaleQcReqSr " & _
                    " LEFT JOIN Item I ON L.Item = I.Code " & _
                    " LEFT JOIN SubGroup Party ON H.Buyer = Party.SubCode " & _
                    " LEFT JOIN SubGroup Sg ON H.Supplier = Sg.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Order QC Request Report"
    Private Sub ProcOrderQCRequestReport()
        Try
            RepName = "Trade_OrderQCRequestReport" : RepTitle = "Inspection Request Report"

            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            If ReportFrm.FGetText(2) = "Summary" Then
                RepName = "Agency_OrderQCRequestReport" : RepTitle = "Inspection Request Report"
                OrderByStr = " Order By  H.V_Date, H.V_No "
            ElseIf ReportFrm.FGetText(2) = "Item Wise Detail" Then
                RepName = "Agency_ItemWiseQCReqestReport" : RepTitle = "Item Wise Inspection Request Report"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            mCondStr = " Where 1 = 1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Buyer", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 6)

            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                    " H.DocID, H.V_Type, H.V_Date, " & _
                    " H.Buyer, Party.ManualCode as SaleToPartyCode, H.ReferenceNo,  " & _
                    " H.Remarks, H.EntryBy, H.EntryDate, I.Description As ItemDesc, Ig.Description As ItemGroupDesc, " & _
                    " H.EntryStatus, H.ApproveBy, H.ApproveDate, H.Status, " & _
                    " L.Qty, L.Unit, L.TotalMeasure, L.MeasureUnit, Supplier.ManualCode as Supplier_Code, " & _
                    " So.ReferenceNo As SaleOrderRefNo, L.OrderQty, L.TotalOrderMeasure " & _
                    " FROM SaleQCReq H " & _
                    " Left Join SaleQCReqDetail L On H.DocID = L.DocID " & _
                    " LEFT JOIN SaleOrder So On L.SaleOrder = So.DocId " & _
                    " Left Join Item I On L.Item = I.Code " & _
                    " Left Join ItemGroup IG On I.ItemGroup = IG.Code " & _
                    " Left Join Rug_Size Size On I.Size = Size.Code " & _
                    " Left Join Rug_Collection Collection On I.Collection = Collection.Code " & _
                    " Left Join Subgroup Party On H.Buyer = Party.SubCode " & _
                    " Left Join Subgroup Supplier On H.Supplier = Supplier.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Order QC Report"
    Private Sub ProcOrderQCReport()
        Try
            RepName = "Trade_OrderQCReport" : RepTitle = "Inspection Report"

            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            If ReportFrm.FGetText(2) = "Summary" Then
                RepName = "Agency_OrderQCReport" : RepTitle = "Inspection Report"
                OrderByStr = " Order By  H.V_Date, H.V_No "
            ElseIf ReportFrm.FGetText(2) = "Item Wise Detail" Then
                RepName = "Agency_ItemWiseQCReport" : RepTitle = "Item Wise Inspection Report"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            mCondStr = " Where 1 = 1 "
            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Buyer", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Supplier", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 6)

            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                    " H.DocID, H.V_Type, H.V_Date, " & _
                    " H.Buyer, Party.ManualCode as SaleToPartyCode, H.ReferenceNo,  " & _
                    " H.Remarks, H.EntryBy, H.EntryDate, I.Description As ItemDesc, Ig.Description As ItemGroupDesc, " & _
                    " H.EntryStatus, H.ApproveBy, H.ApproveDate, H.Status, " & _
                    " L.QcQty, L.Unit, L.TotalQcMeasure, L.MeasureUnit, Supplier.ManualCode as Supplier_Code, " & _
                    " So.ReferenceNo As SaleOrderRefNo, L.OrderQty, L.TotalOrderMeasure, Sqr.ReferenceNo As SaleQcReqRefNo, " & _
                    " L.CheckedQty, L.TotalCheckedMeasure, L.PassedQty, L.TotalPassedMeasure " & _
                    " FROM SaleQC H " & _
                    " Left Join SaleQCDetail L On H.DocID = L.DocID " & _
                    " LEFT JOIN SaleOrder So On L.SaleOrder = So.DocId " & _
                    " LEFT JOIN SaleQcReq Sqr On L.SaleQCReq = Sqr.DocId " & _
                    " Left Join Item I On L.Item = I.Code " & _
                    " Left Join ItemGroup IG On I.ItemGroup = IG.Code " & _
                    " Left Join Rug_Size Size On I.Size = Size.Code " & _
                    " Left Join Rug_Collection Collection On I.Collection = Collection.Code " & _
                    " Left Join Subgroup Party On H.Buyer = Party.SubCode " & _
                    " Left Join Subgroup Supplier On H.Supplier = Supplier.SubCode " & _
                    " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region
End Class
