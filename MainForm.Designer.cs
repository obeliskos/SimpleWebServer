namespace SimpleWebServer
{
    partial class MainForm
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
            if (disposing && (components != null))
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.txtRootDirectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numPort = new System.Windows.Forms.NumericUpDown();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnPickRoot = new System.Windows.Forms.Button();
            this.btnLocationExe = new System.Windows.Forms.Button();
            this.btnLocationWorking = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripMainStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripServerStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStart = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonAbout = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxMimeMapping = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnUpdateMimeMapping = new System.Windows.Forms.Button();
            this.btnAddMimeType = new System.Windows.Forms.Button();
            this.btnRemoveMimeType = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxMimeExtension = new System.Windows.Forms.TextBox();
            this.groupBoxEditMimeType = new System.Windows.Forms.GroupBox();
            this.btnCancelMimeEdit = new System.Windows.Forms.Button();
            this.chkStartMinimized = new System.Windows.Forms.CheckBox();
            this.chkStartupServer = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listBoxMimeExtensions = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBoxEditMimeType.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtRootDirectory
            // 
            this.txtRootDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRootDirectory.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRootDirectory.Location = new System.Drawing.Point(20, 96);
            this.txtRootDirectory.Name = "txtRootDirectory";
            this.txtRootDirectory.Size = new System.Drawing.Size(535, 26);
            this.txtRootDirectory.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Root Directory :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(638, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Listen on port :";
            // 
            // numPort
            // 
            this.numPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPort.Location = new System.Drawing.Point(648, 97);
            this.numPort.Maximum = new decimal(new int[] {
            49151,
            0,
            0,
            0});
            this.numPort.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(120, 26);
            this.numPort.TabIndex = 6;
            this.numPort.Value = new decimal(new int[] {
            8080,
            0,
            0,
            0});
            // 
            // notifyIcon
            // 
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Simple Web Server";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon_Click);
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // btnPickRoot
            // 
            this.btnPickRoot.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPickRoot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPickRoot.Location = new System.Drawing.Point(561, 94);
            this.btnPickRoot.Name = "btnPickRoot";
            this.btnPickRoot.Size = new System.Drawing.Size(40, 28);
            this.btnPickRoot.TabIndex = 9;
            this.btnPickRoot.Text = "...";
            this.btnPickRoot.UseVisualStyleBackColor = true;
            this.btnPickRoot.Click += new System.EventHandler(this.btnPickRoot_Click);
            // 
            // btnLocationExe
            // 
            this.btnLocationExe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocationExe.Location = new System.Drawing.Point(104, 130);
            this.btnLocationExe.Name = "btnLocationExe";
            this.btnLocationExe.Size = new System.Drawing.Size(158, 34);
            this.btnLocationExe.TabIndex = 12;
            this.btnLocationExe.Text = "Set to exe location";
            this.btnLocationExe.UseVisualStyleBackColor = true;
            this.btnLocationExe.Click += new System.EventHandler(this.btnLocationExe_Click);
            // 
            // btnLocationWorking
            // 
            this.btnLocationWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLocationWorking.Location = new System.Drawing.Point(277, 130);
            this.btnLocationWorking.Name = "btnLocationWorking";
            this.btnLocationWorking.Size = new System.Drawing.Size(198, 34);
            this.btnLocationWorking.TabIndex = 13;
            this.btnLocationWorking.Text = "Set to working directory";
            this.btnLocationWorking.UseVisualStyleBackColor = true;
            this.btnLocationWorking.Click += new System.EventHandler(this.btnLocationWorking_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMainStatus,
            this.toolStripServerStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 467);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(788, 22);
            this.statusStrip1.TabIndex = 15;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripMainStatus
            // 
            this.toolStripMainStatus.Name = "toolStripMainStatus";
            this.toolStripMainStatus.Size = new System.Drawing.Size(45, 17);
            this.toolStripMainStatus.Text = "Status :";
            // 
            // toolStripServerStatus
            // 
            this.toolStripServerStatus.Name = "toolStripServerStatus";
            this.toolStripServerStatus.Size = new System.Drawing.Size(726, 17);
            this.toolStripServerStatus.Spring = true;
            this.toolStripServerStatus.Text = "Server Status : Stopped.";
            this.toolStripServerStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStart,
            this.toolStripButtonStop,
            this.toolStripButtonSaveSettings,
            this.toolStripButtonAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(788, 53);
            this.toolStrip1.TabIndex = 16;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonStart
            // 
            this.toolStripButtonStart.AutoSize = false;
            this.toolStripButtonStart.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStart.Image")));
            this.toolStripButtonStart.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStart.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStart.Name = "toolStripButtonStart";
            this.toolStripButtonStart.Size = new System.Drawing.Size(64, 50);
            this.toolStripButtonStart.Text = "Start";
            this.toolStripButtonStart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonStart.ToolTipText = "Start Server";
            this.toolStripButtonStart.Click += new System.EventHandler(this.toolStripButtonStart_Click);
            // 
            // toolStripButtonStop
            // 
            this.toolStripButtonStop.AutoSize = false;
            this.toolStripButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStop.Image")));
            this.toolStripButtonStop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStop.Name = "toolStripButtonStop";
            this.toolStripButtonStop.Size = new System.Drawing.Size(64, 50);
            this.toolStripButtonStop.Text = "Stop";
            this.toolStripButtonStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonStop.ToolTipText = "Stop Server";
            this.toolStripButtonStop.Click += new System.EventHandler(this.toolStripButtonStop_Click);
            // 
            // toolStripButtonSaveSettings
            // 
            this.toolStripButtonSaveSettings.AutoSize = false;
            this.toolStripButtonSaveSettings.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveSettings.Image")));
            this.toolStripButtonSaveSettings.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.toolStripButtonSaveSettings.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonSaveSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveSettings.Name = "toolStripButtonSaveSettings";
            this.toolStripButtonSaveSettings.Size = new System.Drawing.Size(64, 50);
            this.toolStripButtonSaveSettings.Text = "Save";
            this.toolStripButtonSaveSettings.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButtonSaveSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonSaveSettings.ToolTipText = "Save Defaults";
            this.toolStripButtonSaveSettings.Click += new System.EventHandler(this.toolStripButtonSaveSettings_Click);
            // 
            // toolStripButtonAbout
            // 
            this.toolStripButtonAbout.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButtonAbout.AutoSize = false;
            this.toolStripButtonAbout.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonAbout.Image")));
            this.toolStripButtonAbout.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButtonAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonAbout.Name = "toolStripButtonAbout";
            this.toolStripButtonAbout.Size = new System.Drawing.Size(64, 50);
            this.toolStripButtonAbout.Text = "About";
            this.toolStripButtonAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButtonAbout.Click += new System.EventHandler(this.toolStripButtonAbout_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 203);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 20);
            this.label3.TabIndex = 17;
            this.label3.Text = "Mime Types :";
            // 
            // textBoxMimeMapping
            // 
            this.textBoxMimeMapping.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMimeMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMimeMapping.Location = new System.Drawing.Point(24, 103);
            this.textBoxMimeMapping.Name = "textBoxMimeMapping";
            this.textBoxMimeMapping.Size = new System.Drawing.Size(421, 23);
            this.textBoxMimeMapping.TabIndex = 20;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(261, 17);
            this.label4.TabIndex = 21;
            this.label4.Text = "extensions :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(21, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "mapping :";
            // 
            // btnUpdateMimeMapping
            // 
            this.btnUpdateMimeMapping.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateMimeMapping.Location = new System.Drawing.Point(24, 141);
            this.btnUpdateMimeMapping.Name = "btnUpdateMimeMapping";
            this.btnUpdateMimeMapping.Size = new System.Drawing.Size(75, 32);
            this.btnUpdateMimeMapping.TabIndex = 23;
            this.btnUpdateMimeMapping.Text = "Update";
            this.btnUpdateMimeMapping.UseVisualStyleBackColor = true;
            this.btnUpdateMimeMapping.Click += new System.EventHandler(this.btnUpdateMimeMapping_Click);
            // 
            // btnAddMimeType
            // 
            this.btnAddMimeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddMimeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddMimeType.Location = new System.Drawing.Point(5, 1);
            this.btnAddMimeType.Name = "btnAddMimeType";
            this.btnAddMimeType.Size = new System.Drawing.Size(83, 31);
            this.btnAddMimeType.TabIndex = 24;
            this.btnAddMimeType.Text = "Add";
            this.btnAddMimeType.UseVisualStyleBackColor = true;
            this.btnAddMimeType.Click += new System.EventHandler(this.btnAddMimeType_Click);
            // 
            // btnRemoveMimeType
            // 
            this.btnRemoveMimeType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveMimeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemoveMimeType.Location = new System.Drawing.Point(94, 0);
            this.btnRemoveMimeType.Name = "btnRemoveMimeType";
            this.btnRemoveMimeType.Size = new System.Drawing.Size(86, 31);
            this.btnRemoveMimeType.TabIndex = 25;
            this.btnRemoveMimeType.Text = "Delete";
            this.btnRemoveMimeType.UseVisualStyleBackColor = true;
            this.btnRemoveMimeType.Click += new System.EventHandler(this.btnRemoveMimeType_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 17);
            this.label6.TabIndex = 26;
            this.label6.Text = "extension :";
            // 
            // textBoxMimeExtension
            // 
            this.textBoxMimeExtension.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMimeExtension.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxMimeExtension.Location = new System.Drawing.Point(24, 50);
            this.textBoxMimeExtension.Name = "textBoxMimeExtension";
            this.textBoxMimeExtension.Size = new System.Drawing.Size(421, 23);
            this.textBoxMimeExtension.TabIndex = 27;
            // 
            // groupBoxEditMimeType
            // 
            this.groupBoxEditMimeType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxEditMimeType.Controls.Add(this.btnCancelMimeEdit);
            this.groupBoxEditMimeType.Controls.Add(this.label6);
            this.groupBoxEditMimeType.Controls.Add(this.textBoxMimeExtension);
            this.groupBoxEditMimeType.Controls.Add(this.textBoxMimeMapping);
            this.groupBoxEditMimeType.Controls.Add(this.label5);
            this.groupBoxEditMimeType.Controls.Add(this.btnUpdateMimeMapping);
            this.groupBoxEditMimeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxEditMimeType.Location = new System.Drawing.Point(305, 235);
            this.groupBoxEditMimeType.Name = "groupBoxEditMimeType";
            this.groupBoxEditMimeType.Size = new System.Drawing.Size(466, 199);
            this.groupBoxEditMimeType.TabIndex = 28;
            this.groupBoxEditMimeType.TabStop = false;
            this.groupBoxEditMimeType.Text = "mime type properties : ";
            this.groupBoxEditMimeType.Visible = false;
            // 
            // btnCancelMimeEdit
            // 
            this.btnCancelMimeEdit.Location = new System.Drawing.Point(115, 141);
            this.btnCancelMimeEdit.Name = "btnCancelMimeEdit";
            this.btnCancelMimeEdit.Size = new System.Drawing.Size(81, 31);
            this.btnCancelMimeEdit.TabIndex = 28;
            this.btnCancelMimeEdit.Text = "Cancel";
            this.btnCancelMimeEdit.UseVisualStyleBackColor = true;
            this.btnCancelMimeEdit.Click += new System.EventHandler(this.btnCancelMimeEdit_Click);
            // 
            // chkStartMinimized
            // 
            this.chkStartMinimized.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStartMinimized.AutoSize = true;
            this.chkStartMinimized.Location = new System.Drawing.Point(646, 156);
            this.chkStartMinimized.Name = "chkStartMinimized";
            this.chkStartMinimized.Size = new System.Drawing.Size(116, 17);
            this.chkStartMinimized.TabIndex = 29;
            this.chkStartMinimized.Text = "Minimize on startup";
            this.chkStartMinimized.UseVisualStyleBackColor = true;
            // 
            // chkStartupServer
            // 
            this.chkStartupServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkStartupServer.AutoSize = true;
            this.chkStartupServer.Location = new System.Drawing.Point(646, 184);
            this.chkStartupServer.Name = "chkStartupServer";
            this.chkStartupServer.Size = new System.Drawing.Size(130, 17);
            this.chkStartupServer.TabIndex = 30;
            this.chkStartupServer.Text = "Start server on startup";
            this.chkStartupServer.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.listBoxMimeExtensions);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(25, 226);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(261, 223);
            this.panel1.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnAddMimeType);
            this.panel2.Controls.Add(this.btnRemoveMimeType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 184);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(261, 39);
            this.panel2.TabIndex = 33;
            // 
            // listBoxMimeExtensions
            // 
            this.listBoxMimeExtensions.DisplayMember = "Key";
            this.listBoxMimeExtensions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxMimeExtensions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBoxMimeExtensions.FormattingEnabled = true;
            this.listBoxMimeExtensions.ItemHeight = 20;
            this.listBoxMimeExtensions.Location = new System.Drawing.Point(0, 17);
            this.listBoxMimeExtensions.Name = "listBoxMimeExtensions";
            this.listBoxMimeExtensions.ScrollAlwaysVisible = true;
            this.listBoxMimeExtensions.Size = new System.Drawing.Size(261, 167);
            this.listBoxMimeExtensions.TabIndex = 34;
            this.listBoxMimeExtensions.ValueMember = "Key";
            this.listBoxMimeExtensions.Click += new System.EventHandler(this.listBoxMimeExtensions_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 489);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chkStartupServer);
            this.Controls.Add(this.chkStartMinimized);
            this.Controls.Add(this.groupBoxEditMimeType);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLocationWorking);
            this.Controls.Add(this.btnLocationExe);
            this.Controls.Add(this.btnPickRoot);
            this.Controls.Add(this.txtRootDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPort);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Simple Web Server v#.##";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numPort)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBoxEditMimeType.ResumeLayout(false);
            this.groupBoxEditMimeType.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRootDirectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numPort;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnPickRoot;
        private System.Windows.Forms.Button btnLocationExe;
        private System.Windows.Forms.Button btnLocationWorking;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripMainStatus;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonStart;
        private System.Windows.Forms.ToolStripButton toolStripButtonStop;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveSettings;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxMimeMapping;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnUpdateMimeMapping;
        private System.Windows.Forms.Button btnAddMimeType;
        private System.Windows.Forms.Button btnRemoveMimeType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxMimeExtension;
        private System.Windows.Forms.GroupBox groupBoxEditMimeType;
        private System.Windows.Forms.Button btnCancelMimeEdit;
        private System.Windows.Forms.ToolStripButton toolStripButtonAbout;
        private System.Windows.Forms.ToolStripStatusLabel toolStripServerStatus;
        private System.Windows.Forms.CheckBox chkStartMinimized;
        private System.Windows.Forms.CheckBox chkStartupServer;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox listBoxMimeExtensions;
        private System.Windows.Forms.Panel panel2;
    }
}

