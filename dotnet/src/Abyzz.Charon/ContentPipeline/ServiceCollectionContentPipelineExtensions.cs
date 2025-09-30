using Microsoft.Extensions.DependencyInjection;

namespace Charon.ContentPipeline;

public static class ServiceCollectionContentPipelineExtensions
{
    public static IServiceCollection AddFileSystemContentPipeline(this IServiceCollection services,
        Action<FileSystemContentManagerSettings>? configure = null)
    {
        if (configure != null)
        {
            services.Configure(configure);
        }

        services.AddScoped<IContentManager, FileSystemContentManager>();
        return services;
    }
}
