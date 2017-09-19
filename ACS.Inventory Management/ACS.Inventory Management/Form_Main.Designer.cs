namespace ACS.Inventory_Management
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._comboBox_findIn = new System.Windows.Forms.ComboBox();
            this._textBox_findwhat = new System.Windows.Forms.TextBox();
            this._button_Account = new System.Windows.Forms.Button();
            this._button_manager = new System.Windows.Forms.Button();
            this._button_Admin = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this._treeView_device = new System.Windows.Forms.TreeView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._dataGridView_device = new System.Windows.Forms.DataGridView();
            this._imageList_device = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView_device)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1244, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolsToolStripMenuItem,
            this.findToolStripMenuItem});
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.findToolStripMenuItem.Text = "Find";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this._comboBox_findIn);
            this.panel1.Controls.Add(this._textBox_findwhat);
            this.panel1.Controls.Add(this._button_Account);
            this.panel1.Controls.Add(this._button_manager);
            this.panel1.Controls.Add(this._button_Admin);
            this.panel1.Location = new System.Drawing.Point(12, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1220, 53);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::ACS.Inventory_Management.Properties.Resources.find_next;
            this.pictureBox1.Location = new System.Drawing.Point(1165, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(43, 33);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(939, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(30, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "in >>";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(642, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Find what:";
            // 
            // _comboBox_findIn
            // 
            this._comboBox_findIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._comboBox_findIn.FormattingEnabled = true;
            this._comboBox_findIn.Location = new System.Drawing.Point(973, 22);
            this._comboBox_findIn.Name = "_comboBox_findIn";
            this._comboBox_findIn.Size = new System.Drawing.Size(177, 21);
            this._comboBox_findIn.TabIndex = 4;
            // 
            // _textBox_findwhat
            // 
            this._textBox_findwhat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._textBox_findwhat.Location = new System.Drawing.Point(701, 22);
            this._textBox_findwhat.Name = "_textBox_findwhat";
            this._textBox_findwhat.Size = new System.Drawing.Size(235, 20);
            this._textBox_findwhat.TabIndex = 3;
            this._textBox_findwhat.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // _button_Account
            // 
            this._button_Account.Image = global::ACS.Inventory_Management.Properties.Resources.account_settings;
            this._button_Account.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._button_Account.Location = new System.Drawing.Point(150, 0);
            this._button_Account.Name = "_button_Account";
            this._button_Account.Size = new System.Drawing.Size(69, 53);
            this._button_Account.TabIndex = 2;
            this._button_Account.Text = "Account";
            this._button_Account.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._button_Account.UseVisualStyleBackColor = true;
            // 
            // _button_manager
            // 
            this._button_manager.Image = global::ACS.Inventory_Management.Properties.Resources.data_transfer;
            this._button_manager.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._button_manager.Location = new System.Drawing.Point(75, 0);
            this._button_manager.Name = "_button_manager";
            this._button_manager.Size = new System.Drawing.Size(69, 53);
            this._button_manager.TabIndex = 1;
            this._button_manager.Text = "Manager";
            this._button_manager.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._button_manager.UseVisualStyleBackColor = true;
            // 
            // _button_Admin
            // 
            this._button_Admin.Image = global::ACS.Inventory_Management.Properties.Resources.color_settings;
            this._button_Admin.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this._button_Admin.Location = new System.Drawing.Point(0, 0);
            this._button_Admin.Name = "_button_Admin";
            this._button_Admin.Size = new System.Drawing.Size(69, 53);
            this._button_Admin.TabIndex = 0;
            this._button_Admin.Text = "Admin";
            this._button_Admin.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this._button_Admin.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(12, 106);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this._treeView_device);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(1220, 615);
            this.splitContainer1.SplitterDistance = 205;
            this.splitContainer1.TabIndex = 2;
            // 
            // _treeView_device
            // 
            this._treeView_device.Dock = System.Windows.Forms.DockStyle.Fill;
            this._treeView_device.ImageIndex = 22;
            this._treeView_device.ImageList = this._imageList_device;
            this._treeView_device.Location = new System.Drawing.Point(0, 0);
            this._treeView_device.Name = "_treeView_device";
            this._treeView_device.SelectedImageIndex = 21;
            this._treeView_device.Size = new System.Drawing.Size(205, 615);
            this._treeView_device.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this._dataGridView_device);
            this.splitContainer2.Size = new System.Drawing.Size(1023, 668);
            this.splitContainer2.SplitterDistance = 411;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Location = new System.Drawing.Point(0, -6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1011, 385);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // _dataGridView_device
            // 
            this._dataGridView_device.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridView_device.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridView_device.Location = new System.Drawing.Point(0, 0);
            this._dataGridView_device.Name = "_dataGridView_device";
            this._dataGridView_device.Size = new System.Drawing.Size(1023, 253);
            this._dataGridView_device.TabIndex = 0;
            // 
            // _imageList_device
            // 
            this._imageList_device.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("_imageList_device.ImageStream")));
            this._imageList_device.TransparentColor = System.Drawing.Color.Transparent;
            this._imageList_device.Images.SetKeyName(0, "cat5_ethernet_cable.png");
            this._imageList_device.Images.SetKeyName(1, "cd.png");
            this._imageList_device.Images.SetKeyName(2, "commutator.png");
            this._imageList_device.Images.SetKeyName(3, "computer.png");
            this._imageList_device.Images.SetKeyName(4, "ergonomic_mouse.png");
            this._imageList_device.Images.SetKeyName(5, "fax_machine.png");
            this._imageList_device.Images.SetKeyName(6, "firewall.png");
            this._imageList_device.Images.SetKeyName(7, "flatbed_scanner.png");
            this._imageList_device.Images.SetKeyName(8, "gaming_laptop.png");
            this._imageList_device.Images.SetKeyName(9, "keyboard.png");
            this._imageList_device.Images.SetKeyName(10, "power_strip.png");
            this._imageList_device.Images.SetKeyName(11, "ram.png");
            this._imageList_device.Images.SetKeyName(12, "router.png");
            this._imageList_device.Images.SetKeyName(13, "server.png");
            this._imageList_device.Images.SetKeyName(14, "sim_card.png");
            this._imageList_device.Images.SetKeyName(15, "switch.png");
            this._imageList_device.Images.SetKeyName(16, "tablet.png");
            this._imageList_device.Images.SetKeyName(17, "monitor.png");
            this._imageList_device.Images.SetKeyName(18, "time_level.png");
            this._imageList_device.Images.SetKeyName(19, "printer.png");
            this._imageList_device.Images.SetKeyName(20, "align_center.png");
            this._imageList_device.Images.SetKeyName(21, "play.png");
            this._imageList_device.Images.SetKeyName(22, "candy_store.png");
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1244, 749);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form_Main";
            this.Text = "ACS.IT Storage Management - HCM";
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridView_device)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView _treeView_device;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.DataGridView _dataGridView_device;
        private System.Windows.Forms.Button _button_Admin;
        private System.Windows.Forms.Button _button_manager;
        private System.Windows.Forms.Button _button_Account;
        private System.Windows.Forms.ComboBox _comboBox_findIn;
        private System.Windows.Forms.TextBox _textBox_findwhat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ImageList _imageList_device;
    }
}