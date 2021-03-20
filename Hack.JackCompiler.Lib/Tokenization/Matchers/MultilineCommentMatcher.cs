using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class MultilineCommentMatcher : MatcherWithRegex
    {
        public MultilineCommentMatcher()
            : base(@"^\/\*.*\*\/")
        { }
        
        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new TokenToIgnore(match.Value, TokenType.MultiLineComment),
                match.Value.Length);
        }
    }
}