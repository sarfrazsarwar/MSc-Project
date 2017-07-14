<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mathmetic.aspx.cs" Inherits="Data_analytic.Mathmetic" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Plese select appropriate options, while considering one's own expertise in Mathematics domain </h3>
   <div> <asp:Label ID="Label1" runat="server" Text="Mathmetic Aplitude" Font-Size="X-Large" Font-Bold="True"></asp:Label>  <%-- oncheckedchanged="CHK_TOOL_CheckedChanged"--%>
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
   
    EnableViewState="False" Height="108px" Width="511px"  
            Font-Italic="False" Font-Names="Aparajita" Font-Size="X-Large"><%-- AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" --%>
   <Columns  >
        
        <asp:BoundField DataField="Academic_info" 
                HtmlEncode="False" ItemStyle-Width="400px">
        <ItemStyle Width="400px" />
        </asp:BoundField>
        <asp:BoundField DataField="AA_ID" HeaderText="AA_ID" 
                   HtmlEncode="False" ItemStyle-Width="300px" Visible="true">
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:TemplateField HeaderText="No Knowledge" 
            HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector" runat="server" 
                    GroupName="InfoGroup" Checked="true" Width="100" />
            </ItemTemplate>
                   <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>
             <asp:TemplateField  HeaderText="Novice" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector1" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
                 <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Intermedite" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector2" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Expert" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector3" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>
            <%--<asp:TemplateField HeaderText="available "> 
            <ItemTemplate>
                <asp:RadioButton ID="RBT_AVAIABLE" runat="server" 
                    GroupName="InfoGroup" Width="100" />
            </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField  HeaderText="Notavailable"> 
            <ItemTemplate>
                <asp:RadioButton ID="RBT_NOTAVAIABLE" runat="server" 
                    GroupName="InfoGroup"    Width="100" />
            </ItemTemplate>
            </asp:TemplateField>--%>
            <%-- <asp:TemplateField> Checked="true"
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector2" Text="True" runat="server" 
                    GroupName="SuppliersGroup" />
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
          


</asp:GridView>
<div style="margin-top:12px">
<h3>Plese select appropriate options, while considering one's own expertise in research domain </h3>
<asp:Label ID="LBL_RESEARCH" runat="server" Text="Research Experience" Font-Size="X-Large" Font-Bold="True"></asp:Label> 


       <asp:GridView ID="DG_RESEAECH" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="511px" 
            Font-Italic="False" Font-Names="Aparajita" Font-Size="X-Large"><%-- AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" --%>
   <Columns  >
        
        <asp:BoundField DataField="Academic_info" 
                HtmlEncode="False" ItemStyle-Width="400px">
        <ItemStyle Width="400px" />
        </asp:BoundField>
        <asp:BoundField DataField="AA_ID" HeaderText="AA_ID" 
                   HtmlEncode="False" ItemStyle-Width="300px" Visible="true">
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:TemplateField HeaderText="No Knowledge" 
            HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector4" runat="server" 
                    GroupName="InfoGroup1" Checked="true" Width="100" />
            </ItemTemplate>
                   <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>
             <asp:TemplateField  HeaderText="Novice" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector5" runat="server" 
                    GroupName="InfoGroup1"  Width="100" />
            </ItemTemplate>
                 <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Intermedite" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector6" runat="server" 
                    GroupName="InfoGroup1"  Width="100" />
            </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Expert" HeaderStyle-Font-Bold="false"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector7" runat="server" 
                    GroupName="InfoGroup1"  Width="100" />
            </ItemTemplate>
                <HeaderStyle Font-Bold="False" />
            </asp:TemplateField>

    </Columns>
          


</asp:GridView> 
 <%--<asp:RadioButton ID="RBT_R_NOEXP" Text="No experience " runat="server" Checked="true" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_NOvice" Text="Novice" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Inter" Text="Intermediate" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Expert" Text="Expert" runat="server" GroupName="REXP"/>--%>

 </div>
      
     <asp:Button ID="Pre" runat="server" Text="Pre" onclick="Pre_Click" />
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click" />
    </asp:Panel>
</asp:Content>
