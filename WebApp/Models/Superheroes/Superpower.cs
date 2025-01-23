using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Superheroes
{
    [Table("superpower")] 
    public class Superpower
    {
        [Key]
        public int Id { get; set; } 
        
        [Column("power_name")]
        [Required(ErrorMessage = "Nazwa supermocy jest wymagana.")]
        [StringLength(100, ErrorMessage = "Nazwa supermocy może mieć maksymalnie 100 znaków.")]
        public string Name { get; set; } 
        
        
        public ICollection<HeroSuperpower> HeroSuperpowers { get; set; }
    }
}