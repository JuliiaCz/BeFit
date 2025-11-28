using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class Cwiczenie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Nazwa ćwiczenia")]
        public string Name { get; set; } = string.Empty;
    }
}
