using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void imgBtnArrowAd_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            imgButtonBack.Attributes.Add("data-myid", "1");

            if (txtAd.Text == string.Empty)
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Ad");
                ((HtmlGenericControl)div1).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div2).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                bool deger = false;
                for (int i = 0; i < txtAd.Text.Length; i++)
                {
                    if (uygunMu(@"[^0-9]", txtAd.Text[i].ToString()))
                    {
                        deger = true;
                    }
                    else
                    {
                        deger = false;
                        break;
                    }
                }

                if (deger)
                {
                    error("rgb(87,189,130);");
                    System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Ad");
                    ((HtmlGenericControl)div1).Attributes.Add("class", "field-name innactive");
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-password active");
                    imgButtonBack.Visible = true;
                    mesaj.Visible = false;
                }
                else
                {
                    mesaj.Text = "Lütfen Adınızı Dorğu Giriniz!";
                    mesaj.Visible = true;
                    imgButtonBack.Visible = true;
                }
            }
        }

        protected void imgBtnArrowSoyad_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            imgButtonBack.Attributes.Add("data-myid", "2");

            if (txtSoyad.Text == string.Empty)
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Ad");
                ((HtmlGenericControl)div2).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div3).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                bool deger = false;
                for (int i = 0; i < txtSoyad.Text.Length; i++)
                {
                    if (uygunMu(@"[^0-9]", txtSoyad.Text[i].ToString()))
                    {
                        deger = true;
                    }
                    else
                    {
                        deger = false;
                        break;
                    }
                }

                if (deger)
                {
                    error("rgb(87,189,130);");
                    System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Ad");
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-name innactive");
                    ((HtmlGenericControl)div3).Attributes.Add("class", "field-password active");
                    imgButtonBack.Visible = true;
                    mesaj.Visible = false;
                }
                else
                {
                    mesaj.Text = "Lütfen Soyadınızı Dorğu Giriniz!";
                    mesaj.Visible = true;
                    imgButtonBack.Visible = true;
                }
            }
        }

        protected void imgBtnArrowMail_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            imgButtonBack.Attributes.Add("data-myid", "3");

            if (uygunMu(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", txtMail.Text.ToString()))
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Mail");
                ((HtmlGenericControl)div3).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div4).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                mesaj.Text = "Lütfen Mail Adresinizi Dorğu Giriniz!";
                mesaj.Visible = true;
                imgButtonBack.Visible = true;
            }
        }

        protected void imgBtnArrowUsername_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            imgButtonBack.Attributes.Add("data-myid", "4");

            if (uygunMu(@"^[\s\S]{6,}$", txtUsername.Text.ToString()))
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Kullanıcı Adı");
                ((HtmlGenericControl)div4).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div5).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                mesaj.Text = "Kullanıcı Adı min 6, max 50 hane olmalıdır!";
                mesaj.Visible = true;
                imgButtonBack.Visible = true;
            }
        }

        protected void imgBtnArrowPassword_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            imgButtonBack.Attributes.Add("data-myid", "5");

            if (uygunMu(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", txtPassword.Text.ToString()))
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Şifre");
                ((HtmlGenericControl)div5).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div6).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                mesaj.Text = "Şifre min 6, max 50 hane olmalıdır; en az 1 büyük ve 1 küçük harf içermelidir!";
                mesaj.Visible = true;
                imgButtonBack.Visible = true;
            }
            txtPassword.Attributes.Add("value", txtPassword.Text);
        }

        protected void imgBtnArrowPasswordT_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            var div8 = form.FindControl("kayit");
            imgButtonBack.Attributes.Add("data-myid", "6");

            if (txtPassword.Text == txtPasswordT.Text)
            {
                error("rgb(87,189,130);");
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Şifre Tekrarı");
                ((HtmlGenericControl)div6).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div7).Attributes.Add("class", "field-password active");
                ((HtmlGenericControl)div8).Visible = true;
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine(txtPassword.Text + " : " + txtPasswordT.Text);
                mesaj.Text = "Şifreler Uyuşmuyor!";
                mesaj.Visible = true;
                imgButtonBack.Visible = true;
            }
            txtPasswordT.Attributes.Add("value", txtPasswordT.Text);
        }

        protected void imgBtnRegister_Click(object sender, ImageClickEventArgs e)
        {
            SQLBaglanti baglanti = new SQLBaglanti();
            Roles.Users users = new Roles.Users();
            users.ad = txtAd.Text.ToString();
            users.soyad = txtSoyad.Text.ToString();
            users.mail = txtMail.Text.ToString();
            users.username = txtUsername.Text.ToString();
            users.password = txtPassword.Text.ToString();
            //users.picture = baglanti.getImagePaths()[0];
            users.bakiye = 0;

            baglanti.Ekle("Users", avatar.PostedFile, "Users", "Avatars", users.username, users.password, users.mail,
                users.bakiye.ToString(), users.ad, users.soyad);

            if (baglanti.getMesaj() == "Başarılı bir şekilde Kayıt Edildi.")
            {
                Response.Redirect("Login.aspx");

                mesaj.Text = baglanti.getMesaj();
                txtAd.Text = string.Empty;
                txtSoyad.Text = string.Empty;
                txtMail.Text = string.Empty;
                txtUsername.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtPasswordT.Text = string.Empty;
            }
        }

        protected void imgButtonBack_Click(object sender, ImageClickEventArgs e)
        {
            var div1 = form.FindControl("field_name");
            var div2 = form.FindControl("field_surname");
            var div3 = form.FindControl("field_mail");
            var div4 = form.FindControl("field_username");
            var div5 = form.FindControl("field_password");
            var div6 = form.FindControl("field_passwordT");
            var div7 = form.FindControl("field_avatar");
            var div8 = form.FindControl("kayit");
            string deger = imgButtonBack.Attributes["data-myid"];
            imgButtonBack.Visible = true;

            switch (deger)
            {
                case "1":
                    ((HtmlGenericControl)div1).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "0");
                    mesaj.Visible = false;
                    break;

                case "2":
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div3).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "1");
                    mesaj.Visible = false;
                    break;

                case "3":
                    ((HtmlGenericControl)div3).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div4).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "2");
                    mesaj.Visible = false;
                    break;

                case "4":
                    ((HtmlGenericControl)div4).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div5).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "3");
                    mesaj.Visible = false;
                    break;

                case "5":
                    ((HtmlGenericControl)div5).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div6).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "4");
                    mesaj.Visible = false;
                    break;

                case "6":
                    ((HtmlGenericControl)div6).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div7).Attributes.Add("class", "field-password innactive");
                    imgButtonBack.Attributes.Add("data-myid", "5");
                    ((HtmlGenericControl)div8).Visible = false;
                    mesaj.Visible = false;
                    break;
            }
        }

        public bool uygunMu(string reg, string text)
        {
            bool result = false;
            Regex r = new Regex(reg);
            if (r.IsMatch(text))
            {
                error("rgb(87,189,130);");
                result = true;
            }
            else
            {
                error("rgb(189,87,87);");
                result = false;
            }
            return result;
        }

        public void error(string color)
        {
            form.Attributes["style"] = "background-color: " + color + ";";
        }

    }
}