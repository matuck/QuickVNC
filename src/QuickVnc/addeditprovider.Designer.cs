namespace QuickVnc
{
    partial class addeditprovider
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(addeditprovider));
            this.providertypeDropDown = new System.Windows.Forms.ComboBox();
            this.providertypeLabel = new System.Windows.Forms.Label();
            this.pathlabel = new System.Windows.Forms.Label();
            this.pathbox = new System.Windows.Forms.TextBox();
            this.usebuiltin = new System.Windows.Forms.CheckBox();
            this.usernamebox = new System.Windows.Forms.TextBox();
            this.usernamelabel = new System.Windows.Forms.Label();
            this.passwordbox = new System.Windows.Forms.TextBox();
            this.passwordlabel = new System.Windows.Forms.Label();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.savebutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // providertypeDropDown
            // 
            this.providertypeDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.providertypeDropDown.FormattingEnabled = true;
            this.providertypeDropDown.Items.AddRange(new object[] {
            "Domain",
            "Favorite"});
            this.providertypeDropDown.Location = new System.Drawing.Point(50, 13);
            this.providertypeDropDown.Name = "providertypeDropDown";
            this.providertypeDropDown.Size = new System.Drawing.Size(222, 21);
            this.providertypeDropDown.TabIndex = 0;
            this.providertypeDropDown.SelectedIndexChanged += new System.EventHandler(this.providertypeDropDown_SelectedIndexChanged);
            // 
            // providertypeLabel
            // 
            this.providertypeLabel.AutoSize = true;
            this.providertypeLabel.Location = new System.Drawing.Point(13, 13);
            this.providertypeLabel.Name = "providertypeLabel";
            this.providertypeLabel.Size = new System.Drawing.Size(31, 13);
            this.providertypeLabel.TabIndex = 1;
            this.providertypeLabel.Text = "Type";
            // 
            // pathlabel
            // 
            this.pathlabel.Location = new System.Drawing.Point(16, 70);
            this.pathlabel.Name = "pathlabel";
            this.pathlabel.Size = new System.Drawing.Size(50, 32);
            this.pathlabel.TabIndex = 2;
            this.pathlabel.Text = "Group Name";
            // 
            // pathbox
            // 
            this.pathbox.Location = new System.Drawing.Point(65, 70);
            this.pathbox.Name = "pathbox";
            this.pathbox.Size = new System.Drawing.Size(207, 20);
            this.pathbox.TabIndex = 3;
            // 
            // usebuiltin
            // 
            this.usebuiltin.AutoSize = true;
            this.usebuiltin.Location = new System.Drawing.Point(65, 107);
            this.usebuiltin.Name = "usebuiltin";
            this.usebuiltin.Size = new System.Drawing.Size(79, 17);
            this.usebuiltin.TabIndex = 4;
            this.usebuiltin.Text = "Use Built in";
            this.usebuiltin.UseVisualStyleBackColor = true;
            this.usebuiltin.CheckedChanged += new System.EventHandler(this.usebuiltin_CheckedChanged);
            // 
            // usernamebox
            // 
            this.usernamebox.Location = new System.Drawing.Point(74, 140);
            this.usernamebox.Name = "usernamebox";
            this.usernamebox.Size = new System.Drawing.Size(198, 20);
            this.usernamebox.TabIndex = 5;
            // 
            // usernamelabel
            // 
            this.usernamelabel.AutoSize = true;
            this.usernamelabel.Location = new System.Drawing.Point(13, 147);
            this.usernamelabel.Name = "usernamelabel";
            this.usernamelabel.Size = new System.Drawing.Size(55, 13);
            this.usernamelabel.TabIndex = 6;
            this.usernamelabel.Text = "Username";
            // 
            // passwordbox
            // 
            this.passwordbox.Location = new System.Drawing.Point(74, 167);
            this.passwordbox.Name = "passwordbox";
            this.passwordbox.Size = new System.Drawing.Size(198, 20);
            this.passwordbox.TabIndex = 7;
            // 
            // passwordlabel
            // 
            this.passwordlabel.AutoSize = true;
            this.passwordlabel.Location = new System.Drawing.Point(13, 173);
            this.passwordlabel.Name = "passwordlabel";
            this.passwordlabel.Size = new System.Drawing.Size(53, 13);
            this.passwordlabel.TabIndex = 8;
            this.passwordlabel.Text = "Password";
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(196, 194);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 9;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // savebutton
            // 
            this.savebutton.Location = new System.Drawing.Point(115, 194);
            this.savebutton.Name = "savebutton";
            this.savebutton.Size = new System.Drawing.Size(75, 23);
            this.savebutton.TabIndex = 10;
            this.savebutton.Text = "Add";
            this.savebutton.UseVisualStyleBackColor = true;
            this.savebutton.Click += new System.EventHandler(this.savebutton_Click);
            // 
            // addeditprovider
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 226);
            this.Controls.Add(this.savebutton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.passwordlabel);
            this.Controls.Add(this.passwordbox);
            this.Controls.Add(this.usernamelabel);
            this.Controls.Add(this.usernamebox);
            this.Controls.Add(this.usebuiltin);
            this.Controls.Add(this.pathbox);
            this.Controls.Add(this.pathlabel);
            this.Controls.Add(this.providertypeLabel);
            this.Controls.Add(this.providertypeDropDown);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 265);
            this.MinimumSize = new System.Drawing.Size(300, 265);
            this.Name = "addeditprovider";
            this.Text = "Add Search Provider";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox providertypeDropDown;
        private System.Windows.Forms.Label providertypeLabel;
        private System.Windows.Forms.Label pathlabel;
        private System.Windows.Forms.TextBox pathbox;
        private System.Windows.Forms.CheckBox usebuiltin;
        private System.Windows.Forms.TextBox usernamebox;
        private System.Windows.Forms.Label usernamelabel;
        private System.Windows.Forms.TextBox passwordbox;
        private System.Windows.Forms.Label passwordlabel;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.Button savebutton;
    }
}