<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="Acik_Artirma.Pages.UserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
  <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../Form-Fields.css" rel="stylesheet" />
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
            $('.avatarDegistir').mouseenter(function () {
                var $img = $('.myAvatar');
                $img.animate({

                    'backgroundColor': "aqua",
                    'border-color': "red",
                    'border-width':"4px"
                }, 500);

            });

            $('.avatarDegistir').mouseleave(function () {
                var $img = $('.myAvatar');
                $img.animate({

                    'backgroundColor': "transparent",
                    'border-color': "#c5c054",
                    'border-width': "2px"
                }, 500);

            });
        });

    </script>
    <div id="form" class="myProfileForm" runat="server">
        <hr class="line">
        <div class="avatarSol">

            <div class="field-avatar">
                <asp:Image ID="avatar" runat="server" ImageUrl="~/profil.jpeg" CssClass="myAvatar" />
                <asp:FileUpload ID="avatarDegistir" runat="server" CssClass="avatarDegistir" accept=".png,.jpg,.jpeg" />
            </div>

            <div class="field-id">
                <asp:Label ID="lbl1" CssClass="avatarLabels" runat="server" Text="ID"></asp:Label>
                <asp:Label ID="lblId" CssClass="lblId" runat="server" Text="100"></asp:Label>
            </div>

            <div class="field-username">
                <asp:Label ID="Label1" CssClass="avatarLabels" runat="server" Text="Kullanıcı Adı"></asp:Label>
                <asp:Label ID="lblUsername" CssClass="lblUsername" runat="server" Text="deneme"></asp:Label>
            </div>

            <div class="field-mail">
                <asp:Label ID="Label2" CssClass="avatarLabels" runat="server" Text="E-Mail"></asp:Label>
                <asp:Label ID="lblMail" runat="server" CssClass="lblMail" Text="deneme@gmail.com"></asp:Label>
            </div>

            <div class="field-bakiye">
                <asp:Label ID="Label3" CssClass="avatarLabels" runat="server" Text="Bakiye"></asp:Label>
                <asp:Label ID="lblBakiye" runat="server" CssClass="lblBakiye" Text="150"></asp:Label>
            </div>

        </div>

        <div class="avatarSag">

            <div class="field-Ad">
                <asp:Label ID="Label4" CssClass="avatarLabels" runat="server" Text="Ad"></asp:Label>
                <asp:TextBox ID="txtAd" CssClass="txtIsim" runat="server" placeholder="Adım"></asp:TextBox>
            </div>

            <div class="field-Soyad">
                <asp:Label ID="Label5" CssClass="avatarLabels" runat="server" Text="Soyad"></asp:Label>
                <asp:TextBox ID="txtSoyad" CssClass="txtSoyad" runat="server" placeholder="Soyadım"></asp:TextBox>
            </div>

            <div class="field-PasswordEski">
                <asp:Label ID="Label6" CssClass="avatarLabels" runat="server" Text="Şifre"></asp:Label>
                <asp:TextBox ID="txtPasswordEski" CssClass="txtPassword" runat="server" placeholder="Eski Şifrem" TextMode="Password"></asp:TextBox>

            </div>

            <div class="field-PasswordYeni">
                <asp:Label ID="Label7" CssClass="avatarLabels" runat="server" Text="Yeni Şifre"></asp:Label>
                <asp:TextBox ID="txtPasswordYeni" CssClass="txtPasswordY" runat="server" placeholder="Yeni Şifrem" TextMode="Password"></asp:TextBox>
            </div>

            <div class="field-Kaydet">
                <asp:ImageButton ID="imgBtnKaydet" CssClass="imgBtnKaydet" runat="server" ImageUrl="~/Images/icons/save-solid.svg" OnClick="imgBtnKaydet_Click" />
                <asp:Label ID="lblKaydet" CssClass="lblKaydet" runat="server" Text="Kaydet"></asp:Label>
            </div>
        </div>

    </div>
</asp:Content>
