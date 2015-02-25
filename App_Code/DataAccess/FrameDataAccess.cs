using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides access to the TypesFrames table
    /// </summary>
    public class FrameDataAccess : AbstractDataAccess
    {
        private const string Fields = " Title, Price, Color";

        public FrameDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM TypesFrames "; }
        }

        protected override string OrderByFields
        {
            get { return "Title"; }
        }

        protected override string KeyFieldName
        {
            get { return "FrameID"; }
        }
    }
}