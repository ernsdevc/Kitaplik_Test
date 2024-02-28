using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kitaplik_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        KitapVT vtSinif = new KitapVT();

        private void btnListele_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = vtSinif.Kitaplar();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kitap kitap = new Kitap();
            kitap.Ad = txtKitapAdi.Text;
            kitap.Yazar = txtYazar.Text;
            vtSinif.KitapEkle(kitap);
            MessageBox.Show("Kitap Eklendi");

        }
    }
}
