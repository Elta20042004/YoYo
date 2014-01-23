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
    <link rel="stylesheet" href="Scripts/responsive-carousel/src/responsive-carousel.flip.css" media="screen">
    <script src="Scripts/responsive-carousel/src/responsive-carousel.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.keybd.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.touch.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.drag.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.autoinit.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.autoplay.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.flip.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main">
        <table style="border:0px; margin:0px" >
            <tr>
                <td class="auto-style1" valign="top" style="width:70px">
                    <div style="text-align:left; padding:0;">
                        <asp:Menu ID="menuBar" SkipLinkText="" runat="server" Orientation="Vertical">
                        </asp:Menu>
                    </div>
                </td>
                <td class="style2">
                    <div class="carousel" data-transition="flip"  data-autoplay data-interval="1000">
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
