using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,
            new ContactModel()
        {
            Id = 1,
            FirstName = "Adam",
            LastName = "Bebecki",
            Email = "adam@wsei.edu.pl",
            PhoneNumber = "111 222 333",
            BirthDate = new DateOnly(year:2000, month:10, day:10)
        
         }
         },
        
        {2,
        new ContactModel()
        {
            Id = 2,
            FirstName = "Karol",
            LastName = "Wojski",
            Email = "karol@wsei.edu.pl",
            PhoneNumber = "112 221 332",
            BirthDate = new DateOnly(year:2002, month:12, day:9)
        
        }
         
        },
        {3,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Ewa",
                LastName = "Kazik",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "121 212 323",
                BirthDate = new DateOnly(year:2001, month:2, day:14)
        
            }
        },
    };

    private static int _currentId = 3;
    
    
    // Lista kontaktow
    public IActionResult Index()
    {
        return View(_contacts);
    }

    //Zwraca formularz dodania kontaktu
    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }
    
    //Odebranie danych z formularza, zapisa kontaktu i powrot do listy kontaktow
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }     
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }

    public IActionResult Details(int id)
    {
        return View(_contacts[id]);
    }
}