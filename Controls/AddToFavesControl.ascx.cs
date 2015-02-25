using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_AddToFavesControl : System.Web.UI.UserControl
{
    private const string ARTIST = "ARTIST";
    private const string ARTWORK = "ARTWORK";

    private int _idToAdd;
    private string _typeOfFave;

    //this property is set from the .aspx page by IdToAdd=Eval("Id")
    public int IdToAdd
    {
        get { return _idToAdd; }
        set { _idToAdd = value; }
    }

    //this property is set from the .aspx page, must be "ARTIST" or "ARTWORK"
    public string TypeOfFave
    {
        get { return _typeOfFave; }
        set { _typeOfFave = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    /// <summary>
    /// Add the current artists id to the favourites
    /// </summary>
    /// <param name="o"></param>
    /// <param name="e"></param>
    protected void linkFaves_ClickEvent(object o, EventArgs e)
    {
        if (TypeOfFave == ARTIST)
        {
            SessionHandler.AddToUsersSession(SessionHandler.Artist, IdToAdd);
        }
        else if (TypeOfFave == ARTWORK)
        {
            SessionHandler.AddToUsersSession(SessionHandler.ArtWork, IdToAdd);
        }
        
        //addedBadge.Style["display"] = "block";

        //reload the page so the faves will show up in the view faves modal
        Response.Redirect(Request.RawUrl);
    }
}