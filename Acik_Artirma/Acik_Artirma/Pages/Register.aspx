<%@ Page Title="" Language="C#" UnobtrusiveValidationMode="None" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="Acik_Artirma.Pages.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Form-Fields.css" rel="stylesheet" type="text/css" media="screen" runat="server" />
    <script class="jsbin" src="https://ajax.googleapis.com/ajax/libs/jquery/1/jquery.min.js"></script>

    <style>
        .Default {
            display: block;
        }

        .User {
            display: none;
        }

        .Admin {
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../File_Uploader.js"></script>
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>



    <asp:UpdatePanel runat="server" ID="updateService">

        <ContentTemplate>
            <div class="form" id="form" runat="server">
                <asp:ImageButton ID="imgButtonBack" runat="server" ImageUrl="~/Images/icons/arrow-left-solid.svg" CssClass="iconArrow" Visible="false" OnClick="imgButtonBack_Click" />

                <div class="field-name active" id="field_name" runat="server">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/hand-point-right-solid.svg" CssClass="iconUser" />
                    <asp:TextBox ID="txtAd" runat="server" placeholder="Adınız" CssClass="input"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowAd" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowAd_Click" />
                </div>

                <div class="field-password innactive" id="field_surname" runat="server">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/icons/hand-point-right-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtSoyad" runat="server" placeholder="Soyadınız" CssClass="input"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowSoyad" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowSoyad_Click" />
                </div>

                <div class="field-password innactive" id="field_mail" runat="server">
                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/icons/envelope-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtMail" runat="server" placeholder="E-Mail" CssClass="input"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowMail" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowMail_Click" />
                </div>

                <div class="field-password innactive" id="field_username" runat="server">
                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/icons/user-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Kullanıcı Adı" CssClass="input"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowUsername" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowUsername_Click" />
                </div>

                <div class="field-password innactive" id="field_password" runat="server">
                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/icons/key-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Şifre" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowPassword" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowPassword_Click" />
                </div>

                <div class="field-password innactive" id="field_passwordT" runat="server">
                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/icons/key-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtPasswordT" runat="server" placeholder="Şifre(Tekrar)" CssClass="input" TextMode="Password"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrowPasswordT" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrowPasswordT_Click" />
                </div>

                <div class="field-password innactive" id="field_avatar" runat="server">
                    <div class="file-upload" runat="server">
                        <button class="file-upload-btn" type="button" onclick="$('.file-upload-input').trigger( 'click' )" runat="server">Resim Ekle</button>

                        <div class="image-upload-wrap" runat="server">
                            <asp:FileUpload class="file-upload-input" type='file' onchange="readURL(this);" accept=".png,.jpg,.jpeg" ID="avatar" runat="server" />
                            <div class="drag-text" runat="server">
                                <h3>Profil Fotoğrafını Seç Sürükle ve Bırak</h3>
                            </div>
                        </div>
                        <div class="file-upload-content" runat="server">
                            <img class="file-upload-image" src="#" alt="your image" runat="server" />
                            <div class="image-title-wrap" runat="server">
                                <button type="button" onclick="removeUpload()" class="remove-image" runat="server">Sil <span class="image-title" runat="server">Yüklenen Resim</span></button>
                            </div>
                        </div>
                    </div>
                </div>
                <asp:Label ID="mesaj" runat="server" Text="Hata Mesajı" CssClass="mesaj" Visible="false"></asp:Label>

                <div class="kayitOl" runat="server" id="kayit" visible="false">
                    <asp:Label ID="Label1" runat="server" Text="Kayıt Ol" CssClass="kayit"></asp:Label>
                    <asp:ImageButton ID="imgBtnRegister" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow kayitBtn" OnClick="imgBtnRegister_Click" />
                </div>
            </div>
        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowAd" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowSoyad" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowMail" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowUsername" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowPassword" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrowPasswordT" EventName="Click" />
            <asp:PostBackTrigger ControlID="imgBtnRegister" />
        </Triggers>

    </asp:UpdatePanel>

</asp:Content>
