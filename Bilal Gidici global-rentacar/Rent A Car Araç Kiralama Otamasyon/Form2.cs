using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rent_A_Car_Araç_Kiralama_Otamasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {

        }

        private void araçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            aracdüzenleme aracdüzenleme = new aracdüzenleme();
            aracdüzenleme.Show();
        }

        private void boştakiAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bosaraclar bosaraclar = new bosaraclar();
            bosaraclar.Show();
        }

        private void doluAraçlarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            doluaraclar doluaraclar = new doluaraclar();
            doluaraclar.Show();
        }

        private void araçlarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            araclarılistele araclistele = new araclarılistele();
            araclistele.Show();
        }

        private void müşteriDüzenlemeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            yenisözlesme yenisözlesme= new yenisözlesme();
            yenisözlesme.Show();
        }

        private void müşteriListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sözlesmelerilistele sözlesmelerilistele = new sözlesmelerilistele();
            sözlesmelerilistele.Show();
        }

        private void kullanıcılarıListeleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kullanıcılarıdüzenle kullanıcılarıdüzenle = new kullanıcılarıdüzenle();
            kullanıcılarıdüzenle.Show();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void kasaİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            kasa kasa = new kasa();
            kasa.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            toolStripMenuItem5.Text = DateTime.Now.ToLongDateString();
        }

        private void giderİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            giderişlemleri gider = new giderişlemleri();
            gider.Show();
        }
    }
}
