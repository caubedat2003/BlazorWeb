using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Api.Entities;

namespace TodoList.Api.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly TodoListDbContext _context;
        public PatientRepository(TodoListDbContext context)
        {
            _context = context;
        }
        public async Task<Patient> Create(Patient patient)
        {
            await _context.Patients.AddAsync(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> Delete(Patient patient)
        {
            _context.Patients.Remove(patient);
            await _context.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> GetById(Guid Id)
        {
            return await _context.Patients.FindAsync(Id);
        }

        public async Task<List<Patient>> GetPatientsList()
        {
            var query = _context.Patients.AsQueryable();
            return await query.OrderByDescending(x=>x.CreatedDate).ToListAsync();
        }

        public async Task<Patient> Update(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
            return patient;
        }
    }
}
