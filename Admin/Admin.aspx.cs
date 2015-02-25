using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Admin_Admin : System.Web.UI.Page
{
    //this customer is the one being edited
    Customer editedCustomer = new Customer();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            int query = GetQueryString();
            if (query > 0)
            {
                SetUpEditForm(query);
            }
            else
            {
                SetUpAdminRepeater();
            }
        }
    }

    /// <summary>
    /// Puts all the customers into a table
    /// </summary>
    private void SetUpAdminRepeater()
    {
        CustomerCollection cc = new CustomerCollection();
        cc.FetchAll();
        adminRepeat.DataSource = cc;
        adminRepeat.DataBind();
    }

    /// <summary>
    /// Shows the edit customer formview
    /// </summary>
    /// <param name="id">id of the customer</param>
    private void SetUpEditForm(int id)
    {
        CustomerCollection cc = new CustomerCollection();
        cc.FetchForId(id);
        editView.DataSource = cc;
        editView.DataBind();
    }

    /// <summary>
    /// Grab Query String
    /// </summary>
    private int GetQueryString()
    {
        int customerId = 0;
        Int32.TryParse(Request["edit"], out customerId);
        return customerId;
    }

    /// <summary>
    /// Build the edited customer and update it
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnSubmit_Click(object sender, EventArgs e)
    {
        editedCustomer.Id = GetQueryString();
        editedCustomer.FirstName = GetTextFromTextBox("txtFirstName");
        editedCustomer.LastName = GetTextFromTextBox("txtLastName");
        editedCustomer.Address = GetTextFromTextBox("txtAddress");
        editedCustomer.City = GetTextFromTextBox("txtCity");
        editedCustomer.Region = GetTextFromTextBox("txtRegion");
        editedCustomer.Country = GetTextFromTextBox("txtCountry");
        editedCustomer.Postal = GetTextFromTextBox("txtPostal");
        editedCustomer.Phone = GetTextFromTextBox("txtPhone");
        editedCustomer.Email = GetTextFromTextBox("txtEmail");
        editedCustomer.Privacy = GetTextFromTextBox("txtPrivacy");
        editedCustomer.UpdateCustomer();
        Response.Redirect("Admin.aspx", true);
    }

    /// <summary>
    /// Grabs the text from a text box
    /// </summary>
    /// <param name="id">The string id of the control</param>
    /// <returns></returns>
    private string GetTextFromTextBox(string id)
    {
        TextBox tb = (TextBox)editView.FindControl(id);
        string text = tb.Text;
        return tb.Text;
    }
}