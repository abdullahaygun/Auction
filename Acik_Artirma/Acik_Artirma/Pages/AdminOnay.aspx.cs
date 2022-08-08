using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AdminOnay : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        Para para = new Para();
        List<Para> list = new List<Para>();
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

        [System.Web.Services.WebMethod]
        public static void Red(Para data)
        {
            System.Diagnostics.Debug.WriteLine("Reddedildi!" + " + " + data);
            SQLBaglanti baglanti = new SQLBaglanti();
            baglanti.ParaOnay(data.IDUser, "hayır", data.para);
        }

        [System.Web.Services.WebMethod]
        public static void Kabul(Para data)
        {
            System.Diagnostics.Debug.WriteLine("Kabul Edildi." + " + " + data);
            SQLBaglanti baglanti = new SQLBaglanti();
            baglanti.ParaOnay(data.IDUser, "evet", data.para);
            HttpContext.Current.Session["bakiye"] = baglanti.getBakiye(data.IDUser);
        }

        protected void timer_Tick(object sender, EventArgs e)
        {

            list = baglanti.AdminParaOnayListesi(para);
            for (int i = 0; i < list.Count; i++)
            {
                OnayListesi(update, list[i]);

            }
        }

        public void OnayListesi(UpdatePanel update, Para para)
        {

            HtmlGenericControl li = new HtmlGenericControl("li");

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes["class"] = "onayBox";

            HtmlGenericControl lbladSoyad = new HtmlGenericControl("label");
            lbladSoyad.Attributes["class"] = "adSoyad";

            HtmlGenericControl lblUserId = new HtmlGenericControl("label");
            lblUserId.Attributes["class"] = "UserId";
            lblUserId.InnerText = "(" + para.IDUser + ")";
            HtmlGenericControl lbldeger = new HtmlGenericControl("label");
            lbldeger.Attributes["class"] = "deger";
            lbldeger.InnerText = para.para;
            lbldeger.Attributes["data-Deger"] = lbldeger.InnerText;

            HtmlGenericControl lblbirim = new HtmlGenericControl("label");
            lblbirim.Attributes["class"] = "birim";
            lblbirim.InnerText = "₺";

            HtmlGenericControl lblbtnKabul = new HtmlGenericControl("label");
            lblbtnKabul.Attributes["class"] = "btnKabul";
            lblbtnKabul.Attributes["data-UserID"] = para.IDUser;
            lblbtnKabul.InnerText = "Kabul Et";

            HtmlGenericControl lblbtnRed = new HtmlGenericControl("label");
            lblbtnRed.Attributes["class"] = "btnRed";
            lblbtnRed.Attributes["data-UserID"] = para.IDUser;
            lblbtnRed.InnerText = "Reddet";

            div.Controls.Add(lbladSoyad);
            div.Controls.Add(lblUserId);
            div.Controls.Add(lbldeger);
            div.Controls.Add(lblbirim);
            div.Controls.Add(lblbtnKabul);
            div.Controls.Add(lblbtnRed);

            li.Controls.Add(div);


            update.ContentTemplateContainer.Controls.Add(li);


        }
    }
}