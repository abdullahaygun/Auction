<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AuctionClient.aspx.cs" Inherits="Acik_Artirma.Pages.Auction" %>

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

    <asp:PlaceHolder runat="server" ID="placeOnMe">
        <script type="text/javascript">
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(beginRequest);

            function beginRequest() {
                prm._scrollPosition = null;
                prm.WebForms = null;
            }
        </script>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Timer runat="server" ID="time" OnTick="time_Tick" Interval="1000"></asp:Timer>

    </asp:PlaceHolder>























    <%--   <asp:PlaceHolder runat="server" ID="placeOnMe">
        <script type="text/javascript">
            var prm = Sys.WebForms.PageRequestManager.getInstance();

            prm.add_beginRequest(beginRequest);

            function beginRequest() {
                prm._scrollPosition = null;
                prm.WebForms = null;
            }
        </script>

       


    </asp:PlaceHolder>

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Timer runat="server" ID="time" OnTick="time_Tick" Interval="1000"></asp:Timer>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" ChildrenAsTriggers="true">
        <ContentTemplate>


        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="time" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>--%>












    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:PlaceHolder runat="server" ID="placeOnMe"></asp:PlaceHolder>

        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="time" EventName="Tick" />
        </Triggers>
    </asp:UpdatePanel>--%>
</asp:Content>
