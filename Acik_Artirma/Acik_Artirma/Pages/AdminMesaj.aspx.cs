using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class AdminMesaj : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        List<Mesaj> list = new List<Mesaj>();
        Mesaj mesaj = new Mesaj();
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

        protected void timer_Tick(object sender, EventArgs e)
        {

            list = baglanti.MesajListesi(mesaj);
            for (int i = 0; i < list.Count; i++)
            {
                MesajListesi(update, list[i]);

            }
        }

        public void MesajListesi(UpdatePanel update, Mesaj mesaj)
        {

            HtmlGenericControl li = new HtmlGenericControl("li");

            HtmlGenericControl div = new HtmlGenericControl("div");
            div.Attributes["class"] = "onayBox";

            HtmlGenericControl lblUserId = new HtmlGenericControl("label");
            lblUserId.Attributes["class"] = "UserId";
            lblUserId.InnerText = "(" + mesaj.IDUser + ")";

            HtmlGenericControl lbldeger = new HtmlGenericControl("label");
            lbldeger.Attributes["class"] = "deger";
            lbldeger.InnerText = mesaj.mesaj;
            lbldeger.Attributes["data-Deger"] = lbldeger.InnerText;


            div.Controls.Add(lblUserId);
            div.Controls.Add(lbldeger);


            li.Controls.Add(div);


            update.ContentTemplateContainer.Controls.Add(li);


        }
    }
}