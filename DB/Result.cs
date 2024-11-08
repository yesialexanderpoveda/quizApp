namespace DB
{

    public class Result 
    {

        public int ResultId {get;set;}
        public int Ringths {get; set;}
        public int Mistakes {get; set;}
        public string Status {get; set;}
        public string QuestionResult {get; set;} 
        public int UserId {get; set;}
        public Users Users {get; set;}
    }
}