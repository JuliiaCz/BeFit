using System.ComponentModel.DataAnnotations;

namespace BeFit.Models
{
    public class Statystyki
    {
        [Required(ErrorMessage = "Nazwa ćwiczenia wymagana.")]
        [Display(Name = "Nazwa ćwiczenia")]
        public string ExerciseName { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Liczba serii musi być większa od zera.")]
        [Display(Name = "Liczba serii")]
        public int Count { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Łączna liczba powtórzeń nie może być ujemna.")]
        [Display(Name = "Łącznie powtórzeń")]
        public int TotalReps { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Średnia waga nie może być ujemna.")]
        [Display(Name = "Średnia waga")]
        public double AvgWeight { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Maksymalna waga nie może być ujemna.")]
        [Display(Name = "Maksymalna waga")]
        public int MaxWeight { get; set; }
    }
}