using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class RadiologyTestBLL
    {
        #region RadiologyTest

        public static List<RadiologyTestModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<RadiologyTestModel> GetAllActive()
        {
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.GetAll("IsActive", "1", "RadiologyTestName", "ASC", 0, 0);
            }
        }

        public static List<RadiologyTestModel> GetAllActive(string ids)
        {
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.GetAll("RadiologyTestId", ids, "RadiologyTestName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static RadiologyTestModel GetById(long radiologyTestId)
        {
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static RadiologyTestModel Save(RadiologyTestModel company)
        {
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.Save(company);
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
            using (RadiologyTestDAL radiologyTestDAL = new RadiologyTestDAL())
            {
                return radiologyTestDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}