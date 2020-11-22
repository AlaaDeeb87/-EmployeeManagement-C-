using Collection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hantering_av_anställda
{
    public class Employee : EmployeeManagement
    {
        public static void EmployeeRights()
        {
            Console.WriteLine("View Employee details type 1 \nModify Employee details type 2");
            int EmpInput = int.Parse(Console.ReadLine());
            EmployeeManagement obj_Company = new EmployeeManagement();
            List<AbcCmpany> employeeList = new List<AbcCmpany>();
            if (EmpInput == 1)
            {
                using (var inFile = new StreamReader(path))
                {
                    string line;

                    while (inFile.Peek() != -1)
                    {
                        Console.WriteLine("Enter your ID:");
                        int search_Id = int.Parse(Console.ReadLine());
                        AbcCmpany obj_search = obj_Company.Function_Search(employeeList, search_Id);
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
                    Console.WriteLine();
                    inFile.Close();
                }



            }
            else if (EmpInput == 2)
            {
                Console.WriteLine("Enter Employee Id Which You Want To Search:");
                int search_Id = int.Parse(Console.ReadLine());
                StreamReader inFile = new StreamReader(path);
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
                inFile.Close();
            }

        }

    }
}
