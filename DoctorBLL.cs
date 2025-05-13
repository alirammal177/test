using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System.Linq;
namespace HMS.Class.BLL
{
    /// <summary>
    /// User BLL class.
    /// </summary>
    public class DoctorBLL
    {
        #region Public Methods

        public static List<DoctorModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
                return doctorDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<DoctorModel> GetAllActive()
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
                return doctorDAL.GetAll("IsActive", "1", "FirstName", "ASC", 0, 0);
            }
        }
        public static DoctorModel GetById(long userId)
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
                return doctorDAL.GetById(userId);
            }
        }
        public static DoctorModel Save(DoctorViewModel doctorVM)
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
               return doctorDAL.Save(doctorVM.DoctorDetail);
            }
        }
        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
                return doctorDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static int CheckDelinquentFile(long userId)
        {
            using (DoctorDAL doctorDAL = new DoctorDAL())
            {
                return doctorDAL.CheckDelinquentFile(userId);
            }
        }

        #endregion
    }
}