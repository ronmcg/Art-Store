<%@ Control Language="C#" AutoEventWireup="true" CodeFile="FavouritesControl.ascx.cs" Inherits="Controls_FavouritesControl" %>


<asp:UpdatePanel ID="ajaxFavesArtists" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <h5><span class="glyphicon glyphicon-heart">&nbsp;</span>Your Favourite Artists</h5>
                <asp:DataList ID="listArtists" runat="server" CssClass="table table-bordered table-striped">
                    <HeaderTemplate>
                        <asp:LinkButton ID="sortName" runat="server" OnClick="sortName_Click">
                        <span class="glyphicon glyphicon-sort">&nbsp;</span><strong>Sort</strong>
                        </asp:LinkButton>
                        <td>
                            <a href="#">&times;</a>
                        </td>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <a runat="server" id="artistLink" href='<%# Eval("Id", "../SingleArtist.aspx?id={0}") %>'>
                            <asp:Label ID="labArtist" runat="server" Text='<%# String.Format("{0} - ({1} - {2})", Eval("FullName"), Eval("YearOfBirth"), Eval("YearOfDeath"))%>'></asp:Label>
                        </a>
                        <td>
                            <asp:LinkButton ID="btnDeleteArtist" runat="server" OnClick="btnDeleteArtist_Click" CommandArgument='<%# Eval("Id") %>' >
                                <span class="glyphicon glyphicon-remove"></span>
                            </asp:LinkButton>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="ajaxFavesArtWorks" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
                <h5><span class="glyphicon glyphicon-heart">&nbsp;</span>Your Favourite Art Works</h5>
                <asp:DataList ID="listArtWorks" runat="server" CssClass="table table-bordered table-striped">
                    <HeaderTemplate>
                        <!-- You may notice the td tags missing from the first item, this is because the control 
                            puts the first one in by itself -->
                        <asp:LinkButton ID="sortTitle" runat="server" OnClick="sortTitle_Click">
                        <span class="glyphicon glyphicon-sort">&nbsp;</span><strong>Title</strong>
                        </asp:LinkButton>
                        <td>
                            <asp:LinkButton ID="sortMSRP" runat="server" OnClick="sortMSRP_Click">
                        <span class="glyphicon glyphicon-sort">&nbsp;</span><strong>MSRP</strong>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <asp:LinkButton ID="sortYear" runat="server" OnClick="sortYear_Click">
                        <span class="glyphicon glyphicon-sort">&nbsp;</span><strong>Year</strong>
                            </asp:LinkButton>
                        </td>
                        <td>
                            <a href="#">&times;</a>
                        </td>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-4">
                                <img class="img-circle" src='assets/art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg' />
                            </div>
                            <div class="col-md-8 artwork-link">
                                <a runat="server" href='<%# Eval("Id", "../SingleArtWork.aspx?id={0}") %>'>
                                    <asp:Label ID="labArtWork" runat="server" Text='<%# String.Format("{0}", Eval("Title"))%>'></asp:Label>
                                </a>
                            </div>
                        </div>
                        <td>
                            <asp:Label ID="artWorkMSRP" runat="server" Text='<%# String.Format("{0:c}", Eval("MSRP") )%>' />
                        </td>
                        <td>
                            <asp:Label ID="artWorkYear" runat="server" Text='<%# Eval("YearOfWork") %>' />
                        </td>
                        <td>
                            <asp:LinkButton ID="btnDeleteArtist" runat="server" OnClick="btnDeleteArtWork_Click" CommandArgument='<%# Eval("Id") %>' >
                                <span class="glyphicon glyphicon-remove"></span>
                            </asp:LinkButton>
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
