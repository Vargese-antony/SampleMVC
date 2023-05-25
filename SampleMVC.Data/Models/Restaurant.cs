using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleMVC.Data.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [MaxLength(255)]
        [Required(ErrorMessage = "The Name is Mandatory")]
        public string Name { get; set; }
        [Display(Name = "Type of food")]
        public CusineType Cuisine { get; set; }
    }
}
