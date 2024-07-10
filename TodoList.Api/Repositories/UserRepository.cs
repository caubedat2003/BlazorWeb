using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Entities;
using TodoList.Models;

namespace TodoList.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoListDbContext _context;
        public UserRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<Entities.User> GetUserById(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> Create(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Update(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> Delete(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
