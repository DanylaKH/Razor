using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Razor.WebPages.Models
{
    public class Product
    {
        public int id { get; set; }
        [Required(ErrorMessage ="The name field cannot be null")]
        public string name { get; set; }
        [Required(ErrorMessage = "The price field cannot be null")]
        public int price { get; set; }
        public string PhotoPath { get; set; }
    }
}
