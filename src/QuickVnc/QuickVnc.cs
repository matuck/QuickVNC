using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.DirectoryServices;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Xml;

namespace QuickVnc
{
    public partial class QuickVnc : Form
    {
        string configpath;
        xmlpassword password;
        DataTable WorkList;
        Settings settings;
        Thread pingThread;
        delegate void SetTextCallBack(String time, String computer,bool success);

        public QuickVnc()
        {
            InitializeComponent();
            getconfigpath();
            this.password = new xmlpassword(this.configpath);
            this.settings = new Settings(this.configpath);
            //refreshdomaindropdown();
            domaindropdown.DataSource = settings.searchProviders;
            domaindropdown.DisplayMember = "name";
            domaindropdown.ValueMember = "name";
            try
            {
                domaindropdown.SelectedIndex = domaindropdown.FindStringExact(settings.searchProviders.Select("default = 1")[0]["name"].ToString());
            }
            catch { }
            pingThread = new Thread(new ThreadStart(this.PingWorker));
            setupFavoritesContestMenu();
            createWorkListDataTable();
            dataGridView1.AutoGenerateColumns = false;
            BindingSource WorkListBinding = new BindingSource();
            WorkListBinding.DataSource = WorkList;
            dataGridView1.DataSource = WorkListBinding;
            dataGridView1.Columns["computer"].DataPropertyName = "computer";
            dataGridView1.Columns["computer"].Width = 130;
            dataGridView1.Columns["status"].DataPropertyName = "status";
            ((DataGridViewComboBoxColumn) dataGridView1.Columns["passwd"]).DataSource = password.passlist;
            ((DataGridViewComboBoxColumn) dataGridView1.Columns["passwd"]).DataPropertyName = "name";
            ((DataGridViewComboBoxColumn) dataGridView1.Columns["passwd"]).DisplayMember = "name";
            ((DataGridViewComboBoxColumn) dataGridView1.Columns["passwd"]).ValueMember = "name";
            
            pingThread.Start();
        }


        private void updateComputerlist(string searchstring = null)
        {
            compdropbox.Items.Clear();
            DataRow selected = ((DataRowView)domaindropdown.SelectedItem).Row;
            if((string) selected["type"].ToString()  == "domain")
            {
                searchDomain(searchstring, selected["path"].ToString(), (Boolean) selected["usebuiltin"], selected["username"].ToString(), selected["password"].ToString());
            }
            else if((string) selected["type"].ToString()  == "favorite")
            {
                loadFavorites(selected["path"].ToString());
            }
        }

        private void searchDomain(String searchstring, String domain, Boolean usebuiltin, String username, String password)
        {
            DirectoryEntry entry = new DirectoryEntry("LDAP://" + domain);
            if (usebuiltin == false)
            {
                entry.Username = username;
                entry.Password = password;
            }
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            if (searchstring == null || searchstring == "")
            {
                MessageBox.Show("You must enter a search string");
            }
            else
            {
                searchstring = "*" + searchstring + "*";
                mySearcher.Filter = "(&(objectClass=computer)(CN=" + searchstring + "))";
                mySearcher.Sort = new SortOption("name", SortDirection.Ascending);
                SearchResultCollection myresult = mySearcher.FindAll();
                Boolean select = true;
                foreach (SearchResult currresult in myresult)
                {
                    string ComputerName = currresult.GetDirectoryEntry().Name;
                    
                    ComputerName = ComputerName.Replace("CN=", "");
                    compdropbox.Items.Add(ComputerName.ToString());
                    if (select)
                    {
                        compdropbox.SelectedItem = ComputerName.ToString();
                        select = false;
                    }
                }
            }
        }

        private void loadFavorites(String group)
        {
            XmlNodeList favs = this.settings.getFavoritesForGroup(group);
            Boolean select = true;
            foreach(XmlNode fav in favs)
            {
                compdropbox.Items.Add(fav.Attributes["computer"].Value.ToString());
                if (select)
                {
                    compdropbox.SelectedItem = fav.Attributes["computer"].Value.ToString();
                    select = false;
                }
            }
        }
        private void search_Click(object sender, EventArgs e)
        {
            updateComputerlist(computersearch.Text.ToString());
        }

        private void connect_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow useentry = getPasswordEntryforSelectedComputer();
                vnc vnc = new vnc(settings.vncpath, getSelectedComputer(), useentry["username"].ToString(), useentry["password"].ToString());
                vnc.connect();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void passwordsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordList passwordlist = new PasswordList(ref this.password);
            passwordlist.ShowDialog(); 
        }

