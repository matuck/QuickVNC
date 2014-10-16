using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.Text.RegularExpressions;
using System.DirectoryServices;

namespace QuickVnc
{
    public partial class ComputerDescription : Form
    {
        delegate string Calculate(ManagementObjectSearcher s);
        String computer;
        String domain;
        string defaultNamingContext;
        TreeNode treeRoot;
        List<string> nodesToExpand = new List<string>();

        public ComputerDescription(String computer, String domain = null)
        {
            this.computer = computer;
            this.domain = domain;
            InitializeComponent();
            nodesToExpand.AddRange(new string[] { "domainDNS", "builtinDomain", "organizationalUnit", "container" });

            this.Text = computer;
            if(domain != null)
            {
                domaintextbox.Text = domain;
                String[] splitdomain = domain.Split(new Char[] { '.' });
                defaultNamingContext = "dc=" + String.Join(", dc=", splitdomain);
            }
            else
            {
                MessageBox.Show("This window is useless for non-domain machines");
                this.Close();
            }

            try
            {
                wmitextbox.Text = getmachinedescriptionwmi(computer + "." + domain);
            }
            catch (System.Runtime.InteropServices.COMException)
            {
                wmitextbox.Text = "Could not connect to machine to get data.";
            }
            DirectoryEntry domaincomp = getdomaincomputer(computer.ToString());
            
            if (domaincomp.Properties["description"].Count > 0)
            {
                adtextbox.Text = domaincomp.Properties["description"][0].ToString();
            }
            else
            {
                adtextbox.Text = "";
            }

            if(adtextbox.Text.ToString() == "")
            {
                updatetotextbox.Text = wmitextbox.Text;
            }
            else
            {
                updatetotextbox.Text = adtextbox.Text;
            }

            currentoutextbox.Text = domaincomp.Parent.Name;
            populateadtree();
            try
            {
                TreeNode selnode = treeRoot.Nodes.Find(domaincomp.Parent.Name.ToString(), true)[0];
                ouselector.SelectedNode = selnode;
                ouselector.Select();
            }
            catch (IndexOutOfRangeException)
            {

            }

        }

        private string getmachinedata(string value, string machine)
        {
            SelectQuery query = new SelectQuery();
            ConnectionOptions options = new ConnectionOptions();
            ManagementScope scope = new ManagementScope(
                  "\\\\" + machine + "\\root\\CIMV2", options);
            scope.Connect();
            Calculate calculate = delegate(ManagementObjectSearcher s) { return s.ToString(); };
            if (value == "serial")
            {
                query = new SelectQuery("Win32_BIOS");
                calculate = delegate(ManagementObjectSearcher s)
                {
                    foreach (ManagementObject os in s.Get())
                    {
                        return os.GetPropertyValue("serialnumber").ToString();
                    }
                    return "";
                };
            }
            else if (value == "os")
            {
                query = new SelectQuery("Win32_OperatingSystem");
                calculate = delegate(ManagementObjectSearcher s)
                {
                    foreach (ManagementObject os in s.Get())
                    {
                        Object ss = os.GetPropertyValue("Caption");

                        if (Regex.Matches(ss.ToString(), "Windows 8").Count > 0)
                        {
                            return "WIN8";
                        }
                        if (Regex.Matches(ss.ToString(), "Windows 7").Count > 0)
                        {
                            return "WIN7";
                        }
                        if (Regex.Matches(ss.ToString(), "Windows XP").Count > 0)
                        {
                            return "WXP";
                        }
                        if (Regex.Matches(ss.ToString(), "Server 2003").Count > 0)
                        {
                            return "W2K3";
                        }
                        if (Regex.Matches(ss.ToString(), "2008 R2").Count > 0)
                        {
                            return "W2K8R2";
                        }
                        if (Regex.Matches(ss.ToString(), "2008").Count > 0)
                        {
                            return "W2K8";
                        }
                        if (Regex.Matches(ss.ToString(), "2000").Count > 0)
                        {
                            return "W2KS";
                        }
                        return ss.ToString().Trim();
                    }
                    return "";
                };
            }
            else if (value == "model")
            {
                query = new SelectQuery("Win32_ComputerSystem");
                calculate = delegate(ManagementObjectSearcher o)
                {
                    foreach (ManagementObject mo in o.Get())
                    {
                        string s = mo.GetPropertyValue("Model").ToString();
                        s = s.ToString().Replace("OptiPlex", "");
                        s = s.ToString().Replace("Latitude", "");
                        s = s.ToString().Replace("Enhanced", "");
                        s = s.ToString().Replace("PowerEdge", "PE");
                        s = s.ToString().Replace(" ", "");

                        return s.ToString().Trim();
                    }
                    return "";
                };
            }
            else if (value == "processor")
            {
                query = new SelectQuery("Win32_Processor");
                calculate = delegate(ManagementObjectSearcher s)
                {
                    foreach (ManagementObject os in s.Get())
                    {
                        decimal speed = Convert.ToDecimal(os.GetPropertyValue("MaxClockSpeed")) / (decimal)1000;
                        return speed.ToString("N1") + "Ghz";
                    }
                    return "";
                };
            }
            else if (value == "memory")
            {
                query = new SelectQuery("Win32_PhysicalMemory");
                calculate = delegate(ManagementObjectSearcher s)
                {
                    //decimal memory = Convert.ToDecimal(s);
                    decimal memory = 0;
                    foreach (ManagementObject o in s.Get())
                    {
                        memory = memory + Convert.ToDecimal(o.GetPropertyValue("Capacity"));
                    }
                    if (memory >= (decimal)1024)
                    {
                        //convert to kilobytes
                        memory = memory / (decimal)1024;

                        if (memory >= 1024)
                        {
                            //convert to megabytes
                            memory = memory / (decimal)1024;
                            if (memory >= 1024)
                            {
                                //convert to gigabytes
                                memory = memory / (decimal)1024;
                                return memory.ToString() + "GB";
                            }
                            else
                            {
                                return memory.ToString() + "MB";
                            }
                        }
                        else
                        {
                            return memory.ToString() + "KB";
                        }
                    }
                    else
                    {
                        return memory.ToString() + "bytes";
                    }
                };
            }
            else
            {
                throw new ArgumentException("Invalid argument was specified. Must be os, serial, model, processor, memory");
            }
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            //foreach (ManagementObject os in searcher)
            //{
            return calculate(searcher);
            //}
            throw new Exception();
        }

