using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Common;
using Content.DataAccess;

namespace Content.DataAccess
{
    /// <summary>
    /// Provides data access to the Customer table
    /// </summary>
    public class CustomersDataAccess : AbstractDataAccess
    {
        private const string Fields = " FirstName, LastName, Address, City, Region, Country, Postal, Phone, Email, Privacy ";
        
        public CustomersDataAccess()
        {
            
        }
        
        protected override string SelectStatement
        {
            get { return "SELECT " + KeyFieldName + "," + Fields + " FROM Customers "; }
        }

        protected override string OrderByFields
        {
            get { return "LastName"; }
        }

        protected override string KeyFieldName
        {
            get { return "CustomerID"; }
        }

        /// <summary>
        /// Updates values for a customer.
        /// </summary>
        public void UpdateCustomer(int customerId, string firstName, string lastNamw, string address, string city, string region, string country, string postal, string phone, string email, string privacy)
        {
            string sql = "UPDATE Customers SET FirstName=@f, LastName=@l, Address=@a, City=@c, Region=@r, Country=@co, Postal=@p, Phone=@ph, Email=@e, Privacy=@pr";
            sql += " WHERE CustomerID=@id";

            // construct array of parameters

            DbParameter[] parameters = new DbParameter[] {
		    DataHelper.MakeParameter("@f", firstName, DbType.String),
            DataHelper.MakeParameter("@l", lastNamw, DbType.String),
            DataHelper.MakeParameter("@a", address, DbType.String),
            DataHelper.MakeParameter("@c", city, DbType.String),
            DataHelper.MakeParameter("@r", region, DbType.String),
		    DataHelper.MakeParameter("@co", country, DbType.String),
            DataHelper.MakeParameter("@p", postal, DbType.String),
            DataHelper.MakeParameter("@ph", phone, DbType.String),
            DataHelper.MakeParameter("@e", email, DbType.String),
            DataHelper.MakeParameter("@pr", privacy, DbType.String),
            DataHelper.MakeParameter("@id", customerId, DbType.String)};
            // run the specified command
            DataHelper.RunNonQuery(sql, parameters);
        }
    }
}