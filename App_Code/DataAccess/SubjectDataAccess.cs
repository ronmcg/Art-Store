using System;
using System.Data;
using System.Data.Common;

namespace Content.DataAccess
{
    /// <summary>
    /// Data Access Class for the Subjects Table
    /// </summary>
    public class SubjectDataAccess : AbstractDataAccess
    {
        private const string Fields = "Subjects.SubjectName ";

        // Inner Join ArtWorks , ArtWorkSubjects, and Subjects Tables
        protected override string SelectStatement
        {
            get
            { return " SELECT " + KeyFieldName + "," + Fields + " FROM Subjects"; }           
        }

        protected override string KeyFieldName
        {
            get
            {
                return "Subjects.SubjectId";
            }
        }

        protected override string OrderByFields
        {
            get
            {
                return "Subjects.SubjectName";
            }
        }

        /// <summary>
        /// Returns a data table containing Subjects table info for the specified artwork.
        /// Note that this data set will contain either 0,1, or N rows of data.
        /// </summary>
        /// <param name="artworkId">The artwork id</param>
        /// <returns>Datatable of Subjects</returns>
        public DataTable GetSubjectsByArtWorkId(int artworkId)
        {
            string newFields = "ArtWorks.ArtWorkID, Subjects.SubjectName ";
            string newSelect = " SELECT " + KeyFieldName + "," + newFields + " FROM ((ArtWorks INNER JOIN  ArtWorkSubjects ON ArtWorks.ArtWorkID = ArtWorkSubjects.ArtWorkID) INNER JOIN  Subjects ON ArtWorkSubjects.SubjectID = Subjects.SubjectId) ";       
            // set up parameterized query statement
            string sql = newSelect + " WHERE ArtWorks.ArtWorkID = @artworkid ";
            // construct array of parameters
            DbParameter[] parameters = new DbParameter[] { DataHelper.MakeParameter("@artworkid", artworkId, DbType.Int32) };
            // return result
            return DataHelper.GetDataTable(sql, parameters);
        }
    
    }
}