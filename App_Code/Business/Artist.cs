using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;


namespace Content.Business
{

    /// <summary>
    /// Business object for Artist information
    /// </summary>
    public class Artist : AbstractBusiness
    {
        private string _firstName;
        private string _lastName;
        private string _nationality;
        private string _details;
        private int _yearOfDeath;
        private string _artistLink;
        private int _yearOfBirth;
        
        private ArtistDataAccess _artistDA = new ArtistDataAccess();

        /// <summary>
        /// Instantiate an artist with ArtistDataAccess
        /// </summary>
        public Artist()
        {
            DataAccess = _artistDA;
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of an artist</param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            Id = (int)row["ArtistID"];

            if (row["FirstName"] == DBNull.Value)
                FirstName = "";
            else
                FirstName = (string)row["FirstName"];

            if (row["LastName"] == DBNull.Value)
                LastName = "";
            else
                LastName = (string)row["LastName"];

            YearOfBirth = Convert.ToInt32(row["YearOfBirth"]);
            YearOfDeath = Convert.ToInt32(row["YearOfDeath"]);

            if (row["Nationality"] == DBNull.Value)
                Nationality = "";
            else
                Nationality = (string)row["Nationality"];

            if (row["Details"] == DBNull.Value)
                Details = "";
            else
                Details = (string)row["Details"];

            if (row["ArtistLink"] == DBNull.Value)
                ArtistLink = "";
            else
                ArtistLink = (string)row["ArtistLink"];


            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for Artists table properties.
        /// </summary>
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string FullNameComma
        {
            get { return LastName + ", " + FirstName; }
        }
        public int YearOfBirth
        {
            get { return _yearOfBirth; }
            set { _yearOfBirth = value; }
        }
        public int YearOfDeath
        {
            get { return _yearOfDeath; }
            set { _yearOfDeath = value; }
        }
        public string Details
        {
            get { return _details; }
            set { _details = value; }
        }
        public string ArtistLink
        {
            get { return _artistLink; }
            set { _artistLink = value; }
        }
        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
        #endregion
    }
}