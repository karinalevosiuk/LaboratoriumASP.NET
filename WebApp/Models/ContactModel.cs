using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
namespace WebApp.Models;

public class ContactModel
{
    [HiddenInput]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisac imie!")]
    [MaxLength(length:20, ErrorMessage = "Imie nie moe byc dluzsze niz 20 znakow!")]
    [MinLength(length:2, ErrorMessage = "Imie musi miec co najmniej 2 znaki!")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Musisz wpisac Nazwisko!")]
    [MaxLength(length:50, ErrorMessage = "Nazwisko nie moe byc dluzsze niz 50 znakow!")]
    [MinLength(length:2, ErrorMessage = "Nazwisko musi miec co najmniej 2 znaki!")]
    public string LastName { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    [Phone]
    [RegularExpression(pattern:"\\d{3} \\d{3} \\d{3}", ErrorMessage = "Wpisz numer wg wzoru: xxx xxx xxx")]
    public string PhoneNumber { get; set; }
    
    [DataType(DataType.Date)]
    public DateOnly BirthDate { get; set; }
    
}