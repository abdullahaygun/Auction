<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="Acik_Artirma.Pages.AddClient" %>

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
    <script src="//code.jquery.com/jquery-1.11.2.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        function ShowImagePreview(input) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();
                reader.onload = function (e) {
                    $('#<%=ImgPrv.ClientID%>').prop('src', e.target.result)
                        .width(240)
                        .height(150);
                };
                reader.readAsDataURL(input.files[0]);
            }
        }
    </script>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table align="center" class="auto-style1">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label1" runat="server" Text="Ad:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRegisterAdminAd" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRegisterAdminAd" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Ad boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Soyad:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRegisterAdminSoyad" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtRegisterAdminSoyad" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Soyad boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Text="E-Mail:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRegisterAdminMail" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="txtRegisterAdminMail" Display="Dynamic" ErrorMessage="Mail formatınız yanlış!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtRegisterAdminMail" ErrorMessage="RequiredFieldValidator" Display="Dynamic">E-Mail boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label4" runat="server" Text="Kullanıcı Adı:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRegisterAdminUsername" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtRegisterAdminUsername" ErrorMessage="RegularExpressionValidator" ValidationExpression="^[\s\S]{6,50}$" Text="Kullanıcı Adı min 6, max 50 hane olmalıdır!" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtRegisterAdminUsername" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Kullanıcı Adı boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label5" runat="server" Text="Şifre:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:TextBox ID="txtRegisterAdminPassword" runat="server" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtRegisterAdminPassword" ErrorMessage="RegularExpressionValidator" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,50}$" Text="Şifre min 6, max 50 hane olmalıdır; en az 1 büyük ve 1 küçük harf içermelidir!" Display="Dynamic"></asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtRegisterAdminPassword" ErrorMessage="RequiredFieldValidator" Display="Dynamic">Şifre boş geçilemez!</asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label7" runat="server" Text="Profil Fotoğrafı:" CssClass="labels"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:FileUpload ID="flupImage" accept=".png,.jpg,.jpeg" runat="server" onchange="ShowImagePreview(this);" />
                </td>

                <td>
                    <asp:Image ID="ImgPrv" runat="server" Width="30%" /></td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Label ID="formRegisterAdminHata" runat="server" CssClass="labels"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align: center">
                    <asp:Button ID="btnMusteriEkle" runat="server" Text="Müşteri Ekle" OnClick="btnMusteriEkle_Click" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
