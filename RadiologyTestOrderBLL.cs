using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{

    public class RadiologyTestOrderBLL
    {
        #region RadiologyTestOrder

        public static List<RadiologyTestOrderModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                if (searchField == "OrderStatus")
                {
                    if(RadiologyTestOrderStatusType.Pending.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "0";
                    }
                    else if (RadiologyTestOrderStatusType.InProcess.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "1";
                    }
                    else if (RadiologyTestOrderStatusType.Completed.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "2";
                    }
                    else if (RadiologyTestOrderStatusType.Approved.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "3";
                    }
                    else if (RadiologyTestOrderStatusType.Reported.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "4";
                    }
                    else
                    {
                        searchValue = "-1";
                    }
                }
                return patientRadiologyTestDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<RadiologyTestOrderModel> GetAllActive()
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.GetAll("IsActive", "1", "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="patientRadiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static RadiologyTestOrderModel GetById(long patientRadiologyTestId)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.GetById(patientRadiologyTestId);
            }
        }

        public static List<RadiologyTestOrderModel> GetByPatient(long patientId)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.GetAll("PatientId", patientId.ToString(), "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static long Save(RadiologyTestOrderModel testOrder)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.Save(testOrder);
            }
        }

        public static long SaveFromCheckup(RadiologyTestOrderModel testOrder)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.SaveFromCheckup(testOrder);
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
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static int UpdateRadiologyTestOrderStatus(int testOrderStatusType, long testOrderId)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.UpdateRadiologyTestOrderStatus(testOrderStatusType, testOrderId);
            }
        }



        #endregion

        #region RadiologyTestOrder Detail

        public static List<RadiologyTestOrderDetailModel> GetRadiologyTestOrderDetailByRadiologyTestOrder(long testOrderId, long companyId)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.GetRadiologyTestOrderDetailByRadiologyTestOrder(testOrderId, companyId);
            }
        }

        public static void SaveRadiologyTestOrderDetail(long patientRadiologyTestId, List<RadiologyTestOrderDetailModel> testOrderDetailList)
        {
            string testData = string.Empty;

            foreach (var test in testOrderDetailList)
            {
                testData = string.Concat(testData, test.RadiologyTestId, ",", test.Result, ",", test.Amount, "#");
            }

            testData = testData.TrimEnd('#');

            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                patientRadiologyTestDAL.SaveRadiologyTestOrderDetail(patientRadiologyTestId, testData);
            }


        }

        public static long SaveRadiologyTestResult(RadiologyTestOrderDetailModel testOrderResult)
        {
            using (RadiologyTestOrderDAL patientRadiologyTestDAL = new RadiologyTestOrderDAL())
            {
                return patientRadiologyTestDAL.SaveRadiologyTestResult(testOrderResult);
            }
        }

        #endregion
    }
}