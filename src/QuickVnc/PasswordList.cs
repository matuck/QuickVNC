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
    public partial class PasswordList : Form
    {
        private xmlpassword passwords;
        public PasswordList(ref xmlpassword passwords)
        {
            InitializeComponent();
            this.passwords = passwords;
            refreshlistbox();
        }

        private void cancelpass_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addnewpass_Click(object sender, EventArgs e)
        {
            add_editpass add = new add_editpass(ref this.passwords);
            add.ShowDialog();
            refreshlistbox();
        }

        private void editpass_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                add_editpass edit = new add_editpass(ref this.passwords);
                DataRow currentry = this.passwords.getpasswordentry(listBox1.SelectedItem.ToString());
                edit.edit(currentry["name"].ToString(), currentry["username"].ToString());
                edit.ShowDialog();
                refreshlistbox();
            }
        }

        private void deletepass_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                passwords.delete(listBox1.SelectedItem.ToString());
                refreshlistbox();
                DataRow[] rows = this.passwords.passlist.Select("default =  1");
                if(rows.Length == 0)
                {
                    DataRow defaultpassword = this.passwords.passlist.Rows[0];
                    String name = defaultpassword["name"].ToString();
                    String username = defaultpassword["username"].ToString();
                    String password = defaultpassword["password"].ToString();
                    passwords.delete(defaultpassword["name"].ToString());
                    passwords.add(name, username, password, true);
                    refreshlistbox();
                }
            }
        }
        private void refreshlistbox()
        {
            listBox1.Items.Clear();
            DataTable lists = passwords.values();
            foreach (DataRow currentry in lists.Rows)
            {
                listBox1.Items.Add(currentry["name"].ToString());
                if (((Boolean)currentry["default"]))
                {
                    listBox1.SelectedItem = currentry["name"];
                }
            }
        }

        private void default_button_Click(object sender, EventArgs e)
        {
            passwords.removedefault();
            try
            {
                DataRow defaultpassword = passwords.getpasswordentry(listBox1.SelectedItem.ToString());
                String name = defaultpassword["name"].ToString();
                String username = defaultpassword["username"].ToString();
                String password = defaultpassword["password"].ToString();
                passwords.delete(defaultpassword["name"].ToString());
                passwords.add(name, username, password, true);
            }
            catch
            {
                MessageBox.Show("You have to select a password first!");
            }
        }
    }
}
