namespace WebApp.Models.Services;

public class MemoryContactService : IContactService
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {1,
            new ContactModel()
            {
                Category = Category.Business,
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
                Category = Category.Friend,
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
                Category = Category.Family,
                Id = 3,
                FirstName = "Ewa",
                LastName = "Kazik",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "121 212 323",
                BirthDate = new DateOnly(year:2001, month:2, day:14)
        
            }
        },
    };

    private static int _currentId = 3;
    
    public void Add(ContactModel model)
    {
        model.Id = ++_currentId;
        _contacts.Add(model.Id, model);
    }

    public void Update(ContactModel contact)
    {
        if (_contacts.ContainsKey(contact.Id))
        {
            _contacts[contact.Id] = contact;
            
        }
    }

    public void Delete(int id)
    {
        _contacts.Remove(id);
    }

    public List<ContactModel> GetAll()
    {
        return _contacts.Values.ToList();
    }

    public ContactModel GetById(int id)
    {
        return _contacts[id];
    }
}