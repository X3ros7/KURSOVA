namespace Kursova
{
    partial class AddVehicleFeeForm
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
            vehiclesComboBox = new ComboBox();
            priceBox = new TextBox();
            clientsComboBox = new ComboBox();
            dateBox = new TextBox();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // addButton
            // 
            addButton.Location = new Point(12, 256);
            addButton.Name = "addButton";
            addButton.Size = new Size(303, 23);
            addButton.TabIndex = 3;
            addButton.Text = "Додати";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += addButton_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveBorder;
            panel1.Controls.Add(vehiclesComboBox);
            panel1.Controls.Add(priceBox);
            panel1.Controls.Add(clientsComboBox);
            panel1.Controls.Add(dateBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(303, 227);
            panel1.TabIndex = 2;
            // 
            // vehiclesComboBox
            // 
            vehiclesComboBox.FormattingEnabled = true;
            vehiclesComboBox.Location = new Point(162, 70);
            vehiclesComboBox.Name = "vehiclesComboBox";
            vehiclesComboBox.Size = new Size(116, 23);
            vehiclesComboBox.TabIndex = 11;
            // 
            // priceBox
            // 
            priceBox.Location = new Point(178, 171);
            priceBox.Name = "priceBox";
            priceBox.Size = new Size(100, 23);
            priceBox.TabIndex = 7;
            // 
            // clientsComboBox
            // 
            clientsComboBox.FormattingEnabled = true;
            clientsComboBox.Location = new Point(162, 26);
            clientsComboBox.Name = "clientsComboBox";
            clientsComboBox.Size = new Size(116, 23);
            clientsComboBox.TabIndex = 10;
            // 
            // dateBox
            // 
            dateBox.Location = new Point(178, 122);
            dateBox.Name = "dateBox";
            dateBox.Size = new Size(100, 23);
            dateBox.TabIndex = 6;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ButtonFace;
            label4.Location = new Point(23, 171);
            label4.Name = "label4";
            label4.Size = new Size(32, 15);
            label4.TabIndex = 3;
            label4.Text = "Ціна";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ButtonFace;
            label3.Location = new Point(23, 125);
            label3.Name = "label3";
            label3.Size = new Size(95, 15);
            label3.TabIndex = 2;
            label3.Text = "Дата придбання";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ButtonFace;
            label2.Location = new Point(23, 70);
            label2.Name = "label2";
            label2.Size = new Size(84, 15);
            label2.TabIndex = 1;
            label2.Text = "ID автомобіля";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonFace;
            label1.Location = new Point(23, 26);
            label1.Name = "label1";
            label1.Size = new Size(61, 15);
            label1.TabIndex = 0;
            label1.Text = "ID клієнта";
            // 
            // AddVehicleFeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(333, 282);
            Controls.Add(addButton);
            Controls.Add(panel1);
            Name = "AddVehicleFeeForm";
            Text = "Придбання автомобіля";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button addButton;
        private Panel panel1;
        private TextBox priceBox;
        private TextBox dateBox;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private ComboBox vehiclesComboBox;
        private ComboBox clientsComboBox;
    }
}