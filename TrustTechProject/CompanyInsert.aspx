<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CompanyInsert.aspx.cs" Inherits="TrustTechProject.CompanyInsert" %>

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
            <h1>New Company</h1>
        </div>
        <div>
            <table>

                <tr>
                    <td>
                        <asp:Label ID="lblCompanyNum" runat="server" Text="Company Number:"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCompanyNum" runat="server"></asp:TextBox>
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
            <asp:Button ID="btnAddRow" runat="server" Text="Add Company" OnClick="btnAddRow_Click" />
            <asp:Button ID="btnComapnies" runat="server" Text="Main Screen" OnClick="btnComapnies_Click" CausesValidation="false" />
        </div>

        <div>
            <asp:Label ID="lblRowInsert" runat="server" Text="Row Inserted" Visible="false" ForeColor="Red"></asp:Label>
        </div>
    </form>
</body>
</html>
