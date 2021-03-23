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
                var codeToTokenize = jackClass.Substring(index);
                var foundMatch = false;
                
                foreach (var matcher in _matchers)
                {
                    var match = matcher.TryMatch(codeToTokenize);
                    if (!match.IsMatching) continue;

                    foundMatch = true;
                    result.Add(match.Token);
                    index += match.NextIndex;
                    break;
                }

                if (!foundMatch)
                {
                    // TODO: Throw custom exception
                    throw new Exception("The given code cannot be tokenized");
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