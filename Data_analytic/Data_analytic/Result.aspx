<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs"
Inherits="Data_analytic.Result"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 585px;
        }
        .style2
        {
           height:10px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="progressbar";  style="width:100%">
    
    <div class="progBar_Fill">Programming</div> 
    <div class="progBar_Fill">Math</div> 
    <div class="progBar_Fill">Tool</div> 
    <div class="progBar_Fill">Summary</div>
    <div class="progBar_Fill">Result</div>
    <div class="progBar">Final</div>
    </div>
<h3>Semester 1 Modules</h3>
<asp:Panel ID="Panel2"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="895px" 
            style="margin-right: 0px; margin-left: 0px" Height="663px">
<table >
    <tr>
  <td  class="style2"> <div style="margin-left:30px"><h4 style="font-weight:lighter">Recommended Modules</h4></div></td>
   <td>   </td>
    <td class="style2"><div style="margin-left:25px"><h4 style="font-weight:lighter"> Non-Recommended Modules</h4></div></td>
   
   
   
   </tr>
   <tr>
        <td valign="top"> 
        
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <asp:GridView ID="grdSugSemester1" runat="server" AutoGenerateColumns="False"
            Width="416px"  
                        Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" 
            OnSelectedIndexChanged = "OnSelectedIndexChanged" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="270px">
               
                 </asp:BoundField>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="50px">
             
                 </asp:BoundField>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol">
                 </asp:BoundField>
        <asp:BoundField DataField="Credit_hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px">
           
                 </asp:BoundField>
         <asp:BoundField DataField="AcademicModule_ID" HeaderText="AcademicModule_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
                 </asp:BoundField>
                 </Columns  >

             <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
       <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton></td>
   
<%--    </div>--%>
     <%--<div style="margin-top:20px">--%>
     <td class="style2">
       <div> 
       <asp:UpdatePanel ID="UpdatePanel8" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
           <asp:Button ID="btnSemster1LeftShift" runat="server" Text="<<<" 
             onclick="btnSemster1LeftShift_Click" Height="40px" />
               </ContentTemplate>
        </asp:UpdatePanel>
             <br />
        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <asp:Button ID="btnSemster1RightShift" runat="server" Text=">>>" 
             onclick="btnSemster1RightShift_Click" Height="40px" />
         </ContentTemplate>
        </asp:UpdatePanel>
             </div>
             </td>
      <%--   </div>
     style="margin-top:20px">--%>
   <td  valign="top">
   <div class="scrolLft">
      <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
      
          <asp:GridView ID="grdNonSugSemester1" runat="server" AutoGenerateColumns="False"
                       Width="406px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "SM1NON_OnRowDataBound" 
            OnSelectedIndexChanged = "SM1NON_OnSelectedIndexChanged">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="270px"/>
      <%--  <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="20px" />
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="40px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Credit_hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="40px"/>
<%--
    <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
                
        <asp:BoundField DataField="AcademicModule_ID" HeaderText="AcademicModule_ID" 
                HtmlEncode="False" ItemStyle-Width="20px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
         <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
         </div>
      </td>
    <%---%>

    </tr>


    


    </table>
    <br />
     <asp:UpdatePanel ID="UpdatePanel12" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
<asp:Label ID="LBLerror" runat="server" Text="" ForeColor="Red"></asp:Label>
</ContentTemplate>
        </asp:UpdatePanel>
    <br />

    <div style='overflow:scroll; width:98%; height:286px; margin-left:7px; margin-top:10px'>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
     <asp:GridView ID="grdSemester1Detail" runat="server" Width="2000px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Medium" Height="371px" style="margin-left: 4px" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module Name" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <asp:BoundField DataField="Module_No" HeaderText="Module ID" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="none Selected" HeaderText="Deficient Module Requirements" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <asp:BoundField DataField="ExamType" HeaderText="Evaluation Mode" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="Exam_Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="CourseWorks" HeaderText="No of Coursework" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:TemplateField  HeaderText ="Online Catalogue">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk"  runat="server" Target="_blank" Text='<%# SetUrl(Eval("WebAddress")) %>'
                            NavigateUrl='<%# GetUrl(Eval("WebAddress")) %>'></asp:HyperLink>
                    </ItemTemplate>
       </asp:TemplateField>


        <asp:BoundField DataField="Credit_hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Practical_Labs" HeaderText="Practical_Labs" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Theoretical_Lecture" HeaderText="Theoretical_Lecture" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>        
        <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Private_Study_Required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                 
        <asp:BoundField DataField="Manager_Name" HeaderText="Manager_Name" 
                HtmlEncode="False" ItemStyle-Width="300px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>

                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
       <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton> 
       </div>
       <br />
       <div style=" float:right; margin-right:1%; " >
       <asp:Button ID="btnResetSm1" runat="server" Text="Reset" 
        onclick="btnResetSemester1_Click" Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
        </div>
        <br />
       </asp:Panel>

      <br />
      <br />
<h3>Semester 2 Modules</h3>
<asp:Panel ID="Panel3"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="899px" 
            style="margin-right: 0px" Height="649px">
<table style="margin-top:20px">
   <%-- <div style="margin-top:20px">--%>
    <tr>
  <td> <div style="margin-left:30px"><h4 style="font-weight:lighter"> Recommended Modules</h4></div></td>
   <td>   </td>
    <td class="style2"><div style="margin-left:20px"><h4 style="font-weight:lighter"> Non-Recommended Modules</h4></div></td>
   
   
   
   </tr>
   <tr>
   <td valign="top">
    <div style="margin-top:0px" >
        
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <asp:GridView ID="grdSugSemester2" runat="server" Width="417px" 
            AutoGenerateColumns="false" OnRowDataBound = "SM2_OnRowDataBound" 
            OnSelectedIndexChanged = "SM2_OnSelectedIndexChanged" Font-Italic="False" 
            Font-Names="Calibri" Font-Size="Medium">
                     <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <%-- <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Credit_hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="AcademicModule_ID" HeaderText="AcademicModule_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
                  <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" /> 
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
        </div>
        </td>
        <td>
        <div style="margin-top:20px">
        <asp:UpdatePanel ID="UpdatePanel10" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <asp:Button ID="btnSemster2LeftShift" runat="server" Text="<<<" onclick="btnSemster2LeftShift_Click" 
                Height="40px" />
        </ContentTemplate>
        </asp:UpdatePanel>

             <br />
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
         <asp:Button ID="btnSemster2RightShift" runat="server" Text=">>>" 
                onclick="btnSemster2RightShift_Click" Height="40px" />
        </ContentTemplate>
        </asp:UpdatePanel>
         </div>
         </td>
         <td valign="top">
          <div class="scrolLft">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <asp:GridView ID="grdNonSugSemester2" runat="server" Width="404px" 
                AutoGenerateColumns="false" OnRowDataBound = "SM2NON_OnRowDataBound" 
                OnSelectedIndexChanged = "SM2NON_OnSelectedIndexChanged" 
                Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="270px"/>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="20px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="40px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Credit_hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="40px"/>
                
        <asp:BoundField DataField="AcademicModule_ID" HeaderText="AcademicModule_ID" 
                HtmlEncode="False" ItemStyle-Width="20px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
        <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
         </div>
        </td>
        </tr>

        </table>
         <br />
          <asp:UpdatePanel ID="UpdatePanel11" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
            <asp:Label ID="Label1" runat="server" Text="" ForeColor="Red"></asp:Label>
            </ContentTemplate>
            </asp:UpdatePanel>
    <br />
        <div style='overflow:scroll; width:98%; height:286px; margin-left:8px; margin-top:10px;'>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
             <asp:GridView ID="grdSemester2Detail" runat="server" Width="1998px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Medium" Height="429px" style="margin-left: 1px" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module Name" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <asp:BoundField DataField="Module_No" HeaderText="Module ID" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="none Selected" HeaderText="Deficient Module Requirements" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <asp:BoundField DataField="ExamType" HeaderText="Evaluation Mode" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="Exam_Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:BoundField DataField="CourseWorks" HeaderText="No of Coursework" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
       <asp:TemplateField  HeaderText ="Online Catalogue">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk"  runat="server" Target="_blank" Text='<%# SetUrl(Eval("WebAddress")) %>'
                            NavigateUrl='<%# GetUrl(Eval("WebAddress")) %>'></asp:HyperLink>
                    </ItemTemplate>
       </asp:TemplateField>


        <asp:BoundField DataField="Credit_hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Practical_Labs" HeaderText="Practical_Labs" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Theoretical_Lecture" HeaderText="Theoretical_Lecture" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>        
        <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Private_Study_Required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="100px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                 
        <asp:BoundField DataField="Manager_Name" HeaderText="Manager_Name" 
                HtmlEncode="False" ItemStyle-Width="300px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px" ItemStyle-CssClass="hiddencol" HeaderStyle-CssClass="hiddencol"/>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
       <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
   </div>
   <br />
    <div style=" float:right; margin-right:1%" >
    <asp:Button
             ID="btnResetSm2" runat="server" Text="Reset" onclick="btnResetSemester2_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
</div>
 <br />
   </asp:Panel> 
   <br />
    <asp:Label ID="lblErrorMian" runat="server" Text="" ForeColor="#FF3300"></asp:Label>
     <div style=" float:right; margin-right:40%;margin-top:15px" >
        
         <asp:Button ID="btnSubmit" runat="server" Text="Submit" onclick="btnSubmit_Click" Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
        
      </div>
</asp:Content>
