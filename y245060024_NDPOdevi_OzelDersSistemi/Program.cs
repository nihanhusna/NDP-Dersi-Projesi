// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
using System;

namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OzelDersYonetimSistemi sistem = new OzelDersYonetimSistemi();

            while (true)
            {
                Console.WriteLine("================================================");
                Console.WriteLine("\n------ Özel Ders Yönetim Sistemi ------");
                Console.WriteLine("================================================");
                Console.WriteLine("1. Öğretmenleri Listele");
                Console.WriteLine("2. Özel Ders Kaydı Yap");
                Console.WriteLine("3. Özel Ders Kaydını İptal Et");
                Console.WriteLine("4. Mevcut Kayıtları Listele");
                Console.WriteLine("5. Çıkış");
                Console.Write("Seçiminizi yapın: ");
                int secim = int.Parse(Console.ReadLine());

                switch (secim)
                {
                    case 1:
                        sistem.OgretmenleriListele();
                        break;
                    case 2:
                        sistem.OzelDersKaydiYap();
                        break;
                    case 3:
                        sistem.KayitIptaliYap();
                        break;
                    case 4:
                        sistem.MevcutKayitlariListele();
                        break;
                    case 5:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Çıkılıyor...");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        return;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        break;
                }
            }
        }
    }
}
