using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Content.Business;

public partial class Controls_RelatedArtistControl : System.Web.UI.UserControl
{

    //the page needs to pass data to the user control, so we make a property the page can set
    public string Nation { get; set; }

    protected void Page_Load(object sender, EventArgs e)
    {
        PairRepeaterSimilarArtist(repeaterRelated, FetchSimilarArtists(Nation));
    }

    private ArtistCollection FetchSimilarArtists(string nation)
    {
        ArtistCollection ac = null;
        if (nation == null)
        {
            //do soemthing
        }
        else
        {
            ac = new ArtistCollection(false);
            ac.FetchForNationality(nation);
        }
        return ac;
    }

    /// <summary>
    /// Set the data source and bind it to the repeater
    /// </summary>
    /// <param name="r">The repeater to bind to</param>
    /// <param name="ac">The data source</param>
    private void PairRepeaterSimilarArtist(Repeater r, ArtistCollection ac)
    {
        if (ac == null || ac.Count <= 0)
        {
            //do something
        }
        else
        {
            r.DataSource = ac;
            r.DataBind();
        }
    }

}