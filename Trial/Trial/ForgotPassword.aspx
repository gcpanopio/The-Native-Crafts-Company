<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ForgotPassword.aspx.cs" Inherits="Trial.ForgotPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="changePword"><center>
        <p><br />To retrieve your password please enter your username. Make sure you have an internet connection.</p><br /><br />
        <p><asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label></p><br />
        <p>Username:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="217px"></asp:TextBox></p>
       
        <br />
        <p><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Retrieve Password" style="height:30px;"/></p></center>
    </div>
</asp:Content>
