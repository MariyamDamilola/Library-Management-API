using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public interface IContactRepository
{
    Task<IEnumerable<Contact>> GetAllContacts();
    
    Task<Contact> GetContactByNumber(string number);
    
    Task<Contact> CreateContact( CreateContactDTO createContactDto);
    
    Task<Contact> UpdateContact(string currentNumber, CreateContactDTO createContactDto);
    
    Task<bool> DeleteContact(string number);
    
    Task<IEnumerable<Contact>> GetContactByNetwork(string network);
}