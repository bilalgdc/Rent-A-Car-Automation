using System;
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
    public partial class bosaraclar : Form
    {
        public bosaraclar()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            comboBox_BosAraclar.DataSource = ds.Tables[0];
            comboBox_BosAraclar.DisplayMember = "Plaka";
            comboBox_BosAraclar.ValueMember = "Plaka";
        }
        private void bosaraclar_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from boşaraçlar");
        }

        private void bosaraclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void comboBox_BosAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("Select * From boşaraçlar where Plaka='" + comboBox_BosAraclar.Text + "'", baglan);
            baglan.Open();
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox_BosAraclar.Text == read["Plaka"].ToString())
                {

                    //textBox13.Text = read["Plaka"].ToString();
                    textBox_Marka.Text = read["Marka"].ToString();
                    textBox_Seri.Text = read["Seri"].ToString();
                    textBox_Model.Text = read["Model"].ToString();
                    textBox_Renk.Text = read["Renk"].ToString();
                }
            }

            komut.Dispose();
            baglan.Close();
        }
    }
}
