using TodoList.Models;

namespace TodoListBlazorWasm.Services
{
    public interface IUserApiClient
    {
        Task<List<AssigneeDto>> GetAssignees();
        Task<List<UserDto>> GetUsersList();
        Task<UserDto> GetUserDetail(string id);
        Task<bool> EditRole(Guid id, UserDto request);
    }
}
