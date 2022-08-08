using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AddProductbyClient : System.Web.UI.Page
    {
        protected void btnUrunEkle_Click(object sender, EventArgs e)
        {
            SQLBaglanti baglanti = new SQLBaglanti();
            var product = new Products();
            product.aciklama = txtUrunEkleAciklama.Text.ToString();
            product.basFiyat = Convert.ToInt32(txtUrunEkleBasFiyat.Text.ToString());
            product.baslik = txtUrunEkleBaslik.Text.ToString();
            product.basTarih = Convert.ToDateTime(txtUrunEkleBasTarih.Text.ToString());
            product.bitTarih = Convert.ToDateTime(txtUrunEkleBitTarih.Text.ToString());
            baglanti.Ekle("Products", flupImage.PostedFile, "Products", "Pictures", product.baslik, product.basFiyat.ToString(),
                 product.basTarih.ToString(), product.bitTarih.ToString(), product.aciklama);
            formUrunEkleHata.Text = string.Empty;
            if (Page.IsPostBack)
            {
                formUrunEkleHata.Text = baglanti.getMesaj();
                txtUrunEkleBaslik.Text = string.Empty;
                txtUrunEkleBasFiyat.Text = string.Empty;
                txtUrunEkleBasTarih.Text = string.Empty;
                txtUrunEkleBasTarih.Text = string.Empty;
                txtUrunEkleAciklama.Text = string.Empty;
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