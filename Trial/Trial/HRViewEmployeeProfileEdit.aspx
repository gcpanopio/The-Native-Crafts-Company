<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewEmployeeProfileEdit.aspx.cs" Inherits="Trial.HRViewEmployeeProfileEdit" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">

<div class="HREditProfile">
    <p><strong>Employee No.:&nbsp; </strong><asp:Label ID="Label1" runat="server"></asp:Label></p>
    <br/>
    <p><strong>Last Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox4" runat="server" Width="300px" CssClass="shortTB2"></asp:TextBox></p>
    <p><strong>First Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox7" runat="server" Width="300px" Height="22px" 
            CssClass="shortTB2"></asp:TextBox></p>
    <p><strong>Middle Name:&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox8" 
            runat="server" Width="301px" CssClass="shortTB2"></asp:TextBox></p><br />
    <p><strong>Address:&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox1" runat="server" Width="454px" CssClass="longTB2"></asp:TextBox></p>
    <p><strong>Contact No.:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox2" runat="server" Width="300px" CssClass="shortTB2"></asp:TextBox></p>
    <p><strong> E-mail:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox3" runat="server" Width="300px" CssClass="shortTB2"></asp:TextBox></p>
    <p><strong>Birthdate:</strong></p><p class="DateInput">
        <asp:DropDownList ID="DropDownList4" runat="server" style="left:200px;">
            <asp:ListItem Value="1">January</asp:ListItem>
            <asp:ListItem Value="2">February</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">July</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:DropDownList ID="DropDownList5" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
        &nbsp;
        <asp:TextBox ID="TextBox9" runat="server" Width="105px"></asp:TextBox></p>
    <p><strong> Gender:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:DropDownList ID="DropDownList8" runat="server" Height="22px" Width="300px" 
            AutoPostBack="True" CssClass="shortTB2">
            <asp:ListItem>Male</asp:ListItem>
            <asp:ListItem>Female</asp:ListItem>
        </asp:DropDownList></p>
    <p><strong>SSS:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox5" runat="server" Width="300px" CssClass="shortTB2"></asp:TextBox></p>
    <p><strong> TIN:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:TextBox ID="TextBox6" runat="server" Width="300px" CssClass="shortTB2"></asp:TextBox></p>
    <br />
    <p><strong>Position:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSource1" DataTextField="Position" 
            DataValueField="Position_ID" Height="21px" Width="300px" 
            CssClass="shortTB2"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" SelectCommand="SELECT [Position_ID], [Position] FROM [POSITION]"></asp:SqlDataSource></p>
    <p><strong>Location:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </strong>
        <asp:DropDownList ID="DropDownList3" runat="server" 
            DataSourceID="SqlDataSource2" DataTextField="Location_Address" 
            DataValueField="Location_No" Height="19px" Width="300px" 
            CssClass="shortTB2"></asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" SelectCommand="SELECT [Location_No], [Location_Address] FROM [LOCATION]"></asp:SqlDataSource></p>
      <p><strong>Date Hired: </strong> </p><p class="DateInput2"> 
        <asp:DropDownList ID="DropDownList6" runat="server" style="left:200px;">
            <asp:ListItem Value="1">January</asp:ListItem>
            <asp:ListItem Value="2">February</asp:ListItem>
            <asp:ListItem Value="3">March</asp:ListItem>
            <asp:ListItem Value="4">April</asp:ListItem>
            <asp:ListItem Value="5">May</asp:ListItem>
            <asp:ListItem Value="6">June</asp:ListItem>
            <asp:ListItem Value="7">July</asp:ListItem>
            <asp:ListItem Value="8">August</asp:ListItem>
            <asp:ListItem Value="9">September</asp:ListItem>
            <asp:ListItem Value="10">October</asp:ListItem>
            <asp:ListItem Value="11">November</asp:ListItem>
            <asp:ListItem Value="12">December</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:DropDownList ID="DropDownList7" runat="server">
            <asp:ListItem>1</asp:ListItem>
            <asp:ListItem>2</asp:ListItem>
            <asp:ListItem>3</asp:ListItem>
            <asp:ListItem>4</asp:ListItem>
            <asp:ListItem>5</asp:ListItem>
            <asp:ListItem>6</asp:ListItem>
            <asp:ListItem>7</asp:ListItem>
            <asp:ListItem>8</asp:ListItem>
            <asp:ListItem>9</asp:ListItem>
            <asp:ListItem>10</asp:ListItem>
            <asp:ListItem>11</asp:ListItem>
            <asp:ListItem>12</asp:ListItem>
            <asp:ListItem>13</asp:ListItem>
            <asp:ListItem>14</asp:ListItem>
            <asp:ListItem>15</asp:ListItem>
            <asp:ListItem>16</asp:ListItem>
            <asp:ListItem>17</asp:ListItem>
            <asp:ListItem>18</asp:ListItem>
            <asp:ListItem>19</asp:ListItem>
            <asp:ListItem>20</asp:ListItem>
            <asp:ListItem>21</asp:ListItem>
            <asp:ListItem>22</asp:ListItem>
            <asp:ListItem>23</asp:ListItem>
            <asp:ListItem>24</asp:ListItem>
            <asp:ListItem>25</asp:ListItem>
            <asp:ListItem>26</asp:ListItem>
            <asp:ListItem>27</asp:ListItem>
            <asp:ListItem>28</asp:ListItem>
            <asp:ListItem>29</asp:ListItem>
            <asp:ListItem>30</asp:ListItem>
            <asp:ListItem>31</asp:ListItem>
        </asp:DropDownList>
        &nbsp;<asp:TextBox ID="TextBox10" runat="server" Width="109px"></asp:TextBox></p>
         <p><asp:Label ID="Label12" runat="server" CssClass="failureNotification" Text=" "></asp:Label></p> 
    
        <asp:Button ID="Button1" runat="server" ForeColor="#006600" onclick="Button1_Click" Text="Save Changes" CssClass="editButton"/>
</div>
</asp:Content>
