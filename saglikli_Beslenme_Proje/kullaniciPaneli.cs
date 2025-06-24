using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//ADO.Net SQL Server Kütüphane Tanımlama!!!!!!SINAVVV

namespace saglikli_Beslenme_Proje
{
    public static class DatabaseHelper
    {
        private static readonly string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=saglikliBeslenme;Integrated Security=True";
        public static SqlConnection Baglanti = new SqlConnection(connectionString);

        public static void BaglantiAc()
        {
            if (Baglanti.State != ConnectionState.Open)
                Baglanti.Open();
        }

        public static void BaglantiKapat()
        {
            if (Baglanti.State == ConnectionState.Open)
                Baglanti.Close();
        }
    }
    public partial class kullaniciPaneli : Form
    {
        public string Boy { get; set; }
        public string Kilo { get; set; }
        public string Cinsiyet { get; set; }
        public string BeslenmeTercihi { get; set; }
        public string Hastalik { get; set; }
        public int KullaniciID { get; set; }
        public string SecilenHastalik { get; set; }
        public int SecilenHastalikID { get; set; }
        public int HastalikID { get; set; } // SQL ile birebir uyumlu
        public string HastalikAdi { get; set; } // SQL ile birebir uyumlu
        public kullaniciPaneli()
        {
            InitializeComponent();
            
        }

        private void kullaniciPaneli_Load(object sender, EventArgs e)
        {
            // ZORUNLU: Static constructor çalıştırmak için
            // var dummy = BeslenmeSecim.Hastaliklar; // Bu satırı isterseniz silebilirsiniz, BesinleriYukle() çağrısı da static constructor'ı tetikleyecektir.

            HastaliklariYukle();
            BeslenmeTercihleriniYukle();
            // BURAYA EKLEYİN: Veritabanından tüm besin verilerini yükle
            BesinleriYukle(); // <--- Bu satırı ekleyin!

            lblYildizBoy.Visible = false;
            lblYildizKilo.Visible = false;
            lblVki.Visible = false;
            kPanelileri.Enabled = false;
            kPanelileri.Visible = false;

            cmbHastalik.SelectedIndex = -1; // Hastalık combobox boş gelsin
            cmbTercih.SelectedIndex = -1;   // Tercih combobox boş gelsin

            if (!string.IsNullOrEmpty(SecilenHastalik))
                MessageBox.Show("Aktarılan Hastalık: " + SecilenHastalik);
        }

        private void HastaliklariYukle()
        {
            cmbHastalik.Items.Clear();
            try
            {
                DatabaseHelper.BaglantiAc();
                string sorgu = "SELECT DISTINCT HastalikAdi FROM Hastaliklar ORDER BY HastalikAdi";

                using (SqlCommand cmd = new SqlCommand(sorgu, DatabaseHelper.Baglanti))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string hastalikAdi = dr["HastalikAdi"].ToString().Trim();
                        cmbHastalik.Items.Add(hastalikAdi);

                        if (!BeslenmeSecim.Hastaliklar.ContainsKey(hastalikAdi))
                        {
                            BeslenmeSecim.Hastaliklar[hastalikAdi] = new Hastalik { HastalikAdi = hastalikAdi };
                        }
                    }
                }

