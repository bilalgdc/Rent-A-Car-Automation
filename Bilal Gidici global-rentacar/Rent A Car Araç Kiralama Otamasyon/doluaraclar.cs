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
    public partial class doluaraclar : Form
    {
        public doluaraclar()
        {
            InitializeComponent();
        }
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=veritabanı.mdb");
        public void verilerigöster(string veriler)
        {
            OleDbDataAdapter ad = new OleDbDataAdapter(veriler, baglan);
            DataSet ds = new DataSet();
            ad.Fill(ds);
            comboBox_DoluAraclar.DataSource = ds.Tables[0];
            comboBox_DoluAraclar.DisplayMember = "Plaka";
            comboBox_DoluAraclar.ValueMember = "Plaka";
        }
        private void doluaraclar_Load(object sender, EventArgs e)
        {
            verilerigöster("Select * from doluaraçlar");
            
        }

        private void doluaraclar_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_DoluAraclar_SelectedIndexChanged(object sender, EventArgs e)
        {
            OleDbCommand komut = new OleDbCommand("Select * From doluaraçlar where Plaka='"+ comboBox_DoluAraclar.Text +"'", baglan);
            baglan.Open();
            OleDbDataReader read = komut.ExecuteReader();
            while (read.Read())
            {
                if (comboBox_DoluAraclar.Text == read["Plaka"].ToString())
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

        private void textBox_Renk_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox_Marka_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
