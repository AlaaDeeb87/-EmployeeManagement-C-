using Collection;
using System;
using System.Collections.Generic;

namespace Hantering_av_anställda
{
    class Program
    {
       public static void Main(string[] args)
        {
            Console.WriteLine("Admin type 1\nEmployee type 2");
            int num = int.Parse(Console.ReadLine());
            if (num==1)
            {
                EmployeeManagement emloyee = new EmployeeManagement();
                emloyee.employeeManagement();
                
            }
            else if (num==2)
            {
                EmployeeManagement obj_Company = new EmployeeManagement();
                List<AbcCmpany> employeeList = new List<AbcCmpany>();
                EmployeeManagement emloyee = new EmployeeManagement();
                obj_Company.Function_Display_Employee(employeeList);
            }
           
           
        }
  
    }
}
