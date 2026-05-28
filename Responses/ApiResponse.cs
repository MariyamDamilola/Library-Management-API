namespace LibraryManagementAPI.Responses;

public class ApiResponse<B>
{
 
    public bool Success { get; set; }
    
    public string Message { get; set; } = string.Empty;
    
    public B? Data { get; set; }
    
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public static ApiResponse<B> CreateSuccess(B data, string message = "Success")
    {
        return new ApiResponse<B>
        {
            Success = true,
            Message = message,
            Data = data
        };
    }

    public static ApiResponse<B> CreateFailure(string message)
    {
        return new ApiResponse<B>
        {
            Success = false,
            Message = message,
            Data = default
        };
    }
    
    
}