using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System.Linq;
using System;
namespace HMS.Class.BLL
{

    public class GeneralReportBLL
    {
        #region Public Methods

        #region Patient Detail Report

        public static List<PatientModel> GetPatientDetail(long cid, long patientId, long countryId, long cityId, long districtId, long nationalityId, string gender, DateTime? dobFrom, DateTime? dobTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetPatientDetail(cid, patientId, countryId, cityId, districtId, nationalityId, gender, dobFrom, dobTo);
            }
        }

        #endregion

        #region Patient Visit Report

        public static List<PatientCheckupModel> GetCheckupDetail(long cid, long patientId, long doctorId, long consultantTypeId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetCheckupDetail(cid, patientId, doctorId, consultantTypeId, dateFrom, dateTo);
            }
        }

        #endregion


        #region Patient Vacccine Report

        public static List<PatientVaccineModel> GetVaccineDetail(long cid, long vaccineId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetVaccineDetail(cid, vaccineId,dateFrom, dateTo);
            }
        }

        #endregion

        #region Appointment Detail Report

        public static List<AppointmentModel> GetAppointmentDetail(long cid, long patientId, long doctorId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetAppointmentDetail(cid, patientId, doctorId, dateFrom, dateTo);
            }
        }

        #endregion

        #region Diagnosis Wise Patient Report

        public static List<PatientModel> GetDiagnosisWisePatientDetail(long cid, long diagnosisId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetDiagnosisWisePatientDetail(cid, diagnosisId, dateFrom, dateTo);
            }
        }

        #endregion

        #region Consultant Type Wise Patient Report

        public static List<PatientModel> GetConsultantTypeWisePatientDetail(long cid, long consultantTypeId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetConsultantTypeWisePatientDetail(cid, consultantTypeId, dateFrom, dateTo);
            }
        }

        #endregion

        #region Service Type Wise Patient Report

        public static List<PatientModel> GetServiceTypeWisePatientDetail(long cid, long serviceTypeId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetServiceTypeWisePatientDetail(cid, serviceTypeId, dateFrom, dateTo);
            }
        }

        #endregion

        #region Doctor Income Report

        public static List<InvoiceModel> GetDoctorIncomeDetail(long cid, long doctorId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetDoctorIncomeDetail(cid, doctorId, dateFrom, dateTo);
            }
        }


        #endregion

        #region Patient Payment Report

        public static List<PatientModel> GetPatientPaymentDetail(long cid, long patientId, DateTime? dateFrom, DateTime? dateTo)
        {
            using (GeneralReportDAL dal = new GeneralReportDAL())
            {
                return dal.GetPatientPaymentDetail(cid, patientId, dateFrom, dateTo);
            }
        }


        #endregion

        #endregion
    }
}