<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtistList.aspx.cs" Inherits="ArtistList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-12 img-center">
                <h3><span class="glyphicon glyphicon-user"></span>&nbsp; Artists List </h3>
                 <asp:GridView CssClass="link-gridview-adj" ID="listArtists" runat="server" GridLines="None" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="Id" PageSize="6">
                    <Columns>
                        <asp:ImageField DataAlternateTextFormatString="LastName" DataImageUrlField="Id" ControlStyle-CssClass="img-center img-circle img-circle-border spacing-gridview" DataImageUrlFormatString="Assets/art-images/artists/square-medium/{0}.jpg"></asp:ImageField>
                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="SingleArtist.aspx?id={0}" DataTextField="FullName" SortExpression="FullName" />
                    </Columns>
                </asp:GridView>
            </div>
        </div><!--/Row-->
    </div><!--/Container-->
    
</asp:Content>

