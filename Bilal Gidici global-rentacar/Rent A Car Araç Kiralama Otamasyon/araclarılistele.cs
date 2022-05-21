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
    public partial class araclarılistele : Form
    {
        public araclarılistele()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            comboBox_Araclar.DataSource = ds.Tables[0];
            comboBox_Araclar.DisplayMember = "Plaka";
            comboBox_Araclar.ValueMember = "Plaka";
        }
        private void araclarılistele_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from araçlar");
            
            
        }

        private void araclarılistele_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void comboBox_Araclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("Select * From araçlar where Plaka='" + comboBox_Araclar.Text + "'", baglan);
            baglan.Open();
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox_Araclar.Text == read["Plaka"].ToString())
                {

                    //textBox13.Text = read["Plaka"].ToString();
                    textBox_Marka.Text = read["Marka"].ToString();
                    textBox_Seri.Text = read["Seri"].ToString();
                    textBox_Model.Text = read["Model"].ToString();
                    textBox_Renk.Text = read["Renk"].ToString();
                    textBox_Motorgucu.Text = read["MotorGücü"].ToString();
                    textBox_Motorhacmi.Text = read["MotorHacmi"].ToString();
                    textBox_BakimTarihi.Text = read["BakımTarihi"].ToString();
                    textBox_Km.Text = read["Kilometre"].ToString();
                    textBox_Yakit.Text = read["YakıtTürü"].ToString();
                    textBox_Fiyat.Text = read["GünlükFiyat"].ToString();
                    textBox_Aciklama.Text = read["Açıklama"].ToString();


                }
            }
            komut.Dispose();
            baglan.Close();
        }
    }
}
