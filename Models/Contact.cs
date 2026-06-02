namespace LibraryManagementAPI.Models;

public class Contact
{
    private string _number;
    
    public int Id { get; set; }
    public string Name { get; set; }
    public string Network { get; set; }
    
    
    public string Number
    {
        get
        {
            return _number;
        }
        set
        {
            _number = value;
            
            Network = AssignNetworkByPrefix(value);
        }
        
    }

    private string AssignNetworkByPrefix(string phoneNumber)
    {
        //If the number is empty or too short
        if (string.IsNullOrWhiteSpace(phoneNumber) || phoneNumber.Length != 11)
        {
            return "Unknown";
        }
        
        //Extract the first 4 caracters
        string prefix = phoneNumber.Substring(0, 4);

        return prefix switch
        {
            "0803" or "0806" or "0813" or "0816" or "0903" => "MTN",

            "0802" or "0808" or "0812" or "0708" or "0902" => "Airtel",

            "0805" or "0807" or "0811" or "0815" or "0905" => "Glo",
            _ => "Unknown" // If it matches nothing throw unknown
        };
    }
    
}