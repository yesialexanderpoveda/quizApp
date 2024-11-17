using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DB
{
    public class AplicationUser: IdentityUser 
    {
        public ICollection<Result> Results {get; set;}
    }
}