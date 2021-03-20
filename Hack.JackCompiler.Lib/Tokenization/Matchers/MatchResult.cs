using System;

namespace Hack.JackCompiler.Lib.Tokenization.Matchers
{
    public class MatchResult
    {
        public IToken Token { get; init; }
        public bool IsMatching { get; init; }
        public int NextIndex { get; init; }

        public static MatchResult CreateMatching(IToken token, int nextIndex)
        {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return new MatchResult
            {
                Token = token,
                NextIndex = nextIndex,
                IsMatching = true
            };
        }

        public static MatchResult CreateNotMatching()
        {
            return new MatchResult
            {
                IsMatching = false
            };
        }
    }
}