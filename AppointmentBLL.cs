using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using System;

namespace HMS.Class.BLL
{

    public class AppointmentBLL
    {
        #region Appointment

        public static List<AppointmentModel> GetAll(long doctorId)
        {
            using (AppointmentDAL appointmentDAL = new AppointmentDAL())
            {
                return appointmentDAL.GetAll(doctorId);
            }
        }

        public static List<AppointmentModel> GetAll()
        {
            using (AppointmentDAL appointmentDAL = new AppointmentDAL())
            {
                return appointmentDAL.GetAll(0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="appointmentId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static AppointmentModel GetById(long appointmentId)
        {
            using (AppointmentDAL appointmentDAL = new AppointmentDAL())
            {
                return appointmentDAL.GetById(appointmentId);
            }
        }



        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="appointment">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static AppointmentModel Save(AppointmentModel appointment)
        {
            using (AppointmentDAL appointmentDAL = new AppointmentDAL())
            {
                return appointmentDAL.Save(appointment);
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
            using (AppointmentDAL appointmentDAL = new AppointmentDAL())
            {
                return appointmentDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }



        #endregion
    }
}