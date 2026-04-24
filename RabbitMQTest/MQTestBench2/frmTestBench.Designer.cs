namespace MQTestBench2
{
    partial class frmTestBench
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTestBench));
            label1 = new Label();
            txtAddress = new TextBox();
            txtFileReception = new TextBox();
            label2 = new Label();
            btnConnecter = new Button();
            splitContainer1 = new SplitContainer();
            btnOpenDlg = new Button();
            txtSend = new TextBox();
            label8 = new Label();
            label7 = new Label();
            dataSend = new DataGridView();
            btnEnvoyer = new Button();
            txtNomMessage = new TextBox();
            label6 = new Label();
            txtDestination = new TextBox();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            txtReceive = new TextBox();
            tabPage2 = new TabPage();
            splitContainer2 = new SplitContainer();
            dgvHistoryMsg = new DataGridView();
            toolStrip1 = new ToolStrip();
            tsbReset = new ToolStripButton();
            tsbSave = new ToolStripButton();
            txtHistoryMessage = new TextBox();
            btnDeconnecter = new Button();
            dlgOpenFile = new OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataSend).BeginInit();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistoryMsg).BeginInit();
            toolStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(31, 36);
            label1.Name = "label1";
            label1.Size = new Size(68, 20);
            label1.TabIndex = 0;
            label1.Text = "Adresse :";
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(164, 36);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(361, 27);
            txtAddress.TabIndex = 1;
            txtAddress.Text = "192.168.92.129:5672";
            // 
            // txtFileReception
            // 
            txtFileReception.Location = new Point(164, 69);
            txtFileReception.Name = "txtFileReception";
            txtFileReception.Size = new Size(361, 27);
            txtFileReception.TabIndex = 3;
            txtFileReception.Text = "Client";
            txtFileReception.TextChanged += txtFileReception_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 69);
            label2.Name = "label2";
            label2.Size = new Size(127, 20);
            label2.TabIndex = 2;
            label2.Text = "File de réception :";
            // 
            // btnConnecter
            // 
            btnConnecter.Location = new Point(531, 36);
            btnConnecter.Name = "btnConnecter";
            btnConnecter.Size = new Size(144, 60);
            btnConnecter.TabIndex = 4;
            btnConnecter.Text = "Connecter";
            btnConnecter.UseVisualStyleBackColor = true;
            btnConnecter.Click += btnConnecter_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(0, 126);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnOpenDlg);
            splitContainer1.Panel1.Controls.Add(txtSend);
            splitContainer1.Panel1.Controls.Add(label8);
            splitContainer1.Panel1.Controls.Add(label7);
            splitContainer1.Panel1.Controls.Add(dataSend);
            splitContainer1.Panel1.Controls.Add(btnEnvoyer);
            splitContainer1.Panel1.Controls.Add(txtNomMessage);
            splitContainer1.Panel1.Controls.Add(label6);
            splitContainer1.Panel1.Controls.Add(txtDestination);
            splitContainer1.Panel1.Controls.Add(label5);
            splitContainer1.Panel1.Controls.Add(label3);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Size = new Size(1123, 535);
            splitContainer1.SplitterDistance = 602;
            splitContainer1.TabIndex = 5;
            // 
            // btnOpenDlg
            // 
            btnOpenDlg.Location = new Point(66, 132);
            btnOpenDlg.Name = "btnOpenDlg";
            btnOpenDlg.Size = new Size(31, 23);
            btnOpenDlg.TabIndex = 11;
            btnOpenDlg.Text = "...";
            btnOpenDlg.UseVisualStyleBackColor = true;
            btnOpenDlg.Click += btnOpenDlg_Click;
            // 
            // txtSend
            // 
            txtSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSend.Location = new Point(13, 157);
            txtSend.Multiline = true;
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(574, 224);
            txtSend.TabIndex = 10;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label8.Location = new Point(13, 133);
            label8.Name = "label8";
            label8.Size = new Size(47, 20);
            label8.TabIndex = 9;
            label8.Text = "Texte";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(12, 384);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 8;
            label7.Text = "Données";
            // 
            // dataSend
            // 
            dataSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataSend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSend.Location = new Point(13, 407);
            dataSend.Name = "dataSend";
            dataSend.RowHeadersWidth = 51;
            dataSend.Size = new Size(574, 111);
            dataSend.TabIndex = 7;
            // 
            // btnEnvoyer
            // 
            btnEnvoyer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnEnvoyer.Location = new Point(409, 58);
            btnEnvoyer.Name = "btnEnvoyer";
            btnEnvoyer.Size = new Size(178, 60);
            btnEnvoyer.TabIndex = 6;
            btnEnvoyer.Text = "Envoyer";
            btnEnvoyer.UseVisualStyleBackColor = true;
            btnEnvoyer.Click += btnEnvoyer_Click;
            // 
            // txtNomMessage
            // 
            txtNomMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNomMessage.Location = new Point(130, 91);
            txtNomMessage.Name = "txtNomMessage";
            txtNomMessage.Size = new Size(273, 27);
            txtNomMessage.TabIndex = 5;
            txtNomMessage.Text = "ChatMessage";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(13, 94);
            label6.Name = "label6";
            label6.Size = new Size(111, 20);
            label6.TabIndex = 4;
            label6.Text = "Nom Message :";
            // 
            // txtDestination
            // 
            txtDestination.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtDestination.Location = new Point(130, 58);
            txtDestination.Name = "txtDestination";
            txtDestination.Size = new Size(273, 27);
            txtDestination.TabIndex = 3;
            txtDestination.Text = "Client";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(13, 61);
            label5.Name = "label5";
            label5.Size = new Size(96, 20);
            label5.TabIndex = 2;
            label5.Text = "Destinataire :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.Location = new Point(13, 15);
            label3.Name = "label3";
            label3.Size = new Size(83, 20);
            label3.TabIndex = 0;
            label3.Text = "Expédition";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(431, 15);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 4;
            label4.Text = "Réception";
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(3, 15);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(514, 517);
            tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(txtReceive);
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(506, 484);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Log";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtReceive
            // 
            txtReceive.Dock = DockStyle.Fill;
            txtReceive.Location = new Point(3, 3);
            txtReceive.Multiline = true;
            txtReceive.Name = "txtReceive";
            txtReceive.Size = new Size(500, 478);
            txtReceive.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(splitContainer2);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(506, 484);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Messages";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            splitContainer2.Dock = DockStyle.Fill;
            splitContainer2.Location = new Point(3, 3);
            splitContainer2.Name = "splitContainer2";
            splitContainer2.Orientation = Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            splitContainer2.Panel1.Controls.Add(dgvHistoryMsg);
            splitContainer2.Panel1.Controls.Add(toolStrip1);
            splitContainer2.Panel1.RightToLeft = RightToLeft.No;
            // 
            // splitContainer2.Panel2
            // 
            splitContainer2.Panel2.Controls.Add(txtHistoryMessage);
            splitContainer2.Panel2.RightToLeft = RightToLeft.No;
            splitContainer2.Size = new Size(500, 478);
            splitContainer2.SplitterDistance = 188;
            splitContainer2.TabIndex = 0;
            // 
            // dgvHistoryMsg
            // 
            dgvHistoryMsg.AllowUserToAddRows = false;
            dgvHistoryMsg.AllowUserToDeleteRows = false;
            dgvHistoryMsg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvHistoryMsg.Dock = DockStyle.Fill;
            dgvHistoryMsg.Location = new Point(0, 27);
            dgvHistoryMsg.MultiSelect = false;
            dgvHistoryMsg.Name = "dgvHistoryMsg";
            dgvHistoryMsg.RowHeadersWidth = 51;
            dgvHistoryMsg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvHistoryMsg.Size = new Size(500, 161);
            dgvHistoryMsg.TabIndex = 1;
            dgvHistoryMsg.CellContentClick += dgvHistoryMsg_CellContentClick;
            dgvHistoryMsg.CellFormatting += dgvHistoryMsg_CellFormatting;
            dgvHistoryMsg.SelectionChanged += dgvHistoryMsg_SelectionChanged;
            // 
            // toolStrip1
            // 
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { tsbReset, tsbSave });
            toolStrip1.Location = new Point(0, 0);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new Size(500, 27);
            toolStrip1.TabIndex = 0;
            toolStrip1.Text = "toolStrip1";
            // 
            // tsbReset
            // 
            tsbReset.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbReset.Image = (Image)resources.GetObject("tsbReset.Image");
            tsbReset.ImageTransparentColor = Color.Magenta;
            tsbReset.Name = "tsbReset";
            tsbReset.Size = new Size(49, 24);
            tsbReset.Text = "Reset";
            tsbReset.Click += tsbReset_Click;
            // 
            // tsbSave
            // 
            tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Text;
            tsbSave.Image = (Image)resources.GetObject("tsbSave.Image");
            tsbSave.ImageTransparentColor = Color.Magenta;
            tsbSave.Name = "tsbSave";
            tsbSave.Size = new Size(96, 24);
            tsbSave.Text = "Sauvegarder";
            tsbSave.Click += tsbSave_Click;
            // 
            // txtHistoryMessage
            // 
            txtHistoryMessage.Dock = DockStyle.Fill;
            txtHistoryMessage.Location = new Point(0, 0);
            txtHistoryMessage.Multiline = true;
            txtHistoryMessage.Name = "txtHistoryMessage";
            txtHistoryMessage.Size = new Size(500, 286);
            txtHistoryMessage.TabIndex = 0;
            // 
            // btnDeconnecter
            // 
            btnDeconnecter.Enabled = false;
            btnDeconnecter.Location = new Point(681, 36);
            btnDeconnecter.Name = "btnDeconnecter";
            btnDeconnecter.Size = new Size(144, 60);
            btnDeconnecter.TabIndex = 6;
            btnDeconnecter.Text = "Déconnecter";
            btnDeconnecter.UseVisualStyleBackColor = true;
            btnDeconnecter.Click += btnDeconnecter_Click;
            // 
            // dlgOpenFile
            // 
            dlgOpenFile.FileName = "*.msg";
            dlgOpenFile.Filter = "Fichiers messages|*.msg";
            // 
            // frmTestBench
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 656);
            Controls.Add(btnDeconnecter);
            Controls.Add(splitContainer1);
            Controls.Add(btnConnecter);
            Controls.Add(txtFileReception);
            Controls.Add(label2);
            Controls.Add(txtAddress);
            Controls.Add(label1);
            Name = "frmTestBench";
            Text = "Banc de tests RabbitMQ";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataSend).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvHistoryMsg).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtAddress;
        private TextBox txtFileReception;
        private Label label2;
        private Button btnConnecter;
        private SplitContainer splitContainer1;
        private TextBox txtNomMessage;
        private Label label6;
        private TextBox txtDestination;
        private Label label5;
        private Label label3;
        private Button btnEnvoyer;
        private TextBox txtSend;
        private Label label8;
        private Label label7;
        private DataGridView dataSend;
        private Button btnDeconnecter;
        private Button btnOpenDlg;
        private OpenFileDialog dlgOpenFile;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TextBox txtReceive;
        private TabPage tabPage2;
        private Label label4;
        private SplitContainer splitContainer2;
        private DataGridView dgvHistoryMsg;
        private ToolStrip toolStrip1;
        private TextBox txtHistoryMessage;
        private ToolStripButton tsbReset;
        private ToolStripButton tsbSave;
    }
}
