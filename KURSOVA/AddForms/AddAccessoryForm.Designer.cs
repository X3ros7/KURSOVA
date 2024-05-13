namespace Kursova
{
    partial class AddAccessoryForm
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
            addButton = new Button();
            panel1 = new Panel();
            quantityBox = new TextBox();
            label4 = new Label();
            priceBox = new TextBox();
            label3 = new Label();
            brandBox = new TextBox();
            label2 = new Label();
            label1 = new Label();
            typeBox = new TextBox();
            nameBox = new TextBox();
            label5 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(15, 260);
            addButton.Name = "addButton";
            addButton.Size = new Size(375, 22);
            addButton.TabIndex = 3;
            addButton.Text = "Додати";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.AppWorkspace;
            panel1.Controls.Add(nameBox);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(quantityBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(priceBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(brandBox);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(typeBox);
            panel1.Location = new Point(15, 13);
            panel1.Name = "panel1";
            panel1.Size = new Size(375, 241);
            panel1.TabIndex = 2;
            // 
            // quantityBox
            // 
            quantityBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            quantityBox.Location = new Point(141, 196);
            quantityBox.Name = "quantityBox";
            quantityBox.Size = new Size(227, 23);
            quantityBox.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonFace;
            label4.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label4.Location = new Point(3, 199);
            label4.Name = "label4";
            label4.Size = new Size(70, 20);
            label4.TabIndex = 6;
            label4.Text = "Кількість";
            // 
            // priceBox
            // 
            priceBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            priceBox.Location = new Point(141, 151);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(227, 23);
            priceBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonFace;
            label3.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 154);
            label3.Name = "label3";
            label3.Size = new Size(103, 20);
            label3.TabIndex = 4;
            label3.Text = "Ціна за штуку";
            // 
            // brandBox
            // 
            brandBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            brandBox.Location = new Point(141, 76);
            brandBox.Name = "brandBox";
            brandBox.Size = new Size(227, 23);
            brandBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label2.Location = new Point(3, 76);
            label2.Name = "label2";
            label2.Size = new Size(56, 20);
            label2.TabIndex = 2;
            label2.Text = "Бренд ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label1.Location = new Point(3, 23);
            label1.Name = "label1";
            label1.Size = new Size(107, 20);
            label1.TabIndex = 1;
            label1.Text = "Тип аксесуару";
            // 
            // typeBox
            // 
            typeBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            typeBox.Location = new Point(126, 23);
            typeBox.Name = "typeBox";
            typeBox.Size = new Size(242, 23);
            typeBox.TabIndex = 0;
            // 
            // nameBox
            // 
            nameBox.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            nameBox.Location = new Point(141, 113);
            nameBox.Name = "nameBox";
            nameBox.Size = new Size(227, 23);
            nameBox.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ButtonFace;
            label5.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(3, 113);
            label5.Name = "label5";
            label5.Size = new Size(51, 20);
            label5.TabIndex = 8;
            label5.Text = "Назва";
            // 
            // AddAccessoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 292);
            Controls.Add(addButton);
            Controls.Add(panel1);
            Name = "AddAccessoryForm";
            Text = "Додавання аксесуару";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button addButton;
        private Panel panel1;
        private TextBox priceBox;
        private Label label3;
        private TextBox brandBox;
        private Label label2;
        private Label label1;
        private TextBox typeBox;
        private TextBox quantityBox;
        private Label label4;
        private TextBox nameBox;
        private Label label5;
    }
}