<%@ Page Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeBehind="Tool.aspx.cs" Inherits="Data_analytic.Tool"  enableEventValidation="false" %>


<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    <div id="progressbar";  style="width:100%">
    
    <div class="progBar_Fill">Programming</div> 
    <div class="progBar_Fill">Mathematics</div> 
    <div class="progBar_Fill">Tools</div> 
    <div class="progBar">Summary</div>
    <div class="progBar">Result</div>
    <div class="progBar">Final</div>
    </div>
<div style="margin-left:100px;">

 <h3>Tools Domain: </h3>
<h4 style="font-weight:lighter"> &nbsp Please select appropriate information from Tools domain </h4>

</div>
<div style="margin-top:20px"></div>

       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
      <div style="margin-left:100px;">
       <asp:GridView ID="grdTools" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px" Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Tools" HtmlEncode="False" ItemStyle-Width="300px">
               <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:BoundField DataField="AcademicInfo_ID" HeaderStyle-Font-Bold="false" 
                   HeaderText="AcademicInfo_ID" HtmlEncode="False" ItemStyle-Width="300px" 
                   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
               <HeaderStyle Font-Bold="False" />
               <ItemStyle Width="300px" />
               </asp:BoundField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="No Experience" ItemStyle-HorizontalAlign="Center">
                  <ItemTemplate>
                       <asp:RadioButton ID="RowSelector" runat="server" Checked="true" 
                           GroupName="InfoGroup" Width="100"  TextAlign="Left" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Beginner" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector1" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Intermediate" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector2" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Expert" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector3" runat="server" GroupName="InfoGroup" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" />
           <RowStyle Height="30px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
</div>
</ContentTemplate>
</asp:UpdatePanel>

<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
<br />
 <div style=" float:right; margin-right:5%">
 <asp:Button ID="btnReset" runat="server" Text="Reset"  Height="43px" 
         style="margin-left: 0px" Width="146px" onclick="btnReset_Click " BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="Pre" runat="server" Text="Back" onclick="btnPre_Click"  Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click"  Height="43px" style="margin-right: 10px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     </div>
    <%--</asp:Panel>--%>
</asp:Content>