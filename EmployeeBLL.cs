using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class EmployeeBLL
    {
        #region Medicine

        public static List<EmployeeModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (EmployeeDAL employeeDAL = new EmployeeDAL())
            {
                return employeeDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<EmployeeModel> GetAllActive()
        {
            using (EmployeeDAL employeeDAL = new EmployeeDAL())
            {
                return employeeDAL.GetAll("IsActive", "1", "EmployeeName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="medicineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static EmployeeModel GetById(long employeeId)
        {
            using (EmployeeDAL employeeDAL = new EmployeeDAL())
            {
                return employeeDAL.GetById(employeeId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static EmployeeModel Save(EmployeeModel employee)
        {
            using (EmployeeDAL employeeDAL = new EmployeeDAL())
            {
                return employeeDAL.Save(employee);
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
            using (EmployeeDAL employeeDAL = new EmployeeDAL())
            {
                return employeeDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}