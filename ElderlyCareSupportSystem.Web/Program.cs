using ElderlyCareSupportSystem.Application.Dependency;
using ElderlyCareSupportSystem.Infrastructure.Dependency;
using ElderlyCareSupportSystem.Web.Middlewares;

namespace ElderlyCareSupportSystem.Web;

public static class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        {

            // Add services to the container.

            builder.Services.AddControllersWithViews(options =>
                {
                    options.Filters.Add<GlobalExceptionFilter>();
                })
                .AddRazorOptions(options =>
                {
                    options.ViewLocationFormats.Add("/Modules/{1}/Views/{0}.cshtml");
                    options.ViewLocationFormats.Add("/Modules/{1}/Views/Shared/{0}.cshtml");
                });


            builder.Services.AddRouting(options => { options.LowercaseUrls = true; });
            builder.Services
                .AddApplication()
                .AddInfrastructure(builder.Configuration);
            
            builder.Services.AddAuthentication("ElderlyCareSupportCookie")
                .AddCookie("ElderlyCareSupportCookie", options =>
                {
                    options.LoginPath = "/Auth/Login";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                    options.SlidingExpiration = true;
                });
            builder.Services.AddAuthorization();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
            });
            builder.Services.AddRazorPages();
        }

        var app = builder.Build();
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();
            app.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Authentication}/{action=Login}/{id?}")
                .WithStaticAssets();
            app.MapRazorPages()
                .WithStaticAssets();
        }
        await app.RunAsync();
    }
}