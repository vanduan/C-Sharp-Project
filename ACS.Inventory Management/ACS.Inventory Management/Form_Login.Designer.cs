namespace ACS.Inventory_Management
{
    partial class Form_Login
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
            this._label_user = new System.Windows.Forms.Label();
            this._textBox_username = new System.Windows.Forms.TextBox();
            this._label_passwd = new System.Windows.Forms.Label();
            this._textBox_passwd = new System.Windows.Forms.TextBox();
            this._button_login = new System.Windows.Forms.Button();
            this._button_config = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._button_test_conn = new System.Windows.Forms.Button();
            this._button_browser_file_db = new System.Windows.Forms.Button();
            this._textBox_passwd_file_db = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this._textBox_file_db = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _label_user
            // 
            this._label_user.AutoSize = true;
            this._label_user.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._label_user.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._label_user.Location = new System.Drawing.Point(22, 24);
            this._label_user.Name = "_label_user";
            this._label_user.Size = new System.Drawing.Size(71, 15);
            this._label_user.TabIndex = 0;
            this._label_user.Text = "Username: ";
            // 
            // _textBox_username
            // 
            this._textBox_username.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox_username.Location = new System.Drawing.Point(110, 24);
            this._textBox_username.Name = "_textBox_username";
            this._textBox_username.Size = new System.Drawing.Size(195, 21);
            this._textBox_username.TabIndex = 1;
            // 
            // _label_passwd
            // 
            this._label_passwd.AutoSize = true;
            this._label_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._label_passwd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._label_passwd.Location = new System.Drawing.Point(22, 62);
            this._label_passwd.Name = "_label_passwd";
            this._label_passwd.Size = new System.Drawing.Size(67, 15);
            this._label_passwd.TabIndex = 2;
            this._label_passwd.Text = "Password: ";
            // 
            // _textBox_passwd
            // 
            this._textBox_passwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox_passwd.Location = new System.Drawing.Point(110, 62);
            this._textBox_passwd.Name = "_textBox_passwd";
            this._textBox_passwd.PasswordChar = '*';
            this._textBox_passwd.Size = new System.Drawing.Size(195, 21);
            this._textBox_passwd.TabIndex = 3;
            // 
            // _button_login
            // 
            this._button_login.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._button_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button_login.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._button_login.Location = new System.Drawing.Point(329, 21);
            this._button_login.Name = "_button_login";
            this._button_login.Size = new System.Drawing.Size(75, 23);
            this._button_login.TabIndex = 4;
            this._button_login.Text = "Login";
            this._button_login.UseVisualStyleBackColor = false;
            this._button_login.Click += new System.EventHandler(this._button_login_Click);
            // 
            // _button_config
            // 
            this._button_config.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._button_config.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button_config.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._button_config.Location = new System.Drawing.Point(329, 60);
            this._button_config.Name = "_button_config";
            this._button_config.Size = new System.Drawing.Size(75, 23);
            this._button_config.TabIndex = 5;
            this._button_config.Text = "Config >>";
            this._button_config.UseVisualStyleBackColor = false;
            this._button_config.Click += new System.EventHandler(this._button_config_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._button_test_conn);
            this.groupBox1.Controls.Add(this._button_browser_file_db);
            this.groupBox1.Controls.Add(this._textBox_passwd_file_db);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this._textBox_file_db);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(402, 113);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Database config";
            // 
            // _button_test_conn
            // 
            this._button_test_conn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._button_test_conn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button_test_conn.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._button_test_conn.Location = new System.Drawing.Point(252, 81);
            this._button_test_conn.Name = "_button_test_conn";
            this._button_test_conn.Size = new System.Drawing.Size(140, 23);
            this._button_test_conn.TabIndex = 9;
            this._button_test_conn.Text = "Test connection";
            this._button_test_conn.UseVisualStyleBackColor = false;
            this._button_test_conn.Click += new System.EventHandler(this.button1_Click);
            // 
            // _button_browser_file_db
            // 
            this._button_browser_file_db.BackColor = System.Drawing.SystemColors.ButtonFace;
            this._button_browser_file_db.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button_browser_file_db.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this._button_browser_file_db.Location = new System.Drawing.Point(317, 28);
            this._button_browser_file_db.Name = "_button_browser_file_db";
            this._button_browser_file_db.Size = new System.Drawing.Size(75, 23);
            this._button_browser_file_db.TabIndex = 7;
            this._button_browser_file_db.Text = "Open";
            this._button_browser_file_db.UseVisualStyleBackColor = false;
            this._button_browser_file_db.Click += new System.EventHandler(this._button_browser_file_db_Click);
            // 
            // _textBox_passwd_file_db
            // 
            this._textBox_passwd_file_db.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox_passwd_file_db.Location = new System.Drawing.Point(13, 81);
            this._textBox_passwd_file_db.Name = "_textBox_passwd_file_db";
            this._textBox_passwd_file_db.PasswordChar = '*';
            this._textBox_passwd_file_db.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._textBox_passwd_file_db.Size = new System.Drawing.Size(195, 21);
            this._textBox_passwd_file_db.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Password for database";
            // 
            // _textBox_file_db
            // 
            this._textBox_file_db.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._textBox_file_db.Location = new System.Drawing.Point(13, 29);
            this._textBox_file_db.Name = "_textBox_file_db";
            this._textBox_file_db.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._textBox_file_db.Size = new System.Drawing.Size(280, 21);
            this._textBox_file_db.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File database";
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(426, 230);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this._button_config);
            this.Controls.Add(this._button_login);
            this.Controls.Add(this._textBox_passwd);
            this.Controls.Add(this._label_passwd);
            this.Controls.Add(this._textBox_username);
            this.Controls.Add(this._label_user);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.MaximumSize = new System.Drawing.Size(442, 269);
            this.MinimumSize = new System.Drawing.Size(442, 136);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACS.2016 IT Storage Management - Login";
            this.Load += new System.EventHandler(this.Form_Login_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _label_user;
        private System.Windows.Forms.TextBox _textBox_username;
        private System.Windows.Forms.Label _label_passwd;
        private System.Windows.Forms.TextBox _textBox_passwd;
        private System.Windows.Forms.Button _button_login;
        private System.Windows.Forms.Button _button_config;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _button_test_conn;
        private System.Windows.Forms.Button _button_browser_file_db;
        private System.Windows.Forms.TextBox _textBox_passwd_file_db;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox _textBox_file_db;
        private System.Windows.Forms.Label label1;
    }
}

