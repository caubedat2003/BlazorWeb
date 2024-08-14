using System.Net.Http.Json;
using System.Security.Claims;

namespace TodoListBlazorWasm.Services
{
    public class PageAuthorizationClient
    {
        private readonly HttpClient _httpClient;
        public PageAuthorizationClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> IsUserAuthorizedForPage(string pageName, ClaimsPrincipal user)
        {
            var response = await _httpClient.GetFromJsonAsync<bool>($"/api/Authorization/IsUserAuthorizedForPage/{pageName}");
            return response;
        }
    }
}
