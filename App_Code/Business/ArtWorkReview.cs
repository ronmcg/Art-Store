using System;
using System.Data;
using System.Data.SqlTypes;
using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represents a Review, a description of an artwork made by a logged in user.
    /// </summary>
    public class ArtWorkReview :  AbstractBusiness 
    {

        private int _reviewId;
        private int _artworkId;
        private string _reviewer;
        private DateTime _reviewdate;
        private int _rating;
        private string _comment;


        ArtWorkReviewDataAccess awR = new ArtWorkReviewDataAccess();

        /// <summary>
        /// Default Constructor: Instantiates a Review with ArtWorkReviewDataAccess
        /// </summary>
        public ArtWorkReview()
        {
            DataAccess = awR;
        }

        /// <summary>
        /// Constructor: Instantiates a Review with ArtWorkReviewDataAccess, sets parameters.
        /// </summary>
        public ArtWorkReview(int artworkid, string reviewer, int rating, string comment)
        {
             DataAccess=awR;
             _artworkId = artworkid;
             _reviewer = reviewer;
             _rating = rating;
             _comment = comment;
        }

        /// <summary>
        /// Constructor: Instantiates a Review with ArtWorkReviewDataAccess, populates only a specific review.
        /// </summary>
        /// <param name="reviewid">reviewId of a single review</param>
        public ArtWorkReview(int reviewid)
        {
            DataAccess = awR;
            DataTable dt = awR.GetById(reviewid);
            PopulateDataMembersFromDataRow(dt.Rows[0]);
        }

        /// <summary>
        /// Updates review fields.
        /// </summary>
        public void Update()
        {
            awR.UpdateReview(Id, Reviewer, Rating, Comment);
        }

        /// <summary>
        /// Does an insert to changes to review fields.
        /// </summary>
        public void Insert()
        {
            awR.InsertReview(ArtWorkId, Reviewer, Rating, Comment);
        }

        /// <summary>
        /// Deletes review fields.
        /// </summary>
        public void Delete()
        {
            awR.DeleteReview(Id);
        }
   
        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row"></param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {

            if (row["ReviewId"] == DBNull.Value)
                Id = 0;
            else
                Id = Convert.ToInt32(row["ReviewId"]);

            if (row["ArtWorkId"] == DBNull.Value)
                ArtWorkId = 0;
            else
                ArtWorkId = Convert.ToInt32(row["ArtWorkId"]);
           
            if (row["Reviewer"] == DBNull.Value)
                Reviewer = ""; 
            else
                Reviewer = (string)row["Reviewer"];

            ReviewDate = (DateTime)row["ReviewDate"];

             if (row["Rating"] == DBNull.Value)
                Rating = 0; 
            else
                Rating = (int)row["Rating"];

            if (row["Comment"] == DBNull.Value)
                 Comment = ""; 
            else
                 Comment  = (string)row["Comment"];

            IsNew = false;
            IsModified = false;
        }

     
        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for ArtWorkReviews table properties.
        /// </summary>
        /// 
        public int ReviewId
        {
            get { return _reviewId; }
            set { _reviewId = value; }

        }
        public int ArtWorkId
        {
            get { return _artworkId; }
            set { _artworkId = value; }
        }

        public string Reviewer
        {
            get { return _reviewer; }
            set { _reviewer = value; }
        }

        public DateTime ReviewDate
        {
            get { return _reviewdate; }
            set { _reviewdate = value; }
        }
        
        public int  Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        public string Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }
        #endregion
        
    }
}