using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Content.DataAccess;
using System.Web.Security;

public partial class DisplaySingleArtWork : System.Web.UI.Page
{

    private ArtWorkCollection ac = new ArtWorkCollection();
    private ArtWorkReviewCollection artReview = new ArtWorkReviewCollection(false);
    private int artWorkId = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        artWorkId = GetQueryString();
        if (artWorkId <= 0)
            errorMsg.Text = "No artwork found or specified.";
        else
        {
            //Fetch Single Artwork
            ac.FetchForId(artWorkId);

            if (ac.Count <= 0)
                errorMsg.Text = "No artwork found or specified.";
            else
            {
                //Parent repeater of page
                rptSingleWork.DataSource = ac;
                rptSingleWork.DataBind();
            }
        }
    }

    /// <summary>
    /// Gallery/Genre/Subject/Reviews repeater nested within 'parentRptSingleWork_ItemDataBound'
    /// </summary>
    protected void parentRptSingleWork_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        //Gallery Repeater: Child
        Repeater innerRptGallery = (Repeater)e.Item.FindControl("rptGallery");

        GalleryCollection gl = new GalleryCollection(false);
        gl.FetchForId(ac[0].GalleryID);
        innerRptGallery.DataSource = gl;
        innerRptGallery.DataBind();

        //Genre Repeater: Child
        Repeater innerRptGenre = (Repeater)e.Item.FindControl("rptGenre");

        GenreCollection _gCol = new GenreCollection(false);
        _gCol.FetchByArtWorkID(artWorkId);
        innerRptGenre.DataSource = _gCol;
        innerRptGenre.DataBind();

        //Second Genre Repeater (For Related Artworks in Accordian): Child
        Repeater innerRptRelatedArt = (Repeater)e.Item.FindControl("rptRelatedArt");

        GenreCollection _gCol2 = new GenreCollection(false);
        _gCol2.FetchByArtWorkID(artWorkId);
        innerRptRelatedArt.DataSource = _gCol2;
        innerRptRelatedArt.DataBind();

        //Subject Repeater: Child
        Repeater innerRptSubject = (Repeater)e.Item.FindControl("rptSubject");

        SubjectCollection _sCol = new SubjectCollection(false);
        _sCol.FetchByArtWorkId(artWorkId);
        innerRptSubject.DataSource = _sCol;
        innerRptSubject.DataBind();

        //Sales Repeater (Using date created---> Order/OrderDetails)
        Repeater innerRptOrders = (Repeater)e.Item.FindControl("rptSalesDateCreatedList");

        OrdersCollection _ordCol = new OrdersCollection();
        _ordCol.FetchByArtworkID(artWorkId);
        innerRptOrders.DataSource = _ordCol;
        innerRptOrders.DataBind();
        
        //Getting the Reviews
        artReview.FetchReviewsByArtWorkId(artWorkId);

        if (!artReview.IsEmpty)
        {
            rptReview.DataSource = artReview;
            rptReview.DataBind();
        }
        else emptyReview.Text = "There is no review for this artwork ";
    }

    /// <summary>
    /// Grab Query String of ArtworkId
    /// </summary>
    protected int GetQueryString()
    {
        int artistId = 0;
        bool flag = Int32.TryParse(Request["id"], out artistId);
        return artistId;
    }

    /// <summary>
    /// Ratings for Review, switches star image according to a new start rating passed in.
    /// </summary>
    /// <param name="num">New Rating to switch image.</param>
    protected string MakeStars(string num)
    {
        int i = 0;
        i = Convert.ToInt32(num);
        string img = "";
        switch (i)
        {
            case 1:
                img = "Assets/nav-images/star1.gif";
                break;
            case 2:
                img = "Assets/nav-images/star2.gif";
                break;
            case 3:
                img = "Assets/nav-images/star3.gif";
                break;
            case 4:
                img = "Assets/nav-images/star4.gif";
                break;
            case 5:
                img = "Assets/nav-images/star5.gif";
                break;
            default:
                img = "";
                break;
        }
        return img;
    }

    /// <summary>
    ///  Fetches the average rating of an artwork.
    /// </summary>
    protected string AvgRateMakeStars(string artId)
    {
        int artIdInt = Convert.ToInt32(artId);
        int rating = 0;

        rating = artReview.FetchCurrentAvgRating(artIdInt);

        return MakeStars(rating.ToString());
    }

    /// <summary>
    /// Create new review and display. A user can only make a review to a given artwork once.
    /// </summary>
    protected void btnReview_Click(object sender, EventArgs e)
    {
        string reviewText = txtReview.Text;

        ArtWorkReview awr = new ArtWorkReview();
        awr.ArtWorkId = artWorkId;
        MembershipUser reviewer = Membership.GetUser();
        awr.Reviewer = reviewer.UserName;
        awr.Comment = reviewText;
        awr.Rating = Convert.ToInt32(rdiStar.SelectedValue);
        awr.ReviewDate = DateTime.Today;

        if (!HasCommented(reviewer.UserName))
        {
            awr.Insert();
        }

        Response.Redirect("SingleArtWork.aspx?id=" + artWorkId, true);
    }

    /// <summary>
    /// Check: A user can only make a review to a given artwork once. 
    /// </summary>
    /// <param name="user">logged in user</param>
    private bool HasCommented(string user)
    {
        bool hasCommented = false;

        ArtWorkReviewCollection awrc = new ArtWorkReviewCollection();
        awrc.FetchReviewsByArtWorkId(artWorkId);
        
        foreach (ArtWorkReview awr in awrc)
        {
            if (awr.Reviewer == user)
            {
                hasCommented = true;
            }
        }
        return hasCommented;
    }

    /// <summary>
    /// Deletes a review from an artwork.
    /// </summary>
    protected void btnDelete_Command(object sender, CommandEventArgs e)
    {
        int id = Convert.ToInt32(e.CommandArgument.ToString());
        
        ArtWorkReview awr = new ArtWorkReview(id);
        awr.Delete();
        Response.Redirect("SingleArtWork.aspx?id=" + artWorkId, true);
    }

}