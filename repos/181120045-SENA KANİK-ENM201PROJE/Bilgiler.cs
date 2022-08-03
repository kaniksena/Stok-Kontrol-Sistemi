using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _181120045_SENA_KANİK_ENM201PROJE
{
    class Bilgiler
    {
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
            set { this.KullanıcıAdı = kullanıcıAdı; }
        }
        public int sifre
        {
            get { return Sifre; }
            set { this.Sifre = sifre; }
        }
        public string departman
        {
            get { return Departman; }
            set { this.Departman = departman; }
        }
        public string telefonNo
        {
            get { return TelefonNo; }
            set { this.TelefonNo = telefonNo; }
        }

    }
    class DepoBilgileri : KullanıcıBilgileri
    {
        private int ÜrünBarkodu;
        private string ÜrünAdı;
        private int BirimFiyatı;
        private int ÜrünMiktarı;
        private string GirişYapanKişi;
        public int ürünbarkodu
        {
            get { return ÜrünBarkodu; }
            set { this.ÜrünBarkodu = Math.Abs(value); }

        }
        public string ürünAdı
        {
            get { return ÜrünAdı; }
            set { this.ÜrünAdı = ürünAdı; }

        }
        public int birimFiyat
        {
            get { return BirimFiyatı; }
            set { this.BirimFiyatı = birimFiyat; }
        }
        public int ürünMiktarı
        {
            get { return ÜrünMiktarı; }
            set { this.ÜrünMiktarı = ÜrünMiktarı; }
        }
    }
    class SatışBilgileri : DepoBilgileri
    {
        MüşteriBilgileri Müş;
        private int SatışTutarı;
        public int satışTutarı
        {
            get { return SatışTutarı; }
            set { this.SatışTutarı = satışTutarı; }
        }

    }



}
