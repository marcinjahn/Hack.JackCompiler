using System;
using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class IdentifierMatcher : MatcherWithRegex
    {
        public IdentifierMatcher()
            : base(@"^[a-zA-Z_][\w\d_]*")
        { }

        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new Token(match.Value, TokenType.Identifier),
                match.Value.Length);
        }
    }
}