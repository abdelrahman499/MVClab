using Microsoft.AspNetCore.Identity;

namespace MVClab.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string? Adress{ get; set; }
    }
}
