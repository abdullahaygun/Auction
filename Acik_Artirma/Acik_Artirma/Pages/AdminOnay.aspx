<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="AdminOnay.aspx.cs" Inherits="Acik_Artirma.Pages.AdminOnay" %>

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

        * {
            margin: 0;
            padding: 0;
        }

        .ul {
            list-style: none;
            text-align: center;
            padding-top: 10px;
            padding-bottom: 10px;
        }

        .onayBox {
            border: 1px solid blue;
            width: 600px;
            border-radius: 15px;
            padding: 10px;
            margin: 0 auto;
            margin-bottom: 5px;
        }

        .adSoyad {
            font-weight: bold;
        }

        .UserID {
            font-weight: bold;
            font-size: 10px;
            margin-right: 10px;
            vertical-align: sub;
        }

        .deger {
            font-weight: bold;
            font-size: 18px;
        }

        .birim {
            margin-right: 10px;
        }

        .btnKabul {
            border: 2px solid green;
            border-radius: 25px;
            padding: 5px;
            color: #319412;
            font-weight: bold;
        }

            .btnKabul:hover {
                background-color: #31b209;
                box-shadow: 8px 8px 20px grey;
                color: black;
                cursor: pointer;
            }

        .btnRed {
            border: 2px solid red;
            border-radius: 25px;
            padding: 5px;
            color: #b32727;
            font-weight: bold;
        }

            .btnRed:hover {
                background-color: #b12222;
                box-shadow: 8px 8px 20px grey;
                color: black;
                cursor: pointer;
            }
    </style>
</asp:Content>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     

    <asp:PlaceHolder runat="server" ID="placeOnMe">
        <script> 
            $(document).ready(function () {
               

                $(document).on('click', '.btnKabul', function (e) {
                    var veri = {
                        id: "",
                        IDUser: $(this).attr("data-UserID"),
                        para: $('.deger').attr("data-Deger"),
                        onaylandıMı: "",
                        bakıldıMı: ""
                    };
                    console.log("kabul edildi" + " : " + veri.id + " : " + veri.deger);

                    $.ajax({//Burada clientten servera data yollamak için kullandım.
                        type: "POST",
                        url: "AdminOnay.aspx/Kabul",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({ data: veri }),
                        dataType: "json"
                    });
                });

                $(document).on('click', '.btnRed', function (e) {
                    var veri = {
                        id: "",
                        IDUser: $(this).attr("data-UserID"),
                        para: $('.deger').attr("data-Deger"),
                        onaylandıMı: "",
                        bakıldıMı: ""
                    };
                    console.log("reddedildi" + " : " + veri.id + " : " + veri.deger);

                    $.ajax({//Burada clientten servera data yollamak için kullandım.
                        type: "POST",
                        url: "AdminOnay.aspx/Red",
                        contentType: "application/json; charset=utf-8",
                        data: JSON.stringify({ data: veri }),
                        dataType: "json",
                        error: function (msg) {
                            console.log(msg);
                        }
                    });
                });
            });
        </script>
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
    </asp:PlaceHolder>


    <asp:Timer Interval="1000" ID="timer" runat="server" OnTick="timer_Tick"></asp:Timer>

</asp:Content>
