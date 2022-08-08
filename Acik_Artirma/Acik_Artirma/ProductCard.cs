using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Acik_Artirma
{
    public class ProductCard
    {
        PlaceHolder placeOnMe = null;
        SQLBaglanti baglanti = new SQLBaglanti();
        List<Products> liste = new List<Products>();

        public void kartOlustur(string durum, PlaceHolder placeOnMe, string id, string onBaslik, string onTarihFiyat, string onBitisTarih, string onSatanKisi, List<string> arkaResimler, string arkaSonTeklif, string arkaAciklama)
        {

            this.placeOnMe = placeOnMe;
            if (durum == "Client Ürün Silde Göster")
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Attributes["data-myid"] = id;


                string arkaBaslik = onBaslik;
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "artboard";
                div1.ID = "div" + id;
                div1.Attributes["data-myid"] = id;

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "card";
                div2.Attributes["runat"] = "server";


                HtmlGenericControl div3 = new HtmlGenericControl("div");
                div3.Attributes["class"] = "card__side card__side--back";

                HtmlGenericControl div4 = new HtmlGenericControl("div");
                div4.Attributes["class"] = "card__side card__side--front";

                HtmlGenericControl div5 = new HtmlGenericControl("div");
                div5.Attributes["class"] = "card__cover";

                HtmlGenericControl div6 = new HtmlGenericControl("div");
                div6.Attributes["class"] = "card__details";

                HtmlGenericControl h1 = new HtmlGenericControl("h4");
                h1.Attributes["class"] = "card__heading";

                HtmlGenericControl span1 = new HtmlGenericControl("span");
                span1.Attributes["class"] = "card__heading-span";
                span1.InnerText = arkaBaslik;

                HtmlGenericControl div7 = new HtmlGenericControl("div");
                div7.Attributes["class"] = "resimlerArka";

                HtmlGenericControl div8 = new HtmlGenericControl("div");
                div8.Attributes["class"] = "sonTeklif";
                div8.InnerText = arkaSonTeklif;

                HtmlGenericControl div9 = new HtmlGenericControl("div");
                div9.Attributes["class"] = "aciklama";
                div9.InnerText = arkaAciklama;

                HtmlGenericControl div11 = new HtmlGenericControl("div");
                div11.Attributes["class"] = "card__theme";

                HtmlGenericControl div12 = new HtmlGenericControl("div");
                div12.Attributes["class"] = "card__theme-box";

                HtmlGenericControl div13 = new HtmlGenericControl("div");
                div13.Attributes["class"] = "resimler";

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                p1.Attributes["class"] = "card__title";
                p1.InnerText = onBaslik;

                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p2.Attributes["class"] = "card__subject";
                p2.InnerText = onTarihFiyat;

                HtmlGenericControl div14 = new HtmlGenericControl("div");
                div14.Attributes["class"] = "sagOn";
                div14.InnerText = onBitisTarih;

                HtmlGenericControl div15 = new HtmlGenericControl("div");
                div15.Attributes["class"] = "solOn";
                div15.InnerText = onSatanKisi;

                //UpdatePanel update = new UpdatePanel();
                //update.Attributes["runat"] = "server";
                //AsyncPostBackTrigger asyncPostBackTrigger = new AsyncPostBackTrigger();
                //asyncPostBackTrigger.ControlID = "btnClientUrunleriGetir";
                //asyncPostBackTrigger.EventName = "Click";



                //update.Triggers.Add(asyncPostBackTrigger);
                //update.ContentTemplateContainer.Controls.Add(div1);
                placeOnMe.Controls.Add(div1);
                placeOnMe.Controls.Add(checkBox);
                string onResim = arkaResimler[0];
                Image image2 = new Image();
                image2.Attributes["runat"] = "server";
                image2.CssClass = "resim";
                image2.ImageUrl = onResim.ToString();
                div13.Controls.Add(image2);
                div12.Controls.Add(div13);
                div12.Controls.Add(p1);
                div12.Controls.Add(p2);
                div12.Controls.Add(div14);
                div12.Controls.Add(div15);
                h1.Controls.Add(span1);
                div5.Controls.Add(h1);
                div6.Controls.Add(div7);
                for (int i = 0; i < arkaResimler.Count; i++)
                {
                    Image image = new Image();
                    //image.ID = "im" + i.ToString();
                    image.Attributes["runat"] = "server";
                    image.CssClass = "resimArka";
                    image.ImageUrl = arkaResimler[i].ToString();
                    div7.Controls.Add(image);
                }
                div6.Controls.Add(div8);
                div6.Controls.Add(div9);
                div4.Controls.Add(div11);
                div11.Controls.Add(div12);
                div3.Controls.Add(div5);
                div3.Controls.Add(div6);
                div2.Controls.Add(div3);
                div2.Controls.Add(div4);
                div1.Controls.Add(div2);

            }
            else if (durum == "Client Ürün Göster")
            {
                string arkaBaslik = onBaslik;
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "artboard";
                div1.ID = "div" + id;
                div1.Attributes["data-myid"] = id;

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "card";
                div2.Attributes["runat"] = "server";


                HtmlGenericControl div3 = new HtmlGenericControl("div");
                div3.Attributes["class"] = "card__side card__side--back";

                HtmlGenericControl div4 = new HtmlGenericControl("div");
                div4.Attributes["class"] = "card__side card__side--front";

                HtmlGenericControl div5 = new HtmlGenericControl("div");
                div5.Attributes["class"] = "card__cover";

                HtmlGenericControl div6 = new HtmlGenericControl("div");
                div6.Attributes["class"] = "card__details";

                HtmlGenericControl h1 = new HtmlGenericControl("h4");
                h1.Attributes["class"] = "card__heading";

                HtmlGenericControl span1 = new HtmlGenericControl("span");
                span1.Attributes["class"] = "card__heading-span";
                span1.InnerText = arkaBaslik;

                HtmlGenericControl div7 = new HtmlGenericControl("div");
                div7.Attributes["class"] = "resimlerArka";

                HtmlGenericControl div8 = new HtmlGenericControl("div");
                div8.Attributes["class"] = "sonTeklif";
                div8.InnerText = arkaSonTeklif;

                HtmlGenericControl div9 = new HtmlGenericControl("div");
                div9.Attributes["class"] = "aciklama";
                div9.InnerText = arkaAciklama;

                HtmlGenericControl div11 = new HtmlGenericControl("div");
                div11.Attributes["class"] = "card__theme";

                HtmlGenericControl div12 = new HtmlGenericControl("div");
                div12.Attributes["class"] = "card__theme-box";

                HtmlGenericControl div13 = new HtmlGenericControl("div");
                div13.Attributes["class"] = "resimler";

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                p1.Attributes["class"] = "card__title";
                p1.InnerText = onBaslik;

                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p2.Attributes["class"] = "card__subject";
                p2.InnerText = onTarihFiyat;

                HtmlGenericControl div14 = new HtmlGenericControl("div");
                div14.Attributes["class"] = "sagOn";
                div14.InnerText = onBitisTarih;

                HtmlGenericControl div15 = new HtmlGenericControl("div");
                div15.Attributes["class"] = "solOn";
                div15.InnerText = onSatanKisi;

                //UpdatePanel update = new UpdatePanel();
                //update.Attributes["runat"] = "server";
                //AsyncPostBackTrigger asyncPostBackTrigger = new AsyncPostBackTrigger();
                //asyncPostBackTrigger.ControlID = "btnClientUrunleriGetir";
                //asyncPostBackTrigger.EventName = "Click";



                //update.Triggers.Add(asyncPostBackTrigger);
                //update.ContentTemplateContainer.Controls.Add(div1);
                placeOnMe.Controls.Add(div1);
                string onResim = arkaResimler[0];
                Image image2 = new Image();
                image2.Attributes["runat"] = "server";
                image2.CssClass = "resim";
                image2.ImageUrl = onResim.ToString();
                div13.Controls.Add(image2);
                div12.Controls.Add(div13);
                div12.Controls.Add(p1);
                div12.Controls.Add(p2);
                div12.Controls.Add(div14);
                div12.Controls.Add(div15);
                h1.Controls.Add(span1);
                div5.Controls.Add(h1);
                div6.Controls.Add(div7);
                for (int i = 0; i < arkaResimler.Count; i++)
                {
                    Image image = new Image();
                    //image.ID = "im" + i.ToString();
                    image.Attributes["runat"] = "server";
                    image.CssClass = "resimArka";
                    image.ImageUrl = arkaResimler[i].ToString();
                    div7.Controls.Add(image);
                }
                div6.Controls.Add(div8);
                div6.Controls.Add(div9);
                div4.Controls.Add(div11);
                div11.Controls.Add(div12);
                div3.Controls.Add(div5);
                div3.Controls.Add(div6);
                div2.Controls.Add(div3);
                div2.Controls.Add(div4);
                div1.Controls.Add(div2);
            }
            else if (durum == "Client Auction kartları Göster")
            {
                string arkaBaslik = onBaslik;
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "artboard";
                div1.ID = "div" + id;

                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "card";
                div2.Attributes["runat"] = "server";
                div2.Attributes["data-myid"] = id;

                HtmlGenericControl div3 = new HtmlGenericControl("div");
                div3.Attributes["class"] = "card__side card__side--back";

                HtmlGenericControl div4 = new HtmlGenericControl("div");
                div4.Attributes["class"] = "card__side card__side--front";

                HtmlGenericControl div5 = new HtmlGenericControl("div");
                div5.Attributes["class"] = "card__cover";

                HtmlGenericControl div6 = new HtmlGenericControl("div");
                div6.Attributes["class"] = "card__details";

                HtmlGenericControl h1 = new HtmlGenericControl("h4");
                h1.Attributes["class"] = "card__heading";

                HtmlGenericControl span1 = new HtmlGenericControl("span");
                span1.Attributes["class"] = "card__heading-span";
                span1.InnerText = arkaBaslik;

                HtmlGenericControl div7 = new HtmlGenericControl("div");
                div7.Attributes["class"] = "resimlerArka";

                HtmlGenericControl div8 = new HtmlGenericControl("div");
                div8.Attributes["class"] = "sonTeklif";
                div8.InnerText = arkaSonTeklif;

                HtmlGenericControl div9 = new HtmlGenericControl("div");
                div9.Attributes["class"] = "aciklama";
                div9.InnerText = arkaAciklama;

                HtmlGenericControl div11 = new HtmlGenericControl("div");
                div11.Attributes["class"] = "card__theme";

                HtmlGenericControl div12 = new HtmlGenericControl("div");
                div12.Attributes["class"] = "card__theme-box";

                HtmlGenericControl div13 = new HtmlGenericControl("div");
                div13.Attributes["class"] = "resimler";

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                p1.Attributes["class"] = "card__title";
                p1.InnerText = onBaslik;

                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p2.Attributes["class"] = "card__subject";
                p2.InnerText = onTarihFiyat;

                HtmlGenericControl div14 = new HtmlGenericControl("div");
                div14.Attributes["class"] = "sagOn";
                div14.InnerText = onBitisTarih;

                HtmlGenericControl div15 = new HtmlGenericControl("div");
                div15.Attributes["class"] = "solOn";
                div15.InnerText = onSatanKisi;

                UpdatePanel update = new UpdatePanel();
                update.Attributes["runat"] = "server";
                AsyncPostBackTrigger asyncPostBackTrigger = new AsyncPostBackTrigger();
                asyncPostBackTrigger.ControlID = "time";
                asyncPostBackTrigger.EventName = "Tick";



                update.Triggers.Add(asyncPostBackTrigger);
                placeOnMe.Controls.Add(div1);
                div1.Controls.Add(div2);
                div2.Controls.Add(update);
                update.ContentTemplateContainer.Controls.Add(div3);
                update.ContentTemplateContainer.Controls.Add(div4);
                div3.Controls.Add(div5);
                div3.Controls.Add(div6);
                string onResim = arkaResimler[0];
                Image image2 = new Image();
                image2.Attributes["runat"] = "server";
                image2.CssClass = "resim";
                image2.ImageUrl = onResim.ToString();
                div13.Controls.Add(image2);
                div12.Controls.Add(div13);
                div12.Controls.Add(p1);
                div12.Controls.Add(p2);
                div12.Controls.Add(div14);
                div12.Controls.Add(div15);
                h1.Controls.Add(span1);
                div5.Controls.Add(h1);
                div6.Controls.Add(div7);
                for (int i = 0; i < arkaResimler.Count; i++)
                {
                    Image image = new Image();
                    //image.ID = "im" + i.ToString();
                    image.Attributes["runat"] = "server";
                    image.CssClass = "resimArka";
                    image.ImageUrl = arkaResimler[i].ToString();
                    div7.Controls.Add(image);
                }
                div6.Controls.Add(div8);
                div6.Controls.Add(div9);
                div4.Controls.Add(div11);
                div11.Controls.Add(div12);
            }
            else if (durum == "Client Ürün Updatede Göster")
            {


                RadioButton radioButton = new RadioButton();
                radioButton.GroupName = "urunler";
                radioButton.Attributes["runat"] = "server";
                radioButton.Attributes["data-myid"] = id;
                radioButton.AutoPostBack = true;
                radioButton.ID = "radio" + id;
                radioButton.CheckedChanged += RadioButton_CheckedChanged;



                string arkaBaslik = onBaslik;
                HtmlGenericControl div1 = new HtmlGenericControl("div");
                div1.Attributes["class"] = "artboard";
                div1.ID = "div1" + id;
                div1.Attributes["data-myid"] = id;


                HtmlGenericControl div2 = new HtmlGenericControl("div");
                div2.Attributes["class"] = "card";
                div2.Attributes["runat"] = "server";
                div2.ID = "div2" + id;


                HtmlGenericControl div3 = new HtmlGenericControl("div");
                div3.Attributes["class"] = "card__side card__side--back";
                div3.ID = "div3" + id;

                HtmlGenericControl div4 = new HtmlGenericControl("div");
                div4.Attributes["class"] = "card__side card__side--front";
                div4.ID = "div4" + id;

                HtmlGenericControl div5 = new HtmlGenericControl("div");
                div5.Attributes["class"] = "card__cover";
                div5.ID = "div5" + id;

                HtmlGenericControl div6 = new HtmlGenericControl("div");
                div6.Attributes["class"] = "card__details";
                div6.ID = "div6" + id;

                HtmlGenericControl h1 = new HtmlGenericControl("h4");
                h1.Attributes["class"] = "card__heading";
                h1.ID = "h1" + id;

                HtmlGenericControl span1 = new HtmlGenericControl("span");
                span1.Attributes["class"] = "card__heading-span";
                span1.InnerText = arkaBaslik;
                span1.ID = "span1" + id;


                HtmlGenericControl div7 = new HtmlGenericControl("div");
                div7.Attributes["class"] = "resimlerArka";
                div7.ID = "div7" + id;

                HtmlGenericControl div8 = new HtmlGenericControl("div");
                div8.Attributes["class"] = "sonTeklif";
                div8.InnerText = arkaSonTeklif;
                div8.ID = "div8" + id;

                HtmlGenericControl div9 = new HtmlGenericControl("div");
                div9.Attributes["class"] = "aciklama";
                div9.InnerText = arkaAciklama;
                div9.ID = "div9" + id;

                HtmlGenericControl div11 = new HtmlGenericControl("div");
                div11.Attributes["class"] = "card__theme";
                div11.ID = "div11" + id;

                HtmlGenericControl div12 = new HtmlGenericControl("div");
                div12.Attributes["class"] = "card__theme-box";
                div12.ID = "div12" + id;

                HtmlGenericControl div13 = new HtmlGenericControl("div");
                div13.Attributes["class"] = "resimler";
                div13.ID = "div13" + id;

                HtmlGenericControl p1 = new HtmlGenericControl("p");
                p1.Attributes["class"] = "card__title";
                p1.InnerText = onBaslik;
                p1.ID = "p1" + id;

                HtmlGenericControl p2 = new HtmlGenericControl("p");
                p2.Attributes["class"] = "card__subject";
                p2.InnerText = onTarihFiyat;
                p2.ID = "p2" + id;


                HtmlGenericControl div14 = new HtmlGenericControl("div");
                div14.Attributes["class"] = "sagOn";
                div14.InnerText = onBitisTarih;
                div14.ID = "div14" + id;

                HtmlGenericControl div15 = new HtmlGenericControl("div");
                div15.Attributes["class"] = "solOn";
                div15.InnerText = onSatanKisi;
                div15.ID = "div15" + id;


                UpdatePanel update = new UpdatePanel();
                update.Attributes["runat"] = "server";
                AsyncPostBackTrigger asyncPostBackTrigger = new AsyncPostBackTrigger();
                asyncPostBackTrigger.ControlID = "radio" + id;
                asyncPostBackTrigger.EventName = "CheckedChanged";

                Panel panel = new Panel();
                panel.ID = "panel" + id;
                panel.Attributes["runat"] = "server";
                panel.Visible = false;

                Label lblBaslik = new Label();
                lblBaslik.ID = "lblBaslik" + id;
                lblBaslik.Attributes["runat"] = "server";
                lblBaslik.Text = "Başlık: ";

                TextBox txtBaslik = new TextBox();
                txtBaslik.ID = "txtBaslik" + id;
                txtBaslik.Attributes["runat"] = "server";

                Label lblBasFiyat = new Label();
                lblBasFiyat.ID = "lblBasFiyat" + id;
                lblBasFiyat.Attributes["runat"] = "server";
                lblBasFiyat.Text = "Başlangıç Fiyat: ";

                TextBox txtBasFiyat = new TextBox();
                txtBasFiyat.ID = "txtBasFiyat" + id;
                txtBasFiyat.Attributes["runat"] = "server";

                Label lblBasTarih = new Label();
                lblBasTarih.ID = "lblBasTarih" + id;
                lblBasTarih.Attributes["runat"] = "server";
                lblBasTarih.Text = "Başlangıç Tarih: ";

                TextBox txtBasTarih = new TextBox();
                txtBasTarih.ID = "txtBasTarih" + id;
                txtBasTarih.Attributes["runat"] = "server";

                Label lblBitTarih = new Label();
                lblBitTarih.ID = "lblBitTarih" + id;
                lblBitTarih.Attributes["runat"] = "server";
                lblBitTarih.Text = "Bitiş Tarih: ";

                TextBox txtBitTarih = new TextBox();
                txtBitTarih.ID = "txtBitTarih" + id;
                txtBitTarih.Attributes["runat"] = "server";

                Label lblAciklama = new Label();
                lblAciklama.ID = "lblAciklama" + id;
                lblAciklama.Attributes["runat"] = "server";
                lblAciklama.Text = "Açıklama: ";

                TextBox txtAciklama = new TextBox();
                txtAciklama.ID = "txtAciklama" + id;
                txtAciklama.Attributes["runat"] = "server";

                FileUpload fileUpload = new FileUpload();
                fileUpload.ID = "fu" + id;
                fileUpload.Attributes["runat"] = "server";
                fileUpload.AllowMultiple = true;
                fileUpload.Attributes["accept"] = ".png,.jpg,.jpeg";


                Button btnUpdate = new Button();
                btnUpdate.ID = "btnUpdate" + id;
                btnUpdate.Attributes["runat"] = "server";
                btnUpdate.Text = "Güncelle";
                btnUpdate.Click += BtnUpdate_Click;

                panel.Controls.Add(lblBaslik);
                panel.Controls.Add(txtBaslik);

                panel.Controls.Add(lblBasFiyat);
                panel.Controls.Add(txtBasFiyat);

                panel.Controls.Add(lblBasTarih);
                panel.Controls.Add(txtBasTarih);

                panel.Controls.Add(lblBitTarih);
                panel.Controls.Add(txtBitTarih);

                panel.Controls.Add(lblAciklama);
                panel.Controls.Add(txtAciklama);

                panel.Controls.Add(fileUpload);

                panel.Controls.Add(btnUpdate);





                update.Triggers.Add(asyncPostBackTrigger);
                placeOnMe.Controls.Add(radioButton);
                placeOnMe.Controls.Add(update);
                update.ContentTemplateContainer.Controls.Add(div1);
                update.ContentTemplateContainer.Controls.Add(panel);

                string onResim = arkaResimler[0];
                Image image2 = new Image();
                image2.Attributes["runat"] = "server";
                image2.CssClass = "resim";
                image2.ImageUrl = onResim.ToString();
                div13.Controls.Add(image2);
                div12.Controls.Add(div13);
                div12.Controls.Add(p1);
                div12.Controls.Add(p2);
                div12.Controls.Add(div14);
                div12.Controls.Add(div15);
                h1.Controls.Add(span1);
                div5.Controls.Add(h1);
                div6.Controls.Add(div7);
                for (int i = 0; i < arkaResimler.Count; i++)
                {
                    Image image = new Image();
                    //image.ID = "im" + i.ToString();
                    image.Attributes["runat"] = "server";
                    image.CssClass = "resimArka";
                    image.ImageUrl = arkaResimler[i].ToString();
                    div7.Controls.Add(image);
                }
                div6.Controls.Add(div8);
                div6.Controls.Add(div9);
                div4.Controls.Add(div11);
                div11.Controls.Add(div12);
                div3.Controls.Add(div5);
                div3.Controls.Add(div6);
                div2.Controls.Add(div3);
                div2.Controls.Add(div4);
                div1.Controls.Add(div2);
            }


        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            string productID = btn.ID.Substring(9);
            foreach (var item in placeOnMe.Controls)
            {
                if (item is UpdatePanel)
                {
                    foreach (var c in ((UpdatePanel)item).ContentTemplateContainer.Controls)
                    {
                        if (c is Panel)
                        {
                            var pnl = ((UpdatePanel)item).FindControl("panel" + productID);
                            List<string> degerler = new List<string>();
                            foreach (var items in pnl.Controls)
                            {
                                if (items is TextBox)
                                {
                                    if (((TextBox)items).ID == "txtBaslik" + productID)
                                    {
                                        degerler.Add(((TextBox)items).Text);

                                    }
                                    else if (((TextBox)items).ID == "txtBasFiyat" + productID)
                                    {
                                        degerler.Add(((TextBox)items).Text);
                                    }
                                    else if (((TextBox)items).ID == "txtBasTarih" + productID)
                                    {
                                        degerler.Add(((TextBox)items).Text);
                                    }
                                    else if (((TextBox)items).ID == "txtBitTarih" + productID)
                                    {
                                        degerler.Add(((TextBox)items).Text);
                                    }
                                    else if (((TextBox)items).ID == "txtAciklama" + productID)
                                    {
                                        degerler.Add(((TextBox)items).Text);
                                    }

                                }
                            }
                            baglanti.UpdateClientProducts(productID, degerler);
                        }

                    }
                }
            }
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            var mySession = HttpContext.Current.Session["LoginID"].ToString();
            RadioButton btn = sender as RadioButton;
            string productID = btn.ID.Substring(5);
            liste = baglanti.UserUrunleriGuncelle(mySession);

            foreach (var item in placeOnMe.Controls)
            {
                if (item is UpdatePanel)
                {
                    foreach (var c in ((UpdatePanel)item).ContentTemplateContainer.Controls)
                    {
                        if (c is Panel)
                        {
                            ((Panel)c).Visible = false;
                            var pnl = ((UpdatePanel)item).FindControl("panel" + productID);

                            if (btn.Checked)
                            {
                                pnl.Visible = true;
                                foreach (var items in pnl.Controls)
                                {
                                    if (items is TextBox)
                                    {
                                        if (((TextBox)items).ID == "txtBaslik" + productID)
                                        {
                                            for (int i = 0; i < liste.Count; i++)
                                            {

                                                if (liste[i].id == Convert.ToInt32(productID))
                                                {
                                                    ((TextBox)items).Text = liste[i].baslik;
                                                }
                                            }

                                        }
                                        else if (((TextBox)items).ID == "txtBitTarih" + productID)
                                        {
                                            for (int i = 0; i < liste.Count; i++)
                                            {
                                                if (liste[i].id == Convert.ToInt32(productID))
                                                {
                                                    ((TextBox)items).Text = liste[i].bitTarih.ToString();
                                                }
                                            }
                                        }
                                        else if (((TextBox)items).ID == "txtAciklama" + productID)
                                        {
                                            for (int i = 0; i < liste.Count; i++)
                                            {
                                                if (liste[i].id == Convert.ToInt32(productID))
                                                {
                                                    ((TextBox)items).Text = liste[i].aciklama.ToString();
                                                }
                                            }
                                        }
                                        else if (((TextBox)items).ID == "txtBasFiyat" + productID)
                                        {
                                            for (int i = 0; i < liste.Count; i++)
                                            {
                                                if (liste[i].id == Convert.ToInt32(productID))
                                                {
                                                    ((TextBox)items).Text = liste[i].basFiyat.ToString();
                                                }
                                            }
                                        }
                                        else if (((TextBox)items).ID == "txtBasTarih" + productID)
                                        {
                                            for (int i = 0; i < liste.Count; i++)
                                            {
                                                if (liste[i].id == Convert.ToInt32(productID))
                                                {
                                                    ((TextBox)items).Text = liste[i].basTarih.ToString();
                                                }
                                            }
                                        }

                                    }
                                }
                            }

                        }

                    }
                }
            }
        }
    }
}