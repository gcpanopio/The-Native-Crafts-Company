<%@ Page Title="" Language="C#" MasterPageFile="~/SMReport.master" AutoEventWireup="true" CodeBehind="SMViewLocation.aspx.cs" Inherits="Trial.SMViewLocation" %>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
     <br /><br />
     <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource1" Height="149px" style="width:100%;" 
         CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" OnRowDataBound="GridView1_RowDataBound" 
       onselectedindexchanged="GridView1_SelectedIndexChanged">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="Location_Address" HeaderText="Location_Address" 
                 SortExpression="Location_Address" ItemStyle-HorizontalAlign="Left" 
                 HeaderStyle-HorizontalAlign="Center">
             </asp:BoundField>
             <asp:TemplateField HeaderText="Sales" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
                <ItemTemplate>
                  <asp:Label ID="Label1" runat="server"></asp:Label>
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
         
         SelectCommand="SELECT [Location_Address] FROM [LOCATION] WHERE ([Location_Name] = @Location_Name)">
         <SelectParameters>
             <asp:SessionParameter Name="Location_Name" SessionField="locName" Type="String" />
         </SelectParameters>
     </asp:SqlDataSource>
  
    
     </asp:Content>