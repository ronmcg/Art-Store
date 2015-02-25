using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class assign2_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Retrieve the two most recent reviews.
        PrepareTheRecentComments();
    }

    /// <summary>
    /// Get the last two most recent reviews. Only 100 characters are displayed. Link to artwork is provided.
    /// </summary>
    private void PrepareTheRecentComments()
    {
        ArtWorkReviewCollection arR = new ArtWorkReviewCollection();
        arR.GetRecentReviews(2);

        List<string> reviews = new List<string>();
        foreach (ArtWorkReview awr in arR)
        {
            if (awr.Comment.Length > 100)
            {
                reviews.Add(awr.Comment.Substring(0, 100) + "...");
            }
            else
            {
                reviews.Add(awr.Comment);
            }
        }

        labReviewOne.Text = reviews[0];
        linkReviewOne.NavigateUrl = "./SingleArtWork.aspx?id=" + arR[0].ArtWorkId.ToString();

        labReviewTwo.Text = reviews[1];
        linkReviewTwo.NavigateUrl = "./SingleArtWork.aspx?id=" + arR[1].ArtWorkId.ToString();
    }
}