                if (cmbHastalik.Items.Count > 0)
                    cmbHastalik.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hastalıklar yüklenirken hata oluştu: " + ex.Message);
            }
            finally { DatabaseHelper.BaglantiKapat(); }
        }

        private void BeslenmeTercihleriniYukle()
        {
            cmbTercih.Items.Clear(); // ComboBox'ı temizle
            try
            {
                DatabaseHelper.BaglantiAc();
                string sorgu = "SELECT TercihAdi FROM BeslenmeTercihleri ORDER BY TercihAdi"; // Alfabetik sıralama ekledik

                using (SqlCommand cmd = new SqlCommand(sorgu, DatabaseHelper.Baglanti))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                        cmbTercih.Items.Add(dr["TercihAdi"].ToString());
                }

                if (cmbTercih.Items.Count > 0)
                    cmbTercih.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Beslenme tercihleri yüklenirken hata oluştu: " + ex.Message);
            }
            finally { DatabaseHelper.BaglantiKapat(); }
        }

        private void BesinleriYukle()
        {
            try
            {
                DatabaseHelper.BaglantiAc();
                string sorgu = @"
            SELECT h.HastalikID, h.HastalikAdi, t.TercihAdi, b.BesinAdi, bt.YemeliMi
            FROM Hastaliklar h
            JOIN BesinTercihi bt ON h.HastalikID = bt.HastalikID
            JOIN Besinler b ON bt.BesinID = b.BesinID
            JOIN BeslenmeTercihleri t ON bt.TercihID = t.TercihID";

                using (SqlCommand cmd = new SqlCommand(sorgu, DatabaseHelper.Baglanti))
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        int hastalikId = Convert.ToInt32(dr["HastalikID"]);
                        string hastalikAdi = dr["HastalikAdi"].ToString();
                        string tercihAdi = dr["TercihAdi"].ToString();
                        string besinAdi = dr["BesinAdi"].ToString();
                        bool yemeliMi = Convert.ToBoolean(dr["YemeliMi"]);

                        if (!BeslenmeSecim.Hastaliklar.ContainsKey(hastalikAdi))
                        {
                            BeslenmeSecim.Hastaliklar[hastalikAdi] = new Hastalik { HastalikAdi = hastalikAdi, HastalikID = hastalikId };
                        }

                        var hastalik = BeslenmeSecim.Hastaliklar[hastalikAdi];
                        var besin = new Besin(besinAdi);

                        if (yemeliMi)
                        {
                            if (!hastalik.YemesiGerekenler.ContainsKey(tercihAdi))
                                hastalik.YemesiGerekenler[tercihAdi] = new List<Besin>();
                            if (!hastalik.YemesiGerekenler[tercihAdi].Any(b => b.Ad.Equals(besin.Ad, StringComparison.OrdinalIgnoreCase)))
                                hastalik.YemesiGerekenler[tercihAdi].Add(besin);
                        }
                        else
                        {
                            if (!hastalik.YememesiGerekenler.ContainsKey(tercihAdi))
                                hastalik.YememesiGerekenler[tercihAdi] = new List<Besin>();
                            if (!hastalik.YememesiGerekenler[tercihAdi].Any(b => b.Ad.Equals(besin.Ad, StringComparison.OrdinalIgnoreCase)))
                                hastalik.YememesiGerekenler[tercihAdi].Add(besin);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Besin verileri yüklenirken hata: " + ex.Message);
            }
            finally { DatabaseHelper.BaglantiKapat(); }
        }

        private double HesaplaVKI(string boy, string kilo)
        {
            if (!double.TryParse(boy, out double boyMetre) || !double.TryParse(kilo, out double kiloDeger))
                throw new Exception("Boy ve kilo sayısal değer olmalıdır!");

            boyMetre /= 100.0; // cm’den metreye çevir
            return kiloDeger / (boyMetre * boyMetre);
        }
        private void btnHesapla_Click(object sender, EventArgs e)
        {
            lblVki.Visible = true;
            kPanelileri.Enabled = true;
            kPanelileri.Visible = true;

            if (string.IsNullOrWhiteSpace(txtBoy.Text) || string.IsNullOrWhiteSpace(txtKilo.Text))
            {
                MessageBox.Show("Boy ve kilo giriniz!");
                return;
            }

            try
            {
                double vki = HesaplaVKI(txtBoy.Text.Trim(), txtKilo.Text.Trim());
                string durum;
                Color renk;

                if (vki < 18.5) { durum = "Zayıf"; renk = Color.LightBlue; }
                else if (vki < 25) { durum = "Normal"; renk = Color.LightGreen; }
                else if (vki < 30) { durum = "Fazla kilolu"; renk = Color.Khaki; }
                else if (vki < 35) { durum = "1. Derece Obezite"; renk = Color.Orange; }
                else if (vki < 40) { durum = "2. Derece Obezite"; renk = Color.OrangeRed; }
                else { durum = "3. Derece Obezite"; renk = Color.Red; }

                lblVki.Text = $"VKİ: {vki:F2} → {durum}";
                lblVki.BackColor = renk;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesaplama hatası: " + ex.Message);
            }
        }

        private void kPanelileri_Click(object sender, EventArgs e)
        {
            
            if (string.IsNullOrWhiteSpace(txtBoy.Text) || string.IsNullOrWhiteSpace(txtKilo.Text) ||
        cmbTercih.SelectedIndex == -1 || cmbHastalik.SelectedIndex == -1)
            {
                MessageBox.Show("Tüm alanları doldurunuz!");
                return;
            }

            Boy = txtBoy.Text.Trim();
            Kilo = txtKilo.Text.Trim();
            BeslenmeTercihi = cmbTercih.SelectedItem?.ToString().Trim();
            Hastalik = cmbHastalik.SelectedItem?.ToString().Trim();

            try
            {
                DatabaseHelper.BaglantiAc();

                SqlCommand cmdGetHastalikId = new SqlCommand("SELECT HastalikID FROM Hastaliklar WHERE HastalikAdi = @HastalikAdi", DatabaseHelper.Baglanti);
                cmdGetHastalikId.Parameters.AddWithValue("@HastalikAdi", Hastalik);
                object hastalikIdResult = cmdGetHastalikId.ExecuteScalar();
                if (hastalikIdResult == null) throw new Exception("Hastalık veritabanında yok!");
                SecilenHastalikID = Convert.ToInt32(hastalikIdResult);

                if (!BeslenmeSecim.Hastaliklar.ContainsKey(Hastalik))
                {
                    MessageBox.Show($"'{Hastalik}' hastalığı için beslenme önerileri sistemde tanımlı değil. Lütfen veritabanı veya kodda bu hastalığı ekleyin.");
                    return;
                }

                SqlCommand cmdGetTercihId = new SqlCommand("SELECT TercihID FROM BeslenmeTercihleri WHERE TercihAdi = @TercihAdi", DatabaseHelper.Baglanti);
                cmdGetTercihId.Parameters.AddWithValue("@TercihAdi", BeslenmeTercihi);
                object tercihIdResult = cmdGetTercihId.ExecuteScalar();
                if (tercihIdResult == null) throw new Exception("Tercih veritabanında yok!");
                int TercihID = Convert.ToInt32(tercihIdResult);

                string sql = @"SELECT COUNT(*) FROM KisiBilgi WHERE KullaniciID = @KullaniciID";

                SqlCommand kontrolCmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
                kontrolCmd.Parameters.AddWithValue("@KullaniciID", KullaniciID);
                int kayitVarMi = (int)kontrolCmd.ExecuteScalar();

                string komutSql = kayitVarMi > 0 ?
                 @"UPDATE KisiBilgi SET 
                 Cinsiyet = @Cinsiyet, 
                 Boy = @BoyCm, 
                 Kilo = @KiloKg, 
                 Vki = @Vki, 
                 HastalikID = @SecilenHastalikID, 
                 BeslenmeTercihi = @SecilenTercihID 
                 WHERE KullaniciID = @KullaniciID" :
                 @"INSERT INTO KisiBilgi (Cinsiyet, Boy, Kilo, Vki, HastalikID, BeslenmeTercihi)
                   VALUES (@Cinsiyet, @BoyCm, @KiloKg, @Vki, @SecilenHastalikID, @SecilenTercihID)";


                using (SqlCommand komut = new SqlCommand(komutSql, DatabaseHelper.Baglanti))
                {
                    komut.Parameters.AddWithValue("@KullaniciID", KullaniciID);
                    komut.Parameters.AddWithValue("@Cinsiyet", this.Cinsiyet);
                    komut.Parameters.AddWithValue("@BoyCm", Convert.ToDecimal(Boy.Replace('.', ',')));
                    komut.Parameters.AddWithValue("@KiloKg", Convert.ToDecimal(Kilo.Replace('.', ',')));

                    // VKI hesaplayalım:
                    double boyMetre = Convert.ToDouble(Boy) / 100.0;
                    double kiloDeger = Convert.ToDouble(Kilo);
                    double vki = kiloDeger / (boyMetre * boyMetre);
                    komut.Parameters.AddWithValue("@Vki", vki);

                    komut.Parameters.AddWithValue("@SecilenHastalikID", SecilenHastalikID);
                    komut.Parameters.AddWithValue("@SecilenTercihID", TercihID);

                    int sonuc = komut.ExecuteNonQuery();
                    MessageBox.Show(sonuc > 0 ? "Kayıt başarılı!" : "Kayıt başarısız!");
                }

                // Verileri yüklemeden önce
                BesinleriYukle();

                Form2 frm = new Form2
                {
                    SecilenHastalik = this.Hastalik,
                    SecilenTercih = this.BeslenmeTercihi
                };

                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                DatabaseHelper.BaglantiKapat();
            }
        }
    }
    
}
    
  

