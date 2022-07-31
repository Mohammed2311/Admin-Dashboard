using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mohammed.DAL.Entity;

namespace Mohammed.DAL.Entity
{
    public class Distric
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey("CityID")]
        public City City { get; set; }
        public int CityID { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}
