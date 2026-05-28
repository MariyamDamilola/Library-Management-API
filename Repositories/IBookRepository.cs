using Microsoft.EntityFrameworkCore;

using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllBooks();
    
    Task<Book> GetBookById(int id);
    
    Task<Book> CreateBook(CreateBookDTO createBookDto);
    
    Task<Book> UpdateBook(Book book);
    
    Task<bool> DeleteBook(int id);
    
    Task<IEnumerable<Book>> SearchBooks(string search);
    
    Task<IEnumerable<Book>> GetBookByCategory(string category);
    
    Task<IEnumerable<Book>> GetBookOutOfStock();
}