using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;

namespace HMS.Class.BLL
{
   
    public class SupportTicketBLL
    {
        #region Public Methods

        public static List<SupportTicketModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (SupportTicketDAL supportTicketDAL = new SupportTicketDAL())
            {
                return supportTicketDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static SupportTicketModel GetById(long ticketId)
        {
            using (SupportTicketDAL supportTicketDAL = new SupportTicketDAL())
            {
                return supportTicketDAL.GetById(ticketId);
            }
        }

        public static long Update(SupportTicketModel supportTicket)
        {
            using (SupportTicketDAL supportTicketDAL = new SupportTicketDAL())
            {
                return supportTicketDAL.Update(supportTicket);
            }
        }

       
        public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        {
            using (SupportTicketDAL supportTicketDAL = new SupportTicketDAL())
            {
                return supportTicketDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        #endregion
    }
}