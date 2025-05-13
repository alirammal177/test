using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class ExpenseCategoryBLL
    {
        #region Expense

        public static List<ExpenseCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ExpenseCategoryDAL medicineCategoryDAL = new ExpenseCategoryDAL())
            {
                return medicineCategoryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<ExpenseCategoryModel> GetAllActive()
        {
            using (ExpenseCategoryDAL medicineCategoryDAL = new ExpenseCategoryDAL())
            {
                return medicineCategoryDAL.GetAll("IsActive", "1", "ExpenseCategory", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="medicineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static ExpenseCategoryModel GetById(long medicineId)
        {
            using (ExpenseCategoryDAL medicineCategoryDAL = new ExpenseCategoryDAL())
            {
                return medicineCategoryDAL.GetById(medicineId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static ExpenseCategoryModel Save(ExpenseCategoryModel company)
        {
            using (ExpenseCategoryDAL medicineCategoryDAL = new ExpenseCategoryDAL())
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
            using (ExpenseCategoryDAL medicineCategoryDAL = new ExpenseCategoryDAL())
            {
                return medicineCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}