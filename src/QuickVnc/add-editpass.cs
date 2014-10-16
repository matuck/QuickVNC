using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuickVnc
{
    public partial class add_editpass : Form
    {
        private xmlpassword passwords;
        private string action = "";
        public add_editpass(ref xmlpassword passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
        }

        public void edit(string name, string username)
        {
            MessageBox.Show("You must reenter your password or hit cancel!");
            this.namebox.Text = name.ToString();
            this.namebox.Enabled = false;
            this.usernamebox.Text = username.ToString();
            this.action = "edit";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (namebox.Text.ToString() != "" && usernamebox.Text.ToString() != "" && passwordbox.Text.ToString() != "")
            {
                Boolean defaultpass = false;
                if (this.action.ToString() == "edit")
                {
                    DataRow row = this.passwords.passlist.Select(String.Format("name = '{0}'", namebox.Text.ToString()))[0];
                    MessageBox.Show("test");
                    defaultpass = (Boolean) row["default"];
                    this.passwords.delete(namebox.Text.ToString());
                }
                //check for current entry
                try
                {
                    DataRow currentry = this.passwords.getpasswordentry(namebox.Text.ToString());
                    MessageBox.Show("A password entry with this name already exists!");
                }
                catch (IndexOutOfRangeException)
                {
                    this.passwords.add(namebox.Text.ToString(), usernamebox.Text.ToString(), passwordbox.Text.ToString(), defaultpass);
                    this.Close();
                }
            }
            else
            {
               MessageBox.Show("Name, Username, and Password all have to be filled in!");
            }
        }

    }
}
