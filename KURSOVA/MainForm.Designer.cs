namespace Kursova
{
    partial class MainForm
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
            dataGridView1 = new DataGridView();
            menuStrip1 = new MenuStrip();
            tableToolStripMenuItem = new ToolStripMenuItem();
            clientTable = new ToolStripMenuItem();
            vehicleTable = new ToolStripMenuItem();
            accessoryTable = new ToolStripMenuItem();
            testdriverrecordTable = new ToolStripMenuItem();
            vehiclefeeTable = new ToolStripMenuItem();
            accessoryfeeTable = new ToolStripMenuItem();
            leasingrecordTable = new ToolStripMenuItem();
            label1 = new Label();
            panel1 = new Panel();
            valueTextBox = new TextBox();
            searchBox = new Button();
            comboBox = new ComboBox();
            panel2 = new Panel();
            updateRecordButton = new Button();
            deleteRecordButton = new Button();
            addRecordButton = new Button();
            label2 = new Label();
            panel3 = new Panel();
            newValueTextBox = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            idTextBox = new TextBox();
            columnsComboBox = new ComboBox();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(534, 330);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tableToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // tableToolStripMenuItem
            // 
            tableToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientTable, vehicleTable, accessoryTable, testdriverrecordTable, vehiclefeeTable, accessoryfeeTable, leasingrecordTable });
            tableToolStripMenuItem.Name = "tableToolStripMenuItem";
            tableToolStripMenuItem.Size = new Size(65, 20);
            tableToolStripMenuItem.Text = "Таблиця";
            // 
            // clientTable
            // 
            clientTable.Checked = true;
            clientTable.CheckState = CheckState.Checked;
            clientTable.Name = "clientTable";
            clientTable.Size = new Size(180, 22);
            clientTable.Text = "Client";
            clientTable.Click += clientToolStripMenuItem_Click;
            // 
            // vehicleTable
            // 
            vehicleTable.Name = "vehicleTable";
            vehicleTable.Size = new Size(180, 22);
            vehicleTable.Text = "Vehicle";
            vehicleTable.Click += vehicleToolStripMenuItem_Click;
            // 
            // accessoryTable
            // 
            accessoryTable.Name = "accessoryTable";
            accessoryTable.Size = new Size(180, 22);
            accessoryTable.Text = "Accessory";
            accessoryTable.Click += accessoryToolStripMenuItem_Click;
            // 
            // testdriverrecordTable
            // 
            testdriverrecordTable.Name = "testdriverrecordTable";
            testdriverrecordTable.Size = new Size(180, 22);
            testdriverrecordTable.Text = "Test_drive_record";
            testdriverrecordTable.Click += testdriverecordToolStripMenuItem_Click;
            // 
            // vehiclefeeTable
            // 
            vehiclefeeTable.Name = "vehiclefeeTable";
            vehiclefeeTable.Size = new Size(180, 22);
            vehiclefeeTable.Text = "Vehicle_fee";
            vehiclefeeTable.Click += vehiclefeeTable_Click;
            // 
            // accessoryfeeTable
            // 
            accessoryfeeTable.Name = "accessoryfeeTable";
            accessoryfeeTable.Size = new Size(180, 22);
            accessoryfeeTable.Text = "Accessory_fee";
            accessoryfeeTable.Click += accessoryfeeTable_Click;
            // 
            // leasingrecordTable
            // 
            leasingrecordTable.Name = "leasingrecordTable";
            leasingrecordTable.Size = new Size(180, 22);
            leasingrecordTable.Text = "Leasing_record";
            leasingrecordTable.Click += leasingRecordToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ControlLight;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(42, 9);
            label1.Name = "label1";
            label1.Size = new Size(148, 21);
            label1.TabIndex = 2;
            label1.Text = "Пошук інформації";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaption;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(valueTextBox);
            panel1.Controls.Add(searchBox);
            panel1.Controls.Add(comboBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(562, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 212);
            panel1.TabIndex = 3;
            // 
            // valueTextBox
            // 
            valueTextBox.Location = new Point(3, 99);
            valueTextBox.Name = "valueTextBox";
            valueTextBox.Size = new Size(218, 23);
            valueTextBox.TabIndex = 5;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(3, 160);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(218, 23);
            searchBox.TabIndex = 4;
            searchBox.Text = "Знайти";
            searchBox.UseVisualStyleBackColor = true;
            searchBox.Click += searchBox_Click;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Location = new Point(3, 45);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(218, 23);
            comboBox.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(updateRecordButton);
            panel2.Controls.Add(deleteRecordButton);
            panel2.Controls.Add(addRecordButton);
            panel2.Location = new Point(562, 306);
            panel2.Name = "panel2";
            panel2.Size = new Size(226, 221);
            panel2.TabIndex = 4;
            // 
            // updateRecordButton
            // 
            updateRecordButton.Location = new Point(56, 147);
            updateRecordButton.Name = "updateRecordButton";
            updateRecordButton.Size = new Size(125, 47);
            updateRecordButton.TabIndex = 4;
            updateRecordButton.Text = "Оновити запис";
            updateRecordButton.UseVisualStyleBackColor = true;
            updateRecordButton.Click += updateRecordButton_Click;
            // 
            // deleteRecordButton
            // 
            deleteRecordButton.Location = new Point(56, 86);
            deleteRecordButton.Name = "deleteRecordButton";
            deleteRecordButton.Size = new Size(125, 43);
            deleteRecordButton.TabIndex = 3;
            deleteRecordButton.Text = "Видалити запис";
            deleteRecordButton.UseVisualStyleBackColor = true;
            deleteRecordButton.Click += deleteRecordButton_Click;
            // 
            // addRecordButton
            // 
            addRecordButton.Location = new Point(56, 24);
            addRecordButton.Name = "addRecordButton";
            addRecordButton.Size = new Size(125, 45);
            addRecordButton.TabIndex = 0;
            addRecordButton.Text = "Додати запис";
            addRecordButton.UseVisualStyleBackColor = true;
            addRecordButton.Click += addRecordButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(592, 283);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 5;
            label2.Text = "Керування записами";
            // 
            // panel3
            // 
            panel3.Controls.Add(newValueTextBox);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(idTextBox);
            panel3.Controls.Add(columnsComboBox);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(12, 363);
            panel3.Name = "panel3";
            panel3.Size = new Size(534, 164);
            panel3.TabIndex = 6;
            // 
            // newValueTextBox
            // 
            newValueTextBox.Location = new Point(136, 115);
            newValueTextBox.Name = "newValueTextBox";
            newValueTextBox.Size = new Size(218, 23);
            newValueTextBox.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label6.Location = new Point(10, 123);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 11;
            label6.Text = "Нове значення ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 204);
            label5.Location = new Point(10, 76);
            label5.Name = "label5";
            label5.Size = new Size(120, 15);
            label5.TabIndex = 10;
            label5.Text = "Поле для оновлення ";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label4.Location = new Point(95, 39);
            label4.Name = "label4";
            label4.Size = new Size(28, 21);
            label4.TabIndex = 9;
            label4.Text = "ID";
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(136, 41);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(218, 23);
            idTextBox.TabIndex = 8;
            // 
            // columnsComboBox
            // 
            columnsComboBox.FormattingEnabled = true;
            columnsComboBox.Location = new Point(136, 76);
            columnsComboBox.Name = "columnsComboBox";
            columnsComboBox.Size = new Size(218, 23);
            columnsComboBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 11.25F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 204);
            label3.Location = new Point(3, 9);
            label3.Name = "label3";
            label3.Size = new Size(141, 20);
            label3.TabIndex = 6;
            label3.Text = "Оновлення запису";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 539);
            Controls.Add(panel3);
            Controls.Add(label2);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Carshop control system";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private Label label1;
        private Panel panel1;
        private TextBox valueTextBox;
        private Button searchBox;
        private ComboBox comboBox;
        private ToolStripMenuItem tableToolStripMenuItem;
        private ToolStripMenuItem clientTable;
        private ToolStripMenuItem vehicleTable;
        private ToolStripMenuItem accessoryTable;
        private ToolStripMenuItem testdriverrecordTable;
        private ToolStripMenuItem vehiclefeeTable;
        private ToolStripMenuItem accessoryfeeTable;
        private ToolStripMenuItem leasingrecordTable;
        private Panel panel2;
        private Button addRecordButton;
        private Label label2;
        private Button updateRecordButton;
        private Button deleteRecordButton;
        private Panel panel3;
        private Label label3;
        private ComboBox columnsComboBox;
        private TextBox idTextBox;
        private Label label5;
        private Label label4;
        private TextBox newValueTextBox;
        private Label label6;
    }
}
