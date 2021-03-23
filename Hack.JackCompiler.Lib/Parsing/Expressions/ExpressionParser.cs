using System.Collections.Generic;
using Hack.JackCompiler.Lib.Parsing.Expressions.Terms;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions
{
    public class ExpressionParser : ParserBase
    {
        public ExpressionParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Expression;

        public override ParseResult Parse()
        {
            var element = new ExpressionElement();
            element
                .Add(ParseElement(ElementCategory.Term))
                .Add(ParseZeroOrMore(AdditionalTermParser.IsValid,
                    ElementCategory.AdditionalExpressionTerm));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}