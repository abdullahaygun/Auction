<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="Acik_Artirma.Pages.AddProductbyClient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .Default{
            display:none;
        }

        .User{
            display:none;
        }

        .Admin{
            display:block;
        }
    
        .auto-style1 {
            width: 100%;
        }

        .auto-style2 {
            width: 277px;
        }

        .labels {
            font-weight: bold;
            font-size: 30px;
        }

        .auto-style3 {
            width: 292px;
            margin-left: 80px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Başlık:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUrunEkleBaslik" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUrunEkleBaslik" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Başlık boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Başlangıç Fiyat:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUrunEkleBasFiyat" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUrunEkleBasFiyat" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Başlangıç Fiyat boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="Başlangıç Tarih:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUrunEkleBasTarih" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtUrunEkleBasTarih" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Başlangıç Tarih boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
             <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label6" runat="server" Text="Bitiş Tarih:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUrunEkleBitTarih" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtUrunEkleBitTarih" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Bitiş Tarih boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Açıklama:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtUrunEkleAciklama" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Resimler:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:FileUpload ID="flupImage" accept=".png,.jpg,.jpeg" AllowMultiple="true" runat="server" onchange="ShowImagePreview(this);" />
                </td>
                <td>
                    <asp:Image ID="ImgPrv" runat="server" Width="30%" />
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="formUrunEkleHata" runat="server" CssClass="labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnUrunEkle" runat="server" Text="Ürünü Ekle" OnClick="btnUrunEkle_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
