<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="ChangePasswordSuccess.aspx.cs" Inherits="Data_analytic.Account.ChangePasswordSuccess" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <h2>
        Change Password
    </h2>
    <p>
        Your password has been changed successfully.
    </p>

    <asp:Button ID="Button1" runat="server" Text="Back" Height="43px" 
        style="margin-right: 10px" Width="146px"  BackColor="#55a6dd" 
             BorderColor="#666768" BorderStyle="Solid" onclick="Button1_Click" />

</asp:Content>
