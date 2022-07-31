using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.DAL.Entity
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public bool IsActive { get; set; }
        public string Notes { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
        public bool IsDleted { get; set; }
        public int DistricId { get; set; }

        [ForeignKey("DistricId")]
        public Distric District { get; set; }

       



    }
}
