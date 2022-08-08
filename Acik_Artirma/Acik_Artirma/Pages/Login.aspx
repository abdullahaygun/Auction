<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Acik_Artirma.Pages.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Form-Fields.css" rel="stylesheet" />

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
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

    <asp:UpdatePanel runat="server" ID="updateService">
        
        <ContentTemplate>
            <div class="form" id="form" runat="server">

                 <asp:ImageButton ID="imgButtonBack" runat="server" ImageUrl="~/Images/icons/arrow-left-solid.svg" CssClass="iconArrow" OnClick="imgButtonBack_Click" />

                <div class="field-name active" id="field_name" runat="server">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/icons/user-solid.svg" CssClass="iconUser" />
                    <asp:TextBox ID="txtUsername" runat="server" placeholder="Kullancı Adı" CssClass="input"></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrow1" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="Image1_Click" />
                </div>

                <div class="field-password innactive" id="field_password" runat="server">
                    <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/icons/key-solid.svg" CssClass="iconPassword" />
                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Şifre" TextMode="Password" CssClass="input" ></asp:TextBox>
                    <asp:ImageButton ID="imgBtnArrow2" runat="server" ImageUrl="~/Images/icons/arrow-down-solid.svg" CssClass="iconArrow" OnClick="imgBtnArrow2_Click" />
                </div>
                <asp:Label ID="mesaj" runat="server" Text="Hata Mesajı" CssClass="mesaj" Visible="false"></asp:Label>
            </div>

        </ContentTemplate>

        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrow1" EventName="Click" />
            <asp:AsyncPostBackTrigger ControlID="imgBtnArrow2" EventName="Click" />
        </Triggers>

    </asp:UpdatePanel>

</asp:Content>
