using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class ArtistList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Create the ArtistList
            SetUpArtistList(FetchArtistData());
        }
    }

    /// <summary>
    /// Paging for grideview page click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        listArtists.PageIndex = e.NewPageIndex;
        SetUpArtistList(FetchArtistData());
    }
    
    /// <summary>
    /// Gets an ArtistCollection containing a single artist
    /// </summary>
    /// <param name="id">The artist ID</param>
    /// <returns>The resulting ArtistCollection</returns>
    private ArtistCollection FetchArtistData()
    {
        ArtistCollection ac = new ArtistCollection(true);
        return ac;
    }

    /// <summary>
    /// Set the data source and bind it to the repeater
    /// </summary>
    /// <param name="ac">The data source</param>
    private void SetUpArtistList(ArtistCollection ac)
    {
        if (ac == null || ac.Count <= 0)
        {
            //DataError();
        }
        else
        {
            listArtists.DataSource = ac;
            listArtists.DataBind();
        }

    }
}