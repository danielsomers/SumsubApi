// See https://aka.ms/new-console-template for more information
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


public class Program
{
    public static async Task Main(string[] args)
    {
        var webHost = CreateHostBuilder(args).Build();

        await InitializeDatabase(webHost);

        await webHost.RunAsync();
    }

    private static async Task InitializeDatabase(IHost webHost)
    {
        using (var scope = webHost.Services.CreateScope())
        {
            //var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //await context.Database.MigrateAsync();

        }
    }

    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args);
    //.ConfigureWebHostDefaults(webBuilder =>
    // {
    //   webBuilder.UseStartup<Startup>();
    //});
}