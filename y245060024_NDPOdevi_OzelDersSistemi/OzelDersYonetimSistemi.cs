// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
using System;
using System.Collections.Generic;
using System.Linq;

namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class OzelDersYonetimSistemi
    {
        private List<Ogretmen> ogretmenler = new List<Ogretmen>();
        private List<OzelDersKaydi> kayitlar = new List<OzelDersKaydi>();

        public OzelDersYonetimSistemi()
        {

            // Öğretmenleri listeye ekliyoruz
            ogretmenler.Add(new Ogretmen("Ahmet", "Yılmaz", "Matematik", 750));
            ogretmenler.Add(new Ogretmen("Ayşe", " Demir", "Fizik", 650));
            ogretmenler.Add(new Ogretmen("Mehmet", " Çelik", "Kimya", 620));

        }


        public void OgretmenleriListele()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("============================================================");
            Console.WriteLine("\nMevcut öğretmenler:");
            Console.WriteLine("============================================================");
            Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,10}", "No", "Ad", "Branş", "Ders Saati Ücreti");
            Console.WriteLine("============================================================");
            for (int i = 0; i < ogretmenler.Count; i++)
            {
                // Öğretmenin adı ve soyadı ile birlikte ders saati ücretini de gösteriyoruz
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("{0,-5} {1,-20} {2,-15} {3,10}", i + 1, ogretmenler[i].Ad, ogretmenler[i].Brans, ogretmenler[i].DersSaatiFiyatı.ToString("0") + "TL");


                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public bool TarihSaatKontrolu(Ogretmen ogretmen, DateTime dersTarihiSaat)
        {
            // Aynı öğretmen ve tarihe sahip bir kayıt var mı kontrol et
            return kayitlar.Any(kayit => kayit.Ogretmen == ogretmen && kayit.DersTarihiSaat == dersTarihiSaat);
        }

        public void OzelDersKaydiYap()
        {
            Console.WriteLine("================================================");
            Console.WriteLine("\n Öğrenci Bilgilerini Girin");
            Console.Write("Öğrenci adı: ");
            string ogrenciAd = Console.ReadLine();
            Console.Write("Öğrenci soyadı: ");
            string ogrenciSoyad = Console.ReadLine();
            int ogrenciSinif;
            Console.Write("Öğrenci sınıfı: ");
            while (!int.TryParse(Console.ReadLine(), out ogrenciSinif) || ogrenciSinif <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz giriş! Lütfen pozitif bir tam sayı girin.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("Öğrenci sınıfı: ");
            }

            Console.Write("Öğrenci okulu: ");
            string ogrenciOkul = Console.ReadLine();

            Ogrenci ogrenci = new Ogrenci(ogrenciAd, ogrenciSoyad, ogrenciOkul, ogrenciSinif);

            Console.WriteLine("\nBir öğretmen seçin (numarasını girin):");
            OgretmenleriListele();
            Console.Write("Seçiminizi yapın: ");
            int ogretmenSecim = int.Parse(Console.ReadLine()) - 1;

            if (ogretmenSecim < 0 || ogretmenSecim >= ogretmenler.Count)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz öğretmen seçimi.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            Ogretmen secilenOgretmen = ogretmenler[ogretmenSecim];
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Tarih ve Saat Seçimi ---");
            Console.Write("Ders tarihi ve saati (yyyy-MM-dd HH:mm): ");

            DateTime dersTarihiSaat;
            if (!DateTime.TryParse(Console.ReadLine(), out dersTarihiSaat))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Geçersiz tarih ve saat formatı.");
                Console.ForegroundColor = ConsoleColor.Gray;
                return;
            }

            // Tarih ve saat çakışma kontrolü
            if (TarihSaatKontrolu(secilenOgretmen, dersTarihiSaat))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Seçilen tarih ve saat bu öğretmen için dolu. Lütfen farklı bir zaman seçin.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                OzelDersKaydi yeniKayit = new OzelDersKaydi(ogrenci, secilenOgretmen, dersTarihiSaat);
                kayitlar.Add(yeniKayit);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"{ogrenci.Ad} {ogrenci.Soyad} için {secilenOgretmen.Ad} {secilenOgretmen.Soyad} adlı öğretmene ders kaydı yapıldı. Tarih: {dersTarihiSaat}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }

        public void MevcutKayitlariListele()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("================================================");
            Console.WriteLine("\n--- Mevcut Kayıtlar ---");
            Console.WriteLine("================================================");
            foreach (var kayit in kayitlar)
            {
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine(kayit);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
        public void KayitIptaliYap()
        {
            Console.Write("\nÖğrenci adı: ");
            string ogrenciAdi = Console.ReadLine().Trim().ToLower();

            Console.Write("Öğrenci soyadı: ");
            string ogrenciSoyadi = Console.ReadLine().Trim().ToLower();

            Console.Write("Öğrenci okulu: ");
            string ogrenciOkulu = Console.ReadLine().Trim().ToLower();

            // Öğrencinin adı, soyadı ve okulu ile kaydı arıyoruz
            var kayit = kayitlar.FirstOrDefault(k =>
                k.Ogrenci.Ad.ToLower() == ogrenciAdi &&
                k.Ogrenci.Soyad.ToLower() == ogrenciSoyadi &&
                k.Ogrenci.Okul.ToLower() == ogrenciOkulu);

            if (kayit != null)
            {
                kayitlar.Remove(kayit);  // Kayıt bulunursa silinir
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{kayit.Ogrenci.Ad} {kayit.Ogrenci.Soyad} {kayit.DersTarihiSaat} özel ders kaydı iptal edildi.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Bu bilgilerle kaydınız bulunamadı.");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}