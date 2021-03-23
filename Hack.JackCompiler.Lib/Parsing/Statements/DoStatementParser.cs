using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class DoStatementParser : ParserBase
    {
        public DoStatementParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.DoStatement;

        public override ParseResult Parse()
        {
            var element = new DoStatementElement();
            element
                .Add(ParseKeyword(Keywords.Do))
                .Add(ParseElement(ElementCategory.SubroutineCall))
                .Add(ParseSymbol(Symbols.Semicolon));

            return new ParseResult(ConsumedTokensCount, element);
        }
        
        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.Do;
        }
    }
}