using LibraryManagementAPI.Data;
using LibraryManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementAPI.Repositories;

public class ContactRepository : IContactRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ContactRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Contact>> GetAllContacts()
    {
        return await _dbContext.Contacts.ToListAsync();
        
    }

    public async Task<Contact> GetContactByNumber(string number)
    {
        if (string.IsNullOrWhiteSpace(number))
        {
            throw new Exception("Phone number cannot be null or empty.");
        }
        
        var contact = await _dbContext.Contacts.AsNoTracking().FirstOrDefaultAsync(x=> x.Number == number);
        if (contact == null)
        {
            throw new Exception($"Contact with number {number} not found");
        }

        return contact;
    }

    public async Task<Contact> CreateContact(CreateContactDTO createContactDto)
    {
        var contact = new Contact()
        {
            Name = createContactDto.Name,
            Number = createContactDto.Number
        };
        
        await _dbContext.Contacts.AddAsync(contact);
        await  _dbContext.SaveChangesAsync();
        return contact;
    }

    public async Task<Contact> UpdateContact(string currentNumber, CreateContactDTO createContactDto )
    {
       var existingContact = await _dbContext.Contacts.FirstOrDefaultAsync(x=> x.Number == currentNumber);

       if (existingContact == null)
       {
           throw new Exception($"Contact not found");
       }

       existingContact.Name = createContactDto.Name;
       existingContact.Number = createContactDto.Number;
       await _dbContext.SaveChangesAsync();
       return existingContact;
    }

    public async Task<bool> DeleteContact(string number)
    {
            var contact = await _dbContext.Contacts.FirstOrDefaultAsync(x=> x.Number == number);
            if (contact == null)
            {
                throw new Exception($"Phone number not found");
            }
            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();
            return true;
    }

    public async Task<IEnumerable<Contact>> GetContactByNetwork(string network)
    {
        if (string.IsNullOrWhiteSpace(network))
        {
            throw new Exception("Network cannot be null or empty.");
        }
        
        return await _dbContext.Contacts.AsNoTracking().Where(x=> x.Network == network.ToLower()).ToListAsync();
        
    }
}