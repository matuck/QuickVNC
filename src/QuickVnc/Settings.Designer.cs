namespace QuickVnc
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.vncpathbox = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Cancel = new System.Windows.Forms.Button();
            this.save = new System.Windows.Forms.Button();
            this.providerbox = new System.Windows.Forms.ListBox();
            this.deleteprovider = new System.Windows.Forms.Button();
            this.editprovider = new System.Windows.Forms.Button();
            this.addprovider = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.defaultprovider = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Search Providers";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Vnc Path";
            // 
            // vncpathbox
            // 
            this.vncpathbox.Location = new System.Drawing.Point(63, 6);
            this.vncpathbox.Name = "vncpathbox";
            this.vncpathbox.Size = new System.Drawing.Size(348, 20);
            this.vncpathbox.TabIndex = 3;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(417, 6);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(75, 23);
            this.browse.TabIndex = 4;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Cancel
            // 
            this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Cancel.Location = new System.Drawing.Point(419, 172);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 5;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // save
            // 
            this.save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.save.Location = new System.Drawing.Point(336, 172);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 6;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // providerbox
            // 
            this.providerbox.FormattingEnabled = true;
            this.providerbox.Location = new System.Drawing.Point(103, 55);
            this.providerbox.Name = "providerbox";
            this.providerbox.Size = new System.Drawing.Size(366, 82);
            this.providerbox.TabIndex = 7;
            // 
            // deleteprovider
            // 
            this.deleteprovider.Location = new System.Drawing.Point(381, 143);
            this.deleteprovider.Name = "deleteprovider";
            this.deleteprovider.Size = new System.Drawing.Size(88, 23);
            this.deleteprovider.TabIndex = 8;
            this.deleteprovider.Text = "Delete Provider";
            this.deleteprovider.UseVisualStyleBackColor = true;
            this.deleteprovider.Click += new System.EventHandler(this.deleteprovider_Click);
            // 
            // editprovider
            // 
            this.editprovider.Location = new System.Drawing.Point(300, 143);
            this.editprovider.Name = "editprovider";
            this.editprovider.Size = new System.Drawing.Size(75, 23);
            this.editprovider.TabIndex = 9;
            this.editprovider.Text = "Edit Provider";
            this.editprovider.UseVisualStyleBackColor = true;
            this.editprovider.Click += new System.EventHandler(this.editprovider_Click);
            // 
            // addprovider
            // 
            this.addprovider.Location = new System.Drawing.Point(209, 143);
            this.addprovider.Name = "addprovider";
            this.addprovider.Size = new System.Drawing.Size(85, 23);
            this.addprovider.TabIndex = 10;
            this.addprovider.Text = "Add Provider";
            this.addprovider.UseVisualStyleBackColor = true;
            this.addprovider.Click += new System.EventHandler(this.addprovider_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "To make a domain default just select it.";
            // 
            // defaultprovider
            // 
            this.defaultprovider.Location = new System.Drawing.Point(103, 143);
            this.defaultprovider.Name = "defaultprovider";
            this.defaultprovider.Size = new System.Drawing.Size(97, 23);
            this.defaultprovider.TabIndex = 12;
            this.defaultprovider.Text = "Default Provider";
            this.defaultprovider.UseVisualStyleBackColor = true;
            this.defaultprovider.Click += new System.EventHandler(this.defaultprovider_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 206);
            this.Controls.Add(this.defaultprovider);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.addprovider);
            this.Controls.Add(this.editprovider);
            this.Controls.Add(this.deleteprovider);
            this.Controls.Add(this.providerbox);
            this.Controls.Add(this.save);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.vncpathbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(520, 245);
            this.MinimumSize = new System.Drawing.Size(520, 245);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox vncpathbox;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Cancel;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.ListBox providerbox;
        private System.Windows.Forms.Button deleteprovider;
        private System.Windows.Forms.Button editprovider;
        private System.Windows.Forms.Button addprovider;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button defaultprovider;
    }
}