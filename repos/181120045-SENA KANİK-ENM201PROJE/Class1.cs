using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _181120045_SENA_KANİK_ENM201PROJE
{
    class Class1
    {
        public static List<string> ÜrünAdı = new List<string>();
        public static List<string> FirmaAdı = new List<string>();
        public static List<string> KullanıcıAdı = new List<string>();
        public static List<int> SatışTutarı= new List<int>();
    }
    struct MüşteriBilgileri
    {
        public string Firmadı;
        public string FaturaAdresi;
        public int VergiNo;
        public string VergiDairesi;
        public int TelNo;
        public string Eposta;
    }


    class Kullanıcıbilgileri

    {   
        private string KullanıcıAdı;
        private int Sifre;
        private string Departman;
        private string TelefonNo;
        public string kullanıcıAdı
        {
            get { return KullanıcıAdı; }
            set { this.KullanıcıAdı = value.ToUpper(); }
        }
        public int sifre
        {
            get { return Sifre; }
            set { this.Sifre = value; }
        }
        public string departman
        {
            get { return Departman; }
            set { this.Departman = value.ToUpper(); }
        }
        public string telefonNo
        {
            get { return TelefonNo; }
            set { this.TelefonNo = value; }
        }

    }
    class DepoBilgileri : Kullanıcıbilgileri
    {
        private int ÜrünBarkodu;
        private string ÜrünAdı;
        private int BirimFiyatı;
        private int ÜrünMiktarı;
        private string GirişYapanKişi;
        public int ürünbarkodu
        {
            get { return ÜrünBarkodu; }
            set { this.ÜrünBarkodu = value; }

        }
        public string ürünAdı
        {
            get { return ÜrünAdı; }
            set { this.ÜrünAdı = value.ToUpper(); }

        }
        public int birimFiyat
        {
            get { return BirimFiyatı; }
            set { this.BirimFiyatı = value; }
        }
        public int ürünMiktarı
        {
            get { return ÜrünMiktarı; }
            set { this.ÜrünMiktarı = value; }
        }
    }
    class SatışBilgileri : DepoBilgileri
    {
        MüşteriBilgileri Müş;
        private int SatışTutarı;
        public int satışTutarı
        {
            get { return SatışTutarı; }
            set { this.SatışTutarı = value; }
        }


    }
    abstract class MesajYazdırma
    {
        abstract public string yazdır();
       
    }
    class MessageBoxYazdır : MesajYazdırma
    {
        public override string yazdır()
        {
            return "İŞLEM GERÇEKLEŞMİŞTİR.";
        }
    }
    class LabelYazdır : MesajYazdırma
    {
        public override string yazdır()
        {
            return "KULLANICI ADI VEYA ŞİFRE YANLIŞ!!!";
        }
    }
}
