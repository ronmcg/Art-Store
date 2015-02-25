<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SingleArtwork.aspx.cs" Inherits="DisplaySingleArtWork" EnableEventValidation="false" %>

<%@ Register Src="~/Controls/RelatedArtworkControl.ascx" TagPrefix="uc" TagName="RelatedArtworks" %>
<%@ Register Src="~/Controls/AddToFavesControl.ascx" TagPrefix="uc" TagName="AddToFaves" %>
<%@ Register Src="~/Controls/AddToCartControl.ascx" TagPrefix="uc" TagName="AddToCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">

        <!-- Nav tabs (Artist Profile/Works) -->
        <ul class="nav nav-tabs"> 
            <li class="active"><a href="#artwork" data-toggle="tab"><strong>Artwork</strong></a></li>
            <li><a href="#review" data-toggle="tab"><strong>Read Reviews</strong></a></li>
        </ul>

        <div class="tab-content">
            <div class="tab-pane fade in active" id="artwork">
                <!--Artwork Content-->
               <asp:Repeater ID="rptSingleWork" runat="server" OnItemDataBound="parentRptSingleWork_ItemDataBound">
                <ItemTemplate>
                  <div class="row"><!--Artwork Title, Artist Fullname, Favourite Button-->
                    <div class="col-md-10">
                        <h1>
                            <%# Eval("Title") %>
                            <small>By <a href="SingleArtist.aspx?id=<%# Eval("ArtistID") %>"><%# Eval("LastName") %> </a></small>
                        </h1>
                    </div>
                    <div class="col-md-1">
                        <uc:AddToFaves ID="addToFaves" runat="server" IdToAdd='<%# Eval("Id") %>' TypeOfFave="ARTWORK" />
                    </div>
                    <div class="col-md-1">
                        <uc:AddToCart ID="addToCart" runat="server" IdToAdd='<%# Eval("Id") %>' />
                    </div>
                   </div><!--/Row-->

                  <hr />

                   <div class="row"><!--Artwork Details-->
                        <div class="col-md-3">
                            <a data-toggle="modal" href="#myModal">
                                <img class="thumbnail" src="assets/art-images/works/medium/<%# Eval("ImageFileName")%>.jpg" alt="<%# Eval("Title") %>">
                            </a>
                                <asp:LoginView ID="addReviewView" runat="server">
                                    <LoggedInTemplate>
                                        <button type="button" class="btn btn-primary review-center" data-toggle="modal" data-target="#modalAddReview">Write a Review ___<span class="glyphicon glyphicon-pencil"></span></button>
                                    </LoggedInTemplate>
                                    <AnonymousTemplate>
                                        <!--na da-->
                                    </AnonymousTemplate>
                                </asp:LoginView>
                            </div>
                        <!--Right Column-->
                        <!-- Modal to display big pic-->
                        <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                            <div class="modal-dialog large">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">
                                            <%# Eval("Title") %> (<%# Eval("YearOfWork") %>) By <%# Eval("LastName") %>
                                        </h4>
                                    </div>
                                    <div class="modal-body">
                                        <img class="img-center" src="assets/art-images/works/large/<%# Eval("ImageFileName")%>.jpg" alt="<%# Eval("Title") %>">
                                    </div>
                                    <div class="modal-footer">
                                        <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    </div>
                                    </div>
                                    <!-- /.modal-content -->
                                </div>
                                <!-- /.modal-dialog -->
                            </div>
                            <!-- /.modal -->

                            <div class="col-md-6">
                                <!--Middle Content Column-->
                            <blockquote class="blockquote-adj">
                                <p class="details">
                                <%# Eval("Description") %>
                                </p>
                            </blockquote>
                                <br />
                                <!-- Panel: Artist Details -->
                            <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="heading-adj"><span class="glyphicon glyphicon-list-alt">&nbsp;</span><strong>Product Details</strong></h4>
                                    </div>
                                <table class="table">
                                    <tbody>
                                        <tr>
                                            <td class="width-adj-table-cell"><strong>Year Created:</strong></td>
                                            <td><%# Eval("YearOfWork") %></td>
                                        </tr>
                                        <tr>
                                            <td><strong>Medium:</strong></td>
                                            <td><%# Eval("Medium") %></td>
                                        </tr>
                                        <tr>
                                            <td><strong>Dimensions:</strong></td>
                                            <td><%# Eval("Width") %> cm x <%# Eval("Height") %> cm</></td>
                                        </tr>
                                        <tr>
                                            <td><strong>Price:</strong></td>
                                            <td class="green-price"><%# Eval("MSRP", "{0:C2}") %></td>
                                        </tr>
                                        <tr>
                                            <td><strong>Genres:</strong></td>
                                            <td>
                                                <asp:Repeater ID="rptGenre" runat="server">
                                                   <ItemTemplate>
                                                       <a href="Genres.aspx?query=<%# Eval("GenreId") %>&type=2"><%# Eval("GenreName") %></a><br />
                                                   </ItemTemplate>
                                               </asp:Repeater>
                                            </td>      
                                        </tr>
                                        <tr>
                                            <td><strong>Subjects:</strong></td>
                                            <td>
                                                <asp:Repeater ID="rptSubject" runat="server">
                                                   <ItemTemplate>
                                                       <a href="Subjects.aspx?query=<%# Eval("Id") %>&type=3"><%# Eval("SubjectName") %></a><br />
                                                   </ItemTemplate>
                                               </asp:Repeater>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                                </div>
                                <!--/Panel-->
                            </div>
                            <!--/Column Middle-->
                  
                      <div class="col-md-3"> 
                                <div class="panel-group" id="accordion">
                                    <!--Accordian: Gallery Information-->
                      <div class="panel panel-default">
                        <div class="panel-heading">
                          <h4 class="panel-title">
                                   <a data-toggle="collapse" data-parent="#accordion" href="#collapseOne">Museum Information
                            </a>
                          </h4>
                        </div>
                        <div id="collapseOne" class="panel-collapse collapse in">
                          <div class="panel-body">
                            <asp:Repeater ID="rptGallery" runat="server">
                                <ItemTemplate>
                                   <a href="<%# Eval("GalleryWebsite") %>"><%# Eval("GalleryName") %></a><br />
                                    <hr />
                                   <strong>Native Museum Name:</strong> <%# Eval("GalleryNativeName") %><br />
                                   <strong>Residing Country:</strong> <%# Eval("GalleryCountry") %><br />
                                   <strong>Residing City:</strong> <%# Eval("GalleryCity") %><br />
                                   <strong>Lattitude:</strong> <%# Eval("Latitude") %><br />
                                   <strong>Longitude:</strong> <%# Eval("Longitude") %>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                                            <!--/First Body-->
                                        </div>
                                    </div>
                                    <!--/First Panel-->
                                    <div class="panel panel-default">
                                        <!--Panel: Related Info, Orders/OrderDetails-->
                                        <div class="panel-heading">
                                          <h4 class="panel-title">
                                                   <a data-toggle="collapse" data-parent="#accordion" href="#collapseTwo">Sales
                                            </a>
                                          </h4>
                                        </div>
                                        <div id="collapseTwo" class="panel-collapse collapse">
                                          <div class="panel-body">
                                            <asp:Repeater ID="rptSalesDateCreatedList" runat="server">
                                               <ItemTemplate>
                                                  <a href="#"><%#Eval("DateCreated", "{0:MM/d/yy}")%></a><br class="dateCreated-adj" />
                                               </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                        <!--/Second Body-->
                                        </div>
                                  </div>
                                    <!--/Second Panel-->
                                    <div class="panel panel-default">
                                        <!--Panel: Related Works-->
                        <div class="panel-heading">
                          <h4 class="panel-title">
                                  <a data-toggle="collapse" data-parent="#accordion" href="#collapseThree">Related Artworks
                            </a>
                          </h4>
                        </div>
                        <div id="collapseThree" class="panel-collapse collapse">
                        <div class="panel-body">
                        <!--Related Artworks by Genre-->
                           <asp:Repeater ID="rptRelatedArt" runat="server">
                                <ItemTemplate><!-- Table -->
                                <uc:RelatedArtworks ID="similarArtworks" runat="server" Genre='<%# Eval("Id") %>' />
                                </ItemTemplate>
                            </asp:Repeater>
                            </div> <!--/Third Body-->
                            </div>
                            </div><!--/Third Panel-->

                            </div><!--/Accordian-->
                        </div><!--/Right Column--->            
                     </div><!--/row Artwork Details-->
                 </ItemTemplate>
                </asp:Repeater><!--/Main Repeater-->
              </div><!--/Artist Tab-->   
                    
            <div class="tab-pane fade" id="review">
              <!--Review Content-->
              <div class="row">
                    <div class="col-md-12">
                    <h3>Reviews</h3>
                    <hr />
                    </div>
               </div><!--/row 1-->
               <div class="row review-width img-center">
                    <asp:Repeater ID="rptReview" runat="server">
                        <HeaderTemplate>
                            <h3 class="text-muted2 avgRateHeader img-center">
                                Average Rating: <img src="<%# AvgRateMakeStars(GetQueryString().ToString()) %>" />
                            </h3>
                        </HeaderTemplate>
                        <ItemTemplate> 
                            <div class="row">
                            <div class="col-md-3 rev-left-box">
                                    <h3><%# Eval("Reviewer") %> </h3>
                                    <p><%#Eval("ReviewDate", "{0:MM/d/yy}")%></p>
                                        Rating: <img src='<%# MakeStars(Eval("Rating").ToString()) %>' />
                                    </p>
                                    <asp:LoginView ID="reviewView" runat="server">
                                       <RoleGroups>
                                        <asp:RoleGroup Roles="administrator">
                                            <ContentTemplate>
                                                <p>
                                                    <asp:Button ID="btnDelete" runat="server" CssClass="btn btn-primary" CommandArgument='<%# Eval("Id") %>' Text="Delete Review" OnCommand="btnDelete_Command" />
                                                </p>
                                            </ContentTemplate>
                                        </asp:RoleGroup>
                                       </RoleGroups>
                                   </asp:LoginView>
                               </div>
                               <div class="col-md-8">
                                    <br />
                                    <blockquote class="blockquote-adj comment-adj">
                                     <%# Eval( "Comment") %>    
                                    </blockquote>
                              </div>
                            </div>
                            <!--/Row-->
                             <hr class="hr-white img-center" />
                        </ItemTemplate>
                       </asp:Repeater>
                 <asp:Label ID="emptyReview" runat="server" />
                </div><!--/row 2-->
            </div><!--/Review Tab-->
        </div><!--/Tab Content-->

        <!-- Modal For: Adding Review -->
        <div class="modal fade" id="modalAddReview" tabindex="-1" role="dialog" aria-labelledby="myModalLabel"
            aria-hidden="true">
            <div class="modal-dialog">
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title" id="myModalLabel">Add a review</h4>
                    </div>
                    <div class="modal-body">
                        <table id="reviewTable">
                             <tr>
                                <th><strong>Rate the Artwork:</strong></th>
                                <th><strong>Write your Review:</strong></th>  
                             </tr>
                             <tr>
                                 <td>
                                    <asp:RadioButtonList ID="rdiStar" runat="server">
                                        <asp:ListItem Value="1">&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span></asp:ListItem>
                                        <asp:ListItem Value="2">&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span></asp:ListItem>
                                        <asp:ListItem Value="3">&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span></asp:ListItem>
                                        <asp:ListItem Value="4">&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span><span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star-empty"></span></asp:ListItem>
                                        <asp:ListItem Value="5" Selected="True">&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span>&nbsp;<span class="glyphicon glyphicon-star"></span></asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:TextBox CssClass="rev-box" ID="txtReview" runat="server" MaxLength="5000" TextMode="MultiLine" Rows="8" Columns="50" />
                                </td>
                             </tr>
                        </table>
                    </div>
                    <div class="modal-footer">
                        <asp:Button ID="btnReview" CssClass="btn btn-primary" runat="server" OnClick="btnReview_Click" Text="Submit Review" />
                    </div>
                </div><!-- /.modal-content -->
            </div><!-- /.modal-dialog -->
        </div><!-- /.modal -->
       
    </div><!--/Container-->
    
    <div id="error" runat="server" class="artist-not-found alert alert-danger fade in">
        <strong>Uh oh!</strong><asp:Label runat="server" ID="errorMsg" />
    </div>

</asp:Content>

