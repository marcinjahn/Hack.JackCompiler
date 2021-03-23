using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class ArrayAccessTermParser : ParserBase
    {
        public ArrayAccessTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }
        
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;

        public override ParseResult Parse()
        {
            var element = new ArrayAccessTermElement();
            element
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.OpeningSquareBracket))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.ClosingSquareBracket));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}