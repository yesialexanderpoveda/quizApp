
namespace DB
{
    public class Users 
    {
        public int UserId { get; set; }
        public string NameUser {get; set;}
        public string Password {get; set;} 
        public ICollection<Result> Results {get; set;}
    }
}