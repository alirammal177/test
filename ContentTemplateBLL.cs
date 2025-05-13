using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
    public class ContentTemplateBLL
    {
        #region Public Methods

        /// <summary>
        /// Gets all.
        /// </summary>
        /// <param name="searchField">The search field.</param>
        /// <param name="searchValue">The search value.</param>
        /// <param name="sortField">The sort field.</param>
        /// <param name="sortOrder">The sort order.</param>
        /// <param name="pageNo">The page no.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <returns>Return all email templates.</returns>
        public static List<ContentTemplateModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ContentTemplateDAL contentTemplateDAL = new ContentTemplateDAL())
            {
                return contentTemplateDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="contentTemplateId">The email template id.</param>
        /// <returns>Returns email template by id.</returns>
        public static ContentTemplateModel GetById(long contentTemplateId)
        {
            using (ContentTemplateDAL contentTemplateDAL = new ContentTemplateDAL())
            {
                return contentTemplateDAL.GetById(contentTemplateId);
            }
        }

        /// <summary>
        /// Gets the by code.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>Returns email template by code.</returns>
        public static ContentTemplateModel GetByCode(string code)
        {
            using (ContentTemplateDAL contentTemplateDAL = new ContentTemplateDAL())
            {
                return contentTemplateDAL.GetByCode(code);
            }
        }

        /// <summary>
        /// Saves the specified email template.
        /// </summary>
        /// <param name="contentTemplate">The email template.</param>
        /// <returns>Returns email template id if success else error code (Error Code : -1 - template name already exists).</returns>
        public static ContentTemplateModel Save(ContentTemplateModel contentTemplate)
        {
            using (ContentTemplateDAL contentTemplateDAL = new ContentTemplateDAL())
            {
                return contentTemplateDAL.Save(contentTemplate);
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
            using (ContentTemplateDAL contentTemplateDAL = new ContentTemplateDAL())
            {
                return contentTemplateDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        #endregion
    }
}