namespace UDP_Server
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
            textBox_Port = new TextBox();
            button_Listen = new Button();
            label1 = new Label();
            label2 = new Label();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // textBox_Port
            // 
            textBox_Port.Location = new Point(121, 44);
            textBox_Port.Name = "textBox_Port";
            textBox_Port.Size = new Size(167, 31);
            textBox_Port.TabIndex = 0;
            // 
            // button_Listen
            // 
            button_Listen.Font = new Font("Times New Roman", 12F);
            button_Listen.Location = new Point(625, 46);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(143, 43);
            button_Listen.TabIndex = 2;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F);
            label1.Location = new Point(42, 46);
            label1.Name = "label1";
            label1.Size = new Size(53, 27);
            label1.TabIndex = 3;
            label1.Text = "Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F);
            label2.Location = new Point(40, 102);
            label2.Name = "label2";
            label2.Size = new Size(191, 27);
            label2.TabIndex = 4;
            label2.Text = "Received Message";
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(43, 132);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ReadOnly = true;
            richTextBox1.Size = new Size(725, 290);
            richTextBox1.TabIndex = 5;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_Listen);
            Controls.Add(textBox_Port);
            Name = "Form1";
            Text = "UDP Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox_Port;
        private Button button_Listen;
        private Label label1;
        private Label label2;
        private RichTextBox richTextBox1;
    }
}
