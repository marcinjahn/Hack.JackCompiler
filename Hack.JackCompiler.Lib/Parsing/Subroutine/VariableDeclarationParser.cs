using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Class;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Subroutine
{
    public class VariableDeclarationParser : ParserBase
    {
        public static bool IsValid(IToken token)
        {
            return token?.TokenType == TokenType.Keyword && token.Value == Keywords.Var;
        }

        public VariableDeclarationParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } =
            ElementCategory.SubroutineBodyVariableDeclaration;

        public override ParseResult Parse()
        {
            var element = new VariableDeclarationElement();
            element
                .Add(ParseKeyword(Keywords.Var))
                .Add(ParseElement(ElementCategory.Type))
                .Add(ParseIdentifier())
                .Add(ParseZeroOrMore(
                    VariableDeclarationAdditionalParser.IsValid,
                    ElementCategory.AdditionalVariable)) //additional variables
                .Add(ParseSymbol(Symbols.Semicolon));

            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}