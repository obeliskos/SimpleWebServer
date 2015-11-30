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
using System.Xml.Serialization;

namespace SimpleWebServer
{
    /// <summary>
    /// Simple WebServer is a basic static file web server program written by GitHub user Obeliskos.
    /// Uses web server class gist written by github user aksakalli.  
    /// This program uses core .net functionality to ensure it runs well on the Windows 8.1 RT (Surface RT) .NET framework.
    /// </summary>
    public partial class MainForm : Form
    {
        private SimpleHTTPServer simpleServer;
        public string version = "0.4";
        public Settings settings = new Settings();
        string settingsPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ServerSettings.xml";
        public static MainForm formInstance = null;

        public MainForm()
        {
            InitializeComponent();
        }

        public static bool IsAdministrator()
        {
            return (new WindowsPrincipal(WindowsIdentity.GetCurrent()))
                    .IsInRole(WindowsBuiltInRole.Administrator);
        }

        #region Form level methods

        private void MainForm_Load(object sender, EventArgs e)
        {
            formInstance = this;

            // Detect if multiple instances are running and show System tray notification if so.
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("SimpleWebServer");
            if (processes.Length > 1) 
            {
                showNotification("Multiple servers are running", ToolTipIcon.Info, 3000);
            }

            // Load SystemSettings.xml if it exists
            if (System.IO.File.Exists(settingsPath))
            {
                try
                {
                    Settings newSettings;
                    XmlSerializer s = new XmlSerializer(typeof(Settings));
                    TextReader r = new StreamReader(settingsPath);
                    newSettings = (Settings)s.Deserialize(r);
                    r.Close();

                    settings = newSettings;

                    this.txtRootDirectory.Text = settings.RootDirectory;
                    this.numPort.Value = settings.ListenPort;
                    this.chkStartMinimized.Checked = settings.MinimizeOnStartup;
                    this.chkStartupServer.Checked = settings.StartServerOnStartup;

                    toolStripMainStatus.Text = "Settings loaded.";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            else
            {
                toolStripMainStatus.Text = "No settings file yet... using defaults.";
            }

            // populate mime type listbox
            this.listBoxMimeExtensions.DataSource = settings._mimeTypeMappings.Keys.ToList();

            // Default root directory to exe location
            if (txtRootDirectory.Text == "")
            {
                txtRootDirectory.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            }

            this.Text = "Simple Web Server v" + version;
            this.notifyIcon.Text = "Simple Web Server v" + version;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Hide();
                showNotification("Minimized to System tray.", ToolTipIcon.Info, 3000);
            }

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                MessageBox.Show("This program needs to be run as administrator", "Requires Elevated", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                // If they are not admin don't bother minimizing or starting up server automatically
                return;
            }

            if (settings.MinimizeOnStartup)
            {
                this.WindowState = FormWindowState.Minimized;
            }

            if (settings.StartServerOnStartup)
            {
                startServer();
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

        #endregion

        #region Toolbar Handlers

        private void saveDefaults()
        {
            settings.RootDirectory = txtRootDirectory.Text;
            settings.ListenPort = (int)numPort.Value;
            settings.MinimizeOnStartup = this.chkStartMinimized.Checked;
            settings.StartServerOnStartup = this.chkStartupServer.Checked;

            XmlSerializer s = new XmlSerializer(typeof(Settings));
            TextWriter w = new StreamWriter(settingsPath);
            s.Serialize(w, settings);
            w.Close();
        }

        private void startServer()
        {
            simpleServer = new SimpleHTTPServer(txtRootDirectory.Text, (int)numPort.Value);
            showNotification("WebServer listening on port " + numPort.Value.ToString(), ToolTipIcon.Info, 3000);
            toolStripServerStatus.Text = "Server Status : Listening on port " + numPort.Value.ToString();
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            startServer();
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            if (simpleServer != null)
            {
                simpleServer.Stop();
                showNotification("WebServer stopped.", ToolTipIcon.Info, 3000);
                toolStripServerStatus.Text = "Server Status : Stopped.";
            }
        }

        private void toolStripButtonSaveSettings_Click(object sender, EventArgs e)
        {
            saveDefaults();
            toolStripMainStatus.Text = "Settings saved.";
        }

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }

        #endregion

        #region Main Settings Handlers

        private void btnPickRoot_Click(object sender, EventArgs e)
        {
            DialogResult dr = folderBrowserDialog1.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                txtRootDirectory.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnLocationExe_Click(object sender, EventArgs e)
        {
            txtRootDirectory.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);

        }

        private void btnLocationWorking_Click(object sender, EventArgs e)
        {
            txtRootDirectory.Text = Directory.GetCurrentDirectory();

        }

        #endregion

        #region System Tray Icon

        private void showNotification(string notifyText, ToolTipIcon icon, int timeout)
        {
            notifyIcon.ShowBalloonTip(timeout, "Simple Webserver", notifyText, icon);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
        }

        private void notifyIcon_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.Activate();
        }

        #endregion

        #region Mimetype management

        private void btnUpdateMimeMapping_Click(object sender, EventArgs e)
        {
            textBoxMimeExtension.Text = textBoxMimeExtension.Text.ToLower();
            textBoxMimeMapping.Text = textBoxMimeMapping.Text.ToLower();

            if (textBoxMimeExtension.Text == ".newmimetype")
            {
                MessageBox.Show("You need to set the mime extension", "Fix errors before saving mime type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBoxMimeExtension.Text == "")
            {
                MessageBox.Show("You need to enter a mime extension", "Fix errors before saving mime type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (textBoxMimeMapping.Text == "")
            {
                MessageBox.Show("You need to enter a mime mapping", "Fix errors before saving mime type", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string ext = textBoxMimeExtension.Text;
            string mval = "";
            bool result = settings._mimeTypeMappings.TryGetValue(ext, out mval);

            if (result)
            {
                settings._mimeTypeMappings[ext] = textBoxMimeMapping.Text;
                refreshMimeList();
            }
        }

        private void selectMimeType()
        {
            string newitem = listBoxMimeExtensions.SelectedItem.ToString();
            string mapping = "";

            bool result = settings._mimeTypeMappings.TryGetValue(newitem, out mapping);
            if (result)
            {
                textBoxMimeExtension.Text = newitem;
                textBoxMimeMapping.Text = mapping;
            }

            if (newitem == ".newmimetype")
            {
                textBoxMimeExtension.Enabled = true;
            }
            else
            {
                textBoxMimeExtension.Enabled = false;
            }

            groupBoxEditMimeType.Visible = true;
        }

        private void listBoxMimeExtensions_Click(object sender, EventArgs e)
        {
            selectMimeType();
        }

        private void btnCancelMimeEdit_Click(object sender, EventArgs e)
        {
            string selectedExt = listBoxMimeExtensions.SelectedValue.ToString();

            if (selectedExt == ".newmimetype")
            {
                settings._mimeTypeMappings.Remove(".newmimetype");
                refreshMimeList();
            }
            else
            {
                groupBoxEditMimeType.Visible = false;
            }

        }

        private void refreshMimeList()
        {
            // refresh listbox
            this.listBoxMimeExtensions.DataSource = settings._mimeTypeMappings.Keys.ToList();
            // unselect listbox
            this.listBoxMimeExtensions.SelectedItem = null;
            // re-hide groupbox
            this.groupBoxEditMimeType.Visible = false;
        }

        private void btnRemoveMimeType_Click(object sender, EventArgs e)
        {
            string ext = listBoxMimeExtensions.SelectedValue.ToString();

            // remove from dictionary
            settings._mimeTypeMappings.Remove(ext);

            refreshMimeList();
        }

        private void btnAddMimeType_Click(object sender, EventArgs e)
        {
            // add mime type and lookup up the dictionary item
            settings._mimeTypeMappings.Add(".newmimetype", "application/octet-stream");
            object newDictItem = settings._mimeTypeMappings.FirstOrDefault(di => di.Key == ".newmimetype");

            refreshMimeList();

            // rough mechanism to highlight recently added mime type and ensure visible
            listBoxMimeExtensions.Focus();
            listBoxMimeExtensions.SelectedItem = newDictItem;
            listBoxMimeExtensions.SelectedIndex = listBoxMimeExtensions.Items.Count - 1;

            // now display group box editor for selected (new) mime type
            selectMimeType();
        }

        #endregion

    }
}
