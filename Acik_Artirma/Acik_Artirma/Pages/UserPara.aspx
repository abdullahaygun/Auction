<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UserPara.aspx.cs" Inherits="Acik_Artirma.Pages.UserPara" %>

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

        .paraBox {
            position: relative;
            text-align: center;
            display: block;
            width: 500px;
            height: min-content;
            margin: 0 auto;
        }

        .btnPara {
            position: absolute;
            right: 0px;
            top: 0px;
            border: 0;
            background: #5ba40f;
            color: #fff;
            outline: none;
            margin: 0;
            padding: 0 10px;
            border-radius: 100px;
            z-index: 2;
            height: 45px;
            line-height: 45px;
        }

            .btnPara:hover {
                background-color: #75b1dc;
                box-shadow: 8px 8px 20px grey;
                cursor: pointer;
            }

        .txtPara {
            font-family: 'Lucida Sans', 'Lucida Sans Regular', 'Lucida Grande', 'Lucida Sans Unicode', Geneva, Verdana, sans-serif;
            font-size: 20px;
            width: 100%;
            border: 1px solid #ccc;
            border-radius: 100px;
            padding: 10px 100px 10px 20px;
            line-height: 1;
            box-sizing: border-box;
            outline: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:PlaceHolder ID="placeOnMe" runat="server">

        <div class="paraBox">
            <input type="text" name="para" placeholder="Yatırmak İstediğinz Değeri Giriniz.." value="" class="txtPara" />
            <label class="btnPara">YATIR</label>
        </div>

    </asp:PlaceHolder>

    <script>

        $('.btnPara').click(function () {
            var deger = $('.txtPara').val();
            console.log(deger);

            $.ajax({//Burada clientten servera data yollamak için kullandım.
                type: "POST",
                url: "UserPara.aspx/getPara",
                contentType: "application/json; charset=utf-8",
                data: "{'data':'" + deger + "'}",
                dataType: "json"
            });   
        })

    </script>
</asp:Content>
