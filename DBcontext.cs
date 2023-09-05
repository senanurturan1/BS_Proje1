using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Drawing.Design;

namespace BS_Proje1
{
    public class DBcontext
    {
        SqlConnection cnc = new SqlConnection("Data Source=TURANASUS;Initial Catalog=BS_Proje1;Integrated Security=True");
        DataTable dt;
        DataAdapter da;
        SqlDataReader sdr;
        public List<FaturaTakip> faturatakip { get; set; }

        public List<musteritakip> musteritakip { get; set; }

        public DBcontext()
        {
            musteritakip = new List<musteritakip>();
            Mtakip();
        }




        private void Ftakip()
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select * from FaturaTakip", cnc);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                FaturaTakip faturatakip = new FaturaTakip();

                faturatakip.Firma1 = dr[0].ToString();
                faturatakip.Tarih1 = dr[1].ToString();
                faturatakip.Islem1 = dr[2].ToString();
                faturatakip.FaturaNo1 = dr[3].ToString();
                faturatakip.Aciklama1 = dr[4].ToString();
                faturatakip.Tutar1 = dr[5].ToString();
                faturatakip.Odeme1 = dr[6].ToString();
                faturatakip.Bakiye1 = dr[7].ToString();

              
            }
            dr.Close();
            cnc.Close();
        }

       

        public void Mtakip()
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select * from MusteriTakip", cnc);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                musteritakip musteriTakip = new musteritakip();

                musteriTakip.MusteriID1 = dr[0].ToString();
                musteriTakip.Personel1 = dr[1].ToString();
                musteriTakip.IslemTarihi1 = dr[2].ToString();
                musteriTakip.CariAdi1 = dr[3].ToString();
                musteriTakip.Adres1 = dr[4].ToString();
                musteriTakip.Telefon1 = dr[5].ToString();
                musteriTakip.VKN1 = dr[6].ToString();
                musteriTakip.Aciklama1 = dr[7].ToString();
                musteritakip.Add(musteriTakip);
            }
            dr.Close();
            cnc.Close();
        }


        public List<KargoTakip> kargotakip { get; set; }
        private void Ktakip()
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select * from kargotakip", cnc);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                KargoTakip kargoTakip = new KargoTakip();

                kargoTakip.KargoSirketi1 = dr[0].ToString();
                kargoTakip.Tarih1 = dr[1].ToString();
                kargoTakip.Gonderici1 = dr[2].ToString();
                kargoTakip.MusteriID1 = dr[3].ToString();
                kargoTakip.MusteriAd1 = dr[4].ToString();
                kargoTakip.OdemeTipi1 = dr[5].ToString();
                kargoTakip.Aciklama1 = dr[6].ToString();
            }
            dr.Close();
            cnc.Close();
        }


        public List<StokTakip> stoktakip { get; set; }

        private void Stakip()
        {
            cnc.Open();
            SqlCommand cmd = new SqlCommand("select * from StokTakip", cnc);
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                StokTakip stoktakip = new StokTakip();

                
                stoktakip.UrunAd1 = dr[0].ToString();
                stoktakip.UrunTipi1 = dr[1].ToString();
                stoktakip.UrunModeli1 = dr[2].ToString();
                stoktakip.Firma1 = dr[3].ToString();
                stoktakip.UrunFiyat1 = dr[4].ToString();

            }
            dr.Close();
            cnc.Close();
        }

        
        public bool FaturaTakipAdd(string firma, DateTime tarih, string Islem, string FaturaNo, string aciklama, string tutar, string odeme, string bakiye) {

            try
            {
                SqlCommand cmd = new SqlCommand("insert into faturatakip(firma,Islem,tarih,faturano,aciklama,tutar,odeme,bakiye) values (@firma,@Islem,@tarih,@faturano,@aciklama,@tutar,@odeme,@bakiye) ", cnc);
                Form2 f2 = new Form2();
                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@FaturaNo", FaturaNo.ToString());
                cmd.Parameters.AddWithValue("@aciklama", aciklama.ToString());
                cmd.Parameters.AddWithValue("@tutar", tutar.ToString());
                cmd.Parameters.AddWithValue("@odeme", odeme.ToString());
                cmd.Parameters.AddWithValue("@bakiye", bakiye.ToString());
                cmd.Parameters.AddWithValue("@firma", firma.ToString());
                cmd.Parameters.AddWithValue("@Islem", Islem.ToString());
                cnc.Open();
                int affectedrows = cmd.ExecuteNonQuery();
                cnc.Close();

                return true;
            }
            catch 
            {
                return false;

            }
            

        }


        public bool KargoTakipAdd(string KargoSirketi, DateTime tarih, string Gonderici, int MusteriID, string MusteriAd, string OdemeTipi, string Aciklama)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into kargotakip(KargoSirketi,Tarih,Gonderici,MusteriID,MusteriAd,OdemeTipi,Aciklama) values (@KargoSirketi,@Tarih,@Gonderici,@MusteriID,@MusteriAd,@OdemeTipi,@Aciklama) ", cnc);
                Form2 f2 = new Form2();

                cmd.Parameters.AddWithValue("@KargoSirketi", KargoSirketi.ToString());
                cmd.Parameters.AddWithValue("@tarih", tarih);
                cmd.Parameters.AddWithValue("@Gonderici", Gonderici.ToString());
                cmd.Parameters.AddWithValue("@MusteriID", MusteriID);
                cmd.Parameters.AddWithValue("@MusteriAd", MusteriAd.ToString());
                cmd.Parameters.AddWithValue("@OdemeTipi", OdemeTipi.ToString());
                cmd.Parameters.AddWithValue("@Aciklama", Aciklama.ToString());
               
                cnc.Open();

                int affectedrows = cmd.ExecuteNonQuery();

                cnc.Close();

                return true;
            }
            catch 
            {

                return false;
            }
            
        }


        public bool MusteriTakipAdd(string personel,DateTime IslemTarihi,string CariAd,string adres, string telefon,string VKN,string aciklama)
        {

            try
            {
               
                SqlCommand cmd = new SqlCommand("insert into MusteriTakip (Personel,IslemTarihi,cariadi,adres,telefon,VKN,aciklama) values(@Personel,@IslemTarihi,@cariadi,@adres,@telefon,@VKN,@aciklama)", cnc);
                cmd.Parameters.AddWithValue("@personel", personel.ToString());
                cmd.Parameters.AddWithValue("@IslemTarihi", IslemTarihi);
                cmd.Parameters.AddWithValue("@cariadi", CariAd.ToString());
                cmd.Parameters.AddWithValue("@adres", adres.ToString());
                cmd.Parameters.AddWithValue("@telefon", telefon.ToString());
                cmd.Parameters.AddWithValue("@VKN", VKN.ToString());
                cmd.Parameters.AddWithValue("@aciklama", aciklama.ToString());
               
            
                
                cnc.Open();
                int affectedrows = cmd.ExecuteNonQuery();
                cnc.Close();
                return true;
            }
            catch 
            {

                return false;

            }
        
        }



        public bool StokTakipAdd(string UrunAd, string UrunTipi, string UrunModeli, string Firma, string UrunFiyat)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into StokTakip (UrunAd,UrunTipi,UrunModeli,Firma,UrunFiyat) values(@UrunAd,@UrunTipi,@UrunModeli,@Firma,@UrunFiyat)", cnc);

               
                cmd.Parameters.AddWithValue("@UrunAd", UrunAd.ToString());
                cmd.Parameters.AddWithValue("@UrunTipi", UrunTipi.ToString());
                cmd.Parameters.AddWithValue("@UrunModeli", UrunModeli.ToString());
                cmd.Parameters.AddWithValue("@Firma", Firma.ToString());
                cmd.Parameters.AddWithValue("@UrunFiyat", UrunFiyat.ToString());

                cnc.Open();
                int affectedrows = cmd.ExecuteNonQuery();
                cnc.Close();
                

                return true;
            }
            catch 
            {

                return false;
            }
           
        }
    }

















    }













