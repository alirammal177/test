using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class BedCategoryBLL
    {
        #region Bed

        public static List<BedCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (BedCategoryDAL bedCategoryDAL = new BedCategoryDAL())
            {
                return bedCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<BedCategoryModel> GetAllActive()
        {
            using (BedCategoryDAL bedCategoryDAL = new BedCategoryDAL())
            {
                return bedCategoryDAL.GetAll("IsActive", "1", "BedCategory", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="bedId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static BedCategoryModel GetById(long bedId)
        {
            using (BedCategoryDAL bedCategoryDAL = new BedCategoryDAL())
            {
                return bedCategoryDAL.GetById(bedId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static BedCategoryModel Save(BedCategoryModel company)
        {
            using (BedCategoryDAL bedCategoryDAL = new BedCategoryDAL())
            {
                return bedCategoryDAL.Save(company);
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
            using (BedCategoryDAL bedCategoryDAL = new BedCategoryDAL())
            {
                return bedCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}