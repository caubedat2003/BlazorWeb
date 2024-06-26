using TodoList.Models;

namespace TodoListBlazorWasm.Services
{
    public interface IPatientApiClient
    {
        Task<List<PatientRequest>> GetPatientList();
        Task<PatientRequest> GetPatientDetail(string id);
        Task<bool> CreatePatient(PatientRequest request);
        Task<bool> UpdatePatient(Guid id, PatientUpdateRequest request);
        Task<bool> DeletePatient(Guid id);
    }
}
