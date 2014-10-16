using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace QuickVnc
{
    class rdp
    {
        string computer;
        string username;
        string password;
        Thread rdpThread;
        public rdp(string computer, string username, string password)
        {
            this.computer = computer;
            this.username = username;
            this.password = password;
            rdpThread = new Thread(new ThreadStart(this.rdpWorker));
        }

        public void connect()
        {
            rdpThread.Start();
        }
        public void rdpWorker()
        {

            Process rdcProcess = new Process();
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            rdcProcess.StartInfo.Arguments = String.Format("/generic:TERMSRV/{0} /user:{1} /pass:{2}", computer, username, password);
            rdcProcess.Start();

            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\mstsc.exe");
            rdcProcess.StartInfo.Arguments = String.Format("/v:{0}", computer);
            rdcProcess.Start();
            Thread.Sleep(30000);
            rdcProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(@"%SystemRoot%\system32\cmdkey.exe");
            rdcProcess.StartInfo.Arguments = String.Format("/delete:TERMSRV/{0}", computer);
            rdcProcess.Start();
        }
    }
}
