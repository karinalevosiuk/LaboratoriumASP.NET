namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel arg)
    {
        return new ContactEntity()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            Category = arg.Category
        };
    }

    public static ContactModel FromEntity(ContactEntity arg)
    {
        return new ContactModel()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            Category = arg.Category
        };
    }
}