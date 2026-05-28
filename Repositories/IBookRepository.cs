using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Responses;
namespace LibraryManagementAPI.Repositories;

public interface IBookRepository
{
    Task<ApiResponse<IEnumerable<Book>>> GetAllBooks();
    
    Task<ApiResponse<Book>> GetBookById(int id);
    
    Task<ApiResponse<Book>> CreateBook(Book book);
    
    Task<ApiResponse<Book>> UpdateBook(Book book);
    
    Task<ApiResponse<bool>> DeleteBook(int id);
    
    Task<ApiResponse<IEnumerable<Book>>> SearchBooks(string search);
    
    Task<ApiResponse<IEnumerable<Book>>> GetBookByCategory(string category);
    
    Task<ApiResponse<IEnumerable<Book>>> GetBookOutOfStock();
}