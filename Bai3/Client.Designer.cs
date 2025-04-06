namespace Bai3
{
    partial class Client
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
            this.labelIP = new System.Windows.Forms.Label();
            this.labelPort = new System.Windows.Forms.Label();
            this.textBoxIP = new System.Windows.Forms.TextBox();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.groupBoxSend = new System.Windows.Forms.GroupBox();
            this.richTextBoxSend = new System.Windows.Forms.RichTextBox();
            this.groupBoxReceive = new System.Windows.Forms.GroupBox();
            this.richTextBoxReiceive = new System.Windows.Forms.RichTextBox();
            this.bttnConnect = new System.Windows.Forms.Button();
            this.bttnSend = new System.Windows.Forms.Button();
            this.bttnDisconnect = new System.Windows.Forms.Button();
            this.groupBoxSend.SuspendLayout();
            this.groupBoxReceive.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelIP
            // 
            this.labelIP.AutoSize = true;
            this.labelIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelIP.Location = new System.Drawing.Point(48, 29);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(21, 16);
            this.labelIP.TabIndex = 0;
            this.labelIP.Text = "IP";
            // 
            // labelPort
            // 
            this.labelPort.AutoSize = true;
            this.labelPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPort.Location = new System.Drawing.Point(265, 26);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(35, 16);
            this.labelPort.TabIndex = 1;
            this.labelPort.Text = "Port";
            // 
            // textBoxIP
            // 
            this.textBoxIP.Location = new System.Drawing.Point(87, 23);
            this.textBoxIP.Name = "textBoxIP";
            this.textBoxIP.Size = new System.Drawing.Size(157, 22);
            this.textBoxIP.TabIndex = 2;
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(322, 23);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(93, 22);
            this.textBoxPort.TabIndex = 3;
            // 
            // groupBoxSend
            // 
            this.groupBoxSend.Controls.Add(this.richTextBoxSend);
            this.groupBoxSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxSend.Location = new System.Drawing.Point(13, 51);
            this.groupBoxSend.Name = "groupBoxSend";
            this.groupBoxSend.Size = new System.Drawing.Size(655, 270);
            this.groupBoxSend.TabIndex = 4;
            this.groupBoxSend.TabStop = false;
            this.groupBoxSend.Text = "Send Message";
            // 
            // richTextBoxSend
            // 
            this.richTextBoxSend.Location = new System.Drawing.Point(10, 21);
            this.richTextBoxSend.Name = "richTextBoxSend";
            this.richTextBoxSend.Size = new System.Drawing.Size(643, 234);
            this.richTextBoxSend.TabIndex = 0;
            this.richTextBoxSend.Text = "";
            // 
            // groupBoxReceive
            // 
            this.groupBoxReceive.Controls.Add(this.richTextBoxReiceive);
            this.groupBoxReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBoxReceive.Location = new System.Drawing.Point(13, 327);
            this.groupBoxReceive.Name = "groupBoxReceive";
            this.groupBoxReceive.Size = new System.Drawing.Size(654, 111);
            this.groupBoxReceive.TabIndex = 5;
            this.groupBoxReceive.TabStop = false;
            this.groupBoxReceive.Text = "Receive Message";
            // 
            // richTextBoxReiceive
            // 
            this.richTextBoxReiceive.Location = new System.Drawing.Point(9, 22);
            this.richTextBoxReiceive.Name = "richTextBoxReiceive";
            this.richTextBoxReiceive.ReadOnly = true;
            this.richTextBoxReiceive.Size = new System.Drawing.Size(643, 75);
            this.richTextBoxReiceive.TabIndex = 0;
            this.richTextBoxReiceive.Text = "";
            // 
            // bttnConnect
            // 
            this.bttnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnConnect.Location = new System.Drawing.Point(674, 65);
            this.bttnConnect.Name = "bttnConnect";
            this.bttnConnect.Size = new System.Drawing.Size(114, 52);
            this.bttnConnect.TabIndex = 6;
            this.bttnConnect.Text = "Connect";
            this.bttnConnect.UseVisualStyleBackColor = true;
            this.bttnConnect.Click += new System.EventHandler(this.StartConnect);
            // 
            // bttnSend
            // 
            this.bttnSend.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnSend.Location = new System.Drawing.Point(674, 142);
            this.bttnSend.Name = "bttnSend";
            this.bttnSend.Size = new System.Drawing.Size(114, 52);
            this.bttnSend.TabIndex = 7;
            this.bttnSend.Text = "Send";
            this.bttnSend.UseVisualStyleBackColor = true;
            this.bttnSend.Click += new System.EventHandler(this.SendMessage);
            // 
            // bttnDisconnect
            // 
            this.bttnDisconnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bttnDisconnect.Location = new System.Drawing.Point(674, 225);
            this.bttnDisconnect.Name = "bttnDisconnect";
            this.bttnDisconnect.Size = new System.Drawing.Size(114, 52);
            this.bttnDisconnect.TabIndex = 8;
            this.bttnDisconnect.Text = "Disconnect";
            this.bttnDisconnect.UseVisualStyleBackColor = true;
            this.bttnDisconnect.Click += new System.EventHandler(this.Disconnect);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bttnDisconnect);
            this.Controls.Add(this.bttnSend);
            this.Controls.Add(this.bttnConnect);
            this.Controls.Add(this.groupBoxReceive);
            this.Controls.Add(this.groupBoxSend);
            this.Controls.Add(this.textBoxPort);
            this.Controls.Add(this.textBoxIP);
            this.Controls.Add(this.labelPort);
            this.Controls.Add(this.labelIP);
            this.Name = "Client";
            this.Text = "Client";
            this.groupBoxSend.ResumeLayout(false);
            this.groupBoxReceive.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.TextBox textBoxIP;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.GroupBox groupBoxSend;
        private System.Windows.Forms.GroupBox groupBoxReceive;
        private System.Windows.Forms.Button bttnConnect;
        private System.Windows.Forms.Button bttnSend;
        private System.Windows.Forms.RichTextBox richTextBoxSend;
        private System.Windows.Forms.RichTextBox richTextBoxReiceive;
        private System.Windows.Forms.Button bttnDisconnect;
    }
}