<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Subjects.aspx.cs" Inherits="Subjects" %>

<%@ Register Src="~/Controls/ArtWorkResultsControl.ascx" TagPrefix="uc" TagName="ArtWorkResult" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="container">

        <!--SubjectsList-->
        <asp:Repeater ID="rptSubjects" runat="server">
            <ItemTemplate>
                    <div class="row">
                        <div class="col-md-2">
                            <img class="thumbnail thumbnail-adj" src="Assets/art-images/subjects/square-medium/<%# Eval("Id") %>.jpg" />
                        </div>
                        <div class="col-md-10">
                            <h3>
                                <a href="Subjects.aspx?query=<%# Eval("Id") %>&type=3">
                                    <%# Eval("SubjectName") %>
                                </a>
                            </h3>
                        </div>
                    </div>
            </ItemTemplate>
        </asp:Repeater>

        <!--Control: ArtWorkResultsControl display list of single subject and related Artworks when query is passed by link-->
        <uc:ArtWorkResult ID="results" runat="server" />
    </div><!--/Container-->

</asp:Content>

