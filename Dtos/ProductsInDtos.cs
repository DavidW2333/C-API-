using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Dtos
{
    public class ProductsInDtos
    {   
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public double Price { get; set; }
    }
}
