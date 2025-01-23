using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Superheroes
{
    [Table("superhero")] 
    public class Hero
    {
        [Column("id")]
        public int Id { get; set; } 
        [Column("superhero_name")]
        public string SuperheroName { get; set; }
        [Column("full_name")]
        public string? FullName { get; set; } 
        [Column("weight_kg")]
        public double? Weight { get; set; } 
        [Column("height_cm")]
        public double? Height { get; set; } 

        public ICollection<HeroSuperpower> HeroSuperpowers { get; set; } = new List<HeroSuperpower>(); 


    }
}