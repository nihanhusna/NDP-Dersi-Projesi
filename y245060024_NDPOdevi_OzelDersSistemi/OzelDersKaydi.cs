// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
using System;

namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class OzelDersKaydi
    {
        public Ogrenci Ogrenci { get; private set; } 
        public Ogretmen Ogretmen { get; private set; }
        public DateTime DersTarihiSaat { get; private set; }

        public OzelDersKaydi(Ogrenci ogrenci, Ogretmen ogretmen, DateTime dersTarihiSaat)
        {
            Ogrenci = ogrenci;
            Ogretmen = ogretmen;
            DersTarihiSaat = dersTarihiSaat;
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            return $"{Ogrenci.Ad} {Ogrenci.Soyad} için {Ogretmen.Ad} {Ogretmen.Soyad} adlı öğretmene ders kaydı - Tarih: {DersTarihiSaat:yyyy-MM-dd HH:mm}";

        }
    }
}
