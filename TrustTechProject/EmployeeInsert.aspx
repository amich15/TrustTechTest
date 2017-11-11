<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmployeeInsert.aspx.cs" Inherits="TrustTechProject.EmployeeInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/Site.css" rel="stylesheet" />
    <link href="Content/mySite.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>New Employee</h1>
        </div>
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
                        <asp:Label ID="lblFName" runat="server" Text="First Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtFName" runat="server"></asp:TextBox>
                    </td>
                    <asp:RequiredFieldValidator ID="rfvFName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtFName"></asp:RequiredFieldValidator>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblLName" runat="server" Text="Last Name:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtLName" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvLName" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtLName"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblEmployeeId" runat="server" Text="EmployeeId:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmployeeId" runat="server" MaxLength="9"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvEmployeeId" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="txtEmployeeId"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rgexEmployeeId" runat="server" Display="Dynamic" ControlToValidate="txtEmployeeId" ErrorMessage="Enter 0-9  Number Only." ValidationExpression="^\d{0,9}$"></asp:RegularExpressionValidator></code>
                    </td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <asp:RadioButtonList ID="rblGender" runat="server">
                    <asp:ListItem Text="M" Value="M"></asp:ListItem>
                    <asp:ListItem Text="F" Value="F"></asp:ListItem>


                </asp:RadioButtonList>
                <tr>
                    <td>
                        <asp:Label ID="lblBirthDate" runat="server" Text="BirthDate:"></asp:Label>

                    </td>
                    <td>
                        <input type="date" id="dt2" runat="server" />
                        <asp:RequiredFieldValidator ID="rfvBirthDate" runat="server" ErrorMessage="RequiredFieldValidator" ControlToValidate="dt2"></asp:RequiredFieldValidator>
                    </td>

                </tr>
                <tr>
                    <td></td>
                </tr>

            </table>

        </div>
        <div>
            <asp:Button ID="btnAddRow" runat="server" Text="Add Employee" OnClick="btnAddRow_Click" />
            <asp:Button ID="btnEmployees" runat="server" Text="Main Screen" OnClick="btnEmployees_Click" CausesValidation="false" />
        </div>

        <div>
            <asp:Label ID="lblRowInsert" ClientIDMode="Static" runat="server" Text="New Employee Confirmed" Visible="false" ForeColor="Red"></asp:Label>
        </div>


    </form>
</body>
</html>
