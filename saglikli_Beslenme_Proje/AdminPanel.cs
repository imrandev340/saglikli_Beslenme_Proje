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
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            KullaniciListele();
        }
        private void KullaniciListele()
        {
            try
            {
                string sql = "SELECT KullaniciID, kullaniciAdi, eposta FROM KayitOl";
                SqlDataAdapter da = new SqlDataAdapter(sql, DatabaseHelper.Baglanti);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int seciliID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["KullaniciID"].Value);

                string sql = "DELETE FROM KayitOl WHERE KullaniciID = @id";
                SqlCommand cmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
                cmd.Parameters.AddWithValue("@id", seciliID);

                try
                {
                    DatabaseHelper.BaglantiAc();
                    int sonuc = cmd.ExecuteNonQuery();
                    if (sonuc > 0)
                    {
                        MessageBox.Show("Kullanıcı silindi.");
                        KullaniciListele();
                    }
                    else
                        MessageBox.Show("Silme başarısız.");
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
            else
            {
                MessageBox.Show("Lütfen silmek için bir satır seçin.");
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKadi.Text) ||
       string.IsNullOrWhiteSpace(txtSifre.Text) ||
       string.IsNullOrWhiteSpace(txtAdminPosta.Text))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.");
                return;
            }

            string sql = "INSERT INTO Adminler (adminKadi, adminSifre, adminPosta) VALUES (@kadi, @sifre, @posta)";
            SqlCommand cmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
            cmd.Parameters.AddWithValue("@AdminKadi", txtKadi.Text.Trim());
            cmd.Parameters.AddWithValue("@AdminSifre", txtSifre.Text.Trim());
            cmd.Parameters.AddWithValue("@AdminPosta", txtAdminPosta.Text.Trim());

            try
            {
                DatabaseHelper.BaglantiAc();
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    MessageBox.Show("Yeni admin eklendi.");
                    KullaniciListele();
                }
                else
                {
                    MessageBox.Show("Ekleme başarısız.");
                }
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

        private void btnSifreDegistir_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKadi.Text) || string.IsNullOrWhiteSpace(txtSifre.Text))
            {
                MessageBox.Show("Lütfen admin adını ve yeni şifreyi girin!");
                return;
            }

            string sql = "UPDATE Adminler SET adminSifre = @yeniSifre WHERE adminKadi = @kadi";
            SqlCommand cmd = new SqlCommand(sql, DatabaseHelper.Baglanti);
            cmd.Parameters.AddWithValue("@yeniSifre", txtSifre.Text.Trim());
            cmd.Parameters.AddWithValue("@kadi", txtKadi.Text.Trim());

            try
            {
                DatabaseHelper.BaglantiAc();
                int sonuc = cmd.ExecuteNonQuery();
                if (sonuc > 0)
                {
                    MessageBox.Show("Şifre başarıyla güncellendi.");
                    KullaniciListele();
                }
                else
                {
                    MessageBox.Show("Şifre değiştirme başarısız.");
                }
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

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtKadi.Clear();
            txtSifre.Clear();
        }
    }
}
