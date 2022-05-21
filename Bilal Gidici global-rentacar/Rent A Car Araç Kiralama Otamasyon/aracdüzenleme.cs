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
    public partial class aracdüzenleme : Form
    {
        public aracdüzenleme()
        {
            InitializeComponent();
        }
        int guncellemegirdi = 0;
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
            OleDbCommand komut = new OleDbCommand("insert into araçlar (Plaka,Marka,Seri,Model,Renk,MotorGücü,MotorHacmi,BakımTarihi,Kilometre,YakıtTürü,GünlükFiyat,Açıklama) values (@Plaka,@Marka,@Seri,@Model,@Renk,@MotorGücü,@MotorHacmi,@BakımTarihi,@Kilometre,@YakıtTürü,@GünlükFiyat,@Açıklama)", baglan);
            komut.Parameters.AddWithValue("@Plaka", textBox1.Text);
            komut.Parameters.AddWithValue("@Marka", textBox2.Text);
            komut.Parameters.AddWithValue("@Seri", textBox3.Text);
            komut.Parameters.AddWithValue("@Model", textBox4.Text);
            komut.Parameters.AddWithValue("@Renk", textBox5.Text);
            komut.Parameters.AddWithValue("@MotorGücü", textBox6.Text);
            komut.Parameters.AddWithValue("@MotorHacmi", textBox7.Text);
            komut.Parameters.AddWithValue("@BakımTarihi", dateTimePicker1.Text);
            komut.Parameters.AddWithValue("@Kilometre", textBox8.Text);
            komut.Parameters.AddWithValue("@YakıtTürü", comboBox1.Text);
            komut.Parameters.AddWithValue("@GünlükFiyat", textBox9.Text);
            komut.Parameters.AddWithValue("@Açıklama", textBox10.Text);
            komut.ExecuteNonQuery();
            verilerigöster("Select * from araçlar");
            baglan.Close();
            baglan.Open();
            OleDbCommand komutt = new OleDbCommand("insert into boşaraçlar (Plaka,Marka,Seri,Model,Renk) values (@Plaka,@Marka,@Seri,@Model,@Renk)", baglan);
            komutt.Parameters.AddWithValue("@Plaka", textBox1.Text);
            komutt.Parameters.AddWithValue("@Marka", textBox2.Text);
            komutt.Parameters.AddWithValue("@Seri", textBox3.Text);
            komutt.Parameters.AddWithValue("@Model", textBox4.Text);
            komutt.Parameters.AddWithValue("@Renk", textBox5.Text);
            komutt.ExecuteNonQuery();
            baglan.Close();
            MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Kaydedildi.");
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            comboBox1.Text = "";
        }

        private void aracdüzenleme_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from araçlar");
            label14.Text = DateTime.Now.ToLongDateString();
        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (guncellemegirdi == 0)
            {
                string IsimGirisi = Interaction.InputBox("Güncellemek İstediğiniz Aracın Plakasını Yazınız...", "Güncelleme İşlemi", "");
                if (IsimGirisi != "")
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Güncellemek İstediğiniz Aracın Plakası : " + IsimGirisi + " Güncellemek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        guncellemegirdi = 1;
                        baglan.Open();
                        OleDbCommand komut = new OleDbCommand("select * from araçlar where Plaka='" + IsimGirisi + "'", baglan);
                        komut.ExecuteNonQuery();
                        OleDbDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            textBox1.Text = dr["Plaka"].ToString();
                            textBox2.Text = dr["Marka"].ToString();
                            textBox3.Text = dr["Seri"].ToString();
                            textBox4.Text = dr["Model"].ToString();
                            textBox5.Text = dr["Renk"].ToString();
                            textBox6.Text = dr["MotorGücü"].ToString();
                            textBox7.Text = dr["MotorHacmi"].ToString();
                            dateTimePicker1.Text = dr["BakımTarihi"].ToString();
                            textBox8.Text = dr["Kilometre"].ToString();
                            comboBox1.Text = dr["YakıtTürü"].ToString();
                            textBox9.Text = dr["GünlükFiyat"].ToString();
                            textBox10.Text = dr["Açıklama"].ToString();
                        }

                        dr.Close();
                        komut.Dispose();
                        baglan.Close();

                    }
                    else
                    {
                        guncellemegirdi = 0;
                    }
                }
            }
            else
            {
                guncellemegirdi = 0;
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("Update araçlar set Marka='" + textBox2.Text + "',Seri='" + textBox3.Text + "',Model='" + textBox4.Text + "',Renk='" + textBox5.Text + "',MotorGücü='" + textBox6.Text + "',MotorHacmi='" + textBox7.Text + "',BakımTarihi='" + dateTimePicker1.Text + "',Kilometre='" + textBox8.Text + "',YakıtTürü='" + comboBox1.Text + "',GünlükFiyat='" + textBox9.Text + "',Açıklama='" + textBox10.Text + "' where Plaka='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from araçlar");
                baglan.Close();
                MessageBox.Show("Girdiğiniz Bilgiler Başarıyla Güncellendi.");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                comboBox1.Text = "";
            }



           
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand komutt = new OleDbCommand();
            OleDbCommand komutt2 = new OleDbCommand();
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Aracın Plakasını Giriniz.", "Silmek İstediğiniz Aracın Plakasını Giriniz.", "");
            if (IsimGirisi != "")
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Silinecek Aracın Plakası : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from araçlar where Plaka='" + IsimGirisi + "'";
                    komutt.ExecuteNonQuery();
                    komutt2.Connection = baglan;
                    komutt2.CommandText = "delete from boşaraçlar where Plaka='" + IsimGirisi + "'";
                    komutt2.ExecuteNonQuery();
                    baglan.Close();
                    verilerigöster("Select * from araçlar");
                    MessageBox.Show("Silmek İstediğiniz Plaka Başarıyla Silinmiştir.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    comboBox1.Text = "";
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
                }
            }
        }

        private void aracdüzenleme_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
