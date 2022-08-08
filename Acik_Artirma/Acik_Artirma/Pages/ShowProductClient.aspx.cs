using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class ShowProductClient : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        ProductCard productCard = new ProductCard();
        protected void Page_Load(object sender, EventArgs e)
        {
            Products product = new Products();
            //productCard.kartOlustur("Client Ürün Göster", placeOnMe, "66", "Deneme", "21.05.2021 15:00,:00",
            //             "21.05.2021 16:00,:00", "Mehmet", "", product.enYuksekTeklif.ToString(), product.aciklama);
            for (int i = 0; i < baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString()).Count; i++)
            {
                product = baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i];
                if (baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].basladiMi)
                {
                    productCard.kartOlustur("Client Ürün Göster", placeOnMe, product.id.ToString(), product.baslik, product.basTarih.ToString(),
                        product.bitTarih.ToString(), product.satanKisi, product.pictures, product.enYuksekTeklif.ToString(), product.aciklama);
                }
                else
                {
                    productCard.kartOlustur("Client Ürün Göster", placeOnMe, product.id.ToString(), product.baslik, product.basTarih.ToString(),
                        product.bitTarih.ToString(), product.satanKisi, product.pictures, product.enYuksekTeklif.ToString(), product.aciklama);
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
    }
}