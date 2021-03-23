using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions
{
    public class SubroutineCallParser : ParserBase
    {
        public SubroutineCallParser(IEnumerable<IToken> tokens, ParserFactory parserFactory)
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.SubroutineCall;

        public override ParseResult Parse()
        {
            var element = new SubroutineCallElement();
            if (Tokens.ElementAt(1).Value == Symbols.OpeningBrace)
            {
                ParseOwnSubroutineCall(element);
            }
            else
            {
                ParseExternalSubroutineCall(element);
            }

            return new ParseResult(ConsumedTokensCount, element);
        }

        private void ParseOwnSubroutineCall(SubroutineCallElement element)
        {
            element
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseOptional(
                    ExpressionListParser.IsValid,
                    ElementCategory.ExpressionList,
                    new ExpressionListElement()))
                .Add(ParseSymbol(Symbols.ClosingBrace));
        }
        
        private void ParseExternalSubroutineCall(SubroutineCallElement element)
        {
            element
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.Dot))
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseOptional(
                    ExpressionListParser.IsValid,
                    ElementCategory.ExpressionList,
                    new ExpressionListElement()))
                .Add(ParseSymbol(Symbols.ClosingBrace));
        }
    }
}