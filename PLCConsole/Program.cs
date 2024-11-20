using BKUTSDLL;
using BKUTSDLL.Models;
using BKUTSDLL.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

class Program
{
    static void Main(string[] args)
    {

        
        var builder = new ConfigurationBuilder()
       .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
       .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfiguration configuration = builder.Build();

        
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IConfiguration>(configuration)  
            .AddSingleton(new DatabaseService(configuration.GetConnectionString("DefaultConnection")))  
            .AddTransient<PLCCommand>()  
            .AddTransient<PLCCommandExucutor>()  
            .BuildServiceProvider();

       
        var PLCCommandExucutorService = serviceProvider.GetService<PLCCommandExucutor>();


        PLCCommandExucutorService.ExecuteCommand(PLCBrand.SiemensS71200, "Start");

    }
}

