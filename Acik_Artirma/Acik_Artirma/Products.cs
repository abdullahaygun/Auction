using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Acik_Artirma
{
    public class Products
    {
        public int id { get; set; }
        public string rol { get; set; }
        public int UserID { get; set; }
        public string baslik { get; set; }
        public int basFiyat { get; set; }
        public DateTime basTarih { get; set; }
        public DateTime bitTarih { get; set; }
        public string aciklama { get; set; }
        public List<string> pictures { get; set; }
        public bool basladiMi { get; set; }
        public bool bittiMi { get; set; }
        public string satanKisi { get; set; }
        public int enYuksekTeklif { get; set; }
    }

}