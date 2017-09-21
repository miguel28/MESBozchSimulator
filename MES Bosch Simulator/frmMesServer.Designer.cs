namespace MES_Bosch_Simulator
{
    partial class frmMesServer
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
            this.txtReceive = new System.Windows.Forms.TextBox();
            this.tmrUpdate = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblMessage = new System.Windows.Forms.Label();
            this.lblTelegram = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.cboxLabelType = new System.Windows.Forms.ComboBox();
            this.lblLabelType = new System.Windows.Forms.Label();
            this.chkAcceptChangeModel = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtReceive
            // 
            this.txtReceive.Location = new System.Drawing.Point(12, 28);
            this.txtReceive.Multiline = true;
            this.txtReceive.Name = "txtReceive";
            this.txtReceive.Size = new System.Drawing.Size(335, 190);
            this.txtReceive.TabIndex = 0;
            // 
            // tmrUpdate
            // 
            this.tmrUpdate.Enabled = true;
            this.tmrUpdate.Tick += new System.EventHandler(this.tmrUpdate_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Received Buffer";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(16, 19);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(23, 13);
            this.lblIP.TabIndex = 2;
            this.lblIP.Text = "IP: ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAcceptChangeModel);
            this.groupBox1.Controls.Add(this.lblLabelType);
            this.groupBox1.Controls.Add(this.cboxLabelType);
            this.groupBox1.Controls.Add(this.lblMessage);
            this.groupBox1.Controls.Add(this.lblTelegram);
            this.groupBox1.Controls.Add(this.lblIP);
            this.groupBox1.Location = new System.Drawing.Point(377, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 206);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Control";
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(16, 69);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(50, 13);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "Message";
            // 
            // lblTelegram
            // 
            this.lblTelegram.AutoSize = true;
            this.lblTelegram.Location = new System.Drawing.Point(16, 42);
            this.lblTelegram.Name = "lblTelegram";
            this.lblTelegram.Size = new System.Drawing.Size(51, 13);
            this.lblTelegram.TabIndex = 3;
            this.lblTelegram.Text = "Telegram";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(13, 225);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // cboxLabelType
            // 
            this.cboxLabelType.FormattingEnabled = true;
            this.cboxLabelType.Items.AddRange(new object[] {
            "MLB",
            "MQB",
            "FGEN2"});
            this.cboxLabelType.Location = new System.Drawing.Point(82, 96);
            this.cboxLabelType.Name = "cboxLabelType";
            this.cboxLabelType.Size = new System.Drawing.Size(121, 21);
            this.cboxLabelType.TabIndex = 5;
            // 
            // lblLabelType
            // 
            this.lblLabelType.AutoSize = true;
            this.lblLabelType.Location = new System.Drawing.Point(16, 99);
            this.lblLabelType.Name = "lblLabelType";
            this.lblLabelType.Size = new System.Drawing.Size(60, 13);
            this.lblLabelType.TabIndex = 6;
            this.lblLabelType.Text = "Label Type";
            // 
            // chkAcceptChangeModel
            // 
            this.chkAcceptChangeModel.AutoSize = true;
            this.chkAcceptChangeModel.Checked = true;
            this.chkAcceptChangeModel.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAcceptChangeModel.Location = new System.Drawing.Point(31, 158);
            this.chkAcceptChangeModel.Name = "chkAcceptChangeModel";
            this.chkAcceptChangeModel.Size = new System.Drawing.Size(126, 17);
            this.chkAcceptChangeModel.TabIndex = 7;
            this.chkAcceptChangeModel.Text = "AcceptChangeModel";
            this.chkAcceptChangeModel.UseVisualStyleBackColor = true;
            // 
            // frmMesServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 258);
            this.ControlBox = false;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtReceive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMesServer";
            this.Text = "MES Server Simulator";
            this.Load += new System.EventHandler(this.frmMesServer_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtReceive;
        private System.Windows.Forms.Timer tmrUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.Label lblTelegram;
        private System.Windows.Forms.Label lblLabelType;
        private System.Windows.Forms.ComboBox cboxLabelType;
        private System.Windows.Forms.CheckBox chkAcceptChangeModel;
    }
}

