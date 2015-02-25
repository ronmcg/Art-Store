using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlTypes;


namespace Content.Business
{
    /// <summary>
    /// Represents a Frame (an artwork framing material, data)
    /// </summary>
    public class Frame : AbstractBusiness
    {
        private string _title;
        private decimal _price;
        private string _color;

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public Frame()
        {

        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            if (row["FrameID"] == DBNull.Value)
                Id = 0;
            else
                Id = (int)row["FrameID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["Price"] == DBNull.Value)
                Price = 0;
            else
                Price = (decimal)row["Price"];

            if (row["Color"] == DBNull.Value)
                Color = "";
            else
                Color = (string)row["Color"];
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for TypesFrame table properties.
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
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        #endregion  

    }
}