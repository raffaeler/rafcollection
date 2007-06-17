namespace NorthwindTest
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.Label shipCityLabel;
			System.Windows.Forms.Label shipAddressLabel;
			System.Windows.Forms.Label shipNameLabel;
			System.Windows.Forms.Label shippedDateLabel;
			System.Windows.Forms.Label customerIDLabel;
			System.Windows.Forms.Label orderIDLabel;
			System.Windows.Forms.Label freightLabel;
			System.Windows.Forms.Label orderDateLabel;
			System.Windows.Forms.Label requiredDateLabel;
			System.Windows.Forms.Label shipRegionLabel;
			System.Windows.Forms.Label employeeIDLabel;
			System.Windows.Forms.Label shipPostalCodeLabel;
			System.Windows.Forms.Label shipCountryLabel;
			System.Windows.Forms.Label shipViaLabel;
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.shipCityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shippedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.freightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customerIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.requiredDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipRegionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.employeeIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipPostalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipCountryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.shipViaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.orderCollectionBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.pnlDetails = new System.Windows.Forms.Panel();
			this.dataGridView2 = new System.Windows.Forms.DataGridView();
			this.faxDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.cityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.postalCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customerIDDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contactTitleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.contactNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.regionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.shipViaTextBox = new System.Windows.Forms.TextBox();
			this.shipCountryTextBox = new System.Windows.Forms.TextBox();
			this.shipPostalCodeTextBox = new System.Windows.Forms.TextBox();
			this.employeeIDTextBox = new System.Windows.Forms.TextBox();
			this.shipRegionTextBox = new System.Windows.Forms.TextBox();
			this.requiredDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.orderDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.freightTextBox = new System.Windows.Forms.TextBox();
			this.orderIDTextBox = new System.Windows.Forms.TextBox();
			this.customerIDTextBox = new System.Windows.Forms.TextBox();
			this.shippedDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
			this.shipNameTextBox = new System.Windows.Forms.TextBox();
			this.shipAddressTextBox = new System.Windows.Forms.TextBox();
			this.shipCityTextBox = new System.Windows.Forms.TextBox();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.tsbLoad = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.tsbAccept = new System.Windows.Forms.ToolStripButton();
			this.tsbReject = new System.Windows.Forms.ToolStripButton();
			this.tsbIsChanged = new System.Windows.Forms.ToolStripButton();
			this.lblIsChanged = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
			this.tscbColumnFilter = new System.Windows.Forms.ToolStripComboBox();
			this.tscbOperator = new System.Windows.Forms.ToolStripComboBox();
			this.tstFilter = new System.Windows.Forms.ToolStripTextBox();
			this.tsTests = new System.Windows.Forms.ToolStrip();
			this.tsbMemTestDataSet = new System.Windows.Forms.ToolStripButton();
			this.tsbMemTestCollection = new System.Windows.Forms.ToolStripButton();
			this.tsbSpeedTest = new System.Windows.Forms.ToolStripButton();
			this.lblDataSet = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.lblCustom = new System.Windows.Forms.ToolStripLabel();
			this.tsbAssertTests = new System.Windows.Forms.ToolStripButton();
			this.btSerializeTest = new System.Windows.Forms.ToolStripButton();
			shipCityLabel = new System.Windows.Forms.Label();
			shipAddressLabel = new System.Windows.Forms.Label();
			shipNameLabel = new System.Windows.Forms.Label();
			shippedDateLabel = new System.Windows.Forms.Label();
			customerIDLabel = new System.Windows.Forms.Label();
			orderIDLabel = new System.Windows.Forms.Label();
			freightLabel = new System.Windows.Forms.Label();
			orderDateLabel = new System.Windows.Forms.Label();
			requiredDateLabel = new System.Windows.Forms.Label();
			shipRegionLabel = new System.Windows.Forms.Label();
			employeeIDLabel = new System.Windows.Forms.Label();
			shipPostalCodeLabel = new System.Windows.Forms.Label();
			shipCountryLabel = new System.Windows.Forms.Label();
			shipViaLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.orderCollectionBindingSource)).BeginInit();
			this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
			this.toolStripContainer1.ContentPanel.SuspendLayout();
			this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
			this.toolStripContainer1.SuspendLayout();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.pnlDetails.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.tsTests.SuspendLayout();
			this.SuspendLayout();
			// 
			// shipCityLabel
			// 
			shipCityLabel.AutoSize = true;
			shipCityLabel.Location = new System.Drawing.Point(55, 6);
			shipCityLabel.Name = "shipCityLabel";
			shipCityLabel.Size = new System.Drawing.Size(51, 13);
			shipCityLabel.TabIndex = 0;
			shipCityLabel.Text = "Ship City:";
			// 
			// shipAddressLabel
			// 
			shipAddressLabel.AutoSize = true;
			shipAddressLabel.Location = new System.Drawing.Point(34, 32);
			shipAddressLabel.Name = "shipAddressLabel";
			shipAddressLabel.Size = new System.Drawing.Size(72, 13);
			shipAddressLabel.TabIndex = 2;
			shipAddressLabel.Text = "Ship Address:";
			// 
			// shipNameLabel
			// 
			shipNameLabel.AutoSize = true;
			shipNameLabel.Location = new System.Drawing.Point(44, 58);
			shipNameLabel.Name = "shipNameLabel";
			shipNameLabel.Size = new System.Drawing.Size(62, 13);
			shipNameLabel.TabIndex = 4;
			shipNameLabel.Text = "Ship Name:";
			// 
			// shippedDateLabel
			// 
			shippedDateLabel.AutoSize = true;
			shippedDateLabel.Location = new System.Drawing.Point(31, 86);
			shippedDateLabel.Name = "shippedDateLabel";
			shippedDateLabel.Size = new System.Drawing.Size(75, 13);
			shippedDateLabel.TabIndex = 8;
			shippedDateLabel.Text = "Shipped Date:";
			// 
			// customerIDLabel
			// 
			customerIDLabel.AutoSize = true;
			customerIDLabel.Location = new System.Drawing.Point(38, 111);
			customerIDLabel.Name = "customerIDLabel";
			customerIDLabel.Size = new System.Drawing.Size(68, 13);
			customerIDLabel.TabIndex = 12;
			customerIDLabel.Text = "Customer ID:";
			// 
			// orderIDLabel
			// 
			orderIDLabel.AutoSize = true;
			orderIDLabel.Location = new System.Drawing.Point(56, 137);
			orderIDLabel.Name = "orderIDLabel";
			orderIDLabel.Size = new System.Drawing.Size(50, 13);
			orderIDLabel.TabIndex = 14;
			orderIDLabel.Text = "Order ID:";
			// 
			// freightLabel
			// 
			freightLabel.AutoSize = true;
			freightLabel.Location = new System.Drawing.Point(64, 163);
			freightLabel.Name = "freightLabel";
			freightLabel.Size = new System.Drawing.Size(42, 13);
			freightLabel.TabIndex = 16;
			freightLabel.Text = "Freight:";
			// 
			// orderDateLabel
			// 
			orderDateLabel.AutoSize = true;
			orderDateLabel.Location = new System.Drawing.Point(370, 7);
			orderDateLabel.Name = "orderDateLabel";
			orderDateLabel.Size = new System.Drawing.Size(62, 13);
			orderDateLabel.TabIndex = 18;
			orderDateLabel.Text = "Order Date:";
			// 
			// requiredDateLabel
			// 
			requiredDateLabel.AutoSize = true;
			requiredDateLabel.Location = new System.Drawing.Point(353, 33);
			requiredDateLabel.Name = "requiredDateLabel";
			requiredDateLabel.Size = new System.Drawing.Size(79, 13);
			requiredDateLabel.TabIndex = 20;
			requiredDateLabel.Text = "Required Date:";
			// 
			// shipRegionLabel
			// 
			shipRegionLabel.AutoSize = true;
			shipRegionLabel.Location = new System.Drawing.Point(364, 58);
			shipRegionLabel.Name = "shipRegionLabel";
			shipRegionLabel.Size = new System.Drawing.Size(68, 13);
			shipRegionLabel.TabIndex = 22;
			shipRegionLabel.Text = "Ship Region:";
			// 
			// employeeIDLabel
			// 
			employeeIDLabel.AutoSize = true;
			employeeIDLabel.Location = new System.Drawing.Point(362, 84);
			employeeIDLabel.Name = "employeeIDLabel";
			employeeIDLabel.Size = new System.Drawing.Size(70, 13);
			employeeIDLabel.TabIndex = 24;
			employeeIDLabel.Text = "Employee ID:";
			// 
			// shipPostalCodeLabel
			// 
			shipPostalCodeLabel.AutoSize = true;
			shipPostalCodeLabel.Location = new System.Drawing.Point(341, 110);
			shipPostalCodeLabel.Name = "shipPostalCodeLabel";
			shipPostalCodeLabel.Size = new System.Drawing.Size(91, 13);
			shipPostalCodeLabel.TabIndex = 26;
			shipPostalCodeLabel.Text = "Ship Postal Code:";
			// 
			// shipCountryLabel
			// 
			shipCountryLabel.AutoSize = true;
			shipCountryLabel.Location = new System.Drawing.Point(362, 136);
			shipCountryLabel.Name = "shipCountryLabel";
			shipCountryLabel.Size = new System.Drawing.Size(70, 13);
			shipCountryLabel.TabIndex = 28;
			shipCountryLabel.Text = "Ship Country:";
			// 
			// shipViaLabel
			// 
			shipViaLabel.AutoSize = true;
			shipViaLabel.Location = new System.Drawing.Point(383, 162);
			shipViaLabel.Name = "shipViaLabel";
			shipViaLabel.Size = new System.Drawing.Size(49, 13);
			shipViaLabel.TabIndex = 30;
			shipViaLabel.Text = "Ship Via:";
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AutoGenerateColumns = false;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.shipCityDataGridViewTextBoxColumn,
            this.shipAddressDataGridViewTextBoxColumn,
            this.shipNameDataGridViewTextBoxColumn,
            this.shippedDateDataGridViewTextBoxColumn,
            this.freightDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn,
            this.orderIDDataGridViewTextBoxColumn,
            this.orderDateDataGridViewTextBoxColumn,
            this.requiredDateDataGridViewTextBoxColumn,
            this.shipRegionDataGridViewTextBoxColumn,
            this.employeeIDDataGridViewTextBoxColumn,
            this.shipPostalCodeDataGridViewTextBoxColumn,
            this.shipCountryDataGridViewTextBoxColumn,
            this.shipViaDataGridViewTextBoxColumn});
			this.dataGridView1.DataSource = this.orderCollectionBindingSource;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dataGridView1.Location = new System.Drawing.Point(0, 0);
			this.dataGridView1.Name = "dataGridView1";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
			this.dataGridView1.Size = new System.Drawing.Size(647, 254);
			this.dataGridView1.TabIndex = 0;
			// 
			// shipCityDataGridViewTextBoxColumn
			// 
			this.shipCityDataGridViewTextBoxColumn.DataPropertyName = "ShipCity";
			this.shipCityDataGridViewTextBoxColumn.HeaderText = "ShipCity";
			this.shipCityDataGridViewTextBoxColumn.Name = "shipCityDataGridViewTextBoxColumn";
			// 
			// shipAddressDataGridViewTextBoxColumn
			// 
			this.shipAddressDataGridViewTextBoxColumn.DataPropertyName = "ShipAddress";
			this.shipAddressDataGridViewTextBoxColumn.HeaderText = "ShipAddress";
			this.shipAddressDataGridViewTextBoxColumn.Name = "shipAddressDataGridViewTextBoxColumn";
			// 
			// shipNameDataGridViewTextBoxColumn
			// 
			this.shipNameDataGridViewTextBoxColumn.DataPropertyName = "ShipName";
			this.shipNameDataGridViewTextBoxColumn.HeaderText = "ShipName";
			this.shipNameDataGridViewTextBoxColumn.Name = "shipNameDataGridViewTextBoxColumn";
			// 
			// shippedDateDataGridViewTextBoxColumn
			// 
			this.shippedDateDataGridViewTextBoxColumn.DataPropertyName = "ShippedDate";
			this.shippedDateDataGridViewTextBoxColumn.HeaderText = "ShippedDate";
			this.shippedDateDataGridViewTextBoxColumn.Name = "shippedDateDataGridViewTextBoxColumn";
			// 
			// freightDataGridViewTextBoxColumn
			// 
			this.freightDataGridViewTextBoxColumn.DataPropertyName = "Freight";
			this.freightDataGridViewTextBoxColumn.HeaderText = "Freight";
			this.freightDataGridViewTextBoxColumn.Name = "freightDataGridViewTextBoxColumn";
			// 
			// customerIDDataGridViewTextBoxColumn
			// 
			this.customerIDDataGridViewTextBoxColumn.DataPropertyName = "CustomerID";
			this.customerIDDataGridViewTextBoxColumn.HeaderText = "CustomerID";
			this.customerIDDataGridViewTextBoxColumn.Name = "customerIDDataGridViewTextBoxColumn";
			// 
			// orderIDDataGridViewTextBoxColumn
			// 
			this.orderIDDataGridViewTextBoxColumn.DataPropertyName = "OrderID";
			this.orderIDDataGridViewTextBoxColumn.HeaderText = "OrderID";
			this.orderIDDataGridViewTextBoxColumn.Name = "orderIDDataGridViewTextBoxColumn";
			// 
			// orderDateDataGridViewTextBoxColumn
			// 
			this.orderDateDataGridViewTextBoxColumn.DataPropertyName = "OrderDate";
			this.orderDateDataGridViewTextBoxColumn.HeaderText = "OrderDate";
			this.orderDateDataGridViewTextBoxColumn.Name = "orderDateDataGridViewTextBoxColumn";
			// 
			// requiredDateDataGridViewTextBoxColumn
			// 
			this.requiredDateDataGridViewTextBoxColumn.DataPropertyName = "RequiredDate";
			this.requiredDateDataGridViewTextBoxColumn.HeaderText = "RequiredDate";
			this.requiredDateDataGridViewTextBoxColumn.Name = "requiredDateDataGridViewTextBoxColumn";
			// 
			// shipRegionDataGridViewTextBoxColumn
			// 
			this.shipRegionDataGridViewTextBoxColumn.DataPropertyName = "ShipRegion";
			this.shipRegionDataGridViewTextBoxColumn.HeaderText = "ShipRegion";
			this.shipRegionDataGridViewTextBoxColumn.Name = "shipRegionDataGridViewTextBoxColumn";
			// 
			// employeeIDDataGridViewTextBoxColumn
			// 
			this.employeeIDDataGridViewTextBoxColumn.DataPropertyName = "EmployeeID";
			this.employeeIDDataGridViewTextBoxColumn.HeaderText = "EmployeeID";
			this.employeeIDDataGridViewTextBoxColumn.Name = "employeeIDDataGridViewTextBoxColumn";
			// 
			// shipPostalCodeDataGridViewTextBoxColumn
			// 
			this.shipPostalCodeDataGridViewTextBoxColumn.DataPropertyName = "ShipPostalCode";
			this.shipPostalCodeDataGridViewTextBoxColumn.HeaderText = "ShipPostalCode";
			this.shipPostalCodeDataGridViewTextBoxColumn.Name = "shipPostalCodeDataGridViewTextBoxColumn";
			// 
			// shipCountryDataGridViewTextBoxColumn
			// 
			this.shipCountryDataGridViewTextBoxColumn.DataPropertyName = "ShipCountry";
			this.shipCountryDataGridViewTextBoxColumn.HeaderText = "ShipCountry";
			this.shipCountryDataGridViewTextBoxColumn.Name = "shipCountryDataGridViewTextBoxColumn";
			// 
			// shipViaDataGridViewTextBoxColumn
			// 
			this.shipViaDataGridViewTextBoxColumn.DataPropertyName = "ShipVia";
			this.shipViaDataGridViewTextBoxColumn.HeaderText = "ShipVia";
			this.shipViaDataGridViewTextBoxColumn.Name = "shipViaDataGridViewTextBoxColumn";
			// 
			// orderCollectionBindingSource
			// 
			this.orderCollectionBindingSource.DataSource = typeof(NorthwindBizLayer.Entities.OrderCollection);
			// 
			// toolStripContainer1
			// 
			// 
			// toolStripContainer1.BottomToolStripPanel
			// 
			this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
			// 
			// toolStripContainer1.ContentPanel
			// 
			this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
			this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(647, 606);
			this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
			this.toolStripContainer1.Name = "toolStripContainer1";
			this.toolStripContainer1.Size = new System.Drawing.Size(647, 678);
			this.toolStripContainer1.TabIndex = 1;
			this.toolStripContainer1.Text = "toolStripContainer1";
			// 
			// toolStripContainer1.TopToolStripPanel
			// 
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
			this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.tsTests);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.statusStrip1.Location = new System.Drawing.Point(0, 0);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(647, 22);
			this.statusStrip1.TabIndex = 0;
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pnlDetails);
			this.splitContainer1.Size = new System.Drawing.Size(647, 606);
			this.splitContainer1.SplitterDistance = 254;
			this.splitContainer1.TabIndex = 1;
			// 
			// pnlDetails
			// 
			this.pnlDetails.AutoScroll = true;
			this.pnlDetails.Controls.Add(this.dataGridView2);
			this.pnlDetails.Controls.Add(shipViaLabel);
			this.pnlDetails.Controls.Add(this.shipViaTextBox);
			this.pnlDetails.Controls.Add(shipCountryLabel);
			this.pnlDetails.Controls.Add(this.shipCountryTextBox);
			this.pnlDetails.Controls.Add(shipPostalCodeLabel);
			this.pnlDetails.Controls.Add(this.shipPostalCodeTextBox);
			this.pnlDetails.Controls.Add(employeeIDLabel);
			this.pnlDetails.Controls.Add(this.employeeIDTextBox);
			this.pnlDetails.Controls.Add(shipRegionLabel);
			this.pnlDetails.Controls.Add(this.shipRegionTextBox);
			this.pnlDetails.Controls.Add(requiredDateLabel);
			this.pnlDetails.Controls.Add(this.requiredDateDateTimePicker);
			this.pnlDetails.Controls.Add(orderDateLabel);
			this.pnlDetails.Controls.Add(this.orderDateDateTimePicker);
			this.pnlDetails.Controls.Add(freightLabel);
			this.pnlDetails.Controls.Add(this.freightTextBox);
			this.pnlDetails.Controls.Add(orderIDLabel);
			this.pnlDetails.Controls.Add(this.orderIDTextBox);
			this.pnlDetails.Controls.Add(customerIDLabel);
			this.pnlDetails.Controls.Add(this.customerIDTextBox);
			this.pnlDetails.Controls.Add(shippedDateLabel);
			this.pnlDetails.Controls.Add(this.shippedDateDateTimePicker);
			this.pnlDetails.Controls.Add(shipNameLabel);
			this.pnlDetails.Controls.Add(this.shipNameTextBox);
			this.pnlDetails.Controls.Add(shipAddressLabel);
			this.pnlDetails.Controls.Add(this.shipAddressTextBox);
			this.pnlDetails.Controls.Add(shipCityLabel);
			this.pnlDetails.Controls.Add(this.shipCityTextBox);
			this.pnlDetails.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pnlDetails.Location = new System.Drawing.Point(0, 0);
			this.pnlDetails.Name = "pnlDetails";
			this.pnlDetails.Size = new System.Drawing.Size(647, 348);
			this.pnlDetails.TabIndex = 0;
			// 
			// dataGridView2
			// 
			this.dataGridView2.AllowUserToOrderColumns = true;
			this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView2.AutoGenerateColumns = false;
			this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.faxDataGridViewTextBoxColumn,
            this.cityDataGridViewTextBoxColumn,
            this.postalCodeDataGridViewTextBoxColumn,
            this.customerIDDataGridViewTextBoxColumn1,
            this.phoneDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.contactTitleDataGridViewTextBoxColumn,
            this.companyNameDataGridViewTextBoxColumn,
            this.contactNameDataGridViewTextBoxColumn,
            this.regionDataGridViewTextBoxColumn});
			this.dataGridView2.DataSource = this.customersBindingSource;
			this.dataGridView2.Location = new System.Drawing.Point(12, 184);
			this.dataGridView2.Name = "dataGridView2";
			this.dataGridView2.Size = new System.Drawing.Size(623, 161);
			this.dataGridView2.TabIndex = 32;
			// 
			// faxDataGridViewTextBoxColumn
			// 
			this.faxDataGridViewTextBoxColumn.DataPropertyName = "Fax";
			this.faxDataGridViewTextBoxColumn.HeaderText = "Fax";
			this.faxDataGridViewTextBoxColumn.Name = "faxDataGridViewTextBoxColumn";
			// 
			// cityDataGridViewTextBoxColumn
			// 
			this.cityDataGridViewTextBoxColumn.DataPropertyName = "City";
			this.cityDataGridViewTextBoxColumn.HeaderText = "City";
			this.cityDataGridViewTextBoxColumn.Name = "cityDataGridViewTextBoxColumn";
			// 
			// postalCodeDataGridViewTextBoxColumn
			// 
			this.postalCodeDataGridViewTextBoxColumn.DataPropertyName = "PostalCode";
			this.postalCodeDataGridViewTextBoxColumn.HeaderText = "PostalCode";
			this.postalCodeDataGridViewTextBoxColumn.Name = "postalCodeDataGridViewTextBoxColumn";
			// 
			// customerIDDataGridViewTextBoxColumn1
			// 
			this.customerIDDataGridViewTextBoxColumn1.DataPropertyName = "CustomerID";
			this.customerIDDataGridViewTextBoxColumn1.HeaderText = "CustomerID";
			this.customerIDDataGridViewTextBoxColumn1.Name = "customerIDDataGridViewTextBoxColumn1";
			// 
			// phoneDataGridViewTextBoxColumn
			// 
			this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
			this.phoneDataGridViewTextBoxColumn.HeaderText = "Phone";
			this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
			// 
			// addressDataGridViewTextBoxColumn
			// 
			this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
			this.addressDataGridViewTextBoxColumn.HeaderText = "Address";
			this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
			// 
			// countryDataGridViewTextBoxColumn
			// 
			this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
			this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
			this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
			// 
			// contactTitleDataGridViewTextBoxColumn
			// 
			this.contactTitleDataGridViewTextBoxColumn.DataPropertyName = "ContactTitle";
			this.contactTitleDataGridViewTextBoxColumn.HeaderText = "ContactTitle";
			this.contactTitleDataGridViewTextBoxColumn.Name = "contactTitleDataGridViewTextBoxColumn";
			// 
			// companyNameDataGridViewTextBoxColumn
			// 
			this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
			this.companyNameDataGridViewTextBoxColumn.HeaderText = "CompanyName";
			this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
			// 
			// contactNameDataGridViewTextBoxColumn
			// 
			this.contactNameDataGridViewTextBoxColumn.DataPropertyName = "ContactName";
			this.contactNameDataGridViewTextBoxColumn.HeaderText = "ContactName";
			this.contactNameDataGridViewTextBoxColumn.Name = "contactNameDataGridViewTextBoxColumn";
			// 
			// regionDataGridViewTextBoxColumn
			// 
			this.regionDataGridViewTextBoxColumn.DataPropertyName = "Region";
			this.regionDataGridViewTextBoxColumn.HeaderText = "Region";
			this.regionDataGridViewTextBoxColumn.Name = "regionDataGridViewTextBoxColumn";
			// 
			// customersBindingSource
			// 
			this.customersBindingSource.DataMember = "Customers";
			this.customersBindingSource.DataSource = this.orderCollectionBindingSource;
			// 
			// shipViaTextBox
			// 
			this.shipViaTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipVia", true));
			this.shipViaTextBox.Location = new System.Drawing.Point(438, 159);
			this.shipViaTextBox.Name = "shipViaTextBox";
			this.shipViaTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipViaTextBox.TabIndex = 31;
			// 
			// shipCountryTextBox
			// 
			this.shipCountryTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipCountry", true));
			this.shipCountryTextBox.Location = new System.Drawing.Point(438, 133);
			this.shipCountryTextBox.Name = "shipCountryTextBox";
			this.shipCountryTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipCountryTextBox.TabIndex = 29;
			// 
			// shipPostalCodeTextBox
			// 
			this.shipPostalCodeTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipPostalCode", true));
			this.shipPostalCodeTextBox.Location = new System.Drawing.Point(438, 107);
			this.shipPostalCodeTextBox.Name = "shipPostalCodeTextBox";
			this.shipPostalCodeTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipPostalCodeTextBox.TabIndex = 27;
			// 
			// employeeIDTextBox
			// 
			this.employeeIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "EmployeeID", true));
			this.employeeIDTextBox.Location = new System.Drawing.Point(438, 81);
			this.employeeIDTextBox.Name = "employeeIDTextBox";
			this.employeeIDTextBox.Size = new System.Drawing.Size(100, 20);
			this.employeeIDTextBox.TabIndex = 25;
			// 
			// shipRegionTextBox
			// 
			this.shipRegionTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipRegion", true));
			this.shipRegionTextBox.Location = new System.Drawing.Point(438, 55);
			this.shipRegionTextBox.Name = "shipRegionTextBox";
			this.shipRegionTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipRegionTextBox.TabIndex = 23;
			// 
			// requiredDateDateTimePicker
			// 
			this.requiredDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderCollectionBindingSource, "RequiredDate", true));
			this.requiredDateDateTimePicker.Enabled = false;
			this.requiredDateDateTimePicker.Location = new System.Drawing.Point(438, 29);
			this.requiredDateDateTimePicker.Name = "requiredDateDateTimePicker";
			this.requiredDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.requiredDateDateTimePicker.TabIndex = 21;
			// 
			// orderDateDateTimePicker
			// 
			this.orderDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderCollectionBindingSource, "OrderDate", true));
			this.orderDateDateTimePicker.Enabled = false;
			this.orderDateDateTimePicker.Location = new System.Drawing.Point(438, 3);
			this.orderDateDateTimePicker.Name = "orderDateDateTimePicker";
			this.orderDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.orderDateDateTimePicker.TabIndex = 19;
			// 
			// freightTextBox
			// 
			this.freightTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "Freight", true));
			this.freightTextBox.Location = new System.Drawing.Point(112, 160);
			this.freightTextBox.Name = "freightTextBox";
			this.freightTextBox.Size = new System.Drawing.Size(100, 20);
			this.freightTextBox.TabIndex = 17;
			// 
			// orderIDTextBox
			// 
			this.orderIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "OrderID", true));
			this.orderIDTextBox.Location = new System.Drawing.Point(112, 134);
			this.orderIDTextBox.Name = "orderIDTextBox";
			this.orderIDTextBox.Size = new System.Drawing.Size(100, 20);
			this.orderIDTextBox.TabIndex = 15;
			// 
			// customerIDTextBox
			// 
			this.customerIDTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "CustomerID", true));
			this.customerIDTextBox.Location = new System.Drawing.Point(112, 108);
			this.customerIDTextBox.Name = "customerIDTextBox";
			this.customerIDTextBox.Size = new System.Drawing.Size(100, 20);
			this.customerIDTextBox.TabIndex = 13;
			// 
			// shippedDateDateTimePicker
			// 
			this.shippedDateDateTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.orderCollectionBindingSource, "ShippedDate", true));
			this.shippedDateDateTimePicker.Enabled = false;
			this.shippedDateDateTimePicker.Location = new System.Drawing.Point(112, 82);
			this.shippedDateDateTimePicker.Name = "shippedDateDateTimePicker";
			this.shippedDateDateTimePicker.Size = new System.Drawing.Size(200, 20);
			this.shippedDateDateTimePicker.TabIndex = 9;
			// 
			// shipNameTextBox
			// 
			this.shipNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipName", true));
			this.shipNameTextBox.Location = new System.Drawing.Point(112, 55);
			this.shipNameTextBox.Name = "shipNameTextBox";
			this.shipNameTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipNameTextBox.TabIndex = 5;
			// 
			// shipAddressTextBox
			// 
			this.shipAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipAddress", true));
			this.shipAddressTextBox.Location = new System.Drawing.Point(112, 29);
			this.shipAddressTextBox.Name = "shipAddressTextBox";
			this.shipAddressTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipAddressTextBox.TabIndex = 3;
			// 
			// shipCityTextBox
			// 
			this.shipCityTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.orderCollectionBindingSource, "ShipCity", true));
			this.shipCityTextBox.Location = new System.Drawing.Point(112, 3);
			this.shipCityTextBox.Name = "shipCityTextBox";
			this.shipCityTextBox.Size = new System.Drawing.Size(100, 20);
			this.shipCityTextBox.TabIndex = 1;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoad,
            this.toolStripSeparator2,
            this.tsbAccept,
            this.tsbReject,
            this.tsbIsChanged,
            this.lblIsChanged,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscbColumnFilter,
            this.tscbOperator,
            this.tstFilter});
			this.toolStrip1.Location = new System.Drawing.Point(3, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(547, 25);
			this.toolStrip1.TabIndex = 0;
			// 
			// tsbLoad
			// 
			this.tsbLoad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbLoad.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoad.Image")));
			this.tsbLoad.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbLoad.Name = "tsbLoad";
			this.tsbLoad.Size = new System.Drawing.Size(34, 22);
			this.tsbLoad.Text = "Load";
			this.tsbLoad.Click += new System.EventHandler(this.tsbLoad_Click);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// tsbAccept
			// 
			this.tsbAccept.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAccept.Image = ((System.Drawing.Image)(resources.GetObject("tsbAccept.Image")));
			this.tsbAccept.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAccept.Name = "tsbAccept";
			this.tsbAccept.Size = new System.Drawing.Size(44, 22);
			this.tsbAccept.Text = "Accept";
			this.tsbAccept.Click += new System.EventHandler(this.btAccept_Click);
			// 
			// tsbReject
			// 
			this.tsbReject.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbReject.Image = ((System.Drawing.Image)(resources.GetObject("tsbReject.Image")));
			this.tsbReject.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbReject.Name = "tsbReject";
			this.tsbReject.Size = new System.Drawing.Size(42, 22);
			this.tsbReject.Text = "Reject";
			this.tsbReject.Click += new System.EventHandler(this.btReject_Click);
			// 
			// tsbIsChanged
			// 
			this.tsbIsChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbIsChanged.Image = ((System.Drawing.Image)(resources.GetObject("tsbIsChanged.Image")));
			this.tsbIsChanged.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbIsChanged.Name = "tsbIsChanged";
			this.tsbIsChanged.Size = new System.Drawing.Size(68, 22);
			this.tsbIsChanged.Text = "IsChanged?";
			this.tsbIsChanged.Click += new System.EventHandler(this.btIsChanged_Click);
			// 
			// lblIsChanged
			// 
			this.lblIsChanged.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.lblIsChanged.Name = "lblIsChanged";
			this.lblIsChanged.Size = new System.Drawing.Size(0, 22);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolStripLabel1
			// 
			this.toolStripLabel1.Name = "toolStripLabel1";
			this.toolStripLabel1.Size = new System.Drawing.Size(35, 22);
			this.toolStripLabel1.Text = "Filter:";
			// 
			// tscbColumnFilter
			// 
			this.tscbColumnFilter.Name = "tscbColumnFilter";
			this.tscbColumnFilter.Size = new System.Drawing.Size(121, 25);
			// 
			// tscbOperator
			// 
			this.tscbOperator.DropDownWidth = 40;
			this.tscbOperator.Items.AddRange(new object[] {
            "=",
            ">",
            ">=",
            "<",
            "<="});
			this.tscbOperator.Name = "tscbOperator";
			this.tscbOperator.Size = new System.Drawing.Size(75, 25);
			// 
			// tstFilter
			// 
			this.tstFilter.Name = "tstFilter";
			this.tstFilter.Size = new System.Drawing.Size(100, 25);
			this.tstFilter.TextChanged += new System.EventHandler(this.tstFilter_TextChanged);
			// 
			// tsTests
			// 
			this.tsTests.Dock = System.Windows.Forms.DockStyle.None;
			this.tsTests.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMemTestDataSet,
            this.tsbMemTestCollection,
            this.tsbSpeedTest,
            this.lblDataSet,
            this.toolStripSeparator3,
            this.lblCustom,
            this.tsbAssertTests,
            this.btSerializeTest});
			this.tsTests.Location = new System.Drawing.Point(3, 25);
			this.tsTests.Name = "tsTests";
			this.tsTests.Size = new System.Drawing.Size(459, 25);
			this.tsTests.TabIndex = 1;
			// 
			// tsbMemTestDataSet
			// 
			this.tsbMemTestDataSet.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbMemTestDataSet.Image = ((System.Drawing.Image)(resources.GetObject("tsbMemTestDataSet.Image")));
			this.tsbMemTestDataSet.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbMemTestDataSet.Name = "tsbMemTestDataSet";
			this.tsbMemTestDataSet.Size = new System.Drawing.Size(99, 22);
			this.tsbMemTestDataSet.Text = "Mem Test DataSet";
			this.tsbMemTestDataSet.Click += new System.EventHandler(this.tsbMemTestDataSet_Click);
			// 
			// tsbMemTestCollection
			// 
			this.tsbMemTestCollection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbMemTestCollection.Image = ((System.Drawing.Image)(resources.GetObject("tsbMemTestCollection.Image")));
			this.tsbMemTestCollection.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbMemTestCollection.Name = "tsbMemTestCollection";
			this.tsbMemTestCollection.Size = new System.Drawing.Size(106, 22);
			this.tsbMemTestCollection.Text = "Mem Test Collection";
			this.tsbMemTestCollection.Click += new System.EventHandler(this.tsbMemTestCollection_Click);
			// 
			// tsbSpeedTest
			// 
			this.tsbSpeedTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbSpeedTest.Image = ((System.Drawing.Image)(resources.GetObject("tsbSpeedTest.Image")));
			this.tsbSpeedTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbSpeedTest.Name = "tsbSpeedTest";
			this.tsbSpeedTest.Size = new System.Drawing.Size(65, 22);
			this.tsbSpeedTest.Text = "Speed Test";
			this.tsbSpeedTest.Click += new System.EventHandler(this.tsbSpeedTest_Click);
			// 
			// lblDataSet
			// 
			this.lblDataSet.Name = "lblDataSet";
			this.lblDataSet.Size = new System.Drawing.Size(0, 22);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// lblCustom
			// 
			this.lblCustom.Name = "lblCustom";
			this.lblCustom.Size = new System.Drawing.Size(0, 22);
			// 
			// tsbAssertTests
			// 
			this.tsbAssertTests.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.tsbAssertTests.Image = ((System.Drawing.Image)(resources.GetObject("tsbAssertTests.Image")));
			this.tsbAssertTests.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.tsbAssertTests.Name = "tsbAssertTests";
			this.tsbAssertTests.Size = new System.Drawing.Size(71, 22);
			this.tsbAssertTests.Text = "Assert Tests";
			this.tsbAssertTests.Click += new System.EventHandler(this.tsbAssertTests_Click);
			// 
			// btSerializeTest
			// 
			this.btSerializeTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.btSerializeTest.Image = ((System.Drawing.Image)(resources.GetObject("btSerializeTest.Image")));
			this.btSerializeTest.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.btSerializeTest.Name = "btSerializeTest";
			this.btSerializeTest.Size = new System.Drawing.Size(71, 22);
			this.btSerializeTest.Text = "SerializeTest";
			this.btSerializeTest.Click += new System.EventHandler(this.btSerializeTest_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(647, 678);
			this.Controls.Add(this.toolStripContainer1);
			this.MinimumSize = new System.Drawing.Size(400, 705);
			this.Name = "Form1";
			this.Text = "This is only a demo form ... no best practice coding here";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.orderCollectionBindingSource)).EndInit();
			this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
			this.toolStripContainer1.ContentPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
			this.toolStripContainer1.TopToolStripPanel.PerformLayout();
			this.toolStripContainer1.ResumeLayout(false);
			this.toolStripContainer1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.ResumeLayout(false);
			this.pnlDetails.ResumeLayout(false);
			this.pnlDetails.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.tsTests.ResumeLayout(false);
			this.tsTests.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.ToolStripContainer toolStripContainer1;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton tsbLoad;
		private System.Windows.Forms.BindingSource orderCollectionBindingSource;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripLabel toolStripLabel1;
		private System.Windows.Forms.ToolStripTextBox tstFilter;
		private System.Windows.Forms.ToolStripComboBox tscbColumnFilter;
		private System.Windows.Forms.ToolStripComboBox tscbOperator;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipCityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipAddressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shippedDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn freightDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn orderDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn requiredDateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipRegionDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn employeeIDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipPostalCodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipCountryDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn shipViaDataGridViewTextBoxColumn;
		private System.Windows.Forms.ToolStripButton tsbAccept;
		private System.Windows.Forms.ToolStripButton tsbReject;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton tsbIsChanged;
		private System.Windows.Forms.ToolStripLabel lblIsChanged;
		private System.Windows.Forms.Panel pnlDetails;
		private System.Windows.Forms.DateTimePicker shippedDateDateTimePicker;
		private System.Windows.Forms.TextBox shipNameTextBox;
		private System.Windows.Forms.TextBox shipAddressTextBox;
		private System.Windows.Forms.TextBox shipCityTextBox;
		private System.Windows.Forms.TextBox shipViaTextBox;
		private System.Windows.Forms.TextBox shipCountryTextBox;
		private System.Windows.Forms.TextBox shipPostalCodeTextBox;
		private System.Windows.Forms.TextBox employeeIDTextBox;
		private System.Windows.Forms.TextBox shipRegionTextBox;
		private System.Windows.Forms.DateTimePicker requiredDateDateTimePicker;
		private System.Windows.Forms.DateTimePicker orderDateDateTimePicker;
		private System.Windows.Forms.TextBox freightTextBox;
		private System.Windows.Forms.TextBox orderIDTextBox;
		private System.Windows.Forms.TextBox customerIDTextBox;
		private System.Windows.Forms.ToolStrip tsTests;
		private System.Windows.Forms.ToolStripButton tsbMemTestDataSet;
		private System.Windows.Forms.ToolStripButton tsbMemTestCollection;
		private System.Windows.Forms.ToolStripButton tsbSpeedTest;
		private System.Windows.Forms.ToolStripLabel lblDataSet;
		private System.Windows.Forms.ToolStripLabel lblCustom;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.DataGridView dataGridView2;
		private System.Windows.Forms.DataGridViewTextBoxColumn faxDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn cityDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn postalCodeDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn customerIDDataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn contactTitleDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn contactNameDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn regionDataGridViewTextBoxColumn;
		private System.Windows.Forms.BindingSource customersBindingSource;
		private System.Windows.Forms.ToolStripButton tsbAssertTests;
		private System.Windows.Forms.ToolStripButton btSerializeTest;
	}
}

