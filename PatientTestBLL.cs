using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{

    public class PatientTestBLL
    {
        #region PatientTest

        public static List<PatientTestModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<PatientTestModel> GetAllActive()
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.GetAll("IsActive", "1", "PatientTestDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="patientTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static PatientTestModel GetById(long patientTestId)
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.GetById(patientTestId);
            }
        }



        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static long Save(PatientTestViewModel patientTestVM)
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {

                long patientTestId = patientTestDAL.Save(patientTestVM.PatientTest);

                SavePatientTestDetail(patientTestId, patientTestVM.PatientTestDetails);


                return patientTestId;
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
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static int UpdatePatientTestStatus(PatientTestStatusType patientTestStatusType, string multiIds)
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.UpdatePatientTestStatus(patientTestStatusType, multiIds);
            }
        }



        #endregion

        #region PatientTest Detail

        public static List<PatientTestDetailModel> GetPatientTestDetailByPatientTest(long patientTestId)
        {
            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                return patientTestDAL.GetPatientTestDetailByPatientTest(patientTestId);
            }
        }

        public static void SavePatientTestDetail(long patientTestId, List<PatientTestDetailModel> patientTestDetailList)
        {
            string testData = string.Empty;

            foreach (var test in patientTestDetailList)
            {
                testData = string.Concat(testData, test.LabTestId, ",", test.Result, ",", test.Remarks, "#");
            }

            testData = testData.TrimEnd('#');

            using (PatientTestDAL patientTestDAL = new PatientTestDAL())
            {
                patientTestDAL.SavePatientTestDetail(patientTestId, testData);
            }


        }

        #endregion
    }
}