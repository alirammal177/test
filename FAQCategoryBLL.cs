using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class FAQCategoryBLL
    {
        #region FAQ

        public static List<FAQCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (FAQCategoryDAL faqCategoryDAL = new FAQCategoryDAL())
            {
                return faqCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<FAQCategoryModel> GetAllActive()
        {
            using (FAQCategoryDAL faqCategoryDAL = new FAQCategoryDAL())
            {
                return faqCategoryDAL.GetAll("IsActive", "1", "FAQCategoryName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="faqId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static FAQCategoryModel GetById(long faqId)
        {
            using (FAQCategoryDAL faqCategoryDAL = new FAQCategoryDAL())
            {
                return faqCategoryDAL.GetById(faqId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static FAQCategoryModel Save(FAQCategoryModel company)
        {
            using (FAQCategoryDAL faqCategoryDAL = new FAQCategoryDAL())
            {
                return faqCategoryDAL.Save(company);
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
            using (FAQCategoryDAL faqCategoryDAL = new FAQCategoryDAL())
            {
                return faqCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}