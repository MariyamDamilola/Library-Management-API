using LibraryManagementAPI.Data;
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;

namespace LibraryManagementAPI.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;

    public BookRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        var books = await _dbContext.Books.ToListAsync();
        return books;

    }

    public async Task<Book> GetBookById(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == id);
        if (book == null)
        {
            throw new Exception($"Book with id {id} not found");
        }

        return book;
    }

    public async Task<Book> CreateBook(CreateBookDTO createBookDto)
    {
        var bookexist = await _dbContext.Books.AnyAsync(x=> x.Title == createBookDto.Title);
        if (bookexist)
        {
            throw new Exception($"Book with title {createBookDto.Title} already exists");
        }

        if (createBookDto.Price <= 0)
        {
            throw new Exception("Price must be greater than zero");
        }

        if (createBookDto.Quantity < 0)
        {
            throw new Exception("Quantity cannot be negative");
        }

        var book = new Book()
        {

            Title = createBookDto.Title,

            Author = createBookDto.Author,

            Category = createBookDto.Category,

            Price = createBookDto.Price,

            Quantity = createBookDto.Quantity,

            CreatedAt = DateTime.Now,
        };
      
       

        await _dbContext.Books.AddAsync(book);
        await _dbContext.SaveChangesAsync();
        
        return book;
    }

    public async Task<Book> UpdateBook(int id, CreateBookDTO createBookDto)
    {
        if (createBookDto.Price <= 0)
        {
            throw new Exception("Price must be greater than zero");
        }

        if (createBookDto.Quantity < 0)
        {
            throw new Exception("Quantity cannot be negative");
        }
        
        var bookExist = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == id);
        if (bookExist == null)
        {
            throw new Exception($"Book with id {id} not found");
        }
        
        bookExist.Title = createBookDto.Title;
        bookExist.Author = createBookDto.Author;
        bookExist.Category = createBookDto.Category;
        bookExist.Price = createBookDto.Price;
        bookExist.Quantity = createBookDto.Quantity;
        
        
        await _dbContext.SaveChangesAsync();
        return bookExist;
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _dbContext.Books.FirstOrDefaultAsync(x=> x.Id == id);
        if (book == null)
        {
            throw new Exception($"Book with id {id} not found");
        }
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<Book>> SearchBooks(string search)
    {
        if (string.IsNullOrEmpty(search))
        {
            return await _dbContext.Books.ToListAsync();
           
        }
        return await _dbContext.Books.Where(x => EF.Functions.Like(x.Title, $"%{search}%")).ToListAsync();
        
    }

    public async Task<IEnumerable<Book>> GetBookByCategory(string category)
    {
        if (string.IsNullOrEmpty(category))
        {
            throw new Exception("Category cannot be empty");
        }
        return await _dbContext.Books.Where(x => x.Category == category).ToListAsync();
        
    }

    public async Task<IEnumerable<Book>> GetBookOutOfStock()
    {
        return await _dbContext.Books.Where(x => x.Quantity == 0).ToListAsync();
    }
}