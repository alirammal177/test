using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class RadiologyTestCategoryBLL
    {
        #region RadiologyTest

        public static List<RadiologyTestCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (RadiologyTestCategoryDAL radiologyTestCategoryDAL = new RadiologyTestCategoryDAL())
            {
                return radiologyTestCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<RadiologyTestCategoryModel> GetAllActive()
        {
            using (RadiologyTestCategoryDAL radiologyTestCategoryDAL = new RadiologyTestCategoryDAL())
            {
                return radiologyTestCategoryDAL.GetAll("IsActive", "1", "RadiologyTestCategoryName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static RadiologyTestCategoryModel GetById(long radiologyTestId)
        {
            using (RadiologyTestCategoryDAL radiologyTestCategoryDAL = new RadiologyTestCategoryDAL())
            {
                return radiologyTestCategoryDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static RadiologyTestCategoryModel Save(RadiologyTestCategoryModel company)
        {
            using (RadiologyTestCategoryDAL radiologyTestCategoryDAL = new RadiologyTestCategoryDAL())
            {
                return radiologyTestCategoryDAL.Save(company);
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
            using (RadiologyTestCategoryDAL radiologyTestCategoryDAL = new RadiologyTestCategoryDAL())
            {
                return radiologyTestCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}