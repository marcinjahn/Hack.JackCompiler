using System.Collections.Generic;
using System.Linq;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Subroutine
{
    public class ClassSubroutineDeclarationParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ClassSubroutineDeclaration;

        public override ParseResult Parse()
        {
            var element = new ClassSubroutineDeclarationElement();
            element
                .Add(ParseKeyword(Keywords.Constructor, Keywords.Function, Keywords.Method))
                .Add(TypeParser.IsValid(Tokens.FirstOrDefault())
                    ? ParseElement(ElementCategory.Type)
                    : ParseKeyword(Keywords.Void))
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.OpeningBrace))
                .Add(ParseOptional(
                    ParameterListParser.IsValid,
                    ElementCategory.ParameterList,
                    new ParameterListElement()))
                .Add(ParseSymbol(Symbols.ClosingBrace))
                .Add(ParseElement(ElementCategory.SubroutineBody));
            
            return new ParseResult(ConsumedTokensCount, element);
        }

        public static bool IsClassSubroutineDeclaration(IToken token)
        {
            return token.TokenType == TokenType.Keyword &&
                   (token.Value == "constructor" || token.Value == "function" || token.Value == "method");
        }

        public ClassSubroutineDeclarationParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }
    }
}