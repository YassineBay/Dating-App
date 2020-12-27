using Dating_App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dating_App.Data
{
    public class DatingRepository : IDatingRepository<User>
    {
        private readonly ApplicationContext _context;
        public DatingRepository(ApplicationContext context)
        {
            _context = context;
        }
        public void Add(User entity)
        {
            _context.Add(entity);
        }

        public void Delete(User entity)
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(user => user.Photos).FirstOrDefaultAsync(user => user.Id == id);
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(user => user.Photos).ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
