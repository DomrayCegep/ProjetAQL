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
            label1 = new Label();
            txtAddress = new TextBox();
            txtFileReception = new TextBox();
            label2 = new Label();
            btnConnecter = new Button();
            splitContainer1 = new SplitContainer();
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
            txtReceive = new TextBox();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataSend).BeginInit();
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
            btnConnecter.Size = new Size(178, 60);
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
            splitContainer1.Panel2.Controls.Add(txtReceive);
            splitContainer1.Panel2.Controls.Add(label4);
            splitContainer1.Size = new Size(1123, 535);
            splitContainer1.SplitterDistance = 602;
            splitContainer1.TabIndex = 5;
            // 
            // txtSend
            // 
            txtSend.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtSend.Location = new Point(13, 157);
            txtSend.Multiline = true;
            txtSend.Name = "txtSend";
            txtSend.Size = new Size(574, 149);
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
            label7.Location = new Point(13, 309);
            label7.Name = "label7";
            label7.Size = new Size(70, 20);
            label7.TabIndex = 8;
            label7.Text = "Données";
            // 
            // dataSend
            // 
            dataSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataSend.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataSend.Location = new Point(13, 332);
            dataSend.Name = "dataSend";
            dataSend.RowHeadersWidth = 51;
            dataSend.Size = new Size(574, 186);
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
            // txtReceive
            // 
            txtReceive.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtReceive.Location = new Point(11, 50);
            txtReceive.Multiline = true;
            txtReceive.Name = "txtReceive";
            txtReceive.Size = new Size(496, 467);
            txtReceive.TabIndex = 2;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.Location = new Point(3, 15);
            label4.Name = "label4";
            label4.Size = new Size(79, 20);
            label4.TabIndex = 1;
            label4.Text = "Réception";
            // 
            // frmTestBench
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1123, 656);
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
        private Label label4;
        private Button btnEnvoyer;
        private TextBox txtSend;
        private Label label8;
        private Label label7;
        private DataGridView dataSend;
        private TextBox txtReceive;
    }
}
