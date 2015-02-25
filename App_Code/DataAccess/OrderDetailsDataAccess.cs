using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the OrderDetails Table
    /// </summary>
    public class OrderDetailsDataAccess : AbstractDataAccess
    {

        private const string Fields = " ArtWorkID ";

        public OrderDetailsDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get { return "SELECT " + Fields + " FROM OrderDetails "; }
        }

        protected override string OrderByFields
        {
            get { return "ArtWorkID"; }
        }

        protected override string KeyFieldName
        {
            get { return "OrderDetailsID"; }
        }

        /// <summary>
        /// Returns a data table containing the top X records (based on the sort order). 
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        /// <param name="howMany">Number to display</param>
        /// <param name="ascending">boolean, sort by ascending if true</param>
        /// <returns>Table of artworks</returns>
        public DataTable GetTopSellingArtWorks(int howMany, bool ascending)
        {
            // set up parameterized query statement
            string sql = SelectStatement;
            sql += " GROUP BY " + OrderByFields + " ORDER BY COUNT(" + OrderByFields + ")";

            if (!ascending)
                sql += " DESC";

            string topSql = sql.Replace("SELECT", "SELECT TOP " + howMany);
            return DataHelper.GetDataTable(topSql, null);
        }


    }
}