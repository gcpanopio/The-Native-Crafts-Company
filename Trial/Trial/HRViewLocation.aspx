<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewLocation.aspx.cs" Inherits="Trial.HRViewLocation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
     <br /><p><asp:Label ID="Label1" runat="server" CssClass="failureNotification" Text=""></asp:Label></p>
     <br /><br />
     <asp:GridView DataKeyNames="Location_Name" ID="GridView1" runat="server" AllowSorting="True" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="87px" 
       style="margin-left: 25%; width: 50%;" CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" 
       onselectedindexchanged="GridView1_SelectedIndexChanged"
       OnRowCommand="GridView1_RowCommand" 
       OnRowDataBound="GridView1_RowDataBound" 
       OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="Location_Name" HeaderText="Location Name" SortExpression="Location_Name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
             <asp:TemplateField HeaderText=" ">
                 <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Delete" CommandArgument='<%# Eval("Location_Name") %>' CommandName="Delete" />
                    <asp:Button ID="Button2" runat="server" Text="View" CommandArgument='<%# Eval("Location_Name") %>' CommandName="View" />
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
         SelectCommand="SELECT DISTINCT [Location_Name] FROM [LOCATION]"
         DeleteCommand="DELETE FROM [LOCATION] WHERE [Location_Name]=@original_Location_Name" >
    <DeleteParameters>
        <asp:Parameter Name="original_Location_Name" Type="String" /> 
    </DeleteParameters>
     </asp:SqlDataSource>
  
    
     </asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar2" runat="server">
                <p class="sidebar">
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" 
                        onclick="LinkButton1_Click" >Add Location</asp:LinkButton>
                    &nbsp;
                </p>
</asp:Content>