using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public  class Bolum
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
