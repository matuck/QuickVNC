using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace QuickVnc
{
    class vnc
    {
        string computer;
        string username;
        string password;
        string vncpath;
        public vnc(string vncpath, string computer, string username, string password)
        {
            this.vncpath = vncpath;
            this.computer = computer;
            this.username = username;
            this.password = password;
        }
        public void connect()
        {
            Process p = new Process();
            p.EnableRaisingEvents = false;
            p.StartInfo.FileName = this.vncpath;
            p.StartInfo.Arguments = " -uri vnc://" + this.username + ":" + this.password + "@" + this.computer;
            p.Start();
        }
    }
}
