using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
   
    public class ContactUsBLL
    {
        #region Public Methods

        public static List<ContactUsModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (ContactUsDAL contactUsDAL = new ContactUsDAL())
            {
                return contactUsDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static ContactUsModel GetById(long contactId)
        {
            using (ContactUsDAL contactUsDAL = new ContactUsDAL())
            {
                return contactUsDAL.GetById(contactId);
            }
        }

        public static long Update(ContactUsModel contactUs)
        {
            using (ContactUsDAL contactUsDAL = new ContactUsDAL())
            {
                return contactUsDAL.Update(contactUs);
            }
        }

       
        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (ContactUsDAL contactUsDAL = new ContactUsDAL())
            {
                return contactUsDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        #endregion
    }
}