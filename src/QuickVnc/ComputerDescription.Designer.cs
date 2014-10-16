namespace QuickVnc
{
    partial class ComputerDescription
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComputerDescription));
            this.domainlabel = new System.Windows.Forms.Label();
            this.domaintextbox = new System.Windows.Forms.TextBox();
            this.descriptioncontrainer = new System.Windows.Forms.GroupBox();
            this.updatetotextbox = new System.Windows.Forms.TextBox();
            this.adtextbox = new System.Windows.Forms.TextBox();
            this.wmitextbox = new System.Windows.Forms.TextBox();
            this.updatetolabel = new System.Windows.Forms.Label();
            this.adlabel = new System.Windows.Forms.Label();
            this.wmilabel = new System.Windows.Forms.Label();
            this.oucontainer = new System.Windows.Forms.GroupBox();
            this.movetooulabel = new System.Windows.Forms.Label();
            this.ouselector = new System.Windows.Forms.TreeView();
            this.currentoulabel = new System.Windows.Forms.Label();
            this.currentoutextbox = new System.Windows.Forms.TextBox();
            this.updatedescbtn = new System.Windows.Forms.Button();
            this.moveoubtn = new System.Windows.Forms.Button();
            this.updateandmovebtn = new System.Windows.Forms.Button();
            this.closebtn = new System.Windows.Forms.Button();
            this.descriptioncontrainer.SuspendLayout();
            this.oucontainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // domainlabel
            // 
            this.domainlabel.AutoSize = true;
            this.domainlabel.Location = new System.Drawing.Point(14, 8);
            this.domainlabel.Name = "domainlabel";
            this.domainlabel.Size = new System.Drawing.Size(43, 13);
            this.domainlabel.TabIndex = 0;
            this.domainlabel.Text = "Domain";
            // 
            // domaintextbox
            // 
            this.domaintextbox.Location = new System.Drawing.Point(63, 5);
            this.domaintextbox.Name = "domaintextbox";
            this.domaintextbox.ReadOnly = true;
            this.domaintextbox.Size = new System.Drawing.Size(209, 20);
            this.domaintextbox.TabIndex = 1;
            // 
            // descriptioncontrainer
            // 
            this.descriptioncontrainer.Controls.Add(this.updatetotextbox);
            this.descriptioncontrainer.Controls.Add(this.adtextbox);
            this.descriptioncontrainer.Controls.Add(this.wmitextbox);
            this.descriptioncontrainer.Controls.Add(this.updatetolabel);
            this.descriptioncontrainer.Controls.Add(this.adlabel);
            this.descriptioncontrainer.Controls.Add(this.wmilabel);
            this.descriptioncontrainer.Location = new System.Drawing.Point(4, 32);
            this.descriptioncontrainer.Name = "descriptioncontrainer";
            this.descriptioncontrainer.Size = new System.Drawing.Size(278, 104);
            this.descriptioncontrainer.TabIndex = 2;
            this.descriptioncontrainer.TabStop = false;
            this.descriptioncontrainer.Text = "Computer Descripion";
            // 
            // updatetotextbox
            // 
            this.updatetotextbox.Location = new System.Drawing.Point(54, 71);
            this.updatetotextbox.Name = "updatetotextbox";
            this.updatetotextbox.Size = new System.Drawing.Size(218, 20);
            this.updatetotextbox.TabIndex = 5;
            // 
            // adtextbox
            // 
            this.adtextbox.Location = new System.Drawing.Point(43, 44);
            this.adtextbox.Name = "adtextbox";
            this.adtextbox.ReadOnly = true;
            this.adtextbox.Size = new System.Drawing.Size(229, 20);
            this.adtextbox.TabIndex = 4;
            // 
            // wmitextbox
            // 
            this.wmitextbox.Location = new System.Drawing.Point(43, 17);
            this.wmitextbox.Name = "wmitextbox";
            this.wmitextbox.ReadOnly = true;
            this.wmitextbox.Size = new System.Drawing.Size(229, 20);
            this.wmitextbox.TabIndex = 3;
            // 
            // updatetolabel
            // 
            this.updatetolabel.AutoSize = true;
            this.updatetolabel.Location = new System.Drawing.Point(6, 74);
            this.updatetolabel.Name = "updatetolabel";
            this.updatetolabel.Size = new System.Drawing.Size(42, 13);
            this.updatetolabel.TabIndex = 2;
            this.updatetolabel.Text = "Update";
            // 
            // adlabel
            // 
            this.adlabel.AutoSize = true;
            this.adlabel.Location = new System.Drawing.Point(6, 47);
            this.adlabel.Name = "adlabel";
            this.adlabel.Size = new System.Drawing.Size(22, 13);
            this.adlabel.TabIndex = 1;
            this.adlabel.Text = "AD";
            // 
            // wmilabel
            // 
            this.wmilabel.AutoSize = true;
            this.wmilabel.Location = new System.Drawing.Point(7, 20);
            this.wmilabel.Name = "wmilabel";
            this.wmilabel.Size = new System.Drawing.Size(30, 13);
            this.wmilabel.TabIndex = 0;
            this.wmilabel.Text = "WMI";
            // 
            // oucontainer
            // 
            this.oucontainer.Controls.Add(this.movetooulabel);
            this.oucontainer.Controls.Add(this.ouselector);
            this.oucontainer.Controls.Add(this.currentoulabel);
            this.oucontainer.Controls.Add(this.currentoutextbox);
            this.oucontainer.Location = new System.Drawing.Point(4, 141);
            this.oucontainer.Name = "oucontainer";
            this.oucontainer.Size = new System.Drawing.Size(277, 327);
            this.oucontainer.TabIndex = 3;
            this.oucontainer.TabStop = false;
            this.oucontainer.Text = "OU";
            // 
            // movetooulabel
            // 
            this.movetooulabel.AutoSize = true;
            this.movetooulabel.Location = new System.Drawing.Point(7, 54);
            this.movetooulabel.Name = "movetooulabel";
            this.movetooulabel.Size = new System.Drawing.Size(65, 13);
            this.movetooulabel.TabIndex = 3;
            this.movetooulabel.Text = "Move to OU";
            // 
            // ouselector
            // 
            this.ouselector.Location = new System.Drawing.Point(11, 70);
            this.ouselector.Name = "ouselector";
            this.ouselector.Size = new System.Drawing.Size(261, 249);
            this.ouselector.TabIndex = 2;
            // 
            // currentoulabel
            // 
            this.currentoulabel.AutoSize = true;
            this.currentoulabel.Location = new System.Drawing.Point(6, 22);
            this.currentoulabel.Name = "currentoulabel";
            this.currentoulabel.Size = new System.Drawing.Size(60, 13);
            this.currentoulabel.TabIndex = 1;
            this.currentoulabel.Text = "Current OU";
            // 
            // currentoutextbox
            // 
            this.currentoutextbox.Location = new System.Drawing.Point(72, 19);
            this.currentoutextbox.Name = "currentoutextbox";
            this.currentoutextbox.ReadOnly = true;
            this.currentoutextbox.Size = new System.Drawing.Size(200, 20);
            this.currentoutextbox.TabIndex = 0;
            // 
            // updatedescbtn
            // 
            this.updatedescbtn.Location = new System.Drawing.Point(13, 475);
            this.updatedescbtn.Name = "updatedescbtn";
            this.updatedescbtn.Size = new System.Drawing.Size(125, 25);
            this.updatedescbtn.TabIndex = 4;
            this.updatedescbtn.Text = "Update Description";
            this.updatedescbtn.UseVisualStyleBackColor = true;
            this.updatedescbtn.Click += new System.EventHandler(this.updatedescbtn_Click);
            // 
            // moveoubtn
            // 
            this.moveoubtn.Location = new System.Drawing.Point(148, 475);
            this.moveoubtn.Name = "moveoubtn";
            this.moveoubtn.Size = new System.Drawing.Size(125, 25);
            this.moveoubtn.TabIndex = 5;
            this.moveoubtn.Text = "Move OU";
            this.moveoubtn.UseVisualStyleBackColor = true;
            this.moveoubtn.Click += new System.EventHandler(this.moveoubtn_Click);
            // 
            // updateandmovebtn
            // 
            this.updateandmovebtn.Location = new System.Drawing.Point(13, 507);
            this.updateandmovebtn.Name = "updateandmovebtn";
            this.updateandmovebtn.Size = new System.Drawing.Size(259, 23);
            this.updateandmovebtn.TabIndex = 6;
            this.updateandmovebtn.Text = "Update Description and Move OU";
            this.updateandmovebtn.UseVisualStyleBackColor = true;
            this.updateandmovebtn.Click += new System.EventHandler(this.updateandmovebtn_Click);
            // 
            // closebtn
            // 
            this.closebtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closebtn.Location = new System.Drawing.Point(14, 536);
            this.closebtn.Name = "closebtn";
            this.closebtn.Size = new System.Drawing.Size(258, 33);
            this.closebtn.TabIndex = 7;
            this.closebtn.Text = "Close";
            this.closebtn.UseVisualStyleBackColor = true;
            this.closebtn.Click += new System.EventHandler(this.closebtn_Click);
            // 
            // ComputerDescription
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 576);
            this.Controls.Add(this.closebtn);
            this.Controls.Add(this.updateandmovebtn);
            this.Controls.Add(this.moveoubtn);
            this.Controls.Add(this.updatedescbtn);
            this.Controls.Add(this.oucontainer);
            this.Controls.Add(this.descriptioncontrainer);
            this.Controls.Add(this.domaintextbox);
            this.Controls.Add(this.domainlabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(300, 615);
            this.MinimumSize = new System.Drawing.Size(300, 615);
            this.Name = "ComputerDescription";
            this.Text = "ComputerDescription";
            this.descriptioncontrainer.ResumeLayout(false);
            this.descriptioncontrainer.PerformLayout();
            this.oucontainer.ResumeLayout(false);
            this.oucontainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label domainlabel;
        private System.Windows.Forms.TextBox domaintextbox;
        private System.Windows.Forms.GroupBox descriptioncontrainer;
        private System.Windows.Forms.TextBox updatetotextbox;
        private System.Windows.Forms.TextBox adtextbox;
        private System.Windows.Forms.TextBox wmitextbox;
        private System.Windows.Forms.Label updatetolabel;
        private System.Windows.Forms.Label adlabel;
        private System.Windows.Forms.Label wmilabel;
        private System.Windows.Forms.GroupBox oucontainer;
        private System.Windows.Forms.Label currentoulabel;
        private System.Windows.Forms.TextBox currentoutextbox;
        private System.Windows.Forms.Label movetooulabel;
        private System.Windows.Forms.TreeView ouselector;
        private System.Windows.Forms.Button updatedescbtn;
        private System.Windows.Forms.Button moveoubtn;
        private System.Windows.Forms.Button updateandmovebtn;
        private System.Windows.Forms.Button closebtn;
    }
}