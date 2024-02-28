using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Kitaplik_Test
{
    class KitapVT
    {
        SqlConnection baglanti = new SqlConnection(@"Data Source=MACHINEX\MSSQLSERVER01;Initial Catalog=Kitaplik;Integrated Security=True");

        public List<Kitap> Kitaplar()
        {
            List<Kitap> ktp = new List<Kitap>();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLKitaplar", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Kitap k = new Kitap();
                k.ID = dr.GetInt16(0);
                k.Ad = dr.GetString(1);
                k.Yazar = dr.GetString(2);

                ktp.Add(k);
            }
            baglanti.Close();
            return ktp;
        }

        public void KitapEkle(Kitap kitap)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("INSERT INTO TBLKitaplar(KitapAdi,Yazar) VALUES(@p1,@p2)", baglanti);
            komut.Parameters.AddWithValue("@p1", kitap.Ad);
            komut.Parameters.AddWithValue("@p2", kitap.Yazar);
            komut.ExecuteNonQuery();
            baglanti.Close();
        }
    }
}
