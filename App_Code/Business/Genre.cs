using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;
using Content.Business;

namespace Content.Business {

    /// <summary>
    /// Represents a Genre
    /// </summary>
    public class Genre : AbstractBusiness
    {
        private int _genreId;
        private string _genreName;
        private Int32 _era;
        private string _description;
        private string _link;

        private GenreDataAccess _genreDA;

        /// <summary>
        /// Default Constructor: Makes new genre data access connection
        /// </summary>
        public Genre()
        {
            _genreDA = new GenreDataAccess();
            base.DataAccess = _genreDA;
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of Genres</param>
        /// 
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            GenreID = Convert.ToInt32(row["GenreID"]);
            Id = Convert.ToInt32(row["GenreID"]);
            if (row["GenreName"] == DBNull.Value)
                GenreName = "";
            else
                GenreName = (string)row["GenreName"];

            if (row["Era"] == DBNull.Value)
                Era = 0;
            else
                Era = Convert.ToInt32(row["Era"]);

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = (string)row["Description"];

            if (row["Link"] == DBNull.Value)
                Link = "";
            else
                Link = (string)row["Link"];
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for Genres table properties.
        /// </summary>
        public int GenreID
        {
            get { return _genreId; }
            set { _genreId = value; }
        }

        public string GenreName
        {
            get { return _genreName; }
            set { _genreName = value; }
        }

        public Int32 Era
        {
            get { return _era; }
            set { _era = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        public string Link
        {
            get { return _link; }
            set { _link = value; }
        }

        #endregion
    }
}