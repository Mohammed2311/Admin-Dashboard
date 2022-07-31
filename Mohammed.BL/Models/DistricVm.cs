using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Models
{
    public class DistricVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public City City { get; set; }
        public int CityID { get; set; }
        public ICollection<Employee> Employees { get; set; }


    }
}
