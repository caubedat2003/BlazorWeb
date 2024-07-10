using TodoList.Api.Entities;
using TodoList.Models;

namespace TodoList.Api.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetUserList();

        Task<User> GetUserById(Guid id);
        Task<User> Create(User user);
        Task<User> Update(User user);
        Task<User> Delete(User user);
    }
}
