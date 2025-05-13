using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class TestBLL
    {
        #region LabTest

        public static List<TestModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<TestModel> GetAllActive()
        {
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.GetAll("IsActive", "1", "TestName", "ASC", 0, 0);
            }
        }

        public static List<TestModel> GetAllActive(string id)
        {
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.GetAll("TestId", id, "TestName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="labTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static TestModel GetById(long labTestId)
        {
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.GetById(labTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static TestModel Save(TestModel company)
        {
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.Save(company);
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
            using (TestDAL testDAL = new TestDAL())
            {
                return testDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}