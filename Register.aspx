<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="container">
            <div class="col-md-12 img-center">
                <h3><span class="glyphicon glyphicon-pencil"></span> &nbsp; Register </h3>
                <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CssClass="img-circle-border img-thumbnail regBox">
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                    <TitleTextStyle cssclass="loginboxTitle" />
                </asp:CreateUserWizard>
            </div>
    </div>
</asp:Content>

