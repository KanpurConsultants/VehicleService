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
    Private Const JobInvoiceReport As String = "JobInvoiceReport"
    Private Const MaterialIssueOnJobCardReport As String = "MaterialIssueOnJobCardReport"
    Private Const LabourDoneOnJobCardReport As String = "LabourDoneOnJobCardReport"


    Private Const MaterialTrackingSheet As String = "MaterialTrackingSheet"
    Private Const JobCardMISReport As String = "JobCardMISReport"

    Private Const PurchaseInvoiceReport As String = "PurchaseInvoiceReport"

    Private Const JobEstimateReport As String = "JobEstimateReport"
#End Region

#Region "Queries Definition"
    Dim mHelpCityQry$ = "Select 'o' As Tick, CityCode, CityName From City "
    Dim mHelpStateQry$ = "Select 'o' As Tick, State_Code, State_Desc From State "
    Dim mHelpUserQry$ = "Select 'o' As Tick, User_Name As Code, User_Name As [User] From UserMast "
    Dim mHelpSiteQry$ = "Select 'o' As Tick, Code, Name As [Site] From SiteMast Where " & AgL.PubSiteCondition("Code", AgL.PubSiteCode) & " "
    
    Dim mHelpVendorQry$ = " Select 'o' As Tick,  H.SubCode As Code, Sg.DispName AS Vendor FROM Vendor H LEFT JOIN SubGroup Sg ON H.SubCode = Sg.SubCode "
    Dim mHelpPaymentModeQry$ = "Select 'o' As Tick, '" & ClsMain.PaymentMode.Cash & "' As Code, '" & ClsMain.PaymentMode.Cash & "' As Description " & _
                                " UNION ALL " & _
                                " Select 'o' As Tick, '" & ClsMain.PaymentMode.Credit & "' As Code, '" & ClsMain.PaymentMode.Credit & "' As Description "
    Dim mHelpPartyQry$ = " Select 'o' As Tick,  Sg.SubCode As Code, Sg.DispName AS Party FROM SubGroup Sg Where Sg.Nature In ('Customer','Supplier','Cash') "
    Dim mHelpJobCardSingleSelectionQry$ = " Select H.DocID AS Code, H.ManualRefNo FROM Service_JobCard H "
    Dim mHelpJobCardMultiSelectionQry$ = " Select 'o' As Tick,  H.DocID AS Code, H.ManualRefNo FROM Service_JobCard H "

    Dim mHelpEmployeeQry$ = " Select 'o' As Tick,  Sg.SubCode As Code, Sg.Name AS Party FROM SubGroup Sg Where Sg.MasterType = '" & ClsMain.MasterType.Employee & "' "
    Dim mHelpItemQry$ = "Select 'o' As Tick, Code, Description As [Item] From Item "
    Dim mHelpItemGroupQry$ = "Select 'o' As Tick, Code, Description As [Item Group] From ItemGroup "
    Dim mHelpItemCategoryQry$ = "Select 'o' As Tick, Code, Description As [Item Category] From ItemCategory "
    Dim mHelpItemTypeQry$ = "Select 'o' As Tick, Code, Name As [Item Type] From ItemType "
#End Region

    Dim DsRep As DataSet = Nothing, DsRep1 As DataSet = Nothing, DsRep2 As DataSet = Nothing
    Dim mQry$ = "", RepName$ = "", RepTitle$ = "", OrderByStr$ = ""

