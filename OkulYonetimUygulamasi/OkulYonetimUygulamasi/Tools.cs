using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OkulYonetimUygulamasi
{
    internal class Tools
    {
        static public Okul Okul = new Okul();
        static public Okul okul = new Okul();
        static public int SayiAl(string mesaj)
        {
            int sayi;

            

            do
            {
                try
                {
                    Console.Write(mesaj);
                    string giris = Console.ReadLine().ToUpper();

                    if (int.TryParse(giris, out sayi))
                    {
                        return sayi;
                    }
                    else
                    {
                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);

        }
 
        static public string StringAl(string mesaj)
        {
            int sayi;

            //TryParse metodu bool bir değişken döndür.
            //Eğer metod girilen veriyi int bir değişkene çeviremiyorsa hata döndürecek ve tekrar giriş isteyecek.
            // Koşul sağlandıysa girilen veri döndürülür.

            do
            {
                try
                {
                    Console.Write(mesaj);
                    string giris = Console.ReadLine().ToUpper();

                    if (!int.TryParse(giris, out sayi))
                    {
                        return giris;
                    }
                    else
                    {
                        throw new Exception("Hatalı islem tekrar girin.");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            } while (true);

        }

        static public void Cikis()
        {
            Environment.Exit(0);
        }

        static public void ListeYazdir(List<Ogrenci> liste) //bU METOT ogrenci listeler yalnız 5,6,7 de kullanılmayacak (1,2,3,4,8,9,10 ve 11 de kullanılabilir.)
        {
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Not Ort.".PadRight(15) + "Okuduğu Kitap say.".PadRight(17));

            Console.WriteLine("".PadRight(79, '-'));

            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Ortalama.ToString().PadRight(15) + item.OkuduguKitapSayisi.ToString());
            }
        }

        static public string MakeFirstLetterUpper(string input)
        {
            return char.ToUpper(input[0]) + input.Substring(1);
        }

        static public string YaziAl(string mesaj)
        {
            int sayi;
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string input = Console.ReadLine();
                    if (input == "")
                    {
                        throw new Exception("Veri girişi yapılmadı tekrar deneyin.");
                    }
                    string a = input.Substring(0, 1).ToUpper() + input.Substring(1).ToLower();

                    if (int.TryParse(a, out sayi))
                    {
                        throw new Exception("Hatalı islem tekrar girin.");
                    }
                    else
                    {

                        return a;

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
        static public string DogumTarihiAl(string baslik, bool durum)
        {
            int sayi;
            DateTime dogumTarihi;
            do
            {
                try
                {
                    Console.Write(baslik);
                    string input = Console.ReadLine();
                    if (DateTime.TryParse(input, out dogumTarihi))
                    {
                        dogumTarihi = DateTime.Parse(input);
                        return dogumTarihi.ToString();

                    }
                    else
                    {
                        if (durum)
                            Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                        else
                            return input = null;

                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine("Hatali giris yapildi. Tekrar deneyin");
                }
            } while (true);
        }

        static public CINSIYET CinsiyetAl(string mesaj,bool durum)
        {
            CINSIYET cinsiyet;
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string giris = Console.ReadLine().ToUpper();
                    if (giris.Length == 0)
                    {
                        if (durum == true)
                        {
                            
                        }
                        return CINSIYET.Empty;
                    }
                    if (giris == "E")
                    {
                        return CINSIYET.Erkek;
                    }
                    else if (giris == "K")
                    {
                        return CINSIYET.Kiz;
                    }
                    else
                    {
                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);
        }
        static public SUBE SubeAl(string mesaj,bool durum)
        {
            SUBE sube;
            do
            {
                try
                {
                    Console.Write(mesaj);
                    string giris = Console.ReadLine().ToUpper();

                    if(giris.Length == 0)
                    {
                        if(durum== true)
                        {
                            Console.WriteLine();
                            Console.WriteLine("Listelenecek öğrenci yok.");
                        }
                        return SUBE.Empty;
                    }
                    if (giris == "A")
                    {
                        return SUBE.A;
                    }
                    else if (giris == "B")
                    {
                        return SUBE.B;
                    }
                    else if (giris == "C")
                    {
                        return SUBE.C;
                    }
                    else if (giris == "")
                    {
                        return SUBE.Empty;
                    }
                    else
                    {
                        throw new Exception("Hatali giris yapildi. Tekrar deneyin");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            } while (true);

        }

        static public bool OgrenciVarMi(int no)
        {
            bool varMi = false;
            foreach (var item in Uygulama.Okul.Ogrenciler)
            {
                if (item.No == no)
                {
                    varMi = true;
                    break;
                }
            }
            return varMi;
        }

        static public double SubeNotOrtalamasi(SUBE sube)
        {
            double subeNotOrtalamasi = Uygulama.Okul.Ogrenciler.Where(a => a.Sube == sube).Average(a => a.Ortalama);
            return subeNotOrtalamasi;
        }

        static public void IllerListeYazdir(List<Ogrenci> liste) 
        {
            Console.WriteLine("Sube".PadRight(10) + "No".PadRight(10) + "Adı Soyadı".PadRight(25) + "Sehir".PadRight(15) + "Semt".PadRight(17));

            Console.WriteLine("".PadRight(80, '-'));

            foreach (Ogrenci item in liste)
            {
                Console.WriteLine(item.Sube.ToString().PadRight(10) + item.No.ToString().PadRight(10) + (item.Ad + " " + item.Soyad).PadRight(25) + item.Adresi.Il.PadRight(15) + item.Adresi.Ilce);
            }
        }

    }
}
