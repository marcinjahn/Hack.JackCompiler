using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Terminal;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing
{
    public class TypeParser : ParserBase
    {
        public TypeParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;

        public override ParseResult Parse()
        {
            var token = Tokens.FirstOrDefault();

            IElement element = token?.TokenType switch
            {
                TokenType.Keyword when token.Value == Keywords.Int || 
                                       token.Value == Keywords.Char ||
                                       token.Value == Keywords.Boolean => 
                    new KeywordElement(token.Value),
                TokenType.Identifier => 
                    new IdentifierElement(token.Value),
                _ => 
                    throw new InvalidOperationException("Provided token is not a type")
            };

            return new ParseResult(1, element);
        }

        public static bool IsValid(IToken token)
        {
            if (token == null) throw new ArgumentNullException(nameof(token));
            return (token.TokenType == TokenType.Keyword && (token.Value == Keywords.Int ||
                                                             token.Value == Keywords.Char ||
                                                             token.Value == Keywords.Boolean)) ||
                   token.TokenType == TokenType.Identifier;
        }
    }
}