<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Auction.aspx.cs" Inherits="Acik_Artirma.Pages.Auction1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../UrunKart.css" rel="stylesheet" />
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <style>
        body{
            background-color:#a35ac6;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="placeOnMe" runat="server"></asp:PlaceHolder>
    <script>
        $(document).ready(function () {

            var id;
            $('.kart').mouseover(function () {
                id = $(this).attr("data-id");
            });

            //$(".kart").mouseenter(function () {
            //    var kart = $('div[data-id="' + id + '"]');

            //    kart.animate({

            //        'backgroundColor': "#50ab89",
            //        'border-color': "#0a6c48",
            //        'border-width': "5px"
            //    }, 300);
            //});

            //$('.kart').mouseleave(function () {
            //    var kart = $('div[data-id="' + id + '"]');
            //    kart.animate({
            //        'backgroundColor': "#8cd4b9",
            //        'border-color': "#07b977",
            //        'border-width': "2px"
            //    }, 300);

            //});

            $('.kart').click(function () {

                $.ajax({//Burada clientten servera data yollamak için kullandım.
                    type: "POST",
                    url: "AuctionDetay.aspx/TestFunction",
                    contentType: "application/json; charset=utf-8",
                    data: "{'data':'" + id + "'}",
                    dataType: "json"
                });

                $(location).attr('href', "AuctionDetay.aspx");//Ürünlere tekliflerin verildiği ve daha detaylı gösterildiği yer.
            });

            var el;
            setInterval(function () {
                $('.kart').each(function () {
                    el = $(this);
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
                        if (parseInt(Math.abs(a) / 1000) <= 10) {
                            result = "Başlamasına son " + saniye + " saniye kaldı!";
                        }
                        $(this).css({ "cursor": "not-allowed", "background-color": "rgb(112 152 152)" });
                        $(this).off("click");
                        $(this).off("mouseleave");
                        $(this).off("mouseenter");

                    }
                    else if (a > 0 && b < 0) {//başladıysa
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
                        el.mouseenter(function () {
                            $(this).css("background-color", "rgb(80, 171, 137)");
                            $(this).css("border-color", "rgb(10, 108, 72)");
                            $(this).css("border-width", "5px");
                            $(this).css("cursor", "pointer");
                            $(this).click(function () {

                                $.ajax({//Burada clientten servera data yollamak için kullandım.
                                    type: "POST",
                                    url: "AuctionDetay.aspx/TestFunction",
                                    contentType: "application/json; charset=utf-8",
                                    data: "{'data':'" + id + "'}",
                                    dataType: "json"
                                });

                                $(location).attr('href', "AuctionDetay.aspx");//Ürünlere tekliflerin verildiği ve daha detaylı gösterildiği yer.
                            });
                        });

                        el.mouseleave(function () {
                            $(this).css("background-color", "rgb(140, 212, 185)");
                            $(this).css("border-color", "rgb(7, 185, 119)");
                            $(this).css("border-width", "2px");
                        });

                        //el.css({ "cursor": "pointer" });
                        ////, "background-color": "rgb(140, 212, 185)"
                        //console.log("calisti..");
                        //el.on("click");
                        //el.on("mouseleave");
                        //el.on("mouseenter");

                    }
                    else if (a > 0 && b > 0) {//bittiyse
                        result = "Maalesef Bitti!";
                        $(this).css({ "cursor": "not-allowed", "background-color": "rgb(148 152 151)" });
                        $(this).off("click");
                        $(this).off("mouseleave");
                        $(this).off("mouseenter");
                    }

                    $(this).find(".tarih").text(result);
                });
            }, 500);
        });
    </script>
</asp:Content>
