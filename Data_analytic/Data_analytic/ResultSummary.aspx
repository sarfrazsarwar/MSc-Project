<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ResultSummary.aspx.cs" Inherits="Data_analytic.ResultSummary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 462px;
        }
        .style2
        {
            width: 432px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div id="progressbar";  style="width:101%">
    <div class="progBar_Fill">Programming</div> 
    <div class="progBar_Fill">Mathematics</div> 
    <div class="progBar_Fill">Tools</div> 
    <div class="progBar_Fill">Summary</div>
    <div class="progBar_Fill">Result</div>
    <div class="progBar_Fill">Final</div>
    </div>
     <div style="margin-left:25px"> <h3> Student Expertise Level</h3></div>
<asp:Panel ID="Panel1" runat="server" BorderStyle="Dashed" 
        style="margin-left: 25px;margin-top:1%" Height="325px" Width="844px">
<table style="width:100%; height: 328px; margin-left: 2px;"><tr>
<th class="style2"><asp:Label ID="LBL_Programing" runat="server" Text="Programming Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label></th>

    <th> <div><asp:Label ID="Label1" runat="server" Text="Tool" Font-Bold="True" 
            Font-Size="Large"></asp:Label></div></th>
</tr><tr>
      <th class="style2" valign="top" > <div style=" overflow: scroll;overflow-x: hidden; height: 180px;"> 
          <asp:GridView ID ="grdPrograming" runat="server" 
              AutoGenerateColumns="false" Width="405px"  Font-Italic="False" 
              Font-Names="Calibri" Font-Size="Medium" Font-Bold="false">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programming" 
                HtmlEncode="False" ItemStyle-Width="250px">
                <HeaderStyle Font-Bold="True" Font-Size="Medium" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <%-- </Columns  >--%>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="150px">
                <HeaderStyle Font-Bold="True" Font-Size="Medium" />
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 </Columns  >

           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           
        </asp:GridView> 
        </div>
    </th>
   <th valign="top"> 
   <asp:GridView ID="grdTools" runat="server" AutoGenerateColumns="false"  
           Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
           style="margin-left: 0px" Width="400px">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tool" HtmlEncode="False" ItemStyle-Width="250px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" HtmlEncode="False" ItemStyle-Width="150px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView>
    </th></tr>
    <tr>
    <th class="style2" ><asp:Label ID="LBL_RESearch" runat="server" Text="Research/Expriance" 
        Font-Bold="True" Font-Size="Large"></asp:Label></th>
       <th style="margin-top:20px"><asp:Label ID="LBL_MATH" runat="server" Text="Mathmetic Aplitude" Font-Bold="True" 
            Font-Size="Large"></asp:Label> </th>
</tr>
  <tr>   <th class="style2" valign="top">
  <asp:GridView ID="grdResearch" runat="server" AutoGenerateColumns="false"  
          Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
          Width="408px">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Reserch/Expriance" HtmlEncode="False" ItemStyle-Width="250px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" HtmlEncode="False" ItemStyle-Width="150px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
      
    </asp:GridView></th>
    <th  valign="top">
    <asp:GridView ID="grdMath" runat="server" AutoGenerateColumns="false"  
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
            style="margin-left: 0px" Width="399px">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathmetic Aplitude" HtmlEncode="False" ItemStyle-Width="250px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>

        <asp:BoundField DataField="Expertise" HeaderText="Expertise" HtmlEncode="False" ItemStyle-Width="150px">
                <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
    </asp:GridView>
    </th>
    
    
    </tr></table>

    </asp:Panel>

    <br />

  <div style="margin-left:25px"><h3> Module Selected</h3></div>
    <asp:Panel ID="Panel2" runat="server" BorderStyle="Dashed" Height="785px" 
        style="margin-left: 25px; " Width="844px" >
    
    <div style="margin-top:20px">
    <asp:Label ID="Label2" runat="server" Text="Semester 1 Module" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
            </div>

     <div style="margin-top:5px;  overflow:scroll; width:814px; height: 283px; margin-left: 6px;">
    
         <asp:GridView ID="grdSugSemester1" runat="server" AutoGenerateColumns="false" 
             Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Height="240px" 
             style="margin-left: 7px" Width="2000px">
             <Columns>
                 <asp:BoundField DataField="ACademic_Module" HeaderText="Module Name" 
                     HtmlEncode="False" ItemStyle-Width="300px" />
                 <asp:BoundField DataField="Module_No" HeaderText="Module ID" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Credit_hours" HeaderText="Credit Hr" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Module_Priority" HeaderText="Priority" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="ExamType" HeaderText="Evaluation Mode" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Exam_Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
               <asp:BoundField DataField="CourseWorks" HeaderText="No of Coursework" 
                HtmlEncode="False" ItemStyle-Width="100px"/>

                <asp:BoundField DataField="Practical_Labs" HeaderText="Practical Labs (Hrs)" 
                     HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Theoretical_Lecture" 
                     HeaderText="Theoretical Lecture (Hrs)" HtmlEncode="False" ItemStyle-Width="100px"/>

                 <asp:BoundField DataField="ClassTests" HeaderText="Class Test (Hrs)" 
                     HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Private_Study_Required" 
                     HeaderText="Private Study (Hrs)" HtmlEncode="False" 
                     ItemStyle-Width="100px"/>

               <asp:BoundField DataField="Manager_Name" HeaderText="Module Leader" 
                     HtmlEncode="False" ItemStyle-Width="200px" />
                <asp:BoundField DataField="Email" HeaderText="Contact Info" HtmlEncode="False" 
                     ItemStyle-Width="200px" />
                <asp:TemplateField  HeaderText ="Online Catalogue" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk"  runat="server" Target="_blank" Text='<%# SetUrl(Eval("WebAddress")) %>'
                            NavigateUrl='<%# GetUrl(Eval("WebAddress")) %>'></asp:HyperLink>
                    </ItemTemplate>
               </asp:TemplateField>
               
             </Columns>
             <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
             <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
         </asp:GridView>
 </div>

 <div style="margin-top:20px">
 <asp:Label ID="Label4" runat="server" Text="Smester 2 Module" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
            </div>
 <div style="margin-top:26px; overflow:scroll; width:817px; height: 280px; margin-left: 3px;">


     <asp:GridView ID="grdSugSemester2" runat="server" AutoGenerateColumns="false" 
         Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Height="240px" 
         Width="2000px">
         <Columns>
              <asp:BoundField DataField="ACademic_Module" HeaderText="Module Name" 
                     HtmlEncode="False" ItemStyle-Width="300px" />
                 <asp:BoundField DataField="Module_No" HeaderText="Module ID" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Credit_hours" HeaderText="Credit Hr" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Module_Priority" HeaderText="Priority" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="ExamType" HeaderText="Evaluation Mode" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Exam_Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
               <asp:BoundField DataField="CourseWorks" HeaderText="No of Coursework" 
                HtmlEncode="False" ItemStyle-Width="100px"/>

                <asp:BoundField DataField="Practical_Labs" HeaderText="Practical Labs (Hrs)" 
                     HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Theoretical_Lecture" 
                     HeaderText="Theoretical Lecture (Hrs)" HtmlEncode="False" ItemStyle-Width="100px"/>

                 <asp:BoundField DataField="ClassTests" HeaderText="Class Test (Hrs)" 
                     HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Private_Study_Required" 
                     HeaderText="Private Study (Hrs)" HtmlEncode="False" 
                     ItemStyle-Width="100px"/>

               <asp:BoundField DataField="Manager_Name" HeaderText="Module Leader" 
                     HtmlEncode="False" ItemStyle-Width="200px" />
                <asp:BoundField DataField="Email" HeaderText="Contact Info" HtmlEncode="False" 
                     ItemStyle-Width="200px" />
                <asp:TemplateField  HeaderText ="Online Catalogue" ItemStyle-Width="150px">
                    <ItemTemplate>
                        <asp:HyperLink ID="lnk"  runat="server" Target="_blank" Text='<%# SetUrl(Eval("WebAddress")) %>'
                            NavigateUrl='<%# GetUrl(Eval("WebAddress")) %>'></asp:HyperLink>
                    </ItemTemplate>
       </asp:TemplateField>
         </Columns>
         <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
         <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
     </asp:GridView>
 </div>
 
 <div style="margin-top:30px;  margin-left: 3px;">

 <h4>Note: Semester 3 has research project of 60 credit hours, and is treated as 'Pass Required for Progression' (PFP) module.</h4>
 </div>
  </asp:Panel>
  <br />

<div style="margin-top:20px;margin-left:40%">
     <asp:Button ID="btnModifyExpertise" runat="server" onclick="btnModifyExpertise_Click" Text="Modify Expertise"  Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid"/>
      <asp:Button ID="btnModifyModule" runat="server" Text="Modify Module"  Height="43px" 
         style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" onclick="btnModifyModule_Click" />
 </div>
 
</asp:Content>
