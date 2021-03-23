using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class UnaryOperatorTermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public UnaryOperatorTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ParseResult Parse()
        {
            var element = new UnaryOperatorTermElement();
            element
                .Add(ParseSymbol(Symbols.Minus, Symbols.Tilde))
                .Add(ParseElement(ElementCategory.Term));

            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            return token.TokenType == TokenType.Symbol &&
                   (token.Value == Symbols.Minus || token.Value == Symbols.Tilde);
        }
    }
}