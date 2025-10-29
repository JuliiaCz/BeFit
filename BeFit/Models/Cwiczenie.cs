using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class Cwiczenie
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Display(Name = "Opis ćwiczenia")]
        public string Name { get; set; }
    }
}
