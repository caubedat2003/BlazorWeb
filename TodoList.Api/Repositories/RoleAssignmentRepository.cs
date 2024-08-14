using Microsoft.EntityFrameworkCore;
using TodoList.Api.Data;
using TodoList.Models;

namespace TodoList.Api.Repositories
{
    public interface IRoleAssignmentRepository
    {
        Task<List<PageRoleAssignment>> GetRoleAssignments();
        Task SaveRoleAssignments(List<PageRoleAssignment> assignments);
        Task CreateAssignment(PageRoleAssignment assignment);
        Task<PageRoleAssignment> GetPageRoleAssignment(string pageName);
    }
    public class RoleAssignmentRepository : IRoleAssignmentRepository
    {
        private readonly TodoListDbContext _context;
        public RoleAssignmentRepository (TodoListDbContext context)
        {
            _context = context;
        }

        public async Task CreateAssignment(PageRoleAssignment assignment)
        {
            _context.PageRoleAssignments.Add(assignment);
            await _context.SaveChangesAsync();
        }

        public async Task<List<PageRoleAssignment>> GetRoleAssignments()
        {
            return await _context.PageRoleAssignments.ToListAsync();
        }
        public async Task SaveRoleAssignments(List<PageRoleAssignment> assignments)
        {
            foreach(var assignment in assignments)
            {
                _context.Entry(assignment).State = assignment.Id == 0 ? EntityState.Added : EntityState.Modified;
            }
            await _context.SaveChangesAsync();
        }
        public async Task<PageRoleAssignment> GetPageRoleAssignment(string pageName)
        {
            return await _context.PageRoleAssignments.FirstOrDefaultAsync(p => p.PageName == pageName);
        }
    }
}
