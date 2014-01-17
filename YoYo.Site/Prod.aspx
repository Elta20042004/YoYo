<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Prod.aspx.cs" Inherits="WebApplication4.Prod" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

    <style type="text/css">
        .style3 {
            height: 21px;
        }
    </style>
      <script type='text/javascript' src='Scripts/yoyo/Common.js' ></script>
     <script type='text/javascript'>




    </script>
    <link rel="stylesheet" type="text/css" href="Styles/Foto.css?t=<%= DateTime.Now.Ticks %>" media="screen" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="content-panel">
        <div class="content_product_images">
            <a>
                <asp:Image runat="server" ID="imageBigPicture"></asp:Image>
            </a>
        </div>
        <div class="content_product_details">
            <div class="">

                <h1>
                    <asp:Label runat="server" ID="labelProdectName"></asp:Label>
                </h1>
            </div>
            <div>
                <div>
                    <asp:Label runat="server" ID="labelDescription"></asp:Label>
                </div>
                <div class="labelDescription1">

                    <asp:Label runat="server" ID="labelDescription1"></asp:Label>

                </div>

                <div class="content_product_details div.product-buttons">
                    <asp:LinkButton Text="Add to cart" ID="lnkAddToCart" runat="server" OnClick="lnkAddToCart_Click"></asp:LinkButton>
                    <a href="JavaScript:addToCart()" id="addToCart">Add</a>
                </div>

            </div>

        </div>
    </div>
    
    <script type='text/javascript'>addToRV();</script>
        
</asp:Content>
