using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of OrderDetails objects.
    /// </summary>
    public class OrderDetailsCollection : AbstractBusinessCollection<OrderDetails>
    {

        private OrderDetailsDataAccess _odda = new OrderDetailsDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public OrderDetailsCollection()
        {
            
        }

        /// <summary>
        /// Fetch top selling artwork based on passed in int
        /// </summary>
        /// <param name="x">number of top selling artworks to fetch</param>
        public void FetchTopX(int x)
        {
            DataTable dt = _odda.GetTopSellingArtWorks(x, false);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates od objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of OrderDetails</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach(DataRow row in dt.Rows)
            {
                OrderDetails o = new OrderDetails();
                o.PopulateDataMembersFromDataRow(row);
                AddToCollection(o);
            }
        }
    }
}