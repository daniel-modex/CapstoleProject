using AuthApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace AuthApi.Data
{
    public class AuthApiContext : IdentityDbContext<UserDetails>
    {
        public AuthApiContext(DbContextOptions<AuthApiContext> options) : base(options) { }


    }
}
