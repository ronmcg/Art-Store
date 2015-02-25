<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Genres.aspx.cs" Inherits="Genres" %>
<%@ Register Src="~/Controls/ArtWorkResultsControl.ascx" TagPrefix="uc" TagName="ArtWorkResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="container">
        <asp:Repeater ID="rptGenres" runat="server">
            <ItemTemplate>
                <div class="well">
                    <div class="row">
                        <div class="col-md-12">
                            <h1>
                                <a href="Genres.aspx?query=<%# Eval("GenreId") %>&type=2">
                                    <%# Eval("GenreName") %>
                                </a>
                            </h1>
                        </div>
                        <div class="row row-adj"> 
                            <div class="col-md-2">
                                <img src="Assets/art-images/genres/square-medium/<%# Eval("GenreId") %>.jpg" />
                            </div>
                            <div class="col-md-10">
                                <p><%# Eval("Description") %></p>
                            </div>
                        </div>
                        <br />
                        <div class="col-md-12">
                            <a href='<%# Eval("Link") %>'>Learn More</a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <uc:ArtWorkResult ID="results" runat="server" />

    </div>
</asp:Content>

