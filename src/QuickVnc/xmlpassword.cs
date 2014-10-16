using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Data;

namespace QuickVnc
{
    public class xmlpassword
    {
        private string passwordpath;
        private XmlElement root;
        private XmlDocument xmldoc = new XmlDocument();
        public DataTable passlist;
        public xmlpassword(string configpath)
        {
            this.passwordpath = configpath + "\\passwords.xml";
            if(File.Exists(this.passwordpath))
            {
                this.xmldoc.Load(this.passwordpath);
                this.root = this.xmldoc.DocumentElement;
            }
            else
            {
                XmlDeclaration dec = this.xmldoc.CreateXmlDeclaration("1.0", null, null);
                this.xmldoc.AppendChild(dec);
                //create the root element
                this.root = this.xmldoc.CreateElement("Passwords");
                this.xmldoc.AppendChild(this.root);
            }
            this.createPasslistDataTable();
            this.reloadPassListDataTableEntries();
        }

        public void add(string name, string username, string password, bool defaultpassword = false)
        {
            StringEncryption encryptpass = new StringEncryption();
            password = encryptpass.EncryptString(password);
            XmlElement elementpassword = xmldoc.CreateElement("Password");
            elementpassword.SetAttribute("Name", name);
            elementpassword.SetAttribute("Username", username);
            elementpassword.SetAttribute("Password", password);
            if (defaultpassword || this.passlist.Rows.Count == 0)
            {
                elementpassword.SetAttribute("Default", "true");
            }
            this.root.AppendChild(elementpassword);
            this.xmldoc.Save(this.passwordpath);
            this.reloadPassListDataTableEntries();
        }
        public void delete(string name)
        {
            XmlNode delnode = this.xmldoc.SelectSingleNode("Passwords/Password[@Name='" + name.ToString() + "']");
            delnode.ParentNode.RemoveChild(delnode);
            this.xmldoc.Save(this.passwordpath);
            this.reloadPassListDataTableEntries();
        }

        public DataTable values()
        {
            return passlist;
        }

        public DataRow getpasswordentry(string name)
        {
            DataRow[] rows = passlist.Select(String.Format("name = '{0}'", name.ToString()));
            return rows[0];
        }
        public void removedefault()
        {
            XmlNodeList delnodes = this.xmldoc.SelectNodes("Passwords/Password[@Default='true']");
            foreach (XmlNode delnode in delnodes)
            {
                try
                {
                    DataRow removedefault = getpasswordentry(delnode.Attributes.GetNamedItem("Name").Value);
                    delnode.ParentNode.RemoveChild(delnode);
                    this.xmldoc.Save(this.passwordpath);
                    add(removedefault["name"].ToString(), removedefault["username"].ToString(), removedefault["password"].ToString(), false);
                }
                catch (RowNotInTableException)
                {
                    //just means there was no default password already.  not doing anything here.
                }
            }
        }

        public String getDefaultPasswordName()
        {
            DataRow[] rows = passlist.Select("default = 1");
            return rows[0]["name"].ToString();
        }

        ///////////////////////////
        // HELPERS
        ///////////////////////////

        private void createPasslistDataTable()
        {
            passlist = new DataTable();
            DataColumn column;

            //add table columns
            //add name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            passlist.Columns.Add(column);

            //add username column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "username";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            passlist.Columns.Add(column);

            //add password column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "password";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            passlist.Columns.Add(column);

            //add default column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "default";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            passlist.Columns.Add(column);
        }

        private void reloadPassListDataTableEntries()
        {
            passlist.Rows.Clear();
            DataRow row;

            XmlNodeList nodes = this.xmldoc.SelectNodes("Passwords/Password");
            foreach (XmlNode node in nodes)
            {
                row = passlist.NewRow();
                row["name"] = node.Attributes.GetNamedItem("Name").Value;
                row["username"] = node.Attributes.GetNamedItem("Username").Value;
                StringEncryption decryptpass = new StringEncryption();
                row["password"] = decryptpass.DecryptString(node.Attributes.GetNamedItem("Password").Value);
                try
                {
                    if (node.Attributes.GetNamedItem("Default").Value == "true")
                    {
                        row["default"] = true;
                    }
                    else
                    {
                        row["default"] = false;
                    }
                }
                catch
                {
                    row["default"] = false;
                }
                passlist.Rows.Add(row);
            }
        }
    }
}
