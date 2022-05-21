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
using GDC_Arac_Kiralama;
using Microsoft.Reporting.WinForms;
using System.Data.SqlClient;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class yenisözlesme : Form
    {
        public yenisözlesme()
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
        private void yenisözlesme_Load(object sender, EventArgs e)
        {
            baglan.Open();
            textBox1.Focus();
            label26.Text = DateTime.Now.ToLongDateString();
            verilerigöster("Select * from yenisözleşme");
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglan;
            komut.CommandText = "Select * from boşaraçlar";
            komut.CommandType = CommandType.Text;

            OleDbDataReader dr;
            dr = komut.ExecuteReader();
            while (dr.Read()) 
            {
                comboBox1.Items.Add(dr["Plaka"]);
            }
            dataGridView1.Columns[0].Visible = false;
            
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("Select * From boşaraçlar", baglan);
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox1.Text == read["Plaka"].ToString())
                {

                    //textBox13.Text = read["Plaka"].ToString();
                    textBox14.Text = read["Marka"].ToString();
                    textBox15.Text = read["Seri"].ToString();
                    textBox16.Text = read["Model"].ToString();
                    textBox17.Text = read["Renk"].ToString();
                }
            }
            
            komut.Dispose();

            OleDbCommand komut2 = new OleDbCommand("Select * From araçlar", baglan);

            OleDbDataReader read2 = komut2.ExecuteReader();
            while (read2.Read())
            {
                if (comboBox1.Text == read2["Plaka"].ToString())
                {
                    textBox13.Text = read2["YakıtTürü"].ToString();
                }
            }
            
            komut2.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "" && textBox7.Text != "" && textBox8.Text != ""
                && textBox9.Text != "" && textBox10.Text != "" && textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox14.Text != ""
                && textBox15.Text != "" && textBox16.Text != "" && textBox17.Text != "" && textBox18.Text != "" && textBox19.Text != "")
            {

                OleDbCommand komut = new OleDbCommand("insert into yenisözleşme (SözleşmeTarihi,TcKimlik,AdSoyad,Cinsiyet,DoğumTarihi,DoğumYeri,CepTelefon,EMail,Adres,EhliyetNo,EhliyetTarihi,EhliyetVerilenYer,ÇıkışZamanı,DönüşZamanı,KullanımSüresi,VekilAdSoyad,VekilCepTelefon,Plaka,Marka,Seri,Model,Renk,Açıklama,ToplamTutar) values (@SözleşmeTarihi,@TcKimlik,@AdSoyad,@Cinsiyet,@DoğumTarihi,@DoğumYeri,@CepTelefon,@EMail,@Adres,@EhliyetNo,@EhliyetTarihi,@EhliyetVerilenYer,@ÇıkışZamanı,@DönüşZamanı,@KullanımSüresi,@VekilAdSoyad,@VekilCepTelefon,@Plaka,@Marka,@Seri,@Model,@Renk,@Açıklama,@ToplamTutar)", baglan);
                komut.Parameters.AddWithValue("@SözleşmeTarihi", label26.Text);
                komut.Parameters.AddWithValue("@TcKimlik", textBox1.Text);
                komut.Parameters.AddWithValue("@AdSoyad", textBox2.Text);
                komut.Parameters.AddWithValue("@Cinsiyet", comboBox2.Text);
                komut.Parameters.AddWithValue("@DoğumTarihi", dateTimePicker1.Text);
                komut.Parameters.AddWithValue("@DoğumYeri", textBox4.Text);
                komut.Parameters.AddWithValue("@CepTelefon", textBox5.Text);
                komut.Parameters.AddWithValue("@EMail", textBox6.Text);
                komut.Parameters.AddWithValue("@Adres", textBox7.Text);
                komut.Parameters.AddWithValue("@EhliyetNo", textBox8.Text);
                komut.Parameters.AddWithValue("@EhliyetTarihi", dateTimePicker2.Text);
                komut.Parameters.AddWithValue("@EhliyetVerilenYer", textBox9.Text);
                komut.Parameters.AddWithValue("@ÇıkışZamanı", dateTimePicker3.Text);
                komut.Parameters.AddWithValue("@DönüşZamanı", dateTimePicker4.Text);
                komut.Parameters.AddWithValue("@KullanımSüresi", textBox10.Text);
                komut.Parameters.AddWithValue("@VekilAdSoyad", textBox11.Text);
                komut.Parameters.AddWithValue("@VekilCepTelefon", textBox12.Text);
                komut.Parameters.AddWithValue("@Plaka", comboBox1.Text);
                komut.Parameters.AddWithValue("@Marka", textBox14.Text);
                komut.Parameters.AddWithValue("@Seri", textBox15.Text);
                komut.Parameters.AddWithValue("@Model", textBox16.Text);
                komut.Parameters.AddWithValue("@Renk", textBox17.Text);
                komut.Parameters.AddWithValue("@Açıklama", textBox18.Text);
                komut.Parameters.AddWithValue("@ToplamTutar", textBox19.Text);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from yenisözleşme");
                OleDbCommand komutt = new OleDbCommand("insert into doluaraçlar (Plaka,Marka,Seri,Model,Renk) values (@Plaka,@Marka,@Seri,@Model,@Renk)", baglan);
                komutt.Parameters.AddWithValue("@Plaka", comboBox1.Text);
                komutt.Parameters.AddWithValue("@Marka", textBox14.Text);
                komutt.Parameters.AddWithValue("@Seri", textBox15.Text);
                komutt.Parameters.AddWithValue("@Model", textBox16.Text);
                komutt.Parameters.AddWithValue("@Renk", textBox17.Text);
                komutt.ExecuteNonQuery();
                OleDbCommand komuttt = new OleDbCommand("insert into kasa (SözleşmeTarihi,MüşteriAdSoyad,SeçilenAraba,ToplamTutar) values (@SözleşmeTarihi,@MüşteriAdSoyad,@SeçilenAraba,@ToplamTutar)", baglan);
                komuttt.Parameters.AddWithValue("@SözleşmeTarihi", label26.Text);
                komuttt.Parameters.AddWithValue("@MüşteriAdSoyad", textBox2.Text);
                komuttt.Parameters.AddWithValue("@SeçilenAraba", comboBox1.Text);
                komuttt.Parameters.AddWithValue("@ToplamTutar", textBox19.Text);
                komuttt.ExecuteNonQuery();

                komutt.Connection = baglan;
                komutt.CommandText = "delete from boşaraçlar where Plaka='" + comboBox1.Text + "'";
                komutt.ExecuteNonQuery();
                MessageBox.Show("Girmiş Olduğunuz Sözleşme Bilgileri Başarıyla Kaydedilmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand komutt = new OleDbCommand();
            string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'sunu Yazınız...", "Silme İşlemi", "");
            if (IsimGirisi != "")
            {
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Silmek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'su : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {


                    OleDbCommand komut3 = new OleDbCommand("Select * From yenisözleşme where TcKimlik='" + IsimGirisi + "'", baglan);

                    OleDbDataReader read3 = komut3.ExecuteReader();
                    string plaka1 = "boş";
                    while (read3.Read())
                    {
                        plaka1 = read3["Plaka"].ToString();
                    }
                    komut3.Dispose();

                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from yenisözleşme where TcKimlik='" + IsimGirisi + "'";
                    komutt.ExecuteNonQuery();

                    OleDbCommand komut2 = new OleDbCommand("Select * From doluaraçlar where Plaka ='" + plaka1 + "'", baglan);

                    OleDbDataReader read = komut2.ExecuteReader();
                    string plaka = "yok", marka = "yok", seri = "yok", model = "yok", renk = "yok";
                    while (read.Read())
                    {
                        plaka = read["Plaka"].ToString();
                        marka = read["Marka"].ToString();
                        seri = read["Seri"].ToString();
                        model = read["Model"].ToString();
                        renk = read["Renk"].ToString();
                    }
                    komut2.Dispose();

                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from doluaraçlar where Plaka='" + plaka + "'";
                    komutt.ExecuteNonQuery();

                    OleDbCommand komutt4 = new OleDbCommand("insert into boşaraçlar (Plaka,Marka,Seri,Model,Renk) values (@Plaka,@Marka,@Seri,@Model,@Renk)", baglan);
                    komutt4.Parameters.AddWithValue("@Plaka", plaka);
                    komutt4.Parameters.AddWithValue("@Marka", marka);
                    komutt4.Parameters.AddWithValue("@Seri", seri);
                    komutt4.Parameters.AddWithValue("@Model", model);
                    komutt4.Parameters.AddWithValue("@Renk", renk);
                    komutt4.ExecuteNonQuery();
                    komutt4.Dispose();

                    verilerigöster("Select * from yenisözleşme");
                    MessageBox.Show("Sözleşme Başarıyla Silinmiştir.");
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox4.Clear();
                    textBox5.Clear();
                    textBox6.Clear();
                    textBox7.Clear();
                    textBox8.Clear();
                    textBox9.Clear();
                    textBox10.Clear();
                    textBox11.Clear();
                    textBox12.Clear();
                    textBox13.Clear();
                    textBox14.Clear();
                    textBox15.Clear();
                    textBox16.Clear();
                    textBox17.Clear();
                    textBox18.Clear();
                    textBox19.Clear();
                    comboBox1.Text = "";
                    comboBox2.Text = "";
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
                }
            }
        }

        private void yenisözlesme_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            baglan.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (guncellemegirdi == 0)
            {
                string IsimGirisi = Interaction.InputBox("Güncellemek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'sunu Yazınız...", "Güncelleme İşlemi", "");
                if (IsimGirisi != "")
                {
                    DialogResult cikis = new DialogResult();
                    cikis = MessageBox.Show("Güncellemek İstediğiniz Sözleşme Sahibinin Tc Kimlik No'su : " + IsimGirisi + " Güncellemek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                    if (cikis == DialogResult.Yes)
                    {
                        guncellemegirdi = 1;
                        string plakazz = "";
                        OleDbCommand komut = new OleDbCommand("select * from yenisözleşme where TcKimlik='" + IsimGirisi + "'", baglan);
                        komut.ExecuteNonQuery();
                        OleDbDataReader dr = komut.ExecuteReader();
                        while (dr.Read())
                        {
                            textBox1.Text = dr["TcKimlik"].ToString();
                            textBox2.Text = dr["AdSoyad"].ToString();
                            comboBox2.Text = dr["Cinsiyet"].ToString();
                            dateTimePicker1.Text = dr["DoğumTarihi"].ToString();
                            textBox4.Text = dr["DoğumYeri"].ToString();
                            textBox5.Text = dr["CepTelefon"].ToString();
                            textBox6.Text = dr["EMail"].ToString();
                            textBox7.Text = dr["Adres"].ToString();
                            textBox8.Text = dr["EhliyetNo"].ToString();
                            dateTimePicker2.Text = dr["EhliyetTarihi"].ToString();
                            textBox9.Text = dr["EhliyetVerilenYer"].ToString();
                            dateTimePicker3.Text = dr["ÇıkışZamanı"].ToString();
                            dateTimePicker4.Text = dr["DönüşZamanı"].ToString();
                            textBox10.Text = dr["KullanımSüresi"].ToString();
                            textBox11.Text = dr["VekilAdSoyad"].ToString();
                            textBox12.Text = dr["VekilCepTelefon"].ToString();


                            plakazz = dr["Plaka"].ToString();

                            textBox14.Text = dr["Marka"].ToString();
                            textBox15.Text = dr["Seri"].ToString();
                            textBox16.Text = dr["Model"].ToString();
                            textBox17.Text = dr["Renk"].ToString();
                            textBox18.Text = dr["Açıklama"].ToString();
                            textBox19.Text = dr["ToplamTutar"].ToString();
                        }

                        dr.Close();
                        komut.Dispose();


                        OleDbCommand komut2 = new OleDbCommand("Select * From araçlar", baglan);

                        OleDbDataReader read2 = komut2.ExecuteReader();
                        while (read2.Read())
                        {
                            if (plakazz == read2["Plaka"].ToString())
                            {
                                textBox13.Text = read2["YakıtTürü"].ToString();
                                comboBox1.Text = read2["Plaka"].ToString();
                            }
                        }
                        read2.Close();
                        komut2.Dispose();
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
                OleDbCommand komut = new OleDbCommand("Update yenisözleşme set AdSoyad='" + textBox2.Text + "',Cinsiyet='" + comboBox2.Text + "',DoğumTarihi='" + dateTimePicker1.Text + "',DoğumYeri='" + textBox4.Text + "',CepTelefon='" + textBox5.Text + "',EMail='" + textBox6.Text + "',Adres='" + textBox7.Text + "',EhliyetNo='" + textBox8.Text + "',EhliyetTarihi='" + dateTimePicker2.Text + "',EhliyetVerilenYer='" + textBox9.Text + "',ÇıkışZamanı='" + dateTimePicker3.Text + "',DönüşZamanı='" + dateTimePicker4.Text + "',KullanımSüresi='" + textBox10.Text + "',VekilAdSoyad='" + textBox11.Text + "',VekilCepTelefon='" + textBox12.Text + "',Plaka='" + comboBox1.Text + "',Marka='" + textBox14.Text + "',Seri='" + textBox15.Text + "',Model='" + textBox16.Text + "',Renk='" + textBox17.Text + "',Açıklama='" + textBox18.Text + "',ToplamTutar='" + textBox19.Text + "' where TcKimlik='" + textBox1.Text + "'", baglan);
                komut.ExecuteNonQuery();
                verilerigöster("Select * from yenisözleşme");

                MessageBox.Show("Girmiş Olduğunuz Sözleşme Bilgileri Başarıyla Güncellenmiştir.");
                textBox1.Clear();
                textBox2.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                textBox10.Clear();
                textBox11.Clear();
                textBox12.Clear();
                textBox13.Clear();
                textBox14.Clear();
                textBox15.Clear();
                textBox16.Clear();
                textBox17.Clear();
                textBox18.Clear();
                textBox19.Clear();
                comboBox1.Text = "";
                comboBox2.Text = "";
            }
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        int secilenData = -1;
        private void btnRapor_Click(object sender, EventArgs e)
        {
            if (secilenData != -1)
            {
                Form3 frm = new Form3(dataGridView1.Rows[secilenData].Cells[18].Value.ToString());
                frm.ShowDialog();
            }
            else MessageBox.Show("Sözleşme seçmediniz!");
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            secilenData = e.RowIndex;
        }
    }
}
