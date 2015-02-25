using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represents an OrderDetails (data of id's for frame/matt/glass)
    /// </summary>
    public class OrderDetails : AbstractBusiness
    {

        private int _artWorkID;
        private int _frameID;
        private int _mattID;
        private int _glassID;
        //private int _orderID; Unused but a property in OrderDetails

        OrderDetailsDataAccess _odda = new OrderDetailsDataAccess();

        /// <summary>
        /// Constructor: Data access for OrderDetails
        /// </summary>
        public OrderDetails()
        {
            DataAccess = _odda;
        }

        #region override methods

        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of an OrderDetails</param>
        /// 
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {

            if (row["ArtWorkID"] == DBNull.Value)
                ArtWorkID = 0;
            else
                ArtWorkID = Convert.ToInt32(row["ArtWorkID"]);
            if (row["FrameID"] == DBNull.Value)
                FrameID = 0;
            else
                FrameID = Convert.ToInt32(row["FrameID"]);
            if (row["MattID"] == DBNull.Value)
                MattID = 0;
            else
                MattID = Convert.ToInt32(row["MattID"]);
            if (row["GlassID"] == DBNull.Value)
                GlassID = 0;
            else
                GlassID = Convert.ToInt32(row["GlassID"]);
                
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for table properties.
        /// </summary>
        public int ArtWorkID
        {
            get { return _artWorkID; }
            set { _artWorkID = value; }

        }
        public int FrameID
        {
            get { return _frameID; }
            set { _frameID = value; }

        }
        public int MattID
        {
            get { return _mattID; }
            set { _mattID = value; }

        }
        public int GlassID
        {
            get { return _glassID; }
            set { _glassID = value; }

        }
        #endregion
    }
}