namespace WebApp.Models;

public class ContactMapper
{
    public static ContactEntity ToEntity(ContactModel arg)
    {
        return new ()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            Category = arg.Category,
            Organization = arg.Organization,
            OrganizationId = arg.OrganizationId
        };
    }

    public static ContactModel FromEntity(ContactEntity arg)
    {
        return new ()
        {
            Id = arg.Id,
            FirstName = arg.FirstName,
            LastName = arg.LastName,
            BirthDate = arg.BirthDate,
            PhoneNumber = arg.PhoneNumber,
            Email = arg.Email,
            Category = arg.Category,
            OrganizationId = arg.OrganizationId,
            Organization = arg.Organization
            
        };
    }
}