<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="About.aspx.cs" Inherits="About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <div class="row">
            <div class="col-md-9">
                <h1>About</h1>
                <hr />
                <h3 class="text-muted2">Version 1:</h3>
                <p>November 18th, 2013</p>
                <h3 class="text-muted2">Version 2:</h3>
                <p>December 6th, 2013</p>
                <p>
                    This website was designed as a tool to demonstrate the combined use of ASP.NET, Bootstrap Responsive Framework and the use of a Microsoft Access Database. The website uses a three-layer architecture separating the presentation, business and data acess layers for the functions of the site. This page and the contents herein have been created using Microsoft Visual Studio 2012, for class COMP 3512 taught by Professor Randy Connolly at Mount Royal University. The teams workflow consisted of regular code reviews between team members, pair programming and the use of Microsoft's Team Foundation Service for version control.         
                </p>
                <h3 class="text-muted2">Authors:</h3>
            </div>
            <div class="col-md-3">
            <br />
            <img class="img-center" src="Assets/nav-images/MRU-Logo.png" alt="Mount Royal University Logo" />
                <h3 class="web-link">[ <a href="http://ronmadethis.com/portfolio.html">Public Web Link</a> ]</h3>
            </div>
        </div><!--/Row-->

        <div class="row">
            <div class="col-md-4">
                <p class="fl-trail"><strong class="fancy-letter">R</strong>onnie McGregor</p>
                <ul>
                    <li>Layout initial design and project manager.</li>
                    <li>Wrote many of the SQL queries.</li>
                    <li>Created SingleArtist/ArtistList page.</li>
                    <li>Created 'Best Sellers' and 'Related Artists' user controls.</li>
                    <li>Built the 'Add to Favourites' functionality.</li>
                    <li>Built the shopping cart.</li>
                    <li>Built the search (simple/advanced) functionality.</li>
                    <li>Built Add review/delete/rating functionality.</li>
                    <li>Built Admin Console functionality.</li>                    
                    <li>Built recent review/rating/delete review/add review functionality.</li>
                    <li>Live Site Hosting and Online Portfolio</li>
                </ul>
            </div>
            <div class="col-md-4">
                <p class="fl-trail"><strong class="fancy-letter">S</strong>elenge Natsagdorj</p>
                <ul>
                    <li>Created logo and carousel images graphics.</li>
                    <li>Started SingleArtwork Page.</li>
                    <li>Wrote most Business and DataAccess App_Code skeletons for the missing tables that were added.</li>
                    <li>Created repeaters for Popular Artist/Genres/Subjects third navigation.</li>
                    <li>Created ArtworksList/ArtistList Gridviews.</li>
                    <li>Created Review Repeater</li>
                    
                </ul>
            </div>
            <div class="col-md-4">
                <p class="fl-trail"><strong class="fancy-letter">H</strong>azel Lobos</p>
                <ul>
                    <li>Modified layout front-end, color schemes, responsive layout adjustments, bootstrap customizations.</li>
                    <li>Created About page.</li>
                    <li>General presentation layer commenting and documentation for all pages.</li>
                    <li>Edited SingleArtworks page (Created Review Section, Panels in Accordian and Repeaters for Genre/Subjects in 'Product Details')</li>
                    <li>Created 'Newest Editions' user control.</li>
                    <li>Created 'Related Artworks' user control.</li>
                    <li>App_Code layers commenting on all pages.</li>
                    <li>Added horizontal and vertical banners, created banner graphics, adjusted ASP AdRotator function.</li>
                    <li>Created Login and Register pages using ASP.NET Website Administration Tool.</li>
                    <li>CSS for Admin Console, Review/Rating layout, Recent Reviews on Frontpage.</li>                 
                    <li>Css Editing for all pages. Fixing minor errors and final look adjustments.</li>
                </ul>
            </div>
        </div><!--/Row-->
    </div><!--/Container-->

</asp:Content>
