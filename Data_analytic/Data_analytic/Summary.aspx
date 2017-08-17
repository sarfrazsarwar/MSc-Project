<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Summary.aspx.cs" Inherits="Data_analytic.Summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <script type="text/javascript" language="javascript">
         $(document).ready(function () {
             $("#progressbar").progressbar({ value: 0 });
             $(window).load(function () {
                 var intervalID = setInterval(updateProgress, 100);
                 $.ajax({
                     type: "POST",
                     url: "Default.aspx/GetText",
                     data: "{}",
                     contentType: "application/json; charset=utf-8",
                     dataType: "json",
                     async: true,
                     success: function (msg) {
                         $("#progressbar").progressbar("value", 45);
                         $("#progressbar").appendTo(15);
                         //                       $("#result").text(msg.d);
                         clearInterval(intervalID);

                     }
                 });
                 return false;
             });
         });
         function updateProgress() {
             var value = $("#progressbar").progressbar("option", "value");
             if (value < 60) {
                 $("#progressbar").progressbar("value", value + 1);
             }
         }        
        
    </script>
    <div id="progressbar";  style="width:100%"></div>
    <div id="result" style="width:100%; margin-bottom:1%"><%--<span>--%><div style="float:left;text-align:justify; width:51%">0 <span style="float:right">50</span></div> <div style="float:right;text-align:justify">100%</div><%--</span>--%></div>
<div style="margin-left:100px;">
    <asp:Label ID="LBL_Programing" runat="server" Text="Programing Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label>
        <asp:GridView ID ="GD_PRO" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
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
            Font-Size="Large"></asp:Label>
    <asp:GridView ID="GD_MATH" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
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
        Font-Bold="True" Font-Size="Large"></asp:Label>
     <asp:GridView ID="GD_RESearch" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px"
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
            Font-Size="Large"></asp:Label></div>
    <asp:GridView ID="GD_TOOL" runat="server" AutoGenerateColumns="False"
    EnableViewState="False" Height="108px" Width="698px"
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
    </div>
    <br />
     <br />
      <br />
    <div style=" float:right; margin-right:6%">
<asp:Button ID="Pre" runat="server" Text="Back" onclick="Pre_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="Submit" runat="server" Text="Submit" onclick="NEXT_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
 </div>
</asp:Content>
