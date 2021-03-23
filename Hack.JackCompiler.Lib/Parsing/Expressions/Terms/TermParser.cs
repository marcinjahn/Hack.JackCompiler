using System;
using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Expressions.Terms
{
    public class TermParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Term;

        public TermParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ParseResult Parse()
        {
            var element = new TermElement();
            var termType = ExpressionUtilities.GetTermType(Tokens);
            var exactParser = ParserFactory.Create(termType, Tokens);

            var childResult = exactParser.Parse();
            element.Add(childResult.Element);

            return new ParseResult(childResult.NextTokenIndex, element);
        }

        public static bool IsValid(IToken token)
        {
            return token.TokenType == TokenType.IntegerConst || token.TokenType == TokenType.StringConst ||
                   KeywordConstantTermParser.IsValid(token) || token.TokenType == TokenType.Identifier ||
                   (token.TokenType == TokenType.Symbol && token.Value == Symbols.OpeningBrace) ||
                   UnaryOperatorTermParser.IsValid(token);
        }
    }
}