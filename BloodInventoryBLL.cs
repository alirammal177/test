using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;

namespace HMS.Class.BLL
{
    public class BloodInventoryBLL
    {

        public static List<BloodInventoryModel> GetBloodInventory()
        {
            using (BloodInventoryDAL dal = new BloodInventoryDAL())
            {
                return dal.GetBloodInventory();
            }
        }

        public static void SaveBloodInventory(List<BloodInventoryModel> inventoryList)
        {
            string inventoryData = string.Empty;

            foreach (var inv in inventoryList)
            {
                inventoryData = string.Concat(inventoryData, inv.BloodGroup, ",", inv.Availability, "#");
            }

            inventoryData = inventoryData.TrimEnd('#');

            using (BloodInventoryDAL dal = new BloodInventoryDAL())
            {
                dal.SaveBloodInventory(inventoryData);
            }
        }

        public static List<CompanyModel> GetHospitals(string bloodGroup)
        {
            using (BloodInventoryDAL dal = new BloodInventoryDAL())
            {
                return dal.GetHospitals(bloodGroup);
            }
        }

    }
}