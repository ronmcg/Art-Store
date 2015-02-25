using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_LeaderBoardArtistControl : System.Web.UI.UserControl
{
    public int _howMany;

    protected void Page_Load(object sender, EventArgs e)
    {
        SetUpRepeater();
    }

    /// <summary>
    /// Set the data source and bind it to the repeater.
    /// No need to error check odc since the worst case scenario
    /// is that nothing is displayed.
    /// </summary>
    private void SetUpRepeater()
    {
        ArtistCollection ac = new ArtistCollection(false);
        ac.FetchTopSellingArtists(HowMany);
        repeaterArtists.DataSource = ac;
        repeaterArtists.DataBind();
    }

    /// <summary>
    /// Reload the leaderboard
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void DropHowMany_SelectedIndexChanged(object sender, EventArgs e)
    {
        HowMany = Convert.ToInt32(dropHowMany.SelectedValue);
        SetUpRepeater();
    }

    public int HowMany
    {
        get { return _howMany; }
        set { _howMany = value; }
    }

}