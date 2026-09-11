namespace Account1.Models
{ 
    public enum AccountType
    {
        Personal,
        Business
    }
    public class User
    {
        public int Id {get; set;}
        public string Name {get; set;} =string.Empty;
        public AccountType Type {get;set;}
        public string? BusinessName {get; set;}
        public string? Country {get; set;}
        public string? Phone {get; set;}
        public string? Email {get; set;}
        public string? TaxId {get; set;}
    }
}