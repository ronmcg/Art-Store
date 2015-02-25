using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using System.Web.Security;

public partial class MasterPage : System.Web.UI.MasterPage
{

    protected void Page_Load(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser();

        if (!IsPostBack)
        {
            //Subjects/Genre/Top Ten Artists Third Nagivation repeaters
            SetGenreNav();
            SetSubjectNav();
            SetTopTenArtistNav();
        }
        
        //Check: If a user is logged in
        if (user == null)
        {
            loginMsgMenuRight.Text = " or <a href=\"Register.aspx\" class=\"navbar-link\">Register</a> to create an account";
        }
        else 
        {
            loginMsgMenuLeft.Text = "would you like to";
            loginMsgMenuRight.Text = "?";
        }

    }

    /// <summary>
    /// Search Redirect for Search textbox in main Navigation
    /// </summary>
    protected void btnSubmit_click(object sender, EventArgs e) 
    { 
        // url encoded to protect the white space and special chars like % , & and so on
        Response.Redirect("Search.aspx?query=" + Server.UrlEncode(txtSearch.Text) + "&type=1", true);
    }


    /// <summary>
    /// Set up Genre repeater, all genres, not top ten
    /// </summary>
    protected void SetGenreNav()
    {
        GenreCollection genres = new GenreCollection(true);
        if (genres.Count > 0)
        {
            genresTopTen.DataSource = genres;
            genresTopTen.DataBind();
        }
    }

    /// <summary>
    /// Set up Subjects repeater, all subjects, not top ten
    /// </summary>
    protected void SetSubjectNav()
    {
        SubjectCollection subjects = new SubjectCollection(true);
        if (subjects.Count > 0)
        {
            SubjectsTopTen.DataSource = subjects;
            SubjectsTopTen.DataBind();
        }
    }

    /// <summary>
    /// Set up Top Ten Artists repeater (top based on sales)
    /// </summary>
    protected void SetTopTenArtistNav()
    {
        int topTen = 10;
        ArtistCollection artistsTopTen = new ArtistCollection(false);
        artistsTopTen.FetchTopSellingArtists(topTen);

        if (artistsTopTen.Count > 0)
        {
            PopArtistsTopTen.DataSource = artistsTopTen;
            PopArtistsTopTen.DataBind();
        }
    }
}
