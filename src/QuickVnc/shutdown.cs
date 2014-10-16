using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Windows.Forms;

namespace QuickVnc
{
    class Shutdown
    {
        public string username;
        public string password;
        public string computer;
        public Shutdown(string username = null, string password = null, string computer = null)
        {
            this.username = username;
            this.password = password;
            this.computer = computer;
        }
        private void shutdown_restart(int flag)
        {
            try
            {
                ConnectionOptions options = new ConnectionOptions();
                options.EnablePrivileges = true;
                if (this.password != null && this.username != null)
                {
                    // To connect to the remote computer using a different account, specify these values:
                    options.Username = this.username;
                    options.Password = this.password;
                }
                ManagementScope scope = new ManagementScope(
                  "\\\\" + this.computer + "\\root\\CIMV2", options);
                scope.Connect();

                SelectQuery query = new SelectQuery("Win32_OperatingSystem");
                ManagementObjectSearcher searcher =
                    new ManagementObjectSearcher(scope, query);

                foreach (ManagementObject os in searcher.Get())
                {
                    // Obtain in-parameters for the method
                    ManagementBaseObject inParams =
                        os.GetMethodParameters("Win32Shutdown");

                    /**
                     * 0 – Log Off
                     * 1 – Shutdown
                     * 2 – Reboot
                     * 4 – Forced Log Off
                     * 5 – Forced Shutdown
                     * 6 – Forced Reboot
                     * 8 – Power Off
                     * 12 – Forced Power Off
                     */
                    inParams["Flags"] = flag;

                    // Execute the method and obtain the return values.
                    if (flag == 1)
                    {
                        ManagementBaseObject outParams = os.InvokeMethod("Shutdown", inParams, null);
                    }
                    else if (flag == 2)
                    {
                        ManagementBaseObject outParams = os.InvokeMethod("Reboot", inParams, null);
                    }
                }
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
            catch (System.UnauthorizedAccessException unauthorizedErr)
            {
                MessageBox.Show("Connection error (user name or password might be incorrect): " + unauthorizedErr.Message);
            }
        }
        public void restart()
        {
            if (MessageBox.Show("Are you sure you would like to reboot " + computer, "Reboot " + computer, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                shutdown_restart(2);
            }
            else
            {
                MessageBox.Show("Reboot Canceled!");
            }
        }
        public void shutdown()
        {
            if (MessageBox.Show("Are you sure you would like to shutdown " + computer, "Reboot " + computer, MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                shutdown_restart(1);
            }
            else
            {
                MessageBox.Show("Shutdown Canceled!");
            }
        }
    }
}
