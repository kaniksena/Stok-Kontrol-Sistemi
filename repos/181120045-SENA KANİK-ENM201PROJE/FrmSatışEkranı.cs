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
using System.Data.Sql;

namespace _181120045_SENA_KANİK_ENM201PROJE
{
    public partial class FrmSatışEkranı : Form
    {
        public FrmSatışEkranı()
        {
            InitializeComponent();
        }
        SqlConnection bağlantı = new SqlConnection("Data Source=LAPTOP-FG7BEHJK;Initial Catalog=ProjeDeneme;Integrated Security=True");
        int StokMiktarı;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                txt_BarkodSatış.Text = listView1.SelectedItems[0].Text;
                txt_AdıSatış.Text = listView1.SelectedItems[0].SubItems[1].Text;
                txt_BirimfiyatSatış.Text = listView1.SelectedItems[0].SubItems[2].Text;
                StokMiktarı = Convert.ToInt32(listView1.SelectedItems[0].SubItems[3].Text);

              

            }
            catch (Exception)
            {

            }

        }

        private void FrmSatışEkranı_Load(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand();
            kmt.CommandText = "SELECT*FROM DepoBilgileri";
            kmt.Connection = bağlantı;

            SqlDataAdapter adaptör = new SqlDataAdapter(kmt);
            DataTable table = new DataTable();

            adaptör.Fill(table);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                listView1.Items.Add(table.Rows[i]["ÜrünBarkodu"].ToString());
                listView1.Items[i].SubItems.Add(table.Rows[i]["ÜrünAdı"].ToString());
                listView1.Items[i].SubItems.Add(table.Rows[i]["BirimFiyatı"].ToString());
                listView1.Items[i].SubItems.Add(table.Rows[i]["ÜrünMiktarı"].ToString());

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

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (StokMiktarı < Convert.ToInt32(txt_MiktarSatış.Text))
                {
                    MessageBox.Show("Yeterli stok bulunmamaktadır.");
                }
                else
                {
                    SqlCommand kmt = new SqlCommand();
                    kmt.CommandText = "SELECT*FROM MüşteriBilgileri";
                    kmt.Connection = bağlantı;

                    SqlDataAdapter adaptör = new SqlDataAdapter(kmt);
                    DataTable table = new DataTable();

                    adaptör.Fill(table);
                    for (int i = 0; i < table.Rows.Count; i++)
                    {
                        listView2.Items.Add(table.Rows[i]["FirmaAdı"].ToString());
                        listView2.Items[i].SubItems.Add(table.Rows[i]["FaturaAdresi"].ToString());
                        listView2.Items[i].SubItems.Add(table.Rows[i]["FirmaVergiNo"].ToString());
                        listView2.Items[i].SubItems.Add(table.Rows[i]["FirmaVergiDairesi"].ToString());
                        listView2.Items[i].SubItems.Add(table.Rows[i]["FirmaTelNo"].ToString());
                        listView2.Items[i].SubItems.Add(table.Rows[i]["FirmaEposta"].ToString());
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
                }
            }
            catch (Exception)
            {

            }

        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_firmaAdı.Text = listView2.SelectedItems[0].Text;
            txt_faturaAdresi.Text = listView2.SelectedItems[0].SubItems[1].Text;
            txt_vergiNo.Text = listView2.SelectedItems[0].SubItems[2].Text;
            txt_vergiDairesi.Text = listView2.SelectedItems[0].SubItems[3].Text;
            txt_telNo.Text = listView2.SelectedItems[0].SubItems[4].Text;
            txt_Eposta.Text = listView2.SelectedItems[0].SubItems[5].Text;

           


        }

        private void btn_satışyap_Click(object sender, EventArgs e)
        {
            try
            {
                SatışBilgileri sb = new SatışBilgileri();

                sb.ürünbarkodu = Convert.ToInt32(txt_BarkodSatış.Text);
                sb.ürünAdı = txt_AdıSatış.Text;
                sb.birimFiyat = Convert.ToInt32(txt_BirimfiyatSatış.Text);
                sb.ürünMiktarı = Convert.ToInt32(txt_MiktarSatış.Text);
                MüşteriBilgileri mb;
                mb.Firmadı = txt_firmaAdı.Text;
                mb.FaturaAdresi = txt_faturaAdresi.Text;
                sb.satışTutarı = Convert.ToInt32(txt_BirimfiyatSatış.Text) * Convert.ToInt32(txt_MiktarSatış.Text);



                SqlCommand kmt = new SqlCommand();
                bağlantı.Open();
                kmt.Connection = bağlantı;
                kmt.CommandText = "insert into SatışBilgileri(ÜrünBarkodı,ÜrünAdı,BirimFiyatı,ÜrünMiktarı,FirmaAdı,FaturaAdresi,SatışTutarı) VALUES (@ÜrünBarkodı,@ÜrünAdı,@BirimFiyatı,@ÜrünMiktarı,@FirmaAdı,@FaturaAdresi,@SatışTutarı)";

                kmt.Parameters.AddWithValue("@ÜrünBarkodı", sb.ürünbarkodu);
                kmt.Parameters.AddWithValue("@ÜrünAdı", sb.ürünAdı);
                kmt.Parameters.AddWithValue("@BirimFiyatı", sb.birimFiyat);
                kmt.Parameters.AddWithValue("@ÜrünMiktarı", sb.ürünMiktarı);
                kmt.Parameters.AddWithValue("@FirmaAdı", mb.Firmadı);
                kmt.Parameters.AddWithValue("@FaturaAdresi", mb.FaturaAdresi);
                kmt.Parameters.AddWithValue("@SatışTutarı", sb.satışTutarı);


                kmt.ExecuteNonQuery();
                bağlantı.Close();
                DepoBilgileri dp = new DepoBilgileri();
                dp.ürünbarkodu = Convert.ToInt32(txt_BarkodSatış.Text);
                dp.ürünAdı = txt_AdıSatış.Text;
                dp.birimFiyat = Convert.ToInt32(txt_BirimfiyatSatış.Text);
                dp.ürünMiktarı = StokMiktarı - Convert.ToInt32(txt_MiktarSatış.Text);
                SqlCommand kmt1 = new SqlCommand("UPDATE DepoBilgileri SET ÜrünBarkodu=@ÜrünBarkodu , ÜrünAdı=@ÜrünAdı , BirimFiyatı=@BirimFiyatı , ÜrünMiktarı=@ÜrünMiktarı WHERE ÜrünBarkodu=@ÜrünBarkodu", bağlantı);

                kmt1.Parameters.AddWithValue("@ÜrünBarkodu", dp.ürünbarkodu);
                kmt1.Parameters.AddWithValue("@ÜrünAdı", dp.ürünAdı);
                kmt1.Parameters.AddWithValue("@BirimFiyatı", dp.birimFiyat);
                kmt1.Parameters.AddWithValue("@ÜrünMiktarı", dp.ürünMiktarı);

                bağlantı.Open();
                kmt1.ExecuteNonQuery();
                bağlantı.Close();
                MesajYazdırma yazdır = new MessageBoxYazdır();
                MessageBox.Show(" " + yazdır.yazdır());
            }
            catch (Exception)
            {

            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            frm_VeriOkuma frm = new frm_VeriOkuma();
            frm.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }
    }
}
