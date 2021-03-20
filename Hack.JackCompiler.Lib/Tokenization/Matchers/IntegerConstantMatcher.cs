using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class IntegerConstantMatcher : MatcherWithRegex
    {
        public IntegerConstantMatcher()
            : base(@"^\d+")
        { }
        
        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new Token(match.Value, TokenType.IntegerConst),
                match.Value.Length);
        }
    }
}