<%@ Page Title="" Language="C#" MasterPageFile="~/HRView.master" AutoEventWireup="true" CodeBehind="HRViewInventory.aspx.cs" Inherits="Trial.HRViewInventory" %>

<asp:Content ID="Content2" ContentPlaceHolderID="RightContent" runat="server">
     
     <asp:Label ID="Label1" runat="server" Text=" "></asp:Label><br />
     <div class="legend">
     Legend:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p class="quantityless20"><asp:Label ID="Label2" runat="server" Text="Quantity is 20 or less"></asp:Label></p> 
     &nbsp;<p class="unavailable"><asp:Label ID="Label3" runat="server" Text="Item is unavailable"></asp:Label></p></div>
     <br /><br /><br /><br /><br /><br />
     <p><asp:Label ID="Label4" runat="server" Text="" CssClass="failureNotification"></asp:Label></p>
     <br />
     
     <asp:GridView DataKeyNames="product_no" ID="GridView1" runat="server" AllowSorting="True" 
       AutoGenerateColumns="False" DataSourceID="SqlDataSource2" Height="149px" style="width:100%;" 
         CellPadding="4" ForeColor="#333333" 
       GridLines="None" DataMember="DefaultView" 
       onselectedindexchanged="GridView1_SelectedIndexChanged"
       OnRowCommand="GridView1_RowCommand" 
       OnRowDataBound="GridView1_RowDataBound" 
       OnRowDeleted="GridView1_RowDeleted" OnRowDeleting="GridView1_RowDeleting" >
         <AlternatingRowStyle BackColor="White" />
         <Columns>
             <asp:BoundField DataField="product_no" HeaderText="Product No." InsertVisible="False" ReadOnly="True" SortExpression="product_no" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="product_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
             <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
             <asp:CheckBoxField DataField="availability" HeaderText="Availability" SortExpression="availability" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
             <asp:TemplateField HeaderText=" ">
                 <ItemTemplate>
                    <asp:Button ID="Button1" runat="server" Text="Delete" CommandArgument='<%# Eval("product_no") %>' CommandName="Delete" />
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
     <asp:SqlDataSource ID="SqlDataSource2" runat="server" 
         ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
         SelectCommand="SELECT [availability], [product_no], [product_name], [price], [quantity] FROM [PRODUCTS]"
         DeleteCommand="DELETE FROM [PRODUCTS] WHERE [product_no]=@original_product_no" 
         UpdateCommand="IF @quantity = 0 UPDATE PRODUCTS SET [availability] = 'False', [product_name] = @product_name, [price] = @price, [quantity]=@quantity WHERE [product_no] = @product_no 
                        ELSE UPDATE PRODUCTS SET [availability] = @availability, [product_name] = @product_name, [price] = @price, [quantity]=@quantity WHERE [product_no] = @product_no">
         <UpdateParameters>
           <asp:Parameter Type="Boolean" Name="availability"></asp:Parameter>
           <asp:Parameter Type="String" Name="product_name"></asp:Parameter>
           <asp:Parameter Type="Decimal" Name="price"></asp:Parameter>
           <asp:Parameter Type="Int32" Name="quantity"></asp:Parameter> 
           <asp:Parameter Type="Int32" Name="product_no"></asp:Parameter>
         </UpdateParameters>              
         <SelectParameters>
             <asp:Parameter DefaultValue="true" Name="availability" Type="Boolean" />
         </SelectParameters>

         <DeleteParameters>
            <asp:Parameter Name="original_product_no" Type="Int32" /> 
        </DeleteParameters>
     </asp:SqlDataSource>

     </asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Sidebar2" runat="server">
                <p class="sidebar">
                    <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" 
                        onclick="LinkButton1_Click" >Add Product</asp:LinkButton>
                    &nbsp;
                </p>
</asp:Content>