using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

[ApiController]
[Route("/api/v1")]
public class TestController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateEmptyBuilder(new WebApplicationOptions());
        builder.Logging.AddSimpleConsole(console => { console.SingleLine = true; });
        builder.WebHost.UseKestrel();
        builder.Services.AddRouting(); // Add routing services to the container

        // add controller 
        builder.Services.AddControllers();

        var app = builder.Build();
        app.UseRouting();
        app.MapControllers(); // Enable routing -> controllers mapping

        // middleware


        // sample route
        app.MapGet("/hello-world", () =>
        {
            return "Hello, World!";
        });

        app.UseEndpoints(_ =>
        {

        });
        app.Run();
    }
}