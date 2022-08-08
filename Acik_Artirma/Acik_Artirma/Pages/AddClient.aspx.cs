using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            SQLBaglanti baglanti = new SQLBaglanti();
            Roles.Users users = new Roles.Users();
            users.username = txtRegisterAdminUsername.Text.ToString();
            users.ad = txtRegisterAdminAd.Text.ToString();
            users.soyad = txtRegisterAdminSoyad.Text.ToString();
            users.bakiye = 1200;
            users.mail = txtRegisterAdminMail.Text.ToString();
            users.password = txtRegisterAdminPassword.Text.ToString();
            users.picture = baglanti.getImagePaths()[0];

            baglanti.Ekle("Users", flupImage.PostedFile, "Users", "Avatars", users.username, users.password, users.mail,
                users.picture, users.bakiye.ToString(), users.ad, users.soyad);

            formRegisterAdminHata.Text = string.Empty;
            if (Page.IsPostBack)
            {
                formRegisterAdminHata.Text = baglanti.getMesaj();
                txtRegisterAdminAd.Text = string.Empty;
                txtRegisterAdminSoyad.Text = string.Empty;
                txtRegisterAdminMail.Text = string.Empty;
                txtRegisterAdminUsername.Text = string.Empty;
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