using Collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hantering_av_anställda
{
    public class EmployeeManagement
    {
        //public static readonly string path = @"EmployeeManagement.csv";

        //string AppFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData );
        public string path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData));
        public string fileName = @"EmployeeManagement.csv";
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
                int choose_number = int.Parse(Console.ReadLine());

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
                        int choice;
                        Function_Display_Employee(employeeList);
                        Console.Write("Which item do you want to remove? ");
                        choice = int.Parse(Console.ReadLine());
                        List<string> items = new List<string>();
                        int number = 1;
                        string item;
                        StreamReader inFile = new StreamReader(path);
                        while (inFile.Peek() != -1)
                        {
                            item = inFile.ReadLine();
                            if (number != choice)
                                items.Add(item);
                            ++number;
                        }
                        inFile.Close();
                        StreamWriter outFile = new StreamWriter(path);
                        for (int i = 0; i < items.Count; i++)
                            outFile.WriteLine(items[i]);
                        outFile.Close();

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
            StreamWriter outFile = File.AppendText(path);
            AbcCmpany obj_Comapny1 = new AbcCmpany();
            Console.Write("Enter Employee Id:\n");
            obj_Comapny1.emp_Id = int.Parse(Console.ReadLine());
            outFile.Write(obj_Comapny1.emp_Id + "              ");
            Console.Write("Enter Employee Name:\n");
            obj_Comapny1.emp_Name = Console.ReadLine();
            outFile.Write(obj_Comapny1.emp_Name + "              ");
            Console.Write("Enter Employee Addess:\n");
            obj_Comapny1.emp_Address = Console.ReadLine();
            outFile.Write(obj_Comapny1.emp_Address + "              ");
            Console.Write("Enter Employee Designation:\n");
            obj_Comapny1.emp_Designation = Console.ReadLine();
            outFile.Write(obj_Comapny1.emp_Designation);
            employeeList.Add(obj_Comapny1);
            Console.WriteLine("Employee Deatil Added Successfully...!!!!:");
            outFile.WriteLine("");

            outFile.Close();

        }

        public void Function_Display_Employee(List<AbcCmpany> employeeList)
        {

            using (var inFile = new StreamReader(path))
            {
                string line;

                while (inFile.Peek() != -1)
                {
                    line = inFile.ReadLine();
                    Console.WriteLine("****************************Employee Details****************************************");
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine("Employee Id\tEmployee Name\tEmployee Addess\tEmployee Designation");

                    foreach (AbcCmpany i in employeeList)
                    {

                        Console.Write(i.emp_Id + "      \t|  " + i.emp_Name + " \t| " + i.emp_Address + "   \t|  " + i.emp_Designation);

                    }
                    Console.WriteLine("------------------------------------------------------------------------------------");
                    Console.WriteLine(line);

                }

                inFile.Close();
            }

        }

        public AbcCmpany Function_Search(List<AbcCmpany> employeeList, int search_Id)
        {
            return employeeList.Find(emp => emp.emp_Id == search_Id);

        }


        public void Fucntion_Modify_Employee(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {

            Console.WriteLine("Chose Option for Modify Employee Detail:");
            Console.WriteLine("1.Id 2.Name 3.Address 4.Designation");
            StreamWriter outFile = File.AppendText(path);
            int modify_number = int.Parse(Console.ReadLine());



            switch (modify_number)
            {
                case 1:

                    Console.WriteLine("Enter New Employee Id:");
                    int new_Id = int.Parse(Console.ReadLine());
                    outFile.Write(new_Id + "              ");
                    obj_Modify.emp_Id = new_Id;
                    break;
                case 2:
                    Console.WriteLine("Enter New Employee Name:");
                    string new_Name = Console.ReadLine();
                    outFile.Write(new_Name + "              ");
                    obj_Modify.emp_Name = new_Name;
                    break;
                case 3:
                    Console.WriteLine("Enter New Employee Address:");
                    string new_Address = Console.ReadLine();
                    outFile.Write(new_Address + "              ");
                    obj_Modify.emp_Address = new_Address;
                    break;
                case 4:
                    Console.WriteLine("Enter New Employee Designation:");
                    string new_Designation = Console.ReadLine();
                    outFile.Write(new_Designation + "              ");
                    obj_Modify.emp_Designation = new_Designation;
                    break;
                default:
                    Console.WriteLine("Invalide Choise....");
                    break;

            }

            outFile.Close();

        }

        public void Function_Remove(List<AbcCmpany> employeeList, AbcCmpany obj_Modify)
        {

            employeeList.Remove(obj_Modify);
            Console.WriteLine("1 Record Removed SuccessFully....!!!");


        }

    }


}
