using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class SupplierBLL
    {
        #region Medicine

        public static List<SupplierModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (SupplierDAL supplierDAL = new SupplierDAL())
            {
                return supplierDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<SupplierModel> GetAllActive()
        {
            using (SupplierDAL supplierDAL = new SupplierDAL())
            {
                return supplierDAL.GetAll("IsActive", "1", "SupplierName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="medicineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static SupplierModel GetById(long supplierId)
        {
            using (SupplierDAL supplierDAL = new SupplierDAL())
            {
                return supplierDAL.GetById(supplierId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static SupplierModel Save(SupplierModel supplier)
        {
            using (SupplierDAL supplierDAL = new SupplierDAL())
            {
                return supplierDAL.Save(supplier);
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
            using (SupplierDAL supplierDAL = new SupplierDAL())
            {
                return supplierDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}