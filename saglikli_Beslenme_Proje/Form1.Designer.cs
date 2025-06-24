
namespace saglikli_Beslenme_Proje
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.radErkek = new System.Windows.Forms.RadioButton();
            this.radKadin = new System.Windows.Forms.RadioButton();
            this.btnDevam = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(174, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(419, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "CİNSİYETİNİZİ SEÇİNİZ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radErkek
            // 
            this.radErkek.AutoSize = true;
            this.radErkek.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radErkek.Location = new System.Drawing.Point(109, 574);
            this.radErkek.Name = "radErkek";
            this.radErkek.Size = new System.Drawing.Size(125, 33);
            this.radErkek.TabIndex = 4;
            this.radErkek.TabStop = true;
            this.radErkek.Text = "ERKEK";
            this.radErkek.UseVisualStyleBackColor = true;
            this.radErkek.CheckedChanged += new System.EventHandler(this.radErkek_CheckedChanged);
            // 
            // radKadin
            // 
            this.radKadin.AutoSize = true;
            this.radKadin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radKadin.Location = new System.Drawing.Point(475, 574);
            this.radKadin.Name = "radKadin";
            this.radKadin.Size = new System.Drawing.Size(115, 33);
            this.radKadin.TabIndex = 5;
            this.radKadin.TabStop = true;
            this.radKadin.Text = "KADIN";
            this.radKadin.UseVisualStyleBackColor = true;
            this.radKadin.CheckedChanged += new System.EventHandler(this.radKadin_CheckedChanged);
            // 
            // btnDevam
            // 
            this.btnDevam.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnDevam.Enabled = false;
            this.btnDevam.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnDevam.Location = new System.Drawing.Point(225, 624);
            this.btnDevam.Name = "btnDevam";
            this.btnDevam.Size = new System.Drawing.Size(263, 43);
            this.btnDevam.TabIndex = 6;
            this.btnDevam.Text = "DEVAM";
            this.btnDevam.UseVisualStyleBackColor = false;
            this.btnDevam.Click += new System.EventHandler(this.btnDevam_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::saglikli_Beslenme_Proje.Properties.Resources.erkekk;
            this.pictureBox2.Location = new System.Drawing.Point(27, 72);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(290, 471);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::saglikli_Beslenme_Proje.Properties.Resources.kadiin;
            this.pictureBox1.Location = new System.Drawing.Point(374, 109);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 459);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(707, 677);
            this.Controls.Add(this.btnDevam);
            this.Controls.Add(this.radKadin);
            this.Controls.Add(this.radErkek);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.RadioButton radErkek;
        private System.Windows.Forms.RadioButton radKadin;
        private System.Windows.Forms.Button btnDevam;
    }
}

