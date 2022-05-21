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
    public partial class sözlesmelerilistele : Form
    {
        public sözlesmelerilistele()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            comboBox_Adsoyad.DataSource = ds.Tables[0];
            comboBox_Adsoyad.DisplayMember = "AdSoyad";
            comboBox_Adsoyad.ValueMember = "Sıra";
        }
        private void sözlesmelerilistele_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from yenisözleşme");

        }

        private void sözlesmelerilistele_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox_Adsoyad_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("Select * From yenisözleşme where AdSoyad='" + comboBox_Adsoyad.Text + "'", baglan);
            baglan.Open();
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox_Adsoyad.Text == read["AdSoyad"].ToString())
                {

                    //textBox13.Text = read["Plaka"].ToString();
                    textBox_Sözlesmetarihi.Text = read["SözleşmeTarihi"].ToString();
                    textBox_tckimlik.Text = read["TcKimlik"].ToString();
                    textBox_cinsiyet.Text = read["Cinsiyet"].ToString();
                    textBox_dogumtarihi.Text = read["DoğumTarihi"].ToString();
                    textBox_Dogumyeri.Text = read["DoğumYeri"].ToString();
                    textBox_tel.Text = read["CepTelefon"].ToString();
                    textBox_email.Text = read["EMail"].ToString();
                    textBox_Adres.Text = read["Adres"].ToString();
                    textBox_ehliyetno.Text = read["EhliyetNo"].ToString();           
                    textBox_ehliyetverilmeyer.Text = read["EhliyetVerilenYer"].ToString();
                    dateTimePicker_cikis.Text = read["ÇıkışZamanı"].ToString();
                    dateTimePicker_donus.Text = read["DönüşZamanı"].ToString();
                    textBox_kullanimsure.Text = read["KullanımSüresi"].ToString();
                    textBox_vekiladsoyad.Text = read["VekilAdSoyad"].ToString();
                    textBox_vekilceptel.Text = read["VekilCepTelefon"].ToString();
                    textBox_plaka.Text = read["Plaka"].ToString();
                    textBox_marka.Text = read["Marka"].ToString();
                    textBox_model.Text = read["Model"].ToString();
                    textBox_renk.Text = read["Renk"].ToString();
                    textBox_aciklama.Text = read["Açıklama"].ToString();
                    textBox_toplamtutar.Text = read["ToplamTutar"].ToString();
                }
            }

            komut.Dispose();
            baglan.Close();
        }
    }
}
