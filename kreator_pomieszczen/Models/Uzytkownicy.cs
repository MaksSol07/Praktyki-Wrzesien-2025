using Microsoft.AspNetCore.Identity;

namespace kreator_pomieszczen.Models
{
    public class Uzytkownicy : IdentityUser
    {
        public string? PelnaNazwa { get; set; } 
    }
}
