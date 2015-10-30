using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleWebServer
{
    /// <summary>
    /// Simple front end user interface for web server class written by github user aksakalli.  Will likely enhance this over time.
    /// </summary>
    public partial class MainForm : Form
    {
        private SimpleHTTPServer simpleServer;
        private string version = "0.2";

        public MainForm()
        {
            InitializeComponent();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            try { 
                txtRootDirectory.Text = (string) Application.UserAppDataRegistry.GetValue("RootDirectory", Application.ExecutablePath);
                numPort.Value = (decimal) Application.UserAppDataRegistry.GetValue("ListenPort", (decimal) 8080);
            }
            catch (Exception) { }

            this.Text = "Simple Web Server v" + version;
            this.notifyIcon.Text = "Simple Web Server v" + version;

            if (!IsAdministrator())
            {
                MessageBox.Show("This program needs to be run as administrator", "Requires Elevated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {

            simpleServer = new SimpleHTTPServer(txtRootDirectory.Text, (int) numPort.Value);
            lblStatus.Text = "Server started.";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (simpleServer != null)
            {
                simpleServer.Stop();
                lblStatus.Text = "Server stopped.";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                simpleServer.Stop();
            }
            catch(Exception ex)
            {
            }
        }

        private void btnPickRoot_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtRootDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSaveDefaults_Click(object sender, EventArgs e)
        {
            Application.UserAppDataRegistry.SetValue("RootDirectory", txtRootDirectory.Text);
            Application.UserAppDataRegistry.SetValue("ListenPort", (int) numPort.Value);
        }

        private void btnLocationExe_Click(object sender, EventArgs e)
        {
            txtRootDirectory.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        }

        private void btnLocationWorking_Click(object sender, EventArgs e)
        {
            txtRootDirectory.Text = Directory.GetCurrentDirectory();

        }

        private void btnClearDefaults_Click(object sender, EventArgs e)
        {
            Application.UserAppDataRegistry.DeleteValue("RootDirectory", false);
            Application.UserAppDataRegistry.DeleteValue("ListenPort", false);
        }
    }
}
