using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System;

namespace HMS.Class.BLL
{

    public class InvoiceBLL
    {
        #region Invoice

        public static List<InvoiceModel> GetAll(string invoiceType, string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetAll(invoiceType, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<InvoiceModel> GetAllActive(string invoiceType)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetAll(invoiceType, "IsActive", "1", "InvoiceDate", "ASC", 0, 0);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="invoiceId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static InvoiceModel GetById(long invoiceId)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetById(invoiceId, string.Empty);
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="invoiceId">The user id.</param>
        /// <returns>Returns user by id.</returns>
        public static InvoiceModel GetByGUID(string invoiceGUID)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetById(0, invoiceGUID);
            }
        }



        /// <summary>
        /// Saves the specified user.
        /// </summary>
        /// <param name="company">The user.</param>
        /// <returns>Returns user id if success else duplicate column name.</returns>
        public static InvoiceModel Save(InvoiceViewModel invoiceVM)
        {

            if (invoiceVM.InvoiceItems != null)
            {
                List<InvoiceDetailModel> invoiceDetailList = invoiceVM.InvoiceItems;
                var subTotal = 0.0M;
                foreach (var cat in invoiceDetailList)
                {
                    subTotal += cat.Amount;
                }

                invoiceVM.Invoice.SubTotal = subTotal;
                invoiceVM.Invoice.GrandTotal = subTotal + invoiceVM.Invoice.TaxAmount - invoiceVM.Invoice.Discount;

                invoiceVM.Invoice.InvoiceNumber = string.Concat(GetInvoiceType(invoiceVM.Invoice.InvoiceType), invoiceVM.Invoice.PatientId, DateTime.Now.ToString("yyMMddHHmm"));

            }

            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {

                InvoiceModel invoice = invoiceDAL.Save(invoiceVM.Invoice);
                if (invoice.InvoiceId > 0)
                {
                    SaveInvoiceDetail(invoice.InvoiceId, invoiceVM.InvoiceItems, invoiceVM.Invoice.InvoiceType);
                }

                return invoice;
            }
        }

        /// <summary>
        /// Updates the multiple records.
        /// </summary>
        /// <param name="operationType">Type of the operation.</param>
        /// <param name="multiIds">The multi ids.</param>
        /// <returns>Returns 1 if success else 0.</returns>
        public static int DeleteInvoice(string invoiceGUID)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.DeleteInvoice(invoiceGUID);
            }
        }

        public static int UpdateInvoiceStatus(string invoiceGUID, InvoiceStatusType invoiceStatusType)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.UpdateInvoiceStatus(invoiceGUID, invoiceStatusType);
            }
        }



        #endregion

        #region Invoice Detail

        public static List<InvoiceDetailModel> GetInvoiceDetailByInvoice(long invoiceId, string invoiceType, long referenceId)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetInvoiceDetailByInvoice(invoiceId, invoiceType, referenceId);
            }
        }

        public static void SaveInvoiceDetail(long invoiceId, List<InvoiceDetailModel> invoiceDetailList, string invoiceType)
        {
            string chargesData = string.Empty;

            foreach (var cat in invoiceDetailList)
            {
                //if (cat.Amount > 0)
                //{
                //    chargesData = string.Concat(chargesData, cat.DetailGUID, ",", cat.PaymentCategoryId, ",", cat.Amount, ",", cat.FinancialCategoryId,",",cat.Quantity, "#");
                //}

                chargesData = string.Concat(chargesData,
                    cat.DetailGUID, ",",
                    cat.PaymentCategoryId, ",",
                    cat.Amount, ",",
                    cat.FinancialCategoryId, ",",
                    (cat.FCId2 != null ? cat.FCId2 : 0), ",",
                    (cat.FCId3 != null ? cat.FCId3 : 0), ",",
                    cat.FC1Part, ",",
                    cat.FC2Part, ",",
                    cat.FC3Part, ",",
                    cat.Quantity, ",",
                    cat.DoctorId, ",",
                    cat.DoctorPart, "#");
            }

            chargesData = chargesData.TrimEnd('#');

            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                invoiceDAL.SaveInvoiceDetail(invoiceId, chargesData, invoiceType);
            }
        }

        #endregion

        #region Payment

        public static List<PaymentModel> GetByPaymentInvoiceId(long invoiceId)
        {
            using (InvoiceDAL dal = new InvoiceDAL())
            {
                return dal.GetByPaymentByInvoiceId(0, invoiceId);
            }
        }

        public static long SavePayment(PaymentModel payment)
        {
            using (InvoiceDAL dal = new InvoiceDAL())
            {
                return dal.SavePayment(payment);
            }
        }

        public static int DeletePayment(long paymentId)
        {
            using (InvoiceDAL dal = new InvoiceDAL())
            {
                return dal.DeletePayment(paymentId);
            }
        }

        public static PaymentModel GetPaymentByGUID(string receiptGUID)
        {
            using (InvoiceDAL invoiceDAL = new InvoiceDAL())
            {
                return invoiceDAL.GetPaymentByGUID(receiptGUID);
            }
        }

        #endregion

        #region Supported Methods

        private static string GetInvoiceType(string invoiceType)
        {
            string invType = string.Empty;
            if (invoiceType == InvoiceTypes.Appointment.ToString())
            {
                invType = "APP";
            }
            else if (invoiceType == InvoiceTypes.Laboratory.ToString())
            {
                invType = "LAB";
            }
            else if (invoiceType == InvoiceTypes.Radiology.ToString())
            {
                invType = "RAD";
            }
            else if (invoiceType == InvoiceTypes.Pharmacy.ToString())
            {
                invType = "PHY";
            }

            return invType;

        }
        #endregion
    }
}