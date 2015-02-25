using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides access to the Artist table
    /// </summary>
    public class ArtistDataAccess : AbstractDataAccess
    {
        private const string Fields = " FirstName, LastName, Nationality, YearOfBirth, YearOfDeath, Details, ArtistLink ";

        public ArtistDataAccess()
        {

        }

        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM Artists "; }
        }

        protected override string OrderByFields
        {
            get { return "LastName"; }
        }

        protected override string KeyFieldName
        {
            get { return "ArtistID"; }
        }

        /// <summary>
        /// Get by name
        /// </summary>
        /// <param name="name">Search parameter</param>
        /// <returns>The results</returns>
        public DataTable GetByName(string name)
        {   //setup param in SELECT
            string sql = SelectStatement + " WHERE LastName=@name";
            //DataHelper makes an array of params
            DbParameter[] paramaters = new DbParameter[] { DataHelper.MakeParameter("@name", name, DbType.String) };
            //gets the results
            return DataHelper.GetDataTable(sql, paramaters);
        }

        /// <summary>
        /// Get by similar name
        /// </summary>
        /// <param name="name">Search parameter</param>
        /// <returns>The results</returns>
        public DataTable GetByLikeName(string name)
        {   //setup param in SELECT
            string sql = SelectStatement + " WHERE LastName LIKE @name OR FirstName Like @name ";
            //DataHelper makes an array of params with wildcard
            DbParameter[] paramaters = new DbParameter[] { DataHelper.MakeParameter("@name", "%" + name + "%", DbType.String), DataHelper.MakeParameter("@name", "%" + name + "%", DbType.String) };
            //gets the results
            return DataHelper.GetDataTable(sql, paramaters);
        }

        /// <summary>
        /// Get by nationality
        /// </summary>
        /// <param name="nation">The nation to look for</param>
        /// <returns>DataTable of artists form the same nation</returns>
        public DataTable GetByNationality(string nation)
        {
            string sql = SelectStatement + " WHERE Nationality LIKE @nation";
            DbParameter[] parameters = new DbParameter[] { DataHelper.MakeParameter("@nation", "%" + nation + "%", DbType.String) };
            return DataHelper.GetDataTable(sql, parameters);
        }
    }
}