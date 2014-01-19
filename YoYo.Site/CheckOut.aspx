<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CheckOut.aspx.cs" Inherits="WebApplication4.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .inner {
            
            width: 677px;           
            border-bottom : 1px solid #c8c8c8;
            text-align: left;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <script type='text/javascript' src='Scripts/yoyo/checkOut.js' ></script>
    <table  id="checkoutTable" >
                    
    </table>
    <script type='text/javascript'>showCheckoutBag();</script>
</asp:Content>
