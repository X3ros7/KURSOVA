namespace Kursova
{
    partial class EnterForm
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
            enterButton = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // enterButton
            // 
            enterButton.Location = new Point(69, 171);
            enterButton.Name = "enterButton";
            enterButton.Size = new Size(100, 23);
            enterButton.TabIndex = 0;
            enterButton.Text = "Enter";
            enterButton.UseVisualStyleBackColor = true;
            enterButton.Click += EnterButton_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(69, 59);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(69, 123);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 23);
            textBox2.TabIndex = 2;
            textBox2.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 41);
            label1.Name = "label1";
            label1.Size = new Size(94, 15);
            label1.TabIndex = 3;
            label1.Text = "Enter your name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 105);
            label2.Name = "label2";
            label2.Size = new Size(114, 15);
            label2.TabIndex = 4;
            label2.Text = "Enter your password";
            // 
            // EnterForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(243, 222);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(enterButton);
            Name = "EnterForm";
            Text = "Connect to system";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button enterButton;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
    }
}