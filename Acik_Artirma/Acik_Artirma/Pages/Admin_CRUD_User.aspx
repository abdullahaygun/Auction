<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Admin_CRUD_User.aspx.cs" Inherits="Acik_Artirma.Pages.Admin_CRUD_User" %>

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

                <asp:TemplateField HeaderText="USERNAME" ItemStyle-Width="100%" ControlStyle-Width="100%">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("username") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUsername" Text='<%# Eval("username") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtUsernameFooter" runat="server" />
                    </FooterTemplate>

                    <ControlStyle Width="100%"></ControlStyle>

                    <ItemStyle Width="100%"></ItemStyle>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PASSWORD">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("password") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtPassword" Text='<%# Eval("password") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPasswordFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="MAIL">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("mail") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMail" Text='<%# Eval("mail") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtMailFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="PHOTO">
                    <ItemTemplate>
                        <asp:Image ID="imageItem" runat="server" ImageUrl='<%# Eval("picture") %>' CssClass="avatarEdit" Width="30px" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <label class="imageBox">
                            <asp:FileUpload ID="avatar" runat="server" accept=".png,.jpg,.jpeg" CssClass="avatarEdit"/>
                            <asp:Image ID="imageEdit" runat="server" ImageUrl='<%# Eval("picture") %>' Width="30px" />
                        </label>
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtPictureFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="BAKIYE">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("bakiye") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtBakiye" Text='<%# Eval("bakiye") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtBakiyeFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="AD">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("ad") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAd" Text='<%# Eval("ad") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtAdFooter" runat="server" />
                    </FooterTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="SOYAD">
                    <ItemTemplate>
                        <asp:Label Text='<%# Eval("soyad") %>' runat="server" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtSoyad" Text='<%# Eval("soyad") %>' runat="server" />
                    </EditItemTemplate>
                    <FooterTemplate>
                        <asp:TextBox ID="txtSoyadFooter" runat="server" />
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
