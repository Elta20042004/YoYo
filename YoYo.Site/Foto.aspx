<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Foto.aspx.cs" Inherits="WebApplication4.Foto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            height: 21px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table id="tab" border="0" width="800">
        <tr>
            <td class="style3">
                <a>
                    <asp:Image runat="server" ID="imageBigPicture" Width="90" Height="200" ></asp:Image>
                </a>
                <div style="font-size: xx-small">
                    <a>
                        <asp:Label runat="server" ID="labelProdectName"></asp:Label>
                    </a>
                    <asp:Label runat="server" ID="labelDescription"></asp:Label>
                    <asp:LinkButton Text ="Add to cart" ID ="lnkAddToCart" runat ="server" OnClick ="lnkAddToCart_Click" ></asp:LinkButton>
                    </a>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>
