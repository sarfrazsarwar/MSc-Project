﻿<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="Data_analytic.Tool" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
<h3>Plese Select the Tool Information </h3>

<h3>Tool</h3>
   <div> <%--<asp:CheckBox ID="CHK_TOOL" Text="Tool" runat="server" 
           oncheckedchanged="CHK_TOOL_CheckedChanged"  AutoPostBack="True" />--%>
       <%--<asp:Literal ID="Literal1" runat="server" Text="Level">--%>
 <%--  <asp:RadioButton ID="RBT_Noexperience" Text="No experience " runat="server" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_NOVOICE" Text="Novice" runat="server" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Intermediate" Text="Intermediate" runat="server" GroupName="ToolGroup" />
   <asp:RadioButton ID="RBT_Expert" Text="Expert" runat="server" GroupName="ToolGroup"/>--%>
  <%-- </asp:Literal>--%>
   
   </div>
<div style="margin-top:20px"></div>
    <asp:Panel ID="Panel1" runat="server">
       <asp:GridView ID="TOOL_GV" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="511px"><%-- AllowPaging="true"
    OnPageIndexChanging="OnPageIndexChanging" PageSize="5" DataKeyNames="SupplierID" DataSourceID="SuppliersDataSource" --%>
    <Columns  >
        
        <asp:BoundField DataField="Academic_info" HeaderText="TOOLS" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
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
            <%-- <asp:TemplateField> 
            <ItemTemplate>
                <asp:RadioButton ID="RowSelector2" Text="True" runat="server" 
                    GroupName="SuppliersGroup" />
            </ItemTemplate>
        </asp:TemplateField>--%>
    </Columns>
          
</asp:GridView>

     <asp:Button ID="Pre" runat="server" Text="Pre" onclick="Pre_Click" />
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click" />
      
    </asp:Panel>
    </div>
</asp:Content>