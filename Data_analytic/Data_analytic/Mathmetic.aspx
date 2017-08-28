<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Mathmetic.aspx.cs" Inherits="Data_analytic.Mathmetic" enableEventValidation="false"  %>
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
                           $("#progressbar").progressbar("value", 33.32);
                           clearInterval(intervalID);

                       }
                   });
                   return false;
               });
           });
           function updateProgress() {
               var value = $("#progressbar").progressbar("option", "value");
               if (value < 30) {
                   $("#progressbar").progressbar("value", value + 1);
               }
           }        
        
    </script>
    <div id="progressbar";  style="width:100%">
    
    <div class="progBar">Programing</div> 
    <div class="progBar">Math</div> 
    <div class="progBar">Tool</div> 
    <div class="progBar">Summary</div>
    <div class="progBar">Result</div>
    <div class="progBar">Final</div>
    </div>
    
    
     <div style="margin-left:100px;">
      <%--<asp:Label ID="Label1" runat="server" Text="Mathmetic Aplitude" 
           Font-Size="Medium" Font-Bold="True"></asp:Label>--%> 
           <h3>Mathmetic Aplitude:</h3>
           <h4 style="font-weight:lighter">Plese Select the Mathmetic Information </h4> 
   </div>
<div style="margin-top:5px"></div>
   <%-- <asp:Panel ID="Panel1" runat="server">--%>
   <%--<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>--%>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <div style="margin-left:40px;">
      <asp:GridView ID="MATH_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px"  Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" 
                OnSelectedIndexChanged = "OnSelectedIndexChanged" 
                style="margin-left: 67px">
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
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
<div style="margin-top:12px">
    <div style="margin-left:100px;">
<%--<asp:Label ID="LBL_RESEARCH" runat="server" Text="Research Experience" 
        Font-Size="Medium" Font-Bold="True"></asp:Label>--%> 
        <h3>Research Experience:</h3>
<h4 style="font-weight:lighter"> &nbsp Plese Select the Research/Experience Information </h4>
</div>
<br />
<%--<asp:ScriptManager ID="ScriptManager2" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>--%>
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <div style="margin-left:41px;">
       <asp:GridView ID="DG_RESEAECH" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="50px"  Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound1" 
                OnSelectedIndexChanged = "OnSelectedIndexChanged1" style="margin-left: 67px">
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
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
 <%--<asp:RadioButton ID="RBT_R_NOEXP" Text="No experience " runat="server" Checked="true" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_NOvice" Text="Novice" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Inter" Text="Intermediate" runat="server" GroupName="REXP" />
   <asp:RadioButton ID="RBT_R_Expert" Text="Expert" runat="server" GroupName="REXP"/>--%>

 </div>
 <br />
      <div style=" float:right; margin-right:4%">
      <asp:Button ID="Button1" runat="server" Text="Reset"  Height="43px" 
              style="margin-left: 0px" Width="146px" onclick="Button1_Click" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="Pre" runat="server" Text="Back" onclick="Pre_Click"  Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid"   />
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click"  Height="43px" style="margin-right: 10px" Width="146px"  BackColor="#55a6dd" 
             BorderColor="#666768" BorderStyle="Solid"  />
     </div>
<%--    </asp:Panel>--%>
</asp:Content>
