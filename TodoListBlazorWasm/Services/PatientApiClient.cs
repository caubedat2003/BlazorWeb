using System.Net.Http.Json;
using System.Text.Json;
using TodoList.Models;

namespace TodoListBlazorWasm.Services
{
    public class PatientApiClient : IPatientApiClient
    {
        public readonly HttpClient _httpClient;
        public PatientApiClient(HttpClient httpClient) 
        { 
            _httpClient = httpClient;
        }

        public async Task<bool> CreatePatient(PatientRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("api/patient", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeletePatient(Guid id)
        {
            var result = await _httpClient.DeleteAsync($"api/patient/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<PatientRequest> GetPatientDetail(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<PatientRequest>($"api/patient/{id}");
            return result; 
        }

        public async Task<List<PatientRequest>> GetPatientList()
        {
            var result = await _httpClient.GetFromJsonAsync<List<PatientRequest>>("api/patient");
            return result;
        }

        public async Task<bool> UpdatePatient(Guid id, PatientUpdateRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/patient/{id}", request);
            return result.IsSuccessStatusCode;
        }
    }
}
