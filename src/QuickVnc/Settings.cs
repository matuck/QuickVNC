using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace QuickVnc
{
    public partial class Settings : Form
    {
        private string settingspath;
        public string vncpath;
        private XmlDocument xmldoc = new XmlDocument();
        private XmlElement root;
        private XmlNode domainroot;
        public DataTable searchProviders;
        public Settings(string configpath)
        {
            InitializeComponent();
            this.settingspath = configpath + "\\settings.xml";
            loadsettings();
            createSearchProviderDataTable();
            reloadSearchProvidersDataTableEntries();
            providerbox.DataSource = searchProviders;
            providerbox.DisplayMember = "name";
            vncpathbox.Text = this.vncpath.ToString();
        }

        private void browse_Click(object sender, EventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo(this.vncpath);
            openFileDialog1.InitialDirectory = di.Parent.ToString();
            openFileDialog1.FileName = di.Name;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                vncpathbox.Text = openFileDialog1.FileName;
            }
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void loadsettings()
        {
            if(File.Exists(this.settingspath))
            {
                try
                {
                    this.xmldoc.Load(this.settingspath);
                    this.root = this.xmldoc.DocumentElement;
                    this.domainroot = this.xmldoc.SelectSingleNode("Settings/Domains");
                    XmlNode nodevncpath = this.xmldoc.SelectSingleNode("Settings/vncpath");
                    this.vncpath = nodevncpath.InnerText;
                }
                catch
                {
                    MessageBox.Show("Please click settings and complete the form there to complete setup!");
                    this.vncpath = "C:\\Program Files\\RealVNC\\VNCViewerPlus\\vncviewerplus.exe";
                }
            }
            else
            {
                MessageBox.Show("Please click settings and complete the form there to complete setup!");
                this.vncpath = "C:\\Program Files\\RealVNC\\VNCViewerPlus\\vncviewerplus.exe";
                XmlDeclaration dec = this.xmldoc.CreateXmlDeclaration("1.0", null, null);
                this.xmldoc.AppendChild(dec);
                this.root = this.xmldoc.CreateElement("Settings");
                this.xmldoc.AppendChild(this.root);
                this.domainroot = this.xmldoc.CreateElement("Domains");
                this.root.AppendChild(this.domainroot);
                this.xmldoc.Save(this.settingspath);

            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (vncpathbox.Text != "")
            {
                if (File.Exists(vncpathbox.Text.ToString()))
                {
                    XmlNode nodevncpath = this.xmldoc.SelectSingleNode("Settings/vncpath");
                    try
                    {
                        nodevncpath.ParentNode.RemoveChild(nodevncpath);
                    }
                    catch { }
                    XmlElement elementvncpath = this.xmldoc.CreateElement("vncpath");
                    elementvncpath.InnerText = vncpathbox.Text.ToString();
                    this.vncpath = vncpathbox.Text.ToString();
                    this.root.AppendChild(elementvncpath);
                }
                else
                {
                    MessageBox.Show("The vncpath entered is invalid.");
                }
            }
            else
            {
                MessageBox.Show("The VNC path has to be filled in.");
            }
            Boolean hasdefault;
            if(searchProviders.Select("default = 1").Length == 0)
            {
                hasdefault = false;
            }
            else if (searchProviders.Select("default = 1").Length == 1)
            {
                hasdefault = true;
            }
            else
            {
                throw new Exception("You have to many defaults set for search providers");
            }

            //do the domains.
            this.domainroot.RemoveAll();
            DataRow[] domainstosave = searchProviders.Select("type = 'domain'");
            foreach(DataRow domain in domainstosave)
            {
                XmlElement domainnode = this.xmldoc.CreateElement("Domain");
                domainnode.InnerText = domain["path"].ToString();
                if(!hasdefault)
                {
                    domainnode.SetAttribute("default", "true");
                }
                else
                {
                    domainnode.SetAttribute("default", domain["default"].ToString());
                }
                domainnode.SetAttribute("usebuiltin", domain["usebuiltin"].ToString());
                domainnode.SetAttribute("username", domain["username"].ToString());
                if ((string) domain["password"] == "")
                {
                    domainnode.SetAttribute("password", "");
                }
                else
                {
                    StringEncryption encryptpass = new StringEncryption();
                    domainnode.SetAttribute("password", encryptpass.EncryptString(domain["password"].ToString()));
                }
                this.domainroot.AppendChild(domainnode);
            }
            //do the favorites.
            DataRow[] favoritetosave = searchProviders.Select("type = 'favorite'");
            XmlNode favoritesroot = this.xmldoc.SelectSingleNode("Settings/Favorites");
            if(favoritesroot == null)
            {
                favoritesroot = this.xmldoc.CreateElement("Favorites");
                this.xmldoc.SelectSingleNode("Settings").AppendChild(favoritesroot);
            }
            String origgroupname;
            List<XmlNode> toadd = new List<XmlNode>();
            foreach(DataRow favoritegroup in favoritetosave)
            {
                if((string) favoritegroup["username"] == "")
                {
                    origgroupname = favoritegroup["path"].ToString();
                }
                else
                {
                    origgroupname = favoritegroup["username"].ToString();
                    favoritegroup["username"] = "";
                    favoritegroup.AcceptChanges();
                }
                XmlNodeList favs = this.xmldoc.SelectNodes(String.Format("Settings/Favorites/Group[@name='{0}']/Favorite", origgroupname));
                XmlNode removenode = this.xmldoc.SelectSingleNode(String.Format("Settings/Favorites/Group[@name='{0}']", origgroupname));
                XmlElement newnode = this.xmldoc.CreateElement("Group");
                newnode.SetAttribute("name", favoritegroup["path"].ToString());
                newnode.SetAttribute("default", favoritegroup["default"].ToString());
                toadd.Add(newnode);
                foreach(XmlNode fav in favs)
                {
                    newnode.AppendChild(fav);
                }
                if (removenode != null)
                {
                    favoritesroot.RemoveChild(removenode);
                }
            }
            
            foreach(XmlNode add in toadd)
            {
                favoritesroot.AppendChild(add);
            }
            this.xmldoc.Save(settingspath);
            this.Close();
            DialogResult = DialogResult.OK;
        }

        private void addprovider_Click(object sender, EventArgs e)
        {
            addeditprovider addprovider = new addeditprovider(ref this.searchProviders);
            addprovider.Show();
        }

        private void editprovider_Click(object sender, EventArgs e)
        {
            addeditprovider editprovider = new addeditprovider(ref this.searchProviders, ((DataRowView)providerbox.SelectedItem).Row, true);
            editprovider.Show();
        }

        private void deleteprovider_Click(object sender, EventArgs e)
        {
            if((string)((DataRowView)providerbox.SelectedItem).Row["type"] == "domain")
            {
                XmlNode fav = this.xmldoc.SelectSingleNode(String.Format("Settings/Domains/Domain[text() = '{0}']", ((DataRowView)providerbox.SelectedItem).Row["path"]));
                fav.ParentNode.RemoveChild(fav);
            }
            else if ((string)((DataRowView)providerbox.SelectedItem).Row["type"] == "favorite")
            {
                XmlNode fav = this.xmldoc.SelectSingleNode(String.Format("Settings/Favorites/Group[@name='{0}']", ((DataRowView)providerbox.SelectedItem).Row["path"]));
                fav.ParentNode.RemoveChild(fav);
            }
            this.xmldoc.Save(settingspath);
            ((DataRowView)providerbox.SelectedItem).Row.Delete();
        }

        private void defaultprovider_Click(object sender, EventArgs e)
        {
            DataRow[] rows = searchProviders.Select("default = 1");
            foreach(DataRow row in rows)
            {
                row["default"] = false;
            }
            ((DataRowView)providerbox.SelectedItem).Row["default"] = true;
            ((DataRowView)providerbox.SelectedItem).Row.AcceptChanges();
        }

        public XmlNodeList getFavoritesForGroup(String Group)
        {
            return this.xmldoc.SelectNodes(String.Format("Settings/Favorites/Group[@name='{0}']/Favorite", Group));
        }

        public XmlNode getFavorite(String computer)
        {
            return this.xmldoc.SelectSingleNode(String.Format("Settings/Favorites/Group/Favorite[@computer='{0}']", computer));
        }

        public void addFavorite(String computer, String password, String group)
        {
            if (getFavorite(computer) == null)
            {
                XmlElement newfav = this.xmldoc.CreateElement("Favorite");
                newfav.SetAttribute("computer", computer);
                newfav.SetAttribute("password", password);
                this.xmldoc.SelectSingleNode(String.Format("Settings/Favorites/Group[@name='{0}']", group)).AppendChild(newfav);
                this.xmldoc.Save(settingspath);
            }
            else
            {
                throw new DuplicateNameException("This computer already exists in the favorites.");
            }
        }

        public void removeFavorite(String computer)
        {
            XmlNode fav = this.xmldoc.SelectSingleNode(String.Format("Settings/Favorites/Group/Favorite[@computer='{0}']", computer));
            fav.ParentNode.RemoveChild(fav);
            this.xmldoc.Save(settingspath);
        }

        public void saveWorkListItem(String Computer, String Password)
        {
            XmlNode worklist = this.xmldoc.SelectSingleNode("Settings/Worklist");
            if(worklist == null)
            {
                worklist = this.xmldoc.CreateElement("Worklist");
                this.xmldoc.SelectSingleNode("Settings").AppendChild(worklist);
            }
            XmlElement worklistnode = this.xmldoc.CreateElement("Entry");
            worklistnode.SetAttribute("computer", Computer);
            worklistnode.SetAttribute("password", Password);
            worklist.AppendChild(worklistnode);
            this.xmldoc.Save(settingspath);
        }

        public XmlNodeList getSavedWorklist()
        {
            return this.xmldoc.SelectNodes("Settings/Worklist/Entry");
        }

        public void deleteWorkList()
        {
            try
            {
                XmlNode worklist = this.xmldoc.SelectSingleNode("Settings/Worklist");
                worklist.ParentNode.RemoveChild(worklist);
                this.xmldoc.Save(settingspath);
            }
            catch (NullReferenceException) { }
        }

        private void createSearchProviderDataTable()
        {
            searchProviders = new DataTable();
            DataColumn column;

            //add table columns
            //add name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "name";
            column.ReadOnly = false;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);

            //add type column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "type";
            column.ReadOnly = true;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);

            //add path column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "path";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);


            //add default column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "default";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);

            //add usebuiltin column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "usebuiltin";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);

            //add username column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "username";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);

            //add password column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "password";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            searchProviders.Columns.Add(column);
        }

        private void reloadSearchProvidersDataTableEntries()
        {
            searchProviders.Rows.Clear();
            addDomainsToSearchProviders();
            addFavoriteGroupsToSearchProviders();
        }

        private void addDomainsToSearchProviders()
        {
            DataRow row;
            XmlNodeList nodes = this.xmldoc.SelectNodes("Settings/Domains/Domain");
            foreach (XmlNode node in nodes)
            {
                row = searchProviders.NewRow();
                row["name"] = "Domain: " + node.InnerText.ToString();
                row["type"] = "domain";
                row["path"] = node.InnerText.ToString();
                try
                {
                    if (node.Attributes.GetNamedItem("default").Value == "true" || node.Attributes.GetNamedItem("default").Value == "True" || node.Attributes.GetNamedItem("default").Value == "TRUE")
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
                try
                {
                    if (node.Attributes.GetNamedItem("usebuiltin").Value == "true" || node.Attributes.GetNamedItem("usebuiltin").Value == "True" || node.Attributes.GetNamedItem("usebuiltin").Value == "TRUE")
                    {
                        row["usebuiltin"] = true;
                    }
                    else
                    {
                        row["usebuiltin"] = false;
                    }
                }
                catch
                {
                    row["usebuiltin"] = false;
                }

                try
                {
                    row["username"] = node.Attributes.GetNamedItem("username").Value;
                }
                catch
                {
                    row["username"] = "";
                }

                try
                {
                    StringEncryption decryptpass = new StringEncryption();
                    row["password"] = decryptpass.DecryptString(node.Attributes.GetNamedItem("password").Value);
                }
                catch
                {
                    row["password"] = "";
                }

                searchProviders.Rows.Add(row);
            }
        }
        private void addFavoriteGroupsToSearchProviders()
        {
            DataRow row;
            XmlNodeList nodes = this.xmldoc.SelectNodes("Settings/Favorites/Group");
            foreach (XmlNode node in nodes)
            {
                row = searchProviders.NewRow();
                row["name"] = "Favorite: " + node.Attributes.GetNamedItem("name").Value;
                row["type"] = "favorite";
                row["path"] = node.Attributes.GetNamedItem("name").Value;
                try
                {
                    if (node.Attributes.GetNamedItem("default").Value == "true" || node.Attributes.GetNamedItem("default").Value == "True" || node.Attributes.GetNamedItem("default").Value == "TRUE")
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
                row["usebuiltin"] = "false";
                row["username"] = "";
                row["password"] = "";
                searchProviders.Rows.Add(row);
            }
        }
    }
}
