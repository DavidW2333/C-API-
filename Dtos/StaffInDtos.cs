using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CS335_A1.Dtos
{
    public class StaffInDtos
    {
        
        [Required]
        public string LastName { get; set; }
        
        [Required]
        public string FirstName { get; set; }

        public string Title { get; set; }

        public string Email { get; set; }
        public string Tel { get; set; }
        public string Url { get; set; }
        public string Research { get; set; }
    }
}
