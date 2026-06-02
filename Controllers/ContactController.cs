using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers;
[ApiController]
[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly IContactRepository _contactRepository;
    
    public  ContactController(IContactRepository contactRepository)
    {
        _contactRepository = contactRepository;
    }

    [HttpGet("GetAllContacts")]
    public async Task<IActionResult> GetAllContact()
    {
        var contacts = await _contactRepository.GetAllContacts();
        return Ok(contacts);
    }
    
    [HttpGet("GetByNumber/{number}")]
    public async Task<IActionResult> GetContactByNumber(string number)
    {
        var contact = await _contactRepository.GetContactByNumber(number);
        return Ok(contact);
    }
    
    [HttpPost("CreateContact")]
    public async Task<IActionResult> CreateContact(CreateContactDTO createContactDto)
    {
        var createdContact = await _contactRepository.CreateContact(createContactDto);
        return Ok(createdContact);
    }
    
    [HttpPut("UpdateContact")]
    public async Task<IActionResult> UpdateContact(string currentNumber,CreateContactDTO createContactDto)
    {
        var updatedContact = await _contactRepository.UpdateContact(currentNumber,createContactDto);
        return Ok(updatedContact);
    }
    
    [HttpDelete("DeleteContact/{number}")]
    public async Task<IActionResult> DeleteContact(string number)
    {
        var isDeleted = await _contactRepository.DeleteContact(number);
        return Ok(isDeleted);
    }
    
    [HttpGet("GetContactByCategory")]
    public async Task<IActionResult> GetNumberByNetwork(string network)
    {
        var contact = await _contactRepository.GetContactByNetwork(network);
        return Ok(contact);
    }



}