        private string getmachinedescriptionwmi(string machine)
        {
            return this.getmachinedata("os", machine) + " - " + this.getmachinedata("model", machine) + " " + this.getmachinedata("processor", machine) + " " + this.getmachinedata("memory", machine) + " ," + this.getmachinedata("serial", machine);
        }

        private DirectoryEntry getdomaincomputer(string machine)
        {
            DirectoryEntry entry = new DirectoryEntry(buildconnectstring());
            DirectorySearcher mySearcher = new DirectorySearcher(entry);
            mySearcher.Filter = "(&(objectClass=computer)(CN=" + machine + "))";
            SearchResult myresult = mySearcher.FindOne();
            return myresult.GetDirectoryEntry();
        }

        private void populateadtree()
        {
            ouselector.Nodes.Clear();
            ouselector.HideSelection = false;
            BuildTree();
        }

        private void BuildTree()
        {
            using (DirectoryEntry domainx = new DirectoryEntry(buildconnectstring()))
            {
                treeRoot = new TreeNode(domainx.Path);
                ouselector.Nodes.Add(treeRoot);
                AddNodes(domainx, treeRoot);
            }
        }

        private void AddNodes(DirectoryEntry entry, TreeNode node)
        {
            foreach (DirectoryEntry child in entry.Children)
            {
                if (nodesToExpand.Contains(child.SchemaClassName))
                {
                    TreeNode childNode = new TreeNode(child.Name);
                    childNode.Name = child.Name;
                    node.Nodes.Add(childNode);
                    this.AddNodes(child, childNode);
                }
            }
            node.ExpandAll();
        }

        private void updatedescbtn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryEntry domaincomp = getdomaincomputer(computer);
                domaincomp.Properties["description"].Value = updatetotextbox.Text.ToString();
                domaincomp.CommitChanges();
                adtextbox.Text = domaincomp.Properties["description"].Value.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error saving to AD.\r\n" + ex.Message);
            }
        }

        private void moveoubtn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryEntry domaincomp = getdomaincomputer(computer);
                DirectoryEntry newou = new DirectoryEntry(buildconnectstring(ouselector.SelectedNode));
                domaincomp.MoveTo(newou);
                domaincomp.CommitChanges();
                currentoutextbox.Text = getdomaincomputer(computer).Parent.Name;
                TreeNode selnode = treeRoot.Nodes.Find(currentoutextbox.Text.ToString(), true)[0];
                ouselector.SelectedNode = selnode;
                ouselector.Select();
            }
            catch(Exception ex)
            {
                MessageBox.Show("There was an error saving to AD.\r\n" + ex.Message);
            }
        }

        private void updateandmovebtn_Click(object sender, EventArgs e)
        {
            try
            {
                DirectoryEntry domaincomp = getdomaincomputer(computer);
                domaincomp.Properties["description"].Value = updatetotextbox.Text.ToString();
                domaincomp.CommitChanges();
                adtextbox.Text = domaincomp.Properties["description"].Value.ToString();
                DirectoryEntry newou = new DirectoryEntry(buildconnectstring(ouselector.SelectedNode));
                domaincomp.MoveTo(newou);
                currentoutextbox.Text = getdomaincomputer(computer).Parent.Name;
                TreeNode selnode = treeRoot.Nodes.Find(currentoutextbox.Text.ToString(), true)[0];
                ouselector.SelectedNode = selnode;
                ouselector.Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show("There was an error saving to AD.\r\n" + ex.Message);
            }
        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
        private string buildconnectstring(TreeNode selected = null)
        {
            return String.Format("LDAP://{0}", buildconnectstringHelper(selected));
        }

        private string buildconnectstringHelper(TreeNode selected = null)
        {
            string connect = "";
            if (selected != null)
            {
                if (selected.Level == 0)
                {
                    connect = defaultNamingContext;
                }
                else
                {
                    connect = selected.Text.ToString();
                    if (selected.Parent != null)
                    {
                        connect = connect + ", " + buildconnectstringHelper(selected.Parent);
                    }
                }
            }
            else
            {
                connect = defaultNamingContext;
            }
            return connect;
        }
    }
}
