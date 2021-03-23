using Hack.JackCompiler.Lib.Parsing.Extensions;
using Hack.JackCompiler.Lib.Tokenization.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.JackCompiler.Lib.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJackCompiler(this IServiceCollection services)
        {
            services.AddTransient<JackCompiler>();
            services.AddTokenization();
            services.AddParsing();

            return services;
        }
    }
}