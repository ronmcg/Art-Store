using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// A collection of Artist objects
    /// </summary>
    public class ArtistCollection : AbstractBusinessCollection<Artist>
    {

        private bool _sortedAsc = false;
        private ArtistDataAccess _artistDataAccess = new ArtistDataAccess();

        /// <summary>
        /// Sort by Ascending
        /// </summary>
        public bool SortAsc
        {
            get { return _sortedAsc; }
            set { _sortedAsc = value; }
        }

        /// <summary>
        /// Instantiates an ArtistCollection
        /// </summary>
        /// <param name="allArtists">Will load all artists on true</param>
        public ArtistCollection(bool allArtists)
        {
            if (allArtists)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Get all of the artists from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _artistDataAccess.GetAllSorted(true);
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
            DataTable dt = _artistDataAccess.GetById(id);
            PopulateFromDataTable(dt);
        }
        
        /// <summary>
        /// Get all the artist from the same nation
        /// </summary>
        /// <param name="nation">The nation to look for</param>
        public void FetchForNationality(string nation)
        {
            DataTable dt = _artistDataAccess.GetByNationality(nation);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Get artist(s) from the given artist name
        /// </summary>
        /// <param name="nation">The name to look for</param>
        public void FetchForName(string name)
        {
            DataTable dt = _artistDataAccess.GetByLikeName(name);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Gets the top selling artists
        /// NOTE: Top selling artists is defined as the artists of the top 
        /// selling works of art
        /// </summary>
        /// <param name="howMany">how many artists for the table to display</param>
        public void FetchTopSellingArtists(int howMany)
        {
            ArtWorkCollection awc = new ArtWorkCollection();
            awc.FetchTopSellingArtWorks(howMany);
            CreateFromArtWorkCollection(awc);
        }

        /// <summary>
        /// Make an artist collection from a artwork collection
        /// </summary>
        /// <param name="awc">The artwork collection</param>
        public void CreateFromArtWorkCollection(ArtWorkCollection awc)
        {
            foreach (ArtWork aw in awc)
            {
                int id = aw.ArtistId;
                DataTable dt = _artistDataAccess.GetById(id);
                PopulateFromDataTable(dt);
            }
        }

        /// <summary>
        /// Makes an artist collection from an arraylist of artist id's
        /// </summary>
        /// <param name="al">Array List of artist id's</param>
        public void CreateFromArrayList(ArrayList al)
        {
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    int id = (int)al[i];
                    DataTable dt = _artistDataAccess.GetById(id);
                    PopulateFromDataTable(dt);
                }
            }
        }

        /// <summary>
        /// Uses LINQ magic to sort the collection
        /// </summary>
        /// <param name="acs">True for ascending</param>
        public void SortByName(bool asc)
        {
            Array sortedArtists = null;
            if (asc == true)
            {
                sortedArtists = this.OrderBy(o => o.LastName).ToArray();
                _sortedAsc = true;
            }
            else
            {
                sortedArtists = this.OrderByDescending(o => o.LastName).ToArray();
                _sortedAsc = false;
            }
            this.Clear();
            foreach (Artist a in sortedArtists)
            {
                this.AddToCollection(a);
            }
        }

        /// <summary>
        /// Creates Artist objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of artists</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Artist a = new Artist();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

    }
}