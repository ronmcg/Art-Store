<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ArtWorkResultsControl.ascx.cs" Inherits="Controls_ArtWorkResultsControl" %>


<asp:UpdatePanel ID="ajaxFavesArtWorks" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="row">
            <div class="col-md-12">
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
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="row">
                            <div class="col-md-1">
                                <img class="img-circle" src='assets/art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg' />
                            </div>
                            <div class="col-md-11 artwork-link">
                                <a id="A1" runat="server" href='<%# Eval("Id", "../SingleArtWork.aspx?id={0}") %>'>
                                    <asp:Label ID="labArtWork" runat="server" Text='<%# String.Format("{0}", Eval("Title"))%>'></asp:Label>
                                </a>
                                <br />
                                <p><%# CleanUpEmptyDescriptions(Eval("Description").ToString()) %></p>
                            </div>
                        </div>
                        <td>
                            <asp:Label ID="artWorkMSRP" runat="server" Text='<%# String.Format("{0:c}", Eval("MSRP") )%>' />
                        </td>
                        <td>
                            <asp:Label ID="artWorkYear" runat="server" Text='<%# Eval("YearOfWork") %>' />
                        </td>
                    </ItemTemplate>
                </asp:DataList>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>