namespace DB
{
    public class Result 
    {

        public int ResultId {get;set;}
        public int Ringths {get; set;}
        public int Mistakes {get; set;}
        public string Status {get; set;}
        public string QuestionResult {get; set;} 
        public string UserId { get; set; } // Llave foránea que enlaza con ApplicationUser
        public AplicationUser Users { get; set; } 
    }
}