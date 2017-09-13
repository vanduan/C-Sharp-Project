namespace ACS.Advanced_IP
{
    partial class _Form_Main
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
            this._button_treeview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _button_treeview
            // 
            this._button_treeview.BackColor = System.Drawing.Color.Chocolate;
            this._button_treeview.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this._button_treeview.FlatAppearance.BorderSize = 0;
            this._button_treeview.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._button_treeview.Image = global::ACS.Advanced_IP.Properties.Resources.asymmetric_network;
            this._button_treeview.Location = new System.Drawing.Point(33, 32);
            this._button_treeview.Name = "_button_treeview";
            this._button_treeview.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._button_treeview.Size = new System.Drawing.Size(120, 110);
            this._button_treeview.TabIndex = 0;
            this._button_treeview.UseVisualStyleBackColor = false;
            this._button_treeview.Click += new System.EventHandler(this._button_treeview_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label1.Location = new System.Drawing.Point(53, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tree view";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // _Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(504, 317);
            this.Controls.Add(this._button_treeview);
            this.Controls.Add(this.label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "_Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACS.Advanced IP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _button_treeview;
        private System.Windows.Forms.Label label1;
    }
}