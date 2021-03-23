using Hack.JackCompiler.Lib.Tokenization.Matchers;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.JackCompiler.Lib.Tokenization.Extensions
{
    public static class ServiceCollectionExtensions
    {
        /// <summary>
        /// Adds all tokenization services to the IServiceCollection.
        /// The order in which the services are registered matters
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddTokenization(this IServiceCollection services)
        {
            services.AddTransient<JackTokenizer>();
            services.AddTransient<IMatcher, WhitespaceMatcher>();
            services.AddTransient<IMatcher, SingleLineCommentMatcher>();
            services.AddTransient<IMatcher, CodeDocumentationMatcher>();
            services.AddTransient<IMatcher, MultilineCommentMatcher>();
            services.AddTransient<IMatcher, SymbolMatcher>();
            services.AddTransient<IMatcher, KeywordMatcher>();
            services.AddTransient<IMatcher, IdentifierMatcher>();
            services.AddTransient<IMatcher, IntegerConstantMatcher>();
            services.AddTransient<IMatcher, StringConstantMatcher>();

            return services;
        }
    }
}