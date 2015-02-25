using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;
using Content.Business;

namespace Content.Business
{
    /// <summary>
    /// Represents a Gallery
    /// </summary>
    public class Gallery : AbstractBusiness
    {
        private string _galleryName;
        private string _galleryNativeName;
        private string _galleryCity;
        private string _galleryCountry;
        private int _latitude;
        private int _longitude;
        private string _galleryWebSite;
     
        private GalleryDataAccess _galleryDA;

        /// <summary>
        /// Default Constructor: Makes new gallery data access connection
        /// </summary>
        public Gallery() 
        {
            _galleryDA = new GalleryDataAccess();
            base.DataAccess = _galleryDA;
        
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of an gallery</param>

        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            Id = (int)row["GalleryID"];

            if (row["GalleryName"] == DBNull.Value)
                GalleryName = "";
            else
                GalleryName = (string)row["GalleryName"];

            if (row["GalleryNativeName"] == DBNull.Value)
                GalleryNativeName = "";
            else
                GalleryNativeName = (string)row["GalleryNativeName"];
        
            if (row["GalleryCity"] == DBNull.Value)
                GalleryCity = "";
            else
                GalleryCity = (string)row["GalleryCity"];

            if (row["GalleryCountry"] == DBNull.Value)
                GalleryCountry = "";
            else
                GalleryCountry = (string)row["GalleryCountry"];

            if (row["Latitude"] == DBNull.Value)
                Latitude = 0;
            else
                Latitude = Convert.ToInt32(row["Latitude"]);

            if (row["Longitude"] == DBNull.Value)
                Longitude = 0;
            else
                Longitude = Convert.ToInt32(row["Longitude"]);

        
              if (row["GalleryWebSite"] == DBNull.Value)
                GalleryWebSite = "";
            else
                GalleryWebSite = (string)row["GalleryWebSite"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }

        #endregion

        #region properties

            /// <summary>
            /// Getters and Setters for Gallery table properties.
            /// </summary>
            public string GalleryName
            {
                get { return _galleryName; }
                set { _galleryName = value; }
            }
            public string GalleryNativeName
            {
                get { return _galleryNativeName; }
                set { _galleryNativeName = value; }
            }
       
            public string GalleryCity
            {
                get { return _galleryCity; }
                set { _galleryCity = value; }
            }
            public string GalleryCountry
            {
                get { return _galleryCountry; }
                set { _galleryCountry = value; }
            }
            public int Latitude
            {
                get { return _latitude; }
                set { _latitude = value; }
            }
             public int Longitude
            {
                get { return _longitude; }
                set { _longitude = value; }
            }
            public string GalleryWebSite
            {
                get { return _galleryWebSite; }
                set { _galleryWebSite = value; }
            }
            #endregion

        }

}
 