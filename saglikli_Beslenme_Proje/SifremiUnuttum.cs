using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace saglikli_Beslenme_Proje
{
    public partial class SifremiUnuttum : Form
    {
        public SifremiUnuttum()
        {
            InitializeComponent();
        }

        private void btnSifreGuncelle_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKadi.Text.Trim();
            string yeniSifre = txtYeniSifre.Text;

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(yeniSifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string baglantiYolu = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=saglikliBeslenme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection baglanti = new SqlConnection(baglantiYolu))
            {
                baglanti.Open();

                // Kullanıcı var mı kontrol et
                string kontrolSorgu = "SELECT COUNT(*) FROM KayitOl WHERE kullaniciAdi = @kadi";
                SqlCommand kontrolKomut = new SqlCommand(kontrolSorgu, baglanti);
                kontrolKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);
                int kayitSayisi = (int)kontrolKomut.ExecuteScalar();

                if (kayitSayisi == 0)
                {
                    MessageBox.Show("Bu kullanıcı adına ait bir kayıt bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Şifreyi güncelle
                string guncelleSorgu = "UPDATE KayitOl SET sifre = @sifre WHERE kullaniciAdi = @kadi";
                SqlCommand guncelleKomut = new SqlCommand(guncelleSorgu, baglanti);
                guncelleKomut.Parameters.AddWithValue("@sifre", yeniSifre);
                guncelleKomut.Parameters.AddWithValue("@kadi", kullaniciAdi);

                int guncelleSonuc = guncelleKomut.ExecuteNonQuery();

                if (guncelleSonuc > 0)
                {
                    MessageBox.Show("Şifre başarıyla güncellendi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close(); // Formu kapat
                }
                else
                {
                    MessageBox.Show("Şifre güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SifremiUnuttum_Load(object sender, EventArgs e)
        {

        }
    }
}
