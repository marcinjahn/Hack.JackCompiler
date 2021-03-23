using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Subroutine
{
    public class ParameterListParser : ParserBase
    {
        public ParameterListParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ParameterList;

        public override ParseResult Parse()
        {
            var element = new ParameterListElement();
            element
                .Add(ParseElement(ElementCategory.Type))
                .Add(ParseIdentifier())
                .Add(ParseZeroOrMore(
                    ParameterListAdditionalParameterParser.IsValid,
                    ElementCategory.ParameterListAdditionalParameter));

            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            return TypeParser.IsValid(token);
        }
    }
}