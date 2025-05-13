using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System.Linq;
using System;
namespace HMS.Class.BLL
{
    /// <summary>
    /// User BLL class.
    /// </summary>
    public class PatientBLL
    {
        #region Public Methods

        public static List<PatientModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<PatientModel> GetAllActive()
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetAll("IsActive", "1", "FirstName", "ASC", 0, 0);
            }
        }

        public static List<PatientModel> GetAllActive(long id)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetAll("PatientId", Convert.ToString(id), "FirstName", "ASC", 0, 0);
            }
        }
        public static PatientModel GetById(long userId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetById(userId);
            }
        }
        public static PatientModel Save(PatientViewModel patientVM)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                var patient = patientDAL.Save(patientVM.PatientDetail);
                if (patient.UserId > 0)
                {
                    SaveFamilyMember(patient.UserId, patientVM.FamilyMembers);
                }

                return patient;
            }
        }
        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        #region Family Member
        public static List<FamilyMemberModel> GetFamilyMembers(long patientId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetFamilyMembers(patientId);
            }
        }
        private static void SaveFamilyMember(long patientId, List<FamilyMemberModel> members)
        {
            DeleteFamilyMember(patientId);

            if (members != null && members.Count > 0)
            {
                using (PatientDAL patientDAL = new PatientDAL())
                {
                    foreach (var member in members)
                    {
                        patientDAL.SaveFamilyMember(patientId, member);
                    }
                }

            }
        }

        private static int DeleteFamilyMember(long patientId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.DeleteFamilyMember(patientId);
            }
        }

        #endregion

        #region Patient Checkup

        public static List<PatientCheckupModel> GetAllCheckupDetail(long patientId)
        {
            var checkupDetail = new List<PatientCheckupModel>();
            var patientMedication = new List<PatientMedicationModel>();
            var patientVitalSigns = new List<PatientVitalSignModel>();
            var patientTestOrders = new List<TestOrderModel>();
            var patientRadiologyTestOrders = new List<RadiologyTestOrderModel>();

            patientMedication = GetMedicationByPatientId(patientId);
            patientVitalSigns = GetAllVitalSignByPatientId(patientId);
            patientTestOrders = TestOrderBLL.GetByPatient(patientId);
            patientRadiologyTestOrders = RadiologyTestOrderBLL.GetByPatient(patientId);

            using (PatientDAL patientDAL = new PatientDAL())
            {
                checkupDetail = patientDAL.GetAllCheckupDetail(patientId);

                if (patientMedication == null)
                {
                    patientMedication = new List<PatientMedicationModel>();
                }

                if (patientVitalSigns == null)
                {
                    patientVitalSigns = new List<PatientVitalSignModel>();
                }

                if (patientTestOrders == null)
                {
                    patientTestOrders = new List<TestOrderModel>();
                }

                if (patientRadiologyTestOrders == null)
                {
                    patientRadiologyTestOrders = new List<RadiologyTestOrderModel>();
                }

                foreach (var c in checkupDetail)
                {
                    c.MedicineList = patientMedication.Where(p => p.PatientCheckupId == c.PatientCheckupId).ToList();
                    c.VitalSignList = patientVitalSigns.Where(p => p.PatientCheckupId == c.PatientCheckupId).ToList();
                    c.AssociatedTestOrder = patientTestOrders.Where(p => p.AssociatedCheckupId == c.PatientCheckupId).FirstOrDefault();
                    c.AssociatedRadiologyTestOrder = patientRadiologyTestOrders.Where(p => p.AssociatedCheckupId == c.PatientCheckupId).FirstOrDefault();
                }
            }

            return checkupDetail;
        }

        public static PatientCheckupModel GetCheckupDetail(long patientCheckupId)
        {
            var checkupDetail = new PatientCheckupModel();
            using (PatientDAL patientDAL = new PatientDAL())
            {
                checkupDetail = patientDAL.GetCheckupDetail(patientCheckupId);
                checkupDetail.MedicineList = patientDAL.GetMedicationByCheckupId(patientCheckupId);
            }

            return checkupDetail;
        }

        public static long SaveCheckupDetail(PatientCheckupViewModel patientCheckupVM)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                long patientCheckupId = patientDAL.SaveCheckupDetail(patientCheckupVM.PatientCheckup);

                if (patientCheckupVM.PatientCheckup.MedicineList != null)
                {
                    SavePatientMedication(patientCheckupId, patientCheckupVM.PatientCheckup.PatientId, patientCheckupVM.PatientCheckup.MedicineList);
                }
                SaveVitalSigns(patientCheckupId, patientCheckupVM.PatientCheckup.PatientId, patientCheckupVM.VitalSigns);

                return patientCheckupId;
            }
        }

        public static long SaveCheckupFromAppointment(PatientCheckupModel patientCheckup)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.SaveCheckupDetail(patientCheckup);
            }
        }

        public static int DeleteCheckupDetail(long patientCheckupId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.DeleteCheckupDetail(patientCheckupId);
            }
        }

        #endregion

        #region Patient Vital Sign
        public static List<PatientVitalSignModel> GetAllVitalSignByPatientId(long patientId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetVitalSignByPatientId(patientId);
            }
        }

        public static List<PatientVitalSignModel> GetAllVitalSignByCheckupId(long checkupId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetVitalSignByCheckupId(checkupId);
            }
        }

        public static void SaveVitalSigns(long patientCheckupId, long patientId, List<PatientVitalSignModel> vitalSigns)
        {
            string vitalSignData = string.Empty;

            foreach (var vitalSign in vitalSigns)
            {
                vitalSignData = string.Concat(vitalSignData, vitalSign.VitalSignId, ",", vitalSign.Reading, "#");
            }

            vitalSignData = vitalSignData.TrimEnd('#');

            using (PatientDAL patientDAL = new PatientDAL())
            {
                patientDAL.SaveVitalSign(patientCheckupId, patientId, vitalSignData);
            }


        }


        #endregion

        #region Patient Vaccine

        public static List<PatientVaccineModel> GetVaccineHistory(long patientId, long companyId)
        {
            var vaccineDetail = new List<PatientVaccineModel>();
            using (PatientDAL patientDAL = new PatientDAL())
            {
                vaccineDetail = patientDAL.GetAllVaccineDetail(patientId, companyId);
                if (vaccineDetail != null)
                {
                    vaccineDetail = vaccineDetail.Where(v => v.PatientVaccineId > 0).OrderBy(o => o.VaccineDate).ToList();
                }
            }

            return vaccineDetail;
        }
        public static List<PatientVaccineModel> GetAllVaccineDetail(long patientId, long companyId)
        {
            var vaccineDetail = new List<PatientVaccineModel>();
            using (PatientDAL patientDAL = new PatientDAL())
            {
                vaccineDetail = patientDAL.GetAllVaccineDetail(patientId, companyId);
            }

            return vaccineDetail;
        }

        public static PatientVaccineModel GetPatientVaccineByPatientVaccineId(long patientVaccineId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetPatientVaccineByPatientVaccineId(patientVaccineId);
            }
        }

        public static void SaveVaccineDetail(PatientVaccineViewModel patientVaccineVM)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                foreach (var patientVaccine in patientVaccineVM.VaccineHistoryList)
                {
                    if (patientVaccine.IsSelected)
                    {
                        patientVaccine.IsRecentSave = true;
                        patientDAL.SaveVaccineDetail(patientVaccine);
                    }
                }
            }
        }

        public static long SaveOutVaccineDetail(PatientOutVaccineViewModel patientVaccineVM)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.SaveVaccineDetail(patientVaccineVM.PatientVaccine);
            }
        }

        public static int DeleteVaccineDetail(long patientVaccineId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.DeleteVaccineDetail(patientVaccineId);
            }
        }

        public static void ResetRecentSaveVaccineDetail(long patientId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                patientDAL.ResetRecentSaveVaccineDetail(patientId);
            }
        }

        #endregion

        #region Patient Medication

        public static List<PatientMedicationModel> GetMedicationByPatientId(long patientId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetMedicationByPatientId(patientId);
            }
        }

        public static List<PatientMedicationModel> GetMedicationByCheckupId(long checkupId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetMedicationByCheckupId(checkupId);
            }
        }

        public static void SavePatientMedication(long patientCheckupId, long patientId, List<PatientMedicationModel> medicineList)
        {
            string prescriptionData = string.Empty;

            foreach (var medicine in medicineList)
            {
                prescriptionData = string.Concat(prescriptionData, medicine.MedicineId, ",", medicine.NoOfDays, ",", medicine.WhenToTake, ",", medicine.IsBeforeMeal, "#");
            }

            prescriptionData = prescriptionData.TrimEnd('#');

            using (PatientDAL patientDAL = new PatientDAL())
            {
                patientDAL.SavePatientMedication(patientCheckupId, patientId, prescriptionData);
            }

        }

        #endregion

        #region Patient Growth Chart

        public static List<PatientGrowthModel> GetGrowthChartByPatientId(long patientId)
        {
            //var list = new List<PatientGrowthModel>();

            //list.Add(new PatientGrowthModel() { PatientGrowthId = 1, Weight = 5.0M, Height = 56.5M, Head = 36.5M, AgeOnEntryDate = 2M, PatientId = 47 });
            //list.Add(new PatientGrowthModel() { PatientGrowthId = 2, Weight = 6.5M, Height = 58.5M, Head = 37.5M, AgeOnEntryDate = 3.5M, PatientId = 47 });
            //list.Add(new PatientGrowthModel() { PatientGrowthId = 3, Weight = 7.0M, Height = 62.5M, Head = 38.6M, AgeOnEntryDate = 4M, PatientId = 47 });
            //list.Add(new PatientGrowthModel() { PatientGrowthId = 4, Weight = 7.9M, Height = 64.5M, Head = 39.5M, AgeOnEntryDate = 4.6M, PatientId = 47 });
            //list.Add(new PatientGrowthModel() { PatientGrowthId = 5, Weight = 10.0M, Height = 84.5M, Head = 49.5M, AgeOnEntryDate = 15.0M, PatientId = 47 });

            //return list;

            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetGrowthByPatientId(patientId);
            }
        }

        public static PatientGrowthModel GetGrowthChartById(long patientGrowthId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.GetGrowthChartById(patientGrowthId);
            }
        }

        public static long SaveGrowthDetail(PatientGrowthModel patientGrowth)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.SaveGrowthDetail(patientGrowth);
            }
        }

        public static int DeleteGrowthDetail(long patientGrowthId)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.DeleteGrowthDetail(patientGrowthId);
            }
        }

        #endregion

        #region Merge Patient File

        public static long MergePatientFile(long primaryPatientId, string secondaryPatientIds)
        {
            using (PatientDAL patientDAL = new PatientDAL())
            {
                return patientDAL.MergePatientFile(primaryPatientId, secondaryPatientIds);
            }


        }

        #endregion
        #endregion
    }
}