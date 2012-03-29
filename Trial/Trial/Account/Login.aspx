<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Trial.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="loginC" align="center">
        <p class="logintext"><br />Please enter your username and password to log in.</p>
        <br />
        <p class="logintext"><asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" CssClass="errorLoginLabel" style="margin-bottom: 20px; float: none; height: 8px; font-size: small; width: 530px;"></asp:Label>&nbsp;</p>
        <br />
        <p class="logintext">Username:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="223px" CssClass="textbox"></asp:TextBox></p>
        <br />
        <p class="logintext">Password:&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="222px" CssClass="textbox" TextMode="Password"></asp:TextBox></p>
        <br />
        <div class="loginB">
            <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" CssClass="submitButton"  />
            <p class="blue">&nbsp;<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click" CssClass="logintext">Forgot your password?</asp:LinkButton></p>
        </div>
    </div> 
</asp:Content>
