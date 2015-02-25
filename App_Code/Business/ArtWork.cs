using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represent an artwork
    /// </summary>
    public class ArtWork : AbstractBusiness
    {
        private int _artworkId;
        private int _artistId;
        private string _lastName;
        private string _imageFileName;
        private string _title;
        private string _description;
        private string _excerpt;
        private int _artWorkType;
        private int _yearOfWork;
        private int _width;
        private int _height;
        private string _medium;
        private string _orginalHome;
        private int _galleryID;
        private double _cost;
        private double _MSRP;
        private string _artWorkLink;
        private string _googleLink;

        private ArtWorksDataAccess _artWorksDataAccess = new ArtWorksDataAccess();

        /// <summary>
        /// Instantiates the object and sets it's DataAccess for ArtWorksDataAccess
        /// </summary>
        public ArtWork()
        {
            DataAccess = _artWorksDataAccess;
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {

            if (row["ArtWorkID"] != "")
            {
                ArtWorkID = Convert.ToInt32(row["ArtWorkID"]);
                Id = Convert.ToInt32(row["ArtWorkID"]);
            }

            if (row["ArtistID"] == DBNull.Value)
                ArtistId = 0;
            else
                ArtistId = Convert.ToInt32(row["ArtistID"]);
            try
            {
                if (row["LastName"] == DBNull.Value)
                    LastName = "";
                else
                    LastName = (string)row["LastName"];
            }
            catch(ArgumentException e)
            {
                /* Not all artwork collections search for a last name, if we
                 * don't have it then we don't need it
                 * */
            }

            if (row["ImageFileName"] == DBNull.Value)
                ImageFileName = "";
            else
                ImageFileName = (string)row["ImageFileName"];

            if (row["Title"] == DBNull.Value)
                Title = "";
            else
                Title = (string)row["Title"];

            if (row["Description"] == DBNull.Value)
                Description = "";
            else
                Description = (string)row["Description"];

            if (row["Excerpt"] == DBNull.Value)
                Excerpt = "";
            else
                Excerpt = (string)row["Excerpt"];

            if (row["ArtWorkType"] == DBNull.Value)
                ArtWorkType = 0;
            else
                ArtWorkType = Convert.ToInt32(row["ArtWorkType"]);

            if (row["YearOfWork"] == DBNull.Value)
                YearOfWork = 0;
            else
                YearOfWork = Convert.ToInt32(row["YearOfWork"]);

            if (row["Width"] == DBNull.Value)
                Width = 0;
            else
                Width = Convert.ToInt32(row["Width"]);

            if (row["Height"] == DBNull.Value)
                Height = 0;
            else
                Height = Convert.ToInt32(row["Height"]);

            if (row["Medium"] == DBNull.Value)
                Medium = "";
            else
                Medium = (string)row["Medium"];

            if (row["OriginalHome"] == DBNull.Value)
                OriginalHome = "";
            else
                OriginalHome = (string)row["OriginalHome"];

            if (row["GalleryID"] == DBNull.Value)
                GalleryID = 0;
            else
                GalleryID = Convert.ToInt32(row["GalleryID"]);

            if (row["Cost"] == DBNull.Value)
                Cost = 0;
            else
                Cost = Convert.ToDouble(row["Cost"]);

            if (row["MSRP"] == DBNull.Value)
                MSRP = 0;
            else
                MSRP = Convert.ToDouble(row["MSRP"]);

            if (row["ArtWorkLink"] == DBNull.Value)
                ArtWorkLink = "";
            else
                ArtWorkLink = (string)row["ArtWorkLink"];

            if (row["GoogleLink"] == DBNull.Value)
                GoogleLink = "";
            else
                GoogleLink = (string)row["GoogleLink"];

            // since we are populating this object from data set its object variables
            IsNew = false;
            IsModified = false;
        }
        
        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for ArtWorks table properties.
        /// </summary>
        public int ArtWorkID
        {
            get { return _artworkId; }
            set { _artworkId = value; }

        }
        public int ArtistId
        {
            get { return _artistId; }
            set { _artistId = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string ImageFileName
        {
            get { return _imageFileName; }
            set { _imageFileName = value; }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public string Excerpt
        {
            get { return _excerpt; }
            set { _excerpt = value; }
        }
        public int ArtWorkType
        {
            get { return _artWorkType; }
            set { _artWorkType = value; }
        }
        public int YearOfWork
        {
            get { return _yearOfWork; }
            set { _yearOfWork = value; }
        }
        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public string Medium
        {
            get { return _medium; }
            set { _medium = value; }
        }
        public string OriginalHome
        {
            get { return _orginalHome; }
            set { _orginalHome = value; }
        }
        public int GalleryID
        {
            get { return _galleryID; }
            set { _galleryID = value; }
        }
        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
        public double MSRP
        {
            get { return _MSRP; }
            set { _MSRP = value; }
        }
        public string ArtWorkLink
        {
            get { return _artWorkLink; }
            set { _artWorkLink = value; }
        }
        public string GoogleLink
        {
            get { return _googleLink; }
            set { _googleLink = value; }
        }
        #endregion
    }
}