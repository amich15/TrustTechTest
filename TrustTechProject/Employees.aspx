<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Employees.aspx.cs" Inherits="TrustTechProject.Employees" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Employees</title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/mySite.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <h1><%=strCname %> Company</h1>
        <div>
            <table>

                <tr>
                    <td>
                        <asp:Label ID="lblCompanyNum" runat="server" Text="Company Number:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyNum" runat="server" Enabled="false"></asp:TextBox>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblCompanyName" runat="server" Text="Company Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvCompanyName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtCompanyName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblTelephone" runat="server" Text="Telephone"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTelephone" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvTelephone" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtTelephone"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="btnUpdate" runat="server" Text="Update DB" OnClick="btnUpdate_Click" />
            <asp:Button ID="btnDelete" runat="server" Text="Delete Company" OnClick="btnDelete_Click" />
            <asp:Button ID="btnCompany" runat="server" Text="Main Screen" OnClick="btnCompany_Click" CausesValidation="false" />
        </div>
        <div>
            <asp:Label ID="lblUpdateRow" runat="server" Text="DB Updated" Visible="false" ForeColor="Red"></asp:Label>
        </div>

        <div>
            <h1>Employees of <%=strCname %></h1>
        </div>

        <div class="searchEN">
            <asp:Label ID="lblSearchEmployee" runat="server" Text="Search By Last Name:"></asp:Label>
            <asp:TextBox ID="txtSearchEmployeeLName" runat="server"></asp:TextBox>
            <asp:Button ID="btnSearchEmployee" runat="server" Text="Search" />
        </div>
        <div class="myGridDiv">
            <asp:GridView ID="GridEmployees" runat="server" DataSourceID="SqlDataSource1" OnRowDataBound="GridEmployees_RowDataBound" OnSelectedIndexChanged="GridEmployees_SelectedIndexChanged" AutoGenerateColumns="False">
                <Columns>
                    <asp:BoundField DataField="Fname" HeaderText="First Name" SortExpression="Fname"></asp:BoundField>
                    <asp:BoundField DataField="Lname" HeaderText="Last Name" SortExpression="Lname"></asp:BoundField>
                    <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" SortExpression="EmployeeId"></asp:BoundField>
                    <asp:BoundField DataField="Gender" HeaderText="Gender" SortExpression="Gender"></asp:BoundField>
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate" SortExpression="BirthDate" DataFormatString="{0:dd/MM/yyyy}"></asp:BoundField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource runat="server" ID="SqlDataSource1" ConnectionString='<%$ ConnectionStrings:TrustConnection %>' SelectCommand="SELECT [Fname], [Lname], [EmployeeId], [Gender], [BirthDate] FROM [CompanyEmployees] WHERE ([CNum] = @CNum)" FilterExpression="Lname='{0}'">
                <SelectParameters>
                    <asp:QueryStringParameter QueryStringField="id" Name="CNum" Type="int32" DefaultValue="1234"></asp:QueryStringParameter>
                </SelectParameters>
                <FilterParameters>
                    <asp:ControlParameter Name="LNameEmployeeSearch" ControlID="txtSearchEmployeeLName" PropertyName="Text" />
                </FilterParameters>
            </asp:SqlDataSource>

            <asp:EntityDataSource runat="server" ID="TrustCompanyEntity"></asp:EntityDataSource>
        </div>
        <div>
            <asp:Button ID="btnInsertEmployess" runat="server" Text="Add New Employee" OnClick="btnInsertEmployess_Click" CausesValidation="false" />
        </div>

    </form>
</body>
</html>
