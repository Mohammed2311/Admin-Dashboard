using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.DAL.Entity
{
    
    public class Department
    {
        [Key]
        public int ID { get; set; }
        
        public string Code { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
