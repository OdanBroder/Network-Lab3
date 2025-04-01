namespace UDP_Client
{
    partial class Form1
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
            textBox_IP = new TextBox();
            textBox_Port = new TextBox();
            richTextBox1 = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button_send = new Button();
            SuspendLayout();
            // 
            // textBox_IP
            // 
            textBox_IP.Location = new Point(39, 62);
            textBox_IP.Name = "textBox_IP";
            textBox_IP.Size = new Size(537, 31);
            textBox_IP.TabIndex = 0;
            // 
            // textBox_Port
            // 
            textBox_Port.Location = new Point(626, 62);
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(132, 31);
            textBox_Port.TabIndex = 1;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(39, 152);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(719, 247);
            richTextBox1.TabIndex = 2;
            richTextBox1.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 11F);
            label1.Location = new Point(29, 34);
            label1.Name = "label1";
            label1.Size = new Size(144, 25);
            label1.TabIndex = 3;
            label1.Text = "IP Remote host";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 11F);
            label2.Location = new Point(626, 34);
            label2.Name = "label2";
            label2.Size = new Size(48, 25);
            label2.TabIndex = 4;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 11F);
            label3.Location = new Point(29, 124);
            label3.Name = "label3";
            label3.Size = new Size(89, 25);
            label3.TabIndex = 5;
            label3.Text = "Message";
            // 
            // button_send
            // 
            button_send.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_send.Location = new Point(54, 405);
            button_send.Name = "button_send";
            button_send.Size = new Size(112, 34);
            button_send.TabIndex = 6;
            button_send.Text = "Send";
            button_send.UseVisualStyleBackColor = true;
            button_send.Click += button_send_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_send);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(richTextBox1);
            Controls.Add(textBox_Port);
            Controls.Add(textBox_IP);
            Name = "Form1";
            Text = "UDP Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_IP;
        private TextBox textBox_Port;
        private RichTextBox richTextBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button_send;
    }
}
