using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ApplicationUser
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordHash { get; set; }  
    }
}