using Collection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hantering_av_anställda
{
    public class Employee : EmployeeManagement
    {
        public new void Function_Display_Employee(List<AbcCmpany> employeeList)
        {
            EmployeeManagement obj_Company = new EmployeeManagement();
            obj_Company.Function_Display_Employee(employeeList);
        }
 
    }
}
