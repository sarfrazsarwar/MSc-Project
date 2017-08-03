<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mathmetic.aspx.cs" Inherits="Data_analytic.Mathmetic" enableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
   <div> <asp:Label ID="Label1" runat="server" Text="Mathmetic Aplitude" 
           Font-Size="Medium" Font-Bold="True"></asp:Label> 
           <h4>Plese Select the Mathmetic Information </h4> 
           <br />
           <%-- oncheckedchanged="CHK_TOOL_CheckedChanged"--%>
       <%--<asp:Literal ID="Literal1" runat="server" Text="Level">--%><%--AutoPostBack="true"--%>
  <%-- <asp:RadioButton ID="RBT_Noexperience" Text="No experience "  runat="server" Checked="true" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_NOVOICE" Text="Novice" runat="server"  GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Intermediate" Text="Intermediate" runat="server"  GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Expert" Text="Expert" runat="server"  GroupName="ToolGroup"/>--%>
  <%-- </asp:Literal>--%>
   
   </div>
<div style="margin-top:20px"></div>
    <asp:Panel ID="Panel1" runat="server">
      <asp:GridView ID="MATH_GD" runat="server" AutoGenerateColumns="False"
   
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
<div style="margin-top:12px">

<asp:Label ID="LBL_RESEARCH" runat="server" Text="Research Experience" 
        Font-Size="Medium" Font-Bold="True"></asp:Label> 
<h4>Plese Select the Research/Experience Information </h4>
<br />

       <asp:GridView ID="DG_RESEAECH" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="50px" Width="777px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound1" OnSelectedIndexChanged = "OnSelectedIndexChanged1">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Research / Expriance" HtmlEncode="False" ItemStyle-Width="300px">
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
                       <asp:RadioButton ID="RowSelector4" runat="server" Checked="true" 
                           GroupName="InfoGroup1" Width="100"  TextAlign="Left" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Bignner">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector5" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Intermedite">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector6" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Expert">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector7" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <RowStyle Height="10px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView> 
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
 <%--<asp:RadioButton ID="RBT_R_NOEXP" Text="No experience " runat="server" Checked="true" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_NOvice" Text="Novice" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Inter" Text="Intermediate" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Expert" Text="Expert" runat="server" GroupName="REXP"/>--%>

 </div>
 <br />
      <div style="margin-left:55%">
     <asp:Button ID="Pre" runat="server" Text="Pre" onclick="Pre_Click" />
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click" />
     </div>
    </asp:Panel>
</asp:Content>
