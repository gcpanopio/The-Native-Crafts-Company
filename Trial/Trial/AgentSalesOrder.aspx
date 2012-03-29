<%@ Page Title="" Language="C#" MasterPageFile="~/Agent.Master" AutoEventWireup="true" CodeBehind="AgentSalesOrder.aspx.cs" Inherits="Trial.AgentSalesOrder" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h1> SALES ORDER</h1><br />
    <div class="salesorder">
        <p dir="ltr"> <strong>Total Sales for the Month:</strong><asp:Label ID="Label5" runat="server"></asp:Label></p>
        <p dir="ltr"> <asp:Label ID="Label1" runat="server" Text="Current Commission:" style="font-weight: 700"></asp:Label>&nbsp;<asp:Label ID="Label2" runat="server"></asp:Label></p>
        <p> <asp:Label ID="Label3" runat="server" Text="Commission Rate:" style="font-weight: 700"></asp:Label>&nbsp;<asp:Label ID="Label4" runat="server"></asp:Label></p>
    </div>
    <br /><br />
    <asp:DataList ID="DataList1" runat="server" DataSourceID="OrderAndTransactions" 
            style="width:100%;" >
            <ItemTemplate>
                 <div class="iTemplate">
                    <div class="iTemplateSet">
                        <div class="iTemplateDetails">
                            <strong>Transaction No.:</strong><asp:Label ID="transaction_noLabel" runat="server" Text='<%# Eval("transaction_no") %>' />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                            <br />
                            <strong>Amount:</strong><asp:Label ID="amountLabel" runat="server" Text='<%# Eval("amount") %>' />
                            <br />
                            <strong>Date and Time:</strong><asp:Label ID="date_timeLabel" runat="server" Text='<%# Eval("date_time") %>' />
                            <br />
                        </div>
                        <br />
                        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" 
                            AutoGenerateColumns="False" DataSourceID="ProductList" CellPadding="4" style="width:400px; margin-left:150px;"
                            ForeColor="#333333" GridLines="None">
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:BoundField DataField="product_no" HeaderText="Product No" SortExpression="product_no" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center"/>
                                <asp:BoundField DataField="product_name" HeaderText="Product Name" SortExpression="product_name" ItemStyle-HorizontalAlign="Left" HeaderStyle-HorizontalAlign="Center"/>
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
                        <br />
                        <asp:SqlDataSource ID="ProductList" runat="server" 
                            ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
                    
                            SelectCommand="SELECT SALESORDER.product_no, SALESORDER.quantity, PRODUCTS.product_name FROM SALESORDER JOIN PRODUCTS ON SALESORDER.product_no = PRODUCTS.product_no WHERE ([transaction_no] = @transaction_no) ">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="transaction_noLabel" Name="transaction_no" 
                                    PropertyName="Text" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                </div>
                </div>
            </ItemTemplate>
        </asp:DataList>
        <asp:SqlDataSource ID="OrderAndTransactions" runat="server" 
            ConnectionString="<%$ ConnectionStrings:OFFICIAL-DB %>" 
            SelectCommand="SELECT [transaction_no], [amount], [date_time] FROM [TRANSACTION] WHERE ([employee_no] = @employee_no) ORDER BY [date_time] DESC">
            <SelectParameters>
                <asp:SessionParameter Name="employee_no" SessionField="empNo" Type="Int64" />
            </SelectParameters>
        </asp:SqlDataSource>
    
&nbsp; 
</asp:Content>
