using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System.Linq;
using System;
namespace HMS.Class.BLL
{

    public class ContractBLL
    {
        public static List<ContractModel> GetAll(long companyId)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                return contractDAL.GetAll(companyId);
            }
        }

        public static ContractModel GetById(long contractId)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                return contractDAL.GetById(contractId, string.Empty);
            }
        }

        public static ContractModel GetByGUID(string contractGUID)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                return contractDAL.GetById(0, contractGUID);
            }
        }

        public static ContractModel Save(ContractViewModel contractVM)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                var contract = contractDAL.Save(contractVM.Contract);

                if (contract.ContractId > 0)
                {

                    string data = string.Empty;

                    foreach (var userCount in contractVM.UserCounts)
                    {
                        data = string.Concat(data, userCount.RoleID, ",", userCount.NoOfUser, "#");
                    }

                    data = data.TrimEnd('#');

                    contractDAL.SaveContractUserCount(contract.ContractId, data);
                }
                return contract;
            }
        }

        public static List<ContractUserCountModel> GetContractUserCount(long contractId)
        {
            using (ContractDAL contractDALDAL = new ContractDAL())
            {
                return contractDALDAL.GetContractUserCount(contractId);
            }
        }

        public static void UpdateContractStatus(long companyId, string contractGUID, int contractStatus)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                contractDAL.UpdateContractStatus(companyId,contractGUID, contractStatus);
            }
        }

        public static List<ContractModel> GetContractRenewal(string contractGUID)
        {
            using (ContractDAL contractDALDAL = new ContractDAL())
            {
                return contractDALDAL.GetContractRenewal(contractGUID);
            }
        }

        public static ContractModel RenewContract(long companyId, string contractGUID)
        {
            using (ContractDAL contractDAL = new ContractDAL())
            {
                return contractDAL.RenewContract(companyId, contractGUID);
            }
        }

        //public static OrderModel Save(OrderViewModel orderVM)
        //{
        //    var orderTotal = decimal.Zero;
        //    var monthTotal = decimal.Zero;
        //    var subTotal = decimal.Zero;
        //    var prevBalance = decimal.Zero;

        //    var packageTotal = decimal.Zero;
        //    var moduleTotal = decimal.Zero;
        //    var userTotal = decimal.Zero;

        //    var month = decimal.Zero;

        //    if (orderVM.Order.IsRenewOrder)
        //    {
        //        packageTotal = orderVM.OrderPackage.PackagePrice;
        //        month = orderVM.OrderPackage.TotalMonth;
        //        prevBalance = decimal.Zero;
        //    }
        //    else
        //    {

        //        if (orderVM.OrderPackage != null)
        //        {
        //            packageTotal = orderVM.OrderPackage.PackagePrice;
        //            month = orderVM.OrderPackage.TotalMonth;
        //            prevBalance = orderVM.CurrentPackage.RemainingAmount;
        //        }
        //        else
        //        {
        //            month = orderVM.CurrentPackage.RemainingMonths;
        //            prevBalance = decimal.Zero;
        //        }
        //    }

        //    if(orderVM.OrderModules != null)
        //    {
        //        List<OrderModuleModel> orderModules = orderVM.OrderModules;
        //        var modules = orderVM.Modules;
             
        //        foreach (var m in orderModules)
        //        {
        //           var module = modules.Where(x => x.ModuleId == m.ModuleId).FirstOrDefault();
        //           m.ModulePrice = module.ModulePrice.Value;
        //           moduleTotal += module.ModulePrice.Value;
        //        }
        //    }

        //    if (orderVM.OrderUserCounts != null)
        //    {
        //        List<OrderUserCountModel> orderUsers = orderVM.OrderUserCounts;
        //        var roles = orderVM.UserRoles;
           
        //        foreach (var u in orderUsers)
        //        {
        //            var role = roles.Where(x => x.RoleGUID== u.RoleGUID).FirstOrDefault();
        //            u.UserPrice = role.Price.Value;
        //            u.UserCount = u.UserCount;
        //            userTotal += role.Price.Value * u.UserCount;
        //        }
        //    }

        //    monthTotal = packageTotal + moduleTotal + userTotal;
        //    subTotal = monthTotal * month;

        //    orderTotal = subTotal + prevBalance;

        //    orderVM.Order.MonthTotal = monthTotal;
        //    orderVM.Order.TotalMonth = month;
        //    orderVM.Order.PreviousBalance = prevBalance;
        //    orderVM.Order.SubTotal = subTotal;
        //    orderVM.Order.OrderTotal = orderTotal;
        //    orderVM.Order.OrderStatus = PackageOrderStatusType.Pending.GetHashCode();

        //    orderVM.Order.OrderNumber = string.Format("ORD{0}", DateTime.Now.ToString("yyMMddHHmmss"));
            
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {

        //        var order = contractDAL.Save(orderVM.Order);

        //        if (!string.IsNullOrEmpty(order.OrderGUID))
        //        {

        //            //Save Order Package
        //            if(orderVM.OrderPackage != null)
        //            {
        //                contractDAL.SaveOrderPackage(order.OrderGUID, orderVM.OrderPackage);
        //            }


        //            //Save Modules
        //            string moduleData = string.Empty;

        //            if (orderVM.OrderModules != null)
        //            {
        //                foreach (var module in orderVM.OrderModules)
        //                {
        //                    moduleData = string.Concat(moduleData, module.ModuleId, ",", module.ModulePrice, "#");
        //                }
        //            }
        //            moduleData = moduleData.TrimEnd('#');

        //            contractDAL.SaveOrderModules(order.OrderGUID, moduleData);


        //            //Save User Count
        //            string data = string.Empty;
        //            if (orderVM.OrderUserCounts != null)
        //            {
        //                foreach (var userCount in orderVM.OrderUserCounts)
        //                {
        //                    data = string.Concat(data, userCount.RoleGUID, ",", userCount.UserPrice, ",", userCount.UserCount, "#");
        //                }
        //            }
        //            data = data.TrimEnd('#');

        //            contractDAL.SaveOrderUserCount(order.OrderGUID, data);
        //        }

        //        return order;
        //    }
        //}

        //public static int UpdateMultipleRecords(MultiOperationType operationType, string multiIds)
        //{
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {
        //        return contractDAL.UpdateMultipleRecords(operationType, multiIds);
        //    }
        //}

        //public static List<OrderUserCountModel> GetOrderUserCount(long orderId)
        //{
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {
        //        return contractDAL.GetOrderUserCount(orderId);
        //    }
        //}

        //public static OrderReviewViewModel GetOrderReviewData(string orderGUID)
        //{
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {
        //        return contractDAL.GetOrderReviewData(orderGUID);
        //    }
        //}

        //public static OrderModel ConfirmOrder(string orderGUID, OrderConfirmViewModel orderConfirmVM)
        //{
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {
        //        return contractDAL.ConfirmOrder(orderGUID, orderConfirmVM);
        //    }
        //}

        //public static OrderReviewViewModel GetRenewData(string companyId)
        //{
        //    using (ContractDAL contractDAL = new ContractDAL())
        //    {
        //        return contractDAL.GetRenewData(companyId);
        //    }
        //}
      
    }
}