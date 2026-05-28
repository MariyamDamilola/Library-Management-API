namespace LibraryManagementAPI.Models;

public class CreateBookDTO
{
    public string Title { get; set; } = String.Empty;
    
    public string Author { get; set; } = String.Empty;
    
    public string Category { get; set; } = String.Empty;
    
    public int Price { get; set; }
    
    public int Quantity { get; set; }
    
}