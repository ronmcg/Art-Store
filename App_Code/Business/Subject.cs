using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Content.DataAccess;
using Content.Business;


namespace Content.Business
{
    /// <summary>
    /// Represents a Subject (an artwork attribute)
    /// </summary>
    public class Subject : AbstractBusiness
    {
        private string _subjectName;
        private SubjectDataAccess _subjectDA;

        /// <summary>
        /// Constructor: Data access for Subjects
        /// </summary>
        public Subject()
        {
            _subjectDA = new SubjectDataAccess();
            base.DataAccess = _subjectDA;
        }

        #region override methods

        public override void PopulateDataMembersFromDataRow(DataRow row)
        {

            /// <summary>
            /// Set the data members to the data retrieved from the database table/query
            /// </summary>
            /// <param name="row">DataRow of Subjects</param> 
            Id = (int)row["SubjectId"];

            if (row["SubjectName"] == DBNull.Value)
                    SubjectName = "";
            else
            SubjectName = (string)row["SubjectName"];
        }

        #endregion

        #region properties

        /// <summary>
        /// Getters and Setters for table properties.
        /// </summary>
        public string SubjectName
        {
            get { return _subjectName; }
            set { _subjectName = value; }
        }

        #endregion
    }
}