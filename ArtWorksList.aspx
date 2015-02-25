<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ArtWorksList.aspx.cs" Inherits="ArtistWorksList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-12 img-center">
                <h3><span class="glyphicon glyphicon-picture"></span>&nbsp; Artworks List </h3>
                <asp:GridView CssClass="link-gridview-adj" ID="artWorkList" runat="server" GridLines="None" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" AutoGenerateColumns="False" DataKeyNames="Id" PageSize="6">
                    <Columns>
                        <asp:ImageField ControlStyle-CssClass="img-center img-circle img-circle-border spacing-gridview" DataAlternateTextFormatString="Title" DataImageUrlField="ImageFileName" DataImageUrlFormatString="Assets/art-images/works/square-medium/{0}.jpg">
                        </asp:ImageField>
                        <asp:HyperLinkField DataNavigateUrlFields="Id" DataNavigateUrlFormatString="SingleArtwork.aspx?id={0}" DataTextField="Title" SortExpression="Title" />
                    </Columns>
                </asp:GridView>
            </div>
        </div><!--/Row-->
     </div><!--/Container-->
</asp:Content>

