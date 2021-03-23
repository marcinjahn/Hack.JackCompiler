using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class ExpressionInBracketsTermParser : ParserBase
    {
        public ExpressionInBracketsTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;
        
        public override ParseResult Parse()
        {
            var element = new ExpressionInBracketsTermElement();
            element
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.ClosingBrace));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}