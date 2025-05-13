using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    /// <summary>
    /// User BLL class.
    /// </summary>
    public class UserBLL
    {
        #region Public Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="roleType">Type of the role.</param>
        /// <param name="searchField">The search field.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>
        /// Returns all users.
        /// </returns>
        public static List<UserModel> GetAll(RoleType roleType, string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(roleType, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static UserModel GetById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId);
            }
        }

        /// <summary>
        /// Gets the by email.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <returns>Returns user by email.</returns>
        public static UserModel GetByEmail(string email)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetByEmail(email);
            }
        }

        public static UserModel GetEditProfileById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetEditProfileById(userId);
            }
        }
        public static UserModel GetAdminByCompanyId(long companyId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAdminByCompanyId(companyId);
            }
        }

        public static List<UserShortModel> GetUsersForNotification(long? companyId, long? roleId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetUsersForNotification(companyId, roleId);
            }
        }

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static UserModel Save(UserModel user)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.Save(user);
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
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        /// <summary>
        /// Validates the login.
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <returns>Returns user if success otherwise user with less or equal to 0 value.</returns>
        public static UserModel ValidateLogin(string userName, string password)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.ValidateLogin(userName, password);
            }
        }

        public static UserModel GetCountryAdminById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.CountryAdmin.GetHashCode());
            }
        }

        public static List<UserModel> GetAllDoctor(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Doctor, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllActiveDoctor()
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Doctor, "IsActive", "1", "FirstName", "ASC", 0, 0);
            }
        }

        public static List<UserModel> GetAllNurse(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Nurse, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllLaboratorist(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Laboratorist, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllLabTechnicians(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.LabTechnician, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllPharmacist(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Pharmacist, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllAccountant(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Accountant, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllPatients(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Accountant, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllRadiologyDoctor(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.RadiologyDoctor, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<UserModel> GetAllReceptionist(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.Receptionist, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }


        public static List<UserModel> GetAllMRDUses(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetAll(RoleType.MRDUser, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static UserModel GetDoctorById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Doctor.GetHashCode());
            }
        }

        public static UserModel GetNurseById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Nurse.GetHashCode());
            }
        }

        public static UserModel GetLaboratoristById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Laboratorist.GetHashCode());
            }
        }

        public static UserModel GetLabTechnicianById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.LabTechnician.GetHashCode());
            }
        }

        public static UserModel GetPharmacistById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Pharmacist.GetHashCode());
            }
        }

        public static UserModel GetAccountantById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Accountant.GetHashCode());
            }
        }

        public static UserModel GetRadiologyDoctorById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.RadiologyDoctor.GetHashCode());
            }
        }

        public static UserModel GetReceptionistById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.Receptionist.GetHashCode());
            }
        }


        public static UserModel GetMRDUserById(long userId)
        {
            using (UserDAL userDAL = new UserDAL())
            {
                return userDAL.GetById(userId, RoleType.MRDUser.GetHashCode());
            }
        }



        #endregion
    }
}