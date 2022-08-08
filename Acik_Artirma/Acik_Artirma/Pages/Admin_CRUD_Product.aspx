<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_CRUD_Product.aspx.cs" Inherits="Acik_Artirma.Pages.Admin_CRUD_Product" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <link href="../tablo.css" rel="stylesheet" type="text/css" />
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
      <div class="tablom">
        <asp:GridView ID="tablo" CssClass="tablo" runat="server" BackColor="White" BorderColor="#CCCCCC"
            BorderStyle="None" BorderWidth="1px" CellPadding="3" AutoGenerateColumns="false"
            ShowFooter="true" DataKeyNames="id" ShowHeaderWhenEmpty="true" OnRowCommand="tablo_RowCommand" OnRowEditing="tablo_RowEditing" OnRowCancelingEdit="tablo_RowCancelingEdit" OnRowDeleting="tablo_RowDeleting" OnRowUpdating="tablo_RowUpdating" HorizontalAlign="Center">
            <EmptyDataRowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <FooterStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" HorizontalAlign="Center" VerticalAlign="Middle" />
            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" Wrap="False" />
            <RowStyle ForeColor="#000066" HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#007DBB" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#00547E" />

            <AlternatingRowStyle Font-Bold="False" Font-Italic="False" HorizontalAlign="Center" VerticalAlign="Middle" />

            <Columns>
                <asp:TemplateField HeaderText="ID" ItemStyle-Width="100%" ControlStyle-Width="100%">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("id") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtId" Text='<%# Eval("id") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtIdFooter" runat="server" />
                    </FooterTemplate>

                    <ControlStyle Width="100%"></ControlStyle>

                    <ItemStyle Width="100%"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EKLEYEN ROL" ItemStyle-Width="100%" ControlStyle-Width="100%">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("rolEkleyen") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtrolEkleyen" Text='<%# Eval("rolEkleyen") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtrolEkleyenFooter" runat="server" />
                    </FooterTemplate>

                    <ControlStyle Width="100%"></ControlStyle>

                    <ItemStyle Width="100%"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="EKLEYEN ID">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("IDEkleyen") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtIDEkleyen" Text='<%# Eval("IDEkleyen") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtIDEkleyenFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BAŞLIK">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("baslik") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtbaslik" Text='<%# Eval("baslik") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtbaslikFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

               <asp:TemplateField HeaderText="BAŞLANGIÇ FİYAT">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("basFiyat") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtbasFiyat" Text='<%# Eval("basFiyat") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtbasFiyatFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BAŞLANGIÇ TARİH">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("basTarih") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtbasTarih" Text='<%# Eval("basTarih") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtbasTarihFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BİTİŞ TARİH">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("bitTarih") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtbitTarih" Text='<%# Eval("bitTarih") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtbitTarihFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="AÇIKLAMA">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("aciklama") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtaciklama" Text='<%# Eval("aciklama") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtaciklamaFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField ControlStyle-CssClass="test">
                    <ItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/icons/pencil.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Images/icons/delete.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />

                    </ItemTemplate>

                    <EditItemTemplate>
                        <asp:ImageButton ImageUrl="~/Images/icons/diskette.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                        <asp:ImageButton ImageUrl="~/Images/icons/cancel.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />
                    </EditItemTemplate>

                    <FooterTemplate>
                        <asp:ImageButton ImageUrl="~/Images/icons/add.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />
                    </FooterTemplate>

                    <ControlStyle CssClass="test"></ControlStyle>

                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblBasariMesaj" ForeColor="Green" runat="server" />
        <br />
        <asp:Label ID="lblHataMesaj" ForeColor="Red" runat="server" />
        <asp:FileUpload ID="avatar" runat="server" CssClass="avatarEdit" />
    </div>
</asp:Content>
