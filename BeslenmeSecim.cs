using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace saglikli_Beslenme_Proje
{
    public class Besin
    {
        public string Ad { get; set; }

        public Besin(string ad) => Ad = ad;

        public override bool Equals(object obj)
        {
            if (obj is Besin other)
                return this.Ad.Equals(other.Ad, StringComparison.OrdinalIgnoreCase);
            return false;
        }

        public override int GetHashCode()
        {
            return Ad.ToLower().GetHashCode();
        }
    }
    public class Hastalik
    {
        public int HastalikID { get; set; }
        public string HastalikAdi { get; set; }

        public Dictionary<string, List<Besin>> YemesiGerekenler { get; set; }
        public Dictionary<string, List<Besin>> YememesiGerekenler { get; set; }

        public Hastalik()
        {
            YemesiGerekenler = new Dictionary<string, List<Besin>>();
            YememesiGerekenler = new Dictionary<string, List<Besin>>();
        }
    }


    public static class BeslenmeSecim
    {
        public static Dictionary<string, Hastalik> Hastaliklar = new Dictionary<string, Hastalik>();

        static BeslenmeSecim()
        {
            var alzheimer = new Hastalik { HastalikAdi = "Alzheimer Hastalığı" };

            // Zengin
            alzheimer.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Somon"), new Besin("Ceviz"), new Besin("Yaban Mersini"), new Besin("Ispanak"),
                new Besin("Avokado"), new Besin("Keten Tohumu"), new Besin("Brokoli"), new Besin("Yeşil Çay"),
                new Besin("Kabak Çekirdeği"), new Besin("Zeytinyağı")
            });
            alzheimer.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Kızarmış Gıdalar"), new Besin("Şekerli Gazlı İçecekler"), new Besin("Beyaz Ekmek"),
                new Besin("Trans Yağlar"), new Besin("İşlenmiş Etler"), new Besin("Margarin"), new Besin("Aşırı Tuz"),
                new Besin("Alkol"), new Besin("Hazır Tatlılar"), new Besin("Fast Food")
            });

            // Ekonomik
            alzheimer.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Yumurta"), new Besin("Mercimek"), new Besin("Havuç"), new Besin("Elma"),
                new Besin("Yoğurt"), new Besin("Bulgur"), new Besin("Kabak"), new Besin("Çay"),
                new Besin("Ayçiçek Yağı"), new Besin("Kuru Fasulye")
            });
            alzheimer.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Aşırı Tuzlu Kuruyemiş"), new Besin("Hazır Gıdalar"), new Besin("Kızartmalar"),
                new Besin("Şekerli Atıştırmalıklar"), new Besin("Beyaz Un Ürünleri"), new Besin("Hazır Soslar"),
                new Besin("Margarin"), new Besin("Fast Food"), new Besin("Alkol"), new Besin("İşlenmiş Gıdalar")
            });

            // Vegan
            alzheimer.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Badem"), new Besin("Kabak Çekirdeği"),
                new Besin("Avokado"), new Besin("Yaban Mersini"), new Besin("Kara Lahana"), new Besin("Tatlı Patates"),
                new Besin("Mercimek"), new Besin("Brokoli")
            });
            alzheimer.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("İşlenmiş Vegan Gıdalar"), new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Şekerli İçecekler"),
                new Besin("Fast Food"), new Besin("Hazır Vegan Tatlılar"), new Besin("Alkol"), new Besin("Margarin"),
                new Besin("Dondurulmuş Hazır Yemekler"), new Besin("Beyaz Un"), new Besin("Trans Yağlar")
            });

            // Glutensiz
            alzheimer.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Kabak"), new Besin("Badem"), new Besin("Beyaz Et"), new Besin("Balık"),
                new Besin("Yeşil Sebzeler"), new Besin("Kabak Çekirdeği"), new Besin("Yumurta"), new Besin("Yoğurt"),
                new Besin("Kinoa"), new Besin("Zeytinyağı")
            });
            alzheimer.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Malt"),
                new Besin("İşlenmiş Ekmekler"), new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar")
            });

            // Laktozsuz
            alzheimer.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Peynir Alternatifleri"), new Besin("Yoğurt Alternatifleri"), new Besin("Somon"),
                new Besin("Brokoli"), new Besin("Kabak"), new Besin("Yumurta"), new Besin("Yeşil Sebzeler"),
                new Besin("Badem"), new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            alzheimer.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Dondurma"), new Besin("Peynir"),
                new Besin("Yoğurt"), new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar")
            });

            Hastaliklar.Add(alzheimer.HastalikAdi, alzheimer);
            Anemi(Kansızlık)
            var anemi = new Hastalik { HastalikAdi = "Anemi (Kansızlık)" };
            anemi.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Kırmızı Et"), new Besin("Karaciğer"), new Besin("Ispanak"), new Besin("Kuru Kayısı"),
                new Besin("Yumurta"), new Besin("Kinoa"), new Besin("Brokoli"), new Besin("Kırmızı Mercimek"),
                new Besin("Ceviz"), new Besin("Nar")
            });
            anemi.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Çay"), new Besin("Kahve"), new Besin("Süt Ürünleri (Aşırı)"), new Besin("Şekerli Gıdalar"),
                new Besin("Alkol"), new Besin("Fast Food"), new Besin("Beyaz Unlu Mamuller"), new Besin("Hazır Tatlılar"),
                new Besin("Kızartmalar"), new Besin("İşlenmiş Etler")
            });
            anemi.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Yumurta"), new Besin("Mercimek"), new Besin("Ispanak"), new Besin("Kuru Fasulye"),
                new Besin("Havuç"), new Besin("Elma"), new Besin("Yoğurt"), new Besin("Ayçiçek Yağı"),
                new Besin("Pirinç"), new Besin("Kabak")
            });
            anemi.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Şekerli Gıdalar"), new Besin("Hazır Soslar"),
                new Besin("Kızartmalar"), new Besin("Beyaz Un Ürünleri"), new Besin("Margarin"), new Besin("Fast Food"),
                new Besin("Alkol"), new Besin("İşlenmiş Etler"), new Besin("Hazır Tatlılar")
            });
            anemi.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Mercimek"), new Besin("Nohut"), new Besin("Brokoli"),
                new Besin("Tatlı Patates"), new Besin("Ispanak"), new Besin("Chia Tohumu"), new Besin("Ceviz"),
                new Besin("Kabak Çekirdeği"), new Besin("Kara Lahana")
            });
            anemi.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("İşlenmiş Vegan Gıdalar"), new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Şekerli İçecekler"),
                new Besin("Fast Food"), new Besin("Alkol"), new Besin("Margarin"), new Besin("Beyaz Un"),
                new Besin("Dondurulmuş Hazır Yemekler"), new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar")
            });
            anemi.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Beyaz Et"), new Besin("Balık"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"),
                new Besin("Yumurta"), new Besin("Kinoa"), new Besin("Yoğurt"), new Besin("Badem"),
                new Besin("Fındık"), new Besin("Zeytinyağı")
            });
            anemi.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Malt"),
                new Besin("İşlenmiş Ekmekler"), new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar")
            });
            anemi.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Peynir Alternatifleri"), new Besin("Yoğurt Alternatifleri"), new Besin("Balık"),
                new Besin("Yumurta"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"), new Besin("Badem"),
                new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Nar")
            });
            anemi.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Dondurma"), new Besin("Peynir"),
                new Besin("Yoğurt"), new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar")
            });
            Hastaliklar.Add(anemi.HastalikAdi, anemi);


            Diyabet(Şeker Hastalığı)
            var diyabet = new Hastalik { HastalikAdi = "Diyabet (Şeker Hastalığı)" };
            diyabet.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Badem"), new Besin("Ceviz"), new Besin("Somon"), new Besin("Brokoli"),
                new Besin("Kinoa"), new Besin("Yeşil Çay"), new Besin("Zeytinyağı"), new Besin("Kabak"),
                new Besin("Yumurta"), new Besin("Yaban Mersini")
            });
            diyabet.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Beyaz Ekmek"), new Besin("Şeker"), new Besin("Tatlılar"), new Besin("Hazır Meyve Suları"),
                new Besin("Gazlı İçecekler"), new Besin("İşlenmiş Gıdalar"), new Besin("Margarin"), new Besin("Kızartma"),
                new Besin("Alkol"), new Besin("Fast Food")
            });
            diyabet.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Kuru Fasulye"), new Besin("Yumurta"), new Besin("Yoğurt"),
                new Besin("Elma"), new Besin("Havuç"), new Besin("Bulgur"), new Besin("Kabak"),
                new Besin("Çay"), new Besin("Ayçiçek Yağı")
            });
            diyabet.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Beyaz Un"), new Besin("Kızartma"),
                new Besin("Hazır Tatlılar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol"), new Besin("İşlenmiş Gıdalar"), new Besin("Hazır Soslar")
            });
            diyabet.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Brokoli"), new Besin("Mercimek"),
                new Besin("Nohut"), new Besin("Tatlı Patates"), new Besin("Badem"), new Besin("Kabak Çekirdeği"),
                new Besin("Avokado"), new Besin("Kara Lahana")
            });
            diyabet.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol"), new Besin("Dondurulmuş Hazır Yemekler"),
                new Besin("Beyaz Un"), new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar"), new Besin("Hazır Soslar")
            });
            diyabet.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Balık"), new Besin("Beyaz Et"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"),
                new Besin("Yumurta"), new Besin("Kinoa"), new Besin("Yoğurt"), new Besin("Badem"),
                new Besin("Fındık"), new Besin("Zeytinyağı")
            });
            diyabet.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Malt"),
                new Besin("İşlenmiş Ekmekler"), new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar")
            });
            diyabet.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Peynir Alternatifleri"), new Besin("Yoğurt Alternatifleri"), new Besin("Balık"),
                new Besin("Yumurta"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"), new Besin("Badem"),
                new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Nar")
            });
            diyabet.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Dondurma"), new Besin("Peynir"),
                new Besin("Yoğurt"), new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar")
            });
            Hastaliklar.Add(diyabet.HastalikAdi, diyabet);

            Gastrointestinal Hastalıklar
            var gastrointestinal = new Hastalik { HastalikAdi = "Gastrointestinal Hastalıklar (Reflü, Ülser, İBS vb.)" };
            gastrointestinal.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Yulaf Ezmesi"), new Besin("Muz"), new Besin("Zencefil"), new Besin("Pirinç"),
                new Besin("Yoğurt"), new Besin("Haşlanmış Patates"), new Besin("Hindistancevizi Yağı"),
                new Besin("Havuç"), new Besin("Bal"), new Besin("Kabak")
            });
            gastrointestinal.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Baharatlı Gıdalar"), new Besin("Kafein"), new Besin("Alkol"), new Besin("Yağlı Kızartmalar"),
                new Besin("Sarımsak"), new Besin("Soğan"), new Besin("Domates"), new Besin("Turunçgiller"),
                new Besin("Soda"), new Besin("Nane")
            });
            gastrointestinal.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Yoğurt"), new Besin("Haşlanmış Patates"), new Besin("Elma"),
                new Besin("Havuç"), new Besin("Bulgur"), new Besin("Yulaf"), new Besin("Kabak"),
                new Besin("Yumurta"), new Besin("Ayçiçek Yağı")
            });
            gastrointestinal.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Baharatlı Hazır Yemekler"), new Besin("Kızartmalar"), new Besin("Soda"),
                new Besin("Alkol"), new Besin("Kafein"), new Besin("Yağlı Gıdalar"), new Besin("Turunçgiller"),
                new Besin("Soğan"), new Besin("Sarımsak"), new Besin("Nane")
            });
            gastrointestinal.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Yulaf"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Kabak"),
                new Besin("Tatlı Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Kara Lahana"),
                new Besin("Chia Tohumu"), new Besin("Keten Tohumu")
            });
            gastrointestinal.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Baharatlı Yemekler"), new Besin("Kafein"), new Besin("Alkol"), new Besin("Yağlı Kızartmalar"),
                new Besin("Soğan"), new Besin("Sarımsak"), new Besin("Domates"), new Besin("Turunçgiller"),
                new Besin("Soda"), new Besin("Nane")
            });
            gastrointestinal.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Yoğurt"), new Besin("Muz"), new Besin("Haşlanmış Patates"),
                new Besin("Yumurta"), new Besin("Balık"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            gastrointestinal.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Baharatlı Gıdalar"),
                new Besin("Kafein"), new Besin("Alkol"), new Besin("Yağlı Kızartmalar"), new Besin("Sarımsak"),
                new Besin("Soğan"), new Besin("Soda")
            });
            gastrointestinal.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Haşlanmış Patates"),
                new Besin("Yumurta"), new Besin("Balık"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            gastrointestinal.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Krema"), new Besin("Yağlı Kızartmalar"),
                new Besin("Kafein"), new Besin("Alkol"), new Besin("Baharatlı Gıdalar"), new Besin("Soğan"),
                new Besin("Sarımsak"), new Besin("Soda")
            });
            Hastaliklar.Add(gastrointestinal.HastalikAdi, gastrointestinal);


            Hipoglisemi(Düşük Kan Şekeri)
            var hipoglisemi = new Hastalik { HastalikAdi = "Hipoglisemi (Düşük Kan Şekeri)" };
            hipoglisemi.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Tam Tahıllar"), new Besin("Fındık"), new Besin("Kuru Üzüm"), new Besin("Yumurta"),
                new Besin("Badem"), new Besin("Elma"), new Besin("Kırmızı Et"), new Besin("Balık"),
                new Besin("Tatlı Patates"), new Besin("Yoğurt")
            });
            hipoglisemi.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Şekerli Tatlılar"), new Besin("Beyaz Ekmek"), new Besin("Gazlı İçecekler"),
                new Besin("Hazır Meyve Suları"), new Besin("Kızartmalar"), new Besin("Alkol"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("İşlenmiş Gıdalar"), new Besin("Hazır Soslar")
            });
            hipoglisemi.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Yumurta"), new Besin("Mercimek"), new Besin("Bulgur"), new Besin("Elma"),
                new Besin("Kuru Fasulye"), new Besin("Yoğurt"), new Besin("Havuç"), new Besin("Çay"),
                new Besin("Ayçiçek Yağı"), new Besin("Patates")
            });
            hipoglisemi.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Şekerli Tatlılar"), new Besin("Hazır Meyve Suları"), new Besin("Beyaz Ekmek"),
                new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Kızartmalar"),
                new Besin("Margarin"), new Besin("İşlenmiş Gıdalar"), new Besin("Gazlı İçecekler")
            });
            hipoglisemi.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Nohut"), new Besin("Mercimek"),
                new Besin("Tatlı Patates"), new Besin("Elma"), new Besin("Badem"), new Besin("Kabak Çekirdeği"),
                new Besin("Avokado"), new Besin("Kara Lahana")
            });
            hipoglisemi.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol"), new Besin("Dondurulmuş Hazır Yemekler"),
                new Besin("Beyaz Un"), new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar"), new Besin("Hazır Soslar")
            });
            hipoglisemi.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Balık"), new Besin("Beyaz Et"), new Besin("Pirinç"), new Besin("Muz"),
                new Besin("Yumurta"), new Besin("Yoğurt"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Badem"), new Besin("Zeytinyağı")
            });
            hipoglisemi.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Malt"),
                new Besin("Hazır Ekmekler"), new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar")
            });
            hipoglisemi.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Yumurta"),
                new Besin("Balık"), new Besin("Kabak"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Elma")
            });
            hipoglisemi.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Peynir"), new Besin("Dondurma"),
                new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar"), new Besin("Alkol")
            });
            Hastaliklar.Add(hipoglisemi.HastalikAdi, hipoglisemi);

            Hipertansiyon(Yüksek Tansiyon)
            var hipertansiyon = new Hastalik { HastalikAdi = "Hipertansiyon (Yüksek Tansiyon)" };
            hipertansiyon.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Kabak"), new Besin("Ispanak"), new Besin("Sarımsak"), new Besin("Kereviz"),
                new Besin("Zeytinyağı"), new Besin("Yulaf"), new Besin("Fındık"), new Besin("Elma"),
                new Besin("Yeşil Çay"), new Besin("Somon")
            });
            hipertansiyon.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Aşırı Tuz"), new Besin("İşlenmiş Etler"), new Besin("Fast Food"), new Besin("Alkol"),
                new Besin("Kızarmış Gıdalar"), new Besin("Gazlı İçecekler"), new Besin("Şekerli Atıştırmalıklar"),
                new Besin("Hazır Soslar"), new Besin("Margarin"), new Besin("Beyaz Ekmek")
            });
            hipertansiyon.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Yoğurt"), new Besin("Yumurta"),
                new Besin("Havuç"), new Besin("Elma"), new Besin("Bulgur"), new Besin("Kabak"),
                new Besin("Ayçiçek Yağı"), new Besin("Yeşil Çay")
            });
            hipertansiyon.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Aşırı Tuzlu Kuruyemiş"), new Besin("Fast Food"), new Besin("Hazır Gıdalar"),
                new Besin("Şekerli İçecekler"), new Besin("Kızarmış Gıdalar"), new Besin("Alkol"),
                new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Beyaz Un"), new Besin("Gazlı İçecekler")
            });
            hipertansiyon.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kara Lahana"), new Besin("Kabak Çekirdeği"), new Besin("Chia Tohumu"), new Besin("Badem"),
                new Besin("Avokado"), new Besin("Yeşil Sebzeler"), new Besin("Tatlı Patates"), new Besin("Mercimek"),
                new Besin("Nohut"), new Besin("Brokoli")
            });
            hipertansiyon.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Şekerli İçecekler"),
                new Besin("Fast Food"), new Besin("Alkol"), new Besin("Margarin"), new Besin("Trans Yağlar"),
                new Besin("Dondurulmuş Hazır Yemekler"), new Besin("Hazır Soslar"), new Besin("Beyaz Un")
            });
            hipertansiyon.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Balık"), new Besin("Beyaz Et"), new Besin("Kabak"),
                new Besin("Yumurta"), new Besin("Badem"), new Besin("Yoğurt"), new Besin("Yeşil Sebzeler"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            hipertansiyon.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("İşlenmiş Ekmekler"),
                new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"), new Besin("Hazır Soslar"),
                new Besin("Hazır Çorbalar"), new Besin("Alkol")
            });
            hipertansiyon.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Yumurta"),
                new Besin("Balık"), new Besin("Kabak"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Yeşil Çay")
            });
            hipertansiyon.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Peynir"), new Besin("Dondurma"),
                new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar"), new Besin("Alkol")
            });
            Hastaliklar.Add(hipertansiyon.HastalikAdi, hipertansiyon);


            İnsülin Direnci
            var insulinDirenci = new Hastalik { HastalikAdi = "İnsülin Direnci" };
            insulinDirenci.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Somon"), new Besin("Yulaf"), new Besin("Avokado"), new Besin("Ceviz"),
                new Besin("Yeşil Çay"), new Besin("Kabak"), new Besin("Brokoli"), new Besin("Yumurta"),
                new Besin("Kara Lahana"), new Besin("Keten Tohumu")
            });
            insulinDirenci.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Beyaz Ekmek"), new Besin("Şeker"), new Besin("Tatlılar"), new Besin("Gazlı İçecekler"),
                new Besin("İşlenmiş Gıdalar"), new Besin("Margarin"), new Besin("Kızartmalar"), new Besin("Alkol"),
                new Besin("Fast Food"), new Besin("Hazır Tatlılar")
            });
            insulinDirenci.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Kuru Fasulye"), new Besin("Yumurta"), new Besin("Yoğurt"),
                new Besin("Elma"), new Besin("Havuç"), new Besin("Bulgur"), new Besin("Kabak"),
                new Besin("Çay"), new Besin("Ayçiçek Yağı")
            });
            insulinDirenci.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Aşırı Tuzlu Atıştırmalıklar"), new Besin("Beyaz Un"), new Besin("Kızartma"),
                new Besin("Hazır Tatlılar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol"), new Besin("İşlenmiş Gıdalar"), new Besin("Hazır Soslar")
            });
            insulinDirenci.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Brokoli"), new Besin("Mercimek"),
                new Besin("Nohut"), new Besin("Tatlı Patates"), new Besin("Badem"), new Besin("Kabak Çekirdeği"),
                new Besin("Avokado"), new Besin("Kara Lahana")
            });
            insulinDirenci.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol"), new Besin("Dondurulmuş Hazır Yemekler"),
                new Besin("Beyaz Un"), new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar"), new Besin("Hazır Soslar")
            });
            insulinDirenci.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Balık"), new Besin("Beyaz Et"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"),
                new Besin("Yumurta"), new Besin("Kinoa"), new Besin("Yoğurt"), new Besin("Badem"),
                new Besin("Fındık"), new Besin("Zeytinyağı")
            });
            insulinDirenci.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Malt"),
                new Besin("İşlenmiş Ekmekler"), new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar")
            });
            insulinDirenci.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Peynir Alternatifleri"), new Besin("Yoğurt Alternatifleri"), new Besin("Balık"),
                new Besin("Yumurta"), new Besin("Kabak"), new Besin("Yeşil Sebzeler"), new Besin("Badem"),
                new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Nar")
            });
            insulinDirenci.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Süt Bazlı Tatlılar"), new Besin("Dondurma"), new Besin("Peynir"),
                new Besin("Yoğurt"), new Besin("Krema"), new Besin("Tereyağı (Laktozlu)"), new Besin("Hazır Çorbalar"),
                new Besin("Süt Tozu"), new Besin("Laktoz İçeren İşlenmiş Gıdalar")
            });
            Hastaliklar.Add(insulinDirenci.HastalikAdi, insulinDirenci);


            İrritabl Bağırsak Sendromu(İBS)
            var ibs = new Hastalik { HastalikAdi = "İrritabl Bağırsak Sendromu (İBS)" };
            ibs.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Muz"), new Besin("Yoğurt"), new Besin("Haşlanmış Patates"),
                new Besin("Hindistancevizi Yağı"), new Besin("Kabak"), new Besin("Havuç"), new Besin("Bal"),
                new Besin("Zencefil"), new Besin("Kivi")
            });
            ibs.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Baharatlı Gıdalar"), new Besin("Alkol"), new Besin("Kafein"), new Besin("Yağlı Kızartmalar"),
                new Besin("Sarımsak"), new Besin("Soğan"), new Besin("Kuru Fasulye"), new Besin("Süt Ürünleri (Aşırı)"),
                new Besin("Turunçgiller"), new Besin("Soda")
            });
            ibs.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Yoğurt"), new Besin("Haşlanmış Patates"), new Besin("Elma"),
                new Besin("Havuç"), new Besin("Bulgur"), new Besin("Yulaf"), new Besin("Kabak"),
                new Besin("Yumurta"), new Besin("Ayçiçek Yağı")
            });
            ibs.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Baharatlı Hazır Yemekler"), new Besin("Kızartmalar"), new Besin("Soda"),
                new Besin("Alkol"), new Besin("Kafein"), new Besin("Yağlı Gıdalar"), new Besin("Turunçgiller"),
                new Besin("Soğan"), new Besin("Sarımsak"), new Besin("Kuru Fasulye")
            });
            ibs.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Yulaf"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Kabak"),
                new Besin("Tatlı Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Kara Lahana"),
                new Besin("Chia Tohumu"), new Besin("Keten Tohumu")
            });
            ibs.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Baharatlı Yemekler"), new Besin("Kafein"), new Besin("Alkol"), new Besin("Yağlı Kızartmalar"),
                new Besin("Soğan"), new Besin("Sarımsak"), new Besin("Turunçgiller"), new Besin("Soda"),
                new Besin("Kuru Fasulye"), new Besin("Süt Ürünleri")
            });
            ibs.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Yoğurt"), new Besin("Muz"), new Besin("Haşlanmış Patates"),
                new Besin("Yumurta"), new Besin("Balık"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            ibs.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Baharatlı Gıdalar"),
                new Besin("Kafein"), new Besin("Alkol"), new Besin("Yağlı Kızartmalar"), new Besin("Sarımsak"),
                new Besin("Soğan"), new Besin("Soda")
            });
            ibs.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Haşlanmış Patates"),
                new Besin("Yumurta"), new Besin("Balık"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            ibs.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Krema"), new Besin("Yağlı Kızartmalar"),
                new Besin("Kafein"), new Besin("Alkol"), new Besin("Baharatlı Gıdalar"), new Besin("Soğan"),
                new Besin("Sarımsak"), new Besin("Soda")
            });
            Hastaliklar.Add(ibs.HastalikAdi, ibs);


            Kanser(Özellikle Kemoterapi Sonrası Beslenme)
            var kanser = new Hastalik { HastalikAdi = "Kanser (Özellikle Kemoterapi Sonrası Beslenme)" };
            kanser.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Somon"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Brokoli"), new Besin("Kuru Üzüm"),
                new Besin("Kuru Kayısı"), new Besin("Tatlı Patates"), new Besin("Badem"), new Besin("Yumurta"),
                new Besin("Yoğurt"), new Besin("Bal")
            });
            kanser.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Alkol"), new Besin("Kızarmış Gıdalar"), new Besin("Aşırı Tuzlu Gıdalar"),
                new Besin("İşlenmiş Etler"), new Besin("Hazır Tatlılar"), new Besin("Margarin"), new Besin("Fast Food"),
                new Besin("Şekerli İçecekler"), new Besin("Kafein"), new Besin("Hazır Soslar")
            });
            kanser.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Yumurta"), new Besin("Mercimek"), new Besin("Ispanak"), new Besin("Elma"),
                new Besin("Yoğurt"), new Besin("Havuç"), new Besin("Bulgur"), new Besin("Kabak"),
                new Besin("Ayçiçek Yağı"), new Besin("Kuru Fasulye")
            });
            kanser.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Kızarmış Gıdalar"), new Besin("Alkol"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"),
                new Besin("Şekerli İçecekler"), new Besin("İşlenmiş Etler"), new Besin("Margarin"),
                new Besin("Hazır Soslar"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Kafein")
            });
            kanser.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Tatlı Patates"), new Besin("Kara Lahana"),
                new Besin("Brokoli"), new Besin("Mercimek"), new Besin("Nohut"), new Besin("Badem"),
                new Besin("Kabak Çekirdeği"), new Besin("Avokado")
            });
            kanser.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Alkol"), new Besin("Şekerli İçecekler"),
                new Besin("Fast Food"), new Besin("Margarin"), new Besin("Dondurulmuş Hazır Yemekler"),
                new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar"), new Besin("Hazır Soslar"), new Besin("Beyaz Un")
            });
            kanser.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Balık"), new Besin("Beyaz Et"), new Besin("Pirinç"), new Besin("Muz"),
                new Besin("Yumurta"), new Besin("Yoğurt"), new Besin("Kabak"), new Besin("Havuç"),
                new Besin("Avokado"), new Besin("Zeytinyağı")
            });
            kanser.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Ekmekler"),
                new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"), new Besin("Hazır Soslar"),
                new Besin("Hazır Çorbalar"), new Besin("Alkol")
            });
            kanser.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Yumurta"),
                new Besin("Balık"), new Besin("Kabak"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Elma")
            });
            kanser.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Krema"), new Besin("Yağlı Kızartmalar"),
                new Besin("Kafein"), new Besin("Alkol"), new Besin("Hazır Soslar"), new Besin("Soğan"),
                new Besin("Sarımsak"), new Besin("Soda")
            });
            Hastaliklar.Add(kanser.HastalikAdi, kanser);


            // Karaciğer Hastalıkları
            var karaciger = new Hastalik { HastalikAdi = "Karaciğer Hastalıkları" };
            karaciger.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Enginar"), new Besin("Zeytinyağı"), new Besin("Somon"), new Besin("Yaban Mersini"),
                new Besin("Ceviz"), new Besin("Yeşil Çay"), new Besin("Ispanak"), new Besin("Sarımsak"),
                new Besin("Avokado"), new Besin("Yoğurt")
            });
            karaciger.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Alkol"), new Besin("Kızarmış Gıdalar"), new Besin("İşlenmiş Etler"),
                new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Şekerli Gıdalar"), new Besin("Gazlı İçecekler"),
                new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Tereyağı"), new Besin("Beyaz Ekmek")
            });
            karaciger.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Bulgur"), new Besin("Ispanak"), new Besin("Yoğurt"),
                new Besin("Havuç"), new Besin("Elma"), new Besin("Kabak"), new Besin("Zeytinyağı"),
                new Besin("Kuru Fasulye"), new Besin("Pirinç")
            });
            karaciger.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Alkol"), new Besin("Kızarmış Gıdalar"), new Besin("Aşırı Tuzlu Gıdalar"),
                new Besin("Şekerli Gıdalar"), new Besin("Gazlı İçecekler"), new Besin("İşlenmiş Etler"),
                new Besin("Margarin"), new Besin("Tereyağı"), new Besin("Hazır Soslar"), new Besin("Beyaz Ekmek")
            });
            karaciger.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Enginar"), new Besin("Zeytinyağı"), new Besin("Yaban Mersini"), new Besin("Ceviz"),
                new Besin("Yeşil Çay"), new Besin("Ispanak"), new Besin("Sarımsak"), new Besin("Avokado"),
                new Besin("Kabak Çekirdeği"), new Besin("Kinoa")
            });
            karaciger.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Alkol"), new Besin("İşlenmiş Vegan Gıdalar"), new Besin("Şekerli Gıdalar"),
                new Besin("Gazlı İçecekler"), new Besin("Margarin"), new Besin("Hazır Soslar"),
                new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Beyaz Ekmek"), new Besin("Fast Food"),
                new Besin("Trans Yağlar")
            });
            karaciger.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Pirinç"), new Besin("Mısır"), new Besin("Kinoa"), new Besin("Balık"),
                new Besin("Yumurta"), new Besin("Yoğurt"), new Besin("Ispanak"), new Besin("Kabak"),
                new Besin("Zeytinyağı"), new Besin("Avokado")
            });
            karaciger.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"),
                new Besin("Hazır Soslar"), new Besin("Hazır Çorbalar"), new Besin("Beyaz Ekmek"),
                new Besin("Pasta"), new Besin("Kek"), new Besin("Alkol")
            });
            karaciger.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Ispanak"),
                new Besin("Zeytinyağı"), new Besin("Kabak"), new Besin("Avokado"), new Besin("Elma"),
                new Besin("Badem"), new Besin("Kinoa")
            });
            karaciger.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Süt"), new Besin("Peynir"), new Besin("Krema"), new Besin("Dondurma"),
                new Besin("Tereyağı"), new Besin("Alkol"), new Besin("Hazır Soslar"),
                new Besin("Gazlı İçecekler"), new Besin("Kızarmış Gıdalar"), new Besin("Aşırı Tuzlu Gıdalar")
            });
            Hastaliklar.Add(karaciger.HastalikAdi, karaciger);

            // Kalp-Damar Hastalıkları
            var kalpDamar = new Hastalik { HastalikAdi = "Kalp-Damar Hastalıkları" };
            kalpDamar.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Somon"), new Besin("Ceviz"), new Besin("Zeytinyağı"), new Besin("Yulaf"), new Besin("Yeşil Yapraklı Sebzeler"),
                new Besin("Domates"), new Besin("Elma"), new Besin("Avokado"), new Besin("Yoğurt"), new Besin("Badem")
            });
            kalpDamar.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Trans Yağlar"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("İşlenmiş Etler"), new Besin("Margarin"),
                new Besin("Kızartmalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"), new Besin("Alkol"),
                new Besin("Hazır Tatlılar"), new Besin("Pastırma")
            });
            kalpDamar.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Bulgur"), new Besin("Yumurta"), new Besin("Ispanak"), new Besin("Yoğurt"),
                new Besin("Elma"), new Besin("Havuç"), new Besin("Pirinç"), new Besin("Kabak"), new Besin("Ayçiçek Yağı")
            });
            kalpDamar.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Margarin"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"),
                new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
                new Besin("İşlenmiş Etler"), new Besin("Pastırma")
            });
            kalpDamar.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Domates"), new Besin("Elma"), new Besin("Zeytinyağı"), new Besin("Kabak")
            });
            kalpDamar.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
                new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Beyaz Un"),
                new Besin("Alkol"), new Besin("Hazır Soslar")
            });
            kalpDamar.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Somon"), new Besin("Yumurta"), new Besin("Pirinç"), new Besin("Muz"), new Besin("Yoğurt"),
                new Besin("Zeytinyağı"), new Besin("Avokado"), new Besin("Kabak"), new Besin("Elma"), new Besin("Patates")
            });
            kalpDamar.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Glutensiz Ürünler (İşlenmiş)"),
                new Besin("Bira"), new Besin("Hazır Çorbalar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Alkol")
            });
            kalpDamar.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Yumurta"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Elma"), new Besin("Patates"), new Besin("Havuç"), new Besin("Ispanak")
            });
            kalpDamar.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Alkol"), new Besin("Gazlı İçecekler"),
                new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Kızartmalar"), new Besin("Fast Food")
            });
            Hastaliklar.Add(kalpDamar.HastalikAdi, kalpDamar);

            // Hipoglisemi
            var hipoglisemi = new Hastalik { HastalikAdi = "Hipoglisemi" };
            hipoglisemi.YemesiGerekenler.Add("Zengin", new List<Besin>
{
    new Besin("Yulaf"), new Besin("Tam Buğday Ekmeği"), new Besin("Yoğurt"), new Besin("Elma"), new Besin("Badem"),
    new Besin("Avokado"), new Besin("Somon"), new Besin("Ispanak"), new Besin("Kinoalı Salata"), new Besin("Kabak")
});
            hipoglisemi.YememesiGerekenler.Add("Zengin", new List<Besin>
{
    new Besin("Beyaz Ekmek"), new Besin("Şekerli Gıdalar"), new Besin("Bal"), new Besin("Şekerli İçecekler"), new Besin("Reçel"),
    new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Patates Kızartması"), new Besin("Cips"), new Besin("Hamur İşleri")
});
            hipoglisemi.YemesiGerekenler.Add("Ekonomik", new List<Besin>
{
    new Besin("Mercimek"), new Besin("Bulgur"), new Besin("Yumurta"), new Besin("Ispanak"), new Besin("Yoğurt"),
    new Besin("Elma"), new Besin("Havuç"), new Besin("Pirinç"), new Besin("Kabak"), new Besin("Salatalık")
});
            hipoglisemi.YememesiGerekenler.Add("Ekonomik", new List<Besin>
{
    new Besin("Şekerli Gıdalar"), new Besin("Beyaz Ekmek"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
    new Besin("Cips"), new Besin("Patates Kızartması"), new Besin("Hamur İşleri"), new Besin("Gazlı İçecekler"),
    new Besin("Şekerlemeler"), new Besin("Reçel")
});
            hipoglisemi.YemesiGerekenler.Add("Vegan", new List<Besin>
{
    new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
    new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Domates"), new Besin("Elma"), new Besin("Zeytinyağı"), new Besin("Kabak")
});
            hipoglisemi.YememesiGerekenler.Add("Vegan", new List<Besin>
{
    new Besin("Beyaz Ekmek"), new Besin("Şekerli Gıdalar"), new Besin("Hazır Vegan Tatlılar"), new Besin("Gazlı İçecekler"),
    new Besin("Fast Food"), new Besin("Cips"), new Besin("Hamur İşleri"), new Besin("Beyaz Un"), new Besin("Şekerli İçecekler"),
    new Besin("Reçel")
});
            hipoglisemi.YemesiGerekenler.Add("Glutensiz", new List<Besin>
{
    new Besin("Pirinç"), new Besin("Muz"), new Besin("Yoğurt"), new Besin("Zeytinyağı"), new Besin("Avokado"),
    new Besin("Kabak"), new Besin("Elma"), new Besin("Patates"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Badem")
});
            hipoglisemi.YememesiGerekenler.Add("Glutensiz", new List<Besin>
{
    new Besin("Hazır Glutensiz Tatlılar"), new Besin("Şekerli Gıdalar"), new Besin("Gazlı İçecekler"), new Besin("Beyaz Şeker"),
    new Besin("Şekerli İçecekler"), new Besin("Reçel"), new Besin("Hamur İşleri"), new Besin("Cips"), new Besin("Patates Kızartması"),
    new Besin("Fast Food")
});
            hipoglisemi.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
{
    new Besin("Laktozsuz Yoğurt"), new Besin("Yumurta"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"),
    new Besin("Zeytinyağı"), new Besin("Elma"), new Besin("Patates"), new Besin("Havuç"), new Besin("Ispanak")
});
            hipoglisemi.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
{
    new Besin("Şekerli Gıdalar"), new Besin("Beyaz Ekmek"), new Besin("Gazlı İçecekler"), new Besin("Reçel"), new Besin("Cips"),
    new Besin("Patates Kızartması"), new Besin("Fast Food"), new Besin("Hamur İşleri"), new Besin("Şekerlemeler"), new Besin("Hazır Tatlılar")
});
            Hastaliklar.Add(hipoglisemi.HastalikAdi, hipoglisemi);

            // Obezite
            var obezite = new Hastalik { HastalikAdi = "Obezite" };
            obezite.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Somon"), new Besin("Avokado"), new Besin("Kinoa"), new Besin("Yulaf"),
                new Besin("Badem"), new Besin("Zeytinyağı"), new Besin("Yoğurt"), new Besin("Ispanak"),
                new Besin("Tatlı Patates"), new Besin("Yumurta")
            });
            obezite.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Şekerli İçecekler"), new Besin("Fast Food"), new Besin("Cips"),
                new Besin("Beyaz Ekmek"), new Besin("Hamur İşleri"), new Besin("İşlenmiş Etler"),
                new Besin("Kızartmalar"), new Besin("Hazır Tatlılar"), new Besin("Alkol"), new Besin("Margarin")
            });
            obezite.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Mercimek"), new Besin("Yumurta"), new Besin("Elma"), new Besin("Havuç"),
                new Besin("Kabak"), new Besin("Yoğurt"), new Besin("Salatalık"), new Besin("Bulgur"),
                new Besin("Yeşil Mercimek"), new Besin("Ispanak")
            });
            obezite.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Şekerli İçecekler"), new Besin("Fast Food"), new Besin("Beyaz Ekmek"),
                new Besin("Hazır Tatlılar"), new Besin("Margarin"), new Besin("Hamur İşleri"),
                new Besin("Kızartmalar"), new Besin("Cips"), new Besin("İşlenmiş Etler"), new Besin("Alkol")
            });
            obezite.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Tatlı Patates"),
                new Besin("Kara Lahana"), new Besin("Brokoli"), new Besin("Ispanak"),
                new Besin("Kabak"), new Besin("Avokado"), new Besin("Badem"), new Besin("Nohut")
            });
            obezite.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Cips"), new Besin("Trans Yağlar"),
                new Besin("Hazır Tatlılar"), new Besin("Hazır Soslar"), new Besin("Beyaz Un"), new Besin("Alkol")
            });
            obezite.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Kinoa"), new Besin("Pirinç"), new Besin("Muz"), new Besin("Yumurta"),
                new Besin("Yoğurt"), new Besin("Kabak"), new Besin("Avokado"), new Besin("Zeytinyağı"),
                new Besin("Tatlı Patates"), new Besin("Badem")
            });
            obezite.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Ekmekler"),
                new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"), new Besin("Cips"),
                new Besin("Hazır Soslar"), new Besin("Şekerli İçecekler")
            });
            obezite.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Yumurta"),
                new Besin("Balık"), new Besin("Kabak"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Tatlı Patates")
            });
            obezite.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Krema"), new Besin("Dondurma"),
                new Besin("Yağlı Kızartmalar"), new Besin("Hazır Soslar"), new Besin("Margarin"),
                new Besin("Şekerli İçecekler"), new Besin("Cips"), new Besin("Alkol")
            });
            Hastaliklar.Add(obezite.HastalikAdi, obezite);

            // Parkinson Hastalığı
            var parkinson = new Hastalik { HastalikAdi = "Parkinson Hastalığı" };
            parkinson.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Somon"), new Besin("Ceviz"), new Besin("Zeytinyağı"), new Besin("Yaban Mersini"), new Besin("Ispanak"),
            new Besin("Avokado"), new Besin("Brokoli"), new Besin("Kinoa"), new Besin("Badem"), new Besin("Yeşil Çay")
        });
            parkinson.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("İşlenmiş Etler"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"), new Besin("Aşırı Tuzlu Gıdalar"),
            new Besin("Trans Yağlar"), new Besin("Margarin"), new Besin("Kızartmalar"), new Besin("Alkol"),
            new Besin("Hazır Tatlılar"), new Besin("Kafein (Aşırı)")
        });
            parkinson.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Yumurta"), new Besin("Bulgur"), new Besin("Kabak"), new Besin("Ayçiçek Yağı"), new Besin("Fasulye")
        });
            parkinson.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Margarin"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"),
            new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("İşlenmiş Etler"), new Besin("Beyaz Ekmek")
        });
            parkinson.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
            new Besin("Ispanak"), new Besin("Brokoli"), new Besin("Zeytinyağı"), new Besin("Yaban Mersini"), new Besin("Mercimek")
        });
            parkinson.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
            new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Beyaz Un"),
            new Besin("Alkol"), new Besin("Kafein (Aşırı)")
        });
            parkinson.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Somon"), new Besin("Pirinç"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Kinoa")
        });
            parkinson.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Glutensiz Ürünler (İşlenmiş)"),
            new Besin("Bira"), new Besin("Hazır Çorbalar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"),
            new Besin("Margarin"), new Besin("Alkol")
        });
            parkinson.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli")
        });
            parkinson.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Alkol"), new Besin("Gazlı İçecekler"),
            new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Kızartmalar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(parkinson.HastalikAdi, parkinson);

            // Gut Hastalığı
            var gut = new Hastalik { HastalikAdi = "Gut Hastalığı" };
            gut.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kiraz"), new Besin("Zeytinyağı"), new Besin("Kinoa"), new Besin("Brokoli"), new Besin("Avokado"),
            new Besin("Ceviz"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Muz"), new Besin("Ananas"), new Besin("Chia Tohumu")
        });
            gut.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("Deniz Ürünleri"), new Besin("Alkol"), new Besin("Şekerli İçecekler"),
            new Besin("Organ Etleri"), new Besin("Fast Food"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Kızartmalar"),
            new Besin("Trans Yağlar"), new Besin("Hazır Tatlılar")
        });
            gut.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Bulgur"), new Besin("Kabak"), new Besin("Ayçiçek Yağı"), new Besin("Domates"), new Besin("Patates")
        });
            gut.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("Alkol"), new Besin("Gazlı İçecekler"), new Besin("Margarin"),
            new Besin("Kızartmalar"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("İşlenmiş Etler"), new Besin("Organ Etleri")
        });
            gut.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
            new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Kiraz"), new Besin("Zeytinyağı"), new Besin("Brokoli"), new Besin("Muz")
        });
            gut.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
            new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Beyaz Un"),
            new Besin("Alkol"), new Besin("Hazır Soslar")
        });
            gut.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Brokoli"),
            new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Kinoa"), new Besin("Kiraz")
        });
            gut.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Kırmızı Et"), new Besin("Bira"),
            new Besin("Hazır Çorbalar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol")
        });
            gut.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Ispanak"),
            new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli"), new Besin("Kiraz")
        });
            gut.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Kırmızı Et"), new Besin("Alkol"),
            new Besin("Gazlı İçecekler"), new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(gut.HastalikAdi, gut);

            // Çölyak Hastalığı
            var colyak = new Hastalik { HastalikAdi = "Çölyak Hastalığı" };
            colyak.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Pirinç"), new Besin("Somon"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Muz"), new Besin("Badem"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Patates")
        });
            colyak.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Çorbalar"),
            new Besin("İşlenmiş Etler"), new Besin("Hazır Soslar"), new Besin("Fast Food"), new Besin("Hazır Tatlılar"), new Besin("Margarin")
        });
            colyak.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Mercimek"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Ispanak"), new Besin("Ayçiçek Yağı"), new Besin("Kabak"), new Besin("Muz"), new Besin("Fasulye")
        });
            colyak.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Soslar"),
            new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Hazır Tatlılar"), new Besin("İşlenmiş Etler")
        });
            colyak.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Badem"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Brokoli"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Mercimek")
        });
            colyak.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Vegan Ürünler"), new Besin("Bira"),
            new Besin("Hazır Soslar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Hazır Tatlılar")
        });
            colyak.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Kinoa"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Mercimek")
        });
            colyak.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Çorbalar"),
            new Besin("Hazır Soslar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol")
        });
            colyak.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli")
        });
            colyak.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("İnek Sütü"), new Besin("Peynir"),
            new Besin("Tereyağı"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Margarin")
        });
            Hastaliklar.Add(colyak.HastalikAdi, colyak);

            // Sedef Hastalığı
            var sedef = new Hastalik { HastalikAdi = "Sedef Hastalığı" };
            sedef.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Somon"), new Besin("Zeytinyağı"), new Besin("Avokado"), new Besin("Brokoli"), new Besin("Ceviz"),
            new Besin("Yaban Mersini"), new Besin("Kinoa"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Muz"), new Besin("Badem")
        });
            sedef.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("İşlenmiş Etler"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
            new Besin("Alkol"), new Besin("Kızartmalar"), new Besin("Trans Yağlar"), new Besin("Margarin"),
            new Besin("Hazır Tatlılar"), new Besin("Aşırı Tuzlu Gıdalar")
        });
            sedef.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Bulgur"), new Besin("Kabak"), new Besin("Ayçiçek Yağı"), new Besin("Patates"), new Besin("Fasulye")
        });
            sedef.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("Margarin"), new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"),
            new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("İşlenmiş Etler"), new Besin("Aşırı Tuzlu Gıdalar")
        });
            sedef.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
            new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Brokoli"), new Besin("Zeytinyağı"), new Besin("Muz"), new Besin("Mercimek")
        });
            sedef.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
            new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Beyaz Un"),
            new Besin("Alkol"), new Besin("Hazır Soslar")
        });
            sedef.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Kinoa"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Somon")
        });
            sedef.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Çorbalar"),
            new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol"), new Besin("Kırmızı Et")
        });
            sedef.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli")
        });
            sedef.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Kırmızı Et"), new Besin("Alkol"),
            new Besin("Gazlı İçecekler"), new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(sedef.HastalikAdi, sedef);

            // Sindirim Sistemi Hastalıkları
            var sindirim = new Hastalik { HastalikAdi = "Sindirim Sistemi Hastalıkları" };
            sindirim.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Yoğurt"), new Besin("Zeytinyağı"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Somon"),
            new Besin("Brokoli"), new Besin("Avokado"), new Besin("Elma"), new Besin("Kabak"), new Besin("Kinoa")
        });
            sindirim.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kızartmalar"), new Besin("Fast Food"), new Besin("Şekerli İçecekler"), new Besin("Alkol"),
            new Besin("Baharatlı Yiyecekler"), new Besin("Trans Yağlar"), new Besin("Margarin"), new Besin("Hazır Soslar"),
            new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Hazır Tatlılar")
        });
            sindirim.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Mercimek"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Yoğurt"), new Besin("Kabak"), new Besin("Ayçiçek Yağı"), new Besin("Ispanak"), new Besin("Muz")
        });
            sindirim.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"), new Besin("Alkol"), new Besin("Margarin"),
            new Besin("Fast Food"), new Besin("Baharatlı Yiyecekler"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("Aşırı Tuzlu Gıdalar"), new Besin("İşlenmiş Etler")
        });
            sindirim.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Muz"),
            new Besin("Brokoli"), new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Elma")
        });
            sindirim.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
            new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Baharatlı Yiyecekler"),
            new Besin("Alkol"), new Besin("Hazır Soslar")
        });
            sindirim.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Kinoa"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Mercimek")
        });
            sindirim.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Çorbalar"),
            new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol"), new Besin("Baharatlı Yiyecekler")
        });
            sindirim.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Avokado"), new Besin("Zeytinyağı"), new Besin("Ispanak"),
            new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli"), new Besin("Muz")
        });
            sindirim.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Alkol"), new Besin("Gazlı İçecekler"),
            new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Kızartmalar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(sindirim.HastalikAdi, sindirim);

            // Tiroid Hastalıkları
            var tiroid = new Hastalik { HastalikAdi = "Tiroid Hastalıkları" };
            tiroid.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Somon"), new Besin("Deniz Yosunu"), new Besin("Zeytinyağı"), new Besin("Brokoli"), new Besin("Ceviz"),
            new Besin("Avokado"), new Besin("Yaban Mersini"), new Besin("Kinoa"), new Besin("Badem"), new Besin("Muz")
        });
            tiroid.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Soya Ürünleri"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Kızartmalar"), new Besin("Fast Food"),
            new Besin("Şekerli İçecekler"), new Besin("Alkol"), new Besin("Trans Yağlar"), new Besin("Margarin"),
            new Besin("Hazır Tatlılar"), new Besin("Kafein (Aşırı)")
        });
            tiroid.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Yumurta"), new Besin("Patates"), new Besin("Ayçiçek Yağı"), new Besin("Kabak"), new Besin("Fasulye")
        });
            tiroid.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Soya Ürünleri"), new Besin("Margarin"), new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"),
            new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("Aşırı Tuzlu Gıdalar"), new Besin("İşlenmiş Etler")
        });
            tiroid.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
            new Besin("Ispanak"), new Besin("Brokoli"), new Besin("Zeytinyağı"), new Besin("Muz"), new Besin("Deniz Yosunu")
        });
            tiroid.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Soya Ürünleri"), new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"),
            new Besin("Margarin"), new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"),
            new Besin("Alkol"), new Besin("Kafein (Aşırı)")
        });
            tiroid.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Kinoa"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Somon")
        });
            tiroid.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Soya Ürünleri"), new Besin("Bira"),
            new Besin("Hazır Çorbalar"), new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol")
        });
            tiroid.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli")
        });
            tiroid.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Soya Ürünleri"), new Besin("Alkol"),
            new Besin("Gazlı İçecekler"), new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(tiroid.HastalikAdi, tiroid);

            // Psoriatik Artrit
            var psoriatik = new Hastalik { HastalikAdi = "Psoriatik Artrit" };
            psoriatik.YemesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Somon"), new Besin("Zeytinyağı"), new Besin("Avokado"), new Besin("Brokoli"), new Besin("Ceviz"),
            new Besin("Yaban Mersini"), new Besin("Kinoa"), new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Muz"), new Besin("Badem")
        });
            psoriatik.YememesiGerekenler.Add("Zengin", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("İşlenmiş Etler"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
            new Besin("Alkol"), new Besin("Kızartmalar"), new Besin("Trans Yağlar"), new Besin("Margarin"),
            new Besin("Hazır Tatlılar"), new Besin("Aşırı Tuzlu Gıdalar")
        });
            psoriatik.YemesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Mercimek"), new Besin("Pirinç"), new Besin("Ispanak"), new Besin("Havuç"), new Besin("Elma"),
            new Besin("Bulgur"), new Besin("Kabak"), new Besin("Ayçiçek Yağı"), new Besin("Patates"), new Besin("Fasulye")
        });
            psoriatik.YememesiGerekenler.Add("Ekonomik", new List<Besin>
        {
            new Besin("Kırmızı Et"), new Besin("Margarin"), new Besin("Kızartmalar"), new Besin("Gazlı İçecekler"),
            new Besin("Alkol"), new Besin("Fast Food"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"),
            new Besin("İşlenmiş Etler"), new Besin("Aşırı Tuzlu Gıdalar")
        });
            psoriatik.YemesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Kinoa"), new Besin("Chia Tohumu"), new Besin("Ceviz"), new Besin("Badem"), new Besin("Avokado"),
            new Besin("Yeşil Yapraklı Sebzeler"), new Besin("Brokoli"), new Besin("Zeytinyağı"), new Besin("Muz"), new Besin("Mercimek")
        });
            psoriatik.YememesiGerekenler.Add("Vegan", new List<Besin>
        {
            new Besin("Trans Yağlar"), new Besin("Hazır Vegan Ürünler"), new Besin("Aşırı Tuzlu Gıdalar"), new Besin("Margarin"),
            new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"), new Besin("Fast Food"), new Besin("Beyaz Un"),
            new Besin("Alkol"), new Besin("Hazır Soslar")
        });
            psoriatik.YemesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Pirinç"), new Besin("Kinoa"), new Besin("Muz"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Brokoli"), new Besin("Patates"), new Besin("Elma"), new Besin("Havuç"), new Besin("Somon")
        });
            psoriatik.YememesiGerekenler.Add("Glutensiz", new List<Besin>
        {
            new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Bira"), new Besin("Hazır Çorbalar"),
            new Besin("Gazlı İçecekler"), new Besin("Fast Food"), new Besin("Margarin"), new Besin("Alkol"), new Besin("Kırmızı Et")
        });
            psoriatik.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("Laktozsuz Yoğurt"), new Besin("Pirinç"), new Besin("Balık"), new Besin("Avokado"), new Besin("Zeytinyağı"),
            new Besin("Ispanak"), new Besin("Patates"), new Besin("Havuç"), new Besin("Elma"), new Besin("Brokoli")
        });
            psoriatik.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
        {
            new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Tereyağı"), new Besin("Kırmızı Et"), new Besin("Alkol"),
            new Besin("Gazlı İçecekler"), new Besin("Margarin"), new Besin("Hazır Soslar"), new Besin("Hazır Tatlılar"), new Besin("Fast Food")
        });
            Hastaliklar.Add(psoriatik.HastalikAdi, psoriatik);
            // Osteoporoz (Kemik Erimesi)
            var osteoporoz = new Hastalik { HastalikAdi = "Osteoporoz (Kemik Erimesi)" };
            osteoporoz.YemesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Süt"), new Besin("Yoğurt"), new Besin("Peynir"), new Besin("Somon"),
                new Besin("Badem"), new Besin("Ispanak"), new Besin("Kefir"), new Besin("Brokoli"),
                new Besin("Yumurta"), new Besin("Zeytinyağı")
            });
            osteoporoz.YememesiGerekenler.Add("Zengin", new List<Besin>
            {
                new Besin("Alkol"), new Besin("Fazla Tuz"), new Besin("Kafein"), new Besin("Şekerli İçecekler"),
                new Besin("İşlenmiş Etler"), new Besin("Fast Food"), new Besin("Hazır Tatlılar"),
                new Besin("Gazlı İçecekler"), new Besin("Aşırı Protein"), new Besin("Margarin")
            });
            osteoporoz.YemesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Yoğurt"), new Besin("Yumurta"), new Besin("Ispanak"), new Besin("Elma"),
                new Besin("Havuç"), new Besin("Kabak"), new Besin("Bulgur"), new Besin("Sardalya"),
                new Besin("Mercimek"), new Besin("Yeşil Fasulye")
            });
            osteoporoz.YememesiGerekenler.Add("Ekonomik", new List<Besin>
            {
                new Besin("Alkol"), new Besin("Fazla Tuz"), new Besin("Kafein"), new Besin("Gazlı İçecekler"),
                new Besin("Fast Food"), new Besin("Hazır Tatlılar"), new Besin("Margarin"),
                new Besin("İşlenmiş Etler"), new Besin("Beyaz Ekmek"), new Besin("Cips")
            });
            osteoporoz.YemesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Badem"), new Besin("Chia Tohumu"), new Besin("Kinoa"), new Besin("Ispanak"),
                new Besin("Brokoli"), new Besin("Tatlı Patates"), new Besin("Avokado"), new Besin("Kabak Çekirdeği"),
                new Besin("Soya Fasulyesi"), new Besin("Kara Lahana")
            });
            osteoporoz.YememesiGerekenler.Add("Vegan", new List<Besin>
            {
                new Besin("Hazır Vegan Gıdalar"), new Besin("Şekerli İçecekler"), new Besin("Fast Food"),
                new Besin("Margarin"), new Besin("Gazlı İçecekler"), new Besin("Hazır Tatlılar"),
                new Besin("Trans Yağlar"), new Besin("Hazır Soslar"), new Besin("Beyaz Un"), new Besin("Alkol")
            });
            osteoporoz.YemesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Süt"), new Besin("Yoğurt"), new Besin("Peynir"), new Besin("Somon"),
                new Besin("Tatlı Patates"), new Besin("Avokado"), new Besin("Badem"), new Besin("Yumurta"),
                new Besin("Zeytinyağı"), new Besin("Kabak")
            });
            osteoporoz.YememesiGerekenler.Add("Glutensiz", new List<Besin>
            {
                new Besin("Buğday"), new Besin("Arpa"), new Besin("Çavdar"), new Besin("Hazır Ekmekler"),
                new Besin("Pasta"), new Besin("Kek"), new Besin("Bira"), new Besin("Hazır Soslar"),
                new Besin("Gazlı İçecekler"), new Besin("Alkol")
            });
            osteoporoz.YemesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("Laktozsuz Yoğurt"), new Besin("Muz"), new Besin("Pirinç"), new Besin("Yumurta"),
                new Besin("Tatlı Patates"), new Besin("Somon"), new Besin("Badem"), new Besin("Avokado"),
                new Besin("Zeytinyağı"), new Besin("Ispanak")
            });
            osteoporoz.YememesiGerekenler.Add("Laktozsuz", new List<Besin>
            {
                new Besin("İnek Sütü"), new Besin("Peynir"), new Besin("Krema"), new Besin("Dondurma"),
                new Besin("Yağlı Kızartmalar"), new Besin("Hazır Soslar"), new Besin("Margarin"),
                new Besin("Gazlı İçecekler"), new Besin("Şekerli İçecekler"), new Besin("Alkol")
            });
            Hastaliklar.Add(osteoporoz.HastalikAdi, osteoporoz);

        }
        public static void EkleBesinleriVeriTabaninaVeTercihleri(SqlConnection baglanti)
        {
            try
            {
                DatabaseHelper.BaglantiAc();
                EkleBesinleriVeriTabanina(baglanti); // Besinleri ekle

                // Hastalık ve tercihleri veritabanına ekle (örnek)
                foreach (var hastalik in Hastaliklar.Values)
                {
                    string sorguHastalik = "IF NOT EXISTS (SELECT 1 FROM dbo.Hastaliklar WHERE HastalikAdi = @HastalikAdi) INSERT INTO dbo.Hastaliklar (HastalikAdi) VALUES (@HastalikAdi)";
                    using (SqlCommand cmdHastalik = new SqlCommand(sorguHastalik, baglanti))
                    {
                        cmdHastalik.Parameters.AddWithValue("@HastalikAdi", hastalik.HastalikAdi);
                        cmdHastalik.ExecuteNonQuery();
                    }

                    foreach (var tercih in hastalik.YemesiGerekenler.Keys.Union(hastalik.YememesiGerekenler.Keys).Distinct())
                    {
                        string sorguTercih = "IF NOT EXISTS (SELECT 1 FROM dbo.BeslenmeTercihleri WHERE TercihAdi = @TercihAdi) INSERT INTO dbo.BeslenmeTercihleri (TercihAdi) VALUES (@TercihAdi)";
                        using (SqlCommand cmdTercih = new SqlCommand(sorguTercih, baglanti))
                        {
                            cmdTercih.Parameters.AddWithValue("@TercihAdi", tercih);
                            cmdTercih.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına ekleme hatası: " + ex.Message);
            }
            finally
            {
                DatabaseHelper.BaglantiKapat();
            }
        }
    }
}
