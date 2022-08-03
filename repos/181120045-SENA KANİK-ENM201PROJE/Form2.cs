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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-FG7BEHJK;Initial Catalog=ProjeDeneme;Integrated Security=True");

        private void btn_KullanıcıOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                Kullanıcıbilgileri kb = new Kullanıcıbilgileri();
                kb.kullanıcıAdı = txt_kullanıcıAdı.Text;
                kb.sifre = Convert.ToInt32(txt_sifre.Text);
                kb.departman = txt_departman.Text;
                kb.telefonNo = txt_telefonNo.Text;
                if (checkBox_robotDegilim.Checked && label_robot.Text == txt_robotKontrol.Text)
                {
                    SqlCommand kmt = new SqlCommand("INSERT INTO KullanıcıBilgileri(KullanıcıAdı,Sifre,Departman,TelefonNo) VALUES (@KullanıcıAdı,@Sifre,@Departman,@TelefonNo)", bağlantı);
                    kmt.Parameters.AddWithValue("@KullanıcıAdı", kb.kullanıcıAdı);
                    kmt.Parameters.AddWithValue("@Sifre", kb.sifre);
                    kmt.Parameters.AddWithValue("@Departman", kb.departman);
                    kmt.Parameters.AddWithValue("@TelefonNo", kb.telefonNo);

                    bağlantı.Open();
                    kmt.ExecuteNonQuery();
                    bağlantı.Close();

                    MessageBox.Show("yeni kullanıcı oluşturuldu.");
                    this.Close();


                }
                else
                {
                    MessageBox.Show("GİRDİĞİNİZ SAYIYI KONTROL EDİNİZ.[KULLANICI OLUŞTURULAMADI!!]");
                    foreach (Control Items in this.Controls)
                    {
                        if (Items is TextBox)
                        {
                            Items.Text = " ";
                            checkBox_robotDegilim.Checked = false;
                        }
                    }
                    Random rndm = new Random();
                    int RobotKontrol = rndm.Next(100000, 150000);
                    label_robot.Text = RobotKontrol.ToString();
                }
            }
            catch (Exception)
            {

            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Random rndm = new Random();
            int RobotKontrol = rndm.Next(10000, 150000);
            label_robot.Text = RobotKontrol.ToString();

        }
    }
}
