using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    public class ReportBLL
    {
        #region LabTest

        public static List<ReportModel> GetAllBirthReport(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ReportDAL reportDAL = new ReportDAL())
            {
                return reportDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize, 1);
            }
        }

        public static List<ReportModel> GetAllDeathReport(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ReportDAL reportDAL = new ReportDAL())
            {
                return reportDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize, 2);
            }
        }

      
        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="reportId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static ReportModel GetById(long reportId)
        {
            using (ReportDAL reportDAL = new ReportDAL())
            {
                return reportDAL.GetById(reportId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="report">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static ReportModel Save(ReportModel report)
        {
            using (ReportDAL reportDAL = new ReportDAL())
            {
                return reportDAL.Save(report);
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
            using (ReportDAL reportDAL = new ReportDAL())
            {
                return reportDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}