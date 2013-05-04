<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebApplication4._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
    <style type="text/css">
        .style1
        {
            width: 735px;
        }
        .style2
        {
            width: 178px;
        }
    </style>
    <!-- Load local jQuery, removing access to $ (use jQuery, not $). -->
    <script src="Scripts/responsive-carousel/libs/jquery/jquery.js"></script>
    <link rel="stylesheet" href="Scripts/responsive-carousel/src/responsive-carousel.css"
        media="screen"/>
    <link rel="stylesheet" href="Scripts/responsive-carousel/src/responsive-carousel.slide.css"
        media="screen"/>
    <link rel="stylesheet" href="Scripts/responsive-carousel/test/assets/demostyles.css"/>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.keybd.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.touch.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.drag.js"></script>
    <script src="Scripts/responsive-carousel/src/responsive-carousel.autoinit.js"></script>
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main">
        <table width="920" border="1" cellspacing="0" cellpadding="10">
            <tr bgcolor="oldlace">
                <td height="200" class="style2" valign="top">
                    <div>
                        <asp:Menu ID="menuBar" runat="server" Orientation="Vertical" Width="100%" OnMenuItemClick="menuBar_MenuItemClick">
                        </asp:Menu>
                    </div>
                </td>
                <td height="400" class="style2">
                    <div class="carousel" data-transition="slide">
                        <div>
                            <image src="Images/large.jpg" />
                        </div>
                        <div>
                            <image src="Images/monks.jpg" />
                        </div>
                        <div>
                            <image src="Images/monkey.jpg" />
                        </div>
                    </div>
                </td>
            </tr>
            <tr bgcolor="darkred">
                <td colspan="2" height="30">
                    низ сайта
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
