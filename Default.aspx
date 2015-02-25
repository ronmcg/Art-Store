<%@ Page Title="Default" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="assign2_Default" %>
<%@ Register src="~/Controls/LeaderBoardArtWorkControl.ascx" TagPrefix="uc" TagName="LeaderBoardArtWorks" %>
<%@ Register src="~/Controls/LeaderBoardArtistControl.ascx" TagPrefix="uc" TagName="LeaderBoardArtists" %>
<%@ Register src="~/Controls/LeaderBoardNewAdditionsControl.ascx" TagPrefix="uc" TagName="LeaderBoardNewAdditions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server"> 

    <div class="container">
        <div class="row">
        <div class="col-md-9">
        <!-- Carousel Section -->
        <div data-ride="carousel" class="carousel slide" id="carousel-example-captions">
            <ol class="carousel-indicators">
                <li class="" data-slide-to="0" data-target="#carousel-example-captions"></li>
                <li data-slide-to="1" data-target="#carousel-example-captions" class=""></li>
                <li data-slide-to="2" data-target="#carousel-example-captions" class=""></li>
            </ol>
            <div class="carousel-inner">
                <div class="item next left">
                    <img alt="900x500" data-src="holder.js/900x500/auto/#777:#777" src="Assets/nav-images/carousel3.png" />
                    <div class="carousel-caption">
                        <h3>Discover</h3>
                        <p>Browse many well known artists and their work.</p>
                    </div>
                </div>
                <div class="item">
                    <img alt="900x500" data-src="holder.js/900x500/auto/#666:#666" src="Assets/nav-images/carousel2.png" />
                    <div class="carousel-caption">
                        <h3>Connect</h3>
                        <p>Favourite the works that best speaks to you.</p>
                    </div>
                </div>
                <div class="item active left">
                    <img alt="900x500" data-src="holder.js/900x500/auto/#555:#5555" src="Assets/nav-images/carousel1.png" />
                    <div class="carousel-caption">
                        <h3>Aquire</h3>
                        <p>Easy shop and checkout, register above to make your claim!</p>
                    </div>
                </div>
            </div>
            <a data-slide="prev" href="#carousel-example-captions" class="left carousel-control">
                <span class="glyphicon glyphicon-chevron-left"></span>
            </a>
            <a data-slide="next" href="#carousel-example-captions" class="right carousel-control">
                <span class="glyphicon glyphicon-chevron-right"></span>
            </a>
        </div><!--Carousel-->
        </div><!--/Carousel Section-->

        <div class="col-md-3 pull-right">
           <h3 class="text-muted2 review-latest-font">Latest Reviews</h3>
               <div class="thumbnail thumbnail-adj">
                   <asp:Label ID="labReviewOne" runat="server" />
                   <br />
                   <asp:HyperLink ID="linkReviewOne" runat="server" Text="View Artwork" />
                   <hr class="rev-hr" />
                   <asp:Label ID="labReviewTwo" runat="server" />
                   <br />
                   <asp:HyperLink ID="linkReviewTwo" runat="server" Text="View Artwork" />
               </div>
        </div><!--/Latest Review-->
        </div><!--Row-->
        <hr />

        <div class="row"><%--LeaderBoards, visual boxes of artist/artwork data--%>
            <div class="col-md-4">
                <uc:LeaderBoardArtWorks ID="leaderBoard" runat="server" HowMany="5" />
            </div>
            <div class="col-md-4">
                <uc:LeaderBoardArtists ID="leaderArtists" runat="server" HowMany="5" />
            </div>
            <div class="col-md-4">
                <uc:LeaderBoardNewAdditions ID="leaderNewAdditions" runat="server" HowMany="5" />
            </div>
        </div>

    </div><!--/Container-->
</asp:Content>

