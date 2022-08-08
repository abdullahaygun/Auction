using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class UserPara : System.Web.UI.Page
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

        [System.Web.Services.WebMethod]
        public static void getPara(string data)
        {
            SQLBaglanti baglanti = new SQLBaglanti();
            Para para = new Para();
            para.IDUser = HttpContext.Current.Session["LoginID"].ToString();
            para.onaylandıMı = "-";
            para.bakıldıMı = "hayır";
            para.para = data;
            baglanti.setParaOnay(para);
            
        }
    }
}