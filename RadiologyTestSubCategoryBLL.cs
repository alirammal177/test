using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class RadiologyTestSubCategoryBLL
    {
        #region RadiologyTest

        public static List<RadiologyTestSubCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (RadiologyTestSubCategoryDAL radiologyTestSubCategoryDAL = new RadiologyTestSubCategoryDAL())
            {
                return radiologyTestSubCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<RadiologyTestSubCategoryModel> GetAllActive()
        {
            using (RadiologyTestSubCategoryDAL radiologyTestSubCategoryDAL = new RadiologyTestSubCategoryDAL())
            {
                return radiologyTestSubCategoryDAL.GetAll("IsActive", "1", "RadiologyTestSubCategoryName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static RadiologyTestSubCategoryModel GetById(long radiologyTestId)
        {
            using (RadiologyTestSubCategoryDAL radiologyTestSubCategoryDAL = new RadiologyTestSubCategoryDAL())
            {
                return radiologyTestSubCategoryDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static RadiologyTestSubCategoryModel Save(RadiologyTestSubCategoryModel company)
        {
            using (RadiologyTestSubCategoryDAL radiologyTestSubCategoryDAL = new RadiologyTestSubCategoryDAL())
            {
                return radiologyTestSubCategoryDAL.Save(company);
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
            using (RadiologyTestSubCategoryDAL radiologyTestSubCategoryDAL = new RadiologyTestSubCategoryDAL())
            {
                return radiologyTestSubCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}