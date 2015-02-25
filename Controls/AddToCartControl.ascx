<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddToCartControl.ascx.cs" Inherits="Controls_AddToCartControl" %>

<div class="img-center">
    <asp:LinkButton ID="linkAddToCart" runat="server" OnClick="linkAddToCart_Click" ToolTip="Add to your cart">
        <span class="glyphicon glyphicon-shopping-cart add-to-cart"></span> 
    </asp:LinkButton>

    <span class="badge badge-adj-cart">Add to Cart</span>
</div>