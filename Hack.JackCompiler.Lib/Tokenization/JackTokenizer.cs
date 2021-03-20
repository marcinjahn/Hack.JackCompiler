using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization.Matchers;

namespace Hack.JackCompiler.Lib.Tokenization
{
    public class JackTokenizer
    {
        private readonly IEnumerable<IMatcher> _matchers;

        public JackTokenizer(IEnumerable<IMatcher> matchers)
        {
            _matchers = matchers ?? throw new ArgumentNullException(nameof(matchers));
        }

        public IReadOnlyCollection<IToken> Tokenize(string jackClass)
        {
            if (jackClass == null) throw new ArgumentNullException(nameof(jackClass));

            var result = new TokensCollection();

            var index = 0;
            while (index < jackClass.Length)
            {
                foreach (var matcher in _matchers)
                {
                    var match = matcher.TryMatch(jackClass.Substring(index));
                    if (!match.IsMatching) continue;
            
                    result.Add(match.Token);
                    index += match.NextIndex;
                }
            }

            return result.AsReadOnly();
        }

        private static (bool, int) TryToMatch(string input, IMatcher matcher, TokensCollection result)
        {
            var match = matcher.TryMatch(input);
            if (!match.IsMatching) return (false, 0);
            
            result.Add(match.Token);
            return (true, match.NextIndex);

        }
    }
}