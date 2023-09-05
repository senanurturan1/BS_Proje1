using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BS_Proje1
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();

        }
        DBcontext db = new DBcontext();
        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void ftrtkp_btn_Click(object sender, EventArgs e)
        {

            bool FaturaTakipAdd = db.FaturaTakipAdd(firmatxt.Text, tarih_dtp2.Value, islemtxt.Text, faturano_txt.Text, aciklama_rtxt2.Text, tutar_txt.Text, odeme_txt.Text, bakiye_txt.Text);

            if (FaturaTakipAdd)
            {
                MessageBox.Show("İşlem başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("İşlem başarısız.");
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void krgtkp_btn_Click(object sender, EventArgs e)
        {
            bool KargoTakipAdd = db.KargoTakipAdd(kargosirketi_txt.Text, tarih_dtp1.Value, gonderici_txt.Text, Convert.ToInt32(musteri_cmb.Items), musteri_txt.Text, odemetipi_txt.Text, aciklama_rtxt.Text);

            if (KargoTakipAdd)
            {
                MessageBox.Show("İşlem başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("İşlem başarısız.");
            }
        }

        private void MUSTKP_BTN_Click(object sender, EventArgs e)
        {

            bool MusteriTakipAdd = db.MusteriTakipAdd(Personel_txt.Text, Musteri_dtp.Value, cariad_txt.Text, adres_txt.Text, telefon_txt.Text, vkn_txt.Text, aciklama_rtp4.Text);




            if (MusteriTakipAdd)
            {
                MessageBox.Show("İşlem başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("İşlem başarısız.");
            }
        }

        private void Stoktkp_btn_Click(object sender, EventArgs e)
        {

            bool StokTakipAdd = db.StokTakipAdd(urunad_txt.Text, uruntip_txt.Text, urunmodel_txt.Text, firma_txt2.Text, fiyat_txt.Text);

            if (StokTakipAdd)
            {
                MessageBox.Show("İşlem başarıyla gerçekleşti.");
            }
            else
            {
                MessageBox.Show("İşlem başarısız.");
            }
        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

            foreach (var item in db.musteritakip)
            {
                musteri_cmb.Items.Add(item.MusteriID1);
            }


        }
    }
}
