
namespace saglikli_Beslenme_Proje
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listBoxYenmeli = new System.Windows.Forms.ListBox();
            this.lblHastalikBilgi = new System.Windows.Forms.Label();
            this.lblTercih = new System.Windows.Forms.Label();
            this.lblYenmemeli = new System.Windows.Forms.Label();
            this.lblYenmeli = new System.Windows.Forms.Label();
            this.listBoxYenmemeli = new System.Windows.Forms.ListBox();
            this.btnPdfAl = new System.Windows.Forms.Button();
            this.btnCikis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBoxYenmeli
            // 
            this.listBoxYenmeli.FormattingEnabled = true;
            this.listBoxYenmeli.ItemHeight = 25;
            this.listBoxYenmeli.Location = new System.Drawing.Point(36, 213);
            this.listBoxYenmeli.Name = "listBoxYenmeli";
            this.listBoxYenmeli.Size = new System.Drawing.Size(379, 304);
            this.listBoxYenmeli.TabIndex = 3;
            this.listBoxYenmeli.SelectedIndexChanged += new System.EventHandler(this.listBoxYenmeli_SelectedIndexChanged);
            // 
            // lblHastalikBilgi
            // 
            this.lblHastalikBilgi.AutoSize = true;
            this.lblHastalikBilgi.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblHastalikBilgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblHastalikBilgi.Location = new System.Drawing.Point(97, 42);
            this.lblHastalikBilgi.Name = "lblHastalikBilgi";
            this.lblHastalikBilgi.Size = new System.Drawing.Size(0, 25);
            this.lblHastalikBilgi.TabIndex = 5;
            // 
            // lblTercih
            // 
            this.lblTercih.AutoSize = true;
            this.lblTercih.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.lblTercih.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblTercih.Location = new System.Drawing.Point(97, 118);
            this.lblTercih.Name = "lblTercih";
            this.lblTercih.Size = new System.Drawing.Size(0, 25);
            this.lblTercih.TabIndex = 7;
            // 
            // lblYenmemeli
            // 
            this.lblYenmemeli.AutoSize = true;
            this.lblYenmemeli.BackColor = System.Drawing.Color.Red;
            this.lblYenmemeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYenmemeli.Location = new System.Drawing.Point(561, 170);
            this.lblYenmemeli.Name = "lblYenmemeli";
            this.lblYenmemeli.Size = new System.Drawing.Size(308, 26);
            this.lblYenmemeli.TabIndex = 2;
            this.lblYenmemeli.Text = "YENİLEMEYEN BESİNLER";
            // 
            // lblYenmeli
            // 
            this.lblYenmeli.AutoSize = true;
            this.lblYenmeli.BackColor = System.Drawing.Color.Chartreuse;
            this.lblYenmeli.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblYenmeli.Location = new System.Drawing.Point(71, 170);
            this.lblYenmeli.Name = "lblYenmeli";
            this.lblYenmeli.Size = new System.Drawing.Size(283, 26);
            this.lblYenmeli.TabIndex = 1;
            this.lblYenmeli.Text = "YENİLEBİLİR BESİNLER";
            this.lblYenmeli.Click += new System.EventHandler(this.lblYenmeli_Click);
            // 
            // listBoxYenmemeli
            // 
            this.listBoxYenmemeli.FormattingEnabled = true;
            this.listBoxYenmemeli.ItemHeight = 25;
            this.listBoxYenmemeli.Location = new System.Drawing.Point(540, 213);
            this.listBoxYenmemeli.Name = "listBoxYenmemeli";
            this.listBoxYenmemeli.Size = new System.Drawing.Size(379, 304);
            this.listBoxYenmemeli.TabIndex = 8;
            // 
            // btnPdfAl
            // 
            this.btnPdfAl.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnPdfAl.Location = new System.Drawing.Point(540, 545);
            this.btnPdfAl.Name = "btnPdfAl";
            this.btnPdfAl.Size = new System.Drawing.Size(183, 37);
            this.btnPdfAl.TabIndex = 9;
            this.btnPdfAl.Text = "PDF Al";
            this.btnPdfAl.UseVisualStyleBackColor = false;
            this.btnPdfAl.Click += new System.EventHandler(this.btnPdfAl_Click);
            // 
            // btnCikis
            // 
            this.btnCikis.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnCikis.Location = new System.Drawing.Point(736, 545);
            this.btnCikis.Name = "btnCikis";
            this.btnCikis.Size = new System.Drawing.Size(183, 37);
            this.btnCikis.TabIndex = 10;
            this.btnCikis.Text = "ÇIKIŞ";
            this.btnCikis.UseVisualStyleBackColor = false;
            this.btnCikis.Click += new System.EventHandler(this.btnCikis_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(967, 606);
            this.Controls.Add(this.btnCikis);
            this.Controls.Add(this.btnPdfAl);
            this.Controls.Add(this.listBoxYenmemeli);
            this.Controls.Add(this.lblTercih);
            this.Controls.Add(this.lblHastalikBilgi);
            this.Controls.Add(this.listBoxYenmeli);
            this.Controls.Add(this.lblYenmemeli);
            this.Controls.Add(this.lblYenmeli);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBoxYenmeli;
        private System.Windows.Forms.Label lblHastalikBilgi;
        private System.Windows.Forms.Label lblTercih;
        private System.Windows.Forms.Label lblYenmemeli;
        private System.Windows.Forms.Label lblYenmeli;
        private System.Windows.Forms.ListBox listBoxYenmemeli;
        private System.Windows.Forms.Button btnPdfAl;
        private System.Windows.Forms.Button btnCikis;
    }
}