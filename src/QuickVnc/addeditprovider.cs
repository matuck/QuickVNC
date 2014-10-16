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
    public partial class addeditprovider : Form
    {
        DataTable providerTable;
        DataRow provider;
        public addeditprovider(ref DataTable providerTable)
        {
            init(ref providerTable);
        }
        public addeditprovider(ref DataTable providerTable,DataRow provider = null, Boolean edit = false)
        {
            init(ref providerTable, edit, provider);
        }
        public void init(ref DataTable providerTable, Boolean edit = false, DataRow provider = null)
        {
            InitializeComponent();
            this.providerTable = providerTable;
            this.provider = provider;
            if (edit && provider != null)
            {
                setForEdit();
            }
            else
            {
                providertypeDropDown.SelectedItem = "Domain";
                setForDomain();
            }
        }
        private void providertypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            if(comboBox.SelectedItem.ToString() == "Domain")
            {
                setForDomain();
            }
            else if(comboBox.SelectedItem.ToString() == "Favorite")
            {
                setForFavorite();
            }
            else
            {
                throw new Exception("An invalid type was selected");
            }
            
        }

        private void setForEdit()
        {
            if (provider["type"].ToString() == "domain")
            {
                providertypeDropDown.SelectedItem = "Domain";
                setForDomain();
                pathbox.Text = provider["path"].ToString();
                usebuiltin.Checked = (Boolean) provider["usebuiltin"];
                if((Boolean) provider["usebuiltin"])
                {
                    usernamebox.Enabled = false;
                    passwordbox.Enabled = false;
                }
                else
                {
                    usernamebox.Text = provider["username"].ToString();
                    passwordbox.Text = provider["password"].ToString();
                }
            }
            else if (provider["type"].ToString() == "favorite")
            {
                providertypeDropDown.SelectedItem = "Favorite";
                pathbox.Text = provider["path"].ToString();
                setForFavorite();
            }
            else
            {
                MessageBox.Show("An invalid provider type was specified.");
                this.Close();
            }
            savebutton.Text = "Save";
            providertypeDropDown.Enabled = false;
        }
        private void setForFavorite()
        {
            pathlabel.Text = "Group Name";
            usernamelabel.Hide();
            usernamebox.Enabled = false;
            usernamebox.Hide();
            passwordlabel.Hide();
            passwordbox.Enabled = false;
            passwordbox.Hide();
            usebuiltin.Enabled = false;
            usebuiltin.Hide();
        }

        private void setForDomain()
        {
            pathlabel.Text = "Domain";
            usernamelabel.Show();
            usernamebox.Enabled = true;
            usernamebox.Show();
            passwordlabel.Show();
            passwordbox.Enabled = true;
            passwordbox.Show();
            usebuiltin.Enabled = true;
            usebuiltin.Show();
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void usebuiltin_CheckedChanged(object sender, EventArgs e)
        {
            if(((CheckBox) sender).Checked)
            {
                usernamebox.Text = "";
                usernamebox.Enabled = false;
                passwordbox.Text = "";
                passwordbox.Enabled = false;
            }
            else
            {
                usernamebox.Enabled = true;
                passwordbox.Enabled = true;
            }
        }

        private void savebutton_Click(object sender, EventArgs e)
        {
            if (!usebuiltin.Checked && (usernamebox.Text.ToString() == "" || passwordbox.Text.ToString() == "") && providertypeDropDown.SelectedItem.ToString().ToLower() == "domain")
            {
                MessageBox.Show("Use Built in has to be checked or both username and password have to be filled in");
            }
            else
            {
                if (savebutton.Text.ToString() == "Add")
                {
                    DataRow row = providerTable.NewRow();
                    row["path"] = pathbox.Text;
                    row["name"] = providertypeDropDown.SelectedItem.ToString() + ": " + pathbox.Text.ToString();
                    row["type"] = providertypeDropDown.SelectedItem.ToString().ToLower();
                    if (providerTable.Rows.Count == 0)
                    {
                        row["default"] = true;
                    }
                    else
                    {
                        row["default"] = false;
                    }
                    if (providertypeDropDown.SelectedItem.ToString().ToLower() == "domain")
                    {
                        row["usebuiltin"] = usebuiltin.Checked;
                        row["username"] = usernamebox.Text.ToString();
                        row["password"] = passwordbox.Text.ToString();
                    }
                    else if (providertypeDropDown.SelectedItem.ToString().ToLower() == "favorite")
                    {
                        row["usebuiltin"] = false;
                        row["username"] = "";
                        row["password"] = "";
                    }
                    providerTable.Rows.Add(row);
                }
                else if (savebutton.Text.ToString() == "Save")
                {
                    if (provider["type"].ToString() == "favorite")
                    {
                        provider["name"] = "Favorite: " + pathbox.Text;
                        provider["username"] = provider["path"];
                        provider["path"] = pathbox.Text;

                        provider.AcceptChanges();
                    }
                    else if (provider["type"].ToString() == "domain")
                    {
                        provider["name"] = "Domain: " + pathbox.Text;
                        provider["path"] = pathbox.Text;
                        provider["usebuiltin"] = usebuiltin.Checked;
                        if (usebuiltin.Checked)
                        {
                            provider["username"] = "";
                            provider["password"] = "";
                        }
                        else
                        {
                            provider["username"] = usernamebox.Text;
                            provider["password"] = passwordbox.Text;
                        }
                        provider.AcceptChanges();
                    }
                    else
                    {
                        throw new Exception("Invalid type cannot save.");
                    }
                }
                else
                {
                    throw new Exception("Invalid operation to save.");
                }
                this.Close();
            }
        }
    }
}
