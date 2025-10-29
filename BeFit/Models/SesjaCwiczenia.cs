using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class SesjaCwiczenia
    {
        public int Id { get; set; }

        // FK do Sesji treningowej
        [Required]
        public int SesjaId { get; set; }
        public Sesja? Sesja { get; set; }

        // FK do typu ćwiczenia
        [Required]
        public int CwiczenieId { get; set; }
        public Cwiczenie? Cwiczenie { get; set; }

        // Parametry wykonania
        [Range(0, 1000, ErrorMessage = "Ciężar musi być w przedziale 0–1000 kg.")]
        public decimal CiezarKg { get; set; }

        [Range(1, 50, ErrorMessage = "Liczba serii musi być w przedziale 1–50.")]
        public int Serie { get; set; }

        [Range(1, 200, ErrorMessage = "Liczba powtórzeń musi być w przedziale 1–200.")]
        public int Powtorzenia { get; set; }

    }
}
