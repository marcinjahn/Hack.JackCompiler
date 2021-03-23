using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class ArrayAccessorParser : ParserBase
    {
        public static bool IsValid(IToken token)
        {
            return token.TokenType == TokenType.Symbol && token.Value == Symbols.OpeningSquareBracket;
        }

        public ArrayAccessorParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ArrayAccessor;

        public override ParseResult Parse()
        {
            var element = new ArrayAccessorElement();
            element
                .Add(ParseSymbol(Symbols.OpeningSquareBracket))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.ClosingSquareBracket));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}