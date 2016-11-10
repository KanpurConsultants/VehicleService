Public Class ClsFunction
    Dim WithEvents ObjRepFormGlobal As AgLibrary.RepFormGlobal
    Dim WithEvents ReportFrm As ReportLayout.FrmReportLayout
    Dim CRepProc As ClsReportProcedures

    Public Function FOpen(ByVal StrSender As String, ByVal StrSenderText As String, Optional ByVal IsEntryPoint As Boolean = True)
        Dim FrmObj As Form
        Dim StrUserPermission As String
        Dim DTUP As New DataTable
        Dim ADMain As OleDb.OleDbDataAdapter = Nothing
        Dim MDI As New MDIMain

        'For User Permission Open
        StrUserPermission = AgIniVar.FunGetUserPermission(ClsMain.ModuleName, StrSender, StrSenderText, DTUP)
        ''For User Permission End 

        If IsEntryPoint Then
            Select Case StrSender
                Case MDI.MnuDesignationMaster.Name
                    FrmObj = New FrmDesignation(StrUserPermission, DTUP)

                Case MDI.MnuDepartmentMaster.Name
                    FrmObj = New FrmDepartment(StrUserPermission, DTUP)

                Case MDI.MnuServiceQuotationAmendment.Name
                    FrmObj = New FrmServiceQuotationAmendment(StrUserPermission, DTUP)

                Case MDI.MnuVehicleMaster.Name
                    FrmObj = New FrmVehicle(StrUserPermission, DTUP)

                Case MDI.MnuPurchaseInvoiceEntry.Name
                    'FrmObj = New Purchase.FrmPurchInvoice(StrUserPermission, DTUP, ClsMain.ItemType.Parts)
                    FrmObj = New FrmPurchInvoice(StrUserPermission, DTUP, AgTemplate.ClsMain.Temp_NCat.PurchaseInvoice)

                Case MDI.MnuPhysicalStock.Name
                    FrmObj = New FrmPhysicalStockEntry(StrUserPermission, DTUP, AgTemplate.ClsMain.Temp_NCat.PhysicalStockEntry)

                Case MDI.MnuPhysicalStockAdjustment.Name
                    FrmObj = New FrmPhysicalStockAdjustmentEntry(StrUserPermission, DTUP, ClsMain.Temp_NCat.PhysicalStockAdjustment, AgTemplate.ClsMain.Temp_NCat.PhysicalStockEntry, ClsMain.ItemType.Parts)

                Case MDI.MnuStoreIssueEntry.Name
                    FrmObj = New FrmStoreIssue(StrUserPermission, DTUP, ClsMain.Temp_NCat.StoreIssue)

                Case MDI.MnuStoreReceive.Name
                    FrmObj = New FrmStoreReceive(StrUserPermission, DTUP, ClsMain.Temp_NCat.StoreReceive)

                Case MDI.MnuJobCardDetail.Name
                    FrmObj = New FrmJobCardDetail(StrUserPermission, DTUP)

                Case MDI.MnuInsuranceClaimIntimation.Name
                    FrmObj = New FrmInsuranceClaimIntimation(StrUserPermission, DTUP)

                Case MDI.MnuJobInvoice.Name
                    FrmObj = New FrmSaleInvoice(StrUserPermission, DTUP)

                Case MDI.MnuServiceQuotation.Name
                    FrmObj = New FrmServiceQuotation(StrUserPermission, DTUP)

                Case MDI.MnuLabourGroupMaster.Name
                    FrmObj = New FrmLabourGroup(StrUserPermission, DTUP)

                Case MDI.MnuLabourTypeMaster.Name
                    FrmObj = New FrmLabourType(StrUserPermission, DTUP)

                Case MDI.MnuGodownMaster.Name
                    FrmObj = New FrmGodown(StrUserPermission, DTUP)

                Case MDI.MnuModelCategoryMaster.Name
                    FrmObj = New FrmModelCategory(StrUserPermission, DTUP)

                Case MDI.MnuModelGroupMaster.Name
                    FrmObj = New FrmModelGroup(StrUserPermission, DTUP)

                Case MDI.MnuLobourDoneOnJobCard.Name
                    FrmObj = New FrmLabourDoneOnJobCard(StrUserPermission, DTUP)

                Case MDI.MnuMaterialIssueOnJobCard.Name
                    FrmObj = New FrmMaterialIssueToJobCard(StrUserPermission, DTUP)

                Case MDI.MnuJobCard.Name
                    FrmObj = New FrmJobCard(StrUserPermission, DTUP)

                Case MDI.MnuInsuranceCompanyMaster.Name
                    FrmObj = New FrmInsuranceCompany(StrUserPermission, DTUP)

                Case MDI.MnuModelMaster.Name
                    FrmObj = New FrmModel(StrUserPermission, DTUP)

                Case MDI.MnuServiceTroubleMaster.Name
                    FrmObj = New FrmServiceTrouble(StrUserPermission, DTUP)

                Case MDI.MnuServiceTypeMaster.Name
                    FrmObj = New FrmServiceType(StrUserPermission, DTUP)

                Case MDI.MnuRateList.Name
                    FrmObj = New FrmRateList(StrUserPermission, DTUP)

                Case MDI.MnuItemGroupMaster.Name
                    FrmObj = New FrmItemGroup(StrUserPermission, DTUP)

                Case MDI.MnuItemCategoryMaster.Name
                    FrmObj = New FrmItemCategory(StrUserPermission, DTUP)

                Case MDI.MnuItemMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)

                Case MDI.MnuDealerMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Dealer
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Supplier

                Case MDI.MnuEmployeeMaster.Name
                    FrmObj = New FrmEmployee(StrUserPermission, DTUP)
                    CType(FrmObj, FrmEmployee).MasterType = ClsMain.MasterType.Employee
                    CType(FrmObj, FrmEmployee).SubGroupNature = FrmParty.ESubgroupNature.Supplier

                Case MDI.MnuCustomerMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Customer
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Customer

                Case MDI.MnuSupplierMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Supplier
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Supplier

                Case MDI.MnuPurchaseInvoiceEntry.Name
                    'FrmObj = New Purchase.FrmPurchInvoice(StrUserPermission, DTUP, ClsMain.ItemType.Parts)
                    'CType(FrmObj, Purchase.FrmPurchInvoice).FSetParameter(False, False, False, False, False, False, False, False, False, False, True, False, False)


                Case Else
                    FrmObj = Nothing
            End Select
        Else
            ReportFrm = New ReportLayout.FrmReportLayout("", "", StrSenderText, "")
            CRepProc = New ClsReportProcedures(ReportFrm)
            CRepProc.GRepFormName = Replace(Replace(Replace(Replace(StrSenderText, "&", ""), " ", ""), "(", ""), ")", "")
            CRepProc.Ini_Grid()
            FrmObj = ReportFrm

            'ObjRepFormGlobal = New AgLibrary.RepFormGlobal(AgL)
            'CRepProc = New ClsReportProcedures(ObjRepFormGlobal)
            'CRepProc.GRepFormName = Replace(Replace(StrSenderText, "&", ""), " ", "")
            'CRepProc.Ini_Grid()
            'FrmObj = ObjRepFormGlobal
        End If
        If FrmObj IsNot Nothing Then
            FrmObj.Text = StrSenderText
        End If
        Return FrmObj
    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

End Class

