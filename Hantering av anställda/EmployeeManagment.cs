using Collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hantering_av_anställda
{
   public class EmployeeManagement
    {
        public static string filename = @"C:\Users\alaas\OneDrive\Skrivbord\EmployeeManagment.csv";
        public void employeeManagement()
        {
            EmployeeManagement obj_Company = new EmployeeManagement();
            List<AbcCmpany> employeeList = new List<AbcCmpany>();
            char ans;
            int search_Id;
            do
            {
                Console.Clear();
                Console.WriteLine("**************************EMPLOYEE MANAGEMENT SYSTEM MENU******************************");
                Console.WriteLine("1. Add  an Employee");
                Console.WriteLine("2. View Employee details");
                Console.WriteLine("3. Search Employee details");
                Console.WriteLine("4. Modify Employee details");
                Console.WriteLine("5. Remove Employee details");
                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------------------------------------------------------------------------");
                Console.Write("Enter Your Choise Here:-");
                int choose_number = Convert.ToInt32(Console.ReadLine());

                switch (choose_number)
                {
                    case 1:

                        obj_Company.Function_Add_Employee(employeeList);
                        obj_Company.Function_Display_Employee(employeeList);

                        break;
                    case 2:
                        obj_Company.Function_Display_Employee(employeeList);
                        break;
                    case 3:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = int.Parse(Console.ReadLine());
                        AbcCmpany obj_search = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_search != null)
                        {
                            Console.WriteLine("Employee ID \t{0}", obj_search.emp_Id);
                            Console.WriteLine("Employee Name \t{0}", obj_search.emp_Name);
                            Console.WriteLine("Employee Address \t{0}", obj_search.emp_Address);
                            Console.WriteLine("Designation \t{0}\n", obj_search.emp_Designation);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = int.Parse(Console.ReadLine());
                        AbcCmpany obj_Modify = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_Modify != null)
                        {
                            Console.WriteLine("Employee ID      :" + obj_Modify.emp_Id);
                            Console.WriteLine("Employee Name    :" + obj_Modify.emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Modify.emp_Address);
                            Console.WriteLine("Designation      :" + obj_Modify.emp_Designation);
                            obj_Company.Fucntion_Modify_Employee(employeeList, obj_Modify);
                            obj_Company.Function_Display_Employee(employeeList);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }

                        break;
                    case 5:
                        Console.WriteLine("Enter Employee Id Which You Want To Search:");
                        search_Id = int.Parse(Console.ReadLine());
                        AbcCmpany obj_Delete = obj_Company.Function_Search(employeeList, search_Id);
                        if (obj_Delete != null)
                        {
                            Console.WriteLine("Employee ID      :" + obj_Delete.emp_Id);
                            Console.WriteLine("Employee Name    :" + obj_Delete.emp_Name);
                            Console.WriteLine("Employee Address :" + obj_Delete.emp_Address);
                            Console.WriteLine("Designation      :" + obj_Delete.emp_Designation);
                            obj_Company.Function_Remove(employeeList, obj_Delete);
                            obj_Company.Function_Display_Employee(employeeList);
                        }
                        else
                        {
                            Console.WriteLine("Record Not Found...!!!");
                        }
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalide Choise....!!! Please Enter Correct Choice...!!!");
                        break;
                }
                Console.Write("Would You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            } while (ans == 'y' || ans == 'Y');
        }

      

        public void Function_Add_Employee(List<AbcCmpany> employeeList)
        {
            StreamWriter outFile = File.AppendText(filename);
            AbcCmpany obj_Comapny1 = new AbcCmpany();
            Console.Write("Enter Employee Id:");
            obj_Comapny1.emp_Id = Convert.ToInt32(Console.ReadLine());
            outFile.WriteLine(obj_Comapny1.emp_Id);
            Console.Write("Enter Employee Name:");
            obj_Comapny1.emp_Name = Console.ReadLine();
            outFile.WriteLine(obj_Comapny1.emp_Name);
            Console.Write("Enter Employee Addess:");
            obj_Comapny1.emp_Address = Console.ReadLine();
            outFile.WriteLine(obj_Comapny1.emp_Address);
            Console.Write("Enter Employee Designation:");
            obj_Comapny1.emp_Designation = Console.ReadLine();
            outFile.WriteLine(obj_Comapny1.emp_Designation);
            employeeList.Add(obj_Comapny1);
            Console.WriteLine("Employee Deatil Added Successfully...!!!!:");
            outFile.Close();
        }

        public void Function_Display_Employee(List<AbcCmpany> employeeList)
        {
            Console.WriteLine("****************************Employee Details****************************************");
            Console.WriteLine("------------------------------------------------------------------------------------");
            Console.WriteLine("Employee Id\tEmployee Name\tEmployee Addess\tEmployee Designation");
            Console.WriteLine("------------------------------------------------------------------------------------");
            foreach (AbcCmpany i in employeeList)
            {
                Console.WriteLine(i.emp_Id + "      \t|  " + i.emp_Name + " \t| " + i.emp_Address + "   \t|  " + i.emp_Designation);
            }
            Console.WriteLine("------------------------------------------------------------------------------------");
        }

        public AbcCmpany Function_Search(List<AbcCmpany> employeeList, int search_Id)
        {
            return employeeList.Find(emp => emp.emp_Id == search_Id);
        }


        public void Fucntion_Modify_Employee(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {
            Console.WriteLine("Chose Option for Modify Employee Detail:");
            Console.WriteLine("1.Id 2.Name 3.Address 4.Designation");
            StreamWriter outFile = File.AppendText(filename);
            int modify_number = int.Parse(Console.ReadLine());
            switch (modify_number)
            {
                case 1:
                    Console.WriteLine("Enter New Employee Id:");
                    int new_Id = int.Parse(Console.ReadLine());
                    obj_Modify.emp_Id = new_Id;
                    break;
                case 2:
                    Console.WriteLine("Enter New Employee Name:");
                    string new_Name = Console.ReadLine();
                    obj_Modify.emp_Name = new_Name;
                    break;
                case 3:
                    Console.WriteLine("Enter New Employee Address:");
                    string new_Address = Console.ReadLine();
                    obj_Modify.emp_Address = new_Address;
                    break;
                case 4:
                    Console.WriteLine("Enter New Employee Designation:");
                    string new_Designation = Console.ReadLine();
                    obj_Modify.emp_Designation = new_Designation;
                    break;
                default:
                    Console.WriteLine("Invalide Choise....");
                    break;
            }
            outFile.WriteLine(obj_Modify);
            outFile.Close();
            
        }

        public void Function_Remove(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {
            employeeList.Remove(obj_Modify);
            Console.WriteLine("1 Record Removed SuccessFully....!!!");
            StreamWriter outFile = new StreamWriter(filename);
            outFile.WriteLine(obj_Modify);
            outFile.Close();
        }
    }

    
}
