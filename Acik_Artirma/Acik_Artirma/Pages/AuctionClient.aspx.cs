using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Acik_Artirma.Pages
{
    public partial class Auction : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        ProductCard productCard = new ProductCard();
        List<Products> urunler = new List<Products>();
        protected void Page_Load(object sender, EventArgs e)
        {
            urunler = baglanti.AuctionGoster();
            for (int i = 0; i < urunler.Count; i++)
            {
                if (urunler[i].basladiMi)
                {
                    System.Diagnostics.Debug.WriteLine(urunler[i].satanKisi);
                    productCard.kartOlustur("Client Auction kartları Göster", placeOnMe, urunler[i].id.ToString(), urunler[i].baslik, urunler[i].basFiyat.ToString(),
                          urunler[i].bitTarih.ToString(), urunler[i].satanKisi.ToString(), urunler[i].pictures,
                          urunler[i].enYuksekTeklif.ToString(), urunler[i].aciklama);
                }
                else
                {
                    productCard.kartOlustur("Client Auction kartları Göster", placeOnMe, urunler[i].id.ToString(), urunler[i].baslik, urunler[i].basTarih.ToString(),
                        urunler[i].bitTarih.ToString(), urunler[i].satanKisi.ToString(), urunler[i].pictures,
                        urunler[i].enYuksekTeklif.ToString(), urunler[i].aciklama);
                }
            }

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



        protected void time_Tick(object sender, EventArgs e)
        {
        }
    }
}