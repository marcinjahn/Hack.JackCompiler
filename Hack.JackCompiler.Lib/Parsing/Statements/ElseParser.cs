using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class ElseParser : ParserBase
    {
        public ElseParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ElseStatement;

        public override ParseResult Parse()
        {
            var element = new ElseElement();
            element
                .Add(ParseKeyword(Keywords.Else))
                .Add(ParseSymbol(Symbols.OpeningCurlyBrace))
                .Add(ParseOptional(
                    StatementsParser.IsValid,
                    ElementCategory.Statements,
                    new StatementsElement()))
                .Add(ParseSymbol(Symbols.ClosingCurlyBrace));

            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.Else;
        }
    }
}