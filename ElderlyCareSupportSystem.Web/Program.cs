using ElderlyCareSupportSystem.Application.Dependency;
using ElderlyCareSupportSystem.Infrastructure.Dependency;
using ElderlyCareSupportSystem.Web.Middlewares;

namespace ElderlyCareSupportSystem.Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

              
        
        // Add services to the container.
        
        builder.Services.AddControllersWithViews();
        
        
        builder.Services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });  
        builder.Services
            .AddApplication()
            .AddInfrastructure(builder.Configuration);
        
        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseRouting();
        
        app.UseMiddleware<GlobalExceptionMiddleware>();
        
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapStaticAssets();
        app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
            .WithStaticAssets();
        app.MapRazorPages()
            .WithStaticAssets();

        await app.RunAsync();
    }
}