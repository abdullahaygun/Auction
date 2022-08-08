using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Acik_Artirma.Pages
{
    public partial class Admin_CRUD_User : System.Web.UI.Page
    {
        SQLBaglanti baglanti = new SQLBaglanti();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                baglanti.PopulateGridview("Users", tablo);
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

        protected void tablo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            baglanti.rowCommandEkle("Users", tablo, e, avatar.PostedFile, lblBasariMesaj.Text.ToString());
        }

        protected void tablo_RowEditing(object sender, GridViewEditEventArgs e)
        {
            baglanti.rowEditing("Users", tablo, e);
        }

        protected void tablo_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            baglanti.rowCancelling("Users", tablo);
        }

        protected void tablo_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            baglanti.rowDeleting("Users", tablo, e);
        }

        protected void tablo_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            baglanti.rowUpdating("Users", tablo, e, avatar.PostedFile);
        }
    }
}