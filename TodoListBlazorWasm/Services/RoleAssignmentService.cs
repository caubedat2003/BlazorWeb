using System.Net.Http.Json;
using TodoList.Models;

namespace TodoListBlazorWasm.Services
{
    public interface IRoleAssignmentService
    {
        Task<List<PageRoleAssignment>> GetRoleAssignment();
        Task SaveRoleAssignment(List<PageRoleAssignment> assignments);
    }
    public class RoleAssignmentService : IRoleAssignmentService
    {
        private readonly HttpClient _httpClient;
        public RoleAssignmentService (HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<List<PageRoleAssignment>> GetRoleAssignment()
        {
            return await _httpClient.GetFromJsonAsync<List<PageRoleAssignment>>("api/RoleAssignments");
        }
        public async Task SaveRoleAssignment(List<PageRoleAssignment> assignments)
        {
            var respone = await _httpClient.PostAsJsonAsync("api/RoleAssignments/Save", assignments);
            respone.EnsureSuccessStatusCode();
        }
    }
}
