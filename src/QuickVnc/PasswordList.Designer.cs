namespace QuickVnc
{
    partial class PasswordList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PasswordList));
            this.addnewpass = new System.Windows.Forms.Button();
            this.editpass = new System.Windows.Forms.Button();
            this.deletepass = new System.Windows.Forms.Button();
            this.cancelpass = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.default_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addnewpass
            // 
            this.addnewpass.Location = new System.Drawing.Point(98, 226);
            this.addnewpass.Name = "addnewpass";
            this.addnewpass.Size = new System.Drawing.Size(59, 23);
            this.addnewpass.TabIndex = 0;
            this.addnewpass.Text = "Add New";
            this.addnewpass.UseVisualStyleBackColor = true;
            this.addnewpass.Click += new System.EventHandler(this.addnewpass_Click);
            // 
            // editpass
            // 
            this.editpass.Location = new System.Drawing.Point(163, 227);
            this.editpass.Name = "editpass";
            this.editpass.Size = new System.Drawing.Size(52, 23);
            this.editpass.TabIndex = 1;
            this.editpass.Text = "Edit";
            this.editpass.UseVisualStyleBackColor = true;
            this.editpass.Click += new System.EventHandler(this.editpass_Click);
            // 
            // deletepass
            // 
            this.deletepass.Location = new System.Drawing.Point(221, 227);
            this.deletepass.Name = "deletepass";
            this.deletepass.Size = new System.Drawing.Size(53, 23);
            this.deletepass.TabIndex = 2;
            this.deletepass.Text = "Delete";
            this.deletepass.UseVisualStyleBackColor = true;
            this.deletepass.Click += new System.EventHandler(this.deletepass_Click);
            // 
            // cancelpass
            // 
            this.cancelpass.Location = new System.Drawing.Point(280, 227);
            this.cancelpass.Name = "cancelpass";
            this.cancelpass.Size = new System.Drawing.Size(52, 23);
            this.cancelpass.TabIndex = 3;
            this.cancelpass.Text = "Close";
            this.cancelpass.UseVisualStyleBackColor = true;
            this.cancelpass.Click += new System.EventHandler(this.cancelpass_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(13, 13);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(319, 199);
            this.listBox1.TabIndex = 4;
            // 
            // default_button
            // 
            this.default_button.Location = new System.Drawing.Point(17, 226);
            this.default_button.Name = "default_button";
            this.default_button.Size = new System.Drawing.Size(75, 23);
            this.default_button.TabIndex = 5;
            this.default_button.Text = "Default";
            this.default_button.UseVisualStyleBackColor = true;
            this.default_button.Click += new System.EventHandler(this.default_button_Click);
            // 
            // PasswordList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 262);
            this.Controls.Add(this.default_button);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.cancelpass);
            this.Controls.Add(this.deletepass);
            this.Controls.Add(this.editpass);
            this.Controls.Add(this.addnewpass);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(360, 300);
            this.MinimumSize = new System.Drawing.Size(360, 300);
            this.Name = "PasswordList";
            this.Text = "PasswordList";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button addnewpass;
        private System.Windows.Forms.Button editpass;
        private System.Windows.Forms.Button deletepass;
        private System.Windows.Forms.Button cancelpass;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button default_button;
    }
}