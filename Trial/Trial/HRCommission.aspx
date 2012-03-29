<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.Master" AutoEventWireup="true" CodeBehind="HRCommission.aspx.cs" Inherits="Trial.HRCommission" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
    <div class="HREditProfile">
        <br />
        <p>Agent Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label></p>
        <p>Unit Manager Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label></p>
        <p>Sales Manager Commission:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label3" runat="server" Text=""></asp:Label></p>
        <br />
        <p><asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Edit" /></p>
    </div>
</asp:Content>
