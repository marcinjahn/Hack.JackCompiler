using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
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
                new Token(
                    match.Value == "<" || match.Value == ">"?
                        HttpUtility.UrlEncode(match.Value) :
                        match.Value,
                    TokenType.Symbol),
                match.Value.Length);
        }
    }
}