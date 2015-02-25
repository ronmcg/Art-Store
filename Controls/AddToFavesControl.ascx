<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddToFavesControl.ascx.cs" Inherits="Controls_AddToFavesControl" %>

<div class="img-center">
<asp:LinkButton ID="linkFaves" runat="server" OnClick="linkFaves_ClickEvent">
    <span class="glyphicon glyphicon-heart add-to-faves"></span>
</asp:LinkButton>

<%--Never could quite get this to work the way I wanted it to, visible indicator that a favourite is added.--%>
<span class="badge added-badge badge-adj">Favourite</span>
</div>