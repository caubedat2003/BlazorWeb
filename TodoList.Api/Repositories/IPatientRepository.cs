using TodoList.Api.Entities;

namespace TodoList.Api.Repositories
{
    public interface IPatientRepository
    {
        Task<List<Patient>> GetPatientsList();
        Task<Patient> Create(Patient patient);
        Task<Patient> Update(Patient patient);
        Task<Patient> Delete(Patient patient);
        Task<Patient> GetById(Guid Id);
    }
}