        private void computersearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)13) search_Click(sender, e);
        }
        
        private void getconfigpath()
        {
            string configpath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).ToString();
            DirectoryInfo di = new DirectoryInfo(configpath);
            this.configpath = di.Parent.FullName.ToString() + "\\Local\\QuickVnc\\QuickVnc";
            if (!Directory.Exists(this.configpath))
            {
                Directory.CreateDirectory(this.configpath);
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(this.settings.ShowDialog() == DialogResult.OK)
            {
                setupFavoritesContestMenu();
            }
        }

        private void restart_Click(object sender, EventArgs e)
        {
            try
            {
                String computer = getSelectedComputer();
                DataRow userentry = getPasswordEntryforSelectedComputer();
                Shutdown restart = new Shutdown(userentry["username"].ToString(), userentry["password"].ToString(), computer);
                restart.restart();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            try
            {
                String computer = getSelectedComputer();
                DataRow userentry = getPasswordEntryforSelectedComputer();
                Shutdown shutdown = new Shutdown(userentry["username"].ToString(), userentry["password"].ToString(), computer);
                shutdown.shutdown();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void ping_Click(object sender, EventArgs e)
        {
            try
            {
                String comp = getSelectedComputer();
                IPAddress address;
                IPAddress.TryParse(comp, out address);

                if (address == null)
                {
                    try
                    {
                        IPAddress[] addresslist = Dns.GetHostAddresses(comp.ToString());

                        foreach (IPAddress theaddress in addresslist)
                        {
                            address = theaddress;
                            break;
                        }
                    }
                    catch (SocketException)
                    {
                        MessageBox.Show("Host Name was not found.");
                    }
                }

                if (address != null)
                {
                    DataRow row = WorkList.Select(String.Format("computer = '{0}'", comp))[0];
                    row["ping"] = true;
                    row["ipaddress"] = address.ToString();
                }
            }
            catch(InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disautologinBTN_Click(object sender, EventArgs e)
        {
            try
            {
                String logcomp = getSelectedComputer();
                autologin autologin = new autologin(logcomp.ToString());
                autologin.disable();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (ApplicationException ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            catch (UnauthorizedAccessException ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Access Denied");
            }
        }

        private void enautologinBTN_Click(object sender, EventArgs e)
        {
            try
            {
                String logcomp = getSelectedComputer();
                autologin autologin = new autologin(logcomp.ToString());
                autologin.enable();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (ApplicationException ee)
            {
                MessageBox.Show(ee.Message.ToString());
            }
            catch (UnauthorizedAccessException ee)
            {
                MessageBox.Show(ee.Message.ToString(), "Access Denied");
            }
        }

        private void setuploginbtn_Click(object sender, EventArgs e)
        {
            try
            {
                String logcomp = getSelectedComputer();
                userpassdialog userpass = new userpassdialog();
                if (userpass.ShowDialog() == DialogResult.OK)
                {
                    if (userpass.username.Text.ToString() != "" && userpass.username.Text.ToString() != null)
                    {
                        if (userpass.password.Text.ToString() != "" && userpass.password.Text.ToString() != null)
                        {
                            try
                            {
                                string[] compsplit = logcomp.Split(new Char[] { '.' });
                                autologin autologin = new autologin(logcomp.ToString());
                                if (userpass.local.Checked)
                                {
                                    String computer = compsplit[0];
                                    if (!autologin.setup(userpass.username.Text.ToString(), userpass.password.Text.ToString(), computer))
                                    {
                                        MessageBox.Show("Auto login was not setup.");
                                    }
                                }
                                else if (userpass.domain.Checked)
                                {
                                    if(compsplit.Length > 1)
                                    {
                                        String domain = compsplit[1];
                                        if (!autologin.setup(userpass.username.Text.ToString(), userpass.password.Text.ToString(), domain))
                                        {
                                            MessageBox.Show("Auto login was not setup.");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("The selected computer is not in worklist with domain.");
                                    }
                                
                                }
                            }
                            catch(IOException)
                            {
                                MessageBox.Show("Autologin was not setup.  Unable to connect to the computer.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("The password box cannot be blank. Autologin was not setup");
                        }
                    }
                    else
                    {
                        MessageBox.Show("The username box cannot be blank. Autologin was not setup");
                    }
                }
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void rdp_Click(object sender, EventArgs e)
        {
            try
            {
                String computer = getSelectedComputer();
                DataRow userentry = getPasswordEntryforSelectedComputer();
                rdp rdp = new rdp(computer, userentry["username"].ToString(), userentry["password"].ToString());
                rdp.connect();
            }
            catch (InvalidDataException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        private void PingWorker()
        {
            PingReply reply;
            IPAddress address;
            while (0 < 1)
            {
                DataRow[] pingRows = WorkList.Select("ping = 1");
                
                if(pingRows.Length > 0)
                {
                    foreach(DataRow pingRow in pingRows)
                    {
                        if (IPAddress.TryParse(pingRow["ipaddress"].ToString(), out address))
                        {
                            reply = sendping(address);
                            if (reply.Status == IPStatus.Success)
                            {
                                this.pingReply(reply.RoundtripTime + "ms", pingRow["computer"].ToString(), true);
                            }
                            else
                            {
                                this.pingReply("", pingRow["computer"].ToString(), false);
                            }
                        }
                        else
                        {
                            MessageBox.Show("There was an error parsing the ipaddress for " + pingRow["computer"].ToString());
                        }
                    }
                }
                Thread.Sleep(1000);
            }
        }

        public PingReply sendping(IPAddress address)
        {
            System.Net.NetworkInformation.Ping pingSender = new System.Net.NetworkInformation.Ping();
            PingReply reply = pingSender.Send(address);
            return reply;
        }

        private void pingReply(String time, String computer, bool success)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.dataGridView1.InvokeRequired)
            {
                SetTextCallBack d = new SetTextCallBack(pingReply);
                this.Invoke(d, new object[] { time, computer, success });
            }
            else
            {
                DataRow row = WorkList.Select(String.Format("computer = '{0}'", computer))[0];
                if(success)
                {
                    row["status"] = time;
                }
                else
                {
                    row["status"] = "No Response";
                }
            }
        }

        private void setupFavoritesContestMenu()
        {
            addFavoriteToolStripMenuItem.DropDown.Items.Clear();
            DataRow[] groups = this.settings.searchProviders.Select("type = 'favorite'");
            foreach(DataRow group in groups)
            {
                ToolStripMenuItem entry = new ToolStripMenuItem(group["path"].ToString());
                entry.Click += new EventHandler(AddFavoriteGroupClickHandler);
                addFavoriteToolStripMenuItem.DropDown.Items.Add(entry);
            }
        }
        private void AddFavoriteGroupClickHandler(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;
            if (clickedItem.Text.ToString() == "Add Favorite")
            {
                MessageBox.Show("Please select an item from the sub-menu to add to favorites.  If submenu does not exist please go into setttings and add a Favorites Provider.");
            }
            else
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                try
                {
                    settings.addFavorite(row.Cells["computer"].Value.ToString(), row.Cells["passwd"].Value.ToString(), clickedItem.Text.ToString());
                    MessageBox.Show(String.Format("{0} has been added to your favorites in group {1}", row.Cells["computer"].Value.ToString(), clickedItem.Text.ToString()));
                }
                catch (DuplicateNameException)
                {
                    MessageBox.Show(String.Format("A computer with name {0} already exist in the favorites list.", row.Cells["computer"].Value.ToString()));
                }
            }
        }
        private void addworklist_Click(object sender, EventArgs e)
        {
            try
            {
                String compname = getCompName();
                if (WorkList.Select(String.Format("computer = '{0}'", compname)).Length == 0)
                {
                    DataRow row = WorkList.NewRow();
                    row["computer"] = compname;
                    try
                    {
                        row["password"] = password.getDefaultPasswordName();
                    }
                    catch (IndexOutOfRangeException)
                    {

                    }
                    row["ping"] = false;
                    WorkList.Rows.Add(row);
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["passwd"].Value = password.getDefaultPasswordName();
                    DataRow selected = ((DataRowView)domaindropdown.SelectedItem).Row;
                    if((string)selected["type"].ToString() == "favorite")
                    {
                        XmlNode fav = settings.getFavorite(getCompName());
                        if(fav != null)
                        {

                            Boolean contains = false;
                            foreach (DataRowView passrow in ((DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["passwd"]).Items)
                            {
                                if (passrow["name"].ToString() == fav.Attributes["password"].Value.ToString())
                                {
                                    contains = true;
                                    break;
                                }
                            }
                            if(contains)
                            {
                                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["passwd"].Value = fav.Attributes["password"].Value.ToString();
                                row["password"] = fav.Attributes["password"].Value.ToString();
                            }
                            else
                            {
                                MessageBox.Show(String.Format("The password associated with this favorite is no longer available.  Default Password is being used."));
                            }
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show(compname + " already in the worklist");
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns["delete"] is DataGridViewButtonColumn && e.RowIndex >= 0 && senderGrid.Columns["delete"].DisplayIndex == e.ColumnIndex)
            {
                DataRow row = WorkList.Select(String.Format("computer = '{0}'", dataGridView1.Rows[e.RowIndex].Cells["computer"].Value.ToString()))[0];
                WorkList.Rows.Remove(row);

            }
            if (senderGrid.Columns["computer"] is DataGridViewTextBoxColumn && e.RowIndex >= 0 && senderGrid.Columns["computer"].DisplayIndex == e.ColumnIndex)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
            if (senderGrid.Columns["passwd"] is DataGridViewComboBoxColumn && e.RowIndex >= 0 && senderGrid.Columns["passwd"].DisplayIndex == e.ColumnIndex)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            if (senderGrid.Columns["passwd"] is DataGridViewComboBoxColumn && e.RowIndex >= 0 && senderGrid.Columns["passwd"].DisplayIndex != e.ColumnIndex)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
            }
        }
        
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
        }

        public void dataGridView1_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            dataGridView1.CommitEdit(DataGridViewDataErrorContexts.Commit);
            var senderGrid = (DataGridView)sender;
            DataRow row = WorkList.Select(String.Format("computer = '{0}'", dataGridView1.Rows[senderGrid.CurrentRow.Index].Cells["computer"].Value.ToString()))[0];
            row["password"] = ((DataGridViewComboBoxCell)dataGridView1.Rows[senderGrid.CurrentRow.Index].Cells["passwd"]).Value.ToString();
        }

        public void dataGridView1_CellFormating(object sender, DataGridViewCellFormattingEventArgs e)
        {
            foreach (DataGridViewRow Myrow in dataGridView1.Rows)
            {
                try
                {
                    if (Myrow.Cells["status"].Value.ToString() == "No Response")
                    {
                        Myrow.Cells["status"].Style.BackColor = Color.Red;
                        Myrow.Cells["status"].Style.SelectionBackColor = Color.Red;
                    }
                    else if (Myrow.Cells["status"].Value.ToString() != "" && Myrow.Cells["status"].Value.ToString() != null)
                    {
                        Myrow.Cells["status"].Style.BackColor = Color.Green;
                        Myrow.Cells["status"].Style.SelectionBackColor = Color.Green;
                    }
                    else
                    {
                        Myrow.Cells["status"].Style.BackColor = Color.White;
                        Myrow.Cells["status"].Style.SelectionBackColor = Color.White;
                    }
                }
                catch(NullReferenceException)
                {

                }
                
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.settings.deleteWorkList();
            if (WorkList.Rows.Count > 0)
            {
                DialogResult saveworklist = MessageBox.Show("Would you like to restore your worklist next time you open quickvnc?", "Save Worklist", MessageBoxButtons.YesNo);
                if (saveworklist == DialogResult.Yes)
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        this.settings.saveWorkListItem(row.Cells["computer"].Value.ToString(), row.Cells["passwd"].Value.ToString());
                    }
                }
            }
            base.OnFormClosing(e);
            pingThread.Abort();
        }

        private void stopPing_Click(object sender, EventArgs e)
        {
            try
            {
                DataRow compentry = WorkList.Select(String.Format("computer = '{0}'", getSelectedComputer()))[0];
                compentry["ping"] = false;
                compentry["status"] = null;
            }
            catch(InvalidDataException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void stopAllPing_Click(object sender, EventArgs e)
        {
            foreach(DataRow row in WorkList.Rows)
            {
                row["ping"] = false;
                row["status"] = null;
            }
        }

        public void restoreWorklist()
        {
            XmlNodeList entries = this.settings.getSavedWorklist();
            foreach(XmlNode entry in entries)
            {
                DataRow row = this.WorkList.NewRow();
                row["computer"] = entry.Attributes["computer"].Value.ToString();
                row["password"] = password.getDefaultPasswordName();
                WorkList.Rows.Add(row);
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;
                DataGridViewComboBoxCell combocell = ((DataGridViewComboBoxCell)dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[1]);
                DataGridViewComboBoxColumn combocol = (DataGridViewComboBoxColumn) dataGridView1.Columns[1];
                combocell.Value = password.getDefaultPasswordName();
                foreach(DataRowView item in combocol.Items)
                {
                    if(item["name"].ToString() == entry.Attributes["password"].Value.ToString())
                    {
                        combocell.Value = item["name"].ToString();
                        row["password"] = item["name"].ToString();
                        break;
                    }
                }
            }
        }
        ////////////////////////////////////////////
        // Helpers
        ////////////////////////////////////////////
        /// <summary>
        /// Get computer name from drop down box.
        /// </summary>
        /// <exception cref="NullReferenceException">When there is nothing in the computer drop down box.</exception>
        /// <returns></returns>
        private String getCompName()
        {
            if (compdropbox.SelectedItem != null)
            {
                try
                {
                    DataRow domain = ((DataRowView) domaindropdown.SelectedItem).Row;
                    if ((string)domain["type"] == "domain")
                    {
                        return compdropbox.SelectedItem.ToString() + "." + domain["path"].ToString();
                    }
                    else
                    {
                        return compdropbox.SelectedItem.ToString();
                    }
                }
                catch (NullReferenceException)
                {
                    throw new NullReferenceException("Please select or type something in the computer box.");
                }
            }
            else if(compdropbox.Text != null && compdropbox.Text.ToString() != "")
            {
                return compdropbox.Text.ToString();

            }
            else
            {
                throw new NullReferenceException("Please select or type something in the computer box.");
            } 
        }

        /// <summary>
        /// Get the selected computer name
        /// </summary>
        /// <exception cref="InvalidDataException">When a row is not selected or to many rows are selected.</exception>
        /// <returns></returns>
        private String getSelectedComputer()
        {
            if(dataGridView1.SelectedRows.Count == 0)
            {
                throw new InvalidDataException("Please click a computer name in the worklist!");
            }
            else if(dataGridView1.SelectedRows.Count > 1)
            {
                throw new InvalidDataException("To many computers in the worklist selected.  Please select only 1 computer.");
            }
            else
            {
                return dataGridView1.SelectedRows[0].Cells["computer"].Value.ToString();
            }
        }

        /// <summary>
        /// get the password name from the selected row.
        /// </summary>
        /// <exception cref="InvalidDataException">When a row is not selected or to many rows are selected.</exception>
        /// <returns></returns>
        private DataRow getPasswordEntryforSelectedComputer()
        {

            if (dataGridView1.SelectedRows.Count == 0)
            {
                throw new InvalidDataException("Please click a computer name in the worklist!");
            }
            else if (dataGridView1.SelectedRows.Count > 1)
            {
                throw new InvalidDataException("To many computers in the worklist selected.  Please select only 1 computer.");
            }
            else
            {


                return this.password.getpasswordentry(WorkList.Select(String.Format("computer = '{0}'", getSelectedComputer()))[0]["password"].ToString());
            }
        }

        private void createWorkListDataTable()
        {
            WorkList = new DataTable();
            DataColumn column;

            //add table columns
            //add name column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "computer";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            WorkList.Columns.Add(column);

            //add password column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "password";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            WorkList.Columns.Add(column);

            //add status column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "status";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            WorkList.Columns.Add(column);

            //add ping column column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Boolean");
            column.ColumnName = "ping";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            WorkList.Columns.Add(column);

            //add ipaddress column
            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "ipaddress";
            column.ReadOnly = false;
            column.Unique = false;
            // Add the Column to the DataColumnCollection.
            WorkList.Columns.Add(column);
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    this.dataGridView1.Rows[e.RowIndex].Selected = true;
                    this.contextMenuDataGrid.Show(Cursor.Position);
                }
            }
            catch (ArgumentOutOfRangeException)
            {

            }
            
        }

        private void computerDescriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String computer = getSelectedComputer();
            IPAddress address;
            if(!IPAddress.TryParse(computer, out address))
            {
                string[] compsplit = computer.Split(new Char[] { '.' });
                if (compsplit.Length > 1)
                {
                    computer = compsplit[0];
                    String domain = String.Join(".", compsplit.Skip(1));
                    ComputerDescription cd = new ComputerDescription(computer, domain);
                    cd.ShowDialog();
                }
                else
                {
                    MessageBox.Show("This appears to be a non-domain machine. Computer Description does not work on non domain machine.");
                }
            }
            else
            {
                MessageBox.Show("Computer Description will not work on an ip address");
            }
            
        }

        private void domaindropdown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow selected = ((DataRowView)domaindropdown.SelectedItem).Row;
            
            compdropbox.Items.Clear();
            compdropbox.Text = "";
            if(selected["type"].ToString() == "favorite")
            {
                updateComputerlist();
                search.Enabled = false;
                computersearch.Enabled = false;
            }
            else if (selected["type"].ToString() == "domain")
            {
                search.Enabled = true;
                computersearch.Enabled = true;
            }
        }

        private void removeFavoriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dataGridView1.SelectedRows[0];
            this.settings.removeFavorite(row.Cells["computer"].Value.ToString());
            MessageBox.Show(String.Format("Favorite for computer {0} has been deleted", row.Cells["computer"].Value.ToString()));
        }

        private void QuickVnc_Load(object sender, EventArgs e)
        {
            restoreWorklist();
        }
    }
}
