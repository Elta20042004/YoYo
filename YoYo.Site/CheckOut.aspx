<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CheckOut.aspx.cs" Inherits="WebApplication4.CheckOut" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ListView ID="ListView_Products" runat="server" DataKeyNames="id" GroupItemCount="4">
        <EmptyDataTemplate>
            <table id="Table1" runat="server">
                <tr>
                    <td>No data was returned.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td id="Td1" runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <%--<td id="Td2" runat="server">--%>
            <table width="900" runat="server">
                
                <tbody>
                    <tr>
                        <td>
                            <div>
                                <a href='foto.aspx?productID=<%# Eval("id") %>'>
                                    <image src='Images/Products/Icon/<%# Eval("Picture") %>' border="0">
                                </a>
                            </div>
                        </td>
                        <td>
                            <div>
                                <div id="Div1" style="font-size: xx-small" runat="server">
                                    <a href='ProductDetails.aspx?productID=<%# Eval("id") %>'><span class="ProductListHead">
                                        <%# Eval("Name")%>
                                    </span>
                                        <br>
                                </div>
                        </td>
                        <td>
                            <div>
                                </a><span class="ProductListItem"><b>Special Price: </b>
                                    <%# Eval("Price", "{0:c}")%>
                                </span>
                                <br />
                                <asp:Button ID="Button1" runat="server" Text="Remove"
                                    CommandName="Remove" CommandArgument='<%# Eval("id") %>'
                                    OnCommand="Remove_Command" />
                            </div>
                        </td>
                        <td>
                            <div>
                                </a><span class="ProductListItem">
                                    <%# Eval("Quantity", "{0:c}")%>
                                </span>
                            </div>

                        </td>
                    </tr>

                </tbody>
            </table>
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
                    <td id="Td4" runat="server"></td>
                </tr>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
