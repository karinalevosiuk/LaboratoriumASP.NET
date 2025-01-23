using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Models.Superheroes
{
    [Table("hero_power")] 
    public class HeroSuperpower
    {
        [Column("hero_id")]
        public int HeroId { get; set; }  
        public Hero Hero { get; set; } 
        
        [Column("power_id")]
        public int SuperpowerId { get; set; } 
        public Superpower Superpower { get; set; }  
    }
}
