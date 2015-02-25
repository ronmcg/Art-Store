<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RelatedArtistControl.ascx.cs" Inherits="Controls_RelatedArtistControl" %>

<!-- Table -->
<div class="panel panel-default">
    <table class="table table-striped table-hover">
        <tbody>
            <tr>
                <td>
                    <h5 class="heading-adj" ><span class="glyphicon glyphicon-user">&nbsp;</span><strong>Related Artists</strong></h5>
                </td>
            </tr>
            <asp:Repeater ID="repeaterRelated" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href="SingleArtist.aspx?id=<%# Eval("Id") %>">
                            <%# Eval("FullName") %>
                            </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
