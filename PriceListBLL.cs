using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class PriceListBLL
    {
        #region RadiologyTest

        public static List<PriceListModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<PriceListModel> GetAllActive()
        {
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.GetAll("IsActive", "1", "PriceListName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="priceListIdId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static PriceListModel GetById(long priceListIdId)
        {
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.GetById(priceListIdId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static PriceListModel Save(PriceListModel company)
        {
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.Save(company);
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
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static long  Copy(PriceListCopyModel priceList)
        {
            using (PriceListDAL priceListDAL = new PriceListDAL())
            {
                return priceListDAL.Copy(priceList);
            }
        }

        #endregion
    }
}