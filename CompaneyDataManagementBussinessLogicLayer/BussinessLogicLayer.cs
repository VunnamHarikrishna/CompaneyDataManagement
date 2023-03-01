using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entityes;
using CompaneyDataDLL;

namespace CompaneyDataManagementBLL
{
    public class BussinessLogicLayer
    {
        static DataLinkLayer DataLinkLayerobj = new DataLinkLayer();
        public bool CheckIdDetails(int companyID, int index)
        {
            if (index == 0)
            {
                return true;
            }
            List<Company> Companeyobj = new List<Company>();
            Companeyobj = DataLinkLayerobj.GetCompanyDetails();
           
            foreach (Company temp in Companeyobj)
            {
                if (temp.CompanyID.Equals(companyID))
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckNameDetails(string companeyName, int index)
        {
            if (index == 0)
            {
                return true;
            }
            List<Company> Companeyobj = new List<Company>();
            Companeyobj = DataLinkLayerobj.GetCompanyDetails();
          
            foreach (Company temp in Companeyobj)
            {
                if (temp.CompaneyName.Equals(companeyName))
                {
                    return false;
                }
            }
            return true;
        }

        public bool addComapnydata(Company companyobj, int index)
        {
           if(DataLinkLayerobj.AddCompnyDataToTable(companyobj, index))
            {
                return true;
            }
            return false;
        }

        public bool UpdateCompaneydata(Company companyobj)
        {
            if (DataLinkLayerobj.Updatecompaneydata(companyobj))
            {
                return true;
            }
            return false;
        }

        public bool DeleteCompaneydata(Company companyobj)
        {
            if (DataLinkLayerobj.DeleteCompaneydata(companyobj))
            {
                return true;
            }
            return false;

        }

        public string GetCompaneydataById(Company companyobj)
        {
            List<Company> Companeyobj = new List<Company>();
            Companeyobj = DataLinkLayerobj.GetCompanyDetails();
            if (Companeyobj.Count == 0)
            {
                return "";
            }
            foreach (Company temp in Companeyobj)
            {
                if (temp.CompanyID.Equals(companyobj.CompanyID))
                {
                    return temp.CompaneyName;
                }
            }
            return "";
        }

        public List<Company> GetCompanyDetails()
        {
            List<Company> Companeyobj = new List<Company>();
            Companeyobj = DataLinkLayerobj.GetCompanyDetails();
            return Companeyobj;
        }
    }
}
