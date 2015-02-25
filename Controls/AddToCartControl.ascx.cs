using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Controls_AddToCartControl : System.Web.UI.UserControl
{
    private string _idToAdd;

    public string IdToAdd
    {
        get { return _idToAdd; }
        set { _idToAdd = value; }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void linkAddToCart_Click(object sender, EventArgs e)
    {
        int artWorkId = Convert.ToInt32(_idToAdd);
        if (artWorkId > 0)
        {
            SessionHandler.AddToUsersSession(SessionHandler.Cart, artWorkId);
        }
    }
}