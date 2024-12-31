// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class Ogrenci : Kisi
    {
        private string _okul;
        private int _sinif;

        // 'base(ad, soyad)' ifadesi, Kisi sınıfının kurucusunu çağırarak Ad ve Soyad bilgisini orada başlatır.
        public Ogrenci(string ad, string soyad, string okul, int sinif)
            : base(ad, soyad)  
        {
            _okul = okul;
            _sinif = sinif;
        }
        public string Okul => _okul;
        public int Sinif => _sinif;

        public override string ToString()
        {
            return $"{Ad} {Soyad}, Okul: {Okul}, Sınıf: {Sinif}";
        }
    }
}
    