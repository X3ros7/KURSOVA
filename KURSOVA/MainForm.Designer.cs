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
            valueBox = new TextBox();
            searchBox = new Button();
            comboBox = new ComboBox();
            panel2 = new Panel();
            updateRecordButton = new Button();
            deleteRecordButton = new Button();
            addRecordButton = new Button();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(534, 481);
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
            clientTable.Size = new Size(164, 22);
            clientTable.Text = "Client";
            clientTable.Click += clientToolStripMenuItem_Click;
            // 
            // vehicleTable
            // 
            vehicleTable.Name = "vehicleTable";
            vehicleTable.Size = new Size(164, 22);
            vehicleTable.Text = "Vehicle";
            vehicleTable.Click += vehicleToolStripMenuItem_Click;
            // 
            // accessoryTable
            // 
            accessoryTable.Name = "accessoryTable";
            accessoryTable.Size = new Size(164, 22);
            accessoryTable.Text = "Accessory";
            accessoryTable.Click += accessoryToolStripMenuItem_Click;
            // 
            // testdriverrecordTable
            // 
            testdriverrecordTable.Name = "testdriverrecordTable";
            testdriverrecordTable.Size = new Size(164, 22);
            testdriverrecordTable.Text = "Test_drive_record";
            testdriverrecordTable.Click += testdriverecordToolStripMenuItem_Click;
            // 
            // vehiclefeeTable
            // 
            vehiclefeeTable.Name = "vehiclefeeTable";
            vehiclefeeTable.Size = new Size(164, 22);
            vehiclefeeTable.Text = "Vehicle_fee";
            vehiclefeeTable.Click += vehiclefeeTable_Click;
            // 
            // accessoryfeeTable
            // 
            accessoryfeeTable.Name = "accessoryfeeTable";
            accessoryfeeTable.Size = new Size(164, 22);
            accessoryfeeTable.Text = "Accessory_fee";
            accessoryfeeTable.Click += accessoryfeeTable_Click;
            // 
            // leasingrecordTable
            // 
            leasingrecordTable.Name = "leasingrecordTable";
            leasingrecordTable.Size = new Size(164, 22);
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
            panel1.Controls.Add(valueBox);
            panel1.Controls.Add(searchBox);
            panel1.Controls.Add(comboBox);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(562, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(226, 273);
            panel1.TabIndex = 3;
            // 
            // valueBox
            // 
            valueBox.Location = new Point(3, 99);
            valueBox.Name = "valueBox";
            valueBox.Size = new Size(206, 23);
            valueBox.TabIndex = 5;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(3, 160);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(206, 23);
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
            comboBox.Size = new Size(206, 23);
            comboBox.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(updateRecordButton);
            panel2.Controls.Add(deleteRecordButton);
            panel2.Controls.Add(addRecordButton);
            panel2.Location = new Point(565, 348);
            panel2.Name = "panel2";
            panel2.Size = new Size(223, 160);
            panel2.TabIndex = 4;
            // 
            // updateRecordButton
            // 
            updateRecordButton.Location = new Point(56, 107);
            updateRecordButton.Name = "updateRecordButton";
            updateRecordButton.Size = new Size(111, 39);
            updateRecordButton.TabIndex = 4;
            updateRecordButton.Text = "Оновити запис";
            updateRecordButton.UseVisualStyleBackColor = true;
            updateRecordButton.Click += updateRecordButton_Click;
            // 
            // deleteRecordButton
            // 
            deleteRecordButton.Location = new Point(56, 62);
            deleteRecordButton.Name = "deleteRecordButton";
            deleteRecordButton.Size = new Size(111, 39);
            deleteRecordButton.TabIndex = 3;
            deleteRecordButton.Text = "Видалити запис";
            deleteRecordButton.UseVisualStyleBackColor = true;
            deleteRecordButton.Click += deleteRecordButton_Click;
            // 
            // addRecordButton
            // 
            addRecordButton.Location = new Point(56, 17);
            addRecordButton.Name = "addRecordButton";
            addRecordButton.Size = new Size(111, 39);
            addRecordButton.TabIndex = 0;
            addRecordButton.Text = "Додати запис";
            addRecordButton.UseVisualStyleBackColor = true;
            addRecordButton.Click += addRecordButton_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label2.Location = new Point(595, 325);
            label2.Name = "label2";
            label2.Size = new Size(161, 20);
            label2.TabIndex = 5;
            label2.Text = "Керування записами";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 539);
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
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private Label label1;
        private Panel panel1;
        private TextBox valueBox;
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
    }
}
