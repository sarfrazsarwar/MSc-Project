<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Result.aspx.cs" Inherits="Data_analytic.Result"  EnableEventValidation="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel ID="Panel1" runat="server">

    <div style="margin-top:20px">
    <h2>Smester 1 Suggest Modules</h2>
        <asp:GridView ID="GV_SM1" runat="server" Width="904px" 
            AutoGenerateColumns="false"  OnRowDataBound = "OnRowDataBound" OnSelectedIndexChanged = "OnSelectedIndexChanged" >
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px">
               
                 </asp:BoundField>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px">
                
                 </asp:BoundField>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px">
            
                 </asp:BoundField>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="300px">
             
                 </asp:BoundField>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 </asp:BoundField>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="300px">
           
                 </asp:BoundField>
         <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="300px" >
                 </asp:BoundField>
                 </Columns  >
             <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
       <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
   
    </div>
     <div style="margin-top:20px">
        <asp:Button ID="BTN_UP_SM1" runat="server" Text="UP" 
             onclick="BTN_UP_SM1_Click" />
        <asp:Button ID="BTN_DOWN_SM1" runat="server" Text="DOWN" 
             onclick="BTN_DOWN_SM1_Click" />
         </div>
    <div style="margin-top:20px">
    <h2>Smester 1 NonSuggest Modules</h2>
        <asp:GridView ID="Gv_SM1_NO" runat="server" Width="904px" AutoGenerateColumns="false" OnRowDataBound = "SM1NON_OnRowDataBound" OnSelectedIndexChanged = "SM1NON_OnSelectedIndexChanged">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
                 <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
         <asp:LinkButton ID="LinkButton1" runat="server"></asp:LinkButton>
    </div>











    <div style="margin-top:20px">
    <h2>Smester 2 suggest Modules</h2>
        <asp:GridView ID="GV_SM2" runat="server" Width="909px" AutoGenerateColumns="false" OnRowDataBound = "SM2_OnRowDataBound" OnSelectedIndexChanged = "SM2_OnSelectedIndexChanged">
                     <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
          <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
        <asp:LinkButton ID="LinkButton2" runat="server"></asp:LinkButton>
        </div>

        <div style="margin-top:20px">
        <asp:Button ID="BTN_SM2_UP" runat="server" Text="UP" onclick="BTN_SM2_UP_Click" />
        <asp:Button ID="BTN_SM2_DOWN" runat="server" Text="DOWN" 
                onclick="BTN_SM2_DOWN_Click" />
         </div>

        <div style="margin-top:20px">
    <h2>Smester 2 NonSuggest Modules</h2>
        <asp:GridView ID="Gv_SM2_NO" runat="server" Width="904px" AutoGenerateColumns="false" OnRowDataBound = "SM2NON_OnRowDataBound" OnSelectedIndexChanged = "SM2NON_OnSelectedIndexChanged">
             <Columns  >
       <asp:BoundField DataField="ACademic_Module" HeaderText="Module" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
        <asp:BoundField DataField="AM_ID" HeaderText="AM_ID" 
                HtmlEncode="False" ItemStyle-Width="300px"/>
                 </Columns  >
          <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
        <asp:LinkButton ID="LinkButton3" runat="server"></asp:LinkButton>
    </div>

     <div style="margin-top:20px">
         <asp:Button ID="Save" runat="server" Text="Submit" onclick="Save_Click" />
      </div>
    </asp:Panel>
</asp:Content>
