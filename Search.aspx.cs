using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;
using Content.DataAccess;
public partial class Search : System.Web.UI.Page
{

    private const int TYPE_ARTWORK = 1;
    private const int TYPE_ARTIST = 2;
    protected void Page_Load(object sender, EventArgs e)
    {
        SettingsUpMoreCiriteria();
        if (GetQueryString() != "")
        {
            SearchForArtist(GetQueryString());
        }
    }
    protected void SettingsUpMoreCiriteria()
    {
        mCriteria.Visible = true;
        int selected = GetTypeOfSearch();
        if (selected == TYPE_ARTIST)
        {
            mCriteria.Visible = false;
        }
    }

    /// <summary>
    /// Get type of search (Artwork #1, Artist #2) according to selected radio button.
    /// </summary>
    private int GetTypeOfSearch()
    {
        int selected = Convert.ToInt32(rbOptions.SelectedValue);
        return selected;
    }

    /// <summary>
    /// Get the values from the text boxes if they exist and put them in a dictionary
    /// </summary>
    /// <returns>Dictionary containing 0 or more criteria</returns>
    private Dictionary<string, string> GetMoreCriteria()
    {
        Dictionary<string, string> criteria = new Dictionary<string, string>();

        if (txtYearStart.Text.ToString() != "")
        {
            criteria.Add("YearStart", txtYearStart.Text.ToString());
        }
        else
        {
            criteria.Add("YearStart", null);
        }
        if (txtYearEnd.Text.ToString() != "")
        {
            criteria.Add("YearEnd", txtYearEnd.Text.ToString());
        }
        else
        {
            criteria.Add("YearEnd", null);
        }
        if (txtCostStart.Text.ToString() != "")
        {
            criteria.Add("MSRPStart", txtCostStart.Text.ToString());
        }
        else
        {
            criteria.Add("MSRPStart", null);
        }
        if (txtCostEnd.Text.ToString() != "")
        {
            criteria.Add("MSRPEnd", txtCostEnd.Text.ToString());
        }
        else
        {
            criteria.Add("MSRPEnd", null);
        }
        return criteria;
    }

    /// <summary>
    /// Error message for empty input in search
    /// </summary>
    protected void EmptyInputError()
    {
        errText.Text = "No text or search result was found!";
    }

    /// <summary>
    /// On search click, gets the type of search and displays according to search criteria.
    /// </summary>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        int selected = GetTypeOfSearch();
        Dictionary<string, string> queries = GetMoreCriteria();
        if (selected == TYPE_ARTWORK)
        {   
            //no additional criteria means search by title
            if (queries["YearStart"] == null && queries["YearEnd"] == null && queries["MSRPStart"] == null && queries["MSRPEnd"] == null)
            {
                string query = txtTitle.Text;
                Response.Redirect("Search.aspx?query=" + query + "&type=1");
            }
            else
            {
                string searchPage = "Search.aspx?";
                if (queries["YearStart"] != null)
                {
                    searchPage += "yearstart=" + queries["YearStart"];
                }
                if (queries["YearEnd"] != null)
                {
                    searchPage += "&yearend=" + queries["YearEnd"];
                }
                if (queries["MSRPStart"] != null)
                {
                    searchPage += "&msrpstart=" + queries["MSRPStart"];
                }
                if (queries["MSRPEnd"] != null)
                {
                    searchPage += "&msrpend=" + queries["MSRPEnd"];
                }
                Response.Redirect(searchPage + "&type=4");
            }
        }
        else if (selected == TYPE_ARTIST)
        {
            string query = txtTitle.Text;
            Response.Redirect("Search.aspx?artist=" + query);
        }
    }

    /// <summary>
    /// Grab the query string for Artist id
    /// </summary>
    private string GetQueryString()
    {
        string q = "";
        if (Request.QueryString["artist"] != null)
        {
            q = Request.QueryString["artist"].ToString();
        }
        return q;
    }

    /// <summary>
    /// Search Artist(s) with ArtistName
    /// </summary>
    /// <param name="artist">ArtistName string, first name, last name or combined</param>
    private void SearchForArtist(string artist)
    {
        
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchForName(artist);
        if (ac.Count > 0)
        {
            rptArtist.DataSource = ac;
            rptArtist.DataBind();
        }
    }

}