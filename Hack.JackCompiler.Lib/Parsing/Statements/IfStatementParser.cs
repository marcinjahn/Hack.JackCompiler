using System;
using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class IfStatementParser : ParserBase
    {
        public IfStatementParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.IfStatement;

        public override ParseResult Parse()
        {
            var element = new IfStatementElement();
            element
                .Add(ParseKeyword(Keywords.If))
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseElement(ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.ClosingBrace))
                .Add(ParseSymbol(Symbols.OpeningCurlyBrace))
                .Add(ParseOptional(
                    StatementsParser.IsValid,
                    ElementCategory.Statements,
                    new StatementsElement()))
                .Add(ParseSymbol(Symbols.ClosingCurlyBrace))
                .Add(ParseOptional(
                    ElseParser.IsValid,
                    ElementCategory.ElseStatement));

            return new ParseResult(ConsumedTokensCount, element);
        }
        
        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.If;
        }
    }
}