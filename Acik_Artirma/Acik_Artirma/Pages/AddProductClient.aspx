<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddProductClient.aspx.cs" Inherits="Acik_Artirma.Pages.AddProductClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../AddProductForm.css" rel="stylesheet" />
    <style>
        .Default {
            display: none;
        }

        .User {
            display: block;
        }

        .Admin {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        $(document).ready(function () {

            $('.btn').click(function () {
                var $btn = $(<%= btnEkle.ClientID %>);

                $btn.click();

            });
        });
    </script>
    <div>

        <div class="form__group">
            <input type="text" class="form__field" placeholder="Başlık" id='txtBaslik' runat="server" />
            <label for="name" class="form__label">Başlık</label>
        </div>

        <div class="form__group">
            <input type="text" class="form__field" placeholder="Başlangıç Fiyat" id='txtBasFiyat' runat="server" />
            <label for="name" class="form__label">Başlangıç Fiyat</label>
        </div>

        <div class="takvimBox">
            <label>Başlangıç Tarih</label>
            <input type="datetime-local" id="basTarih" class="tarih" name="birthdaytime" runat="server">
        </div>

        <div class="takvimBox">
            <label>Bitiş Tarih</label>
            <input type="datetime-local" id="bitTarih" class="tarih" name="birthdaytime" runat="server">
        </div>

        <div class="form__group">
            <input type="text" class="form__field" placeholder="Açıklama" id='txtAciklama' runat="server" />
            <label for="name" class="form__label">Açıklama</label>
        </div>


        <label class="imageBox">
            <asp:FileUpload ID="avatar" runat="server" accept=".png,.jpg,.jpeg" AllowMultiple="true" CssClass="fileUpload" />
            <span class="text">Ürüne Ait Resimleri EKLE</span>
        </label>

        <div class="container">
            <asp:Button ID="btnEkle" runat="server" Text="Button" OnClick="btnEkle_Click" CssClass="btnEkle" />
            <a href="#" class="btn" runat="server">EKLE</a>
        </div>

        <label id="mesaj" class="mesaj" runat="server"></label>
        
    </div>
</asp:Content>
