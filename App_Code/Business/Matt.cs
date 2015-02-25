using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represents a Matt (an artwork framing material, data)
    /// </summary>
    public class Matt : AbstractBusiness
    {
        private string _title;
        private string _colorCode;

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public Matt()
        {
             
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of TypesMatt</param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            if (row["MattID"] == DBNull.Value)
                Id = 0;
            else
                Id = (int)row["MattID"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["ColorCode"] == DBNull.Value)
                ColorCode = "";
            else
                ColorCode = (string)row["ColorCode"];
        }

       #endregion

        # region properties

        /// <summary>
        /// Getters and Setters for TypesMatt table properties.
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string ColorCode
        {
            get { return _colorCode; }
            set { _colorCode = value; }
        }

        #endregion

    }
}