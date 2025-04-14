using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RashaPrimeWeb.Domain.Entities
{
    public class UserApplication:IdentityUser
    {
        public string Name { get; set; }
    
        public string Family { get; set; }
        
        public string City { get; set; }
    }
}
