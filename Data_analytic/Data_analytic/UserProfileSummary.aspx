<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserProfileSummary.aspx.cs" Inherits="Data_analytic.UserProfileSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div id="progressbar";  style="width:100%">
    
    <div class="progBar_Fill">Programming</div> 
    <div class="progBar_Fill">Math</div> 
    <div class="progBar_Fill">Tool</div> 
    <div class="progBar_Fill">Summary</div>
    <div class="progBar">Result</div>
    <div class="progBar">Final</div>
    </div>
<div style="margin-left:100px;">
    <asp:Label ID="lblpPrograming" runat="server" Text="Programming Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:GridView ID ="grdPrograming" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programming Domain" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                <%-- </Columns  >--%>
        <asp:BoundField DataField="Expertise" HeaderText="Experience Level" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
                 <RowStyle Height="20px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView> 
    
    <div style="margin-top:20px">
    <asp:Label ID="lblMath" runat="server" Text="Mathematics Domain" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
    <asp:GridView ID="grdMath" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathematics Domain" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Experience Level" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
                 <RowStyle Height="20px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
<div style="margin-top:20px">
    <asp:Label ID="lblresearch" runat="server" Text="Research Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label>
     <asp:GridView ID="grdResearch" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Research Domain" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Experience Level" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
                 <RowStyle Height="20px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
    <div style="margin-top:20px">
    <div><asp:Label ID="lblTool" runat="server" Text="Tools Domain" Font-Bold="True" 
            Font-Size="Large"></asp:Label></div>
    <asp:GridView ID="grdTools" runat="server" AutoGenerateColumns="False"
    EnableViewState="False" Height="108px" Width="698px"
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tools Domain" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Experience Level" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
                 <RowStyle Height="20px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView></div>
    </div>
    <br />
     <br />
      <br />
    <div style=" float:right; margin-right:6%">
<asp:Button ID="Pre" runat="server" Text="Back" onclick="btnPre_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="Submit" runat="server" Text="Submit" onclick="btnNext_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
 </div>
</asp:Content>
