﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LeaderBoardArtistControl.ascx.cs" Inherits="Controls_LeaderBoardArtistControl" %>


<asp:UpdatePanel ID="UpdatePanelArtists" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <!-- Table -->
        <div class="panel panel-default">
            <table class="table table-striped table-hover">
                <tbody>
                    <tr>
                        <td><h5>
                            <span class="glyphicon glyphicon-list">&nbsp;</span>
                            <strong> Top  &nbsp;</strong>
                            <asp:DropDownList ID="dropHowMany" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropHowMany_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="100">100</asp:ListItem>
                            </asp:DropDownList>
                            <strong> &nbsp; Best Sellers</strong>
                        </td></h5>
                    </tr>
                    <asp:Repeater ID="repeaterArtists" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <div class="row">
                                        <a href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                                        <div class="col-md-8 leaderboard-title">
                                            <%# Eval("FullName") %>
                                        </div>
                                        <div class="col-md-4 pull-right">
                                            <img class="img-circle" src='assets/art-images/artists/square-thumb/<%# Eval("Id") %>.jpg' />
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
