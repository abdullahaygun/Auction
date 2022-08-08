<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Iletisim.aspx.cs" Inherits="Acik_Artirma.Pages.Iletisim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
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

        .mesajBox {
            display: block;
            position: relative;
            text-align: center;
            margin: 0 auto;
            padding-top:50px;
        }

        .mesaj {
            width: 300px;
            height: 100px;
            margin: 0 auto;
            border-radius: 10px;
            box-shadow: none;
        }

        .btnGonder {
            margin: 0 auto;
            text-align: center;
            position: absolute;
            top: 100px;
            transform: translate(10%,-50%);
            padding: 8px;
            border: 1px solid blue;
            width: max-content;
            height: max-content;
            border-radius: 25px;
            font-weight: bold;
        }

            .btnGonder:hover {
                background-color: #2b4791;
                border-radius: 30px;
                color: white;
                cursor: pointer;
                box-shadow: 8px 8px 20px blue;
            }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder runat="server" ID="placeOnMe">

        <div class="mesajBox">
            <asp:TextBox CssClass="mesaj" ID="txt" runat="server" TextMode="MultiLine" placeholder="Mesajınızı Buraya Yazınız.."></asp:TextBox>
            <label class="btnGonder">GÖNDER</label>
        </div>

        <script>

            $(document).ready(function () {

                $('.mesaj').focus(function () {
                    $(this).css("box-shadow", "8px 8px 20px blue");
                });

                $('.mesaj').blur(function () {
                    $(this).css("box-shadow", "none");
                });

                var veri = {
                    IDUser: <%=Session["LoginID"].ToString() %>,
                    mesaj: ""
                };

                $('.btnGonder').click(function () {
                    veri.mesaj = $('.mesaj').val();

                    $.ajax({//Burada clientten servera data yollamak için kullandım.
                        type: "POST",
                        url: "Iletisim.aspx/setMesaj",
                        contentType: 'application/json;charset=utf-8',
                        dataType: 'json',
                        data: JSON.stringify({ data: veri }),
                        error: function (msg) {
                            console.log(msg);
                        }
                    });
                });

                
            });


        </script>

    </asp:PlaceHolder>
</asp:Content>
