namespace ACS.Advanced_IP
{
    partial class _Form_Login
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
            this._lab_username = new System.Windows.Forms.Label();
            this._lab_passwd = new System.Windows.Forms.Label();
            this._textB_username = new System.Windows.Forms.TextBox();
            this._textB_passwd = new System.Windows.Forms.TextBox();
            this._butt_login = new System.Windows.Forms.Button();
            this._butt_config = new System.Windows.Forms.Button();
            this._groupB_loginConfig = new System.Windows.Forms.GroupBox();
            this._button_testConDB = new System.Windows.Forms.Button();
            this._textBox_passwdDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this._button_browserDB = new System.Windows.Forms.Button();
            this._label_selectDB = new System.Windows.Forms.Label();
            this._textBox_linkFileDB = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._groupB_loginConfig.SuspendLayout();
            this.SuspendLayout();
            // 
            // _lab_username
            // 
            this._lab_username.AutoSize = true;
            this._lab_username.BackColor = System.Drawing.SystemColors.Window;
            this._lab_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lab_username.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._lab_username.Location = new System.Drawing.Point(26, 34);
            this._lab_username.Name = "_lab_username";
            this._lab_username.Size = new System.Drawing.Size(81, 15);
            this._lab_username.TabIndex = 0;
            this._lab_username.Text = "Username: ";
            // 
            // _lab_passwd
            // 
            this._lab_passwd.AutoSize = true;
            this._lab_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lab_passwd.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this._lab_passwd.Location = new System.Drawing.Point(26, 67);
            this._lab_passwd.Name = "_lab_passwd";
            this._lab_passwd.Size = new System.Drawing.Size(77, 15);
            this._lab_passwd.TabIndex = 1;
            this._lab_passwd.Text = "Password: ";
            this._lab_passwd.Click += new System.EventHandler(this.label1_Click);
            // 
            // _textB_username
            // 
            this._textB_username.Location = new System.Drawing.Point(114, 34);
            this._textB_username.Name = "_textB_username";
            this._textB_username.Size = new System.Drawing.Size(171, 20);
            this._textB_username.TabIndex = 2;
            // 
            // _textB_passwd
            // 
            this._textB_passwd.Location = new System.Drawing.Point(114, 67);
            this._textB_passwd.Name = "_textB_passwd";
            this._textB_passwd.PasswordChar = '*';
            this._textB_passwd.Size = new System.Drawing.Size(171, 20);
            this._textB_passwd.TabIndex = 3;
            // 
            // _butt_login
            // 
            this._butt_login.BackColor = System.Drawing.Color.White;
            this._butt_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butt_login.ForeColor = System.Drawing.Color.DimGray;
            this._butt_login.Location = new System.Drawing.Point(310, 30);
            this._butt_login.Name = "_butt_login";
            this._butt_login.Size = new System.Drawing.Size(82, 26);
            this._butt_login.TabIndex = 4;
            this._butt_login.Text = "Login";
            this._butt_login.UseVisualStyleBackColor = false;
            this._butt_login.Click += new System.EventHandler(this.button1_Click);
            // 
            // _butt_config
            // 
            this._butt_config.BackColor = System.Drawing.Color.White;
            this._butt_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._butt_config.ForeColor = System.Drawing.SystemColors.GrayText;
            this._butt_config.Location = new System.Drawing.Point(310, 63);
            this._butt_config.Name = "_butt_config";
            this._butt_config.Size = new System.Drawing.Size(82, 26);
            this._butt_config.TabIndex = 5;
            this._butt_config.Text = "Config >>";
            this._butt_config.UseVisualStyleBackColor = false;
            this._butt_config.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // _groupB_loginConfig
            // 
            this._groupB_loginConfig.Controls.Add(this._button_testConDB);
            this._groupB_loginConfig.Controls.Add(this._textBox_passwdDB);
            this._groupB_loginConfig.Controls.Add(this.label1);
            this._groupB_loginConfig.Controls.Add(this._button_browserDB);
            this._groupB_loginConfig.Controls.Add(this._label_selectDB);
            this._groupB_loginConfig.Controls.Add(this._textBox_linkFileDB);
            this._groupB_loginConfig.Location = new System.Drawing.Point(29, 110);
            this._groupB_loginConfig.Name = "_groupB_loginConfig";
            this._groupB_loginConfig.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this._groupB_loginConfig.Size = new System.Drawing.Size(363, 119);
            this._groupB_loginConfig.TabIndex = 6;
            this._groupB_loginConfig.TabStop = false;
            this._groupB_loginConfig.Text = "Login config";
            this._groupB_loginConfig.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // _button_testConDB
            // 
            this._button_testConDB.Location = new System.Drawing.Point(238, 87);
            this._button_testConDB.Name = "_button_testConDB";
            this._button_testConDB.Size = new System.Drawing.Size(118, 23);
            this._button_testConDB.TabIndex = 5;
            this._button_testConDB.Text = "Test connection";
            this._button_testConDB.UseVisualStyleBackColor = true;
            this._button_testConDB.Click += new System.EventHandler(this._button_testConDB_Click);
            // 
            // _textBox_passwdDB
            // 
            this._textBox_passwdDB.Location = new System.Drawing.Point(6, 87);
            this._textBox_passwdDB.Name = "_textBox_passwdDB";
            this._textBox_passwdDB.PasswordChar = '*';
            this._textBox_passwdDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._textBox_passwdDB.Size = new System.Drawing.Size(171, 20);
            this._textBox_passwdDB.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Passwd database";
            // 
            // _button_browserDB
            // 
            this._button_browserDB.Location = new System.Drawing.Point(282, 33);
            this._button_browserDB.Name = "_button_browserDB";
            this._button_browserDB.Size = new System.Drawing.Size(75, 23);
            this._button_browserDB.TabIndex = 2;
            this._button_browserDB.Text = "Open";
            this._button_browserDB.UseVisualStyleBackColor = true;
            this._button_browserDB.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // _label_selectDB
            // 
            this._label_selectDB.AutoSize = true;
            this._label_selectDB.Location = new System.Drawing.Point(5, 16);
            this._label_selectDB.Name = "_label_selectDB";
            this._label_selectDB.Size = new System.Drawing.Size(84, 13);
            this._label_selectDB.TabIndex = 1;
            this._label_selectDB.Text = "Select database";
            // 
            // _textBox_linkFileDB
            // 
            this._textBox_linkFileDB.Location = new System.Drawing.Point(6, 35);
            this._textBox_linkFileDB.Name = "_textBox_linkFileDB";
            this._textBox_linkFileDB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._textBox_linkFileDB.Size = new System.Drawing.Size(266, 20);
            this._textBox_linkFileDB.TabIndex = 0;
            this._textBox_linkFileDB.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(139, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 7;
            // 
            // _Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(426, 251);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._groupB_loginConfig);
            this.Controls.Add(this._butt_config);
            this.Controls.Add(this._butt_login);
            this.Controls.Add(this._textB_passwd);
            this.Controls.Add(this._textB_username);
            this.Controls.Add(this._lab_passwd);
            this.Controls.Add(this._lab_username);
            this.MaximumSize = new System.Drawing.Size(442, 290);
            this.MinimumSize = new System.Drawing.Size(442, 148);
            this.Name = "_Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACS.Advanced IP - Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this._groupB_loginConfig.ResumeLayout(false);
            this._groupB_loginConfig.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lab_username;
        private System.Windows.Forms.Label _lab_passwd;
        private System.Windows.Forms.TextBox _textB_username;
        private System.Windows.Forms.TextBox _textB_passwd;
        private System.Windows.Forms.Button _butt_login;
        private System.Windows.Forms.Button _butt_config;
        private System.Windows.Forms.GroupBox _groupB_loginConfig;
        private System.Windows.Forms.TextBox _textBox_linkFileDB;
        private System.Windows.Forms.Label _label_selectDB;
        private System.Windows.Forms.Button _button_browserDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _textBox_passwdDB;
        private System.Windows.Forms.Button _button_testConDB;
        private System.Windows.Forms.Label label2;
    }
}

