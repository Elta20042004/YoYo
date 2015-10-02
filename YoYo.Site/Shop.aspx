<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Shop.aspx.cs" Inherits="YoYo.Site.Shop" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
    </style>
</asp:Content>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div class="main">
        <table   style="background-color:white; border:0px; margin:0px">
            <tr style="background-color:white">
                <td class="auto-style1" valign="top" style="background-color:white; width:60px; margin:0px 10px 0px 0px;">
                    <div style="text-align:left" >
                        <asp:CheckBoxList AutoPostBack="true" ID="Color" runat="server" OnSelectedIndexChanged="Color_OnSelectedIndexChanged" Width="75px" >
                            <asp:ListItem Value="145">blue</asp:ListItem>
                            <asp:ListItem Value="140">yellow</asp:ListItem>
                            <asp:ListItem Value="138">black</asp:ListItem>
                            <asp:ListItem Value="160">white</asp:ListItem>
                        </asp:CheckBoxList>
                    </div>
                </td>
                <td class="style1" valign="top">
                    <h1>
                        <asp:ListView ID="ListView_Products" runat="server" DataKeyNames="id"
                            GroupItemCount="4">
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
                                <td id="Td2" runat="server">
                                    <table border="0" ><%--width="170"--%>
                                        <tr>
                                            <td>
                                                <tr>
                                                    <a href='Prod.aspx?productID=<%# Eval("id") %>'>                                                        
                                                        <image src='Images/Products/Small/<%# Eval("Picture") %>' border="0">
                                                    </a>
                                                    <div style="font-size: xx-small" >
                                                        <a href='Prod.aspx?productID=<%# Eval("id") %>'><class="ProductListHead">
                                                            <%# Eval("Name")%>
                                                        </href>
                                                            <br>
                                                        </a><span class="ProductListItem"><b>Special Price: </b>
                                                            <%# Eval("Price", "{0:c}")%>
                                                        </span>
                                                        <br />                                              
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
                                        <td id="Td4" runat="server"></td>
                                    </tr>
                                </table>
                            </LayoutTemplate>
                        </asp:ListView>
                    </h1>
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
