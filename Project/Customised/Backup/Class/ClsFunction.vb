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
                Case MDI.MnuVatCommodityCodeMaster.Name
                    FrmObj = New FrmVatCommodityCode(StrUserPermission, DTUP)

                Case MDI.MnuManufacturerMaster.Name
                    FrmObj = New FrmManufacturer(StrUserPermission, DTUP)

                Case MDI.MnuRateList.Name
                    FrmObj = New FrmRateList(StrUserPermission, DTUP)

                Case MDI.MnuItemGroupMaster.Name
                    FrmObj = New FrmItemGroup(StrUserPermission, DTUP)

                Case MDI.MnuItemCategoryMaster.Name
                    FrmObj = New FrmItemCategory(StrUserPermission, DTUP)

                Case MDI.MnuItemMaster.Name
                    FrmObj = New FrmItem(StrUserPermission, DTUP)

                Case MDI.MnuRateTypeMaster.Name
                    FrmObj = New FrmRateType(StrUserPermission, DTUP)

                Case MDI.MnuItemInvoiceGroupMaster.Name
                    FrmObj = New FrmItemInvoiceGroup(StrUserPermission, DTUP)

                Case MDI.MnuAgentMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Agent
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Supplier

                Case MDI.MnuCustomerMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Customer
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Customer

                Case MDI.MnuSupplierMaster.Name
                    FrmObj = New FrmParty(StrUserPermission, DTUP)
                    CType(FrmObj, FrmParty).MasterType = ClsMain.MasterType.Supplier
                    CType(FrmObj, FrmParty).SubGroupNature = FrmParty.ESubgroupNature.Supplier

                Case MDI.MnuPurchaseChallanEntry.Name
                    FrmObj = New Purchase.FrmPurchChallan(StrUserPermission, DTUP, ClsMain.ItemType.FinishedMaterial)
                    CType(FrmObj, Purchase.FrmPurchChallan).EntryNCat = AgTemplate.ClsMain.Temp_NCat.GoodsReceipt
                    CType(FrmObj, Purchase.FrmPurchChallan).FSetParameter(False, False, False, False, False, False, False, False, False, False, True, False, True)

                Case MDI.MnuPurchaseInvoiceEntry.Name
                    FrmObj = New Purchase.FrmPurchInvoice(StrUserPermission, DTUP, ClsMain.ItemType.FinishedMaterial)
                    CType(FrmObj, Purchase.FrmPurchInvoice).FSetParameter(False, False, False, False, False, False, False, False, False, False, True, False, True)

                Case MDI.MnuPurchaseReturnEntry.Name
                    FrmObj = New Purchase.FrmPurchReturn(StrUserPermission, DTUP, ClsMain.ItemType.FinishedMaterial)
                    CType(FrmObj, Purchase.FrmPurchReturn).FSetParameter(False, False, False, True, True, True, True, True, True, True)

                Case MDI.MnuSaleInvoiceEntry.Name
                    FrmObj = New FrmSaleInvoice(StrUserPermission, DTUP, ClsMain.ItemType.FinishedMaterial)
                    CType(FrmObj, FrmSaleInvoice).FSetParameter(False, False, False, True, True, True, True, True, True, True, True, False, False, False, False)

                Case MDI.MnuSaleReturnEntry.Name
                    FrmObj = New FrmSaleReturn(StrUserPermission, DTUP, ClsMain.ItemType.FinishedMaterial)
                    CType(FrmObj, FrmSaleReturn).FSetParameter(False, False, False, True, True, True, True, True, True, True, True, False, False, False, False)

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

