// Author :Nihan Hüsna Kılıç Beşik y245060024  nihan.besik1@ogr.sakarya.edu.tr
namespace y245060024_NDPOdevi_OzelDersSistemi
{
    internal class Kisi
    {
        // Bu alanlar private. Dışarıdan doğrudan erişilemez.
        // _ad ve _soyad alanları öğrenci veya öğretmen nesnelerinin isim bilgilerini tutar.
        private string _ad;
        private string _soyad;

       
        // Kurucunun 'protected' olması, bu sınıftan doğrudan nesne oluşturulamayacağı anlamına gelir.
        // Yani sadece bu sınıfı miras alan alt sınıflar (Ogrenci, Ogretmen gibi) bu kurucuyu çağırarak nesne oluşturabilir.
        // Bu sayede Kisi sınıfı, tek başına anlamlı olmayan, ancak alt sınıflar için temel oluşturan bir yapı haline gelir.
        protected Kisi(string ad, string soyad)
        {
            // Kurucu, _ad ve _soyad alanlarını alınan parametrelerle başlatır.
            // Bu sayede her Kisi (veya ondan türeyen nesne) oluşturulduğunda ad-soyad bilgisi zorunlu kılınmış olur.
            _ad = ad;
            _soyad = soyad;
        }

        // Public read-only özellikler. Dışarıya adı ve soyadı okumak için açıyoruz ama değiştiremiyoruz.
        public string Ad => _ad;
        public string Soyad => _soyad;

        public override string ToString()
        {
            return $"{Ad} {Soyad}";
        }
    }
}
