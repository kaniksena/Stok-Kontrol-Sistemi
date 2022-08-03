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
    public partial class frm_VeriOkuma : Form
    {
        public frm_VeriOkuma()
        {
            InitializeComponent();
        }

        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-FG7BEHJK;Initial Catalog=ProjeDeneme;Integrated Security=True");

        private void frm_VeriOkuma_Load(object sender, EventArgs e)
        {
            try
            {

                SqlCommand kmt = new SqlCommand();

                kmt.CommandText = "SELECT*FROM DepoBilgileri";
                kmt.Connection = bağlantı;

                SqlDataAdapter adaptör = new SqlDataAdapter(kmt);
                DataTable table = new DataTable();

                adaptör.Fill(table);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    listView2.Items.Add(table.Rows[i]["ÜrünBarkodu"].ToString());
                    listView2.Items[i].SubItems.Add(table.Rows[i]["ÜrünAdı"].ToString());
                    listView2.Items[i].SubItems.Add(table.Rows[i]["BirimFiyatı"].ToString());
                    listView2.Items[i].SubItems.Add(table.Rows[i]["ÜrünMiktarı"].ToString());
                    listView2.Items[i].SubItems.Add(table.Rows[i]["GirişYapanKişi"].ToString());
                   
                   

                }
                ListView listView = this.listView2;
                int j = 0;
                Color shaded = Color.FromArgb(240, 240, 240);
                foreach (ListViewItem item in listView.Items)
                {
                    if (j++ % 2 == 1)
                    {
                        item.BackColor = Color.LightBlue;
                        item.UseItemStyleForSubItems = true;
                    }
                }

                SqlCommand kmt1 = new SqlCommand("SELECT*FROM KullanıcıBilgileri", bağlantı);
                bağlantı.Open();
                SqlDataReader dr = kmt1.ExecuteReader();
                while (dr.Read())
                {
                    Class1.KullanıcıAdı.Add(dr["KullanıcıAdı"].ToString());




                }
                bağlantı.Close();
                for (int i = 0; i < Class1.KullanıcıAdı.Count; i++)
                    comboBox1.Items.Add(Class1.KullanıcıAdı[i]);
            }
            catch (Exception)
            {

            }

           
        }

        private void btn_ürünekle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kmt = new SqlCommand("INSERT INTO DepoBilgileri(ÜrünBarkodu,ÜrünAdı,BirimFiyatı,ÜrünMiktarı,GirişYapanKişi) VALUES (@ÜrünBarkodu,@ÜrünAdı,@BirimFiyatı,@ÜrünMiktarı,@GirişYapanKişi)", bağlantı);



                kmt.Parameters.AddWithValue("@ÜrünBarkodu", Convert.ToInt32(txt_barkod.Text));
                kmt.Parameters.AddWithValue("@ÜrünAdı", txt_adı.Text);
                kmt.Parameters.AddWithValue("@BirimFiyatı", txt_birimf.Text);
                kmt.Parameters.AddWithValue("@ÜrünMiktarı", Convert.ToInt32(txt_stokm.Text));
                kmt.Parameters.AddWithValue("@GirişYapanKişi", comboBox1.SelectedItem.ToString());

                bağlantı.Open();
                kmt.ExecuteNonQuery();
                bağlantı.Close();
                MesajYazdırma yazdır = new MessageBoxYazdır();
                MessageBox.Show(" " + yazdır.yazdır());
            }
            catch (Exception)
            {

            }

        }

        private void btn_ürüngün_Click(object sender, EventArgs e)
        {
            try
            {
                DepoBilgileri dp = new DepoBilgileri();
                dp.ürünbarkodu = Convert.ToInt32(txt_barkod.Text);
                dp.ürünAdı = txt_adı.Text;
                dp.birimFiyat = Convert.ToInt32(txt_birimf.Text);
                dp.kullanıcıAdı = comboBox1.SelectedItem.ToString();
                dp.ürünMiktarı = StokMiktarı + Convert.ToInt32(txt_stokm.Text);

                SqlCommand kmt = new SqlCommand("UPDATE DepoBilgileri SET ÜrünBarkodu=@ÜrünBarkodu , ÜrünAdı=@ÜrünAdı , BirimFiyatı=@BirimFiyatı , ÜrünMiktarı=@ÜrünMiktarı, GirişYapanKişi=@GirişYapanKişi WHERE ÜrünBarkodu=@ÜrünBarkodu", bağlantı);

                kmt.Parameters.AddWithValue("@ÜrünBarkodu", dp.ürünbarkodu);
                kmt.Parameters.AddWithValue("@ÜrünAdı", dp.ürünAdı);
                kmt.Parameters.AddWithValue("@BirimFiyatı", dp.birimFiyat);

                kmt.Parameters.AddWithValue("@GirişYapanKişi", dp.kullanıcıAdı);
                kmt.Parameters.AddWithValue("@ÜrünMiktarı", dp.ürünMiktarı);

                bağlantı.Open();
                kmt.ExecuteNonQuery();
                bağlantı.Close();


                MesajYazdırma yazdır = new MessageBoxYazdır();
                MessageBox.Show(" " + yazdır.yazdır());
               
                
            }
            catch (Exception)
            {

            }

        }

        private void btm_ürünlis_Click(object sender, EventArgs e)
        {
            try
            {
                DepoBilgileri dp = new DepoBilgileri();
                dp.ürünbarkodu = Convert.ToInt32(txt_barkod.Text);
                dp.ürünAdı = txt_adı.Text;
                dp.birimFiyat = Convert.ToInt32(txt_birimf.Text);
                dp.ürünMiktarı = Convert.ToInt32(txt_stokm.Text);

                SqlCommand kmt1 = new SqlCommand("DELETE DepoBilgileri WHERE ÜrünBarkodu=@ÜrünBarkodu AND ÜrünAdı=@ÜrünAdı AND BirimFiyatı=@BirimFiyatı ", bağlantı);

                kmt1.Parameters.AddWithValue("@ÜrünBarkodu", dp.ürünbarkodu);
                kmt1.Parameters.AddWithValue("@ÜrünAdı", dp.ürünAdı);
                kmt1.Parameters.AddWithValue("@BirimFiyatı", dp.birimFiyat);
                

                bağlantı.Open();
                kmt1.ExecuteNonQuery();
                bağlantı.Close();
            }
            catch (Exception)
            {

            }

        }


      
        int StokMiktarı;
        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
               
                txt_barkod.Text = listView2.SelectedItems[0].Text;
                txt_adı.Text = listView2.SelectedItems[0].SubItems[1].Text;
                txt_birimf.Text =listView2.SelectedItems[0].SubItems[2].Text;
                comboBox1.Text = listView2.SelectedItems[0].SubItems[4].Text;
              
                
                StokMiktarı = Convert.ToInt32(listView2.SelectedItems[0].SubItems[3].Text);
               
            }
            catch (Exception)
            {

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 veri = new Form1();
            veri.Show();
            this.Close();

        }

        private void btn_Satışlis_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kmt = new SqlCommand();

                kmt.CommandText = "SELECT*FROM SatışBilgileri";
                kmt.Connection = bağlantı;

                SqlDataAdapter adaptör = new SqlDataAdapter(kmt);
                DataTable table = new DataTable();

                adaptör.Fill(table);
                
                for(int i =0;i< table.Rows.Count;i++)
                {
                    listView1.Items.Add(table.Rows[i]["ÜrünBarkodı"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["ÜrünAdı"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["BirimFiyatı"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["ÜrünMiktarı"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["FirmaAdı"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["FaturaAdresi"].ToString());
                    listView1.Items[i].SubItems.Add(table.Rows[i]["SatışTutarı"].ToString());


                }
                ListView listView = this.listView1;
                int j = 0;
                Color shaded = Color.FromArgb(240, 240, 240);
                foreach (ListViewItem item in listView.Items)
                {
                    if (j++ % 2 == 1)
                    {
                        item.BackColor = Color.LightBlue;
                            item.UseItemStyleForSubItems = true;
                    }
                }
            }
            catch (Exception)
            {

            }

        }
        int iadeMik;

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txt_ÜrünBarkdıs.Text = listView1.SelectedItems[0].Text;
                txt_ürünAdıs.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_BirimFiyats.Text = listView1.SelectedItems[0].SubItems[2].Text;
                txt_satışMiks.Text = listView1.SelectedItems[0].SubItems[3].Text;
                txt_FirmaAdıs.Text = listView1.SelectedItems[0].SubItems[4].Text;
                txt_FaturaAdresis.Text = listView1.SelectedItems[0].SubItems[5].Text;
                txt_SatışTutarıs.Text = listView1.SelectedItems[0].SubItems[6].Text;
                iadeMik = Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);



            }
            catch (Exception)
            {

            }

        }

        private void btn_MüşteriList_Click(object sender, EventArgs e)
        {

            SqlCommand kmt = new SqlCommand("SELECT*FROM MüşteriBilgileri", bağlantı);
            bağlantı.Open();
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Class1.FirmaAdı.Add(dr["FirmaAdı"].ToString());




            }

            bağlantı.Close();
            for (int i = 0; i < Class1.FirmaAdı.Count; i++)
                listBox1.Items.Add(Class1.FirmaAdı[i]);

        }

        private void btn_ürünAdlarınıLis_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("SELECT*FROM DepoBilgileri", bağlantı);
            bağlantı.Open();
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Class1.ÜrünAdı.Add(dr["ÜrünAdı"].ToString());
                




            }

            bağlantı.Close();
            for (int i = 0; i < Class1.ÜrünAdı.Count; i++)
                listBox2.Items.Add(Class1.ÜrünAdı[i]);

        }

        private void btn_satışTutar_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("SELECT*FROM SatışBilgileri", bağlantı);
            bağlantı.Open();
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Class1.SatışTutarı.Add(Convert.ToInt32(dr["SatışTutarı"]));





            }

            bağlantı.Close();
            for (int i = 0; i < Class1.SatışTutarı.Count; i++)
                listBox3.Items.Add(Class1.SatışTutarı[i]);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SatışBilgileri sb = new SatışBilgileri();
                SqlCommand kmt = new SqlCommand("DELETE FROM SatışBilgileri WHERE ÜrünBarkodı=@ÜrünBarkodı AND FirmaAdı=@FirmaAdı AND ÜrünMiktarı=@ÜrünMiktarı", bağlantı);


                kmt.Parameters.AddWithValue("@ÜrünBarkodı", Convert.ToInt32(txt_ÜrünBarkdıs.Text));
                kmt.Parameters.AddWithValue("@FirmaAdı", txt_FirmaAdıs.Text);
                kmt.Parameters.AddWithValue("@ÜrünMiktarı", Convert.ToInt32(txt_satışMiks.Text));
                bağlantı.Open();
                kmt.ExecuteNonQuery();
                bağlantı.Close();
               
                MessageBox.Show("iade talebi alınmıştır.");
            }
            catch (Exception)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            FrmSatışEkranı satış = new FrmSatışEkranı();
             
            satış.Show();
            this.Hide();
        }

        private void listView3_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                textBox1.Text = listView3.SelectedItems[0].Text;
                textBox7.Text = listView3.SelectedItems[0].SubItems[1].Text;
                textBox2.Text= listView3.SelectedItems[0].SubItems[2].Text;
                textBox3.Text = listView3.SelectedItems[0].SubItems[3].Text;
                textBox4.Text = listView3.SelectedItems[0].SubItems[4].Text;
                textBox5.Text = listView3.SelectedItems[0].SubItems[5].Text;
                




            }
            catch (Exception)
            {

            }
        }

        private void btn_MüşLis_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kmt = new SqlCommand();
                kmt.CommandText = "SELECT*FROM MüşteriBilgileri";
                kmt.Connection = bağlantı;

                SqlDataAdapter adaptör = new SqlDataAdapter(kmt);
                DataTable table = new DataTable();
                adaptör.Fill(table);
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    listView3.Items.Add(table.Rows[i]["FirmaAdı"].ToString());
                    listView3.Items[i].SubItems.Add(table.Rows[i]["FaturaAdresi"].ToString());
                    listView3.Items[i].SubItems.Add(table.Rows[i]["FirmaVergiNo"].ToString());
                    listView3.Items[i].SubItems.Add(table.Rows[i]["FirmaVergiDairesi"].ToString());
                    listView3.Items[i].SubItems.Add(table.Rows[i]["FirmaTelNo"].ToString());
                    listView3.Items[i].SubItems.Add(table.Rows[i]["FirmaEposta"].ToString());
                }
                ListView listView = this.listView3;
                int j = 0;
                Color shaded = Color.FromArgb(240, 240, 240);
                foreach (ListViewItem item in listView.Items)
                {
                    if (j++ % 2 == 1)
                    {
                        item.BackColor = Color.LightBlue;
                        item.UseItemStyleForSubItems = true;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_MGüncelle_Click(object sender, EventArgs e)
        {
            try
            {
                MüşteriBilgileri mb;
                mb.Firmadı = textBox1.Text;
                mb.FaturaAdresi = textBox7.Text;
                mb.VergiNo = Convert.ToInt32(textBox2.Text);
                mb.VergiDairesi = textBox3.Text;
                mb.TelNo = Convert.ToInt32(textBox4.Text);
                mb.Eposta = textBox5.Text;
                SqlCommand kmt = new SqlCommand("UPDATE MüşteriBilgileri SET  FirmaAdı=@FirmaAdı , FaturaAdresi=@FaturaAdresi , FirmaVergiNo=@FirmaVergiNo ,FirmaTelNo=@FirmaTelNo, FirmaEposta=@FirmaEposta WHERE FirmaVergiNo=@FirmaVergiNo", bağlantı);

                kmt.Parameters.AddWithValue("@FirmaAdı", mb.Firmadı);
                kmt.Parameters.AddWithValue("@FaturaAdresi", mb.FaturaAdresi);
                kmt.Parameters.AddWithValue("@FirmaVergiNo", mb.VergiNo);

                kmt.Parameters.AddWithValue("FirmaVergiDairesi", mb.VergiDairesi);
                kmt.Parameters.AddWithValue("@FirmaTelNo", mb.TelNo);
                kmt.Parameters.AddWithValue("@FirmaEposta", mb.Eposta);


                bağlantı.Open();
                kmt.ExecuteNonQuery();
                bağlantı.Close();
                MesajYazdırma yazdır = new MessageBoxYazdır();
                MessageBox.Show(" " + yazdır.yazdır());
            }
            catch (Exception)
            {
                MessageBox.Show("LÜTFEN TABLODAN FİRMA ADI SEÇİNİZ");
            }

        }

        private void btn_müşteriSil_Click(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("DELETE MüşteriBilgileri  WHERE FirmaVergiNo=@FirmaVergiNo", bağlantı);

           
            kmt.Parameters.AddWithValue("@FirmaVergiNo", Convert.ToInt32(textBox2.Text));



            bağlantı.Open();
            kmt.ExecuteNonQuery();
            bağlantı.Close();
        }

        private void btn_Mekle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand kmt = new SqlCommand("INSERT INTO MüşteriBilgileri(FirmaAdı , FaturaAdresi , FirmaVergiNo ,FirmaVergiDairesi,FirmaTelNo, FirmaEposta) VALUES(@FirmaAdı,@FaturaAdresi,@FirmaVergiNo,@FirmaVergiDairesi,@FirmaTelNo,@FirmaEposta)", bağlantı);

                kmt.Parameters.AddWithValue("@FirmaAdı", textBox1.Text);
                kmt.Parameters.AddWithValue("@FaturaAdresi", textBox7.Text);
                kmt.Parameters.AddWithValue("@FirmaVergiNo", Convert.ToInt32(textBox2.Text));
                kmt.Parameters.AddWithValue("FirmaVergiDairesi", textBox3.Text);
                kmt.Parameters.AddWithValue("@FirmaTelNo", Convert.ToInt32(textBox4.Text));
                kmt.Parameters.AddWithValue("@FirmaEposta", textBox5.Text);


                bağlantı.Open();
                kmt.ExecuteNonQuery();
                bağlantı.Close();
                MesajYazdırma yazdır = new MessageBoxYazdır();
                MessageBox.Show(" " + yazdır.yazdır());
            }
            catch (Exception)
            {

            }
        }
    }
}

