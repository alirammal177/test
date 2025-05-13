using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class GalleryBLL
    {
    
        public static List<GalleryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (GalleryDAL galleryDAL = new GalleryDAL())
            {
                return galleryDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<GalleryModel> GetAllActive()
        {
            using (GalleryDAL galleryDAL = new GalleryDAL())
            {
                return galleryDAL.GetAll("IsActive", "1", "DisplayOrder", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static GalleryModel GetById(long radiologyTestId)
        {
            using (GalleryDAL galleryDAL = new GalleryDAL())
            {
                return galleryDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static GalleryModel Save(GalleryModel gallery)
        {
            using (GalleryDAL galleryDAL = new GalleryDAL())
            {
                return galleryDAL.Save(gallery);
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
            using (GalleryDAL galleryDAL = new GalleryDAL())
            {
                return galleryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

     
    }
}