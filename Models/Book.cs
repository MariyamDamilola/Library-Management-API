using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagementAPI.Models;

public class Book
{
    public int Id { get; set; }
    
    public string Title { get; set; } = String.Empty;
    
    public string Author { get; set; } = String.Empty;
    
    public string Category { get; set; } = String.Empty;
    
    public int Price { get; set; }
    
    public int Quantity { get; set; }
    
    public DateTime CreatedAt { get; set; }
}