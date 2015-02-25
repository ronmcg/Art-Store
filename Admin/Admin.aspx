<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Admin.aspx.cs" Inherits="Admin_Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Admin Console</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link href="~/Assets/css/normalize.css" rel="stylesheet" />
    <link href="~/Assets/css/bootstrap.min.css" rel="stylesheet" media="screen" />  
    <link href="~/Assets/css/styles.css" rel="stylesheet" />
    <link href="~/Assets/css/stylesAdmin.css" rel="stylesheet" />

     <!-- Bootstrap core JavaScript, jQuery (necessary for Bootstrap's JavaScript plugins) -------------------------->
    <script src="http://code.jquery.com/jquery.js"></script>
    <script src="Assets/js/bootstrap.min.js"></script>
    <script src="Assets/js/jquery-2.0.3.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        
        <div class="img-center">
            <br />
            <a class="main-pg" href="../Default.aspx">Go back to main site</a>
            <hr />
            <h1>Admin console</h1>
            <h3>Edit Customers</h3>
              <div class="container">
                <div class="col-md-12 row-adj-admin">
                    <!--List of customers-->
                    <div class="table-responsive">
                    <table class="table table-bordered table-adj">
                        <tbody>
                            <asp:Repeater ID="adminRepeat" runat="server">
                                <HeaderTemplate>
                                    <thead>
                                        <tr>
                                            <th>ID</th>
                                            <th>Name</th>
                                        </tr>
                                    </thead>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <tr>
                                        <td><%# Eval("Id") %></td>
                                        <td>
                                            <a href="Admin.aspx?edit=<%# Eval("Id") %>">
                                                <%# String.Format("{0} {1}", Eval("FirstName"), Eval("LastName")) %>
                                            </a>
                                        </td>
                                    </tr>
                                </ItemTemplate>
                            </asp:Repeater>
                        </tbody>
                    </table>
                    </div><!--/Collapse-->
                    <!--End list of customers-->
                    <!--Edit customer-->
                    <asp:FormView ID="editView" runat="server" CssClass="table table-bordered">
                        <HeaderTemplate>
                            <asp:HyperLink ID="linBack" runat="server" NavigateUrl="~/Admin/Admin.aspx" Text="Back to list" />
                            <br />
                            <asp:RequiredFieldValidator ID="requiredFirst" Display="Dynamic" CssClass="required" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*A first name is required<br />" />
                            <asp:RequiredFieldValidator ID="requiredLast" Display="Dynamic" CssClass="required" runat="server" ControlToValidate="txtLastName" ErrorMessage="*A last name is required<br />" />
                            <asp:RegularExpressionValidator ID="regexEmail" Display="Dynamic" CssClass="required" runat="server" ControlToValidate="txtEmail" ErrorMessage="*Email must be in the form example@example.com" ValidationExpression=".*@.*"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="requiredEmail" Display="Dynamic" CssClass="required" runat="server" ControlToValidate="txtEmail" ErrorMessage="*An email is required<br />" />
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tbody>
                                <tr>
                                    <td>First Name</td>
                                    <td>
                                        <asp:TextBox ID="txtFirstName" runat="server" CssClass="edit" Text='<%# Eval("FirstName") %>' /></td>

                                </tr>
                                <tr>
                                    <td>Last Name</td>
                                    <td>
                                        <asp:TextBox ID="txtLastName" runat="server" CssClass="edit" Text='<%# Eval("LastName") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Address</td>
                                    <td>
                                        <asp:TextBox ID="txtAddress" runat="server" CssClass="edit" Text=' <%# Eval("Address") %>' /></td>
                                </tr>
                                <tr>
                                    <td>City</td>
                                    <td>
                                        <asp:TextBox ID="txtCity" runat="server" CssClass="edit" Text=' <%# Eval("City") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Region</td>
                                    <td>
                                        <asp:TextBox ID="txtRegion" runat="server" CssClass="edit" Text=' <%# Eval("Region") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Country</td>
                                    <td>
                                        <asp:TextBox ID="txtCountry" runat="server" CssClass="edit" Text=' <%# Eval("Country") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Postal</td>
                                    <td>
                                        <asp:TextBox ID="txtPostal" runat="server" CssClass="edit" Text=' <%# Eval("Postal") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Phone</td>
                                    <td>
                                        <asp:TextBox ID="txtPhone" runat="server" CssClass="edit" Text=' <%# Eval("Phone") %>' /></td>
                                </tr>
                                <tr>
                                    <td>Email</td>
                                    <td>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="edit" Text=' <%# Eval("Email") %>' />
                                    </td>
                                </tr>
                                <tr>
                                    <td>Privacy</td>
                                    <td>
                                        <asp:TextBox ID="txtPrivacy" runat="server" CssClass="edit" Text=' <%# Eval("Privacy") %>' /></td>
                                </tr>
                            </tbody>
                        </ItemTemplate>
                        <FooterTemplate>
                            <asp:Button ID="btnSubmit" runat="server" Text="Update" CssClass="btn btn-success pull-right" OnClick="btnSubmit_Click" />
                        </FooterTemplate>
                    </asp:FormView><!--End edit customer-->
                </div><!--/col--> 
             </div><!--/Container-->
        </div><!--/Center Title/Link to Main-->
    </form>
</body>
</html>
