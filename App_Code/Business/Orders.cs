using System;
using System.Data;
using System.Data.SqlTypes;

using Content.DataAccess;


namespace Content.Business
{
    /// <summary>
    /// Represents an Orders (data of id's and dates for when an order is created and completed)
    /// </summary>
    public class Orders : AbstractBusiness
    {

        private DateTime _dateCreated;

        //These elements are unused but are properties in Orders table
        //private int _orderID;
        //private int _customerID;
        //private DateTime _dateCompleted;

        OrdersDataAccess _ordda = new OrdersDataAccess();

        /// <summary>
        /// Constructor: Data access for Orders
        /// </summary>
        public Orders()
        {
            DataAccess = _ordda;
        }

        #region override methods

        /// <summary>
        /// Set the data members to the data retrieved from the database table/query
        /// </summary>
        /// <param name="row">DataRow of Orders</param> 
        public override void PopulateDataMembersFromDataRow(DataRow row)
        {

            _dateCreated = (DateTime)row["DateCreated"];

            //These elements are unused but are properties in Orders table
            //_orderID = (int)row["OrderID"];
            //_customerID = (int)row["CustomerID"];
            //_dateCompleted = (DateTime)row["DateCompleted"];
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for Orders properties.
        /// </summary>
        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        //These elements are unused but are properties in Orders table
        //public int OrderID
        //{
        //    get { return _orderID; }
        //    set { _orderID = value; }
        //}

        //public int CustomerID
        //{
        //    get { return _customerID; }
        //    set { _customerID = value; }
        //}
 
        //public DateTime DateCompleted
        //{
        //    get { return _dateCompleted; }
        //    set { _dateCompleted = value; }
        //}

        #endregion
    }
}