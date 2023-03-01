using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompaneyDataManagementBLL;
using Entityes;


namespace CompaneyDataManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            //objects
            BussinessLogicLayer bussinessLogicObj = new BussinessLogicLayer();
            Company Companyobj = new Company();
            int index = 0;

            bool check = true;
            do
            {
                Console.WriteLine("Enter Your Choice : ");
                Console.WriteLine("1.Enter Companey Details  \n2.Edit Companey \n3.Delete Company " +
                    "\n4.Get Company By Id \n5.Display Company Details \n6.Go Back");
                try
                {
                    int Choice = int.Parse(Console.ReadLine());

                    switch (Choice)
                    {
                        case 1:
                            do
                            {
                                if (check)
                                {
                                    Console.WriteLine("enter company id: ");

                                }
                                else
                                {
                                    Console.WriteLine("wrong id is alredy there enter another");
                                }
                                Companyobj.CompanyID = int.Parse(Console.ReadLine());
                                if (bussinessLogicObj.CheckIdDetails(Companyobj.CompanyID,index))
                                {
                                    Console.WriteLine("Accepted ");
                                    break;
                                }
                                else
                                {
                                    check = false;
                                }
                            } while (!check);
                            check = true;
                            do
                            {
                                if (check)
                                {
                                    Console.WriteLine("enter company name: ");

                                }
                                else
                                {
                                    Console.WriteLine("wrong name is alredy there enter another");
                                }
                                Companyobj.CompaneyName = Console.ReadLine();
                                if (bussinessLogicObj.CheckNameDetails(Companyobj.CompaneyName, index))
                                {
                                    Console.WriteLine("Accepted ");
                                    break;
                                }
                                else
                                {
                                    check = false;
                                }
                            } while (!check);
                            if (bussinessLogicObj.addComapnydata(Companyobj, index))
                            {
                                Console.WriteLine("data added sucess fully");
                                index++;
                            }
                            else
                            {
                                throw new Exception("somting went wrong try it agin");
                            }
                            check = true;
                            break;
                        case 2:
                            Console.WriteLine("enter company id:");
                            Companyobj.CompanyID = int.Parse(Console.ReadLine());
                            Console.WriteLine("enter changed name");
                            Companyobj.CompaneyName = Console.ReadLine();
                            if (bussinessLogicObj.UpdateCompaneydata(Companyobj))
                            {
                                Console.WriteLine("data updated sucessfully ");
                            }
                            else
                            {
                                Console.WriteLine("somting went wrong");
                            }
                            break;
                        case 3:
                            Console.WriteLine("enter company id: for whitch companey details you want to delete ");
                            Companyobj.CompanyID = int.Parse(Console.ReadLine());
                           
                            if (bussinessLogicObj.DeleteCompaneydata(Companyobj))
                            {
                                Console.WriteLine("data deleted sucessfully ");
                            }
                            else
                            {
                                Console.WriteLine("somting went wrong");
                            }
                            break;
                        case 4:
                            Console.WriteLine("enter company id: for whitch companey details you want to get ");
                            Companyobj.CompanyID = int.Parse(Console.ReadLine());

                           try
                            {
                               string CompanyName= bussinessLogicObj.GetCompaneydataById(Companyobj);
                                Console.WriteLine("\n\n");
                                Console.WriteLine("company name is: "+CompanyName);
                                Console.WriteLine("\n\n");
                            }
                            catch
                            {
                                Console.WriteLine("somting went wrong");
                            }
                            break;
                        case 5:
                            List<Company> Companeyobj = new List<Company>();
                            Companeyobj = bussinessLogicObj.GetCompanyDetails();
                            Console.WriteLine("\n\n");
                            foreach (Company temp in Companeyobj)
                            {
                                Console.WriteLine(temp.CompanyID+"   "+temp.CompaneyName);
                            }
                            Console.WriteLine("\n\n");
                            break;
                           
                        case 6:
                            check = false;
                            Console.WriteLine("exiting... \ndone.");
                            break;
                        default:

                            break;
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


            } while (check);
        }
    }
}
