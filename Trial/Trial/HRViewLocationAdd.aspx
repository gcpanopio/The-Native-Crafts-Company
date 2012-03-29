<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewLocationAdd.aspx.cs" Inherits="Trial.HRViewLocationAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightContent" runat="server">
    <div class = "HREditProfile">
        <p>Location Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox2" runat="server" Width="301px" CssClass="shortTB3"></asp:TextBox></p>
        <p>Location Address:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" Width="304px" CssClass="shortTB3"></asp:TextBox></p><br />
        <p><asp:Label ID="Label2" runat="server" Text="" CssClass="failureNotification"></asp:Label></p>
        <p><asp:Button ID="Button1" runat="server" Text="Add" onclick="Button1_Click"/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Text="Cancel" onclick="Button2_Click"/>
        </p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Sidebar2" runat="server">
</asp:Content>
