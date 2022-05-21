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
using Microsoft.VisualBasic;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class giderişlemleri : Form
    {
        public giderişlemleri()
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
        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            OleDbCommand komut = new OleDbCommand("insert into giderişlemleri (GiderTarihi,GiderAçıklama,GiderTutarı) values (@GiderTarihi,@GiderAçıklama,@GiderTutarı)", baglan);
            komut.Parameters.AddWithValue("@GiderTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@GiderAçıklama", textBox1.Text);
            komut.Parameters.AddWithValue("@GiderTutarı", textBox2.Text);
            komut.ExecuteNonQuery();
            baglan.Close();
            verilerigöster("Select * from giderişlemleri");
            MessageBox.Show("Kullanıcı Başarıyla Eklenmiştir...");
            textBox1.Clear();
            textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OleDbCommand komutt = new OleDbCommand();
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Giderin Açıklamasını Yazınız...", "Silme İşlemi", "");
            if (IsimGirisi != "")
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Silmek İstediğiniz Giderin Açıklaması : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from giderişlemleri where GiderAçıklama='" + IsimGirisi + "'";
                    komutt.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Gider Başarıyla Silinmiştir...");
                    verilerigöster("Select * from giderişlemleri");
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Gider Silinmedi !");
                }
            }
        }

        private void giderişlemleri_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from giderişlemleri");
            dataGridView1.Columns[0].Visible = false;
        }

        private void giderişlemleri_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }
    }
}
