using System;
using System.Data;
using System.Web;
using Content.DataAccess;

namespace Content.Business
{
    /// <summary>
    /// Base class for all business classes
    /// </summary>
    public abstract class AbstractBusiness
    {
        //data members
        protected const int DefaultId = 0;
        private int _id;
        private AbstractDataAccess _dataAccess;
        
        //flags for the object
        private bool _isNew;
        private bool _isModified;

        /// <summary>
        /// Given a data table with data, populate the business objects data members.
        /// 
        /// Implemented by each business object subclass
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        public abstract void PopulateDataMembersFromDataRow(DataRow table);

        
        /// <summary>
        /// Saves the current business object
        /// </summary>
        public void Save()
        {
            if (IsValid)
            {
                if (IsModified)
                {
                    if (IsNew) { }
                    //Insert();
                    else { }
                        //Update();
                }
            }
        }

      /// <summary>
      /// The data access class used by this business object
      /// </summary>
      protected AbstractDataAccess DataAccess
      {
         get { return _dataAccess; }
         set { _dataAccess = value; }
      }

      /// <summary>
      /// Has the business object been modified since last save
      /// </summary>
      protected bool IsModified
      {
         get { return _isModified; }
         set { _isModified = value; }
      }

      /// <summary>
      /// Is this business object new or does it contain 
      /// data that exists in database
      /// </summary>
      public bool IsNew
      {
         get { return _isNew; }
         set { _isNew = value; }
      }


      /// <summary>
      /// The id of the business object
      /// </summary>
      public int Id
      {
         get { return _id; }
         set {
            if (_id != value)
            {
               _id = value;
               IsModified = true;
            }
         }
      }

      /// <summary>
      /// Is the business object valid
      /// </summary>
      public bool IsValid
      {
         get
         {
            //BusinessRules.Assert("IdNotLessZero","Id can not be less than zero",Id < 0);
            //CheckIfSubClassStateIsValid();
             return true; //BusinessRules.AreNoBrokenRules;
         }
      }
    }
}