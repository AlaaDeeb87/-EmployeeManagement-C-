using System;

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
                Employee.EmployeeRights();
            }
            

        }
  
    }
}
