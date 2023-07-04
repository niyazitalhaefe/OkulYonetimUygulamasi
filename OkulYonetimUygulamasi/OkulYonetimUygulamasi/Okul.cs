using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi
{
    internal class Okul
    {
       
        public List<Ogrenci> Ogrenciler = new List<Ogrenci>();
        public void OgrenciEkle(int no, string ad, string soyad , DateTime dogumTarihi, CINSIYET cinsiyet, SUBE sube)
        {
            Ogrenci o = new Ogrenci();

            o.Ad = ad;
            o.No = no;
            o.Soyad = soyad;
            o.DogumTarihi = dogumTarihi;
            o.Cinsiyet = cinsiyet;
            o.Sube = sube;

            Adres tmp = new Adres();
            o.Adresi = tmp;

            
            this.Ogrenciler.Add(o);
        }

        public void NotEkle(int no, string ders, int not)
        {
            Ogrenci o = this.Ogrenciler.Where(a => a.No == no).FirstOrDefault();

            if (o != null)
            {
                o.Notlar.Add(new DersNotu(ders, not));
            }
        }
    }
}
