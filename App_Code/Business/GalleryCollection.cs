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
    /// Represents a collection of Gallery objects.
    /// we are not going to keep the collection of all gallery in cache memory since we 
    /// may unlikely access it so frequently
    /// </summary>
    public class GalleryCollection : AbstractBusinessCollection<Gallery>
    {

        private GalleryDataAccess _galleryDA = new GalleryDataAccess();

        /// <summary>
        /// Instantiates an GalleryCollection
        /// </summary>
        /// <param name="allArtists">Will load all gallery on true</param>
        public GalleryCollection(bool preloadAll)
        {
            if (preloadAll)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Get all of the artists from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _galleryDA.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Get a single artist
        /// </summary>
        /// <param name="id">The artist ID</param>
        public void FetchForId(int id)
        {
            DataTable dt = _galleryDA.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates Gallery objects from the datatable and puts them in this collection
        /// </summary>
        /// <param name="dt">DataTable of gallery objects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Gallery g = new Gallery();
                g.PopulateDataMembersFromDataRow(row);
                AddToCollection(g);
            }
        }
    }
}
