<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MathematicsResearch.aspx.cs" Inherits="Data_analytic.MathematicsResearch" enableEventValidation="false"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="progressbar";  style="width:100%">
    
    <div class="progBar_Fill">Programming</div> 
    <div class="progBar_Fill">Mathematics</div> 
    <div class="progBar">Tools</div> 
    <div class="progBar">Summary</div>
    <div class="progBar">Result</div>
    <div class="progBar">Final</div>
    </div>
    
    
     <div style="margin-left:100px;">
           <h3>Mathematics Domain:</h3>
           <h4 style="font-weight:lighter">Please select appropriate information from Mathematics domain </h4> 
   </div>
<div style="margin-top:5px"></div>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <div style="margin-left:40px;">
      <asp:GridView ID="grdMath" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="108px"  Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" 
                OnSelectedIndexChanged = "OnSelectedIndexChanged" 
                style="margin-left: 67px">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Mathematics" HtmlEncode="False" ItemStyle-Width="300px">
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
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <RowStyle Height="30px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView>
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
<div style="margin-top:12px">
    <div style="margin-left:100px;"> 
        <h3>Research Domain:</h3>
<h4 style="font-weight:lighter"> &nbsp Please select appropriate information from Research domain </h4>
</div>
<br />
       <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <div style="margin-left:41px;">
       <asp:GridView ID="grdResearch" runat="server" AutoGenerateColumns="False"
   
    EnableViewState="False" Height="50px"  Width="698px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound1" 
                OnSelectedIndexChanged = "OnSelectedIndexChanged1" style="margin-left: 67px">
           <Columns>
               <asp:BoundField DataField="Academic_info" HeaderStyle-Font-Bold="false" 
                   HeaderText="Research" HtmlEncode="False" ItemStyle-Width="300px">
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
                       <asp:RadioButton ID="RowSelector4" runat="server" Checked="true" 
                           GroupName="InfoGroup1" Width="100"  TextAlign="Left" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Beginner" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector5" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Intermediate" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector6" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
               <asp:TemplateField HeaderStyle-Font-Bold="false" HeaderText="Expert" ItemStyle-HorizontalAlign="Center">
                   <ItemTemplate>
                       <asp:RadioButton ID="RowSelector7" runat="server" GroupName="InfoGroup1" 
                           Width="100" />
                   </ItemTemplate>
                   <HeaderStyle Font-Bold="True" Font-Size="Medium" />
               </asp:TemplateField>
           </Columns>
           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <RowStyle Height="30px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
          
</asp:GridView> 
</div>
</ContentTemplate>
</asp:UpdatePanel>
<asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>

 </div>
 <br />
      <div style=" float:right; margin-right:4%">
      <asp:Button ID="btnReset" runat="server" Text="Reset"  Height="43px" 
              style="margin-left: 0px" Width="146px" onclick="btnReset_Click" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
     <asp:Button ID="btnPre" runat="server" Text="Back" onclick="btnPre_Click"  Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid"   />
     <asp:Button ID="btnNext" runat="server" Text="Next" onclick="btnNext_Click"  Height="43px" style="margin-right: 10px" Width="146px"  BackColor="#55a6dd" 
             BorderColor="#666768" BorderStyle="Solid"  />
     </div>
<%--    </asp:Panel>--%>
</asp:Content>
