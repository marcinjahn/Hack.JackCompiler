using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Expressions;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Statements
{
    public class ReturnStatementParser : ParserBase
    {
        public ReturnStatementParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.LetStatement;

        public override ParseResult Parse()
        {
            var element = new ReturnStatementElement();
            element
                .Add(ParseKeyword(Keywords.Return))
                .Add(ParseOptional(
                    ExpressionUtilities.IsValid,
                    ElementCategory.Expression))
                .Add(ParseSymbol(Symbols.Semicolon));

            return new ParseResult(ConsumedTokensCount, element);
        }
        
        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.Return;
        }
    }
}