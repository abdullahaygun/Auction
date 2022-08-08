using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class DeleteProductClient : System.Web.UI.Page
    {
        ProductCard productCard = new ProductCard();
        SQLBaglanti baglanti = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString()).Count; i++)
            {
                if (baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].basladiMi)
                {
                    productCard.kartOlustur("Client Ürün Silde Göster", placeOnMe, baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].id.ToString(),
                    baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].baslik, baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].basFiyat.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].bitTarih.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].satanKisi.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].pictures,
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].enYuksekTeklif.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].aciklama);
                }
                else
                {
                    productCard.kartOlustur("Client Ürün Silde Göster", placeOnMe, baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].id.ToString(),
                    baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].baslik, baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].basTarih.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].bitTarih.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].satanKisi.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].pictures,
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].enYuksekTeklif.ToString(),
                            baglanti.UserinUrunleriniGoster(Session["LoginID"].ToString())[i].aciklama);
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

        protected void btnClientUrunleriGetir_Click(object sender, EventArgs e)
        {
            foreach(var c in placeOnMe.Controls)
            {
                if(c is CheckBox)
                {
                    if (((CheckBox)c).Checked)
                    {
                        string id = ((CheckBox)c).Attributes["data-myid"].ToString();
                        baglanti.Sil("Products" ,id);
                        System.Diagnostics.Debug.WriteLine("Slindi..");
                        
                    }
                    
                }
            }

            Response.Redirect("DeleteProductClient.aspx");

        }
    }
}