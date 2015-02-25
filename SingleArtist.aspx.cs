using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using System.Data;

public partial class Artist : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SetUpRepeaterArtist(FetchArtistData(GetQueryString()));
        SetUpRepeaterArtWorks(FetchArtistArtWorkData(GetQueryString()));
    }

    /// <summary>
    /// Get the query string
    /// </summary>
    /// <returns></returns>
    private int GetQueryString()
    {
        int artistId = 0;
        Int32.TryParse(Request["id"], out artistId);
        return artistId;
    }


    /// <summary>
    /// Gets an ArtistCollection containing a single artist
    /// </summary>
    /// <param name="id">The artist ID</param>
    /// <returns>The resulting ArtistCollection</returns>
    private ArtistCollection FetchArtistData(int id)
    {
        ArtistCollection ac = null;
        if (id <= 0)
        {
            DataError();
        }
        else
        {
            ac = new ArtistCollection(false);
            ac.FetchForId(id);
        }
        return ac;
    }

    /// <summary>
    /// Set the data source and bind it to the repeater
    /// </summary>
    /// <param name="ac">The data source</param>
    private void SetUpRepeaterArtist(ArtistCollection ac)
    {
        if (ac == null || ac.Count <= 0)
        {
            DataError();
        }
        else
        {
            repeaterArtist.DataSource = ac;
            repeaterArtist.DataBind();
        }
    }

    /// <summary>
    /// Set up repeater binding, abstract
    /// </summary>
    /// <param name="r">The Repeater</param>
    /// <param name="data">The data source</param>
    private void SetUpRepeater(Repeater r, AbstractBusinessCollection<AbstractBusiness> data)
    {
        if (data == null || data.Count <= 0)
        {
            DataError();
        }
        else
        {
            r.DataSource = data;
            r.DataBind();
        }
    }

    /// <summary>
    /// Get the DataTable for the artists art works
    /// </summary>
    /// <param name="id">The artist ID</param>
    /// <returns>The resulting ArtWorkCollection</returns>
    private ArtWorkCollection FetchArtistArtWorkData(int id)
    {
        ArtWorkCollection aw = null;
        if (id <= 0)
        {
            DataError();
        }
        else
        {
            aw = new ArtWorkCollection();
            aw.FetchForArtist(id);
        }
        return aw;
    }

    /// <summary>
    /// Set the data source and bind it to the repeater
    /// </summary>
    /// <param name="r">The repeater to bind to</param>
    /// <param name="ac">The data source</param>
    private void SetUpRepeaterArtWorks(ArtWorkCollection aw)
    {
        if (aw == null || aw.Count <= 0)
        {
            DataError();
        }
        else
        {
            repeaterArtWorks.DataSource = aw;
            repeaterArtWorks.DataBind();
        }
    }

    /// <summary>
    /// Display the error message
    /// </summary>
    private void DataError()
    {
        error.Style["display"] = "block";
    }
}