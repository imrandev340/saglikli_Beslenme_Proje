using System;
using System.Collections.Generic;

namespace saglikli_Beslenme_Proje
{
    // Besin sınıfı
    public class Besin
    {
        public string Isim { get; set; }
        public string Aciklama { get; set; }  // Açıklama gerekiyorsa
        public string Kategori { get; set; }  // Örn: Zengin, Vegan vb.

        public Besin(string isim)
        {
            Isim = isim;
        }
    }

    // Hastalık sınıfı
    public class Hastalik
    {
        public string Isim { get; set; }
        // Dictionary yerine List kullanıyoruz
        public List<Besin> YenmesiGerekenler { get; set; }
        public List<Besin> YememesiGerekenler { get; set; }

        public Hastalik()
        {
            YenmesiGerekenler = new List<Besin>();
            YememesiGerekenler = new List<Besin>();
        }
    }
    // Listeleme veya görüntüleme için sınıf
    public class BesinGosterim
    {
        public string TuketilmeliAd { get; set; }
        public string TuketilmemeliAd { get; set; }
    }

    // Ana beslenme seçimi sınıfı (hastalıklar burada tutulur)
    public static class BeslenmeSecim
    {
        public static Dictionary<string, Hastalik> Hastaliklar { get; set; } = new Dictionary<string, Hastalik>();
    }
}
