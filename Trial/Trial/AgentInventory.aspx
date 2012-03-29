<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" CodeBehind="AgentInventory.aspx.cs" Inherits="Trial.AgentInventory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h1> SYSTEM INVENTORY </h1><br />
    <div class="instructions">
    <p> <b>INSTRUCTIONS: </b>&nbsp;&nbsp; <br />&nbsp;&nbsp;&nbsp; Place your orders by ticking the 
        checkbox and specifying the quantity of desired products. You can sort the System 
        Inventory by clicking the &nbsp;column headers.</p></div>
    <div class="legendCopyRight"><b>Legend:</b>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<p 
            class="quantityless202"><asp:Label ID="Label2" runat="server" Text="Quantity is 20 or less"></asp:Label></p> 
     </div>
     <br/><br/><br/><br/><br/><br/>
    <p> <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label></p>
    <p>  
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Order" 
            Width="107px" class = "orderButton"/>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" 
            AutoGenerateColumns="False" CellPadding="4" DataSourceID="SqlDataSource1" 
            Height="149px" style="width:80%; margin-left: 140px; " 
            ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="chkchild" runat="server"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Width="50px"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="product_no" HeaderText="Product No" InsertVisible="False" ReadOnly="True" SortExpression="product_no" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="product_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="price" HeaderText="Price" SortExpression="price" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
                <asp:BoundField DataField="quantity" HeaderText="Quantity" SortExpression="quantity" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Center"/>
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
    </p>
    <p> 
        &nbsp;</p>
    <p> 
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
            SelectCommand="SELECT [product_no], [product_name], [price], [quantity] FROM [PRODUCTS] WHERE ([availability] = @availability) AND (quantity > 0)">
            <SelectParameters>
                <asp:Parameter DefaultValue="True" Name="availability" Type="Boolean" />
            </SelectParameters>
        </asp:SqlDataSource>
    </p>
    <p> 
        &nbsp;</p>
</asp:Content>
