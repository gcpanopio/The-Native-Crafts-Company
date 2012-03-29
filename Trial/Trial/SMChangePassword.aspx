<%@ Page Title="" Language="C#" MasterPageFile="~/SM.Master" AutoEventWireup="true" CodeBehind="SMChangePassword.aspx.cs" Inherits="Trial.SMChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="changePword">
        <center><asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" CssClass="errorLoginLabel"  ></asp:Label><br /><br />
        <p>Current Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox1" runat="server" Width="223px" CssClass="textbox" TextMode="Password"></asp:TextBox></p>
        <p>New Password:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:TextBox ID="TextBox2" runat="server" Width="222px" CssClass="textbox" TextMode="Password"></asp:TextBox></p>
        <p>Retype New Password:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="222px" CssClass="textbox" TextMode="Password"></asp:TextBox></p><br />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" CssClass="submitButton2" /></center>
    </div> 
    <br />
</asp:Content>

