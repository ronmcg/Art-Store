using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides access to the Galleries table
    /// </summary>
    public class GalleryDataAccess : AbstractDataAccess
    {   
        // this Fields hold all the fields in Galleries table except the keyFeild
        private const string Fields = " GalleryName, GalleryNativeName, GalleryCity, GalleryCountry, Latitude, Longitude,GalleryWebSite ";

        public GalleryDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get
            { return  "SELECT "+KeyFieldName+","+Fields+ " FROM Galleries "; }
        }

        protected override string KeyFieldName
        {
            get
            {
                return "GalleryID";
            }
        }
        protected override string OrderByFields
        {
            get
            {
                return "GalleryName";
            }
        }
  }
}