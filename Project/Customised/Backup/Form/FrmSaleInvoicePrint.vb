Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmSaleInvoicePrint
    Dim mQry As String = ""

    Dim DtMaster As DataTable = Nothing
    Dim mSearchCode$ = ""
    Dim mCustomGrid As AgCustomFields.AgCustomGrid
    Dim mCalcGrid As AgStructure.AgCalcGrid

    Public Sub New(ByVal SearchCode As String, ByVal CustomGrid As AgCustomFields.AgCustomGrid, ByVal CalcGrid As AgStructure.AgCalcGrid)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        mSearchCode = SearchCode
        mCustomGrid = CustomGrid
        mCalcGrid = CalcGrid
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, 0)
    End Sub

    Public Sub IniGrid()
    End Sub

    Private Sub KeyDown_Form(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.ActiveControl IsNot Nothing Then
            If Not (TypeOf (Me.ActiveControl) Is AgControls.AgDataGrid) Then
                If e.KeyCode = Keys.Return Then SendKeys.Send("{Tab}")
            End If
            If e.KeyCode = Keys.Escape Then Me.Close()
        End If
    End Sub

    Sub KeyPress_Form(ByVal Sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = Chr(Keys.Escape) Then Exit Sub
        If Me.ActiveControl Is Nothing Then Exit Sub
        AgL.CheckQuote(e)
    End Sub

    Private Sub Form_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ExporterDeclaration.Checked = True
    End Sub

    Private Sub BlankText()
    End Sub

    Private Function Data_Validation() As Boolean
        Dim I As Integer = 0
        Try
            Data_Validation = True
        Catch ex As Exception
            MsgBox(ex.Message)
            Data_Validation = False
        End Try
    End Function

    Private Sub MasterKey()
        Dim DsTemp As DataSet
        Dim DsTemp1 As DataSet
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = "", bCondstr1 As String = ""
        Dim bProcess As String = "", bReportFormat As String = ""

        Dim j As Integer
        Dim I As Integer
        Dim Rollno As String = ""
        Dim PoNo As String = ""
        Dim Mitemname As String = ""
        Dim bTempTable$ = ""


        Try
            bTableName = "SaleInvoice" : bSecTableName = "SaleInvoiceDetail Sd ON s.DocID =sd.DocId "
            bCondstr = "WHERE s.DocID='" & mSearchCode & "' "
            bCondstr1 = " max(s.DocID) as BIllId"

            mQry = "SELECT  SD.SaleOrder,ISNULL(sord.PartyOrderNo,'') AS OrderNo,sd.Item AS Itemcode ,max(s.Currency) AS Currency, " & _
                             " sum(sd.Qty) AS Pcs,sum(sd.Amount)/sum(sd.Qty) AS Rate, sum(sd.Amount) AS AMount, " & _
                             " max(item.Description) AS ItemName, max(d.Description) AS Design, max(Si.PrintingDescription) AS Size " & _
                             " FROM  " & bTableName & " s    LEFT JOIN  " & bSecTableName & "  " & _
                             " LEFT JOIN Item ON sd.item=Item.Code  " & _
                             " LEFT JOIN SubGroup ON s.SaleToParty =SubGroup.SubCode  " & _
                             " LEFT JOIN RUG_Design D ON I.Design = D.Code  " & _
                             " LEFT JOIN RUG_Quality  rq ON I.Quality = rq.Code  " & _
                             " LEFT JOIN Rug_Size Si ON I.Size = SI.Code  " & _
                             " LEFT JOIN SaleOrder sord ON sd.SaleOrder=sord.DocID      " & _
                             " LEFT JOIN City ON s.SaleToPartyCity=City.CityCode  " & _
                             " " & bCondstr & " GROUP BY sord.PartyOrderNo ,SD.SaleOrder, sd.Item  "


            DsTemp = AgL.FillData(mQry, AgL.GcnRead)



            bTempTable = AgL.GetGUID(AgL.GCn).ToString
            mQry = "CREATE TABLE [#" & bTempTable & "] " & _
                   " (Pono  NVARCHAR(50), Item NVARCHAR(50), Design NVARCHAR(50),Size NVARCHAR(50), Noofpcs Float, " & _
                   " RatePerPcs Float, TotalValue Float, RollNo NVARCHAR(Max))  "
            AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)



            With DsTemp.Tables(0)



                If .Rows.Count > 0 Then
                    For I = 0 To DsTemp.Tables(0).Rows.Count - 1


                        mQry = "SELECT convert(float,sd.BaleNo) AS Rollno " & _
                                         " FROM  " & bTableName & " s    LEFT JOIN  " & bSecTableName & "  " & _
                                         " " & bCondstr & " and sd.Item=" & AgL.Chk_Text(AgL.XNull(.Rows(I)("ItemCode"))) & " and IsNull(sd.SaleOrder,'') = '" & AgL.XNull(.Rows(I)("SaleOrder")) & "'  "

                        Rollno = ""
                        DsTemp1 = AgL.FillData(mQry, AgL.GcnRead)
                        With DsTemp1.Tables(0)
                            If .Rows.Count > 0 Then
                                For j = 0 To DsTemp1.Tables(0).Rows.Count - 1
                                    If Rollno = "" Then
                                        Rollno = Rollno & AgL.XNull(.Rows(j)("Rollno"))
                                    Else
                                        Rollno = Rollno & "," & AgL.XNull(.Rows(j)("Rollno"))
                                    End If

                                Next
                            End If
                        End With

                        mQry = "INSERT INTO [#" & bTempTable & "] (Pono,Item,Design,Size,Noofpcs,RatePerPcs,TotalValue,RollNo ) " & _
                         " Values(  " & AgL.Chk_Text(AgL.XNull(.Rows(I)("OrderNo"))) & "," & _
                         "  " & AgL.Chk_Text(AgL.XNull(.Rows(I)("ItemName"))) & ",  " & AgL.Chk_Text(AgL.XNull(.Rows(I)("Design"))) & ", " & AgL.Chk_Text(AgL.XNull(.Rows(I)("Size"))) & ", " & _
                         " " & Val(AgL.VNull(.Rows(I)("Pcs"))) & "," & Val(AgL.VNull(.Rows(I)("Rate"))) & "," & Val(AgL.VNull(.Rows(I)("AMount"))) & "," & AgL.Chk_Text(Rollno) & " ) "

                        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn)

                    Next I
                End If
            End With

            mQry = "Select Pono as [PO NOS],Item as [ITEM NO.],Design as [DESIGN NOS.],Size as [SIZE(SQ.FTS.] ,Noofpcs as [NO.OF PCS.] , " & _
               " RatePerPcs as [RATE PER PCS.] ,TotalValue as [TOTAL VALUE US$] ,RollNo as [ROLL NO.] from [#" & bTempTable & "]"


            Dim FrmObj As Form
            FrmObj = New AgTemplate.FrmReportWindow(mQry, "Master Key Of Invoice")


            FrmObj.ShowDialog()

        Catch EX As Exception
            MsgBox(EX.Message)
        End Try

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim mCrd As New ReportDocument
        Dim ReportView As New AgLibrary.RepView
        Dim DsRep As New DataSet
        Dim strQry As String = "", RepName As String = "", RepTitle As String = ""
        Dim bTableName As String = "", bSecTableName As String = "", bCondstr As String = ""
        Dim bStructJoin As String = ""
        Dim bProcess As String = "", bReportFormat As String = ""

        Try
            Select Case sender.name
                Case Else
                    Me.Cursor = Cursors.Default

                    If mSearchCode = "" Then
                        MsgBox("No Records Found to Print!!!", vbInformation, "Information")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    bCondstr = " Where S.DocId = '" & mSearchCode & "'"

                    If ExporterDeclaration.Checked = True Then
                        AgL.PubReportTitle = "Exporter Declaration"
                        RepName = "Carpet_ExporterDeclaration" : RepTitle = "Exporter Declaration"
                    ElseIf CargoDeclaration.Checked = True Then
                        AgL.PubReportTitle = "Cargo Declaration"
                        RepName = "Carpet_CargoDeclaration" : RepTitle = "Cargo Declaration"
                    ElseIf PackingList.Checked = True Then
                        AgL.PubReportTitle = "Carpet Packing List"
                        RepName = "Carpet_PackingList" : RepTitle = "Packing List"
                    ElseIf OrderSheet.Checked = True Then
                        AgL.PubReportTitle = "Order Sheet"
                        RepName = "Carpet_OrderSheet" : RepTitle = "Order Sheet"
                    ElseIf SingleCountryDeclaration.Checked = True Then
                        AgL.PubReportTitle = "Single Country Declaration"
                        RepName = "Carpet_SingleCountryDeclaration" : RepTitle = "SINGLE COUNTRY DECLARATION"
                    ElseIf SpecialCustomerInvoice.Checked = True Then
                        AgL.PubReportTitle = "SPECIAL CUSTOMS INVOICE"
                        RepName = "Carpet_SpecialCustomerInvoice" : RepTitle = "SPECIAL CUSTOMS INVOICE"
                    ElseIf OptDocumentOfExchange.Checked = True Then
                        AgL.PubReportTitle = "Document Of Exchange"
                        RepName = "Carpet_DocumentOfExchange" : RepTitle = "Document Of Exchange"
                    ElseIf OptDocumentOfExchange2.Checked = True Then
                        AgL.PubReportTitle = "Document Of Exchange"
                        RepName = "Carpet_DocumentOfExchange2" : RepTitle = "Document Of Exchange"
                    ElseIf Invoice.Checked = True Then
                        AgL.PubReportTitle = "Invoice"
                        RepName = "Carpet_SaleInvoice" : RepTitle = "Invoice"
                    ElseIf OptPostShipmentCoveringLetter.Checked = True Then
                        AgL.PubReportTitle = "Post Shipment Covering Letter"
                        RepName = "Carpet_PostShipmentCoveringLetter" : RepTitle = "Post Shipment Covering Letter"
                    ElseIf OptPostShipmentCoveringLetterpURCHASE.Checked = True Then
                        AgL.PubReportTitle = "Post Shipment Covering Letter"
                        RepName = "Carpet_PostShipmentCoveringLetterPurchase" : RepTitle = "Post Shipment Covering Letter"
                    Else
                        MsgBox("Select Any Print Option!!!", vbInformation, "Information")
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    strQry = " SELECT 	s.DocID,s.V_Type,s.V_Prefix,s.V_Date,s.V_No,s.Div_Code,s.Site_Code,s.ReferenceNo,s.Godown,s.Vendor,s.SaleToParty, " & _
                             " s.SaleToPartyName,s.SaleToPartyAddress,s.SaleToPartyCity,s.SaleToPartyMobile,s.SaleToPartyTinNo,s.SaleToPartyCstNo, " & _
                             " s.ShipToParty,s.ShipToPartyName,s.ShipToPartyAddress,s.ShipToPartyCity,s.ShipToPartyMobile,s.SaleOrder,s.SaleChallan, " & _
                             " CU.Description AS Currency,s.SalesTaxGroupParty,s.Structure,s.BillingType,s.Form,s.FormNo,s.Transporter,s.Vehicle,s.VehicleDescription," & _
                             " s.Driver,s.DriverName,s.DriverContactNo,s.LrNo,s.LrDate,s.PrivateMark,PL.Description AS PortOfLoading,PD.Description AS DestinationPort,s.FinalPlaceOfDelivery, " & _
                             " s.PreCarriageBy,s.PlaceOfPreCarriage,s.ShipmentThrough,s.CreditDays,s.ReferenceDocId,s.Remarks,s.TotalQty,s.TotalMeasure,s.TotalAmount, " & _
                             " s.OrderNo,s.OrderDate," & _
                             " s.BaleNoStr AS HeaderRoll, " & _
                             " sd.Item,sd.Specification,sd.SalesTaxGroupItem,sd.DocQty,sd.Qty,sd.Unit,sd.MeasurePerPcs,sd.MeasureUnit, I.ItemInvoiceGroup," & _
                             " sd.TotalDocMeasure,sd.TotalMeasure,sd.Rate,sd.Amount,sd.ReferenceDocId,sd.LotNo,sd.BaleNo, item.Description AS ItemName, " & _
                             " SI.Description AS Size, SD.TotalDeliveryMeasure AS DeliveryMeasure, SD.DeliveryMeasurePerPcs , Si.MeterArea, Si.YardArea,City.CityName,City.Country, " & _
                             " SUBGROUP.ADD1,SUBGROUP.ADD2,SUBGROUP.ADD3,SM.Name AS SiteName, CSM.Country AS CompanyCountry,IIG.Description  AS InvoiceItemGroupDesc,  " & _
                             " S.TotalBale, " & _
                             " SM.Director, SM.Tin, SM.IEC , SM.ExciseDivision as ExiseDivision ," & _
                             " SO.PartyOrderNo , IB.BuyerSku, IB.BuyerUpcCode, ISNULL(IIG.Knots,0) AS KnotsPerSQMtr, IIG.ItcHsCode, " & _
                             " Sd.Qty * Si.FeetArea As TotalFeetArea, Sd.Qty * Si.MeterArea As TotalMeterArea, " & _
                             " " & mCalcGrid.FLineTableFieldNameStr("S.", "H_") & " " & _
                             " " & mCustomGrid.FHeaderTableFieldNameStr("S.", "H_") & "  " & _
                             " FROM  SaleInvoice S  WITH (NOLOCK) " & _
                             " LEFT JOIN SaleInvoiceDetail Sd On S.DocId = Sd.DocId  " & _
                             " LEFT JOIN SiteMast SM  WITH (NOLOCK) ON SM.Code=S.Site_Code  " & _
                             " LEFT JOIN City CSM  WITH (NOLOCK) ON CSM.CityCode=SM.City_Code  " & _
                             " LEFT JOIN Currency CU  WITH (NOLOCK) ON CU.Code=S.Currency " & _
                             " LEFT JOIN Item  WITH (NOLOCK) ON sd.item=Item.Code " & _
                             " LEFT JOIN SaleOrder SO  WITH (NOLOCK) ON SO.DocID= SD.SaleOrder " & _
                             " LEFT JOIN ItemBuyer IB  WITH (NOLOCK) ON IB.Code = SD.Item AND IB.Buyer = s.SaleToParty " & _
                             " LEFT JOIN SubGroup  WITH (NOLOCK) ON s.SaleToParty = SubGroup.SubCode " & _
                             " LEFT JOIN RUG_SampleSku CS  WITH (NOLOCK) ON sd.item=cs.Code " & _
                             " LEFT JOIN Rug_Size Si  WITH (NOLOCK) ON Cs.Size = SI.Code " & _
                             " LEFT JOIN City  WITH (NOLOCK) ON s.SaleToPartyCity=City.CityCode " & _
                             " LEFT JOIN SeaPort PD  WITH (NOLOCK) ON PD.Code=s.DestinationPort " & _
                             " LEFT JOIN SeaPort PL  WITH (NOLOCK) ON PL.Code=s.PortOfLoading " & _
                             " LEFT JOIN Item I On Sd.Item = I.Code " & _
                             " LEFT JOIN ItemInvoiceGroup IIG  WITH (NOLOCK) ON IIG.Code= I.ItemInvoiceGroup " & _
                             " " & bCondstr

                    '& " Order by (Case When IsNumeric(Convert(Numeric,Sd.BaleNo))>0 Then Convert(Numeric,Sd.BaleNo) Else 0 end )  "


                    '" CASE WHEN IsNumeric(sd.BaleNo) > 0 THEN Convert(INT, sd.BaleNo) ELSE 0 END AS  RollNoToSort, " & _


                    AgL.ADMain = New SqlClient.SqlDataAdapter(strQry, AgL.GCn)
                    AgL.ADMain.Fill(DsRep)

                    AgPL.CreateFieldDefFile1(DsRep, AgL.PubReportPath & "\" & RepName & ".ttx", True)

                    mCrd.Load(AgL.PubReportPath & "\" & RepName & ".rpt")
                    mCrd.SetDataSource(DsRep.Tables(0))

                    CType(ReportView.Controls("CrvReport"), CrystalDecisions.Windows.Forms.CrystalReportViewer).ReportSource = mCrd
                    AgPL.Formula_Set(mCrd, RepTitle)
                    AgPL.Show_Report(ReportView, "* " & RepTitle & " *", Me.MdiParent)

                    Call AgL.LogTableEntry(mSearchCode, Me.Text, "P", AgL.PubMachineName, AgL.PubUserName, AgL.PubLoginDate, AgL.GCn, AgL.ECmd)
            End Select
        Catch Ex As Exception
            MsgBox(Ex.Message)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub BtnClose_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles BtnClose.Click
        Me.Close()
    End Sub
End Class