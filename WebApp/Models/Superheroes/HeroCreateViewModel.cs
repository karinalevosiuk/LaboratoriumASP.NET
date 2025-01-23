using System.ComponentModel.DataAnnotations;

namespace WebApp.Models.Superheroes
{
    public class HeroCreateViewModel
    {
        [Required(ErrorMessage = "Imię superbohatera jest wymagane.")]
        [StringLength(100, ErrorMessage = "Imię superbohatera nie może mieć więcej niż 100 znaków.")]
        public string SuperheroName { get; set; }

        [Required(ErrorMessage = "Pełne imię jest wymagane.")]
        [StringLength(200, ErrorMessage = "Pełne imię nie może mieć więcej niż 200 znaków.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Waga jest wymagane.")]
        [Range(1, 1000, ErrorMessage = "Waga musi być większa niż 0.")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Wzrost jest wymagane.")]
        [Range(1, 300, ErrorMessage = "Wzrost musi być większy niż 0.")]
        public double Height { get; set; }
        
        public List<int> SelectedSuperpowers { get; set; }
    }
}