using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{

    public class NotificationBLL
    {
        #region Notification

        public static List<NotificationModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                if (searchField == "IsRead")
                {
                    if ("unread".StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "0";
                    }
                    else if ("read".StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "1";
                    }
                    else
                    {
                        searchValue = "-1";
                    }
                }
                return notificationDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static NotificationModel GetById(long notificationId)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                return notificationDAL.GetById(notificationId);
            }
        }

        public static long Save(NotificationModel notification)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                return notificationDAL.Save(notification);
            }
        }

        public static int DeleteMasterNotification(MultiOperationType operationType, string multiIds)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                return notificationDAL.UpdateMultipleRecords(operationType, multiIds, 0);
            }
        }

        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                long userId = SqlHelper.ParseNativeLong(CommonLogic.GetSessionValue(StringConstants.UserId));
                return notificationDAL.UpdateMultipleRecords(operationType, multiIds, userId);
            }
        }

        #endregion

        #region Expiration Notification

        public static List<ExpirationNotificationModel> GetExpirationNotification()
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                return notificationDAL.GetExpirationNotification();
            }
        }
        public static void UpdateExecutionSchedule()
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                notificationDAL.UpdateExecutionSchedule();
            }
        }

        #endregion

        #region Received Notification

        public static List<NotificationModel> GetReceivedNotification(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (NotificationDAL notificationDAL = new NotificationDAL())
            {
                if (searchField == "IsRead")
                {
                    if ("unread".StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "0";
                    }
                    else if ("read".StartsWith(searchValue.ToLower()))
                    {
                        searchValue = "1";
                    }
                    else
                    {
                        searchValue = "-1";
                    }
                }
                return notificationDAL.GetReceivedNotification(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        #endregion

    }
}