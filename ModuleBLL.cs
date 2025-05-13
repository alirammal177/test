using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using HMS.ViewModel;
using System.Linq;
namespace HMS.Class.BLL
{
    public class ModuleBLL
    {

        public static List<ModuleModel> GetModules()
        {
            using (ModuleDAL dal = new ModuleDAL())
            {
                return dal.GetModules();
            }
        }

        public static List<ModuleModel> GetAddOnModules()
        {
            using (ModuleDAL dal = new ModuleDAL())
            {
                var modules = dal.GetModules();
                if (modules != null)
                {
                    modules = modules.Where(x => x.IsAddon).ToList();
                }

                return modules;
            }
        }

        public static List<ModuleModel> GetNonPurchasedModules()
        {
            using (ModuleDAL dal = new ModuleDAL())
            {
                return dal.GetNonPurchasedModules();
            }
        }
    }
}