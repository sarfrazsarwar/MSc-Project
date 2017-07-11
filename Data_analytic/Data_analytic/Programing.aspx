<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programing.aspx.cs" Inherits="Data_analytic.Programing" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h3>Plese Select the Programing Information </h3>
   <div>
   <asp:Label ID="LBL_PROG" runat="server" Text="Programing Domain" Font-Bold="True" 
           Font-Size="X-Large"></asp:Label>  
   
   <%-- <asp:CheckBox ID="CHK_PROG" Text="Tool" runat="server" 
            AutoPostBack="True" />--%><%-- oncheckedchanged="CHK_TOOL_CheckedChanged"--%>
       <%--<asp:Literal ID="Literal1" runat="server" Text="Level">--%><%--AutoPostBack="true" --%>
   <%--<asp:RadioButton ID="RBT_Noexperience" Text="No experience " runat="server"  Checked="true" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_NOVOICE" Text="Novice" runat="server" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Intermediate" Text="Intermediate" runat="server" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Expert" Text="Expert" runat="server"  GroupName="ToolGroup"/>--%>
  <%-- </asp:Literal>--%>
   
   </div>
<div style="margin-top:20px"></div>
    <asp:Panel ID="Panel1" runat="server">
       <asp:GridView ID="PRO_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="511px" Font-Bold="True" 
            Font-Italic="False" Font-Names="Aparajita" Font-Size="X-Large" 
             ShowFooter="True"><%-- AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" Visible="false"--%>
           <%--<AlternatingRowStyle BackColor="#FFFF99" BorderColor="#FFCC00" 
               BorderStyle="Outset" />--%>
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderText="Programing" 
                   HtmlEncode="False" ItemStyle-Width="300px">
                    <ItemStyle Width="300px" />
               </asp:BoundField>
                <%--</Columns>
                 <Columns>--%>
                   <asp:BoundField DataField="AA_ID" HeaderText="AA_ID" 
                   HtmlEncode="False" ItemStyle-Width="300px" Visible="true">
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:TemplateField HeaderText="Not available "> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector" runat="server" 
                    GroupName="InfoGroup" Checked="true" Width="100" />
            </ItemTemplate>
            </asp:TemplateField>
             <asp:TemplateField  HeaderText="available"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector1" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Intermedite"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector2" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField  HeaderText="Expert"> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector3" runat="server" 
                    GroupName="InfoGroup"  Width="100" />
            </ItemTemplate>
            </asp:TemplateField>
               <%-- <asp:TemplateField> Checked="true" 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector2" Text="True" runat="server" 
                    GroupName="SuppliersGroup" />
            </ItemTemplate>
        </asp:TemplateField>--%>
           </Columns>
          <%-- <RowStyle BackColor="#FFFFCC" />--%>
          
</asp:GridView>
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click" />
    </asp:Panel>
    </div>
</asp:Content>
