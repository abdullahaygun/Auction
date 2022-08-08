using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AddProductClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                SQLBaglanti baglanti = new SQLBaglanti();
                var product = new Products();
                product.aciklama = txtAciklama.Value.ToString();
                product.basFiyat = Convert.ToInt32(txtBasFiyat.Value.ToString());
                product.baslik = txtBaslik.Value.ToString();
                product.basTarih = Convert.ToDateTime(basTarih.Value.ToString());
                product.bitTarih = Convert.ToDateTime(bitTarih.Value.ToString());

                baglanti.Ekle("Products", avatar.PostedFile, "Products", "Pictures", product.baslik, product.basFiyat.ToString(),
                    product.basTarih.ToString(), product.bitTarih.ToString(), product.aciklama);
                mesaj.InnerText = string.Empty;
                if (Page.IsPostBack)
                {
                    mesaj.InnerText = baglanti.getMesaj();
                    txtBaslik.Value = string.Empty;
                    txtBasFiyat.Value = string.Empty;
                    basTarih.Value = string.Empty;
                    bitTarih.Value = string.Empty;
                    txtAciklama.Value = string.Empty;

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }

        }
    }
}