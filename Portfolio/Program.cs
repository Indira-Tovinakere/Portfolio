using Application.Services;
using Domain.Interfaces.IRepository;
using Domain.Interfaces.IServices;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Portfolio.Data;
using Presentation.Controller;
class Prg
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();
        ConfigureServices(services);
        var serviceProvider = services.BuildServiceProvider();

        //If you have a controller or entry point
        var app = serviceProvider.GetRequiredService<Controller>();
        app.Run();
    }
    private static void ConfigureServices(ServiceCollection services)
    {
        string connectionString = "server=127.0.0.1;port=3316;user=root;password=Kalpa84#;database=PORTFOLIO;";
        services.AddDbContext<PortfolioContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        //Register Repositories (Infrastructure)
        services.AddScoped<IRepository, Repository>();

        //Register Services (Application)
        services.AddScoped<IService, Services>();

        //Register Controller or UI Entry Point (Optional)
        services.AddTransient<Controller>();
    }
}