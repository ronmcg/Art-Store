using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.Business;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Summary description for Customer
    /// </summary>
    public class Customer : AbstractBusiness
    {
        private string _firstName;
        private string _lastName;
        private string _address;
        private string _city;
        private string _region;
        private string _country;
        private string _postal;
        private string _phone;
        private string _email;
        private string _privacy;
        
        CustomersDataAccess _da = new CustomersDataAccess();

        /// <summary>
        /// Default Constructor: Empty
        /// </summary>
        public Customer()
        {

        }

        /// <summary>
        /// Constructor: Create a new Customer object manually.
        /// </summary>
        public Customer(int customerId, string firstName, string lastNamw, string address, string city, string region, string country, string postal, string phone, string email, string privacy)
        {
            Id = customerId;
            FirstName = firstName;
            LastName = lastNamw;
            Address = address;
            City = city;
            Region = region;
            Country = country;
            Postal = postal;
            Phone = phone;
            Email = email;
            Privacy = privacy;
        }

        /// <summary>
        /// Updates this customer. Don't pass any nulls, use "" instead.
        /// </summary>
        public void UpdateCustomer()
        {
            _da.UpdateCustomer(Id, FirstName, LastName, Address, City, Region, Country, Postal, Phone, Email, Privacy);
        }

        #region override methods
        /// <summary>
        /// set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of an artist</param>
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {
            Id = (int)row["CustomerID"];

            if (row["FirstName"] == DBNull.Value)
                FirstName = "";
            else
                FirstName = (string)row["FirstName"];

            if (row["LastName"] == DBNull.Value)
                LastName = "";
            else
                LastName = (string)row["LastName"];

            if (row["Address"] == DBNull.Value)
                Address = "";
            else
                Address = (string)row["Address"];

            if (row["City"] == DBNull.Value)
                City = "";
            else
                City = (string)row["City"];

            if (row["Region"] == DBNull.Value)
                Region = "";
            else
                Region = (string)row["Region"];

            if (row["Country"] == DBNull.Value)
                Country = "";
            else
                Country = (string)row["Country"];

            if (row["Postal"] == DBNull.Value)
                Postal = "";
            else
                Postal = (string)row["Postal"];

            if (row["Phone"] == DBNull.Value)
                Phone = "";
            else
                Phone = (string)row["Phone"];

            if (row["Email"] == DBNull.Value)
                Email = "";
            else
                Email = (string)row["Email"];

            if (row["Privacy"] == DBNull.Value)
                Privacy = "";
            else
                Privacy = (string)row["Privacy"];
        }
        #endregion

        #region properties
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string Postal
        {
            get { return _postal; }
            set { _postal = value; }
        }
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Privacy
        {
            get { return _privacy; }
            set { _privacy = value; }
        }

        #endregion
    }
}