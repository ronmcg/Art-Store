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
    /// A collection that either holds a single piece of art or all of the art for an artist
    /// </summary>
    public class ArtWorkCollection : AbstractBusinessCollection<ArtWork>
    {

        ArtWorksDataAccess _awda = new ArtWorksDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public ArtWorkCollection()
        {
           
        }

        /// <summary>
        /// Constructor: If true, return all artworks of an artist
        /// </summary>
        /// <param name="allArtworks">boolean, return all artworks if true</param>
        public ArtWorkCollection(bool allArtworks)
        {
            if (allArtworks)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Get all of the artists from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _awda.GetAllSorted(true);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch all of the art work by an artist
        /// </summary>
        /// <param name="artistId">The artists ID</param>
        public void FetchForArtist(int artistId)
        {
            DataTable dt = _awda.GetByArtist(artistId);
            // population this collection from this data table
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Fetch a single piece of art
        /// </summary>
        /// <param name="artWorkId">The artworks ID</param>
        public void FetchForId(int artWorkId)
        {
            DataTable dt = _awda.GetById(artWorkId);
            PopulateFromDataTable(dt);
            _isNew = false;
        }

        /// <summary>
        /// Leaderboard Control: Top Selling Artworks
        /// Fetch pieces of art defined by how many (int) is passed in.
        /// Note: Top selling art based on sales
        /// </summary>
        /// <param name="howMany">Number, how many artworks to display in table</param>
        public void FetchTopSellingArtWorks(int howMany)
        {
            DataTable dt = _awda.GetTopSellingArt(howMany);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Leaderboard Control: New Additions (Artworks)
        /// Fetch pieces of art defined by how many (int) is passed in.
        /// Note: New artwork is defined by order that art has been added in artworks table
        /// This method therefore grabs from items at bottom of table -> Newest
        /// </summary>
        /// <param name="howMany">Number, how many artworks to display in table</param>  
        public void FetchNewArtworks(int howMany)
        {
            DataTable dt = _awda.GetNewArtworks(howMany);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Control: RelatedArtworksControl for SingleArtWork.aspx
        /// Grabs artworks based on passed in GenreName
        /// </summary>
        /// <param name="genre">GenreName to match</param> 
        public void FetchForGenre(int genre)
        {
            DataTable dt = _awda.GetByGenre(genre);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Repeater: ArtworksList.aspx
        /// Fetch all pieces of art
        /// </summary>
        public void FetchArtWorksList()
        {
            DataTable dt = _awda.GetArtWorksList();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// This is used exclusively in the LeaderboardControl, since we have to use OrderDetailCollection
        /// to get the best sellers we use that collection (which contains only ArtWorkID's) to create
        /// an ArtWorkCollection
        /// </summary>
        /// <param name="odc">The OrderDetailsCollection you want to turn into an ArtWorkCollection</param>
        public void CreateFromOrderDetailsCollection(OrderDetailsCollection odc)
        {
            foreach (OrderDetails od in odc)
            {
                ArtWork aw = new ArtWork();
                int id = od.ArtWorkID;
                FetchForId(id);
            }
        }

        /// <summary>
        /// Creates the art work collection that matches the title words of an artwork
        /// </summary>
        /// <param name="title">artwork title</param>
        public void FetchLikeTitle(string title)
        {
            DataTable dt = _awda.GetLikeTitle(title);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates the art work collection that matches the genre words of an artwork
        /// </summary>
        /// <param name="title">genre title</param>
        public void FetchByGenreID(int genreid)
        {
            DataTable dt = _awda.GetByGenre(genreid);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates the art work collection that matches the subject id of an artwork
        /// </summary>
        /// <param name="subId">subject id</param>
        public void FetchBySubjectID(int subID)
        {
            DataTable dt = _awda.GetBySubject(subID);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Used in Search.aspx, collection of artwork based on defined parameter criteria.
        /// </summary>
        /// <param name="ys">year of work start</param>
        /// <param name="ye">year of work end</param>
        /// <param name="ms">msrp start price (least expensive)</param>
        /// <param name="me">msrp end price (most expensive)</param>
        public void FetchByAdvanced(int ys, int ye, int ms, int me)
        {
            DataTable dt = _awda.GetByAdvanced(ys, ye, ms, me);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates the art work collection from an arraylist of artwork IDs
        /// </summary>
        /// <param name="al"></param>
        public void CreateFromArrayList(ArrayList al)
        {
            if (al != null)
            {
                for (int i = 0; i < al.Count; i++)
                {
                    int id = (int)al[i];
                    DataTable dt = _awda.GetById(id);
                    PopulateFromDataTable(dt);
                }
            }
        }

        /// <summary>
        /// Sort artworks based on title (ascending or descending)
        /// </summary>
        /// <param name="asc">boolean, if true, artworks sorted by title ascending</param>
        public void SortByTitle(bool asc)
        {
            Array sortedArtWorks = null;

            if (asc == true)
            {
                sortedArtWorks = this.OrderBy(o => o.Title).ToArray();
            }
            else
            {
                sortedArtWorks = this.OrderByDescending(o => o.Title).ToArray();
            }
            this.Clear();

            foreach (ArtWork a in sortedArtWorks)
            {
                this.AddToCollection(a);
            }
        }

        /// <summary>
        /// Sort artworks based on MSRP (ascending or descending)
        /// </summary>
        /// <param name="asc">boolean, if true, artworks sorted by MSRP ascending</param>
        public void SortByMSRP(bool asc)
        {
            Array sortedArtWorks = null;
            if (asc == true)
            {
                sortedArtWorks = this.OrderBy(o => o.MSRP).ToArray();
            }
            else
            {
                sortedArtWorks = this.OrderByDescending(o => o.MSRP).ToArray();
            }
            this.Clear();
            foreach (ArtWork a in sortedArtWorks)
            {
                this.AddToCollection(a);
            }
        }

        /// <summary>
        /// Sort artworks based on year (ascending or descending)
        /// </summary>
        /// <param name="asc">boolean, if true, artworks sorted by year ascending</param>
        public void SortByYear(bool asc)
        {
            Array sortedArtWorks = null;
            if (asc == true)
            {
                sortedArtWorks = this.OrderBy(o => o.YearOfWork).ToArray();
            }
            else
            {
                sortedArtWorks = this.OrderByDescending(o => o.YearOfWork).ToArray();
            }
            this.Clear();
            foreach (ArtWork a in sortedArtWorks)
            {
                this.AddToCollection(a);
            }
        }

        /// <summary>
        /// Creates ArtWork objects from the datatable and puts them in this collection
        /// </summary>
        /// <param name="dt">DataTable of artworks</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                ArtWork a = new ArtWork();
                a.PopulateDataMembersFromDataRow(row);
                AddToCollection(a);
            }
        }

    }
}