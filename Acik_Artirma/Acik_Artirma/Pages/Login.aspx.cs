using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Acik_Artirma.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            imgButtonBack.Visible = false;
        }

        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            var div = form.FindControl("field_name");
            var div2 = form.FindControl("field_password");

            if (uygunMu(@"^[\s\S]{6,}$", txtUsername.Text.ToString()))
            {
                System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Kullanıcı Adı");
                ((HtmlGenericControl)div).Attributes.Add("class", "field-name innactive");
                ((HtmlGenericControl)div2).Attributes.Add("class", "field-password active");
                imgButtonBack.Visible = true;
                mesaj.Visible = false;
            }
            else
            {
                mesaj.Text = "Kullanıcı Adı min 6, max 50 hane olmalıdır!";
                mesaj.Visible = true;
            }
        }

        protected void imgBtnArrow2_Click(object sender, ImageClickEventArgs e)
        {
            var div = form.FindControl("field_name");
            var div2 = form.FindControl("field_password");

            if (uygunMu(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$", txtPassword.Text.ToString()))
            {
                SQLBaglanti baglanti = new SQLBaglanti();
                int admin = baglanti.Giris("Admins", txtUsername.Text.ToString(), txtPassword.Text.ToString());
                int user = baglanti.Giris("Users", txtUsername.Text.ToString(), txtPassword.Text.ToString());
                if (admin != 0)
                {
                    Session["LoginID"] = admin;
                    Session["LoginTable"] = "Admins";
                    Session["AdSoyad"] = txtUsername.Text.ToString();
                    Response.Redirect("Admin.aspx");
                    System.Diagnostics.Debug.WriteLine("(ADMIN) Giriş Başaırılı..");

                    System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Şifre");
                    ((HtmlGenericControl)div).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-password innactive");
                }
                else
                {
                    error("rgb(189,87,87);");
                    imgButtonBack.Visible = true;
                    mesaj.Text = "Kullanıcı Adı ya da Şifreniz HATALI!";
                    mesaj.Visible = true;
                }

                if (user != 0)
                {
                    Session["bakiye"] = baglanti.getBakiye(user.ToString());
                    Session["LoginID"] = user;
                    Session["LoginTable"] = "Users";
                    Session.Add("AdSoyad", baglanti.getAdSoyad("Users", txtUsername.Text.ToString(), txtPassword.Text.ToString()));
                    Session["getAvatar"] = baglanti.getAvatar("Users", txtUsername.Text.ToString(), txtPassword.Text.ToString());
                    Response.Redirect("Auction.aspx");
                    System.Diagnostics.Debug.WriteLine("(USER) Giriş Başaırılı..");

                    System.Diagnostics.Debug.WriteLine("Her şey mükemmel.. Şifre");
                    ((HtmlGenericControl)div).Attributes.Add("class", "field-name active");
                    ((HtmlGenericControl)div2).Attributes.Add("class", "field-password innactive");
                }
                else
                {
                    error("rgb(189,87,87);");
                    imgButtonBack.Visible = true;
                    mesaj.Text = "Kullanıcı Adı ya da Şifreniz HATALI!";
                    mesaj.Visible = true;
                }

            }
            else
            {
                mesaj.Text = "Şifre min 6, max 50 hane olmalıdır; en az 1 büyük ve 1 küçük harf içermelidir!";
                mesaj.Visible = true;
                imgButtonBack.Visible = true;
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

        protected void imgButtonBack_Click(object sender, ImageClickEventArgs e)
        {
            var div = form.FindControl("field_name");
            var div2 = form.FindControl("field_password");
            ((HtmlGenericControl)div).Attributes.Add("class", "field-name active");
            ((HtmlGenericControl)div2).Attributes.Add("class", "field-password innactive");
            mesaj.Visible = false;
        }
    }
}