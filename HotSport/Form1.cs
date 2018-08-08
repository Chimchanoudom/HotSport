using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace HotSport
{
    public partial class Form1 : Form
    {
        private ProcessStartInfo go = null;
        private string message;
        Process p = null;
        public Form1()
        {
            InitializeComponent();
            first();
            
           
        }
        public void first()
        {
            
            go = new ProcessStartInfo("cmd.exe");
            go.UseShellExecute = false;
            go.RedirectStandardOutput = true;
            go.CreateNoWindow = true;
            go.FileName = "netsh";
        }
        public void start()
        {
           
            go.Arguments = "wlan start hosted network";
            p = Process.Start(go);
            message = p.StandardOutput.ReadToEnd()+"\n";
            MessageBox.Show(message);
        }
        public void stop()
        {
            go.Arguments = "wlan stop hosted network";
            p = Process.Start(go);
            message = p.StandardOutput.ReadToEnd() + "\n";
            MessageBox.Show(message);
        }
        public void create(string ssid,string key)
        {
            go.Arguments = string.Format("wlan set hostednetwork mode=allow ssid={0} key={1}",ssid,key);
            executt(go);
        }
        public void executt(ProcessStartInfo go)
        {
            bool execut = false;
            try
            {
                using (Process p =  Process.Start(go))
                {
                    message = p.StandardOutput.ReadToEnd() + "\n";
                    p.WaitForExit();
                    execut = true;
                    MessageBox.Show(message);
                    start();
                }
            }
            catch (Exception e)
            {
                message = "";
                message += e.Message;
                execut = false;
            }
        }
        private void btnCreate_Click(object sender, EventArgs e)
        {
            
            create(txtSSID.Text, txtKey.Text);
           
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

            stop();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            start();
        }
    }
}
