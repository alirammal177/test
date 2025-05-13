using HMS.Class.DAL;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{
    /// <summary>
    /// Setting BLL class.
    /// </summary>
    public class SettingBLL
    {
        #region Public Methods

        /// <summary>
        /// Gets the setting.
        /// </summary>
        /// <returns>Returns setting.</returns>
        public static SettingModel GetSetting()
        {
            using (SettingDAL settingDAL = new SettingDAL())
            {
                return settingDAL.GetSetting();
            }
        }

        /// <summary>
        /// Saves the setting.
        /// </summary>
        /// <param name="setting">The setting.</param>
        /// <returns>Returns setting id if success else error code.</returns>
        public static long SaveSetting(SettingModel setting)
        {
            using (SettingDAL settingDAL = new SettingDAL())
            {
                return settingDAL.SaveSetting(setting);
            }
        }

        /// <summary>
        /// Gets the dashboard details.
        /// </summary>
        /// <param name="userId">The user id.</param>
        /// <returns>Returns dashboard details.</returns>
        public static DashboardViewModel GetDashboardDetails()
        {
            using (SettingDAL settingDAL = new SettingDAL())
            {
                return settingDAL.GetDashboardDetails();
            }
        }

        #endregion
    }
}