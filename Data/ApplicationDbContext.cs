
using Microsoft.EntityFrameworkCore;
using LibraryManagementAPI.Models;
namespace LibraryManagementAPI.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    public DbSet<Book>Books { get; set; } 
    
    public DbSet<Contact>Contacts { get; set; }

    /*protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasData(
        new Book
        {
            Id = 1,
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Category = "Programming",
            Price = 15000,
            Quantity = 10,
            CreatedAt = new DateTime(2025, 1, 1)
        },
        new Book
        {
            Id = 2,
            Title = "The Pragmatic Programmer",
            Author = "Andrew Hunt",
            Category = "Programming",
            Price = 18000,
            Quantity = 8,
            CreatedAt = new DateTime(2025, 1, 2)
        },
        new Book
        {
            Id = 3,
            Title = "Atomic Habits",
            Author = "James Clear",
            Category = "Self Development",
            Price = 12000,
            Quantity = 15,
            CreatedAt = new DateTime(2025, 1, 3)
        },
        new Book
        {
            Id = 4,
            Title = "Think and Grow Rich",
            Author = "Napoleon Hill",
            Category = "Business",
            Price = 10000,
            Quantity = 12,
            CreatedAt = new DateTime(2025, 1, 4)
        },
        new Book
        {
            Id = 5,
            Title = "Rich Dad Poor Dad",
            Author = "Robert Kiyosaki",
            Category = "Finance",
            Price = 9500,
            Quantity = 20,
            CreatedAt = new DateTime(2025, 1, 5)
        },
        new Book
        {
            Id = 6,
            Title = "The Alchemist",
            Author = "Paulo Coelho",
            Category = "Fiction",
            Price = 8500,
            Quantity = 7,
            CreatedAt = new DateTime(2025, 1, 6)
        },
        new Book
        {
            Id = 7,
            Title = "Introduction to Algorithms",
            Author = "Thomas H. Cormen",
            Category = "Programming",
            Price = 25000,
            Quantity = 5,
            CreatedAt = new DateTime(2025, 1, 7)
        },
        new Book
        {
            Id = 8,
            Title = "Deep Work",
            Author = "Cal Newport",
            Category = "Productivity",
            Price = 11000,
            Quantity = 18,
            CreatedAt = new DateTime(2025, 1, 8)
        },
        new Book
        {
            Id = 9,
            Title = "The Psychology of Money",
            Author = "Morgan Housel",
            Category = "Finance",
            Price = 13000,
            Quantity = 25,
            CreatedAt = new DateTime(2025, 1, 9)
        },
        new Book
        {
            Id = 10,
            Title = "Zero to One",
            Author = "Peter Thiel",
            Category = "Business",
            Price = 14000,
            Quantity = 9,
            CreatedAt = new DateTime(2025, 1, 10)
        }
    );

        modelBuilder.Entity<Contact>().HasData(
            new Contact
            {
                Id = 101,
                Name = "Chidi Okafor",
                Number = "08031234567",
                Network = "MTN"
            },
            new Contact
            {
                Id = 102,
                Name = "Amina Bello",
                Number = "08023334455",
                Network = "Airtel"
            },
            new Contact
            {
                Id = 103,
                Name = "Olumide Bakare",
                Number = "08055556677",
                Network = "Glo"
            },
            new Contact
            {
                Id = 104,
                Name = "Blessing Johnson",
                Number = "08069876543",
                Network = "MTN"
            },
            new Contact
            {
                Id = 105,
                Name = "Emeka Nwosu",
                Number = "08087776655",
                Network = "Airtel"
            },
            new Contact
            {
                Id = 106,
                Name = "Fatima Musa",
                Number = "08071239874",
                Network = "Glo"
            },
            new Contact
            {
                Id = 107,
                Name = "Tunde Adeniran",
                Number = "08135554433",
                Network = "MTN"
            },
            new Contact
            {
                Id = 108,
                Name = "Yetunde Adesina",
                Number = "08121112233",
                Network = "Airtel"
            },
            new Contact
            {
                Id = 109,
                Name = "Funmi Balogun",
                Number = "08119990011",
                Network = "Glo"
            },
            new Contact
            {
                Id = 110,
                Name = "Chioma Nnaji",
                Number = "07084445566",
                Network = "Airtel"
                
            }
        );*/
    }

    
    
