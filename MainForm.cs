using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            txtRootDirectory.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

            if (!IsAdministrator())
            {
                MessageBox.Show("This program needs to be run as administrator");
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
    }
}
