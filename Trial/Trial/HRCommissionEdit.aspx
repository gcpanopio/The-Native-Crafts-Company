<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.Master" AutoEventWireup="true" CodeBehind="HRCommissionEdit.aspx.cs" Inherits="Trial.HRCommissionEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
    <div class="HREditProfile">
        <p><asp:Label ID="Label1" runat="server" CssClass="failureNotification" Text=""></asp:Label></p>
        <br />
        <p>Agent Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></p>
        <p>Unit Manager Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></p>
        <p>Sales Manager Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></p><br />
        <p><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Save" /></p>
    </div>
</asp:Content>
