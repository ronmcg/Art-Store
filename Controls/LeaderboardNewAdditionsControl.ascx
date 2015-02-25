<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeaderboardNewAdditionsControl.ascx.cs" Inherits="Controls_NewAdditionsControl" %>

<asp:UpdatePanel ID="UpdatePanelArtWork" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <!-- Table -->
        <div class="panel panel-default">
            <table class="table table-striped table-hover">
                <tbody>
                    <tr>
                        <td><h5>
                            <span class="glyphicon glyphicon-list">&nbsp;</span>
                            <strong> Top &nbsp;</strong>
                            <asp:DropDownList ID="dropHowMany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropHowMany_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="100">100</asp:ListItem>
                            </asp:DropDownList>
                            <strong>&nbsp; Newest Additions</strong>
                            </h5>
                        </td>
                    </tr>
                    <asp:Repeater ID="rptNewAdditions" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="row">
                                        <a href="SingleArtWork.aspx?id=<%# Eval("Id") %>">
                                        <div class="col-md-8 leaderboard-title">
                                            <%# Eval("Title") %>
                                        </div>
                                        <div class="col-md-4 pull-right">
                                            <img class="img-circle" src='assets/art-images/works/square-thumbs/<%# Eval("ImageFileName") %>.jpg' />
                                        </div>
                                        </a>
                                    </div>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
