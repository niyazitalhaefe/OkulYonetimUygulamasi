using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkulYonetimUygulamasi
{
    internal class Uygulama
    {

        static public Okul Okul = new Okul();

        int sayac = 0;

        public void Calistir()
        {
            Menu();

            SahteVeriEkle();
            while (true)
            {
                string secim = SecimAl("menu");
                switch (secim)
                {
                    case "1":
                        OgrenciListele();
                        break;

                    case "2":
                        SubeyeGoreListele();
                        break;

                    case "3":
                        CinsiyeteGoreOgrenciListele();
                        break;

                    case "4":
                        TarihtenSonraListele();
                        break;

                    case "5":
                        IllereGoreOgrenciListele();
                        break;

                    case "6":
                        OgrencininNotlarınıGoruntule();
                        break;

                    case "7":
                        OgrencininOkuduguKitaplarıListele();
                        break;

                    case "8":
                        EnYuksekBes();
                        break;

                    case "9":
                        EnDusukUc();
                        break;

                    case "10":
                        SubeEnYuksekBes();
                        break;

                    case "11":
                        SubeEnDusukUc();
                        break;

                    case "12":
                        OgrencininNotOrtalamasiniGor();
                        break;

                    case "13":
                        SubeninNotOrtalamasiniGor();
                        break;

                    case "14":
                        SonKitapListele();
                        break;

                    case "15":
                        OgrenciEkle();
                        break;

                    case "16":
                        OgrenciGuncelle();
                        break;

                    case "17":
                        OgrenciSil();
                        break;

                    case "18":
                        OgrenciAdresGir();
                        break;

                    case "19":
                        OgrenciOkuduKitabiGir();
                        break;

                    case "20":
                        OgrenciNotGir();
                        break;

                    case "ÇIKIŞ":
                        Cikis();
                        break;

                    case "LİSTE":
                        Menu();
                        break;


                    default:
                        Console.WriteLine("Hatalı işlem gerçekleştirildi. Tekrar deneyin.");
                        sayac++;
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkış yapmak için \"çıkış\" yazın.");

            }
        }

        static public void Cikis()
        {
            Environment.Exit(0);
        }

        static void Menu()
        {
            Console.WriteLine("------  Okul Yönetim Uygulamasi  -----");
            Console.WriteLine();

            Console.WriteLine("1 - Bütün öğrencileri listele");
            Console.WriteLine("2 - Şubeye göre öğrencileri listele");
            Console.WriteLine("3 - Cinsiyetine göre öğrencileri listele");
            Console.WriteLine("4 - Şu tarihten sonra doğan öğrencileri listele");
            Console.WriteLine("5 - İllere göre sıralayarak öğrencileri listele");
            Console.WriteLine("6 - Öğrencinin tüm notlarını listele");
            Console.WriteLine("7 - Öğrencinin okuduğu kitapları listele");
            Console.WriteLine("8 - Okuldaki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("9 - Okuldaki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("10 - Şubedeki en yüksek notlu 5 öğrenciyi listele");
            Console.WriteLine("11 - Şubedeki en düşük notlu 3 öğrenciyi listele");
            Console.WriteLine("12 - Öğrencinin not ortalamasını gör");
            Console.WriteLine("13 - Şubenin not ortalamasını gör");
            Console.WriteLine("14 - Öğrencinin okuduğu son kitabı gör");
            Console.WriteLine("15 - Öğrenci ekle");
            Console.WriteLine("16 - Öğrenci güncelle");
            Console.WriteLine("17 - Öğrenci sil");
            Console.WriteLine("18 - Öğrencinin adresini gir");
            Console.WriteLine("19 - Öğrencinin okuduğu kitabı gir");
            Console.WriteLine("20 - Öğrencinin notunu gir");
            Console.WriteLine();
            Console.WriteLine("Çıkış yapmak için \"çıkış\" yazıp \"enter\" a basın.");

        }

        public string SecimAl(string variation)
        {


            if (sayac != 10)
            {
                if (variation != "menu")
                {
                    Console.WriteLine();
                    Console.WriteLine("Menüyü tekrar listelemek için \"liste\", çıkıs yapmak için \"çıkıs\" yazın.");


                }

                Console.WriteLine();
                Console.Write("Yapmak istediginiz islemi seçiniz: ");
                string giris = Console.ReadLine().ToUpper();
                Console.WriteLine();

                return giris;


            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                return "çıkış";

            }
        }


        public void NotGir()
        {
            try
            {
                Console.WriteLine("20-Not Gir ----------------------------------------------------------");
                Console.Write("Öğrencinin numarası: ");
                int no = int.Parse(Console.ReadLine());




                string ders = Console.ReadLine();


                int adet = int.Parse(Console.ReadLine());

                for (int i = 1; i <= adet; i++)
                {
                    Console.Write(i + ". notu girin: ");
                    int not = int.Parse(Console.ReadLine());
                    Okul.NotEkle(no, ders, not);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }


        public void SonKitapListele()
        {
            Console.WriteLine("14-Ögrencinin okudugu son kitabı listele ----------------------------");

            int sayi;
            bool tmp = false;
            while (true)
            {
                sayi = Tools.SayiAl("Ögrencinin numarasi: ");

                foreach (Ogrenci item in Okul.Ogrenciler)
                {
                    if (item.No == sayi)
                    {
                        tmp = true;
                        break;
                    }
                }

                if (tmp == true)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                    break;
                }
            }




            foreach (Ogrenci item in Okul.Ogrenciler)
            {
                if (item.No == sayi)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Okudugu Son Kitap");
                    Console.WriteLine("-----------------------------");
                    string son_kitap = item.Kitaplar.LastOrDefault();

                    if (son_kitap == null)
                    {
                        Console.WriteLine("Öğrencinin okuduğu herhangi bir kitap bulunmamaktadır.");
                    }

                    else
                    {
                        Console.WriteLine(son_kitap);
                    }

                    Console.WriteLine();
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }

        }



        public void OgrenciAdresGir()
        {
            Console.WriteLine("18-Ögrencinin Adresini Gir ------------------------------------------");

            int sayi;
            bool tmp = false;
            while (true)
            {
                sayi = Tools.SayiAl("Ögrencinin numarasi: ");

                foreach (Ogrenci item in Okul.Ogrenciler)
                {
                    if (item.No == sayi)
                    {
                        tmp = true;
                        break;
                    }
                }

                if (tmp == true)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }




            foreach (Ogrenci item in Okul.Ogrenciler)
            {
                if (item.No == sayi)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                    Console.WriteLine();


                    string il = Tools.YaziAl("Il: ");
                    string ilce = Tools.YaziAl("Ilce: ");
                    string mahalle = Tools.YaziAl("Mahalle: ");

                    Adres o_adres = new Adres();

                    o_adres.Il = il;
                    o_adres.Ilce = ilce;
                    o_adres.Mahalle = mahalle;


                    item.Adresi = o_adres;


                    Console.WriteLine();
                    Console.WriteLine("Bilgiler sisteme girilmistir.");
                    Console.WriteLine();
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }

        }

        public void OgrenciOkuduKitabiGir()
        {
            Console.WriteLine("19-Ögrencinin okudugu kitabı gir ------------------------------------");

            int sayi;
            bool tmp = false;
            while (true)
            {

                sayi = Tools.SayiAl("Ögrencinin numarasi: ");

                foreach (Ogrenci item in Okul.Ogrenciler)
                {
                    if (item.No == sayi)
                    {
                        tmp = true;
                        break;
                    }
                }

                if (tmp == true)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }




            foreach (Ogrenci item in Okul.Ogrenciler)
            {
                if (item.No == sayi)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                    Console.WriteLine();


                    Console.Write("Eklenecek Kitabin Adı:");
                    string kitap = Console.ReadLine();

                    kitap = Tools.MakeFirstLetterUpper(kitap);

                    item.Kitaplar.Add(kitap);

                    Console.WriteLine("Bilgiler sisteme girilmistir.");


                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }

        }


        public void OgrenciNotGir()
        {
            Console.WriteLine("20-Not Gir ----------------------------------------------------------");

            int sayi;
            bool tmp = false;
            while (true)
            {
                sayi = Tools.SayiAl("Ögrencinin numarasi: ");

                foreach (Ogrenci item in Okul.Ogrenciler)
                {
                    if (item.No == sayi)
                    {
                        tmp = true;
                        break;
                    }
                }

                if (tmp == true)
                {
                    break;
                }

                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }

            foreach (Ogrenci item in Okul.Ogrenciler)
            {
                if (item.No == sayi)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                    Console.WriteLine();

                    Console.Write("Not eklemek istediğiniz dersi giriniz: ");
                    string ders = Console.ReadLine().ToUpper();

                    int kackere = Tools.SayiAl("Eklemek istediginiz not adedi: ");

                    for (int i = 1; i <= kackere; i++)
                    {

                        int notu = Tools.SayiAl(i + ". Notu girin: ");

                        DersNotu d = new DersNotu(ders, notu);

                        item.Notlar.Add(d);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Bilgiler sisteme girilmistir.");
                    break;
                }
                else
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
            }

        }

        static public void SahteVeriEkle()
        {
            Okul.OgrenciEkle(1, "Elif", "Selçuk", new DateTime(1990, 5, 4), CINSIYET.Kiz, SUBE.A);
            Okul.OgrenciEkle(2, "Betül", "Yılmaz", new DateTime(1991, 5, 4), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(3, "Hakan", "Çelik", new DateTime(1991, 5, 4), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(4, "Kerem", "Akay", new DateTime(1992, 5, 4), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(5, "Hatice", "Çınar", new DateTime(1992, 5, 4), CINSIYET.Kiz, SUBE.B);
            Okul.OgrenciEkle(6, "Selim", "İleri", new DateTime(1993, 5, 4), CINSIYET.Erkek, SUBE.B);
            Okul.OgrenciEkle(7, "Selin", "Kamış", new DateTime(1993, 5, 4), CINSIYET.Kiz, SUBE.C);
            Okul.OgrenciEkle(8, "Sinan", "Avcı", new DateTime(1994, 5, 4), CINSIYET.Erkek, SUBE.A);
            Okul.OgrenciEkle(9, "Deniz", "Çoban", new DateTime(1995, 5, 4), CINSIYET.Erkek, SUBE.C);
            Okul.OgrenciEkle(10, "Selda", "Kavak", new DateTime(1999, 5, 4), CINSIYET.Kiz, SUBE.B);

            Okul.NotEkle(1, "Türkçe", 85);
            Okul.NotEkle(1, "Matematik", 42);
            Okul.NotEkle(1, "Fen", 9);
            Okul.NotEkle(1, "Sosyal", 15);
            Okul.NotEkle(2, "Türkçe", 79);
            Okul.NotEkle(2, "Matematik", 20);
            Okul.NotEkle(2, "Fen", 66);
            Okul.NotEkle(2, "Sosyal", 48);
            Okul.NotEkle(3, "Türkçe", 98);
            Okul.NotEkle(3, "Matematik", 21);
            Okul.NotEkle(3, "Fen", 19);
            Okul.NotEkle(3, "Sosyal", 84);
            Okul.NotEkle(4, "Türkçe", 8);
            Okul.NotEkle(4, "Matematik", 10);
            Okul.NotEkle(4, "Fen", 10);
            Okul.NotEkle(4, "Sosyal", 47);
            Okul.NotEkle(5, "Türkçe", 39);
            Okul.NotEkle(5, "Matematik", 9);
            Okul.NotEkle(5, "Fen", 87);
            Okul.NotEkle(5, "Sosyal", 80);
            Okul.NotEkle(6, "Türkçe", 57);
            Okul.NotEkle(6, "Matematik", 76);
            Okul.NotEkle(6, "Fen", 72);
            Okul.NotEkle(6, "Sosyal", 44);
            Okul.NotEkle(7, "Türkçe", 26);
            Okul.NotEkle(7, "Matematik", 59);
            Okul.NotEkle(7, "Fen", 33);
            Okul.NotEkle(7, "Sosyal", 49);
            Okul.NotEkle(8, "Türkçe", 98);
            Okul.NotEkle(8, "Matematik", 23);
            Okul.NotEkle(8, "Fen", 3);
            Okul.NotEkle(8, "Sosyal", 73);
            Okul.NotEkle(9, "Türkçe", 78);
            Okul.NotEkle(9, "Matematik", 78);
            Okul.NotEkle(9, "Fen", 33);
            Okul.NotEkle(9, "Sosyal", 25);
            Okul.NotEkle(10, "Türkçe", 31);
            Okul.NotEkle(10, "Matematik", 13);
            Okul.NotEkle(10, "Fen", 17);
            Okul.NotEkle(10, "Sosyal", 84);
          
           
           Random rnd = new Random();

            foreach (Ogrenci item in Okul.Ogrenciler)
            {
                int sans = rnd.Next(1, 4);
                string il;
                string ilce;
                string mahalle;

                if (sans == 1)
                {
                    il = "Istanbul";
                    ilce = "Bakirkoy";
                    mahalle = "yes";
                }
                else if (sans == 2)
                {
                    il = "Malatya";
                    ilce = "Battalgazi";
                    mahalle = "no";
                }
                else
                {
                    ilce = "Ortakoy";
                    mahalle = "maybe";
                    il = "Izmir";
                }

                Adres o_adres = new Adres();

                o_adres.Il = il;
                o_adres.Ilce = ilce;
                o_adres.Mahalle = mahalle;


                item.Adresi = o_adres;


            }

        }
        static void OgrenciListele()
        {
            Console.WriteLine("1-Bütün Ögrencileri Listele --------------------------------------------------");
            Console.WriteLine();
            Tools.ListeYazdir(Okul.Ogrenciler);
        }

        public void OgrencininNotOrtalamasiniGor()
        {
            Console.WriteLine("12-Ögrencinin Not Ortalamasını Gör ----------------------------------");
            while (true)
            {


                int no = Tools.SayiAl("Ögrencinin numarası: ");
                if (!Tools.OgrenciVarMi(no))
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                }
                else
                {
                    foreach (var item in Uygulama.Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                            Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                            Console.WriteLine();
                            Console.WriteLine("Ögrencinin not ortalaması: " + item.Ortalama);
                            break;
                        }

                    }
                    break;
                }

            }
        }
        public void SubeninNotOrtalamasiniGor()
        {
            Console.WriteLine("13-Şubenin Not Ortalamasını Gör -------------------------------------");
            SUBE sube = Tools.SubeAl("Bir şube seçin (A/B/C): " , false);
            if (sube == SUBE.Empty)
            {
                Console.WriteLine();
                Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
            }
            else
            {
                double subeNotOrtalamasi = Tools.SubeNotOrtalamasi(sube);
                Console.WriteLine();
                Console.WriteLine(sube + " subesinin not ortalaması: " + subeNotOrtalamasi);
            }
        }

        public void OgrenciEkle()
        {
            Console.WriteLine("15-Öğrenci Ekle -----------------------------------------------------");
            int no = Tools.SayiAl("Ögrencinin numarası: ");
            string ad = Tools.YaziAl("Ögrencinin adı: ");
            string soyad = Tools.YaziAl("Ögrencinin soyadı: ");
            string dogumTarihi = Tools.DogumTarihiAl("Ögrencinin dogum tarihi: ", true);
            CINSIYET cinsiyet = Tools.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ", false);
            SUBE sube = Tools.SubeAl("Ögrencinin subesi (A/B/C): " , false);

            Ogrenci ogr = null;

            foreach (var item in Okul.Ogrenciler)
            {
                if (item.No == no)
                {
                    ogr = item;
                    break;

                }
            }
            if (ogr == null)
            {
                Okul.OgrenciEkle(no, ad, soyad, DateTime.Parse(dogumTarihi), cinsiyet, sube);
            }
            else
            {
                Okul.OgrenciEkle((Okul.Ogrenciler.Count + 1), ad, soyad, DateTime.Parse(dogumTarihi), cinsiyet, sube);
            }
            Console.WriteLine();
            Console.WriteLine((Okul.Ogrenciler.Count) + " numaralı ögrenci sisteme basarılı bir sekilde eklenmistir.");
            Console.WriteLine("Sistemde " + no + " numaralı öğrenci olduğu için verdiğiniz öğrenci no " + (Okul.Ogrenciler.Count) + " olarak değiştirildi.");


        }

        public void OgrenciGuncelle()
        {
            Console.WriteLine("16-Ögrenci Güncelle -----------------------------------------------------------");

            int no = Tools.SayiAl("Ögrencinin numarası: ");
            while (!Tools.OgrenciVarMi(no))
            {
                Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
            }
            string ad = Tools.YaziAl("Ögrencinin adı: ");
            string soyad = Tools.YaziAl("Ögrencinin soyadı: ");
            DateTime dogumTarihi;
            if (DateTime.TryParse(Tools.DogumTarihiAl("Ögrencinin dogum tarihi: ", false), out dogumTarihi))
            {
                CINSIYET cinsiyet = Tools.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ", false);
                SUBE sube = Tools.SubeAl("Ögrencinin subesi (A/B/C): ", false);
                if(sube == SUBE.Empty)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ogrenci güncellendi.");

                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            item.Ad = ad;
                            item.Soyad = soyad;
                            item.DogumTarihi = dogumTarihi;
                            item.Cinsiyet = cinsiyet;
                            
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ogrenci güncellendi.");

                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            item.Ad = ad;
                            item.Soyad = soyad;
                            item.DogumTarihi = dogumTarihi;
                            item.Cinsiyet = cinsiyet;
                            item.Sube = sube;
                            break;
                        }
                    }
                }      
            }
            else
            {
                CINSIYET cinsiyet = Tools.CinsiyetAl("Ögrencinin cinsiyeti (K/E): ", false);
                SUBE sube = Tools.SubeAl("Ögrencinin subesi (A/B/C): ", false);
                if(sube== SUBE.Empty)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ogrenci güncellendi.");

                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            item.Ad = ad;
                            item.Soyad = soyad;
                            item.DogumTarihi = dogumTarihi;
                            item.Cinsiyet = cinsiyet;
                            
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Ogrenci güncellendi.");

                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            item.Ad = ad;
                            item.Soyad = soyad;
                            item.DogumTarihi = dogumTarihi;
                            item.Cinsiyet = cinsiyet;
                            item.Sube = SUBE.Empty;
                            break;
                        }
                    }
                }               
            }         
        }


        public void OgrenciSil()
        {
            Console.WriteLine("17-Ögrenci sil ----------------------------------------------------------------");
            int no = Tools.SayiAl("Ögrencinin numarası: ");
            while (!Tools.OgrenciVarMi(no))
            {
                Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");
                no = Tools.SayiAl("Ögrencinin numarası: ");
            }
            foreach (var item in Okul.Ogrenciler)
            {
                if (item.No == no)
                {
                    Console.WriteLine();
                    Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                    Console.WriteLine("Ögrencinin Subesi: " + item.Sube);
                    Console.WriteLine();
                    Console.Write("Ögrenciyi silmek istediginize emin misiniz (E/H): ");
                    string cevap = Console.ReadLine().ToUpper();
                    if (cevap == "E")
                    {
                        Okul.Ogrenciler.Remove(item);
                        Console.WriteLine("Ögrenci basarılı bir sekilde silindi.");
                    }
                    break;
                }
            }
        }

        static void SubeyeGoreListele()
        {
            Console.WriteLine("2-Subeye Göre Ögrencileri Listele --------------------------------------------");
            while (true)
            {
                Console.Write("Listelemek istediğiniz şubeyi girin (A/B/C): ");
                string sube = Console.ReadLine().ToUpper();
                Console.WriteLine();

                List<Ogrenci> yeniListe = new List<Ogrenci>();


                if (sube == "A")
                {
                    
                    yeniListe = Okul.Ogrenciler.Where(a => a.Sube == SUBE.A).ToList();
                    Tools.ListeYazdir(yeniListe);

                }
                else if (sube == "B")
                {
                    
                    yeniListe = Okul.Ogrenciler.Where(a => a.Sube == SUBE.B).ToList();
                    Tools.ListeYazdir(yeniListe);

                }
                else if (sube == "C")
                {
                    
                    yeniListe = Okul.Ogrenciler.Where(a => a.Sube == SUBE.C).ToList();
                    Tools.ListeYazdir(yeniListe);

                }
                else if (sube == "")
                {
                    
                    Console.WriteLine("Listelenecek öğrenci yok.");
                    break;

                }
                else
                {

                    Console.WriteLine();
                    Console.WriteLine("Yanlış bir seçim yaptınız.");

                }
                break;
            }
        }

        static void CinsiyeteGoreOgrenciListele()
        {
            Console.WriteLine("3-Cinsiyete Göre Öğrencileri Listele -----------------------------------------");


            CINSIYET tmp = Tools.CinsiyetAl("Listelemek istediğiniz cinsiyeti girin (K/E): ", true);

            List<Ogrenci> CinsiyeteGoreListe = new List<Ogrenci>();
            Console.WriteLine();
            CinsiyeteGoreListe = Okul.Ogrenciler.Where(a => a.Cinsiyet == tmp).ToList();
            if (CinsiyeteGoreListe.Count > 0)
            {
                Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap say.".PadRight(17));

                Console.WriteLine("".PadRight(79, '-'));

                foreach (Ogrenci item in CinsiyeteGoreListe)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.OkuduguKitapSayisi.ToString());
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }
        }

        static void TarihtenSonraListele()
        {

            Console.WriteLine("4-Dogum Tarihine Göre Ögrencileri Listele ------------------------------------");
            string tarih = Tools.DogumTarihiAl("Hangi tarihten sonraki ögrencileri listelemek istersiniz: ", true);

            List<Ogrenci> TarihGoreliste = new List<Ogrenci>();
            Console.WriteLine();
            TarihGoreliste = Okul.Ogrenciler.Where(a => a.DogumTarihi > DateTime.Parse(tarih)).ToList();
            if (TarihGoreliste.Count > 0)
            {
                Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap say.".PadRight(17));

                Console.WriteLine("".PadRight(79, '-'));

                foreach (Ogrenci item in TarihGoreliste)
                {
                    Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.OkuduguKitapSayisi.ToString());
                }
            }
            else
            {
                Console.WriteLine("Listelenecek öğrenci yok.");
            }  
        }

        static void IllereGoreOgrenciListele()
        {
            Console.WriteLine("5-Illere Göre Ögrencileri Listele --------------------------------------------");
            List<Ogrenci> IllereGoreliste = new List<Ogrenci>();
            IllereGoreliste = Okul.Ogrenciler.OrderBy(a => a.Adresi.Il).ToList();
            Console.WriteLine();
            Tools.IllerListeYazdir(IllereGoreliste);

        }

        static void OgrencininNotlarınıGoruntule()
        {
            Console.WriteLine("6-Ögrencinin notlarını görüntüle ---------------------------------------------");

            while (true)
            {
                int no = Tools.SayiAl("Ögrencinin numarası: ");
                if (!Tools.OgrenciVarMi(no))
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");

                }
                else
                {
                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                            Console.WriteLine("Öğrencinin şubesi: " + item.Sube);
                            Console.WriteLine();
                            Console.WriteLine("Dersin Adı".PadRight(14) + "Notu");
                            Console.WriteLine("--------------------");
                            foreach (var i in item.Notlar)
                            {
                                Console.WriteLine(i.DersAdi.PadRight(14) + i.Not.ToString());
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        static void OgrencininOkuduguKitaplarıListele()
        {
            Console.WriteLine("7-Ögrencinin okudugu kitapları listele ---------------------------------------");

            while (true)
            {


                int no = Tools.SayiAl("Ögrencinin numarası: ");
                if (!Tools.OgrenciVarMi(no))
                {
                    Console.WriteLine("Bu numarada bir ögrenci yok.Tekrar deneyin.");

                }
                else
                {
                    foreach (var item in Okul.Ogrenciler)
                    {
                        if (item.No == no)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Ögrencinin Adı Soyadı: " + item.Ad + " " + item.Soyad);
                            Console.WriteLine("Öğrencinin şubesi: " + item.Sube);
                            Console.WriteLine();
                            Console.WriteLine("Okudugu Kitaplar");
                            Console.WriteLine("-----------------");
                            foreach (var i in item.Kitaplar)
                            {
                                Console.WriteLine(i);
                            }
                            break;
                        }
                    }
                    break;
                }
            }
        }

        static void EnYuksekBes()
        {
            Console.WriteLine("8-Okuldaki en basarılı 5 ögrenciyi listele -----------------------------------");
            List<Ogrenci> Okulenyuksekbesliste = new List<Ogrenci>();
            Okulenyuksekbesliste = Okul.Ogrenciler.OrderByDescending(a => a.Ortalama).Take(5).ToList();
            Console.WriteLine();
            Tools.ListeYazdir(Okulenyuksekbesliste);
        }

        static void EnDusukUc()
        {
            Console.WriteLine("9-Okuldaki en basarısız 3 ögrenciyi listele ----------------------------------");
            List<Ogrenci> OkulEnDusukUcListe = new List<Ogrenci>();
            OkulEnDusukUcListe = Okul.Ogrenciler.OrderBy(a => a.Ortalama).Take(3).ToList();
            Console.WriteLine();
            Tools.ListeYazdir(OkulEnDusukUcListe);
        }

        static void SubeEnYuksekBes()
        {
            Console.WriteLine("10-Subedeki en basarılı 5 ögrenciyi listele -----------------------------------");

            SUBE sube = Tools.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): " , true);
            if (sube == SUBE.Empty)
            {
                Console.WriteLine();   
            }
            else
            {
                Console.WriteLine();
                List<Ogrenci> SubeEnYuksekBesListe = new List<Ogrenci>();
                SubeEnYuksekBesListe = Okul.Ogrenciler.Where(a => a.Sube == sube).OrderByDescending(a => a.Ortalama).Take(5).ToList();
                Tools.ListeYazdir(SubeEnYuksekBesListe);
            }
        }

        static void SubeEnDusukUc()
        {
            Console.WriteLine("11-Subedeki en basarısız 3 ögrenciyi listele ----------------------------------");

            List<Ogrenci> SubeEnDusukUcliste = new List<Ogrenci>();
            SUBE sube = Tools.SubeAl("Listelemek istediğiniz şubeyi girin (A/B/C): ", true);
            if (sube == SUBE.Empty)
            {
                Console.WriteLine();
               
            }
            else
            {
                Console.WriteLine();
                SubeEnDusukUcliste = Okul.Ogrenciler.Where(a => a.Sube == sube).OrderBy(a => a.Ortalama).Take(3).ToList();
                Tools.ListeYazdir(SubeEnDusukUcliste);
            }

        }

    }
}

