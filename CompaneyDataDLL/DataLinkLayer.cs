using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entityes;

namespace CompaneyDataDLL
{
    public class DataLinkLayer
    {
        static DatabaseConnection Connection = new DatabaseConnection();
        public List<Company> GetCompanyDetails()
        {
            List<Company> Companydata = new List<Company>();

            SqlCommand Command = new SqlCommand($"select * from CompanyData where IsDeleted=0;", Connection.getConnection());


            Connection.OpenConnection();
            SqlDataReader Cmddata = Command.ExecuteReader();
            
            while (Cmddata.Read())
            {
                Company Tempobj = new Company();

                Tempobj.CompanyID = Cmddata.GetInt32(Cmddata.GetOrdinal("CompanyID"));
                Tempobj.CompaneyName = Cmddata.GetString(Cmddata.GetOrdinal("CompanyName"));

                Companydata.Add(Tempobj);

            }
            Connection.CloseConnection();
            return Companydata;
        }

        public bool AddCompnyDataToTable(Company companyobj, int index)
        {

            if (index == 0)
            {
                   try
                {
                    Connection.OpenConnection();
                    SqlCommand Command = new SqlCommand($"drop table CompanyData;", Connection.getConnection());
                    Command.ExecuteNonQuery();
                    Command = new SqlCommand($"CREATE TABLE CompanyData ( CompanyID int, CompanyName varchar(15),IsDeleted bit);", Connection.getConnection());
                    Command.ExecuteNonQuery();
                    Command = new SqlCommand($"insert into CompanyData values({companyobj.CompanyID},'{companyobj.CompaneyName}',0);", Connection.getConnection());
                    Command.ExecuteNonQuery();
                    Connection.CloseConnection();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            else
            {
                SqlCommand Command = new SqlCommand($"insert into CompanyData values({companyobj.CompanyID},'{companyobj.CompaneyName}',0);", Connection.getConnection());
                try
                {
                    Connection.OpenConnection();
                    Command.ExecuteNonQuery();
                    Connection.CloseConnection();
                }
                catch(Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
           
            return true;
        }

        public bool Updatecompaneydata(Company companyobj)
        {
            SqlCommand Command = new SqlCommand($"update CompanyData set CompanyName='{companyobj.CompaneyName}' where CompanyID={companyobj.CompanyID};", Connection.getConnection());

            try
            {
                Connection.OpenConnection();
                Command.ExecuteNonQuery();
                Connection.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return true;
        }


        //select CompaneyName from CompanyData where CompanyID=1;
        //public string GetCompaneydataById(Company companyobj)
        //{
        //    SqlCommand Command = new SqlCommand($"select CompaneyName from CompanyData where CompanyID={companyobj.CompanyID};", Connection.getConnection());

        //    Connection.OpenConnection();
        //    SqlDataReader Cmddata = Command.ExecuteReader();

        //   string companeyname = Cmddata.GetString(Cmddata.GetOrdinal("CompaneyName"));
        //    Connection.CloseConnection();
        //    return companeyname;
        //}

        public bool DeleteCompaneydata(Company companyobj)
        {
            SqlCommand Command = new SqlCommand($"update CompanyData set IsDeleted=1 where CompanyID={companyobj.CompanyID};", Connection.getConnection());

            try
            {
                Connection.OpenConnection();
                Command.ExecuteNonQuery();
                Connection.CloseConnection();
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
