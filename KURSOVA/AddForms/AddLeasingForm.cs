﻿using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Xml.Linq;
using Kursova.utils;
using Kursova.Models;

namespace Kursova
{
    public partial class AddLeasingForm : Form
    {
        private string connString;
        private MainForm mainForm;

        public AddLeasingForm(string connString, MainForm mainForm)
        {
            InitializeComponent();
            this.connString = connString;
            this.mainForm = mainForm;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string clientId = clientIdBox.Text;
            string vehicleId = vehicleIdBox.Text;
            string date = dateBox.Text;
            string endDate = endDateBox.Text;

            if (StringChecker.isNullOrEmpty(clientId, vehicleId, date, endDate))
            {
                MessageBox.Show("Not all values was entered.");
                return;
            }

            var leasingRecord = new LeasingRecord(0, int.Parse(clientId), int.Parse(vehicleId), DateTime.Parse(date), DateTime.Parse(endDate));

            NpgsqlConnection conn = new NpgsqlConnection(connString);
            NpgsqlCommand cmd = CreateRecord.GenerateCommand(leasingRecord);

            conn.Open();
            cmd.Connection = conn;
            var executor = new CommandExecutor(conn);
            var dataTable = new DataTable();
            if (executor.ExecuteCommand(cmd, out dataTable))
            {
                MessageBox.Show("Запис про аксесуар було додано до системи");
                mainForm.dataGridView1.DataSource = dataTable;
                this.Close();
            }
        }
    }
}
