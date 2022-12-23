using System.ComponentModel.DataAnnotations;

namespace MvcWorkspace.Models
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Test { get; set; }   

    }
}
