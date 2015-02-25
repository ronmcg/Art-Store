using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the Orders Table
    /// </summary>
    public class OrdersDataAccess : AbstractDataAccess
    {
        private const string Fields = " CustomerID, DateCreated, DateCompleted ";
        
        public OrdersDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM Orders"; }
        }

        protected override string KeyFieldName
        {
            get { return "OrderID"; }
        }

        protected override string OrderByFields
        {
            get { return "DateCompleted"; }
        }

        /// <summary>
        /// Gets the sales dates (date created) of an artwork
        /// </summary>
        /// <param name="id">artwork id</param>
        /// <returns>Table of dateCreated dates of sales</returns>
        public DataTable GetDateCreatedSalesByArtWorkId(int id)
        {
            string newfields = " Orders.DateCreated ";
            string sql = "SELECT " + newfields + " FROM ((OrderDetails INNER JOIN Orders ON OrderDetails.OrderID = Orders.OrderID) INNER JOIN ArtWorks ON OrderDetails.ArtWorkID = ArtWorks.ArtWorkID) ";
            sql += " WHERE (OrderDetails.ArtWorkID = " + id + ") ";
            sql += " ORDER BY Orders.DateCreated ASC";
            return DataHelper.GetDataTable(sql, null);
        }
    }
}