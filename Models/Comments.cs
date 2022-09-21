using System.ComponentModel.DataAnnotations;

namespace CS335_A1.Models
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Comment { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string IP { get; set; }
    }
}


