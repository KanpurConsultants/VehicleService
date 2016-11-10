Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsMain
    Public CFOpen As New ClsFunction
    Public Const ModuleName As String = "Customised"

    Public Const DefaultUnit As String = "Sq.Feet"

    Sub New(ByVal AgLibVar As AgLibrary.ClsMain)
        AgL = AgLibVar
        AgPL = New AgLibrary.ClsPrinting(AgL)
        AgIniVar = New AgLibrary.ClsIniVariables(AgL)
        ClsMain_Purchase = New Purchase.ClsMain(AgL)
        ClsMain_EMail = New EMail.ClsMain(AgL)
        ClsMain_ReportLayout = New ReportLayout.ClsMain(AgL)

        Call IniDtEnviro()
        AgL.PubDivisionList = "('" + AgL.PubDivCode + "')"
    End Sub

    Public Class PaymentMode
        Public Const Cash As String = "Cash"
        Public Const Credit As String = "Credit"
        Public Const Complementary As String = "Complementary"
    End Class

    Public Class MasterType
        Public Const Customer As String = "Customer"
        Public Const Supplier As String = "Supplier"
        Public Const Agent As String = "Agent"
    End Class

    Public Class SubGroupMasterType
        Public Const Customer As String = "Customer"
        Public Const Supplier As String = "Supplier"
    End Class

    Public Class ExportOrderType
        Public Const SaleOrder As String = "Sale Order"
        Public Const CustomOrder As String = "Custom Order"
    End Class

    Public Enum EntryPointType
        Main
        Log
    End Enum

    Public Class LogStatus
        Public Const LogOpen As String = "Open"
        Public Const LogDiscard As String = "Discard"
        Public Const LogApproved As String = "Approved"
    End Class

    Public Class ItemType
        Public Const RawMaterial As String = "RM"
        Public Const FinishedMaterial As String = "FM"
    End Class

    Public Class ItemGroup
        Public Const Sample As String = "Sample"
    End Class

    Public Class ItemCategory
        Public Const Sample As String = "Sample"
        Public Const CarpetSKU As String = "Carpet SKU"
    End Class

    Public Class Shape
        Public Const Rectangle As String = "Rectangle"
        Public Const Circle As String = "Circle"
        Public Const Square As String = "Square"
        Public Const Others As String = "Others"
    End Class

    Public Class Temp_NCat
        Public Const ItemInvoiceGroup As String = "IIG"
    End Class

    Public Class Temp_VType
        Public Const EstimateGR As String = "EGR"
    End Class


#Region "Public Help Queries"

    Public Const PubStrHlpQryWashingType As String = "Select 'Normal' as Code, 'Normal' as Description " & _
                                                     " Union All Select 'Antique' as Code, 'Antique' as Description " & _
                                                     " Union All Select 'Herbal' as Code, 'Herbal' as Description " & _
                                                     " Union All Select 'N.A.' as Code, 'N.A.' as Description "


#End Region

