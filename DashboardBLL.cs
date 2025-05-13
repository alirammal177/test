using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System;

namespace HMS.Class.BLL
{
    public class DashboardBLL
    {
        #region Public Methods

        #region General
        public static DashboardViewModel GetDashboardDetails()
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetDashboardDetails();
            }
        }

        #endregion

        #region Doctor
        public static DashboardViewModel GetDoctorDashboardDetails(DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetDoctorDashboard(dateFrom, dateTo);
            }
        }
        public static DoctorDashboardChartViewModel GetDoctorDashboardChartData(DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetDoctorDashboardChartData(dateFrom, dateTo);
            }
        }

        public static PieChartDataModel GetDoctorDashboardDiagnosisDetails(long diagnosisId)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetDoctorDashboardDiagnosisDetails("Diagnosis", diagnosisId);
            }
        }

        public static PieChartDataModel GetDoctorDashboardServiceDetails(long serviceId)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetDoctorDashboardDiagnosisDetails("Services", serviceId);
            }
        }
        #endregion

        #region SuperAdmin
        public static DashboardViewModel GetSADashboardDetails(long? companyId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetSuperAdminDashboard(companyId, dateFrom, dateTo);
            }
        }

        public static DashboardChartViewModel GetSuperAdminDashboardChartData(long? companyId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetSuperAdminDashboardChartData(companyId, dateFrom, dateTo);
            }
        }

        #endregion

        #region Admin
        public static DashboardViewModel GetAdminDashboardDetails(DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetAdminDashboard(dateFrom, dateTo);
            }
        }

        public static AdminDashboardChartViewModel GetAdminDashboardChartData(DateTime? dateFrom, DateTime? dateTo)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetAdminDashboardChartData(dateFrom, dateTo);
            }
        }

        public static PieChartDataModel GetAdminDashboardDiagnosisDetails(long diagnosisId)
        {
            using (DashboardDAL dal = new DashboardDAL())
            {
                return dal.GetAdminDashboardDiagnosisDetails(diagnosisId);
            }
        }

        #endregion

        #endregion
    }
}