using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_ArtWorkResultsControl : System.Web.UI.UserControl
{
    private const int SORT_ON_TITLE = 0;
    private const int SORT_ON_MSRP = 1;
    private const int SORT_ON_YEAR = 2;

    private ArtWorkCollection awc = new ArtWorkCollection();

    protected void Page_Load(object sender, EventArgs e)
    {
        switch (GetQueryType())
        {
            case 1:
                SearchByTitle(GetQueryString());
                break;
            case 2:
                SearchByGenre(GetQueryString());
                break;
            case 3:
                SearchBySubject(GetQueryString());
                break;
            case 4:
                SearchByAdvanced();
                break;
        }
    }

    /// <summary>
    /// regardless of the kind of search you are doing the value you
    /// are searching for must be in a query string called query
    /// </summary>
    /// <returns></returns>
    private string GetQueryString()
    {
        string q = "";
        if (Request.QueryString["query"] != null)
        {
            q = Request.QueryString["query"].ToString();
        }
        return q;
    }

    private int GetQueryType()
    {
        int t = 0;
        if (Request.QueryString["type"] != null)
        {
            bool success = Int32.TryParse(Request.QueryString["type"].ToString(), out t);
        }
        return t;
    }

    private ArtWorkCollection SearchByTitle(string title)
    {
        awc.FetchLikeTitle(title);
        listArtWorks.DataSource = awc;
        listArtWorks.DataBind();
        return awc;
    }

    private ArtWorkCollection SearchByGenre(string genre)
    {
        int g = 0;
        bool success = Int32.TryParse(genre, out g);
        if (success)
        {
            awc.FetchByGenreID(g);
        }
        listArtWorks.DataSource = awc;
        listArtWorks.DataBind();
        return awc;
    }

    private ArtWorkCollection SearchBySubject(string subject)
    {
        int s = 0;
        bool success = Int32.TryParse(subject, out s);
        if (success)
        {
            awc.FetchBySubjectID(s);
        }
        listArtWorks.DataSource = awc;
        listArtWorks.DataBind();
        return awc;
    }

    private ArtWorkCollection SearchByAdvanced()
    {
        //default values if they didn't specify a criteria
        int ys = 0;
        int ye = 999999;
        int ms = 0;
        int me = 999999;
        if (Request.QueryString["yearstart"] != null)
            Int32.TryParse(Request.QueryString["yearstart"].ToString(), out ys);
        if (Request.QueryString["yearend"] != null)
            Int32.TryParse(Request.QueryString["yearend"].ToString(), out ye);
        if (Request.QueryString["msrpstart"] != null)
            Int32.TryParse(Request.QueryString["msrpstart"].ToString(), out ms);
        if (Request.QueryString["msrpend"] != null)
            Int32.TryParse(Request.QueryString["msrpend"].ToString(), out me);
        awc.FetchByAdvanced(ys, ye, ms, me);
        listArtWorks.DataSource = awc;
        listArtWorks.DataBind();
        return awc;
    }


    /// <summary>
    /// Sort by title
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void sortTitle_Click(object sender, EventArgs e)
    {
        SortArtWorkColumn(SessionHandler.SortTitle, SORT_ON_TITLE);
    }

    /// <summary>
    /// sort by MSRP
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void sortMSRP_Click(object sender, EventArgs e)
    {
        SortArtWorkColumn(SessionHandler.SortMSRP, SORT_ON_MSRP);
    }

    /// <summary>
    /// Sort by YearOfWork
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void sortYear_Click(object sender, EventArgs e)
    {
        SortArtWorkColumn(SessionHandler.SortYear, SORT_ON_YEAR);
    }

    /// <summary>
    /// Resorts the list in the session and then rebind the data
    /// </summary>
    /// <param name="whichSortSession">Which session to check for last sort</param>
    /// <param name="columnToSortOn">sort flag</param>
    private void SortArtWorkColumn(string whichSortSession, int columnToSortOn)
    {
        bool ascending = SessionHandler.FlipSortingSession(whichSortSession);
        if (ascending)
        {
            SetUpArtWorkDataLists(false, columnToSortOn);
        }
        else
        {
            SetUpArtWorkDataLists(true, columnToSortOn);
        }
    }

    private void SetUpArtWorkDataLists(bool p, int columnToSortOn)
    {
        listArtWorks.DataSource = GetArtWorkCollection(p, columnToSortOn);
        listArtWorks.DataBind();
    }

    /// <summary>
    /// Makes an art work collection from the ArrayList of artwork IDs
    /// </summary>
    /// <returns></returns>
    private ArtWorkCollection GetArtWorkCollection(bool asc, int sortOn)
    {
        switch (sortOn)
        {
            case SORT_ON_TITLE:
                awc.SortByTitle(asc);
                break;
            case SORT_ON_MSRP:
                awc.SortByMSRP(asc);
                break;
            case SORT_ON_YEAR:
                awc.SortByYear(asc);
                break;
        }
        return awc;
    }

    /// <summary>
    /// Some paintings don't have descriptions so let the user know that.
    /// </summary>
    protected string CleanUpEmptyDescriptions(string desc)
    {
        if (desc == "")
        {
            return "<i>No Description</i>";
        }
        else
        {
            return desc;
        }
    }

}