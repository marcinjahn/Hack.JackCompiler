using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class LetStatementParser : ParserBase
    {
        public LetStatementParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.LetStatement;

        public override ParseResult Parse()
        {
            var element = new LetStatementElement();
            element
                .Add(ParseKeyword(Keywords.Let))
                .Add(ParseIdentifier())
                .Add(ParseOptional(
                    ArrayAccessorParser.IsValid,
                    ElementCategory.ArrayAccessor))
                .Add(ParseSymbol(Symbols.Equal))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.Semicolon));

            return new ParseResult(ConsumedTokensCount, element);
        }
        
        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.Let;
        }
    }
}