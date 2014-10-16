namespace QuickVnc
{
    partial class userpassdialog
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
            this.cancel = new System.Windows.Forms.Button();
            this.ok = new System.Windows.Forms.Button();
            this.domain = new System.Windows.Forms.RadioButton();
            this.local = new System.Windows.Forms.RadioButton();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancel
            // 
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Location = new System.Drawing.Point(147, 92);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 0;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            // 
            // ok
            // 
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(66, 92);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 1;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // domain
            // 
            this.domain.AutoSize = true;
            this.domain.Checked = true;
            this.domain.Location = new System.Drawing.Point(66, 69);
            this.domain.Name = "domain";
            this.domain.Size = new System.Drawing.Size(61, 17);
            this.domain.TabIndex = 2;
            this.domain.TabStop = true;
            this.domain.Text = "Domain";
            this.domain.UseVisualStyleBackColor = true;
            // 
            // local
            // 
            this.local.AutoSize = true;
            this.local.Location = new System.Drawing.Point(147, 69);
            this.local.Name = "local";
            this.local.Size = new System.Drawing.Size(51, 17);
            this.local.TabIndex = 3;
            this.local.TabStop = true;
            this.local.Text = "Local";
            this.local.UseVisualStyleBackColor = true;
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(70, 14);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(152, 20);
            this.username.TabIndex = 4;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(70, 43);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(152, 20);
            this.password.TabIndex = 5;
            // 
            // usernamelabel
            // 
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Location = new System.Drawing.Point(9, 17);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(55, 13);
            this.usernamelabel.TabIndex = 6;
            this.usernamelabel.Text = "Username";
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(12, 46);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(53, 13);
            this.passwordlabel.TabIndex = 7;
            this.passwordlabel.Text = "Password";
            // 
            // userpassdialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.ClientSize = new System.Drawing.Size(234, 121);
            this.ControlBox = false;
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.usernamelabel);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.local);
            this.Controls.Add(this.domain);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.cancel);
            this.MaximumSize = new System.Drawing.Size(250, 160);
            this.MinimumSize = new System.Drawing.Size(250, 160);
            this.Name = "userpassdialog";
            this.Text = "Set User & Password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button ok;
        public System.Windows.Forms.RadioButton domain;
        public System.Windows.Forms.RadioButton local;
        public System.Windows.Forms.TextBox username;
        public System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.Label passwordlabel;
    }
}