using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class PaymentCategoryBLL
    {
        #region Payment

        public static List<PaymentCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<PaymentCategoryModel> GetAllActive()
        {
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.GetAll("IsActive", "1", "PaymentCategory", "ASC", 0, 0);
            }
        }

        public static List<PaymentCategoryModel> GetAllActive(string ids)
        {
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.GetAll("PaymentCategoryId", ids, "PaymentCategory", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="medicineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static PaymentCategoryModel GetById(long medicineId)
        {
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.GetById(medicineId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static PaymentCategoryModel Save(PaymentCategoryModel company)
        {
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.Save(company);
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
            using (PaymentCategoryDAL medicineCategoryDAL = new PaymentCategoryDAL())
            {
                return medicineCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}