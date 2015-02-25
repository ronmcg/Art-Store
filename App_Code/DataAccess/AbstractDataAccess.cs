using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{

    /// <summary>
    /// Encapsulates common functionality needed by the data access classes
    /// </summary>
    public abstract class AbstractDataAccess
    {
        /// <summary>
        /// Defines the basic select statement for retrieving data 
        /// without criteria.
        /// 
        /// This property is implemented by the concrete subclasses.
        /// </summary>
        protected abstract string SelectStatement
        {
            get;
        }


        /// <summary>
        /// Defines the field you want to sort by
        /// 
        /// This property is implemented by the concrete subclasses.
        /// </summary>
        protected abstract string OrderByFields
        {
            get;
        }


        /// <summary>
        /// Defines any field name of primary key field
        /// 
        /// This property is implemented by the concrete subclasses.
        /// </summary>
        protected abstract string KeyFieldName
        {
            get;
        }

        /// <summary>
        /// Returns a data table containing PostCategory table info for this id.
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public DataTable GetById(int id)
        {
            // set up parameterized query statement
            string sql = SelectStatement + " WHERE " + KeyFieldName + "=@id";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] {
			   DataHelper.MakeParameter("@id", id, DbType.Int32)
			};
            return DataHelper.GetDataTable(sql, parameters);
        }


        /// <summary>
        /// Returns all the data for the data source
        /// </summary>
        public DataTable GetAll()
        {
            string sql = SelectStatement;
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Returns all the data for the data source
        /// </summary>
        public DataTable GetAllSorted(bool ascending)
        {
            string sql = SelectStatement;
            sql += " ORDER BY " + OrderByFields;
            if (!ascending)
                sql += " DESC";
            return DataHelper.GetDataTable(sql, null);
        }

        /// <summary>
        /// Returns a data table containing the top X records (based on the sort order).
        /// 
        /// Note that this data set will contain either 0 or 1 rows of data.
        /// </summary>
        public virtual DataTable GetTop(int howMany, bool ascending)
        {
            string sql = SelectStatement;
            sql += " ORDER BY " + OrderByFields;
            if (!ascending)
                sql += " DESC";

            string topSql = sql.Replace("SELECT", "SELECT TOP " + howMany);
            return DataHelper.GetDataTable(topSql, null);
        }
    }
}