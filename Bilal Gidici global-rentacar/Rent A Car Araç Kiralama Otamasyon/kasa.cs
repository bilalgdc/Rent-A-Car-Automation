﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class kasa : Form
    {
        public kasa()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }
        public void giderlerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }
        private void kasa_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from kasa");
            giderlerigöster("Select * from giderişlemleri");
            dataGridView1.Columns[0].Visible = false;
            dataGridView2.Columns[0].Visible = false;

            if (dataGridView1.RowCount > 1)
            {
                decimal iTotal = 0;

                for (int index = 0; index <=
                    dataGridView1.RowCount - 1; index++)
                {
                    iTotal +=Convert.ToDecimal(dataGridView1.Rows[index].Cells[4].Value);
                }
                label2.Text = iTotal.ToString();

                if (dataGridView2.RowCount > 1)
                {
                    decimal iTotall = 0;

                    for (int index = 0; index <=
                        dataGridView2.RowCount - 1; index++)
                    {
                        iTotall +=
                           Convert.ToDecimal(dataGridView2.Rows[index].Cells[3].Value);
                    }
                    label3.Text = iTotall.ToString();
                    double sayı1, sayı2;
                    double fark;

                    sayı1 = Convert.ToDouble(label2.Text);
                    sayı2 = Convert.ToDouble(label3.Text);

                    fark = sayı1 - sayı2;
                    label4.Text = fark.ToString() +(" TL");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
