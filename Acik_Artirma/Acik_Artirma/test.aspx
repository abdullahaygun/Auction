<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="Acik_Artirma.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="test.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
</head>
<body>
    <form id="form1" runat="server">

        <div class="kart" id="kart0" data-id="kart0" data-role="admin" data-bastarih="2021.05.16 20:00:30" data-bittarih="2021.05.16 21:00:00">

            <div class="resimBox">
                <asp:Image ID="resim" runat="server" ImageUrl="~/Images/icons/pencil.png" CssClass="resim" />
            </div>

            <div class="baslikBox">
                <label id="baslik" runat="server" class="baslik">LG G5 Telefon Temiz..</label>
            </div>

            <div class="fiyatBox">
                <label id="fiyat" runat="server" class="fiyat">1750 ₺</label>
            </div>

            <div class="tarihBox">
                <label id="tarih" runat="server" class="tarih"></label>
            </div>

        </div>

        <div class="kart" id="kart1" data-id="kart1" data-role="user" data-bastarih="2021.05.17 20:00:30" data-bittarih="2021.05.17 21:00:00">

            <div class="resimBox">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/pencil.png" CssClass="resim" />
            </div>

            <div class="baslikBox">
                <label id="Label1" runat="server" class="baslik">LG G2 Telefon Temiz..</label>
            </div>

            <div class="fiyatBox">
                <label id="Label2" runat="server" class="fiyat">750 ₺</label>
            </div>

            <div class="tarihBox">
                <label id="Label3" runat="server" class="tarih"></label>
            </div>

        </div>

    </form>

    <script>
        $(document).ready(function () {

            var id;
            $('.kart').mouseover(function () {
                id = $(this).attr("data-id");
            });

            $(".kart").mouseenter(function () {
                var kart = $('div[data-id="' + id + '"]');


                kart.animate({

                    'backgroundColor': "#50ab89",
                    'border-color': "#0a6c48",
                    'border-width': "5px"
                }, 300);
            });

            $('.kart').mouseleave(function () {
                var kart = $('div[data-id="' + id + '"]');
                kart.animate({
                    'backgroundColor': "#8cd4b9",
                    'border-color': "#07b977",
                    'border-width': "2px"
                }, 300);

            });

            $('.kart').click(function () {
                $(location).attr('href', "Auction.aspx");
            });

            setInterval(function () {
                $('.kart').each(function () {
                    var x = $(this).data("bastarih");
                    var y = $(this).data("bittarih");

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
                    if (a < 0 && b < 0) {//başlamadıysa
                        result = "Başlamasına ";
                        saniye = parseInt(Math.abs(a) / 1000) % 60;
                        dakika = parseInt((parseInt(Math.abs(a) / 1000) / 60) % 60);
                        saat = parseInt(((parseInt(Math.abs(a) / 1000) / 60) / 60) % 24);
                        gün = parseInt(((parseInt(Math.abs(a) / 1000) / 60) / 60) / 24);
                        var saniyeText = saniye + " saniye ";
                        var dakikaText = dakika + " dakika ";
                        var saatText = saat + " saat ";
                        var günText = gün + " gün ";
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
                        result += " kaldı.";
                        if (parseInt(Math.abs(b) / 1000) <= 10) {
                            result = "Başlamasına son " + saniye + " saniye kaldı!";
                        }

                    } else if (a > 0 && b < 0) {//başladıysa
                        result = "Bitmesine ";
                        saniye = parseInt(Math.abs(b) / 1000) % 60;
                        dakika = parseInt((parseInt(Math.abs(b) / 1000) / 60) % 60);
                        saat = parseInt(((parseInt(Math.abs(b) / 1000) / 60) / 60) % 24);
                        gün = parseInt(((parseInt(Math.abs(b) / 1000) / 60) / 60) / 24);
                        var saniyeText = saniye + " saniye ";
                        var dakikaText = dakika + " dakika ";
                        var saatText = saat + " saat ";
                        var günText = gün + " gün ";
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
                        result += " kaldı.";
                        if (parseInt(Math.abs(b) / 1000) <= 10) {
                            result = "Bitimine son " + saniye + " saniye kaldı!";
                        }
                    } else if (a > 0 && b > 0) {//bittiyse
                        result = "Maalesef Bitti!";
                    }

                    $(this).find(".tarih").text(result);

                });

            }, 100);
        });
    </script>
</body>
</html>
