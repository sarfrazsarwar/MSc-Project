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
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
        <asp:BoundField DataField="TruePostive" HeaderText="True Postive" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
        <asp:BoundField DataField="FalseNegtive" HeaderText="False Negtive" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
        <asp:BoundField DataField="Recall" HeaderText="Recall" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
        <asp:BoundField DataField="Compulsory" HeaderText="Compulsory" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
        <asp:BoundField DataField="Credit hours" HeaderText="Credit Hr" 
                HtmlEncode="False" ItemStyle-Width="300px">
                 <ItemStyle Width="300px" />
                 </asp:BoundField>
                 </Columns  >
             <selectedrowstyle backcolor="LightCyan"
         forecolor="DarkBlue"
         font-bold="true"/> 
        </asp:GridView>
       <asp:LinkButton ID="lnkDummy" runat="server"></asp:LinkButton>
   
    </div>


    <div style="margin-top:20px">
    <h2>Smester 1 NonSuggest Modules</h2>
        <asp:GridView ID="Gv_SM1_NO" runat="server" Width="904px" AutoGenerateColumns="false">
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
                 </Columns  >
        </asp:GridView>
    </div>











    <div style="margin-top:20px">
    <h2>Smester 2 suggest Modules</h2>
        <asp:GridView ID="GV_SM2" runat="server" Width="909px" AutoGenerateColumns="false">
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
                 </Columns  >
        </asp:GridView>
        </div>



        <div style="margin-top:20px">
    <h2>Smester 2 NonSuggest Modules</h2>
        <asp:GridView ID="Gv_SM2_NO" runat="server" Width="904px" AutoGenerateColumns="false">
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
                 </Columns  >
        </asp:GridView>
    </div>


    </asp:Panel>
</asp:Content>
