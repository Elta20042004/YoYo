<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Registration.aspx.cs" Inherits="WebApplication4.Registration" %>
<asp:Content id="content1" ContentPlaceHolderID="headcontent" runat="server">
</asp:Content>
<asp:Content id="content2" ContentPlaceHolderID="maincontent" runat="server">
    
    
    <table>
        <tr>
            <td>First Name</td>            
            <td>
                <asp:TextBox ID="txtFirstName" runat="server"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtFirstName" ErrorMessage="Enter your name." 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>      
        </tr>
        <tr>
            <td>Last Name</td>            
            <td>
                <asp:TextBox ID="txtLastName" runat="server"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtLastName" ErrorMessage="Enter your last name. " 
                    Display="Dynamic"></asp:RequiredFieldValidator>
            </td>      
         </tr>
         <tr>
            <td>Email</td>            
            <td>
                <asp:TextBox ID="TextEmail" runat="server"> </asp:TextBox>             
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="TextEmail" ErrorMessage="Email not correctly" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    Display="Dynamic"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="TextEmail" ErrorMessage="Enter you email" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="CustomValidator1" runat="server" 
                    ControlToValidate="TextEmail" Display="Dynamic" 
                    ErrorMessage="Takoj sajt uzhe est'" 
                    onservervalidate="CustomValidator1_ServerValidate"></asp:CustomValidator>
            </td>      
        </tr>
        <tr>
            <td>Confirm Email</td>            
            <td>
                <asp:TextBox ID="TextConfirmEmail" runat="server"> </asp:TextBox>
                 <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="TextConfirmEmail" ControlToValidate="TextEmail" 
                    ErrorMessage="Check the Email!!!" Display="Dynamic"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="TextConfirmEmail" ErrorMessage="Enter you email" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                    ControlToValidate="TextConfirmEmail" ErrorMessage="email is not correctly" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    Display="Dynamic"></asp:RegularExpressionValidator>
            </td>      
        </tr>      
        <tr>
            <td>Password</td>            
            <td>
                <asp:TextBox ID="TextPassword" runat="server"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                   ControlToValidate="TextPassword" ErrorMessage="Enter you password" 
                    Display="Dynamic"></asp:RequiredFieldValidator>                          
            </td>      
        </tr>
         <tr>
            <td>Confirm Password</td>            
            <td>
                <asp:TextBox ID="TextConfirmPassword" runat="server"> </asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="TextConfirmPassword" ErrorMessage="Enter password" 
                    Display="Dynamic"></asp:RequiredFieldValidator>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" 
                    ControlToCompare="TextConfirmPassword" ControlToValidate="TextPassword" 
                    ErrorMessage="error in the password" Display="Dynamic"></asp:CompareValidator>
            </td>      
        </tr>   
         <tr>
            <td colspan="2">          
                <asp:Button OnClick="Save_Onclick" ID="ButtonSave" runat="server" Text="Save" />
               
            </td>  
        </tr>   

    </table>

</asp:Content>
