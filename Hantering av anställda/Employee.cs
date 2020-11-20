using Collection;
using System;
using System.Collections.Generic;
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
            if (EmpInput==1)
            {
               
                Console.WriteLine("Enter Employee Id Which You Want To Search:");
                int search_Id = int.Parse(Console.ReadLine());
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

            }
            else if (EmpInput==2)
            {
                Console.WriteLine("Enter Employee Id Which You Want To Search:");
                int search_Id = int.Parse(Console.ReadLine());
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

            }

        }
 
    }
}
