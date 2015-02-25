using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of Matt objects.
    /// </summary>
    public class MattCollection : AbstractBusinessCollection<Matt>
    {
        private MattDataAccess _mda = new MattDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public MattCollection()
        {
            
        }

        /// <summary>
        /// Fetches all Matt objects from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _mda.GetAll();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates Matt objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of Matt objects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Matt m = new Matt();
                m.PopulateDataMembersFromDataRow(row);
                AddToCollection(m);
            }
        }
    }
}