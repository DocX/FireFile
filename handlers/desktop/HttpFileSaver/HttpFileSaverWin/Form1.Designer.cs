namespace HttpFileSaverWin
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxServiceURL = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxRootPath = new System.Windows.Forms.ComboBox();
            this.buttonShowFolderDialog = new System.Windows.Forms.Button();
            this.buttonStartServer = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.listBoxMessages = new System.Windows.Forms.ListBox();
            this.buttonStopServer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Location = new System.Drawing.Point(90, 12);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(182, 20);
            this.textBoxAddress.TabIndex = 0;
            this.toolTip1.SetToolTip(this.textBoxAddress, "Used in service URL");
            this.textBoxAddress.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(310, 12);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(53, 20);
            this.textBoxPort.TabIndex = 1;
            this.toolTip1.SetToolTip(this.textBoxPort, "On which port listen to requests");
            this.textBoxPort.TextChanged += new System.EventHandler(this.textBoxAddress_TextChanged);
            this.textBoxPort.Validating += new System.ComponentModel.CancelEventHandler(this.textBoxPort_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(278, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Port";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Service name";
            // 
            // textBoxServiceURL
            // 
            this.textBoxServiceURL.Location = new System.Drawing.Point(15, 102);
            this.textBoxServiceURL.Name = "textBoxServiceURL";
            this.textBoxServiceURL.ReadOnly = true;
            this.textBoxServiceURL.Size = new System.Drawing.Size(348, 20);
            this.textBoxServiceURL.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Service URL (Copy to FireFile)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Document root";
            // 
            // comboBoxRootPath
            // 
            this.comboBoxRootPath.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxRootPath.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystemDirectories;
            this.comboBoxRootPath.FormattingEnabled = true;
            this.comboBoxRootPath.Location = new System.Drawing.Point(95, 38);
            this.comboBoxRootPath.Name = "comboBoxRootPath";
            this.comboBoxRootPath.Size = new System.Drawing.Size(223, 21);
            this.comboBoxRootPath.TabIndex = 2;
            this.toolTip1.SetToolTip(this.comboBoxRootPath, "Where is root folder of files on web");
            // 
            // buttonShowFolderDialog
            // 
            this.buttonShowFolderDialog.Location = new System.Drawing.Point(324, 38);
            this.buttonShowFolderDialog.Name = "buttonShowFolderDialog";
            this.buttonShowFolderDialog.Size = new System.Drawing.Size(39, 21);
            this.buttonShowFolderDialog.TabIndex = 3;
            this.buttonShowFolderDialog.Text = "...";
            this.buttonShowFolderDialog.UseVisualStyleBackColor = true;
            this.buttonShowFolderDialog.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonStartServer
            // 
            this.buttonStartServer.Location = new System.Drawing.Point(288, 128);
            this.buttonStartServer.Name = "buttonStartServer";
            this.buttonStartServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStartServer.TabIndex = 5;
            this.buttonStartServer.Text = "Start";
            this.buttonStartServer.UseVisualStyleBackColor = true;
            this.buttonStartServer.Click += new System.EventHandler(this.button2_Click);
            // 
            // listBoxMessages
            // 
            this.listBoxMessages.FormattingEnabled = true;
            this.listBoxMessages.Location = new System.Drawing.Point(15, 167);
            this.listBoxMessages.Name = "listBoxMessages";
            this.listBoxMessages.Size = new System.Drawing.Size(348, 225);
            this.listBoxMessages.TabIndex = 6;
            // 
            // buttonStopServer
            // 
            this.buttonStopServer.Enabled = false;
            this.buttonStopServer.Location = new System.Drawing.Point(207, 128);
            this.buttonStopServer.Name = "buttonStopServer";
            this.buttonStopServer.Size = new System.Drawing.Size(75, 23);
            this.buttonStopServer.TabIndex = 8;
            this.buttonStopServer.Text = "Stop";
            this.buttonStopServer.UseVisualStyleBackColor = true;
            this.buttonStopServer.Click += new System.EventHandler(this.buttonStopServer_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 405);
            this.Controls.Add(this.buttonStopServer);
            this.Controls.Add(this.listBoxMessages);
            this.Controls.Add(this.buttonStartServer);
            this.Controls.Add(this.buttonShowFolderDialog);
            this.Controls.Add(this.comboBoxRootPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxServiceURL);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HTTP File Saver";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxServiceURL;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxRootPath;
        private System.Windows.Forms.Button buttonShowFolderDialog;
        private System.Windows.Forms.Button buttonStartServer;
        private System.Windows.Forms.ListBox listBoxMessages;
        private System.Windows.Forms.Button buttonStopServer;
    }
}

