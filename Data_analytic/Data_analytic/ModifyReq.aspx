<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ModifyReq.aspx.cs" Inherits="Data_analytic.ModifyReq" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <%--OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged"--%>
 <table><tr><td>
<asp:GridView ID="Module_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="421px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF"  OnRowDataBound = "OnRowDataBound" 
         OnSelectedIndexChanged = "OnSelectedIndexChanged">
           
           <Columns>
               <asp:BoundField DataField="ACademic_Module" HeaderStyle-Font-Bold="false" 
                   HeaderText="Moule" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               
               <asp:BoundField DataField="AM_ID" HeaderStyle-Font-Bold="false" 
                   HeaderText="AM_ID" HtmlEncode="False" ItemStyle-Width="300px" 
                   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
               <HeaderStyle Font-Bold="False" />
                 <ItemStyle Width="300px" />
               </asp:BoundField>
               
              
                
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
</td><td>
<asp:GridView ID="REQ_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="309px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF"   style="margin-left: 159px">
           
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Academic_info" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               
               <asp:BoundField DataField="Expertise" HeaderStyle-Font-Bold="false" 
                   HeaderText="Expertise" HtmlEncode="False" ItemStyle-Width="300px" 
                    >
               <HeaderStyle Font-Bold="False" />
                 <ItemStyle Width="300px" />
               </asp:BoundField>
               
              
                
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView></td></tr></table>
<asp:Button ID="Button1" runat="server" Text="Modify Requriment" 
        onclick="Button1_Click" />
</asp:Content>

