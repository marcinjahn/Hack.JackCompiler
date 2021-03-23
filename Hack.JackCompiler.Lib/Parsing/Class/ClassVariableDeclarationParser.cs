using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Class
{
    public class ClassVariableDeclarationParser : ParserBase
    {
        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.ClassVariableDeclaration;

        public override ParseResult Parse()
        {
            var element = new ClassVariableDeclarationElement();
            element
                .Add(ParseKeyword(Keywords.Static, Keywords.Field))
                .Add(ParseElement(ElementCategory.Type))
                .Add(ParseIdentifier()) //varName
                .Add(ParseZeroOrMore(
                    VariableDeclarationAdditionalParser.IsValid,
                    ElementCategory.AdditionalVariable)) //additional variables
                .Add(ParseSymbol(Symbols.Semicolon));
            
            return new ParseResult(ConsumedTokensCount, element);
        }
        
        public static bool IsClassVariableDeclaration(IToken token)
        {
            return token.TokenType == TokenType.Keyword &&
                   (token.Value == Keywords.Static || token.Value == Keywords.Field);
        }

        public ClassVariableDeclarationParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) 
            : base(tokens, parserFactory)
        {
        }
    }
}