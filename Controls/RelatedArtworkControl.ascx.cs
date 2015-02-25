using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_RelatedArtworkControl : System.Web.UI.UserControl
{
    //the page needs to pass data to the user control, so we make a property the page can set
    public string Genre { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        PairRepeaterSimilarGenre(repeaterRelated, FetchSimilarArtworks(Genre));
    }

    private ArtWorkCollection FetchSimilarArtworks(string genre)
    {
        ArtWorkCollection awc = null;
        int g = 0;
        bool success = Int32.TryParse(genre, out g);
        if (success)
        {
            awc = new ArtWorkCollection(false);
            awc.FetchForGenre(g);
        }
        return awc;
    }

    /// <summary>
    /// Set the data source and bind it to the repeater
    /// </summary>
    /// <param name="r">The repeater to bind to</param>
    /// <param name="ac">The data source</param>
    private void PairRepeaterSimilarGenre(Repeater r, ArtWorkCollection awc)
    {
        if (awc == null || awc.Count <= 0)
        {
            //Nothing to display
        }
        else
        {
            r.DataSource = awc;
            r.DataBind();
        }
    }
}