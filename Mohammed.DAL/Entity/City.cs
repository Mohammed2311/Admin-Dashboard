using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.DAL.Entity
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        [ForeignKey("CountryId")]
        public Country Country { get; set; }
        public ICollection<Distric> Districs { get; set; }
    }
}
