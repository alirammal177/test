using System.Collections.Generic;
using HMS.Class.DAL;
using HMS.Class.Helper;
using HMS.Models;
using System.Linq;
namespace HMS.Class.BLL
{

    public class MasterBLL
    {
        #region Country

        public static List<CountryModel> GetAllCountries(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllCountries(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<CountryModel> GetAllCountries()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllCountries("", "", "CountryName", "ASC", 0, 0);
            }
        }
        public static CountryModel GetCountryById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetCountryById(id);
            }
        }
        public static CountryModel SaveCountry(CountryModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveCountry(model);
            }
        }
        public static int DeleteCountry(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteCountry(operationType, multiIds);
            }
        }

        #endregion

        #region City

        public static List<CityModel> GetAllCities(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllCities(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<CityModel> GetAllCities()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllCities("", "", "CityName", "ASC", 0, 0);
            }
        }

        public static List<CityModel> GetCityByCountry(long countryId)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllCities("CountryId", countryId.ToString(), "CityName", "ASC", 0, 0);
            }
        }
        public static CityModel GetCityById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetCityById(id);
            }
        }

        public static CityModel SaveCity(CityModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveCity(model);
            }
        }

        public static int DeleteCity(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteCity(operationType, multiIds);
            }
        }

        #endregion

        #region District

        public static List<DistrictModel> GetAllDistricts(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDistricts(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<DistrictModel> GetAllDistricts()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDistricts("", "", "DistrictName", "ASC", 0, 0);
            }
        }
        public static List<DistrictModel> GetDistrictsByCity(long cityId)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDistricts("CityId", cityId.ToString(), "DistrictName", "ASC", 0, 0);
            }
        }
        public static DistrictModel GetDistrictById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetDistrictById(id);
            }
        }
        public static DistrictModel SaveDistrict(DistrictModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveDistrict(model);
            }
        }
        public static int DeleteDistrict(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteDistrict(operationType, multiIds);
            }
        }

        #endregion

        #region Nationality
        public static List<NationalityModel> GetAllNationalities(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllNationalities(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<NationalityModel> GetAllNationalities()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllNationalities("", "", "NationalityName", "ASC", 0, 0);
            }
        }
        public static NationalityModel GetNationalityById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetNationalityById(id);
            }
        }
        public static NationalityModel SaveNationality(NationalityModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveNationality(model);
            }
        }
        public static int DeleteNationality(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteNationality(operationType, multiIds);
            }
        }

        #endregion

        #region Allergy
        public static List<AllergyModel> GetAllAllergies(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllAllergies(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<AllergyModel> GetAllAllergies()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllAllergies("", "", "AllergyName", "ASC", 0, 0);
            }
        }
        public static AllergyModel GetAllergyById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllergyById(id);
            }
        }
        public static AllergyModel SaveAllergy(AllergyModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveAllergy(model);
            }
        }
        public static int DeleteAllergy(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteAllergy(operationType, multiIds);
            }
        }

        #endregion

        #region Operation
        public static List<OperationModel> GetAllOperations(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllOperations(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<OperationModel> GetAllOperations()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllOperations("", "", "OperationName", "ASC", 0, 0);
            }
        }

        public static List<OperationModel> GetAllOperations(string ids)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllOperations("OperationId", ids, "OperationName", "ASC", 0, 0);
            }
        }
        public static OperationModel GetOperationById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetOperationById(id);
            }
        }
        public static OperationModel SaveOperation(OperationModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveOperation(model);
            }
        }
        public static int DeleteOperation(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteOperation(operationType, multiIds);
            }
        }

        #endregion

        #region ConsultantType
        public static List<ConsultantTypeModel> GetAllConsultantTypes(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllConsultantTypes(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }

        public static List<ConsultantTypeModel> GetAllConsultantTypes()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllConsultantTypes("", "", "ConsultantTypeName", "ASC", 0, 0);
            }
        }
        public static ConsultantTypeModel GetConsultantTypeById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetConsultantTypeById(id);
            }
        }
        public static ConsultantTypeModel SaveConsultantType(ConsultantTypeModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveConsultantType(model);
            }
        }
        public static int DeleteConsultantType(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteConsultantType(operationType, multiIds);
            }
        }

        #endregion

        #region Diagnosis
        public static List<DiagnosisModel> GetAllDiagnosisList(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDiagnosisList(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<DiagnosisModel> GetAllDiagnosisList()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDiagnosisList("", "", "DiagnosisName", "ASC", 0, 0);
            }
        }

        public static List<DiagnosisModel> GetAllDiagnosisList(string ids = "")
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllDiagnosisList("DiagnosisId", ids, "DiagnosisName", "ASC", 0, 0);
            }
        }
        public static DiagnosisModel GetDiagnosisById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetDiagnosisById(id);
            }
        }
        public static DiagnosisModel SaveDiagnosis(DiagnosisModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveDiagnosis(model);
            }
        }
        public static int DeleteDiagnosis(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteDiagnosis(operationType, multiIds);
            }
        }

        #endregion

        #region Unit
        public static List<UnitModel> GetAllUnitList(string searchField, string searchValue, string sortField, string sortOrder, int pageNo, int pageSize)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllUnitList(searchField, searchValue, sortField, sortOrder, pageNo, pageSize);
            }
        }
        public static List<UnitModel> GetAllUnitList()
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetAllUnitList("", "", "UnitName", "ASC", 0, 0);
            }
        }
        public static UnitModel GetUnitById(long id)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.GetUnitById(id);
            }
        }
        public static UnitModel SaveUnit(UnitModel model)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.SaveUnit(model);
            }
        }
        public static int DeleteUnit(MultiOperationType operationType, string multiIds)
        {
            using (MasterDAL dal = new MasterDAL())
            {
                return dal.DeleteUnit(operationType, multiIds);
            }
        }

        #endregion

        #region Insurances

        public static List<InsuranceModel> GetAllInsurances()
        {
            var list = new List<InsuranceModel>();

            list.Add(new InsuranceModel() { InsuranceId = 1, InsuranceName = "Medgulf" });
            list.Add(new InsuranceModel() { InsuranceId = 2, InsuranceName = "Arope" });

            return list;
        }

        #endregion

        #region Social Hisotry

        public static List<ListItemModel> GetAllSocialHistory()
        {
            var list = new List<ListItemModel>();

            list.Add(new ListItemModel() { Value = "Smoker", Text = "Smoker" });
            list.Add(new ListItemModel() { Value = "Non Smoker", Text = "Non Smoker" });
            list.Add(new ListItemModel() { Value = "X-Smoker", Text = "X-Smoker" });
            list.Add(new ListItemModel() { Value = "Alcoholic", Text = "Alcoholic" });
            list.Add(new ListItemModel() { Value = "Non Alcoholic", Text = "Non Alcoholic" });
            list.Add(new ListItemModel() { Value = "X-Alcoholic", Text = "X-Alcoholic" });
            list.Add(new ListItemModel() { Value = "Drug Addict", Text = "Drug Addict" });
            list.Add(new ListItemModel() { Value = "Non Drug Addict", Text = "Non Drug Addict" });
            list.Add(new ListItemModel() { Value = "X-Drug Addict", Text = "X-Drug Addict" });
            
            return list;
        }

        #endregion
    }
}