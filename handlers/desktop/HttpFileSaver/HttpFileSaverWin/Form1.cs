using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace HttpFileSaverWin
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            textBoxAddress.Text = "default";
            textBoxPort.Text = "50400";

        }

        private void textBoxAddress_TextChanged(object sender, EventArgs e)
        {
            textBoxServiceURL.Text = string.Format(
                "http://localhost:{0}/{1}/",
                textBoxPort.Text,
                textBoxAddress.Text
                );

        }

        private void textBoxPort_Validating(object sender, CancelEventArgs e)
        {
            int port = 0;
            e.Cancel = !int.TryParse(textBoxPort.Text, out port);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                comboBoxRootPath.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        Thread serverThread = null;

        HttpFileSaverLib.FileSaver server;

        private void setInputsEnable(bool enabled)
        {
            buttonStartServer.Enabled = enabled;
            textBoxAddress.Enabled = enabled;
            textBoxPort.Enabled = enabled;
            comboBoxRootPath.Enabled = enabled;
            buttonShowFolderDialog.Enabled = enabled;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setInputsEnable(false);

            try
            {
                server = new HttpFileSaverLib.FileSaver(int.Parse(textBoxPort.Text));
                server.AddRoot(new HttpFileSaverLib.FileSaver.RootMapping()
                {
                    domain = textBoxAddress.Text,
                    localRootPath = comboBoxRootPath.Text
                }
                    );

                server.NewMessage += new EventHandler<HttpFileSaverLib.FileSaver.MessageEventArgs>(server_NewMessage);

                serverThread = new Thread(server.Start);
                serverThread.Start();

                buttonStopServer.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");

                server = null;
                serverThread = null;
                setInputsEnable(true);
            }
        }

        void server_NewMessage(object sender, HttpFileSaverLib.FileSaver.MessageEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler<HttpFileSaverLib.FileSaver.MessageEventArgs>(server_NewMessage), sender, e);
            }
            else
            {
                listBoxMessages.Items.Add(e.message);
            }
        }

        private void buttonStopServer_Click(object sender, EventArgs e)
        {
            serverThread.Abort();
            server.Stop();

            serverThread = null;
            server = null;

            setInputsEnable(true);
            buttonStopServer.Enabled = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serverThread != null)
                serverThread.Abort();
        }
    }
}
