using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

/// <summary>
/// You were right, this was hard.
/// -Ronnie
/// </summary>
public partial class Cart : System.Web.UI.Page
{

    private const int SORT_ON_TITLE = 0;
    private const int SORT_ON_MSRP = 1;
    private const int SORT_ON_YEAR = 2;

    /// <summary>
    /// Get the items in existing cart, sort on title. 
    /// </summary>
    private ArtWorkCollection ArtInTheCart
    {
        get { return GetArtInCart(true, SORT_ON_TITLE); }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            SetUpList(true, SORT_ON_TITLE);
            PopulateDropdowns();
            foreach (DataListItem dl in listCart.Items)
            {
                UpdateSubTotal(dl.ItemIndex);
            }
            UpdateTotal();
        }
    }

    /// <summary>
    /// Get the collection of artworks in the cart
    /// </summary>
    /// <param name="asc">True for ascending sort</param>
    /// <param name="sortOn">What column to sort on, use constants</param>
    /// <returns>The art in the cart, sorted as desired</returns>
    private ArtWorkCollection GetArtInCart(bool asc, int sortOn)
    {
        ArtWorkCollection awc = new ArtWorkCollection();
        awc.CreateFromArrayList(SessionHandler.GetUsersSession(SessionHandler.Cart));
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
    /// Populates all of the dropdowns at once.
    /// </summary>
    private void PopulateDropdowns()
    {
        PopulateFrameDropdown();
        PopulateGlassDropdown();
        PopulateMattDropdown();
    }

    /// <summary>
    /// Populates the values for a dropdown.
    /// Find a control is a bit tricky for DataLists since you have
    /// to loop through each item (row in the table) and find the 
    /// control there.
    /// </summary>
    private void PopulateFrameDropdown()
    {
        FrameCollection fc = new FrameCollection();
        fc.FetchAll();
        DropDownList dd = null;
        int i = 0;
        foreach (ArtWork aw in ArtInTheCart)
        {
            dd = (DropDownList)listCart.Items[i].FindControl("drpFrame");
            foreach (Frame f in fc)
            {
                string drpText = f.Title + String.Format(" - {0:c}", f.Price);
                ListItem li = new ListItem(drpText, f.Price.ToString());
                dd.Items.Add(li);
            }
            dd.SelectedIndex = 0;
            i++;
        }
    }

    /// <summary>
    /// Populates the values for a dropdown.
    /// Find a control is a bit tricky for DataLists since you have
    /// to loop through each item (row in the table) and find the 
    /// control there.
    /// </summary>
    private void PopulateMattDropdown()
    {
        MattCollection mc = new MattCollection();
        mc.FetchAll();
        DropDownList dd = null;
        int i = 0;
        foreach (ArtWork aw in ArtInTheCart)
        {
            dd = (DropDownList)listCart.Items[i].FindControl("drpMatt");
            foreach (Matt m in mc)
            {
                string drpText = m.Title;
                ListItem li = new ListItem(drpText, m.Id.ToString());
                dd.Items.Add(li);
            }
            dd.SelectedIndex = 0;
            i++;
        }
    }

    /// <summary>
    /// Populates the values for a dropdown.
    /// Find a control is a bit tricky for DataLists since you have
    /// to loop through each item (row in the table) and find the 
    /// control there.
    /// </summary>
    private void PopulateGlassDropdown()
    {
        GlassCollection gc = new GlassCollection();
        gc.FetchAll();
        DropDownList dd = null;
        int i = 0;
        foreach (ArtWork aw in ArtInTheCart)
        {
            dd = (DropDownList)listCart.Items[i].FindControl("drpGlass");
            foreach (Glass g in gc)
            {
                string drpText = g.Title + String.Format(" - {0:c}", g.Price);
                ListItem li = new ListItem(drpText, g.Price.ToString());
                dd.Items.Add(li);
            }
            dd.SelectedIndex = 0;
            i++;
        }
    }

    /// <summary>
    /// Set the source and binds the data
    /// </summary>
    /// <param name="asc">True for ascending sort</param>
    /// <param name="sortOn">What column to sort on, use constants</param>
    private void SetUpList(bool asc, int sortOn)
    {
        listCart.DataSource = GetArtInCart(asc, sortOn);
        listCart.DataBind();
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
            SetUpList(false, columnToSortOn);
        }
        else
        {
            SetUpList(true, columnToSortOn);
        }
        PopulateDropdowns();
        foreach (DataListItem dl in listCart.Items)
        {
            UpdateSubTotal(dl.ItemIndex);
        }
    }

    /// <summary>
    /// Removes an artwork from the session
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnDeleteArtWork_Click(object sender, EventArgs e)
    {
        Deleter(sender, SessionHandler.Cart);
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
        SetUpList(true, SORT_ON_TITLE);
        PopulateDropdowns();
        UpdateTotal();
    }

    /// <summary>
    /// Update the total label, get all the options from all the art in the cart
    /// and if the quanitity is > 1 loop through and add on the subtotals from each
    /// </summary>
    private void UpdateTotal()
    {
        double sum = 0;
        int i = 0;
        foreach (ArtWork aw in ArtInTheCart)
        {
            TextBox tb = (TextBox)listCart.Items[i].FindControl("txtQuantity");
            int q = 0;
            bool success = Int32.TryParse(tb.Text.ToString(), out q);
            if (success)
            {
                sum += aw.MSRP * q;
                for (int j = 0; j < ArtInTheCart.Count; j++)
                {
                    sum += UpdateSubTotal(j);
                }
            }
            else
            {
                sum += aw.MSRP;
                sum += UpdateSubTotal(i);
            }
            i++;
        }
        string total = String.Format("{0:c}", sum);
        labTotal.Text = total;
    }

    /// <summary>
    /// Update a row 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    private double UpdateSubTotal(int index)
    {
        double sum = 0;
        DropDownList dd = (DropDownList)listCart.Items[index].FindControl("drpFrame");
        sum += Convert.ToDouble(dd.SelectedValue);

        dd = (DropDownList)listCart.Items[index].FindControl("drpGlass");
        sum += Convert.ToDouble(dd.SelectedValue);

        dd = (DropDownList)listCart.Items[index].FindControl("drpMatt");
        int i = dd.SelectedIndex;
        if (i != 34)
        {
            sum += 25; //#34 is none
        }
        Label l = (Label)listCart.Items[index].FindControl("subtotal");
        l.Text = "Options: " + String.Format("{0:c}", sum);
        return sum;
    }

    /// <summary>
    /// Update totals when an event is triggered on click for changes in Frame/Glass/Matt/Quantity of an artwork
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void drpFrame_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTotal();
    }
    protected void drpGlass_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTotal();
    }
    protected void drpMatt_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateTotal();
    }
    protected void txtQuantity_TextChanged(object sender, EventArgs e)
    {
        UpdateTotal();
    }
}