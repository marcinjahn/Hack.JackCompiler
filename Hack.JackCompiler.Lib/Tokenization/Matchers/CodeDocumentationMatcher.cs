using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class CodeDocumentationMatcher : MatcherWithRegex
    {
        public CodeDocumentationMatcher()
            : base(@"^\/\*\*.*\*\/")
        { }
        
        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new TokenToIgnore(match.Value, TokenType.CodeDocumentation),
                match.Value.Length);
        }
    }
}