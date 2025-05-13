using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class FAQBLL
    {
        #region FAQ

        public static List<FAQModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (FAQDAL faqDAL = new FAQDAL())
            {
                return faqDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<FAQModel> GetAllActive()
        {
            using (FAQDAL faqDAL = new FAQDAL())
            {
                return faqDAL.GetAll("IsActive", "1", "DisplayOrder", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="faqId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static FAQModel GetById(long faqId)
        {
            using (FAQDAL faqDAL = new FAQDAL())
            {
                return faqDAL.GetById(faqId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static FAQModel Save(FAQModel company)
        {
            using (FAQDAL faqDAL = new FAQDAL())
            {
                return faqDAL.Save(company);
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
            using (FAQDAL faqDAL = new FAQDAL())
            {
                return faqDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}