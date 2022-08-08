﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UpdateProductClient.aspx.cs" Inherits="Acik_Artirma.Pages.UpdateProductClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../AuctionClient.css" rel="stylesheet" />
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
    <asp:PlaceHolder ID="placeOnMe" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    </asp:PlaceHolder>
</asp:Content>
