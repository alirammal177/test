using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System;
using System.Linq;
namespace HMS.Class.BLL
{

    public class FinancialCategoryBLL
    {
        #region FinancialCategory

        public static List<FinancialCategoryModel> GetAll(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.GetAll(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<FinancialCategoryModel> GetAllActive()
        {
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.GetAll("IsActive", "1", "FinancialCategoryName", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="financialCategoryId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static FinancialCategoryModel GetById(long financialCategoryId)
        {
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.GetById(financialCategoryId);
            }
        }



        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static FinancialCategoryModel Save(FinancialCategoryModel company)
        {
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.Save(company);
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
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.UpdateMultipleRecords(operationType, multiIds);
            }
        }

        public static List<FinancialCategoryModel> GetByPatientId(long patientId)
        {
            using (FinancialCategoryDAL financialCategoryDAL = new FinancialCategoryDAL())
            {
                return financialCategoryDAL.GetByPatientId(patientId);
            }
        }


        #endregion

        #region Age Exception


        public static List<AgeExceptionItemModel> GetAgeExceptionItems(long financialCategoryId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetAgeExceptionItems(financialCategoryId);
            }
        }
        public static AgeExceptionItemModel GetAgeExceptionItemById(long ageExceptionItemId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetAgeExceptionItemById(ageExceptionItemId);
            }
        }
        public static long AddAgeException(AgeExceptionItemModel ageException)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.AddAgeException(ageException);
            }
        }

        public static int DeleteAgeExceptionItem(long ageExceptionId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.DeleteAgeExceptionItem(ageExceptionId);
            }
        }
        #endregion

        #region Item Exception


        public static List<ItemExceptionModel> GetItemExceptions(long financialCategoryId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetItemExceptions(financialCategoryId);
            }
        }
        public static ItemExceptionModel GetItemExceptionById(long itemExceptionId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetItemExceptionById(itemExceptionId);
            }
        }
        public static long AddItemException(ItemExceptionModel itemException)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.AddItemException(itemException);
            }
        }

        public static int DeleteItemException(long itemExceptionId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.DeleteItemException(itemExceptionId);
            }
        }
        #endregion

        #region Service Exception


        public static List<ServiceExceptionModel> GetServiceExceptions(long financialCategoryId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetServiceExceptions(financialCategoryId);
            }
        }
        public static ServiceExceptionModel GetServiceExceptionById(long serviceExceptionId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetServiceExceptionById(serviceExceptionId);
            }
        }
        public static long AddServiceException(ServiceExceptionModel serviceException)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.AddServiceException(serviceException);
            }
        }

        public static int DeleteServiceException(long serviceExceptionId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.DeleteServiceException(serviceExceptionId);
            }
        }
        #endregion

        #region Patient Price Calcuation

        public static PriceClaculationModel GetCalculatedPatientPrice(long financialCategoryId, long patientId, string systemItemId, string itemType, decimal unitPrice = 0)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetCalculatedPatientPrice(financialCategoryId, patientId, systemItemId, itemType, unitPrice);
            }
        }


        #endregion

        #region FC Invoices
        public static List<FCInvoiceModel> GetFCInvoice(long financialCategoryId, string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCInvoice(financialCategoryId, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static FCInvoiceModel GetFCInvoiceByGUID(string invoiceGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCInvoiceByGUID(invoiceGUID);
            }
        }

        public static FCInvoiceModel SaveFCInvoice(FCInvoiceViewModel invoiceVM)
        {

            if (invoiceVM.UnpaidInvoiceList != null)
            {
                var subTotal = invoiceVM.UnpaidInvoiceList.Where(x => x.IsSelected).Sum(x => x.FCPart);
                invoiceVM.FCInvoice.SubTotal = subTotal;
                invoiceVM.FCInvoice.GrandTotal = subTotal + invoiceVM.FCInvoice.TaxAmount - invoiceVM.FCInvoice.Discount;

                invoiceVM.FCInvoice.InvoiceNumber = string.Concat("FC", DateTime.Now.ToString("yyMMddHHmmss"));

            }

            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {

                FCInvoiceModel invoice = dal.SaveFCInvoice(invoiceVM.FCInvoice);
                if (invoice.InvoiceId > 0)
                {

                    string invoiceData = string.Empty;

                    var invoiceList = invoiceVM.UnpaidInvoiceList.Where(x => x.IsSelected);

                    foreach (var cat in invoiceList)
                    {
                        invoiceData = string.Concat(invoiceData,
                          cat.InvoiceId, ",",
                          cat.InvoiceNumber, ",",
                          cat.InvoiceDate, ",",
                          cat.PatientId, ",",
                          cat.FCPart, "#");
                    }

                    invoiceData = invoiceData.TrimEnd('#');


                    dal.SaveFCInvoiceDetail(invoice.InvoiceId, invoiceVM.FCInvoice.FinancialCategoryId, invoiceData);


                }

                return invoice;
            }
        }


        public static int DeleteFCInvoice(string invoiceGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.DeleteFCInvoice(invoiceGUID);
            }
        }


        public static List<FCUnpaidInvoiceModel> GetAllUnpaidInvoice(long financialCategoryId, long companyId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetAllUnpaidInvoice(financialCategoryId, companyId);
            }

        }

        public static List<FCUnpaidInvoiceModel> GetFCInvoiceDetailByInvoiceGUID(string invoiceGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCInvoiceDetailByInvoiceGUID(invoiceGUID);
            }
        }

        public static int UpdatePaidStatus(string invoiceGUID, InvoiceStatusType invoiceStatusType)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.UpdatePaidStatus(invoiceGUID, invoiceStatusType);
            }
        }

        #endregion

        #region FC Receipt

        public static FCReceiptModel GetFCReceiptByGUID(string receiptGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCReceiptByGUID(receiptGUID);
            }
        }
        public static List<FCReceiptModel> GetFCReceiptByInvoiceGUID(string invoiceGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCReceiptByInvoiceGUID(invoiceGUID);
            }
        }

        public static List<FCUnpaidInvoiceModel> GetFCReceiptDetailByReceiptGUID(string receiptGUID)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCReceiptDetailByReceiptGUID(receiptGUID);
            }
        }

        public static FCReceiptModel SaveFCReceipt(FCReceiptModel receipt, string itemIds)
        {

            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.SaveFCReceipt(receipt, itemIds);
            }
        }

        public static int DeleteFCReceipt(string receiptId)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.DeleteFCReceipt(receiptId);
            }
        }
        #endregion

        #region FC Report

        public static List<FCReportModel> GetFCPartDetail(long fcId, string status, DateTime? dateFrom, DateTime? dateTo)
        {
            using (FinancialCategoryDAL dal = new FinancialCategoryDAL())
            {
                return dal.GetFCPartDetail(fcId, status, dateFrom, dateTo);
            }
        }

        #endregion
    }
}