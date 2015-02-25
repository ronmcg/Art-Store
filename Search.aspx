<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Search.aspx.cs" Inherits="Search" %>

<%@ Register Src="~/Controls/ArtWorkResultsControl.ascx" TagPrefix="uc" TagName="ArtWorkResults" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

        <!-- Diplaying the Advanced Search Box -->
        <div class="container">

            <h2>Search</h2>
            <hr />
            <div class="well">
                <p class="text-muted">Simple Search</p>
                <asp:RadioButtonList ID="rbOptions" runat="server" AutoPostBack="true" >
                    <asp:ListItem Value="1" Selected="True"> &nbsp;Artwork Title</asp:ListItem>
                    <asp:ListItem Value="2"> &nbsp;Artist's Name</asp:ListItem>
                </asp:RadioButtonList>
                <asp:TextBox CssClass="moreCriteria" ID="txtTitle" runat="server" />
                <asp:Panel ID="mCriteria" runat="server" Visible="true" >
                    <br />
                    <br />
                    <p class="text-muted">More Criteria (Artworks)</p>
                    <p class="rangeTitle">Year Range</p>
                    <asp:TextBox CssClass="range" ID="txtYearStart" runat="server" placeholder="Start" />
                    <asp:TextBox CssClass="range" ID="txtYearEnd" runat="server" placeholder="End" />
                    <p class="rangeTitle">Price Range</p>
                    <asp:TextBox CssClass="range" ID="txtCostStart" runat="server" placeholder="Start" />
                    <asp:TextBox CssClass="range" ID="txtCostEnd" runat="server" placeholder="End" />
                </asp:Panel>
                <asp:Button ID="btnSubmit" CssClass="btn btn-primary btn-search-adj" runat="server" Text="Search"
                    OnClick="btnSubmit_Click" />
            </div>

            <!-- Displaying Search Result -->
            <asp:Panel ID="panSearchResult" runat="server">
                <h2>Search Results</h2>
            </asp:Panel>
            <asp:Label ID="errText" runat="server"></asp:Label>

            <!-- Displaying the ARTWORK Repeater-->
            <uc:ArtWorkResults ID="artworksResults" runat="server" />

            <!-- Displaying the ARTIST Repeater -->
            <div>
                <asp:Repeater ID="rptArtist" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-lg-2">
                                <a href="SingleArtist.aspx?id=<%# Eval("Id" )%>">
                                    <img class="img-thumbnail" src="Assets/art-images/artists/square-medium/<%# Eval("Id") %>.jpg"
                                        alt="<%# Eval("FirstName") %> <%# Eval("LastName") %>" title='<%# Eval("Details")%>' />
                                </a>
                                <br />
                            </div>
                            <div class="col-lg-10">
                                <a href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                                    <h4><%# Eval("FullName") %></h4>
                                </a>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>

        </div>
        <!--/Container-->

</asp:Content>


