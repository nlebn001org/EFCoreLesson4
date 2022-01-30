using System;
using System.Collections.Generic;

#nullable disable

namespace EFCoreLesson4Task1
{
    public partial class Employee
    {
        public Employee()
        {
            InverseManagerEmp = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }

        public int EmployeeId { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set; }
        public string Mname { get; set; }
        public decimal Salary { get; set; }
        public decimal PriorSalary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public int? ManagerEmpId { get; set; }

        public virtual Employee ManagerEmp { get; set; }
        public virtual ICollection<Employee> InverseManagerEmp { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
