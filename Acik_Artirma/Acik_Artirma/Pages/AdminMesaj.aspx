<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminMesaj.aspx.cs" Inherits="Acik_Artirma.Pages.AdminMesaj" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <style>
        .Default {
            display: none;
        }

        .User {
            display: none;
        }

        .Admin {
            display: block;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server">

         <ul class="ul" id="ul" runat="server">

        <asp:ScriptManager runat="server" />

            <asp:UpdatePanel runat="server" ID="update">
                <ContentTemplate>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
                </Triggers>
            </asp:UpdatePanel>

        </ul>
         <asp:Timer Interval="1000" ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>

        <script>
        </script>

    </asp:PlaceHolder>
</asp:Content>
