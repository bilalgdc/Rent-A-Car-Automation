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
    public partial class kullanıcılarıdüzenle : Form
    {
        public kullanıcılarıdüzenle()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Yönetici") 
            {
                baglan.Open();
                OleDbCommand komut = new OleDbCommand("insert into yönetici (Kullanıcıİsmi,KullanıcıŞifre) values (@Kullanıcıİsmi,@KullanıcıŞifre)", baglan);
                komut.Parameters.AddWithValue("@Kullanıcıİsmi", textBox1.Text);
                komut.Parameters.AddWithValue("@KullanıcıŞifre", textBox2.Text);
                komut.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kullanıcı Başarıyla Eklenmiştir...");
            }
            if (comboBox1.Text == "Çalışan") 
            {
                baglan.Open();
                OleDbCommand komutt = new OleDbCommand("insert into çalışan (Kullanıcıİsmi,KullanıcıŞifre) values (@Kullanıcıİsmi,@KullanıcıŞifre)", baglan);
                komutt.Parameters.AddWithValue("@Kullanıcıİsmi", textBox1.Text);
                komutt.Parameters.AddWithValue("@KullanıcıŞifre", textBox2.Text);
                komutt.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("Kullanıcı Başarıyla Eklenmiştir...");
            }
        }

        private void kullanıcılarıdüzenle_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Şifresini Değiştirmek İstediğiniz Kullanıcı İsmini Giriniz...");
            }
            else 
            {
                if (comboBox1.Text == "Yönetici")
                {
                    baglan.Open();
                    OleDbCommand komut = new OleDbCommand("Update yönetici set KullanıcıŞifre='" + textBox2.Text + "' where Kullanıcıİsmi='" + textBox1.Text + "'", baglan);
                    komut.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Güncellenmiştir...");
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.Text = "";
                }
                if (comboBox1.Text == "Çalışan")
                {
                    baglan.Open();
                    OleDbCommand komutt = new OleDbCommand("Update çalışan set KullanıcıŞifre='" + textBox2.Text + "' where Kullanıcıİsmi='" + textBox1.Text + "'", baglan);
                    komutt.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Güncellenmiştir...");
                    textBox1.Clear();
                    textBox2.Clear();
                    comboBox1.Text = "";
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "") 
            {
                MessageBox.Show("Lütfen Yetki Türünü Seçiniz...");
            }
            if (comboBox1.Text == "Yönetici") 
            {
                OleDbCommand komutt = new OleDbCommand();
                string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Kullanıcının İsmini Yazınız...", "Silme İşlemi", "");
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Silmek İstediğiniz Kullanıcı İsmi : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from yönetici where Kullanıcıİsmi='" + IsimGirisi + "'";
                    komutt.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Silinmiştir...");  
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Kullanıcı Silinmedi !");
                }
            }
            if (comboBox1.Text == "Çalışan") 
            {
                OleDbCommand komutt = new OleDbCommand();
                string IsimGirisi = Interaction.InputBox("Silmek İstediğiniz Kullanıcının İsmini Yazınız...", "Silme İşlemi", "");
                DialogResult cikis = new DialogResult();
                cikis = MessageBox.Show("Silmek İstediğiniz Kullanıcı İsmi : " + IsimGirisi + " Silmek İstiyormusun ?", "Uyarı", MessageBoxButtons.YesNo);
                if (cikis == DialogResult.Yes)
                {
                    baglan.Open();
                    komutt.Connection = baglan;
                    komutt.CommandText = "delete from çalışan where Kullanıcıİsmi='" + IsimGirisi + "'";
                    komutt.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("Kullanıcı Başarıyla Silinmiştir...");
                }
                if (cikis == DialogResult.No)
                {
                    MessageBox.Show("Silmek İstediğiniz Plaka Silinmedi !");
                }
            }
        }
    }
}
