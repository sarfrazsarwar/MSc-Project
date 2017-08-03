<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="Data_analytic.Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="LBL_Programing" runat="server" Text="Programing Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:GridView ID ="GD_PRO" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="774px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programing" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                <%-- </Columns  >--%>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView> 
    
    <div style="margin-top:20px">
    <asp:Label ID="LBL_MATH" runat="server" Text="Mathmetic Aplitude" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label>
    <asp:GridView ID="GD_MATH" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="774px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathmetic Aplitude" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
<div style="margin-top:20px">
    <asp:Label ID="LBL_RESearch" runat="server" Text="Research/Expriance" 
        Font-Bold="True" Font-Size="X-Large"></asp:Label>
     <asp:GridView ID="GD_RESearch" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="774px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Reserch/Expriance" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
    <div style="margin-top:20px">
    <div><asp:Label ID="Label1" runat="server" Text="Tool" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label></div>
    <asp:GridView ID="GD_TOOL" runat="server" AutoGenerateColumns="False"
    EnableViewState="False" Height="108px" Width="774px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tool" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
     <div style="margin-top:20px">
<asp:Button ID="Pre" runat="server" Text="Pre" onclick="Pre_Click" />
     <asp:Button ID="Submit" runat="server" Text="Submit" onclick="NEXT_Click" />
 </div>
</asp:Content>
