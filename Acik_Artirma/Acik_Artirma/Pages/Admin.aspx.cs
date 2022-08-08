using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AdSoyad"] != null)
            {
                var lblAvatarAdmin = Page.Master.FindControl("lblAvatarAdmin") as Label;
                lblAvatarAdmin.Text = "Hoşgeldiniz, " + Session["AdSoyad"].ToString();
            }
        }
    }
}