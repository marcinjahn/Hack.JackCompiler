using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions
{
    internal class ExpressionListParser : ParserBase
    {
        public static bool IsValid(IToken token)
        {
            return ExpressionUtilities.IsValid(token);
        }

        public ExpressionListParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ExpressionList;

        public override ParseResult Parse()
        {
            var element = new ExpressionListElement();
            element
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseZeroOrMore(
                    AdditionalExpressionParser.IsValid,
                    ElementCategory.ExpressionListAdditionalElement));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}