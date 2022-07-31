using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mohammed.BL.Models
{
    public class DepartmentVm
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = " It is Required")]
        [MinLength(3 , ErrorMessage ="Must be more than 3")] 
        public string Name { get; set; }

        [Required(ErrorMessage = " It is Required")]
        [Range(100, 500)]

        public string Code { get; set; }



    }
}
