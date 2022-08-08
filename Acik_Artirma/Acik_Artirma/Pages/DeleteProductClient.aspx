<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DeleteProductClient.aspx.cs" Inherits="Acik_Artirma.Pages.DeleteProductClient" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../AuctionClient.css" rel="stylesheet" />
    <style>
         .Default{
            display:none;
        }

        .User{
            display:block;
        }

        .Admin{
            display:none;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server" ID="placeOnMe">
        <asp:Button ID="Button1" runat="server" Text="Sil" OnClick="btnClientUrunleriGetir_Click" />
    </asp:PlaceHolder>
    
</asp:Content>
