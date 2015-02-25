using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represents a Glass (an artwork framing material, data)
    /// </summary>
    public class Glass : AbstractBusiness
    {

        private string _title;
        private decimal _price;
        private string _description;

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public Glass()
        {

        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of TypesGlass</param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            if (row["GlassID"] == DBNull.Value)
                Id = 0;
            else
                Id = (int)row["GlassID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["Price"] == DBNull.Value)
                Price = 0;
            else
                Price = (decimal)row["Price"];

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = (string)row["Description"];
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for TypesGlass properties.
        /// </summary>

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        #endregion

    }
}