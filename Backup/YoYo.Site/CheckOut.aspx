﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CheckOut.aspx.cs" Inherits="WebApplication4.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <asp:ListView ID="ListView_Products" runat="server" DataKeyNames="id" GroupItemCount="4">
        <EmptyDataTemplate>
            <table id="Table1" runat="server">
                <tr>
                    <td>
                        No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td id="Td1" runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server">
                </td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td id="Td2" runat="server">
                <table border="0" width="170">
                    <tr>
                        <td>
                            <tr>
                                <a href='foto.aspx?productID=<%# Eval("id") %>'>
                                    <image src='<%# Eval("PictureBig") %>' width="150" height="280" border="0">
                                </a>
                                <div style="font-size: xx-small">
                                    <a href='ProductDetails.aspx?productID=<%# Eval("id") %>'><span class="ProductListHead">
                                        <%# Eval("Name")%>
                                    </span>
                                        <br>
                                    </a><span class="ProductListItem"><b>Special Price: </b>
                                        <%# Eval("Price", "{0:c}")%>
                                    </span>
                                    <br />
                                    <a href='AddToCart.aspx?productID=<%# Eval("id") %>'><span class="ProductListItem"><b>
                                        Add To Cart<b></font></span> </a>
                                </div>
                            </tr>
                        </td>
                    </tr>
                </table>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td3" runat="server">
                        <table id="groupPlaceholderContainer" runat="server">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <td id="Td4" runat="server">
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
