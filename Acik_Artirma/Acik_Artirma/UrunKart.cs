using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma
{
    public class UrunKart
    {
        public UrunKart()
        {

        }

        public void olustur(PlaceHolder placeOnMe,string urunID,string IDKart,string RoleKart, string pathResim, string getBaslık,string getFiyat,string getBasTarih, string getBitTarih)
        {
            HtmlGenericControl divKart = new HtmlGenericControl("div");
            HtmlGenericControl divResimBox = new HtmlGenericControl("div");
            HtmlGenericControl divBaslikBox = new HtmlGenericControl("div");
            HtmlGenericControl divFiyatBox = new HtmlGenericControl("div");
            HtmlGenericControl divTarihBox = new HtmlGenericControl("div");

            divKart.Attributes["class"] = "kart";
            divKart.Attributes["runat"] = "server";
            divKart.Attributes["id"] = "kart"+urunID;
            divKart.Attributes["data-id"] = IDKart;
            divKart.Attributes["data-role"] = RoleKart;
            divKart.Attributes["data-bastarih"] = getBasTarih;
            divKart.Attributes["data-bittarih"] = getBitTarih;

            divResimBox.Attributes["class"] = "resimBox";
            Image resim = new Image();
            resim.Attributes["id"] = "resim" + urunID;
            resim.Attributes["runat"] = "server";
            resim.ImageUrl = pathResim;
            resim.CssClass = "resim";

            divBaslikBox.Attributes["class"] = "baslikBox";
            HtmlGenericControl baslik = new HtmlGenericControl("label");
            baslik.Attributes["id"] = "baslik" + urunID;
            baslik.Attributes["class"] = "baslik";
            baslik.Attributes["runat"] = "server";
            baslik.InnerText = getBaslık;

            divFiyatBox.Attributes["class"] = "fiyatBox";
            HtmlGenericControl fiyat = new HtmlGenericControl("label");
            fiyat.Attributes["id"] = "fiyat" + urunID;
            fiyat.Attributes["class"] = "fiyat";
            fiyat.Attributes["runat"] = "server";
            fiyat.InnerText = getFiyat+" ₺";


            divTarihBox.Attributes["class"] = "tarihBox";
            HtmlGenericControl tarih = new HtmlGenericControl("label");
            tarih.Attributes["id"] = "tarih" + urunID;
            tarih.Attributes["class"] = "tarih";
            tarih.Attributes["runat"] = "server";

            placeOnMe.Controls.Add(divKart);
            placeOnMe.Controls.Add(divResimBox);
            placeOnMe.Controls.Add(divBaslikBox);
            placeOnMe.Controls.Add(divFiyatBox);
            placeOnMe.Controls.Add(divTarihBox);
            divResimBox.Controls.Add(resim);
            divBaslikBox.Controls.Add(baslik);
            divFiyatBox.Controls.Add(fiyat);
            divTarihBox.Controls.Add(tarih);
            divKart.Controls.Add(divResimBox);
            divKart.Controls.Add(divBaslikBox);
            divKart.Controls.Add(divFiyatBox);
            divKart.Controls.Add(divTarihBox);




        }
    }
}