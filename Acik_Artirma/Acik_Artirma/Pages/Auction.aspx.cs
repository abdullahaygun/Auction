using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class Auction1 : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        UrunKart urunKart = new UrunKart();
        List<Products> urunler = new List<Products>();
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

            urunler = baglanti.AuctionGoster();
            for (int i = 0; i < urunler.Count; i++)
            {
                urunKart.olustur(placeOnMe, urunler[i].id.ToString(), urunler[i].id.ToString(), urunler[i].rol, urunler[i].pictures[0],
                    urunler[i].baslik, urunler[i].basFiyat.ToString(), urunler[i].basTarih.ToString("yyyy.MM.dd HH:mm:ss"), urunler[i].bitTarih.ToString("yyyy.MM.dd HH:mm:ss"));
            }

        }
    }
}