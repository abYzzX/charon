using System.IO.Compression;
using Abyzz.Charon.Demo;
using Charon;
using Charon.ContentPipeline;
using Charon.Extensions;
using Charon.Modularity;
using Charon.Sdl3;
using Charon.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Extensions.Logging;

class Program
{
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .AddYamlFile("appsettings.yml", false)
            .AddYamlFile($"appsettings.{Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")}.yml", true)
            .Build();

        var logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .CreateLogger();
        
        InitLogger.Logger = new SerilogLoggerFactory(logger).CreateLogger("Abyzz.Charon.Demo");

        var builder = new CharonGameBuilder()
            .UseSdl3()
            .AddFpsCounter()
            .ConfigureConfiguration(c =>c.AddConfiguration(configuration))
            .ConfigureLogging(l =>
            {
                l.ClearProviders().AddSerilog(logger);
            })
            .UseMainScene<DemoScene>();
        
        var game = builder.Build<CharonDemoModule>();
        game.Initialize();
        game.Run();
    }
}
