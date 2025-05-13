﻿using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Models;

namespace HMS.Class.BLL
{
    /// <summary>
    /// Site menu BLL class.
    /// </summary>
    public class SiteMenuBLL
    {
        #region Public Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="roleId">The role id.</param>
        /// <param name="isExcludeInactive">if set to <c>true</c> [is exclude inactive].</param>
        /// <returns>Returns all site menus.</returns>
        public static List<SiteMenuModel> GetAll(int roleId, bool isExcludeInactive)
        {
            using (SiteMenuDAL siteMenuDAL = new SiteMenuDAL())
            {
                return siteMenuDAL.GetAll(roleId, isExcludeInactive);
            }
        }

        #endregion
    }
}