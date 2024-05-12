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
            таблицяToolStripMenuItem = new ToolStripMenuItem();
            clientTable = new ToolStripMenuItem();
            vehicleTable = new ToolStripMenuItem();
            accessoryTable = new ToolStripMenuItem();
            testdriverrecordTable = new ToolStripMenuItem();
            vehiclefeeTable = new ToolStripMenuItem();
            accessoryfeeTable = new ToolStripMenuItem();
            leasingrecordTable = new ToolStripMenuItem();
            addToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 27);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 411);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { таблицяToolStripMenuItem, addToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // таблицяToolStripMenuItem
            // 
            таблицяToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { clientTable, vehicleTable, accessoryTable, testdriverrecordTable, vehiclefeeTable, accessoryfeeTable, leasingrecordTable });
            таблицяToolStripMenuItem.Name = "таблицяToolStripMenuItem";
            таблицяToolStripMenuItem.Size = new Size(65, 20);
            таблицяToolStripMenuItem.Text = "Таблиця";
            // 
            // clientTable
            // 
            clientTable.Checked = true;
            clientTable.CheckState = CheckState.Checked;
            clientTable.Name = "clientTable";
            clientTable.Size = new Size(187, 22);
            clientTable.Text = "Клієнти";
            clientTable.Click += клієнтиToolStripMenuItem_Click;
            // 
            // vehicleTable
            // 
            vehicleTable.Name = "vehicleTable";
            vehicleTable.Size = new Size(187, 22);
            vehicleTable.Text = "Автомобілі";
            vehicleTable.Click += автомобіліToolStripMenuItem_Click;
            // 
            // accessoryTable
            // 
            accessoryTable.Name = "accessoryTable";
            accessoryTable.Size = new Size(187, 22);
            accessoryTable.Text = "Аксесуари";
            accessoryTable.Click += аксесуариToolStripMenuItem_Click;
            // 
            // testdriverrecordTable
            // 
            testdriverrecordTable.Name = "testdriverrecordTable";
            testdriverrecordTable.Size = new Size(187, 22);
            testdriverrecordTable.Text = "Запис на тест-драйв";
            testdriverrecordTable.Click += записНаТестдрайвToolStripMenuItem_Click;
            // 
            // vehiclefeeTable
            // 
            vehiclefeeTable.Name = "vehiclefeeTable";
            vehiclefeeTable.Size = new Size(187, 22);
            vehiclefeeTable.Text = "Плата за автомобіль";
            vehiclefeeTable.Click += vehiclefeeTable_Click;
            // 
            // accessoryfeeTable
            // 
            accessoryfeeTable.Name = "accessoryfeeTable";
            accessoryfeeTable.Size = new Size(187, 22);
            accessoryfeeTable.Text = "Плата за аксесуари";
            accessoryfeeTable.Click += accessoryfeeTable_Click;
            // 
            // leasingrecordTable
            // 
            leasingrecordTable.Name = "leasingrecordTable";
            leasingrecordTable.Size = new Size(187, 22);
            leasingrecordTable.Text = "Запис лізингу";
            leasingrecordTable.Click += записЛізингуToolStripMenuItem_Click;
            // 
            // addToolStripMenuItem
            // 
            addToolStripMenuItem.Name = "addToolStripMenuItem";
            addToolStripMenuItem.Size = new Size(92, 20);
            addToolStripMenuItem.Text = "Додати запис";
            addToolStripMenuItem.Click += додатиToolStripMenuItem_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dataGridView1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "Carshop control system";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem таблицяToolStripMenuItem;
        private ToolStripMenuItem clientTable;
        private ToolStripMenuItem vehicleTable;
        private ToolStripMenuItem accessoryTable;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem testdriverrecordTable;
        private ToolStripMenuItem vehiclefeeTable;
        private ToolStripMenuItem accessoryfeeTable;
        private ToolStripMenuItem leasingrecordTable;
    }
}
