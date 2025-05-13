using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class ExpenseBLL
    {
        #region Expense

        public static List<ExpenseModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ExpenseDAL expenseDAL = new ExpenseDAL())
            {
                return expenseDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<ExpenseModel> GetAllActive()
        {
            using (ExpenseDAL expenseDAL = new ExpenseDAL())
            {
                return expenseDAL.GetAll("IsActive", "1", "ExpenseDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="expenseId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static ExpenseModel GetById(long expenseId)
        {
            using (ExpenseDAL expenseDAL = new ExpenseDAL())
            {
                return expenseDAL.GetById(expenseId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static ExpenseModel Save(ExpenseModel company)
        {
            using (ExpenseDAL expenseDAL = new ExpenseDAL())
            {
                return expenseDAL.Save(company);
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
            using (ExpenseDAL expenseDAL = new ExpenseDAL())
            {
                return expenseDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}