using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DB
{
    public class AplicationUser: IdentityUser 
    {
        public ICollection<GroupQuestions> Groups {get; set;}
        public ICollection<Result> Results {get; set;}
        
    }
}