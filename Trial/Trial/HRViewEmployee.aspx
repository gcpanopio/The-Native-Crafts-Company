<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewEmployee.aspx.cs" Inherits="Trial.HRViewEmployee" %>
 
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
    
     <p><asp:Label ID="Label1" runat="server" CssClass="failureNotification" Text=""></asp:Label></p><br />
    
     <asp:GridView DataKeyNames="employee_no" ID="GridView1" runat="server" AllowSorting="True" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="149px" 
       style="margin-left: auto; width: 100%;" CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" 
       onselectedindexchanged="GridView1_SelectedIndexChanged"
       OnRowCommand="GridView1_RowCommand" 
       OnRowDataBound="GridView1_RowDataBound" 
       OnRowDeleted="GridView1_RowDeleted" 
       OnRowDeleting="GridView1_RowDeleting" Width="732px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="employee_no" HeaderText="Employee No." InsertVisible="False" ReadOnly="True" SortExpression="employee_no" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="l_name" HeaderText="Last Name" SortExpression="l_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="f_name" HeaderText="First Name" SortExpression="f_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="m_name" HeaderText="Middle Name" SortExpression="m_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
             
             <asp:TemplateField HeaderText=" ">
                 <ItemTemplate>
                    <asp:Button ID="Button1" runat="server"  Text="Delete" CommandArgument='<%# Eval("employee_no") %>' CommandName="Delete" />
                    <asp:Button ID="Button2" runat="server"  Text="View" CommandArgument='<%# Eval("employee_no") %>' CommandName="View"/>
                 </ItemTemplate>
               </asp:TemplateField>
         </Columns>
         <EditRowStyle BackColor="#7C6F57" />
         <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#E3EAEB" />
         <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F8FAFA" />
         <SortedAscendingHeaderStyle BackColor="#246B61" />
         <SortedDescendingCellStyle BackColor="#D4DFE1" />
         <SortedDescendingHeaderStyle BackColor="#15524A" />
     </asp:GridView>
     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
         ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
         
         
         SelectCommand="SELECT [employee_no], [l_name], [f_name], [m_name] FROM [EMPLOYEEPROFILE]" 
         DeleteCommand="DELETE FROM [EMPLOYEEPROFILE] WHERE [employee_no]=@original_employee_no" >
    <DeleteParameters>
        <asp:Parameter Name="original_employee_no" Type="Int32" /> 
    </DeleteParameters>
     </asp:SqlDataSource>
    
     </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar2" runat="server">
                <p class="sidebar">
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" 
                        onclick="LinkButton1_Click" >Add Employee</asp:LinkButton>
                    &nbsp;
                </p>
</asp:Content>