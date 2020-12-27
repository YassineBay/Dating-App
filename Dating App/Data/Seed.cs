using Dating_App.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Data
{
    public class Seed
    {
        private readonly ApplicationContext _context;
        public Seed(ApplicationContext context)
        {
            _context = context;
        }

        public void SeedUsers()
        {
           // _context.Users.RemoveRange(_context.Users);
           // _context.SaveChanges();

            //seed users
            var userData = System.IO.File.ReadAllText("Data/UserSeed.json");
            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            foreach (var user in users)
            {
                //create the password hash
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash("password", out passwordHash, out passwordSalt);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.Username = user.Username.ToLower();
                _context.Users.Add(user);
            }
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
