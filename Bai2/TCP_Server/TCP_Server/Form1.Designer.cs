namespace TCP_Server
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
            button_Listen = new Button();
            richTextBox1 = new RichTextBox();
            SuspendLayout();
            // 
            // button_Listen
            // 
            button_Listen.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Listen.Location = new Point(605, 44);
            button_Listen.Name = "button_Listen";
            button_Listen.Size = new Size(124, 41);
            button_Listen.TabIndex = 0;
            button_Listen.Text = "Listen";
            button_Listen.UseVisualStyleBackColor = true;
            button_Listen.Click += button_Listen_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(38, 111);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(736, 488);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 638);
            Controls.Add(richTextBox1);
            Controls.Add(button_Listen);
            Name = "Form1";
            Text = "TCP Server";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Listen;
        private RichTextBox richTextBox1;
    }
}
