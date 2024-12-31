// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class Ogretmen : Kisi
    {
        private string _brans;
        private decimal _dersSaatiFiyati;

        public Ogretmen(string ad, string soyad, string brans, decimal dersSaatiFiyati)
            : base(ad, soyad) 
        {
            _brans = brans;
            _dersSaatiFiyati = dersSaatiFiyati;
        }

        public string Brans => _brans;
        public decimal DersSaatiFiyatı => _dersSaatiFiyati;

        public string FiyatGoster()
        {
            return $"{DersSaatiFiyatı:F2} TL";
        }

        public override string ToString()
        {
            return $"{Ad} {Soyad}, Branş: {Brans}, Ders Saati Ücreti: {DersSaatiFiyatı} TL";
        }
    }
}