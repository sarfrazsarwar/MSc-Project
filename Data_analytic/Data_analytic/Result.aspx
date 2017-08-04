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
            width: 98px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="1049px">

<asp:Panel ID="Panel2"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="1004px" 
            style="margin-right: 0px">
<table style="margin-left:50Px">
   <%-- <div style="margin-top:20px">--%>
    <tr>
  <td> <h2>Smester 1 Suggest Modules</h2></td>
   <td>     move left Right         </td>
    <td class="style2"><h2>Smester 1 NonSuggest Modules</h2></td>
   
   
   
   </tr>
   <tr>
        <td> 
        
        <asp:GridView ID="GV_SM1" runat="server" AutoGenerateColumns="False"
            Width="426px"  
                        Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "OnRowDataBound" 
            OnSelectedIndexChanged = "OnSelectedIndexChanged" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="350px">
               
              <%--   </asp:BoundField>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px">
                
                 </asp:BoundField>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px">--%>
            
                 </asp:BoundField>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="100px">
             
                 </asp:BoundField>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="100px">
                 </asp:BoundField>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="50px">
           
                 </asp:BoundField>
         <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"   ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" >
                 </asp:BoundField>
                 </Columns  >

             <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
       <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton></td>
   
<%--    </div>--%>
     <%--<div style="margin-top:20px">--%>
     <td class="style2">
       <div> <asp:Button ID="BTN_UP_SM1" runat="server" Text="Left" 
             onclick="BTN_UP_SM1_Click" />
             <br />
             <br />
             <br />
             <br />
        <asp:Button ID="BTN_DOWN_SM1" runat="server" Text="Right" 
             onclick="BTN_DOWN_SM1_Click" />
             </div>
             </td>
      <%--   </div>
     style="margin-top:20px">--%>
   <td class="style1">
      <div>  
          <asp:GridView ID="Gv_SM1_NO" runat="server" AutoGenerateColumns="False"
                       Width="452px" 
            Font-Italic="False" Font-Names="Calibri" Font-Size="Medium"  
            BorderColor="#66CCFF" OnRowDataBound = "SM1NON_OnRowDataBound" 
            OnSelectedIndexChanged = "SM1NON_OnSelectedIndexChanged">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="350px"/>
      <%--  <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
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
         <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
       </div>  </td>
    <%---%>

    </tr>





    </table>
    <br />
    <br />
    <%-- ab.[ClassTests],ab.[Private study required],ab.[CourseWorks],ab.[ExamType],ab.[Exam Weightage],--%>
    <div style='overflow:scroll; width:80%;height:150px; margin-left:50px'>
     <asp:GridView ID="GridView1" runat="server" Width="1194px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Small" Height="93px" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="350px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Cridet Hr" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Practical Labs" HeaderText="Practical Labs" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="Theoretical Lecture" HeaderText="Theoretical Lecture" 
                HtmlEncode="False" ItemStyle-Width="100px"/>
        <asp:BoundField DataField="ExamType" HeaderText="ExamType" 
                HtmlEncode="False" ItemStyle-Width="200px"/>
        <asp:BoundField DataField="Exam Weightage" HeaderText="Exam Weightage" 
                HtmlEncode="False" ItemStyle-Width="100px"/>


                 <asp:BoundField DataField="ClassTests" HeaderText="ClassTest" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="Private study required" HeaderText="Private Studey Required" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks" HeaderText="courseWorks" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 <asp:BoundField DataField="CourseWorks_Weightage" HeaderText="CourseWorks_Wtg" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 



                 <asp:BoundField DataField="Manager Name" HeaderText="Manager Name" 
                HtmlEncode="False" ItemStyle-Width="350px"/>
                 <asp:BoundField DataField="Email" HeaderText="Email" 
                HtmlEncode="False" ItemStyle-Width="300px"/>

                <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
       <asp:LinkButton ID="LinkButton4" runat="server"></asp:LinkButton> 
       </div>
       <asp:Button ID="Button2" runat="server" Text="Reset" 
        onclick="Button2_Click" />
       </asp:Panel>

      <br />
      <br />
<asp:Panel ID="Panel3"
           runat="server" BorderStyle="Dashed" BorderWidth="2px" Width="1005px">
<table style="margin-top:20px">
   <%-- <div style="margin-top:20px">--%>
    <tr>
  <td> <h2>Smester 2 suggest Modules</h2></td>
   <td>     move left Right         </td>
    <td class="style2"><h2>Smester 2 NonSuggest Modules</h2></td>
   
   
   
   </tr>
   <tr>
   <td>
    <div style="margin-top:20px">
        
    
        <asp:GridView ID="GV_SM2" runat="server" Width="414px" 
            AutoGenerateColumns="false" OnRowDataBound = "SM2_OnRowDataBound" 
            OnSelectedIndexChanged = "SM2_OnSelectedIndexChanged">
                     <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
       <%-- <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
                  <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" /> 
        </asp:GridView>
        <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
        </div>
        </td>
        <td>
        <div style="margin-top:20px">
        <asp:Button ID="BTN_SM2_UP" runat="server" Text="Left" onclick="BTN_SM2_UP_Click" />

         <br />
             <br />
             <br />
             <br />
         <asp:Button ID="BTN_SM2_DOWN" runat="server" Text="Right" 
                onclick="BTN_SM2_DOWN_Click" />
         </div>
         </td>
         <td>
        <div style="margin-top:20px">
        <asp:GridView ID="Gv_SM2_NO" runat="server" Width="396px" 
                AutoGenerateColumns="false" OnRowDataBound = "SM2NON_OnRowDataBound" 
                OnSelectedIndexChanged = "SM2NON_OnSelectedIndexChanged" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <%--<asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>--%>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="50px"/>
                
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="50px"  ItemStyle-CssClass="hiddencol"  HeaderStyle-CssClass="hiddencol" />
                 </Columns  >
            <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
        <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
         </div>
        </td>
        </tr>

        </table>

        <div style='overflow:scroll; width:80%;height:150px; margin-left:50px'>
             <asp:GridView ID="GridView2" runat="server" Width="1045px" 
            AutoGenerateColumns="false"  Font-Italic="False" Font-Names="Calibri" 
            Font-Size="Small" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
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
                <asp:BoundField DataField="none Selected" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
                 <HeaderStyle BackColor="#CCCCFF" BorderColor="Black" Height="18px" />
           <SelectedRowStyle BackColor="#A1DCF2" Font-Bold="True" />
        </asp:GridView>
       <asp:LinkButton ID="LinkButton5" runat="server"></asp:LinkButton>
   </div>
    <asp:Button
             ID="Button1" runat="server" Text="Reset" onclick="Button1_Click" />
    
   </asp:Panel>
     <div style="margin-top:20px">
     <asp:Label ID="Label2" runat="server" Text="Reviews"></asp:Label>
         <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="503px"></asp:TextBox>
         <br />
         <asp:Button ID="Save" runat="server" Text="Submit" onclick="Save_Click" />
        
      </div>
    </asp:Panel>
</asp:Content>
