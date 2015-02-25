using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlTypes;
using System.Web;
using Content.DataAccess;
using Content.Business;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of Subject objects.
    /// </summary>
    public class SubjectCollection : AbstractBusinessCollection<Subject>
    {
        private SubjectDataAccess _sDA = new SubjectDataAccess();
        private const string CACHE_SUBJECTS = "subjects";

        /// <summary>
        /// Default Constructor: Loads all Subjects
        /// </summary>
        public SubjectCollection(bool preloadAll)
        {
            if (preloadAll)
            {
                FetchAll();
            }
        }

        /// <summary>
        /// Get all of the Subjects from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = (DataTable)HttpContext.Current.Cache[CACHE_SUBJECTS];
            if (dt == null)
            {
                dt = _sDA.GetAll();
                HttpContext.Current.Cache[CACHE_SUBJECTS] = dt;
            }
            // population this collection from this data table
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch all of the subjects by an artwork
        /// </summary>
        /// <param name="id">The artwork ID</param>
        public void FetchByArtWorkId(int id)
        {
            DataTable dt = _sDA.GetSubjectsByArtWorkId(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates Subject objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of Subjects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Subject s = new Subject();
                s.PopulateDataMembersFromDataRow(row);
                AddToCollection(s);
            }
        }

        /// <summary>
        /// Fetch artworks by genre id
        /// </summary>
        /// <param name="genreID">The genre id</param>
        public void FetchById(int genreID)
        {
            DataTable dt = _sDA.GetById(genreID);
            PopulateFromDataTable(dt);
        }
    }
}

