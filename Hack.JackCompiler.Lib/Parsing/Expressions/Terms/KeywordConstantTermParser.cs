using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Terminal;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class KeywordConstantTermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public KeywordConstantTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ParseResult Parse()
        {
            var token = Tokens.FirstOrDefault();
            if (!IsValid(token))
            {
                // TODO: Use custom exception type
                throw new InvalidOperationException("Provided token is not an integer constant");
            }
            
            Tokens = Tokens.Skip(1);
            ConsumedTokensCount++;

            return new ParseResult(ConsumedTokensCount, new KeywordElement(token.Value));
        }

        public static bool IsValid(IToken token)
        {
            return token.TokenType == TokenType.Keyword &&
                   new[]
                       {
                           Keywords.True, Keywords.False, Keywords.Null, Keywords.This
                       }
                       .Contains(token.Value);
        }
    }
}