<%@ Page Title="" Language="C#" MasterPageFile="~/Report.Master" AutoEventWireup="true" CodeBehind="UMViewInventory.aspx.cs" Inherits="Trial.UMViewInventory" %>
<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
     <br /><br />
     
     <asp:GridView DataKeyNames="product_no" ID="GridView1" runat="server" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Height="149px" style="width:100%;"  CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" OnRowDataBound="GridView1_RowDataBound" 
       onselectedindexchanged="GridView1_SelectedIndexChanged"
 
         Width="680px">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="product_no" HeaderText="Product No." 
                 InsertVisible="False" ReadOnly="True" SortExpression="product_no" 
                 ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="product_name" HeaderText="Product Name" 
                 SortExpression="product_name" ItemStyle-HorizontalAlign="Left" 
                 HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Left"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" 
                 ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
             </asp:BoundField>
             <asp:BoundField DataField="quantity" HeaderText="Quantity" 
                 SortExpression="quantity" ItemStyle-HorizontalAlign="Right" 
                 HeaderStyle-HorizontalAlign="Center">
<HeaderStyle HorizontalAlign="Center"></HeaderStyle>

<ItemStyle HorizontalAlign="Right"></ItemStyle>
             </asp:BoundField>
             <asp:TemplateField HeaderText=" ">
                 <ItemTemplate>
                 </ItemTemplate>
               </asp:TemplateField>
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
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
         SelectCommand="SELECT [product_no], [product_name], [price], [quantity] FROM [PRODUCTS] WHERE ([availability] = @availability)">
         <SelectParameters>
             <asp:Parameter DefaultValue="true" Name="availability" Type="Boolean" />
         </SelectParameters>
     </asp:SqlDataSource>
    
     </asp:Content>