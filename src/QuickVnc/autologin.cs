using System;
using System.IO;
using System.Security.Permissions;
using Microsoft.Win32;
using System.Windows.Forms;

namespace QuickVnc
{
    class autologin
    {
        private RegistryKey Key;

        public autologin(string computer)
        {

            this.Key = RegistryKey.OpenRemoteBaseKey(
                    RegistryHive.LocalMachine, computer).OpenSubKey(
                    "SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows NT").OpenSubKey(
                    "CurrentVersion").OpenSubKey("Winlogon", true);
        }

        public bool disable()
        {
            
            if (this.Key.GetValue("AutoAdminLogon").ToString() == "0")
            {
                throw new System.ApplicationException("Auto Login is already Disabled");
            }
            else
            {
                this.Key.SetValue("AutoAdminLogon", "0");
                return true;
            }

        }

        public bool enable()
        {
            if (this.Key.GetValue("AutoAdminLogon").ToString() == "1")
            {
                throw new System.ApplicationException("Auto Login is already Enabled");
            }
            else
            {
                this.Key.SetValue("AutoAdminLogon", "1");
                return true;
            }
        }

        public bool setup(String username, String password, String domain)
        {
            try
            {
                this.Key.SetValue("AutoAdminLogon", "1");
                this.Key.SetValue("ForceAutoLogon", "1");
                this.Key.SetValue("DefaultDomainName", domain);
                this.Key.SetValue("DefaultUserName", username);
                this.Key.SetValue("DefaultPassword", password);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}
