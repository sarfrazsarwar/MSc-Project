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
                       $("#progressbar").progressbar("value", 60);
                       $("#progressbar").appendTo(20);
                       //                       $("#result").text(msg.d);
                       clearInterval(intervalID);

                   }
               });
               return false;
           });
       });
       function updateProgress() {
           var value = $("#progressbar").progressbar("option", "value");
           if (value < 80) {
               $("#progressbar").progressbar("value", value + 1);
           }
       }        
        
    </script>
    <div id="progressbar";  style="width:100%"></div>
    <div id="result" style="width:100%"><%--<span>--%><div style="float:left;text-align:justify; width:51%">0 <span style="float:right">50</span></div> <div style="float:right;text-align:justify">100%</div><%--</span>--%></div>
<h3>Semester 1 Modules</h3>
<asp:Panel ID="Panel2"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="896px" 
            style="margin-right: 0px; margin-left: 0px" Height="741px">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>
<table >
   <%-- <div style="margin-top:20px">--%>
    <tr>
  <td  class="style2"> <div style="margin-left:30px"><h4 style="font-weight:lighter">Recommended Modules</h4></div></td>
   <td>   </td>
    <td class="style2"><div style="margin-left:25px"><h4 style="font-weight:lighter"> None Recommended Modules</h4></div></td>
   
   
   
   </tr>
   <tr>
        <td valign="top"> 
        
       <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <asp:GridView ID="GV_SM1" runat="server" AutoGenerateColumns="False"
            Width="416px"  
                        Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" 
            OnSelectedIndexChanged = "OnSelectedIndexChanged" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="270px">
               
              <%--   </asp:BoundField>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px">
                
                 </asp:BoundField>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px">--%>
            
                 </asp:BoundField>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="50px">
             
                 </asp:BoundField>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol">
                 </asp:BoundField>
        <asp:BoundField DataField="Credit hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px">
           
                 </asp:BoundField>
         <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
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
           <asp:Button ID="BTN_UP_SM1" runat="server" Text="<<<" 
             onclick="BTN_UP_SM1_Click" Height="40px" />
               </ContentTemplate>
        </asp:UpdatePanel>
             <br />
        <asp:UpdatePanel ID="UpdatePanel9" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <asp:Button ID="BTN_DOWN_SM1" runat="server" Text=">>>" 
             onclick="BTN_DOWN_SM1_Click" Height="40px" />
         </ContentTemplate>
        </asp:UpdatePanel>
             </div>
             </td>
      <%--   </div>
     style="margin-top:20px">--%>
   <td  valign="top">
      <asp:UpdatePanel ID="UpdatePanel4" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
          <asp:GridView ID="Gv_SM1_NO" runat="server" AutoGenerateColumns="False"
                       Width="419px" 
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
                HtmlEncode="False" ItemStyle-Width="50px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
<%--
    <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
                
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="25px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        </ContentTemplate>
        </asp:UpdatePanel>
         <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
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

    <div style='overflow:scroll; width:98%; height:395px; margin-left:7px; margin-top:10px'>
    <asp:UpdatePanel ID="UpdatePanel5" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
     <asp:GridView ID="GridView1" runat="server" Width="2000px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Medium" Height="371px" style="margin-left: 4px" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="450px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Theoretical Lecture" HeaderText="Theoretical Lecture" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="ExamType" HeaderText="ExamType" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>


                 <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="Private study required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Wtg" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
                 



                 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px"/>

                <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
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
       <asp:Button ID="Button2" runat="server" Text="Reset" 
        onclick="Button2_Click" Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
        </div>
        <br />
       </asp:Panel>

      <br />
      <br />
<h3>Semester 2 Modules</h3>
<asp:Panel ID="Panel3"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="896px" 
            style="margin-right: 0px" Height="808px">
<table style="margin-top:20px">
   <%-- <div style="margin-top:20px">--%>
    <tr>
  <td> <div style="margin-left:30px"><h4 style="font-weight:lighter"> Recommended Modules</h4></div></td>
   <td>   </td>
    <td class="style2"><div style="margin-left:20px"><h4 style="font-weight:lighter"> None Recommended Modules</h4></div></td>
   
   
   
   </tr>
   <tr>
   <td valign="top">
    <div style="margin-top:0px" >
        
    <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
        <asp:GridView ID="GV_SM2" runat="server" Width="417px" 
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
        <asp:BoundField DataField="Credit hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
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
        <asp:Button ID="BTN_SM2_UP" runat="server" Text="<<<" onclick="BTN_SM2_UP_Click" 
                Height="40px" />
        </ContentTemplate>
        </asp:UpdatePanel>

             <br />
        <asp:UpdatePanel ID="UpdatePanel7" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
         <asp:Button ID="BTN_SM2_DOWN" runat="server" Text=">>>" 
                onclick="BTN_SM2_DOWN_Click" Height="40px" />
        </ContentTemplate>
        </asp:UpdatePanel>
         </div>
         </td>
         <td valign="top">
        <div style="margin-top:0px">
        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional" >
        <ContentTemplate>
        <asp:GridView ID="Gv_SM2_NO" runat="server" Width="419px" 
                AutoGenerateColumns="false" OnRowDataBound = "SM2NON_OnRowDataBound" 
                OnSelectedIndexChanged = "SM2NON_OnSelectedIndexChanged" 
                Font-Italic="False" Font-Names="Calibri" Font-Size="Medium" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <%--<asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Priority" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px" ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credits" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
                
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
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
        <div style='overflow:scroll; width:98%; height:455px; margin-left:8px; margin-top:10px;'>
        <asp:UpdatePanel ID="UpdatePanel6" runat="server" UpdateMode="Conditional" >
      <ContentTemplate>
             <asp:GridView ID="GridView2" runat="server" Width="1998px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Medium" Height="429px" style="margin-left: 1px" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="500px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Theoretical Lecture" HeaderText="Theoretical Lecture" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="ExamType" HeaderText="ExamType" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>

                 <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
                 <asp:BoundField DataField="Private study required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks Wtg" 
                HtmlEncode="False" ItemStyle-Width="50px"/>

                 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                HtmlEncode="False" ItemStyle-Width="150px"/>
                 <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="150px"/>
                <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
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
             ID="Button1" runat="server" Text="Reset" onclick="Button1_Click" Height="43px" style="margin-left: 0px" Width="146px" BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
</div>
 <br />
   </asp:Panel> 
   <br />
     <div style=" float:right; margin-right:40%;margin-top:15px" >
        
         <asp:Button ID="Save" runat="server" Text="Submit" onclick="Save_Click" Height="43px" style="margin-left: 0px" Width="146px"  BackColor="#55a6dd" 
            BorderColor="#666768" BorderStyle="Solid" />
        
      </div>
</asp:Content>
