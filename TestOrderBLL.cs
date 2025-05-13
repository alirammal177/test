using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{

    public class TestOrderBLL
    {
        #region TestOrder

        public static List<TestOrderModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                if (searchField == "ReportStatus")
                {
                    if(TestOrderStatusType.Pending.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "0";
                    }
                    else if (TestOrderStatusType.InProcess.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "1";
                    }
                    else if (TestOrderStatusType.Completed.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "2";
                    }
                    else if (TestOrderStatusType.Approved.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "3";
                    }
                    else if (TestOrderStatusType.Reported.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "4";
                    }
                    else
                    {
                        searchValue = "-1";
                    }
                }
                return patientTestDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<TestOrderModel> GetAllActive()
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.GetAll("IsActive", "1", "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="patientTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static TestOrderModel GetById(long patientTestId)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.GetById(patientTestId);
            }
        }

        public static List<TestOrderModel> GetByPatient(long patientId)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.GetAll("PatientId", patientId.ToString(), "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static long Save(TestOrderModel testOrder)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.Save(testOrder);
            }
        }

        public static long SaveFromCheckup(TestOrderModel testOrder)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.SaveFromCheckup(testOrder);
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
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static int UpdateTestOrderStatus(TestOrderStatusType testOrderStatusType, long testOrderId)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.UpdateTestOrderStatus(testOrderStatusType, testOrderId);
            }
        }



        #endregion

        #region TestOrder Detail

        public static List<TestOrderDetailModel> GetTestOrderDetailByTestOrder(long testOrderId, long companyId)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.GetTestOrderDetailByTestOrder(testOrderId, companyId);
            }
        }

        public static void SaveTestOrderDetail(long patientTestId, List<TestOrderDetailModel> testOrderDetailList)
        {
            string testData = string.Empty;

            foreach (var test in testOrderDetailList)
            {
                testData = string.Concat(testData, test.SubTestId, ",", test.Result, ",", test.Remarks, "#");
            }

            testData = testData.TrimEnd('#');

            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                patientTestDAL.SaveTestOrderDetail(patientTestId, testData);
            }


        }

        public static List<TestOrderDetailModel> GetTestByTestOrder(long testOrderId, long companyId)
        {
            using (TestOrderDAL patientTestDAL = new TestOrderDAL())
            {
                return patientTestDAL.GetTestByTestOrder(testOrderId, companyId);
            }
        }

        #endregion
    }
}