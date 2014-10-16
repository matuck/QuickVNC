namespace QuickVnc
{
    partial class QuickVnc
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuickVnc));
            this.computersearch = new System.Windows.Forms.TextBox();
            this.compdropbox = new System.Windows.Forms.ComboBox();
            this.connect = new System.Windows.Forms.Button();
            this.search = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.domaindropdown = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.restart = new System.Windows.Forms.Button();
            this.shutdown = new System.Windows.Forms.Button();
            this.ping = new System.Windows.Forms.Button();
            this.disautologinBTN = new System.Windows.Forms.Button();
            this.enautologinBTN = new System.Windows.Forms.Button();
            this.setuploginbtn = new System.Windows.Forms.Button();
            this.rdp = new System.Windows.Forms.Button();
            this.addworklist = new System.Windows.Forms.Button();
            this.findcomputers = new System.Windows.Forms.GroupBox();
            this.worklistgroup = new System.Windows.Forms.GroupBox();
            this.stopAllPing = new System.Windows.Forms.Button();
            this.stopPing = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.computer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwd = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.delete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.contextMenuDataGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disableAutoLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enableAutoLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setupAutoLoginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopPingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.restartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.shutdownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.remoteControlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vNCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rDPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computerDescriptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeFavoriteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.findcomputers.SuspendLayout();
            this.worklistgroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuDataGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // computersearch
            // 
            this.computersearch.Location = new System.Drawing.Point(9, 46);
            this.computersearch.Name = "computersearch";
            this.computersearch.Size = new System.Drawing.Size(249, 20);
            this.computersearch.TabIndex = 2;
            this.computersearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.computersearch_KeyPress);
            // 
            // compdropbox
            // 
            this.compdropbox.FormattingEnabled = true;
            this.compdropbox.Location = new System.Drawing.Point(64, 72);
            this.compdropbox.Name = "compdropbox";
            this.compdropbox.Size = new System.Drawing.Size(281, 21);
            this.compdropbox.TabIndex = 3;
            // 
            // connect
            // 
            this.connect.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connect.Location = new System.Drawing.Point(9, 173);
            this.connect.Name = "connect";
            this.connect.Size = new System.Drawing.Size(171, 34);
            this.connect.TabIndex = 5;
            this.connect.Text = "VNC";
            this.connect.UseVisualStyleBackColor = true;
            this.connect.Click += new System.EventHandler(this.connect_Click);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(264, 46);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(81, 23);
            this.search.TabIndex = 6;
            this.search.Text = "Search";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.passwordsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(374, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // passwordsToolStripMenuItem
            // 
            this.passwordsToolStripMenuItem.Name = "passwordsToolStripMenuItem";
            this.passwordsToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.passwordsToolStripMenuItem.Text = "Passwords";
            this.passwordsToolStripMenuItem.Click += new System.EventHandler(this.passwordsToolStripMenuItem_Click);
            // 
            // domaindropdown
            // 
            this.domaindropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.domaindropdown.FormattingEnabled = true;
            this.domaindropdown.Location = new System.Drawing.Point(95, 19);
            this.domaindropdown.Name = "domaindropdown";
            this.domaindropdown.Size = new System.Drawing.Size(250, 21);
            this.domaindropdown.TabIndex = 8;
            this.domaindropdown.SelectedIndexChanged += new System.EventHandler(this.domaindropdown_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Search Provider";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Computer";
            // 
            // restart
            // 
            this.restart.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.restart.Location = new System.Drawing.Point(9, 213);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(167, 41);
            this.restart.TabIndex = 12;
            this.restart.Text = "Restart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // shutdown
            // 
            this.shutdown.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.shutdown.Location = new System.Drawing.Point(182, 213);
            this.shutdown.Name = "shutdown";
            this.shutdown.Size = new System.Drawing.Size(163, 41);
            this.shutdown.TabIndex = 13;
            this.shutdown.Text = "Shutdown";
            this.shutdown.UseVisualStyleBackColor = true;
            this.shutdown.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // ping
            // 
            this.ping.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.ping.Location = new System.Drawing.Point(11, 259);
            this.ping.Name = "ping";
            this.ping.Size = new System.Drawing.Size(89, 41);
            this.ping.TabIndex = 14;
            this.ping.Text = "Ping";
            this.ping.UseVisualStyleBackColor = true;
            this.ping.Click += new System.EventHandler(this.ping_Click);
            // 
            // disautologinBTN
            // 
            this.disautologinBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.disautologinBTN.Location = new System.Drawing.Point(9, 306);
            this.disautologinBTN.Name = "disautologinBTN";
            this.disautologinBTN.Size = new System.Drawing.Size(167, 35);
            this.disautologinBTN.TabIndex = 15;
            this.disautologinBTN.Text = "Disable Auto Login";
            this.disautologinBTN.UseVisualStyleBackColor = true;
            this.disautologinBTN.Click += new System.EventHandler(this.disautologinBTN_Click);
            // 
            // enautologinBTN
            // 
            this.enautologinBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.enautologinBTN.Location = new System.Drawing.Point(182, 307);
            this.enautologinBTN.Name = "enautologinBTN";
            this.enautologinBTN.Size = new System.Drawing.Size(162, 35);
            this.enautologinBTN.TabIndex = 16;
            this.enautologinBTN.Text = "Enable Auto Login";
            this.enautologinBTN.UseVisualStyleBackColor = true;
            this.enautologinBTN.Click += new System.EventHandler(this.enautologinBTN_Click);
            // 
            // setuploginbtn
            // 
            this.setuploginbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.setuploginbtn.Location = new System.Drawing.Point(11, 347);
            this.setuploginbtn.Name = "setuploginbtn";
            this.setuploginbtn.Size = new System.Drawing.Size(336, 34);
            this.setuploginbtn.TabIndex = 17;
            this.setuploginbtn.Text = "Setup Auto Login";
            this.setuploginbtn.UseVisualStyleBackColor = true;
            this.setuploginbtn.Click += new System.EventHandler(this.setuploginbtn_Click);
            // 
            // rdp
            // 
            this.rdp.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdp.Location = new System.Drawing.Point(182, 173);
            this.rdp.Name = "rdp";
            this.rdp.Size = new System.Drawing.Size(163, 34);
            this.rdp.TabIndex = 18;
            this.rdp.Text = "RDP";
            this.rdp.UseVisualStyleBackColor = true;
            this.rdp.Click += new System.EventHandler(this.rdp_Click);
            // 
            // addworklist
            // 
            this.addworklist.Location = new System.Drawing.Point(9, 99);
            this.addworklist.Name = "addworklist";
            this.addworklist.Size = new System.Drawing.Size(336, 23);
            this.addworklist.TabIndex = 20;
            this.addworklist.Text = "Add To Worklist";
            this.addworklist.UseVisualStyleBackColor = true;
            this.addworklist.Click += new System.EventHandler(this.addworklist_Click);
            // 
            // findcomputers
            // 
            this.findcomputers.Controls.Add(this.domaindropdown);
            this.findcomputers.Controls.Add(this.addworklist);
            this.findcomputers.Controls.Add(this.label1);
            this.findcomputers.Controls.Add(this.computersearch);
            this.findcomputers.Controls.Add(this.search);
            this.findcomputers.Controls.Add(this.label2);
            this.findcomputers.Controls.Add(this.compdropbox);
            this.findcomputers.Location = new System.Drawing.Point(9, 27);
            this.findcomputers.Name = "findcomputers";
            this.findcomputers.Size = new System.Drawing.Size(353, 132);
            this.findcomputers.TabIndex = 21;
            this.findcomputers.TabStop = false;
            this.findcomputers.Text = "Find Computers";
            // 
            // worklistgroup
            // 
            this.worklistgroup.Controls.Add(this.stopAllPing);
            this.worklistgroup.Controls.Add(this.stopPing);
            this.worklistgroup.Controls.Add(this.dataGridView1);
            this.worklistgroup.Controls.Add(this.connect);
            this.worklistgroup.Controls.Add(this.setuploginbtn);
            this.worklistgroup.Controls.Add(this.rdp);
            this.worklistgroup.Controls.Add(this.enautologinBTN);
            this.worklistgroup.Controls.Add(this.restart);
            this.worklistgroup.Controls.Add(this.disautologinBTN);
            this.worklistgroup.Controls.Add(this.shutdown);
            this.worklistgroup.Controls.Add(this.ping);
            this.worklistgroup.Location = new System.Drawing.Point(9, 165);
            this.worklistgroup.Name = "worklistgroup";
            this.worklistgroup.Size = new System.Drawing.Size(353, 388);
            this.worklistgroup.TabIndex = 22;
            this.worklistgroup.TabStop = false;
            this.worklistgroup.Text = "Work List";
            // 
            // stopAllPing
            // 
            this.stopAllPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopAllPing.Location = new System.Drawing.Point(218, 260);
            this.stopAllPing.Name = "stopAllPing";
            this.stopAllPing.Size = new System.Drawing.Size(127, 41);
            this.stopAllPing.TabIndex = 21;
            this.stopAllPing.Text = "Stop All Ping";
            this.stopAllPing.UseVisualStyleBackColor = true;
            this.stopAllPing.Click += new System.EventHandler(this.stopAllPing_Click);
            // 
            // stopPing
            // 
            this.stopPing.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stopPing.Location = new System.Drawing.Point(106, 260);
            this.stopPing.Name = "stopPing";
            this.stopPing.Size = new System.Drawing.Size(106, 40);
            this.stopPing.TabIndex = 20;
            this.stopPing.Text = "Stop Ping";
            this.stopPing.UseVisualStyleBackColor = true;
            this.stopPing.Click += new System.EventHandler(this.stopPing_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.computer,
            this.passwd,
            this.status,
            this.delete});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(9, 19);
            this.dataGridView1.MaximumSize = new System.Drawing.Size(336, 150);
            this.dataGridView1.MinimumSize = new System.Drawing.Size(336, 150);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(336, 150);
            this.dataGridView1.TabIndex = 19;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridView1_CellFormating);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            this.dataGridView1.CurrentCellDirtyStateChanged += new System.EventHandler(this.dataGridView1_CurrentCellDirtyStateChanged);
            this.dataGridView1.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dataGridView1_EditingControlShowing);
            // 
            // computer
            // 
            this.computer.HeaderText = "Computer";
            this.computer.Name = "computer";
            this.computer.ReadOnly = true;
            // 
            // passwd
            // 
            this.passwd.HeaderText = "Password";
            this.passwd.MaxDropDownItems = 100;
            this.passwd.Name = "passwd";
            // 
            // status
            // 
            this.status.HeaderText = "Status";
            this.status.Name = "status";
            this.status.ReadOnly = true;
            // 
            // delete
            // 
            this.delete.HeaderText = "Delete";
            this.delete.Name = "delete";
            this.delete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.delete.Text = "Delete";
            this.delete.UseColumnTextForButtonValue = true;
            // 
            // contextMenuDataGrid
            // 
            this.contextMenuDataGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loginToolStripMenuItem,
            this.pingToolStripMenuItem,
            this.powerToolStripMenuItem,
            this.remoteControlToolStripMenuItem,
            this.computerDescriptionToolStripMenuItem,
            this.addFavoriteToolStripMenuItem,
            this.removeFavoriteToolStripMenuItem});
            this.contextMenuDataGrid.Name = "contextMenuDataGrid";
            this.contextMenuDataGrid.Size = new System.Drawing.Size(192, 158);
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.disableAutoLoginToolStripMenuItem,
            this.enableAutoLoginToolStripMenuItem,
            this.setupAutoLoginToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // disableAutoLoginToolStripMenuItem
            // 
            this.disableAutoLoginToolStripMenuItem.Name = "disableAutoLoginToolStripMenuItem";
            this.disableAutoLoginToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.disableAutoLoginToolStripMenuItem.Text = "Disable Auto Login";
            this.disableAutoLoginToolStripMenuItem.Click += new System.EventHandler(this.disautologinBTN_Click);
            // 
            // enableAutoLoginToolStripMenuItem
            // 
            this.enableAutoLoginToolStripMenuItem.Name = "enableAutoLoginToolStripMenuItem";
            this.enableAutoLoginToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.enableAutoLoginToolStripMenuItem.Text = "Enable Auto Login";
            this.enableAutoLoginToolStripMenuItem.Click += new System.EventHandler(this.enautologinBTN_Click);
            // 
            // setupAutoLoginToolStripMenuItem
            // 
            this.setupAutoLoginToolStripMenuItem.Name = "setupAutoLoginToolStripMenuItem";
            this.setupAutoLoginToolStripMenuItem.Size = new System.Drawing.Size(174, 22);
            this.setupAutoLoginToolStripMenuItem.Text = "Setup Auto Login";
            this.setupAutoLoginToolStripMenuItem.Click += new System.EventHandler(this.setuploginbtn_Click);
            // 
            // pingToolStripMenuItem
            // 
            this.pingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startPingToolStripMenuItem,
            this.stopPingToolStripMenuItem});
            this.pingToolStripMenuItem.Name = "pingToolStripMenuItem";
            this.pingToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.pingToolStripMenuItem.Text = "Ping";
            // 
            // startPingToolStripMenuItem
            // 
            this.startPingToolStripMenuItem.Name = "startPingToolStripMenuItem";
            this.startPingToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.startPingToolStripMenuItem.Text = "Start Ping";
            this.startPingToolStripMenuItem.Click += new System.EventHandler(this.ping_Click);
            // 
            // stopPingToolStripMenuItem
            // 
            this.stopPingToolStripMenuItem.Name = "stopPingToolStripMenuItem";
            this.stopPingToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.stopPingToolStripMenuItem.Text = "Stop Ping";
            this.stopPingToolStripMenuItem.Click += new System.EventHandler(this.stopPing_Click);
            // 
            // powerToolStripMenuItem
            // 
            this.powerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.restartToolStripMenuItem,
            this.shutdownToolStripMenuItem});
            this.powerToolStripMenuItem.Name = "powerToolStripMenuItem";
            this.powerToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.powerToolStripMenuItem.Text = "Power";
            // 
            // restartToolStripMenuItem
            // 
            this.restartToolStripMenuItem.Name = "restartToolStripMenuItem";
            this.restartToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.restartToolStripMenuItem.Text = "Restart";
            this.restartToolStripMenuItem.Click += new System.EventHandler(this.restart_Click);
            // 
            // shutdownToolStripMenuItem
            // 
            this.shutdownToolStripMenuItem.Name = "shutdownToolStripMenuItem";
            this.shutdownToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.shutdownToolStripMenuItem.Text = "Shutdown";
            this.shutdownToolStripMenuItem.Click += new System.EventHandler(this.shutdown_Click);
            // 
            // remoteControlToolStripMenuItem
            // 
            this.remoteControlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vNCToolStripMenuItem,
            this.rDPToolStripMenuItem});
            this.remoteControlToolStripMenuItem.Name = "remoteControlToolStripMenuItem";
            this.remoteControlToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.remoteControlToolStripMenuItem.Text = "Remote Control";
            // 
            // vNCToolStripMenuItem
            // 
            this.vNCToolStripMenuItem.Name = "vNCToolStripMenuItem";
            this.vNCToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.vNCToolStripMenuItem.Text = "VNC";
            this.vNCToolStripMenuItem.Click += new System.EventHandler(this.connect_Click);
            // 
            // rDPToolStripMenuItem
            // 
            this.rDPToolStripMenuItem.Name = "rDPToolStripMenuItem";
            this.rDPToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.rDPToolStripMenuItem.Text = "RDP";
            this.rDPToolStripMenuItem.Click += new System.EventHandler(this.rdp_Click);
            // 
            // computerDescriptionToolStripMenuItem
            // 
            this.computerDescriptionToolStripMenuItem.Name = "computerDescriptionToolStripMenuItem";
            this.computerDescriptionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.computerDescriptionToolStripMenuItem.Text = "Computer Description";
            this.computerDescriptionToolStripMenuItem.Click += new System.EventHandler(this.computerDescriptionToolStripMenuItem_Click);
            // 
            // addFavoriteToolStripMenuItem
            // 
            this.addFavoriteToolStripMenuItem.Name = "addFavoriteToolStripMenuItem";
            this.addFavoriteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.addFavoriteToolStripMenuItem.Text = "Add Favorite";
            this.addFavoriteToolStripMenuItem.Click += new System.EventHandler(this.AddFavoriteGroupClickHandler);
            // 
            // removeFavoriteToolStripMenuItem
            // 
            this.removeFavoriteToolStripMenuItem.Name = "removeFavoriteToolStripMenuItem";
            this.removeFavoriteToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.removeFavoriteToolStripMenuItem.Text = "Remove Favorite";
            this.removeFavoriteToolStripMenuItem.Click += new System.EventHandler(this.removeFavoriteToolStripMenuItem_Click);
            // 
            // QuickVnc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 561);
            this.Controls.Add(this.worklistgroup);
            this.Controls.Add(this.findcomputers);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(390, 600);
            this.MinimumSize = new System.Drawing.Size(390, 600);
            this.Name = "QuickVnc";
            this.Text = "QuickVnc";
            this.Load += new System.EventHandler(this.QuickVnc_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.findcomputers.ResumeLayout(false);
            this.findcomputers.PerformLayout();
            this.worklistgroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuDataGrid.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox computersearch;
        private System.Windows.Forms.ComboBox compdropbox;
        private System.Windows.Forms.Button connect;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem passwordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ComboBox domaindropdown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button restart;
        private System.Windows.Forms.Button shutdown;
        private System.Windows.Forms.Button ping;
        private System.Windows.Forms.Button disautologinBTN;
        private System.Windows.Forms.Button enautologinBTN;
        private System.Windows.Forms.Button setuploginbtn;
        private System.Windows.Forms.Button rdp;
        private System.Windows.Forms.Button addworklist;
        private System.Windows.Forms.GroupBox findcomputers;
        private System.Windows.Forms.GroupBox worklistgroup;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn computer;
        private System.Windows.Forms.DataGridViewComboBoxColumn passwd;
        private System.Windows.Forms.DataGridViewTextBoxColumn status;
        private System.Windows.Forms.DataGridViewButtonColumn delete;
        private System.Windows.Forms.Button stopAllPing;
        private System.Windows.Forms.Button stopPing;
        private System.Windows.Forms.ContextMenuStrip contextMenuDataGrid;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disableAutoLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem enableAutoLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setupAutoLoginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startPingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stopPingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem restartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem shutdownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem remoteControlToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vNCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rDPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computerDescriptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFavoriteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeFavoriteToolStripMenuItem;
    }
}

