<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Previous_summary.aspx.cs" Inherits="Data_analytic.Previous_summary" %>
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
                       $("#progressbar").progressbar("value", 100);
                       //                       $("#result").text(msg.d);
                       clearInterval(intervalID);

                   }
               });
               return false;
           });
       });
       function updateProgress() {
           var value = $("#progressbar").progressbar("option", "value");
           if (value < 100) {
               $("#progressbar").progressbar("value", value + 1);
           }
       }        
        
    </script>
    <div id="progressbar";  style="width:101%">
    <div class="progBar">Programing</div> 
    <div class="progBar">Math</div> 
    <div class="progBar">Tool</div> 
    <div class="progBar">Summary</div>
    <div class="progBar">Result</div>
    <div class="progBar">Final</div>
    </div>
     <div style="margin-left:25px"> <h3> Student Expertise Level</h3></div>
<asp:Panel ID="Panel1" runat="server" BorderStyle="Dashed" 
        style="margin-left: 25px;margin-top:1%" Height="325px" Width="844px">
<table style="width:100%; height: 328px; margin-left: 2px;"><tr>
<th class="style2"><asp:Label ID="LBL_Programing" runat="server" Text="Programing Domain" 
        Font-Bold="True" Font-Size="Large"></asp:Label></th>

    <th> <div><asp:Label ID="Label1" runat="server" Text="Tool" Font-Bold="True" 
            Font-Size="Large"></asp:Label></div></th>
</tr><tr>
      <th class="style2" valign="top" > <div style=" overflow: scroll;overflow-x: hidden; height: 180px;"> 
          <asp:GridView ID ="GD_PRO" runat="server" 
              AutoGenerateColumns="false" Width="405px"  Font-Italic="False" 
              Font-Names="Calibri" Font-Size="Medium" Font-Bold="false">

         <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Programing" 
                HtmlEncode="False" ItemStyle-Width="250px">
                <HeaderStyle Font-Bold="True" Font-Size="Medium" />
                </asp:BoundField>
                <%-- </Columns  >--%>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="150px">
                <HeaderStyle Font-Bold="True" Font-Size="Medium" />
                </asp:BoundField>
                 </Columns  >

           <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           
        </asp:GridView> 
        </div>
    </th>
   <th valign="top"> 
   <asp:GridView ID="GD_TOOL" runat="server" AutoGenerateColumns="false"  
           Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
           style="margin-left: 0px" Width="400px">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Tool" 
                HtmlEncode="False" ItemStyle-Width="250px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="150px"/>
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
  <asp:GridView ID="GD_RESearch" runat="server" AutoGenerateColumns="false"  
          Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
          Width="408px">
     <Columns  >
        <asp:BoundField DataField="Data" HeaderText="Reserch/Expriance" 
                HtmlEncode="False" ItemStyle-Width="250px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="150px"/>
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
      
    </asp:GridView></th>
    <th  valign="top">
    <asp:GridView ID="GD_MATH" runat="server" AutoGenerateColumns="false"  
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Font-Bold="false" 
            style="margin-left: 0px" Width="399px">
     <Columns  >
       <asp:BoundField DataField="Data" HeaderText="Mathmetic Aplitude" 
                HtmlEncode="False" ItemStyle-Width="250px"/>
        <asp:BoundField DataField="Expertise" HeaderText="Expertise" 
                HtmlEncode="False" ItemStyle-Width="150px"/>
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
    
         <asp:GridView ID="GV_SM2" runat="server" AutoGenerateColumns="false" 
             Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Height="267px" 
             style="margin-left: 7px" Width="2000px">
             <Columns>
                 <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                     HtmlEncode="False" ItemStyle-Width="300px" />
                 <asp:BoundField DataField="Module Priority" HeaderText="Priority" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Theoretical Lecture" 
                     HeaderText="Theoretical Lecture" HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="ExamType" HeaderText="ExamType" HtmlEncode="False" 
                     ItemStyle-Width="100px" />
                 <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Private study required" 
                     HeaderText="Private Studey Required" HtmlEncode="False" 
                     ItemStyle-Width="100px" />
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks_Wtg" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                     HtmlEncode="False" ItemStyle-Width="100px" />
                 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                     HtmlEncode="False" ItemStyle-Width="300px" />
                 <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="False" 
                     ItemStyle-Width="300px" />
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


     <asp:GridView ID="Gv_SM1" runat="server" AutoGenerateColumns="false" 
         Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" Height="274px" 
         Width="2000px">
         <Columns>
             <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                 HtmlEncode="False" ItemStyle-Width="300px" />
             <asp:BoundField DataField="Module Priority" HeaderText="Priority" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="Credit hours" HeaderText="Cridets" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="Theoretical Lecture" 
                 HeaderText="Theoretical Lecture" HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="ExamType" HeaderText="ExamType" HtmlEncode="False" 
                 ItemStyle-Width="100px" />
             <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="Private study required" 
                 HeaderText="Private Studey Required" HtmlEncode="False" 
                 ItemStyle-Width="100px" />
             <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks_Wtg" 
                 HtmlEncode="False" ItemStyle-Width="100px" />
             <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                 HtmlEncode="False" ItemStyle-Width="300px" />
             <asp:BoundField DataField="Email" HeaderText="Email" HtmlEncode="False" 
                 ItemStyle-Width="300px" />
         </Columns>
         <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
         <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
     </asp:GridView>
 </div>
 
 <div style="margin-top:30px;  margin-left: 3px;">

 <h4>Note:Smester 3 Include project of 15 credits</h4>
 </div>
  </asp:Panel>
  <br />

<div style="margin-top:20px;margin-left:40%">
     <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Modify Expertise"  Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid"/>
      <asp:Button ID="Button2" runat="server" Text="Modify Module"  Height="43px" 
         style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" onclick="Button2_Click" />
 </div>
 
</asp:Content>
