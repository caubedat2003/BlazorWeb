using System.Net.Http.Json;
using TodoList.Models;

namespace TodoListBlazorWasm.Services
{
    public class UserApiClient : IUserApiClient
    {
        public HttpClient _httpClient;
        public UserApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> EditRole(Guid id, UserDto request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/users/{id}/role", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<List<AssigneeDto>> GetAssignees()
        {
            var result = await _httpClient.GetFromJsonAsync<List<AssigneeDto>>($"/api/users");
            return result;
        }

        public async Task<UserDto> GetUserDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<UserDto>($"/api/users/{id}");
            return result;
        }

        public async Task<List<UserDto>> GetUsersList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<UserDto>>("/api/users");
            return result;
        }
    }
}
