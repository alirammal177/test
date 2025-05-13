using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using System;
using System.Linq;

namespace HMS.Class.BLL
{

    public class SubTestBLL
    {
        #region SubTest

        public static List<SubTestModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (SubTestDAL subTestDAL = new SubTestDAL())
            {
                return subTestDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<SubTestModel> GetAllActive()
        {
            using (SubTestDAL subTestDAL = new SubTestDAL())
            {
                return subTestDAL.GetAll("IsActive", "1", "SubTestName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="subTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static SubTestModel GetById(long subTestId)
        {
            using (SubTestDAL subTestDAL = new SubTestDAL())
            {
                return subTestDAL.GetById(subTestId);
            }
        }



        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static SubTestModel Save(SubTestModel company)
        {
            using (SubTestDAL subTestDAL = new SubTestDAL())
            {
                return subTestDAL.Save(company);
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
            using (SubTestDAL subTestDAL = new SubTestDAL())
            {
                return subTestDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }



        #endregion

        #region Delta Check

        public static List<DeltaCheckModel> GetDeltaCheckResult(long patientId, DateTime? dateFrom, DateTime? dateTo)
        {
            List<DeltaCheckModel> deltaCheckResultList = new List<DeltaCheckModel>();
            if (patientId > 0)
            {
                using (SubTestDAL dal = new SubTestDAL())
                {

                    DeltaCheckModel deltaCheckResult;
                    var deltaCheckRawData = dal.GetDeltaCheckResult(patientId, dateFrom, dateTo);

                    var distinctSubTests = deltaCheckRawData.Where(x => x.PatientId == patientId).GroupBy(x => new { x.SubTestId, x.SubTestName }).Select(x => new DeltaCheckModel { SubTestId = x.Key.SubTestId, SubTestName = x.Key.SubTestName }).ToList();


                    foreach (var subTest in distinctSubTests)
                    {
                        deltaCheckResult = new DeltaCheckModel();
                        deltaCheckResult.SubTestId = subTest.SubTestId;
                        deltaCheckResult.SubTestName = subTest.SubTestName;

                        //CVA
                        var allPatientTest = deltaCheckRawData.Where(x => x.SubTestId == subTest.SubTestId);

                        var sumOfSquares = 0.0;
                        var average = (double)allPatientTest.Average(x => x.Result);
                        deltaCheckResult.CVAMean = average;
                        foreach (var test in allPatientTest)
                        {
                            sumOfSquares += Math.Pow((Convert.ToDouble(test.Result) - Convert.ToDouble(average)), 2);
                        }
                        var SDa = Math.Sqrt(sumOfSquares / allPatientTest.Count() * 1.0);
                        var CVa = SDa / deltaCheckResult.CVAMean * 100;
                        deltaCheckResult.CVA = CVa;

                        //CVI
                        var singlePatientTest = allPatientTest.Where(x => x.PatientId == patientId);
                        sumOfSquares = 0.0;
                        average = (double)singlePatientTest.Average(x => x.Result);
                        deltaCheckResult.CVIMean = average;
                        foreach (var test in singlePatientTest)
                        {
                            sumOfSquares += Math.Pow((Convert.ToDouble(test.Result) - Convert.ToDouble(average)), 2);
                        }
                        var SDi = Math.Sqrt(sumOfSquares / singlePatientTest.Count() * 1.0);
                        var CVi = SDi / deltaCheckResult.CVIMean * 100;
                        deltaCheckResult.CVI = CVi;

                        deltaCheckResult.RCV95 = 1.414 * 1.96 * Math.Pow(((CVa * CVa) + (CVi * CVi)), 0.5);
                        deltaCheckResult.RCV99 = 2.58 * 1.96 * Math.Pow(((CVa * CVa) + (CVi * CVi)), 0.5);


                        deltaCheckResultList.Add(deltaCheckResult);
                    }

                }
            }

            return deltaCheckResultList;
        }


        #endregion

    }
}