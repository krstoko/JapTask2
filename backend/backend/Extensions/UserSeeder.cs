
using backend.Data;
using backend.Infrastructure.DataContext;
using backend.Models;
using System.Linq;

namespace FirstDotNetProject.Data
{
    public static class DbInitializer
    {
        public static void SeedUser(this DataContext context)
        {
            if (context.Users.Any())
            {
                return;
            }
            var user = new User { Username = "TestUser" };

            CreatePasswordHash("test", out byte[] passwordHash, out byte[] passwordSalt);
            user.Password_Has = passwordHash;
            user.Password_Salt = passwordSalt;
            context.Users.Add(user);
            context.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

    }
}