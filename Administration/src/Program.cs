using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class DependentService
{
    public DependentService()
    {
        Console.WriteLine("DependentService created");
    }
}

public class TestService
{
    public DependentService dependentService;

    public TestService(DependentService dependentService)
    {
        this.dependentService = dependentService;
        Console.WriteLine("TestService created");
    }
    public void Test()
    {
        Console.WriteLine("Test");
    }
}

public class AdminConfig
{
    public string AdminName { get; set; }

}

public class Program
{
    public static void Main(string[] args)
    {
        ConfigurationManager configManager = new ConfigurationManager();
        configManager.AddEnvironmentVariables("PREFIX_");

        var host = Host.CreateEmptyApplicationBuilder(new HostApplicationBuilderSettings
        {
            Configuration = configManager
        });

        // map env vars to AdminConfig
        host.Services.Configure<AdminConfig>(host.Configuration.GetSection("Admin"));

        host.Services.AddSingleton<TestService>();

        var app = host.Build();
        app.Run();

        // // DI
        // // Starts off with a ServiceCollection
        // ServiceCollection collections = new ServiceCollection();
        // // This will add a singleton of TestService to the collection
        // // Throughout the lifetime of the application, there will only be one instance of TestService
        // collections.AddSingleton<TestService>();
        // collections.AddSingleton<DependentService>();

        // // Builds the collection
        // var provider = collections.BuildServiceProvider();

        // // Get instance of TestService
        // var testService = provider.GetService<TestService>();
        // testService.Test();

        // // scoping services
        // using (var scope = provider.CreateScope())
        // {
        //     var scopedService = scope.ServiceProvider.GetService<TestService>();
        //     scopedService.Test();
        // }

        // using (var scope = provider.CreateScope())
        // {
        //     var scopedService = scope.ServiceProvider.GetService<TestService>();
        //     scopedService.Test();
        // }

        // AddSingleton - Only one instance of the service is created
        // AddScoped - A new instance of the service is created for each scope
        // AddTransient - A new instance of the service is created each time it is requested
    }
}