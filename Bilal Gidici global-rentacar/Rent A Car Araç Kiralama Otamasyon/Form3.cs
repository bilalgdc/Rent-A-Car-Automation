using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GDC_Arac_Kiralama
{
    public partial class Form3 : Form
    {
        string plaka = "";
        public Form3(string p)
        {
            InitializeComponent();
            this.plaka = p;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'veritabanıDataSet.yenisözleşme' table. You can move, or remove it, as needed.
            this.yenisözleşmeTableAdapter.FillBygetir(this.veritabanıDataSet.yenisözleşme,plaka);

            this.reportViewer1.RefreshReport();
        }
    }
}
