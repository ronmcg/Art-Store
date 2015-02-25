using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Represents a collection of Glass objects.
    /// </summary>
    public class GlassCollection : AbstractBusinessCollection<Glass>
    {
        private GlassDataAccess _gc = new GlassDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public GlassCollection()
        {
   
        }

        /// <summary>
        /// Fetches all Glass objects from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _gc.GetAll();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates glass objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of glass objects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Glass g = new Glass();
                g.PopulateDataMembersFromDataRow(row);
                AddToCollection(g);
            }
        }
    }
}