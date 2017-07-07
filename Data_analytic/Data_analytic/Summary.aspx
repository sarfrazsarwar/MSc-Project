<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="Data_analytic.Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LBL_Programing" runat="server" Text="Programing"></asp:Label>
        <asp:GridView ID ="GD_PRO" runat="server" AutoGenerateColumns="false">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programing" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
        </asp:GridView> 
        <asp:Label ID="LBL_MATH" runat="server" Text="Mathmetic Aplitude"></asp:Label>
    <asp:GridView ID="GD_MATH" runat="server" AutoGenerateColumns="false">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathmetic Aplitude" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
    </asp:GridView>
    <asp:Label ID="LBL_RESearch" runat="server" Text="Research"></asp:Label>
    <div><asp:Label ID="Label1" runat="server" Text="Tool"></asp:Label></div>
    <asp:GridView ID="GD_TOOL" runat="server" AutoGenerateColumns="false">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tool" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
    </asp:GridView>

<asp:Button ID="Pre" runat="server" Text="Pre" onclick="Pre_Click" />
     <asp:Button ID="Submit" runat="server" Text="Submit" onclick="NEXT_Click" />
</asp:Content>
