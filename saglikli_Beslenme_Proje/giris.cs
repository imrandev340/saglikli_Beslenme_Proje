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
using System.Configuration;

namespace saglikli_Beslenme_Proje
{
    public partial class giris : Form
    {
        public giris()
        {
            InitializeComponent();
        }

        private void btnKayitOl_Click(object sender, EventArgs e)
        {
            bool bosAlanVar = false;

            // Boş alan kontrolü
            if (string.IsNullOrWhiteSpace(txtKadi.Text))
            {
                txtKadi.BackColor = Color.Red;
                bosAlanVar = true;
            }
            if (string.IsNullOrWhiteSpace(txtPosta.Text))
            {
                txtPosta.BackColor = Color.Red;
                bosAlanVar = true;
            }
            if (string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                txtSifre.BackColor = Color.Red;
                bosAlanVar = true;
            }

            if (bosAlanVar)
            {
                MessageBox.Show("Lütfen tüm zorunlu alanları doldurunuz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string baglantiYolu = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=saglikliBeslenme;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection baglanti = new SqlConnection(baglantiYolu);
                baglanti.Open();

                // 1. Önce kullanıcı adı zaten var mı kontrol et
                SqlCommand kontrolKomut = new SqlCommand("SELECT COUNT(*) FROM KayitOl WHERE kullaniciAdi = @kullaniciAdi", baglanti);
                kontrolKomut.Parameters.AddWithValue("@kullaniciAdi", txtKadi.Text.Trim());

                int kayitSayisi = (int)kontrolKomut.ExecuteScalar();

                if (kayitSayisi > 0)
                {
                    MessageBox.Show("Bu kullanıcı adı zaten kayıtlı. Lütfen farklı bir kullanıcı adı seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    baglanti.Close();
                    return;
                }

                // 2. Kayıt işlemi
                SqlCommand komut = new SqlCommand(
                    "INSERT INTO KayitOl (kullaniciAdi, eposta, sifre) VALUES (@kullaniciAdi, @eposta, @sifre)", baglanti);

                komut.Parameters.AddWithValue("@kullaniciAdi", txtKadi.Text.Trim());
                komut.Parameters.AddWithValue("@eposta", txtPosta.Text.Trim());
                komut.Parameters.AddWithValue("@sifre", txtSifre.Text);

                if (komut.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Kayıt başarıyla yapıldı.");
                    Form1 frm1 = new Form1();
                    frm1.Show();
                    this.Hide();
                }

                baglanti.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void giris_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            // Admin girişi işaretli değilse direkt Form1'e yönlendir:
            if (!chkAdminGiris.Checked)
            {
                MessageBox.Show("Kullanıcı giriş ekranına yönlendiriliyorsunuz.");
                Form1 frm1 = new Form1();
                frm1.Show();
                this.Hide();
                return;
            }
            string kullaniciAdi = txtKadi.Text.Trim();
            string sifre = txtSifre.Text.Trim();

            if (chkAdminGiris.Checked) // Eğer "Admin Girişi" seçiliyse
            {
                string sql = "SELECT COUNT(*) FROM Adminler WHERE adminKadi = @kullaniciAdi AND adminSifre = @sifre";
                SqlCommand cmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                DatabaseHelper.BaglantiAc();
                int sonuc = (int)cmd.ExecuteScalar();
                DatabaseHelper.BaglantiKapat();

                if (sonuc > 0)
                {
                    MessageBox.Show("Admin girişi başarılı!");
                    AdminPanel adminPanel = new AdminPanel();
                    adminPanel.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçersiz Admin bilgisi!");
                }
            }
            else // Normal kullanıcı girişi
            {
                string sql = "SELECT COUNT(*) FROM KayitOl WHERE kullaniciAdi=@kullaniciAdi AND sifre=@sifre";
                SqlCommand cmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
                cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sifre", sifre);

                DatabaseHelper.BaglantiAc();
                int sonuc = (int)cmd.ExecuteScalar();
                DatabaseHelper.BaglantiKapat();

                if (sonuc > 0)
                {
                    MessageBox.Show("Kullanıcı girişi başarılı!");
                    // Kullanıcı anasayfasına yönlendirme:
                    giris AdminPanel = new giris();
                    AdminPanel.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Geçersiz kullanıcı bilgisi!");
                }
            }
        }

        private void linkSifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifremiUnuttum sifreForm = new SifremiUnuttum();
            sifreForm.ShowDialog();
        }

        private void chkSifreGoster_CheckedChanged(object sender, EventArgs e)
        {
            txtSifre.PasswordChar = chkSifreGoster.Checked ? '\0' : '*';
        }

        private void chkAdminGiris_CheckedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
