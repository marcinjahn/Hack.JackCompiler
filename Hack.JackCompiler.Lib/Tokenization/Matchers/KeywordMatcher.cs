using System.Linq;
using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class KeywordMatcher : MatcherWithRegex
    {
        public KeywordMatcher()
            : base(() =>
            {
                var keywordProps = typeof(Keywords).GetProperties();

                var keywords = keywordProps
                    .Select(keyword => (string) keyword.GetValue(null))
                    .ToList();

                return $"^({string.Join('|', keywords)}) ";
            })
        { }

        protected override MatchResult GetMatchingResult(Match match)
        {
            var value = match.Value;
            return MatchResult.CreateMatching(
                new Token(value.TrimEnd(), TokenType.Keyword),
                value.Length);
        }
    }
}