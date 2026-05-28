
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;
namespace LibraryManagementAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Book>Books { get; set; }   
}