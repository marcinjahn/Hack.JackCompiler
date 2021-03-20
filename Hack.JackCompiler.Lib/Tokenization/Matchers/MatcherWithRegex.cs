using System;
using System.Text.RegularExpressions;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public abstract class MatcherWithRegex : IMatcher
    {
        private readonly Regex _regex;

        protected MatcherWithRegex(string regexPattern)
        {
            _regex = new Regex(regexPattern);
        }
        
        protected MatcherWithRegex(Func<string> regexPatternGenerator)
            : this(regexPatternGenerator())
        { }

        public MatchResult TryMatch(string input)
        {
            var match = _regex.Match(input);
            return match.Success ? 
                GetMatchingResult(match) : 
                MatchResult.CreateNotMatching();
        }

        protected abstract MatchResult GetMatchingResult(Match match);
    }
}