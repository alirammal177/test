using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class TestGroupBLL
    {
        #region LabTest

        public static List<TestGroupModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (TestGroupDAL testGroupDAL = new TestGroupDAL())
            {
                return testGroupDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<TestGroupModel> GetAllActive()
        {
            using (TestGroupDAL testGroupDAL = new TestGroupDAL())
            {
                return testGroupDAL.GetAll("IsActive", "1", "TestGroupName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="labTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static TestGroupModel GetById(long labTestId)
        {
            using (TestGroupDAL testGroupDAL = new TestGroupDAL())
            {
                return testGroupDAL.GetById(labTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static TestGroupModel Save(TestGroupModel company)
        {
            using (TestGroupDAL testGroupDAL = new TestGroupDAL())
            {
                return testGroupDAL.Save(company);
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
            using (TestGroupDAL testGroupDAL = new TestGroupDAL())
            {
                return testGroupDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}