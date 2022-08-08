using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Acik_Artirma
{
    public class TekliflerTablosu
    {
        public TekliflerTablosu(HtmlGenericControl ul, AuctionClass auction, string satanAdSoyad)
        {
            HtmlGenericControl li = new HtmlGenericControl("li");
            li.Attributes["class"] = "teklifSatir";

            HtmlGenericControl lblteklif = new HtmlGenericControl("label");
            lblteklif.Attributes["class"] = "teklif";
            lblteklif.InnerText = auction.teklif;

            HtmlGenericControl lblteklifTL = new HtmlGenericControl("label");
            lblteklifTL.Attributes["class"] = "teklifTL";
            lblteklifTL.InnerText = "₺";

            HtmlGenericControl lbladSoyad = new HtmlGenericControl("label");
            lbladSoyad.Attributes["class"] = "adSoyad";
            lbladSoyad.InnerText = satanAdSoyad;

            HtmlGenericControl lblid = new HtmlGenericControl("label");
            lblid.Attributes["class"] = "id";
            lblid.InnerText = "("+auction.IDTeklifVeren+")";

            HtmlGenericControl lblteklifTarih = new HtmlGenericControl("label");
            lblteklifTarih.Attributes["class"] = "teklifTarih";
            lblteklifTarih.InnerText = auction.teklifTarihi;

            li.Controls.Add(lblteklif);
            li.Controls.Add(lblteklifTL);
            li.Controls.Add(lbladSoyad);
            li.Controls.Add(lblid);
            li.Controls.Add(lblteklifTarih);
            ul.Controls.Add(li);

        }
    }
}