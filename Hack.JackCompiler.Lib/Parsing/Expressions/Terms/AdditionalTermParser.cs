using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class AdditionalTermParser : ParserBase
    {
        public static bool IsValid(IToken token)
        {
            return token.TokenType == TokenType.Symbol && (
                GetOperators().Contains(token.Value));
        }

        public AdditionalTermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;

        public override ParseResult Parse()
        {
            var element = new AdditionalTermElement();
            element
                .Add(ParseSymbol(GetOperators().ToArray()))
                .Add(ParseElement(ElementCategory.Term));

            return new ParseResult(ConsumedTokensCount, element);
        }

        private static IEnumerable<string> GetOperators() =>
            new[]
            {
                Symbols.Plus, Symbols.Minus, Symbols.Star, Symbols.Slash, Symbols.Ampersand, Symbols.Pipe,
                Symbols.LessThan, Symbols.GreaterThan, Symbols.Equal
            };
    }
}