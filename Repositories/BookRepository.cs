using LibraryManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;
using LibraryManagementAPI.Responses;

namespace LibraryManagementAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<ApiResponse<IEnumerable<Book>>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        return ApiResponse<IEnumerable<Book>>.CreateSuccess(books, "All books retrieved successfully.");
        
    }

    public async Task<ApiResponse<Book>> GetBookById(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == id);
        if (book == null)
        {
            return ApiResponse<Book>.CreateFailure($"Book with id {id} not found");
        }
        return ApiResponse<Book>.CreateSuccess(book, "Book retrieved successfully.");
    }

    public async Task<ApiResponse<Book>> CreateBook(Book book)
    {

        if (book.Price <= 0)
        {
            return ApiResponse<Book>.CreateFailure("Price must be greater than zero");
        }

        if (book.Quantity < 0)
        {
            return ApiResponse<Book>.CreateFailure("Quantity cannot be negative");
        }
        var bookexist = await _dbContext.Books.AnyAsync(x=> x.Title == book.Title);
        if (bookexist)
        {
            return ApiResponse<Book>.CreateFailure($"Book with title {book.Title} already exists");
        }
        
        book.CreatedAt = DateTime.Now;

        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        
        return ApiResponse<Book>.CreateSuccess(book, "Book created successfully.");
    }

    public async Task<ApiResponse<Book>> UpdateBook(Book book)
    {
        if (book.Price <= 0)
        {
            return ApiResponse<Book>.CreateFailure("Price must be greater than zero");
        }

        if (book.Quantity < 0)
        {
            return ApiResponse<Book>.CreateFailure("Quantity cannot be negative");
        }
        
        var bookExist = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == book.Id);
        if (bookExist == null)
        {
            return ApiResponse<Book>.CreateFailure($"Book with id {book.Id} not found");
        }
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
        return ApiResponse<Book>.CreateSuccess(book, "Book updated successfully.");
    }

    public async Task<ApiResponse<bool>> DeleteBook(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == id);
        if (book == null)
        {
            return ApiResponse<bool>.CreateFailure($"Book with id {id} not found");
        }
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return ApiResponse<bool>.CreateSuccess(true, "Book deleted successfully.");
    }

    public async Task<ApiResponse<IEnumerable<Book>>> SearchBooks(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            var allBooks = await _dbContext.Books.ToListAsync();
            return ApiResponse<IEnumerable<Book>>.CreateSuccess(allBooks, "Search query empty. Returning all books.");
        }
        var books = await _dbContext.Books.Where(x => EF.Functions.Like(x.Title, $"%{search}%")).ToListAsync();
        
        return ApiResponse<IEnumerable<Book>>.CreateSuccess(books, $"Found {books.Count} books matching '{search}'.");
    }

    public async Task<ApiResponse<IEnumerable<Book>>> GetBookByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            return ApiResponse<IEnumerable<Book>>.CreateFailure("Category cannot be empty");
        }
        var books = await _dbContext.Books.Where(x => x.Category == category).ToListAsync();
        return ApiResponse<IEnumerable<Book>>.CreateSuccess(books, $"Found {books.Count} books in category '{category}'.");
        
    }

    public async Task<ApiResponse<IEnumerable<Book>>> GetBookOutOfStock()
    {
        var books = await _dbContext.Books.Where(x => x.Quantity == 0).ToListAsync();
        return ApiResponse<IEnumerable<Book>>.CreateSuccess(books, "Books out of stock retrieved successfully.");
    }
}