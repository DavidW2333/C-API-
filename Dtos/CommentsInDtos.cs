using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Dtos
{
    public class CommentsInDtos
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Comment { get; set; }
    }
}
