using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class Sesja
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Data i godzina rozpoczęcia")]
        public DateTime Start { get; set; }
        [Required]
        [Display(Name = "Data i godzina zakończenia")]
        public DateTime End { get; set; }
        public List<SesjaCwiczenia> SesjaCwiczenies { get; set; } = new();
        [Display(Name = "Stworzone przez")]
        public string CreatedById { get; set; } = string.Empty;
        [Display(Name = "Stworzone przez")]
        public virtual Uzytkownik? CreatedBy { get; set; }
    }
}