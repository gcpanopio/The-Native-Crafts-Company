<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewLocationProfile.aspx.cs" Inherits="Trial.HRViewLocationProfile" %>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
     <br />
     <p><asp:Label ID="Label1" runat="server" CssClass="failureNotification" Text=""></asp:Label></p>
     
     <br /><p class="LocationName"><ui>
  <asp:Label ID="LocationName" runat="server" Text=""></asp:Label></ui>
     </p>
     
     <asp:GridView DataKeyNames="Location_No" ID="GridView1" runat="server" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="76px" 
       style="margin-left: 25%; width: 50%;" CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" 
       onselectedindexchanged="GridView1_SelectedIndexChanged"
       OnRowCommand="GridView1_RowCommand" 
       OnRowDataBound="GridView1_RowDataBound" 
       OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" 
         Width="396px" AllowSorting="True">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="Location_No" HeaderText="Location_No" SortExpression="Location_No" InsertVisible="False" ReadOnly="True" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="Location_Address" HeaderText="Location_Address" SortExpression="Location_Address" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
                 <asp:TemplateField HeaderText=" ">
               <ItemTemplate>
                 <asp:Button ID="Button1" runat="server" Text="Delete" CommandArgument='<%# Eval("Location_No") %>' CommandName="Delete" />
               </ItemTemplate>
             </asp:TemplateField>
             <asp:CommandField ButtonType="Button" ShowEditButton="True" />
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
         
         SelectCommand="SELECT [Location_No], [Location_Address] FROM [LOCATION] WHERE ([Location_Name] = @Location_Name)"
         DeleteCommand="DELETE FROM [LOCATION] WHERE ([Location_No]=@original_Location_No)"
         UpdateCommand="UPDATE LOCATION SET [Location_Address] = @Location_Address WHERE [Location_No] = @Location_No"  >
         <SelectParameters>
             <asp:SessionParameter Name="Location_Name" SessionField="VlocName" Type="String" />
         </SelectParameters>
         <UpdateParameters>
           <asp:Parameter Type="String" Name="Location_Address"></asp:Parameter>
           <asp:Parameter Type="Int32" Name="Location_No"></asp:Parameter>
         </UpdateParameters>
         <DeleteParameters>
           <asp:Parameter Type="Int32" Name="original_Location_No"></asp:Parameter>
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