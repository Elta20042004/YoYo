<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="SingIn.aspx.cs" Inherits="YoYo.Site.SingIn" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style3
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <table>
            <tr>
                <td class="style3">
                    Vvedite svoj login:
                </td>
                <td class="style3">
                    <asp:TextBox ID="txtLogin" runat="server"> </asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Vvedite svoj parol':
                </td>
                <td>
                    <asp:TextBox ID="TextParol" runat="server"> </asp:TextBox>
                </td>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="OK" onclick="Button1_Click" />
        <asp:Label Visible="false" ID="Label" runat="server" Text="Vy vveli nevernyj parol"></asp:Label>
    </div>
</asp:Content>
