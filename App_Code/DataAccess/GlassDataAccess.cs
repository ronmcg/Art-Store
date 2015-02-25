using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the TypesGlass Table
    /// </summary>
    public class GlassDataAccess : AbstractDataAccess
    {
        private const string Fields = " Title, Description, Price";
        
        public GlassDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM TypesGlass "; }
        }

        protected override string OrderByFields
        {
            get { return "LastName"; }
        }

        protected override string KeyFieldName
        {
            get { return "GlassID"; }
        }
    }
}