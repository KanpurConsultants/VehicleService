Public Class FrmVehicle
    Inherits AgTemplate.TempMaster


    Dim mQry$

#Region "Designer Code"
    Private Sub InitializeComponent()
        Me.Label19 = New System.Windows.Forms.Label
        Me.TxtCustomerId = New AgControls.AgTextBox
        Me.TxtOwnerMobile = New AgControls.AgTextBox
        Me.TxtOwnerAdd2 = New AgControls.AgTextBox
        Me.LblCity = New System.Windows.Forms.Label
        Me.TxtOwnerAdd1 = New AgControls.AgTextBox
        Me.LblAddress = New System.Windows.Forms.Label
        Me.TxtChassisNo = New AgControls.AgTextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtVehicleSpecification = New AgControls.AgTextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtInsuranceCompany = New AgControls.AgTextBox
        Me.TxtPolicyNo = New AgControls.AgTextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.LblOwnerMobile = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.TxtModel = New AgControls.AgTextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtOwnerCity = New AgControls.AgTextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.LblRegistrationNo = New System.Windows.Forms.Label
        Me.TxtEngineNo = New AgControls.AgTextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.TxtPolicyExpiryDate = New AgControls.AgTextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.TxtPolicyDate = New AgControls.AgTextBox
        Me.LblCurrency = New System.Windows.Forms.Label
        Me.LblOwnerName = New System.Windows.Forms.Label
        Me.TxtOwnerName = New AgControls.AgTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TxtRegistrationNo = New AgControls.AgTextBox
        Me.GrpUP.SuspendLayout()
        Me.GBoxEntryType.SuspendLayout()
        Me.GBoxMoveToLog.SuspendLayout()
        Me.GBoxApprove.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GBoxDivision.SuspendLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Topctrl1
        '
        Me.Topctrl1.Size = New System.Drawing.Size(862, 41)
        Me.Topctrl1.TabIndex = 15
        Me.Topctrl1.tAdd = False
        Me.Topctrl1.tDel = False
        Me.Topctrl1.tEdit = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(0, 317)
        Me.GroupBox1.Size = New System.Drawing.Size(904, 4)
        '
        'GrpUP
        '
        Me.GrpUP.Location = New System.Drawing.Point(14, 321)
        '
        'TxtEntryBy
        '
        Me.TxtEntryBy.Tag = ""
        Me.TxtEntryBy.Text = ""
        '
        'GBoxEntryType
        '
        Me.GBoxEntryType.Location = New System.Drawing.Point(148, 321)
        '
        'TxtEntryType
        '
        Me.TxtEntryType.Tag = ""
        '
        'GBoxMoveToLog
        '
        Me.GBoxMoveToLog.Location = New System.Drawing.Point(554, 321)
        '
        'TxtMoveToLog
        '
        Me.TxtMoveToLog.Tag = ""
        '
        'GBoxApprove
        '
        Me.GBoxApprove.Location = New System.Drawing.Point(401, 321)
        Me.GBoxApprove.Text = "Approved By"
        '
        'TxtApproveBy
        '
        Me.TxtApproveBy.Location = New System.Drawing.Point(3, 23)
        Me.TxtApproveBy.Size = New System.Drawing.Size(136, 18)
        Me.TxtApproveBy.Tag = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Location = New System.Drawing.Point(704, 321)
        '
        'GBoxDivision
        '
        Me.GBoxDivision.Location = New System.Drawing.Point(278, 321)
        '
        'TxtDivision
        '
        Me.TxtDivision.AgSelectedValue = ""
        Me.TxtDivision.Tag = ""
        '
        'TxtStatus
        '
        Me.TxtStatus.AgSelectedValue = ""
        Me.TxtStatus.Tag = ""
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(432, 115)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(78, 16)
        Me.Label19.TabIndex = 3068
        Me.Label19.Text = "Customer Id"
        '
        'TxtCustomerId
        '
        Me.TxtCustomerId.AgAllowUserToEnableMasterHelp = False
        Me.TxtCustomerId.AgLastValueTag = Nothing
        Me.TxtCustomerId.AgLastValueText = Nothing
        Me.TxtCustomerId.AgMandatory = False
        Me.TxtCustomerId.AgMasterHelp = False
        Me.TxtCustomerId.AgNumberLeftPlaces = 8
        Me.TxtCustomerId.AgNumberNegetiveAllow = False
        Me.TxtCustomerId.AgNumberRightPlaces = 2
        Me.TxtCustomerId.AgPickFromLastValue = False
        Me.TxtCustomerId.AgRowFilter = ""
        Me.TxtCustomerId.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtCustomerId.AgSelectedValue = Nothing
        Me.TxtCustomerId.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtCustomerId.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtCustomerId.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtCustomerId.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustomerId.Location = New System.Drawing.Point(525, 114)
        Me.TxtCustomerId.MaxLength = 20
        Me.TxtCustomerId.Name = "TxtCustomerId"
        Me.TxtCustomerId.Size = New System.Drawing.Size(184, 18)
        Me.TxtCustomerId.TabIndex = 5
        '
        'TxtOwnerMobile
        '
        Me.TxtOwnerMobile.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerMobile.AgLastValueTag = Nothing
        Me.TxtOwnerMobile.AgLastValueText = Nothing
        Me.TxtOwnerMobile.AgMandatory = False
        Me.TxtOwnerMobile.AgMasterHelp = False
        Me.TxtOwnerMobile.AgNumberLeftPlaces = 8
        Me.TxtOwnerMobile.AgNumberNegetiveAllow = False
        Me.TxtOwnerMobile.AgNumberRightPlaces = 2
        Me.TxtOwnerMobile.AgPickFromLastValue = False
        Me.TxtOwnerMobile.AgRowFilter = ""
        Me.TxtOwnerMobile.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerMobile.AgSelectedValue = Nothing
        Me.TxtOwnerMobile.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerMobile.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerMobile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerMobile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerMobile.Location = New System.Drawing.Point(468, 194)
        Me.TxtOwnerMobile.MaxLength = 35
        Me.TxtOwnerMobile.Name = "TxtOwnerMobile"
        Me.TxtOwnerMobile.Size = New System.Drawing.Size(241, 18)
        Me.TxtOwnerMobile.TabIndex = 10
        '
        'TxtOwnerAdd2
        '
        Me.TxtOwnerAdd2.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerAdd2.AgLastValueTag = Nothing
        Me.TxtOwnerAdd2.AgLastValueText = Nothing
        Me.TxtOwnerAdd2.AgMandatory = False
        Me.TxtOwnerAdd2.AgMasterHelp = False
        Me.TxtOwnerAdd2.AgNumberLeftPlaces = 8
        Me.TxtOwnerAdd2.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd2.AgNumberRightPlaces = 2
        Me.TxtOwnerAdd2.AgPickFromLastValue = False
        Me.TxtOwnerAdd2.AgRowFilter = ""
        Me.TxtOwnerAdd2.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd2.AgSelectedValue = Nothing
        Me.TxtOwnerAdd2.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd2.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd2.Location = New System.Drawing.Point(240, 174)
        Me.TxtOwnerAdd2.MaxLength = 100
        Me.TxtOwnerAdd2.Name = "TxtOwnerAdd2"
        Me.TxtOwnerAdd2.Size = New System.Drawing.Size(469, 18)
        Me.TxtOwnerAdd2.TabIndex = 8
        '
        'LblCity
        '
        Me.LblCity.AutoSize = True
        Me.LblCity.BackColor = System.Drawing.Color.Transparent
        Me.LblCity.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCity.Location = New System.Drawing.Point(95, 195)
        Me.LblCity.Name = "LblCity"
        Me.LblCity.Size = New System.Drawing.Size(31, 16)
        Me.LblCity.TabIndex = 3062
        Me.LblCity.Text = "City"
        '
        'TxtOwnerAdd1
        '
        Me.TxtOwnerAdd1.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerAdd1.AgLastValueTag = Nothing
        Me.TxtOwnerAdd1.AgLastValueText = Nothing
        Me.TxtOwnerAdd1.AgMandatory = False
        Me.TxtOwnerAdd1.AgMasterHelp = False
        Me.TxtOwnerAdd1.AgNumberLeftPlaces = 8
        Me.TxtOwnerAdd1.AgNumberNegetiveAllow = False
        Me.TxtOwnerAdd1.AgNumberRightPlaces = 2
        Me.TxtOwnerAdd1.AgPickFromLastValue = False
        Me.TxtOwnerAdd1.AgRowFilter = ""
        Me.TxtOwnerAdd1.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerAdd1.AgSelectedValue = Nothing
        Me.TxtOwnerAdd1.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerAdd1.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerAdd1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerAdd1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerAdd1.Location = New System.Drawing.Point(240, 154)
        Me.TxtOwnerAdd1.MaxLength = 100
        Me.TxtOwnerAdd1.Name = "TxtOwnerAdd1"
        Me.TxtOwnerAdd1.Size = New System.Drawing.Size(469, 18)
        Me.TxtOwnerAdd1.TabIndex = 7
        '
        'LblAddress
        '
        Me.LblAddress.AutoSize = True
        Me.LblAddress.BackColor = System.Drawing.Color.Transparent
        Me.LblAddress.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblAddress.Location = New System.Drawing.Point(95, 155)
        Me.LblAddress.Name = "LblAddress"
        Me.LblAddress.Size = New System.Drawing.Size(56, 16)
        Me.LblAddress.TabIndex = 3061
        Me.LblAddress.Text = "Address"
        '
        'TxtChassisNo
        '
        Me.TxtChassisNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtChassisNo.AgLastValueTag = Nothing
        Me.TxtChassisNo.AgLastValueText = Nothing
        Me.TxtChassisNo.AgMandatory = False
        Me.TxtChassisNo.AgMasterHelp = False
        Me.TxtChassisNo.AgNumberLeftPlaces = 8
        Me.TxtChassisNo.AgNumberNegetiveAllow = False
        Me.TxtChassisNo.AgNumberRightPlaces = 2
        Me.TxtChassisNo.AgPickFromLastValue = False
        Me.TxtChassisNo.AgRowFilter = ""
        Me.TxtChassisNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtChassisNo.AgSelectedValue = Nothing
        Me.TxtChassisNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtChassisNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtChassisNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtChassisNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtChassisNo.Location = New System.Drawing.Point(525, 74)
        Me.TxtChassisNo.MaxLength = 50
        Me.TxtChassisNo.Name = "TxtChassisNo"
        Me.TxtChassisNo.Size = New System.Drawing.Size(184, 18)
        Me.TxtChassisNo.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(432, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 16)
        Me.Label9.TabIndex = 3060
        Me.Label9.Text = "Chassis No"
        '
        'TxtVehicleSpecification
        '
        Me.TxtVehicleSpecification.AgAllowUserToEnableMasterHelp = False
        Me.TxtVehicleSpecification.AgLastValueTag = Nothing
        Me.TxtVehicleSpecification.AgLastValueText = Nothing
        Me.TxtVehicleSpecification.AgMandatory = False
        Me.TxtVehicleSpecification.AgMasterHelp = False
        Me.TxtVehicleSpecification.AgNumberLeftPlaces = 8
        Me.TxtVehicleSpecification.AgNumberNegetiveAllow = False
        Me.TxtVehicleSpecification.AgNumberRightPlaces = 2
        Me.TxtVehicleSpecification.AgPickFromLastValue = False
        Me.TxtVehicleSpecification.AgRowFilter = ""
        Me.TxtVehicleSpecification.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtVehicleSpecification.AgSelectedValue = Nothing
        Me.TxtVehicleSpecification.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtVehicleSpecification.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtVehicleSpecification.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtVehicleSpecification.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtVehicleSpecification.Location = New System.Drawing.Point(240, 114)
        Me.TxtVehicleSpecification.MaxLength = 100
        Me.TxtVehicleSpecification.Name = "TxtVehicleSpecification"
        Me.TxtVehicleSpecification.Size = New System.Drawing.Size(187, 18)
        Me.TxtVehicleSpecification.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.Transparent
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(95, 115)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(129, 16)
        Me.Label7.TabIndex = 3059
        Me.Label7.Text = "Vehicle Specification"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(222, 101)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 7)
        Me.Label5.TabIndex = 3058
        Me.Label5.Text = "Ä"
        '
        'TxtInsuranceCompany
        '
        Me.TxtInsuranceCompany.AgAllowUserToEnableMasterHelp = False
        Me.TxtInsuranceCompany.AgLastValueTag = Nothing
        Me.TxtInsuranceCompany.AgLastValueText = Nothing
        Me.TxtInsuranceCompany.AgMandatory = False
        Me.TxtInsuranceCompany.AgMasterHelp = False
        Me.TxtInsuranceCompany.AgNumberLeftPlaces = 8
        Me.TxtInsuranceCompany.AgNumberNegetiveAllow = False
        Me.TxtInsuranceCompany.AgNumberRightPlaces = 2
        Me.TxtInsuranceCompany.AgPickFromLastValue = False
        Me.TxtInsuranceCompany.AgRowFilter = ""
        Me.TxtInsuranceCompany.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtInsuranceCompany.AgSelectedValue = Nothing
        Me.TxtInsuranceCompany.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtInsuranceCompany.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtInsuranceCompany.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtInsuranceCompany.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtInsuranceCompany.Location = New System.Drawing.Point(240, 214)
        Me.TxtInsuranceCompany.MaxLength = 0
        Me.TxtInsuranceCompany.Name = "TxtInsuranceCompany"
        Me.TxtInsuranceCompany.Size = New System.Drawing.Size(469, 18)
        Me.TxtInsuranceCompany.TabIndex = 11
        '
        'TxtPolicyNo
        '
        Me.TxtPolicyNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyNo.AgLastValueTag = Nothing
        Me.TxtPolicyNo.AgLastValueText = Nothing
        Me.TxtPolicyNo.AgMandatory = False
        Me.TxtPolicyNo.AgMasterHelp = False
        Me.TxtPolicyNo.AgNumberLeftPlaces = 8
        Me.TxtPolicyNo.AgNumberNegetiveAllow = False
        Me.TxtPolicyNo.AgNumberRightPlaces = 2
        Me.TxtPolicyNo.AgPickFromLastValue = False
        Me.TxtPolicyNo.AgRowFilter = ""
        Me.TxtPolicyNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyNo.AgSelectedValue = Nothing
        Me.TxtPolicyNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtPolicyNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyNo.Location = New System.Drawing.Point(240, 234)
        Me.TxtPolicyNo.MaxLength = 20
        Me.TxtPolicyNo.Name = "TxtPolicyNo"
        Me.TxtPolicyNo.Size = New System.Drawing.Size(176, 18)
        Me.TxtPolicyNo.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.Transparent
        Me.Label16.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(95, 235)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 16)
        Me.Label16.TabIndex = 3065
        Me.Label16.Text = "Policy No"
        '
        'LblOwnerMobile
        '
        Me.LblOwnerMobile.AutoSize = True
        Me.LblOwnerMobile.BackColor = System.Drawing.Color.Transparent
        Me.LblOwnerMobile.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerMobile.Location = New System.Drawing.Point(416, 195)
        Me.LblOwnerMobile.Name = "LblOwnerMobile"
        Me.LblOwnerMobile.Size = New System.Drawing.Size(46, 16)
        Me.LblOwnerMobile.TabIndex = 3063
        Me.LblOwnerMobile.Text = "Mobile"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.BackColor = System.Drawing.Color.Transparent
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(95, 215)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(84, 16)
        Me.Label15.TabIndex = 3064
        Me.Label15.Text = "Insurance Co"
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
        Me.TxtModel.Location = New System.Drawing.Point(240, 94)
        Me.TxtModel.MaxLength = 0
        Me.TxtModel.Name = "TxtModel"
        Me.TxtModel.Size = New System.Drawing.Size(187, 18)
        Me.TxtModel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(95, 94)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 16)
        Me.Label6.TabIndex = 3057
        Me.Label6.Text = "Model"
        '
        'TxtOwnerCity
        '
        Me.TxtOwnerCity.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerCity.AgLastValueTag = Nothing
        Me.TxtOwnerCity.AgLastValueText = Nothing
        Me.TxtOwnerCity.AgMandatory = False
        Me.TxtOwnerCity.AgMasterHelp = False
        Me.TxtOwnerCity.AgNumberLeftPlaces = 8
        Me.TxtOwnerCity.AgNumberNegetiveAllow = False
        Me.TxtOwnerCity.AgNumberRightPlaces = 2
        Me.TxtOwnerCity.AgPickFromLastValue = False
        Me.TxtOwnerCity.AgRowFilter = ""
        Me.TxtOwnerCity.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerCity.AgSelectedValue = Nothing
        Me.TxtOwnerCity.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerCity.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerCity.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerCity.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerCity.Location = New System.Drawing.Point(240, 194)
        Me.TxtOwnerCity.MaxLength = 0
        Me.TxtOwnerCity.Name = "TxtOwnerCity"
        Me.TxtOwnerCity.Size = New System.Drawing.Size(176, 18)
        Me.TxtOwnerCity.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(222, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 7)
        Me.Label4.TabIndex = 3054
        Me.Label4.Text = "Ä"
        '
        'LblRegistrationNo
        '
        Me.LblRegistrationNo.AutoSize = True
        Me.LblRegistrationNo.BackColor = System.Drawing.Color.Transparent
        Me.LblRegistrationNo.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblRegistrationNo.Location = New System.Drawing.Point(95, 74)
        Me.LblRegistrationNo.Name = "LblRegistrationNo"
        Me.LblRegistrationNo.Size = New System.Drawing.Size(97, 16)
        Me.LblRegistrationNo.TabIndex = 3053
        Me.LblRegistrationNo.Text = "Registration No"
        '
        'TxtEngineNo
        '
        Me.TxtEngineNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtEngineNo.AgLastValueTag = Nothing
        Me.TxtEngineNo.AgLastValueText = Nothing
        Me.TxtEngineNo.AgMandatory = False
        Me.TxtEngineNo.AgMasterHelp = False
        Me.TxtEngineNo.AgNumberLeftPlaces = 8
        Me.TxtEngineNo.AgNumberNegetiveAllow = False
        Me.TxtEngineNo.AgNumberRightPlaces = 2
        Me.TxtEngineNo.AgPickFromLastValue = False
        Me.TxtEngineNo.AgRowFilter = ""
        Me.TxtEngineNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtEngineNo.AgSelectedValue = Nothing
        Me.TxtEngineNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtEngineNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtEngineNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtEngineNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtEngineNo.Location = New System.Drawing.Point(525, 94)
        Me.TxtEngineNo.MaxLength = 50
        Me.TxtEngineNo.Name = "TxtEngineNo"
        Me.TxtEngineNo.Size = New System.Drawing.Size(184, 18)
        Me.TxtEngineNo.TabIndex = 3
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(547, 235)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(76, 16)
        Me.Label18.TabIndex = 3067
        Me.Label18.Text = "Expiry Date"
        '
        'TxtPolicyExpiryDate
        '
        Me.TxtPolicyExpiryDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyExpiryDate.AgLastValueTag = Nothing
        Me.TxtPolicyExpiryDate.AgLastValueText = Nothing
        Me.TxtPolicyExpiryDate.AgMandatory = False
        Me.TxtPolicyExpiryDate.AgMasterHelp = False
        Me.TxtPolicyExpiryDate.AgNumberLeftPlaces = 8
        Me.TxtPolicyExpiryDate.AgNumberNegetiveAllow = False
        Me.TxtPolicyExpiryDate.AgNumberRightPlaces = 2
        Me.TxtPolicyExpiryDate.AgPickFromLastValue = False
        Me.TxtPolicyExpiryDate.AgRowFilter = ""
        Me.TxtPolicyExpiryDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyExpiryDate.AgSelectedValue = Nothing
        Me.TxtPolicyExpiryDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyExpiryDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPolicyExpiryDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyExpiryDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyExpiryDate.Location = New System.Drawing.Point(625, 234)
        Me.TxtPolicyExpiryDate.MaxLength = 0
        Me.TxtPolicyExpiryDate.Name = "TxtPolicyExpiryDate"
        Me.TxtPolicyExpiryDate.Size = New System.Drawing.Size(84, 18)
        Me.TxtPolicyExpiryDate.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.Transparent
        Me.Label17.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(417, 234)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(35, 16)
        Me.Label17.TabIndex = 3066
        Me.Label17.Text = "Date"
        '
        'TxtPolicyDate
        '
        Me.TxtPolicyDate.AgAllowUserToEnableMasterHelp = False
        Me.TxtPolicyDate.AgLastValueTag = Nothing
        Me.TxtPolicyDate.AgLastValueText = Nothing
        Me.TxtPolicyDate.AgMandatory = False
        Me.TxtPolicyDate.AgMasterHelp = False
        Me.TxtPolicyDate.AgNumberLeftPlaces = 8
        Me.TxtPolicyDate.AgNumberNegetiveAllow = False
        Me.TxtPolicyDate.AgNumberRightPlaces = 2
        Me.TxtPolicyDate.AgPickFromLastValue = False
        Me.TxtPolicyDate.AgRowFilter = ""
        Me.TxtPolicyDate.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtPolicyDate.AgSelectedValue = Nothing
        Me.TxtPolicyDate.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtPolicyDate.AgValueType = AgControls.AgTextBox.TxtValueType.Date_Value
        Me.TxtPolicyDate.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtPolicyDate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPolicyDate.Location = New System.Drawing.Point(461, 234)
        Me.TxtPolicyDate.MaxLength = 0
        Me.TxtPolicyDate.Name = "TxtPolicyDate"
        Me.TxtPolicyDate.Size = New System.Drawing.Size(83, 18)
        Me.TxtPolicyDate.TabIndex = 13
        '
        'LblCurrency
        '
        Me.LblCurrency.AutoSize = True
        Me.LblCurrency.BackColor = System.Drawing.Color.Transparent
        Me.LblCurrency.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblCurrency.Location = New System.Drawing.Point(432, 94)
        Me.LblCurrency.Name = "LblCurrency"
        Me.LblCurrency.Size = New System.Drawing.Size(68, 16)
        Me.LblCurrency.TabIndex = 3056
        Me.LblCurrency.Text = "Engine No"
        '
        'LblOwnerName
        '
        Me.LblOwnerName.AutoSize = True
        Me.LblOwnerName.BackColor = System.Drawing.Color.Transparent
        Me.LblOwnerName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblOwnerName.Location = New System.Drawing.Point(95, 135)
        Me.LblOwnerName.Name = "LblOwnerName"
        Me.LblOwnerName.Size = New System.Drawing.Size(83, 16)
        Me.LblOwnerName.TabIndex = 3055
        Me.LblOwnerName.Text = "Owner Name"
        '
        'TxtOwnerName
        '
        Me.TxtOwnerName.AgAllowUserToEnableMasterHelp = False
        Me.TxtOwnerName.AgLastValueTag = Nothing
        Me.TxtOwnerName.AgLastValueText = Nothing
        Me.TxtOwnerName.AgMandatory = True
        Me.TxtOwnerName.AgMasterHelp = False
        Me.TxtOwnerName.AgNumberLeftPlaces = 8
        Me.TxtOwnerName.AgNumberNegetiveAllow = False
        Me.TxtOwnerName.AgNumberRightPlaces = 2
        Me.TxtOwnerName.AgPickFromLastValue = False
        Me.TxtOwnerName.AgRowFilter = ""
        Me.TxtOwnerName.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtOwnerName.AgSelectedValue = Nothing
        Me.TxtOwnerName.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtOwnerName.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtOwnerName.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtOwnerName.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtOwnerName.Location = New System.Drawing.Point(240, 134)
        Me.TxtOwnerName.MaxLength = 100
        Me.TxtOwnerName.Name = "TxtOwnerName"
        Me.TxtOwnerName.Size = New System.Drawing.Size(469, 18)
        Me.TxtOwnerName.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Wingdings 2", 5.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(222, 141)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(10, 7)
        Me.Label1.TabIndex = 3069
        Me.Label1.Text = "Ä"
        '
        'TxtRegistrationNo
        '
        Me.TxtRegistrationNo.AgAllowUserToEnableMasterHelp = False
        Me.TxtRegistrationNo.AgLastValueTag = Nothing
        Me.TxtRegistrationNo.AgLastValueText = Nothing
        Me.TxtRegistrationNo.AgMandatory = False
        Me.TxtRegistrationNo.AgMasterHelp = True
        Me.TxtRegistrationNo.AgNumberLeftPlaces = 8
        Me.TxtRegistrationNo.AgNumberNegetiveAllow = False
        Me.TxtRegistrationNo.AgNumberRightPlaces = 2
        Me.TxtRegistrationNo.AgPickFromLastValue = False
        Me.TxtRegistrationNo.AgRowFilter = ""
        Me.TxtRegistrationNo.AgSearchMethod = AgControls.AgLib.TxtSearchMethod.Simple
        Me.TxtRegistrationNo.AgSelectedValue = Nothing
        Me.TxtRegistrationNo.AgTxtCase = AgControls.AgTextBox.TxtCase.None
        Me.TxtRegistrationNo.AgValueType = AgControls.AgTextBox.TxtValueType.Text_Value
        Me.TxtRegistrationNo.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.TxtRegistrationNo.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtRegistrationNo.Location = New System.Drawing.Point(240, 74)
        Me.TxtRegistrationNo.MaxLength = 20
        Me.TxtRegistrationNo.Name = "TxtRegistrationNo"
        Me.TxtRegistrationNo.Size = New System.Drawing.Size(187, 18)
        Me.TxtRegistrationNo.TabIndex = 3070
        '
        'FrmVehicle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 365)
        Me.Controls.Add(Me.TxtRegistrationNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.TxtCustomerId)
        Me.Controls.Add(Me.TxtOwnerMobile)
        Me.Controls.Add(Me.TxtOwnerAdd2)
        Me.Controls.Add(Me.LblCity)
        Me.Controls.Add(Me.TxtOwnerAdd1)
        Me.Controls.Add(Me.LblAddress)
        Me.Controls.Add(Me.TxtChassisNo)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.TxtVehicleSpecification)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtInsuranceCompany)
        Me.Controls.Add(Me.TxtPolicyNo)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.LblOwnerMobile)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.TxtModel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtOwnerCity)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.LblRegistrationNo)
        Me.Controls.Add(Me.TxtEngineNo)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.TxtPolicyExpiryDate)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.TxtPolicyDate)
        Me.Controls.Add(Me.LblCurrency)
        Me.Controls.Add(Me.LblOwnerName)
        Me.Controls.Add(Me.TxtOwnerName)
        Me.Name = "FrmVehicle"
        Me.Text = "Quality Master"
        Me.Controls.SetChildIndex(Me.GBoxDivision, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Topctrl1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GrpUP, 0)
        Me.Controls.SetChildIndex(Me.GBoxEntryType, 0)
        Me.Controls.SetChildIndex(Me.GBoxApprove, 0)
        Me.Controls.SetChildIndex(Me.GBoxMoveToLog, 0)
        Me.Controls.SetChildIndex(Me.TxtOwnerName, 0)
        Me.Controls.SetChildIndex(Me.LblOwnerName, 0)
        Me.Controls.SetChildIndex(Me.LblCurrency, 0)
        Me.Controls.SetChildIndex(Me.TxtPolicyDate, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.TxtPolicyExpiryDate, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.TxtEngineNo, 0)
        Me.Controls.SetChildIndex(Me.LblRegistrationNo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtOwnerCity, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtModel, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.LblOwnerMobile, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.TxtPolicyNo, 0)
        Me.Controls.SetChildIndex(Me.TxtInsuranceCompany, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.TxtVehicleSpecification, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.TxtChassisNo, 0)
        Me.Controls.SetChildIndex(Me.LblAddress, 0)
        Me.Controls.SetChildIndex(Me.TxtOwnerAdd1, 0)
        Me.Controls.SetChildIndex(Me.LblCity, 0)
        Me.Controls.SetChildIndex(Me.TxtOwnerAdd2, 0)
        Me.Controls.SetChildIndex(Me.TxtOwnerMobile, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomerId, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtRegistrationNo, 0)
        Me.GrpUP.ResumeLayout(False)
        Me.GrpUP.PerformLayout()
        Me.GBoxEntryType.ResumeLayout(False)
        Me.GBoxEntryType.PerformLayout()
        Me.GBoxMoveToLog.ResumeLayout(False)
        Me.GBoxMoveToLog.PerformLayout()
        Me.GBoxApprove.ResumeLayout(False)
        Me.GBoxApprove.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GBoxDivision.ResumeLayout(False)
        Me.GBoxDivision.PerformLayout()
        CType(Me.DTMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Protected WithEvents TxtOwnerName As AgControls.AgTextBox
    Protected WithEvents LblOwnerName As System.Windows.Forms.Label
    Protected WithEvents LblCurrency As System.Windows.Forms.Label
    Protected WithEvents TxtPolicyDate As AgControls.AgTextBox
    Protected WithEvents Label17 As System.Windows.Forms.Label
    Protected WithEvents TxtPolicyExpiryDate As AgControls.AgTextBox
    Protected WithEvents Label18 As System.Windows.Forms.Label
    Protected WithEvents TxtEngineNo As AgControls.AgTextBox
    Protected WithEvents LblRegistrationNo As System.Windows.Forms.Label
    Protected WithEvents Label4 As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerCity As AgControls.AgTextBox
    Protected WithEvents Label6 As System.Windows.Forms.Label
    Protected WithEvents TxtModel As AgControls.AgTextBox
    Protected WithEvents Label15 As System.Windows.Forms.Label
    Protected WithEvents LblOwnerMobile As System.Windows.Forms.Label
    Protected WithEvents Label16 As System.Windows.Forms.Label
    Protected WithEvents TxtPolicyNo As AgControls.AgTextBox
    Protected WithEvents TxtInsuranceCompany As AgControls.AgTextBox
    Protected WithEvents Label5 As System.Windows.Forms.Label
    Protected WithEvents Label7 As System.Windows.Forms.Label
    Protected WithEvents TxtVehicleSpecification As AgControls.AgTextBox
    Protected WithEvents Label9 As System.Windows.Forms.Label
    Protected WithEvents TxtChassisNo As AgControls.AgTextBox
    Protected WithEvents LblAddress As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerAdd1 As AgControls.AgTextBox
    Protected WithEvents LblCity As System.Windows.Forms.Label
    Protected WithEvents TxtOwnerAdd2 As AgControls.AgTextBox
    Protected WithEvents TxtOwnerMobile As AgControls.AgTextBox
    Protected WithEvents TxtCustomerId As AgControls.AgTextBox
    Protected WithEvents Label1 As System.Windows.Forms.Label
    Protected WithEvents TxtRegistrationNo As AgControls.AgTextBox
    Protected WithEvents Label19 As System.Windows.Forms.Label
#End Region

    Private Sub FrmYarn_BaseEvent_Data_Validation(ByRef passed As Boolean) Handles Me.BaseEvent_Data_Validation
        If TxtRegistrationNo.Text.Trim = "" Then Err.Raise(1, , "Registration No Is Required!")
        If TxtModel.Text.Trim = "" Then Err.Raise(1, , "Model Is Required!")
        If AgL.RequiredField(TxtOwnerName, LblOwnerName.Text) Then passed = False : Exit Sub

        If TxtPolicyDate.Text <> "" And TxtPolicyExpiryDate.Text <> "" Then
            If CDate(TxtPolicyDate.Text) >= CDate(TxtPolicyExpiryDate.Text) Then
                MsgBox("Policy Date Can't Be Greater Then Policy Expiry Date...!", MsgBoxStyle.Information)
                TxtPolicyExpiryDate.Focus() : passed = False : Exit Sub
            End If
        End If

        passed = FCheckDuplicateDescription()

        passed = ClsMain.FValidateMobile(TxtOwnerMobile.Text, LblOwnerMobile.Text)
    End Sub

    Private Function FCheckDuplicateDescription() As Boolean
        FCheckDuplicateDescription = True

        If Topctrl1.Mode = "Add" Then
            mQry = "Select count(*) From Item_UID WHERE Replace(Replace(Replace(Item_UID, ' ', ''), '-', ''), '.', '') = '" & Replace(Replace(Replace(TxtRegistrationNo.Text, " ", ""), "-", ""), ".", "") & "' "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateDescription = False : MsgBox("Registration No Already Exist!", MsgBoxStyle.Information)
        Else
            mQry = "Select count(*) From Item_UID WHERE Replace(Replace(Replace(Item_UID, ' ', ''), '-', ''), '.', '') = '" & Replace(Replace(Replace(TxtRegistrationNo.Text, " ", ""), "-", ""), ".", "") & "' And Code<>'" & mInternalCode & "' "
            If AgL.Dman_Execute(mQry, AgL.GCn).ExecuteScalar > 0 Then FCheckDuplicateDescription = False : MsgBox("Registration No Already Exist!", MsgBoxStyle.Information)
        End If
    End Function

    Public Overridable Sub FrmYarn_BaseEvent_FindMain() Handles Me.BaseEvent_FindMain
        Dim mConStr$ = ""
        AgL.PubFindQry = "SELECT Iu.Code, Iu.Item_UID as Registration_No, I.Description As Model, " & _
                        " Iu.ChassisNo As Chassis_No, Iu.EngineNo As Engine_No, Iu.OwnerName As Owner_Name, Iu.OwnerAdd1 As Owner_Add1, Iu.OwnerAdd2 As Owner_Add2, C.CityName As Owner_City, " & _
                        " Iu.OwnerMobile As Owner_Mobile, Iu.InsuranceCompany As Insurance_Company, Iu.PolicyNo As Policy_No, Iu.PolicyDate As Policy_Date, Iu.PolicyExpiryDate As Policy_Expiry_Date, " & _
                        " Iu.VehicleSpecification As Vehicle_Specification, Iu.EntryBy As Entry_By, Iu.EntryDate As Entry_Date, Iu.EntryType As Entry_Type " & _
                        " FROM Item_UID Iu  " & _
                        " LEFT JOIN Item I On Iu.Item = I.Code " & _
                        " LEFT JOIN City C On Iu.OwnerCity = C.CityCode "
        AgL.PubFindQryOrdBy = "[Registration_No]"
    End Sub

    Private Sub FrmYarn_BaseEvent_Form_PreLoad() Handles Me.BaseEvent_Form_PreLoad
        MainTableName = "Item_UID"
        LogTableName = "Item_UID_Log"
    End Sub

    Private Sub FrmYarn_BaseEvent_Save_InTrans(ByVal SearchCode As String, ByVal Conn As System.Data.SqlClient.SqlConnection, ByVal Cmd As System.Data.SqlClient.SqlCommand) Handles Me.BaseEvent_Save_InTrans
        mQry = " Update Item_Uid " & _
                    " SET  " & _
                    " Item_Uid = " & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                    " RegistrationNo = " & AgL.Chk_Text(TxtRegistrationNo.Text) & ", " & _
                    " Item = " & AgL.Chk_Text(TxtModel.Tag) & ", " & _
                    " EngineNo = " & AgL.Chk_Text(TxtEngineNo.Text) & ", " & _
                    " ChassisNo = " & AgL.Chk_Text(TxtChassisNo.Text) & ", " & _
                    " VehicleSpecification = " & AgL.Chk_Text(TxtVehicleSpecification.Text) & ", " & _
                    " CustomerId = " & AgL.Chk_Text(TxtCustomerId.Text) & ", " & _
                    " OwnerName = " & AgL.Chk_Text(TxtOwnerName.Text) & ", " & _
                    " OwnerAdd1 = " & AgL.Chk_Text(TxtOwnerAdd1.Text) & ", " & _
                    " OwnerAdd2 = " & AgL.Chk_Text(TxtOwnerAdd2.Text) & ", " & _
                    " OwnerCity = " & AgL.Chk_Text(TxtOwnerCity.Tag) & ", " & _
                    " OwnerMobile = " & AgL.Chk_Text(TxtOwnerMobile.Text) & ", " & _
                    " InsuranceCompany = " & AgL.Chk_Text(TxtInsuranceCompany.Tag) & ", " & _
                    " PolicyNo = " & AgL.Chk_Text(TxtPolicyNo.Text) & ", " & _
                    " PolicyDate = " & AgL.Chk_Text(TxtPolicyDate.Text) & ", " & _
                    " PolicyExpiryDate = " & AgL.Chk_Text(TxtPolicyExpiryDate.Text) & " " & _
                    " Where Code = '" & SearchCode & "' "
        AgL.Dman_ExecuteNonQry(mQry, AgL.GCn, AgL.ECmd)
    End Sub

    Private Sub FrmQuality1_BaseFunction_FIniList() Handles Me.BaseFunction_FIniList
        mQry = "Select Code, Item_UID As Name " & _
                " From Item_UID " & _
                " Order By Item_UID "
        TxtRegistrationNo.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT H.Code, H.Description " & _
                " FROM Item H " & _
                " WHERE IsNull(H.Status,'" & AgTemplate.ClsMain.EntryStatus.Active & "') = '" & AgTemplate.ClsMain.EntryStatus.Active & "' " & _
                " And H.ItemType = '" & ClsMain.ItemType.Model & "'"
        TxtModel.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT Sg.SubCode, Sg.DispName As Name FROM SubGroup Sg Where Sg.MasterType = '" & ClsMain.MasterType.Insurance & "'"
        TxtInsuranceCompany.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)

        mQry = " SELECT C.CityCode AS Code, C.CityName FROM City C "
        TxtOwnerCity.AgHelpDataSet = AgL.FillData(mQry, AgL.GCn)
    End Sub

    Private Sub FrmQuality1_BaseFunction_MoveRec(ByVal SearchCode As String) Handles Me.BaseFunction_MoveRec
        Dim DsTemp As DataSet

        mQry = "Select H.* " & _
                " From Item_UID H " & _
                " Where H.Code='" & SearchCode & "'"
        DsTemp = AgL.FillData(mQry, AgL.GCn)

        With DsTemp.Tables(0)
            If .Rows.Count > 0 Then
                mInternalCode = AgL.XNull(.Rows(0)("Code"))

                TxtRegistrationNo.Text = AgL.XNull(.Rows(0)("Item_Uid"))
                TxtChassisNo.Text = AgL.XNull(.Rows(0)("ChassisNo"))
                TxtEngineNo.Text = AgL.XNull(.Rows(0)("EngineNo"))
                TxtModel.AgSelectedValue = AgL.XNull(.Rows(0)("Item"))
                TxtVehicleSpecification.Text = AgL.XNull(.Rows(0)("VehicleSpecification"))
                TxtCustomerId.Text = AgL.XNull(.Rows(0)("CustomerId"))
                TxtOwnerName.Text = AgL.XNull(.Rows(0)("OwnerName"))
                TxtOwnerAdd1.Text = AgL.XNull(.Rows(0)("OwnerAdd1"))
                TxtOwnerAdd2.Text = AgL.XNull(.Rows(0)("OwnerAdd2"))
                TxtOwnerCity.AgSelectedValue = AgL.XNull(.Rows(0)("OwnerCity"))
                TxtOwnerMobile.Text = AgL.XNull(.Rows(0)("OwnerMobile"))
                TxtInsuranceCompany.AgSelectedValue = AgL.XNull(.Rows(0)("InsuranceCompany"))
                TxtPolicyNo.Text = AgL.XNull(.Rows(0)("PolicyNo"))
                TxtPolicyDate.Text = AgL.XNull(.Rows(0)("PolicyDate"))
                TxtPolicyExpiryDate.Text = AgL.XNull(.Rows(0)("PolicyExpiryDate"))
            End If
        End With
    End Sub

    Private Sub Topctrl1_tbAdd() Handles Topctrl1.tbAdd
        TxtRegistrationNo.Focus()
    End Sub

    Private Sub Topctrl1_tbEdit() Handles Topctrl1.tbEdit
        TxtRegistrationNo.Focus()
    End Sub

    Private Sub Topctrl1_tbPrn() Handles Topctrl1.tbPrn
    End Sub

    Private Sub Control_Enter(ByVal sender As Object, ByVal e As System.EventArgs)
        Try
            Select Case sender.name
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Public Sub New(ByVal StrUPVar As String, ByVal DTUP As DataTable)
        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Topctrl1.FSetParent(Me, StrUPVar, DTUP)
        Topctrl1.SetDisp(True)
    End Sub

    Private Sub FrmYarn_BaseFunction_FIniMast(ByVal BytDel As Byte, ByVal BytRefresh As Byte) Handles Me.BaseFunction_FIniMast
        Dim mConStr$ = ""
        mQry = "Select I.Code As SearchCode " & _
                " From Item_UID I " & mConStr & _
                " Order By I.Item_Uid "
        Topctrl1.FIniForm(DTMaster, AgL.GCn, mQry, , , , , BytDel, BytRefresh)
    End Sub

    Private Sub Form_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        AgL.FPaintForm(Me, e, Topctrl1.Height)
    End Sub

    Private Sub FrmItem_UID_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        AgL.WinSetting(Me, 403, 878)
    End Sub

    Private Sub Control_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles TxtPolicyDate.Validating, TxtPolicyExpiryDate.Validating, TxtRegistrationNo.Validating, TxtOwnerMobile.Validating
        Dim DtTemp As DataTable = Nothing
        Dim DrTemp As DataRow() = Nothing
        Try
            Select Case sender.NAME
                Case TxtRegistrationNo.Name
                    e.Cancel = Not FCheckDuplicateDescription()

                Case TxtOwnerMobile.Name
                    e.Cancel = Not ClsMain.FValidateMobile(TxtOwnerMobile.Text, LblOwnerMobile.Text)

                Case TxtPolicyDate.Name
                    If TxtPolicyDate.Text <> "" And TxtPolicyExpiryDate.Text = "" Then
                        TxtPolicyExpiryDate.Text = DateAdd(DateInterval.Day, -1, CDate(DateAdd(DateInterval.Year, 1, CDate(TxtPolicyDate.Text))))
                    End If

                Case TxtPolicyExpiryDate.Name
                    If MsgBox("Do you want to save?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton1, "Save") = MsgBoxResult.Yes Then
                        Topctrl1.FButtonClick(13)
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Function FGetRelationalData() As Boolean
        Try
            mQry = " Select Count(*) From Service_JobCard Where Item_Uid = '" & mSearchCode & "' "
            If AgL.VNull(AgL.Dman_Execute(mQry, AgL.GcnRead).ExecuteScalar) > 0 Then
                MsgBox("Job card exists for this vehicle.Can't delete...!", MsgBoxStyle.Information)
                FGetRelationalData = True
                Exit Function
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " In FGetRelationalData In Vehicle Master")
            FGetRelationalData = True
        End Try
    End Function

    Private Sub ME_BaseEvent_Topctrl_tbDel(ByRef Passed As Boolean) Handles Me.BaseEvent_Topctrl_tbDel
        Passed = Not FGetRelationalData()
    End Sub

    
End Class
