<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Previous_summary.aspx.cs" Inherits="Data_analytic.Previous_summary" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .style1
        {
            width: 466px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<asp:Panel ID="Panel1" runat="server" BorderStyle="Outset">
<table style="width:100%"><tr>
<th class="style1"><asp:Label ID="LBL_Programing" runat="server" Text="Programing Domain" 
        Font-Bold="True" Font-Size="X-Large"></asp:Label></th>

    <th> <div><asp:Label ID="Label1" runat="server" Text="Tool" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label></div></th>
</tr><tr>
      <th class="style1">  <div style="margin-top:20px">
          <asp:GridView ID ="GD_PRO" runat="server" 
              AutoGenerateColumns="false" Width="458px">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programing" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                <%-- </Columns  >--%>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
        </asp:GridView> </div>
    </th>
   <th style="margin-top:20px"> 
   <asp:GridView ID="GD_TOOL" runat="server" AutoGenerateColumns="false">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tool" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
    </asp:GridView>
    </th></tr>
    <tr>
    <th style="margin-top:20px" class="style1"><asp:Label ID="LBL_RESearch" runat="server" Text="Research/Expriance" 
        Font-Bold="True" Font-Size="X-Large"></asp:Label></th>
       <th style="margin-top:20px"><asp:Label ID="LBL_MATH" runat="server" Text="Mathmetic Aplitude" Font-Bold="True" 
            Font-Size="X-Large"></asp:Label> </th>
</tr>
  <tr>   <th style="margin-top:20px" class="style1"><asp:GridView ID="GD_RESearch" runat="server" AutoGenerateColumns="false">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Reserch/Expriance" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
      
      
    </asp:GridView></th>
    <th style="margin-top:20px">
    <asp:GridView ID="GD_MATH" runat="server" AutoGenerateColumns="false">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathmetic Aplitude" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
    </asp:GridView>
    </th>
    
    
    </tr></table>

    </asp:Panel>




    <asp:Panel ID="Panel2" runat="server" BorderStyle="Outset" >
   
     <div style="margin-top:20px;  overflow:scroll; width:673px; height: 193px;">
     <asp:Label ID="Label2" runat="server" Text="Semester 1 Module" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
     <asp:GridView ID="Gv_SM1" runat="server" Width="1192px" AutoGenerateColumns="false" 
             Height="155px">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Module Priority" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Theoretical Lecture" HeaderText="Theoretical Lecture" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="ExamType" HeaderText="ExamType" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Private study required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks_Wtg" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
        </asp:GridView>
 </div>


 <div style="margin-top:20px; overflow:scroll; width:667px">

 <asp:Label ID="Label3" runat="server" Text="Smester 2 Module" Font-Bold="True" 
            Font-Size="Large"></asp:Label>
     <asp:GridView ID="GV_SM2" runat="server" Width="1178px" 
         AutoGenerateColumns="false">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                <asp:BoundField DataField="Module Priority" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Theoretical Lecture" HeaderText="Theoretical Lecture" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="ExamType" HeaderText="ExamType" 
                HtmlEncode="False" ItemStyle-Width="300px"/>

         <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Private study required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks_Wtg" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                
                 </Columns  >
        </asp:GridView>
 </div> 
 <div style="margin-top:20px">
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Modify" />
 </div>
 </asp:Panel>
</asp:Content>
