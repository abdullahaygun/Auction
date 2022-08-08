using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AuctionDetay : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        static Products product = new Products();
        AuctionClass auction = new AuctionClass();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["LoginTable"].ToString() == "Admins")
            {
                HtmlGenericControl style = new HtmlGenericControl();
                style.TagName = "style";
                style.Attributes.Add("type", "text/css");
                style.InnerHtml = ".Default{display:none;} .User{display:none;} .Admin{display:block;}";
                Page.Header.Controls.Add(style);
            }
            else if (Session["LoginTable"].ToString() == "Users")
            {
                HtmlGenericControl style = new HtmlGenericControl();
                style.TagName = "style";
                style.Attributes.Add("type", "text/css");
                style.InnerHtml = ".Default{display:none;} .User{display:block;} .Admin{display:none;}";
                Page.Header.Controls.Add(style);
            }

            product.id = Convert.ToInt32(Session["UrunID"]);
            baglanti.AuctionDetayGöster(product);

            for (int i = 0; i < product.pictures.Count; i++)
            {
                HtmlGenericControl resim = new HtmlGenericControl("img");
                resim.Attributes["runat"] = "server";
                resim.Attributes["class"] = "resim";
                resim.ID = "resim" + i;
                resim.Attributes["data-index"] = i.ToString();
                resim.Attributes["src"] = product.pictures[i].Replace("~", "..");
                ResimBox.Controls.Add(resim);
            }

            for (int i = 0; i < product.pictures.Count; i++)
            {
                HtmlGenericControl resim = new HtmlGenericControl("img");
                resim.Attributes["runat"] = "server";
                resim.Attributes["class"] = "FooterResim";
                resim.ID = "resimm" + i;
                resim.Attributes["data-index"] = i.ToString();
                resim.Attributes["src"] = product.pictures[i].Replace("~", "..");
                FooterResimBox.Controls.Add(resim);
            }

            baslik.InnerText = product.baslik;
            bitisBox.Attributes["data-basTarih"] = product.basTarih.ToString("yyyy.MM.dd HH:mm:ss");
            bitisBox.Attributes["data-bitTarih"] = product.bitTarih.ToString("yyyy.MM.dd HH:mm:ss");
            satanAdSoyad.InnerText = product.satanKisi;
            satanId.InnerText = "(" + product.UserID.ToString() + ")";
            aciklama.InnerText = product.aciklama;

            basFiyat.InnerText = product.basFiyat.ToString();
            satanAdSoyad.InnerText = product.satanKisi;

            if (Session["AdSoyad"] != null)
            {
                var lblavataruser = Page.Master.FindControl("lblavataruser") as Label;
                lblavataruser.Text = "Hoşgeldiniz, " + Session["AdSoyad"].ToString();
            }

            if (Session["getAvatar"] != null)
            {
                var useravatar = Page.Master.FindControl("useravatar") as Image;
                useravatar.ImageUrl = Session["getAvatar"].ToString();
            }
        }

        [System.Web.Services.WebMethod]
        public static void TestFunction(string data)
        {
            HttpContext.Current.Session["UrunID"] = data;
        }



        [System.Web.Services.WebMethod]
        public static void getTeklifim(AuctionClass data)
        {
            SQLBaglanti baglanti = new SQLBaglanti();
            baglanti.AuctionEkle(data);
            Para para = new Para();
            para.IDUser = data.IDTeklifVeren;
            para.para = data.teklif;
            baglanti.bakiyeAzalt(para);
        }
        List<AuctionClass> liste = new List<AuctionClass>();
        protected void timer_Tick(object sender, EventArgs e)
        {
            auction.IDProduct = product.id.ToString();
            liste = baglanti.TekliflerGoster(auction);
            for (int i = 0; i < liste.Count; i++)
            {
            TekliflerTablosu tekliflerTablosu = new TekliflerTablosu(ul, liste[i], product.satanKisi);

            }
        }
    }
}