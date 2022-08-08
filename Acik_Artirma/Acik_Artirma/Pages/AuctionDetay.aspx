<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuctionDetay.aspx.cs" Inherits="Acik_Artirma.Pages.AuctionDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../AuctionDetay.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="placeOnMe" runat="server">
        <script>
            $(document).ready(function () {
                var id;
                $('.FooterResim').click(function () {
                    id = $(this).attr("data-index");
                    var tiklananResim = $(this);

                    var el = $('.resim[data-index="' + id + '"]');
                    $('.ResimBox').prepend(el);
                    $('.FooterResim').each(function () {
                        $(this).css({ opacity: 0.60 });
                        $(this).css({ "border": "none" });
                    });
                    tiklananResim.css({ opacity: 1 });
                    tiklananResim.css({ "border": "1px solid #417abb" });
                    tiklananResim.css({ "border-radius": "5px" });
                });
                $('.FooterResim').mouseover(function () {
                    $(this).css({ opacity: 1 });
                });

                $('.FooterResim').mouseleave(function () {
                    if ($(this).attr("data-index") != id) {
                        $(this).css({ opacity: 0.60 });
                    }
                });

                var el;
                setInterval(function () {
                    el = $('.bitisBox');
                    var x = el.data("bastarih");
                    var y = el.data("bittarih");

                    var basTarih = new Date(x);
                    var bitTarih = new Date(y);
                    var now = Date.now();
                    var a = now - basTarih;
                    var b = now - bitTarih;
                    var saniye;
                    var dakika;
                    var saat;
                    var gün;
                    var result;

                    if (a > 0 && b < 0) {//başladıysa
                        result = "Açık Artırmanın Bitimine SON ";
                        saniye = parseInt(Math.abs(b) / 1000) % 60;
                        dakika = parseInt((parseInt(Math.abs(b) / 1000) / 60) % 60);
                        saat = parseInt(((parseInt(Math.abs(b) / 1000) / 60) / 60) % 24);
                        gün = parseInt(((parseInt(Math.abs(b) / 1000) / 60) / 60) / 24);
                        var saniyeText = saniye + " SANİYE ";
                        var dakikaText = dakika + " DAKİKA ";
                        var saatText = saat + " SAAT ";
                        var günText = gün + " GÜN ";
                        if (gün == 0) {
                            günText = "";
                        }
                        if (saat == 0) {
                            saatText = "";
                        }
                        if (dakika == 0) {
                            dakikaText = "";
                        }
                        if (saniye == 0) {
                            saniyeText = "";
                        }
                        result += günText + saatText + dakikaText + saniyeText;
                        result += " Kaldı..";
                        if (parseInt(Math.abs(b) / 1000) <= 10) {
                            result = "Bitimine son " + saniye + " SANİYE kaldı!";
                        }
                    }
                    el.find(".KalanZaman").text(result);

                    //$('.tekliflerBox ul').prepend("<li class=teklifSatir>"
                    //    + "< label class=teklif>" + "12, 5" + "</label >"
                    //    + "< label class=teklifTL>₺</label >"
                    //    + "<label class=adSoyad>" + "Abdullah AYGÜN" + "</label>"
                    //    + "<label class=id data-table=" + "Users" + "><sub>(14)</sub></label>"
                    //    + "<label class=teklifTarih>" + "19.05.2021 14: 05: 24" + "</label>"
                    //    + "</li>");
                }, 1000);

                $('.btnTeklif').click(function () {
                    var teklifDeger = $('.teklifDeger').val();
                    var basFiyat = $('.basFiyat').text();
                    var sonTeklifId = $('li[class=teklifSatir] .id').first().text();
                    sonTeklifId = sonTeklifId.substring(1, sonTeklifId.length - 1);
                    var oncekiTeklifDeger = $('li[class=teklifSatir] .teklif').eq(1).text();
                    var sonTeklifDeger = $('li[class=teklifSatir] .teklif').first().text();
                    console.log(oncekiTeklifDeger+ " : "+sonTeklifDeger);
                    var girisID = <%=Session["LoginID"].ToString() %>;
                    var bakiye =<%=Session["bakiye"].ToString() %>;
                    if (teklifDeger <= basFiyat) {
                        $('.mesaj').text("Lütfen Başlangıç Fiyatından Yüksek Değer Giriniz!");
                        $('.mesajBox').css("display", "block");
                    } else if (teklifDeger <= sonTeklifDeger) {
                        $('.mesaj').text("Lütfen Verilen Son Tekliften Daha Büyük Bir Teklif Veriniz!");
                        $('.mesajBox').css("display", "block");
                    } else if (girisID == sonTeklifId) {
                        $('.mesaj').text("Art Arda Teklif Veremezsiniz!");
                        $('.mesajBox').css("display", "block");
                    } else if (bakiye < teklifDeger) {
                        //console.log(bakiye + " : " + teklifDeger);
                        $('.mesaj').text("Bakiye yetersiz!");
                    }
                    else {
                        $('.mesajBox').css("display", "none");
                        var date = new Date();
                        var time =
                            ("00" + date.getDate()).slice(-2)
                            + "." + ("00" + (date.getMonth() + 1)).slice(-2)
                            + "." + date.getFullYear() + " "
                            + ("00" + date.getHours()).slice(-2) + ":"
                            + ("00" + date.getMinutes()).slice(-2)
                            + ":" + ("00" + date.getSeconds()).slice(-2);

                        var veri = {
                            IDProduct: <%=Session["UrunID"].ToString() %>,
                            IDTeklifVeren: girisID.toString(),
                            RoleTeklifVeren: "Users",
                            teklif: teklifDeger.toString(),
                            oncekiTeklifDeger: oncekiTeklifDeger.toString(),
                            sonTeklifDeger: sonTeklifDeger.toString(),
                            teklifTarihi: time.toString()
                        };



                        $.ajax({//Burada clientten servera data yollamak için kullandım.
                            type: "POST",
                            url: "AuctionDetay.aspx/getTeklifim",
                            contentType: 'application/json;charset=utf-8',
                            dataType: 'json',
                            data: JSON.stringify({ data: veri }),
                            error: function (msg) {
                                console.log(msg);
                            }
                        });
                    }
                });
            });

        </script>

        <div class="BaslikBox">
            <label class="baslik" id="baslik" runat="server"></label>
        </div>

        <div class="ResimBox" id="ResimBox" runat="server">
        </div>
        <div class="FooterResimBox" id="FooterResimBox" runat="server">
        </div>

        <div class="bitisBox" id="bitisBox" runat="server">
            <label class="KalanZaman">
            </label>
        </div>

        <div class="mesajBox">
            <label class="mesaj"></label>
        </div>

        <div class="btnTeklifBox">
            <input type="text" name="teklif" placeholder="Teklif.." value="" class="teklifDeger" />
            <label class="btnTeklif">TEKLİF VER</label>
        </div>

        <div class="basFiyatBox">
            <label class="basFiyatStr">Başlangıç Fiyatı: </label>
            <label class="basFiyat" id="basFiyat" runat="server"></label>
            <label>₺</label>
        </div>

        <div class="satanBox">
            <label class="satanBaslik">Satıcı: </label>
            <label class="satanAdSoyad" id="satanAdSoyad" runat="server"></label>
            <label class="satanId" id="satanId" runat="server"></label>
        </div>


        <div class="tekliflerBox" id="tekliflerBox" runat="server">
            <asp:ScriptManager runat="server" />
            <asp:UpdatePanel runat="server">
                <ContentTemplate>
                    <ul id="ul" runat="server">

                        <li class="kolonBasliklar">
                            <label class="tekliflerBaslik">TEKLİFLER</label>
                            <label class="teklifVerenBaslik">TEKLİF VEREN</label>
                            <label class="teklifTarihiBaslik">TEKLİF TARİHİ</label>
                        </li>

                    </ul>
                </ContentTemplate>

                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>

        </div>

        <div class="aciklamaBox">
            <label class="aciklamaBaslik">AÇIKLAMA</label>
            <label class="aciklama" id="aciklama" runat="server">
                <%--Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.--%>
            </label>
        </div>

        <asp:Timer runat="server" ID="timer" Interval="1000" OnTick="timer_Tick"></asp:Timer>
    </asp:PlaceHolder>
</asp:Content>
