using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the Genres Table
    /// </summary>
    public class GenreDataAccess : AbstractDataAccess
    {

        private const string Fields = " Genres.GenreName, Genres.Era, Genres.Description, Genres.Link ";
        
        public GenreDataAccess()
        {
            
        }

        // Inner Joint ArtWorks Table , ArtWorkGenres, and Genres
        protected override string SelectStatement
        {
            get
            {
                return " SELECT " + KeyFieldName + "," + Fields + " FROM Genres";
            }
        }
        
        // Genres Primary Key field Getter Property
        protected override string KeyFieldName
        {
            get
            {
                return "Genres.GenreID ";
            }
        }
        protected override string OrderByFields
        {
            get 
            {
                return "Era, GenreName";
            }
        }

        /// <summary>
        /// Returns a data table containing Genres table info for the specified artwork.
        /// Note that this data set will contain either 0,1, or N rows of data.
        /// Note : This unique case because to get ArtWorks's Genre it uses three diffrent table. ArtWords and Genries are joined by the ArtWorkGenres Table 
        /// </summary>
        /// <param name="artworkid">The artwork id</param>
        /// <returns>Table of Genres</returns>
        public DataTable GetGenresByArtWorkId(int artworkid)
        { 
            string newFields = " ArtWorks.ArtWorkID, Genres.GenreID, Genres.GenreName, Genres.Era, Genres.Description, Genres.Link ";
            string newSelect = " SELECT " + KeyFieldName + "," + newFields + " FROM ((ArtWorks INNER JOIN ArtWorkGenres ON ArtWorks.ArtWorkID = ArtWorkGenres.ArtWorkID) INNER JOIN  Genres ON ArtWorkGenres.GenreID = Genres.GenreID) ";
            string sql = newSelect + " WHERE ArtWorks.ArtWorkID = @artworkid ";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] { DataHelper.MakeParameter("@artworkid", artworkid, DbType.Int32) };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}