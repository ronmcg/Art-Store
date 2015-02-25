using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of Genre objects.
    /// we are not going to keep the collection of all genre in cache memory since we 
    /// may unlikely access it so frequently
    /// </summary>
    /// 
    public class GenreCollection : AbstractBusinessCollection<Genre>
    {
        private GenreDataAccess _genreDA = new GenreDataAccess();
        private const string CACHE_GENRES = "genres";
        /// <summary>
        /// Instantiates an GenreCollection
        /// </summary>
        /// <param name="allGenre">Will load all genre on true</param>
        public GenreCollection(bool preloadAll)
        {
            if (preloadAll)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Fetch genre of artworks by genre id
        /// </summary>
        /// <param name="id">genre id to match</param>
        public void FetchById(int id)
        {
            DataTable dt = _genreDA.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch all genres from the database, sorted
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = (DataTable)HttpContext.Current.Cache[CACHE_GENRES];
            if (dt == null)
            {
                dt = _genreDA.GetAll();
                HttpContext.Current.Cache[CACHE_GENRES] = dt;
            }
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch genre of artworks by artwork id
        /// </summary>
        /// <param name="id">artwork id to match</param>
        public void FetchByArtWorkID(int id)
        {
            DataTable dt = _genreDA.GetGenresByArtWorkId(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates genre objects from the datatable and puts them in this collection
        /// </summary>
        /// <param name="dt">DataTable of genres</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Genre ge = new Genre();
                ge.PopulateDataMembersFromDataRow(row);
                AddToCollection(ge);
            }
        }
    }
}