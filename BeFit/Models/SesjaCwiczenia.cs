using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Threading.Tasks;

namespace BeFit.Models
{
    public class SesjaCwiczenia
    {
        public int Id { get; set; }

        // FK do Sesji treningowej
        [Required]
        [Display(Name = "Sesja treningowa")]
        public int SesjaId { get; set; }

        [Display(Name = "Sesja treningowa")]
        public virtual Sesja? Sesja { get; set; }

        // FK do typu ćwiczenia
        [Required]
        [Display(Name = "Ćwiczenie")]
        public int CwiczenieId { get; set; }

        [Display(Name = "Ćwiczenie")]
        public virtual Cwiczenie? Cwiczenie { get; set; }

        // Parametry wykonania
        [Range(0, 1000, ErrorMessage = "Ciężar musi być w przedziale 0–1000 kg.")]
        [Display(Name = "Ciężar [kg]")]
        public decimal CiezarKg { get; set; }

        [Range(1, 50, ErrorMessage = "Liczba serii musi być w przedziale 1–50.")]
        [Display(Name = "Serie")]
        public int Serie { get; set; }

        [Range(1, 200, ErrorMessage = "Liczba powtórzeń musi być w przedziale 1–200.")]
        [Display(Name = "Powtórzenia")]
        public int Powtorzenia { get; set; }


        [Display(Name = "Stworzone przez")]
        public string CreatedById { get; set; } = string.Empty;
        [Display(Name = "Stworzone przez")]
        public virtual Uzytkownik? CreatedBy { get; set; }

    }
}
