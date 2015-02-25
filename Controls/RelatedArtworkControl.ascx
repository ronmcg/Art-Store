<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelatedArtworkControl.ascx.cs" Inherits="Controls_RelatedArtworkControl" %>

<!-- Table -->
<div class="panel panel-default">
    <table class="table table-striped table-hover">
        <tbody>
            <tr>
                <td>
                    <h5 class="heading-adj"><span class="glyphicon glyphicon-picture">&nbsp;</span><strong>By Genre</strong></h5>
                </td>
            </tr>
            <asp:Repeater ID="repeaterRelated" runat="server">
                <HeaderTemplate>
                    <%# Eval("GenreName") %>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="SingleArtwork.aspx?id=<%# Eval("Id") %>">
                            <%# Eval("Title") %>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>