using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;

namespace Content.Business
{

    /// <summary>
    /// Collection that holds Frames for a single or many artworks
    /// </summary>
    public class FrameCollection : AbstractBusinessCollection<Frame>
    {
        
        private FrameDataAccess _frameDataAccess = new FrameDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public FrameCollection()
        {
            
        }

        /// <summary>
        /// Fetches all Frames from the database
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _frameDataAccess.GetAll();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates frame objects from the datatable and adds them to this collection
        /// </summary>
        /// <param name="dt">DataTable of frames</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Frame f = new Frame();
                f.PopulateDataMembersFromDataRow(row);
                AddToCollection(f);
            }
        }
    }
}