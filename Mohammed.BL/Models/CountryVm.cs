using Mohammed.DAL.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Models
{
    public class CountryVm
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }


    }
}
