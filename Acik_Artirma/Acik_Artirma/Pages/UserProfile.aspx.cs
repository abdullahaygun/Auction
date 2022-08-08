using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class UserProfile : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<string> degerlerim = new List<string>();
            degerlerim = baglanti.Goster();
            string sifreEski = degerlerim[2];
            avatar.ImageUrl = degerlerim[4];
            lblId.Text = degerlerim[0];
            lblUsername.Text = degerlerim[1];
            lblMail.Text = degerlerim[3];
            lblBakiye.Text = degerlerim[5];
            txtAd.Attributes["placeholder"] = degerlerim[6];
            txtSoyad.Attributes["placeholder"] = degerlerim[7];

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

        protected void avatarDegistir_Click(object sender, ImageClickEventArgs e)
        {
        }

        protected void imgBtnKaydet_Click(object sender, ImageClickEventArgs e)
        {
            bool degerAd = false;
            bool degerSoyad = false;
            for (int i = 0; i < txtAd.Text.Length; i++)
            {
                if (uygunMu(@"[^0-9]", txtAd.Text[i].ToString()))
                {
                    degerAd = true;
                }
                else
                {
                    degerAd = false;
                    break;
                }
            }

            for (int i = 0; i < txtSoyad.Text.Length; i++)
            {
                if (uygunMu(@"[^0-9]", txtSoyad.Text[i].ToString()))
                {
                    degerSoyad = true;
                }
                else
                {
                    degerSoyad = false;
                    break;
                }
            }

            if (degerAd)
            {
                baglanti.UserProfilGuncelle("ad", txtAd.Text.ToString());
            }
            else
            {
                //form.Attributes["style"] = "background-color: rgb(189,87,87);";
            }

            if (degerSoyad)
            {
                baglanti.UserProfilGuncelle("soyad", txtSoyad.Text.ToString());
            }
            else
            {
                //form.Attributes["style"] = "background-color: rgb(189,87,87);";

            }

            if (uygunMu(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", txtPasswordYeni.Text.ToString()))
            {
                baglanti.UserProfilGuncelleSifre(txtPasswordYeni.Text.ToString(), txtPasswordEski.Text.ToString());
            }
            else
            {
                //form.Attributes["style"] = "background-color: rgb(189,87,87);";
            }
            if (avatarDegistir.PostedFile.FileName != string.Empty)
            {
                baglanti.UserProfilGuncelleAvatar(avatarDegistir.PostedFile);
            }

        }

        public bool uygunMu(string reg, string text)
        {
            bool result = false;
            Regex r = new Regex(reg);
            if (r.IsMatch(text))
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return result;
        }
    }
}