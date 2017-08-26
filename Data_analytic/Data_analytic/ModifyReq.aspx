<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyReq.aspx.cs" Inherits="Data_analytic.ModifyReq" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style2
        {
            width: 496px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%--OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged"--%>
 <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
<div style="margin-left:68px"><h3> Accadmic Module Requirment</h3></div>
 <table style="margin-left:65px"><tr><td valign="top">
 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
    
<asp:GridView ID="Module_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="194px" Width="421px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF"  OnRowDataBound = "OnRowDataBound" 
         OnSelectedIndexChanged = "OnSelectedIndexChanged">
           
           <Columns>
               <asp:BoundField DataField="ACademic_Module" HeaderStyle-Font-Bold="false" 
                   HeaderText="Moule" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium" Height="18px"/>
               <ItemStyle Width="300px" />
               </asp:BoundField>
               
               <asp:BoundField DataField="AM_ID" HeaderStyle-Font-Bold="false" 
                   HeaderText="AM_ID" HtmlEncode="False" ItemStyle-Width="300px" 
                   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
               <HeaderStyle Font-Bold="False" />
                 <ItemStyle Width="300px" />
               </asp:BoundField>
               
              
                
           </Columns>
           <RowStyle cssclass="RowStyle" />
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px"/>
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>

</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
</td>


<td class="style2" valign="top" >
<asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>

      <div style="margin-left:40px">
<asp:GridView ID="REQ_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="300px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF"   >
           
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Academic_info" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium"  Height="18px"/>
               <ItemStyle Width="200px" />
               
               </asp:BoundField>
               
               <asp:BoundField DataField="Expertise" HeaderStyle-Font-Bold="false" 
                   HeaderText="Expertise" HtmlEncode="False" ItemStyle-Width="300px" 
                    >
               <HeaderStyle Font-Bold="False" />
                 <ItemStyle Width="100px" />
               </asp:BoundField>
               
              
                
           </Columns>
           <RowStyle cssclass="RowStyle" />
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView></div>
</ContentTemplate>
</asp:UpdatePanel>

</td>

</tr></table>
<br />
<br />
<div style=" float:right; margin-right:40%">
<asp:Button ID="Button1" runat="server" Text="Modify Requriment" 
        onclick="Button1_Click"  Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
             BorderColor="#666768" BorderStyle="Solid" />
 </div>
</asp:Content>

