using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class MedicineBLL
    {
        #region Medicine

        public static List<MedicineModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<MedicineModel> GetAllActive()
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetAll("IsActive", "1", "MedicineName", "ASC", 0, 0);
            }
        }

        public static List<MedicineModel> GetAllActive(string ids)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetAll("MedicineId", ids, "MedicineName", "ASC", 0, 0);
            }
        }


        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="medicineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static MedicineModel GetById(long medicineId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetById(medicineId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static MedicineModel Save(MedicineModel company)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.Save(company);
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
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion

        #region Medicine Transactions

        public static List<MedicineInTransactionModel> GetInTransactions(long medicineId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetInTransactions(medicineId);
            }
        }

        public static List<MedicineOutTransactionModel> GetOutTransactions(long medicineId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetOutTransactions(medicineId);
            }
        }

        public static List<MedicineDispenseTransactionModel> GetDispenseTransactionsByMedicineId(long medicineId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetDispenseTransactions(medicineId,0);
            }
        }

        public static List<MedicineDispenseTransactionModel> GetDispenseTransactionsByOrderId(long medicationOrderId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.GetDispenseTransactions(0, medicationOrderId);
            }
        }

        public static long AddInTransaction(MedicineInTransactionModel transaction)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.AddInTransaction(transaction);
            }
        }
        public static long AddOutTransaction(MedicineOutTransactionModel transaction)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.AddOutTransaction(transaction);
            }
        }

        public static void AddDispenseTransaction(List<MedicineDispenseTransactionModel> transactions)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                foreach (var transaction in transactions)
                {
                    medicineDAL.AddDispenseTransaction(transaction);
                }
            }
        }

        public static int DeleteInTransaction(long transactionId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.DeleteInTransaction(transactionId);
            }
        }
        public static int DeleteOutTransaction(long transactionId)
        {
            using (MedicineDAL medicineDAL = new MedicineDAL())
            {
                return medicineDAL.DeleteOutTransaction(transactionId);
            }
        }

        #endregion
    }
}