using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_FavouritesControl : System.Web.UI.UserControl
{
    private const int SORT_ON_TITLE = 0;
    private const int SORT_ON_MSRP = 1;
    private const int SORT_ON_YEAR = 2;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUpDataLists(true);
        }
    }

    /// <summary>
    /// Makes an artist collection using the ArrayList of artist IDs
    /// </summary>
    /// <param name="asc">True for ascending</param>
    /// <returns></returns>
    private ArtistCollection GetArtistCollection(bool asc)
    {
        ArtistCollection ac = new ArtistCollection(false);
        ac.CreateFromArrayList(SessionHandler.GetUsersSession(SessionHandler.Artist));
        ac.SortByName(asc);
        return ac;
    }

    /// <summary>
    /// Makes an art work collection from the ArrayList of artwork IDs
    /// </summary>
    /// <returns></returns>
    private ArtWorkCollection GetArtWorkCollection(bool asc, int sortOn)
    {
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.CreateFromArrayList(SessionHandler.GetUsersSession(SessionHandler.ArtWork));
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
    /// Set source and bind the collections to our DataLists
    /// </summary>
    private void SetUpDataLists(bool asc)
    {
        listArtists.DataSource = GetArtistCollection(asc);
        listArtists.DataBind();
        listArtWorks.DataSource = GetArtWorkCollection(asc, SORT_ON_TITLE);
        listArtWorks.DataBind();
    }

    /// <summary>
    /// Set source and bind the collections to the artist DataList
    /// </summary>
    private void SetUpArtistDataLists(bool asc)
    {
        listArtists.DataSource = GetArtistCollection(asc);
        listArtists.DataBind();
    }
    /// <summary>
    /// Set source and bind the collections to the artist DataList
    /// </summary>
    private void SetUpArtWorkDataLists(bool asc, int sortOn)
    {
        listArtWorks.DataSource = GetArtWorkCollection(asc, sortOn);
        listArtWorks.DataBind();
    }

    /// <summary>
    /// Resorts the list in the session by LastName then re bind the data
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void sortName_Click(object sender, EventArgs e)
    {
        bool ascending = SessionHandler.FlipSortingSession(SessionHandler.SortName);
        if (ascending)
        {
            SetUpArtistDataLists(false);
        }
        else
        {
            SetUpArtistDataLists(true);
        }
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

    /// <summary>
    /// Removes an artist from the session
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteArtist_Click(object sender, EventArgs e)
    {
        Deleter(sender, SessionHandler.Artist);
    }

    /// <summary>
    /// Removes an artwork from the session
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteArtWork_Click(object sender, EventArgs e)
    {
        Deleter(sender, SessionHandler.ArtWork);
    }

    /// <summary>
    /// Removes an item from the session
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="session"></param>
    private void Deleter(object sender, string session)
    {
        LinkButton lb = (LinkButton)sender;
        int idToDelete = Convert.ToInt32(lb.CommandArgument);
        SessionHandler.RemoveFromUsersSession(session, idToDelete);
        SetUpDataLists(true);
    }
}