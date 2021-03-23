using System.Collections.Generic;
using Hack.JackCompiler.Lib.JackConstants;
using Hack.JackCompiler.Lib.Parsing.Subroutine;
using Hack.JackCompiler.Lib.Tokenization;

namespace Hack.JackCompiler.Lib.Parsing.Class
{
    public class ClassParser : ParserBase
    {
        public ClassParser(IEnumerable<IToken> tokens, ParserFactory parserFactory) : base(tokens, parserFactory)
        {
        }

        public override ElementCategory SupportedElementCategory { get; } = ElementCategory.Class;

        public override ParseResult Parse()
        {
            var element = new ClassElement();
            element
                .Add(ParseKeyword(Keywords.Class))
                .Add(ParseIdentifier())
                .Add(ParseSymbol(Symbols.OpeningCurlyBrace))
                .Add(ParseZeroOrMore(
                    ClassVariableDeclarationParser.IsClassVariableDeclaration,
                    ElementCategory.ClassVariableDeclaration))
                .Add(ParseZeroOrMore(
                    ClassSubroutineDeclarationParser.IsClassSubroutineDeclaration,
                    ElementCategory.ClassSubroutineDeclaration))
                .Add(ParseSymbol(Symbols.ClosingCurlyBrace));
            
            return new ParseResult(ConsumedTokensCount, element);
        }
    }
}