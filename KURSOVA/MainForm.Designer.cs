﻿namespace Kursova
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
            clientToolStripMenu = new ToolStripMenuItem();
            vehicleToolStripMenu = new ToolStripMenuItem();
            accessoryToolStripMenuItem = new ToolStripMenuItem();
            recordsToolStripMenuItem = new ToolStripMenuItem();
            vehicleFeeToolStripMenuItem = new ToolStripMenuItem();
            accessoryFeeToolStripMenuItem = new ToolStripMenuItem();
            leasingRecordToolStripMenuItem = new ToolStripMenuItem();
            тестдрайвToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            panel1 = new Panel();
            valueTextBox = new TextBox();
            searchButton = new Button();
            searchFieldBox = new ComboBox();
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
            menuStrip2 = new MenuStrip();
            додатиToolStripMenuItem = new ToolStripMenuItem();
            клієнтаToolStripMenuItem = new ToolStripMenuItem();
            автомобільToolStripMenuItem = new ToolStripMenuItem();
            аксесуарToolStripMenuItem = new ToolStripMenuItem();
            записНаТестдрайвToolStripMenuItem = new ToolStripMenuItem();
            придбанняАвтоToolStripMenuItem = new ToolStripMenuItem();
            придбанняАксесуаруToolStripMenuItem = new ToolStripMenuItem();
            лізингАвтоToolStripMenuItem = new ToolStripMenuItem();
            пошукToolStripMenuItem = new ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            menuStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(534, 306);
            dataGridView1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { clientToolStripMenu, vehicleToolStripMenu, accessoryToolStripMenuItem, recordsToolStripMenuItem, тестдрайвToolStripMenuItem });
            menuStrip1.Location = new Point(0, 24);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // clientToolStripMenu
            // 
            clientToolStripMenu.Checked = true;
            clientToolStripMenu.CheckState = CheckState.Checked;
            clientToolStripMenu.Name = "clientToolStripMenu";
            clientToolStripMenu.Size = new Size(61, 20);
            clientToolStripMenu.Text = "Клієнти";
            clientToolStripMenu.Click += клієнтиToolStripMenuItem_Click;
            // 
            // vehicleToolStripMenu
            // 
            vehicleToolStripMenu.Checked = true;
            vehicleToolStripMenu.CheckState = CheckState.Checked;
            vehicleToolStripMenu.Name = "vehicleToolStripMenu";
            vehicleToolStripMenu.Size = new Size(81, 20);
            vehicleToolStripMenu.Text = "Автомобілі";
            vehicleToolStripMenu.Click += автомобіліToolStripMenuItem_Click;
            // 
            // accessoryToolStripMenuItem
            // 
            accessoryToolStripMenuItem.Name = "accessoryToolStripMenuItem";
            accessoryToolStripMenuItem.Size = new Size(77, 20);
            accessoryToolStripMenuItem.Text = "Аксесуари";
            accessoryToolStripMenuItem.Click += аксесуариToolStripMenuItem_Click;
            // 
            // recordsToolStripMenuItem
            // 
            recordsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { vehicleFeeToolStripMenuItem, accessoryFeeToolStripMenuItem, leasingRecordToolStripMenuItem });
            recordsToolStripMenuItem.Name = "recordsToolStripMenuItem";
            recordsToolStripMenuItem.Size = new Size(73, 20);
            recordsToolStripMenuItem.Text = "Договори";
            // 
            // vehicleFeeToolStripMenuItem
            // 
            vehicleFeeToolStripMenuItem.Name = "vehicleFeeToolStripMenuItem";
            vehicleFeeToolStripMenuItem.Size = new Size(194, 22);
            vehicleFeeToolStripMenuItem.Text = "Придбання авто";
            vehicleFeeToolStripMenuItem.Click += придбанняАвтоToolStripMenuItem_Click;
            // 
            // accessoryFeeToolStripMenuItem
            // 
            accessoryFeeToolStripMenuItem.Name = "accessoryFeeToolStripMenuItem";
            accessoryFeeToolStripMenuItem.Size = new Size(194, 22);
            accessoryFeeToolStripMenuItem.Text = "Придбання аксесуару";
            accessoryFeeToolStripMenuItem.Click += придбанняАксесуаруToolStripMenuItem_Click;
            // 
            // leasingRecordToolStripMenuItem
            // 
            leasingRecordToolStripMenuItem.Name = "leasingRecordToolStripMenuItem";
            leasingRecordToolStripMenuItem.Size = new Size(194, 22);
            leasingRecordToolStripMenuItem.Text = "Лізинг автомобіля";
            leasingRecordToolStripMenuItem.Click += лізингАвтомобіляToolStripMenuItem_Click;
            // 
            // тестдрайвToolStripMenuItem
            // 
            тестдрайвToolStripMenuItem.Name = "тестдрайвToolStripMenuItem";
            тестдрайвToolStripMenuItem.Size = new Size(79, 20);
            тестдрайвToolStripMenuItem.Text = "Тест-драйв";
            тестдрайвToolStripMenuItem.Click += тестдрайвToolStripMenuItem_Click;
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
            panel1.Controls.Add(searchButton);
            panel1.Controls.Add(searchFieldBox);
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
            // searchButton
            // 
            searchButton.Location = new Point(3, 160);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(218, 23);
            searchButton.TabIndex = 4;
            searchButton.Text = "Знайти";
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchBox_Click;
            // 
            // searchFieldBox
            // 
            searchFieldBox.FormattingEnabled = true;
            searchFieldBox.Location = new Point(3, 45);
            searchFieldBox.Name = "searchFieldBox";
            searchFieldBox.Size = new Size(218, 23);
            searchFieldBox.TabIndex = 3;
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
            panel3.BorderStyle = BorderStyle.FixedSingle;
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
            // menuStrip2
            // 
            menuStrip2.Items.AddRange(new ToolStripItem[] { додатиToolStripMenuItem, пошукToolStripMenuItem });
            menuStrip2.Location = new Point(0, 0);
            menuStrip2.Name = "menuStrip2";
            menuStrip2.Size = new Size(800, 24);
            menuStrip2.TabIndex = 7;
            menuStrip2.Text = "menuStrip2";
            // 
            // додатиToolStripMenuItem
            // 
            додатиToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { клієнтаToolStripMenuItem, автомобільToolStripMenuItem, аксесуарToolStripMenuItem, записНаТестдрайвToolStripMenuItem, придбанняАвтоToolStripMenuItem, придбанняАксесуаруToolStripMenuItem, лізингАвтоToolStripMenuItem });
            додатиToolStripMenuItem.Name = "додатиToolStripMenuItem";
            додатиToolStripMenuItem.Size = new Size(58, 20);
            додатиToolStripMenuItem.Text = "Додати";
            // 
            // клієнтаToolStripMenuItem
            // 
            клієнтаToolStripMenuItem.Name = "клієнтаToolStripMenuItem";
            клієнтаToolStripMenuItem.Size = new Size(192, 22);
            клієнтаToolStripMenuItem.Text = "клієнта";
            клієнтаToolStripMenuItem.Click += клієнтаToolStripMenuItem_Click;
            // 
            // автомобільToolStripMenuItem
            // 
            автомобільToolStripMenuItem.Name = "автомобільToolStripMenuItem";
            автомобільToolStripMenuItem.Size = new Size(192, 22);
            автомобільToolStripMenuItem.Text = "автомобіль";
            автомобільToolStripMenuItem.Click += автомобільToolStripMenuItem_Click;
            // 
            // аксесуарToolStripMenuItem
            // 
            аксесуарToolStripMenuItem.Name = "аксесуарToolStripMenuItem";
            аксесуарToolStripMenuItem.Size = new Size(192, 22);
            аксесуарToolStripMenuItem.Text = "аксесуар ";
            аксесуарToolStripMenuItem.Click += аксесуарToolStripMenuItem_Click;
            // 
            // записНаТестдрайвToolStripMenuItem
            // 
            записНаТестдрайвToolStripMenuItem.Name = "записНаТестдрайвToolStripMenuItem";
            записНаТестдрайвToolStripMenuItem.Size = new Size(192, 22);
            записНаТестдрайвToolStripMenuItem.Text = "запис на тест-драйв";
            записНаТестдрайвToolStripMenuItem.Click += записНаТестдрайвToolStripMenuItem_Click;
            // 
            // придбанняАвтоToolStripMenuItem
            // 
            придбанняАвтоToolStripMenuItem.Name = "придбанняАвтоToolStripMenuItem";
            придбанняАвтоToolStripMenuItem.Size = new Size(192, 22);
            придбанняАвтоToolStripMenuItem.Text = "придбання авто";
            придбанняАвтоToolStripMenuItem.Click += придбанняАвтоToolStripMenuItem_Click_1;
            // 
            // придбанняАксесуаруToolStripMenuItem
            // 
            придбанняАксесуаруToolStripMenuItem.Name = "придбанняАксесуаруToolStripMenuItem";
            придбанняАксесуаруToolStripMenuItem.Size = new Size(192, 22);
            придбанняАксесуаруToolStripMenuItem.Text = "придбання аксесуару";
            // 
            // лізингАвтоToolStripMenuItem
            // 
            лізингАвтоToolStripMenuItem.Name = "лізингАвтоToolStripMenuItem";
            лізингАвтоToolStripMenuItem.Size = new Size(192, 22);
            лізингАвтоToolStripMenuItem.Text = "лізинг авто";
            // 
            // пошукToolStripMenuItem
            // 
            пошукToolStripMenuItem.Name = "пошукToolStripMenuItem";
            пошукToolStripMenuItem.Size = new Size(58, 20);
            пошукToolStripMenuItem.Text = "Пошук";
            пошукToolStripMenuItem.Click += пошукToolStripMenuItem_Click;
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
            Controls.Add(menuStrip2);
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
            menuStrip2.ResumeLayout(false);
            menuStrip2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public DataGridView dataGridView1;
        private MenuStrip menuStrip1;
        private Label label1;
        private Panel panel1;
        private TextBox valueTextBox;
        private Button searchButton;
        private ComboBox searchFieldBox;
        private ToolStripMenuItem clientToolStripMenu;
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
        private ToolStripMenuItem vehicleToolStripMenu;
        private ToolStripMenuItem accessoryToolStripMenuItem;
        private ToolStripMenuItem recordsToolStripMenuItem;
        private ToolStripMenuItem vehicleFeeToolStripMenuItem;
        private ToolStripMenuItem accessoryFeeToolStripMenuItem;
        private ToolStripMenuItem leasingRecordToolStripMenuItem;
        private ToolStripMenuItem тестдрайвToolStripMenuItem;
        private MenuStrip menuStrip2;
        private ToolStripMenuItem пошукToolStripMenuItem;
        private ToolStripMenuItem додатиToolStripMenuItem;
        private ToolStripMenuItem клієнтаToolStripMenuItem;
        private ToolStripMenuItem автомобільToolStripMenuItem;
        private ToolStripMenuItem аксесуарToolStripMenuItem;
        private ToolStripMenuItem записНаТестдрайвToolStripMenuItem;
        private ToolStripMenuItem придбанняАвтоToolStripMenuItem;
        private ToolStripMenuItem придбанняАксесуаруToolStripMenuItem;
        private ToolStripMenuItem лізингАвтоToolStripMenuItem;
    }
}
