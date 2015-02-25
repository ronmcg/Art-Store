using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Collection that holds Reviews for an artwork
    /// </summary>
    public class ArtWorkReviewCollection : AbstractBusinessCollection<ArtWorkReview>
    {
        private ArtWorkReviewDataAccess awR = new ArtWorkReviewDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public ArtWorkReviewCollection()
        {
  
        }

        /// <summary>
        /// Constructor: If true, return all reviews of an artwork
        /// </summary>
        /// <param name="allReviews">boolean, return all reviews if true</param>
        public ArtWorkReviewCollection(bool allReviews)
        {
            if (allReviews)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Fetches reviews according to passed in artworkId
        /// </summary>
        /// <param name="artworkid">artwork id</param>
        public void FetchReviewsByArtWorkId(int artworkid)
        {
            DataTable dt = awR.GetReviewsByArtWorkId(artworkid);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        ///  Grabs the most recent reviews from Artworks Table
        /// </summary>
        /// <param name="howManyX">Number of reviews to grab</param>
        public void GetRecentReviews(int howManyX)
        {
            DataTable dt = awR.GetRecentReviews(howManyX);
            PopulateFromDataTable(dt);        
        }

        /// <summary>
        /// Given ArtWorkId, it returns the artworks average rating based on each review rating
        /// </summary>
        /// <param name="id">ArtworkId to rate</param>
        public int FetchCurrentAvgRating(int id)
        {
           int avgRating = 0;
           object o = ArtWorkReviewDataAccess.GetCurrentAvgRating(id);
           if (o != DBNull.Value)
               avgRating = (int)Math.Ceiling(Convert.ToDecimal(o));
           return avgRating;
        }

        /// <summary>
        /// Get all of the artists from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = awR.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates ArtWorkReview objects from the datatable and puts them in this collection
        /// </summary>
        /// <param name="dt">DataTable of ArtWorkReview objects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                ArtWorkReview a = new ArtWorkReview();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }
    }

}