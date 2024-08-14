using System.Security.Claims;

namespace TodoList.Api.Repositories
{
    public class PageAuthorizationService
    {
        private readonly IRoleAssignmentRepository _roleAssignmentRepository;
        public PageAuthorizationService(IRoleAssignmentRepository roleAssignmentRepository)
        {
            _roleAssignmentRepository = roleAssignmentRepository;
        }
        public async Task<bool> IsUserAuthorizedForPage(string pageName, ClaimsPrincipal user)
        {
            var roles = user.FindAll(ClaimTypes.Role).Select(r => r.Value).ToList();
            if(!roles.Any())
            {
                return false;
            }
            var pageRoleAssignment = await _roleAssignmentRepository.GetPageRoleAssignment(pageName);
            if(pageRoleAssignment == null)
            {
                return false;
            }
            return roles.Any(role =>
                (role == "Admin" && pageRoleAssignment.IsAdmin) ||
                (role == "Receptionist" && pageRoleAssignment.IsReceptionist) ||
                (role == "Doctor" && pageRoleAssignment.IsDoctor) ||
                (role == "Cashier" && pageRoleAssignment.IsCashier) ||
                (role == "Pharmacist" && pageRoleAssignment.IsPharmacist)
            );
        }
    }
}
