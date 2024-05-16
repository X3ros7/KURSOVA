namespace Kursova
{
    partial class SearchForm
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
            tabControl1 = new TabControl();
            clientTabPage = new TabPage();
            vehicleTabPage = new TabPage();
            accessoryTabPage = new TabPage();
            testDriveTabPage = new TabPage();
            leasingRecordTabPage = new TabPage();
            vehicleFeeTabPage = new TabPage();
            accessoryFeeTabPage = new TabPage();
            label1 = new Label();
            searchButton = new Button();
            tabControl1.SuspendLayout();
            clientTabPage.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(clientTabPage);
            tabControl1.Controls.Add(vehicleTabPage);
            tabControl1.Controls.Add(accessoryTabPage);
            tabControl1.Controls.Add(testDriveTabPage);
            tabControl1.Controls.Add(leasingRecordTabPage);
            tabControl1.Controls.Add(vehicleFeeTabPage);
            tabControl1.Controls.Add(accessoryFeeTabPage);
            tabControl1.Location = new Point(12, 49);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(399, 306);
            tabControl1.TabIndex = 0;
            // 
            // clientTabPage
            // 
            clientTabPage.Controls.Add(label1);
            clientTabPage.Location = new Point(4, 24);
            clientTabPage.Name = "clientTabPage";
            clientTabPage.Padding = new Padding(3);
            clientTabPage.Size = new Size(391, 278);
            clientTabPage.TabIndex = 0;
            clientTabPage.Text = "Клієнт";
            clientTabPage.UseVisualStyleBackColor = true;
            // 
            // vehicleTabPage
            // 
            vehicleTabPage.Location = new Point(4, 24);
            vehicleTabPage.Name = "vehicleTabPage";
            vehicleTabPage.Padding = new Padding(3);
            vehicleTabPage.Size = new Size(391, 278);
            vehicleTabPage.TabIndex = 1;
            vehicleTabPage.Text = "Автомобіль";
            vehicleTabPage.UseVisualStyleBackColor = true;
            // 
            // accessoryTabPage
            // 
            accessoryTabPage.Location = new Point(4, 24);
            accessoryTabPage.Name = "accessoryTabPage";
            accessoryTabPage.Size = new Size(391, 278);
            accessoryTabPage.TabIndex = 2;
            accessoryTabPage.Text = "Аксесуар";
            accessoryTabPage.UseVisualStyleBackColor = true;
            // 
            // testDriveTabPage
            // 
            testDriveTabPage.Location = new Point(4, 24);
            testDriveTabPage.Name = "testDriveTabPage";
            testDriveTabPage.Size = new Size(391, 278);
            testDriveTabPage.TabIndex = 3;
            testDriveTabPage.Text = "Тест-драйв";
            testDriveTabPage.UseVisualStyleBackColor = true;
            // 
            // leasingRecordTabPage
            // 
            leasingRecordTabPage.Location = new Point(4, 24);
            leasingRecordTabPage.Name = "leasingRecordTabPage";
            leasingRecordTabPage.Size = new Size(391, 278);
            leasingRecordTabPage.TabIndex = 4;
            leasingRecordTabPage.Text = "Лізинг";
            leasingRecordTabPage.UseVisualStyleBackColor = true;
            // 
            // vehicleFeeTabPage
            // 
            vehicleFeeTabPage.Location = new Point(4, 24);
            vehicleFeeTabPage.Name = "vehicleFeeTabPage";
            vehicleFeeTabPage.Size = new Size(391, 278);
            vehicleFeeTabPage.TabIndex = 5;
            vehicleFeeTabPage.Text = "Придбання авто";
            vehicleFeeTabPage.UseVisualStyleBackColor = true;
            // 
            // accessoryFeeTabPage
            // 
            accessoryFeeTabPage.Location = new Point(4, 24);
            accessoryFeeTabPage.Name = "accessoryFeeTabPage";
            accessoryFeeTabPage.Size = new Size(391, 278);
            accessoryFeeTabPage.TabIndex = 6;
            accessoryFeeTabPage.Text = "Придбання аксесуару";
            accessoryFeeTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 27);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // searchButton
            // 
            searchButton.Location = new Point(16, 361);
            searchButton.Name = "searchButton";
            searchButton.Size = new Size(391, 23);
            searchButton.TabIndex = 1;
            searchButton.Text = "Пошук";
            searchButton.UseVisualStyleBackColor = true;
            // 
            // SearchForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(423, 387);
            Controls.Add(searchButton);
            Controls.Add(tabControl1);
            Name = "SearchForm";
            Text = "SearchForm";
            tabControl1.ResumeLayout(false);
            clientTabPage.ResumeLayout(false);
            clientTabPage.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage clientTabPage;
        private TabPage vehicleTabPage;
        private TabPage accessoryTabPage;
        private TabPage testDriveTabPage;
        private TabPage leasingRecordTabPage;
        private TabPage vehicleFeeTabPage;
        private TabPage accessoryFeeTabPage;
        private Label label1;
        private Button searchButton;
    }
}