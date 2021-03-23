using Hack.JackCompiler.Lib.Tokenization;
using Hack.JackCompiler.Lib.Tokenization.Matchers;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.JackCompiler.Lib.Files.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFilesUtilities(this IServiceCollection services)
        {
            services.AddTransient<FileUtilitiesFactory>();

            return services;
        }
    }
}