using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{

    public class MedicationOrderBLL
    {
        #region MedicationOrder

        public static List<MedicationOrderModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                if (searchField == "OrderStatus")
                {
                    if(MedicationOrderStatusType.Requested.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "0";
                    }
                    else if (MedicationOrderStatusType.PartiallyDispensed.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "1";
                    }
                    else if (MedicationOrderStatusType.Dispensed.ToString().ToLower().StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "2";
                    }
                    else
                    {
                        searchValue = "-1";
                    }
                }
                return dal.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<MedicationOrderModel> GetAllActive()
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.GetAll("IsActive", "1", "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="patientTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static MedicationOrderModel GetById(long medicationOrderId)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.GetById(medicationOrderId);
            }
        }

        public static List<MedicationOrderModel> GetByPatient(long patientId)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.GetAll("PatientId", patientId.ToString(), "OrderDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static long Save(MedicationOrderViewModel medicationOrderVM)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                long medicationOrderId = dal.Save(medicationOrderVM.MedicationOrder);

                if (medicationOrderVM.MedicineList != null)
                {
                    SaveMedicationOrderDetail(medicationOrderId, medicationOrderVM.MedicationOrder.PatientId, medicationOrderVM.MedicineList);
                }

                return medicationOrderId;
            }
        }


        public static long SaveFromCheckup(MedicationOrderModel medicationOrder)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.SaveFromCheckup(medicationOrder);
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
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static int UpdateMedicationOrderStatus(int medicationOrderStatusType, long medicationOrderId)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.UpdateMedicationOrderStatus(medicationOrderStatusType, medicationOrderId);
            }
        }

        public static int UpdatePrintStatus(string medicationIds, bool isPrint)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.UpdatePrintStatus(medicationIds, isPrint);
            }
        }



        #endregion

        #region MedicationOrder Detail

        public static List<MedicationOrderDetailModel> GetMedicationOrderDetailByMedicationOrder(long medicationOrderId, long companyId)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.GetMedicationOrderDetailByMedicationOrder(medicationOrderId, companyId);
            }
        }
        public static void SaveMedicationOrderDetail(long medicationOrderId, long patientId, List<MedicationOrderDetailModel> medicineList)
        {
            string prescriptionData = string.Empty;

            foreach (var medicine in medicineList)
            {
                prescriptionData = string.Concat(prescriptionData, medicine.MedicineId, ",", medicine.NoOfDays, ",", medicine.WhenToTake, ",", medicine.IsBeforeMeal, "#");
            }

            prescriptionData = prescriptionData.TrimEnd('#');

            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                dal.SaveMedicationOrderDetail(medicationOrderId,patientId, prescriptionData);
            }

        }

        public static long DispenseMedication(long medicationOrderId, long patientMedicationId, decimal requestedQty, decimal dispensedQty,string refNo)
        {
            using (MedicationOrderDAL dal = new MedicationOrderDAL())
            {
                return dal.DispenseMedication(medicationOrderId, patientMedicationId, requestedQty, dispensedQty, refNo);
            }
        }

        #endregion
    }
}