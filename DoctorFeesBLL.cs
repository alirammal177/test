using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using System;
using HMS.ViewModel;
using System.Linq;
namespace HMS.Class.BLL
{

    public class DoctorFeesBLL
    {

        #region Doctor Fees Item


        public static List<DoctorFeeItemModel> GetDoctorFeeItems(long doctorId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeeItems(doctorId);
            }
        }
        public static DoctorFeeItemModel GetDoctorFeeItemById(long doctorFeeItemId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeeItemById(doctorFeeItemId);
            }
        }
        public static long AddDoctorFeeItem(DoctorFeeItemModel doctorFeeItem)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.AddDoctorFeeItem(doctorFeeItem);
            }
        }

        public static int DeleteDoctorFeeItem(long doctorFeeItemId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.DeleteDoctorFeeItem(doctorFeeItemId);
            }
        }
        #endregion

        #region Doctor Service


        public static List<DoctorFeeServiceModel> GetDoctorFeeServices(long doctorId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeeServices(doctorId);
            }
        }
        public static DoctorFeeServiceModel GetDoctorFeeServiceById(long doctorFeeServiceId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeeServiceById(doctorFeeServiceId);
            }
        }
        public static long AddDoctorFeeService(DoctorFeeServiceModel doctorFeeService)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.AddDoctorFeeService(doctorFeeService);
            }
        }

        public static int DeleteDoctorFeeService(long doctorFeeServiceId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.DeleteDoctorFeeService(doctorFeeServiceId);
            }
        }
        #endregion

        #region Doctor Fees Calcuation

        public static DoctorFeeClaculationModel GetDoctorFeesPart(long doctorId, string systemItemId, string itemType)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeesPart(doctorId, systemItemId, itemType);
            }
        }


        #endregion

        #region Doctor Fees Report 

        public static List<DoctorFeeReportModel> GetDoctorFeesDetail(long doctorId, string status, DateTime? dateFrom, DateTime? dateTo)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeesDetail(doctorId, status, dateFrom, dateTo);
            }
        }

        #endregion

        #region Doctor Fees Receipt 
        public static List<DoctorFeeReceiptModel> GetDoctorFeesReceipt(long doctorId, string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeesReceipt(doctorId, searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static DoctorFeeReceiptModel GetDoctorFeesReceiptByGUID(string receiptGUID)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetDoctorFeesReceiptByGUID(receiptGUID);
            }
        }

        public static DoctorFeeReceiptModel SaveDoctorFeesReceipt(DoctorFeesInvoiceViewModel invoiceVM)
        {

            if (invoiceVM.UnpaidInvoiceList != null)
            {
                var subTotal = invoiceVM.UnpaidInvoiceList.Where(x => x.IsSelected).Sum(x => x.DoctorFees);
                invoiceVM.DoctorFeeReceipt.SubTotal= subTotal;
                invoiceVM.DoctorFeeReceipt.GrandTotal = subTotal;

                invoiceVM.DoctorFeeReceipt.ReceiptNumber = string.Concat("REC", DateTime.Now.ToString("yyMMddHHmmss"));

            }

            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {

                DoctorFeeReceiptModel  receipt = dal.SaveDoctorFeesReceipt(invoiceVM.DoctorFeeReceipt);
                if (receipt.ReceiptId > 0)
                {

                    string invoiceData = string.Empty;

                    var invoiceList = invoiceVM.UnpaidInvoiceList.Where(x=>x.IsSelected);

                    foreach (var cat in invoiceList)
                    {
                        invoiceData = string.Concat(invoiceData, cat.InvoiceId, ",");
                    }

                    invoiceData = invoiceData.TrimEnd('#');


                    dal.SaveReceiptDetail(receipt.ReceiptGUID, invoiceData);


                }

                return receipt;
            }
        }


        public static int DeleteDoctorFeesReceipt(string receiptGUID)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.DeleteDoctorFeesReceipt(receiptGUID);
            }
        }


        public static List<DoctorFeeUnpaidInvoiceModel> GetAllUnpaidInvoice(long doctorId, long companyId)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetAllUnpaidInvoice(doctorId, companyId);
            }

        }

        public static List<DoctorFeeReportModel> GetReceiptDetailDetailByReceiptGUID(string receiptGUID)
        {
            using (DoctorFeesDAL dal = new DoctorFeesDAL())
            {
                return dal.GetReceiptDetailDetailByReceiptGUID(receiptGUID);
            }
        }

        #endregion
    }
}