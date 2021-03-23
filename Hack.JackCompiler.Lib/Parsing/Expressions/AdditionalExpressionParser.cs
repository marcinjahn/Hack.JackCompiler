using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions
{
    public class AdditionalExpressionParser : ParserBase
    {
        public AdditionalExpressionParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } =
            ElementCategory.ExpressionListAdditionalElement;

        public override ParseResult Parse()
        {
            var element = new AdditionalExpressionElement();
            element
                .Add(ParseSymbol(Symbols.Comma))
                .Add(ParseElement(ElementCategory.Expression));

            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            if (token == null) throw new ArgumentNullException(nameof(token));

            return token.TokenType == TokenType.Symbol && token.Value == Symbols.Comma;
        }
    }
}