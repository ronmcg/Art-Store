using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides data access to the ArtWorkReview table
    /// </summary>
    public class ArtWorkReviewDataAccess : AbstractDataAccess
    {

        private const string Fields = " ArtWorkReviews.ReviewId, ArtWorkReviews.ArtWorkId, ArtWorkReviews.Reviewer, ArtWorkReviews.ReviewDate, ArtWorkReviews.Rating, ArtWorkReviews.Comment ";
       
        public ArtWorkReviewDataAccess()
        {
        }

        protected override string SelectStatement
        {
            get       
            {
                string sql = "SELECT " + Fields;
                sql += " FROM  ArtWorks INNER JOIN  ArtWorkReviews ON ArtWorks.ArtWorkID = ArtWorkReviews.ArtWorkId ";
                return sql;
            }
        }

        protected override string OrderByFields
        {
            get
            {
                return "ReviewId";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return " ReviewId";
            }
        }

        /// <summary>
        /// Get reviews by artwork id.
        /// </summary>
        /// <param name="artworkid">artwork id</param>
        public DataTable GetReviewsByArtWorkId(int artworkid)
        {
            string sql = SelectStatement + " WHERE ArtWorks.ArtWorkID=@artworkid ";
            //params
            DbParameter[] param = new DbParameter[] {
              DataHelper.MakeParameter("@artworkid",artworkid, DbType.Int32)
            };
            return DataHelper.GetDataTable(sql, param);
        }

        /// <summary>
        ///  Last two reviews from the table are the most recent. Grabs the lastest review specified by the parameter.
        /// </summary>
        /// <param name="howManyX">Number of reviews to display</param>
        public DataTable GetRecentReviews(int howManyX) { 
            string sql=" SELECT TOP " + howManyX + " "+ Fields ;
                   sql += " FROM ArtWorkReviews ";
                   sql += " ORDER BY " + OrderByFields + " DESC ";
                   return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Get artworks reviews by average rating of an artwork.
        /// </summary>
        /// <param name="artworkid">artwork id</param>
        public static object GetCurrentAvgRating(int artworkid)
        {
            string sql = " SELECT AVG(Rating) AS AvgRating ";
            sql += " FROM ArtWorkReviews ";
            sql += " WHERE ArtWorkId = @artworkid ";
            DbParameter[] param = new DbParameter[] {
              DataHelper.MakeParameter("@artworkid", artworkid, DbType.Int32)
            };
            return DataHelper.RunScalar(sql, param);
        }
        
        /// <summary>
        /// Addes a new review to the ArtWorkReview table
        /// </summary>
        /// <param name="artworkid">artwork id</param>
        /// <param name="comment">reviewers comment on an artwork</param>
        /// <param name="rating">rating 1-5 given to an artwork</param>
        /// <param name="reviewer">username of a logged in reviewer</param>
        public void InsertReview(int artworkid, string reviewer, int rating, string comment)
        {
            string sql = " INSERT INTO ArtWorkReviews(ArtWorkId,Reviewer,ReviewDate,Rating,Comment)";
            sql += " VALUES (@Artworkid,@Reviewer,@ReviewDate,@Rating,@Commet)";

            // array of parameters 
            DbParameter[] parameters = new DbParameter[] 
            {
                DataHelper.MakeParameter("@Artworkid", artworkid, DbType.Int32),
                DataHelper.MakeParameter("@Reviewer", reviewer, DbType.String),
                DataHelper.MakeParameter("@ReviewDate",DateTime.Today, DbType.DateTime),
                DataHelper.MakeParameter("@Rating", rating, DbType.Int32),
                DataHelper.MakeParameter("@Commet","<p>" + comment + "</p>", DbType.String)
			};
            DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Updates the selected review values
        /// </summary>
        /// <param name="artworkid">artwork id</param>
        /// <param name="comment">reviewers comment on an artwork</param>
        /// <param name="rating">rating 1-5 given to an artwork</param>
        /// <param name="reviewer">username of a logged in reviewer</param>
        public void UpdateReview(int reviewId, string reviewer, int rating, string comment)
        {
            string sql = "UPDATE ArtWorkReviews SET Reviewer=@Reviewer, ReviewDate=@ReviewDate, Rating=@Rating, Comment=@Comment";
            sql += " WHERE ReviewId=@ReviewId";

         // construct array of parameters
         DbParameter[] parameters = new DbParameter[] {
		    DataHelper.MakeParameter("@Reviewer", reviewer, DbType.String),
            DataHelper.MakeParameter("@ReviewDate", DateTime.Today, DbType.DateTime),
            DataHelper.MakeParameter("@Rating", rating, DbType.Int32),
            DataHelper.MakeParameter("@Comment", comment, DbType.String),
            DataHelper.MakeParameter("@ReviewId", reviewId, DbType.Int32)
														   };
         // run the specified command
         DataHelper.RunNonQuery(sql, parameters);
        }

        /// <summary>
        /// Deletes the selected review.
        /// </summary>
        /// <param name="reviewID">review ID</param>
        public void DeleteReview(int reviewID)
        {
            string sql = "DELETE FROM ArtWorkReviews WHERE ReviewId=@ReviewId ";
            
            DbParameter[] parameters = new DbParameter[] {
            DataHelper.MakeParameter("@ReviewId", reviewID, DbType.Int32)
			};
            // run the specified command
            DataHelper.RunNonQuery(sql, parameters);
        }
  
    }
}