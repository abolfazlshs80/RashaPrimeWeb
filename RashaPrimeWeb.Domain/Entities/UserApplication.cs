using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace RashaPrimeWeb.Domain.Entities
{
    public class UserApplication:IdentityUser
    {
        public string FirstName { get; set; }
    
        public string LastName { get; set; }

    }
}
