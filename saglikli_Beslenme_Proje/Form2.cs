using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using saglikli_Beslenme_Proje;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace saglikli_Beslenme_Proje
{

    public partial class Form2 : Form
    {

        public string SecilenHastalik { get; set; }
        public string SecilenTercih { get; set; }
        public Form2()
        {
            InitializeComponent();
            this.BackColor = Color.WhiteSmoke;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        
        private void Form2_Load(object sender, EventArgs e)
        {
            SecilenHastalik = SecilenHastalik?.Trim();
            SecilenTercih = SecilenTercih?.Trim();

            if (string.IsNullOrEmpty(SecilenHastalik) || string.IsNullOrEmpty(SecilenTercih))
            {
                MessageBox.Show("Hastalık veya beslenme tercihi seçilmemiş! Form kapatılıyor.");
                this.Close();
                return;
            }

            if (!BeslenmeSecim.Hastaliklar.ContainsKey(SecilenHastalik))
            {
                MessageBox.Show($"'{SecilenHastalik}' hastalığı sistemde bulunamadı. Form kapatılıyor.");
                this.Close();
                return;
            }

            lblHastalikBilgi.Text = $"Hastalık: {SecilenHastalik}";
            lblHastalikBilgi.ForeColor = Color.FromArgb(44, 62, 80);

            lblTercih.Text = $"Beslenme Tercihi: {SecilenTercih}";
            lblTercih.ForeColor = Color.FromArgb(44, 62, 80);

            Goster(SecilenHastalik, BeslenmeSecim.Hastaliklar[SecilenHastalik].YemesiGerekenler, BeslenmeSecim.Hastaliklar[SecilenHastalik].YememesiGerekenler);
        }
        public void Goster(string hastalikAdi, Dictionary<string, List<Besin>> yenmesiGerekenlerDict, Dictionary<string, List<Besin>> yememesiGerekenlerDict)
        {
            this.Text = $"{hastalikAdi} İçin Beslenme Önerileri";

            listBoxYenmeli.Items.Clear();
            listBoxYenmemeli.Items.Clear();

            listBoxYenmemeli.BackColor = Color.White;
            listBoxYenmemeli.BorderStyle = BorderStyle.FixedSingle;
        
            if (yenmesiGerekenlerDict.ContainsKey(SecilenTercih))
            {
                foreach (var besin in yenmesiGerekenlerDict[SecilenTercih])
                    listBoxYenmeli.Items.Add("✔ " + besin.Ad);
            }
            else
            {
                listBoxYenmeli.Items.Add($"Bu tercih ({SecilenTercih}) için yemesi gereken besin bulunamadı.");
            }

            if (yememesiGerekenlerDict.ContainsKey(SecilenTercih))
            {
                foreach (var besin in yememesiGerekenlerDict[SecilenTercih])
                    listBoxYenmemeli.Items.Add("✘ " + besin.Ad);
            }
            else
            {
                listBoxYenmemeli.Items.Add($"Bu tercih ({SecilenTercih}) için yememesi gereken besin bulunamadı.");
            }
        }

        private void lblYenmeli_Click(object sender, EventArgs e)
        {

        }

        private void listBoxYenmeli_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnPdfAl_Click(object sender, EventArgs e)
        {
            try
            {
                // PDF oluşturulacak yol
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\BeslenmeOnersi.pdf";

                // PDF dökümanı
                Document doc = new Document(PageSize.A4);
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();

                // Başlık
                Paragraph title = new Paragraph("Beslenme Önerileri Raporu\n\n")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(title);
                // Sağlık mesajı
                Paragraph mesaj = new Paragraph("Hiçbir şey sizin sağlığınızdan önemli değildir.\n\n")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                doc.Add(mesaj);


                // Hastalık ve Tercih
                doc.Add(new Paragraph($"Hastalık: {SecilenHastalik}"));
                doc.Add(new Paragraph($"Beslenme Tercihi: {SecilenTercih}\n"));

                // Yenmesi Gerekenler
                doc.Add(new Paragraph("Yenmesi Gerekenler:"));
                foreach (var item in listBoxYenmeli.Items)
                {
                    doc.Add(new Paragraph(item.ToString()));
                }

                // Boşluk
                doc.Add(new Paragraph("\n"));

                // Yenmemesi Gerekenler
                doc.Add(new Paragraph("Yenmemesi Gerekenler:"));
                foreach (var item in listBoxYenmemeli.Items)
                {
                    doc.Add(new Paragraph(item.ToString()));
                }

                doc.Close();

                MessageBox.Show("PDF başarıyla masaüstüne kaydedildi: BeslenmeOnersi.pdf");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF oluşturulurken hata: " + ex.Message);
            }
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            DialogResult sonuc = MessageBox.Show("Projeyi kapatmak istiyor musunuz?", "Çıkış Onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (sonuc == DialogResult.Yes)
            {
                Application.Exit(); 
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
    // Besin sınıfı
    public class Besin
    {
        public string Ad { get; set; }
        public Besin(string ad) => Ad = ad;
    }

    // Hastalik sınıfı
    public class Hastalik
    {
        public int HastalikID { get; set; }
        public string HastalikAdi { get; set; } // Veya Isim yerine bunu kullan
        public Dictionary<string, List<Besin>> YemesiGerekenler { get; set; } = new Dictionary<string, List<Besin>>();
        public Dictionary<string, List<Besin>> YememesiGerekenler { get; set; } = new Dictionary<string, List<Besin>>();
    }


    // Statik veri deposu
    public static class BeslenmeSecim
    {
        public static Dictionary<string, Hastalik> Hastaliklar = new Dictionary<string, Hastalik>();
    }
}



