using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class PriceListItemBLL
    {
        #region PriceListItem

        public static List<PriceListItemModel> GetAll(long priceListId, string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.GetAll(priceListId, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        //public static List<PriceListItemModel> GetAllActive()
        //{
        //    using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
        //    {
        //        return priceListItemDAL.GetAll("IsActive", "1", "PriceListItemName", "ASC", 0, 0);
        //    }
        //}

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="priceListItemId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static PriceListItemModel GetById(long priceListItemId)
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.GetById(priceListItemId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static PriceListItemModel Save(PriceListItemModel company)
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.Save(company);
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
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }


        public static List<SystemItemModel> GetSystemItems()
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.GetSystemItems();
            }
        }

        public static List<SystemItemModel> GetAllSystemItems(string itemType,string searchField, string searchValue, int pageNo, int pageSize)
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.GetAllSystemItems(itemType, searchField, searchValue, pageNo,pageSize); 
            }
        }

        public static List<SystemItemModel> GetAllSystemItems(string itemType, string id)
        {
            using (PriceListItemDAL priceListItemDAL = new PriceListItemDAL())
            {
                return priceListItemDAL.GetAllSystemItems(itemType, "ItemId", id, 0, 0);
            }
        }
    

        #endregion
    }
}