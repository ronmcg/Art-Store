<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cart.aspx.cs" Inherits="Cart" EnableViewState="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">
        <h1>Your Cart</h1>
        <asp:DataList ID="listCart" runat="server" CssClass="table table-bordered">
            <HeaderTemplate><!--Sorting buttons-->
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
                    <div class="col-md-1">
                        <img class="img-circle" src='assets/art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg' />
                    </div>
                    <div class="col-md-10 artwork-link">
                        <a runat="server" href='<%# Eval("Id", "SingleArtwork.aspx?id={0}") %>'>
                            <asp:Label ID="labArtWork" runat="server" Text='<%# String.Format("{0}", Eval("Title"))%>'></asp:Label>
                        </a>
                        <strong>
                            <asp:Label ID="labQuantity" runat="server" Text="Quantity:" />
                        </strong>
                        <asp:TextBox ID="txtQuantity" runat="server" Text="1" Width="30px" AutoPostBack="true" OnTextChanged="txtQuantity_TextChanged" />
                        <small class="text-muted">Press enter</small>
                        <div class="row">
                            <div class="col-md-11 options">
                                <abbr title="The style of frame">Frame:</abbr>
                                <asp:DropDownList ID="drpFrame" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="drpFrame_SelectedIndexChanged">
                                </asp:DropDownList>
                                <abbr title="The type of glass">Glass:</abbr>
                                <asp:DropDownList ID="drpGlass" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="drpGlass_SelectedIndexChanged">
                                </asp:DropDownList>
                                <abbr title="The colour of the matt you order will sit on in the frame, all matts are $25.00">Matt:</abbr>
                                <asp:DropDownList ID="drpMatt" runat="server" EnableViewState="true" AutoPostBack="true" OnSelectedIndexChanged="drpMatt_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                            <div class="col-md-1">
                                <asp:Label ID="subtotal" runat="server" Text="0" />
                            </div>
                        </div>
                    </div>
                </div>
                <td>
                    <div class="msrp">
                        <asp:Label ID="artWorkMSRP" runat="server" Text='<%# String.Format("{0:c}", Eval("MSRP") )%>' />
                    </div>
                </td>
                <td>
                    <div class="year">
                        <asp:Label ID="artWorkYear" runat="server" Text='<%# Eval("YearOfWork") %>' />
                    </div>
                </td>
                <td>
                    <div class="delete">
                        <asp:LinkButton ID="btnDeleteArtist" runat="server" OnClick="btnDeleteArtWork_Click" CommandArgument='<%# Eval("Id") %>' >
                            <span class="glyphicon glyphicon-remove"></span>
                        </asp:LinkButton>
                    </div>
                </td>
            </ItemTemplate>
        </asp:DataList>
        <div class="pull-right">
            <strong>Total:&nbsp;
            <asp:Label ID="labTotal" runat="server" />
            </strong>
        </div>
        <br />
        <button type="button" class="btn btn-success pull-right">Check out</button>
    </div><!--/Container-->

</asp:Content>

