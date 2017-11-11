<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Companies.aspx.cs" Inherits="TrustTechProject.Companies" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/mySite.css" rel="stylesheet" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1 class="myFirst">Companies List</h1>

            <div class="searchCN">
                <asp:Label ID="lblSearchCompany" runat="server" Text="Search By Name:"></asp:Label>
                <asp:TextBox ID="txtSearchCompany" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearchCompany" runat="server" Text="Search" />
            </div>

            <div class="myGridDiv">


                <asp:GridView ID="GridCompanies" runat="server" OnRowDataBound="GridCompanies_RowDataBound" OnSelectedIndexChanged="GridCompanies_SelectedIndexChanged"
                    CssClass="myGrid" DataSourceID="SqlDataSource1" AutoGenerateColumns="False" DataKeyNames="Id" HeaderStyle-BackColor="#3AC0F2" HeaderStyle-ForeColor="White">
                    <Columns>

                        <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id" Visible="false"></asp:BoundField>
                        <asp:BoundField DataField="CNum" HeaderText="Company Number" SortExpression="CNum" ReadOnly="True">
                            <ControlStyle Width="300px"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Cname" HeaderText="Company Name" SortExpression="Cname">
                            <ControlStyle Width="300px"></ControlStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address">
                            <ControlStyle Width="200px"></ControlStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="companyAddrss"></HeaderStyle>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="Telephone" HeaderText="Telephone" SortExpression="Telephone">
                            <ControlStyle Width="300px"></ControlStyle>
                        </asp:BoundField>
                    </Columns>
                </asp:GridView>
                <asp:EntityDataSource runat="server" ID="CompanyEntityDataSource"></asp:EntityDataSource>
                <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:TrustConnection %>' SelectCommand="SELECT [Id], [CNum], [Cname], [Address], [Telephone] FROM [Companies]" FilterExpression="cName='{0}'">
                    <FilterParameters>
                        <asp:ControlParameter Name="companySearch" ControlID="txtSearchCompany" PropertyName="Text" />
                    </FilterParameters>
                </asp:SqlDataSource>

            </div>
            <asp:Button ID="btnInsertCompany" runat="server" Text="Add New Company" OnClick="btnInsertCompany_Click" />
        </div>
    </form>
</body>
</html>
