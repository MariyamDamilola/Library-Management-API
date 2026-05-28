using LibraryManagementAPI.Models;
using LibraryManagementAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementAPI.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;
    
    public  BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    [HttpGet("GetAllBooks")]
    public async Task<IActionResult> GetAllBook()
    {
        var books = await _bookRepository.GetAllBooks();
        return Ok(books);
    }

    [HttpGet("GetBookById/{Id}")]
    public async Task<IActionResult> GetBookById(int Id)
    {
        var book = await _bookRepository.GetBookById(Id);
        return Ok(book);
    }

    [HttpPost("CreateBook")]
    public async Task<IActionResult> CreateBook(CreateBookDTO createBookDto)
    {
        var createdBook = await _bookRepository.CreateBook(createBookDto);
        return Ok(createdBook);
    }

    [HttpPut("UpdateBook")]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        var updatedBook = await _bookRepository.UpdateBook(book);
            return Ok(updatedBook);
    }

    [HttpDelete("DeleteBook/{Id}")]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var isDeleted = await _bookRepository.DeleteBook(id);
            return Ok(isDeleted);
    }

    [HttpGet("SearchBooks")]
    public async Task<IActionResult> SearchBooks(string search)
    {
        var searchedBook = await _bookRepository.SearchBooks(search);
        return Ok(searchedBook);
    }

    [HttpGet("GetBookByCategory")]
    public async Task<IActionResult> GetBookByCategory(string category)
    {
        var books = await _bookRepository.GetBookByCategory(category);
        return Ok(books);
    }

    [HttpGet("OutOfStock")]
    public async Task<IActionResult> OutOfStock()
    {
        var result = await _bookRepository.GetBookOutOfStock();
        return Ok(result);
    }
    
    
}