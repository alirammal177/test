using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class BedBLL
    {
        #region Bed

        public static List<BedModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<BedModel> GetAllActive()
        {
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.GetAll("IsActive", "1", "BedName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="bedId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static BedModel GetById(long bedId)
        {
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.GetById(bedId);
            }
        }


        public static List<BedModel> GetAvailableBeds(long bedCategoryId, string bedId)
        {
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.GetAvailableBeds(bedCategoryId, bedId);
            }
        }
     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static BedModel Save(BedModel company)
        {
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.Save(company);
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
            using (BedDAL bedDAL = new BedDAL())
            {
                return bedDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}