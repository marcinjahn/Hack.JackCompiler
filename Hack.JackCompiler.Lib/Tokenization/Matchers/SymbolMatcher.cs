using System.Linq;
using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class SymbolMatcher : MatcherWithRegex
    {
        public SymbolMatcher()
            : base(() =>
            {
                var symbolProps = typeof(Symbols).GetProperties();

                var symbols = 
                    symbolProps
                        .Select(symbol => (string) symbol.GetValue(null))
                        .ToList();

                return $"^({string.Join('|', symbols.Select(Regex.Escape))})";
            })
        { }

        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new Token(GetValue(match.Value), TokenType.Symbol),
                match.Value.Length);
        }

        private static string GetValue(string rawValue)
        {
            return rawValue switch
            {
                "<" => "&lt;",
                ">" => "&gt;",
                "\"" => "&quot;",
                "&" => "&amp;",
                _ => rawValue
            };
        }
    }
}