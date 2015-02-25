<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">   
        <div class="col-md-12 img-center">
                <h3><span class="glyphicon glyphicon-user"></span> &nbsp; Welcome Back </h3>
                <asp:LoginView ID="logView" runat="server" >
                        <AnonymousTemplate><!--Login Box-->
                            <asp:login ID="aLogin" runat="server" CreateUserUrl="Register.aspx" CreateUserText="Not a user?" 
                                UserNameLabelText="User:" CssClass="img-circle-border img-thumbnail loginBox">
                                <TitleTextStyle cssclass="loginboxTitle" />
                            </asp:login>
                        </AnonymousTemplate>
                        <LoggedInTemplate><!--View after user has logged in-->
                            <asp:LoginName ID="logName" runat="server"
                            FormatString="Welcome <strong>{0}</strong>" />
                        </LoggedInTemplate>
                    </asp:LoginView>
        </div>
    </div>
</asp:Content>

