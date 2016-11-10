<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MnuMain = New System.Windows.Forms.MenuStrip
        Me.MnuMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemCategoryMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuItemMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuCustomerMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuSupplierMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuEmployeeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDealerMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuRateList = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuServiceTypeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuServiceTroubleMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInsuranceCompanyMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuModelCategoryMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuModelGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuModelMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuGodownMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLabourGroupMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLabourTypeMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuVehicleMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDepartmentMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuDesignationMaster = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchase = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseInvoiceEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuService = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobCard = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInsuranceClaimIntimation = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuServiceQuotation = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuServiceQuotationAmendment = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMaterialIssueOnJobCard = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLobourDoneOnJobCard = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobCardDetail = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobInvoice = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuInventory = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPhysicalStock = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPhysicalStockAdjustment = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStoreIssueEntry = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuStoreReceive = New System.Windows.Forms.ToolStripMenuItem
        Me.MnnReports = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMaterialIssueOnJobCardReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuLabourDoneOnJobCardReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobInvoiceReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMaterialTrackingSheet = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobCardMISReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuPurchaseInvoiceReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuJobEstimateReport = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'MnuMain
        '
        Me.MnuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMaster, Me.MnuPurchase, Me.MnuService, Me.MnuInventory, Me.MnnReports})
        Me.MnuMain.Location = New System.Drawing.Point(0, 0)
        Me.MnuMain.Name = "MnuMain"
        Me.MnuMain.Size = New System.Drawing.Size(965, 24)
        Me.MnuMain.TabIndex = 1
        Me.MnuMain.Text = "MenuStrip1"
        '
        'MnuMaster
        '
        Me.MnuMaster.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuItemCategoryMaster, Me.MnuItemGroupMaster, Me.MnuItemMaster, Me.MnuCustomerMaster, Me.MnuSupplierMaster, Me.MnuEmployeeMaster, Me.MnuDealerMaster, Me.MnuRateList, Me.MnuServiceTypeMaster, Me.MnuServiceTroubleMaster, Me.MnuInsuranceCompanyMaster, Me.MnuModelCategoryMaster, Me.MnuModelGroupMaster, Me.MnuModelMaster, Me.MnuGodownMaster, Me.MnuLabourGroupMaster, Me.MnuLabourTypeMaster, Me.MnuVehicleMaster, Me.MnuDepartmentMaster, Me.MnuDesignationMaster})
        Me.MnuMaster.Name = "MnuMaster"
        Me.MnuMaster.Size = New System.Drawing.Size(52, 20)
        Me.MnuMaster.Text = "Master"
        '
        'MnuItemCategoryMaster
        '
        Me.MnuItemCategoryMaster.Name = "MnuItemCategoryMaster"
        Me.MnuItemCategoryMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuItemCategoryMaster.Text = "Item Category Master"
        '
        'MnuItemGroupMaster
        '
        Me.MnuItemGroupMaster.Name = "MnuItemGroupMaster"
        Me.MnuItemGroupMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuItemGroupMaster.Text = "Item Group Master"
        '
        'MnuItemMaster
        '
        Me.MnuItemMaster.Name = "MnuItemMaster"
        Me.MnuItemMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuItemMaster.Text = "Item Master"
        '
        'MnuCustomerMaster
        '
        Me.MnuCustomerMaster.Name = "MnuCustomerMaster"
        Me.MnuCustomerMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuCustomerMaster.Text = "Customer Master"
        '
        'MnuSupplierMaster
        '
        Me.MnuSupplierMaster.Name = "MnuSupplierMaster"
        Me.MnuSupplierMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuSupplierMaster.Text = "Supplier Master"
        '
        'MnuEmployeeMaster
        '
        Me.MnuEmployeeMaster.Name = "MnuEmployeeMaster"
        Me.MnuEmployeeMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuEmployeeMaster.Text = "Employee Master"
        '
        'MnuDealerMaster
        '
        Me.MnuDealerMaster.Name = "MnuDealerMaster"
        Me.MnuDealerMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuDealerMaster.Text = "Dealer Master"
        '
        'MnuRateList
        '
        Me.MnuRateList.Name = "MnuRateList"
        Me.MnuRateList.Size = New System.Drawing.Size(217, 22)
        Me.MnuRateList.Text = "Rate List"
        '
        'MnuServiceTypeMaster
        '
        Me.MnuServiceTypeMaster.Name = "MnuServiceTypeMaster"
        Me.MnuServiceTypeMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuServiceTypeMaster.Text = "Service Type Master"
        '
        'MnuServiceTroubleMaster
        '
        Me.MnuServiceTroubleMaster.Name = "MnuServiceTroubleMaster"
        Me.MnuServiceTroubleMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuServiceTroubleMaster.Text = "Service Trouble Master"
        '
        'MnuInsuranceCompanyMaster
        '
        Me.MnuInsuranceCompanyMaster.Name = "MnuInsuranceCompanyMaster"
        Me.MnuInsuranceCompanyMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuInsuranceCompanyMaster.Text = "Insurance Company Master"
        '
        'MnuModelCategoryMaster
        '
        Me.MnuModelCategoryMaster.Name = "MnuModelCategoryMaster"
        Me.MnuModelCategoryMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuModelCategoryMaster.Text = "Model Category Master"
        '
        'MnuModelGroupMaster
        '
        Me.MnuModelGroupMaster.Name = "MnuModelGroupMaster"
        Me.MnuModelGroupMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuModelGroupMaster.Text = "Model Group Master"
        '
        'MnuModelMaster
        '
        Me.MnuModelMaster.Name = "MnuModelMaster"
        Me.MnuModelMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuModelMaster.Text = "Model Master"
        '
        'MnuGodownMaster
        '
        Me.MnuGodownMaster.Name = "MnuGodownMaster"
        Me.MnuGodownMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuGodownMaster.Text = "Godown Master"
        '
        'MnuLabourGroupMaster
        '
        Me.MnuLabourGroupMaster.Name = "MnuLabourGroupMaster"
        Me.MnuLabourGroupMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuLabourGroupMaster.Text = "Labour Group Master"
        '
        'MnuLabourTypeMaster
        '
        Me.MnuLabourTypeMaster.Name = "MnuLabourTypeMaster"
        Me.MnuLabourTypeMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuLabourTypeMaster.Text = "Labour Type Master"
        '
        'MnuVehicleMaster
        '
        Me.MnuVehicleMaster.Name = "MnuVehicleMaster"
        Me.MnuVehicleMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuVehicleMaster.Text = "Vehicle Master"
        '
        'MnuDepartmentMaster
        '
        Me.MnuDepartmentMaster.Name = "MnuDepartmentMaster"
        Me.MnuDepartmentMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuDepartmentMaster.Text = "Department Master"
        '
        'MnuDesignationMaster
        '
        Me.MnuDesignationMaster.Name = "MnuDesignationMaster"
        Me.MnuDesignationMaster.Size = New System.Drawing.Size(217, 22)
        Me.MnuDesignationMaster.Text = "Designation Master"
        '
        'MnuPurchase
        '
        Me.MnuPurchase.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPurchaseInvoiceEntry})
        Me.MnuPurchase.Name = "MnuPurchase"
        Me.MnuPurchase.Size = New System.Drawing.Size(63, 20)
        Me.MnuPurchase.Text = "Purchase"
        '
        'MnuPurchaseInvoiceEntry
        '
        Me.MnuPurchaseInvoiceEntry.Name = "MnuPurchaseInvoiceEntry"
        Me.MnuPurchaseInvoiceEntry.Size = New System.Drawing.Size(196, 22)
        Me.MnuPurchaseInvoiceEntry.Text = "Purchase Invoice Entry"
        '
        'MnuService
        '
        Me.MnuService.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuJobCard, Me.MnuInsuranceClaimIntimation, Me.MnuServiceQuotation, Me.MnuServiceQuotationAmendment, Me.MnuMaterialIssueOnJobCard, Me.MnuLobourDoneOnJobCard, Me.MnuJobCardDetail, Me.MnuJobInvoice})
        Me.MnuService.Name = "MnuService"
        Me.MnuService.Size = New System.Drawing.Size(54, 20)
        Me.MnuService.Text = "Service"
        '
        'MnuJobCard
        '
        Me.MnuJobCard.Name = "MnuJobCard"
        Me.MnuJobCard.Size = New System.Drawing.Size(231, 22)
        Me.MnuJobCard.Text = "Job Card"
        '
        'MnuInsuranceClaimIntimation
        '
        Me.MnuInsuranceClaimIntimation.Name = "MnuInsuranceClaimIntimation"
        Me.MnuInsuranceClaimIntimation.Size = New System.Drawing.Size(231, 22)
        Me.MnuInsuranceClaimIntimation.Text = "Insurance Claim Intimation"
        '
        'MnuServiceQuotation
        '
        Me.MnuServiceQuotation.Name = "MnuServiceQuotation"
        Me.MnuServiceQuotation.Size = New System.Drawing.Size(231, 22)
        Me.MnuServiceQuotation.Text = "Service Quotation"
        '
        'MnuServiceQuotationAmendment
        '
        Me.MnuServiceQuotationAmendment.Name = "MnuServiceQuotationAmendment"
        Me.MnuServiceQuotationAmendment.Size = New System.Drawing.Size(231, 22)
        Me.MnuServiceQuotationAmendment.Text = "Service Quotation Amendment"
        '
        'MnuMaterialIssueOnJobCard
        '
        Me.MnuMaterialIssueOnJobCard.Name = "MnuMaterialIssueOnJobCard"
        Me.MnuMaterialIssueOnJobCard.Size = New System.Drawing.Size(231, 22)
        Me.MnuMaterialIssueOnJobCard.Text = "Material Issue On Job Card"
        '
        'MnuLobourDoneOnJobCard
        '
        Me.MnuLobourDoneOnJobCard.Name = "MnuLobourDoneOnJobCard"
        Me.MnuLobourDoneOnJobCard.Size = New System.Drawing.Size(231, 22)
        Me.MnuLobourDoneOnJobCard.Text = "Lobour Done On Job Card"
        '
        'MnuJobCardDetail
        '
        Me.MnuJobCardDetail.Name = "MnuJobCardDetail"
        Me.MnuJobCardDetail.Size = New System.Drawing.Size(231, 22)
        Me.MnuJobCardDetail.Text = "Job Card Detail"
        '
        'MnuJobInvoice
        '
        Me.MnuJobInvoice.Name = "MnuJobInvoice"
        Me.MnuJobInvoice.Size = New System.Drawing.Size(231, 22)
        Me.MnuJobInvoice.Text = "Job Invoice"
        '
        'MnuInventory
        '
        Me.MnuInventory.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuPhysicalStock, Me.MnuPhysicalStockAdjustment, Me.MnuStoreIssueEntry, Me.MnuStoreReceive})
        Me.MnuInventory.Name = "MnuInventory"
        Me.MnuInventory.Size = New System.Drawing.Size(67, 20)
        Me.MnuInventory.Text = "Inventory"
        '
        'MnuPhysicalStock
        '
        Me.MnuPhysicalStock.Name = "MnuPhysicalStock"
        Me.MnuPhysicalStock.Size = New System.Drawing.Size(210, 22)
        Me.MnuPhysicalStock.Text = "Physical Stock"
        '
        'MnuPhysicalStockAdjustment
        '
        Me.MnuPhysicalStockAdjustment.Name = "MnuPhysicalStockAdjustment"
        Me.MnuPhysicalStockAdjustment.Size = New System.Drawing.Size(210, 22)
        Me.MnuPhysicalStockAdjustment.Text = "Physical Stock Adjustment"
        '
        'MnuStoreIssueEntry
        '
        Me.MnuStoreIssueEntry.Name = "MnuStoreIssueEntry"
        Me.MnuStoreIssueEntry.Size = New System.Drawing.Size(210, 22)
        Me.MnuStoreIssueEntry.Text = "Material Issue"
        '
        'MnuStoreReceive
        '
        Me.MnuStoreReceive.Name = "MnuStoreReceive"
        Me.MnuStoreReceive.Size = New System.Drawing.Size(210, 22)
        Me.MnuStoreReceive.Text = "Material Receive"
        '
        'MnnReports
        '
        Me.MnnReports.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MnuMaterialIssueOnJobCardReport, Me.MnuLabourDoneOnJobCardReport, Me.MnuJobInvoiceReport, Me.MnuMaterialTrackingSheet, Me.MnuJobCardMISReport, Me.MnuPurchaseInvoiceReport, Me.MnuJobEstimateReport})
        Me.MnnReports.Name = "MnnReports"
        Me.MnnReports.Size = New System.Drawing.Size(57, 20)
        Me.MnnReports.Text = "Reports"
        '
        'MnuMaterialIssueOnJobCardReport
        '
        Me.MnuMaterialIssueOnJobCardReport.Name = "MnuMaterialIssueOnJobCardReport"
        Me.MnuMaterialIssueOnJobCardReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuMaterialIssueOnJobCardReport.Tag = "Report"
        Me.MnuMaterialIssueOnJobCardReport.Text = "Material Issue On Job Card Report"
        '
        'MnuLabourDoneOnJobCardReport
        '
        Me.MnuLabourDoneOnJobCardReport.Name = "MnuLabourDoneOnJobCardReport"
        Me.MnuLabourDoneOnJobCardReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuLabourDoneOnJobCardReport.Tag = "Report"
        Me.MnuLabourDoneOnJobCardReport.Text = "Labour Done On Job Card Report"
        '
        'MnuJobInvoiceReport
        '
        Me.MnuJobInvoiceReport.Name = "MnuJobInvoiceReport"
        Me.MnuJobInvoiceReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuJobInvoiceReport.Tag = "Reports"
        Me.MnuJobInvoiceReport.Text = "Job Invoice Report"
        '
        'MnuMaterialTrackingSheet
        '
        Me.MnuMaterialTrackingSheet.Name = "MnuMaterialTrackingSheet"
        Me.MnuMaterialTrackingSheet.Size = New System.Drawing.Size(251, 22)
        Me.MnuMaterialTrackingSheet.Tag = "Report"
        Me.MnuMaterialTrackingSheet.Text = "Material Tracking Sheet"
        '
        'MnuJobCardMISReport
        '
        Me.MnuJobCardMISReport.Name = "MnuJobCardMISReport"
        Me.MnuJobCardMISReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuJobCardMISReport.Tag = "Report"
        Me.MnuJobCardMISReport.Text = "Job Card MIS Report"
        '
        'MnuPurchaseInvoiceReport
        '
        Me.MnuPurchaseInvoiceReport.Name = "MnuPurchaseInvoiceReport"
        Me.MnuPurchaseInvoiceReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuPurchaseInvoiceReport.Tag = "Report"
        Me.MnuPurchaseInvoiceReport.Text = "Purchase Invoice Report"
        '
        'MnuJobEstimateReport
        '
        Me.MnuJobEstimateReport.Name = "MnuJobEstimateReport"
        Me.MnuJobEstimateReport.Size = New System.Drawing.Size(251, 22)
        Me.MnuJobEstimateReport.Tag = "Report"
        Me.MnuJobEstimateReport.Text = "Job Estimate Report"
        '
        'MDIMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(965, 661)
        Me.Controls.Add(Me.MnuMain)
        Me.IsMdiContainer = True
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.MnuMain
        Me.Name = "MDIMain"
        Me.Text = "Customise"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MnuMain.ResumeLayout(False)
        Me.MnuMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStripMenuItem10 As System.Windows.Forms.ToolStripMenuItem
    Public WithEvents MnuMain As System.Windows.Forms.MenuStrip
    Friend WithEvents MnuPurchase As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnnReports As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobInvoiceReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseInvoiceEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuService As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobInvoice As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPurchaseInvoiceReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuCustomerMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuSupplierMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuRateList As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemCategoryMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuItemGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuServiceTypeMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuServiceTroubleMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuInsuranceCompanyMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuModelMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuEmployeeMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMaterialIssueOnJobCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuLobourDoneOnJobCard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuInsuranceClaimIntimation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuServiceQuotation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobCardDetail As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuInventory As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPhysicalStock As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStoreIssueEntry As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuStoreReceive As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuModelCategoryMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuModelGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuGodownMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuLabourGroupMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuLabourTypeMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDealerMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuPhysicalStockAdjustment As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMaterialTrackingSheet As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobCardMISReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuVehicleMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuMaterialIssueOnJobCardReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuLabourDoneOnJobCardReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuJobEstimateReport As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDepartmentMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuDesignationMaster As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuServiceQuotationAmendment As System.Windows.Forms.ToolStripMenuItem

End Class
