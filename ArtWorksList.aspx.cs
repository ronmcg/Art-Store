using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class ArtistWorksList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //Get the artwork collection datatable to display
            DataAccess();
        }
    }

    /// <summary>
    /// Paging for grideview page click event
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
          artWorkList.PageIndex = e.NewPageIndex;
          DataAccess();
    }

    /// <summary>
    /// Create new ArtWorkCollection, fetch the artworks list and bind to 'artWorkList' repeater.
    /// </summary>
    /// <param name="ac">The data source</param>
    protected void DataAccess() 
    {
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.FetchArtWorksList();
        artWorkList.DataSource = awc;
        artWorkList.DataBind();
    }
}