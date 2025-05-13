using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{

    public class FeatureBLL
    {
    
        public static List<FeatureModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (FeatureDAL featureDAL = new FeatureDAL())
            {
                return featureDAL.GetAll( searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<FeatureModel> GetAllActive()
        {
            using (FeatureDAL featureDAL = new FeatureDAL())
            {
                return featureDAL.GetAll("IsActive", "1", "DisplayOrder", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="radiologyTestId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static FeatureModel GetById(long radiologyTestId)
        {
            using (FeatureDAL featureDAL = new FeatureDAL())
            {
                return featureDAL.GetById(radiologyTestId);
            }
        }

     

        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static FeatureModel Save(FeatureModel feature)
        {
            using (FeatureDAL featureDAL = new FeatureDAL())
            {
                return featureDAL.Save(feature);
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
            using (FeatureDAL featureDAL = new FeatureDAL())
            {
                return featureDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

    

     
    }
}