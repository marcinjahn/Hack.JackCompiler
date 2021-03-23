using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class StatementsParser : ParserBase
    {
        public StatementsParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Statements;
        public override ParseResult Parse()
        {
            var element = new StatementsElement();

            element
                .Add(ParseZeroOrMore(
                    new[]
                    {
                        new Tuple<Predicate<IToken>, ElementCategory>(DoStatementParser.IsValid,
                            ElementCategory.DoStatement),
                        new Tuple<Predicate<IToken>, ElementCategory>(IfStatementParser.IsValid,
                            ElementCategory.IfStatement),
                        new Tuple<Predicate<IToken>, ElementCategory>(LetStatementParser.IsValid,
                            ElementCategory.LetStatement),
                        new Tuple<Predicate<IToken>, ElementCategory>(ReturnStatementParser.IsValid,
                            ElementCategory.ReturnStatement),
                        new Tuple<Predicate<IToken>, ElementCategory>(WhileStatementParser.IsValid,
                            ElementCategory.WhileStatement),
                    }));

            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsValid(IToken token)
        {
            return DoStatementParser.IsValid(token) ||
                   IfStatementParser.IsValid(token) ||
                   LetStatementParser.IsValid(token) ||
                   ReturnStatementParser.IsValid(token) ||
                   WhileStatementParser.IsValid(token);
        }
    }
}