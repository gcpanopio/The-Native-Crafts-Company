<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" CodeBehind="AgentProfileEdit.aspx.cs" Inherits="Trial.AgentProfileEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
        <div class="profileView">
            <div class = "profileRight">
                <p>You can only edit certain parts of your profile.</p><br />
                <p > <strong>Employee No.:&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label1" runat="server"></asp:Label></p>
                <br />
                <p> <strong>Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label2" runat="server"></asp:Label></p>
                <p> <strong>Address:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    <asp:TextBox ID="TextBox1" class="longTB" runat="server" style="width:70%; "></asp:TextBox></p>
                <p> <strong>Contact No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    <asp:TextBox ID="TextBox2" class="shortTB" runat="server" ></asp:TextBox></p>
                <p> <strong>Birthdate:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label6"  runat="server"></asp:Label></p>
                <p> <strong>SSS:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label8" runat="server"></asp:Label></p>
                <br />
                <p> <strong>Position:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label10" runat="server"></asp:Label></p>
                <p> <strong>Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label13" runat="server"></asp:Label></p>
                <p> <strong>Date Hired:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label12" runat="server"></asp:Label></p>
            </div>
            <div class = "profileLeft2">
                <p > <strong>E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
                    <asp:TextBox ID="TextBox3" class="shortTB" runat="server" CssClass="shortTB" ></asp:TextBox></p>
                <p > <strong>Gender:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="Label7" runat="server"></asp:Label></p>
                <p > <strong>TIN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong><asp:Label ID="Label9" runat="server"></asp:Label></p>
            </div>
            <asp:Button ID="Button5" runat="server" onclick="Button5_Click" Text="Save Changes" CssClass="editButton"  />
            <p> <asp:Label ID="Label14" runat="server" ForeColor="Red"></asp:Label></p>
        </div>

</asp:Content>
