using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class BedAllotmentBLL
    {
        #region BedAllotment

        public static List<BedAllotmentModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (BedAllotmentDAL bedAllotmentDAL = new BedAllotmentDAL())
            {
                return bedAllotmentDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="bedAllotmentId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static BedAllotmentModel GetById(long bedAllotmentId)
        {
            using (BedAllotmentDAL bedAllotmentDAL = new BedAllotmentDAL())
            {
                return bedAllotmentDAL.GetById(bedAllotmentId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="bedAllotment">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static BedAllotmentModel Save(BedAllotmentModel bedAllotment)
        {
            using (BedAllotmentDAL bedAllotmentDAL = new BedAllotmentDAL())
            {
                return bedAllotmentDAL.Save(bedAllotment);
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
            using (BedAllotmentDAL bedAllotmentDAL = new BedAllotmentDAL())
            {
                return bedAllotmentDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}