using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class SingleLineCommentMatcher : MatcherWithRegex
    {
        public SingleLineCommentMatcher()
            : base(@"^\/\/.*")
        { }
        
        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new TokenToIgnore(match.Value, TokenType.SingleLineComment),
                match.Value.Length);
        }
    }
}