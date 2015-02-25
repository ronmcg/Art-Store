using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Represents a collection of Customer objects.
    /// </summary>
    public class CustomerCollection : AbstractBusinessCollection<Customer>
    {
        
        private CustomersDataAccess _cda = new CustomersDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public CustomerCollection()
        {
            
        }

        /// <summary>
        /// Fetches all customer objects.
        /// </summary>
        public void FetchAll()
        {
            DataTable dt = _cda.GetAll();
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Fetch customer objects by customer id
        /// </summary>
        /// <param name="id">customer id</param>
        public void FetchForId(int id)
        {
            DataTable dt = _cda.GetById(id);
            PopulateFromDataTable(dt);
        }

        /// <summary>
        /// Creates Customer objects from the datatable and puts them in this collection
        /// </summary>
        /// <param name="dt">DataTable of Customer objects</param>
        private void PopulateFromDataTable(DataTable dt)
        {
            // population this collection from this data table
            foreach (DataRow row in dt.Rows)
            {
                Customer c = new Customer();
                c.PopulateDataMembersFromDataRow(row);
                AddToCollection(c);
            }
        }
    }
}