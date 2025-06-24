using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net.Http;


namespace saglikli_Beslenme_Proje
{
    public partial class Form1 : Form
    {
        private string cinsiyet;
        public Form1()
        {
            InitializeComponent();
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void btnDevam_Click(object sender, EventArgs e)
        {
            if (!(radErkek.Checked || radKadin.Checked))
            {
                MessageBox.Show("Lütfen cinsiyet seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                cinsiyet = radErkek.Checked ? "Erkek" : "Kadın";

                kullaniciPaneli frm1 = new kullaniciPaneli();
                frm1.Cinsiyet = cinsiyet; // Cinsiyeti diğer forma aktar
                frm1.Show();
                this.Close();
                frm1.Show();
                this.Close(); // Bellekten temizlemek için
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            radErkek.Checked = false;
            radKadin.Checked = false;
            btnDevam.Enabled = false;
        }

        private void radErkek_CheckedChanged(object sender, EventArgs e)
        {
            btnDevam.Enabled = radErkek.Checked || radKadin.Checked;
        }

        private void radKadin_CheckedChanged(object sender, EventArgs e)
        {
            btnDevam.Enabled = radErkek.Checked || radKadin.Checked;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
 }
    

