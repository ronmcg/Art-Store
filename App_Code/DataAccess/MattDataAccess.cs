using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the TypesMatt Table
    /// </summary>
    public class MattDataAccess : AbstractDataAccess
    {
        private const string Fields = " Title, ColorCode";
        
        public MattDataAccess()
        {
             
        }

        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM TypesMatt "; }
        }

        protected override string OrderByFields
        {
            get { return "LastName"; }
        }

        protected override string KeyFieldName
        {
            get { return "MattID"; }
        }
    }
}