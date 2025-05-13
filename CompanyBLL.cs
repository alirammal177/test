using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    /// <summary>
    /// User BLL class.
    /// </summary>
    public class CompanyBLL
    {
        #region Public Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="roleType">Type of the role.</param>
        /// <param name="searchField">The search field.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all users.
        /// </returns>
        public static List<CompanyModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (CompanyDAL companyDAL = new CompanyDAL())
            {
                return companyDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<CompanyModel> GetAllActive()
        {
            using (CompanyDAL companyDAL = new CompanyDAL())
            {
                return companyDAL.GetAll("IsActive", "1", "CompanyName", "ASC", 0, 0);
            }
        }


        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="companyId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static CompanyModel GetById(long companyId)
        {
            using (CompanyDAL companyDAL = new CompanyDAL())
            {
                return companyDAL.GetById(companyId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static CompanyModel Save(CompanyModel company)
        {
            using (CompanyDAL companyDAL = new CompanyDAL())
            {
                return companyDAL.Save(company);
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
            using (CompanyDAL companyDAL = new CompanyDAL())
            {
                return companyDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}