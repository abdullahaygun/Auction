using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class UpdateProductClient : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        ProductCard productCard = new ProductCard();
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString()).Count; i++)
            {

                    productCard.kartOlustur("Client Ürün Updatede Göster", placeOnMe, baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].id.ToString(),
                    baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].baslik, baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].basFiyat.ToString(),
                            baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].bitTarih.ToString(),
                            baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].satanKisi.ToString(),
                            baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].pictures,
                            baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].enYuksekTeklif.ToString(),
                            baglanti.UserUrunleriGuncelle(Session["LoginID"].ToString())[i].aciklama);

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