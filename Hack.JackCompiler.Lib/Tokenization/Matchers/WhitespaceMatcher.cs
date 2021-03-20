using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class WhitespaceMatcher : MatcherWithRegex
    {
        public WhitespaceMatcher()
            : base(@"^[\s|\r\n|\r|\n]+")
        { }
        
        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new TokenToIgnore(match.Value, TokenType.Whitespace),
                match.Value.Length);
        }
    }
}