using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of Orders objects.
    /// </summary>
    public class OrdersCollection : AbstractBusinessCollection<Orders>
    {
        private OrdersDataAccess _orda = new OrdersDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public OrdersCollection()
        {

        }

        /// <summary>
        /// Fetches all Orders objects from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _orda.GetAll();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates Orders objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of Orders</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            //populate this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Orders o = new Orders();
                o.PopulateDataMembersFromDataRow(row);
                AddToCollection(o);
            }
        }

        /// <summary>
        /// Artworks.aspx - Orders (sales) panel
        /// Fetches orders by 'date created' property, for a single artwork
        /// </summary>
        /// <param name="id">artwork id</param>
        public void FetchByArtworkID(int id)
        {
            DataTable dt = _orda.GetDateCreatedSalesByArtWorkId(id);
            PopulateFromDataTable(dt);
            _isNew = false;
        }
    }
}