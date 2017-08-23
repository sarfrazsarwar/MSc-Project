<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Programing.aspx.cs" Inherits="Data_analytic.Programing" MaintainScrollPositionOnPostback="true" enableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server" >
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
                       $("#progressbar").progressbar("value", 16.66);
                       clearInterval(intervalID);

                   }
               });
               return false;
           });
       });
       function updateProgress() {
           var value = $("#progressbar").progressbar("option", "value");
           if (value < 15) {
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
 
   <div  style="margin-left:100px;">
   <h3>Programing Domain:</h3>
   <h4 style="font-weight:lighter"> &nbsp Plese Select the Programing Information </h4>
   </div>
<div style="margin-top:20px"></div>
<asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
   <%-- <asp:Panel ID="Panel1" runat="server">--%>
   <div style="margin-left:100px;">
       <asp:GridView ID="PRO_GD" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="false" Height="108px" Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" >
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Programing" HtmlEncode="False" ItemStyle-Width="300px">
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
                           GroupName="InfoGroup" Width="100"  TextAlign="Left" AutoPostBack="false" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Bignner">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector1" runat="server" GroupName="InfoGroup" 
                           Width="100" AutoPostBack="false" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Intermedite">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector2" runat="server" GroupName="InfoGroup" 
                           Width="100" AutoPostBack="false" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Expert">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector3" runat="server" GroupName="InfoGroup" 
                           Width="100" AutoPostBack="false" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
</div>
 </ContentTemplate>
 
 <%--<Triggers>
         <asp:AsyncPostBackTrigger ControlID="PRO_GD"  EventName="OnSelectedIndexChanged"/>
         <asp:AsyncPostBackTrigger ControlID="PRO_GD" EventName=" OnRowDataBound"  />
     </Triggers>--%>
 </asp:UpdatePanel>
 <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<br />
<br />
    <div style=" float:right; margin-right:6%">
    <asp:Button ID="Button1" runat="server" Text="Reset"  
            Height="43px" style="margin-left: 0px" Width="146px"   
            onclick="Button1_Click" BackColor="#55a6dd" BorderStyle="Solid" 
            BorderColor="#666768"  />
     <asp:Button ID="NEXT" runat="server" Text="Next"  onclick="NEXT_Click"
            Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid"    />
     </div>
   <%--CssClass="btnstyle1" CssClass="Nextstyle"</asp:Panel>--%>
</asp:Content>
