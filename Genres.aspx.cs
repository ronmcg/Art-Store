using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Genres : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckQueryStringSet())
        {
            //No value, set up repeater of GenreList
            SetUpRepeaterGenres(-1);
        }
        else
        {
            //QueryString has a value, grab the GenreID to match and display artworks
            int id = 0;
            bool success = Int32.TryParse(GetQueryString(), out id);
            if (success)
                SetUpRepeaterGenres(id);
        }
    }

    /// <summary>
    /// Checks if query string has a value
    /// </summary>
    private bool CheckQueryStringSet()
    {
        if (Request.QueryString["query"] == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    /// <summary>
    /// Grabs the query string, checks if null
    /// </summary>
    private string GetQueryString()
    {
        string q = "";
        if (Request.QueryString["query"] != null)
        {
            q = Request.QueryString["query"].ToString();
        }
        return q;
    }

    /// <summary>
    /// Grabs the Genre List repeater of artworks according to GenreId query string.
    /// </summary>
    private void SetUpRepeaterGenres(int genreID)
    {
        GenreCollection gc = null;
        if (genreID == -1)
        {
            gc = new GenreCollection(true);
        }
        else
        {
            gc = new GenreCollection(false);
            gc.FetchById(genreID);
        }
        rptGenres.DataSource = gc;
        rptGenres.DataBind();
    }
}