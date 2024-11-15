using Microsoft.AspNet.Identity.EntityFramework;

namespace AuthApi.Models
{
    public class UserDetails:IdentityUser
    {
        public string Name { get; set; } = null!;
        public string Role { get; set; } = null!;
    }
}
