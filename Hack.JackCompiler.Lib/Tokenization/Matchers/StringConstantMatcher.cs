using System;
using System.Text.RegularExpressions;
using Hack.JackCompiler.Lib.JackConstants;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class StringConstantMatcher : MatcherWithRegex
    {
        public StringConstantMatcher()
            : base("^\".*\"")
        { }

        protected override MatchResult GetMatchingResult(Match match)
        {
            return MatchResult.CreateMatching(
                new Token(match.Value.Trim('"'), TokenType.StringConst),
                match.Value.Length);
        }
    }
}