namespace _181120045_SENA_KANİK_ENM201PROJE
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label3 = new System.Windows.Forms.Label();
            this.label_uyarı = new System.Windows.Forms.Label();
            this.btn_giriş = new System.Windows.Forms.Button();
            this.radio_yeniKullanıcı = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_sifre = new System.Windows.Forms.TextBox();
            this.txt_kullanıcıAdı = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Image = ((System.Drawing.Image)(resources.GetObject("label3.Image")));
            this.label3.Location = new System.Drawing.Point(76, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(648, 115);
            this.label3.TabIndex = 15;
            // 
            // label_uyarı
            // 
            this.label_uyarı.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_uyarı.ForeColor = System.Drawing.Color.Aqua;
            this.label_uyarı.Location = new System.Drawing.Point(143, 305);
            this.label_uyarı.Name = "label_uyarı";
            this.label_uyarı.Size = new System.Drawing.Size(498, 23);
            this.label_uyarı.TabIndex = 14;
            this.label_uyarı.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_giriş
            // 
            this.btn_giriş.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btn_giriş.Font = new System.Drawing.Font("Microsoft YaHei", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_giriş.ForeColor = System.Drawing.Color.White;
            this.btn_giriş.Location = new System.Drawing.Point(323, 340);
            this.btn_giriş.Name = "btn_giriş";
            this.btn_giriş.Size = new System.Drawing.Size(271, 35);
            this.btn_giriş.TabIndex = 13;
            this.btn_giriş.Text = "GİRİŞ YAP";
            this.btn_giriş.UseVisualStyleBackColor = false;
            this.btn_giriş.Click += new System.EventHandler(this.btn_giriş_Click);
            // 
            // radio_yeniKullanıcı
            // 
            this.radio_yeniKullanıcı.Font = new System.Drawing.Font("Microsoft YaHei Light", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radio_yeniKullanıcı.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.radio_yeniKullanıcı.Location = new System.Drawing.Point(323, 398);
            this.radio_yeniKullanıcı.Name = "radio_yeniKullanıcı";
            this.radio_yeniKullanıcı.Size = new System.Drawing.Size(271, 24);
            this.radio_yeniKullanıcı.TabIndex = 12;
            this.radio_yeniKullanıcı.TabStop = true;
            this.radio_yeniKullanıcı.Text = "YENİ KULLANICI OLUŞTUR.";
            this.radio_yeniKullanıcı.UseVisualStyleBackColor = true;
            this.radio_yeniKullanıcı.CheckedChanged += new System.EventHandler(this.radio_yeniKullanıcı_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Location = new System.Drawing.Point(110, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "KULLANICI ADI:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_sifre
            // 
            this.txt_sifre.BackColor = System.Drawing.Color.LightGray;
            this.txt_sifre.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_sifre.Location = new System.Drawing.Point(323, 263);
            this.txt_sifre.Multiline = true;
            this.txt_sifre.Name = "txt_sifre";
            this.txt_sifre.Size = new System.Drawing.Size(271, 28);
            this.txt_sifre.TabIndex = 8;
            this.txt_sifre.UseSystemPasswordChar = true;
            // 
            // txt_kullanıcıAdı
            // 
            this.txt_kullanıcıAdı.BackColor = System.Drawing.Color.LightGray;
            this.txt_kullanıcıAdı.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_kullanıcıAdı.Location = new System.Drawing.Point(323, 184);
            this.txt_kullanıcıAdı.Multiline = true;
            this.txt_kullanıcıAdı.Name = "txt_kullanıcıAdı";
            this.txt_kullanıcıAdı.Size = new System.Drawing.Size(271, 28);
            this.txt_kullanıcıAdı.TabIndex = 9;
            this.txt_kullanıcıAdı.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_kullanıcıAdı.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Location = new System.Drawing.Point(184, 263);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "ŞİFRE:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_uyarı);
            this.Controls.Add(this.btn_giriş);
            this.Controls.Add(this.radio_yeniKullanıcı);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_sifre);
            this.Controls.Add(this.txt_kullanıcıAdı);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HOŞGELDİNİZ|| GİRİŞ YAP";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_uyarı;
        private System.Windows.Forms.Button btn_giriş;
        private System.Windows.Forms.RadioButton radio_yeniKullanıcı;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_sifre;
        private System.Windows.Forms.TextBox txt_kullanıcıAdı;
        private System.Windows.Forms.Label label2;
    }
}