#Region "Initializing Grid"
    Public Sub Ini_Grid()
        Try
            Dim I As Integer = 0
            Select Case GRepFormName
                Case JobInvoiceReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Summary' as Code, 'Summary' as Name Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Bill To A/c", "Bill To A/c", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry & " Where ItemType  In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Group", "Item Group", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemGroupQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Category", "Item Category", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemCategoryQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Type", "Item Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemTypeQry & " Where Code In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")

                Case MaterialIssueOnJobCardReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Summary' as Code, 'Summary' as Name Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry & " Where ItemType  In ('" & ClsMain.ItemType.Parts & "') ")
                    ReportFrm.CreateHelpGrid("Item Group", "Item Group", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemGroupQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "') ")
                    ReportFrm.CreateHelpGrid("Item Category", "Item Category", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemCategoryQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "') ")
                    ReportFrm.CreateHelpGrid("Item Type", "Item Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemTypeQry & " Where Code In ('" & ClsMain.ItemType.Parts & "') ")
                    ReportFrm.CreateHelpGrid("Issue To Employee", "Issue To Employee", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpEmployeeQry)

                Case LabourDoneOnJobCardReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Summary' as Code, 'Summary' as Name Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry & " Where ItemType  In ('" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Group", "Item Group", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemGroupQry & " Where ItemType In ('" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Category", "Item Category", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemCategoryQry & " Where ItemType In ('" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Type", "Item Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemTypeQry & " Where Code In ('" & ClsMain.ItemType.Labour & "') ")

                Case MaterialTrackingSheet
                    ReportFrm.CreateHelpGrid("JobCard", "Job Card", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, mHelpJobCardSingleSelectionQry, "", , , , , False)
                    ReportFrm.CreateHelpGrid("ItemCategory", "Item Category", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemCategoryQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")

                Case JobCardMISReport
                    ReportFrm.CreateHelpGrid("JobCard", "Job Card", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpJobCardMultiSelectionQry, , , , , , False)

                Case PurchaseInvoiceReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Summary' as Code, 'Summary' as Name Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry)
                    ReportFrm.CreateHelpGrid("Party", "Party", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpPartyQry)
                    ReportFrm.CreateHelpGrid("Site", "Site", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpSiteQry)
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeMultiSelectionQry("PurchInvoice"))

                Case JobEstimateReport
                    ReportFrm.CreateHelpGrid("FromDate", "From Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubStartDate)
                    ReportFrm.CreateHelpGrid("ToDate", "To Date", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.DateType, "", AgL.PubEndDate)
                    ReportFrm.CreateHelpGrid("Report Type", "Report Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.SingleSelection, "Select 'Detail' as Code, 'Detail' as Name Union All Select 'Summary' as Code, 'Summary' as Name Union All Select 'Month Wise Summary' as Code, 'Month Wise Summary' as Name", "Detail", , , , , False)
                    ReportFrm.CreateHelpGrid("Item", "Item", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemQry & " Where ItemType  In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Group", "Item Group", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemGroupQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Category", "Item Category", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemCategoryQry & " Where ItemType In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("Item Type", "Item Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, mHelpItemTypeQry & " Where Code In ('" & ClsMain.ItemType.Parts & "','" & ClsMain.ItemType.Labour & "') ")
                    ReportFrm.CreateHelpGrid("VoucherType", "Voucher Type", ReportLayout.FrmReportLayout.FieldFilterDataType.StringType, ReportLayout.FrmReportLayout.FieldDataType.MultiSelection, FGetVoucher_TypeMultiSelectionQry("SaleQuotation"), "All")
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
#End Region

    Private Sub ObjRepFormGlobal_ProcessReport() Handles ReportFrm.ProcessReport
        Select Case mGRepFormName
            Case JobInvoiceReport
                ProcJobInvoiceReport()

            Case MaterialIssueOnJobCardReport
                ProcMaterialIssueOnJobCardReport(ClsMain.Temp_NCat.ServiceMaterialIssue)

            Case LabourDoneOnJobCardReport
                ProcMaterialIssueOnJobCardReport(ClsMain.Temp_NCat.ServiceLabourDone)

            Case MaterialTrackingSheet
                ProcMaterialTrackingSheet()

            Case JobCardMISReport
                ProcJobCardMISReport()

            Case PurchaseInvoiceReport
                ProcPurchaseInvoiceReport()

            Case JobEstimateReport
                ProcJobEstimateReport()
        End Select
    End Sub

    Public Sub New(ByVal mReportFrm As ReportLayout.FrmReportLayout)
        ReportFrm = mReportFrm
    End Sub

    Private Function FGetVoucher_TypeMultiSelectionQry(ByVal TableName As String) As String
        FGetVoucher_TypeMultiSelectionQry = " SELECT Distinct 'o' As Tick, H.V_Type AS Code, Vt.Description AS [Voucher Type] " & _
                                " FROM " & TableName & " H  " & _
                                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type "
    End Function

    Private Function FGetVoucher_TypeSingleSelectionQry(ByVal TableName As String) As String
        FGetVoucher_TypeSingleSelectionQry = " SELECT Distinct H.V_Type AS Code, Vt.Description AS [Voucher Type] " & _
                                " FROM " & TableName & " H  " & _
                                " LEFT JOIN Voucher_Type Vt ON H.V_Type = Vt.V_Type "
    End Function

#Region "Sale Report"
    Private Sub ProcJobInvoiceReport()
        Try
            RepName = "Trade_SaleReport" : RepTitle = "Job Invoice Report"

            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepTitle = "Job Invoice Report (" & ReportFrm.FGetText(2) & ")"

            If ReportFrm.FGetText(2) = "Summary" Then
                RepName = "Trade_SaleReport"
            ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                RepName = "Trade_SaleReportSummary"
                strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                strGrpFldHead = "'Month'"
                OrderByStr = " Order By H.V_Date"
            ElseIf ReportFrm.FGetText(2) = "Detail" Then
                RepName = "Trade_ItemWiseSaleReport"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            mCondStr = " Where 1 = 1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.BillToParty", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemGroup", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemCategory", 6)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemType", 7)



            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                   " L.DocId, H.V_Date, " & _
                   " H.SaleToPartyName + ',' + IsNull(H.SaleToPartyCityName,'') As SaleToPartyName , H.SaleToPartyAdd1, H.SaleToPartyAdd2,  " & _
                   " H.SaleToPartyCityName, H.SaleToPartyMobile,  " & _
                   " H.ReferenceNo,  H.Remarks, Iu.RegistrationNo, Model.Description As ModelDesc, " & _
                   " I.Description As ItemDesc, L.Rate, " & _
                   " L.Gross_Amount, L.Sales_Tax_Taxable_Amt, L.Vat, L.Sat, L.Discount, L.Other_Charges, " & _
                   " L.Net_Amount, L.Round_Off , L.Landed_Value, L.Qty, L.Unit, J.ManualRefNo as JobCardNo, Party.Name As BillToAc  " & _
                   " FROM SaleInvoice H " & _
                   " Left Join SaleInvoiceDetail L On H.DocID = L.DocID " & _
                   " Left Join Service_JobCard J On H.Service_JobCard = J.DocID " & _
                   " LEFT JOIN Item_Uid Iu On J.Item_Uid = Iu.Code " & _
                   " LEFT JOIN Item Model On Iu.Item = Model.Code " & _
                   " Left Join Item I On L.Item = I.Code " & _
                   " Left Join Subgroup Party On H.BillToParty = Party.SubCode " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Material Issue On Job Card Report"
    Private Sub ProcMaterialIssueOnJobCardReport(ByVal NCat As String)
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            If NCat = ClsMain.Temp_NCat.ServiceMaterialIssue Then
                RepTitle = "Material Issue On Job Card Report (" & ReportFrm.FGetText(2) & ")"
                If ReportFrm.FGetText(2) = "Summary" Then
                    RepName = "Service_MaterialIssueOnJobCardSummary"
                ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                    RepName = "Service_MaterialIssueOnJobCardGroupWise"
                    strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                    strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                    strGrpFldHead = "'Month'"
                    OrderByStr = " Order By H.V_Date"
                ElseIf ReportFrm.FGetText(2) = "Detail" Then
                    RepName = "Service_MaterialIssueOnJobCardItemWise"
                    OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
                End If

                mCondStr = " Where Vt.NCat = '" & NCat & "' "

                mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 3)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemGroup", 4)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemCategory", 5)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemType", 6)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.IssueToSubCode", 7)
            ElseIf NCat = ClsMain.Temp_NCat.ServiceLabourDone Then
                RepTitle = "Labour Done On Job Card Report (" & ReportFrm.FGetText(2) & ")"
                If ReportFrm.FGetText(2) = "Summary" Then
                    RepName = "Service_LabourDoneOnJobCardSummary"
                ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                    RepName = "Service_MaterialIssueOnJobCardGroupWise"
                    strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                    strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                    strGrpFldHead = "'Month'"
                    OrderByStr = " Order By H.V_Date"
                ElseIf ReportFrm.FGetText(2) = "Detail" Then
                    RepName = "Service_LabourDoneOnJobCardItemWise"
                    OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
                End If

                mCondStr = " Where Vt.NCat = '" & NCat & "' "
                mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 3)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemGroup", 4)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemCategory", 5)
                mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemType", 6)
            End If


            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                   " L.DocId, H.V_Date, " & _
                   " H.SaleToPartyAdd1, H.SaleToPartyAdd2,  " & _
                   " H.SaleToPartyMobile,  " & _
                   " H.ReferenceNo,  H.Remarks, Iu.RegistrationNo, Model.Description As ModelDesc, " & _
                   " I.Description As ItemDesc, L.Rate, L.Net_Amount As NetAmount, " & _
                   " L.Qty, L.Unit, J.ManualRefNo as JobCardNo, Emp.Name As IssueToEmployee  " & _
                   " FROM SaleChallan H " & _
                   " Left Join SaleChallanDetail L On H.DocID = L.DocID " & _
                   " LEFT JOIN Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                   " Left Join Service_JobCard J On H.Service_JobCard = J.DocID " & _
                   " LEFT JOIN Item_Uid Iu On J.Item_Uid = Iu.Code " & _
                   " LEFT JOIN Item Model On Iu.Item = Model.Code " & _
                   " Left Join Item I On L.Item = I.Code " & _
                   " Left Join Subgroup Emp On H.IssueToSubCode = Emp.SubCode " & mCondStr & OrderByStr
            DsRep = AgL.FillData(mQry, AgL.GCn)


            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Material Tracking Sheet"
    Private Sub ProcMaterialTrackingSheet()
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepName = "Service_MaterialTrackingSheet" : RepTitle = "Material Tracking Sheet"

            If ReportFrm.FGetCode(0) = "" Then
                MsgBox("Select Job Card...!")
                Exit Sub
            End If

            mCondStr = " Where 1 = 1 "
            mCondStr += " And J.DocId = '" & ReportFrm.FGetCode(0) & "' "
            mCondStr += " And Parts.ItemType <> '" & ClsMain.ItemType.Labour & "'"
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("Parts.ItemCategory", 1)

            mQry = " SELECT J.ManualRefNo As JobCardNo, S.NoOfPanels, Model.Description As ModelDesc, Iu.RegistrationNo, " & _
                    " Parts.Description AS PartDesc, L.Qty, L.Unit, L.Rate, L.Amount, Sg.Name AS MachanicName, " & _
                    " Ig.Description As ItemGroupDesc, Ic.Description As ItemCategoryDesc " & _
                    " FROM SaleChallan H  " & _
                    " LEFT JOIN SaleChallanDetail L ON H.DocID = L.DocId " & _
                    " LEFT JOIN Service_JobCard J ON H.Service_JobCard = J.DocID " & _
                    " LEFT JOIN SaleInvoice S ON J.DocID = S.Service_JobCard " & _
                    " LEFT JOIN Item_UID Iu ON J.Item_Uid = Iu.Code " & _
                    " LEFT JOIN Item Model ON Iu.Item = Model.Code " & _
                    " LEFT JOIN Item Parts ON L.Item = Parts.Code  " & _
                    " LEFT JOIN ItemGroup Ig ON Parts.ItemGroup = Ig.Code " & _
                    " LEFT JOIN ItemCategory Ic ON Parts.ItemCategory = Ic.Code " & _
                    " LEFT JOIN SubGroup Sg ON L.SubCode = Sg.SubCode " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            ReportFrm.PrintReport(DsRep, RepName, RepTitle)
        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Job Card MIS Report"
    Private Sub ProcJobCardMISReport()
        Dim mInvoiceQry$ = "", mEstimateQry$ = "", mChallanQry$ = ""
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            RepName = "Service_JobCardMISReport" : RepTitle = "Job Card MIS Report"

            mCondStr = " Where 1 = 1 "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.DocId", 0)

            mInvoiceQry = " SELECT S.Service_JobCard, Max(S.V_Date) AS V_Date, Max(S.ReferenceNo) AS ReferenceNo, " & _
                            " Max(S.PaidAmt) AS PaidAmt, " & _
                            " Sum(CASE WHEN I.ItemType = 'Parts' THEN Sd.Net_Amount ELSE 0 END) AS Invoiced_Parts, " & _
                            " Sum(CASE WHEN I.ItemType = 'Labour' THEN Sd.Net_Amount ELSE 0 END) AS Invoiced_Labour, " & _
                            " Max(S.Net_Amount) AS TotalInvoiceAmt " & _
                            " FROM SaleInvoice S  " & _
                            " LEFT JOIN SaleInvoiceDetail Sd ON S.DocID = Sd.DocId " & _
                            " LEFT JOIN Item I ON Sd.Item = I.Code " & _
                            " GROUP BY S.Service_JobCard "

            mEstimateQry = " SELECT Q.Service_JobCard, Max(Q.V_Date) AS V_Date, " & _
                            " Sum(CASE WHEN I.ItemType = 'Parts' THEN Qd.Amount ELSE 0 END) AS Estimated_Parts, " & _
                            " Sum(CASE WHEN I.ItemType = 'Labour' THEN Qd.Amount ELSE 0 END) AS Estimated_Labour " & _
                            " FROM SaleQuotation Q  " & _
                            " LEFT JOIN SaleQuotationDetail Qd ON Q.DocID = Qd.DocId " & _
                            " LEFT JOIN Item I ON Qd.Item = I.Code " & _
                            " GROUP BY Q.Service_JobCard "

            mChallanQry = " SELECT C.Service_JobCard, Min(C.V_Date) AS StartDate, Max(C.V_Date) AS EndDate " & _
                            " FROM SaleChallan C " & _
                            " GROUP BY C.Service_JobCard "



            mQry = " SELECT Model.Description AS Model, Iu.RegistrationNo AS Vehicle_Reg_No, " & _
                        " H.OwnerName AS [Customer_Name],  " & _
                        " H.OwnerMobile AS [Customer_Contact_No], " & _
                        " H.Cashless_NonCashLess, " & _
                        " Insurance.ManualCode AS [Name_Of_Insurance_Company_Self_By_Customer],  " & _
                        " H.PolicyNo AS [Insurance_Policy_Number],  " & _
                        " Intimation.V_Date AS [Claim_Registration_Date],  " & _
                        " Intimation.IntimationNo AS [Claim_Number],  " & _
                        " Intimation.SurveyorName AS [Surveyor_Name_if_thru_Insurance], " & _
                        " H.ManualRefNo AS [Repair_Order_RO_No],  " & _
                        " H.V_Date AS [RO_Date],  " & _
                        " H.EstDelDate AS [Promised_Date], " & _
                        " Advisor.Name AS [Service_Advisor_Name],  " & _
                        " Estimate.V_Date AS [Estimate_Date],  " & _
                        " IsNull(Estimate.Estimated_Parts,0) AS Estimated_Parts, " & _
                        " IsNull(Estimate.Estimated_Labour,0) AS Estimated_Labour, " & _
                        " H.No_Of_Panels AS [No_Of_Panels_To_Be_Repaired], " & _
                        " Type.Description AS [Type_Of_Repair],  " & _
                        " Challan.EndDate AS Actual_Vehicle_Ready_Date, " & _
                        " Invoice.V_Date AS [Invoice_Date], " & _
                        " Invoice.ReferenceNo AS [Invoice_No],  " & _
                        " IsNull(Invoice.Invoiced_Parts,0) AS Invoiced_Parts, " & _
                        " IsNull(Invoice.Invoiced_Labour,0) AS Invoiced_Labour, " & _
                        " IsNull(Invoice.TotalInvoiceAmt,0) - IsNull(Invoice.PaidAmt,0) AS [Liability_Amount_Paid_By_Ins], " & _
                        " Invoice.PaidAmt AS [Depriciation_Paid_By_Customer], " & _
                        " Challan.StartDate AS [Removal_Mechanical_And_Accessories_Start_Date], " & _
                        " Challan.EndDate AS [Refitting_And_Mechanical_Job_End_Date], " & _
                        " JobClose.Job_Close_Date AS [Re_Survey_Final_Inspection_Date], " & _
                        " JobClose.Insurance_Libility_Letter_Date AS [Date_Of_Receipt_Of_Insurance_Liability_Letter], " & _
                        " JobClose.Remarks,  " & _
                        " Datediff(DAY,H.V_Date,H.EstDelDate) AS [Estimated_Repair_Time_In_Days], " & _
                        " CASE WHEN JobClose.Job_Close_Date IS NOT NULL THEN Datediff(DAY,H.V_Date,JobClose.Job_Close_Date) ELSE Datediff(DAY,H.V_Date,Invoice.V_Date) END AS [Actual_Repair_Time_Taked_In_Days] " & _
                        " FROM Service_JobCard H  " & _
                        " LEFT JOIN Item_UID Iu ON H.Item_Uid = Iu.Code " & _
                        " LEFT JOIN Item Model ON Iu.Item = Model.Code " & _
                        " LEFT JOIN SubGroup Insurance ON H.InsuranceCompany = Insurance.SubCode " & _
                        " LEFT JOIN SubGroup Advisor ON H.ServiceAdvisor = Advisor.SubCode " & _
                        " LEFT JOIN Service_Type Type ON H.Service_Type = Type.Code " & _
                        " LEFT JOIN Service_InsuranceClaimIntimation Intimation ON h.DocID = Intimation.Service_JobCard " & _
                        " LEFT JOIN (" & mEstimateQry & ") AS Estimate ON H.DocID = Estimate.Service_JobCard " & _
                        " LEFT JOIN (" & mChallanQry & ") AS Challan ON H.DocID = Challan.Service_JobCard " & _
                        " LEFT JOIN (" & mInvoiceQry & ") AS Invoice ON H.DocID = Invoice.Service_JobCard " & _
                        " LEFT JOIN Service_JobCardDetail JobClose ON H.DocId = JobClose.Service_JobCard " & mCondStr
            DsRep = AgL.FillData(mQry, AgL.GCn)

            If DsRep.Tables(0).Rows.Count = 0 Then Err.Raise(1, , "No Records to Print!")

            Dim Frmbj As AgTemplate.FrmReportWindow = New AgTemplate.FrmReportWindow(mQry, RepTitle)
            Frmbj.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
            DsRep = Nothing
        End Try
    End Sub
