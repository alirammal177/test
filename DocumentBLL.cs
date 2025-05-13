using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class DocumentBLL
    {
        #region RadiologyTest

        public static List<DocumentModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (DocumentDAL documentDAL = new DocumentDAL())
            {
                return documentDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<DocumentModel> GetAllActive()
        {
            using (DocumentDAL documentDAL = new DocumentDAL())
            {
                return documentDAL.GetAll("IsActive", "1", "DocumentName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static DocumentModel GetById(long radiologyTestId)
        {
            using (DocumentDAL documentDAL = new DocumentDAL())
            {
                return documentDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static DocumentModel Save(DocumentModel company)
        {
            using (DocumentDAL documentDAL = new DocumentDAL())
            {
                return documentDAL.Save(company);
            }
        }

        /// <summary>
        /// Updates the multiple records.
        /// </summary>
        /// <param name="operationType">Type of the operation.</param>
        /// <param name="multiIds">The multi ids.</param>
        /// <returns>Returns 1 if success else 0.</returns>
        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (DocumentDAL documentDAL = new DocumentDAL())
            {
                return documentDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}