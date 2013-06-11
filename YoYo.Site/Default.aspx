<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication4._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1 {
            width: 735px;
        }

        .style2 {
            width: 178px;
        }

        .auto-style1 {
            width: 100px;
        }
    </style>
    <!-- Load local jQuery, removing access to $ (use jQuery, not $). -->
    <script src="Scripts/responsive-carousel/libs/jquery/jquery.js"></script>
    <link rel="stylesheet" href="Scripts/responsive-carousel/src/responsive-carousel.css"
        media="screen" />
    <link rel="stylesheet" href="Scripts/responsive-carousel/src/responsive-carousel.slide.css"
        media="screen" />
    <link rel="stylesheet" href="Scripts/responsive-carousel/test/assets/demostyles.css" />
    <script src="Scripts/responsive-carousel/src/responsive-carousel.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.keybd.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.touch.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.drag.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.autoinit.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main">
        <table border="0" cellspacing="0" cellpadding="10">
            <tr>
                <td class="auto-style1" valign="top">
                    <div>
                        <asp:Menu ID="menuBar" runat="server" Orientation="Vertical">
                        </asp:Menu>
                    </div>
                </td>
                <td class="style2">
                    <div class="carousel" data-transition="slide" id="carousel">
                        <div>                           
                            <img src="Images/large.jpg"    width="800"/>
                        </div>
                        <div>
                            <img src="Images/monks.jpg" width="800" />
                        </div>
                        <div>
                            <img src="Images/monkey.jpg" width="800" />
                        </div>
                    </div>
                </td>
            </tr>           
        </table>
    </div>
</asp:Content>
