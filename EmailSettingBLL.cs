using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    /// <summary>
    /// Email Setting BLL class.
    /// </summary>
    public class EmailSettingBLL
    {
        #region Public Methods

        public static List<EmailSettingModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (EmailSettingDAL emailSettingDAL = new EmailSettingDAL())
            {
                return emailSettingDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static EmailSettingModel GetById(long emailSettingId)
        {
            using (EmailSettingDAL emailSettingDAL = new EmailSettingDAL())
            {
                return emailSettingDAL.GetById(emailSettingId, "");
            }
        }

        public static EmailSettingModel GetByEmailType(string emailType)
        {
            using (EmailSettingDAL emailSettingDAL = new EmailSettingDAL())
            {
                return emailSettingDAL.GetById(0, emailType);
            }
        }

        public static EmailSettingModel Save(EmailSettingModel emailSetting)
        {
            using (EmailSettingDAL emailSettingDAL = new EmailSettingDAL())
            {
                return emailSettingDAL.Save(emailSetting);
            }
        }

        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (EmailSettingDAL emailSettingDAL = new EmailSettingDAL())
            {
                return emailSettingDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        #endregion
    }
}