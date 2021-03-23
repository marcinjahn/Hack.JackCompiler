using Hack.JackCompiler.Lib.Parsing.Class;
using Hack.JackCompiler.Lib.Parsing.Expressions;
using Hack.JackCompiler.Lib.Parsing.Expressions.Terms;
using Hack.JackCompiler.Lib.Parsing.Statements;
using Hack.JackCompiler.Lib.Parsing.Subroutine;
using Microsoft.Extensions.DependencyInjection;

namespace Hack.JackCompiler.Lib.Parsing.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddParsing(this IServiceCollection services)
        {
            services.AddTransient<TypeParser>();
            services.AddTransient<ParserFactory>();
            services.AddTransient<ClassParser>();
            services.AddTransient<ClassVariableDeclarationParser>();
            services.AddTransient<VariableDeclarationAdditionalParser>();
            services.AddTransient<AdditionalTermParser>();
            services.AddTransient<ArrayAccessTermParser>();
            services.AddTransient<ExpressionInBracketsTermParser>();
            services.AddTransient<IntegerConstantTermParser>();
            services.AddTransient<KeywordConstantTermParser>();
            services.AddTransient<StringConstantTermParser>();
            services.AddTransient<SubroutineCallTermParser>();
            services.AddTransient<TermParser>();
            services.AddTransient<UnaryOperatorTermParser>();
            services.AddTransient<VarNameTermParser>();
            services.AddTransient<AdditionalExpressionParser>();
            services.AddTransient<ExpressionListParser>();
            services.AddTransient<ExpressionParser>();
            services.AddTransient<SubroutineCallParser>();
            services.AddTransient<ArrayAccessorParser>();
            services.AddTransient<DoStatementParser>();
            services.AddTransient<ElseParser>();
            services.AddTransient<IfStatementParser>();
            services.AddTransient<LetStatementParser>();
            services.AddTransient<ReturnStatementParser>();
            services.AddTransient<WhileStatementParser>();
            services.AddTransient<ClassSubroutineDeclarationParser>();
            services.AddTransient<ParameterListAdditionalParameterParser>();
            services.AddTransient<ParameterListParser>();
            services.AddTransient<SubroutineBodyParser>();
            services.AddTransient<VariableDeclarationParser>();
            services.AddTransient<StatementsParser>();

            services.AddTransient<JackParser>();
            
            return services;
        }
    }
}