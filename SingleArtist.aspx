<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleArtist.aspx.cs" Inherits="Artist" %>
<%@ Register Src="~/Controls/RelatedArtistControl.ascx" TagPrefix="uc" TagName="SimilarArtists" %>
<%@ Register Src="~/Controls/AddToFavesControl.ascx" TagPrefix="uc" TagName="AddToFaves" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">

        <!-- Nav tabs (Artist Profile/Works) -->
        <ul class="nav nav-tabs"> 
            <li class="active"><a href="#profile" data-toggle="tab"><strong>Profile</strong></a></li>
            <li><a href="#works" data-toggle="tab"><strong>Works</strong></a></li>
        </ul>

        <div class="tab-content">
            <div class="tab-pane fade in active" id="profile">
                <asp:Repeater ID="repeaterArtist" runat="server">
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-11">

                                <h1>
                                    <%#  Eval("FullName") %>
                                    <small>
                                        <%# String.Format("({0} - {1})", Eval("YearOfBirth"), Eval("YearOfDeath")) %>
                                    </small>
                                </h1>
                            </div>
                            <div class="col-md-1">
                                <uc:AddToFaves ID="addToFaves" runat="server" IdToAdd='<%# Eval("Id") %>' TypeOfFave="ARTIST" />
                            </div>
                        </div><!--/Row-->
                        <hr />
                        <div class="row">
                            <div class="col-md-2 artist-profile">
                                <a href="Assets/art-images/artists/medium/<%# Eval("Id") %>.jpg"><img class="img-rounded thumbnail" src="Assets/art-images/artists/square-medium/<%# Eval("Id") %>.jpg" alt="<%# Eval("FullName") %>" /></a>
                            </div>
                            <div class="col-md-7">
                                <blockquote class="blockquote-adj">
                                    <p class="details">
                                        <%# Eval("Details") %>
                                    </p>
                                </blockquote>
                                <br />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="panel panel-default">
                                            <!-- Default panel contents -->
                                            <div class="panel-heading"><strong><h4 class="heading-adj" ><span class="glyphicon glyphicon-list-alt">&nbsp;</span>Artist Details</strong></h4></div>
                                            <!-- Table -->
                                            <table class="table">
                                                <tbody>
                                                    <tr>
                                                        <td><strong>Nationality:</strong></td>
                                                        <td><%# Eval("Nationality") %></td>
                                                    </tr>
                                                    <tr>
                                                        <td><strong>More Info:</strong></td>
                                                        <td><a href="<%# Eval("ArtistLink") %>" target="_blank"><%# Eval("ArtistLink") %></a></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <!-- Table -->
                                <uc:SimilarArtists ID="similarArtists" runat="server" Nation='<%# Eval("Nationality") %>' />
                            </div>
                        </div><!--/Row-->
                    </ItemTemplate>
                </asp:Repeater>
            </div><!--/Tab Fade Area-->
            <!--WORKS TAB-->
            <div class="tab-pane fade" id="works"><br />
                <asp:Repeater ID="repeaterArtWorks" runat="server">
                    <ItemTemplate>
                        <div class="col-md-3">
                                <figure>
                                    <a href="<%# Eval("Id", "SingleArtWork.aspx?id={0}") %>">
                                        <img class="img-center img-circle img-circle-border" src="assets/art-images/works/square-medium/<%# Eval("ImageFileName") %>.jpg" alt="<%# Eval("Title") %>" title="<%# Eval("Title") %>"  />
                                </figure>
                                </a><br />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div><!--/Works tab-->

            <div id="error" runat="server" class="artist-not-found alert alert-danger fade in">
                <strong>Uh oh!</strong> No artist found or specified.
            </div>
        </div><!--/Tab Content-->

    </div><!--/Container-->
</asp:Content>

