using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Content.Business;

public partial class Subjects : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!CheckQueryStringSet())
        {
            SetUpRepeaterSubjects(-1);
        }
        else
        {
            int id = 0;
            bool success = Int32.TryParse(GetQueryString(), out id);
            
            if (success)
             SetUpRepeaterSubjects(id);
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
    /// Grabs the Subjects List repeater of artworks according to SubjectId query string.
    /// </summary>
    private void SetUpRepeaterSubjects(int subjectID)
    {
        SubjectCollection sc = null;
        if (subjectID == -1)
        {
            sc = new SubjectCollection(true);
        }
        else
        {
            sc = new SubjectCollection(false);
            sc.FetchById(subjectID);
        }
        rptSubjects.DataSource = sc;
        rptSubjects.DataBind();
    }
}