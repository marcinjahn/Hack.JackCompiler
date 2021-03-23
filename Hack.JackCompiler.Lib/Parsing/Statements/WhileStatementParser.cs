using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class WhileStatementParser: ParserBase
    {
        public WhileStatementParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.WhileStatement;

        public override ParseResult Parse()
        {
            var element = new WhileStatementElement();
            element
                .Add(ParseKeyword(Keywords.While))
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.ClosingBrace))
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
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.While;
        }
    }
}