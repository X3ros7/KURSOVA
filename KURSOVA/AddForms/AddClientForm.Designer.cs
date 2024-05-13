namespace Kursova
{
    partial class AddClientForm
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
            panel1 = new Panel();
            phoneBox = new TextBox();
            label3 = new Label();
            emailBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            nameBox = new TextBox();
            addButton = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(phoneBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(emailBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(nameBox);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(375, 193);
            panel1.TabIndex = 0;
            // 
            // phoneBox
            // 
            phoneBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            phoneBox.Location = new Point(141, 136);
            phoneBox.Name = "phoneBox";
            phoneBox.Size = new Size(227, 23);
            phoneBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonFace;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 139);
            label3.Name = "label3";
            label3.Size = new Size(129, 20);
            label3.TabIndex = 4;
            label3.Text = "Номер телефону:";
            // 
            // emailBox
            // 
            emailBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            emailBox.Location = new Point(141, 76);
            emailBox.Name = "emailBox";
            emailBox.Size = new Size(227, 23);
            emailBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(3, 79);
            label2.Name = "label2";
            label2.Size = new Size(132, 20);
            label2.TabIndex = 2;
            label2.Text = "Електрона пошта:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 23);
            label1.Name = "label1";
            label1.Size = new Size(91, 20);
            label1.TabIndex = 1;
            label1.Text = "Ім'я клієнта:";
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nameBox.Location = new Point(126, 23);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(242, 23);
            nameBox.TabIndex = 0;
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 208);
            addButton.Name = "addButton";
            addButton.Size = new Size(375, 22);
            addButton.TabIndex = 1;
            addButton.Text = "Додати";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // AddClientForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(399, 233);
            Controls.Add(addButton);
            Controls.Add(panel1);
            Name = "AddClientForm";
            Text = "Додавання клієнта";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox nameBox;
        private Label label1;
        private Label label2;
        private TextBox emailBox;
        private TextBox phoneBox;
        private Label label3;
        private Button addButton;
    }
}