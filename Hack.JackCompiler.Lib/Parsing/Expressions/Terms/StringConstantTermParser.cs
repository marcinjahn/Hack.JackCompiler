using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class StringConstantTermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public override ParseResult Parse()
        {
            var token = Tokens.FirstOrDefault();
            if (token?.TokenType != TokenType.StringConst)
            {
                // TODO: Use custom exception type
                throw new InvalidOperationException("Provided token is not an integer constant");
            }
            
            Tokens = Tokens.Skip(1);
            ConsumedTokensCount++;

            return new ParseResult(ConsumedTokensCount, new StringConstantTermElement(token.Value));
        }

        public StringConstantTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }
    }
}