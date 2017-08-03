<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditReq.aspx.cs" Inherits="Data_analytic.EditReq"  enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



<asp:Label ID="Label1" runat="server" Text="" Font-Bold="True" Font-Size="Medium"></asp:Label>
<br />
<br />
<br />
<asp:GridView ID="Modyfy_GD" runat="server" AutoGenerateColumns="False"

    EnableViewState="False" Height="108px" Width="774px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Math" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:BoundField DataField="AA_ID" HeaderStyle-Font-Bold="false" 
                   HeaderText="AA_ID" HtmlEncode="False" ItemStyle-Width="300px" 
                   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
               <HeaderStyle Font-Bold="False" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="No Expriance">
                  <ItemTemplate>
                       <asp:RadioButton ID="RowSelector" runat="server" Checked="true" 
                           GroupName="InfoGroup" Width="100"  TextAlign="Left" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Bignner">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector1" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Intermedite">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector2" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Expert">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector3" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
<asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>


<br />

<br />
<asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />

</asp:Content>