#Region " Structure Update Code "

    Public Sub UpdateTableStructure(ByRef MdlTable() As AgLibrary.ClsMain.LITable)
        FBomDetail(MdlTable, "BOMDetail", EntryPointType.Main)
        FBomDetail(MdlTable, "BOMDetail_Log", EntryPointType.Log)

        FSaleInvoice(MdlTable, "SaleInvoice", EntryPointType.Main)
        FSaleInvoice(MdlTable, "SaleInvoice_Log", EntryPointType.Log)

        FPurchInvoice(MdlTable, "PurchInvoice", EntryPointType.Main)
        FPurchInvoice(MdlTable, "PurchInvoice_Log", EntryPointType.Log)

        FPurchInvoiceDetail(MdlTable, "PurchInvoiceDetail", EntryPointType.Main)
        FPurchInvoiceDetail(MdlTable, "PurchInvoiceDetail_Log", EntryPointType.Log)

     

        FItemType(MdlTable, "ItemType", EntryPointType.Main)

        FItemCategory(MdlTable, "ItemCategory", EntryPointType.Main)
        FItemCategory(MdlTable, "ItemCategory_Log", EntryPointType.Log)

        FItemGroup(MdlTable, "ItemGroup", EntryPointType.Main)
        FItemGroup(MdlTable, "ItemGroup_Log", EntryPointType.Log)

        FItem(MdlTable, "Item", EntryPointType.Main)
        FItem(MdlTable, "Item_Log", EntryPointType.Log)

        FSubGroup(MdlTable, "SubGroup", EntryPointType.Main)
        FSubGroup(MdlTable, "SubGroup_Log", EntryPointType.Log)

        FCurrency(MdlTable, "Currency", EntryPointType.Main)

        FVoucher_Type(MdlTable, "Voucher_Type")

        FEnviro(MdlTable, "Enviro")

        FDuesEnviro(MdlTable, "DuesPaymentEnviro")

        FUnitConversion(MdlTable, "UnitConversion")

        FRUG_SampleContent(MdlTable, "RUG_SampleContent", EntryPointType.Main)
        FRUG_SampleContent(MdlTable, "RUG_SampleContent_Log", EntryPointType.Log)

        FRUG_SampleShade(MdlTable, "RUG_SampleShade", EntryPointType.Main)
        FRUG_SampleShade(MdlTable, "RUG_SampleShade_Log", EntryPointType.Log)

        FRUG_SampleSizeAvailable(MdlTable, "RUG_SampleSizeAvailable", EntryPointType.Main)
        FRUG_SampleSizeAvailable(MdlTable, "RUG_SampleSizeAvailable_Log", EntryPointType.Log)

        FRUG_SampleSku(MdlTable, "RUG_SampleSku", EntryPointType.Main)
        FRUG_SampleSku(MdlTable, "RUG_SampleSku_Log", EntryPointType.Log)

        FRug_Size(MdlTable, "RUG_Size", EntryPointType.Main)
        FRug_Size(MdlTable, "RUG_Size_Log", EntryPointType.Log)

        FRUG_Quality(MdlTable, "RUG_Quality", EntryPointType.Main)
        FRUG_Quality(MdlTable, "RUG_Quality_Log", EntryPointType.Log)

        FRUG_Collection(MdlTable, "RUG_Collection", EntryPointType.Main)
        FRUG_Collection(MdlTable, "RUG_Collection_Log", EntryPointType.Log)

        FRUG_CollectionRateList(MdlTable, "RUG_CollectionRateList", EntryPointType.Main)
        FRUG_CollectionRateList(MdlTable, "RUG_CollectionRateList_Log", EntryPointType.Log)

        FRUG_CollectionRateListDetail(MdlTable, "RUG_CollectionRateListDetail", EntryPointType.Main)
        FRUG_CollectionRateListDetail(MdlTable, "RUG_CollectionRateListDetail_Log", EntryPointType.Log)

        FRUG_Shade(MdlTable, "RUG_Shade", EntryPointType.Main)
        FRUG_Shade(MdlTable, "RUG_Shade_Log", EntryPointType.Log)

        FRUG_Construction(MdlTable, "RUG_Construction", EntryPointType.Main)
        FRUG_Construction(MdlTable, "RUG_Construction_Log", EntryPointType.Log)

        FRUG_Design(MdlTable, "RUG_Design", EntryPointType.Main)
        FRUG_Design(MdlTable, "RUG_Design_Log", EntryPointType.Log)

        FRUG_DesignImage(MdlTable, "RUG_DesignImage", EntryPointType.Main)
        FRUG_DesignImage(MdlTable, "RUG_DesignImage_Log", EntryPointType.Log)

        FVoucher_Type(MdlTable, "Voucher_Type")
    End Sub

    Public Sub UpdateTableInitialiser()
        Try
            Call CreateVType()

            Call TB_PostingGroupSalesTaxItem()

            Call TB_PostingGroupSalesTaxParty()

            Call TB_PostingGroupSalesTax()

            Call TB_Structure()

            Call TB_AcGroup()

            Call TB_SubGroup()

            Call TB_VoucherCat()

            Call TB_ItemType()

            Call TB_Enviro()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TB_PostingGroupSalesTaxItem()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From PostingGroupSalesTaxItem Where Description = 'General'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.PostingGroupSalesTaxItem (Description, Active) VALUES ('General', 1) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_PostingGroupSalesTaxItem")
        End Try
    End Sub

    Private Sub TB_PostingGroupSalesTaxParty()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From PostingGroupSalesTaxParty Where Description = 'Central'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO PostingGroupSalesTaxParty (Description, Active) VALUES ('Central', 1)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.Dman_Execute(" Select Count(*) From PostingGroupSalesTaxParty Where Description = 'Local'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO PostingGroupSalesTaxParty (Description, Active) VALUES ('Local', 1)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_PostingGroupSalesTaxParty")
        End Try
    End Sub

    Private Sub TB_PostingGroupSalesTax()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From PostingGroupSalesTax Where PostingGroupSalesTaxParty = 'Central' And PostingGroupSalesTaxItem = 'General'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.PostingGroupSalesTax (PostingGroupSalesTaxItem, PostingGroupSalesTaxParty, PurchaseSaleAc, SalesTax, SalesTaxAc, VAT, VatAc, AdditionalTax, AdditionalTaxAc, Cst, CstAc, CustomDuty, CustomDutyAc, CustomDutyECess, CustomDutyECessAc, CustomDutyHECess, CustomDutyHECessAc, CustomAdditionalDuty, CustomAdditionalDutyAc, Site_Code, Div_Code, WEF) " & _
                        " VALUES ('General', 'Central', NULL, 0, NULL, 0, NULL, 0, NULL, 2, NULL, 0, NULL, 0, NULL, 0, NULL, 0, NULL, '1', 'D', '2012-04-01')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.Dman_Execute(" Select Count(*) From PostingGroupSalesTax Where PostingGroupSalesTaxParty = 'Local' And PostingGroupSalesTaxItem = 'General'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.PostingGroupSalesTax (PostingGroupSalesTaxItem, PostingGroupSalesTaxParty, PurchaseSaleAc, SalesTax, SalesTaxAc, VAT, VatAc, AdditionalTax, AdditionalTaxAc, Cst, CstAc, CustomDuty, CustomDutyAc, CustomDutyECess, CustomDutyECessAc, CustomDutyHECess, CustomDutyHECessAc, CustomAdditionalDuty, CustomAdditionalDutyAc, Site_Code, Div_Code, WEF) " & _
                        " VALUES ('General', 'Local', NULL, 0, NULL, 12.5, NULL, 1, NULL, 0, NULL, 0, NULL, 0, NULL, 0, NULL, 0, NULL, '1', 'D', '2012-04-01')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_PostingGroupSalesTax")
        End Try
    End Sub

    Private Sub TB_Enviro()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From Enviro Where Site_Code = '" & AgL.PubSiteCode & "'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.Enviro (ID, Site_Code, Div_Code, DefaultSalesTaxGroupParty, DefaultSalesTaxGroupItem, PurchOrderShowIndentInLine, IsLinkWithFA, IsNegativeStockAllowed, IsLotNoApplicable, DefaultDueDays, SaleAc, PostingAc, CashAc, BankAc, TdsAc, AdditionAc, DeductionAc, ServiceTaxAc, ECessAc, RoundOffAc, HECessAc, ServiceTaxPer, ECessPer, HECessPer, UpLoadDate, PreparedBy, U_EntDt, U_AE, Edit_Date, ModifiedBy, ApprovedBy, ApprovedDate, GPX1, GPX2, GPN1, GPN2, IsNegetiveStockAllowed) " & _
                        " VALUES ('1', '1', 'D', 'Local', 'General', 0, NULL, 1, 1, NULL, 'Sale', '111', 'cash', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_Enviro")
        End Try
    End Sub

    Private Sub TB_Structure()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From Structure Where Code = 'PURCH'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.Structure (Code, Description, HeaderTable, LineTable, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)  " & _
                        " VALUES ('PURCH', 'PURCH', NULL, NULL, 'M', '1', 'sa', '2012-01-15', 'A', NULL, NULL, NULL)  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                        " VALUES ('PURCH', 10, 'GAMT', 'Charges', 'FixedValue', NULL, '|AMOUNT|', NULL, NULL, NULL, NULL, 0, 1, 1, 0, 1, 0, 0, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL) " & _
                        " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                        " VALUES ('PURCH', 20, 'DIS', 'Charges', 'Percentage Or Amount', NULL, NULL, 'AMOUNT', NULL, NULL, NULL, 0, 0, 0, 0, 1, 0, 0, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL) " & _
                        " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                        " VALUES ('PURCH', 30, 'OC', 'Charges', 'Percentage Or Amount', NULL, NULL, 'AMOUNT', NULL, NULL, NULL, 0, 1, 0, 0, 1, 0, 0, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL) " & _
                        " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                        " VALUES ('PURCH', 40, 'NAMT', 'Charges', 'FixedValue', NULL, '{GAMT}-{DIS}+{OC}', NULL, NULL, NULL, NULL, 0, NULL, 1, 0, 0, 0, 0, 1, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL) " & _
                        " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                        " VALUES ('PURCH', 50, 'LV', 'Cost', 'FixedValue', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, 1, 0, 0, 0, 0, 0, NULL, NULL, NULL, NULL, 0, NULL, NULL, NULL) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.Dman_Execute(" Select Count(*) From Structure Where Code = 'SALE'", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.Structure (Code, Description, HeaderTable, LineTable, Div_Code, Site_Code, PreparedBy, U_EntDt, U_AE, ModifiedBy, Edit_Date, UpLoadDate)  " & _
                        " VALUES ('SALE', 'SALE', NULL, NULL, 'M', '1', 'sa', '2002-01-01', 'A', NULL, NULL, NULL)  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

                mQry = " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 10, 'GAMT', 'Charges', 'FixedValue', NULL, '|AMOUNT|', NULL, NULL, NULL, NULL, 0, 1, NULL, 0, 1, 0, 0, 1, NULL, 'Gross_Amount', 'Gross_Amount', NULL, 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 12, 'DPTAX', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{DPTAX}/100', 'AMOUNT', NULL, NULL, NULL, 0, 0, NULL, 0, 1, 0, 0, 1, 'Discount_Pre_Tax_Per', 'Discount_Pre_Tax', 'Discount_Pre_Tax', 'Discount_Pre_Tax_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 14, 'OAPTAX', 'Charges', 'Percentage Or Amount', NULL, '{GAMT}*{OAPTAX}/100', 'AMOUNT', NULL, NULL, NULL, 0, 1, NULL, 0, 1, 0, 0, 1, 'Other_Additions_Pre_Tax_Per', 'Other_Additions_Pre_Tax', 'Other_Additions_Pre_Tax', 'Other_Additions_Pre_Tax_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 16, 'STTA', 'Charges', 'FixedValue', NULL, '{GAMT}-{DPTAX}+{OAPTAX}', NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 0, 1, NULL, 'Sales_Tax_Taxable_Amt', 'Sales_Tax_Taxable_Amt', NULL, 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 18, 'VAT', 'VAT', 'Percentage', NULL, '{STTA}*{VAT}/100', NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 1, 1, 'Vat_Per', 'Vat', 'Vat', 'Vat_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 19, 'SAT', 'SAT', 'Percentage', NULL, '{STTA}*{SAT}/100', NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 1, 1, 'Sat_Per', 'Sat', 'Sat', 'Sat_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 20, 'DIS', 'Charges', 'Percentage Or Amount', NULL, '({STTA}+{VAT}+{SAT}) *{DIS}/100', 'AMOUNT', NULL, NULL, NULL, 0, 0, NULL, 0, 1, 0, 0, 1, 'Discount_Per', 'Discount', 'Discount', 'Discount_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 30, 'OC', 'Charges', 'Percentage Or Amount', NULL, '({STTA}+{VAT}+{SAT}) *{OC}/100', 'AMOUNT', NULL, NULL, NULL, 0, 1, NULL, 0, 1, 0, 0, 1, 'Other_Charges_Per', 'Other_Charges', 'Other_Charges', 'Other_Charges_Per', 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 35, 'RO', 'Charges', 'FixedValue', NULL, '({STTA}+{VAT}+{SAT}-{DIS}+{OC}) -ROUND({STTA}+{VAT}+{SAT}-{DIS}+{OC},0)', NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 0, 1, NULL, 'Round_Off', 'Round_Off', NULL, 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 40, 'NAMT', 'Charges', 'FixedValue', NULL, '{STTA}+{VAT}+{SAT}-{DIS}+{OC}+{RO}', NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 0, 1, NULL, 'Net_Amount', 'Net_Amount', NULL, 0, NULL, '2012-04-01', NULL) " & _
                            " INSERT INTO dbo.StructureDetail (Code, Sr, Charges, Charge_Type, Value_Type, Value, Calculation, BaseColumn, PostAc, PostAcFromColumn, DrCr, LineItem, AffectCost, Percentage, Amount, VisibleInMaster, VisibleInMasterLine, VisibleInTransactionLine, VisibleInTransactionFooter, HeaderPerField, HeaderAmtField, LineAmtField, LinePerField, GridDisplayIndex, UpLoadDate, WEF, InactiveDate) " & _
                            " VALUES ('SALE', 50, 'LV', 'Cost', 'FixedValue', NULL, NULL, NULL, NULL, NULL, NULL, 0, NULL, NULL, 0, 1, 0, 0, 0, NULL, 'Landed_Value', 'Landed_Value', NULL, 0, NULL, '2012-04-01', NULL) "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_Structure")
        End Try
    End Sub

    Private Sub TB_AcGroup()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From AcGroup ", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate)" & _
                            " VALUES ('0001', NULL, 'Capital Account', NULL, 'Others', 'Y', 'L', 'Capital Account', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0002', NULL, 'Loan (Liability)', NULL, 'Others', 'Y', 'L', 'Loan (Liability)', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0003', NULL, 'Current Liabilities', NULL, 'Others', 'Y', 'L', 'Current Liabilities', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0004', NULL, 'Fixed Assets', NULL, 'Others', 'Y', 'A', 'Fixed Assets', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0005', NULL, 'Investments', NULL, 'Others', 'Y', 'A', 'Investments', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0006', NULL, 'Current Assets', NULL, 'Others', 'Y', 'A', 'Current Assets', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0007', NULL, 'Branch/Divisions', NULL, 'Others', 'Y', 'A', 'Branch/Divisions', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0008', NULL, 'Misc. Expences (Asset)', NULL, 'Expenses', 'Y', 'A', 'Misc. Expences (Asset)', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0009', NULL, 'Suspense A/c', NULL, 'Others', 'Y', 'A', 'Suspense A/c', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0010', NULL, 'Reserves & Surplus', '0001', 'Others', 'Y', 'L', 'Reserves & Surplus', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0011', NULL, 'Bank OD A/c', '0002', 'Bank', 'Y', 'L', 'Bank OD A/c', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0012', NULL, 'Secured Loans', NULL, 'Others', 'Y', 'L', 'Secured Loans', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0013', NULL, 'Unsecured Loans', '0002', 'Others', 'Y', 'L', 'Unsecured Loans', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0014', NULL, 'Duties & Taxes', '0003', 'Expenses', 'Y', 'L', 'Duties & Taxes', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0015', NULL, 'Provisions', '0003', 'Expenses', 'Y', 'L', 'Provisions', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0016', NULL, 'Sundry Creditors', '0003', 'Supplier', 'Y', 'L', 'Sundry Creditors', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0017', NULL, 'Opening Stock', NULL, 'Direct', 'Y', 'E', 'Opening Stock', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0018', NULL, 'Deposits (Asset)', '0006', 'Others', 'Y', 'A', 'Deposits (Asset)', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0019', NULL, 'Loans & Advances (Asset)', '0006', 'Others', 'Y', 'A', 'Loans & Advances (Asset)', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0020', NULL, 'Sundry Debtors', '0006', 'Customer', 'Y', 'A', 'Sundry Debtors', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0021', NULL, 'Cash-in-Hand', '0006', 'Cash', 'Y', 'A', 'Cash-In-Hand', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0022', NULL, 'Bank Accounts', '0006', 'Bank', 'Y', 'A', 'Bank Accounts', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0023', NULL, 'Sales Accounts', NULL, 'Sales', 'Y', 'R', 'Sales Accounts', 'DEENA', '2011-07-13', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0024', NULL, 'Purchase Accounts', NULL, 'Purchase', 'Y', 'E', 'Purchase Accounts', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0025', NULL, 'Direct Incomes', NULL, 'Direct', 'Y', 'R', 'Direct Incomes', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0026', NULL, 'Direct Expenses', NULL, 'Direct', 'Y', 'E', 'Direct Expenses', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0027', NULL, 'Indirect Incomes', NULL, 'Indirect', 'Y', 'R', 'Indirect Incomes', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0028', NULL, 'Indirect Expenses', NULL, 'Indirect', 'Y', 'E', 'Indirect Expenses', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0029', NULL, 'Profit & Loss A/c', NULL, 'Others', 'Y', 'L', 'Profit & Loss A/c', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL) " & _
                            " INSERT INTO dbo.AcGroup (GroupCode, SNo, GroupName, GroupUnder, Nature, SysGroup, GroupNature, ContraGroupName, U_Name, U_EntDt, U_AE, TradingYn, MainGrCode, BlOrd, MainGrLen, ID, Site_Code, GroupNameBiLang, GroupLevel, CurrentCount, CurrentBalance, SubLedYn, AliasYn, GroupHelp, LastYearBalance, UpLoadDate) " & _
                            " VALUES ('0030', NULL, 'Closing Stock', NULL, 'Direct', 'Y', 'R', 'Closing Stock', 'SA', '2011-04-09', 'E',  NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)  "
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_Enviro")
        End Try
    End Sub


    Private Sub TB_ItemType()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From ItemType ", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.ItemType (Code, Name) VALUES ('CL', 'Coal') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('CM', 'Chemical') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('FL', 'Fuel') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('FM', 'Finished Mtrl.') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('OT', 'Others') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('PM', 'Packing Mtrl.') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('RM', 'Raw Mtrl.') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('SF', 'Semi Finished') " & _
                        " INSERT INTO dbo.ItemType (Code, Name) VALUES ('SM', 'Store Mtrl.')"
            End If



        Catch ex As Exception

        End Try
    End Sub


    Private Sub TB_SubGroup()
        Dim mQry$ = ""
        Try
            If AgL.Dman_Execute(" Select Count(*) From SubGroup Where SubCode = 'Cash' ", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.SubGroup (SubCode, SiteList, DispName, Name, GroupCode, GroupNature, ManualCode, Nature) " & _
                        " VALUES ('CASH', '|1|', 'CASH A/C', 'CASH A/C', '0021', '', 'CASH', 'CASH')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If

            If AgL.Dman_Execute(" Select Count(*) From SubGroup Where SubCode = 'SALE' ", AgL.GCn).ExecuteScalar = 0 Then
                mQry = " INSERT INTO dbo.SubGroup (SubCode, SiteList, DispName, Name, GroupCode, GroupNature, ManualCode, Nature) " & _
                        " VALUES ('SALE', '|1|', 'SALE A/C', 'SALE A/C', '0023', '', 'SALE', 'Customer')"
                AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
            End If
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_Enviro")
        End Try
    End Sub

    Private Sub TB_VoucherCat()
        Dim mQry$ = ""
        Try
            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'SALE',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoice'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoiceDetail') " & _
            '        " WHERE NCat = 'SI'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'SALE',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoice'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoiceDetail') " & _
            '        " WHERE NCat = 'SWKOT'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'SALE',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoice'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleInvoiceDetail') " & _
            '        " WHERE NCat = 'SRET'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'PURCH',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'PurchInvoice'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'PurchInvoiceDetail') " & _
            '        " WHERE NCat = 'PINV'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'PURCH',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'PurchInvoice'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'PurchInvoiceDetail') " & _
            '        " WHERE NCat = 'PRET'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)

            'mQry = " UPDATE VoucherCat " & _
            '        " SET Structure = 'SALE',  " & _
            '        " HeaderTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleOrder'), " & _
            '        " LineTable = (SELECT object_id FROM sys.Objects WHERE name = 'SaleOrderDetail') " & _
            '        " WHERE NCat = 'SO'  "
            'AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
        Catch ex As Exception
            MsgBox(ex.Message + ".On TB_VoucherCat")
        End Try
    End Sub

    Private Sub CreateVType()
        Try
            '===================================================< KOT V_Type >===================================================
            'Try
            '    AgL.CreateNCat(AgL.GCn, Temp_NCat.KOT, Temp_NCat.KOT, "KOT", AgL.PubSiteCode)
            '    AgL.CreateVType(AgL.GCn, Temp_NCat.KOT, Temp_NCat.KOT, Temp_NCat.KOT, "KOT", Temp_NCat.KOT, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            'Catch ex As Exception
            '    MsgBox(ex.Message & " In CreateVType of " & Temp_NCat.KOT)
            'End Try

            '===================================================< Estimate GR V_Type >===================================================
            Try
                AgL.CreateVType(AgL.GCn, AgTemplate.ClsMain.Temp_NCat.GoodsReceipt, AgTemplate.ClsMain.Temp_NCat.GoodsReceipt, Temp_VType.EstimateGR, "Estimate GR", Temp_VType.EstimateGR, AgL.PubUserName, AgL.PubLoginDate, AgL.PubStartDate, AgL.PubEndDate, AgL.PubSiteCode, AgL.PubDivCode, False, AgL.PubSitewiseV_No)
            Catch ex As Exception
                MsgBox(ex.Message & " In CreateVType of " & Temp_VType.EstimateGR)
            End Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub FIni_ItemType()
        Dim mQry$
        Dim strData$ = ""
        mQry = "Select Count(*) from ItemType Where Code = 'RM'"
        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar = 0 Then
            If strData <> "" Then strData += " Union All "
            strData += " Select 'RM' CODE, 'Raw Material' as Name "
        End If

        mQry = "Select Count(*) from ItemType Where Code = 'FM'"
        If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar = 0 Then
            If strData <> "" Then strData += " Union All "
            strData += " Select 'FM' CODE, 'Finish Material' as Name "
        End If

        strData = "Insert Into ItemType (Code,Name ) " + _
                  "( " & strData & ") x "

    End Sub

    Private Sub FPurchInvoiceDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)
        AgL.FSetColumnValue(MdlTable, "Specification", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
    End Sub

    Private Sub FPurchInvoice(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "VendorName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "VendorAddress", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "VendorCity", AgLibrary.ClsMain.SQLDataType.nVarChar, 6)
        AgL.FSetColumnValue(MdlTable, "VendorMobile", AgLibrary.ClsMain.SQLDataType.nVarChar, 35)
        AgL.FSetFKeyValue(MdlTable, "VendorCity", "CityCode", "City")
    End Sub

    Private Sub FSubGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DispName", AgLibrary.ClsMain.SQLDataType.nVarChar, 100)
        AgL.FSetColumnValue(MdlTable, "MasterType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Currency", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "SalesTaxPostingGroup", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FCurrency(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
    End Sub

    Private Sub FDuesEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "V_Type", AgLibrary.ClsMain.SQLDataType.nVarChar, 5, True)
        AgL.FSetColumnValue(MdlTable, "DiscountAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CashAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "BankAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "DebitNoteAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CreditNoteAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    End Sub

    Private Sub FVoucher_Type(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DivisionWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "SiteWise", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Number_Method", AgLibrary.ClsMain.SQLDataType.nVarChar, 9)
        AgL.FSetColumnValue(MdlTable, "Saperate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Separate_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Common_Narr", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ChqNo", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ChqDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "ClgDt", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Affect_FA", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
    End Sub

    Private Sub FEnviro(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "DefaultSalesTaxGroupParty", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "DefaultSalesTaxGroupItem", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PurchOrderShowIndentInLine", AgLibrary.ClsMain.SQLDataType.Bit, , , , 0)
        AgL.FSetColumnValue(MdlTable, "SaleAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PostingAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CashAc", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "IsLinkWithFA", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "IsNegativeStockAllowed", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "IsLotNoApplicable", AgLibrary.ClsMain.SQLDataType.Bit, , , , 1)
        AgL.FSetColumnValue(MdlTable, "DefaultDueDays", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetFKeyValue(MdlTable, "Site_Code", "Code", "SiteMast")
    End Sub


    Private Sub FItemType(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 20, True)
    End Sub

    Private Sub FItemCategory(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "ItemType", "Code", "ItemType")
    End Sub

    Private Sub FItem(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Specification", AgLibrary.ClsMain.SQLDataType.nVarChar, 255)
        AgL.FSetColumnValue(MdlTable, "Design", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Size", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Colour", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Quality", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Collection", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "Design", "Code", "Rug_Design")
        AgL.FSetFKeyValue(MdlTable, "Size", "Code", "Rug_Size")
    End Sub

    Private Sub FItemGroup(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, True)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ItemType", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "ItemCategory", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "ItemCategory", "Code", "ItemCategory")
        AgL.FSetFKeyValue(MdlTable, "ItemType", "Code", "ItemType")
    End Sub

    Private Sub FSaleInvoice(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "TableCode", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
        AgL.FSetColumnValue(MdlTable, "PaymentMode", AgLibrary.ClsMain.SQLDataType.VarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PostingAc", AgLibrary.ClsMain.SQLDataType.VarChar, 10)

        AgL.FSetFKeyValue(MdlTable, "TableCode", "Code", "Ht_Table")
    End Sub

    Private Sub FSaleInvoiceDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Size", AgLibrary.ClsMain.SQLDataType.VarChar, 10)
    End Sub

    Private Sub FBom(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "ForQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ForWeight", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "ForUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float, , , , 0)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FBomDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int)
        AgL.FSetColumnValue(MdlTable, "Process", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Qty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ConsumptionPer", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "ApplyIn", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Uid", AgLibrary.ClsMain.SQLDataType.uniqueidentifier)

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Bom_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Bom")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
        AgL.FSetFKeyValue(MdlTable, "Process", "NCat", "Process")
    End Sub

    Private Sub FRUG_SampleSku(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Size", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PileQuality", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "CostPerSqFeet", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Main Then
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "Item")
        Else
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "Item_Log")
        End If
    End Sub

    Private Sub FUnitConversion(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "FromUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ToUnit", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Multiplier", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Rounding", AgLibrary.ClsMain.SQLDataType.Int)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
    End Sub

    Private Sub FRUG_SampleSizeAvailable(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Size", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUG_SampleSku_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUG_SampleSku")
        End If
        AgL.FSetFKeyValue(MdlTable, "Size", "Code", "Rug_Size")
    End Sub

    Private Sub FRUG_SampleContent(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Item", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUG_SampleSku_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUG_SampleSku")
        End If
        AgL.FSetFKeyValue(MdlTable, "Item", "Code", "Item")
    End Sub

    Private Sub FRUG_SampleShade(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "Shade", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUG_SampleSku_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUG_SampleSku")
        End If
        AgL.FSetFKeyValue(MdlTable, "Shade", "Code", "Rug_Shade")
    End Sub

    Private Sub FRug_Size(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Shape", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "FeetLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FeetWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FeetArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "FeetDiameter", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "MeterArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardLength", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardWidth", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "YardArea", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LFeet", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "LInch", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WFeet", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WInch", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_Quality(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "StdRugWeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PileWeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "PileHeight", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "TuftPerSqrInch", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "WashingType", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Clipping", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Fringes", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "TotalQty", AgLibrary.ClsMain.SQLDataType.Float)
        AgL.FSetColumnValue(MdlTable, "Weight", AgLibrary.ClsMain.SQLDataType.Float)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Construction", "Code", "RUG_Construction")
    End Sub

    Private Sub FRUG_Shade(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Colour", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Pantone", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_Collection(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Quality", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_CollectionRateList(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "WEF", AgLibrary.ClsMain.SQLDataType.SmallDateTime)

        AgL.FSetColumnValue(MdlTable, "RateListCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_CollectionRateListDetail(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Sr", AgLibrary.ClsMain.SQLDataType.Int, , True)
        AgL.FSetColumnValue(MdlTable, "WEF", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "Collection", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Rate", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, IIf(EntryType = EntryPointType.Log, True, False))
    End Sub

    Private Sub FRUG_Construction(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)

        AgL.FSetColumnValue(MdlTable, "PreparedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "U_EntDt", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "U_AE", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Edit_Date", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "ModifiedBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
    End Sub

    Private Sub FRUG_Design(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10, IIf(EntryType = EntryPointType.Main, True, False))
        AgL.FSetColumnValue(MdlTable, "ManualCode", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Description", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Construction", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Carpet_Collection", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "Carpet_Style", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "PileQuality", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Sample", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Colour", AgLibrary.ClsMain.SQLDataType.nVarChar, 50)
        AgL.FSetColumnValue(MdlTable, "Collection", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)

        AgL.FSetColumnValue(MdlTable, "EntryBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "EntryType", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "EntryStatus", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveBy", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "ApproveDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "MoveToLog", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "MoveToLogDate", AgLibrary.ClsMain.SQLDataType.SmallDateTime)
        AgL.FSetColumnValue(MdlTable, "IsDeleted", AgLibrary.ClsMain.SQLDataType.Bit)
        AgL.FSetColumnValue(MdlTable, "Div_Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 1)
        AgL.FSetColumnValue(MdlTable, "Status", AgLibrary.ClsMain.SQLDataType.nVarChar, 20)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        AgL.FSetFKeyValue(MdlTable, "Construction", "Code", "RUG_Construction")
    End Sub

    Private Sub FRUG_DesignImage(ByRef MdlTable() As AgLibrary.ClsMain.LITable, ByVal StrTableName As String, ByVal EntryType As EntryPointType)
        AgL.FAddTable(MdlTable, StrTableName, ModuleName)

        AgL.FSetColumnValue(MdlTable, "Code", AgLibrary.ClsMain.SQLDataType.nVarChar, 10)
        AgL.FSetColumnValue(MdlTable, "Photo", AgLibrary.ClsMain.SQLDataType.image)
        AgL.FSetColumnValue(MdlTable, "UID", AgLibrary.ClsMain.SQLDataType.uniqueidentifier, , IIf(EntryType = EntryPointType.Log, True, False))

        If EntryType = EntryPointType.Log Then
            AgL.FSetFKeyValue(MdlTable, "UID", "UID", "RUg_Design_Log")
        Else
            AgL.FSetFKeyValue(MdlTable, "Code", "Code", "RUg_Design")
        End If
    End Sub
#End Region

    Public Shared Sub FPrepareContraText(ByVal BlnOverWrite As Boolean, ByRef StrContraTextVar As String, _
                                         ByVal StrContraName As String, ByVal DblAmount As Double, ByVal StrDrCr As String)
        Dim IntNameMaxLen As Integer = 35, IntAmtMaxLen As Integer = 18, IntSpaceNeeded As Integer = 2
        StrContraName = AgL.XNull(AgL.Dman_Execute("Select Name from Subgroup With (NoLock) Where SubCode = '" & StrContraName & "'  ", AgL.GcnRead).ExecuteScalar)

        If BlnOverWrite Then
            StrContraTextVar = Mid(Trim(StrContraName), 1, IntNameMaxLen) & Space((IntNameMaxLen + IntSpaceNeeded) - Len(Mid(Trim(StrContraName), 1, IntNameMaxLen))) & Space(IntAmtMaxLen - Len(Format(Val(DblAmount), "##,##,##,##,##0.00"))) & Format(Val(DblAmount), "##,##,##,##,##0.00") & " " & Trim(StrDrCr)
        Else
            StrContraTextVar += Mid(Trim(StrContraName), 1, IntNameMaxLen) & Space((IntNameMaxLen + IntSpaceNeeded) - Len(Mid(Trim(StrContraName), 1, IntNameMaxLen))) & Space(IntAmtMaxLen - Len(Format(Val(DblAmount), "##,##,##,##,##0.00"))) & Format(Val(DblAmount), "##,##,##,##,##0.00") & " " & Trim(StrDrCr)
        End If
    End Sub

    Public Shared Sub PostStructureToAccounts(ByVal FGMain As AgStructure.AgCalcGrid, ByVal mNarr As String, ByVal mDocID As String, ByVal mDiv_Code As String, _
                                              ByVal mSite_Code As String, ByVal Div_Code As String, ByVal mV_Type As String, ByVal mV_Prefix As String, ByVal mV_No As Integer, _
                                              ByVal mRecID As String, ByVal PostingPartyAc As String, ByVal mV_Date As String, _
                                              ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand)
        Dim StrContraTextJV As String = ""
        Dim mPostSubCode = ""
        Dim I As Integer
        Dim mQry$ = "", bSelectionQry$ = ""
        Dim DtTemp As DataTable = Nothing


        For I = 0 To FGMain.Rows.Count - 1
            If Trim(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_PostAc, I).Value) <> "" Then
                If bSelectionQry = "" Then
                    bSelectionQry = " Select '" & FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_PostAc, I).Value & "' As PostAc, " & _
                    " Case When " & AgL.Chk_Text(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_DrCr, I).Value) & " = 'Dr' Then " & Val(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount, I).Value) & "  " & _
                    "      When " & AgL.Chk_Text(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_DrCr, I).Value) & " = 'Cr' Then " & -Val(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount, I).Value) & " End As Amount "
                Else
                    bSelectionQry += " UNION ALL "
                    bSelectionQry += " Select '" & FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_PostAc, I).Value & "' As PostAc, " & _
                    " Case When " & AgL.Chk_Text(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_DrCr, I).Value) & " = 'Dr' Then " & Val(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount, I).Value) & "  " & _
                    "      When " & AgL.Chk_Text(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_DrCr, I).Value) & " = 'Cr' Then " & -Val(FGMain(AgStructure.AgCalcGrid.AgCalcGridColumn.Col_Amount, I).Value) & " End As Amount "

                End If
            End If
        Next

        If bSelectionQry = "" Then Exit Sub



        mQry = " Select V1.PostAc, IsNull(Sum(V1.Amount),0) As Amount, " & _
                " Case When IsNull(Sum(V1.Amount),0) > 0 Then 'Dr' " & _
                "      When IsNull(Sum(V1.Amount),0) < 0 Then 'Cr' End As DrCr " & _
                " From (" & bSelectionQry & ") As V1 " & _
                " Group BY V1.PostAc "
        DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        With DtTemp
            For I = 0 To .Rows.Count - 1
                If Trim(AgL.XNull(.Rows(I)("PostAc"))) <> "" Then
                    If AgL.StrCmp(AgL.XNull(.Rows(I)("PostAc")), "|PARTY|") Then
                        If AgL.VNull(.Rows(I)("Amount")) <> 0 And AgL.XNull(.Rows(I)("DrCr")) <> "" Then
                            If StrContraTextJV <> "" Then StrContraTextJV += vbCrLf
                            FPrepareContraText(False, StrContraTextJV, PostingPartyAc, Math.Abs(AgL.VNull(.Rows(I)("Amount"))), AgL.XNull(.Rows(I)("DrCr")))
                        End If
                    Else
                        If AgL.VNull(.Rows(I)("Amount")) <> 0 And AgL.XNull(.Rows(I)("DrCr")) <> "" Then
                            If StrContraTextJV <> "" Then StrContraTextJV += vbCrLf
                            FPrepareContraText(False, StrContraTextJV, AgL.XNull(.Rows(I)("PostAc")), Math.Abs(Val(AgL.VNull(.Rows(I)("Amount")))), AgL.XNull(.Rows(I)("DrCr")))
                        End If
                    End If
                End If
            Next
        End With

        Dim mSrl As Integer = 0, mDebit As Double, mCredit As Double
        mQry = "Delete from Ledger where docId='" & mDocID & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        With DtTemp
            For I = 0 To .Rows.Count - 1
                If Trim(AgL.XNull(.Rows(I)("PostAc"))) <> "" And Val(AgL.VNull(.Rows(I)("Amount"))) <> 0 Then
                    mSrl += 1

                    mDebit = 0 : mCredit = 0
                    If AgL.StrCmp(AgL.XNull(.Rows(I)("PostAc")), "|PARTY|") Then
                        mPostSubCode = PostingPartyAc
                    Else
                        mPostSubCode = AgL.XNull(.Rows(I)("PostAc"))
                    End If

                    If AgL.StrCmp(AgL.XNull(.Rows(I)("DrCr")), "Dr") Then
                        mDebit = Math.Abs(AgL.VNull(.Rows(I)("Amount")))
                    ElseIf AgL.StrCmp(AgL.XNull(.Rows(I)("DrCr")), "Cr") Then
                        mCredit = Math.Abs(AgL.VNull(.Rows(I)("Amount")))
                    End If

                    mQry = "Insert Into Ledger(DocId,RecId,V_SNo,V_Date,SubCode,ContraSub,AmtDr,AmtCr," & _
                         " Narration,V_Type,V_No,V_Prefix,Site_Code,DivCode,Chq_No,Chq_Date,TDSCategory,TDSOnAmt,TDSDesc," & _
                         " TDSPer,TDS_Of_V_SNo,System_Generated,FormulaString,ContraText) Values " & _
                         " ('" & mDocID & "','" & mRecID & "'," & mSrl & "," & AgL.ConvertDate(mV_Date) & "," & AgL.Chk_Text(mPostSubCode) & "," & AgL.Chk_Text("") & ", " & _
                         " " & mDebit & "," & mCredit & ", " & _
                         " " & AgL.Chk_Text(mNarr) & ",'" & mV_Type & "','" & mV_No & "','" & mV_Prefix & "'," & _
                         " '" & mSite_Code & "','" & mDiv_Code & "','" & AgL.Chk_Text("") & "'," & _
                         " " & AgL.ConvertDate("") & "," & AgL.Chk_Text("") & "," & _
                         " " & Val("") & "," & AgL.Chk_Text("") & "," & Val("") & "," & 0 & ",'Y','" & "" & "','" & StrContraTextJV & "')"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                End If
            Next I
        End With
    End Sub

    Public Shared Sub ProcCreateLink(ByVal DGL As DataGridView, ByVal ColumnName As String)
        Try
            DGL.Columns(ColumnName).CellTemplate.Style.Font = New Font(DGL.DefaultCellStyle.Font.FontFamily, DGL.DefaultCellStyle.Font.Size, FontStyle.Underline)
            DGL.Columns(ColumnName).CellTemplate.Style.ForeColor = Color.Blue

            If DGL.Rows.Count > 0 Then
                DGL.Item(ColumnName, 0).Style.Font = New Font(DGL.DefaultCellStyle.Font.FontFamily, DGL.DefaultCellStyle.Font.Size, FontStyle.Underline)
                DGL.Item(ColumnName, 0).Style.ForeColor = Color.Blue
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub ProcOpenLinkForm(ByVal Mnu As System.Windows.Forms.ToolStripItem, ByVal SearchCode As String, ByVal Parent As Form)
        Dim FrmObj As AgTemplate.TempTransaction
        Dim CFOpen As New ClsFunction
        Try
            FrmObj = CFOpen.FOpen(Mnu.Name, Mnu.Text, True)
            If FrmObj IsNot Nothing Then
                FrmObj.MdiParent = Parent
                FrmObj.Show()
                FrmObj.FindMove(SearchCode)
                FrmObj = Nothing
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Shared Sub FSaveInMailOutBox(ByVal V_Type As String, ByVal GenDocId As String, _
            ByVal Party As String, ByVal PartyName As String, _
            ByVal Agent As String, ByVal AgentName As String, _
            ByVal Supplier As String, ByVal SupplierName As String, _
            ByVal V_Date As String, ByVal ReferenceNo As String, _
            ByVal Conn As SqlClient.SqlConnection, ByVal Cmd As SqlClient.SqlCommand, _
            Optional ByVal Attachment As String = "")

        Dim mQry$ = "", bSubject$ = "", bDescription$ = "", bRecepientEMail$ = "", bRecepient$ = "", Code$ = ""
        Dim DtTemp As DataTable = Nothing
        Dim I As Integer = 0, mSr As Integer = 0

        mQry = " SELECT * FROM MailEnviro Where V_Type = '" & V_Type & "'"
        DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        If DtTemp.Rows.Count = 0 Then Exit Sub

        bSubject = DtTemp.Rows(0)("Subject")
        bDescription = Replace(Replace(Replace(Replace(Replace(DtTemp.Rows(0)("Message"), "<Party>", PartyName), "<Agent>", AgentName), "<Date>", V_Date), "<ReferenceNo>", ReferenceNo), "<Supplier>", SupplierName)

        Code = AgL.GetMaxId("MailOutbox", "Code", AgL.GCn, AgL.PubDivCode, AgL.PubSiteCode, 8, True, True, AgL.ECmd, AgL.Gcn_ConnectionString)

        mQry = " Delete From MailOutBoxDetail Where Code = (Select Code From MailOutbox Where GenDocId = '" & GenDocId & "')"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mQry = " Delete From MailOutbox Where GenDocId = '" & GenDocId & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        If DtTemp.Rows.Count > 0 Then
            mQry = " INSERT INTO MailOutBox(Code, GenDocId, V_Type, Sender, Subject, Description, IsSend, " & _
                    " EntryBy, EntryDate, Div_Code) " & _
                    " VALUES('" & Code & "', '" & GenDocId & "', " & AgL.Chk_Text(V_Type) & ", " & _
                    " " & AgL.Chk_Text(DtTemp.Rows(0)("Sender")) & ", " & _
                    " " & AgL.Chk_Text(DtTemp.Rows(0)("Subject")) & ", " & _
                    " " & AgL.Chk_Text(bDescription) & ", 0, " & _
                    " '" & AgL.PubUserName & "', '" & AgL.GetDateTime(AgL.GcnRead) & "', '" & AgL.PubDivCode & "')"
            AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
        End If

        mQry = " SELECT L.* " & _
                " FROM MailEnviroDetail L " & _
                " LEFT JOIN MailEnviro H On L.Code = H.Code " & _
                " Where H.V_Type = '" & V_Type & "'"
        DtTemp = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

        With DtTemp
            If .Rows.Count > 0 Then
                For I = 0 To DtTemp.Rows.Count - 1
                    mSr += 1
                    If AgL.XNull(.Rows(I)("Recepient")) = "<Party>" Then
                        bRecepientEMail = FRetMailId(Party)
                        bRecepient = Party
                    ElseIf AgL.XNull(.Rows(I)("Recepient")) = "<Agent>" Then
                        bRecepientEMail = FRetMailId(Agent)
                        bRecepient = Agent
                    ElseIf AgL.XNull(.Rows(I)("Recepient")) = "<Supplier>" Then
                        bRecepientEMail = FRetMailId(Supplier)
                        bRecepient = Supplier
                    Else
                        bRecepientEMail = FRetMailId(AgL.XNull(.Rows(I)("Recepient")))
                        bRecepient = AgL.XNull(.Rows(I)("Recepient"))
                    End If
                    mQry = " INSERT INTO MailOutBoxDetail(Code, Sr, RecepientType, Recepient, " & _
                            " RecepientEMail) " & _
                            " VALUES ('" & Code & "', " & Val(mSr) & ", " & _
                            " " & AgL.Chk_Text(AgL.XNull(.Rows(I)("RecepientType"))) & ", " & _
                            " " & AgL.Chk_Text(bRecepient) & ",	" & _
                            " " & AgL.Chk_Text(bRecepientEMail) & ")"
                    AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)
                Next
            End If
        End With

        If Attachment <> "" Then
            FSaveAttachments(Code, Attachment)
        End If
    End Sub

    Public Shared Sub FSaveAttachments(ByVal Code As String, ByVal FileName As String)
        Dim I As Integer = 0
        Dim mFileToUpload$ = ""
        Dim Extension$ = ""
        Dim mSr As Integer = 0
        Dim mQry$ = ""

        Dim Conn As SqlClient.SqlConnection = ClsMain.FCreateFileDbConn()
        Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Cmd.Connection = Conn

        mQry = " Delete From MailOutBoxAttachments Where Code = '" & Code & "'"
        AgL.Dman_ExecuteNonQry(mQry, Conn, Cmd)

        mFileToUpload = FileName
        Extension = System.IO.Path.GetExtension(FileName)
        mSr = 1

        If StrComp(Extension, ".bmp", CompareMethod.Text) = 0 Or _
                    StrComp(Extension, ".jpg", CompareMethod.Text) = 0 Or _
                    StrComp(Extension, ".jpeg", CompareMethod.Text) = 0 Or _
                    StrComp(Extension, ".png", CompareMethod.Text) = 0 Or _
                    StrComp(Extension, ".gif", CompareMethod.Text) = 0 Then
            UploadImageOrFile(mFileToUpload, "Image", Code, mSr)
        Else
            UploadImageOrFile(mFileToUpload, Extension, Code, mSr)
        End If
    End Sub

    Public Shared Sub UploadImageOrFile(ByVal sFilePath As String, ByVal sFileType As String, ByVal Code As String, ByVal Sr As Integer)
        Dim SqlCom As SqlCommand
        Dim FileContent As Byte()
        Dim sFileName As String
        Dim qry As String

        Try
            Dim Conn As SqlClient.SqlConnection = ClsMain.FCreateFileDbConn()
            Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
            Cmd.Connection = Conn

            FileContent = ReadFile(sFilePath)
            sFileName = System.IO.Path.GetFileName(sFilePath)

            qry = "Insert into MailOutBoxAttachments (Code, Sr, FileName,FileContent," & _
                    " FileType) values(@Code, @Sr, @FileName, @FileContent," & _
                    " @FileType)"

            SqlCom = New SqlCommand(qry, Conn)

            SqlCom.Parameters.Add(New SqlParameter("@Code", Code))
            SqlCom.Parameters.Add(New SqlParameter("@Sr", Sr))
            SqlCom.Parameters.Add(New SqlParameter("@FileName", sFileName))
            SqlCom.Parameters.Add(New SqlParameter("@FileContent", DirectCast(FileContent, Object)))
            SqlCom.Parameters.Add(New SqlParameter("@FileType", sFileType))
            SqlCom.ExecuteNonQuery()

        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
    End Sub

    Public Shared Function ReadFile(ByVal sPath As String) As Byte()
        Dim data As Byte() = Nothing
        Dim fInfo As New FileInfo(sPath)
        Dim numBytes As Long = fInfo.Length
        Dim fStream As New FileStream(sPath, FileMode.Open, FileAccess.Read)
        Dim br As New BinaryReader(fStream)
        data = br.ReadBytes(CInt(numBytes))
        Return data
    End Function

    Public Shared Function FRetMailId(ByVal SubCode As String)
        Dim mQry$ = ""
        mQry = " Select EMail From SubGroup Sg With (NoLock) Where SubCode = '" & SubCode & "' "
        FRetMailId = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)
    End Function

    Public Shared Function FCreateFileDbConn() As SqlClient.SqlConnection
        Dim mQry$ = ""
        Try
            Dim DatabaseName$ = ""
            Dim DsTemp As DataSet = Nothing
            mQry = " Select FileDbName From Company Where Comp_Code = '" & AgL.PubCompCode & "' "
            DatabaseName = AgL.XNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar)
            Dim Cs As String = "Persist Security Info=False;User ID='" & AgL.PubDBUserSQL & "';pwd=" & AgL.PubDBPasswordSQL & ";Initial Catalog=" & DatabaseName & ";Data Source=" & AgL.PubServerName

            Dim Conn As SqlClient.SqlConnection = New SqlClient.SqlConnection(Cs)
            If Conn.State = ConnectionState.Closed Then Conn.Open()

            FCreateFileDbConn = Conn
        Catch ex As Exception
            FCreateFileDbConn = Nothing
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Function FSendEMail(ByVal SearchCode As String) As Boolean
        Dim MLDFrom As System.Net.Mail.MailAddress
        Dim MLMMain As System.Net.Mail.MailMessage
        Dim SMTPMain As System.Net.Mail.SmtpClient
        Dim I As Integer
        Dim DtFromEmail As DataTable = Nothing
        Dim DtRecepients As DataTable = Nothing
        Dim DtAttachments As DataTable = Nothing
        Dim SmtpHost$ = "", SmtpPort$ = ""
        Dim bBlnEnableSsl As Boolean = False
        Dim mQry$ = ""


        Try
            'If AgL.PubDtEnviro_EMail.Rows.Count > 0 Then
            '    bBlnEnableSsl = AgL.VNull(AgL.PubDtEnviro_EMail.Rows(0)("EnableSsl"))
            'End If

            mQry = " SELECT H.*, S.FromEmailAddress, S.FromEmailPassword, S.SMTPHost, S.SMTPPort " & _
                    " FROM MailOutBox H With (NoLock) " & _
                    " LEFT JOIN MailSender S With (NoLock) On H.Sender = S.Code " & _
                    " WHERE H.Code = '" & SearchCode & "'"
            DtFromEmail = AgL.FillData(mQry, AgL.GcnRead).Tables(0)

            If DtFromEmail.Rows.Count > 0 Then
                SmtpHost = AgL.XNull(DtFromEmail.Rows(0)("SmtpHost"))
                SmtpPort = AgL.XNull(DtFromEmail.Rows(0)("SmtpPort"))

                MLDFrom = New System.Net.Mail.MailAddress(AgL.XNull(DtFromEmail.Rows(0)("FromEMailAddress")))
                MLMMain = New System.Net.Mail.MailMessage()
                MLMMain.From = MLDFrom
                SMTPMain = New System.Net.Mail.SmtpClient(SmtpHost, SmtpPort)
                MLMMain.Body = AgL.XNull(DtFromEmail.Rows(0)("Description"))
                MLMMain.Subject = AgL.XNull(DtFromEmail.Rows(0)("Subject"))

                mQry = " SELECT * FROM MailOutBoxDetail With (NoLock) WHERE Code = '" & SearchCode & "'"
                DtRecepients = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                With DtRecepients
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            If AgL.XNull(.Rows(I)("RecepientType")) = "To" Then
                                MLMMain.To.Add(AgL.XNull(.Rows(I)("RecepientEMail")))
                            ElseIf AgL.XNull(.Rows(I)("RecepientType")) = "Cc" Then
                                MLMMain.CC.Add(AgL.XNull(.Rows(I)("RecepientEMail")))
                            ElseIf AgL.XNull(.Rows(I)("RecepientType")) = "Cc" Then
                                MLMMain.Bcc.Add(AgL.XNull(.Rows(I)("RecepientEMail")))
                            End If
                        Next
                    End If
                End With

                Dim Conn As SqlClient.SqlConnection = ClsMain.FCreateFileDbConn()
                Dim Cmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
                Cmd.Connection = Conn

                mQry = " Select * From MailOutBoxAttachments With (NoLock) Where Code = '" & SearchCode & "' "
                DtAttachments = AgL.FillData(mQry, Conn).Tables(0)

                With DtAttachments
                    If .Rows.Count > 0 Then
                        For I = 0 To .Rows.Count - 1
                            Dim ByteData As Byte() = DirectCast(.Rows(I)("FileContent"), Byte())
                            Dim MS As MemoryStream = New System.IO.MemoryStream(ByteData)
                            MLMMain.Attachments.Add(New System.Net.Mail.Attachment(MS, AgL.XNull(.Rows(I)("FileName")).ToString))
                        Next
                    End If
                End With

                SMTPMain.Credentials = New Net.NetworkCredential(DtFromEmail.Rows(0)("FromEmailAddress"), DtFromEmail.Rows(0)("FromEmailPassword"))
                SMTPMain.EnableSsl = True
                SMTPMain.Send(MLMMain)
                MLMMain.Dispose()
                FSendEMail = True


            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Function

    Public Shared Sub FPrintThisDocument(ByVal objFrm As Object, ByVal V_Type As String, _
    Optional ByVal PrintQuery As String = "", Optional ByVal RepName As String = "", Optional ByVal RepTitle As String = "")
        Dim DtVTypeSetting As DataTable = Nothing
        Dim mQry As String
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = ""

        Try
            If PrintQuery = "" Then
                mQry = "Select * from Voucher_Type_Print_Settings With (NoLock) " & _
                       "Where V_Type = '" & V_Type & "' " & _
                       "And Site_Code = '" & AgL.PubSiteCode & "' " & _
                       "And Div_Code  = '" & AgL.PubDivCode & "' "
                DtVTypeSetting = AgL.FillData(mQry, AgL.GcnRead).Tables(0)
                If DtVTypeSetting.Rows.Count = 0 Then
                    MsgBox("Voucher type print settings are not defined, Can't continue.", MsgBoxStyle.OkOnly, "Validation")
                    Exit Sub
                End If

                If AgL.XNull(DtVTypeSetting.Rows(0)("Query")) = "" Then
                    MsgBox("Query Field is blank in Voucher type print settings, Can't continue.", MsgBoxStyle.OkOnly, "Validation")
                    Exit Sub
                Else
                    PrintQuery = AgL.XNull(DtVTypeSetting.Rows(0)("Query"))
                End If

                If AgL.XNull(DtVTypeSetting.Rows(0)("Report_Name")) = "" Then
                    MsgBox("Report_Name Field is blank in Voucher type print settings, Can't continue.", MsgBoxStyle.OkOnly, "Validation")
                    Exit Sub
                End If

                If AgL.XNull(DtVTypeSetting.Rows(0)("Report_Heading")) = "" Then
                    MsgBox("Report_Heading Field is blank in Voucher type print settings, Can't continue.", MsgBoxStyle.OkOnly, "Validation")
                    Exit Sub
                End If

                AgL.PubReportTitle = AgL.XNull(DtVTypeSetting.Rows(0)("Report_Heading"))
                RepName = AgL.XNull(DtVTypeSetting.Rows(0)("Report_Name")) : RepTitle = AgL.XNull(DtVTypeSetting.Rows(0)("Report_Heading"))

                PrintQuery = Replace(PrintQuery.ToString.ToUpper, "<SEARCHCODE>", objFrm.mSearchCode)
            End If


            AgL.ADMain = New SqlClient.SqlDataAdapter(PrintQuery, AgL.GCn)
            AgL.ADMain.Fill(DsRep)
            AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)
            mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
            mCrd.SetDataSource(DsRep.Tables(0))
            CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
            AgPL.Formula_Set(mCrd, RepTitle)
            AgPL.Show_Report(ReportView, "* " & RepTitle & " *", objFrm.MdiParent)

            Call AgL.LogTableEntry(objFrm.mSearchCode, objFrm.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally

        End Try
    End Sub

    Public Shared Sub FGetItemRate(ByVal ItemCode As String, ByVal RateType As String, ByVal V_Date As String, _
                                    ByVal Party As String, ByVal Supplier As String, _
                                    ByRef Rate As Double, ByRef RatePerQty As Double, ByRef RatePerMeasure As Double, _
                                    Optional ByRef QuotationDocId As String = "", _
                                    Optional ByRef QuotationNo As String = "", _
                                    Optional ByRef QuotationSr As String = "", _
                                    Optional ByRef Qty As Double = 0)
        Dim mQry$ = ""
        Dim DtTemp As DataTable = Nothing
        Dim DtTempERateLIst As DataTable = Nothing
        Try
            mQry = " SELECT TOP 1 L.Rate, L.DocId As QuotationDocId, H.V_Type + '-' + H.ReferenceNo As QuotationNo, " & _
                    " L.Sr As QuotationSr, L.Qty, L.RatePerQty, L.RatePerMeasure " & _
                    " FROM SaleQuotationDetail L  " & _
                    " LEFT JOIN SaleQuotation H ON L.DocId = H.DocID " & _
                    " WHERE H.SaleToParty = '" & Party & "' AND IsNull(L.Supplier,'') = '" & Supplier & "' " & _
                    " AND L.Item = '" & ItemCode & "'  " & _
                    " AND H.V_Date <= '" & V_Date & "' " & _
                    " ORDER BY H.V_Date DESC "
            DtTemp = AgL.FillData(mQry, AgL.GCn).Tables(0)
            If DtTemp.Rows.Count > 0 Then
                Rate = AgL.VNull(DtTemp.Rows(0)("Rate"))
                RatePerQty = AgL.VNull(DtTemp.Rows(0)("RatePerQty"))
                RatePerMeasure = AgL.VNull(DtTemp.Rows(0)("RatePerMeasure"))
                QuotationDocId = AgL.XNull(DtTemp.Rows(0)("QuotationDocId"))
                QuotationNo = AgL.XNull(DtTemp.Rows(0)("QuotationNo"))
                QuotationSr = AgL.VNull(DtTemp.Rows(0)("QuotationSr"))
                Qty = AgL.VNull(DtTemp.Rows(0)("Qty"))
            Else
                mQry = " SELECT TOP 1 L.Rate FROM RateListDetail L WHERE L.Item = '" & ItemCode & "'  AND IsNull(L.RateType,'') = '" & RateType & "' And WEF <= '" & V_Date & "'  ORDER BY L.WEF DESC "
                DtTempERateLIst = AgL.FillData(mQry, AgL.GCn).Tables(0)
                If DtTemp.Rows.Count > 0 Then
                    Rate = AgL.VNull(DtTempERateLIst.Rows(0)("Rate"))
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " In FGetItemRate")
        End Try
    End Sub
End Class