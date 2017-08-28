<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="Data_analytic.Tool"  enableEventValidation="false" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
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
                       $("#progressbar").progressbar("value", 49.98);
                    
                       //                       $("#result").text(msg.d);
                       clearInterval(intervalID);

                   }
               });
               return false;
           });
       });
       function updateProgress() {
           var value = $("#progressbar").progressbar("option", "value");
           if (value < 45) {
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
<%--<asp:Label ID="Label1" runat="server" Text="Tools" 
 Font-Size="Medium" Font-Bold="True"></asp:Label> --%>
 <h3>Tools: </h3>
<h4 style="font-weight:lighter"> &nbsp Plese Select the Tool Information </h4>

</div>
<div style="margin-top:20px"></div>
    <%--<asp:Panel ID="Panel1" runat="server">--%>
   <%-- <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
</asp:ScriptManager>--%>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
      <div style="margin-left:100px;">
       <asp:GridView ID="TOOL_GV" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Tools" HtmlEncode="False" ItemStyle-Width="300px">
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
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
</div>
</ContentTemplate>
</asp:UpdatePanel>

<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<br />
 <div style=" float:right; margin-right:5%">
 <asp:Button ID="Button1" runat="server" Text="Reset"  Height="43px" 
         style="margin-left: 0px" Width="146px" onclick="Button1_Click " BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="Pre" runat="server" Text="Back" onclick="Pre_Click"  Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="NEXT" runat="server" Text="Next" onclick="NEXT_Click"  Height="43px" style="margin-right: 10px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     </div>
    <%--</asp:Panel>--%>
</asp:Content>