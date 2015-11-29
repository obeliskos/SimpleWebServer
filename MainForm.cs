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
    /// Simple front end user interface for web server class written by github user aksakalli.  Will likely enhance this over time.
    /// </summary>
    public partial class MainForm : Form
    {
        private SimpleHTTPServer simpleServer;
        public string version = "0.3";
        public Settings settings = new Settings();
        string settingsPath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\ServerSettings.xml";
        public static MainForm formInstance = null;
        //public var _priceDataArray = from row in this.settings select new { Item = row.Key, Price = row.Value };

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
            //try { 
            //    txtRootDirectory.Text = (string) Application.UserAppDataRegistry.GetValue("RootDirectory", Application.ExecutablePath);
            //    numPort.Value = (decimal) Application.UserAppDataRegistry.GetValue("ListenPort", (decimal) 8080);
            //}
            //catch (Exception) { }
            formInstance = this;

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

            this.listBoxMimeExtensions.DataSource = settings._mimeTypeMappings.Keys.ToList();

            // Default root directory to exe location
            if (txtRootDirectory.Text == "")
            {
                txtRootDirectory.Text = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            }

            // ELSE? Show Status strip label message indicating that we are using defaults

            this.Text = "Simple Web Server v" + version;
            this.notifyIcon.Text = "Simple Web Server v" + version;

            if (!IsAdministrator())
            {
                MessageBox.Show("This program needs to be run as administrator", "Requires Elevated", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            XmlSerializer s = new XmlSerializer(typeof(Settings));
            TextWriter w = new StreamWriter(settingsPath);
            s.Serialize(w, settings);
            w.Close();
        }

        private void toolStripButtonStart_Click(object sender, EventArgs e)
        {
            if (simpleServer != null)
            {
                simpleServer.Stop();
                toolStripMainStatus.Text = "Server stopped.";
            }
        }

        private void toolStripButtonStop_Click(object sender, EventArgs e)
        {
            simpleServer = new SimpleHTTPServer(txtRootDirectory.Text, (int)numPort.Value);
            toolStripMainStatus.Text = "Server started.";
        }

        private void toolStripButtonSaveSettings_Click(object sender, EventArgs e)
        {
            saveDefaults();
            toolStripMainStatus.Text = "Settings saved.";
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

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == WindowState)
            {
                this.Hide();
            }

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

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            AboutForm af = new AboutForm();
            af.Show();
        }
    }
}
