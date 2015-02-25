using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides data access to the ArtWorks table
    /// </summary>
    public class ArtWorksDataAccess : AbstractDataAccess
    {

        private const string Fields = " Artists.LastName, ArtWorks.ArtistID, ArtWorks.ArtWorkID, ImageFileName, Title, Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink ";

        public ArtWorksDataAccess()
        {
        }

        protected override string SelectStatement
        {
            get
            {
                string sql = "SELECT " + Fields + " FROM ArtWorks";
                sql += " INNER JOIN Artists ON ArtWorks.ArtistID = Artists.ArtistID";
                return sql;
            }
        }

        protected override string OrderByFields
        {
            get
            {
                return "YearOfWork, Title";
            }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "ArtWorkID";
            }
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for this wild card title search.
        /// Note that this data set will contain either 0 or many rows of data.
        /// </summary>
        /// <param name="title">ArtWorks title</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetLikeTitle(string title)
        {
            //string stilte = "%" + title + "%";
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE Title LIKE @title";

            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			  DataHelper.MakeParameter("@title", "%" + title + "%" , DbType.String)
			};
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Returns a data table containing ArtWorks table info for the specified artist.
        /// Note that this data set will contain either 0,1, or N rows of data.
        /// </summary>
        /// <param name="artistId">The artist id</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetByArtist(int artistId)
        {
            string sql = SelectStatement + " WHERE ArtWorks.ArtistID=@artistid";
            //params
            DbParameter[] param = new DbParameter[] {
                DataHelper.MakeParameter("@artistid", artistId, DbType.Int32)
            };
            return DataHelper.GetDataTable(sql, param);
        }

        /// <summary>
        /// Get top selling art according to sales (OrderDetails)
        /// </summary>
        /// <param name="howMany">Number of how many to display</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetTopSellingArt(int howMany)
        {
            string sql = "SELECT TOP " + howMany + " ArtWorks.ArtistID, ArtWorks.ArtWorkID, ImageFileName, Title, Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink";
            sql += " FROM (SELECT OrderDetails.ArtWorkID,ArtWorks.ArtistID, ArtWorks.ArtWorkID, ImageFileName, Title, Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink";
            sql += " FROM OrderDetails INNER JOIN ArtWorks ON OrderDetails.ArtWorkID=ArtWorks.ArtWorkID";
            sql += " GROUP BY OrderDetails.ArtWorkID,ArtWorks.ArtistID, ArtWorks.ArtWorkID, ImageFileName, Title, Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink";
            sql += " ORDER BY COUNT(OrderDetails.ArtWorkID) DESC)";
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Get artworks according to Genre
        /// </summary>
        /// <param name="genreID">specific Genre to display</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetByGenre(int genreID)
        {
            string sql = "SELECT ArtWorks.ArtistID, ArtWorks.ArtWorkID, ImageFileName, Title, ArtWorks.Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink, ArtWorkGenres.GenreID, Genres.GenreName ";
            sql += " FROM ((ArtWorks INNER JOIN ArtWorkGenres ON ArtWorks.ArtWorkID=ArtWorkGenres.ArtWorkID) INNER JOIN Genres ON  ArtWorkGenres.GenreID= Genres.GenreID) ";
            sql += " WHERE Genres.GenreID=@id";
            //params
            DbParameter[] param = new DbParameter[] {
                DataHelper.MakeParameter("@id", genreID, DbType.Int32)
            };
            return DataHelper.GetDataTable(sql, param);
        }

        /// <summary>
        /// Get artworks according to subjects
        /// </summary>
        /// <param name="subjectID">The subject id</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetBySubject(int subjectID)
        {
            string sql = " SELECT ArtWorks.ArtistID, ArtWorks.ArtWorkID AS ArtWorkID, ImageFileName, Title, Description, Excerpt, ArtWorkType, YearOfWork, Width, Height, Medium, OriginalHome, GalleryID, Cost, MSRP, ArtWorkLink, GoogleLink , ArtWorkSubjects.ArtWorkID, ArtWorkSubjects.SubjectID ";
            sql += "FROM ((ArtWorks INNER JOIN ArtWorkSubjects ON ArtWorks.ArtWorkID=ArtWorkSubjects.ArtWorkID) INNER JOIN Subjects ON  ArtWorkSubjects.SubjectID= Subjects.SubjectId) ";
            sql += "WHERE Subjects.SubjectId=@id";
            //params
            DbParameter[] param = new DbParameter[] {
                DataHelper.MakeParameter("@id", subjectID, DbType.Int32)
            };
            return DataHelper.GetDataTable(sql, param);
        }

        /// <summary>
        /// Get artworks according to Advanced Search criteria (specified by parameters)
        /// </summary>
        /// <param name="ys">year of work start</param>
        /// <param name="ye">year of work end</param>
        /// <param name="ms">msrp start price (least expensive)</param>
        /// <param name="me">msrp end price (most expensive)</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetByAdvanced(int ys, int ye, int ms, int me)
        {
            string sql = SelectStatement;
            sql = sql.Replace("Artists.LastName, ", "");
            sql = sql.Replace("INNER JOIN Artists ON ArtWorks.ArtistID = Artists.ArtistID", "");
            sql += "WHERE YearOfWork BETWEEN @ys AND @ye AND MSRP BETWEEN @ms AND @me";
            //params
            DbParameter[] param = new DbParameter[] {
                DataHelper.MakeParameter("@ys", ys, DbType.Int32), DataHelper.MakeParameter("@ye", ye, DbType.Int32), DataHelper.MakeParameter("@ms", ms, DbType.Int32), DataHelper.MakeParameter("@me", me, DbType.Int32)
            };
            return DataHelper.GetDataTable(sql, param);
        }

        /// <summary>
        /// Datatable to grab the newest artworks (number to display given by user)
        /// Newest: Select top # sorted by ArtworkID descending, newest are those added last on the ArtWorks table
        /// </summary>
        /// <param name="howMany">The number of artworks</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetNewArtworks(int howMany)
        {
            string newfields = Fields.Replace("Artists.LastName, ", " ");
            string sql = "SELECT TOP " + howMany + newfields;
            sql += " FROM Artworks ";
            sql += " ORDER BY ArtWorkID DESC";
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Related Artworks Leaderboard: Get artworks set by Genre
        /// </summary>
        /// <param name="genre">Genre to match</param>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetByGenre(string genre)
        {
            string newFields = " ArtWorks.Title, ArtWorks.ArtWorkID, Genres.GenreName ";
            string newSelect = "SELECT " + newFields + " FROM ((ArtWorks INNER JOIN ArtWorkGenres ON ArtWorks.ArtWorkID = ArtWorkGenres.ArtWorkID) INNER JOIN Genres ON ArtWorkGenres.GenreID = Genres.GenreID) ";
            string sql = newSelect + " WHERE (Genres.GenreName LIKE " + " @genre " + " )";
            DbParameter[] parameters = new DbParameter[] { DataHelper.MakeParameter("@genre", genre, DbType.String) };
            return DataHelper.GetDataTable(sql, parameters);
        }

        /// <summary>
        /// Get list of all artworks
        /// </summary>
        /// <returns>DataTable of artworks</returns>
        public DataTable GetArtWorksList()
        {
            string sql = SelectStatement.Replace("Artists.LastName, ", " ");
            sql += " ORDER BY " + OrderByFields.Replace("YearOfWork,", " ");
            return DataHelper.GetDataTable(sql, null);
        }
    }
}