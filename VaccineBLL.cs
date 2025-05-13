using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    
    public class VaccineBLL
    {
        #region Vaccine

        public static List<VaccineModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (VaccineDAL vaccineDAL = new VaccineDAL())
            {
                return vaccineDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<VaccineModel> GetAllActive()
        {
            using (VaccineDAL vaccineDAL = new VaccineDAL())
            {
                return vaccineDAL.GetAll("IsActive", "1", "AgeInMonth", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="vaccineId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static VaccineModel GetById(long vaccineId)
        {
            using (VaccineDAL vaccineDAL = new VaccineDAL())
            {
                return vaccineDAL.GetById(vaccineId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static VaccineModel Save(VaccineModel company)
        {
            using (VaccineDAL vaccineDAL = new VaccineDAL())
            {
                return vaccineDAL.Save(company);
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
            using (VaccineDAL vaccineDAL = new VaccineDAL())
            {
                return vaccineDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

        #endregion
    }
}