<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewInventoryAdd.aspx.cs" Inherits="Trial.HRViewInventoryAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="RightContent" runat="server">
    <div class="HREditProfile">  
         <p>Availability:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
             <asp:DropDownList ID="DropDownList1" runat="server" Height="22px" Width="142px" 
                 CssClass="shortTB3">
                 <asp:ListItem Selected="True">True</asp:ListItem>
                 <asp:ListItem>False</asp:ListItem>
             </asp:DropDownList></p>
         <p>Product Name:&nbsp;&nbsp;&nbsp;<asp:TextBox ID="TextBox1" runat="server" 
                 Height="22px" CssClass="shortTB3"></asp:TextBox></p>
         <p>Price:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
                 ID="TextBox2" runat="server" CssClass="shortTB3"></asp:TextBox></p>
         <p>Quantity:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:TextBox 
                 ID="TextBox3" runat="server" CssClass="shortTB3"></asp:TextBox></p><br />
         <p><asp:Label ID="Label2" runat="server" Text="" CssClass="failureNotification"></asp:Label></p>
         <p><asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
         <asp:Button ID="Button2" runat="server" Text="Cancel" OnClick="Button2_Click" />
         </p>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Sidebar2" runat="server">
</asp:Content>
