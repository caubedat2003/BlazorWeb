using Blazored.LocalStorage;
using Blazored.Toast;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TodoListBlazorWasm.Services;


namespace TodoListBlazorWasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            builder.Services.AddBlazoredToast();
            builder.Services.AddTransient<ITaskApiClient, TaskApiClient>();
            builder.Services.AddTransient<IUserApiClient, UserApiClient>();
            builder.Services.AddTransient<IPatientApiClient, PatientApiClient>();
            builder.Services.AddTransient<IProceduresService, ProceduresService>();
            builder.Services.AddTransient<IRoleAssignmentService, RoleAssignmentService>();
            builder.Services.AddTransient<PageAuthorizationClient, PageAuthorizationClient>();
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<AuthenticationStateProvider, ApiAuthenticationStateProvider>();
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped(sp => new HttpClient { 
                BaseAddress = new Uri(builder.Configuration["BackendApiUrl"])
            });
            await builder.Build().RunAsync();
        }
    }
}
