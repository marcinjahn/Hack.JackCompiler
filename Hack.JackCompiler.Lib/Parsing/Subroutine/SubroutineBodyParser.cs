using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Statements;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Subroutine
{
    public class SubroutineBodyParser : ParserBase
    {
        public SubroutineBodyParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.SubroutineBody;

        public override ParseResult Parse()
        {
            var element = new SubroutineBodyElement();
            element
                .Add(ParseSymbol(Symbols.OpeningCurlyBrace))
                .Add(ParseZeroOrMore(
                    VariableDeclarationParser.IsValid,
                    ElementCategory.SubroutineBodyVariableDeclaration))
                .Add(ParseOptional(
                    StatementsParser.IsValid,
                    ElementCategory.Statements,
                    new StatementsElement()))
                .Add(ParseSymbol(Symbols.ClosingCurlyBrace));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}