#End Region

#Region "Purchase Invoice Report"
    Private Sub ProcPurchaseInvoiceReport()
        Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"
        Try
            RepTitle = "Purchase Invoice Report (" & ReportFrm.FGetText(2) & ")"

            If ReportFrm.FGetText(2) = "Summary" Then
                RepName = "Trade_PurchaseReport"
            ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                RepName = "Trade_PurchaseReportSummary"
                strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                strGrpFldHead = "'Month'"
                OrderByStr = " Order By H.V_Date"
            ElseIf ReportFrm.FGetText(2) = "Detail" Then
                RepName = "Trade_ItemWisePurchaseReport"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            Dim mCondStr$ = ""
            mCondStr = " Where Vt.NCat = '" & AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice & "' "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Vendor", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.Site_Code", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 6)

            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                        " L.DocId, L.Sr, L.PurchOrder, L.PurchChallan, L.PurchChallanSr, L.BaleNo, L.Item, I.ManualCode AS ItemManualCode, " & _
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

#Region "Job Estimate Report"
    Private Sub ProcJobEstimateReport()
        Try
            Dim mCondStr$ = ""
            Dim strGrpFld As String = "''", strGrpFldHead As String = "''", strGrpFldDesc As String = "''"

            'If ReportFrm.FGetCode(7) = "" Then
            '    MsgBox("Seelct Voucher Type...!", MsgBoxStyle.Information) : Exit Sub
            'End If

            RepTitle = "Job Estimate Report (" & ReportFrm.FGetText(2) & ")"

            If ReportFrm.FGetText(2) = "Summary" Then
                RepName = "Service_JobEstimateReport"
            ElseIf ReportFrm.FGetText(2) = "Month Wise Summary" Then
                RepName = "Service_JobEstimateReportSummary"
                strGrpFld = "Substring(convert(nvarchar,H.V_Date,11),0,6)"
                strGrpFldDesc = "Replace(SubString(Convert(VARCHAR,H.v_Date,6),4,6),' ','-')"
                strGrpFldHead = "'Month'"
                OrderByStr = " Order By H.V_Date"
            ElseIf ReportFrm.FGetText(2) = "Detail" Then
                RepName = "Service_ItemWiseJobEstimateReport"
                OrderByStr = " Order By  H.V_Date, H.V_No, I.Description "
            End If

            mCondStr = " Where 1 = 1 "

            mCondStr = mCondStr & " AND H.V_Date Between '" & ReportFrm.FGetText(0) & "' And '" & ReportFrm.FGetText(1) & "' "
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("L.Item", 3)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemGroup", 4)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemCategory", 5)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("I.ItemType", 6)
            mCondStr = mCondStr & ReportFrm.GetWhereCondition("H.V_Type", 7)
            mCondStr = mCondStr & " And L.GenDocId Is Null "



            mQry = " SELECT " & strGrpFld & " as GrpField, " & strGrpFldDesc & " as GrpFieldDesc, " & strGrpFldHead & " as GrpFieldHead, " & _
                   " L.DocId, H.V_Date, " & _
                   " H.SaleToPartyName As SaleToPartyName , H.SaleToPartyAdd1, H.SaleToPartyAdd2,  " & _
                   " H.SaleToPartyCityName, H.SaleToPartyMobile,  " & _
                   " H.ReferenceNo,  H.Remarks, Iu.RegistrationNo, Model.Description As ModelDesc, " & _
                   " I.Description As ItemDesc, L.Rate, " & _
                   " L.Gross_Amount, L.Sales_Tax_Taxable_Amt, L.Vat, L.Sat, L.Discount, L.Other_Charges, " & _
                   " L.Net_Amount, L.Round_Off , L.Landed_Value, L.Qty, L.Unit, J.ManualRefNo as JobCardNo, " & _
                   " Vt.Description As Voucher_Type_Desc " & _
                   " FROM SaleQuotation H " & _
                   " Left Join SaleQuotationDetail L On H.DocID = L.DocID " & _
                   " Left Join Voucher_Type Vt On H.V_Type = Vt.V_Type " & _
                   " Left Join Service_JobCard J On H.Service_JobCard = J.DocID " & _
                   " LEFT JOIN Item_Uid Iu On J.Item_Uid = Iu.Code " & _
                   " LEFT JOIN Item Model On Iu.Item = Model.Code " & _
                   " Left Join Item I On L.Item = I.Code " & mCondStr & OrderByStr
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
