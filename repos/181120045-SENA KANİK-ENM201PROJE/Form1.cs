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

namespace _181120045_SENA_KANİK_ENM201PROJE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-FG7BEHJK;Initial Catalog=ProjeDeneme;Integrated Security=True");
        

        private void btn_giriş_Click(object sender, EventArgs e)
        {
            Kullanıcıbilgileri kb = new Kullanıcıbilgileri();
            kb.kullanıcıAdı = txt_kullanıcıAdı.Text;
            kb.sifre = Convert.ToInt32(txt_sifre.Text);
            SqlCommand kmt = new SqlCommand();
            SqlDataReader dr;
            bağlantı.Open();
            kmt.CommandText = "SELECT*FROM KullanıcıBilgileri WHERE KullanıcıAdı='" +kb.kullanıcıAdı + "'AND Sifre='" + kb.sifre + "'";
            kmt.Connection = bağlantı;
            dr = kmt.ExecuteReader();
            if (dr.Read())
            {

                frm_VeriOkuma frm = new frm_VeriOkuma();
                frm.Show();
                this.Hide();


            }
            else
                label_uyarı.Visible = true;
            bağlantı.Close();


        }

       

       

        private void Form1_Load(object sender, EventArgs e)
        {
            MesajYazdırma yazdır = new LabelYazdır();

            label_uyarı.Text = yazdır.yazdır();
            label_uyarı.Visible = false;
        }

        private void radio_yeniKullanıcı_CheckedChanged(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
            radio_yeniKullanıcı.Checked = false;

        }
    }
}
